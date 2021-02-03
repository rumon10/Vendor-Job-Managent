Imports BusinessAccessLayer
Imports DataAccessLayer

Public Class UserCreationBAL
    Public Function addcustomerInformation(ByVal obj As UserInformationmBO)
        Dim query As String = "INSERT INTO Users (UserName,FullName,[Password],[CreatedDate]) VALUES ('" + obj.UserName + "','" + obj.FullName + "','" + obj.Password + "','" + Date.Now.ToString("yyyy/MM/dd") + "')"
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function

    Public Function Isexists(ByVal usrName As String) As Boolean
        Dim isexist As Boolean = False
        Dim query As String = "SELECT * FROM Users WHERE UserName='" + usrName + "'"
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            Dim datatable As DataTable = dbConnection.ExecuteQuery(query)
            If datatable.Rows.Count > 0 Then
                isexist = True
            Else
                isexist = False
            End If
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return isexist
    End Function

    Public Function updateUserInformation(ByVal Obj As UserInformationmBO, ByVal Id As Integer)
        Dim query As String = "UPDATE Users SET FullName='" + Obj.FullName + "',[Password]='" + Obj.Password + "' WHERE [UserId]=" & Id
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function

    Public Function GetUsrInfo() As DataTable

        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT [UserId],UserName AS [User Name],FullName AS [Name],CreatedDate AS [Create Date],[Password] FROM Users"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            datatable = dbconnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function ChangePassword(ByVal password As String)
        Dim query As String = "UPDATE Users SET [Password]='" + password + "' WHERE [UserId]=" & LoginInformationBO.userId
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            LoginInformationBO.password = password
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function

    Public Function DeleteUserInformation(ByVal Id As Integer)
        Dim query As String = "DELETE FROM Users WHERE [UserId]=" & Id
        Dim dbConnection As DbConnection = New DbConnection()
        Try
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function GetUserExistingPassword() As String
        Return password
    End Function
    Public Function GetExistingUsername() As String
        Return LoginInformationBO.username
    End Function
    Public Function GetExistingUserRole() As String
        Return LoginInformationBO.RoleName
    End Function
    Public Function GetExistingUserId() As String
        Return LoginInformationBO.userId
    End Function
    Public Function GetExistingUserFullName() As String
        Return LoginInformationBO.UserFullName
    End Function

    Public Function UserMemoryRelease()
        username = String.Empty
        logindatetime = Date.MinValue
        loginrole = String.Empty
        userId = 0
        password = String.Empty
        RoleName = String.Empty
        AttJobNo = 0
        JobAcceptedNo = 0
        Return Nothing
    End Function

End Class
