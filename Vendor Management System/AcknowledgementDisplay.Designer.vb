<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AcknowledgementDisplay
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DefaultGridFilterFactory1 As GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory = New GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AcknowledgementDisplay))
        Me.btnExportDisputedJob = New System.Windows.Forms.Button()
        Me.btnDisplayDisputedJob = New System.Windows.Forms.Button()
        Me.dtpToTransDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFromTransDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.dgvAcknowledgementsjob = New System.Windows.Forms.DataGridView()
        Me.DataGridFilterExtender1 = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.pnlAcknowledgeJobs = New System.Windows.Forms.Panel()
        Me.chbActive = New System.Windows.Forms.CheckBox()
        CType(Me.dgvAcknowledgementsjob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcknowledgeJobs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExportDisputedJob
        '
        Me.btnExportDisputedJob.BackColor = System.Drawing.Color.Transparent
        Me.btnExportDisputedJob.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnExportDisputedJob.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnExportDisputedJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExportDisputedJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnExportDisputedJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportDisputedJob.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportDisputedJob.ForeColor = System.Drawing.Color.Black
        Me.btnExportDisputedJob.Location = New System.Drawing.Point(619, 8)
        Me.btnExportDisputedJob.Name = "btnExportDisputedJob"
        Me.btnExportDisputedJob.Size = New System.Drawing.Size(203, 26)
        Me.btnExportDisputedJob.TabIndex = 37
        Me.btnExportDisputedJob.Text = "Export Acknowledgement Jobs"
        Me.btnExportDisputedJob.UseVisualStyleBackColor = False
        '
        'btnDisplayDisputedJob
        '
        Me.btnDisplayDisputedJob.BackColor = System.Drawing.Color.Transparent
        Me.btnDisplayDisputedJob.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnDisplayDisputedJob.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnDisplayDisputedJob.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDisplayDisputedJob.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnDisplayDisputedJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplayDisputedJob.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisplayDisputedJob.ForeColor = System.Drawing.Color.Black
        Me.btnDisplayDisputedJob.Location = New System.Drawing.Point(455, 8)
        Me.btnDisplayDisputedJob.Name = "btnDisplayDisputedJob"
        Me.btnDisplayDisputedJob.Size = New System.Drawing.Size(160, 26)
        Me.btnDisplayDisputedJob.TabIndex = 36
        Me.btnDisplayDisputedJob.Text = "Acknowledgement Jobs"
        Me.btnDisplayDisputedJob.UseVisualStyleBackColor = False
        '
        'dtpToTransDate
        '
        Me.dtpToTransDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpToTransDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTransDate.Location = New System.Drawing.Point(335, 7)
        Me.dtpToTransDate.Name = "dtpToTransDate"
        Me.dtpToTransDate.Size = New System.Drawing.Size(112, 26)
        Me.dtpToTransDate.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(257, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "To Date :"
        '
        'dtpFromTransDate
        '
        Me.dtpFromTransDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpFromTransDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTransDate.Location = New System.Drawing.Point(148, 7)
        Me.dtpFromTransDate.Name = "dtpFromTransDate"
        Me.dtpFromTransDate.Size = New System.Drawing.Size(101, 26)
        Me.dtpFromTransDate.TabIndex = 33
        '
        'lblDateReceived
        '
        Me.lblDateReceived.AutoSize = True
        Me.lblDateReceived.BackColor = System.Drawing.Color.Transparent
        Me.lblDateReceived.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateReceived.Location = New System.Drawing.Point(14, 12)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Size = New System.Drawing.Size(131, 18)
        Me.lblDateReceived.TabIndex = 32
        Me.lblDateReceived.Text = "From Trans Date :"
        '
        'dgvAcknowledgementsjob
        '
        Me.dgvAcknowledgementsjob.AllowUserToAddRows = False
        Me.dgvAcknowledgementsjob.AllowUserToDeleteRows = False
        Me.dgvAcknowledgementsjob.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvAcknowledgementsjob.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAcknowledgementsjob.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAcknowledgementsjob.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAcknowledgementsjob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAcknowledgementsjob.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAcknowledgementsjob.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvAcknowledgementsjob.EnableHeadersVisualStyles = False
        Me.dgvAcknowledgementsjob.GridColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAcknowledgementsjob.Location = New System.Drawing.Point(5, 64)
        Me.dgvAcknowledgementsjob.MultiSelect = False
        Me.dgvAcknowledgementsjob.Name = "dgvAcknowledgementsjob"
        Me.dgvAcknowledgementsjob.ReadOnly = True
        Me.dgvAcknowledgementsjob.RowHeadersVisible = False
        Me.dgvAcknowledgementsjob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAcknowledgementsjob.Size = New System.Drawing.Size(892, 496)
        Me.dgvAcknowledgementsjob.TabIndex = 31
        '
        'DataGridFilterExtender1
        '
        Me.DataGridFilterExtender1.DataGridView = Me.dgvAcknowledgementsjob
        DefaultGridFilterFactory1.CreateDistinctGridFilters = False
        DefaultGridFilterFactory1.DefaultGridFilterType = GetType(GridViewExtensions.GridFilters.TextGridFilter)
        DefaultGridFilterFactory1.DefaultShowDateInBetweenOperator = False
        DefaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = False
        DefaultGridFilterFactory1.HandleEnumerationTypes = True
        DefaultGridFilterFactory1.MaximumDistinctValues = 20
        Me.DataGridFilterExtender1.FilterFactory = DefaultGridFilterFactory1
        Me.DataGridFilterExtender1.FilterTextVisible = False
        '
        'pnlAcknowledgeJobs
        '
        Me.pnlAcknowledgeJobs.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlAcknowledgeJobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAcknowledgeJobs.Controls.Add(Me.lblDateReceived)
        Me.pnlAcknowledgeJobs.Controls.Add(Me.dtpFromTransDate)
        Me.pnlAcknowledgeJobs.Controls.Add(Me.btnExportDisputedJob)
        Me.pnlAcknowledgeJobs.Controls.Add(Me.Label1)
        Me.pnlAcknowledgeJobs.Controls.Add(Me.btnDisplayDisputedJob)
        Me.pnlAcknowledgeJobs.Controls.Add(Me.dtpToTransDate)
        Me.pnlAcknowledgeJobs.Enabled = False
        Me.pnlAcknowledgeJobs.Location = New System.Drawing.Point(72, 1)
        Me.pnlAcknowledgeJobs.Name = "pnlAcknowledgeJobs"
        Me.pnlAcknowledgeJobs.Size = New System.Drawing.Size(827, 43)
        Me.pnlAcknowledgeJobs.TabIndex = 39
        '
        'chbActive
        '
        Me.chbActive.AutoSize = True
        Me.chbActive.BackColor = System.Drawing.Color.Transparent
        Me.chbActive.Location = New System.Drawing.Point(5, 11)
        Me.chbActive.Name = "chbActive"
        Me.chbActive.Size = New System.Drawing.Size(61, 20)
        Me.chbActive.TabIndex = 40
        Me.chbActive.Text = "Active"
        Me.chbActive.UseVisualStyleBackColor = False
        '
        'AcknowledgementDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(902, 565)
        Me.Controls.Add(Me.chbActive)
        Me.Controls.Add(Me.pnlAcknowledgeJobs)
        Me.Controls.Add(Me.dgvAcknowledgementsjob)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AcknowledgementDisplay"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acknowledgement Jobs"
        CType(Me.dgvAcknowledgementsjob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcknowledgeJobs.ResumeLayout(False)
        Me.pnlAcknowledgeJobs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExportDisputedJob As System.Windows.Forms.Button
    Friend WithEvents btnDisplayDisputedJob As System.Windows.Forms.Button
    Friend WithEvents dtpToTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateReceived As System.Windows.Forms.Label
    Friend WithEvents dgvAcknowledgementsjob As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridFilterExtender1 As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents pnlAcknowledgeJobs As System.Windows.Forms.Panel
    Friend WithEvents chbActive As System.Windows.Forms.CheckBox
End Class
