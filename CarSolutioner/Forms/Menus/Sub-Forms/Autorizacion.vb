Public Class Autorizacion
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click

        If conexion.TipoUsuario = "4" Then
            If VerificarCodigo(txtDescuento.Text) = True Then
                lbldataincorrect.Visible = False
                Me.DialogResult = vbYes
                Me.Dispose()
            Else
                lbldataincorrect.Visible = True
            End If
        Else
            Me.DialogResult = vbYes
            Me.Dispose()
        End If

    End Sub

    Private Sub Descuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If conexion.TipoUsuario = "4" Then
            lbldataincorrect.Visible = False
        Else
            Me.DialogResult = vbYes
            Me.Dispose()
        End If


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrarDescuento.Click
        Me.Dispose()
    End Sub

    Private Sub SoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
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
End Class