Imports System.Drawing.Drawing2D
Imports BusinessAccessLayer
Imports System.IO



Public Class Backup
    Dim UserMessageBox As MessageBoxUser = New MessageBoxUser()
    Dim usrCreation As UserCreationBAL = New UserCreationBAL()

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(40, 125, 180), 10)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.Panel1.Width, Me.Panel1.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(47, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Backup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblBackup.Text = "           Database Backup Time " + DateAndTime.Now.ToString("F")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() <> DialogResult.Cancel Then
            txtBackup.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If txtBackup.Text.Trim() = String.Empty Then
                UserMessageBox.ShowMessageBox("Please Select a Database Backup location.", "Database Backup", 1, 2)
                Return
            End If
            lblBackupStatus.Text = "Backup: Processing..."
            Dim sourceFile As String = Directory.GetCurrentDirectory() + "\\VendorJobDB.mdb"
            Dim postIndex As Integer = 0
            Dim backupPath As String = txtBackup.Text + "\\" + "VendorJobDB" + "_" + Date.Now.ToString("yyyyMMdd") + "_" + postIndex.ToString() + ".mdb"

            While (Me.IsExists(backupPath) = True)
                postIndex = postIndex + 1
                backupPath = txtBackup.Text + "\\" + "VendorJobDB" + "_" + Date.Now.ToString("yyyyMMdd") + "_" + postIndex.ToString() + ".mdb"
            End While

            File.Copy(sourceFile, backupPath)
            UserMessageBox.ShowMessageBox("Sucessfilly Database Backup is completed.", "Database Backup", 1, 1)
            Me.Close()

        Catch ex As Exception
            UserMessageBox.ShowMessageBox(ex.Message, "Error", 1, 4)
        End Try
    End Sub
    Private Function IsExists(ByVal filePath As String) As Boolean
        If File.Exists(filePath) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub lblBackup_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Try
            Dim pen As Pen = New Pen(Color.FromArgb(19, 95, 152), 0)
            Dim rect As New System.Drawing.Rectangle(0, 0, Me.lblBackup.Width, Me.lblBackup.Height)
            Dim gradientBrush As New LinearGradientBrush(rect, Color.FromArgb(30, 128, 185), Color.FromArgb(221, 241, 255), LinearGradientMode.ForwardDiagonal)
            Dim graphics As Graphics = e.Graphics
            graphics.FillRectangle(gradientBrush, rect)
            e.Graphics.DrawRectangle(pen, rect)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class