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

    Dim _Marcas As DataTable
    Dim _Modelos As DataTable
    Dim _Categorias As DataTable
    Dim _Tipos As DataTable
    Dim _Sucursales As DataTable
    Dim _Documentos As DataTable

    Dim _Años As New List(Of String)

    'El constructor de la clase. El código de aquí se ejecutará cada vez que se cree una instancia de esta clase. Es como el "load" pero de la clase, no es de ningun formulario.
    Public Sub New()
        Dim añosaux As Integer = 1900
        While añosaux <= CInt(DateTime.Today.Year)
            Años.Add(añosaux.ToString)
            añosaux = añosaux + 1
        End While

        timer.Interval = 10000
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






    'TODO: Programar excepciones de tal manera que muestre mensaje correspondiente
    'segun cual sea el error (error de conexión, error de primary key, etc)


    'Abrir y cerrar la conexión con la BD. La idea es abrirla antes de ejecutar una sentencia, y cerrarla al finalizar.
    Public Function Conectar(Usuario, Contraseña) As String

        Try
            If cx.State = ConnectionState.Closed Then



                'SERVIDOR UTU
                'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=10.0.29.6;SERVER=ol_informix1;SERVICE=1526;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"


                'SERVIDOR VICTOR
                ' cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

                'SERVIDOR VICTOR 32 BITS
                cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

                cx.Open()

                Return "Verdadero"
            End If
        Catch ex As Odbc.OdbcException

            If (ex.Message.Contains("[HY000] [Informix][Informix ODBC Driver]") Or ex.Message.Contains("[28000] [Informix][Informix ODBC Driver]")) Then


                Return "BadCredentials"
                Cerrar()

            Else

                ' MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
                'TODO: Quitar este MsgBox, está por motivos de solucion de errores:
                '  MsgBox(ex.Message)

                reintentarconexionlogin()
                Cerrar()
                Return "Red"
            End If




            'MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
            ' MsgBox(ex.Message)


        End Try

    End Function

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
    Public Sub RellenarDataGridView(dgv As DataGridView, sentencia As String)
        Conectar(Usuario, Contraseña)
        'Creamos una nueva fuente de datos, para poder asignarla al DataGridView luego.
        Dim fuente As New BindingSource()

        Try

            fuente.DataSource = EjecutarSelect(sentencia).DefaultView
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

    Function reintentarconexionlogin()

        Dim valor As MsgBoxResult = MsgBox("Conexion perdida, desea intentar reconectar?", MsgBoxStyle.OkOnly, "Error de red")
        Dim retraso As Integer

        retraso = 3000 + GetTickCount

        Dim resultado As MsgBoxResult = MsgBox("Intentando Reconectar", MsgBoxStyle.OkOnly, "Notificacion")

        While retraso >= GetTickCount
            Application.DoEvents()

        End While
        If valor = MsgBoxResult.Ok Then


            If Conectar(Usuario, Contraseña) = "Verdadero" Then


                Cerrar()
                MsgBox("Conexion establecida", MsgBoxStyle.Information, "Notificacion")
            Else
                MsgBox("No se pudo reanudar la conexion", MsgBoxStyle.Critical, "Notificacion")
            End If

        End If



    End Function
    'Ejecuta una sentencia de tipo "NonQuery", es decir, que no "devuelve" "nada" (ejemplo INSERT, UPDATE, etc).
    'En realidad, devuelve el nro de filas afectadas; o un -1.
    Public Function EjecutarNonQuery(sentencia As String) As Boolean

        Dim nrofilas As New Integer()
        Conectar(Usuario, Contraseña)

        Try

            cm.Connection = cx
            cm.CommandText = sentencia
            nrofilas = cm.ExecuteNonQuery()

            If nrofilas = 0 Then
                MsgBox("No se realizaron cambios.", MsgBoxStyle.Information, "Advertencia")
                Return False

            Else
                Return True
            End If


        Catch ex As Exception


            Return False

        Finally

            Cerrar()

        End Try

    End Function


End Class
