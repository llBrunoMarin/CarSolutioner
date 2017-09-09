'MenuPrincipal (DISEÑO)
Public Class frmMainMenu

    Dim conexion As ConnectionBD = Login.conexion

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()
        Alquilar.cargardatos()
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

        frmCambiosGenerales.Show()

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
    Private Sub CargarDatos()

        'Cargas DataGridView

        conexion.Modelos = conexion.EjecutarSelect("SELECT * from modelo")
        conexion.Marcas = conexion.EjecutarSelect("SELECT * from marca")
        conexion.Categorias = conexion.EjecutarSelect("SELECT * from categoria")
        conexion.Tipos = conexion.EjecutarSelect("SELECT * from tipo")
        conexion.Sucursales = conexion.EjecutarSelect("SELECT * from sucursal")


        conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")
        conexion.RellenarDataGridView(dgvEmpleados, "SELECT Cliente.nrodocumento Documento, Cliente.nombre Nombre, Cliente.apellido Apellido, Cliente.email correo, empleado.usuario, empleado.tipo FROM EMPLEADO, CLIENTE WHERE Cliente.idpersona = Empleado.idpersona AND Empleado.estado = 't'")
        conexion.RellenarDataGridView(dgvVehiculos, "SELECT V.matricula Matricula,
                                                    Ma.nombre Marca,
                                                    Mo.nombre Modelo,
                                                    T.nombre Tipo,
                                                    V.anio Anio,
                                                    C.nombre Categoria,
                                                    V.deducible Deducible,
                                                    V.aireacondicionado Aire,
                                                    V.cantidaddepuertas Puertas,
                                                    V.cantidaddepasajeros Pasajeros,
                                                    V.cantidaddemaletas Maletas,
                                                    V.esmanual Manual,
                                                    V.kilometraje KM,
                                                    S.Nombre Sucursal FROM Vehiculo V, Categoria C,
                                                    Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria
                                                    AND V.idmodelo = Mo.idmodelo
                                                    AND Mo.Idmarca = Ma.Idmarca
                                                    AND Mo.Idtipo = T.idtipo
                                                    AND V.idsucursal = S.idsucursal AND V.estado = 't'")
        conexion.RellenarDataGridView(dgvReservas, "SELECT R.fechareservainicio, R.fechareservafin, R.fechaalquilerinicio, R.fechaalquilerfin, R.cantidadkm, R.costototal, R.fechatramite, R.estado, V.matricula, Cl.nombre, Ca.nombre, T.nombre, SS.nombre, SL.nombre, R.usuarioempleado  FROM Reserva R, Vehiculo V, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL WHERE R.nrochasis = V.nrochasis AND R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal  UNION SELECT R.fechareservainicio, R.fechareservafin, R.fechaalquilerinicio, R.fechaalquilerfin, R.cantidadkm, R.costototal, R.fechatramite, R.estado, '-' , Cl.nombre, Ca.nombre, T.nombre, SS.nombre, SL.nombre,R.usuarioempleado FROM Reserva R, Categoria Ca, Cliente Cl, Tipo T, Sucursal SS, Sucursal SL WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal")

        'Cargas de ComboBox
        CargarDatosComboBox(cbxMarcaFVeh, conexion.Marcas, "nombre")
        CargarDatosComboBox(cbxMarcaAVeh, conexion.Marcas, "nombre")
        CargarDatosComboBox(cbxMarcaMVeh, conexion.Marcas, "nombre")


        CargarDatosComboBox(cbxTipoAVeh, conexion.Tipos, "nombre")
        CargarDatosComboBox(cbxTipoFVeh, conexion.Tipos, "nombre")
        CargarDatosComboBox(cbxTipoMVeh, conexion.Tipos, "nombre")

        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaAVeh, conexion.Categorias, "nombre")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre")
        'Los modelos se cargan en el apartado "Vehiculos".

    End Sub

    Private Sub RecargarDatos(dgv As DataGridView)

        Select Case dgv.Name
            Case "dgvClientes"
                conexion.RellenarDataGridView(dgvClientes, "SELECT tipodocumento Tipo, nrodocumento Documento, nombre Nombre, apellido Apellido, email Correo, fecnac Nacimiento, empresa Empresa FROM CLIENTE WHERE estado = 't'")

            Case "dgvEmpleados"
                'conexion.RellenarDataGridView(dgvEmpleados, "SELECT usuario, tipo FROM EMPLEADO WHERE estado = 't'")

            Case "dgvVehiculos"
                'conexion.RellenarDataGridView(dgvVehiculos, "SELECT matricula, etc FROM VEHICULO WHERE estado = 't'")

            Case "dgvReservas"
                'conexion.RellenarDataGridView(dgvReservas, "SELECT FROM RESERVA where estado = '?'")

        End Select

    End Sub

    Private Sub CargarDatosComboBox(cbx As ComboBox, dt As DataTable, columna As String)

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext

        cbx.DataSource = dt.DefaultView
        
        cbx.DisplayMember = columna
        cbx.ValueMember = columna

    End Sub

    Private Sub dgvReservas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReservas.CellContentClick

    End Sub
<<<<<<< HEAD
=======


>>>>>>> ad9d3dd52c864d5a11c7c46866ef7e6d0c39a371

    Private Sub pnlFRes_Paint(sender As Object, e As PaintEventArgs) Handles pnlFRes.Paint

    End Sub
End Class
