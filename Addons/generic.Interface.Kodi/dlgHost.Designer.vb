<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgHost
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnPopulateSources = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblWebserverPort = New System.Windows.Forms.Label()
        Me.lblHostIP = New System.Windows.Forms.Label()
        Me.txtWebPort = New System.Windows.Forms.TextBox()
        Me.txtHostIP = New System.Windows.Forms.TextBox()
        Me.lblLabel = New System.Windows.Forms.Label()
        Me.txtLabel = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbLinux = New System.Windows.Forms.RadioButton()
        Me.rbWindows = New System.Windows.Forms.RadioButton()
        Me.dgvSources = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.pnlLoading = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.chkRealTimeSync = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSources, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLoading.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPopulateSources
        '
        Me.btnPopulateSources.Location = New System.Drawing.Point(488, 236)
        Me.btnPopulateSources.Name = "btnPopulateSources"
        Me.btnPopulateSources.Size = New System.Drawing.Size(75, 23)
        Me.btnPopulateSources.TabIndex = 2
        Me.btnPopulateSources.Text = "Populate Sources"
        Me.btnPopulateSources.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(373, 97)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.txtPassword, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPassword, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblUsername, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUsername, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblWebserverPort, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHostIP, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtWebPort, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtHostIP, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLabel, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtLabel, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(367, 78)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPassword.Location = New System.Drawing.Point(257, 55)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Text = "kodi"
        '
        'lblPassword
        '
        Me.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(170, 58)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Text = "Password"
        '
        'lblUsername
        '
        Me.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(3, 58)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username"
        '
        'txtUsername
        '
        Me.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsername.Location = New System.Drawing.Point(64, 55)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 3
        Me.txtUsername.Text = "kodi"
        '
        'lblWebserverPort
        '
        Me.lblWebserverPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblWebserverPort.AutoSize = True
        Me.lblWebserverPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebserverPort.Location = New System.Drawing.Point(170, 32)
        Me.lblWebserverPort.Name = "lblWebserverPort"
        Me.lblWebserverPort.Size = New System.Drawing.Size(81, 13)
        Me.lblWebserverPort.TabIndex = 0
        Me.lblWebserverPort.Text = "Webserver Port"
        '
        'lblHostIP
        '
        Me.lblHostIP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblHostIP.AutoSize = True
        Me.lblHostIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHostIP.Location = New System.Drawing.Point(3, 32)
        Me.lblHostIP.Name = "lblHostIP"
        Me.lblHostIP.Size = New System.Drawing.Size(42, 13)
        Me.lblHostIP.TabIndex = 0
        Me.lblHostIP.Text = "Host IP"
        '
        'txtWebPort
        '
        Me.txtWebPort.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWebPort.Location = New System.Drawing.Point(257, 29)
        Me.txtWebPort.Name = "txtWebPort"
        Me.txtWebPort.Size = New System.Drawing.Size(100, 20)
        Me.txtWebPort.TabIndex = 3
        Me.txtWebPort.Text = "8090"
        '
        'txtHostIP
        '
        Me.txtHostIP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHostIP.Location = New System.Drawing.Point(64, 29)
        Me.txtHostIP.Name = "txtHostIP"
        Me.txtHostIP.Size = New System.Drawing.Size(100, 20)
        Me.txtHostIP.TabIndex = 3
        Me.txtHostIP.Text = "localhost"
        '
        'lblLabel
        '
        Me.lblLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblLabel.AutoSize = True
        Me.lblLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabel.Location = New System.Drawing.Point(3, 6)
        Me.lblLabel.Name = "lblLabel"
        Me.lblLabel.Size = New System.Drawing.Size(35, 13)
        Me.lblLabel.TabIndex = 0
        Me.lblLabel.Text = "Name"
        '
        'txtLabel
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtLabel, 3)
        Me.txtLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLabel.Location = New System.Drawing.Point(64, 3)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.Size = New System.Drawing.Size(293, 20)
        Me.txtLabel.TabIndex = 4
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbLinux)
        Me.GroupBox2.Controls.Add(Me.rbWindows)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(15, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(281, 59)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kodi Source type"
        '
        'rbLinux
        '
        Me.rbLinux.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLinux.Location = New System.Drawing.Point(14, 37)
        Me.rbLinux.Name = "rbLinux"
        Me.rbLinux.Size = New System.Drawing.Size(216, 19)
        Me.rbLinux.TabIndex = 1
        Me.rbLinux.Text = "Windows UNC/Linux/MacOS X"
        Me.rbLinux.UseVisualStyleBackColor = True
        '
        'rbWindows
        '
        Me.rbWindows.Checked = True
        Me.rbWindows.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbWindows.Location = New System.Drawing.Point(14, 15)
        Me.rbWindows.Name = "rbWindows"
        Me.rbWindows.Size = New System.Drawing.Size(216, 23)
        Me.rbWindows.TabIndex = 0
        Me.rbWindows.TabStop = True
        Me.rbWindows.Text = "Windows Drive Letter (X:\)"
        Me.rbWindows.UseVisualStyleBackColor = True
        '
        'dgvSources
        '
        Me.dgvSources.AllowUserToAddRows = False
        Me.dgvSources.AllowUserToDeleteRows = False
        Me.dgvSources.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSources.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.dgvSources.Enabled = False
        Me.dgvSources.Location = New System.Drawing.Point(12, 187)
        Me.dgvSources.MultiSelect = False
        Me.dgvSources.Name = "dgvSources"
        Me.dgvSources.RowHeadersVisible = False
        Me.dgvSources.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSources.ShowCellErrors = False
        Me.dgvSources.ShowCellToolTips = False
        Me.dgvSources.ShowEditingIcon = False
        Me.dgvSources.ShowRowErrors = False
        Me.dgvSources.Size = New System.Drawing.Size(440, 150)
        Me.dgvSources.TabIndex = 14
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.FillWeight = 150.0!
        Me.Column1.HeaderText = "Ember Source"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.FillWeight = 270.0!
        Me.Column2.HeaderText = "XBMC Source"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 270
        '
        'pnlLoading
        '
        Me.pnlLoading.BackColor = System.Drawing.Color.White
        Me.pnlLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLoading.Controls.Add(Me.Label3)
        Me.pnlLoading.Controls.Add(Me.ProgressBar1)
        Me.pnlLoading.Location = New System.Drawing.Point(121, 234)
        Me.pnlLoading.Name = "pnlLoading"
        Me.pnlLoading.Size = New System.Drawing.Size(200, 54)
        Me.pnlLoading.TabIndex = 15
        Me.pnlLoading.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Searching ..."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 32)
        Me.ProgressBar1.MarqueeAnimationSpeed = 25
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(192, 17)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 1
        '
        'chkRealTimeSync
        '
        Me.chkRealTimeSync.AutoSize = True
        Me.chkRealTimeSync.Location = New System.Drawing.Point(446, 53)
        Me.chkRealTimeSync.Name = "chkRealTimeSync"
        Me.chkRealTimeSync.Size = New System.Drawing.Size(101, 17)
        Me.chkRealTimeSync.TabIndex = 16
        Me.chkRealTimeSync.Text = "Real Time Sync"
        Me.chkRealTimeSync.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(497, 384)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(578, 384)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 18
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dlgHost
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(665, 412)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkRealTimeSync)
        Me.Controls.Add(Me.pnlLoading)
        Me.Controls.Add(Me.dgvSources)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPopulateSources)
        Me.Name = "dlgHost"
        Me.Text = "dlgHosts"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        CType(Me.dgvSources,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlLoading.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnPopulateSources As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblWebserverPort As System.Windows.Forms.Label
    Friend WithEvents lblHostIP As System.Windows.Forms.Label
    Friend WithEvents txtWebPort As System.Windows.Forms.TextBox
    Friend WithEvents txtHostIP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbLinux As System.Windows.Forms.RadioButton
    Friend WithEvents rbWindows As System.Windows.Forms.RadioButton
    Friend WithEvents dgvSources As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents pnlLoading As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblLabel As System.Windows.Forms.Label
    Friend WithEvents txtLabel As System.Windows.Forms.TextBox
    Friend WithEvents chkRealTimeSync As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
