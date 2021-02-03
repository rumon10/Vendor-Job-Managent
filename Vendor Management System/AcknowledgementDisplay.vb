Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer
Imports Excel = Microsoft.Office.Interop.Excel
Public Class AcknowledgementDisplay
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Private Sub AcknowledgementDisplay_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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

    Private Sub AcknowledgementDisplay_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.loadAcknowledgementJob()
    End Sub
    Private Sub loadAcknowledgementJob()
        Try
            Dim acknowlegement As AcknowledgementBAL = New AcknowledgementBAL()
            Dim data As DataTable

            If chbActive.Checked = True Then
                data = acknowlegement.AcknowledgementJobs(dtpFromTransDate.Value, dtpToTransDate.Value)
            Else
                data = acknowlegement.AcknowledgementJobs()
            End If

            dgvAcknowledgementsjob.DataSource = data
            dgvAcknowledgementsjob.Columns("Vendor ID").Width = 100
            dgvAcknowledgementsjob.Columns("Vendor Name").Width = 150
            dgvAcknowledgementsjob.Columns("Contact Name").Width = 150
            dgvAcknowledgementsjob.Columns("Trans Date").Width = 80
            dgvAcknowledgementsjob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            dgvAcknowledgementsjob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvAcknowledgementsjob.Columns("Comments").Width = dgvAcknowledgementsjob.Width - (100 + 150 + 150 + 80 - 2)
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub btnDisplayDisputedJob_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplayDisputedJob.Click
        Me.loadAcknowledgementJob()
    End Sub

    Private Sub btnExportDisputedJob_Click(sender As System.Object, e As System.EventArgs) Handles btnExportDisputedJob.Click
        Try
            If dgvAcknowledgementsjob.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Acknowledgement Job Information exists under this date period.", "Acknowledgement Job Information Export", 1, 1)
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
            xlWorkSheet.Name = "Acknowledgement Job"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Acknowledgement Job Information"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 0 To dgvAcknowledgementsjob.Columns.Count - 1
                xlWorkSheet.Cells(3, i + 1) = dgvAcknowledgementsjob.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(3, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvAcknowledgementsjob.RowCount - 1
                For j = 0 To dgvAcknowledgementsjob.ColumnCount - 1

                    If dgvAcknowledgementsjob.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 3, j + 1)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvAcknowledgementsjob.Rows(i).Cells(j).Value.ToString()


                    Else
                        xlWorkSheet.Cells(i + 1 + 3, j + 1) = dgvAcknowledgementsjob.Rows(i).Cells(j).Value.ToString()
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

    Private Sub chbActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbActive.CheckedChanged
        If chbActive.Checked = True Then
            pnlAcknowledgeJobs.Enabled = True
        Else
            pnlAcknowledgeJobs.Enabled = False
            Me.loadAcknowledgementJob()
        End If
    End Sub
End Class