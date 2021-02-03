<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendorJobLookup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorJobLookup))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.chbJobProcessingDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFromProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chbTransaDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpfromTransDate = New System.Windows.Forms.DateTimePicker()
        Me.dtptoTransdate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtJboNumber = New System.Windows.Forms.TextBox()
        Me.chbJobNumber = New System.Windows.Forms.CheckBox()
        Me.dgvSucessJob = New System.Windows.Forms.DataGridView()
        Me.txtVendorId = New System.Windows.Forms.TextBox()
        Me.chbVendorId = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblErrorJobs = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chbErrorProcessingDate = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpErrorFromProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpErrorToProcessingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtErrorjobNumber = New System.Windows.Forms.TextBox()
        Me.chbErrorJobNumber = New System.Windows.Forms.CheckBox()
        Me.txtErrorVendorId = New System.Windows.Forms.TextBox()
        Me.chbErrorVendorID = New System.Windows.Forms.CheckBox()
        Me.dgvErrorJob = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridFilterExtender1 = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.DataGridFilterExtender2 = New GridViewExtensions.DataGridFilterExtender(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvSucessJob, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvErrorJob, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridFilterExtender2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Size = New System.Drawing.Size(885, 543)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.btnYes)
        Me.TabPage1.Controls.Add(Me.chbJobProcessingDate)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.chbTransaDate)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.txtJboNumber)
        Me.TabPage1.Controls.Add(Me.chbJobNumber)
        Me.TabPage1.Controls.Add(Me.dgvSucessJob)
        Me.TabPage1.Controls.Add(Me.txtVendorId)
        Me.TabPage1.Controls.Add(Me.chbVendorId)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(877, 514)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sucess Job Info Overview"
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.Transparent
        Me.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnYes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYes.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnYes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnYes.Location = New System.Drawing.Point(766, 31)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(93, 40)
        Me.btnYes.TabIndex = 29
        Me.btnYes.Text = "Search"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'chbJobProcessingDate
        '
        Me.chbJobProcessingDate.BackColor = System.Drawing.Color.Transparent
        Me.chbJobProcessingDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbJobProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbJobProcessingDate.ForeColor = System.Drawing.Color.Black
        Me.chbJobProcessingDate.Location = New System.Drawing.Point(507, 6)
        Me.chbJobProcessingDate.Name = "chbJobProcessingDate"
        Me.chbJobProcessingDate.Size = New System.Drawing.Size(213, 20)
        Me.chbJobProcessingDate.TabIndex = 24
        Me.chbJobProcessingDate.Text = "Job Processing Date"
        Me.chbJobProcessingDate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpFromProcessingDate)
        Me.GroupBox1.Controls.Add(Me.dtpToProcessingDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(507, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 50)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        '
        'dtpFromProcessingDate
        '
        Me.dtpFromProcessingDate.CustomFormat = "MM/dd/yy"
        Me.dtpFromProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromProcessingDate.Location = New System.Drawing.Point(57, 16)
        Me.dtpFromProcessingDate.Name = "dtpFromProcessingDate"
        Me.dtpFromProcessingDate.Size = New System.Drawing.Size(73, 23)
        Me.dtpFromProcessingDate.TabIndex = 1
        '
        'dtpToProcessingDate
        '
        Me.dtpToProcessingDate.CustomFormat = "MM/dd/yy"
        Me.dtpToProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToProcessingDate.Location = New System.Drawing.Point(169, 16)
        Me.dtpToProcessingDate.Name = "dtpToProcessingDate"
        Me.dtpToProcessingDate.Size = New System.Drawing.Size(73, 23)
        Me.dtpToProcessingDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(136, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "TO :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(9, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "From :"
        '
        'chbTransaDate
        '
        Me.chbTransaDate.BackColor = System.Drawing.Color.Transparent
        Me.chbTransaDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbTransaDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbTransaDate.ForeColor = System.Drawing.Color.Black
        Me.chbTransaDate.Location = New System.Drawing.Point(235, 6)
        Me.chbTransaDate.Name = "chbTransaDate"
        Me.chbTransaDate.Size = New System.Drawing.Size(213, 20)
        Me.chbTransaDate.TabIndex = 22
        Me.chbTransaDate.Text = "Trans Date Period"
        Me.chbTransaDate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtpfromTransDate)
        Me.GroupBox2.Controls.Add(Me.dtptoTransdate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Location = New System.Drawing.Point(235, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(257, 50)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        '
        'dtpfromTransDate
        '
        Me.dtpfromTransDate.CustomFormat = "MM/dd/yy"
        Me.dtpfromTransDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfromTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfromTransDate.Location = New System.Drawing.Point(57, 16)
        Me.dtpfromTransDate.Name = "dtpfromTransDate"
        Me.dtpfromTransDate.Size = New System.Drawing.Size(82, 23)
        Me.dtpfromTransDate.TabIndex = 1
        '
        'dtptoTransdate
        '
        Me.dtptoTransdate.CustomFormat = "MM/dd/yy"
        Me.dtptoTransdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptoTransdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptoTransdate.Location = New System.Drawing.Point(175, 17)
        Me.dtptoTransdate.Name = "dtptoTransdate"
        Me.dtptoTransdate.Size = New System.Drawing.Size(74, 23)
        Me.dtptoTransdate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(142, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "TO :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From :"
        '
        'txtJboNumber
        '
        Me.txtJboNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJboNumber.Enabled = False
        Me.txtJboNumber.Location = New System.Drawing.Point(102, 37)
        Me.txtJboNumber.Name = "txtJboNumber"
        Me.txtJboNumber.Size = New System.Drawing.Size(119, 23)
        Me.txtJboNumber.TabIndex = 6
        '
        'chbJobNumber
        '
        Me.chbJobNumber.AutoSize = True
        Me.chbJobNumber.BackColor = System.Drawing.Color.Transparent
        Me.chbJobNumber.Location = New System.Drawing.Point(9, 39)
        Me.chbJobNumber.Name = "chbJobNumber"
        Me.chbJobNumber.Size = New System.Drawing.Size(95, 20)
        Me.chbJobNumber.TabIndex = 5
        Me.chbJobNumber.Text = "Job Number"
        Me.chbJobNumber.UseVisualStyleBackColor = False
        '
        'dgvSucessJob
        '
        Me.dgvSucessJob.AllowUserToAddRows = False
        Me.dgvSucessJob.AllowUserToDeleteRows = False
        Me.dgvSucessJob.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvSucessJob.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSucessJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSucessJob.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSucessJob.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSucessJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSucessJob.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSucessJob.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvSucessJob.EnableHeadersVisualStyles = False
        Me.dgvSucessJob.GridColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSucessJob.Location = New System.Drawing.Point(3, 112)
        Me.dgvSucessJob.MultiSelect = False
        Me.dgvSucessJob.Name = "dgvSucessJob"
        Me.dgvSucessJob.ReadOnly = True
        Me.dgvSucessJob.RowHeadersVisible = False
        Me.dgvSucessJob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSucessJob.Size = New System.Drawing.Size(869, 397)
        Me.dgvSucessJob.TabIndex = 1
        '
        'txtVendorId
        '
        Me.txtVendorId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVendorId.Enabled = False
        Me.txtVendorId.Location = New System.Drawing.Point(102, 9)
        Me.txtVendorId.Name = "txtVendorId"
        Me.txtVendorId.Size = New System.Drawing.Size(119, 23)
        Me.txtVendorId.TabIndex = 4
        '
        'chbVendorId
        '
        Me.chbVendorId.AutoSize = True
        Me.chbVendorId.BackColor = System.Drawing.Color.Transparent
        Me.chbVendorId.Location = New System.Drawing.Point(9, 11)
        Me.chbVendorId.Name = "chbVendorId"
        Me.chbVendorId.Size = New System.Drawing.Size(84, 20)
        Me.chbVendorId.TabIndex = 3
        Me.chbVendorId.Text = "Vendor ID"
        Me.chbVendorId.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.lblErrorJobs)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.chbErrorProcessingDate)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.txtErrorjobNumber)
        Me.TabPage2.Controls.Add(Me.chbErrorJobNumber)
        Me.TabPage2.Controls.Add(Me.txtErrorVendorId)
        Me.TabPage2.Controls.Add(Me.chbErrorVendorID)
        Me.TabPage2.Controls.Add(Me.dgvErrorJob)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(877, 514)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Error Job Info"
        '
        'lblErrorJobs
        '
        Me.lblErrorJobs.AutoSize = True
        Me.lblErrorJobs.BackColor = System.Drawing.Color.Transparent
        Me.lblErrorJobs.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorJobs.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblErrorJobs.Location = New System.Drawing.Point(7, 62)
        Me.lblErrorJobs.Name = "lblErrorJobs"
        Me.lblErrorJobs.Size = New System.Drawing.Size(143, 19)
        Me.lblErrorJobs.TabIndex = 39
        Me.lblErrorJobs.Text = "Total Error Jobs: 0"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(510, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 40)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chbErrorProcessingDate
        '
        Me.chbErrorProcessingDate.BackColor = System.Drawing.Color.Transparent
        Me.chbErrorProcessingDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbErrorProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbErrorProcessingDate.ForeColor = System.Drawing.Color.Black
        Me.chbErrorProcessingDate.Location = New System.Drawing.Point(250, 6)
        Me.chbErrorProcessingDate.Name = "chbErrorProcessingDate"
        Me.chbErrorProcessingDate.Size = New System.Drawing.Size(213, 20)
        Me.chbErrorProcessingDate.TabIndex = 36
        Me.chbErrorProcessingDate.Text = "Job Processing Date"
        Me.chbErrorProcessingDate.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.dtpErrorFromProcessingDate)
        Me.GroupBox3.Controls.Add(Me.dtpErrorToProcessingDate)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(250, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(253, 50)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        '
        'dtpErrorFromProcessingDate
        '
        Me.dtpErrorFromProcessingDate.CustomFormat = "MM/dd/yy"
        Me.dtpErrorFromProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpErrorFromProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpErrorFromProcessingDate.Location = New System.Drawing.Point(57, 16)
        Me.dtpErrorFromProcessingDate.Name = "dtpErrorFromProcessingDate"
        Me.dtpErrorFromProcessingDate.Size = New System.Drawing.Size(73, 23)
        Me.dtpErrorFromProcessingDate.TabIndex = 1
        '
        'dtpErrorToProcessingDate
        '
        Me.dtpErrorToProcessingDate.CustomFormat = "MM/dd/yy"
        Me.dtpErrorToProcessingDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpErrorToProcessingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpErrorToProcessingDate.Location = New System.Drawing.Point(169, 16)
        Me.dtpErrorToProcessingDate.Name = "dtpErrorToProcessingDate"
        Me.dtpErrorToProcessingDate.Size = New System.Drawing.Size(73, 23)
        Me.dtpErrorToProcessingDate.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(136, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "TO :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "From :"
        '
        'txtErrorjobNumber
        '
        Me.txtErrorjobNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtErrorjobNumber.Enabled = False
        Me.txtErrorjobNumber.Location = New System.Drawing.Point(104, 37)
        Me.txtErrorjobNumber.Name = "txtErrorjobNumber"
        Me.txtErrorjobNumber.Size = New System.Drawing.Size(119, 23)
        Me.txtErrorjobNumber.TabIndex = 33
        '
        'chbErrorJobNumber
        '
        Me.chbErrorJobNumber.AutoSize = True
        Me.chbErrorJobNumber.BackColor = System.Drawing.Color.Transparent
        Me.chbErrorJobNumber.Location = New System.Drawing.Point(11, 39)
        Me.chbErrorJobNumber.Name = "chbErrorJobNumber"
        Me.chbErrorJobNumber.Size = New System.Drawing.Size(83, 17)
        Me.chbErrorJobNumber.TabIndex = 32
        Me.chbErrorJobNumber.Text = "Job Number"
        Me.chbErrorJobNumber.UseVisualStyleBackColor = False
        '
        'txtErrorVendorId
        '
        Me.txtErrorVendorId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtErrorVendorId.Enabled = False
        Me.txtErrorVendorId.Location = New System.Drawing.Point(104, 9)
        Me.txtErrorVendorId.Name = "txtErrorVendorId"
        Me.txtErrorVendorId.Size = New System.Drawing.Size(119, 23)
        Me.txtErrorVendorId.TabIndex = 31
        '
        'chbErrorVendorID
        '
        Me.chbErrorVendorID.AutoSize = True
        Me.chbErrorVendorID.BackColor = System.Drawing.Color.Transparent
        Me.chbErrorVendorID.Location = New System.Drawing.Point(11, 11)
        Me.chbErrorVendorID.Name = "chbErrorVendorID"
        Me.chbErrorVendorID.Size = New System.Drawing.Size(74, 17)
        Me.chbErrorVendorID.TabIndex = 30
        Me.chbErrorVendorID.Text = "Vendor ID"
        Me.chbErrorVendorID.UseVisualStyleBackColor = False
        '
        'dgvErrorJob
        '
        Me.dgvErrorJob.AllowUserToAddRows = False
        Me.dgvErrorJob.AllowUserToDeleteRows = False
        Me.dgvErrorJob.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.dgvErrorJob.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvErrorJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvErrorJob.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvErrorJob.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvErrorJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvErrorJob.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvErrorJob.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvErrorJob.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvErrorJob.EnableHeadersVisualStyles = False
        Me.dgvErrorJob.GridColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvErrorJob.Location = New System.Drawing.Point(3, 112)
        Me.dgvErrorJob.MultiSelect = False
        Me.dgvErrorJob.Name = "dgvErrorJob"
        Me.dgvErrorJob.RowHeadersVisible = False
        Me.dgvErrorJob.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvErrorJob.Size = New System.Drawing.Size(869, 397)
        Me.dgvErrorJob.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "Create Job"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 5
        '
        'DataGridFilterExtender1
        '
        Me.DataGridFilterExtender1.DataGridView = Me.dgvSucessJob
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
        Me.DataGridFilterExtender2.DataGridView = Me.dgvErrorJob
        DefaultGridFilterFactory2.CreateDistinctGridFilters = False
        DefaultGridFilterFactory2.DefaultGridFilterType = GetType(GridViewExtensions.GridFilters.TextGridFilter)
        DefaultGridFilterFactory2.DefaultShowDateInBetweenOperator = False
        DefaultGridFilterFactory2.DefaultShowNumericInBetweenOperator = False
        DefaultGridFilterFactory2.HandleEnumerationTypes = True
        DefaultGridFilterFactory2.MaximumDistinctValues = 20
        Me.DataGridFilterExtender2.FilterFactory = DefaultGridFilterFactory2
        Me.DataGridFilterExtender2.FilterTextVisible = False
        '
        'VendorJobLookup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 543)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "VendorJobLookup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Offering Job"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvSucessJob, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvErrorJob, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFilterExtender1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridFilterExtender2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSucessJob As System.Windows.Forms.DataGridView
    Friend WithEvents dgvErrorJob As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridFilterExtender1 As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents DataGridFilterExtender2 As GridViewExtensions.DataGridFilterExtender
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtVendorId As System.Windows.Forms.TextBox
    Friend WithEvents chbVendorId As System.Windows.Forms.CheckBox
    Friend WithEvents txtJboNumber As System.Windows.Forms.TextBox
    Friend WithEvents chbJobNumber As System.Windows.Forms.CheckBox
    Friend WithEvents chbTransaDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpfromTransDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtptoTransdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chbJobProcessingDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFromProcessingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToProcessingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chbErrorProcessingDate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpErrorFromProcessingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpErrorToProcessingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtErrorjobNumber As System.Windows.Forms.TextBox
    Friend WithEvents chbErrorJobNumber As System.Windows.Forms.CheckBox
    Friend WithEvents txtErrorVendorId As System.Windows.Forms.TextBox
    Friend WithEvents chbErrorVendorID As System.Windows.Forms.CheckBox
    Friend WithEvents lblErrorJobs As System.Windows.Forms.Label
End Class
