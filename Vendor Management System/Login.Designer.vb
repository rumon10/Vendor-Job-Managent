<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.usernametxt = New System.Windows.Forms.TextBox()
        Me.passwordtxt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.exitbtn = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dllAccessType = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.loginbtn = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnZero = New System.Windows.Forms.Button()
        Me.btnTab = New System.Windows.Forms.Button()
        Me.btnNine = New System.Windows.Forms.Button()
        Me.btnEgith = New System.Windows.Forms.Button()
        Me.btnSeven = New System.Windows.Forms.Button()
        Me.btnSix = New System.Windows.Forms.Button()
        Me.btnFive = New System.Windows.Forms.Button()
        Me.btnFour = New System.Windows.Forms.Button()
        Me.btnThree = New System.Windows.Forms.Button()
        Me.btnTwo = New System.Windows.Forms.Button()
        Me.btnOne = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(55, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name"
        '
        'usernametxt
        '
        Me.usernametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usernametxt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernametxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.usernametxt.Location = New System.Drawing.Point(148, 64)
        Me.usernametxt.Name = "usernametxt"
        Me.usernametxt.Size = New System.Drawing.Size(205, 27)
        Me.usernametxt.TabIndex = 1
        '
        'passwordtxt
        '
        Me.passwordtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.passwordtxt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordtxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.passwordtxt.Location = New System.Drawing.Point(148, 95)
        Me.passwordtxt.Name = "passwordtxt"
        Me.passwordtxt.Size = New System.Drawing.Size(205, 27)
        Me.passwordtxt.TabIndex = 2
        Me.passwordtxt.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(56, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'exitbtn
        '
        Me.exitbtn.BackColor = System.Drawing.Color.Transparent
        Me.exitbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.exitbtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.exitbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.exitbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitbtn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitbtn.ForeColor = System.Drawing.Color.Firebrick
        Me.exitbtn.Location = New System.Drawing.Point(253, 130)
        Me.exitbtn.Name = "exitbtn"
        Me.exitbtn.Size = New System.Drawing.Size(83, 28)
        Me.exitbtn.TabIndex = 4
        Me.exitbtn.Text = "Quit"
        Me.exitbtn.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.Label3.Location = New System.Drawing.Point(15, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(182, 56)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Vendor Job" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Management System" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Version-6.0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(55, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "User Type"
        '
        'dllAccessType
        '
        Me.dllAccessType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.dllAccessType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.dllAccessType.BackColor = System.Drawing.Color.White
        Me.dllAccessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dllAccessType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.dllAccessType.FormattingEnabled = True
        Me.dllAccessType.Items.AddRange(New Object() {"System Admin", "Vendor"})
        Me.dllAccessType.Location = New System.Drawing.Point(148, 35)
        Me.dllAccessType.Name = "dllAccessType"
        Me.dllAccessType.Size = New System.Drawing.Size(205, 24)
        Me.dllAccessType.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.passwordtxt)
        Me.GroupBox1.Controls.Add(Me.dllAccessType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.usernametxt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.exitbtn)
        Me.GroupBox1.Controls.Add(Me.loginbtn)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox1.Location = New System.Drawing.Point(15, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(428, 171)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Login"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(130, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(13, 16)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(130, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(130, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(13, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = ":"
        '
        'loginbtn
        '
        Me.loginbtn.BackColor = System.Drawing.Color.Transparent
        Me.loginbtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.loginbtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.loginbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.loginbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginbtn.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.loginbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.loginbtn.Location = New System.Drawing.Point(164, 130)
        Me.loginbtn.Name = "loginbtn"
        Me.loginbtn.Size = New System.Drawing.Size(83, 28)
        Me.loginbtn.TabIndex = 3
        Me.loginbtn.Text = "Login"
        Me.loginbtn.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnEnter)
        Me.GroupBox2.Controls.Add(Me.btnZero)
        Me.GroupBox2.Controls.Add(Me.btnTab)
        Me.GroupBox2.Controls.Add(Me.btnNine)
        Me.GroupBox2.Controls.Add(Me.btnEgith)
        Me.GroupBox2.Controls.Add(Me.btnSeven)
        Me.GroupBox2.Controls.Add(Me.btnSix)
        Me.GroupBox2.Controls.Add(Me.btnFive)
        Me.GroupBox2.Controls.Add(Me.btnFour)
        Me.GroupBox2.Controls.Add(Me.btnThree)
        Me.GroupBox2.Controls.Add(Me.btnTwo)
        Me.GroupBox2.Controls.Add(Me.btnOne)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox2.Location = New System.Drawing.Point(222, 190)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 190)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Number Pad"
        '
        'btnEnter
        '
        Me.btnEnter.BackColor = System.Drawing.Color.Transparent
        Me.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEnter.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnEnter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEnter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnEnter.Location = New System.Drawing.Point(148, 142)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(54, 32)
        Me.btnEnter.TabIndex = 16
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = False
        '
        'btnZero
        '
        Me.btnZero.BackColor = System.Drawing.Color.Transparent
        Me.btnZero.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnZero.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZero.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnZero.Location = New System.Drawing.Point(82, 142)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Size = New System.Drawing.Size(54, 32)
        Me.btnZero.TabIndex = 15
        Me.btnZero.Text = "0"
        Me.btnZero.UseVisualStyleBackColor = False
        '
        'btnTab
        '
        Me.btnTab.BackColor = System.Drawing.Color.Transparent
        Me.btnTab.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnTab.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTab.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTab.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnTab.Location = New System.Drawing.Point(16, 142)
        Me.btnTab.Name = "btnTab"
        Me.btnTab.Size = New System.Drawing.Size(54, 32)
        Me.btnTab.TabIndex = 14
        Me.btnTab.Text = "Tab"
        Me.btnTab.UseVisualStyleBackColor = False
        '
        'btnNine
        '
        Me.btnNine.BackColor = System.Drawing.Color.Transparent
        Me.btnNine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnNine.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnNine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnNine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnNine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNine.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNine.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnNine.Location = New System.Drawing.Point(148, 104)
        Me.btnNine.Name = "btnNine"
        Me.btnNine.Size = New System.Drawing.Size(54, 32)
        Me.btnNine.TabIndex = 13
        Me.btnNine.Text = "9"
        Me.btnNine.UseVisualStyleBackColor = False
        '
        'btnEgith
        '
        Me.btnEgith.BackColor = System.Drawing.Color.Transparent
        Me.btnEgith.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnEgith.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnEgith.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnEgith.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnEgith.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEgith.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEgith.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnEgith.Location = New System.Drawing.Point(82, 104)
        Me.btnEgith.Name = "btnEgith"
        Me.btnEgith.Size = New System.Drawing.Size(54, 32)
        Me.btnEgith.TabIndex = 12
        Me.btnEgith.Text = "8"
        Me.btnEgith.UseVisualStyleBackColor = False
        '
        'btnSeven
        '
        Me.btnSeven.BackColor = System.Drawing.Color.Transparent
        Me.btnSeven.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSeven.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSeven.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSeven.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSeven.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeven.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeven.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSeven.Location = New System.Drawing.Point(16, 104)
        Me.btnSeven.Name = "btnSeven"
        Me.btnSeven.Size = New System.Drawing.Size(54, 32)
        Me.btnSeven.TabIndex = 11
        Me.btnSeven.Text = "7"
        Me.btnSeven.UseVisualStyleBackColor = False
        '
        'btnSix
        '
        Me.btnSix.BackColor = System.Drawing.Color.Transparent
        Me.btnSix.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnSix.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSix.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSix.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSix.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnSix.Location = New System.Drawing.Point(148, 66)
        Me.btnSix.Name = "btnSix"
        Me.btnSix.Size = New System.Drawing.Size(54, 32)
        Me.btnSix.TabIndex = 10
        Me.btnSix.Text = "6"
        Me.btnSix.UseVisualStyleBackColor = False
        '
        'btnFive
        '
        Me.btnFive.BackColor = System.Drawing.Color.Transparent
        Me.btnFive.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnFive.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnFive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnFive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFive.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnFive.Location = New System.Drawing.Point(82, 66)
        Me.btnFive.Name = "btnFive"
        Me.btnFive.Size = New System.Drawing.Size(54, 32)
        Me.btnFive.TabIndex = 9
        Me.btnFive.Text = "5"
        Me.btnFive.UseVisualStyleBackColor = False
        '
        'btnFour
        '
        Me.btnFour.BackColor = System.Drawing.Color.Transparent
        Me.btnFour.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnFour.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnFour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnFour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnFour.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFour.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFour.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnFour.Location = New System.Drawing.Point(16, 66)
        Me.btnFour.Name = "btnFour"
        Me.btnFour.Size = New System.Drawing.Size(54, 32)
        Me.btnFour.TabIndex = 8
        Me.btnFour.Text = "4"
        Me.btnFour.UseVisualStyleBackColor = False
        '
        'btnThree
        '
        Me.btnThree.BackColor = System.Drawing.Color.Transparent
        Me.btnThree.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnThree.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnThree.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnThree.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnThree.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnThree.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnThree.Location = New System.Drawing.Point(148, 28)
        Me.btnThree.Name = "btnThree"
        Me.btnThree.Size = New System.Drawing.Size(54, 32)
        Me.btnThree.TabIndex = 7
        Me.btnThree.Text = "3"
        Me.btnThree.UseVisualStyleBackColor = False
        '
        'btnTwo
        '
        Me.btnTwo.BackColor = System.Drawing.Color.Transparent
        Me.btnTwo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnTwo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnTwo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnTwo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnTwo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTwo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTwo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnTwo.Location = New System.Drawing.Point(82, 28)
        Me.btnTwo.Name = "btnTwo"
        Me.btnTwo.Size = New System.Drawing.Size(54, 32)
        Me.btnTwo.TabIndex = 6
        Me.btnTwo.Text = "2"
        Me.btnTwo.UseVisualStyleBackColor = False
        '
        'btnOne
        '
        Me.btnOne.BackColor = System.Drawing.Color.Transparent
        Me.btnOne.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.btnOne.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnOne.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnOne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(152, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOne.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOne.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnOne.Location = New System.Drawing.Point(16, 28)
        Me.btnOne.Name = "btnOne"
        Me.btnOne.Size = New System.Drawing.Size(54, 32)
        Me.btnOne.TabIndex = 5
        Me.btnOne.Text = "1"
        Me.btnOne.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 186)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 141)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(461, 401)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendor Job Management System"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents usernametxt As System.Windows.Forms.TextBox
    Friend WithEvents passwordtxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents exitbtn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dllAccessType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents loginbtn As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnZero As System.Windows.Forms.Button
    Friend WithEvents btnTab As System.Windows.Forms.Button
    Friend WithEvents btnNine As System.Windows.Forms.Button
    Friend WithEvents btnEgith As System.Windows.Forms.Button
    Friend WithEvents btnSeven As System.Windows.Forms.Button
    Friend WithEvents btnSix As System.Windows.Forms.Button
    Friend WithEvents btnFive As System.Windows.Forms.Button
    Friend WithEvents btnFour As System.Windows.Forms.Button
    Friend WithEvents btnThree As System.Windows.Forms.Button
    Friend WithEvents btnTwo As System.Windows.Forms.Button
    Friend WithEvents btnOne As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
