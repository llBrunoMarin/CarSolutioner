Public Class FinalizarAlquiler
    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionadaFinalizarAlquiler

    Private Sub FinalizarAlquiler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitulo.Text = "Alquiler del vehículo: " + ReservaSeleccionada.Matricula + " a nombre de: " + ReservaSeleccionada.NomCliente + ""
        txtCantidadDias.Text = If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)
        txtDescuentoCliente.Text = conexion.EjecutarSelect("SELECT porcdescuento FROM Cliente WHERE idpersona = '" + ReservaSeleccionada.IdCliente.ToString + "'").Rows(0)(0).ToString
        txtKMAutoAntes.Text = conexion.EjecutarSelect("SELECT kilometraje FROM Vehiculo WHERE nrochasis = '" + ReservaSeleccionada.NroChasis.ToString + "'").Rows(0)(0).ToString
    End Sub

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtKMAutoAhora.KeyPress
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

        Select Case ReservaSeleccionada.IdCantKM
            Case 1
                If Not txtKMAutoAhora.Text = "" Then
                    Diferencia = CInt(txtKMAutoAhora.Text) - CInt(txtKMAutoAntes.Text)
                    Permitidos = 150 * If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)

                    If Diferencia > Permitidos Then
                        lblAdvertencia.Visible = True
                        lblAdvertencia.Text = "Atención: Este cliente se pasó " + (Diferencia - Permitidos).ToString + " KM de los Kilómetros acordados. " + vbNewLine + " " + vbNewLine + " Se cobrará un recargo acorde."
                    Else
                        lblAdvertencia.Visible = False
                    End If
                End If

            Case 2
                If Not txtKMAutoAhora.Text = "" Then
                    Diferencia = CInt(txtKMAutoAhora.Text) - CInt(txtKMAutoAntes.Text)
                    Permitidos = 300 * If((Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days = 0, 1, (Date.Now - ReservaSeleccionada.FechaAlquilerInicio).Days)

                    If Diferencia > Permitidos Then
                        lblAdvertencia.Visible = True
                        lblAdvertencia.Text = "Atención: Este cliente se pasó " + (Diferencia - Permitidos).ToString + " KM de los Kilómetros acordados. " + vbNewLine + " " + vbNewLine + " Se cobrará un recargo acorde."
                    Else
                        lblAdvertencia.Visible = False
                    End If
                End If

            Case 3
                lblAdvertencia.Visible = False

        End Select

        Dim CostoTotal As Integer = ReservaSeleccionada.CostoTotal
        Dim Descuento As Integer = 0
        Dim Recargo As Integer = 0

        txtCostoTotal.Text = CostoTotal
        txtDescuento.Text = Descuento
        txtRecargo.Text = Recargo
        txtCostoTotalTotal.Text = (CostoTotal + Descuento + Recargo).ToString
    End Sub

    Private Sub CompletarAlquiler(sender As Object, e As EventArgs) Handles btnAccept.Click
        If Not txtKMAutoAhora.Text = "" Then
            conexion.EjecutarNonQuery("UPDATE Reserva SET fechaalquilerfin = '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "', estado = 2, costototal = '" + txtCostoTotalTotal.Text + "' WHERE idreserva = '" + ReservaSeleccionada.IdReserva.ToString + "'")
            frmMainMenu.CargarDatos()
            AmaranthMessagebox("Alquiler finalizado satisfactoriamente.", "Continuar")
            Me.Dispose()
        Else
            AmaranthMessagebox("Por favor, especifique el kilometraje actual del vehículo.", "Error")
        End If
    End Sub

    Private Sub btnCerrarMsgbox_Click(sender As Object, e As EventArgs) Handles btnCerrarMsgbox.Click
        Me.Dispose()
    End Sub
End Class