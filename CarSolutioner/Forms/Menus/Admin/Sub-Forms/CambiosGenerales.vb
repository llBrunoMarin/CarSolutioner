Public Class frmCambiosGenerales

    Private Sub frmCambiosGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbcTabControl.ItemSize = New Size(0, 1)
        btnSucursales.PerformClick()
        'CargarDatosComboBox(cbxSucursalDesde, conexion.EjecutarSelect("SELECT * FROM sucursal where estado = 't'"), "nombre", "idsucursal")
        'cbxSucursalDesde.SelectedItem = Nothing
        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False
        conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
        conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM MARCA")
        conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")

        conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
        chboxInactivosModelos.Checked = True
        chboxInactivasMarcas.Checked = True
        'CargarDatosComboBox(cbxTipoFilter, conexion.Tipos, "nombre", "idtipo")

        CargarDatosComboBox(cboxTipoModelo, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cboxMarcasModelo, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cboxModeloModificarMarca, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxTipoModeloModificar, conexion.Tipos, "nombre", "idtipo")
        'cbxTipoFilter.SelectedItem = 1

















        '        conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
        'c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal," + cbxTipoFilter.SelectedValue.ToString + ")
        'Cantidad  FROM
        'Categoria C, Sucursal S

        'group by s.nombre, cantidad, c.idcategoria
        'order by s.nombre





        '")
        '        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False
        'CargarDatosComboBox(cbxCategoriaFilter, conexion.EjecutarSelect("Select * from categoria where estado='t'"), "nombre", "idcategoria")
        'CargarDatosComboBox(cbxCategoriaHacia, conexion.EjecutarSelect("Select * from categoria where estado='t'"), "nombre", "idcategoria")
        'cbxCategoriaHacia.SelectedItem = Nothing
        'CargarDatosComboBox(cbxTipoHacia, conexion.EjecutarSelect("SELECT * FROM tipo where estado = 't'"), "nombre", "idtipo")
        'cbxTipoHacia.SelectedItem = Nothing
        dgvCategorias.Columns("idcategoria").Visible = False
        chboxsucinactivas.Checked = True
        inactivascategorias.Checked = True
        chboxTiposInactivos.Checked = True
        Dim filtro As String
        'cbxCategoriaFilter.SelectedItem = 1
        'filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
        'dgvVehiculoXSucursal.DataSource.Filter = filtro
        chboxInactivosModelos.Checked = True
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
                SetTabAndColors(btnVehiculo, tbpVehiculos, Color.White)










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



        If Not (txtTelSuc1.Text = "" Or txtNomSuc.Text = "" Or txtDicSuc.Text = "" Or txtCidSuc.Text = "") Then
            If txttelefono2suc.Text = "" Then
                txttelefono2suc.Text = "-"
            End If
            Dim variable As String = "INSERT INTO sucursal values (0, '" + txtNomSuc.Text.ToString + "', '" + txtCidSuc.Text.ToString + "', '" + txtDicSuc.Text.ToString + "', '" + txtTelSuc1.Text.ToString + "','" + txttelefono2suc.Text.ToString + "','T')"
            If conexion.EjecutarNonQuery(variable) Then
                'TE KREISTE Q LO ROMPISTE PPERO NOOOOOO JAAAAAJAJAJAJ ES PERFEKTO MI PROGRAMA
                MsgBox("Sucursal agregada")
                conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
                If chboxsucinactivas.Checked Then
                    conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
                    dgvSucursales.Columns("idsucursal").Visible = False

                Else
                    conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
                End If
                For Each con As Control In pnlsuccambios.Controls
                    VaciarControl(con)
                Next
            Else

                MsgBox("No puedes agregar una sucursal en el mismo lugar que otra")
            End If
        Else
            MsgBox("Debes rellenar los campos obligatorios")
            End If




    End Sub

    Private Sub dgvSucursales_s(ByVal sender As Object, ByVal e As EventArgs) Handles dgvSucursales.SelectionChanged
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

        If Not (txttelefonosucmod1.Text = "" Or txtnombresucmod.Text = "" Or txtciudadsucmod.Text = "" Or txtdireccionsucmod.Text = "") Then
            Dim estado As String
            If txttelefonosucmod2.Text = "" Then
                txttelefonosucmod2.Text = "-"
            End If

            If cboxestadosucmod.SelectedItem = "Activa" Then

                estado = "t"

                conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text.ToString + "', direccion = '" + txtdireccionsucmod.Text.ToString + "', telefono1 = '" + txttelefonosucmod1.Text.ToString + "', telefono2 = '" + txttelefonosucmod2.Text.ToString + "', ciudad = '" + txtciudadsucmod.Text.ToString + "', estado = '" + estado.ToString + "' where idsucursal = '" + idsucursalmod + "'")
                conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                dgvSucursales.Columns("idsucursal").Visible = False
                MsgBox("Sucursal modificada")
            ElseIf Not cboxsucursalmov.SelectedItem Is Nothing Then
                Dim ReservasActivas As DataTable = conexion.EjecutarSelect("Select idreserva from reserva where estado = 1 and ( idsucursalllegada = '" + idsucursalmod + "' or idsucursalsalida = '" + idsucursalmod + "')")
                If ReservasActivas.Rows.Count = 0 Then
                    estado = "f"
                    If conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = " + cboxsucursalmov.SelectedValue.ToString + " where idsucursal = " + idsucursalmod + "", " Vehiculos, debido a que esta sucursal no poseia vehiculos.") Then

                        MsgBox("Vehiculos trasladados satisfactoriamente a " + cboxsucursalmov.Text + ". La sucursal se declara inactiva.", MsgBoxStyle.Information, "Notificacion")
                        conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
                        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                        dgvSucursales.Columns("idsucursal").Visible = False

                    Else
                        MsgBox("La sucursal ha sido modificada.", MsgBoxStyle.Information, "Notificacion")

                        conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = 'f' where idsucursal = '" + idsucursalmod + "'")
                        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                    End If

                Else
                    MsgBox("Tienes reservas activas en esta sucursal, no puede ser dada de baja hasta que las reservas sean derivadas manualmente.", MsgBoxStyle.Exclamation, "Notificacion")
                End If
            ElseIf pnlmovimiento.Enabled = False Then
                estado = "f"
                conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = " + txttelefonosucmod1.Text.ToString + ", telefono2 = " + txttelefonosucmod2.Text.ToString + ", ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
                conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                dgvSucursales.Columns("idsucursal").Visible = False
                MsgBox("Sucursal modificada")
            Else
                MsgBox("Imposible dar de baja, verifica que esta sucursal no es la ultima y que has seleccionado una sucursal a la cual mover los vehiculos de la sucursal seleccionada.")
            End If
        Else
            MsgBox("Debes rellenar los campos")
        End If
    End Sub

    Private Sub btncatadd_Click(sender As Object, e As EventArgs) Handles btncatadd.Click

        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlcatcambios.Controls
            If TypeOf (ctrl) Is TextBox Then
                If ctrl.Text = "" Then
                    FaltaDato = True
                    Exit For
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next
        If Not FaltaDato = True Then

            If conexion.EjecutarNonQuery("Insert into categoria values (0, " + txttarifabasecatadd.Text + "," + txttarifa150catadd.Text + "," + txttarifa300catadd.Text + "," + txttarifalibrecatadd.Text + ",'" + txtnomcatadd.Text + "','T')") Then
                conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
                dgvCategorias.Columns("idcategoria").Visible = False
                For Each con As Control In pnlcatcambios.Controls
                    VaciarControl(con)
                Next
            Else
                MsgBox("Precios no validos")
            End If
        Else
                MsgBox("Faltan datos en los campos obligatorios.")
        End If
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

    Private Sub btndeletesuc_Click(sender As Object, e As EventArgs)

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

            If conexion.EjecutarSelect("Select matricula from vehiculo where idsucursal='" + idsucursalmod + "'").Rows.Count > 0 Then

                pnlmovimiento.Enabled = True
            Else
                pnlmovimiento.Enabled=false
            End If
        Else
                pnlmovimiento.Enabled = False

        End If
    End Sub

    Private Sub cboxsucursalmov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxsucursalmov.Click

        Cargando(500)
        CargarDatosComboBox(cboxsucursalmov, conexion.EjecutarSelect("SELECT * FROM sucursal where idsucursal != " + idsucursalmod + "  and estado = 't'"), "nombre", "idsucursal")
    End Sub
    Private Sub cbxcatmov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxcatmov.Click

        Cargando(500)
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
        Dim faltadato As Boolean
        For Each ctrl As Control In pnlmodificarcat.Controls
            If TypeOf (ctrl) Is TextBox Then
                If ctrl.Text = "" Then
                    FaltaDato = True
                    Exit For
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next
        If Not faltadato = True Then

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
            ElseIf pnlcatmov.Enabled = False Then

                conexion.EjecutarNonQuery("update categoria Set tarifadiariabase='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='f', nombre = '" + txtNomCatMod.Text.ToString + "' where idcategoria='" + idcategoria + "'")
                conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
                MsgBox("Categoria inactiva")
            Else
                MsgBox("Imposible dar de baja, asegurate que has seleccionado una categoria a la cual mover los vehiculos. O verifica que esta no sea tu ultima categoria.")
            End If
        Else
            MsgBox("Faltan datos en los campos obligatorios")
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

            If conexion.EjecutarSelect("Select matricula from vehiculo where idcategoria='" + dgvCategorias.CurrentRow.Cells("idcategoria").Value.ToString() + "'").Rows.Count > 0 Then
                pnlcatmov.Enabled = True
            Else
                pnlcatmov.Enabled = False
            End If
        Else
            pnlcatmov.Enabled = False

        End If
    End Sub

    Private Sub btnVehiculo_Click(sender As Object, e As EventArgs) Handles btnVehiculo.Click

    End Sub

    Private Sub numeros(sender As Object, e As KeyPressEventArgs) Handles txttarifa150catadd.KeyPress, txttarifa300catadd.KeyPress, txttarifabasecatadd.KeyPress, txttarifalibrecatadd.KeyPress, txtTarifa150ModCat.KeyPress, txtTarifaBaseModCat.KeyPress, txtTarifa300ModCat.KeyPress, txtKmLibreModCat.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    '    Private Sub cbxSucursalHacia_Click(sender As Object, e As EventArgs)
    '        If cbxSucursalDesde.SelectedItem Is Nothing Then
    '            MsgBox("Primero debes seleccionar sucursal Desde")
    '        Else
    '            CargarDatosComboBox(cbxSucursalHacia, conexion.EjecutarSelect("SELECT * FROM sucursal where estado = 't' and idsucursal !='" + cbxSucursalDesde.SelectedValue.ToString + "'"), "nombre", "idsucursal")
    '        End If

    '    End Sub

    '    Private Sub cbxSucursalDesde_SelectedIndexChanged(sender As Object, e As EventArgs)
    '        cbxSucursalHacia.SelectedItem = Nothing
    '    End Sub

    '    Private Sub btnMover_Click(sender As Object, e As EventArgs)
    '        Dim datosvacios As Boolean = False
    '        For Each control In pnlMovimientoVeh.Controls
    '            If TypeOf (control) Is ComboBox Then
    '                If DirectCast(control, ComboBox).SelectedItem Is Nothing Then

    '                    datosvacios = True
    '                End If

    '            ElseIf (TypeOf (control) Is NumericUpDown) Then
    '                If DirectCast(control, NumericUpDown).Value = 0 Then

    '                    datosvacios = True
    '                End If
    '            End If
    '        Next
    '        If Not datosvacios Then
    '            Dim vehiculosposiblesamover As Integer = conexion.EjecutarSelect(" SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
    '         FROM vehiculo v, modelo mo, tipo t
    '        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
    '        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'
    '").Rows.Count
    '            If vehiculosposiblesamover = 0 Then
    '                MsgBox("No tienes vehiculos de estas caracteristicas en esta sucursal, intenta con otra nuevamente.")
    '            ElseIf vehiculosposiblesamover < NupCantidadHacia.Value Then

    '                Dim decision As MsgBoxResult = MsgBox("Solo puedes mover " + vehiculosposiblesamover.ToString + " con estas caracteristicas, desea continuar?", MsgBoxStyle.YesNo)
    '                If decision = MsgBoxResult.Yes Then
    '                    conexion.EjecutarNonQuery("update vehiculo set idsucursal=" + cbxSucursalHacia.SelectedValue.ToString + "

    '        WHERE nrochasis IN
    '           (Select nrochasis from (
    '        SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
    '         FROM vehiculo v, modelo mo, tipo t
    '        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
    '        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'

    '         ))
    '        ")
    '                    MsgBox("Se movieron " + vehiculosposiblesamover.ToString + " vehiculos desde " + cbxSucursalDesde.Text + ", hacia " + cbxSucursalHacia.Text + " Satisfactoriamente.")
    '                    conexion.RellenarDataGridView(dgvVehiculoXSucursal, "
    'select s.nombre, count(v.nrochasis)cantidad from sucursal s, vehiculo v
    'where s.idsucursal=v.idsucursal
    'group by s.nombre

    '")
    '                Else


    '                End If
    '            Else
    '                conexion.EjecutarNonQuery("update vehiculo set idsucursal=" + cbxSucursalHacia.SelectedValue.ToString + "

    '        WHERE nrochasis IN
    '           (Select nrochasis from (
    '        SELECT first " + NupCantidadHacia.Value.ToString + " nrochasis
    '         FROM vehiculo v, modelo mo, tipo t
    '        where idcategoria='" + cbxCategoriaHacia.SelectedValue.ToString + "' and
    '        V.IDMODELO=mo.idmodelo and t.idtipo=mo.idtipo and t.idtipo='" + cbxTipoHacia.SelectedValue.ToString + "' and idsucursal='" + cbxSucursalDesde.SelectedValue.ToString + "'

    '         ))
    '        ")
    '                MsgBox("Se movieron " + vehiculosposiblesamover.ToString + " vehiculos desde " + cbxSucursalDesde.Text + ", hacia " + cbxSucursalHacia.Text + " Satisfactoriamente.")

    '                conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
    'c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal, 1)
    'Cantidad  FROM
    'Categoria C, Sucursal S

    'group by s.nombre, cantidad, c.idcategoria
    'order by s.nombre





    '")


    '            End If
    '        Else
    '            MsgBox("No puedes dejar campos vacios ni la cantidad de vehiculos puede ser 0")
    '        End If



    '    End Sub

    '    Private Sub cbxCategoriaFilter_SelectedIndexChanged(sender As Object, e As EventArgs)


    '        Dim filtro As String
    '        filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
    '        dgvVehiculoXSucursal.DataSource.Filter = filtro
    '        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False

    '    End Sub

    '    Private Sub cbxTipoFilter_SelectedIndexChanged(sender As Object, e As EventArgs)

    '        conexion.RellenarDataGridView(dgvVehiculoXSucursal, "SELECT s.nombre,
    'c.idcategoria,CantVehCatSuc(c.idcategoria, s.idsucursal," + cbxTipoFilter.SelectedValue.ToString + ")
    'Cantidad  FROM
    'Categoria C, Sucursal S

    'group by s.nombre, cantidad, c.idcategoria
    'order by s.nombre





    '")
    '        Dim filtro As String
    '        filtro = " idcategoria = " + cbxCategoriaFilter.SelectedValue.ToString + ""
    '        dgvVehiculoXSucursal.DataSource.Filter = filtro
    '        dgvVehiculoXSucursal.Columns("idcategoria").Visible = False
    '    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub



    Private Sub dgvTipos_CellContentClick(sender As Object, e As EventArgs) Handles dgvTipos.SelectionChanged
        If Not IsNothing(dgvTipos.CurrentRow) Then
            txtModificarTipo.Text = dgvTipos.CurrentRow.Cells("nombre").Value.ToString()
            If dgvTipos.CurrentRow.Cells("estado").Value.ToString() = True Then
                BtnEliminarTipo.Text = "Baja"
            Else
                BtnEliminarTipo.Text = "Alta"
            End If
        End If
    End Sub

    Private Sub btnModificarTipo_Click(sender As Object, e As EventArgs) Handles btnModificarTipo.Click

        Dim idtipo As String = dgvTipos.CurrentRow.Cells("idtipo").Value.ToString()

            If txtModificarTipo.Text = dgvTipos.CurrentRow.Cells("nombre").Value.ToString() Then
                AmaranthMessagebox("No has hecho ningun cambio", "Advertencia")
            ElseIf Not txtModificarTipo.Text = Nothing Then
            If conexion.EjecutarNonQuery("UPDATE TIPO Set NOMBRE='" + txtModificarTipo.Text.ToString + "' WHERE IDTIPO='" + idtipo + "'") Then
                AmaranthMessagebox("Se modifico el nombre del tipo correctamente", "Continuar")
                conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")
                txtModificarTipo.Text = dgvTipos.CurrentRow.Cells("nombre").Value.ToString()
            Else
                MsgBox("Ya existe un tipo con este nombre")
            End If
        End If

            txtBuscarTipo.Text = Nothing


    End Sub
    Private Sub chboxTiposInactivos_CheckedChanged(sender As Object, e As EventArgs) Handles chboxTiposInactivos.CheckedChanged, btnAgregarTipo.Click, BtnEliminarTipo.Click, txtBuscarTipo.TextChanged, btnModificarTipo.Click
        Dim filtro As String
        chboxsucinactivas.Checked = True
        If chboxTiposInactivos.Checked Then

            filtro = "nombre LIKE '" + txtBuscarTipo.Text + "%'"
            dgvTipos.DataSource.Filter = filtro
        Else
            filtro = "estado = True and nombre LIKE '" + txtBuscarTipo.Text + "%'"


            dgvTipos.DataSource.Filter = filtro
        End If

    End Sub
    Private Sub btnAgregarTipo_Click(sender As Object, e As EventArgs) Handles btnAgregarTipo.Click
        If Not txtNombreTipo.Text = Nothing Then

            If conexion.EjecutarNonQuery("INSERT INTO TIPO VALUES(0, '" + txtNombreTipo.Text.ToString + "','t')") = False Then
                MsgBox("No puedes insertar un tipo con el mismo nombre que uno ya existente")
                txtNombreTipo.Text = Nothing
            Else
                MsgBox("Tipo agregado correctamente")
                conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")

                txtNombreTipo.Text = Nothing

            End If
        Else
            MsgBox("Debe escribir un nombre de tipo")
        End If
        txtBuscarTipo.Text = Nothing


    End Sub

    Private Sub BtnEliminarTipo_Click(sender As Object, e As EventArgs) Handles BtnEliminarTipo.Click

        Dim idtipo As String = dgvTipos.CurrentRow.Cells("idtipo").Value.ToString()
        If conexion.EjecutarSelect("SELECT idreserva from reserva where idtipo='" + idtipo + "' and estado=1 ").Rows.Count > 0 Or conexion.EjecutarSelect("
select nrochasis from mantenimiento where
nrochasis in (Select nrochasis from vehiculo v, tipo t where
idtipo='" + idtipo + "')

").Rows.Count > 0 Then
            MsgBox("Existen Alquileres, Mantenimientos o Reservas relacionadas con este tipo.")

        ElseIf dgvTipos.CurrentRow.Cells("estado").Value.ToString() = True Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los vehiculos de este tipo seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes And conexion.EjecutarSelect("SELECT idtipo from tipo where estado = 't'").Rows.Count > 1 Then
                conexion.EjecutarNonQuery("update tipo set estado='f' where idtipo='" + idtipo + "'")
                MsgBox("El tipo " + dgvTipos.CurrentRow.Cells("nombre").Value.ToString() + " ha sido dado de baja")
                If conexion.EjecutarNonQuery("
UPDATE vehiculo set estado= 't' where idmodelo IN(
Select idmodelo from modelo m
where m.idtipo='" + idtipo + "')", "Vehiculos, debido a que este tipo no estaba asignado a ningun vehiculo") = False Then
                    MsgBox("Tipo dado de baja")
                Else
                    MsgBox("Vehiculos y Tipo dados de baja")
                End If

                conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")
            ElseIf resultado = MsgBoxResult.No Then
            Else

                MsgBox("No puedes dar de baja el ultimo tipo")
            End If


        Else

            conexion.EjecutarNonQuery("update tipo set estado='t' where idtipo='" + idtipo + "'")
                MsgBox("El tipo " + dgvTipos.CurrentRow.Cells("nombre").Value.ToString() + " ha sido dado de alta")
                conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")

            End If



            txtBuscarTipo.Text = Nothing

    End Sub




    Private Sub dgvModelos_CellContentClick(sender As Object, e As EventArgs) Handles dgvModelos.SelectionChanged
        If Not IsNothing(dgvModelos.CurrentRow) Then
            txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString()
            cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString()
            cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString()
            If dgvModelos.CurrentRow.Cells("EstadoModelo").Value.ToString() = True Then
                btnEstadoModelo.Text = "Baja"
            Else
                btnEstadoModelo.Text = "Alta"
            End If
        End If
    End Sub

    Private Sub btnEstadoModelo_Click(sender As Object, e As EventArgs) Handles btnEstadoModelo.Click
        Dim idmodelo As String = dgvModelos.CurrentRow.Cells("idmodelo").Value.ToString()





        If dgvModelos.CurrentRow.Cells("EstadoModelo").Value.ToString = False Then
            conexion.EjecutarNonQuery("Update modelo set estado='t' where idmodelo='" + idmodelo + "'")
            MsgBox("El modelo " + dgvModelos.CurrentRow.Cells("modelo").Value.ToString + " de la marca" + dgvModelos.CurrentRow.Cells("Marca").Value.ToString + " se ha dado de alta.")
            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")









        ElseIf conexion.EjecutarSelect("SELECT IDRESERVA FROM RESERVA WHERE NROCHASIS IN
(SELECT NROCHASIS FROM VEHICULO V, MODELO MO WHERE
V.IDMODELO='" + idmodelo + "' ) and estado='1'
").Rows.Count > 0 And conexion.EjecutarSelect("SELECT NROCHASIS FROM MANTENIMIENTO WHERE NROCHASIS IN(
        SELECT NROCHASIS FROM VEHICULO V, MODELO MO
        WHERE V.IDMODELO ='" + idmodelo + "')

").Rows.Count > 0 Then         'agregar un and con el mantenimiento activo companieros niapalo toco fechas
            MsgBox("No puedes cambiar el estado de este modelo porque esta siendo usado en otros registros activos.")
        Else
            Dim resultado As MsgBoxResult = MsgBox("Los vehiculos de este modelo seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes Then
                conexion.EjecutarNonQuery("UPDATE VEHICULO SET ESTADO='F' WHERE IDMODELO='" + idmodelo + "'", "Vehiculos")
                conexion.EjecutarNonQuery("UPDATE  MODELO SET ESTADO='F' WHERE IDMODELO='" + idmodelo + "'", "Modelo")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
                MsgBox("El modelo " + dgvModelos.CurrentRow.Cells("modelo").Value.ToString + " de la marca " + dgvModelos.CurrentRow.Cells("Marca").Value.ToString + " y sus respectivos Vehiculos han pasado a inactivos")

            End If
        End If







    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificarModelo.Click
        Dim idmodelo As String = dgvModelos.CurrentRow.Cells("idmodelo").Value.ToString()
        If cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then
            MsgBox("Debes realizar cambios")
        ElseIf cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then

            If conexion.EjecutarNonQuery("UPDATE MODELO SET IDMARCA=" + cboxModeloModificarMarca.SelectedValue.ToString + " WHERE IDMODELO='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Se ha modificado la marca")
            End If

            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            ElseIf txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then
            If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Se ha modificado el nombre del modelo")
            End If

                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString Then

                If conexion.EjecutarNonQuery("Update modelo set idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Se cambio solo el tipo")
                End If
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            ElseIf txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And cbxTipoModeloModificar.SelectedValue.ToString <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then
                If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                    MsgBox("Marca, nombre y tipo del modelo actualizados")
                End If
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

                If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Modificados solo tipo y nombre")
                End If
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")

            ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

                If conexion.EjecutarNonQuery("Update modelo set  idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")

            Else
                MsgBox("Modificados solo tipo y marcas")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            End If
            ElseIf cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

                If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")

            Else
                MsgBox("Modificados solo nombre y marca")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            End If
        End If
    End Sub

    Private Sub chboxInactivosModelos_CheckedChanged(sender As Object, e As EventArgs) Handles chboxInactivosModelos.CheckedChanged, txtBuscarModelos.TextChanged, btnEstadoModelo.Click, btnModificarModelo.Click

        Dim filtro As String

        If chboxInactivosModelos.Checked Then

            filtro = "nombremodelo LIKE '" + txtBuscarModelos.Text + "%' or nombremarca LIKE '" + txtBuscarModelos.Text + "%'"

        Else
            filtro = "estadomodelo = True and ( nombremodelo LIKE '" + txtBuscarModelos.Text + "%' or nombremarca LIKE '" + txtBuscarModelos.Text + "%')"


        End If

        dgvModelos.DataSource.Filter = filtro
    End Sub

    Private Sub btnAddModelo_Click(sender As Object, e As EventArgs) Handles btnAddModelo.Click
        If Not txtNombreModelo.Text = Nothing Then
            If conexion.EjecutarNonQuery("INSERT INTO MODELO VALUES (0,'" + cboxMarcasModelo.SelectedValue.ToString + "', '" + txtNombreModelo.Text.ToString + "', '" + cboxTipoModelo.SelectedValue.ToString + "', 't')") = False Then
                MsgBox("No puedes insertar un modelo que ya existe")
            Else
                MsgBox("Modelo: " + txtNombreModelo.Text + " añadido correctamente.")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where
ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
                txtNombreModelo.Text = Nothing
            End If
        End If
    End Sub
    Private Sub btnModificarMarca_Click(sender As Object, e As EventArgs) Handles btnMarcaModificar.Click
        Dim idmarca As String = dgvMarcas.CurrentRow.Cells("idmarca").Value.ToString()

        If txtModificarMarca.Text = dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString() Then
            AmaranthMessagebox("No has hecho ningun cambio", "Advertencia")
        ElseIf Not txtModificarMarca.Text = Nothing Then
            If conexion.EjecutarNonQuery("UPDATE marca Set NOMBRE='" + txtModificarMarca.Text.ToString + "' WHERE IDmarca='" + idmarca + "'") Then
                AmaranthMessagebox("Se modifico el nombre del tipo correctamente", "Continuar")
                conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM Marca")
                txtModificarTipo.Text = dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString()
            Else
                MsgBox("Esa marca ya existe actualmente.")
            End If
        Else

        End If

        txtBuscarMarcas.Text = Nothing
    End Sub
    Private Sub btnAddMarca_Click(sender As Object, e As EventArgs) Handles btnAddMarca.Click
        If Not txtNombreMarcaAgregar.Text = Nothing Then

            If conexion.EjecutarNonQuery("INSERT INTO marca VALUES(0, '" + txtNombreMarcaAgregar.Text.ToString + "','t')") = False Then
                MsgBox("No puedes insertar una marca con el mismo nombre que una ya existente")
                txtNombreMarcaAgregar.Text = Nothing
            Else
                MsgBox("Marca agregada correctamente")
                conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM Marca")

                txtNombreMarcaAgregar.Text = Nothing

            End If
        Else
            MsgBox("Debe escribir un nombre de marca")
        End If
        txtNombreMarcaAgregar.Text = Nothing

    End Sub

    Private Sub btnEstadoMarca_Click(sender As Object, e As EventArgs) Handles btnEstadoMarca.Click
        Dim idmarca As String = dgvMarcas.CurrentRow.Cells("idmarca").Value.ToString()
        If conexion.EjecutarSelect("

select idreserva from reserva where nrochasis in
(select nrochasis from vehiculo v, marca ma, modelo mo
where v.idmodelo=mo.idmodelo and mo.idmarca=ma.idmarca and ma.idmarca=" + idmarca + ")

and estado= 1 ").Rows.Count > 0 Or conexion.EjecutarSelect("
select nrochasis from mantenimiento where nrochasis in
(select nrochasis from vehiculo v, marca ma, modelo mo
where ma.idmarca=mo.idmarca and v.idmodelo=mo.idmodelo and
ma.idmarca='" + idmarca + "')

").Rows.Count > 0 Then


            MsgBox("Existen Alquileres, Mantenimientos o Reservas relacionadas con esta marca.")

        ElseIf dgvMarcas.CurrentRow.Cells("estadomarca").Value.ToString() = True Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los vehiculos de esta marca seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes And conexion.EjecutarSelect("SELECT idmarca from marca where estado = 't'").Rows.Count > 1 Then
                conexion.EjecutarNonQuery("update marca set estado='f' where idmarca='" + idmarca + "'")

                If conexion.EjecutarNonQuery("
Update vehiculo set estado='f' where nrochasis in(
                    Select nrochasis from vehiculo v, marca ma, modelo mo
where v.idmodelo = mo.idmodelo And ma.idmarca = mo.idmarca
And ma.idmarca='" + idmarca + "')
", "Vehiculos, debido a que esta marca no estaba asignada a ningun vehiculo") = False Then
                    MsgBox("Marca dada de baja")
                Else
                    MsgBox("Vehiculos y Marca dados de baja")
                End If

                conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM Marca")
            ElseIf resultado = MsgBoxResult.No Then
            Else

                MsgBox("No puedes dar de baja la ultima marca")
            End If


        Else

            conexion.EjecutarNonQuery("update marca set estado='t' where idmarca='" + idmarca + "'")
            MsgBox("La marca " + dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString() + " ha sido dado de alta")
            conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM Marca")

        End If



        txtBuscarMarcas.Text = Nothing
    End Sub
    Private Sub chboxInactivasMarcas_CheckedChanged(sender As Object, e As EventArgs) Handles chboxInactivasMarcas.CheckedChanged, txtBuscarMarcas.TextChanged, btnEstadoMarca.Click, btnMarcaModificar.Click, btnAddMarca.Click

        Dim filtro As String

        If chboxInactivasMarcas.Checked Then

            filtro = "nombre LIKE '" + txtBuscarMarcas.Text + "%'"

        Else
            filtro = "estado = True and ( nombre LIKE '" + txtBuscarMarcas.Text + "%')"


        End If

        dgvMarcas.DataSource.Filter = filtro
    End Sub

    Private Sub dgvMarcas_CellContentClick(sender As Object, e As EventArgs) Handles dgvMarcas.SelectionChanged
        If Not IsNothing(dgvMarcas.CurrentRow) Then
            txtModificarMarca.Text = dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString()
            If dgvMarcas.CurrentRow.Cells("estadomarca").Value.ToString() = True Then
                btnEstadoMarca.Text = "Baja"
            Else
                btnEstadoMarca.Text = "Alta"
            End If
        End If
    End Sub
End Class
