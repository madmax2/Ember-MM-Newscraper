﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTMDBInfoSettingsHolder_MovieSet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTMDBInfoSettingsHolder_MovieSet))
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.gbGlobalOpts = New System.Windows.Forms.GroupBox()
        Me.lblEMMAPI = New System.Windows.Forms.Label()
        Me.btnUnlockAPI = New System.Windows.Forms.Button()
        Me.chkGetAdultItems = New System.Windows.Forms.CheckBox()
        Me.pbTMDBApiKeyInfo = New System.Windows.Forms.PictureBox()
        Me.chkFallBackEng = New System.Windows.Forms.CheckBox()
        Me.cbPrefLanguage = New System.Windows.Forms.ComboBox()
        Me.lblPrefLanguage = New System.Windows.Forms.Label()
        Me.lblApiKey = New System.Windows.Forms.Label()
        Me.txtApiKey = New System.Windows.Forms.TextBox()
        Me.cbEnabled = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblScraperOrder = New System.Windows.Forms.Label()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.pnlSettings = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbScraperOpts = New System.Windows.Forms.GroupBox()
        Me.chkPlot = New System.Windows.Forms.CheckBox()
        Me.chkTitle = New System.Windows.Forms.CheckBox()
        Me.gbGlobalOpts.SuspendLayout()
        CType(Me.pbTMDBApiKeyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlSettings.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbScraperOpts.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(286, 393)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(90, 16)
        Me.lblVersion.TabIndex = 74
        Me.lblVersion.Text = "Version:"
        '
        'gbGlobalOpts
        '
        Me.gbGlobalOpts.Controls.Add(Me.lblEMMAPI)
        Me.gbGlobalOpts.Controls.Add(Me.btnUnlockAPI)
        Me.gbGlobalOpts.Controls.Add(Me.chkGetAdultItems)
        Me.gbGlobalOpts.Controls.Add(Me.pbTMDBApiKeyInfo)
        Me.gbGlobalOpts.Controls.Add(Me.chkFallBackEng)
        Me.gbGlobalOpts.Controls.Add(Me.cbPrefLanguage)
        Me.gbGlobalOpts.Controls.Add(Me.lblPrefLanguage)
        Me.gbGlobalOpts.Controls.Add(Me.lblApiKey)
        Me.gbGlobalOpts.Controls.Add(Me.txtApiKey)
        Me.gbGlobalOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.gbGlobalOpts.Location = New System.Drawing.Point(11, 31)
        Me.gbGlobalOpts.Name = "gbGlobalOpts"
        Me.gbGlobalOpts.Size = New System.Drawing.Size(594, 102)
        Me.gbGlobalOpts.TabIndex = 1
        Me.gbGlobalOpts.TabStop = False
        Me.gbGlobalOpts.Text = "TMDB"
        '
        'lblEMMAPI
        '
        Me.lblEMMAPI.AutoSize = True
        Me.lblEMMAPI.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblEMMAPI.Location = New System.Drawing.Point(194, 39)
        Me.lblEMMAPI.Name = "lblEMMAPI"
        Me.lblEMMAPI.Size = New System.Drawing.Size(162, 13)
        Me.lblEMMAPI.TabIndex = 12
        Me.lblEMMAPI.Text = "Ember Media Manager API key"
        '
        'btnUnlockAPI
        '
        Me.btnUnlockAPI.Location = New System.Drawing.Point(9, 34)
        Me.btnUnlockAPI.Name = "btnUnlockAPI"
        Me.btnUnlockAPI.Size = New System.Drawing.Size(179, 23)
        Me.btnUnlockAPI.TabIndex = 11
        Me.btnUnlockAPI.Text = "Use my own API key"
        Me.btnUnlockAPI.UseVisualStyleBackColor = True
        '
        'chkGetAdultItems
        '
        Me.chkGetAdultItems.AutoSize = True
        Me.chkGetAdultItems.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.chkGetAdultItems.Location = New System.Drawing.Point(339, 67)
        Me.chkGetAdultItems.Name = "chkGetAdultItems"
        Me.chkGetAdultItems.Size = New System.Drawing.Size(125, 17)
        Me.chkGetAdultItems.TabIndex = 6
        Me.chkGetAdultItems.Text = "Include Adult Items"
        Me.chkGetAdultItems.UseVisualStyleBackColor = True
        '
        'pbTMDBApiKeyInfo
        '
        Me.pbTMDBApiKeyInfo.Image = CType(resources.GetObject("pbTMDBApiKeyInfo.Image"), System.Drawing.Image)
        Me.pbTMDBApiKeyInfo.Location = New System.Drawing.Point(572, 36)
        Me.pbTMDBApiKeyInfo.Name = "pbTMDBApiKeyInfo"
        Me.pbTMDBApiKeyInfo.Size = New System.Drawing.Size(16, 16)
        Me.pbTMDBApiKeyInfo.TabIndex = 5
        Me.pbTMDBApiKeyInfo.TabStop = False
        '
        'chkFallBackEng
        '
        Me.chkFallBackEng.AutoSize = True
        Me.chkFallBackEng.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFallBackEng.Location = New System.Drawing.Point(190, 67)
        Me.chkFallBackEng.Name = "chkFallBackEng"
        Me.chkFallBackEng.Size = New System.Drawing.Size(129, 17)
        Me.chkFallBackEng.TabIndex = 4
        Me.chkFallBackEng.Text = "Fall back on english"
        Me.chkFallBackEng.UseVisualStyleBackColor = True
        '
        'cbPrefLanguage
        '
        Me.cbPrefLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrefLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.cbPrefLanguage.FormattingEnabled = True
        Me.cbPrefLanguage.Items.AddRange(New Object() {"bg", "cs", "da", "de", "el", "en", "es", "fi", "fr", "he", "hu", "it", "nb", "nl", "no", "pl", "pt", "ru", "sk", "sv", "ta", "tr", "uk", "vi", "xx", "zh"})
        Me.cbPrefLanguage.Location = New System.Drawing.Point(123, 65)
        Me.cbPrefLanguage.Name = "cbPrefLanguage"
        Me.cbPrefLanguage.Size = New System.Drawing.Size(45, 21)
        Me.cbPrefLanguage.TabIndex = 3
        '
        'lblPrefLanguage
        '
        Me.lblPrefLanguage.AutoSize = True
        Me.lblPrefLanguage.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.lblPrefLanguage.Location = New System.Drawing.Point(6, 68)
        Me.lblPrefLanguage.Name = "lblPrefLanguage"
        Me.lblPrefLanguage.Size = New System.Drawing.Size(111, 13)
        Me.lblPrefLanguage.TabIndex = 2
        Me.lblPrefLanguage.Text = "Preferred Language:"
        '
        'lblApiKey
        '
        Me.lblApiKey.AutoSize = True
        Me.lblApiKey.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApiKey.Location = New System.Drawing.Point(6, 18)
        Me.lblApiKey.Name = "lblApiKey"
        Me.lblApiKey.Size = New System.Drawing.Size(79, 13)
        Me.lblApiKey.TabIndex = 0
        Me.lblApiKey.Text = "TMDB API Key:"
        '
        'txtApiKey
        '
        Me.txtApiKey.Enabled = False
        Me.txtApiKey.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApiKey.Location = New System.Drawing.Point(194, 36)
        Me.txtApiKey.Name = "txtApiKey"
        Me.txtApiKey.Size = New System.Drawing.Size(372, 22)
        Me.txtApiKey.TabIndex = 1
        Me.txtApiKey.Visible = False
        '
        'cbEnabled
        '
        Me.cbEnabled.AutoSize = True
        Me.cbEnabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnabled.Location = New System.Drawing.Point(10, 5)
        Me.cbEnabled.Name = "cbEnabled"
        Me.cbEnabled.Size = New System.Drawing.Size(68, 17)
        Me.cbEnabled.TabIndex = 0
        Me.cbEnabled.Text = "Enabled"
        Me.cbEnabled.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.lblScraperOrder)
        Me.Panel1.Controls.Add(Me.btnDown)
        Me.Panel1.Controls.Add(Me.cbEnabled)
        Me.Panel1.Controls.Add(Me.btnUp)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1125, 25)
        Me.Panel1.TabIndex = 0
        '
        'lblScraperOrder
        '
        Me.lblScraperOrder.AutoSize = True
        Me.lblScraperOrder.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScraperOrder.Location = New System.Drawing.Point(500, 7)
        Me.lblScraperOrder.Name = "lblScraperOrder"
        Me.lblScraperOrder.Size = New System.Drawing.Size(58, 12)
        Me.lblScraperOrder.TabIndex = 1
        Me.lblScraperOrder.Text = "Scraper order"
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Image = CType(resources.GetObject("btnDown.Image"), System.Drawing.Image)
        Me.btnDown.Location = New System.Drawing.Point(591, 1)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(23, 23)
        Me.btnDown.TabIndex = 3
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Image = CType(resources.GetObject("btnUp.Image"), System.Drawing.Image)
        Me.btnUp.Location = New System.Drawing.Point(566, 1)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(23, 23)
        Me.btnUp.TabIndex = 2
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'pnlSettings
        '
        Me.pnlSettings.Controls.Add(Me.Label1)
        Me.pnlSettings.Controls.Add(Me.PictureBox1)
        Me.pnlSettings.Controls.Add(Me.Panel1)
        Me.pnlSettings.Controls.Add(Me.gbGlobalOpts)
        Me.pnlSettings.Controls.Add(Me.gbScraperOpts)
        Me.pnlSettings.Location = New System.Drawing.Point(12, 4)
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.Size = New System.Drawing.Size(617, 369)
        Me.pnlSettings.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(37, 337)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "These settings are specific to this module." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please refer to the global settings " & _
    "for more options."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 335)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 96
        Me.PictureBox1.TabStop = False
        '
        'gbScraperOpts
        '
        Me.gbScraperOpts.Controls.Add(Me.chkPlot)
        Me.gbScraperOpts.Controls.Add(Me.chkTitle)
        Me.gbScraperOpts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbScraperOpts.Location = New System.Drawing.Point(11, 139)
        Me.gbScraperOpts.Name = "gbScraperOpts"
        Me.gbScraperOpts.Size = New System.Drawing.Size(210, 69)
        Me.gbScraperOpts.TabIndex = 3
        Me.gbScraperOpts.TabStop = False
        Me.gbScraperOpts.Text = "Scraper Fields - Scraper specific"
        '
        'chkPlot
        '
        Me.chkPlot.AutoSize = True
        Me.chkPlot.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPlot.Location = New System.Drawing.Point(6, 42)
        Me.chkPlot.Name = "chkPlot"
        Me.chkPlot.Size = New System.Drawing.Size(46, 17)
        Me.chkPlot.TabIndex = 10
        Me.chkPlot.Text = "Plot"
        Me.chkPlot.UseVisualStyleBackColor = True
        '
        'chkTitle
        '
        Me.chkTitle.AutoSize = True
        Me.chkTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTitle.Location = New System.Drawing.Point(6, 19)
        Me.chkTitle.Name = "chkTitle"
        Me.chkTitle.Size = New System.Drawing.Size(47, 17)
        Me.chkTitle.TabIndex = 0
        Me.chkTitle.Text = "Title"
        Me.chkTitle.UseVisualStyleBackColor = True
        '
        'frmTMDBInfoSettingsHolder_MovieSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(652, 388)
        Me.Controls.Add(Me.pnlSettings)
        Me.Controls.Add(Me.lblVersion)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTMDBInfoSettingsHolder_MovieSet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scraper Setup"
        Me.gbGlobalOpts.ResumeLayout(False)
        Me.gbGlobalOpts.PerformLayout()
        CType(Me.pbTMDBApiKeyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlSettings.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbScraperOpts.ResumeLayout(False)
        Me.gbScraperOpts.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents gbGlobalOpts As System.Windows.Forms.GroupBox
    Friend WithEvents lblApiKey As System.Windows.Forms.Label
    Friend WithEvents txtApiKey As System.Windows.Forms.TextBox
    Friend WithEvents cbEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlSettings As System.Windows.Forms.Panel
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents lblScraperOrder As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gbScraperOpts As System.Windows.Forms.GroupBox
    Friend WithEvents chkPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkTitle As System.Windows.Forms.CheckBox
    Friend WithEvents chkFallBackEng As System.Windows.Forms.CheckBox
    Friend WithEvents cbPrefLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrefLanguage As System.Windows.Forms.Label
    Friend WithEvents pbTMDBApiKeyInfo As System.Windows.Forms.PictureBox
    Friend WithEvents chkGetAdultItems As System.Windows.Forms.CheckBox
    Friend WithEvents lblEMMAPI As System.Windows.Forms.Label
    Friend WithEvents btnUnlockAPI As System.Windows.Forms.Button

End Class
