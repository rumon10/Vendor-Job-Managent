Imports System.Drawing.Drawing2D
Imports System.IO
Imports BusinessAccessLayer
Imports System.Globalization


Public Class JobProcessing
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Dim jobInfoBO As JobInfoBO = New JobInfoBO()
    Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
    Dim jobInfoErrorBO As JobInfoErrorBO = New JobInfoErrorBO()
    Dim rowcount As Integer = 0
    Dim ErrorOccured As Boolean = False
    Dim vendorId As Integer = 0
    Dim AttJobNo As Integer = 0
    Dim jobNumber As Integer = 0


    Private Sub JobProcessing_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel3.Paint
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

    Private Sub JobProcessing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        If ItemImgofd.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            txtFile.Text = ItemImgofd.FileName
        End If
    End Sub

    Private Sub exitbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        If txtFile.Text = String.Empty Then
            UserMessageBox.ShowMessageBox("Valid File is required to process job Information.", "Job Information", 1, 1)
            Return
        End If

        Try
            lbljobprocessingtime.Text = DateAndTime.Now.ToString("F")
            lbljobprocessingtime.Refresh()
            lblJobStatus.Text = "Processing"
            lblProgress.Refresh()
            progress.Maximum = 0
            Me.vendorId = 0
            Me.rowcount = 0
            Me.ErrorOccured = False
            ProcessingJob()
            lblJobStatus.Text = "Complete"
            lblJobStatus.Refresh()
        Catch ex As Exception
            lblJobStatus.Text = "Error"
            lblJobStatus.Refresh()
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Function ProcessingJob()
        Try

            Dim dt As DataTable = New DataTable()
            Dim data As DataTable = jobProcess.JobProcessing(txtFile.Text)
            progress.Maximum = data.Rows.Count
            lbljobprocessingtime.Text = DateAndTime.Now.ToString("F")
            lbljobprocessingtime.Refresh()
            If data.Rows.Count > 0 Then
                progress.Visible = True
                VendorJobProcess(data)
                Me.Hide()
                Dim vendorJobLookUp As VendorJobLookup = New VendorJobLookup()
                vendorJobLookUp.AttJobNo = Me.AttJobNo
                vendorJobLookUp.Show()
            Else
                progress.Visible = False
                lblProgress.Text = "No Data Exists."
                lblProgress.Refresh()
            End If
        Catch ex As Exception
            Throw
        End Try
        Return Nothing
    End Function

    Private Function VendorJobProcess(ByVal data As DataTable)

        jobProcess = New JobProcessingInfo()
        AttJobNo = jobProcess.GetAttJobNo()


        If AttJobNo = 0 Then
            UserMessageBox.ShowMessageBox("Attachment Job Number Error.", "Error", 1, 4)
            Return Nothing
        End If

        rowcount = 0
        While Me.rowcount < data.Rows.Count
            Try
                Dim jobExist As Boolean = False

                jobInfoErrorBO.ErrorReason = String.Empty + "Invalid Format: "

                If Integer.TryParse(data.Rows(rowcount)(0).ToString(), jobInfoBO.VendorId) = True Then
                    jobInfoBO.VendorId = Convert.ToInt32(data.Rows(rowcount)(0).ToString())
                    Me.vendorId = jobInfoBO.VendorId
                Else
                    Me.ErrorOccured = True
                    jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Vendor ID"
                End If

                If Date.TryParse(data.Rows(rowcount)(1).ToString(), jobInfoBO.TransDate) = True Then
                    jobInfoBO.TransDate = Convert.ToDateTime(data.Rows(rowcount)(1).ToString())
                Else
                    Me.ErrorOccured = True
                    jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Trans Date"
                End If

                If Integer.TryParse(data.Rows(rowcount)(2).ToString(), jobInfoBO.JobNumber) = True Then
                    jobInfoBO.JobNumber = Convert.ToInt32(data.Rows(rowcount)(2).ToString())
                    Me.jobNumber = jobInfoBO.JobNumber
                Else
                    Me.ErrorOccured = True
                    jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Job Number"
                End If

                If Decimal.TryParse(data.Rows(rowcount)(9).ToString(), jobInfoBO.Stattlement) = True Then
                    jobInfoBO.Stattlement = Convert.ToDecimal(data.Rows(rowcount)(9).ToString())
                Else
                    Me.ErrorOccured = True
                    jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Stattlement"
                End If

                If Me.vendorId <> 0 Then

                    If jobProcess.Isexists(Me.vendorId) = False Then
                        Me.ErrorOccured = True
                        jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Vendor ID Exists: No"
                    End If

                End If

                If Me.jobNumber <> 0 Then

                    If jobProcess.IsexistsJobNumber(Me.jobNumber) = True Then
                        jobExist = True
                        jobInfoErrorBO.ErrorReason = jobInfoErrorBO.ErrorReason + " Job Number Exists: Yes"
                    End If

                End If

                If ErrorOccured = True And jobExist = False Then

                    jobInfoErrorBO.VendorId = data.Rows(rowcount)(0).ToString()
                    jobInfoErrorBO.TransDate = data.Rows(rowcount)(1).ToString()
                    jobInfoErrorBO.JobNumber = data.Rows(rowcount)(2).ToString()
                    jobInfoErrorBO.Address = data.Rows(rowcount)(3).ToString()
                    jobInfoErrorBO.City = data.Rows(rowcount)(5).ToString()
                    jobInfoErrorBO.State = data.Rows(rowcount)(6).ToString()
                    jobInfoErrorBO.ZipCode = data.Rows(rowcount)(7).ToString()
                    jobInfoErrorBO.Stattlement = data.Rows(rowcount)(9).ToString()

                    jobProcess.ProcessJobInformationErrorByParamterwise(jobInfoErrorBO)
                    Me.ErrorOccured = False

                ElseIf jobExist = False And ErrorOccured = False Then

                    jobInfoBO.Address = data.Rows(rowcount)(3).ToString()
                    jobInfoBO.City = data.Rows(rowcount)(5).ToString()
                    jobInfoBO.State = data.Rows(rowcount)(6).ToString()
                    jobInfoBO.ZipCode = data.Rows(rowcount)(7).ToString()
                    jobProcess.ProcessJobInformationByParamterwise(jobInfoBO)

                End If

                progress.Value = progress.Value + 1
                lblProgress.Text = rowcount.ToString + " Job processing Completed"
                lblProgress.Refresh()
                Me.rowcount = Me.rowcount + 1
                Me.vendorId = 0
                Me.jobNumber = 0
                jobExist = False
            Catch ex As Exception
                jobInfoErrorBO.ErrorReason = ex.Message
                jobInfoErrorBO.VendorId = data.Rows(rowcount)(0).ToString()
                jobInfoErrorBO.TransDate = data.Rows(rowcount)(1).ToString()
                jobInfoErrorBO.JobNumber = data.Rows(rowcount)(2).ToString()
                jobInfoErrorBO.Address = data.Rows(rowcount)(3).ToString()
                jobInfoErrorBO.City = data.Rows(rowcount)(5).ToString()
                jobInfoErrorBO.State = data.Rows(rowcount)(6).ToString()
                jobInfoErrorBO.ZipCode = data.Rows(rowcount)(7).ToString()
                jobInfoErrorBO.Stattlement = data.Rows(rowcount)(9).ToString()

                jobProcess.ProcessJobInformationErrorByParamterwise(jobInfoErrorBO)
                Me.ErrorOccured = False
                progress.Value = progress.Value + 1
                lblProgress.Text = rowcount.ToString + " Job processing Completed"
                lblProgress.Refresh()
                Me.rowcount = Me.rowcount + 1
                Me.vendorId = 0
                Me.jobNumber = 0
            End Try
            
        End While
        Return Nothing
    End Function
End Class