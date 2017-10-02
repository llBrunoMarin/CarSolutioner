'MenuPrincipal (DISEÑO)
Public Class frmMainMenu

    Dim conexion As ConnectionBD = Login.conexion
    Public ReservaSeleccionada As New ReservaSeleccionada(conexion)



    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()

        'Hacemos toda la carga de datos
        CargarDatos()

        cbxTipoDocumFCliente.SelectedItem = Nothing

        cbxCategoriaFRes.SelectedItem = Nothing
        cbxCategoriaARes.SelectedItem = Nothing
        cbxCategoriaFVeh.SelectedItem = Nothing
        cbxCategoriaAVeh.SelectedItem = Nothing

        cbxTipoFVeh.SelectedItem = Nothing
        cbxTipoAVeh.SelectedItem = Nothing

        cbxMarcaFVeh.SelectedItem = Nothing
        cbxMarcaAVeh.SelectedItem = Nothing

        cbxModeloAVeh.SelectedItem = Nothing
        cbxModeloFVeh.SelectedItem = Nothing

        cbxSucLlegadaARes.SelectedItem = Nothing
        cbxSucSalidaARes.SelectedItem = Nothing
        cbxSucLlegFRes.SelectedItem = Nothing
        cbxSucSalFres.SelectedItem = Nothing
        cbxSucursalAVeh.SelectedItem = Nothing
        cbxSucursalFVeh.SelectedItem = Nothing

        cbxAnioNACliente.SelectedItem = Nothing
        cbxAnioNFCliente.SelectedItem = Nothing



    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnVehiculos.Click, btnReservas.Click, btnMantenimiento.Click, btnEmpleados.Click, btnClientes.Click

        ResetColors()

        Select Case sender.Name

            Case "btnMantenimiento"
                SetTabAndColors(btnMantenimiento, tbpMantenimiento, Color.Silver)

            Case "btnReservas"
                SetTabAndColors(btnReservas, tbpReservas, Color.Silver)

            Case "btnClientes"
                SetTabAndColors(btnClientes, tbpClientes, Color.Silver)

            Case "btnVehiculos"
                SetTabAndColors(btnVehiculos, tbpVehiculos, Color.Silver)

            Case "btnEmpleados"
                SetTabAndColors(btnEmpleados, tbpEmpleados, Color.Silver)

            Case "pbxVehiculo"
                tbcTabControl.SelectedTab = tbpMenuPrincipal
                tbpMenuPrincipal.BackColor = Color.Silver

        End Select

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Login.Dispose()
        Me.Dispose()

    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub tsitemCambiosGenerales_Click(sender As Object, e As EventArgs) Handles tsitemCambiosGenerales.Click

        cargando(pcboxloading, 500)

        frmCambiosGenerales.ShowDialog()

    End Sub

    Private Sub SetTabAndColors(boton As Button, pagina As TabPage, Color As Color)

        boton.BackColor = Color
        boton.FlatAppearance.MouseOverBackColor = Color
        boton.FlatAppearance.MouseDownBackColor = Color
        boton.ForeColor = Color.FromArgb(100, 38, 38)

        pagina.BackColor = Color
        tbcTabControl.SelectedTab = pagina

    End Sub

    Private Sub ResetColors()

        'Recorrer todos los controles del panel Sidebar
        For Each control In pnlSidebar.Controls.OfType(Of Button)

            control.BackColor = Color.Transparent
            control.ForeColor = Color.White
            control.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 55, 55)

        Next

    End Sub

    'TODO: Reportar estado de carga en el formulario Loading
    Public Sub CargarDatos()
        'Se marcan como inactivas las reservas que pasen la fecha de hoy
        conexion.EjecutarNonQuery("UPDATE RESERVA SET ESTADO = 2 WHERE fechareservafin <= '" + DateTime.Today.ToShortDateString + "'")

        'Cargas Tablas
        conexion.Modelos = conexion.EjecutarSelect("SELECT * from modelo")
        conexion.Marcas = conexion.EjecutarSelect("SELECT * from marca")
        conexion.Categorias = conexion.EjecutarSelect("SELECT * from categoria")
        conexion.Tipos = conexion.EjecutarSelect("SELECT * from tipo")
        conexion.Sucursales = conexion.EjecutarSelect("SELECT * from sucursal")
        conexion.Documentos = conexion.EjecutarSelect("SELECT * from tipodocumento")
        'Agregar a la clase conexion etc, dio un error de instancia raro ta raro esto

        Dim tipoT As New DataTable

        tipoT.Columns.Add("id", GetType(System.Int32))
        tipoT.Columns.Add("tipos", GetType(String))

        tipoT.Rows.Add(1, "Director General")
        tipoT.Rows.Add(2, "Gerente")
        tipoT.Rows.Add(3, "Jefe de Personal")
        tipoT.Rows.Add(4, "Empleado")


        'Cargas DataGridView
        RecargarDatos(dgvReservas)
        RecargarDatos(dgvAlquileres)
        RecargarDatos(dgvClientes)
        RecargarDatos(dgvVehiculos)
        RecargarDatos(dgvEmpleados)
        RecargarDatos(frmAlquilar.dgvAlquilar)

        'Cargas de ComboBox
        'MARCAS
        CargarDatosComboBox(cbxMarcaFVeh, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaMVeh, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaAVeh, conexion.Marcas, "nombre", "idmarca")

        'TIPOS
        CargarDatosComboBox(cbxTipoFVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxPuertasMVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoMVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAReserva, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoFempleados, tipoT, "tipos", "id")
        CargarDatosComboBox(cbxTipoMempleados, tipoT, "tipos", "id")
        CargarDatosComboBox(cbxTipoCempleados, tipoT, "tipos", "id")

        'CATEGORIAS
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaAVeh, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaMVeh, conexion.Categorias, "nombre", "idcategoria")

        'Los modelos se cargan en el apartado "Vehiculos".

        'SUCURSALES
        CargarDatosComboBox(cbxSucursalFVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalAVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalFres, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegFRes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalidaARes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegadaARes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalFempleados, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalCempleados, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMempleados, conexion.Sucursales, "nombre", "idsucursal")

        'DOCUMENTOS
        CargarDatosComboBox(cbxTipoDocumFCliente, conexion.Documentos, "nombre", "idtipodoc")
        CargarDatosComboBox(cbxTipoDocumACliente, conexion.Documentos, "nombre", "idtipodoc")
        CargarDatosComboBox(cbxTipoDocumMCliente, conexion.Documentos, "nombre", "idtipodoc")
        CargarDatosComboBox(cbxTipoDocumMCliente, conexion.Documentos, "nombre", "idtipodoc")

        'AÑOS
        CargarDatosComboBox(cbxAnioNFCliente, conexion.Años)
        CargarDatosComboBox(cbxAnioNACliente, conexion.Años)
        CargarDatosComboBox(cbxAnioNMCliente, conexion.Años)




        Me.Opacity = 100
        Login.Hide()
    End Sub

    'Segun el DataGridView que se pase como argumento, es las cargas que realiza.
    Public Sub RecargarDatos(dgv As DataGridView, Optional sentencia As String = "")

        Select Case dgv.Name

            Case "dgvClientes"
                dgvClientes.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvClientes, "SELECT DAY(fecnac) dia, Cliente.*, Doc.nombre tipodocumento, MONTH(fecnac) mes, YEAR(fecnac) anio FROM CLIENTE, Tipodocumento Doc WHERE estado = 't' AND Cliente.idtipodoc = Doc.idtipodoc")
                dgvClientes.Columns("idpersona").Visible = False

            Case "dgvEmpleados"

                conexion.RellenarDataGridView(dgvEmpleados, "SELECT Cliente.idpersona, Cliente.nrodocumento, Cliente.nombre, Cliente.apellido, Cliente.email, empleado.usuario, empleado.tipo tiponum, sucursal.nombre sucursales, CASE WHEN empleado.tipo = 1 THEN ""Director General"" WHEN empleado.tipo = 2 THEN ""Gerente"" WHEN empleado.tipo = 3 THEN ""Jefe de Personal"" WHEN empleado.tipo = 4 THEN ""Empleado"" ELSE NULL END tipo FROM EMPLEADO, CLIENTE, TRABAJA, SUCURSAL WHERE Cliente.idpersona = Empleado.idpersona AND trabaja.usuarioempleado = empleado.usuario AND trabaja.idsucursal = sucursal.idsucursal AND trabaja.fechafin is null AND Empleado.estado = 't'")

            Case "dgvVehiculos"
                conexion.RellenarDataGridView(dgvVehiculos, "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal")

            Case "dgvReservas"
                conexion.RellenarDataGridView(dgvReservas, "SELECT R.fechareservainicio, R.idreserva, T.nombre tipo, C.nombre || ' ' || C.apellido nombreapellido, ca.nombre categoria, R.fechareservafin, R.costototal, R.fechatramite, R.estado, R.idpersona,	R.idcategoria, R.idtipo, R.idsucursalsalida, R.idsucursalllegada, SS.nombre salida, SL.nombre llegada, R.usuarioempleado, CASE WHEN R.cantidadkm = 1 THEN ""150 KM/Día"" WHEN R.cantidadkm = 2 THEN ""300 KM/Día"" WHEN R.cantidadkm = 3 THEN ""KM Libres"" ELSE NULL END cantidadkm FROM Reserva R, Cliente C, Categoria Ca, Tipo T, Sucursal SS, Sucursal SL WHERE C.idpersona = R.idpersona AND Ca.idcategoria = R.idcategoria AND T.idtipo = R.idtipo AND SS.idsucursal = R.idsucursalsalida AND SL.idsucursal = R.idsucursalllegada and r.estado=1")


            Case "dgvAlquileres"
                conexion.RellenarDataGridView(dgvAlquileres, "SELECT R.idreserva, R.idpersona, R.fechaalquilerinicio FechaInicio, R.fechaalquilerfin FechaFin, R.cantidadkm, R.costototal, R.fechatramite, R.estado, V.matricula, Cl.nombre, Cl.apellido, Ca.nombre Categoria, T.nombre Tipo, SS.nombre Sucursal, SL.nombre SucursalDestino, R.usuarioempleado Empleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL, Vehiculo V WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND V.nrochasis = R.nrochasis ORDER BY Cl.nombre")
                dgvAlquileres.Columns("idpersona").Visible = False
                dgvAlquileres.Columns("idreserva").Visible = False

            Case "dgvAlquilar"
                conexion.RellenarDataGridView(frmAlquilar.dgvAlquilar, "SELECT V.matricula Matricula, Ma.nombre Marca, Mo.nombre Modelo, T.nombre Tipo, V.anio Anio, C.nombre Categoria, V.deducible Deducible, V.aireacondicionado Aire, V.cantidaddepuertas Puertas, V.cantidaddepasajeros Pasajeros, V.cantidaddemaletas Maletas, V.esmanual Manual, V.kilometraje KM, S.Nombre Sucursal, V.nrochasis FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal AND V.estado = 't'")
                frmAlquilar.dgvAlquilar.Columns("nrochasis").Visible = False
                frmAlquilar.dgvAlquilar.Columns("categoria").Visible = False
                frmAlquilar.dgvAlquilar.Columns("tipo").Visible = False
                frmAlquilar.dgvAlquilar.Columns("sucursal").Visible = False

            Case "dgvMantenimiento"
                conexion.RellenarDataGridView(dgvMantenimiento, "selet * from tipoT")
            Case Else
                conexion.RellenarDataGridView(dgv, sentencia)


        End Select

    End Sub

End Class
