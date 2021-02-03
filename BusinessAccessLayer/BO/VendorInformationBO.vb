Public Class VendorInformationBO
    Inherits PersonalInformation

    Private _customerId As Integer = 0
    Property CustomerId As Integer
        Get
            Return _customerId
        End Get
        Set(ByVal value As Integer)
            _customerId = value
        End Set
    End Property


End Class
