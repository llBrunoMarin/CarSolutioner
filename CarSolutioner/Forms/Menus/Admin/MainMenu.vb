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
        CargarDatos()

        'cbxTipoDocumFCliente.SelectedItem = Nothing
        'cbxMarcaFVeh.SelectedItem = Nothing
        'cbxMarcaAVeh.SelectedItem = Nothing



    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnMantenimiento.Click, btnReservas.Click, btnClientes.Click, btnVehiculos.Click, btnEmpleados.Click, pbxVehiculo.Click

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

    'TODO: Hacer otro tipo de cargas si es necesario, cargar también combobox y reportar estado de carga (otro formulario con barrita)
    Public Sub CargarDatos()

        'Cargas Tablas
        conexion.Modelos = conexion.EjecutarSelect("SELECT * from modelo")
        conexion.Marcas = conexion.EjecutarSelect("SELECT * from marca")
        conexion.Categorias = conexion.EjecutarSelect("SELECT * from categoria")
        conexion.Tipos = conexion.EjecutarSelect("SELECT * from tipo")
        conexion.Sucursales = conexion.EjecutarSelect("SELECT * from sucursal")

        'Cargas DataGridView
        RecargarDatos(dgvReservas)
        RecargarDatos(dgvAlquileres)
        RecargarDatos(dgvClientes)
        RecargarDatos(dgvVehiculos)
        RecargarDatos(dgvEmpleados)
        RecargarDatos(frmAlquilar.dgvAlquilar)

        'Cargas de ComboBox
        'MARCAS
        CargarDatosComboBox(cbxMarcaFVeh, conexion.Marcas, "nombre")
        CargarDatosComboBox(cbxMarcaAVeh, conexion.Marcas, "nombre")
        CargarDatosComboBox(cbxMarcaMVeh, conexion.Marcas, "nombre")

        'TIPOS
        CargarDatosComboBox(cbxTipoAVeh, conexion.Tipos, "nombre")
        CargarDatosComboBox(cbxTipoFVeh, conexion.Tipos, "nombre")
        CargarDatosComboBox(cbxTipoMVeh, conexion.Tipos, "nombre")

        'CATEGORIAS
        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaAVeh, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre")

        'SUCURSALES
        CargarDatosComboBox(cbxSucursalAVeh, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucursalFVeh, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucursalMVeh, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucSalFres, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucLlegFRes, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucSalidaARes, conexion.Sucursales, "nombre")
        CargarDatosComboBox(cbxSucLlegadaARes, conexion.Sucursales, "nombre")

        'Los modelos se cargan en el apartado "Vehiculos".

    End Sub

    Public Sub RecargarDatos(dgv As DataGridView)

        Select Case dgv.Name

            Case "dgvClientes"
                conexion.RellenarDataGridView(dgvClientes, "SELECT idpersona, tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")
                dgvClientes.Columns("idpersona").Visible = False

            Case "dgvEmpleados"
                conexion.RellenarDataGridView(dgvEmpleados, "SELECT Cliente.idpersona, Cliente.nrodocumento Documento, Cliente.nombre Nombre, Cliente.apellido Apellido, Cliente.email correo, empleado.usuario, empleado.tipo FROM EMPLEADO, CLIENTE WHERE Cliente.idpersona = Empleado.idpersona AND Empleado.estado = 't'")
                dgvEmpleados.Columns("idpersona").Visible = False

            Case "dgvVehiculos"
                conexion.RellenarDataGridView(dgvVehiculos, "SELECT V.nrochasis, V.matricula Matricula, Ma.nombre Marca, Mo.nombre Modelo, T.nombre Tipo, V.anio Anio, C.nombre Categoria, V.deducible Deducible, V.aireacondicionado Aire, V.cantidaddepuertas Puertas, V.cantidaddepasajeros Pasajeros, V.cantidaddemaletas Maletas, V.esmanual Manual, V.kilometraje KM, S.Nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal AND V.estado = 't'")
                dgvVehiculos.Columns("nrochasis").Visible = False

            Case "dgvReservas"
                conexion.RellenarDataGridView(dgvReservas, "SELECT R.idreserva, R.idpersona, R.fechareservainicio Inicio, R.fechareservafin Fin, R.cantidadkm Cantidad_KM, R.costototal Costo, R.fechatramite Fecha_Tramite, Cl.nombre Nombre, Cl.apellido Apellido, Ca.nombre Categoria, T.nombre Tipo, SS.nombre Sucursal_Partida, SL.nombre Sucursal_Destino, R.usuarioempleado Empleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL WHERE R.idtipo = T.idtipo AND R.nrochasis IS NULL AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal ORDER BY Cl.nombre")
                dgvReservas.Columns("idpersona").Visible = False

            Case "dgvAlquileres"
                conexion.RellenarDataGridView(dgvAlquileres, "SELECT R.idpersona, R.fechaalquilerinicio FechaInicio, R.fechaalquilerfin FechaFin, R.cantidadkm, R.costototal, R.fechatramite, R.estado, V.matricula, Cl.nombre, Cl.apellido, Ca.nombre Categoria, T.nombre Tipo, SS.nombre Sucursal, SL.nombre SucursalDestino, R.usuarioempleado Empleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL, Vehiculo V WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND V.nrochasis = R.nrochasis ORDER BY Cl.nombre")
                dgvAlquileres.Columns("idpersona").Visible = False

            Case "dgvAlquilar"
                conexion.RellenarDataGridView(frmAlquilar.dgvAlquilar, "SELECT V.nrochasis, V.matricula Matricula, Ma.nombre Marca, Mo.nombre Modelo, T.nombre Tipo, V.anio Anio, C.nombre Categoria, V.deducible Deducible, V.aireacondicionado Aire, V.cantidaddepuertas Puertas, V.cantidaddepasajeros Pasajeros, V.cantidaddemaletas Maletas, V.esmanual Manual, V.kilometraje KM, S.Nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal AND V.estado = 't'")
                frmAlquilar.dgvAlquilar.Columns("nrochasis").Visible = False

        End Select

    End Sub

    Public Sub CargarDatosComboBox(cbx As ComboBox, dt As DataTable, columna As String)

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext
        cbx.DataSource = dt.DefaultView

        cbx.DisplayMember = columna
        cbx.ValueMember = columna

    End Sub


End Class
