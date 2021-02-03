<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainform))
        Me.main = New System.Windows.Forms.MenuStrip()
        Me.VendorManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JobProcessingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HomeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbUserMaping = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbusername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbFullUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbLoginDatetimeMaping = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llbLogindatetime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRoleHeader = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSoftTile = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeaderVendorName = New System.Windows.Forms.Label()
        Me.lblHeaderVendorId = New System.Windows.Forms.Label()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.main.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'main
        '
        Me.main.AutoSize = False
        Me.main.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.main.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VendorManagementToolStripMenuItem, Me.JobProcessingToolStripMenuItem, Me.ToolStripMenuItem1, Me.HomeToolStripMenuItem1, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem5, Me.ToolStripMenuItem4})
        Me.main.Location = New System.Drawing.Point(0, 0)
        Me.main.Name = "main"
        Me.main.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.main.Size = New System.Drawing.Size(1028, 30)
        Me.main.TabIndex = 0
        Me.main.Text = "MenuStrip1"
        Me.main.Visible = False
        '
        'VendorManagementToolStripMenuItem
        '
        Me.VendorManagementToolStripMenuItem.Checked = True
        Me.VendorManagementToolStripMenuItem.CheckOnClick = True
        Me.VendorManagementToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.VendorManagementToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.VendorManagementToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.VendorManagementToolStripMenuItem.Name = "VendorManagementToolStripMenuItem"
        Me.VendorManagementToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.VendorManagementToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.VendorManagementToolStripMenuItem.Size = New System.Drawing.Size(151, 26)
        Me.VendorManagementToolStripMenuItem.Text = "Vendor Management"
        '
        'JobProcessingToolStripMenuItem
        '
        Me.JobProcessingToolStripMenuItem.Checked = True
        Me.JobProcessingToolStripMenuItem.CheckOnClick = True
        Me.JobProcessingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.JobProcessingToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.JobProcessingToolStripMenuItem.Name = "JobProcessingToolStripMenuItem"
        Me.JobProcessingToolStripMenuItem.Size = New System.Drawing.Size(116, 26)
        Me.JobProcessingToolStripMenuItem.Text = "Job Processing"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(79, 26)
        Me.ToolStripMenuItem1.Text = "Job Offer"
        '
        'HomeToolStripMenuItem1
        '
        Me.HomeToolStripMenuItem1.Name = "HomeToolStripMenuItem1"
        Me.HomeToolStripMenuItem1.Size = New System.Drawing.Size(93, 26)
        Me.HomeToolStripMenuItem1.Text = "Job History"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(178, 26)
        Me.ToolStripMenuItem6.Text = "Approved Disputed Jobs"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(128, 26)
        Me.ToolStripMenuItem2.Text = "Create New User"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(135, 26)
        Me.ToolStripMenuItem3.Text = "Change Password"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(87, 26)
        Me.ToolStripMenuItem5.Text = "DB Backup"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(28, 26)
        Me.ToolStripMenuItem4.ToolTipText = "Lock Screen"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(119, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel6, Me.llbRole, Me.llbUserMaping, Me.llbusername, Me.ToolStripStatusLabel5, Me.llbFullUser, Me.llbLoginDatetimeMaping, Me.llbLogindatetime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 571)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 30)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel3.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(61, 26)
        Me.ToolStripStatusLabel3.Text = "Network"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(74, 26)
        Me.ToolStripStatusLabel1.Text = "Connected"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel6.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel6.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel6.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(74, 26)
        Me.ToolStripStatusLabel6.Text = "Login Role"
        '
        'llbRole
        '
        Me.llbRole.BackColor = System.Drawing.Color.Transparent
        Me.llbRole.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbRole.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbRole.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbRole.ForeColor = System.Drawing.Color.Black
        Me.llbRole.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.llbRole.Name = "llbRole"
        Me.llbRole.Size = New System.Drawing.Size(55, 26)
        Me.llbRole.Text = "Vendor"
        '
        'llbUserMaping
        '
        Me.llbUserMaping.BackColor = System.Drawing.Color.Transparent
        Me.llbUserMaping.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbUserMaping.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbUserMaping.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbUserMaping.ForeColor = System.Drawing.Color.Black
        Me.llbUserMaping.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.llbUserMaping.Name = "llbUserMaping"
        Me.llbUserMaping.Size = New System.Drawing.Size(78, 26)
        Me.llbUserMaping.Text = "User Name"
        '
        'llbusername
        '
        Me.llbusername.BackColor = System.Drawing.Color.Transparent
        Me.llbusername.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbusername.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbusername.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbusername.ForeColor = System.Drawing.Color.Black
        Me.llbusername.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.llbusername.Name = "llbusername"
        Me.llbusername.Size = New System.Drawing.Size(4, 26)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel5.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel5.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.ToolStripStatusLabel5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel5.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel5.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(47, 26)
        Me.ToolStripStatusLabel5.Text = "Name"
        '
        'llbFullUser
        '
        Me.llbFullUser.BackColor = System.Drawing.Color.Transparent
        Me.llbFullUser.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbFullUser.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbFullUser.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbFullUser.ForeColor = System.Drawing.Color.Black
        Me.llbFullUser.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.llbFullUser.Name = "llbFullUser"
        Me.llbFullUser.Size = New System.Drawing.Size(4, 26)
        '
        'llbLoginDatetimeMaping
        '
        Me.llbLoginDatetimeMaping.BackColor = System.Drawing.Color.Transparent
        Me.llbLoginDatetimeMaping.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbLoginDatetimeMaping.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbLoginDatetimeMaping.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbLoginDatetimeMaping.ForeColor = System.Drawing.Color.Black
        Me.llbLoginDatetimeMaping.Margin = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.llbLoginDatetimeMaping.Name = "llbLoginDatetimeMaping"
        Me.llbLoginDatetimeMaping.Size = New System.Drawing.Size(121, 26)
        Me.llbLoginDatetimeMaping.Text = "Login Date && Time"
        '
        'llbLogindatetime
        '
        Me.llbLogindatetime.BackColor = System.Drawing.Color.Transparent
        Me.llbLogindatetime.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.llbLogindatetime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken
        Me.llbLogindatetime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbLogindatetime.ForeColor = System.Drawing.Color.Black
        Me.llbLogindatetime.Name = "llbLogindatetime"
        Me.llbLogindatetime.Size = New System.Drawing.Size(4, 25)
        '
        'lblRoleHeader
        '
        Me.lblRoleHeader.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lblRoleHeader.Location = New System.Drawing.Point(0, 31)
        Me.lblRoleHeader.Name = "lblRoleHeader"
        Me.lblRoleHeader.Size = New System.Drawing.Size(1030, 2)
        Me.lblRoleHeader.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LemonChiffon
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 569)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1028, 2)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Label2"
        '
        'lblSoftTile
        '
        Me.lblSoftTile.BackColor = System.Drawing.Color.Transparent
        Me.lblSoftTile.Font = New System.Drawing.Font("Lucida Sans", 65.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoftTile.ForeColor = System.Drawing.Color.LightYellow
        Me.lblSoftTile.Location = New System.Drawing.Point(3, 42)
        Me.lblSoftTile.Name = "lblSoftTile"
        Me.lblSoftTile.Size = New System.Drawing.Size(1025, 469)
        Me.lblSoftTile.TabIndex = 4
        Me.lblSoftTile.Text = "Vendor Job Management System"
        Me.lblSoftTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMain
        '
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 30)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1028, 539)
        Me.pnlMain.TabIndex = 5
        Me.pnlMain.Visible = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.lblHeaderVendorName)
        Me.pnlHeader.Controls.Add(Me.lblHeaderVendorId)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 30)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1028, 30)
        Me.pnlHeader.TabIndex = 6
        '
        'lblHeaderVendorName
        '
        Me.lblHeaderVendorName.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderVendorName.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblHeaderVendorName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderVendorName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.lblHeaderVendorName.Location = New System.Drawing.Point(474, 0)
        Me.lblHeaderVendorName.Name = "lblHeaderVendorName"
        Me.lblHeaderVendorName.Size = New System.Drawing.Size(554, 30)
        Me.lblHeaderVendorName.TabIndex = 7
        Me.lblHeaderVendorName.Text = "Vendor Name : Rumon Kumar Prosad"
        Me.lblHeaderVendorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHeaderVendorId
        '
        Me.lblHeaderVendorId.BackColor = System.Drawing.Color.Transparent
        Me.lblHeaderVendorId.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblHeaderVendorId.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderVendorId.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.lblHeaderVendorId.Location = New System.Drawing.Point(0, 0)
        Me.lblHeaderVendorId.Name = "lblHeaderVendorId"
        Me.lblHeaderVendorId.Size = New System.Drawing.Size(468, 30)
        Me.lblHeaderVendorId.TabIndex = 7
        Me.lblHeaderVendorId.Text = "Vendor ID : 0"
        Me.lblHeaderVendorId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(138, 26)
        Me.ToolStripMenuItem7.Text = "Acknowlegements"
        '
        'Mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 601)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.lblSoftTile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblRoleHeader)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.main)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.main
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Mainform"
        Me.Text = "Vendor Job Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.main.ResumeLayout(False)
        Me.main.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents main As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbusername As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbLoginDatetimeMaping As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbLogindatetime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbUserMaping As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbFullUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llbRole As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRoleHeader As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSoftTile As System.Windows.Forms.Label
    Friend WithEvents VendorManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JobProcessingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderVendorId As System.Windows.Forms.Label
    Friend WithEvents lblHeaderVendorName As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
End Class
