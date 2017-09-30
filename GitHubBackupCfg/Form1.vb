Public Class Form1

  Private BaseDir As String

  Private SelPrivacy As String() = {"", "PRIVATE", "PUBLIC"}
  Private SelAffil As String() = {"", "OWNER", "COLLABORATOR", "ORGANIZATION_MEMBER"}
  Private SelBool As String() = {"", "true", "false"}

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
    ddAffil.SelectedIndex = 0
    ddFork.SelectedIndex = 0
    ddLocked.SelectedIndex = 0
    ddPrivacy.SelectedIndex = 0


    BaseDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)

    REM read config file
    Dim x As String
    Try
      x = My.Computer.FileSystem.ReadAllText(BaseDir & "\config.json")
    Catch ex As System.IO.FileNotFoundException
      Exit Sub
    End Try
    Dim cfg = Config.DeSerialize(x)

    txtGHUser.Text = cfg.GHUserID
    txtGHPW.Text = cfg.GHPassword

    SetDD(ddPrivacy, cfg.RepPrivacy, SelPrivacy)
    SetDD(ddAffil, cfg.RepAffiliation, SelAffil)
    SetDD(ddLocked, cfg.RepLocked, SelBool)
    SetDD(ddFork, cfg.RepFork, SelBool)

    txtGitExe.Text = cfg.GitExePath

    chkLog.Checked = cfg.LogFiles

    chkEmailSuccess.Checked = cfg.EmailSuccess
    txtSubjectSuccess.Text = cfg.EmailSuccessSubject
    chkEmailFail.Checked = cfg.EmailFailure
    txtSubjectFail.Text = cfg.EmailFailureSubject

    txtEmailFrom.Text = cfg.EmailFrom
    txtEmailTo.Text = cfg.EmailTo

    txtSmtpHost.Text = cfg.SmtpHost
    txtSmtpPort.Text = cfg.SmtpPort.ToString
    chkSmtpSSL.Checked = cfg.SmtpSSL
    chkSmtpAuth.Checked = (cfg.SmtpUser.Length > 0)
    txtSmtpUser.Text = cfg.SmtpUser
    txtSmtpPW.Text = cfg.SmtpPW

  End Sub

  Private Sub SetDD(dd As ComboBox, val As String, vals As String())
    For i = 0 To vals.Count - 1
      If val.ToLower = vals(i).ToLower Then dd.SelectedIndex = i : Exit Sub
    Next
    dd.SelectedIndex = 0
  End Sub

  Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    If Not ValidateForm() Then Exit Sub

    Dim cfg = New Config
    cfg.GHUserID = txtGHUser.Text.Trim
    cfg.GHPassword = txtGHPW.Text.Trim

    cfg.RepPrivacy = SelPrivacy(ddPrivacy.SelectedIndex)
    cfg.RepAffiliation = SelAffil(ddAffil.SelectedIndex)
    cfg.RepLocked = SelBool(ddLocked.SelectedIndex)
    cfg.RepFork = SelBool(ddFork.SelectedIndex)

    cfg.GitExePath = txtGitExe.Text.Trim

    cfg.LogFiles = chkLog.Checked

    cfg.EmailSuccess = chkEmailSuccess.Checked
    cfg.EmailSuccessSubject = txtSubjectSuccess.Text.Trim
    cfg.EmailFailure = chkEmailFail.Checked
    cfg.EmailFailureSubject = txtSubjectFail.Text.Trim
    cfg.EmailFrom = txtEmailFrom.Text.Trim
    cfg.EmailTo = txtEmailTo.Text.Trim

    cfg.SmtpHost = txtSmtpHost.Text.Trim
    cfg.SmtpPort = Integer.Parse(txtSmtpPort.Text)
    cfg.SmtpSSL = chkSmtpSSL.Checked

    cfg.SmtpUser = If(chkSmtpAuth.Checked, txtSmtpUser.Text, "")
    cfg.SmtpPW = If(chkSmtpAuth.Checked, txtSmtpPW.Text.Trim, "")

    My.Computer.FileSystem.WriteAllText(BaseDir & "\config.json", cfg.Serialize(), False)

    MessageBox.Show("The configuration was saved to disk", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Function ValidateForm() As Boolean
    If txtGHUser.Text.Trim.Length = 0 Then Alert("GitHub User-ID cannot be blank!") : txtGHUser.Focus() : Return False
    If txtGHPW.Text.Trim.Length = 0 Then Alert("GitHub password cannot be blank!") : txtGHPW.Focus() : Return False
    If txtGitExe.Text.Trim.Length > 0 Then
      If Not txtGitExe.Text.Trim.ToLower.EndsWith("\git.exe") Then Alert("Git.exe path must end with \git.exe") : txtGitExe.Focus() : Return False
    End If
    If chkEmailFail.Checked AndAlso txtSubjectFail.Text.Trim.Length = 0 Then Alert("E-mail subject for failed backups cannot be blank!") : txtSubjectFail.Focus() : Return False
    If chkEmailSuccess.Checked AndAlso txtSubjectSuccess.Text.Trim.Length = 0 Then Alert("E-mail subject for successful backups cannot be blank!") : txtSubjectSuccess.Focus() : Return False
    If chkEmailFail.Checked OrElse chkEmailSuccess.Checked Then
      If txtEmailFrom.Text.Trim.Length = 0 Then Alert("E-mail from address cannot be blank!") : txtEmailFrom.Focus() : Return False
      If txtEmailTo.Text.Trim.Length = 0 Then Alert("E-mail to address cannot be blank!") : txtEmailTo.Focus() : Return False
      If txtSmtpHost.Text.Trim.Length = 0 Then Alert("SMTP host cannot be blank!") : txtSmtpHost.Focus() : Return False
      Dim p As Integer
      If Not Integer.TryParse(txtSmtpPort.Text.Trim, p) OrElse p < 1 Or p > 65535 Then Alert("Invalid SMTP port number (must be 1-65535)") : txtSmtpPort.Focus() : Return False
      If chkSmtpAuth.Checked Then
        If txtSmtpUser.Text.Trim.Length = 0 Then Alert("SMTP authentication User-ID cannot be blank!") : txtSmtpUser.Focus() : Return False
        If txtSmtpPW.Text.Trim.Length = 0 Then Alert("SMTP authentication password cannot be blank!") : txtSmtpPW.Focus() : Return False
      End If
    End If
    Return True
  End Function

  Private Sub Alert(msg As String)
    MessageBox.Show(msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
  End Sub

End Class
