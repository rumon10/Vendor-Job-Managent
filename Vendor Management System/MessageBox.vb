Imports System.Drawing.Drawing2D

Public Class MessageBoxUser
    Public _DialogResult As DialogResult = Windows.Forms.DialogResult.No

    Private Sub MessageBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 10)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width - 11, Me.Height - 34)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        _DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        _DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Public Function ShowMessageBox(ByVal Message As String, ByVal Title As String, ByVal button As Integer, ByVal icon As Integer)
        lblMessagebox.Text = Message
        Text = Title

        If button = 2 Then
            btnNo.Visible = True
            btnYes.Text = "Yes"
            btnYes.Location = New Point(177, 111)
        Else
            btnNo.Visible = False
            btnYes.Text = "Ok"
            btnYes.Location = New Point(191, 111)

        End If

        If icon = 1 Then
            pcImage.Image = My.Resources.InfoMessage
        ElseIf icon = 2 Then
            pcImage.Image = My.Resources.QuestionMessage
        ElseIf icon = 3 Then
            pcImage.Image = My.Resources.WarningMessage
        Else
            pcImage.Image = My.Resources.ErrorMess

        End If

        Me.ShowDialog()

        Return Nothing
    End Function
End Class