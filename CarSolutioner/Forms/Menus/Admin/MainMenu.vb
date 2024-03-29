﻿Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
'MenuPrincipal (DISEÑO)
Public Class frmMainMenu


    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Le cambiamos el renderer al MenuStrip (cuestiones de diseño)
        CambiarRenderMenuStrip(mstMenuStrip)

        'Asignamos el tamaño de las tabs a 1 para ocultarlas.
        tbcTabControl.ItemSize = New Size(0, 1)

        '"Clickeamos" el botón Reservas (para que sea el botón presionado por defecto)
        btnReservas.PerformClick()

        'Hacemos toda la carga de datos
        CargarTodosDatos(Me)

        NoInjection()

        cbxTipoDocumFCliente.SelectedItem = Nothing

        cbxCategoriaFRes.SelectedItem = Nothing
        cbxCategoriaFVeh.SelectedItem = Nothing
        cbxCategoriaAVeh.SelectedItem = Nothing
        cbxCategoriaFAlquiler.SelectedItem = Nothing

        cbxTipoFVeh.SelectedItem = Nothing
        cbxTipoAVeh.SelectedItem = Nothing
        cbxTipoFRes.SelectedItem = Nothing
        cbxTipoFAlquileres.SelectedItem = Nothing

        cbxMarcaFVeh.SelectedItem = Nothing
        cbxMarcaAVeh.SelectedItem = Nothing

        cbxModeloAVeh.SelectedItem = Nothing
        cbxModeloFVeh.SelectedItem = Nothing

        cbxSucLlegFRes.SelectedItem = Nothing
        cbxSucSalFres.SelectedItem = Nothing
        cbxSucursalAVeh.SelectedItem = Nothing
        cbxSucursalFVeh.SelectedItem = Nothing
        cbxSucursalDestinoFAlquileres.SelectedItem = Nothing
        cbxSucursalPartidaFAlquileres.SelectedItem = Nothing

        cbxAnioNACliente.SelectedItem = Nothing
        cbxAnioNFCliente.SelectedItem = Nothing

        cbxSucursalFempleados.SelectedItem = Nothing
        cbxTipoFempleados.SelectedItem = Nothing
        chbxFiltrarEstadoMant.Checked = True
        chboxAlquileresProceso.Checked = True

        cbxKilomFRes.SelectedItem = Nothing
        chboxVerHoyFReserva.Checked = True
        cbxKilometrajeFAlquileres.SelectedItem = Nothing

        cbxAireFVeh.SelectedItem = Nothing
        cbxManualFVeh.SelectedItem = Nothing


        dtpFiltrarFechaInicioMant.Enabled = False
        dtpFiltrarFechaFinMant.Enabled = False

        dtpFechaInicioMant.Value = Date.Now

        dtpInicioARes.MinDate = Date.Now.AddMinutes(5).Round()
        dtpFinARes.MinDate = dtpInicioARes.Value.AddDays(1)


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

        Cargando(500, Me)

        frmCambiosGenerales.ShowDialog(Me)

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
        conexion.Marcas = conexion.EjecutarSelect("SELECT * from Marca")
        conexion.MarcasConModelo = conexion.EjecutarSelect("SELECT DISTINCT Ma.* FROM Marca Ma, Modelo Mo WHERE Mo.idmarca = Ma.idmarca")
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
        CargarReportes()


        'Cargas de ComboBox
        'MARCAS
        CargarDatosComboBox(cbxMarcaAVeh, conexion.MarcasConModelo, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaMVeh, conexion.MarcasConModelo, "nombre", "idmarca")
        CargarDatosComboBox(cbxMarcaFVeh, conexion.MarcasConModelo, "nombre", "idmarca")

        'TIPOS
        CargarDatosComboBox(cbxTipoFVeh, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAVeh, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoMVeh, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoFRes, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoAReserva, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoMReserva, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxTipoFAlquileres, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")

        'RANGOS EMPLEADOS
        CargarDatosComboBox(cbxTipoFempleados, conexion.TipoEmpleados, "tipos", "id")
        CargarDatosComboBox(cbxTipoMempleados, conexion.TipoEmpleados, "tipos", "id")
        CargarDatosComboBox(cbxTipoCempleados, conexion.TipoEmpleados, "tipos", "id")

        'CATEGORIAS
        CargarDatosComboBox(cbxCategoriaMReserva, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFRes, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaAVeh, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaARes, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFVeh, conexion.Categorias, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaMVeh, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaFAlquiler, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")

        'Los modelos se cargan en el apartado "Vehiculos".

        'SUCURSALES
        CargarDatosComboBox(cbxSucursalFVeh, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalAVeh, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMVeh, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalFres, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegFRes, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucSalidaARes, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucLlegadaARes, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalFempleados, conexion.Sucursales, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalCempleados, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalMempleados, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalLlegadaMReserva, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalSalidaMReserva, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxDestinoMAlquileres, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalPartidaFAlquileres, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")
        CargarDatosComboBox(cbxSucursalDestinoFAlquileres, conexion.Sucursales.Select("estado = true").CopyToDataTable, "nombre", "idsucursal")

        cbxSucSalidaARes.Enabled = True
        cbxSucSalidaARes.SelectedValue = conexion.IdSucursalUsuario
        cbxSucSalidaARes.Enabled = False


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
        CargarDatosComboBox(cbxKilomMAlquileres, conexion.Kilometros, "km", "id")
        CargarDatosComboBox(cbxKilometrajeFAlquileres, conexion.Kilometros, "km", "id")

        Me.Opacity = 100

        'Comboboxes de Si y No
        Dim SiNo As New DataTable
        SiNo.Columns.Add("text", GetType(String))
        SiNo.Columns.Add("value", GetType(Boolean))
        SiNo.Rows.Add("Si", True)
        SiNo.Rows.Add("No", False)

        CargarDatosComboBox(cbxAireFVeh, SiNo, "text", "value")
        CargarDatosComboBox(cbxManualFVeh, SiNo, "text", "value")

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
                chbxFiltroEmpleados.Checked = Not chbxFiltroEmpleados.Checked

            Case "dgvVehiculos"
                dgvVehiculos.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvVehiculos, "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND V.idsucursal = S.idsucursal UNION SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, 'En la calle' Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T WHERE V.idsucursal is null AND V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo ")
                'Para que se vuelva a aplicar el filtro
                chbxFiltroVehiculos.Checked = Not chbxFiltroVehiculos.Checked

            Case "dgvReservas"
                dgvReservas.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvReservas, "SELECT R.fechareservainicio, R.fechareservafin, TO_CHAR(r.fechareservainicio, '%d/%m/%Y') fechareservainiciof, R.idreserva, T.nombre tipo, C.nombre || ' ' || C.apellido nombreapellido, C.nrodocumento, ca.nombre categoria, R.costototal, R.fechatramite, R.estado idestado, R.idpersona, R.idcategoria, R.idtipo, R.idsucursalsalida, R.idsucursalllegada, SS.nombre salida, SL.nombre llegada, R.usuarioempleado, CASE WHEN R.cantidadkm = 1 THEN ""150 KM/Día"" WHEN R.cantidadkm = 2 THEN ""300 KM/Día"" WHEN R.cantidadkm = 3 THEN ""KM Libres"" ELSE NULL END cantidadkmtext, CASE WHEN R.estado = 1 THEN ""Activa"" WHEN R.estado = 2 THEN ""Inactiva"" WHEN R.estado = 3 THEN ""Anulada"" ELSE NULL END estado, R.cantidadkm idcantidadkm FROM Reserva R, Cliente C, Categoria Ca, Tipo T, Sucursal SS, Sucursal SL WHERE C.idpersona = R.idpersona AND Ca.idcategoria = R.idcategoria AND T.idtipo = R.idtipo AND SS.idsucursal = R.idsucursalsalida AND SL.idsucursal = R.idsucursalllegada AND R.nrochasis IS NULL ORDER BY fechareservainicio")
                dgvReservas.Columns("fechareservainicio").ValueType = GetType(Date)
                dgvReservas.Columns("fechareservafin").ValueType = GetType(Date)

                chboxFechaFRes.Checked = Not chboxFechaFRes.Checked
                chboxFechaFRes.Checked = Not chboxFechaFRes.Checked

            Case "dgvAlquileres"
                dgvAlquileres.AutoGenerateColumns = False
                conexion.RellenarDataGridView(dgvAlquileres, "SELECT R.idreserva, R.idpersona, R.fechaalquilerinicio, CASE WHEN R.fechaalquilerfin IS NULL Then ""En proceso"" ELSE TO_CHAR(R.fechaalquilerfin, '%d/%m/%Y %H:%M') END fechaalquilerfin, R.fechareservainicio, R.fechareservafin, R.cantidadkm idcantidadkm, V.deducible, R.costototal, R.fechatramite, TO_CHAR(R.fechatramite,'%d/%m/%Y') fechatramitef, R.estado idestado, R.nrochasis, V.matricula, Cl.nombre ||"" ""|| Cl.apellido nombreapellido, Cl.nrodocumento, ca.idcategoria, Ca.nombre categoria, T.idtipo, T.nombre tipo, SS.nombre sucsalida, SS.idsucursal idsucsalida, SL.nombre sucllegada, SL.idsucursal idsucllegada, R.usuarioempleado, CASE WHEN R.cantidadkm = 1 THEN ""150 KM/Día"" WHEN R.cantidadkm = 2 THEN ""300 KM/Día"" WHEN R.cantidadkm = 3 THEN ""KM Libres"" ELSE NULL END cantidadkmtext, CASE WHEN R.estado = 1 THEN ""Activa"" WHEN R.estado = 2 THEN ""Inactiva"" WHEN R.estado = 3 THEN ""Anulada"" ELSE NULL END estadotext FROM Reserva R, Vehiculo V, Cliente Cl, Categoria Ca, Tipo T, Sucursal SS, Sucursal SL WHERE R.idtipo = T.idtipo AND R.idcategoria = Ca.idcategoria AND Cl.idpersona = R.idpersona AND R.idsucursalsalida = SS.idsucursal AND R.idsucursalllegada = SL.idsucursal AND V.nrochasis = R.nrochasis ORDER BY nombreapellido")
                chboxAlquileresProceso.Checked = Not chboxAlquileresProceso.Checked
                chboxAlquileresProceso.Checked = Not chboxAlquileresProceso.Checked


            Case "dgvMant"
                conexion.RellenarDataGridView(dgvMant, "SELECT m.*, m.fechainicio fechainiciof, m.fechafin fechafinf, v.matricula FROM mantenimiento m, vehiculo v WHERE v.nrochasis = m.nrochasis ")
                chbxFiltrarEstadoMant.Checked = Not chbxFiltrarEstadoMant.Checked
                chbxFiltrarEstadoMant.Checked = Not chbxFiltrarEstadoMant.Checked

                'REPORTES
            Case "dgvMasAlquileresRClientes"
                conexion.RellenarDataGridView(dgvMasAlquileresRClientes, "SELECT C.apellido  , c.nombre, c.email, 0 Alquileres FROM Cliente c group by apellido, nombre,email UNION SELECT c.apellido , c.nombre, c.email, count(r.nrochasis) Alquileres from cliente c, vehiculo v, reserva r where c.idpersona = r.idpersona and r.nrochasis=v.nrochasis group by apellido, nombre,email order by alquileres desc")
            Case "dgvVehiculosDisponibles"
                conexion.RellenarDataGridView(dgvVehiculosDisponibles, "Select  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal FROM Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE v.idsucursal = '" + conexion.IdSucursalUsuario.ToString + "' AND V.idcategoria = C.idcategoria AND V.idmodelo = Mo.idmodelo AND Mo.Idmarca = Ma.Idmarca AND Mo.Idtipo = T.idtipo AND v.nrochasis NOT IN (SELECT r.nrochasis FROM Reserva R WHERE r.fechaalquilerfin IS NOT NULL) AND  v.nrochasis NOT IN (SELECT m.nrochasis FROM mantenimiento m WHERE TODAY BETWEEN m.fechainicio AND m.fechafin)")
            Case "dgvAccionesEmp"
                conexion.RellenarDataGridView(dgvAccionesEmp, "SELECT IP, TO_CHAR(fechayhora, '%d/%m/%Y') Fecha, TO_CHAR(fechayhora, '%H:%M') Hora, descripcion FROM Accion ORDER BY fechayhora DESC")
            Case "dgvAutosMasRentables"
                conexion.RellenarDataGridView(dgvAutosMasRentables, "SELECT V.matricula, Ma.nombre Marca, Mo.nombre Modelo, T.total FROM Vehiculo V, Marca Ma, Modelo Mo, RentTotalVehiculos T WHERE V.idmodelo = Mo.idmodelo AND Mo.idmarca = Ma.idmarca AND V.nrochasis = T.nrochasis ORDER BY total DESC")
            Case "dgvPorcVeh"
                conexion.RellenarDataGridView(dgvPorcVeh, "SELECT nombre, TotalSuc(idsucursal, CURRENT Year to Day) Total, PorcAlq(idsucursal, CURRENT Year to Day) || ""%"" PorcAlq, PorcMant(idsucursal, CURRENT YEAR TO DAY) || ""%"" PorcMant, PorcDispon(idsucursal, CURRENT YEAR TO DAY)|| ""%""  PorcDispon FROM Sucursal WHERE TotalSuc(idsucursal, CURRENT Year to Day) > 0")
            Case "dgvClientesMasGastaron"
                conexion.RellenarDataGridView(dgvClientesMasGastaron, "SELECT S.nombre, C.apellido, C.nombre, T.total FROM Sucursal S, Cliente C, RentTotalClientesMdeo T WHERE S.idsucursal = T.sucursal AND C.idpersona = T.idpersona UNION SELECT S.nombre, C.apellido, C.nombre, Ta.total FROM Sucursal S, Cliente C, RentTotalClientesAereopuerto TA WHERE S.idsucursal = TA.sucursal AND C.idpersona = TA.idpersona UNION SELECT S.nombre, C.apellido, C.nombre, Tp.total FROM Sucursal S, Cliente C, RentTotalClientesPEste TP WHERE S.idsucursal = TP.sucursal AND C.idpersona = TP.idpersona UNION SELECT S.nombre, C.apellido, C.nombre, TPa.total FROM Sucursal S, Cliente C, RentTotalClientesPaloma TPA WHERE S.idsucursal = TPA.sucursal AND C.idpersona = TPA.idpersona")
            Case Else
                conexion.RellenarDataGridView(dgv, sentencia)

        End Select

    End Sub

    Public Sub CargarReportes()
        RecargarDatos(dgvMasAlquileresRClientes)
        RecargarDatos(dgvVehiculosDisponibles)
        RecargarDatos(dgvAccionesEmp)
        RecargarDatos(dgvAutosMasRentables)
        RecargarDatos(dgvPorcVeh)
        RecargarDatos(dgvClientesMasGastaron)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CargarTodosDatos(Me)
    End Sub

    Private Sub LupaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LupaToolStripMenuItem.Click
        Dim p As Process() = Process.GetProcessesByName("Magnify")
        If p.Count > 0 Then
            For Each pr In p
                pr.Kill()
            Next
        Else
            Process.Start("C:\Windows\system32\Magnify.exe")
        End If

    End Sub

    Private Sub GenerarPdfDgvActual(tpg As TabPage, Optional child As TabPage = Nothing)

        Select Case tpg.Name

            Case "tbpMantenimiento"
                CrearPDF(dgvMant, "Mantenimientos")

            Case "tbpReservas"
                Select Case child.Name
                    Case "tpgReservas"
                        CrearPDF(dgvReservas, "Reservas")

                    Case "tpgAlquileres"
                        CrearPDF(dgvAlquileres, "Alquileres")

                End Select

            Case "tbpClientes"
                Select Case child.Name
                    Case "Clientes"

                End Select
                CrearPDF(dgvClientes, "Clientes")

            Case "tbpVehiculos"
                CrearPDF(dgvVehiculos, "Vehiculos")

            Case "tbpEmpleados"
                CrearPDF(dgvEmpleados, "Empleados")

        End Select

    End Sub

    Private Sub NoInjection()
        Dim allTxt As New List(Of Control)
        For Each txt As TextBox In FindControlRecursive(allTxt, Me, GetType(TextBox))
            If ((txt.Name = "txtCorreoACliente") Or (txt.Name = "txtCorreoMCliente")) Then

            Else

                AddHandler txt.KeyPress, AddressOf antiSQLInjection
            End If
        Next

        Dim allNum As New List(Of Control)
        For Each num As NumericUpDown In FindControlRecursive(allNum, Me, GetType(NumericUpDown))
            AddHandler num.KeyPress, AddressOf antiSQLInjection
        Next
    End Sub

    Private Sub GuardarPdf(sender As Object, e As EventArgs) Handles ItemGuardarPDF.Click

        GenerarPdfDgvActual(tbcTabControl.SelectedTab, tabResAlq.SelectedTab)

    End Sub

    Private Sub AcercaDeCarSolutionerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeCarSolutionerToolStripMenuItem.Click
        Acercade.Show()
    End Sub

    Private Sub btnExportarVehDispHoy_Click(sender As Object, e As EventArgs) Handles btnExportarVehDispHoy.Click
        CrearPDF(dgvVehiculosDisponibles, "Vehiculos disponibles para hoy en esta Sucursal")
    End Sub

    Private Sub btnExportarEstadoVeh_Click(sender As Object, e As EventArgs) Handles btnExportarEstadoVeh.Click
        CrearPDF(dgvPorcVeh, "Estado actual de los Vehiculos")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        CrearPDF(dgvAccionesEmp, "Acciones de los Empleados")
    End Sub

    Private Sub btnMasRentables_Click(sender As Object, e As EventArgs) Handles btnMasRentables.Click
        CrearPDF(dgvAutosMasRentables, "Autos más rentables")
    End Sub

    Private Sub btnClientesMasGastaron_Click(sender As Object, e As EventArgs) Handles btnClientesMasGastaron.Click
        CrearPDF(dgvClientesMasGastaron, "Clientes que más han gastado")
    End Sub
End Class