Imports System.Drawing.Drawing2D

Public Class JobRejectsReaon
    Public Reason As String = String.Empty
    Public Result As DialogResult = Windows.Forms.DialogResult.No
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Public jobNumber As String = String.Empty
    Public DisputeReason As String = String.Empty


    Private Sub JobRejectsReaon_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Result = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            Me.Reason = txtReason.Text
            Me.DisputeReason = ddlDisputeReason.Text
            Me.Result = Windows.Forms.DialogResult.Yes
            Me.Close()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub JobRejectsReaon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Dispute Job Reason || Job Number-" + Me.jobNumber
        ddlDisputeReason.SelectedIndex = 0
    End Sub
End Class