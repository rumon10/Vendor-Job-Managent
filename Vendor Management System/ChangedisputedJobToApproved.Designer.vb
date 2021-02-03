<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangedisputedJobToApproved
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DefaultGridFilterFactory1 As GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory = New GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory()
        Dim DefaultGridFilterFactory2 As GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory = New GridViewExtensions.GridFilterFactories.DefaultGridFilterFactory()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangedisputedJobToApproved))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExportDisputedJob = New System.Windows.Forms.Button()
        Me.btnDisplayDisputedJob = New System.Windows.Forms.Button()
        Me.dtpToTransDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFromTransDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDateReceived = New System.Windows.Forms.Label()
        Me.dgvDisputed = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnDisputedApprovedJobs = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFromTransDate1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvApprovedJobsFromDisputed = New System.Windows.Forms.DataGridView()
        Me.DataGridFilterExtender1 = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.DataGridFilterExtender2 = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.pnlActiveDisputedJob = New System.Windows.Forms.Panel()
        Me.chbDateFilterDisputed = New System.Windows.Forms.CheckBox()
        Me.pnlApprovedJobFilter = New System.Windows.Forms.Panel()
        Me.chbApprovedFilter = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvDisputed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvApprovedJobsFromDisputed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFilterExtender2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActiveDisputedJob.SuspendLayout()
        Me.pnlApprovedJobFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(914, 519)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.chbDateFilterDisputed)
        Me.TabPage1.Controls.Add(Me.pnlActiveDisputedJob)
        Me.TabPage1.Controls.Add(Me.dgvDisputed)
        Me.TabPage1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(906, 492)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Disputed Jobs"
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
        Me.btnExportDisputedJob.Location = New System.Drawing.Point(642, 4)
        Me.btnExportDisputedJob.Name = "btnExportDisputedJob"
        Me.btnExportDisputedJob.Size = New System.Drawing.Size(138, 26)
        Me.btnExportDisputedJob.TabIndex = 30
        Me.btnExportDisputedJob.Text = "Export Disputed Jobs"
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
        Me.btnDisplayDisputedJob.Location = New System.Drawing.Point(490, 4)
        Me.btnDisplayDisputedJob.Name = "btnDisplayDisputedJob"
        Me.btnDisplayDisputedJob.Size = New System.Drawing.Size(145, 26)
        Me.btnDisplayDisputedJob.TabIndex = 29
        Me.btnDisplayDisputedJob.Text = "Display Disputed Jobs"
        Me.btnDisplayDisputedJob.UseVisualStyleBackColor = False
        '
        'dtpToTransDate
        '
        Me.dtpToTransDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpToTransDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToTransDate.Location = New System.Drawing.Point(371, 4)
        Me.dtpToTransDate.Name = "dtpToTransDate"
        Me.dtpToTransDate.Size = New System.Drawing.Size(113, 26)
        Me.dtpToTransDate.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(252, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "To Trans Date :"
        '
        'dtpFromTransDate
        '
        Me.dtpFromTransDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpFromTransDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTransDate.Location = New System.Drawing.Point(138, 4)
        Me.dtpFromTransDate.Name = "dtpFromTransDate"
        Me.dtpFromTransDate.Size = New System.Drawing.Size(111, 26)
        Me.dtpFromTransDate.TabIndex = 13
        '
        'lblDateReceived
        '
        Me.lblDateReceived.AutoSize = True
        Me.lblDateReceived.BackColor = System.Drawing.Color.Transparent
        Me.lblDateReceived.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateReceived.Location = New System.Drawing.Point(5, 8)
        Me.lblDateReceived.Name = "lblDateReceived"
        Me.lblDateReceived.Size = New System.Drawing.Size(131, 18)
        Me.lblDateReceived.TabIndex = 11
        Me.lblDateReceived.Text = "From Trans Date :"
        '
        'dgvDisputed
        '
        Me.dgvDisputed.AllowUserToAddRows = False
        Me.dgvDisputed.AllowUserToDeleteRows = False
        Me.dgvDisputed.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvDisputed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDisputed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvDisputed.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDisputed.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDisputed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDisputed.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDisputed.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDisputed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDisputed.EnableHeadersVisualStyles = False
        Me.dgvDisputed.GridColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvDisputed.Location = New System.Drawing.Point(3, 62)
        Me.dgvDisputed.MultiSelect = False
        Me.dgvDisputed.Name = "dgvDisputed"
        Me.dgvDisputed.ReadOnly = True
        Me.dgvDisputed.RowHeadersVisible = False
        Me.dgvDisputed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDisputed.Size = New System.Drawing.Size(898, 425)
        Me.dgvDisputed.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "Approve"
        Me.Column1.ToolTipText = "Approve Disputed Job"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 5
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.chbApprovedFilter)
        Me.TabPage2.Controls.Add(Me.pnlApprovedJobFilter)
        Me.TabPage2.Controls.Add(Me.dgvApprovedJobsFromDisputed)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(906, 492)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Approved Job From Disputed"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(611, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(194, 26)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Export Disputed Approved Jobs"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnDisputedApprovedJobs
        '
        Me.btnDisputedApprovedJobs.BackColor = System.Drawing.Color.Transparent
        Me.btnDisputedApprovedJobs.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnDisputedApprovedJobs.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnDisputedApprovedJobs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDisputedApprovedJobs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnDisputedApprovedJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisputedApprovedJobs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisputedApprovedJobs.ForeColor = System.Drawing.Color.Black
        Me.btnDisputedApprovedJobs.Location = New System.Drawing.Point(421, 4)
        Me.btnDisputedApprovedJobs.Name = "btnDisputedApprovedJobs"
        Me.btnDisputedApprovedJobs.Size = New System.Drawing.Size(186, 26)
        Me.btnDisputedApprovedJobs.TabIndex = 37
        Me.btnDisputedApprovedJobs.Text = "View Disputed Approved Jobs"
        Me.btnDisputedApprovedJobs.UseVisualStyleBackColor = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(314, 4)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(102, 26)
        Me.dtpDate.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(243, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 18)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "To Date :"
        '
        'dtpFromTransDate1
        '
        Me.dtpFromTransDate1.CustomFormat = "MM/dd/yyyy"
        Me.dtpFromTransDate1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromTransDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromTransDate1.Location = New System.Drawing.Point(135, 3)
        Me.dtpFromTransDate1.Name = "dtpFromTransDate1"
        Me.dtpFromTransDate1.Size = New System.Drawing.Size(104, 26)
        Me.dtpFromTransDate1.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 18)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "From Trans Date :"
        '
        'dgvApprovedJobsFromDisputed
        '
        Me.dgvApprovedJobsFromDisputed.AllowUserToAddRows = False
        Me.dgvApprovedJobsFromDisputed.AllowUserToDeleteRows = False
        Me.dgvApprovedJobsFromDisputed.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgvApprovedJobsFromDisputed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvApprovedJobsFromDisputed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvApprovedJobsFromDisputed.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvApprovedJobsFromDisputed.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvApprovedJobsFromDisputed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvApprovedJobsFromDisputed.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvApprovedJobsFromDisputed.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvApprovedJobsFromDisputed.EnableHeadersVisualStyles = False
        Me.dgvApprovedJobsFromDisputed.GridColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvApprovedJobsFromDisputed.Location = New System.Drawing.Point(3, 63)
        Me.dgvApprovedJobsFromDisputed.MultiSelect = False
        Me.dgvApprovedJobsFromDisputed.Name = "dgvApprovedJobsFromDisputed"
        Me.dgvApprovedJobsFromDisputed.ReadOnly = True
        Me.dgvApprovedJobsFromDisputed.RowHeadersVisible = False
        Me.dgvApprovedJobsFromDisputed.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvApprovedJobsFromDisputed.Size = New System.Drawing.Size(898, 424)
        Me.dgvApprovedJobsFromDisputed.TabIndex = 4
        '
        'DataGridFilterExtender1
        '
        Me.DataGridFilterExtender1.DataGridView = Me.dgvDisputed
        DefaultGridFilterFactory1.CreateDistinctGridFilters = False
        DefaultGridFilterFactory1.DefaultGridFilterType = GetType(GridViewExtensions.GridFilters.TextGridFilter)
        DefaultGridFilterFactory1.DefaultShowDateInBetweenOperator = False
        DefaultGridFilterFactory1.DefaultShowNumericInBetweenOperator = False
        DefaultGridFilterFactory1.HandleEnumerationTypes = True
        DefaultGridFilterFactory1.MaximumDistinctValues = 20
        Me.DataGridFilterExtender1.FilterFactory = DefaultGridFilterFactory1
        Me.DataGridFilterExtender1.FilterTextVisible = False
        '
        'DataGridFilterExtender2
        '
        Me.DataGridFilterExtender2.DataGridView = Me.dgvApprovedJobsFromDisputed
        DefaultGridFilterFactory2.CreateDistinctGridFilters = False
        DefaultGridFilterFactory2.DefaultGridFilterType = GetType(GridViewExtensions.GridFilters.TextGridFilter)
        DefaultGridFilterFactory2.DefaultShowDateInBetweenOperator = False
        DefaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = False
        DefaultGridFilterFactory2.HandleEnumerationTypes = True
        DefaultGridFilterFactory2.MaximumDistinctValues = 20
        Me.DataGridFilterExtender2.FilterFactory = DefaultGridFilterFactory2
        '
        'pnlActiveDisputedJob
        '
        Me.pnlActiveDisputedJob.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlActiveDisputedJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlActiveDisputedJob.Controls.Add(Me.lblDateReceived)
        Me.pnlActiveDisputedJob.Controls.Add(Me.dtpFromTransDate)
        Me.pnlActiveDisputedJob.Controls.Add(Me.btnExportDisputedJob)
        Me.pnlActiveDisputedJob.Controls.Add(Me.Label1)
        Me.pnlActiveDisputedJob.Controls.Add(Me.btnDisplayDisputedJob)
        Me.pnlActiveDisputedJob.Controls.Add(Me.dtpToTransDate)
        Me.pnlActiveDisputedJob.Enabled = False
        Me.pnlActiveDisputedJob.Location = New System.Drawing.Point(117, 4)
        Me.pnlActiveDisputedJob.Name = "pnlActiveDisputedJob"
        Me.pnlActiveDisputedJob.Size = New System.Drawing.Size(786, 34)
        Me.pnlActiveDisputedJob.TabIndex = 32
        '
        'chbDateFilterDisputed
        '
        Me.chbDateFilterDisputed.AutoSize = True
        Me.chbDateFilterDisputed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDateFilterDisputed.Location = New System.Drawing.Point(8, 12)
        Me.chbDateFilterDisputed.Name = "chbDateFilterDisputed"
        Me.chbDateFilterDisputed.Size = New System.Drawing.Size(105, 20)
        Me.chbDateFilterDisputed.TabIndex = 33
        Me.chbDateFilterDisputed.Text = "Active Filter"
        Me.chbDateFilterDisputed.UseVisualStyleBackColor = True
        '
        'pnlApprovedJobFilter
        '
        Me.pnlApprovedJobFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.pnlApprovedJobFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApprovedJobFilter.Controls.Add(Me.Label3)
        Me.pnlApprovedJobFilter.Controls.Add(Me.dtpFromTransDate1)
        Me.pnlApprovedJobFilter.Controls.Add(Me.Button1)
        Me.pnlApprovedJobFilter.Controls.Add(Me.Label2)
        Me.pnlApprovedJobFilter.Controls.Add(Me.btnDisputedApprovedJobs)
        Me.pnlApprovedJobFilter.Controls.Add(Me.dtpDate)
        Me.pnlApprovedJobFilter.Enabled = False
        Me.pnlApprovedJobFilter.Location = New System.Drawing.Point(95, 4)
        Me.pnlApprovedJobFilter.Name = "pnlApprovedJobFilter"
        Me.pnlApprovedJobFilter.Size = New System.Drawing.Size(810, 34)
        Me.pnlApprovedJobFilter.TabIndex = 40
        '
        'chbApprovedFilter
        '
        Me.chbApprovedFilter.AutoSize = True
        Me.chbApprovedFilter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbApprovedFilter.Location = New System.Drawing.Point(3, 10)
        Me.chbApprovedFilter.Name = "chbApprovedFilter"
        Me.chbApprovedFilter.Size = New System.Drawing.Size(94, 20)
        Me.chbApprovedFilter.TabIndex = 41
        Me.chbApprovedFilter.Text = "Active Filter"
        Me.chbApprovedFilter.UseVisualStyleBackColor = True
        '
        'ChangedisputedJobToApproved
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(914, 519)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChangedisputedJobToApproved"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Approved Disputed Jobs"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvDisputed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvApprovedJobsFromDisputed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFilterExtender2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActiveDisputedJob.ResumeLayout(False)
        Me.pnlActiveDisputedJob.PerformLayout()
        Me.pnlApprovedJobFilter.ResumeLayout(False)
        Me.pnlApprovedJobFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvDisputed As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents dtpFromTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateReceived As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnDisplayDisputedJob As System.Windows.Forms.Button
    Friend WithEvents btnExportDisputedJob As System.Windows.Forms.Button
    Friend WithEvents dgvApprovedJobsFromDisputed As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnDisputedApprovedJobs As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFromTransDate1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridFilterExtender1 As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents DataGridFilterExtender2 As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents pnlActiveDisputedJob As System.Windows.Forms.Panel
    Friend WithEvents chbDateFilterDisputed As System.Windows.Forms.CheckBox
    Friend WithEvents pnlApprovedJobFilter As System.Windows.Forms.Panel
    Friend WithEvents chbApprovedFilter As System.Windows.Forms.CheckBox
End Class
