'MenuPrincipal (DISEÑO)
Public Class frmMainMenu

    Dim conexion As ConnectionBD = Login.conexion
    Public ReservaSeleccionada As New ReservaSeleccionada(conexion)
    Dim TiposDeDocumentoFiltro As New DataTable
    Dim TiposDeDocumento As New DataTable
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim años As Integer = 1900
        While años <= CInt(DateTime.Today.Year)
            cbxAnioNFCliente.Items.Add(años)
            años = años + 1
        End While



        TiposDeDocumentoFiltro.Columns.Add("valor", GetType(String))
        TiposDeDocumentoFiltro.Columns.Add("mostrar", GetType(String))
        TiposDeDocumentoFiltro.Rows.Add("", "Todos")
        TiposDeDocumentoFiltro.Rows.Add("CI UY", "CI UY")
        TiposDeDocumentoFiltro.Rows.Add("SYSTEM", "SYSTEM")



        TiposDeDocumento.Columns.Add("valor", GetType(String))
        TiposDeDocumento.Columns.Add("mostrar", GetType(String))
        TiposDeDocumento.Rows.Add("CI UY", "CI UY")
        TiposDeDocumento.Rows.Add("SYSTEM", "SYSTEM")

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()
        CargarDatos()

        cbxTipoDocumFCliente.SelectedItem = "Todos"

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


        'dtpInicioARes.Value = Nothing
        'dtpFinARes.Value = Nothing




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
        conexion.EjecutarNonQuery("UPDATE RESERVA SET ESTADO = 2 WHERE fechareservainicio <= '" + DateTime.Today.ToShortDateString + "'")
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
        CargarDatosComboBox(cbxMarcaFVeh, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaMVeh, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaAVeh, conexion.Marcas, "nombre", "idmarca")

        'TIPOS
        CargarDatosComboBox(cbxTipoFVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoMVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAVeh, conexion.Tipos, "nombre", "idtipo")

        'CATEGORIAS
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaAVeh, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre", "idcategoria")

        'SUCURSALES
        CargarDatosComboBox(cbxSucursalFVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalAVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalFres, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegFRes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalidaARes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegadaARes, conexion.Sucursales, "nombre", "idsucursal")

        'DOCUMENTOS
        CargarDatosComboBox(cbxTipoDocumFCliente, TiposDeDocumentoFiltro, "mostrar", "valor")
        CargarDatosComboBox(cbxTipoDocumACliente, TiposDeDocumento, "mostrar", "valor")
        CargarDatosComboBox(cbxTipoDocumMCliente, TiposDeDocumento, "mostrar", "valor")
        'Los modelos se cargan en el apartado "Vehiculos".

    End Sub

    Public Sub RecargarDatos(dgv As DataGridView)

        Select Case dgv.Name

            Case "dgvClientes"
                conexion.RellenarDataGridView(dgvClientes, "SELECT idpersona, tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa, DAY(fecnac) dia, MONTH(fecnac) mes, YEAR(fecnac) anio FROM CLIENTE WHERE estado = 't'")
                dgvClientes.Columns("idpersona").Visible = False
                dgvClientes.Columns("dia").Visible = False
                dgvClientes.Columns("mes").Visible = False
                dgvClientes.Columns("anio").Visible = False

            Case "dgvEmpleados"
                conexion.RellenarDataGridView(dgvEmpleados, "SELECT Cliente.idpersona, Cliente.nrodocumento Documento, Cliente.nombre Nombre, Cliente.apellido Apellido, Cliente.email correo, empleado.usuario, empleado.tipo FROM EMPLEADO, CLIENTE WHERE Cliente.idpersona = Empleado.idpersona AND Empleado.estado = 't'")
                dgvEmpleados.Columns("idpersona").Visible = False

            Case "dgvVehiculos"
                conexion.RellenarDataGridView(dgvVehiculos, "SELECT V.nrochasis, V.idcategoria, V.idmodelo, v.idsucursal, V.matricula Matricula, Ma.nombre Marca, Ma.idmarca, Mo.nombre Modelo, T.nombre Tipo, T.idtipo, V.anio Anio, C.nombre Categoria, V.deducible Deducible, V.aireacondicionado Aire, V.cantidaddepuertas Puertas, V.cantidaddepasajeros Pasajeros, V.cantidaddemaletas Maletas, V.esmanual Manual, V.kilometraje KM, S.Nombre Sucursal, V.estado estado FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal AND V.estado = 't'")
                dgvVehiculos.Columns("nrochasis").Visible = False
                dgvVehiculos.Columns("idmodelo").Visible = False
                dgvVehiculos.Columns("idmarca").Visible = False
                dgvVehiculos.Columns("idtipo").Visible = False
                dgvVehiculos.Columns("idsucursal").Visible = False
                dgvVehiculos.Columns("idcategoria").Visible = False
            Case "dgvReservas"

                conexion.RellenarDataGridView(dgvReservas, "SELECT R.idreserva, R.idpersona, R.fechareservainicio Inicio, R.fechareservafin Fin, R.cantidadkm Cantidad_KM, R.costototal Costo, R.fechatramite Fecha_Tramite, Cl.nombre Nombre, Cl.apellido Apellido, Ca.nombre Categoria, T.nombre Tipo, SS.nombre Sucursal_Partida, SL.nombre Sucursal_Destino, R.usuarioempleado Empleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL WHERE R.idtipo = T.idtipo AND R.nrochasis IS NULL AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND R.estado = 1 ORDER BY Cl.nombre")
                dgvReservas.Columns("idpersona").Visible = False
                dgvReservas.Columns("idreserva").Visible = False

            Case "dgvAlquileres"
                conexion.RellenarDataGridView(dgvAlquileres, "SELECT R.idreserva,R.idpersona, R.fechaalquilerinicio FechaInicio, R.fechaalquilerfin FechaFin, R.cantidadkm, R.costototal, R.fechatramite, R.estado, V.matricula, Cl.nombre, Cl.apellido, Ca.nombre Categoria, T.nombre Tipo, SS.nombre Sucursal, SL.nombre SucursalDestino, R.usuarioempleado Empleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL, Vehiculo V WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND V.nrochasis = R.nrochasis ORDER BY Cl.nombre")
                dgvAlquileres.Columns("idpersona").Visible = False
                dgvAlquileres.Columns("idreserva").Visible = False


            Case "dgvAlquilar"
                conexion.RellenarDataGridView(frmAlquilar.dgvAlquilar, "SELECT V.nrochasis, V.matricula Matricula, Ma.nombre Marca, Mo.nombre Modelo, T.nombre Tipo, V.anio Anio, C.nombre Categoria, V.deducible Deducible, V.aireacondicionado Aire, V.cantidaddepuertas Puertas, V.cantidaddepasajeros Pasajeros, V.cantidaddemaletas Maletas, V.esmanual Manual, V.kilometraje KM, S.Nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal AND V.estado = 't'")
                frmAlquilar.dgvAlquilar.Columns("nrochasis").Visible = False
                frmAlquilar.dgvAlquilar.Columns("categoria").Visible = False
                frmAlquilar.dgvAlquilar.Columns("tipo").Visible = False
                frmAlquilar.dgvAlquilar.Columns("sucursal").Visible = False

        End Select

    End Sub

    Public Sub CargarDatosComboBox(cbx As ComboBox, dt As DataTable, columna As String, value As String)

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext
        cbx.DataSource = dt.DefaultView

        cbx.DisplayMember = columna
        cbx.ValueMember = value

    End Sub


End Class
