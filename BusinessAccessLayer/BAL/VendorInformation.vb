Imports DataAccessLayer

Public Class VendorInformationBAL

    Public Function Isexists(ByVal customerId As Integer) As Boolean
        Dim isexist As Boolean = False
        Dim query As String = "SELECT * FROM Vendors WHERE VendorId=" & customerId
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
    Public Function GetUserName() As String
        Dim user As String = username.ToString()
        Return user
    End Function

    Public Function addcustomerInformation(ByVal customerInfo As VendorInformationBO)
        Dim query As String = "INSERT INTO Vendors (VendorId,VendorName,FirstName,LastName,CompanyName,EmailAddress,BusinessPhone,HomePhone,CellPhone,Address,City,State,ZipCode,Contracts,Notes,Pin,EntryDate,AccountStatus,UserId) VALUES (" & customerInfo.CustomerId & ",'" + customerInfo.VendorName + "','" + customerInfo.FirstName + "','" + customerInfo.LastName + "','" + customerInfo.CompanyName + "','" + customerInfo.Email + "','" + customerInfo.BusinessPhone + "','" + customerInfo.HomePhone + "','" + customerInfo.CellPhone + "','" + customerInfo.Address + "','" + customerInfo.City + "','" + customerInfo.State + "','" + customerInfo.ZipCode + "'," & customerInfo.Contracts & ",'" + customerInfo.Notes + "','" + customerInfo.PinNumber + "','" + Date.Now.ToString("yyyy-MM-dd") + "'," & customerInfo.AccountStatus & "," & userId & ")"
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

    Public Function GetCityList() As DataTable

        Dim query As String = "SELECT Distinct City FROM Vendors"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetDistrictList() As DataTable

        Dim query As String = "SELECT Distinct District FROM Customers"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetStateList() As DataTable

        Dim query As String = "SELECT DISTINCT State FROM Vendors"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetStreetNameList() As DataTable

        Dim query As String = "SELECT DISTINCT StreetName FROM Customers"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetZipcodeList() As DataTable

        Dim query As String = "SELECT DISTINCT ZipCode FROM Vendors"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetAllCustomerInformation() As DataTable

        Dim query As String = "SELECT [Id] AS RecId,VendorId AS [Vendor ID],VendorName AS [Vendor Name],FirstName & ' ' & LastName AS [Contact Name],CompanyName AS [Company Name],EmailAddress AS [Email],FORMAT(BusinessPhone,'000-000-0000') AS [Business Phone],FORMAT(HomePhone,'000-000-0000') AS [Home Phone],FORMAT(CellPhone,'000-000-0000') AS [Cell Phone],[Address],City,State,ZipCode AS [Zip Code],Contracts AS [Contract],AccountStatus AS [Account Status],Notes,Pin FROM Vendors ORDER BY VendorId ASC"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function GetCustomerInformation(ByVal Id As Integer) As DataTable

        Dim query As String = "SELECT [Id] AS RecId,VendorId AS [Vendor ID],VendorName AS [Vendor Name],FirstName,LastName,CompanyName,EmailAddress AS [Email],BusinessPhone AS [Business Phone],HomePhone AS [Home Phone],CellPhone AS [Cell Phone],[Address],City,State,ZipCode AS [Zip Code],Contracts,AccountStatus AS [Account Status],Notes,Pin FROM Vendors WHERE [ID]=" & Id
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function
    Public Function GetCustomerInformation1(ByVal CustomerId As String) As DataTable

        Dim query As String = "SELECT [Id],CustomerId AS [Customer Id],FirstName AS [First Name],LastName AS [Last Name],ContactNumber AS [Contact Number],HouseNo AS [House No],Street,City,District,State,ActiveDate,EntryDate AS [Entry Date] FROM Customers WHERE CustomerId='" + CustomerId + "'"
        Dim dbConnection As DbConnection = New DbConnection()
        Dim datatable As DataTable = New DataTable()

        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return datatable
    End Function

    Public Function updatecustomerInformation(ByVal customerInfo As VendorInformationBO, ByVal Id As Integer)
        Dim query As String = "UPDATE Vendors SET VendorName='" + customerInfo.VendorName + "',FirstName='" + customerInfo.FirstName + "',LastName='" + customerInfo.LastName + "',CompanyName='" + customerInfo.CompanyName + "',EmailAddress='" + customerInfo.Email + "',BusinessPhone='" + customerInfo.BusinessPhone + "',HomePhone='" + customerInfo.HomePhone + "',CellPhone='" + customerInfo.CellPhone + "',[Address]='" + customerInfo.Address + "',City='" + customerInfo.City + "',State='" + customerInfo.State + "',ZipCode='" + customerInfo.ZipCode + "',Contracts=" & customerInfo.Contracts & ",AccountStatus=" & customerInfo.AccountStatus & ",Notes='" + customerInfo.Notes + "',Pin='" + customerInfo.PinNumber + "',EntryDate='" + Date.Now.ToString("yyyy-MM-dd") + "',UserId=" & userId & " WHERE [ID]=" & Id
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
    Public Function GetCustomerList() As DataTable

        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT [Id],CustomerId & ',' & FirstName & ' ' & LastName AS [Customer] FROM Customers"
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
    Public Function updatecustomerInsuranceInformation(ByVal InsuranceNotes As String, ByVal PatientId As String)
        Dim query As String = "UPDATE Customers SET InsuranceNotes='" + InsuranceNotes + "' ,LastEdit='" + Date.Now.ToString("yyyy-MM-dd") + "',LastEditBy=" & userId & " WHERE [CustomerId]='" + PatientId + "'"
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

    Public Function RemoveCustomer(ByVal RecId As Integer)
        Dim query As String = "DELETE FROM Vendors WHERE [ID]=" & RecId
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

End Class
