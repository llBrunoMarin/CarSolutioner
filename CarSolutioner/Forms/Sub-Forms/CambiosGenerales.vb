Public Class frmCambiosGenerales

    Private Sub frmCambiosGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbcTabControl.ItemSize = New Size(0, 1)
        btnSucursales.PerformClick()
        CargarDatosComboBox(cbxSucursalDesde, conexion.EjecutarSelect("SELECT * FROM sucursal where estado = 't'"), "nombre", "idsucursal")
        cbxSucursalDesde.SelectedItem = Nothing
        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False
        conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")


        CargarDatosComboBox(cbxTipoFilter, conexion.Tipos, "nombre", "idtipo")
        cbxTipoFilter.SelectedItem = 1
        conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal," + cbxTipoFilter.SelectedValue.ToString + ")
Cantidad  FROM
Categoria C, Sucursal S

group by s.nombre, cantidad, c.idcategoria
order by s.nombre





")
        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False
        CargarDatosComboBox(cbxCategoriaFilter, conexion.EjecutarSelect("Select * from categoria where estado='t'"), "nombre", "idcategoria")
        CargarDatosComboBox(cbxCategoriaHacia, conexion.EjecutarSelect("Select * from categoria where estado='t'"), "nombre", "idcategoria")
        cbxCategoriaHacia.SelectedItem = Nothing
        CargarDatosComboBox(cbxTipoHacia, conexion.EjecutarSelect("SELECT * FROM tipo where estado = 't'"), "nombre", "idtipo")
        cbxTipoHacia.SelectedItem = Nothing
        dgvCategorias.Columns("idcategoria").Visible = False
        chboxsucinactivas.Checked = True
        inactivascategorias.Checked = True

        Dim filtro As String
        cbxCategoriaFilter.SelectedItem = 1
        filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
        dgvVehiculoXSucursal.DataSource.Filter = filtro

    End Sub
    Dim idcategoria
    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub
    Dim idsucursalmod As String
    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnSucursales.Click, btnCategorias.Click, btnVehiculo.Click

        ResetColors()

        Select Case sender.Name
            Case "btnCategorias"
                SetTabAndColors(btnCategorias, tbpCategorias, Color.White)

            Case "btnSucursales"
                SetTabAndColors(btnSucursales, tbpSucursales, Color.White)

            Case "btnVehiculo"
                SetTabAndColors(btnVehiculo, tbpVehiculo, Color.White)










        End Select

    End Sub

    Sub ResetColors()

        'Recorrer todos los controles del panel Sidebar
        For Each control In pnlSidebar.Controls
            'Si el control es un botón
            If TypeOf control Is Button Then
                control.BackColor = Color.Transparent
                control.ForeColor = Color.White
                control.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 55, 55)
            End If

        Next

    End Sub

    Private Sub SetTabAndColors(boton As Button, pagina As TabPage, Color As Color)

        boton.BackColor = Color
        boton.FlatAppearance.MouseOverBackColor = Color
        boton.FlatAppearance.MouseDownBackColor = Color
        boton.ForeColor = Color.FromArgb(100, 38, 38)

        pagina.BackColor = Color
        tbcTabControl.SelectedTab = pagina

    End Sub


    Private Sub btnAddSuc_Click(sender As Object, e As EventArgs) Handles btnAddSuc.Click
        conexion.EjecutarNonQuery("INSERT INTO sucursal values (0, '" + txtNomSuc.Text + "', '" + txtCidSuc.Text + "', '" + txtDicSuc.Text.ToString + "', " + txtTelSuc1.Text.ToString + "," + txttelefonosucmod2.Text.ToString + ",'T')")
        If chboxsucinactivas.Checked Then
            conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
            dgvSucursales.Columns("idsucursal").Visible = False

        Else
            conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        End If
        For Each con As Control In pnlsuccambios.Controls
            VaciarControl(con)
        Next
    End Sub

    Private Sub dataGridView1_CellClick(ByVal sender As Object, ByVal e As EventArgs) Handles dgvSucursales.SelectionChanged
        cboxsucursalmov.SelectedItem = Nothing
        cboxsucursalmov.DataSource = Nothing
        If Not IsNothing(dgvSucursales.CurrentRow) Then

            Dim estadosucmod As Boolean

            idsucursalmod = dgvSucursales.CurrentRow.Cells("idsucursal").Value.ToString()
            txtnombresucmod.Text = dgvSucursales.CurrentRow.Cells("nombre").Value.ToString()
            txtciudadsucmod.Text = dgvSucursales.CurrentRow.Cells("ciudad").Value.ToString()
            txtdireccionsucmod.Text = dgvSucursales.CurrentRow.Cells("direccion").Value.ToString()
            estadosucmod = dgvSucursales.CurrentRow.Cells("estado").Value.ToString()
            txttelefonosucmod2.Text = dgvSucursales.CurrentRow.Cells("telefono2").Value.ToString()
            txttelefonosucmod1.Text = dgvSucursales.CurrentRow.Cells("telefono1").Value.ToString()
            lblsucmov.Text = txtnombresucmod.Text

            If estadosucmod = "True" Then
                cboxestadosucmod.SelectedItem = "Activa"

            Else
                cboxestadosucmod.SelectedItem = "Inactiva"
            End If

        End If

    End Sub

    Private Sub btnmodsuc_Click(sender As Object, e As EventArgs) Handles btnmodsuc.Click

        Dim estado As String

        If cboxestadosucmod.SelectedItem = "Activa" Then

            estado = "t"

            conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
            conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
            dgvSucursales.Columns("idsucursal").Visible = False

        ElseIf Not cboxsucursalmov.SelectedItem Is Nothing Then
            Dim ReservasActivas As DataTable = conexion.EjecutarSelect("Select idreserva from reserva where estado = 1 and ( idsucursalllegada = '" + idsucursalmod + "' or idsucursalsalida = '" + idsucursalmod + "')")
            If ReservasActivas.Rows.Count = 0 Then
                estado = "f"
                If conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = " + cboxsucursalmov.SelectedValue.ToString + " where idsucursal = " + idsucursalmod + "", "Vehiculos") Then

                    MsgBox("Vehiculos trasladados satisfactoriamente a " + cboxsucursalmov.Text + ". La sucursal se declara inactiva.", MsgBoxStyle.Information, "Notificacion")
                    conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
                    conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                    dgvSucursales.Columns("idsucursal").Visible = False

                Else
                    MsgBox("La sucursal se declara inactiva.", MsgBoxStyle.Information, "Notificacion")

                    conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = 'f' where idsucursal = '" + idsucursalmod + "'")
                    conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                End If

            Else
                    MsgBox("Tienes reservas activas en esta sucursal, no puede ser dada de baja hasta que las reservas sean derivadas manualmente.", MsgBoxStyle.Exclamation, "Notificacion")
            End If


        End If


    End Sub

    Private Sub btncatadd_Click(sender As Object, e As EventArgs) Handles btncatadd.Click
        conexion.EjecutarNonQuery("Insert into categoria values (0, " + txttarifabasecatadd.Text + "," + txttarifa150catadd.Text + "," + txttarifa300catadd.Text + "," + txttarifalibrecatadd.Text + ",'" + txtnomcatadd.Text + "','T')")
        conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
        dgvCategorias.Columns("idcategoria").Visible = False
        For Each con As Control In pnlcatcambios.Controls
            VaciarControl(con)
        Next
    End Sub


    Private Sub chboxsucinactivas_CheckedChanged_1(sender As Object, e As EventArgs) Handles chboxsucinactivas.CheckedChanged, btnmodsuc.Click, btnAddSuc.Click
        Dim filtro As String
        If chboxsucinactivas.Checked Then

            filtro = ""
            dgvSucursales.DataSource.Filter = filtro
        Else
            filtro = "estado = True "

            dgvSucursales.DataSource.Filter = filtro
        End If

    End Sub

    Private Sub btndeletesuc_Click(sender As Object, e As EventArgs) Handles btndeletesuc.Click

        If conexion.EjecutarNonQuery("delete from sucursal where idsucursal=" + idsucursalmod + "") = False Then

            MsgBox("No puede eliminar una sucursal que esta siendo utilizada por otros registros.", MsgBoxStyle.Exclamation, "Notificacion")
        Else
            MsgBox("Sucursal eliminada con exito.", MsgBoxStyle.Information, "Notificacion")
        End If

        For Each con As Control In pnlmodsuc.Controls
            VaciarControl(con)
        Next
        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")


    End Sub

    Private Sub pnlmodsuc_Paint(sender As Object, e As PaintEventArgs) Handles pnlmodsuc.Paint

    End Sub

    Private Sub cboxestadosucmod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxestadosucmod.SelectedIndexChanged

        If cboxestadosucmod.SelectedItem = "Inactiva" Then



            pnlmovimiento.Enabled = True

        Else
            pnlmovimiento.Enabled = False

        End If
    End Sub

    Private Sub cboxsucursalmov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxsucursalmov.Click

        cargando(frmMainMenu.pcboxloading, 500)
        CargarDatosComboBox(cboxsucursalmov, conexion.EjecutarSelect("SELECT * FROM sucursal where idsucursal != " + idsucursalmod + "  and estado = 't'"), "nombre", "idsucursal")
    End Sub
    Private Sub cbxcatmov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxcatmov.Click

        cargando(frmMainMenu.pcboxloading, 500)
        CargarDatosComboBox(cbxcatmov, conexion.EjecutarSelect("SELECT * FROM categoria where idcategoria != " + idcategoria + "  and estado = 't'"), "nombre", "idcategoria")
    End Sub
    Private Sub categoriamod(sender As Object, e As EventArgs) Handles dgvCategorias.SelectionChanged
        cbxcatmov.SelectedItem = Nothing
        cbxcatmov.DataSource=Nothing
        If Not IsNothing(dgvCategorias.CurrentRow) Then
            txtNomCatMod.Text = dgvCategorias.CurrentRow.Cells("nombre").Value.ToString()
            txtTarifaBaseModCat.Text = dgvCategorias.CurrentRow.Cells("tarifadiariabase").Value.ToString()
            txtTarifa150ModCat.Text = dgvCategorias.CurrentRow.Cells("tarifax150kmdia").Value.ToString()
            txtTarifa300ModCat.Text = dgvCategorias.CurrentRow.Cells("tarifax300kmdia").Value.ToString()
            txtKmLibreModCat.Text = dgvCategorias.CurrentRow.Cells("tarifakmlibredia").Value.ToString()
            lblcatmod.Text = txtNomCatMod.Text
            Dim estado As String
            idcategoria = dgvCategorias.CurrentRow.Cells("idcategoria").Value.ToString()
            estado = dgvCategorias.CurrentRow.Cells("estado").Value.ToString()
            If estado = "True" Then
                cbxModCat.SelectedItem = "Activa"

            Else
                cbxModCat.SelectedItem = "Inactiva"
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnModificarCat.Click
        If cbxModCat.SelectedItem = "Activa" Then

            Dim estadomod As String
            If cbxModCat.SelectedItem = "Activa" Then
                estadomod = "t"
            Else
                estadomod = "f"
            End If
            conexion.EjecutarNonQuery("update categoria Set tarifadiariabase='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='t', nombre = '" + txtNomCatMod.Text.ToString + "' where idcategoria='" + idcategoria + "'")
            conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
        ElseIf Not cbxcatmov.SelectedItem Is Nothing Then

            If conexion.EjecutarNonQuery("update vehiculo set idcategoria = '" + cbxcatmov.SelectedValue.ToString + "' where idcategoria='" + idcategoria + "' ", "Vehiculos") = False Then
                MsgBox("Categoria ha pasado inactiva.", MsgBoxStyle.Information, "Notificacion")
                conexion.EjecutarNonQuery("update categoria Set tarifadiariabase ='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='f', nombre = '" + txtNomCatMod.Text.ToString + "' where idcategoria='" + idcategoria + "'")
                conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
            Else
                MsgBox("Vehiculos  de esta categoria han sido trasladados satisfactoriamente a la categoria " + cbxcatmov.Text + ".", MsgBoxStyle.Information, "Notificacion")
                conexion.EjecutarNonQuery("update categoria Set tarifadiariabase ='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='f', nombre = '" + txtNomCatMod.Text.ToString + "' where idcategoria='" + idcategoria + "'")
                conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
            End If
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles inactivascategorias.CheckedChanged, btnModificarCat.Click, btncatadd.Click
        Dim filtro As String
        If inactivascategorias.Checked Then

            filtro = ""
            dgvCategorias.DataSource.Filter = filtro
        Else
            filtro = "estado = True "

            dgvCategorias.DataSource.Filter = filtro
        End If
    End Sub

    Private Sub cbxModCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxModCat.SelectedIndexChanged
        If cbxModCat.SelectedItem = "Inactiva" Then



            pnlcatmov.Enabled = True

        Else
            pnlcatmov.Enabled = False

        End If
    End Sub

    Private Sub btnVehiculo_Click(sender As Object, e As EventArgs) Handles btnVehiculo.Click

    End Sub



    Private Sub cbxSucursalHacia_Click(sender As Object, e As EventArgs) Handles cbxSucursalHacia.Click
        If cbxSucursalDesde.SelectedItem Is Nothing Then
            MsgBox("Primero debes seleccionar sucursal Desde")
        Else
            CargarDatosComboBox(cbxSucursalHacia, conexion.EjecutarSelect("SELECT * FROM sucursal where estado = 't' and idsucursal !='" + cbxSucursalDesde.SelectedValue.ToString + "'"), "nombre", "idsucursal")
        End If

    End Sub

    Private Sub cbxSucursalDesde_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSucursalDesde.SelectedIndexChanged
        cbxSucursalHacia.SelectedItem = Nothing
    End Sub

    Private Sub btnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        Dim datosvacios As Boolean = False
        For Each control In pnlMovimientoVeh.Controls
            If TypeOf (control) Is ComboBox Then
                If DirectCast(control, ComboBox).SelectedItem Is Nothing Then

                    datosvacios = True
                End If

            ElseIf (TypeOf (control) Is NumericUpDown) Then
                If DirectCast(control, NumericUpDown).Value = 0 Then

                    datosvacios = True
                End If
            End If
        Next
        If Not datosvacios Then
            Dim vehiculosposiblesamover As Integer = conexion.EjecutarSelect(" SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
         FROM vehiculo v, modelo mo, tipo t
        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'
").Rows.Count
            If vehiculosposiblesamover = 0 Then
                MsgBox("No tienes vehiculos de estas caracteristicas en esta sucursal, intenta con otra nuevamente.")
            ElseIf vehiculosposiblesamover < NupCantidadHacia.Value Then

                Dim decision As MsgBoxResult = MsgBox("Solo puedes mover " + vehiculosposiblesamover.ToString + " con estas caracteristicas, desea continuar?", MsgBoxStyle.YesNo)
                If decision = MsgBoxResult.Yes Then
                    conexion.EjecutarNonQuery("update vehiculo set idsucursal=" + cbxSucursalHacia.SelectedValue.ToString + "

        WHERE nrochasis IN
           (Select nrochasis from (
        SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
         FROM vehiculo v, modelo mo, tipo t
        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'

         ))
        ")
                    MsgBox("Se movieron " + vehiculosposiblesamover.ToString + " vehiculos desde " + cbxSucursalDesde.Text + ", hacia " + cbxSucursalHacia.Text + " Satisfactoriamente.")
                    conexion.RellenarDataGridView(dgvVehiculoXSucursal, "
select s.nombre, count(v.nrochasis)cantidad from sucursal s, vehiculo v
where s.idsucursal=v.idsucursal
group by s.nombre

")
                Else


                End If
            Else
                conexion.EjecutarNonQuery("update vehiculo set idsucursal=" + cbxSucursalHacia.SelectedValue.ToString + "

        WHERE nrochasis IN
           (Select nrochasis from (
        SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
         FROM vehiculo v, modelo mo, tipo t
        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'

         ))
        ")
 MsgBox("Se movieron " + vehiculosposiblesamover.ToString + " vehiculos desde " + cbxSucursalDesde.Text + ", hacia " + cbxSucursalHacia.Text + " Satisfactoriamente.")

                conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal, 1)
Cantidad  FROM
Categoria C, Sucursal S

group by s.nombre, cantidad, c.idcategoria
order by s.nombre





")


            End If
        Else
            MsgBox("No puedes dejar campos vacios ni la cantidad de vehiculos puede ser 0")
        End If



    End Sub

    Private Sub cbxCategoriaFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategoriaFilter.SelectionChangeCommitted


        Dim filtro As String
        filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
        dgvVehiculoXSucursal.DataSource.Filter = filtro
        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False

    End Sub

    Private Sub cbxTipoFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTipoFilter.SelectionChangeCommitted

        conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal," + cbxTipoFilter.SelectedValue.ToString + ")
Cantidad  FROM
Categoria C, Sucursal S

group by s.nombre, cantidad, c.idcategoria
order by s.nombre





")
        Dim filtro As String
        filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
        dgvVehiculoXSucursal.DataSource.Filter = filtro
        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False
    End Sub
End Class
