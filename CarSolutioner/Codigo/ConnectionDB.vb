Public Class ConnectionBD

    Dim cx As New Odbc.OdbcConnection
    Dim cm As New Odbc.OdbcCommand
    Dim da As New Odbc.OdbcDataAdapter
    Dim ds As New Data.DataSet
    Dim dr As Odbc.OdbcDataReader


    Dim _Usuario As String = Nothing
    Dim _Contraseña As String = Nothing

    Dim _Marcas As DataTable
    Dim _Modelos As DataTable
    Dim _Categorias As DataTable
    Dim _Tipos As DataTable
    Dim _Sucursales As DataTable


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


    'TODO: Programar excepciones de tal manera que muestre mensaje correspondiente
    'segun cual sea el error (error de conexión, error de primary key, etc)

    'Abrir y cerrar la conexión con la BD. La idea es abrirla antes de ejecutar una sentencia, y cerrarla al finalizar.
    Public Function Conectar(Usuario, Contraseña) As Boolean
        Try
            'SERVIDOR UTU
            'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=10.0.29.6;SERVER=ol_informix1;SERVICE=1526;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

            'SERVIDOR VICTOR
            cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

            'SERVIDOR VICTOR 32 BITS
            'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

            cx.Open()
            Return True

        Catch ex As Odbc.OdbcException

            If (ex.Message.Contains("[HY000] [Informix][Informix ODBC Driver]") Or ex.Message.Contains("[28000] [Informix][Informix ODBC Driver]")) Then

                MsgBox("Usuario y/o Contraseña incorrectos.", MsgBoxStyle.Information, "Datos Incorrectos")

            Else

                MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
                'TODO: Quitar este MsgBox, está por motivos de solucion de errores:
                MsgBox(ex.Message)
            End If

            Return False

        Catch ex As Exception

            MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")

            Return False

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

        'Creamos una nueva fuente de datos, para poder asignarla al DataGridView luego.
        Dim fuente As New BindingSource()

        Try

            fuente.DataSource = EjecutarSelect(sentencia).DefaultView
            dgv.DataSource = fuente

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            'Propiedades que queremos por defecto en todos los DataGridView.
            dgv.ReadOnly = True
            dgv.RowHeadersVisible = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.AllowUserToResizeColumns = False
            dgv.AllowUserToResizeRows = False
            dgv.MultiSelect = False

            Select Case dgv.Name

                Case "dgvClientes"
                    dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

                Case "dgvVehiculos"
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    'dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    '
                    'dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            End Select

            For Each column As DataGridViewColumn In dgv.Columns

                Dim palabra() As Char = column.HeaderText.ToCharArray
                palabra(0) = Char.ToUpper(palabra(0))
                column.HeaderText = palabra

            Next


        End Try

    End Sub


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

            MsgBox(ex.Message)
            Return False

        Finally

            Cerrar()

        End Try

    End Function

    Public Sub Rellenaconmemoriaw(dgv As DataGridView, sentencia As String)

        'Creamos una nueva fuente de datos, para poder asignarla al DataGridView luego.
        Dim fuente As New BindingSource()

        Try

            fuente.DataSource = EjecutarSelect(sentencia).DefaultView
            dgv.DataSource = fuente

        Catch ex As Exception

            MsgBox(ex.Message)

        Finally

            'Propiedades que queremos por defecto en todos los DataGridView.
            dgv.ReadOnly = True
            dgv.RowHeadersVisible = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.AllowUserToResizeColumns = False
            dgv.AllowUserToResizeRows = False
            dgv.MultiSelect = False

            Select Case dgv.Name

                Case "dgvClientes"
                    dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

                Case "dgvVehiculos"
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
                    'dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    'dgv.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                    'dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    '
                    'dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
                    'dgv.Columns(13).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            End Select

            For Each column As DataGridViewColumn In dgv.Columns

                Dim palabra() As Char = column.HeaderText.ToCharArray
                palabra(0) = Char.ToUpper(palabra(0))
                column.HeaderText = palabra

            Next


        End Try

    End Sub

End Class
