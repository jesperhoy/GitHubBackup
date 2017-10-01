Module Module1

  Private cfg As Config
  Private Log As System.Text.StringBuilder = New System.Text.StringBuilder
  Private BadExit As Boolean = False
  Private BaseDir As String

  Sub Main()
    LogLine("Process started at " & Now.ToString)

    BaseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

    REM read config file
    Dim x As String
    Try
      x = My.Computer.FileSystem.ReadAllText(BaseDir & "\config.json")
    Catch ex As System.IO.FileNotFoundException
      Console.WriteLine("Configuration file (""config.json"") not found.")
      Environment.ExitCode = 2
      Exit Sub
    End Try
    cfg = Config.DeSerialize(x)

    Dim lst = GetReposFromGitHub()
    If BadExit Then GoTo markDone

    For Each r In lst
      DoRepo(r)
      If BadExit Then GoTo markDone
    Next

markDone:
    LogSeparator()
    LogLine("Process ended at " & Now.ToString)

    If cfg.LogFiles Then
      Dim LogFile = BaseDir & "\logs\" & Now.ToString("yyyyMMddHHmmss") & ".log"
      LogSeparator()
      LogLine("Writing log-file """ & LogFile & """")
      Try
        My.Computer.FileSystem.CreateDirectory(BaseDir & "\logs")
        My.Computer.FileSystem.WriteAllText(LogFile, Log.ToString, False)
      Catch ex As Exception
        LogLine("*** Exception writing log file:  " & ex.Message)
        BadExit = True
      End Try
    End If

    If If(BadExit, cfg.EmailFailure, cfg.EmailSuccess) Then
      LogSeparator()
      LogLine("Sending e-mail notification to " & cfg.EmailTo)
      Try
        cfg.SendEmail(If(BadExit, cfg.EmailFailureSubject, cfg.EmailSuccessSubject), Log.ToString)
      Catch ex As Exception
        LogLine("*** Exception sending e-mail notification: " & ex.Message)
        BadExit = True
      End Try
    End If

    If BadExit Then Environment.ExitCode = 1
  End Sub

  Sub DoRepo(r As Repo)
    Dim rDir = BaseDir & "\repositories\" & r.Owner & "_" & r.Name & ".git"

    LogSeparator()
    LogLine("Processing repository: " & r.Owner & "/" & r.Name & " (backup directory """ & rDir & """)")

    Dim p = New System.Diagnostics.Process()
    p.StartInfo.FileName = If(String.IsNullOrEmpty(cfg.GitExePath), "git.exe", cfg.GitExePath)
    p.StartInfo.CreateNoWindow = True
    p.StartInfo.UseShellExecute = False
    p.StartInfo.RedirectStandardOutput = True
    p.StartInfo.RedirectStandardError = True

    If Not My.Computer.FileSystem.DirectoryExists(rDir) Then
      REM This is a new repository - make mirror clone
      LogLine("Backup directory does not exist. Cloning from GitHub:")

      p.StartInfo.Arguments = "clone -v --progress --mirror " & r.GitHubUrl(cfg.GHUserID, cfg.GHPassword) & " """ & rDir & """"
      LogLine("Executing GIT " & "clone -v --progress --mirror " & r.GitHubUrl(cfg.GHUserID, "*****") & " """ & rDir & """")

    Else
      REM This is an existing repository
      LogLine("Backup directory already exists. Updating from GitHub:")

      'Overwrite config file with GitHub credentials
      Try
        My.Computer.FileSystem.WriteAllText(rDir & "\config", r.ConfigFile(cfg.GHUserID, cfg.GHPassword), False)
      Catch ex As Exception
        BadExit = True
        LogLine("*** Exception updating repository 'config' file: " & ex.Message)
        GoTo markExit
      End Try

      p.StartInfo.Arguments = "--git-dir=""" & rDir & """ remote -v update"
      LogLine("Executing GIT " & p.StartInfo.Arguments)
    End If

    Try
      p.Start()
      p.WaitForExit()
    Catch ex As Exception
      BadExit = True
      LogLine("*** Exception executing Git command: " & ex.Message)
      GoTo markExit
    End Try

    If p.ExitCode = 0 Then
      LogLine("Git command completed successfully")
    Else
      LogLine("*** Git command completed with exit code " & p.ExitCode)
    End If


    Dim x = p.StandardOutput.ReadToEnd
    If x.Length > 0 Then
      LogLine("Git output (stdout):")
      LogBlock(x)
    End If
    x = p.StandardError.ReadToEnd
    If x.Length > 0 Then
      LogLine("Git output (stderr):")
      LogBlock(x)
    End If

    If p.ExitCode <> 0 Then BadExit = True : GoTo markExit

markExit:
    'Overwrite config file without GitHub credentials
    Try
      My.Computer.FileSystem.WriteAllText(rDir & "\config", r.ConfigFile(), False)
    Catch ex As Exception
    End Try
  End Sub

  Private Const GHPageSize = 100
  Private Function GetReposFromGitHub() As List(Of Repo)
    LogSeparator()
    LogLine("Fetching list of repositories from GitHub:")
    Dim cursor As String = Nothing
    Dim rv As New List(Of Repo)
    Dim lst As List(Of Repo)
    Do
      lst = GetPageOfReposFromGitHub(cursor)
      If BadExit Then Return Nothing
      rv.AddRange(lst)
    Loop Until lst.Count < GHPageSize
    LogLine("Found " & lst.Count & " repositories.")
    Return rv
  End Function

  Private Function GetPageOfReposFromGitHub(ByRef cursor As String) As List(Of Repo)
    REM Fetch repo list from GitHub using GraphQL API
    Dim wc = New System.Net.WebClient()
    Dim ua = My.Application.Info.AssemblyName.Replace(" ", "-") & "/" & My.Application.Info.Version.ToString
    wc.Headers.Add("User-Agent", ua) 'will throw error without this
    wc.Headers.Add("Authorization", "Basic " & System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(cfg.GHUserID & ":" & cfg.GHPassword)))
    wc.Headers.Add("Content-type", "application/json")

    Dim qs = "query {" & vbCrLf &
                  "   viewer {" & vbCrLf &
                  "    repositories (first:" & GHPageSize
    If cursor IsNot Nothing Then qs &= " after:""" & cursor & """"
    If Not String.IsNullOrEmpty(cfg.RepPrivacy) Then qs &= " privacy:" & cfg.RepPrivacy
    If Not String.IsNullOrEmpty(cfg.RepAffiliation) Then qs &= " affiliations:" & cfg.RepAffiliation
    If Not String.IsNullOrEmpty(cfg.RepLocked) Then qs &= " isLocked:" & cfg.RepLocked
    If Not String.IsNullOrEmpty(cfg.RepFork) Then qs &= " isFork:" & cfg.RepFork
    qs &= ") {" & vbCrLf &
                  "      edges {" & vbCrLf &
                  "        node {" & vbCrLf &
                  "          name" & vbCrLf &
                  "          owner {" & vbCrLf &
                  "            login" & vbCrLf &
                  "          }" & vbCrLf &
                  "        }" & vbCrLf &
                  "      cursor" & vbCrLf &
                  "      }" & vbCrLf &
                  "    }" & vbCrLf &
                  "  }" & vbCrLf &
                  "}"

    Dim ulStr = "{""query"":""" & qs.Replace(vbCrLf, "\n").Replace("""", "\""") & """}"
    Dim Resp As String = Nothing
    Try
      Resp = wc.UploadString("https://api.github.com/graphql", ulStr)
    Catch ex As System.Net.WebException
      BadExit = True
      LogLine("*** Exception getting data from GitHub: " & ex.Message)
      If ex.Response IsNot Nothing Then
        Dim ba(CInt(ex.Response.ContentLength) - 1) As Byte
        Dim l = ex.Response.GetResponseStream.Read(ba, 0, ba.Length)
        Dim x = System.Text.Encoding.UTF8.GetString(ba, 0, l)
        LogLine("HTTP response:")
        LogBlock(x)
      End If
      Return Nothing
    End Try

    Dim rv = New List(Of Repo)
    Try
      Dim o = DirectCast(JhSerializer.JhsValue.ParseJson(Resp), JhSerializer.JhsObject)
      Dim a = o.GetObject("data").GetObject("viewer").GetObject("repositories").GetArray("edges")
      Dim o2 As JhSerializer.JhsObject
      Dim r As Repo
      For Each o In a
        cursor = o.GetString("cursor")
        o = o.GetObject("node")
        o2 = o.GetObject("owner")
        r = New Repo With {.Name = o.GetString("name"), .Owner = o2.GetString("login")}
        rv.Add(r)
        LogLine("> " & r.Owner & "/" & r.Name)
      Next
    Catch ex As Exception
      LogLine("*** Exception parsing JSON data from GitHub: " & ex.Message)
      BadExit = True
      Return Nothing
    End Try
    Return rv
  End Function

  Class Repo
    Public Name As String
    Public Owner As String

    Function ConfigFile(Optional userID As String = Nothing, Optional pw As String = Nothing) As String
      Return "[core]" & vbLf &
              vbTab & "repositoryformatversion = 0" & vbLf &
              vbTab & "filemode = false" & vbLf &
              vbTab & "bare = true" & vbLf &
              vbTab & "symlinks = false" & vbLf &
              vbTab & "ignorecase = true" & vbLf &
              "[remote ""origin""]" & vbLf &
              vbTab & "url = https://" & If(userID Is Nothing, "", userID & ":" & pw & "@") & "github.com/" & Owner & "/" & Name & vbLf &
              vbTab & "fetch = +refs/*:refs/*" & vbLf &
              vbTab & "mirror = true" & vbLf
    End Function

    Function GitHubUrl(userID As String, pw As String) As String
      Return "https://" & userID & ":" & pw & "@github.com/" & Owner & "/" & Name
    End Function

  End Class

  Sub LogLine(x As String)
    Log.AppendLine(x)
    Console.WriteLine(x)
  End Sub

  Sub LogSeparator()
    LogLine("----------------------------------")
  End Sub

  Sub LogBlock(x As String)
    Dim rdr = New System.IO.StringReader(x)
    Dim y As String
    Do
      y = rdr.ReadLine()
      If y Is Nothing Then Exit Do
      LogLine("> " & y)
    Loop
  End Sub

End Module
