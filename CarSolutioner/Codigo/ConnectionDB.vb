Public Class ConnectionBD

    Dim cx As New Odbc.OdbcConnection
    Dim cm As New Odbc.OdbcCommand
    Dim da As New Odbc.OdbcDataAdapter
    Dim ds As New Data.DataSet
    Dim dr As Odbc.OdbcDataReader
    Dim timer As New Timer


    Dim _Usuario As String = Nothing
    Dim _Contraseña As String = Nothing
    Dim _TipoUsuario As String = Nothing
    Dim _ConnectionStatus As String = Nothing


    Dim _Marcas As DataTable
    Dim _Modelos As DataTable
    Dim _Categorias As DataTable
    Dim _Tipos As DataTable
    Dim _Sucursales As DataTable
    Dim _Documentos As DataTable
    Dim _Kilometros As New DataTable
    Dim _TipoEmpleados As New DataTable

    Dim _Años As New List(Of String)

    'El constructor de la clase. El código de aquí se ejecutará cada vez que se cree una instancia de esta clase. Es como el "load" pero de la clase, no es de ningun formulario.
    Public Sub New()
        Dim añosaux As Integer = 1900
        While añosaux <= CInt(DateTime.Today.Year)
            Años.Add(añosaux.ToString)
            añosaux = añosaux + 1
        End While

        timer.Interval = 10000

        TipoEmpleados.Columns.Add("id", GetType(Integer))
        TipoEmpleados.Columns.Add("tipos", GetType(String))
        TipoEmpleados.Rows.Add(1, "Director General")
        TipoEmpleados.Rows.Add(2, "Gerente")
        TipoEmpleados.Rows.Add(3, "Jefe de Personal")
        TipoEmpleados.Rows.Add(4, "Empleado")

        Kilometros.Columns.Add("id", GetType(Integer))
        Kilometros.Columns.Add("km", GetType(String))
        Kilometros.Rows.Add(1, "150 KM por día")
        Kilometros.Rows.Add(2, "300 KM por día")
        Kilometros.Rows.Add(3, "KM Libres por día")

    End Sub

    Public Property Usuario() As String
        Get
            Return _Usuario
        End Get
        Set(ByVal value As String)
            _Usuario = value
        End Set
    End Property
    Public Property Contraseña() As String
        Get
            Return _Contraseña
        End Get
        Set(ByVal value As String)
            _Contraseña = value
        End Set
    End Property
    Public Property TipoUsuario As String
        Get
            Return _TipoUsuario
        End Get
        Set(value As String)
            _TipoUsuario = value
        End Set
    End Property
    Public Property ConnectionStatus As String
        Get
            Return _ConnectionStatus
        End Get
        Set(value As String)
            _ConnectionStatus = value
        End Set
    End Property
    Public Property Modelos() As DataTable
        Get
            Return _Modelos
        End Get
        Set(value As DataTable)
            _Modelos = value
        End Set
    End Property
    Public Property Marcas() As DataTable
        Get
            Return _Marcas
        End Get
        Set(value As DataTable)
            _Marcas = value
        End Set
    End Property
    Public Property Categorias() As DataTable
        Get
            Return _Categorias
        End Get
        Set(ByVal value As DataTable)
            _Categorias = value
        End Set
    End Property
    Public Property Tipos() As DataTable
        Get
            Return _Tipos
        End Get
        Set(ByVal value As DataTable)
            _Tipos = value
        End Set
    End Property
    Public Property Sucursales() As DataTable
        Get
            Return _Sucursales
        End Get
        Set(value As DataTable)
            _Sucursales = value
        End Set
    End Property
    Public Property Documentos As DataTable
        Get
            Return _Documentos
        End Get
        Set(value As DataTable)
            _Documentos = value
        End Set
    End Property
    Public Property Años As List(Of String)
        Get
            Return _Años
        End Get
        Set(value As List(Of String))
            _Años = value
        End Set
    End Property

    Public Property TipoEmpleados As DataTable
        Get
            Return _TipoEmpleados
        End Get
        Set(value As DataTable)
            _TipoEmpleados = value
        End Set
    End Property

    Public Property Kilometros As DataTable
        Get
            Return _Kilometros
        End Get
        Set(value As DataTable)
            _Kilometros = value
        End Set
    End Property



    'TODO: Programar excepciones de tal manera que muestre mensaje correspondiente
    'segun cual sea el error (error de conexión, error de primary key, etc)


    'Abrir y cerrar la conexión con la BD. La idea es abrirla antes de ejecutar una sentencia, y cerrarla al finalizar.
    Public Sub Conectar(Usuario, Contraseña)

        Try

            If cx.State = ConnectionState.Closed Then
                cx.ConnectionTimeout = 2

                'SERVIDOR UTU
                'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=10.0.29.6;SERVER=ol_informix1;SERVICE=1526;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"


                'SERVIDOR VICTOR
                cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"


                'SERVIDOR VICTOR 32 BITS
                cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

                'Servidor victor 64 bits EN UTU (probar si anda)
                'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;proxy_host=10.0.29.5;proxy_port=80;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

                cx.Open()

                Me.ConnectionStatus = "Opened"

            End If

        Catch ex As Odbc.OdbcException

            If (ex.Message.Contains("[HY000] [Informix][Informix ODBC Driver]") Or ex.Message.Contains("[28000] [Informix][Informix ODBC Driver]")) Then

                Me.ConnectionStatus = "BadCredentials"


                Cerrar()

            Else

                ' MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
                'TODO: Quitar este MsgBox, está por motivos de solucion de errores:


                Me.ConnectionStatus = "NetworkFailure"
                If Not Application.OpenForms().OfType(Of Reconectar).Any Then
                    Reconectar.ShowDialog()
                End If
            End If



            'MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
            ' MsgBox(ex.Message)


        End Try

    End Sub

    Public Function Cerrar() As Boolean
        Try
            cx.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)

            Throw ex
            Return False
        End Try

    End Function

    Public Function EjecutarSelect(sentencia As String) As DataTable
        Dim dt As New DataTable


        Conectar(Me.Usuario, Me.Contraseña)
        Try

            cm.Connection = cx
            cm.CommandText = sentencia

            'Le carga a la tabla el resultado de ejecutar el comando.
            dt.Load(cm.ExecuteReader())

            'Devuelve la tabla
            Return dt

        Catch ex As Exception

            MsgBox(ex.Message)

            Return dt

        Finally

            Cerrar()

        End Try
    End Function

    'Rellena un datagridview que se le coloca como parámetro, con el nombre de la tabla que también
    'entra como tal.
    Public Sub RellenarDataGridView(dgv As DataGridView, sentencia As String, Optional Tabla As DataTable = Nothing)
        Conectar(Usuario, Contraseña)
        'Creamos una nueva fuente de datos, para poder asignarla al DataGridView luego.
        Dim fuente As New BindingSource()

        Try
            If Tabla Is Nothing Then
                fuente.DataSource = EjecutarSelect(sentencia).DefaultView
            Else
                fuente.DataSource = Tabla
            End If

            dgv.DataSource = fuente

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            'Propiedades que queremos por defecto en casi todos los DataGridView.
            'dgv.ReadOnly = True
            'dgv.RowHeadersVisible = False
            'dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            'dgv.AllowUserToAddRows = False
            'dgv.AllowUserToDeleteRows = False
            'dgv.AllowUserToResizeColumns = False
            'dgv.AllowUserToResizeRows = False
            'dgv.MultiSelect = False

            For Each column As DataGridViewColumn In dgv.Columns

                Dim palabra() As Char = column.HeaderText.ToCharArray
                palabra(0) = Char.ToUpper(palabra(0))
                column.HeaderText = palabra

            Next


        End Try

    End Sub
    Private Declare Function GetTickCount Lib "kernel32" () As Integer


    'Ejecuta una sentencia de tipo "NonQuery", es decir, que no "devuelve" "nada" (ejemplo INSERT, UPDATE, etc).
    'En realidad, devuelve el nro de filas afectadas; o un -1.
    Public Function EjecutarNonQuery(sentencia As String, Optional frase As String = Nothing) As Boolean

        Dim nrofilas As New Integer()
        Conectar(Usuario, Contraseña)

        Try

            cm.Connection = cx
            cm.CommandText = sentencia
            nrofilas = cm.ExecuteNonQuery()

            If nrofilas = 0 Then
                If frase = Nothing Then
                    MsgBox("No se realizaron cambios.", MsgBoxStyle.Information, "Advertencia")
                Else
                    MsgBox("No se realizaron cambios, en: " + frase, MsgBoxStyle.Information, "Advertencia")

                End If
                Return False

            Else

                Return True
            End If


        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        Finally

            Cerrar()

        End Try

    End Function


End Class
