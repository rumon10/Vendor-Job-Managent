Public Class AcknowledgementBO
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

    Private _stattlement As Decimal
    Property Stattlement As Decimal
        Get
            Return _stattlement
        End Get
        Set(ByVal value As Decimal)
            _stattlement = value
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
    Private _comments As String
    Property Comments As String
        Get
            Return _comments
        End Get
        Set(ByVal value As String)
            _comments = value
        End Set
    End Property

End Class
