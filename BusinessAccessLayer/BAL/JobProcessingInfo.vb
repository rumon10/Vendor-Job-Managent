Imports DataAccessLayer
Imports System.Data.OleDb
Imports System.IO





Public Class JobProcessingInfo
    Dim dbConnection As DbConnection = New DbConnection()

    Public Function JobProcessing(ByVal filePath As String) As DataTable

        Dim filename As String = filePath
        Dim datatable As DataTable
        Dim connString As String = String.Format("Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""", Path.GetDirectoryName(filename))

        Try
            Using conn As OleDbConnection = New OleDbConnection(connString)
                conn.Open()
                Dim query As String = "SELECT * FROM [" + Path.GetFileName(filename) + "]"
                Using adapter As OleDbDataAdapter = New OleDbDataAdapter(query, conn)
                    Dim ds As DataSet = New DataSet("CSV File")
                    adapter.Fill(ds)
                    datatable = ds.Tables(0)
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
        Return datatable
    End Function
    Public Function ProcessJobInformation(ByVal jobInfoBO As JobInfoBO)
        Try

            Dim query As String = "INSERT INTO JobInfo ([VendorId],[TransDate],[JobNumber],[Address],[City],[State],[ZipCode],[settlment],[Status],[UserId],[EntryDate],[AttJobNo]) VALUES (" & jobInfoBO.VendorId & ",'" + jobInfoBO.TransDate.ToString("yyyy/MM/dd") + "'," & jobInfoBO.JobNumber & ",'" + jobInfoBO.Address + "','" + jobInfoBO.City + "','" + jobInfoBO.State + "','" + jobInfoBO.ZipCode + "'," & jobInfoBO.Stattlement & ",0," & userId & ",'" + Date.Now.ToString("yy/MM/dd") + "'," & AttJobNo & ")"
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception
            Throw
        End Try
        Return Nothing
    End Function
    Public Function ProcessJobInformationByParamterwise(ByVal jobInfoBO As JobInfoBO)
        Try
            Dim query As String = "INSERT INTO JobInfo ([VendorId],[TransDate],[JobNumber],[Address],[City],[State],[ZipCode],[settlment],[Status],[UserId],[EntryDate],[AttJobNo]) VALUES (@vendorId,@transDate,@jobNumber,@address,@city,@state,@zipCode,@settlment,@status,@userId,@entryDate,@attJobNo)"
            dbConnection.ConnectDatabase()
            dbConnection.AddParamter("@vendorId", OleDbType.Integer, jobInfoBO.VendorId)
            dbConnection.AddParamter("@transDate", OleDbType.Date, jobInfoBO.TransDate.ToString("yyyy/MM/dd"))
            dbConnection.AddParamter("@jobNumber", OleDbType.Integer, jobInfoBO.JobNumber)
            dbConnection.AddParamter("@address", OleDbType.VarChar, jobInfoBO.Address)
            dbConnection.AddParamter("@city", OleDbType.VarChar, jobInfoBO.City)
            dbConnection.AddParamter("@state", OleDbType.VarChar, jobInfoBO.State)
            dbConnection.AddParamter("@zipCode", OleDbType.VarChar, jobInfoBO.ZipCode)
            dbConnection.AddParamter("@settlment", OleDbType.Decimal, jobInfoBO.Stattlement)
            dbConnection.AddParamter("@status", OleDbType.Integer, 0)
            dbConnection.AddParamter("@userId", OleDbType.Integer, userId)
            dbConnection.AddParamter("@entryDate", OleDbType.Date, Date.Now)
            dbConnection.AddParamter("@attJobNo", OleDbType.Integer, AttJobNo)
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function ProcessJobInformationErrorByParamterwise(ByVal jobInfoBO As JobInfoErrorBO)
        Try
            Dim query As String = "INSERT INTO JobInfoError ([VendorId],[TransDate],[JobNumber],[Address],[City],[State],[ZipCode],[settlment],[Status],[UserId],[EntryDate],[ErrorReason],[AttJobNo]) VALUES (@vendorId,@transDate,@jobNumber,@address,@city,@state,@zipCode,@settlment,@status,@userId,@entryDate,@errorReason,@attJobNo)"
            dbConnection.ConnectDatabase()
            dbConnection.AddParamter("@vendorId", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.VendorId) Or jobInfoBO.VendorId.Length > 255), jobInfoBO.VendorId = String.Empty, jobInfoBO.VendorId))
            dbConnection.AddParamter("@transDate", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.TransDate) Or jobInfoBO.TransDate.Length > 255), jobInfoBO.TransDate = String.Empty, jobInfoBO.TransDate))
            dbConnection.AddParamter("@jobNumber", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.JobNumber) Or jobInfoBO.JobNumber.Length > 255), jobInfoBO.JobNumber = String.Empty, jobInfoBO.JobNumber))
            dbConnection.AddParamter("@address", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.Address) Or jobInfoBO.Address.Length > 255), jobInfoBO.Address = String.Empty, jobInfoBO.Address))
            dbConnection.AddParamter("@city", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.City) Or jobInfoBO.City.Length > 255), jobInfoBO.City = String.Empty, jobInfoBO.City))
            dbConnection.AddParamter("@state", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.State) Or jobInfoBO.State.Length > 255), jobInfoBO.State = String.Empty, jobInfoBO.State))
            dbConnection.AddParamter("@zipCode", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.ZipCode) Or jobInfoBO.ZipCode.Length > 255), jobInfoBO.ZipCode = String.Empty, jobInfoBO.ZipCode))
            dbConnection.AddParamter("@settlment", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.Stattlement) Or jobInfoBO.Stattlement.Length > 255), jobInfoBO.Stattlement = String.Empty, jobInfoBO.Stattlement))
            dbConnection.AddParamter("@status", OleDbType.Integer, 0)
            dbConnection.AddParamter("@userId", OleDbType.Integer, userId)
            dbConnection.AddParamter("@entryDate", OleDbType.Date, Date.Now.ToString("yyyy/MM/dd"))
            dbConnection.AddParamter("@errorReason", OleDbType.VarChar, If((String.IsNullOrEmpty(jobInfoBO.ErrorReason) Or jobInfoBO.ErrorReason.Length > 255), jobInfoBO.ErrorReason = String.Empty, jobInfoBO.ErrorReason))
            dbConnection.AddParamter("@attJobNo", OleDbType.Integer, AttJobNo)
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function ProcessJobInformationError(ByVal jobInfoBO As JobInfoErrorBO)
        Try

            Dim query As String = "INSERT INTO JobInfoError (VendorId,TransDate,JobNumber,Address,City,State,ZipCode,settlment,Status,UserId,EntryDate,ErrorReason,AttJobNo) VALUES ('" + jobInfoBO.VendorId + "','" + jobInfoBO.TransDate + "','" + jobInfoBO.JobNumber + "','" + jobInfoBO.Address + "','" + jobInfoBO.City + "','" + jobInfoBO.State + "','" + jobInfoBO.ZipCode + "','" + jobInfoBO.Stattlement + "',0," & userId & ",'" + Date.Now.ToString("yyyy/MM/dd") + "','" + jobInfoBO.ErrorReason + "'," & AttJobNo & ")"
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function

    Public Function Isexists(ByVal VendorId As Integer) As Boolean
        Dim isexist As Boolean = False
        Dim query As String = "SELECT * FROM Vendors WHERE VendorId=" & VendorId
       
        Try
            dbConnection.ConnectDatabase()
            Dim datatable As DataTable = dbConnection.ExecuteQuery(query)
            dbConnection.CloseDatabase()
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
    Public Function SucessJobInfo() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT VendorId AS [Vendor ID],TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment FROM JobInfo WHERE AttJobNo=" & AttjobNo

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

    Public Function SucessJobInfoByMultipleParm(ByVal whereby As String) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT VendorId AS [Vendor ID],TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment,JobInfo.EntryDate AS [Processing Date] FROM JobInfo " + whereby

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
    Public Function ErrorJobInfo() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,VendorId AS [Vendor Id],TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment,ErrorReason AS [Reason] FROM JobInfoError WHERE AttJobNo=" & AttjobNo

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
    Public Function ErrorJobInfobyMultipleParm(ByVal whereby As String) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,VendorId AS [Vendor Id],TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment,ErrorReason AS [Reason],EntryDate AS [Processing Date] FROM JobInfoError " + whereby

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
    Public Function GetAttJobNo() As Integer
        Dim orderId As Integer = 0
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT OrderId FROM OrderNumbers WHERE Type='Job'"
        Me.Upatenumber("Job")
        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)

            If datatable.Rows.Count > 0 Then
                orderId = datatable.Rows(0)(0).ToString()
                LoginInformationBO.AttJobNo = orderId
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return orderId
    End Function
    Public Function VendorJobInfo() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment] FROM JobInfo WHERE Status = 0 AND VendorId=" & userId

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
    Public Function VendorApprovedJobInfo(ByVal fromDate As Date, ByVal todate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment] FROM JobInfo WHERE Status = 1 AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' AND VendorId=" & userId

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
    Public Function VendorRejectedJobInfo(ByVal fromDate As Date, ByVal todate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.DisputeReason AS [Dispute Reason],JobInfo.RejectedReason AS [Disputing Notes] FROM JobInfo WHERE Status = 2 AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' AND VendorId=" & userId

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
    Public Function AcceptsJobInfo()
        Try

            Dim query As String = "UPDATE JobInfo SET Status=1,AcceptedNo=" & JobAcceptedNo & " WHERE JobInfo.Status = 0 AND VendorId=" & userId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function AcceptsOneJobInfo(ByVal RecId As Integer)
        Try

            Dim query As String = "UPDATE JobInfo SET Status=1,AcceptedNo=" & JobAcceptedNo & " WHERE JobInfo.Status = 0 AND VendorId=" & userId & " AND RecId=" & RecId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function RecejectJobInfo(ByVal RecId As Integer, ByVal Reason As String, ByVal DisputeReason As String)
        Try

            Dim query As String = "UPDATE JobInfo SET Status=2,RejectedReason='" + Reason + "',DisputeReason='" + DisputeReason + "' WHERE RecId=" & RecId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function RecejectAllVendorJobInfo(ByVal Reason As String, ByVal DisputeReason As String)
        Try

            Dim query As String = "UPDATE JobInfo SET Status=2,RejectedReason='" + Reason + "',DisputeReason='" + DisputeReason + "' WHERE JobInfo.Status = 0 AND JobInfo.VendorId=" & userId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function IsexistsJobNumber(ByVal JobNumber As Integer) As Boolean
        Dim isexist As Boolean = False
        Dim query As String = "SELECT * FROM JobInfo WHERE JobNumber=" & JobNumber

        Try
            dbConnection.ConnectDatabase()
            Dim datatable As DataTable = dbConnection.ExecuteQuery(query)
            dbConnection.CloseDatabase()
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
    Public Function GetCurrentAttJobNo() As Integer
        Return LoginInformationBO.AttJobNo
    End Function
    Public Function DeleteErrorJob(ByVal RecId As Integer)
        Try

            Dim query As String = "DELETE FROM JobInfoError WHERE RecId=" & RecId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
            dbConnection.CloseDatabase()
        Catch ex As Exception
            Throw
        End Try
        Return Nothing
    End Function
    Public Function GetJobAccetsNo() As Integer
        Dim orderId As Integer = 0
        Dim datatable As DataTable = New DataTable()
        Dim query As String = "SELECT OrderId FROM OrderNumbers WHERE Type='Acc'"
        Me.Upatenumber("Acc")
        Try
            dbConnection.ConnectDatabase()
            datatable = dbConnection.ExecuteQuery(query)

            If datatable.Rows.Count > 0 Then
                orderId = datatable.Rows(0)(0).ToString()
                LoginInformationBO.JobAcceptedNo = orderId
            End If

        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return orderId
    End Function
    Private Function Upatenumber(ByVal Type As String)
        Dim query As String = "UPDATE OrderNumbers SET OrderId=OrderId+1 WHERE Type='" + Type + "'"
        Dim dbconnection As DbConnection = New DbConnection()
        Try
            dbconnection.ConnectDatabase()
            dbconnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbconnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function GetCurrentJobAceptedNo() As Integer
        Return LoginInformationBO.JobAcceptedNo
    End Function
    Public Function VendorCurrentJobInfo() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment FROM JobInfo WHERE AcceptedNo=" & JobAcceptedNo

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
    Public Function VendorJobHistory(ByVal whereby As String) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT Vendors.VendorId AS [Vendor Id],Vendors.FirstName & ' '& Vendors.LastName AS [Vendor Name],JobInfo.TransDate AS [Trans Date],JobInfo.JobNumber AS [Job Number],JobInfo.Address AS [Address],JobInfo.City AS [City],JobInfo.State AS [State],JobInfo.ZipCode AS [Zip Code],settlment,iif(JobInfo.Status=0,'Offer',iif(JobInfo.Status=1,'Approved','Disputed')) AS [Job Status],JobInfo.DisputeReason AS [Dispute Reason],JobInfo.RejectedReason AS [Disputing Notes] FROM JobInfo,Vendors WHERE JobInfo.VendorId = Vendors.VendorId AND " + whereby + " ORDER BY TransDate ASC"

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
    Public Function GetVendorProfile(ByVal VendorId As Integer) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT Vendors.VendorId,Vendors.FirstName & ' ' & Vendors.LastName AS [VendorName],Vendors.Contracts AS [Contract]," +
                             "(SELECT COUNT(*) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 0) AS [Offer Job]," +
                                "(SELECT COUNT(*) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 1) AS [Accepted Job]," +
                                "(SELECT COUNT(*) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 2) AS [Declined Job]," +
                                "(SELECT SUM(settlment) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 0) AS [Offer Settlment]," +
                                "(SELECT SUM(settlment) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 1) AS [Accepted Settlment]," +
                                "(SELECT SUM(settlment) FROM JobInfo WHERE JobInfo.VendorId = Vendors.VendorId AND JobInfo.Status = 2) AS [Declined Settlment] FROM Vendors WHERE Vendors.VendorId =" & VendorId

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
    Public Function DisputedJobInfo(ByVal fromDate As Date, ByVal todate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.DisputeReason AS [Dispute Reason],JobInfo.RejectedReason AS [Disputing Notes] FROM JobInfo WHERE Status = 2 AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "'"

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
    Public Function ApprovedDisputedJob(ByVal notes As String, ByVal approvedReason As String, ByVal RecId As Integer)
        Try
            Dim query As String = "UPDATE JobInfo SET Status=1,RejectedReason='" + String.Empty + "',DisputeReason='" + String.Empty + "',ApprovedReason='" + approvedReason + "',ApprovedNote='" + notes + "' WHERE JobInfo.RecId=" & RecId
            dbConnection.ConnectDatabase()
            dbConnection.ExecuteNonQuery(query)
        Catch ex As Exception
            Throw ex
        Finally
            dbConnection.CloseDatabase()
        End Try
        Return Nothing
    End Function
    Public Function ApprovedDisputedJobInfo(ByVal fromDate As Date, ByVal todate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.ApprovedReason AS [Approved Reason],JobInfo.ApprovedNote AS [Approved Note] FROM JobInfo WHERE Status = 1 AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "' AND ApprovedReason <> '' AND ApprovedReason <> Null"

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
    Public Function ApprovedDisputedJobInfo() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.ApprovedReason AS [Approved Reason],JobInfo.ApprovedNote AS [Approved Note] FROM JobInfo WHERE Status = 1 AND ApprovedReason <> '' AND ApprovedReason <> Null"

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
    Public Function GetVendorDisputedJob(ByVal fromDate As Date, ByVal todate As Date) As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.DisputeReason AS [Dispute Reason],JobInfo.RejectedReason AS [Disputing Notes] FROM JobInfo WHERE Status = 2 AND FORMAT(JobInfo.TransDate,'yyyy/mm/dd') BETWEEN '" + fromDate.ToString("yyyy/MM/dd") + "' AND '" + todate.ToString("yyyy/MM/dd") + "'"

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
    Public Function GetVendorDisputedJob() As DataTable
        Dim data As DataTable
        Dim query As String = "SELECT RecId,TransDate AS [Trans Date],JobNumber AS [Job Number],Address,City,State,ZipCode AS [Zip Code],settlment AS [Settlment],JobInfo.DisputeReason AS [Dispute Reason],JobInfo.RejectedReason AS [Disputing Notes] FROM JobInfo WHERE Status = 2"

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
