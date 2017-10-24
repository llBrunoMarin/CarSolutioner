Public Class ReservaSeleccionada

    Dim _IdReserva As Integer
    Dim _IdCliente As Integer
    Dim _Matricula As String
    Dim _NroChasis As String
    Dim _NomCliente As String
    Dim _FechaReservaInicio As Date
    Dim _FechaReservaFin As Date
    Dim _FechaAlquilerInicio As Date
    Dim _FechaTramite As Date
    Dim _IdCategoria As Integer
    Dim _IdNuevaCategoria As Integer
    Dim _IdTipo As Integer
    Dim _IdSucursalPartida As Integer
    Dim _IdSucursalDestino As Integer
    Dim _UsuarioEmpleado As String
    Dim _IdCantKM As Integer
    Dim _CostoTotal As Integer
    Dim _DescuentoCliente As Integer
    Dim _AutosDisponibles As DataTable
    Dim _DeducibleVehiculo As Integer
    Dim _DiasReservados As DateInterval

    Public Property IdReserva As Integer
        Get
            Return _IdReserva
        End Get
        Set(value As Integer)
            _IdReserva = value
        End Set
    End Property

    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

    Public Property NomCliente As String
        Get
            Return _NomCliente
        End Get
        Set(value As String)
            _NomCliente = value
        End Set
    End Property

    Public Property FechaReservaInicio As Date
        Get
            Return _FechaReservaInicio
        End Get
        Set(value As Date)
            _FechaReservaInicio = value
        End Set
    End Property

    Public Property FechaReservaFin As Date
        Get
            Return _FechaReservaFin
        End Get
        Set(value As Date)
            _FechaReservaFin = value
        End Set
    End Property

    Public Property FechaTramite As Date
        Get
            Return _FechaTramite
        End Get
        Set(value As Date)
            _FechaTramite = value
        End Set
    End Property

    Public Property IdCategoria As Integer
        Get
            Return _IdCategoria
        End Get
        Set(value As Integer)
            _IdCategoria = value
        End Set
    End Property

    Public Property IdTipo As Integer
        Get
            Return _IdTipo
        End Get
        Set(value As Integer)
            _IdTipo = value
        End Set
    End Property

    Public Property IdSucursalPartida As Integer
        Get
            Return _IdSucursalPartida
        End Get
        Set(value As Integer)
            _IdSucursalPartida = value
        End Set
    End Property

    Public Property IdSucursalDestino As Integer
        Get
            Return _IdSucursalDestino
        End Get
        Set(value As Integer)
            _IdSucursalDestino = value
        End Set
    End Property

    Public Property UsuarioEmpleado As String
        Get
            Return _UsuarioEmpleado
        End Get
        Set(value As String)
            _UsuarioEmpleado = value
        End Set
    End Property

    Public Property IdCantKM As Integer
        Get
            Return _IdCantKM
        End Get
        Set(value As Integer)
            _IdCantKM = value
        End Set
    End Property

    Public Property CostoTotal As Integer
        Get
            Return _CostoTotal
        End Get
        Set(value As Integer)
            _CostoTotal = value
        End Set
    End Property

    Public Property DiasReservados As DateInterval
        Get
            Return _DiasReservados
        End Get
        Set()
            _DiasReservados = (Me.FechaReservaFin - Me.FechaReservaInicio).Days
        End Set
    End Property

    Public Property DescuentoCliente As Integer
        Get
            Return _DescuentoCliente
        End Get
        Set(value As Integer)
            _DescuentoCliente = value
        End Set
    End Property

    Public Property FechaAlquilerInicio As Date
        Get
            Return _FechaAlquilerInicio
        End Get
        Set(value As Date)
            _FechaAlquilerInicio = value
        End Set
    End Property

    Public Property Matricula As String
        Get
            Return _Matricula
        End Get
        Set(value As String)
            _Matricula = value
        End Set
    End Property

    Public Property NroChasis As String
        Get
            Return _NroChasis
        End Get
        Set(value As String)
            _NroChasis = value
        End Set
    End Property

    Public Property AutosDisponibles As DataTable
        Get
            Return _AutosDisponibles
        End Get
        Set(value As DataTable)
            _AutosDisponibles = value
        End Set
    End Property

    Public Property IdNuevaCategoria As Integer
        Get
            Return _IdNuevaCategoria
        End Get
        Set(value As Integer)
            _IdNuevaCategoria = value
        End Set
    End Property

    Public Property DeducibleVehiculo As Integer
        Get
            Return _DeducibleVehiculo
        End Get
        Set(value As Integer)
            _DeducibleVehiculo = value
        End Set
    End Property
End Class
