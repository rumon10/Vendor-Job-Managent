Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer
Imports Excel = Microsoft.Office.Interop.Excel

Public Class VendorJobHistory
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Private Sub VendorJobHistory_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub VendorJobHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dllJobStatus.SelectedIndex = 3
        GetJobHistory(DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub
    Public Function GetJobHistory(ByVal fromDate As Date, ByVal toDate As Date)
        Try

            Dim queryWhereBy As String = " 0=0 "
            Dim Vendor As Integer = 0
            Dim jobNumber = 0

            If CheckBox1.Checked Then
                queryWhereBy = queryWhereBy + " AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + toDate.ToString("yyyy/MM/dd") + "'"
            End If

            If CheckBox2.Checked Then
                If VendorId.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Vendor Id is required to generated report.", "Vendor Id", 1, 1)
                    Return Nothing
                ElseIf Integer.TryParse(VendorId.Text, Vendor) = False Then
                    UserMessageBox.ShowMessageBox("Invalid vendor Id.", "Vendor Id", 1, 1)
                    Return Nothing
                Else
                    queryWhereBy = queryWhereBy + " AND JobInfo.VendorId=" & Integer.Parse(VendorId.Text)
                End If

            End If

            If CheckBox3.Checked = True Then
                If txtJobNumber.Text = String.Empty Then
                    UserMessageBox.ShowMessageBox("Job Number is required to generated report.", "Job Number", 1, 1)
                    Return Nothing
                ElseIf Integer.TryParse(txtJobNumber.Text, jobNumber) = False Then
                    UserMessageBox.ShowMessageBox("Invalid Job Number.", "Job Number", 1, 1)
                    Return Nothing
                Else
                    queryWhereBy = queryWhereBy + " AND JobInfo.JobNumber=" & Integer.Parse(txtJobNumber.Text)
                End If
            End If

            If CheckBox4.Checked = True Then
                If dllJobStatus.SelectedIndex = 0 Then
                    queryWhereBy = queryWhereBy + " AND JobInfo.Status = 0"
                ElseIf dllJobStatus.SelectedIndex = 1 Then
                    queryWhereBy = queryWhereBy + " AND JobInfo.Status = 1"
                ElseIf dllJobStatus.SelectedIndex = 2 Then
                    queryWhereBy = queryWhereBy + " AND JobInfo.Status = 2"

                End If
            End If


            Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
            Dim data = jobProcess.VendorJobHistory(queryWhereBy)
            dgvSucessJob.DataSource = data
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

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        GetJobHistory(DateTimePicker1.Value, DateTimePicker2.Value)
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            GroupBox2.Enabled = True
        Else
            GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            VendorId.Enabled = True
        Else
            VendorId.Enabled = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            txtJobNumber.Enabled = True
        Else
            txtJobNumber.Enabled = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            dllJobStatus.Enabled = True
        Else
            dllJobStatus.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If dgvSucessJob.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Job Information exists under this filter.", "Job Information Export", 1, 1)
                Return
            End If


            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            Dim i As Integer
            Dim j As Integer

            xlApp = New Excel.Application
            xlApp.Visible = True
            xlWorkBook = xlApp.Workbooks.Add(1)
            xlWorkSheet = xlWorkBook.Worksheets(1)
            Dim rg As Microsoft.Office.Interop.Excel.Range
            xlWorkSheet.Name = "Job Information"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Job Information History"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 0 To dgvSucessJob.Columns.Count - 1
                xlWorkSheet.Cells(5, i + 1) = dgvSucessJob.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(5, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvSucessJob.RowCount - 1
                For j = 0 To dgvSucessJob.ColumnCount - 1

                    If dgvSucessJob.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvSucessJob.Rows(i).Cells(j).Value.ToString()


                    Else
                        xlWorkSheet.Cells(i + 1 + 5, j + 1) = dgvSucessJob.Rows(i).Cells(j).Value.ToString()
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.EntireColumn.AutoFit()
                    End If
                Next
            Next


            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
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
End Class