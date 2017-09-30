Public Class Config

  Public GHUserID As String = ""
  Public GHPassword As String = ""

  Public RepPrivacy As String = "" 'PUBLIC,PRIVATE, or blank
  Public RepAffiliation As String = "" 'OWNER, COLLABORATOR, ORGANIZATION_MEMBER, or blank
  Public RepLocked As String = "" 'true or false or blank
  Public RepFork As String = "" 'true or false or blank

  Public GitExePath As String = "" 'Optional - if blank, "git.exe" is used (hoping it will be in PATH)

  Public LogFiles As Boolean = False

  Public EmailSuccess As Boolean = True
  Public EmailSuccessSubject As String = "GitHub backup completed successfully :-)"
  Public EmailFailure As Boolean = True
  Public EmailFailureSubject As String = "GitHub backup failed :-("
  Public EmailFrom As String = ""
  Public EmailTo As String = ""

  Public SmtpHost As String = ""
  Public SmtpPort As Integer = 25
  Public SmtpSSL As Boolean = False
  Public SmtpUser As String = ""
  Public SmtpPW As String = ""

  Public Sub SendEmail(subject As String, body As String)
    Dim c = New System.Net.Mail.SmtpClient(SmtpHost, SmtpPort)
    c.EnableSsl = SmtpSSL
    If Not String.IsNullOrEmpty(SmtpUser) Then c.Credentials = New System.Net.NetworkCredential(SmtpUser, SmtpPW)
    Dim m = New System.Net.Mail.MailMessage(EmailFrom, EmailTo, subject, body)
    c.Send(m)
  End Sub

  Function Serialize() As String
    Dim rv = New JhSerializer.JhsObject
    rv.Add("GitHubUser", GHUserID)
    rv.Add("GitHubPW", EncodePW(GHPassword))

    rv.Add("RepPrivacy", RepPrivacy)
    rv.Add("RepAffiliation", RepAffiliation)
    rv.Add("RepLocked", RepLocked)
    rv.Add("RepFork", RepFork)

    rv.Add("GitExePath", GitExePath)

    rv.Add("LogFiles", LogFiles)

    rv.Add("EmailSuccess", EmailSuccess)
    rv.Add("EmailSuccessSubject", EmailSuccessSubject)
    rv.Add("EmailFailure", EmailFailure)
    rv.Add("EmailFailureSubject", EmailFailureSubject)
    rv.Add("EmailFrom", EmailFrom)
    rv.Add("EmailTo", EmailTo)

    rv.Add("SmtpHost", SmtpHost)
    rv.Add("SmtpPort", SmtpPort)
    rv.Add("SmtpSSL", SmtpSSL)
    rv.Add("SmtpUser", SmtpUser)
    rv.Add("SmtpPW", EncodePW(SmtpPW))

    Return rv.EncodeJson(True)
  End Function

  Shared Function DeSerialize(x As String) As Config
    Dim o = DirectCast(JhSerializer.JhsValue.ParseJson(x), JhSerializer.JhsObject)
    Dim rv = New Config

    rv.GHUserID = o.GetString("GitHubUser")
    rv.GHPassword = DecodePW(o.GetString("GitHubPW"))

    rv.RepPrivacy = o.GetString("RepPrivacy", "")
    rv.RepAffiliation = o.GetString("RepAffiliation", "")
    rv.RepLocked = o.GetString("RepLocked", "")
    rv.RepFork = o.GetString("RepFork", "")

    rv.GitExePath = o.GetString("GitExePath", "")

    rv.LogFiles = o.GetBool("LogFiles")

    rv.EmailSuccess = o.GetBool("EmailSuccess")
    rv.EmailSuccessSubject = o.GetString("EmailSuccessSubject")
    rv.EmailFailure = o.GetBool("EmailFailure")
    rv.EmailFailureSubject = o.GetString("EmailFailureSubject")
    rv.EmailFrom = o.GetString("EmailFrom")
    rv.EmailTo = o.GetString("EmailTo")

    rv.SmtpHost = o.GetString("SmtpHost")
    rv.SmtpPort = o.GetInt("SmtpPort", 25)
    rv.SmtpSSL = o.GetBool("SmtpSSL", False)
    rv.SmtpUser = o.GetString("SmtpUser")
    rv.SmtpPW = DecodePW(o.GetString("SmtpPW"))

    Return rv
  End Function

  Private Shared Function EncodePW(x As String) As String
    Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(x))
  End Function

  Private Shared Function DecodePW(x As String) As String
    Return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(x))
  End Function

End Class
