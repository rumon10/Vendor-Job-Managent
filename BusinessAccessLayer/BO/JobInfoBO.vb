Public Class JobInfoBO
    Inherits PersonalInformation

    Private _transDate As Date
    Property TransDate As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _jobNumber As Integer
    Property JobNumber As Integer
        Get
            Return _jobNumber
        End Get
        Set(ByVal value As Integer)
            _jobNumber = value
        End Set
    End Property

    Private _stattlement As Decimal
    Property Stattlement As Decimal
        Get
            Return _stattlement
        End Get
        Set(ByVal value As Decimal)
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

    Private _vendorId As Integer
    Property VendorId As Integer
        Get
            Return _vendorId
        End Get
        Set(ByVal value As Integer)
            _vendorId = value
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
