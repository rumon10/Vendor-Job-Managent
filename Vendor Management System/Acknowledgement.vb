Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer
Public Class Acknowledgement
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Public _vendorId As Integer = 0
    Public _transDate As Date
    Private Sub Acknowledgement_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCreate_Click(sender As System.Object, e As System.EventArgs) Handles btnCreate.Click
        Try
            If _vendorId = 0 Then
                UserMessageBox.ShowMessageBox("To create an acknowlegement of job needs a vendor Id. No Vendor Id is found. Please try again.", "Vendor Id Required", 1, 4)
                Return
            End If
            Dim acknowledgementBO As AcknowledgementBO = New AcknowledgementBO()
            acknowledgementBO.VendorId = _vendorId
            acknowledgementBO.TransDate = dtpTransDate.Value

            If txtComments.Text.Trim() = String.Empty Then
                UserMessageBox.ShowMessageBox("Missing Job Comments is required. Please enter the valid missing job comments.", "Missing Job Comments.", 1, 3)
                Return
            End If
            acknowledgementBO.Comments = txtComments.Text.Trim()
            Dim acknowledgementBAL As AcknowledgementBAL = New AcknowledgementBAL()
            acknowledgementBAL.CreateNewAcknowledgement(acknowledgementBO)
            UserMessageBox.ShowMessageBox("A job missing job report is sucessfully created.", "Report Missing Job", 1, 1)
            txtComments.Text = String.Empty
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Acknowledgement_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If _transDate = Nothing Then
            dtpTransDate.Value = Date.Now
        Else
            dtpTransDate.Value = _transDate
        End If
    End Sub
End Class