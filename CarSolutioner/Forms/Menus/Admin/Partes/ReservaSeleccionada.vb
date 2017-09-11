Imports CarSolutioner

Public Class ReservaSeleccionada

    Public Sub New(cx As ConnectionBD)
        Conexion = cx
    End Sub

    Dim _conexion As ConnectionBD

    Dim _Categoria As String
    Dim _NomCliente As String
    Dim _ApeCliente As String
    Dim _Tipo As String
    Dim _SucursalInicio As String
    Dim _SucursalDestino As String
    Dim _FechaInicio As Date
    Dim _FechaFin As Date
    Dim _CantKM As String
    Dim _FechaTramite As Date
    Dim _CostoTotal As Integer
    Dim _Empleado As String
    Dim _idpersonaI As Integer
    Dim _diasalquilados As Integer

    Dim _IdReserva As Integer
    Dim _IdCategoria As Integer
    Dim _IdTipo As Integer
    Dim _IdCliente As Integer

    Public Property Conexion As ConnectionBD
        Get
            Return _conexion
        End Get
        Set(value As ConnectionBD)
            _conexion = value
        End Set
    End Property

    Public Property Categoria() As String
        Get
            Return _Categoria
        End Get
        Set(ByVal value As String)

            _Categoria = value
            IdCategoria = Conexion.Categorias.Select("nombre = '" + value + "'").CopyToDataTable.Rows(0)(0)

        End Set
    End Property
    Public Property NomCliente() As String
        Get
            Return _NomCliente
        End Get
        Set(ByVal value As String)
            _NomCliente = value
        End Set
    End Property
    Public Property ApeCliente() As String
        Get
            Return _ApeCliente
        End Get
        Set(ByVal value As String)
            _ApeCliente = value
        End Set
    End Property
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            IdTipo = Conexion.Tipos.Select("nombre = '" + value + "'").CopyToDataTable.Rows(0)(0)
            _Tipo = value
        End Set
    End Property
    Public Property SucursalInicio As String
        Get
            Return _SucursalInicio
        End Get
        Set(value As String)
            _SucursalInicio = value
        End Set
    End Property
    Public Property SucursalDestino As String
        Get
            Return _SucursalDestino
        End Get
        Set(value As String)
            _SucursalDestino = value
        End Set
    End Property
    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaFin As Date
        Get
            Return _FechaFin
        End Get
        Set(value As Date)
            _FechaFin = value
        End Set
    End Property
    Public Property CantKM As String
        Get
            Return _CantKM
        End Get
        Set(value As String)
            _CantKM = value
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
    Public Property CostoTotal As Integer
        Get
            Return _CostoTotal
        End Get
        Set(value As Integer)
            _CostoTotal = value
        End Set
    End Property
    Public Property Empleado As String
        Get
            Return _Empleado
        End Get
        Set(value As String)
            _Empleado = value
        End Set
    End Property
    Public Property IdpersonaI As Integer
        Get
            Return _idpersonaI
        End Get
        Set(value As Integer)
            _idpersonaI = value
        End Set
    End Property
    Public Property Diasalquilados As Integer
        Get
            Return _diasalquilados
        End Get
        Set(value As Integer)
            _diasalquilados = value
        End Set
    End Property

    Public Property IdReserva As Integer
        Get
            Return _IdReserva
        End Get
        Set(value As Integer)
            _IdReserva = value
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
    Public Property IdCliente As Integer
        Get
            Return _IdCliente
        End Get
        Set(value As Integer)
            _IdCliente = value
        End Set
    End Property

End Class
