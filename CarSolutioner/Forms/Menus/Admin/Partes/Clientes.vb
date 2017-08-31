'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class

'CLIENTES
Partial Public Class frmMainMenu

    Private Sub chboxFechaFClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chbxFechaFClientes.CheckedChanged

        If chbxFechaFClientes.Checked Then

            cbxDiaFCliente.SelectedItem = Nothing
            cbxMesFCliente.SelectedItem = Nothing
            txtAnioFCliente.Text = ""
            gbxFecNacFCliente.Enabled = True

        Else

            gbxFecNacFCliente.Enabled = False

        End If

    End Sub

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged, cbxTipoDocumFCliente.SelectionChangeCommitted, chbxFechaFClientes.CheckStateChanged, cbxDiaFCliente.SelectionChangeCommitted, cbxMesFCliente.SelectionChangeCommitted, txtAnioFCliente.TextChanged

        Dim filtro As String

        If chbxFechaFClientes.Checked = True Then



        Else

            filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
                                       "Documento", txtDocumFClientes.Text, "Tipo", cbxTipoDocumFCliente.SelectedItem.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "Correo", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro

        End If

    End Sub

    Private Sub btnIngresarACliente_Click(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click
        Dim sentencia As String

        sentencia = String.Format("INSERT INTO Cliente (tipodocumento, nrodocumento, nombre, apellido, email, fecnac, empresa, estado) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 't' )",
                         cbxTipoDocumACliente.SelectedItem, txtDocumACliente.Text, txtNombreACliente.Text, txtApellidoACliente.Text, txtCorreoACliente.Text, dtpFecNacACliente.Value.Date.ToShortDateString, txtEmpresaACliente.Text)

        conexion.EjecutarNonQuery(sentencia)

        CargarDatos(dgvClientes)

    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click

        For Each control As Control In pnlFClientes.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
            End If
        Next

    End Sub


    Private Sub btnModificarCliente_Click(sender As Object, e As EventArgs) Handles btnModificarCliente.Click

        Dim sentencia As String

        sentencia = "UPDATE Cliente SET tipodocumento = '" + cbxTipoDocumMCliente.SelectedItem + "', nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + dtpFecNacMCliente.Value.ToShortDateString + "', empresa = '" + txtEmpresaMCliente.Text + "' WHERE idpersona = (SELECT idpersona FROM cliente WHERE nrodocumento = '" + dgvClientes.CurrentRow.Cells(1).Value.ToString() + "') "

        conexion.EjecutarNonQuery(sentencia)

        CargarDatos(dgvClientes)

    End Sub

    Private Sub RellenarDatosCliente(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged

        If Not IsNothing(dgvClientes.CurrentRow) Then

            'cbxTipoDocumMCliente.SelectedItem = dgvClientes.CurrentRow.Cells(0).Value.ToString()
            'txtDocumMCliente.Text = dgvClientes.CurrentRow.Cells(1).Value.ToString()
            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(2).Value.ToString
            'txtApellidoMCliente.Text = dgvClientes.CurrentRow.Cells(3).Value.ToString()
            'txtCorreoMCliente.Text = dgvClientes.CurrentRow.Cells(4).Value.ToString()
            'dtpFecNacMCliente.Value = dgvClientes.CurrentRow.Cells(5).Value.ToString()
            'txtEmpresaMCliente.Text = dgvClientes.CurrentRow.Cells(6).Value.ToString()

            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()
            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()

        End If


    End Sub


End Class
