Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
'MenuPrincipal (DISEÑO)
Public Class frmMainMenuInvitado


    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)


        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Vehiculos (para que sea el botón presionado por defecto)
        btnVehiculos.PerformClick()

        'Hacemos toda la carga de datos
        CargarTodosDatos(Me)

        cbxTipoDocumFCliente.SelectedItem = Nothing

        cbxCategoriaFRes.SelectedItem = Nothing
        cbxCategoriaFVeh.SelectedItem = Nothing


        cbxTipoFRes.SelectedItem = Nothing

        cbxMarcaFVeh.SelectedItem = Nothing



        cbxModeloFVeh.SelectedItem = Nothing

        cbxSucLlegFRes.SelectedItem = Nothing
        cbxSucSalFres.SelectedItem = Nothing

        cbxSucursalFVeh.SelectedItem = Nothing

        cbxAnioNACliente.SelectedItem = Nothing
        cbxAnioNFCliente.SelectedItem = Nothing

        cbxSucursalFempleados.SelectedItem = Nothing
        cbxTipoFempleados.SelectedItem = Nothing
        chbxFiltrarEstadoMant.Checked = True

        cbxKilomFRes.SelectedItem = Nothing
        chboxVerHoyFReserva.Checked = True

        dtpInicioARes.MinDate = Date.Now.AddMinutes(5).Round()
        dtpFinARes.MinDate = dtpInicioARes.Value.AddDays(1)


    End Sub

    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnVehiculos.Click

        ResetColors()



        tbcTabControl.SelectedTab = tbpVehiculos
                tbpMenuPrincipal.BackColor = Color.Silver




    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)

        Login.Dispose()
        Me.Dispose()

    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub tsitemCambiosGenerales_Click(sender As Object, e As EventArgs)

        Cargando(500, Me)

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
        conexion.EjecutarNonQuery("UPDATE RESERVA SET ESTADO = 2 WHERE fechareservafin < TO_DATE('" + Date.Now.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M') ")

        'Cargas Tablas
        conexion.Modelos = conexion.EjecutarSelect("SELECT * from modelo")
        conexion.Marcas = conexion.EjecutarSelect("SELECT * from marca")
        conexion.Categorias = conexion.EjecutarSelect("SELECT * from categoria")
        conexion.Tipos = conexion.EjecutarSelect("SELECT * from tipo")
        conexion.Sucursales = conexion.EjecutarSelect("SELECT * from sucursal")
        conexion.Documentos = conexion.EjecutarSelect("SELECT * from tipodocumento")

        'Cargas DataGridView
        RecargarDatos(dgvReservas)
        RecargarDatos(dgvAlquileres)
        RecargarDatos(dgvClientes)
        RecargarDatos(dgvVehiculos)
        RecargarDatos(dgvEmpleados)
        RecargarDatos(dgvMant)
        RecargarDatos(dgvMasAlquileresRClientes)

        'Cargas de ComboBox
        'MARCAS

        CargarDatosComboBox(cbxMarcaFVeh, conexion.Marcas, "nombre", "idmarca")

        'TIPOS


        CargarDatosComboBox(cbxTipoFRes, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAReserva, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoMReserva, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")

        'RANGOS EMPLEADOS
        CargarDatosComboBox(cbxTipoFempleados, conexion.TipoEmpleados, "tipos", "id")
        CargarDatosComboBox(cbxTipoMempleados, conexion.TipoEmpleados, "tipos", "id")
        CargarDatosComboBox(cbxTipoCempleados, conexion.TipoEmpleados, "tipos", "id")

        'CATEGORIAS
        CargarDatosComboBox(cbxCategoriaMReserva, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre", "idcategoria")

        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre", "idcategoria")


        'Los modelos se cargan en el apartado "Vehiculos".

        'SUCURSALES
        CargarDatosComboBox(cbxSucursalFVeh, conexion.Sucursales, "nombre", "idsucursal")

        CargarDatosComboBox(cbxSucSalFres, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegFRes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalidaARes, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegadaARes, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalFempleados, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalCempleados, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMempleados, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalLlegadaMReserva, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalSalidaMReserva, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")

        'DOCUMENTOS
        CargarDatosComboBox(cbxTipoDocumFCliente, conexion.Documentos, "nombre", "idtipodoc")
        CargarDatosComboBox(cbxTipoDocumACliente, conexion.Documentos.Select("estado = true").CopyToDataTable, "nombre", "idtipodoc")
        CargarDatosComboBox(cbxTipoDocumMCliente, conexion.Documentos.Select("estado = true").CopyToDataTable, "nombre", "idtipodoc")

        'AÑOS
        CargarDatosComboBox(cbxAnioNFCliente, conexion.Años)
        CargarDatosComboBox(cbxAnioNACliente, conexion.Años)
        CargarDatosComboBox(cbxAnioNMCliente, conexion.Años)

        'TIPOS DE KM (para que no se lea "1, 2, 3")
        CargarDatosComboBox(cbxKilomFRes, conexion.Kilometros, "km", "id")
        CargarDatosComboBox(cbxKmARes, conexion.Kilometros, "km", "id")
        CargarDatosComboBox(cbxKilomMReserva, conexion.Kilometros, "km", "id")
        Me.Opacity = 100

        Login.Hide()
    End Sub

    'Segun el DataGridView que se pase como argumento, es las cargas que realiza.
    Public Sub RecargarDatos(dgv As DataGridView, Optional sentencia As String = "")

        Select Case dgv.Name

            Case "dgvClientes"
                dgvClientes.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvClientes, "SELECT DAY(fecnac) dia, cliente.idpersona, cliente.nombre, cliente.apellido, cliente.idtipodoc,  cliente.nrodocumento, cliente.email, cliente.fecnac, cliente.empresa, cliente.porcdescuento, cliente.estado, cliente.telefono, Doc.nombre tipodocumento, MONTH(fecnac) mes, YEAR(fecnac) anio FROM CLIENTE, Tipodocumento Doc WHERE Cliente.idtipodoc = Doc.idtipodoc")
                dgvClientes.Columns("idpersona").Visible = False
                chbxFechaFClientes.Checked = Not chbxFechaFClientes.Checked
                chbxFechaFClientes.Checked = Not chbxFechaFClientes.Checked

            Case "dgvEmpleados"
                dgvEmpleados.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvEmpleados, "SELECT Cliente.idpersona, Cliente.nrodocumento, Cliente.nombre, Cliente.apellido, Cliente.email, empleado.estado, empleado.usuario, empleado.tipo idtipo, sucursal.idsucursal, sucursal.nombre sucursales, CASE WHEN empleado.tipo = 1 THEN ""Director General"" WHEN empleado.tipo = 2 THEN ""Gerente"" WHEN empleado.tipo = 3 THEN ""Jefe de Personal"" WHEN empleado.tipo = 4 THEN ""Empleado"" ELSE NULL END tipo FROM EMPLEADO, CLIENTE, TRABAJA, SUCURSAL WHERE Cliente.idpersona = Empleado.idpersona AND trabaja.usuarioempleado = empleado.usuario AND trabaja.idsucursal = sucursal.idsucursal AND trabaja.fechafin is null AND Empleado.estado = 't'")
                Dim AuxiliarFiltro As String
                AuxiliarFiltro = txtNombreFempleado.Text
                txtNombreFempleado.Text = ""
                txtNombreFempleado.Text = AuxiliarFiltro

            Case "dgvVehiculos"
                dgvVehiculos.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvVehiculos, "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal UNION SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, 'En la calle' Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T WHERE V.idsucursal is null AND V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND nrochasis NOT IN (SELECT nrochasis FROM Reserva R WHERE fechaalquilerfin IS NOT NULL) AND nrochasis NOT IN (SELECT nrochasis FROM mantenimiento WHERE TODAY BETWEEN fechainicio AND fechafin)")
                'Para que se vuelva a aplicar el filtro
                chbxFiltro.Checked = Not chbxFiltro.Checked

            Case "dgvReservas"
                dgvReservas.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvReservas, "SELECT R.fechareservainicio, R.fechareservafin, TO_CHAR(r.fechareservainicio, '%d/%m/%Y') fechareservainiciof, R.idreserva, T.nombre tipo, C.nombre || ' ' || C.apellido nombreapellido, C.nrodocumento, ca.nombre categoria,R.costototal, R.fechatramite, R.estado idestado, R.idpersona, R.idcategoria, R.idtipo, R.idsucursalsalida, R.idsucursalllegada, SS.nombre salida, SL.nombre llegada, R.usuarioempleado, CASE WHEN R.cantidadkm = 1 THEN ""150 KM/Día"" WHEN R.cantidadkm = 2 THEN ""300 KM/Día"" WHEN R.cantidadkm = 3 THEN ""KM Libres"" ELSE NULL END cantidadkmtext, CASE WHEN R.estado = 1 THEN ""Activa"" WHEN R.estado = 2 THEN ""Inactiva"" WHEN R.estado = 3 THEN ""Anulada"" ELSE NULL END estado, R.cantidadkm idcantidadkm FROM Reserva R, Cliente C, Categoria Ca, Tipo T, Sucursal SS, Sucursal SL WHERE C.idpersona = R.idpersona AND Ca.idcategoria = R.idcategoria AND T.idtipo = R.idtipo AND SS.idsucursal = R.idsucursalsalida AND SL.idsucursal = R.idsucursalllegada AND R.nrochasis IS NULL ORDER BY fechareservainicio")
                dgvReservas.Columns("fechareservainicio").ValueType = GetType(Date)
                dgvReservas.Columns("fechareservafin").ValueType = GetType(Date)
                chboxFechaFRes.Checked = Not chboxFechaFRes.Checked
                chboxFechaFRes.Checked = Not chboxFechaFRes.Checked

            Case "dgvAlquileres"
                dgvAlquileres.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvAlquileres, "SELECT R.idreserva, R.idpersona, R.fechaalquilerinicio, R.fechaalquilerfin, R.fechareservainicio, R.fechareservafin, R.cantidadkm idcantidadkm, V.deducible, R.costototal, R.fechatramite, R.estado idestado, R.nrochasis, V.matricula, Cl.nombre ||"" ""|| Cl.apellido nombreapellido, Cl.nrodocumento, ca.idcategoria, Ca.nombre categoria, T.idtipo, T.nombre tipo, SS.nombre sucsalida, SS.idsucursal idsucsalida, SL.nombre sucllegada, SL.idsucursal idsucllegada, R.usuarioempleado, CASE WHEN R.cantidadkm = 1 THEN ""150 KM/Día"" WHEN R.cantidadkm = 2 THEN ""300 KM/Día"" WHEN R.cantidadkm = 3 THEN ""KM Libres"" ELSE NULL END cantidadkmtext, CASE WHEN R.estado = 1 THEN ""Activa"" WHEN R.estado = 2 THEN ""Inactiva"" WHEN R.estado = 3 THEN ""Anulada"" ELSE NULL END estadotext FROM Reserva R, Vehiculo V, Cliente Cl, Categoria Ca, Tipo T, Sucursal SS, Sucursal SL WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND V.nrochasis = R.nrochasis ORDER BY nombreapellido")


            Case "dgvMant"
                conexion.RellenarDataGridView(dgvMant, "SELECT m.*, m.fechainicio fechainiciof, m.fechafin fechafinf, v.matricula FROM mantenimiento m, vehiculo v WHERE v.nrochasis = m.nrochasis ")
                chbxFiltrarEstadoMant.Checked = Not chbxFiltrarEstadoMant.Checked
                chbxFiltrarEstadoMant.Checked = Not chbxFiltrarEstadoMant.Checked

                'REPORTES
            Case "dgvMasAlquileresRClientes"
                conexion.RellenarDataGridView(dgvMasAlquileresRClientes, "SELECT C.apellido  , c.nombre, c.email, 0 Alquileres FROM Cliente c group by apellido, nombre,email UNION SELECT c.apellido , c.nombre, c.email, count(r.nrochasis) Alquileres from cliente c, vehiculo v, reserva r where c.idpersona = r.idpersona and r.nrochasis=v.nrochasis group by apellido, nombre,email order by alquileres desc")

            Case Else
                conexion.RellenarDataGridView(dgv, sentencia)

        End Select

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CargarTodosDatos(Me)
    End Sub

    Private Sub pbcEngland_Click(sender As Object, e As EventArgs) Handles pbcEngland.Click
        btnVehiculos.Text = "Vehicles"
        lblSearchVehicles.Text = "Search Vehicles"
        lblLanguage.Text = "Select Language"
        lblcat.Text = "Category"
        lblmarca.Text = "Brand"
        lblmodelo.Text = "Model"

        lblsucursal.Text = "Office"
        lblaño.Text = "Year"
        lblmaletas.Text = "Suit Cases"
        lblpasajeros.Text = "Passengers"
        lblParamIgnore.Text = "0 Will ignore this field"

        dgvVehiculos.Columns("matricula").HeaderText = "Plate"
        dgvVehiculos.Columns("marca").HeaderText = "Brand"
        dgvVehiculos.Columns("categoria").HeaderText = "Category"
        dgvVehiculos.Columns("Modelo").HeaderText = "Model"
        dgvVehiculos.Columns("esmanual").HeaderText = "Manual"
        dgvVehiculos.Columns("aireacondicionado").HeaderText = "Air"
        dgvVehiculos.Columns("sucursal").HeaderText = "Office"
        dgvVehiculos.Columns("aniov").HeaderText = "Year"
        dgvVehiculos.Columns("cantidaddemaletas").HeaderText = "Suit Cases"
        dgvVehiculos.Columns("cantidaddepasajeros").HeaderText = "Passengers"


    End Sub

    Private Sub PbcGermany_Click(sender As Object, e As EventArgs) Handles PbcGermany.Click
        btnVehiculos.Text = "Fahrzeuge"
        lblSearchVehicles.Text = "Fahrzeugsuche"
        lblLanguage.Text = "Sprache auswählen"
        lblcat.Text = "Kategorie"
        lblmarca.Text = "Marke"
        lblmodelo.Text = "Model"

        lblsucursal.Text = "Büro"
        lblaño.Text = "Jahr"
        lblmaletas.Text = "Koffer"
        lblpasajeros.Text = "Passagiere"
        lblParamIgnore.Text = "0 Ignoriert diesen Parameter"

        dgvVehiculos.Columns("matricula").HeaderText = "Plate"
        dgvVehiculos.Columns("marca").HeaderText = "Marke"
        dgvVehiculos.Columns("categoria").HeaderText = "Kategorie"
        dgvVehiculos.Columns("Modelo").HeaderText = "Model"
        dgvVehiculos.Columns("esmanual").HeaderText = "Manual"
        dgvVehiculos.Columns("aireacondicionado").HeaderText = "Air"
        dgvVehiculos.Columns("sucursal").HeaderText = "Büro"
        dgvVehiculos.Columns("aniov").HeaderText = "Jahr"
        dgvVehiculos.Columns("cantidaddemaletas").HeaderText = "Koffer"
        dgvVehiculos.Columns("cantidaddepasajeros").HeaderText = "Passagiere"
    End Sub
End Class