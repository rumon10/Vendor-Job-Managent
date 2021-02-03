Imports BusinessAccessLayer
Imports System.Drawing.Drawing2D


Public Class fromChangePassword
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            Dim userCreation As UserCreationBAL = New UserCreationBAL()

            If oldpasswordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Pleaze Enter the Existing password.", "Password", 1, 1)
                Return
            ElseIf newpasswordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Pleaze Enter the New password.", "Password", 1, 1)
                Return
            ElseIf confirmpassword.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Pleaze Enter the confirm password.", "Password", 1, 1)
                Return
            ElseIf String.Equals(newpasswordtxt.Text, confirmpassword.Text) = False Then
                UserMessageBox.ShowMessageBox("New password and confirm password does not match.", "Password", 1, 3)
                Return
            ElseIf String.Equals(oldpasswordtxt.Text, userCreation.GetUserExistingPassword()) = False Then
                UserMessageBox.ShowMessageBox("Entering password is wrong!!!.", "Password", 1, 3)
                Return
            Else
                userCreation.ChangePassword(newpasswordtxt.Text)
                UserMessageBox.ShowMessageBox("Sucessfully Changed User password.", "Password", 1, 1)
                oldpasswordtxt.Text = ""
                newpasswordtxt.Text = ""
                confirmpassword.Text = ""
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        Me.Close()
    End Sub

    Private Sub fromChangePassword_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width - 2, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try

    End Sub
End Class