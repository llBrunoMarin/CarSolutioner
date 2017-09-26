
'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class


'CLIENTES
Partial Public Class frmMainMenu
    Dim modo As String
    Private Sub chboxFechaFClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chbxFechaFClientes.CheckedChanged

        If chbxFechaFClientes.Checked Then
            gbxFecNacFCliente.Enabled = True
        Else
            cbxDiaNFCliente.SelectedItem = Nothing
            cbxMesNFCliente.SelectedItem = Nothing
            cbxAnioNFCliente.SelectedItem = Nothing
            gbxFecNacFCliente.Enabled = False
        End If

    End Sub

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged, cbxTipoDocumFCliente.SelectionChangeCommitted, chbxFechaFClientes.CheckStateChanged, cbxDiaNFCliente.SelectionChangeCommitted, cbxMesNFCliente.SelectionChangeCommitted, cbxAnioNFCliente.SelectionChangeCommitted

        Dim filtro As String

        If chbxFechaFClientes.Checked = True Then

            If Not ((cbxDiaNFCliente.SelectedItem Is Nothing) And (cbxMesNFCliente.SelectedItem Is Nothing) And (cbxAnioNFCliente.SelectedItem Is Nothing)) Then


                filtro = String.Format("{0} LIKE '%{1}%' AND {2} = {3} AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'" + TipoFiltro(cbxDiaNFCliente, "dia") + TipoFiltro(cbxMesNFCliente, "mes") + TipoFiltro(cbxAnioNFCliente, "anio"),
                                                    "nrodocumento", txtDocumFClientes.Text, "idtipodoc", cbxTipoDocumFCliente.SelectedValue.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

                dgvClientes.DataSource.Filter = filtro
            End If

        Else

            filtro = String.Format("{0} LIKE '%{1}%' AND {2} = {3} AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%' AND {10} LIKE '%{11}%'",
                                       "nrodocumento", txtDocumFClientes.Text, "idtipodoc", cbxTipoDocumFCliente.SelectedValue.ToString, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro

        End If

    End Sub

    Private Sub AltaCliente(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click

        Dim FechaSeleccionada As String = cbxDiaNACliente.Text + "/" + cbxMesNACliente.Text + "/" + cbxAnioNACliente.Text

        If (IsDate(FechaSeleccionada)) Then

            Dim sentencia As String
            sentencia = String.Format("INSERT INTO Cliente (tipodocumento, nrodocumento, nombre, apellido, email, fecnac, empresa, estado) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 't' )",
                             cbxTipoDocumACliente.SelectedValue, txtDocumACliente.Text, txtNombreACliente.Text, txtApellidoACliente.Text, txtCorreoACliente.Text, FechaSeleccionada, txtEmpresaACliente.Text)

            If cbxTipoDocumACliente.SelectedValue = "CI UY" Then

                'Si la cédula es válida
                If VerificarCI(txtDocumACliente.Text) Then

                    'Si el cliente se ingresa satisfactoriamente, mostrar mensaje y agregar teléfonos.
                    If conexion.EjecutarNonQuery(sentencia) Then
                        MsgBox("Cliente ingresado satisfactoriamente")
                        RecargarDatos(dgvClientes)

                        Dim IDPersonaInsertada As String = conexion.EjecutarSelect("SELECT idpersona FROM Cliente WHERE nrodocumento = '" + txtDocumACliente.Text + "'").Rows(0)(0).ToString
                        Dim ListaTelefonos As New List(Of String)

                        'Agrega cada item del combobox a la Lista
                        For Each item In cbxTelefonosACliente.Items
                            ListaTelefonos.Add(item.ToString)
                        Next

                        'Por cada item DISTINTO en la lista de telefonos (para evitar duplicados)
                        For Each Telefono In ListaTelefonos.Distinct()
                            conexion.EjecutarNonQuery("INSERT INTO telefonopersona VALUES ('" + IDPersonaInsertada + "', '" + Telefono + "')")
                        Next

                    End If

                End If

            Else

                'Si el cliente se ingresa satisfactoriamente, mostrar mensaje y agregar teléfonos.
                If conexion.EjecutarNonQuery(sentencia) Then
                    MsgBox("Cliente ingresado satisfactoriamente")
                    RecargarDatos(dgvClientes)
                End If

            End If

        Else
            'Si la fecha seleccionada no es una fecha válida, mostramos un mensaje de error y salimos del Sub.
            MsgBox("Por favor, seleccione una fecha válida.")

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

        If (IsDate(cbxDiaNMCliente.Text + "/" + cbxMesNMCliente.Text + "/" + cbxAnioNMCliente.Text)) Then
            Dim FechaSeleccionada As String = cbxDiaNMCliente.Text + "/" + cbxMesNMCliente.Text + "/" + cbxAnioNMCliente.Text
            conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "' WHERE idpersona = " + dgvClientes.CurrentRow.Cells("idpersona").Value.ToString() + "")
            RecargarDatos(dgvClientes)
        Else
            MsgBox("Por favor, ingrese una fecha válida.")
        End If

    End Sub

    Private Sub RellenarDatosCliente(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged

        If Not IsNothing(dgvClientes.CurrentRow) Then

            cbxTipoDocumMCliente.SelectedIndex = cbxTipoDocumMCliente.FindString(dgvClientes.CurrentRow.Cells("tipodocumento").Value.ToString())
            txtDocumMCliente.Text = dgvClientes.CurrentRow.Cells("nrodocumento").Value.ToString()
            txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells("nombre").Value.ToString
            txtApellidoMCliente.Text = dgvClientes.CurrentRow.Cells("apellido").Value.ToString()
            txtCorreoMCliente.Text = dgvClientes.CurrentRow.Cells("email").Value.ToString()
            txtEmpresaMCliente.Text = dgvClientes.CurrentRow.Cells("empresa").Value.ToString()
            cbxDiaNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("dia").Value.ToString()
            cbxMesNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("mes").Value.ToString()
            cbxAnioNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("anio").Value.ToString()

        End If


    End Sub

    Private Sub VerTelefonos(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

        If TypeOf DirectCast(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            'Obtiene el ID de la persona seleccionada.
            Dim idpersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("idpersona").Value.ToString
            Dim NombrePersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("nombre").Value.ToString + " " + DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("apellido").Value.ToString

            'Obtiene los teléfonos de la persona seleccionada y los carga en el DataGridView
            Dim VerTelefonos As New frmTelefonosCliente("Ver", NombrePersona)
            conexion.RellenarDataGridView(VerTelefonos.dgvTelefonos, "SELECT telefono FROM TelefonoPersona WHERE idpersona = " + idpersona + " ")
            VerTelefonos.ShowDialog()

        End If

    End Sub

    Private Sub AgregarTelefonos(sender As Object, e As EventArgs) Handles btnAgregarTelefonosACliente.Click

        Dim ListaTelefonos As New List(Of String)
        For Each item In cbxTelefonosACliente.Items
            ListaTelefonos.Add(item.ToString)
        Next

        Dim AgregarTelefonos As New frmTelefonosCliente(ListaTelefonos)
        AgregarTelefonos.ShowDialog()

    End Sub
End Class
