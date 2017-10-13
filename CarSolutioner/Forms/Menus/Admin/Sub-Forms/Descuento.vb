Public Class Descuento
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        If VerificarCodigo(txtDescuento.Text) Then
            lbldataincorrect.Visible = False
            Me.DialogResult = vbYes
            Me.Dispose()
        Else
            lbldataincorrect.Visible = True
        End If
    End Sub

    Private Sub Descuento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbldataincorrect.Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrarDescuento.Click
        Me.DialogResult = vbNo
        Me.Dispose()
    End Sub
End Class