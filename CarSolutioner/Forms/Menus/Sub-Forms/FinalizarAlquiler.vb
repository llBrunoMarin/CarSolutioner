Public Class FinalizarAlquiler
    Public Sub New(reserva As ReservaSeleccionada)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ReservaSeleccionada = reserva
    End Sub
    Dim ReservaSeleccionada As ReservaSeleccionada

    Private Sub FinalizarAlquiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Alquiler del vehículo: " + ReservaSeleccionada.Matricula + " a nombre de: " + ReservaSeleccionada.NomCliente + ""
        txtCantidadDias.Text = If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)
        txtKMAutoAntes.Text = conexion.EjecutarSelect("SELECT kilometraje FROM Vehiculo WHERE nrochasis = '" + ReservaSeleccionada.NroChasis.ToString + "'").Rows(0)(0).ToString
        txtDeducible.Text = ReservaSeleccionada.DeducibleVehiculo
    End Sub

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtKMAutoAhora.KeyPress, txtRecargo.KeyPress
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

    Private Sub CalculoKMExcedidos(sender As Object, e As EventArgs) Handles txtKMAutoAhora.TextChanged
        Dim Diferencia As Integer
        Dim Permitidos As Integer
        If Not txtKMAutoAhora.Text = "" Then

            Diferencia = CInt(txtKMAutoAhora.Text) - CInt(txtKMAutoAntes.Text)

            If Not Diferencia < 0 Then

                Select Case ReservaSeleccionada.IdCantKM
                    Case 1


                        Permitidos = 150 * If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)

                        If Diferencia > Permitidos Then
                            lblAdvertencia.Visible = True
                            lblAdvertencia.Text = "Atención: Este cliente se pasó " + (Diferencia - Permitidos).ToString + " KM de los Kilómetros acordados. " + vbNewLine + " " + vbNewLine + " Se cobrará un recargo acorde."
                        Else
                            lblAdvertencia.Visible = False
                        End If


                    Case 2

                        Permitidos = 300 * If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)

                        If Diferencia > Permitidos Then
                            lblAdvertencia.Visible = True
                            lblAdvertencia.Text = "Atención: Este cliente se pasó " + (Diferencia - Permitidos).ToString + " KM de los Kilómetros acordados. " + vbNewLine + " " + vbNewLine + " Se cobrará un recargo acorde."
                        Else
                            lblAdvertencia.Visible = False
                        End If


                    Case 3
                        lblAdvertencia.Visible = False

                End Select

                Dim CostoTotal As Integer = ReservaSeleccionada.CostoTotal
                Dim Recargo As Integer = 0
                If Diferencia > Permitidos Then
                    Recargo = (Diferencia - Permitidos) * conexion.Categorias.Select("idcategoria = " + ReservaSeleccionada.IdCategoria.ToString + "").CopyToDataTable.Rows(0)("precioxkmexcedido")
                End If


                txtCostoTotal.Text = CostoTotal
                txtRecargo.Text = Recargo
                txtCostoTotalTotal.Text = (CostoTotal + Recargo).ToString
            End If

        End If

    End Sub

    Private Sub CompletarAlquiler(sender As Object, e As EventArgs) Handles btnAccept.Click

        If Not txtKMAutoAhora.Text = "" Then
            If Not (CInt(txtKMAutoAhora.Text) - CInt(txtKMAutoAntes.Text)) < 0 Then

                conexion.EjecutarNonQuery("UPDATE Reserva SET fechaalquilerfin = '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "', estado = 2, costototal = '" + txtCostoTotalTotal.Text + "' WHERE idreserva = '" + ReservaSeleccionada.IdReserva.ToString + "'")
                conexion.EjecutarNonQuery("UPDATE Vehiculo SET kilometraje = '" + txtKMAutoAhora.Text + "', idsucursal = '" + ReservaSeleccionada.IdSucursalDestino.ToString + "' WHERE nrochasis = '" + ReservaSeleccionada.NroChasis.ToString + "'")
                CargarTodosDatos(Me.Owner)

                AmaranthMessagebox("Alquiler finalizado satisfactoriamente.", "Continuar")
                Me.Dispose()

            Else
                AmaranthMessagebox("El kilometraje actual no puede ser menor al de salida. Por favor verifique.", "Error", Me)
            End If
        Else
            AmaranthMessagebox("Por favor, especifique el kilometraje actual del vehículo.", "Error", Me)
        End If
    End Sub

    Private Sub btnCerrarMsgbox_Click(sender As Object, e As EventArgs) Handles btnCerrarMsgbox.Click
        Me.Dispose()
    End Sub

    Private Sub btnAgregarDescuentoAlquiler_Click(sender As Object, e As EventArgs) Handles btnAgregarDescuentoAlquiler.Click
        If Autorizar(Me) = vbYes Then
            txtRecargo.Enabled = True
        End If
    End Sub
End Class