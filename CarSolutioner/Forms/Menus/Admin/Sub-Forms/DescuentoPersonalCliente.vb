Public Class DescuentoPersonalCliente
    Private Property IdClienteDescuento As Integer

    Public Sub New(idcliente As Integer)

        InitializeComponent()
        IdClienteDescuento = idcliente

    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        conexion.EjecutarNonQuery("UPDATE Cliente SET porcdescuento = '" + numDescuento.Value.ToString + "' WHERE idpersona = '" + IdClienteDescuento.ToString + "'")
        Me.DialogResult = vbYes
    End Sub

    Private Sub Salir(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = vbNo
        Me.Dispose()
    End Sub

End Class