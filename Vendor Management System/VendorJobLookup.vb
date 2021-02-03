Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer


Public Class VendorJobLookup
    Public AttJobNo As Integer
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()


    Private Sub VendorJobLookup_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage1.Paint, TabPage2.Paint, MyBase.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 1)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width, Me.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub VendorJobLookup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            GetSuccessJob()
            GetErrorJob()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Public Function GetSuccessJob()
        Try

            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim data = jobProcess.SucessJobInfo()
            dgvSucessJob.DataSource = data
            dgvSucessJob.Columns("Vendor Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Job Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvSucessJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvSucessJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Function SucessingJobFilter()
        Try
            Dim vendorId As Integer = 0
            Dim jobNumber As Integer = 0
            Dim whereBy As String = " WHERE 0=0 "

            If chbVendorId.Checked Then
                If txtVendorId.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Please Enter the Vendor ID or inactive the vendor ID filter.", "Vendor ID", 1, 1)
                ElseIf Integer.TryParse(txtVendorId.Text, vendorId) = False Then
                    UserMessageBox.ShowMessageBox("Invaild Vendor ID format. Please enter the correct format Vendor ID.", "Vendor ID", 1, 1)
                Else
                    vendorId = Integer.Parse(txtVendorId.Text)
                    whereBy = whereBy + " AND JobInfo.VendorId=" & vendorId
                End If
            End If


            If chbJobNumber.Checked Then
                If txtJboNumber.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Please Enter the Job Number or inactive the Job Number filter.", "Job Number", 1, 1)
                ElseIf Integer.TryParse(txtJboNumber.Text, jobNumber) = False Then
                    UserMessageBox.ShowMessageBox("Invaild Job Number format. Please enter the correct format Job Number.", "Job Number", 1, 1)
                Else
                    jobNumber = Integer.Parse(txtJboNumber.Text)
                    whereBy = whereBy + " AND JobInfo.JobNumber=" & jobNumber
                End If
            End If

            If chbTransaDate.Checked Then
                whereBy = whereBy + " AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + dtpfromTransDate.Value.ToString("yyyy/MM/dd") + "' AND '" + dtptoTransdate.Value.ToString("yyyy/MM/dd") + "'"
            End If

            If chbJobProcessingDate.Checked Then
                whereBy = whereBy + " AND FORMAT(JobInfo.EntryDate,'yyyy/mm/dd') BETWEEN '" + dtpFromProcessingDate.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpToProcessingDate.Value.ToString("yyyy/MM/dd") + "'"
            End If


            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim data = jobProcess.SucessJobInfoByMultipleParm(whereBy)
            dgvSucessJob.DataSource = data
            dgvSucessJob.Columns("Vendor Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Job Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvSucessJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvSucessJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSucessJob.Columns("Processing Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvSucessJob.Columns("Processing Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Public Function GetErrorJob()
        Try

            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim data = jobProcess.ErrorJobInfo()
            dgvErrorJob.DataSource = data
            dgvErrorJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvErrorJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvErrorJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvErrorJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lblErrorJobs.Text = "Total Error Jobs:" + dgvErrorJob.RowCount.ToString()
            dgvErrorJob.Columns("RecId").Visible = False
            dgvErrorJob.Columns("Address").ReadOnly = True
            dgvErrorJob.Columns("City").ReadOnly = True
            dgvErrorJob.Columns("State").ReadOnly = True
            dgvErrorJob.Columns("Zip Code").ReadOnly = True
            dgvErrorJob.Columns("Reason").ReadOnly = True


        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub dgvErrorJob_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvErrorJob.CellMouseClick
        Try
            If dgvErrorJob.RowCount > 0 And e.RowIndex > -1 And e.ColumnIndex = 0 Then
                VendorJobProcess(dgvErrorJob.Rows(e.RowIndex))
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Function VendorJobProcess(ByVal data As DataGridViewRow)
        Try
            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim jobInfoBO As JobInfoBO = New JobInfoBO()
            Dim vendorId As Integer = 0
            Dim AttJobNo As Integer = 0
            Dim jobNumber As Integer = 0
            Dim RecId As Integer = 0

            If Integer.TryParse(data.Cells("Vendor Id").Value.ToString(), jobInfoBO.VendorId) = False Then
                UserMessageBox.ShowMessageBox("Incorrect Vendor ID Format.", "Vendor ID", 1, 1)
                Return Nothing
            ElseIf Date.TryParse(data.Cells("Trans Date").Value.ToString(), jobInfoBO.TransDate) = False Then
                UserMessageBox.ShowMessageBox("Incorrect Trans Date Format.", "Trans Date", 1, 1)
                Return Nothing
            ElseIf Integer.TryParse(data.Cells("Job Number").Value.ToString(), jobInfoBO.JobNumber) = False Then
                UserMessageBox.ShowMessageBox("Incorrect Job Number Format.", "Job Number", 1, 1)
                Return Nothing
            ElseIf Decimal.TryParse(data.Cells("settlment").Value.ToString(), jobInfoBO.Stattlement) = False Then
                UserMessageBox.ShowMessageBox("Incorrect settlment Format.", "settlment", 1, 1)
                Return Nothing
            End If

            jobInfoBO.VendorId = Convert.ToInt32(data.Cells("Vendor Id").Value.ToString())
            vendorId = jobInfoBO.VendorId

            jobInfoBO.TransDate = Convert.ToDateTime(data.Cells("Trans Date").Value.ToString().ToString())

            jobInfoBO.JobNumber = Convert.ToInt32(data.Cells("Job Number").Value.ToString())
            jobNumber = jobInfoBO.JobNumber

            jobInfoBO.Address = data.Cells("Address").Value.ToString()
            jobInfoBO.City = data.Cells("City").Value.ToString()
            jobInfoBO.State = data.Cells("State").Value.ToString()
            jobInfoBO.ZipCode = data.Cells("Zip Code").Value.ToString()
            jobInfoBO.Stattlement = Convert.ToDecimal(data.Cells("settlment").Value.ToString())
            jobInfoBO.JobAttNo = jobProcess.GetCurrentAttJobNo()
            RecId = data.Cells("RecId").Value.ToString()

            If jobProcess.Isexists(vendorId) = False Then
                UserMessageBox.ShowMessageBox("Vendor ID does not exists.", "Vendor ID", 1, 1)
                Return Nothing
            End If


            If jobProcess.IsexistsJobNumber(jobNumber) = True Then
                UserMessageBox.ShowMessageBox("This Job number already Exists.", "Job Number", 1, 1)
                Return Nothing
            End If

            jobProcess.ProcessJobInformation(jobInfoBO)
            jobProcess.DeleteErrorJob(RecId)

            If chbVendorId.Checked = True Or chbJobNumber.Checked = True Or chbTransaDate.Checked = True Or chbJobProcessingDate.Checked Then
                Me.SucessingJobFilter()
            Else
                GetSuccessJob()
            End If

            If chbErrorVendorID.Checked = True Or chbErrorJobNumber.Checked = True Or chbErrorProcessingDate.Checked = True Then
                Me.ErrorJobFilter()
            Else
                GetErrorJob()
            End If


        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        SucessingJobFilter()
    End Sub
    Private Function ErrorJobFilter()
        Try
            Dim vendorId As String = String.Empty
            Dim jobNumber As String = String.Empty
            Dim whereBy As String = " WHERE Status=0 "

            If chbErrorVendorID.Checked Then
                If txtErrorVendorId.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Please Enter the Vendor ID or inactive the vendor ID filter.", "Vendor ID", 1, 1)
                Else
                    vendorId = txtErrorVendorId.Text
                    whereBy = whereBy + " AND JobInfoError.VendorId='" + vendorId + "'"
                End If
            End If


            If chbErrorJobNumber.Checked Then
                If txtErrorjobNumber.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Please Enter the Job Number or inactive the Job Number filter.", "Job Number", 1, 1)
                Else
                    jobNumber = txtErrorjobNumber.Text
                    whereBy = whereBy + " AND JobInfoError.JobNumber='" + jobNumber + "'"
                End If
            End If


            If chbErrorProcessingDate.Checked Then
                whereBy = whereBy + " AND FORMAT(JobInfoError.EntryDate,'yyyy/mm/dd') BETWEEN '" + dtpErrorFromProcessingDate.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpErrorToProcessingDate.Value.ToString("yyyy/MM/dd") + "'"
            End If


            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim data = jobProcess.ErrorJobInfobyMultipleParm(whereBy)
            dgvErrorJob.DataSource = data
            dgvErrorJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvErrorJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvErrorJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvErrorJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvErrorJob.Columns("Processing Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvErrorJob.Columns("Processing Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lblErrorJobs.Text = "Total Error Jobs:" + dgvErrorJob.RowCount.ToString()
            dgvErrorJob.Columns("RecId").Visible = False
            dgvErrorJob.Columns("Address").ReadOnly = True
            dgvErrorJob.Columns("City").ReadOnly = True
            dgvErrorJob.Columns("State").ReadOnly = True
            dgvErrorJob.Columns("Zip Code").ReadOnly = True
            dgvErrorJob.Columns("Reason").ReadOnly = True
            dgvErrorJob.Columns("Processing Date").ReadOnly = True

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ErrorJobFilter()
    End Sub

    Private Sub chbVendorId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendorId.CheckedChanged
        If chbVendorId.Checked Then
            txtVendorId.Enabled = True
        Else
            txtVendorId.Enabled = False
        End If
    End Sub

    Private Sub chbJobNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbJobNumber.CheckedChanged
        If chbJobNumber.Checked Then
            txtJboNumber.Enabled = True
        Else
            txtJboNumber.Enabled = False
        End If
    End Sub

    Private Sub chbTransaDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTransaDate.CheckedChanged
        If chbTransaDate.Checked Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub chbJobProcessingDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbJobProcessingDate.CheckedChanged
        If chbJobProcessingDate.Checked Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub chbErrorVendorID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbErrorVendorID.CheckedChanged
        If chbErrorVendorID.Checked Then
            txtErrorVendorId.Enabled = True
        Else
            txtErrorVendorId.Enabled = False
        End If
    End Sub

    Private Sub chbErrorJobNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbErrorJobNumber.CheckedChanged
        If chbErrorJobNumber.Checked Then
            txtErrorjobNumber.Enabled = True
        Else
            txtErrorjobNumber.Enabled = False
        End If
    End Sub

    Private Sub chbErrorProcessingDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbErrorProcessingDate.CheckedChanged
        If chbErrorProcessingDate.Checked Then
            GroupBox3.Enabled = True
        Else
            GroupBox3.Enabled = False
        End If
    End Sub
End Class