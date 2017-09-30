<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.txtGHPW = New System.Windows.Forms.TextBox()
    Me.txtGHUser = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ddFork = New System.Windows.Forms.ComboBox()
    Me.ddLocked = New System.Windows.Forms.ComboBox()
    Me.ddAffil = New System.Windows.Forms.ComboBox()
    Me.ddPrivacy = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.txtGitExe = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.chkLog = New System.Windows.Forms.CheckBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.txtSmtpPW = New System.Windows.Forms.TextBox()
    Me.txtSmtpUser = New System.Windows.Forms.TextBox()
    Me.txtSmtpPort = New System.Windows.Forms.TextBox()
    Me.txtSmtpHost = New System.Windows.Forms.TextBox()
    Me.txtEmailTo = New System.Windows.Forms.TextBox()
    Me.txtEmailFrom = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.chkSmtpAuth = New System.Windows.Forms.CheckBox()
    Me.chkSmtpSSL = New System.Windows.Forms.CheckBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.txtSubjectSuccess = New System.Windows.Forms.TextBox()
    Me.txtSubjectFail = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.chkEmailSuccess = New System.Windows.Forms.CheckBox()
    Me.chkEmailFail = New System.Windows.Forms.CheckBox()
    Me.btnSave = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.txtGHPW)
    Me.GroupBox1.Controls.Add(Me.txtGHUser)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(382, 115)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "GitHub credentials:"
    '
    'txtGHPW
    '
    Me.txtGHPW.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtGHPW.Location = New System.Drawing.Point(66, 62)
    Me.txtGHPW.Name = "txtGHPW"
    Me.txtGHPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtGHPW.Size = New System.Drawing.Size(310, 20)
    Me.txtGHPW.TabIndex = 1
    '
    'txtGHUser
    '
    Me.txtGHUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtGHUser.Location = New System.Drawing.Point(66, 29)
    Me.txtGHUser.Name = "txtGHUser"
    Me.txtGHUser.Size = New System.Drawing.Size(310, 20)
    Me.txtGHUser.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(6, 65)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Password:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 33)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "User-ID:"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.ddFork)
    Me.GroupBox2.Controls.Add(Me.ddLocked)
    Me.GroupBox2.Controls.Add(Me.ddAffil)
    Me.GroupBox2.Controls.Add(Me.ddPrivacy)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Controls.Add(Me.Label4)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Location = New System.Drawing.Point(12, 137)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(382, 192)
    Me.GroupBox2.TabIndex = 1
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Filter repositories:"
    '
    'ddFork
    '
    Me.ddFork.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ddFork.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddFork.FormattingEnabled = True
    Me.ddFork.Items.AddRange(New Object() {"Any", "Only forks", "Only not forks"})
    Me.ddFork.Location = New System.Drawing.Point(104, 151)
    Me.ddFork.Name = "ddFork"
    Me.ddFork.Size = New System.Drawing.Size(272, 21)
    Me.ddFork.TabIndex = 5
    '
    'ddLocked
    '
    Me.ddLocked.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ddLocked.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddLocked.FormattingEnabled = True
    Me.ddLocked.Items.AddRange(New Object() {"Any", "Only locked", "Only not locked"})
    Me.ddLocked.Location = New System.Drawing.Point(104, 111)
    Me.ddLocked.Name = "ddLocked"
    Me.ddLocked.Size = New System.Drawing.Size(272, 21)
    Me.ddLocked.TabIndex = 4
    '
    'ddAffil
    '
    Me.ddAffil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ddAffil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddAffil.FormattingEnabled = True
    Me.ddAffil.Items.AddRange(New Object() {"Any", "Owner", "Collaborator", "Organization member"})
    Me.ddAffil.Location = New System.Drawing.Point(104, 71)
    Me.ddAffil.Name = "ddAffil"
    Me.ddAffil.Size = New System.Drawing.Size(272, 21)
    Me.ddAffil.TabIndex = 3
    '
    'ddPrivacy
    '
    Me.ddPrivacy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ddPrivacy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ddPrivacy.FormattingEnabled = True
    Me.ddPrivacy.Items.AddRange(New Object() {"Any", "Only private", "Only public"})
    Me.ddPrivacy.Location = New System.Drawing.Point(104, 31)
    Me.ddPrivacy.Name = "ddPrivacy"
    Me.ddPrivacy.Size = New System.Drawing.Size(272, 21)
    Me.ddPrivacy.TabIndex = 2
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(6, 154)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(31, 13)
    Me.Label6.TabIndex = 3
    Me.Label6.Text = "Fork:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(6, 114)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(46, 13)
    Me.Label5.TabIndex = 2
    Me.Label5.Text = "Locked:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(4, 74)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(52, 13)
    Me.Label4.TabIndex = 1
    Me.Label4.Text = "Affiliation:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(4, 34)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(83, 13)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Private / Public:"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.Label16)
    Me.GroupBox3.Controls.Add(Me.txtGitExe)
    Me.GroupBox3.Controls.Add(Me.Label7)
    Me.GroupBox3.Location = New System.Drawing.Point(12, 339)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(382, 78)
    Me.GroupBox3.TabIndex = 2
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Git.exe"
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(76, 53)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(176, 13)
    Me.Label16.TabIndex = 2
    Me.Label16.Text = "Optional. PATH will be used if blank"
    '
    'txtGitExe
    '
    Me.txtGitExe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtGitExe.Location = New System.Drawing.Point(79, 28)
    Me.txtGitExe.Name = "txtGitExe"
    Me.txtGitExe.Size = New System.Drawing.Size(297, 20)
    Me.txtGitExe.TabIndex = 6
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(6, 31)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(67, 13)
    Me.Label7.TabIndex = 0
    Me.Label7.Text = "Git.exe path:"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.chkLog)
    Me.GroupBox4.Location = New System.Drawing.Point(12, 423)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(382, 73)
    Me.GroupBox4.TabIndex = 3
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Log files:"
    '
    'chkLog
    '
    Me.chkLog.AutoSize = True
    Me.chkLog.Location = New System.Drawing.Point(6, 29)
    Me.chkLog.Name = "chkLog"
    Me.chkLog.Size = New System.Drawing.Size(123, 17)
    Me.chkLog.TabIndex = 7
    Me.chkLog.Text = "Write log files to disk"
    Me.chkLog.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.txtSmtpPW)
    Me.GroupBox5.Controls.Add(Me.txtSmtpUser)
    Me.GroupBox5.Controls.Add(Me.txtSmtpPort)
    Me.GroupBox5.Controls.Add(Me.txtSmtpHost)
    Me.GroupBox5.Controls.Add(Me.txtEmailTo)
    Me.GroupBox5.Controls.Add(Me.txtEmailFrom)
    Me.GroupBox5.Controls.Add(Me.Label15)
    Me.GroupBox5.Controls.Add(Me.Label14)
    Me.GroupBox5.Controls.Add(Me.chkSmtpAuth)
    Me.GroupBox5.Controls.Add(Me.chkSmtpSSL)
    Me.GroupBox5.Controls.Add(Me.Label13)
    Me.GroupBox5.Controls.Add(Me.Label12)
    Me.GroupBox5.Controls.Add(Me.Label11)
    Me.GroupBox5.Controls.Add(Me.Label10)
    Me.GroupBox5.Controls.Add(Me.txtSubjectSuccess)
    Me.GroupBox5.Controls.Add(Me.txtSubjectFail)
    Me.GroupBox5.Controls.Add(Me.Label9)
    Me.GroupBox5.Controls.Add(Me.Label8)
    Me.GroupBox5.Controls.Add(Me.chkEmailSuccess)
    Me.GroupBox5.Controls.Add(Me.chkEmailFail)
    Me.GroupBox5.Location = New System.Drawing.Point(400, 12)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(448, 484)
    Me.GroupBox5.TabIndex = 4
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "E-mail notification:"
    '
    'txtSmtpPW
    '
    Me.txtSmtpPW.Location = New System.Drawing.Point(114, 400)
    Me.txtSmtpPW.Name = "txtSmtpPW"
    Me.txtSmtpPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtSmtpPW.Size = New System.Drawing.Size(208, 20)
    Me.txtSmtpPW.TabIndex = 19
    '
    'txtSmtpUser
    '
    Me.txtSmtpUser.Location = New System.Drawing.Point(114, 373)
    Me.txtSmtpUser.Name = "txtSmtpUser"
    Me.txtSmtpUser.Size = New System.Drawing.Size(208, 20)
    Me.txtSmtpUser.TabIndex = 18
    '
    'txtSmtpPort
    '
    Me.txtSmtpPort.Location = New System.Drawing.Point(114, 289)
    Me.txtSmtpPort.Name = "txtSmtpPort"
    Me.txtSmtpPort.Size = New System.Drawing.Size(75, 20)
    Me.txtSmtpPort.TabIndex = 15
    Me.txtSmtpPort.Text = "25"
    '
    'txtSmtpHost
    '
    Me.txtSmtpHost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSmtpHost.Location = New System.Drawing.Point(114, 254)
    Me.txtSmtpHost.Name = "txtSmtpHost"
    Me.txtSmtpHost.Size = New System.Drawing.Size(328, 20)
    Me.txtSmtpHost.TabIndex = 14
    '
    'txtEmailTo
    '
    Me.txtEmailTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtEmailTo.Location = New System.Drawing.Point(114, 199)
    Me.txtEmailTo.Name = "txtEmailTo"
    Me.txtEmailTo.Size = New System.Drawing.Size(328, 20)
    Me.txtEmailTo.TabIndex = 13
    '
    'txtEmailFrom
    '
    Me.txtEmailFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtEmailFrom.Location = New System.Drawing.Point(114, 170)
    Me.txtEmailFrom.Name = "txtEmailFrom"
    Me.txtEmailFrom.Size = New System.Drawing.Size(328, 20)
    Me.txtEmailFrom.TabIndex = 12
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(45, 403)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(56, 13)
    Me.Label15.TabIndex = 13
    Me.Label15.Text = "Password:"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(45, 376)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(46, 13)
    Me.Label14.TabIndex = 12
    Me.Label14.Text = "User-ID:"
    '
    'chkSmtpAuth
    '
    Me.chkSmtpAuth.AutoSize = True
    Me.chkSmtpAuth.Location = New System.Drawing.Point(9, 350)
    Me.chkSmtpAuth.Name = "chkSmtpAuth"
    Me.chkSmtpAuth.Size = New System.Drawing.Size(151, 17)
    Me.chkSmtpAuth.TabIndex = 17
    Me.chkSmtpAuth.Text = "Use SMTP authentication:"
    Me.chkSmtpAuth.UseVisualStyleBackColor = True
    '
    'chkSmtpSSL
    '
    Me.chkSmtpSSL.AutoSize = True
    Me.chkSmtpSSL.Location = New System.Drawing.Point(9, 327)
    Me.chkSmtpSSL.Name = "chkSmtpSSL"
    Me.chkSmtpSSL.Size = New System.Drawing.Size(97, 17)
    Me.chkSmtpSSL.TabIndex = 16
    Me.chkSmtpSSL.Text = "Use SSL (TLS)"
    Me.chkSmtpSSL.UseVisualStyleBackColor = True
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(6, 292)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(61, 13)
    Me.Label13.TabIndex = 9
    Me.Label13.Text = "SMTP port:"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(4, 257)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(63, 13)
    Me.Label12.TabIndex = 8
    Me.Label12.Text = "SMTP host:"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(6, 202)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(63, 13)
    Me.Label11.TabIndex = 7
    Me.Label11.Text = "To address:"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(4, 173)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(73, 13)
    Me.Label10.TabIndex = 6
    Me.Label10.Text = "From address:"
    '
    'txtSubjectSuccess
    '
    Me.txtSubjectSuccess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSubjectSuccess.Location = New System.Drawing.Point(114, 121)
    Me.txtSubjectSuccess.Name = "txtSubjectSuccess"
    Me.txtSubjectSuccess.Size = New System.Drawing.Size(328, 20)
    Me.txtSubjectSuccess.TabIndex = 11
    Me.txtSubjectSuccess.Text = "GitHub backup completed successfully :-)"
    '
    'txtSubjectFail
    '
    Me.txtSubjectFail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtSubjectFail.Location = New System.Drawing.Point(114, 63)
    Me.txtSubjectFail.Name = "txtSubjectFail"
    Me.txtSubjectFail.Size = New System.Drawing.Size(328, 20)
    Me.txtSubjectFail.TabIndex = 9
    Me.txtSubjectFail.Text = "GitHub backup failed :-("
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(33, 125)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(75, 13)
    Me.Label9.TabIndex = 3
    Me.Label9.Text = "E-mail subject:"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(33, 66)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(75, 13)
    Me.Label8.TabIndex = 2
    Me.Label8.Text = "E-mail subject:"
    '
    'chkEmailSuccess
    '
    Me.chkEmailSuccess.AutoSize = True
    Me.chkEmailSuccess.Location = New System.Drawing.Point(7, 98)
    Me.chkEmailSuccess.Name = "chkEmailSuccess"
    Me.chkEmailSuccess.Size = New System.Drawing.Size(163, 17)
    Me.chkEmailSuccess.TabIndex = 10
    Me.chkEmailSuccess.Text = "Send for successful backups"
    Me.chkEmailSuccess.UseVisualStyleBackColor = True
    '
    'chkEmailFail
    '
    Me.chkEmailFail.AutoSize = True
    Me.chkEmailFail.Location = New System.Drawing.Point(7, 40)
    Me.chkEmailFail.Name = "chkEmailFail"
    Me.chkEmailFail.Size = New System.Drawing.Size(138, 17)
    Me.chkEmailFail.TabIndex = 8
    Me.chkEmailFail.Text = "Send for failed backups"
    Me.chkEmailFail.UseVisualStyleBackColor = True
    '
    'btnSave
    '
    Me.btnSave.Location = New System.Drawing.Point(733, 502)
    Me.btnSave.Name = "btnSave"
    Me.btnSave.Size = New System.Drawing.Size(115, 31)
    Me.btnSave.TabIndex = 20
    Me.btnSave.Text = "Save"
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(860, 549)
    Me.Controls.Add(Me.btnSave)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form1"
    Me.ShowIcon = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GitHub Backup Configuration"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents txtGHPW As TextBox
  Friend WithEvents txtGHUser As TextBox
  Friend WithEvents Label2 As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents ddFork As ComboBox
  Friend WithEvents ddLocked As ComboBox
  Friend WithEvents ddAffil As ComboBox
  Friend WithEvents ddPrivacy As ComboBox
  Friend WithEvents Label6 As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents Label16 As Label
  Friend WithEvents txtGitExe As TextBox
  Friend WithEvents Label7 As Label
  Friend WithEvents GroupBox4 As GroupBox
  Friend WithEvents chkLog As CheckBox
  Friend WithEvents GroupBox5 As GroupBox
  Friend WithEvents txtSmtpPW As TextBox
  Friend WithEvents txtSmtpUser As TextBox
  Friend WithEvents txtSmtpPort As TextBox
  Friend WithEvents txtSmtpHost As TextBox
  Friend WithEvents txtEmailTo As TextBox
  Friend WithEvents txtEmailFrom As TextBox
  Friend WithEvents Label15 As Label
  Friend WithEvents Label14 As Label
  Friend WithEvents chkSmtpAuth As CheckBox
  Friend WithEvents chkSmtpSSL As CheckBox
  Friend WithEvents Label13 As Label
  Friend WithEvents Label12 As Label
  Friend WithEvents Label11 As Label
  Friend WithEvents Label10 As Label
  Friend WithEvents txtSubjectSuccess As TextBox
  Friend WithEvents txtSubjectFail As TextBox
  Friend WithEvents Label9 As Label
  Friend WithEvents Label8 As Label
  Friend WithEvents chkEmailSuccess As CheckBox
  Friend WithEvents chkEmailFail As CheckBox
  Friend WithEvents btnSave As Button
End Class
