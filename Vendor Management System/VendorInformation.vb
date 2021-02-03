Imports BusinessAccessLayer
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Text.RegularExpressions

Public Class VendorInformation
    Dim _access As status = status.Insert
    Dim RecId As Integer = 0
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Dim _VendorId As Integer = 0
    Private _rIdx As Integer = 0
    Private Sub VendorInformation_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint, tpBasicInformation.Paint, tpSpecialNotes.Paint, tpAllclient.Paint, VendorProfileSummary.Paint
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
    Private Sub exitbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        resetInput()
    End Sub
    Private Function resetInput()

        customerIdtxt.Text = ""
        firstnametxt.Text = ""
        lastnametxt.Text = ""
        txtCompanyName.Text = ""
        BusinessPhoneTxt.Text = ""
        HomePhoneTxt.Text = ""
        CellPhonetxt.Text = ""
        EmailAdresstxt.Text = ""
        Addresstxt.Text = ""
        contactnotxt.Text = ""
        PinNumbertxt.Text = ""
        notestxt.Text = ""
        txtVendorName.Text = ""
        chbActive.Checked = True
        VendImage.Image = Nothing
        _access = status.Insert
        lblImageVendorId.Text = "Vendor ID # No"
        lblImageSaveStatus.Text = "No Photo Unpload"
        RecId = 0
        customerIdtxt.ReadOnly = False
        customerIdtxt.Focus()

        Return Nothing
    End Function

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        If validateCustomerInformation() = True Then
            saveInformation()
        End If
    End Sub

    Private Function saveInformation()
        Dim customerInfoBO As VendorInformationBO = New VendorInformationBO()
        customerInfoBO.CustomerId = Integer.Parse(customerIdtxt.Text)
        customerInfoBO.VendorName = txtVendorName.Text
        customerInfoBO.FirstName = firstnametxt.Text
        customerInfoBO.LastName = lastnametxt.Text
        customerInfoBO.CompanyName = txtCompanyName.Text
        customerInfoBO.BusinessPhone = BusinessPhoneTxt.Text
        customerInfoBO.HomePhone = HomePhoneTxt.Text
        customerInfoBO.CellPhone = CellPhonetxt.Text
        customerInfoBO.Email = EmailAdresstxt.Text
        customerInfoBO.Address = Addresstxt.Text
        customerInfoBO.Contracts = Integer.Parse(contactnotxt.Text)
        customerInfoBO.City = Citytxt.Text
        customerInfoBO.State = Statetxt.Text
        customerInfoBO.ZipCode = zipcodetxt.Text
        customerInfoBO.Notes = notestxt.Text
        customerInfoBO.PinNumber = PinNumbertxt.Text

        If chbActive.Checked = True Then
            customerInfoBO.AccountStatus = True
        Else
            customerInfoBO.AccountStatus = False
        End If

        Dim customer As VendorInformationBAL = New VendorInformationBAL()

        If _access = status.Insert Then
            Try
                If customer.Isexists(customerInfoBO.CustomerId) = True Then
                    UserMessageBox.ShowMessageBox("Vendor ID " + customerIdtxt.Text + " already exists in the Vendor Job Management System. Please enter different unique Vendor ID.", "Vendor ID", 1, 3)
                    Return Nothing
                End If

                customer.addcustomerInformation(customerInfoBO)
                getallCustomerInformation()
                _VendorId = Integer.Parse(customerIdtxt.Text)

                UserMessageBox.ShowMessageBox("Sucessfully Saved Vendor Information of ID-" + customerIdtxt.Text + ".", "New Vendor Creatd", 1, 1)
                resetInput()
                LoadInputInformation()
                Me.GetVendorProfile(0)
            Catch ex As Exception
                UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
            End Try

        ElseIf _access = status.Edit Then
            Try
                If RecId <> 0 Then
                    customer.updatecustomerInformation(customerInfoBO, RecId)
                    getallCustomerInformation()
                    resetInput()
                    LoadInputInformation()
                    _access = status.Insert
                    customerIdtxt.ReadOnly = False
                    Me.GetVendorProfile(0)
                    UserMessageBox.ShowMessageBox("Sucessfully Updated Vendor Information of Vendor ID " + customerInfoBO.CustomerId.ToString(), "Vendor Information Update", 1, 1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

        Return Nothing
    End Function

    Private Function getallCustomerInformation()
        Dim customer As VendorInformationBAL = New VendorInformationBAL()
        Try
            Dim datatable As DataTable = customer.GetAllCustomerInformation()
            Customeralldgv.DataSource = datatable
            Customeralldgv.Columns("RecId").Visible = False
            Customeralldgv.Columns("Pin").Visible = False
            Customeralldgv.Columns("Contract").DefaultCellStyle.Format = "0\%"
            Customeralldgv.Columns("Contract").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Customeralldgv.Columns("Vendor ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub customerIdtxt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles customerIdtxt.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Function LoadInputInformation()
        Try
            Dim customerInfo As VendorInformationBAL = New VendorInformationBAL()

            Dim data2 As DataTable = customerInfo.GetCityList()
            Citytxt.DataSource = data2
            Citytxt.DisplayMember = "City"

            Dim data3 As DataTable = customerInfo.GetStateList()
            Statetxt.DataSource = data3
            Statetxt.DisplayMember = "State"

            Dim data4 As DataTable = customerInfo.GetZipcodeList()
            zipcodetxt.DataSource = data4
            zipcodetxt.DisplayMember = "ZipCode"

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Function validateCustomerInformation() As Boolean
        Dim isvalidated As Boolean = True
        Dim contractPercentage As Integer = 0

        If customerIdtxt.Text = String.Empty Then
            UserMessageBox.ShowMessageBox("Vendor ID can not blank. Unique Vendor ID is required to create new vendor.", "Vendor ID Required!", 1, 3)
            isvalidated = False
        ElseIf firstnametxt.Text = String.Empty Then
            UserMessageBox.ShowMessageBox("Vendor First Name can not blank. Please enter the vendor first name of Vendor ID " + customerIdtxt.Text, "First Name Required!", 1, 3)
            isvalidated = False
        ElseIf EmailAdresstxt.Text <> String.Empty And Me.IsEmail(EmailAdresstxt.Text) = False Then
            UserMessageBox.ShowMessageBox("Invaild email address. Please enter the valid email address of Vendor ID " + customerIdtxt.Text + ", Vendor name " + firstnametxt.Text + " " + lastnametxt.Text, " Valid Email Address Required!", 1, 3)
            isvalidated = False
        ElseIf BusinessPhoneTxt.Text <> String.Empty And BusinessPhoneTxt.MaskCompleted = False Then
            UserMessageBox.ShowMessageBox("Invaild business phone number. Please enter valid business phone number.", "Valid Business Phone Required!", 1, 3)
            isvalidated = False
        ElseIf HomePhoneTxt.Text <> String.Empty And HomePhoneTxt.MaskCompleted = False Then
            UserMessageBox.ShowMessageBox("Invaild home phone number. Please enter valid home phone number.", "Valid Home phone Required!", 1, 3)
            isvalidated = False
        ElseIf CellPhonetxt.Text <> String.Empty And CellPhonetxt.MaskCompleted = False Then
            UserMessageBox.ShowMessageBox("Invaild cell phone number. Please enter valid business cell phone.", "Cell phone Required!", 1, 3)
            isvalidated = False
        ElseIf PinNumbertxt.Text = String.Empty Then
            UserMessageBox.ShowMessageBox("Vendor pin number can not blank. Please enter the vendor secure pin number.", "Pin number Required!", 1, 3)
            isvalidated = False
        ElseIf contactnotxt.Text = String.Empty Then
            UserMessageBox.ShowMessageBox("Vendor contract can not blank. Please enter vendor contract between 0 - 99.", "Contract Required!", 1, 3)
            isvalidated = False
        Else
            isvalidated = True
        End If
        Return isvalidated
    End Function

    Function IsEmail(ByVal email As String) As Boolean
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")

        Return emailExpression.IsMatch(email)
    End Function

    Private Sub VendorInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInputInformation()
        getallCustomerInformation()
        Me.GetVendorProfile(0)
    End Sub
    
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        LoadInputInformation()
        getallCustomerInformation()
        resetInput()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If ItemImgofd.ShowDialog() <> DialogResult.Cancel Then
                DisplayImage(ItemImgofd.FileName)
                lblDesigningImage.Visible = False
                Me.VendorPhotoSaveStatus(True)
            End If

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function DisplayImage(ByVal imagepath As String)
        Try
            Dim fs As System.IO.FileStream
            fs = New System.IO.FileStream(imagepath, IO.FileMode.Open, IO.FileAccess.Read)
            VendImage.Image = System.Drawing.Image.FromStream(fs)
            fs.Close()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            If customerIdtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Please put the Vendor Id First. To upload the photo of vendor, vendor ID is required.", "Vendor ID Required!", 1, 3)
                Return
            End If

            If ItemImgofd.FileName = String.Empty And VendImage.Image IsNot Nothing Then
                UserMessageBox.ShowMessageBox("Vendor ID-" + customerIdtxt.Text + " has already existed a photo. To upload new vendor photo please select a new vendor photo.", "Vendor Photo", 1, 3)
                Return
            End If

            If ItemImgofd.FileName = String.Empty Then
                UserMessageBox.ShowMessageBox("Please Select the Vendor Photo. Then save the vendor photo.", "Vendor Photo Required!", 1, 3)
                Return
            End If

            If ItemImgofd.FileName IsNot String.Empty And Integer.Parse(customerIdtxt.Text) <> 0 Then
                Dim imagepath = Directory.GetCurrentDirectory() + "\\image\\" + customerIdtxt.Text + ".png"
                Me.saveImage(imagepath)
                Me.VendorPhotoSaveStatus(False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function saveImage(ByVal ImagePath As String)
        Try
            If File.Exists(ImagePath) Then
                File.Delete(ImagePath)
            End If
            Image.FromFile(ItemImgofd.FileName).Save(ImagePath)
            ItemImgofd.FileName = ""
        Catch ex As Exception
            VendImage.Image.Save(ImagePath)
        End Try
        Return Nothing
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If VendImage.Image IsNot Nothing And Integer.Parse(customerIdtxt.Text) <> 0 Then
                Dim imagepath = Directory.GetCurrentDirectory() + "\\image\\" + customerIdtxt.Text + ".png"
                If File.Exists(imagepath) = True Then
                    File.Delete(imagepath)
                End If
                lblDesigningImage.Visible = True
                VendImage.Image = Nothing
                ItemImgofd.FileName = ""
                Me.VendorPhotoSaveStatus(False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub VendorPhotoSaveStatus(ByVal Isuploaded As Boolean)
        If customerIdtxt.Text = String.Empty Then
            lblImageVendorId.Text = "Vendor ID Required!"
            lblImageVendorId.ForeColor = Color.DarkRed
        Else
            lblImageVendorId.Text = "Vendor ID : " + customerIdtxt.Text
            lblImageVendorId.ForeColor = Color.AliceBlue
        End If
        If Isuploaded = True And VendImage.Image IsNot Nothing Then
            lblImageSaveStatus.Text = "Uploaded Photo Not Saved"
            lblImageSaveStatus.ForeColor = Color.DarkRed
        ElseIf Isuploaded = False And VendImage.Image IsNot Nothing Then
            lblImageSaveStatus.Text = "Vendor Photo Saved"
            lblImageSaveStatus.ForeColor = Color.AliceBlue
        Else
            lblImageSaveStatus.Text = "No Photo Uploaded"
            lblImageSaveStatus.ForeColor = Color.AliceBlue
        End If
    End Sub
    Private Sub Customeralldgv_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Customeralldgv.CellMouseClick
        Try
            If e.RowIndex < 0 Then
                Return
            End If

            If Customeralldgv.Rows.Count > 0 And e.RowIndex > -1 Then
                Me.GetVendorProfile(e.RowIndex)
            End If

            If Customeralldgv.Rows.Count > 0 And e.ColumnIndex = 0 Then

                Dim Id As Integer = Integer.Parse(Customeralldgv.Rows(e.RowIndex).Cells("RecId").Value.ToString())
                Dim customer As VendorInformationBAL = New VendorInformationBAL()
                Dim datatable As DataTable = customer.GetCustomerInformation(Id)

                Dim seletedVendorId As String = datatable.Rows(0)("Vendor Id").ToString()
                Dim seletedVendorName As String = datatable.Rows(0)("FirstName").ToString() + " " + datatable.Rows(0)("LastName").ToString()
                RecId = Id
                _rIdx = e.RowIndex
                If datatable.Rows.Count > 0 And e.RowIndex > -1 Then
                    If e.ColumnIndex = 0 Then
                        UserMessageBox.ShowMessageBox("Do you want to Update the Vendor Information of ID- " + seletedVendorId + ", Contact Name : " + seletedVendorName + "?", "Vendor Information Update Request!", 2, 2)
                        If UserMessageBox._DialogResult = Windows.Forms.DialogResult.Yes Then
                            _access = status.Edit
                            customerIdtxt.ReadOnly = True
                            customerIdtxt.Text = datatable.Rows(0)("Vendor Id").ToString()
                            txtVendorName.Text = datatable.Rows(0)("Vendor Name").ToString()
                            firstnametxt.Text = datatable.Rows(0)("FirstName").ToString()
                            lastnametxt.Text = datatable.Rows(0)("LastName").ToString()
                            txtCompanyName.Text = datatable.Rows(0)("CompanyName").ToString()
                            EmailAdresstxt.Text = datatable.Rows(0)("Email").ToString()
                            BusinessPhoneTxt.Text = datatable.Rows(0)("Business Phone").ToString()
                            HomePhoneTxt.Text = datatable.Rows(0)("Home Phone").ToString()
                            CellPhonetxt.Text = datatable.Rows(0)("Cell Phone").ToString()
                            contactnotxt.Text = datatable.Rows(0)("Contracts").ToString()
                            Addresstxt.Text = datatable.Rows(0)("Address").ToString()
                            Citytxt.Text = datatable.Rows(0)("City").ToString()
                            Statetxt.Text = datatable.Rows(0)("State").ToString()
                            zipcodetxt.Text = datatable.Rows(0)("Zip Code").ToString()
                            notestxt.Text = datatable.Rows(0)("Notes").ToString()
                            PinNumbertxt.Text = datatable.Rows(0)("Pin").ToString()

                            If IsDBNull(datatable.Rows(0)("Account Status")) Then
                                chbActive.Checked = False
                            Else
                                Dim accountstatus As Boolean = Convert.ToBoolean(datatable.Rows(0)("Account Status"))
                                If accountstatus = True Then
                                    chbActive.Checked = True
                                Else
                                    chbActive.Checked = False
                                End If
                            End If

                            _VendorId = customerIdtxt.Text


                            lblDesigningImage.Visible = True
                            VendImage.Image = Nothing
                            Me.VendorPhotoSaveStatus(False)

                            Dim Imagepath As String = Directory.GetCurrentDirectory() + "\\image\\" + _VendorId.ToString() + ".png"

                            If Integer.Parse(_VendorId) <> 0 And File.Exists(Imagepath) Then
                                lblDesigningImage.Visible = False
                                DisplayImage(Imagepath)
                                Me.VendorPhotoSaveStatus(False)
                            End If
                        End If
                    End If
                End If
            End If


            If Customeralldgv.Rows.Count > 0 And e.ColumnIndex = 1 Then

                Dim rowIdx As Integer = e.RowIndex
                Dim seletedVendorId As String = Customeralldgv.Rows(rowIdx).Cells("Vendor Id").Value.ToString()
                Dim seletedVendorName As String = Customeralldgv.Rows(0).Cells("Vendor Name").Value.ToString()
                UserMessageBox.ShowMessageBox("Do you want to Remove the Vendor Information of ID- " + seletedVendorId + ", Contact Name : " + seletedVendorName + "?", "Remove Vendor Request!", 2, 2)

                If UserMessageBox._DialogResult = Windows.Forms.DialogResult.Yes Then
                    Dim customer As VendorInformationBAL = New VendorInformationBAL()
                    Dim RecId As Integer = Integer.Parse(Customeralldgv.Rows(e.RowIndex).Cells("RecId").Value.ToString())
                    customer.RemoveCustomer(RecId)
                    Me.removeVendorPhoto(seletedVendorId)
                    getallCustomerInformation()
                    _VendorId = Customeralldgv.Rows(0).Cells("Vendor Id").Value.ToString()
                    UserMessageBox.ShowMessageBox("Vendor ID-" + seletedVendorId + ",Contact Name-" + seletedVendorName + " has been sucessfully removed from Vendor Job Management System.", "Vendor Information Remove Completed!", 1, 1)
                    resetInput()
                    Me.GetVendorProfile(0)
                End If
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub removeVendorPhoto(ByVal vendorId As String)
        Try
            If vendorId = String.Empty Then
                Return
            End If

            Dim imagepath = Directory.GetCurrentDirectory() + "\\image\\" + vendorId + ".png"
            If File.Exists(imagepath) = True Then
                File.Delete(imagepath)
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If tpAllclient.Focus() = True Then
                If Customeralldgv.Rows.Count <= 0 Then
                    UserMessageBox.ShowMessageBox("No vendor information exists to export.", "Vendor Information Export", 1, 1)
                    Return
                End If


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
                xlWorkSheet.Name = "Vendor Information"


                xlWorkSheet.Range("A1:K1").Merge()
                xlWorkSheet.Range("A1:K1").Value = "Vendor Information Overview"
                xlWorkSheet.Range("A1:K1").Font.Bold = True
                xlWorkSheet.Range("A1:K1").Font.Size = 16
                xlWorkSheet.Range("A1:K1").Font.Name = "Arial"
                xlWorkSheet.Range("A1:K1").Style.HorizontalAlignment = -4108




                For i = 3 To Customeralldgv.Columns.Count - 1
                    xlWorkSheet.Cells(3, i - 2) = Customeralldgv.Columns(i).HeaderText
                    rg = xlWorkSheet.Cells(3, i - 2)
                    rg.EntireColumn.AutoFit()
                    rg.Font.Bold = True
                Next


                For i = 0 To Customeralldgv.RowCount - 1
                    For j = 3 To Customeralldgv.ColumnCount - 1
                        If Customeralldgv.Columns(j).Name = "Vendor ID" Then
                            rg = xlWorkSheet.Cells(i + 1 + 3, j - 2)
                            rg.NumberFormatLocal = "@"
                            rg.HorizontalAlignment = -4152
                            rg.Value2 = Customeralldgv.Rows(i).Cells(j).Value.ToString()
                        ElseIf Customeralldgv.Columns(j).Name = "Contract" Then
                            rg = xlWorkSheet.Cells(i + 1 + 3, j - 2)
                            rg.HorizontalAlignment = -4152
                            rg.Value2 = Customeralldgv.Rows(i).Cells(j).Value.ToString()
                        Else
                            xlWorkSheet.Cells(i + 1 + 3, j - 2) = Customeralldgv.Rows(i).Cells(j).Value.ToString()
                            rg = xlWorkSheet.Cells(i + 1 + 5, j - 2)
                            rg.HorizontalAlignment = -4131
                            rg.EntireColumn.AutoFit()
                        End If
                    Next
                Next

                xlApp.Visible = True
                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)
            End If


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

    Private Sub contactnotxt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Function GetVendorProfile(ByVal RowIdx As Integer)
        Try
            If Customeralldgv.RowCount < 0 Then
                Return Nothing
            End If


            Dim vendorId As Integer = Integer.Parse(Customeralldgv.Rows(RowIdx).Cells("Vendor ID").Value.ToString())
            Dim Jobinfo As JobProcessingInfo = New JobProcessingInfo()
            Dim datatable As DataTable = Jobinfo.GetVendorProfile(vendorId)

            If datatable.Rows.Count > 0 Then

                lblVendorName.Text = "Contact Name: " + datatable.Rows(0)(1).ToString()
                lblVendorIdContracts.Text = "ID: " + datatable.Rows(0)(0).ToString() + "  Contract: " + datatable.Rows(0)(2).ToString() + " %"

                lblJobOffer.Text = "Job Offer: " + datatable.Rows(0)(3).ToString()
                lblApprovedJob.Text = "Approved Job: " + datatable.Rows(0)(4).ToString()
                lblDeclineJob.Text = "Decline Job: " + datatable.Rows(0)(5).ToString()

                If datatable.Rows(0)(6) IsNot DBNull.Value Then
                    lblofferSatlement.Text = "Offer Satlement: $" + datatable.Rows(0)(6).ToString()
                Else
                    lblofferSatlement.Text = "Offer Satlement: $0.00"
                End If

                If datatable.Rows(0)(7) IsNot DBNull.Value Then
                    lblApprovedSatlement.Text = "Approved Satlement: $" + datatable.Rows(0)(7).ToString()
                Else
                    lblApprovedSatlement.Text = "Approved Satlement: $0.00"
                End If

                If datatable.Rows(0)(8) IsNot DBNull.Value Then
                    lblDeclineSatlement.Text = "Decline Satlement: $" + datatable.Rows(0)(8).ToString()
                Else
                    lblDeclineSatlement.Text = "Decline Satlement: $0.00"
                End If


            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function
End Class