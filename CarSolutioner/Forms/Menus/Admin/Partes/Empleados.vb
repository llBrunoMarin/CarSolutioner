'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerEmpleados
End Class

'EMPLEADOS
Partial Public Class frmMainMenu


    Private Sub FiltrosEmpleados(sender As Object, e As EventArgs) Handles txtNroDocFempleado.TextChanged, cbxSucursalFempleados.TextChanged, cbxTipoFempleados.TextChanged

        Dim filtro As String

        'filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%'" +
        '                       TipoFiltro(cbxTipoDocumFCliente, "idtipodoc") + TipoFiltro(cbxDiaNFCliente, "dia") +
        '                       TipoFiltro(cbxMesNFCliente, "mes") + TipoFiltro(cbxAnioNFCliente, "anio"),
        '                       "nrodocumento", txtDocumFClientes.Text, "Nombre", txtNombreFClientes.Text, "Apellido",
        '                       txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

        'dgvClientes.DataSource.Filter = filtro


    End Sub




End Class
