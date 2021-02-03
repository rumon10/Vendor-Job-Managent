Public Class JobInfoErrorBO
    Inherits PersonalInformation

    Private _vendorId As String
    Property VendorId As String
        Get
            Return _vendorId
        End Get
        Set(ByVal value As String)
            _vendorId = value
        End Set
    End Property

    Private _transDate As String
    Property TransDate As String
        Get
            Return _transDate
        End Get
        Set(ByVal value As String)
            _transDate = value
        End Set
    End Property

    Private _jobNumber As String
    Property JobNumber As String
        Get
            Return _jobNumber
        End Get
        Set(ByVal value As String)
            _jobNumber = value
        End Set
    End Property

    Private _stattlement As String
    Property Stattlement As String
        Get
            Return _stattlement
        End Get
        Set(ByVal value As String)
            _stattlement = value
        End Set
    End Property

    Private _errorReason As String
    Property ErrorReason As String
        Get
            Return _errorReason
        End Get
        Set(ByVal value As String)
            _errorReason = value
        End Set
    End Property

    Private _jobAttNo As Integer
    Property JobAttNo As Integer
        Get
            Return _jobAttNo
        End Get
        Set(ByVal value As Integer)
            _jobAttNo = value
        End Set
    End Property
End Class
