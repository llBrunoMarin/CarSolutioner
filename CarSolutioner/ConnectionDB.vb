Public Class ConnectionDB

    Dim cx As New Odbc.OdbcConnection
    Dim cm As New Odbc.OdbcCommand
    Dim da As New Odbc.OdbcDataAdapter
    Dim ds As New Data.DataSet
    Dim dr As Odbc.OdbcDataReader

    Dim Usuario As String
    Dim Contraseña As String

    Function GetUsuario() As String
        Return Usuario
    End Function

    Sub SetUsuario(user As String)
        Usuario = user
    End Sub

    Function GetContraseña() As String
        Return Contraseña
    End Function

    Sub SetContraseña(password As String)
        Contraseña = password
    End Sub

    'TODO: TryCatchs correspondientes, y crear + métodos.
    'TODO: Programar excepciones de tal manera que muestre mensaje correspondiente
    'segun cual sea el error (error de conexión, error de primary key, etc)

    'Abrir y cerrar la conexión con la BD. La idea es abrirla antes de ejecutar una sentencia, y cerrarla al finalizar.
    Function conectar(Usuario, Contraseña) As Boolean
        Try
            cx.ConnectionString = "DRIVER={IBM INFORMIX ODBC DRIVER (64-bit)};UID=" + Usuario + ";PWD=" + Contraseña + ";DATABASE=amaranth_solutions;HOST=10.0.29.6;SERVER=ol_informix1;SERVICE=1526;PROTOCOL=olsoctcp;CLIENT_LOCALE=en_US.CP1252;DB_LOCALE=en_US.819;"
            cx.Open()
            Return True

        Catch ex As Exception
            If ex.Message.Contains(" [HY000] [Informix][Informix ODBC Driver][-11302] Insufficient Connection information was supplied") Then
                MsgBox("Usuario y/o Contraseña incorrectos.", MsgBoxStyle.Information, "Datos Incorrectos")
            ElseIf ex.Message.Contains("ERROR [28000] [Informix][Informix ODBC Driver][Informix]") Then
                MsgBox("Usuario y/o Contraseña incorrectos.", MsgBoxStyle.Information, "Datos Incorrectos")
            Else
                MsgBox("Error desconocido", MsgBoxStyle.Exclamation, "Error")
            End If

            Return False

        End Try

    End Function

    Function cerrar() As Boolean
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
    Function ejecutarNonQuery(sentencia As String) As Boolean
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
    Function rellenarDataGridView(dgv As DataGridView, nombretabla As String)

        'Tenemos que crear el "DataTable" acá, para que cree una nueva instancia cada vez.
        'De lo contrario, el datagridview tendría el contenido de muchas tablas a la vez.
        Dim dt As New Data.DataTable

        conectar(Usuario, Contraseña)
        Try

            cm.Connection = cx
            cm.CommandText = "SELECT * FROM " + nombretabla
            dt.Load(cm.ExecuteReader())
            dgv.DataSource = dt
            Return True

        Catch ex As Exception

            MsgBox(ex.Message)
            Throw ex
            Return False

        Finally

            cerrar()

        End Try

    End Function

    Function ejecutarSelect(sentencia As String)
        Dim dt As New Data.DataTable

        conectar(Usuario, Contraseña)
        Try

            cm.Connection = cx
            cm.CommandText = sentencia

            'Le carga a la tabla el resultado de ejecutar el comando.
            dt.Load(cm.ExecuteReader())

            'Devuelve la tabla
            Return dt

        Catch ex As Exception

            MsgBox(ex.Message)
            Throw ex
            Return False

        Finally

            cerrar()

        End Try


    End Function



End Class
