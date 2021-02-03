Imports BusinessAccessLayer
Imports System.Drawing.Drawing2D

Public Class Mainform
    Public userAccess As Integer = -1

    Dim usrcreation As UserCreationBAL = New UserCreationBAL()

    Delegate Sub NewRegistrations()

    ' Other methods and properties
    Private mfound As NewRegistrations

    Public Sub RegisterClient(ByVal found As NewRegistrations)
        Mfound = found
    End Sub

    Private Sub Mainform_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
    Private Sub VendorInformationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim vendorinformation As VendorInformation = New VendorInformation()
        vendorinformation.Show()
    End Sub

    Private Sub InventoryManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim inventory As VendorInformation = New VendorInformation()
        inventory.Show()
    End Sub
    Private Sub ProductSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim obj As fromUserCreation = New fromUserCreation()
        obj.Show()
    End Sub
    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim changepassword As fromChangePassword = New fromChangePassword()
        changepassword.Show()
    End Sub

    Private Sub Mainform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
           
            Me.main.Visible = False
            Me.pnlHeader.Visible = False
            Me.lblRoleHeader.Width = Me.Width

            'Setup Login User Information'
            llbusername.Text = usrcreation.GetExistingUsername()
            llbFullUser.Text = usrcreation.GetExistingUserFullName()
            llbLogindatetime.Text = DateAndTime.Now.ToString("F")
            llbLoginDatetimeMaping.Text = "Login Date && Time"
            Dim acessRole = usrcreation.GetExistingUserRole()
            llbRole.Text = acessRole

                If Me.userAccess = 0 Then
                    llbUserMaping.Text = "User Name"
                ElseIf Me.userAccess = 1 Then
                    llbUserMaping.Text = "Vendor ID"
            End If

                'Setup User Access Role'
                AccessSetting(acessRole)

            Me.SetFontSize()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetFontSize()
        lblSoftTile.Top = (Me.Height - lblSoftTile.Height) / 2
        lblSoftTile.Left = Me.Left
        lblSoftTile.Width = Me.Width
        Dim fontSize As Single = lblSoftTile.Width * 0.06342
        lblSoftTile.Font = New System.Drawing.Font("Lucida Sans", fontSize, FontStyle.Bold)
    End Sub
    Private Function AccessSetting(ByVal Role As String)
        Try
            If Me.userAccess = 0 Then
                Me.main.Visible = True
                Me.pnlHeader.Visible = False

            ElseIf Me.userAccess = 1 Then
                Me.main.Visible = False
                pnlHeader.Visible = True
                lblHeaderVendorId.Visible = True
                lblHeaderVendorName.Visible = True
                lblHeaderVendorId.Text = "  Vendor ID : " + usrcreation.GetExistingUserId()
                lblHeaderVendorName.Text = "Name : " + usrcreation.GetExistingUserFullName() + "    "

                'Setup Vendor User Control'
                Dim customeruc As VendorJobs = New VendorJobs()
                Me.lblSoftTile.Visible = False
                Me.pnlMain.Controls.Clear()
                Me.Controls.Add(Me.pnlMain)
                Me.pnlMain.Visible = True
                customeruc.Width = pnlMain.Width - 30
                customeruc.Height = pnlMain.Height - 76
                customeruc.Left = (pnlMain.Width - customeruc.Width) / 2
                customeruc.Top = (pnlMain.Height - customeruc.Height) / 2
                Me.pnlMain.Controls.Add(customeruc)

            Else
                Me.main.Visible = False
                Me.pnlHeader.Visible = False
            End If
        Catch ex As Exception
            Throw
        End Try
        Return Nothing
    End Function

    Private Sub Mainform_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width - 2, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VendorManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorManagementToolStripMenuItem.Click
        Dim vendor As VendorInformation = New VendorInformation()
        vendor.Show()
    End Sub

    Private Sub JobProcessingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobProcessingToolStripMenuItem.Click
        Dim job As JobProcessing = New JobProcessing()
        job.Show()
    End Sub

    Private Sub VendorJobToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim customeruc As VendorJobs = New VendorJobs()
        Me.lblSoftTile.Visible = False
        Me.pnlMain.Controls.Clear()
        Me.Controls.Add(Me.pnlMain)
        Me.pnlMain.Visible = True
        customeruc.Left = (pnlMain.Width - customeruc.Width) / 2
        customeruc.Top = (pnlMain.Height - customeruc.Height) / 2
        Me.pnlMain.Controls.Add(customeruc)
    End Sub

    Private Sub HomeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HomeToolStripMenuItem1.Click
        Dim jobhistory As VendorJobHistory = New VendorJobHistory()
        jobhistory.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim lookup As VendorJobLookup = New VendorJobLookup()
        Dim process As JobProcessingInfo = New JobProcessingInfo()
        lookup.AttJobNo = process.GetCurrentAttJobNo()
        lookup.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim user As fromUserCreation = New fromUserCreation()
        user.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Dim chanhe As fromChangePassword = New fromChangePassword()
        chanhe.Show()
    End Sub

    Private Sub pnlHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlHeader.Paint, main.Paint, StatusStrip1.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.pnlHeader.Width, Me.pnlHeader.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(30, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim backup As Backup = New Backup()
        backup.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.main.Enabled = False
        Dim lock As LockScreen = New LockScreen()
        lock.Left = (Me.lblSoftTile.Width - lock.Width) / 2
        lock.Top = (Me.lblSoftTile.Height - lock.Height) / 2
        Me.lblSoftTile.Controls.Add(lock)
    End Sub
   
    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        Dim changeJobstatus As ChangedisputedJobToApproved = New ChangedisputedJobToApproved()
        changeJobstatus.Show()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem7.Click
        Dim acknowledgement As AcknowledgementDisplay = New AcknowledgementDisplay()
        acknowledgement.Show()
    End Sub
End Class