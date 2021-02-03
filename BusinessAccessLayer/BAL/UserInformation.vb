Imports DataAccessLayer

Public Class UserInformation

    Public Function IsAunthenticatedUser(ByVal user As String, ByVal pass As String) As Boolean
        Dim isactive As Boolean = False
        Dim query As String = "SELECT UserId,UserName,Password,FullName FROM USERS WHERE UserName='" + user + "' AND Password='" + pass + "'"
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            Dim datatable As DataTable = dbConnection.ExecuteQuery(query)
            If datatable.Rows.Count > 0 Then
                username = datatable.Rows(0)("UserName").ToString()
                password = datatable.Rows(0)("Password").ToString()
                userId = Integer.Parse(datatable.Rows(0)("UserId").ToString())
                UserFullName = datatable.Rows(0)("FullName").ToString()
                logindatetime = Date.Now.ToString()
                RoleName = "System Admin"
                isactive = True
            Else
                isactive = False
            End If

        Catch ex As Exception
            Throw ex

        Finally
            dbConnection.CloseDatabase()

        End Try

        Return isactive
    End Function

    Public Function IsAunthenticatedVendor(ByVal user As Integer, ByVal pass As String) As Boolean
        Dim isactive As Boolean = False
        Dim query As String = "SELECT * FROM Vendors WHERE VendorId=" & user & " AND [Pin]='" + pass + "'"
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            Dim datatable As DataTable = dbConnection.ExecuteQuery(query)
            If datatable.Rows.Count > 0 Then
                username = Integer.Parse(datatable.Rows(0)("VendorId").ToString())
                password = datatable.Rows(0)("Pin").ToString()
                userId = Integer.Parse(datatable.Rows(0)("VendorId").ToString())
                UserFullName = datatable.Rows(0)("FirstName").ToString() + " " + datatable.Rows(0)("LastName").ToString()
                logindatetime = Date.Now.ToString()
                RoleName = "Vendor"
                isactive = True
            Else
                isactive = False
            End If

        Catch ex As Exception
            Throw ex

        Finally
            dbConnection.CloseDatabase()

        End Try

        Return isactive
    End Function

End Class
