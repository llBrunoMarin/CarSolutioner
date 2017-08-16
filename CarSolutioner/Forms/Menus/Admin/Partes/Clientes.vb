'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class

'CLIENTES
Partial Public Class MainMenu

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged

        'TODO: Agregar filtrado de combobox (tiraba excepción)
        Dim filtro As String
        filtro = String.Format("{0} LIKE '{1}%' AND {2} LIKE '{3}%' AND {4} LIKE '{5}%' AND {6} LIKE '{7}%' AND {8} LIKE '{9}%'",
                               "nrodocumento", txtDocumFClientes.Text, "nombre", txtNombreFClientes.Text, "apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "empresa", txtEmpresaFClientes.Text)

        dgvClientes.DataSource.Filter = filtro

    End Sub

End Class
