Public Class PersonalInformation
    Private _firstName As String = "Empty"
    Property FirstName As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property


    Private _lastName As String = "Empty"
    Property LastName As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property
    Private _vendorName As String = "Empty"
    Property VendorName As String
        Get
            Return _vendorName
        End Get
        Set(ByVal value As String)
            _vendorName = value
        End Set
    End Property
    Private _companyName As String = "Empty"
    Property CompanyName As String
        Get
            Return _companyName
        End Get
        Set(ByVal value As String)
            _companyName = value
        End Set
    End Property
    Private _activeDate As Date
    Property ActiveDate As Date
        Get
            Return _activeDate
        End Get
        Set(ByVal value As Date)
            _activeDate = value
        End Set
    End Property

    Private _contactNumber As String = "Empty"
    Property ContactNumber As String
        Get
            Return _contactNumber
        End Get
        Set(ByVal value As String)
            _contactNumber = value
        End Set
    End Property
    Private _houseNo As String = "Empty"
    Property HouseNo As String
        Get
            Return _houseNo
        End Get
        Set(ByVal value As String)
            _houseNo = value
        End Set
    End Property

    Private _street As String = "Empty"
    Property Street As String
        Get
            Return _street
        End Get
        Set(ByVal value As String)
            _street = value
        End Set
    End Property

    Private _city As String = "Empty"
    Property City As String
        Get
            Return _city
        End Get
        Set(ByVal value As String)
            _city = value
        End Set
    End Property

    Private _district As String = "Empty"
    Property District As String
        Get
            Return _district
        End Get
        Set(ByVal value As String)
            _district = value
        End Set
    End Property

    Private _state As String = "Empty"
    Property State As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property

    Private _email As String = "Empty"
    Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _zipCode As String = "Empty"
    Property ZipCode As String
        Get
            Return _zipCode
        End Get
        Set(ByVal value As String)
            _zipCode = value
        End Set
    End Property

    Private _gender As String = "Empty"
    Property Gender As String
        Get
            Return _gender
        End Get
        Set(ByVal value As String)
            _gender = value
        End Set
    End Property

    Private _DOB As Date
    Property DOB As Date
        Get
            Return _DOB
        End Get
        Set(ByVal value As Date)
            _DOB = value
        End Set
    End Property

    Private _homePhone As String = "Empty"
    Property HomePhone As String
        Get
            Return _homePhone
        End Get
        Set(ByVal value As String)
            _homePhone = value
        End Set
    End Property

    Private _businessPhone As String = "Empty"
    Property BusinessPhone As String
        Get
            Return _businessPhone
        End Get
        Set(ByVal value As String)
            _businessPhone = value
        End Set
    End Property

    Private _cellPhone As String = "Empty"
    Property CellPhone As String
        Get
            Return _cellPhone
        End Get
        Set(ByVal value As String)
            _cellPhone = value
        End Set
    End Property

    Private _address As String = "Empty"
    Property Address As String
        Get
            Return _address
        End Get
        Set(ByVal value As String)
            _address = value
        End Set
    End Property

    Private _contracts As Integer = 0
    Property Contracts As Integer
        Get
            Return _contracts
        End Get
        Set(ByVal value As Integer)
            _contracts = value
        End Set
    End Property

    Private _pinNumber As String = "Empty"
    Property PinNumber As String
        Get
            Return _pinNumber
        End Get
        Set(ByVal value As String)
            _pinNumber = value
        End Set
    End Property

    Private _notes As String = "Empty"
    Property Notes As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property
    Private _accountStatus As Boolean
    Property AccountStatus As Boolean
        Get
            Return _accountStatus
        End Get
        Set(ByVal value As Boolean)
            _accountStatus = value
        End Set
    End Property

End Class
