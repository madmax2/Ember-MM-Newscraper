<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingsHolder
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
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.pnlSettingsMain = New System.Windows.Forms.Panel()
        Me.tblSettingsMain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblHostIP = New System.Windows.Forms.Label()
        Me.lblWebserverPort = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtHostIP = New System.Windows.Forms.TextBox()
        Me.txtWebserverPort = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.pnlSettingsTop = New System.Windows.Forms.Panel()
        Me.tblSettingsTop = New System.Windows.Forms.TableLayoutPanel()
        Me.chkEnabled = New System.Windows.Forms.CheckBox()
        Me.pnlSettings.SuspendLayout()
        Me.pnlSettingsMain.SuspendLayout()
        Me.tblSettingsMain.SuspendLayout()
        Me.pnlSettingsTop.SuspendLayout()
        Me.tblSettingsTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSettings
        '
        Me.pnlSettings.AutoSize = True
        Me.pnlSettings.BackColor = System.Drawing.Color.White
        Me.pnlSettings.Controls.Add(Me.pnlSettingsMain)
        Me.pnlSettings.Controls.Add(Me.pnlSettingsTop)
        Me.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettings.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(329, 186)
        Me.pnlSettings.TabIndex = 84
        '
        'pnlSettingsMain
        '
        Me.pnlSettingsMain.AutoSize = True
        Me.pnlSettingsMain.Controls.Add(Me.tblSettingsMain)
        Me.pnlSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSettingsMain.Location = New System.Drawing.Point(0, 23)
        Me.pnlSettingsMain.Name = "pnlSettingsMain"
        Me.pnlSettingsMain.Size = New System.Drawing.Size(329, 163)
        Me.pnlSettingsMain.TabIndex = 5
        '
        'tblSettingsMain
        '
        Me.tblSettingsMain.AutoSize = True
        Me.tblSettingsMain.ColumnCount = 3
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsMain.Controls.Add(Me.lblHostIP, 0, 0)
        Me.tblSettingsMain.Controls.Add(Me.lblWebserverPort, 0, 1)
        Me.tblSettingsMain.Controls.Add(Me.lblUsername, 0, 2)
        Me.tblSettingsMain.Controls.Add(Me.lblPassword, 0, 3)
        Me.tblSettingsMain.Controls.Add(Me.txtHostIP, 1, 0)
        Me.tblSettingsMain.Controls.Add(Me.txtWebserverPort, 1, 1)
        Me.tblSettingsMain.Controls.Add(Me.txtUsername, 1, 2)
        Me.tblSettingsMain.Controls.Add(Me.txtPassword, 1, 3)
        Me.tblSettingsMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsMain.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsMain.Name = "tblSettingsMain"
        Me.tblSettingsMain.RowCount = 5
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsMain.Size = New System.Drawing.Size(329, 163)
        Me.tblSettingsMain.TabIndex = 0
        '
        'lblHostIP
        '
        Me.lblHostIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHostIP.AutoSize = True
        Me.lblHostIP.Location = New System.Drawing.Point(3, 7)
        Me.lblHostIP.Name = "lblHostIP"
        Me.lblHostIP.Size = New System.Drawing.Size(43, 13)
        Me.lblHostIP.TabIndex = 0
        Me.lblHostIP.Text = "Host IP"
        '
        'lblWebserverPort
        '
        Me.lblWebserverPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWebserverPort.AutoSize = True
        Me.lblWebserverPort.Location = New System.Drawing.Point(3, 35)
        Me.lblWebserverPort.Name = "lblWebserverPort"
        Me.lblWebserverPort.Size = New System.Drawing.Size(85, 13)
        Me.lblWebserverPort.TabIndex = 0
        Me.lblWebserverPort.Text = "Webserver Port"
        '
        'lblUsername
        '
        Me.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(3, 63)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username"
        '
        'lblPassword
        '
        Me.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(3, 91)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'txtHostIP
        '
        Me.txtHostIP.Location = New System.Drawing.Point(94, 3)
        Me.txtHostIP.Name = "txtHostIP"
        Me.txtHostIP.Size = New System.Drawing.Size(100, 22)
        Me.txtHostIP.TabIndex = 3
        '
        'txtWebserverPort
        '
        Me.txtWebserverPort.Location = New System.Drawing.Point(94, 31)
        Me.txtWebserverPort.Name = "txtWebserverPort"
        Me.txtWebserverPort.Size = New System.Drawing.Size(100, 22)
        Me.txtWebserverPort.TabIndex = 3
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(94, 59)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 22)
        Me.txtUsername.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(94, 87)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 22)
        Me.txtPassword.TabIndex = 3
        '
        'pnlSettingsTop
        '
        Me.pnlSettingsTop.AutoSize = True
        Me.pnlSettingsTop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlSettingsTop.Controls.Add(Me.tblSettingsTop)
        Me.pnlSettingsTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlSettingsTop.Name = "pnlSettingsTop"
        Me.pnlSettingsTop.Size = New System.Drawing.Size(329, 23)
        Me.pnlSettingsTop.TabIndex = 0
        '
        'tblSettingsTop
        '
        Me.tblSettingsTop.AutoSize = True
        Me.tblSettingsTop.ColumnCount = 2
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tblSettingsTop.Controls.Add(Me.chkEnabled, 0, 0)
        Me.tblSettingsTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblSettingsTop.Location = New System.Drawing.Point(0, 0)
        Me.tblSettingsTop.Name = "tblSettingsTop"
        Me.tblSettingsTop.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.tblSettingsTop.RowCount = 2
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblSettingsTop.Size = New System.Drawing.Size(329, 23)
        Me.tblSettingsTop.TabIndex = 5
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(8, 3)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(68, 17)
        Me.chkEnabled.TabIndex = 0
        Me.chkEnabled.Text = "Enabled"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'frmSettingsHolder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(329, 186)
        Me.Controls.Add(Me.pnlSettings)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSettingsHolder"
        Me.Text = "frmSettingsHolder"
        Me.pnlSettings.ResumeLayout(False)
        Me.pnlSettings.PerformLayout()
        Me.pnlSettingsMain.ResumeLayout(False)
        Me.pnlSettingsMain.PerformLayout()
        Me.tblSettingsMain.ResumeLayout(False)
        Me.tblSettingsMain.PerformLayout()
        Me.pnlSettingsTop.ResumeLayout(False)
        Me.pnlSettingsTop.PerformLayout()
        Me.tblSettingsTop.ResumeLayout(False)
        Me.tblSettingsTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents pnlSettingsTop As System.Windows.Forms.Panel
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSettingsMain As System.Windows.Forms.Panel
    Friend WithEvents tblSettingsTop As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblSettingsMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblHostIP As System.Windows.Forms.Label
    Friend WithEvents lblWebserverPort As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtHostIP As System.Windows.Forms.TextBox
    Friend WithEvents txtWebserverPort As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
End Class
