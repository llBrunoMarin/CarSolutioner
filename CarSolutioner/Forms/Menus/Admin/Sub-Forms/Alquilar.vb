Public Class frmAlquilar

    Dim ReservaSeleccionada As New ReservaSeleccionada
    Dim Vista As VistaAlquilar

    Public Enum VistaAlquilar
        Normal
        Editado
    End Enum

    Public Sub New(Disponibles As DataTable, vista As VistaAlquilar, Reserva As ReservaSeleccionada)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ReservaSeleccionada = Reserva
        ReservaSeleccionada.AutosDisponibles = Disponibles

        Select Case vista
            Case VistaAlquilar.Normal
                Me.Vista = VistaAlquilar.Normal
                lblAdvertencia.Size = New Size(336, 77)
                lblAdvertencia.Location = New Point(291, 173)
                lblCategoriaAntigua.Visible = False
                txtCategoriaAntigua.Visible = False
                chboxCobrarEstaCat.Visible = False
                ReservaSeleccionada.IdNuevaCategoria = ReservaSeleccionada.IdCategoria

            Case VistaAlquilar.Editado
                Me.Vista = VistaAlquilar.Editado
                lblAdvertencia.Size = New Size(336, 33)
                lblCategoriaAntigua.Visible = True
                txtCategoriaAntigua.Visible = True
                chboxCobrarEstaCat.Visible = True
                txtCategoriaAntigua.Text = conexion.Categorias.Select("idcategoria =" + Reserva.IdCategoria.ToString() + "").CopyToDataTable.Rows(0)(5).ToString()

        End Select
    End Sub
    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Load

        'Rellenamos el DataGridView con los autos disponibles en ese momento, en esa sucursal, que no estén en mantenimiento

        conexion.RellenarDataGridView(dgvAlquilar, "", ReservaSeleccionada.AutosDisponibles)

        CargarDatosComboBox(cbxSucLlegada, conexion.Sucursales, "nombre", "idsucursal")
        cbxSucLlegada.SelectedValue = ReservaSeleccionada.IdSucursalDestino

        CargarDatosComboBox(cbxKilometraje, conexion.Kilometros, "km", "id")
        cbxKilometraje.SelectedValue = ReservaSeleccionada.IdCantKM
        cbxKilometraje.Enabled = False

        'estos llenan los datetime picker
        'TODO: LAS FECHAS DE ALQUILER NO SE DEBEN SETEAR ASÍ
        dtpFRInicio.Value = ReservaSeleccionada.FechaReservaInicio
        dtpFRfin.Value = ReservaSeleccionada.FechaReservaFin
        dtpFRfin.MinDate = Date.Now.AddHours(24)
        dtpFAinicio.Value = Date.Now.ToString("dd/MM/yyyy HH:mm")

        lblTitulo.Text = "Vehiculos para la reserva de: " + ReservaSeleccionada.NomCliente
        txtTipo.Text = conexion.Tipos.Select("idtipo =" + ReservaSeleccionada.IdTipo.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
        txtCategoria.Text = conexion.Categorias.Select("idcategoria =" + ReservaSeleccionada.IdNuevaCategoria.ToString() + "").CopyToDataTable.Rows(0)(5).ToString()
        txtSucursal.Text = conexion.Sucursales.Select("idsucursal =" + ReservaSeleccionada.IdSucursalPartida.ToString() + "").CopyToDataTable.Rows(0)(1).ToString()
        txtCantidadDias.Text = (dtpFRfin.Value - dtpFAinicio.Value).Days.ToString
        numDescuentoCliente.Value = CargarDescuentoCliente(ReservaSeleccionada.IdCliente)
        txtCostoEsperado.Text = ReservaSeleccionada.CostoTotal.ToString

    End Sub

    Private Sub CalculoCosto(sender As Object, e As EventArgs) Handles dtpFRfin.ValueChanged, dtpFAinicio.ValueChanged, numDescuentoCliente.ValueChanged, numDescuentoReserva.ValueChanged, chboxCobrarEstaCat.CheckedChanged

        Dim TarifaDiariaBase As Integer
        Dim TarifaDiariaKM As Integer
        Dim CostoReservaEstimado As Integer
        Dim DescuentoCalcCliente As Integer
        Dim DescuentoCalcReserva As Integer
        Dim CostoTotal As Integer
        Select Case chboxCobrarEstaCat.Checked
            Case True
                Select Case ReservaSeleccionada.IdCantKM
                    Case 1
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (150 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (150 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva. " + vbNewLine + "De lo contrario, se cobrará un recargo acorde por kilómetro excedido."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(2).ToString)

                    Case 2
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (300 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (300 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva. " + vbNewLine + "De lo contrario, se cobrará un recargo acorde por kilómetro excedido."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
                    Case 3
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer los kilómetros que quiera en toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer los kilómetros que quiera en toda la reserva. " + vbNewLine + " No se cobrará ningun tipo de recargo en función al kilometraje."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)
                End Select
            Case False
                Select Case ReservaSeleccionada.IdCantKM
                    Case 1
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (150 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (150 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva. " + vbNewLine + "De lo contrario, se cobrará un recargo acorde por kilómetro excedido."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(2).ToString)

                    Case 2
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (300 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer un total de " + (300 * (dtpFRfin.Value - dtpFAinicio.Value).Days).ToString + " kilómetros en total de toda la reserva. " + vbNewLine + "De lo contrario, se cobrará un recargo acorde por kilómetro excedido."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
                    Case 3
                        If Me.Vista = VistaAlquilar.Normal Then
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer los kilómetros que quiera en toda la reserva."
                        Else
                            lblAdvertencia.Text = "Esto quiere decir que el cliente podrá recorrer los kilómetros que quiera en toda la reserva. " + vbNewLine + " No se cobrará ningun tipo de recargo en función al kilometraje."

                        End If
                        TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                        TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)
                End Select
        End Select



        CostoReservaEstimado = (TarifaDiariaBase + TarifaDiariaKM) * ((dtpFRfin.Value - dtpFAinicio.Value).Days)
        DescuentoCalcCliente = (CostoReservaEstimado * numDescuentoCliente.Value) / 100

        CostoTotal = CostoReservaEstimado - DescuentoCalcCliente

        DescuentoCalcReserva = (CostoTotal * numDescuentoReserva.Value) / 100
        CostoTotal = CostoTotal - DescuentoCalcReserva

        ReservaSeleccionada.CostoTotal = CostoTotal

        txtCostoEsperado.Text = CostoReservaEstimado.ToString()
        txtCostoTotalEsperado.Text = CostoTotal.ToString()
        txtCantidadDias.Text = (dtpFRfin.Value - dtpFAinicio.Value).Days.ToString

    End Sub
    'Doble click en el dgv alquilar, o click en el botón Alquilar
    Public Sub AlquilarAutoSeleccionado(sender As Object, e As EventArgs) Handles dgvAlquilar.CellMouseDoubleClick, btnAlquilar.Click

        Dim selectedRow As DataGridViewRow

        If sender Is dgvAlquilar Then
            selectedRow = dgvAlquilar.Rows(DirectCast(e, DataGridViewCellMouseEventArgs).RowIndex)
        Else
            selectedRow = dgvAlquilar.CurrentRow
        End If

        Dim NroChasis As String = selectedRow.Cells("nrochasis").Value.ToString

        'Dim resultado As DialogResult = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        Dim resultado As DialogResult = AmaranthMessagebox("¿Estás seguro que deseas alquilar el vehículo?", "Si/No")
        If resultado = vbYes Then

            'Actualiza la Reserva para que sea un ALQUILER, con NroChasis = al seleccionado, fechaalquilerinicio = hoy, fechareservafin = seleccionada (en caso que el cliente cambie su fecha reserva fin)
            conexion.EjecutarNonQuery("UPDATE Reserva SET nrochasis = '" + NroChasis + "', idsucursalllegada = '" + cbxSucLlegada.SelectedValue.ToString + "', fechaalquilerinicio = '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "', fechareservafin = '" + dtpFRfin.Value.ToString("yyyy-MM-dd HH:mm") + "' WHERE idreserva = " + ReservaSeleccionada.IdReserva.ToString + " ")
            conexion.EjecutarNonQuery("UPDATE vehiculo set idsucursal = NULL WHERE nrochasis='" + NroChasis + "'")
            MsgBox("Alquiler Ingresado")
            Me.Dispose()
            frmMainMenu.CargarDatos()


        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub


    Private Function CargarDescuentoCliente(id As Integer) As Integer
        Return CInt(conexion.EjecutarSelect("SELECT porcdescuento FROM Cliente WHERE idpersona = '" + id.ToString + "'").Rows(0)(0).ToString)
    End Function

    Private Sub btnDescuentoCliente_Click(sender As Object, e As EventArgs) Handles btnDescuentoCliente.Click
        If Autorizar(Me) = vbYes Then

            Dim descuento As New DescuentoPersonalCliente(ReservaSeleccionada.IdCliente)
            descuento.ShowDialog()
            numDescuentoCliente.Enabled = True
            numDescuentoCliente.Value = CargarDescuentoCliente(ReservaSeleccionada.IdCliente)
            numDescuentoCliente.Enabled = False
        Else

        End If
    End Sub

    Private Sub btnDescuentoReserva_Click(sender As Object, e As EventArgs) Handles btnDescuentoReserva.Click
        If Autorizar(Me) = vbYes Then
            numDescuentoReserva.Enabled = True
            lblDescuentoReserva.Text = "(Haga click para aplicar descuento) " + vbNewLine + " Escriba un numero y presione Enter"
        End If
    End Sub

    Private Sub chboxCobrarEstaCat_CheckedChanged(sender As Object, e As EventArgs) Handles chboxCobrarEstaCat.Click

        If Autorizar(Me) = vbYes Then
            chboxCobrarEstaCat.Checked = True
        Else
            chboxCobrarEstaCat.Checked = False
        End If
    End Sub
End Class