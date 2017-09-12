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

            If TipoDeFecha(cbxDiaFCliente, cbxMesFCliente, txtAnioFCliente) = "Dia" Then

                filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%' AND {12} LIKE '%%/08/1985'",
                                      "Documento", txtDocumFClientes.Text, "Tipo", cbxTipoDocumFCliente.SelectedValue.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "Correo", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text, "nacimiento")

                dgvClientes.DataSource.Filter = filtro
            End If


        Else

            filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
                                       "Documento", txtDocumFClientes.Text, "Tipo", cbxTipoDocumFCliente.SelectedValue.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "Correo", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro

        End If

    End Sub

    Private Sub btnIngresarACliente_Click(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click

        Dim sentencia As String
        sentencia = String.Format("INSERT INTO Cliente (tipodocumento, nrodocumento, nombre, apellido, email, fecnac, empresa, estado) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 't' )",
                         cbxTipoDocumACliente.SelectedValue, txtDocumACliente.Text, txtNombreACliente.Text, txtApellidoACliente.Text, txtCorreoACliente.Text, dtpFecNacACliente.Value.Date.ToShortDateString, txtEmpresaACliente.Text)

        If cbxTipoDocumACliente.SelectedValue = "CI UY" Then
            If VerificarCI(txtDocumACliente.Text) Then
                If conexion.EjecutarNonQuery(sentencia) Then
                    MsgBox("Cliente ingresado satisfactoriamente")
                End If
                RecargarDatos(dgvClientes)
            End If
        Else
            If conexion.EjecutarNonQuery(sentencia) Then
                MsgBox("Cliente ingresado satisfactoriamente")
            End If
        End If



    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click

        For Each control As Control In pnlFClientes.Controls
            If TypeOf control Is TextBox Or TypeOf control Is NumericUpDown Then
                control.Text = ""
            End If
        Next

    End Sub


    Private Sub btnModificarCliente_Click(sender As Object, e As EventArgs) Handles btnModificarCliente.Click

        conexion.EjecutarNonQuery("UPDATE Cliente SET tipodocumento = '" + cbxTipoDocumMCliente.SelectedItem + "', nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + dtpFecNacMCliente.Value.ToShortDateString + "', empresa = '" + txtEmpresaMCliente.Text + "' WHERE idpersona = (SELECT idpersona FROM cliente WHERE nrodocumento = '" + dgvClientes.CurrentRow.Cells(1).Value.ToString() + "') ")
        RecargarDatos(dgvClientes)

    End Sub

    Private Sub RellenarDatosCliente(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged

        If Not IsNothing(dgvClientes.CurrentRow) Then

            cbxTipoDocumMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("tipo").Value.ToString()
            txtDocumMCliente.Text = dgvClientes.CurrentRow.Cells("documento").Value.ToString()
            txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells("nombre").Value.ToString
            txtApellidoMCliente.Text = dgvClientes.CurrentRow.Cells("apellido").Value.ToString()
            txtCorreoMCliente.Text = dgvClientes.CurrentRow.Cells("correo").Value.ToString()
            dtpFecNacMCliente.Value = dgvClientes.CurrentRow.Cells("nacimiento").Value.ToString()
            txtEmpresaMCliente.Text = dgvClientes.CurrentRow.Cells("empresa").Value.ToString()

            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()
            'txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells(0).ToString()

        End If


    End Sub


End Class
