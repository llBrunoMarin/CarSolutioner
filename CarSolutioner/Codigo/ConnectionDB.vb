Public Class ConnectionBD

    Dim cx As New Odbc.OdbcConnection
    Dim cm As New Odbc.OdbcCommand
    Dim da As New Odbc.OdbcDataAdapter
    Dim ds As New Data.DataSet
    Dim dr As Odbc.OdbcDataReader

    Dim _Usuario As String = Nothing
    Dim _Contraseña As String = Nothing

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

    'Public Function ejecutarSelect(sentencia As String) As SelectReturn




    'End Function

    'TODO: TryCatchs correspondientes, y crear + métodos.
    'TODO: Programar excepciones de tal manera que muestre mensaje correspondiente
    'segun cual sea el error (error de conexión, error de primary key, etc)

    'Abrir y cerrar la conexión con la BD. La idea es abrirla antes de ejecutar una sentencia, y cerrarla al finalizar.

    'TODO Cambiar pendorcho
    Public Function EjecutarSelect(sentencia As String) As DataTable
        Dim dt As New DataTable


        conectar(Me.Usuario, Me.Contraseña)
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

            cerrar()

        End Try
    End Function

    Public Function conectar(Usuario, Contraseña) As Boolean
        Try
            'SERVIDOR UTU
            cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=10.0.29.6;SERVER=ol_informix1;SERVICE=1526;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"

            'SERVIDOR VICTOR
            'cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranthsolutions;HOST=vdo.dyndns.org;SERVER=proyectoUTU;SERVICE=9088;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"
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

    Public Function cerrar() As Boolean
        Try
            cx.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Throw ex
            Return False
        End Try

    End Function



    'Ejecuta una sentencia de tipo "NonQuery", es decir, que no "devuelve" "nada" (ejemplo INSERT, UPDATE, etc).
    'En realidad, devuelve el nro de filas afectadas; o un -1.
    Public Function EjecutarNonQuery(sentencia As String) As Boolean
        Dim nrofilas As Integer
        conectar(Usuario, Contraseña)

        Try

            cm.Connection = cx
            cm.CommandText = sentencia
            nrofilas = cm.ExecuteNonQuery()

            If Not nrofilas = 0 Then
                Return True

            Else
                Return False
            End If


        Catch ex As Exception

            MsgBox(ex.Message)
            Return False

        Finally

            cerrar()

        End Try

    End Function

    'Rellena un datagridview que se le coloca como parámetro, con el nombre de la tabla que también
    'entra como tal.

    Function RellenarDataGridView(dgv As DataGridView, sentencia As String)

        'Tenemos que crear el "DataTable" acá, para que cree una nueva instancia cada vez.
        'De lo contrario, el datagridview tendría el contenido de muchas tablas a la vez.



        Try

            dgv.DataSource = EjecutarSelect(sentencia)
            Return True

        Catch ex As Exception

            MsgBox(ex.Message)

            Return False

        Finally

            'Propiedades que queremos por defecto en todos los DataGridView.
            dgv.Rows(0).Selected = False
            dgv.ReadOnly = True
            dgv.RowHeadersVisible = False
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False
            dgv.AllowUserToResizeColumns = False
            dgv.AllowUserToResizeRows = False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.ColumnHeader


            For Each column As DataGridViewColumn In dgv.Columns
                Dim palabra() As Char = column.HeaderText.ToCharArray
                palabra(0) = Char.ToUpper(palabra(0))
                column.HeaderText = palabra

            Next
            cerrar()

        End Try

    End Function





End Class
