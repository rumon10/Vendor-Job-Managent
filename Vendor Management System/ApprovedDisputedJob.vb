Public Class ApprovedDisputedJob
    Public ApprovedNotes As String = String.Empty
    Public ApprovedReason As String = String.Empty

    Public Result As DialogResult = Windows.Forms.DialogResult.No
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Public jobNumber As String = String.Empty
    Private Sub ApprovedDisputedJob_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If jobNumber = String.Empty Then
            UserMessageBox.ShowMessageBox("Job number can not found. Please try later.", "Job Number Required", 1, 4)
            Return
        End If
        Me.Text = "Approved Note Disputed Job || Job Number " + jobNumber
        ddlApprovedReason.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            If ddlApprovedReason.Text.Trim() = String.Empty Then
                UserMessageBox.ShowMessageBox("Disputed job approved reason is required. Please select one reason", "Approved Reason", 1, 3)
                Return
            End If
            If txtApprovedNotes.Text.Trim() = String.Empty Then
                UserMessageBox.ShowMessageBox("Approved note is required. Please enter the approved note of this disputed job-" + jobNumber, "Approved Note", 1, 3)
                Return
            End If

            ApprovedNotes = txtApprovedNotes.Text
            ApprovedReason = ddlApprovedReason.Text
            Result = DialogResult.Yes
            Me.Close()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
End Class