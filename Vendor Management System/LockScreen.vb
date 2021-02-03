Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer


Public Class LockScreen
    Private UserMessage As MessageBoxUser = New MessageBoxUser()
    Dim usrCreation As UserCreationBAL = New UserCreationBAL()

    Private Sub LockScreen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(85, 128, 185), 5)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LockScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            lblLockTime.Text = "Locked at " + DateAndTime.Now.ToString("F")
            lblUserName.Text = usrCreation.GetExistingUsername().ToUpper()
        Catch ex As Exception
            UserMessage.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If txtpassword.Text.Trim() = String.Empty Then
                UserMessage.ShowMessageBox("To unluck the Screen existing login user password is required.", "Password", 1, 3)
            Else
                If txtpassword.Text = usrCreation.GetUserExistingPassword() Then
                    Me.Controls.Clear()
                    Dim F As Mainform = Me.ParentForm
                    F.main.Enabled = True
                    F.lblSoftTile.Controls.Clear()
                Else
                    UserMessage.ShowMessageBox("Incorrect password. Please enter the existing login user password is required.", "Password", 1, 3)
                End If

            End If
        Catch ex As Exception
            UserMessage.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub pnlHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Label2.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Label2.Width, Me.Label2.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(30, 128, 185), Color.FromArgb(225, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
