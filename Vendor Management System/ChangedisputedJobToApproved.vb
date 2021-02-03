Imports BusinessAccessLayer
Imports Excel = Microsoft.Office.Interop.Excel
Public Class ChangedisputedJobToApproved
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Private Sub ChangedisputedJobToApproved_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadDisputedJob()
        Me.loadApprovedDisputedJob()
    End Sub
    Private Sub loadDisputedJob()
        Try
            Dim jobprocess As JobProcessingInfo = New JobProcessingInfo()
            Dim data As DataTable

            If chbDateFilterDisputed.Checked = True Then
                data = jobprocess.GetVendorDisputedJob(dtpFromTransDate.Value, dtpToTransDate.Value)
            Else
                data = jobprocess.GetVendorDisputedJob()
            End If

            dgvDisputed.DataSource = data
            dgvDisputed.Columns("RecId").Visible = False
            dgvDisputed.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dgvDisputed.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDisputed.Columns("Job Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDisputed.Columns("Zip Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDisputed.Columns("Settlment").DefaultCellStyle.Format = "c"
            dgvDisputed.Columns("Settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub loadApprovedDisputedJob()
        Try
            Dim jobprocess As JobProcessingInfo = New JobProcessingInfo()
            Dim data As DataTable

            If chbApprovedFilter.Checked = True Then
                data = jobprocess.ApprovedDisputedJobInfo(dtpFromTransDate1.Value, dtpDate.Value)
            Else
                data = jobprocess.ApprovedDisputedJobInfo()
            End If

            dgvApprovedJobsFromDisputed.DataSource = data
            dgvApprovedJobsFromDisputed.Columns("RecId").Visible = False
            dgvApprovedJobsFromDisputed.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dgvApprovedJobsFromDisputed.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvApprovedJobsFromDisputed.Columns("Job Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvApprovedJobsFromDisputed.Columns("Zip Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvApprovedJobsFromDisputed.Columns("Settlment").DefaultCellStyle.Format = "c"
            dgvApprovedJobsFromDisputed.Columns("Settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub btnDisplayDisputedJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayDisputedJob.Click
        Me.loadDisputedJob()
    End Sub

    Private Sub dgvDisputed_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDisputed.CellMouseClick
        Try
            If dgvDisputed.Rows.Count > 0 And e.RowIndex > -1 Then
                If e.ColumnIndex = 0 Then
                    Dim rowInx As Integer = e.RowIndex
                    Dim recId As Integer = Integer.Parse(dgvDisputed.Rows(rowInx).Cells("RecId").Value.ToString())
                    Dim jobNumber As String = dgvDisputed.Rows(rowInx).Cells("Job Number").Value.ToString()

                    If recId = 0 Or jobNumber = String.Empty Then
                        UserMessageBox.ShowMessageBox("Unknown error has been occured. Please try again. If needed then please refresh the Disputed Jobs.", "Refresh Need", 1, 4)
                        Return
                    End If

                    Dim approvedNotes As ApprovedDisputedJob = New ApprovedDisputedJob()
                    approvedNotes.jobNumber = jobNumber
                    approvedNotes.ShowDialog()
                    Dim result As DialogResult = approvedNotes.Result
                    Dim ApprovedReason As String = approvedNotes.ApprovedReason
                    Dim approvedNote As String = approvedNotes.ApprovedNotes

                    If result = DialogResult.Yes And ApprovedReason <> String.Empty And approvedNotes.ApprovedNotes <> String.Empty Then
                        Dim jobprocess As JobProcessingInfo = New JobProcessingInfo()
                        jobprocess.ApprovedDisputedJob(approvedNote, ApprovedReason, recId)
                        Me.loadDisputedJob()
                        UserMessageBox.ShowMessageBox("Job Number " + jobNumber + " has been suceefully approved.", "Sucess", 1, 1)
                        Return
                    End If

                End If
            End If

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub btnExportDisputedJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportDisputedJob.Click
        Try
            If dgvDisputed.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Disputed Job Information exists under this date period.", "Disputed Job Information Export", 1, 1)
                Return
            End If

            Me.Cursor = Cursors.WaitCursor

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(1)
            xlWorkSheet = xlWorkBook.Worksheets(1)
            Dim rg As Microsoft.Office.Interop.Excel.Range
            xlWorkSheet.Name = "Disputed Job Information"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Disputed Job Information"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 1 To dgvDisputed.Columns.Count - 1
                xlWorkSheet.Cells(3, i) = dgvDisputed.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(3, i)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvDisputed.RowCount - 1
                For j = 1 To dgvDisputed.ColumnCount - 1

                    If dgvDisputed.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 3, j)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvDisputed.Rows(i).Cells(j).Value.ToString()


                    Else
                        xlWorkSheet.Cells(i + 1 + 3, j) = dgvDisputed.Rows(i).Cells(j).Value.ToString()
                        rg = xlWorkSheet.Cells(i + 1 + 3, j)
                        rg.EntireColumn.AutoFit()
                    End If
                Next
            Next

            xlApp.Visible = True
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub btnDisputedApprovedJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisputedApprovedJobs.Click
        Me.loadApprovedDisputedJob()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If dgvApprovedJobsFromDisputed.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Approved Disputed Job Information exists under this date period.", "Approved Disputed Job Information Export", 1, 1)
                Return
            End If

            Me.Cursor = Cursors.WaitCursor
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(1)
            xlWorkSheet = xlWorkBook.Worksheets(1)
            Dim rg As Microsoft.Office.Interop.Excel.Range
            xlWorkSheet.Name = "Approved Disputed Job"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Approved Disputed Job Information"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 0 To dgvApprovedJobsFromDisputed.Columns.Count - 1
                xlWorkSheet.Cells(3, i + 1) = dgvApprovedJobsFromDisputed.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(3, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvApprovedJobsFromDisputed.RowCount - 1
                For j = 0 To dgvApprovedJobsFromDisputed.ColumnCount - 1

                    If dgvApprovedJobsFromDisputed.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 3, j + 1)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvApprovedJobsFromDisputed.Rows(i).Cells(j).Value.ToString()


                    Else
                        xlWorkSheet.Cells(i + 1 + 3, j + 1) = dgvApprovedJobsFromDisputed.Rows(i).Cells(j).Value.ToString()
                        rg = xlWorkSheet.Cells(i + 1 + 3, j + 1)
                        rg.EntireColumn.AutoFit()
                    End If
                Next
            Next

            xlApp.Visible = True
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
            Me.Cursor = Cursors.Arrow
        End Try
    End Sub
    Private Sub chbDateFilterDisputed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDateFilterDisputed.CheckedChanged
        If chbDateFilterDisputed.Checked = True Then
            pnlActiveDisputedJob.Enabled = True
        Else
            pnlActiveDisputedJob.Enabled = False
        End If
    End Sub
    Private Sub chbApprovedFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbApprovedFilter.CheckedChanged
        If chbApprovedFilter.Checked = True Then
            pnlApprovedJobFilter.Enabled = True
        Else
            pnlApprovedJobFilter.Enabled = False
            Me.loadDisputedJob()
            Me.loadApprovedDisputedJob()
        End If
    End Sub
End Class