Imports DataAccessLayer
Imports System.Data.OleDb

Public Class AcknowledgementBAL
    Dim dbConnection As DbConnection = New DbConnection()
    Public Function CreateNewAcknowledgement(ByVal jobInfoBO As AcknowledgementBO)
        Try
            Dim query As String = "INSERT INTO Acknowledgement ([VendorId],[TransDate],[Comments],[CreateDate]) VALUES (@vendorId,@transDate,@comments,@entryDate)"
            dbConnection.ConnectDatabase()
            dbConnection.AddParamter("@vendorId", OleDbType.Integer, jobInfoBO.VendorId)
            dbConnection.AddParamter("@transDate", OleDbType.Date, jobInfoBO.TransDate)
            dbConnection.AddParamter("@comments", OleDbType.VarChar, jobInfoBO.Comments)
            dbConnection.AddParamter("@entryDate", OleDbType.Date, Date.Now)
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function AcknowledgementJobs(ByVal fromDAte As Date, ByVal toDate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT Acknowledgement.VendorId AS [Vendor ID],Vendors.VendorName AS [Vendor Name],Vendors.FirstName + ' ' + Vendors.LastName AS [Contact Name],Acknowledgement.TransDate AS [Trans Date],Acknowledgement.Comments FROM Acknowledgement LEFT JOIN Vendors ON Acknowledgement.VendorId=Vendors.VendorId WHERE FORMAT(Acknowledgement.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDAte.ToString("yyyy/MM/dd") + "' AND '" + toDate.ToString("yyyy/MM/dd") + "'"

        Try
            dbConnection.ConnectDatabase()
            data = dbConnection.ExecuteQuery(query)
            dbConnection.CloseDatabase()

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return data
    End Function
    Public Function AcknowledgementJobs() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT Acknowledgement.VendorId AS [Vendor ID],Vendors.VendorName AS [Vendor Name],Vendors.FirstName + ' ' + Vendors.LastName AS [Contact Name],Acknowledgement.TransDate AS [Trans Date],Acknowledgement.Comments FROM Acknowledgement LEFT JOIN Vendors ON Acknowledgement.VendorId=Vendors.VendorId"

        Try
            dbConnection.ConnectDatabase()
            data = dbConnection.ExecuteQuery(query)
            dbConnection.CloseDatabase()

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return data
    End Function
End Class
