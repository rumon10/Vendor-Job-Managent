Public Class UserInformationmBO
    Private _Username As String = "Empty"
    Property UserName As String
        Get
            Return _Username
        End Get
        Set(ByVal value As String)
            _Username = value
        End Set
    End Property

    Private _fullname As String = "Empty"
    Property FullName As String
        Get
            Return _fullname
        End Get
        Set(ByVal value As String)
            _fullname = value
        End Set
    End Property

    Private _password As String = "Empty"
    Property Password As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _createnewOrder As Boolean = True

    Property CreateNewOrder As Boolean
        Get
            Return _createnewOrder
        End Get
        Set(ByVal value As Boolean)
            _createnewOrder = value
        End Set
    End Property

    Private _patientMaintanence As Boolean = True

    Property PatientMaintaince As Boolean
        Get
            Return _patientMaintanence
        End Get
        Set(ByVal value As Boolean)
            _patientMaintanence = value
        End Set
    End Property

    Private _inventoryMaintence As Boolean = True

    Property InventoryMaintence As Boolean
        Get
            Return _inventoryMaintence
        End Get
        Set(ByVal value As Boolean)
            _inventoryMaintence = value
        End Set
    End Property

    Private _orderLookup As Boolean = True

    Property OrderLookup As Boolean
        Get
            Return _orderLookup
        End Get
        Set(ByVal value As Boolean)
            _orderLookup = value
        End Set
    End Property

    Private _userCreation As Boolean = True

    Property UserCreation As Boolean
        Get
            Return _userCreation
        End Get
        Set(ByVal value As Boolean)
            _userCreation = value
        End Set
    End Property

    Private _OrderStatusUpdate As Boolean = True

    Property OrderStatusUpdate As Boolean
        Get
            Return _OrderStatusUpdate
        End Get
        Set(ByVal value As Boolean)
            _OrderStatusUpdate = value
        End Set
    End Property
    Private _deletedOrder As Boolean = True
    Property DeleteOrder As Boolean
        Get
            Return _deletedOrder
        End Get
        Set(ByVal value As Boolean)
            _deletedOrder = value
        End Set
    End Property
End Class
