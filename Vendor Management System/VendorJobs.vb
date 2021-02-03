Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer
Imports Excel = Microsoft.Office.Interop.Excel

Public Class VendorJobs
    Public vendorId As Integer
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Dim jobProcess As JobProcessingInfo = New JobProcessingInfo()
    Dim IsApprovedJobLoaded As Boolean = False
    Dim IsRejectedJobLoaded As Boolean = False
    'Dim _vendorLogout As Mainform.UserLogout

    Private Sub VendorJobs_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(85, 128, 185), 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width + 3, Me.Height + 3)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SetJobGridSize()
        Try
            dgvVendorJob.Width = TabPage1.Width - 40
            dgvVendorJob.Height = TabPage1.Height - 104
            dgvVendorJob.Left = (TabPage1.Width - dgvVendorJob.Width) / 2
            lblOfferJob.Left = dgvVendorJob.Left

            dgvApprovedJob.Width = TabPage2.Width - 40
            dgvApprovedJob.Height = TabPage2.Height - 104
            dgvApprovedJob.Left = (TabPage2.Width - dgvApprovedJob.Width) / 2

            dgvRejectedJob.Width = TabPage3.Width - 40
            dgvRejectedJob.Height = TabPage3.Height - 104
            dgvRejectedJob.Left = (TabPage3.Width - dgvRejectedJob.Width) / 2

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub VendorJobs_TabPageBorder_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TabPage2.Paint, TabPage1.Paint, TabPage3.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(85, 128, 185), 15)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.TabPage1.Width, Me.TabPage1.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            Dim i As Integer = 0
            Dim JobAccepts As Integer = 0

            If dgvVendorJob.Rows.Count > 0 Then
                UserMessageBox.ShowMessageBox("Do you want to approved your " + dgvVendorJob.Rows.Count.ToString() + " Jobs?", "Approved All Job", 2, 2)
                If UserMessageBox._DialogResult = DialogResult.Yes Then
                    jobProcess.GetJobAccetsNo()
                    jobProcess.AcceptsJobInfo()
                    Me.LoadOfferJob()
                End If
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim logout As Logout = New Logout()
        Me.Controls.Clear()
        logout.Left = (Me.Width - logout.Width) / 2
        logout.Top = (Me.Height - logout.Height) / 2
        Me.Controls.Add(logout)

        operationType = "logout"
        Dim usrCreation As UserCreationBAL = New UserCreationBAL()
        Dim F As Mainform = Me.ParentForm
        F.lblHeaderVendorId.Text = "Last Logout:" + DateAndTime.Now.ToString("F")
        F.lblHeaderVendorName.Text = "  Last Vendor:" + usrCreation.GetExistingUserFullName()
        F.llbusername.Text = "No Vendor"
        F.llbFullUser.Text = "No Vendor"
        F.llbLoginDatetimeMaping.Text = "Last " + F.llbLoginDatetimeMaping.Text
        usrCreation.UserMemoryRelease()
    End Sub

    Private Sub exitbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        Try
            Dim acknowledgement As Acknowledgement = New Acknowledgement()
            Dim user As UserCreationBAL = New UserCreationBAL()
            acknowledgement._vendorId = user.GetExistingUserId()
            Dim transdate As Date
            If dgvVendorJob.Rows.Count > 0 Then
                If Not IsDBNull(dgvVendorJob.Rows(0).Cells("Trans Date").Value) Then
                    transdate = Convert.ToDateTime(dgvVendorJob.Rows(0).Cells("Trans Date").Value.ToString())
                End If
            End If
            acknowledgement._transDate = transdate
            acknowledgement.Show()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub VendorJobs_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetJobGridSize()
        Me.LoadOfferJob()
    End Sub

    Private Function LoadOfferJob()
        Try

            Dim data As DataTable = jobProcess.VendorJobInfo()
            dgvVendorJob.DataSource = data
            dgvVendorJob.Columns("RecId").Visible = False
            dgvVendorJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvVendorJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvVendorJob.Columns("Settlment").DefaultCellStyle.Format = "c"
            dgvVendorJob.Columns("Settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvVendorJob.Columns("Job Number").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvVendorJob.Columns("Zip Code").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            lblOfferJob.Text = "Offer Jobs: " + dgvVendorJob.RowCount.ToString()
            dgvVendorJob.Columns(0).Width = 75
            dgvVendorJob.Columns(1).Width = 75
            dgvVendorJob.Columns("Trans Date").Width = 100
            dgvVendorJob.Columns("Job Number").Width = 110
            dgvVendorJob.Columns("City").Width = 110
            dgvVendorJob.Columns("State").Width = 60
            dgvVendorJob.Columns("Zip Code").Width = 80
            dgvVendorJob.Columns("Settlment").Width = 90
            dgvVendorJob.Columns("Address").Width = dgvVendorJob.Width - (75 + 75 + 100 + 110 + 110 + 60 + 80 + 90)

            For Each ctrl As Control In dgvVendorJob.Controls
                If TypeOf ctrl Is VScrollBar Then
                    dgvVendorJob.Columns("Address").Width = dgvVendorJob.Columns("Address").Width - 20
                End If
            Next

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
         Me.LoadOfferJob()
    End Sub
    Private Function ApprovedJobLoaded()
        Try
            Dim fromDate As Date = DateTimePicker1.Value
            Dim todate As Date = Date.Now

            Dim data As DataTable = jobProcess.VendorApprovedJobInfo(fromDate, todate)
            dgvApprovedJob.DataSource = data
            dgvApprovedJob.Columns("RecId").Visible = False
            dgvApprovedJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvApprovedJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvApprovedJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvApprovedJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Function RejectedJobLoaded()
        Try
            Dim fromDate As Date = DateTimePicker2.Value
            Dim todate As Date = Date.Now

            Dim data As DataTable = jobProcess.VendorRejectedJobInfo(fromDate, todate)
            dgvRejectedJob.DataSource = data
            dgvRejectedJob.Columns("RecId").Visible = False
            dgvRejectedJob.Columns("Trans Date").DefaultCellStyle.Format = "MM/dd/yy"
            dgvRejectedJob.Columns("Trans Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRejectedJob.Columns("settlment").DefaultCellStyle.Format = "c"
            dgvRejectedJob.Columns("settlment").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub TabControl1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TabControl1.MouseClick
        Try
            If Me.IsApprovedJobLoaded = False And TabControl1.SelectedIndex = 1 Then
                Me.ApprovedJobLoaded()
                Me.IsApprovedJobLoaded = True
            ElseIf Me.IsRejectedJobLoaded = False And TabControl1.SelectedIndex = 2 Then
                Me.RejectedJobLoaded()
                Me.IsRejectedJobLoaded = True
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.ApprovedJobLoaded()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If dgvApprovedJob.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Approved Job Information exists under this filter.", "Approved Job Information Export", 1, 1)
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
            xlWorkSheet.Name = "Approved Job Information"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Approved Job Information"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 0 To dgvApprovedJob.Columns.Count - 1
                xlWorkSheet.Cells(5, i + 1) = dgvApprovedJob.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(5, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvApprovedJob.RowCount - 1
                For j = 0 To dgvApprovedJob.ColumnCount - 1

                    If dgvApprovedJob.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvApprovedJob.Rows(i).Cells(j).Value.ToString()

                    ElseIf dgvApprovedJob.Columns(j).Name = "Settlment" Then
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.NumberFormat = "$0.00"
                        rg.Value2 = dgvApprovedJob.Rows(i).Cells(j).Value.ToString()

                    Else
                        xlWorkSheet.Cells(i + 1 + 5, j + 1) = dgvApprovedJob.Rows(i).Cells(j).Value.ToString()
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

    Private Sub dgvVendorJob_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvVendorJob.CellMouseClick
        Try
            If dgvVendorJob.Rows.Count > 0 And e.RowIndex > -1 And e.ColumnIndex = 1 Then
                Dim rowIdx As Integer = e.RowIndex
                Dim RecId As Integer = Integer.Parse(dgvVendorJob.Rows(rowIdx).Cells("RecId").Value.ToString())
                Dim jobNumber As String = dgvVendorJob.Rows(rowIdx).Cells("Job Number").Value.ToString()

                Dim DeclineReason As JobRejectsReaon = New JobRejectsReaon()
                DeclineReason.jobNumber = jobNumber
                DeclineReason.ShowDialog()

                If DeclineReason.Result = DialogResult.Yes Then
                    jobProcess.RecejectJobInfo(RecId, DeclineReason.Reason, DeclineReason.DisputeReason)
                    Me.LoadOfferJob()
                End If
            ElseIf dgvVendorJob.Rows.Count > 0 And e.RowIndex > -1 And e.ColumnIndex = 0 Then

                Dim rowIdx As Integer = e.RowIndex
                Dim RecId As Integer = Integer.Parse(dgvVendorJob.Rows(rowIdx).Cells("RecId").Value.ToString())
                jobProcess.GetJobAccetsNo()
                jobProcess.AcceptsOneJobInfo(RecId)
                Me.LoadOfferJob()
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.RejectedJobLoaded()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If dgvApprovedJob.Rows.Count <= 0 Then
                UserMessageBox.ShowMessageBox("No Rejected Job Information exists under this filter.", "Rejected Job Information Export", 1, 1)
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
            xlWorkSheet.Name = "Rejected Job Information"


            xlWorkSheet.Range("A1:K1").Merge()
            xlWorkSheet.Range("A1:K1").Value = "Rejected Job Information"
            xlWorkSheet.Range("A1:K1").Font.Bold = True
            xlWorkSheet.Range("A1:K1").Font.Size = 16
            xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
            xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




            For i = 0 To dgvRejectedJob.Columns.Count - 1
                xlWorkSheet.Cells(5, i + 1) = dgvRejectedJob.Columns(i).HeaderText
                rg = xlWorkSheet.Cells(5, i + 1)
                rg.EntireColumn.AutoFit()
                rg.Font.Bold = True
            Next


            For i = 0 To dgvRejectedJob.RowCount - 1
                For j = 0 To dgvRejectedJob.ColumnCount - 1

                    If dgvRejectedJob.Columns(j).Name = "Trans Date" Then
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.NumberFormatLocal = "m/d/yyyy"
                        rg.Value2 = dgvRejectedJob.Rows(i).Cells(j).Value.ToString()

                    ElseIf dgvRejectedJob.Columns(j).Name = "Settlment" Then
                        rg = xlWorkSheet.Cells(i + 1 + 5, j + 1)
                        rg.NumberFormat = "$0.00"
                        rg.Value2 = dgvRejectedJob.Rows(i).Cells(j).Value.ToString()

                    Else
                        xlWorkSheet.Cells(i + 1 + 5, j + 1) = dgvRejectedJob.Rows(i).Cells(j).Value.ToString()
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
End Class
