Imports BusinessAccessLayer
Imports System.Drawing.Drawing2D

Public Class Login
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Dim currentTabIndex As Integer = 0
    Dim currentTextTab As Integer = 0

    Private Sub exitbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitbtn.Click
        Application.Exit()
    End Sub

    Private Sub loginbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginbtn.Click
        Try
            currentTabIndex = 3
            UserLogin()
        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function UserLogin()
        Try
            If usernametxt.Text = String.Empty And passwordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox(Label1.Text + " and " + Label2.Text + " are required to login Vendor Job Management System.", Label1.Text + " & " + Label2.Text + " Required!", 1, 3)
                Return Nothing
            ElseIf usernametxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox(Label1.Text + " is required to login Vendor Job Management System.", Label1.Text + " Required!", 1, 3)
                Return (Nothing)
            ElseIf passwordtxt.Text = String.Empty Then
                UserMessageBox.ShowMessageBox(Label2.Text + " is required to login Vendor Job Management System.", Label2.Text + " Required!", 1, 3)
                Return Nothing

            Else
                Dim userInformation As UserInformation = New UserInformation()

                If dllAccessType.SelectedIndex = 0 Then

                    If userInformation.IsAunthenticatedUser(usernametxt.Text, passwordtxt.Text) = True Then
                        Dim mainform As Mainform = New Mainform()
                        Me.Hide()
                        mainform.userAccess = 0
                        mainform.Show()
                    Else
                        UserMessageBox.ShowMessageBox("Incorrect " + Label1.Text + " and " + Label2.Text + ". Please Enter correct " + Label1.Text + " and " + Label2.Text + " to login Vendor Job Management System.", "Correct " + Label1.Text + " & " + Label2.Text + " Required!", 1, 3)
                        usernametxt.Text = ""
                        passwordtxt.Text = ""
                    End If

                ElseIf dllAccessType.SelectedIndex = 1 Then

                    Dim vendorId As Integer = 0
                    If Integer.TryParse(usernametxt.Text, vendorId) = False Then
                        UserMessageBox.ShowMessageBox("Incorrect Vendor ID format. Please enter correct format of Vendor ID.", "Correct Format Vendor ID Required!", 1, 3)
                        Return Nothing
                    Else
                        vendorId = Integer.Parse(usernametxt.Text)
                    End If
                    If userInformation.IsAunthenticatedVendor(usernametxt.Text, passwordtxt.Text) = True Then
                        Dim mainform As Mainform = New Mainform()
                        Me.Hide()
                        mainform.userAccess = 1
                        mainform.Show()
                    Else
                        UserMessageBox.ShowMessageBox("Incorrect " + Label1.Text + " and " + Label2.Text + ". Please Enter correct " + Label1.Text + " and " + Label2.Text + " to login Vendor Job Management System.", "Correct " + Label1.Text + " & " + Label2.Text + " Required!", 1, 3)
                        usernametxt.Text = ""
                        passwordtxt.Text = ""
                    End If

                End If
            End If
        Catch ex As Exception
            Throw
        End Try
        Return Nothing
    End Function
   
    Private Sub Login_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        Try

            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 12)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Width - 10, Me.Height - 32)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dllAccessType.SelectedIndex = 0
    End Sub

    Private Sub dllAccessType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dllAccessType.SelectedIndexChanged
        Try
            If dllAccessType.SelectedIndex = 0 Then
                Label1.Text = "User Name"
                Label2.Text = "Password"
            ElseIf dllAccessType.SelectedIndex = 1 Then
                Label1.Text = "Vendor ID"
                Label2.Text = "Pin Number"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOne.Click

        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "1")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "1")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If

    End Sub

    Private Sub usernametxt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usernametxt.Leave
        currentTextTab = 1
        currentTabIndex = 1
    End Sub

    Private Sub passwordtxt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passwordtxt.Leave
        currentTextTab = 2
        currentTabIndex = 2
    End Sub

    Private Sub btnTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTwo.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "2")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "2")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnThree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnThree.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "3")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "3")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnFour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFour.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "4")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "4")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnFive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFive.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "5")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "5")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnSix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSix.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "6")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "6")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnSeven_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeven.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "7")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "7")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnEgith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEgith.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "8")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "8")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnNine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNine.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "9")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "9")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZero.Click
        Dim cursorIndex As Integer = 0

        If currentTextTab = 1 Then
            cursorIndex = usernametxt.SelectionStart
            usernametxt.Text = usernametxt.Text.Insert(cursorIndex, "0")
            usernametxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            usernametxt.Focus()
        ElseIf currentTextTab = 2 Then
            cursorIndex = passwordtxt.SelectionStart
            passwordtxt.Text = passwordtxt.Text.Insert(cursorIndex, "0")
            passwordtxt.SelectionStart = cursorIndex + 1
            currentTextTab = 0
            passwordtxt.Focus()
        End If
    End Sub

    Private Sub btnTab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTab.Click
        If currentTabIndex <= 4 Then
            currentTabIndex = currentTabIndex + 1

            If currentTabIndex = 1 Then
                usernametxt.Focus()
            ElseIf currentTabIndex = 2 Then
                passwordtxt.Focus()
            ElseIf currentTabIndex = 3 Then
                loginbtn.Focus()
            ElseIf currentTabIndex = 4 Then
                exitbtn.Focus()
            Else
                dllAccessType.Focus()
                currentTabIndex = 0
            End If

            If currentTabIndex >= 4 Then
                currentTabIndex = 0
            End If
        End If
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        If currentTabIndex = 4 Then
            Application.Exit()
        Else
            Try
                UserLogin()
            Catch ex As Exception
                UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
            End Try
        End If
    End Sub

    Private Sub dllAccessType_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dllAccessType.Leave
        currentTabIndex = 0
    End Sub
End Class
