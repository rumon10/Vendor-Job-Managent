Imports BusinessAccessLayer
Imports System.Drawing.Drawing2D

Public Class fromUserCreation
    Private _status As status = status.Insert
    Private _recId As String = "0"
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            If Usernametxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("User Name can not blank. Unique user name is required.", "User Name", 1, 1)
                Return
            ElseIf passwordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Password can not blank. Please enter your secure password.", "Password", 1, 1)
                Return

            ElseIf confirmpasswordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox("Confirm Password can not blank. Please enter your confirm password to ensure more.", "Confirm Password", 1, 1)
                Return

            ElseIf String.Equals(passwordtxt.Text, confirmpasswordtxt.Text) = False < 0 Then
                UserMessageBox.ShowMessageBox("Password & confirmation password does not match.", "Password Match", 1, 1)
                Return

            Else
                Dim userCreation As UserCreationBAL = New UserCreationBAL()
                Dim userCreationBO As UserInformationmBO = New UserInformationmBO()

                userCreationBO.UserName = Usernametxt.Text
                userCreationBO.FullName = fullnametxt.Text
                userCreationBO.Password = passwordtxt.Text


                If (_status = status.Insert) Then
                    If userCreation.Isexists(Usernametxt.Text) = True Then
                        UserMessageBox.ShowMessageBox("User Name " + Usernametxt.Text + " already exists. Please enter unique user name.", "User Name", 1, 3)
                        Return
                    Else
                        userCreation.addcustomerInformation(userCreationBO)
                        UserMessageBox.ShowMessageBox("Sucessfully new user is created.", "User Name", 1, 1)

                    End If

                ElseIf _status = status.Edit Then
                    userCreation.updateUserInformation(userCreationBO, _recId)
                    UserMessageBox.ShowMessageBox("Sucessfully Updated the user Information.", "User Name", 1, 1)
                End If

                GetUserList()
                Reset()
            End If

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Function GetUserList()
        Try
            Dim userCreation As UserCreationBAL = New UserCreationBAL()
            Dim data As DataTable = userCreation.GetUsrInfo()
            userInformationdgv.DataSource = data
            userInformationdgv.Columns("UserId").Visible = False
            userInformationdgv.Columns("Password").Visible = False
            userInformationdgv.Columns("Create Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            userInformationdgv.Columns("Create Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            userInformationdgv.Columns(0).Width = 55
            userInformationdgv.Columns(1).Width = 55
            userInformationdgv.Columns("User Name").Width = 100
            userInformationdgv.Columns("Name").Width = 210
            userInformationdgv.Columns("Create Date").Width = 80
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
        Return Nothing
    End Function

    Private Sub fromUserCreation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetUserList()
    End Sub

    Private Sub userInformationdgv_CellMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles userInformationdgv.CellMouseClick
        Try
            If userInformationdgv.Rows.Count > 0 And e.RowIndex > -1 Then
                Dim rowIdx As Integer = e.RowIndex
                _recId = userInformationdgv.Rows(rowIdx).Cells("UserId").Value.ToString()

                If e.ColumnIndex = 0 Then
                    UserMessageBox.ShowMessageBox("Do you want to update this user Information?", "User Information", 2, 2)
                    If UserMessageBox._DialogResult = Windows.Forms.DialogResult.Yes Then
                        _status = status.Edit
                        Usernametxt.Text = userInformationdgv.Rows(rowIdx).Cells("User Name").Value.ToString()
                        Usernametxt.ReadOnly = True
                        passwordtxt.Text = userInformationdgv.Rows(rowIdx).Cells("Password").Value.ToString()
                        confirmpasswordtxt.Text = userInformationdgv.Rows(rowIdx).Cells("Password").Value.ToString()
                        fullnametxt.Text = userInformationdgv.Rows(rowIdx).Cells("Name").Value.ToString()
                    End If
                ElseIf e.ColumnIndex = 1 Then
                    UserMessageBox.ShowMessageBox("Do you want to delete this User Information?", "User Information", 2, 2)
                    If UserMessageBox._DialogResult = Windows.Forms.DialogResult.Yes Then
                        Dim userCreation As UserCreationBAL = New UserCreationBAL()
                        userCreation.DeleteUserInformation(_recId)
                        GetUserList()
                    End If
                End If
            End If
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        Reset()
    End Sub
    Private Function Reset()
        Usernametxt.Text = ""
        passwordtxt.Text = ""
        fullnametxt.Text = ""
        confirmpasswordtxt.Text = ""
        _status = status.Insert
        _recId = "0"
        Usernametxt.ReadOnly = False
        Return Nothing
    End Function

    Private Sub fromUserCreation_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
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
End Class