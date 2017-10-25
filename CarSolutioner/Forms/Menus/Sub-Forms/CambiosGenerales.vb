Public Class frmCambiosGenerales

    Private Sub frmCambiosGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbcTabControl.ItemSize = New Size(0, 1)

        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False
        conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
        conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM MARCA")
        conexion.RellenarDataGridView(dgvTipos, "SELECT * FROM TIPO")

        conexion.RellenarDataGridView(dgvDocumentos, "Select * from tipodocumento")
        conexion.RellenarDataGridView(dgvDocxCliente, "select doc.nombre, count(idpersona) Cantidad from tipodocumento doc, cliente c where doc.idtipodoc=c.idtipodoc group by nombre")
        conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")


        conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")

        chboxInactivosModelos.Checked = True
        chboxInactivasMarcas.Checked = True
        CargarDatosComboBox(cboxTipoModelo, conexion.Tipos, "nombre", "idtipo")
        CargarDatosComboBox(cboxMarcasModelo, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cboxModeloModificarMarca, conexion.Marcas, "nombre", "idmarca")
        CargarDatosComboBox(cbxTipoModeloModificar, conexion.Tipos, "nombre", "idtipo")
        dgvCategorias.Columns("idcategoria").Visible = False
        chboxInactivotipodoc.Checked = True
        chboxsucinactivas.Checked = True
        inactivascategorias.Checked = True
        chboxTiposInactivos.Checked = True
        chboxInactivosModelos.Checked = True
        btnVehiculo.PerformClick()
    End Sub
    Dim idcategoria
    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub
    Dim idsucursalmod As String
    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnSucursales.Click, btnCategorias.Click, btnVehiculo.Click, btnDocumento.Click

        ResetColors()

        Select Case sender.Name
            Case "btnCategorias"
                SetTabAndColors(btnCategorias, tbpCategorias, Color.White)

            Case "btnSucursales"
                SetTabAndColors(btnSucursales, tbpSucursales, Color.White)

            Case "btnVehiculo"
                SetTabAndColors(btnVehiculo, tbpVehiculos, Color.White)
            Case "btnDocumento"
                SetTabAndColors(btnDocumento, tbpDocumento, Color.White)





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


        If Not IsNothing(dgvSucursales.CurrentRow) Then
            Dim nomsuc As String = dgvSucursales.CurrentRow.Cells("nombre").Value.ToString
            Dim telsuc1 As String = dgvSucursales.CurrentRow.Cells("telefono1").Value.ToString
            Dim dirsuc As String = dgvSucursales.CurrentRow.Cells("direccion").Value.ToString
            Dim telsuc2 As String = dgvSucursales.CurrentRow.Cells("telefono2").Value.ToString
            Dim cidsuc As String = dgvSucursales.CurrentRow.Cells("ciudad").Value.ToString
            Dim estadosuc As String = dgvSucursales.CurrentRow.Cells("estado").Value.ToString
            Dim cboxvalue As String
            If cboxestadosucmod.SelectedItem = "Activa" Then
                cboxvalue = "1"
            Else
                cboxvalue = "2"
            End If
            If nomsuc = txtnombresucmod.Text And cidsuc = txtciudadsucmod.Text And dirsuc = txtdireccionsucmod.Text And telsuc2 = txttelefonosucmod2.Text And telsuc1 = txttelefonosucmod1.Text And (estadosuc = "True" And cboxvalue = "1" Or estadosuc = "False" And cboxvalue = "2") Then
                MsgBox("Debe modificar algo")

            Else
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
                                conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = '" + txttelefonosucmod1.Text.ToString + "', telefono2 =' " + txttelefonosucmod2.Text.ToString + "', ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
                                conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                                dgvSucursales.Columns("idsucursal").Visible = False

                            Else
                                MsgBox("La sucursal ha sido modificada.", MsgBoxStyle.Information, "Notificacion")

                                conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 = '" + txttelefonosucmod1.Text.ToString + "', telefono2 =' " + txttelefonosucmod2.Text.ToString + "', ciudad = '" + txtciudadsucmod.Text + "', estado = 'f' where idsucursal = '" + idsucursalmod + "'")
                                conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                            End If

                        Else
                            MsgBox("Tienes reservas activas en esta sucursal, no puede ser dada de baja hasta que las reservas sean derivadas manualmente.", MsgBoxStyle.Exclamation, "Notificacion")
                        End If
                    ElseIf pnlmovimiento.Enabled = False Then
                        estado = "f"
                        conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', telefono1 =' " + txttelefonosucmod1.Text.ToString + "', telefono2 =' " + txttelefonosucmod2.Text.ToString + "', ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
                        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM sucursal")
                        dgvSucursales.Columns("idsucursal").Visible = False
                        MsgBox("Sucursal modificada")
                    Else
                        MsgBox("Imposible dar de baja, verifica que esta sucursal no es la ultima y que has seleccionado una sucursal a la cual mover los vehiculos de la sucursal seleccionada.")
                    End If
                Else
                    MsgBox("Debes rellenar los campos")
                End If
            End If
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

            If conexion.EjecutarNonQuery("Insert into categoria values (0, " + txttarifabasecatadd.Text + "," + txttarifa150catadd.Text + "," + txttarifa300catadd.Text + "," + txttarifalibrecatadd.Text + ",'" + txtnomcatadd.Text + "', '" + txtKmExcedido.Text + "', 'T')") Then
                conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
                dgvCategorias.Columns("idcategoria").Visible = False
                For Each con As Control In pnlcatcambios.Controls
                    VaciarControl(con)
                Next
            Else
                MsgBox("No se puede ingresar una categoria que ya existe")
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

        Cargando(500, Me.Owner)
        CargarDatosComboBox(cboxsucursalmov, conexion.EjecutarSelect("SELECT * FROM sucursal where idsucursal != " + idsucursalmod + "  and estado = 't'"), "nombre", "idsucursal")
    End Sub
    Private Sub cbxcatmov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxcatmov.Click

        Cargando(500, Me.Owner)
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
            txtRecargoKmextramodif.Text = dgvCategorias.CurrentRow.Cells("precioxkmexcedido").Value.ToString()
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
            Dim cboxvalue As Integer
            If cbxModCat.SelectedItem = "Activa" Then
                cboxvalue = "1"
            Else
                cboxvalue = "2"
            End If
            Dim estadocat As String = dgvCategorias.CurrentRow.Cells("estado").Value.ToString
            If txtNomCatMod.Text = dgvCategorias.CurrentRow.Cells("nombre").Value.ToString() And txtTarifaBaseModCat.Text = dgvCategorias.CurrentRow.Cells("tarifadiariabase").Value.ToString() And txtTarifa150ModCat.Text = dgvCategorias.CurrentRow.Cells("tarifax150kmdia").Value.ToString() And txtTarifa300ModCat.Text = dgvCategorias.CurrentRow.Cells("tarifax300kmdia").Value.ToString() And txtKmLibreModCat.Text = dgvCategorias.CurrentRow.Cells("tarifakmlibredia").Value.ToString() And (estadocat = "True" And cboxvalue = "1" Or estadocat = "False" And cboxvalue = "2") Then
                MsgBox("Modifique")
            Else



                If cbxModCat.SelectedItem = "Activa" Then

                    Dim estadomod As String
                    If cbxModCat.SelectedItem = "Activa" Then
                        estadomod = "t"
                    Else
                        estadomod = "f"
                    End If
                    If conexion.EjecutarNonQuery("update categoria Set tarifadiariabase='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='t', nombre = '" + txtNomCatMod.Text.ToString + "' where idcategoria='" + idcategoria + "'") Then
                        MsgBox("Modificacion exitosa")
                        conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
                    Else
                        AmaranthMessagebox("Esa categoria ya existe", "Error", Me)
                    End If
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

                    conexion.EjecutarNonQuery("update categoria Set tarifadiariabase='" + txtTarifaBaseModCat.Text.ToString + "', tarifax150kmdia = '" + txtTarifa150ModCat.Text.ToString + "', tarifax300kmdia = '" + txtTarifa300ModCat.Text.ToString + "', tarifakmlibredia =  '" + txtKmLibreModCat.Text.ToString + "', estado ='f', nombre = '" + txtNomCatMod.Text.ToString + "', precioxkmexcedido = '" + txtRecargoKmextramodif.Text.ToString + "' where idcategoria='" + idcategoria + "'")
                    conexion.RellenarDataGridView(dgvCategorias, "SELECT * FROM categoria")
                        MsgBox("Categoria inactiva")
                    Else
                    MsgBox("Imposible dar de baja. Asegurate que has seleccionado una categoria a la cual mover los vehiculos, o verifica que esta no sea tu ultima categoria.")
                End If


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

    Private Sub numeros(sender As Object, e As KeyPressEventArgs) Handles txttarifa150catadd.KeyPress, txttarifa300catadd.KeyPress, txttarifabasecatadd.KeyPress, txttarifalibrecatadd.KeyPress, txtTarifa150ModCat.KeyPress, txtTarifaBaseModCat.KeyPress, txtTarifa300ModCat.KeyPress, txtKmLibreModCat.KeyPress, txtKmExcedido.KeyPress, txtRecargoKmextramodif.KeyPress
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
            AmaranthMessagebox("No has hecho ningun cambio", "Advertencia", Me)
        ElseIf Not txtModificarTipo.Text = Nothing Then
            If conexion.EjecutarNonQuery("UPDATE TIPO Set NOMBRE='" + txtModificarTipo.Text.ToString + "' WHERE IDTIPO='" + idtipo + "'") Then
                AmaranthMessagebox("Se modifico el nombre del tipo correctamente", "Continuar", Me)
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
        Dim sentencia As String = "select v.nrochasis from vehiculo v, modelo mo where mo.idtipo=" + idtipo + " and v.idmodelo=mo.idmodelo and V.nrochasis IN (Select nrochasis FROM Mantenimiento WHERE fechainicio <=  '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and fechafin >= '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "'    )"
        If conexion.EjecutarSelect("SELECT idreserva from reserva where idtipo='" + idtipo + "' and estado=1").Rows.Count > 0 Or conexion.EjecutarSelect(sentencia).Rows.Count > 0 Then
            MsgBox("Existen Alquileres, Mantenimientos o Reservas relacionadas con este tipo.")
            MsgBox(conexion.EjecutarSelect("SELECT idreserva from reserva where idtipo='" + idtipo + "' and estado=1").Rows.Count.ToString)
            MsgBox(conexion.EjecutarSelect(sentencia).Rows.Count.ToString)
        ElseIf dgvTipos.CurrentRow.Cells("estado").Value.ToString() = True Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los vehiculos de este tipo seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes And conexion.EjecutarSelect("SELECT idtipo from tipo where estado = 't'").Rows.Count > 1 Then
                conexion.EjecutarNonQuery("update tipo set estado='f' where idtipo='" + idtipo + "'")
                MsgBox("El tipo " + dgvTipos.CurrentRow.Cells("nombre").Value.ToString() + " ha sido dado de baja")
                If conexion.EjecutarNonQuery("UPDATE vehiculo set estado= 'f' where idmodelo IN(Select idmodelo from modelo m where m.idtipo='" + idtipo + "')", "Vehiculos, debido a que este tipo no estaba asignado a ningun vehiculo") = False Then
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

            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
        ElseIf txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then
            If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Se ha modificado el nombre del modelo")
            End If

            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
        ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString Then

            If conexion.EjecutarNonQuery("Update modelo set idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Se cambio solo el tipo")
            End If
            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
        ElseIf txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString And cbxTipoModeloModificar.SelectedValue.ToString <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString Then
            If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Marca, nombre y tipo del modelo actualizados")
            End If
            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
        ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue = dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

            If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")
            Else
                MsgBox("Modificados solo tipo y nombre")
            End If
            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")

        ElseIf cbxTipoModeloModificar.SelectedValue <> dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text = dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

            If conexion.EjecutarNonQuery("Update modelo set  idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "', idtipo='" + cbxTipoModeloModificar.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")

            Else
                MsgBox("Modificados solo tipo y marcas")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            End If
        ElseIf cbxTipoModeloModificar.SelectedValue = dgvModelos.CurrentRow.Cells("idtipo_mod").Value.ToString And txtNombreModeloModificar.Text <> dgvModelos.CurrentRow.Cells("modelo").Value.ToString And cboxModeloModificarMarca.SelectedValue <> dgvModelos.CurrentRow.Cells("idmarca_mod").Value.ToString Then

            If conexion.EjecutarNonQuery("Update modelo set nombre='" + txtNombreModeloModificar.Text.ToString + "', idmarca='" + cboxModeloModificarMarca.SelectedValue.ToString + "' where idmodelo='" + idmodelo + "'") = False Then
                MsgBox("Ya existe otro modelo con estas caracteristicas")

            Else
                MsgBox("Modificados solo nombre y marca")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
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
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
                txtNombreModelo.Text = Nothing
            End If
        Else
            MsgBox("Debes ingresar un nombre")
        End If
    End Sub
    Private Sub btnModificarMarca_Click(sender As Object, e As EventArgs) Handles btnMarcaModificar.Click
        Dim idmarca As String = dgvMarcas.CurrentRow.Cells("idmarca").Value.ToString()


        If txtModificarMarca.Text = dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString() Then
            AmaranthMessagebox("No has hecho ningun cambio", "Advertencia", Me)
        ElseIf Not txtModificarMarca.Text = Nothing Then
            If conexion.EjecutarNonQuery("UPDATE marca Set NOMBRE='" + txtModificarMarca.Text.ToString + "' WHERE IDmarca='" + idmarca + "'") Then
                AmaranthMessagebox("Se modifico el nombre de la marca correctamente", "Continuar", Me)
                conexion.RellenarDataGridView(dgvMarcas, "SELECT * FROM Marca")
                txtModificarTipo.Text = dgvMarcas.CurrentRow.Cells("nombremarca").Value.ToString()
            Else
                MsgBox("Esa marca ya existe actualmente.")
            End If
        Else

        End If

        txtBuscarMarcas.Text = Nothing
    End Sub
    Private Sub btnModificarMtipodoc(sender As Object, e As EventArgs) Handles btnModificartipodoc.Click
        Dim idtipodoc As String = dgvDocumentos.CurrentRow.Cells("idtipodoc").Value.ToString()

        If txtmodificartipodoc.Text = dgvDocumentos.CurrentRow.Cells("nombretipodoc").Value.ToString() Then
            AmaranthMessagebox("No has hecho ningun cambio", "Advertencia", Me)
        ElseIf Not txtmodificartipodoc.Text = Nothing Then
            If Not dgvDocumentos.CurrentRow.Cells("nombretipodoc").Value.ToString() = "CI UY" Then
                If conexion.EjecutarNonQuery("UPDATE tipodocumento Set NOMBRE='" + txtmodificartipodoc.Text.ToString + "' WHERE IDtipodoc='" + idtipodoc + "'") Then
                    AmaranthMessagebox("Se modifico el nombre del tipo correctamente", "Continuar", Me)
                    conexion.RellenarDataGridView(dgvDocumentos, "SELECT * FROM tipodocumento")
                    txtmodificartipodoc.Text = dgvDocumentos.CurrentRow.Cells("nombretipodoc").Value.ToString()
                Else
                    AmaranthMessagebox("Ese tipo ya existe actualmente.", "Error", Me)
                End If
            Else
                AmaranthMessagebox("No puede modificar la Cedula Uruguaya. Es un documento base.", "Error", Me)
            End If

        Else
            AmaranthMessagebox("Debe modificar algo.", "Error", Me)
        End If
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
        If conexion.EjecutarSelect("select idreserva from reserva where nrochasis in (select nrochasis from vehiculo v, marca ma, modelo mo where v.idmodelo=mo.idmodelo and mo.idmarca=ma.idmarca and ma.idmarca=" + idmarca + ") and estado= 1 ").Rows.Count > 0 Or conexion.EjecutarSelect("select v.nrochasis from vehiculo v, marca ma, modelo mo where v.idmodelo=mo.idmodelo and mo.idmarca=ma.idmarca and ma.idmarca=" + idmarca + " and V.nrochasis IN (Select nrochasis FROM Mantenimiento WHERE fechainicio <=  '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and fechafin >= '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "'    )").Rows.Count > 0 Then

            MsgBox("Existen Alquileres, Mantenimientos o Reservas relacionadas con esta marca.")

        ElseIf dgvMarcas.CurrentRow.Cells("estadomarca").Value.ToString() = True Then
            Dim resultado As MsgBoxResult
            resultado = MsgBox("Los vehiculos de esta marca seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes And conexion.EjecutarSelect("SELECT idmarca from marca where estado = 't'").Rows.Count > 1 Then
                conexion.EjecutarNonQuery("update marca set estado='f' where idmarca='" + idmarca + "'")

                If conexion.EjecutarNonQuery("Update vehiculo set estado='f' where nrochasis in( Select nrochasis from vehiculo v, marca ma, modelo mo where v.idmodelo = mo.idmodelo And ma.idmarca = mo.idmarca And ma.idmarca='" + idmarca + "')", "Vehiculos, debido a que esta marca no estaba asignada a ningun vehiculo") = False Then
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



    Private Sub dgvDocumentos_changed(ByVal sender As Object, ByVal e As EventArgs) Handles dgvDocumentos.SelectionChanged
        If Not IsNothing(dgvDocumentos.CurrentRow) Then
            txtmodificartipodoc.Text = dgvDocumentos.CurrentRow.Cells("nombretipodoc").Value.ToString
            Dim estado As String = dgvDocumentos.CurrentRow.Cells("estadotipodoc").Value.ToString
            If estado = "True" Then
                btnestadotipodoc.Text = "Baja"
            Else
                btnestadotipodoc.Text = "Alta"
            End If
        End If
    End Sub
    Private Sub btnaddtipodoc_Click(sender As Object, e As EventArgs) Handles btnaddtipodoc.Click
        If Not txtnombretipodoc.Text = "" Then
            If conexion.EjecutarNonQuery("INSERT INTO TIPODOCUMENTO VALUES(0, '" + txtnombretipodoc.Text.ToString + "', 'T')") Then
                MsgBox("Documento ingresado correctamente.")
                conexion.RellenarDataGridView(dgvDocumentos, "Select * from tipodocumento")
                txtnombretipodoc.Text = Nothing
            Else
                MsgBox("Este tipo de documento ya existe")
            End If

        End If
    End Sub

    Private Sub btnestadotipodoc_Click(sender As Object, e As EventArgs) Handles btnestadotipodoc.Click
        Dim idtipodoc As String = dgvDocumentos.CurrentRow.Cells("idtipodoc").Value.ToString
        Dim nombre As String = dgvDocumentos.CurrentRow.Cells("nombretipodoc").Value.ToString
        If idtipodoc = "1" Or idtipodoc = "2" Or idtipodoc = "3" Then
            MsgBox("No puedes eliminar tipos de documentos predefinidos por el sistema")

        ElseIf dgvDocumentos.CurrentRow.Cells("estadotipodoc").Value.ToString = "True" Then
            If conexion.EjecutarSelect("Select idpersona from cliente where idtipodoc='" + idtipodoc + "'").Rows.Count > 1 Then
                MsgBox("No puede eliminar un tipo de documento hasta que haya modificado el tipo de documento de los clientes que se registraron con el mismo.")
            Else
                conexion.EjecutarNonQuery("Update tipodocumento set estado='f' where idtipodoc='" + idtipodoc + "'")
                MsgBox("El tipo de documento ha sido dado de baja")
                conexion.RellenarDataGridView(dgvDocumentos, "Select * from tipodocumento")
            End If
        Else
            MsgBox("El tipo de documento ha sido dado de alta")
            conexion.RellenarDataGridView(dgvDocumentos, "Select * from tipodocumento")
        End If

    End Sub
    Private Sub chboxInactivotipodoc_CheckedChanged(sender As Object, e As EventArgs) Handles chboxInactivotipodoc.CheckedChanged, btnaddtipodoc.Click, btnModificartipodoc.Click, btnestadotipodoc.Click, txtbuscartipodoc.TextChanged
        Dim filtro As String
        If chboxInactivotipodoc.Checked Then
            filtro = "nombre LIKE '" + txtbuscartipodoc.Text + "%'"
            dgvDocumentos.DataSource.Filter = filtro
        Else
            filtro = "estado = True and nombre LIKE '" + txtbuscartipodoc.Text + "%'"
            dgvDocumentos.DataSource.Filter = filtro

        End If
    End Sub
    Private Sub btnEstadoModelo_Click(sender As Object, e As EventArgs) Handles btnEstadoModelo.Click
        Dim idmodelo As String = dgvModelos.CurrentRow.Cells("idmodelo").Value.ToString()


        Dim sentencia2 As String = "select v.nrochasis from vehiculo v, modelo mo where mo.idmodelo=" + idmodelo + " and v.idmodelo=mo.idmodelo and V.nrochasis IN (Select nrochasis FROM Mantenimiento WHERE fechainicio <=  '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "' and fechafin >= '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "'    )"


        If dgvModelos.CurrentRow.Cells("EstadoModelo").Value.ToString = False Then
            conexion.EjecutarNonQuery("Update modelo set estado='t' where idmodelo='" + idmodelo + "'")
            MsgBox("El modelo " + dgvModelos.CurrentRow.Cells("modelo").Value.ToString + " de la marca" + dgvModelos.CurrentRow.Cells("Marca").Value.ToString + " se ha dado de alta.")
            conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")

        ElseIf conexion.EjecutarSelect("SELECT IDRESERVA FROM RESERVA WHERE NROCHASIS IN (SELECT NROCHASIS FROM VEHICULO V, MODELO MO WHERE V.IDMODELO='" + idmodelo + "' ) and estado='1'").Rows.Count > 0 Or conexion.EjecutarSelect(sentencia2).Rows.Count > 0 Then         'agregar un and con el mantenimiento activo companieros niapalo toco fechas
            MsgBox("No puedes cambiar el estado de este modelo porque esta siendo usado en otros registros activos.")
        Else
            Dim resultado As MsgBoxResult = MsgBox("Los vehiculos de este modelo seran dados de baja, desea continuar?", MsgBoxStyle.YesNo)

            If resultado = MsgBoxResult.Yes And conexion.EjecutarSelect("SELECT IDMODELO FROM MODELO WHERE ESTADO='T'").Rows.Count > 1 Then
                conexion.EjecutarNonQuery("UPDATE VEHICULO SET ESTADO='F' WHERE IDMODELO='" + idmodelo + "'", "Vehiculos")
                conexion.EjecutarNonQuery("UPDATE  MODELO SET ESTADO='F' WHERE IDMODELO='" + idmodelo + "'", "Modelo")

                MsgBox("El modelo " + dgvModelos.CurrentRow.Cells("modelo").Value.ToString + " de la marca " + dgvModelos.CurrentRow.Cells("Marca").Value.ToString + " y sus respectivos Vehiculos han pasado a inactivos")
                conexion.RellenarDataGridView(dgvModelos, "Select mo.nombre nombremodelo, ma.nombre nombremarca, t.nombre nombretipo, mo.idmodelo, ma.idmarca, t.idtipo, mo.estado estadomodelo from modelo mo, marca ma, tipo t where ma.idmarca=mo.idmarca and t.idtipo = mo.idtipo")
            ElseIf resultado = MsgBoxResult.No Then
            Else
                MsgBox("No puede eliminar su ultimo modelo")

            End If
        End If







    End Sub

End Class
