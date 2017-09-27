
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

        Try
            Dim filtro As String

            If chbxFechaFClientes.Checked = True Then

                    If Not ((cbxDiaNFCliente.SelectedItem Is Nothing) And (cbxMesNFCliente.SelectedItem Is Nothing) And (cbxAnioNFCliente.SelectedItem Is Nothing)) Then


                        filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%'" + TipoFiltro(cbxTipoDocumFCliente, "idtipodoc") + TipoFiltro(cbxDiaNFCliente, "dia") + TipoFiltro(cbxMesNFCliente, "mes") + TipoFiltro(cbxAnioNFCliente, "anio"),
                                                            "nrodocumento", txtDocumFClientes.Text, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

                        dgvClientes.DataSource.Filter = filtro

                    End If

                Else

                    filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%'" + TipoFiltro(cbxTipoDocumFCliente, "idtipodoc"),
                                                            "nrodocumento", txtDocumFClientes.Text, "Nombre", txtNombreFClientes.Text, "Apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "Empresa", txtEmpresaFClientes.Text)

                    dgvClientes.DataSource.Filter = filtro

                End If


        Catch ex As NullReferenceException

        End Try

    End Sub

    Private Sub AltaCliente(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click

        Dim FechaSeleccionada As String = cbxDiaNACliente.Text + "/" + cbxMesNACliente.Text + "/" + cbxAnioNACliente.Text

        If (IsDate(FechaSeleccionada)) Then

            Dim sentencia As String
            sentencia = String.Format("INSERT INTO Cliente (idtipodoc, nrodocumento, nombre, apellido, email, fecnac, empresa, estado) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', 't' )",
                             cbxTipoDocumACliente.SelectedValue, txtDocumACliente.Text, txtNombreACliente.Text, txtApellidoACliente.Text, txtCorreoACliente.Text, FechaSeleccionada, txtEmpresaACliente.Text)

            If cbxTipoDocumACliente.SelectedValue = 1 Then

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
            'Si la fecha seleccionada no es una fecha válida, mostramos un mensaje de error y salimos del Sub.
            MsgBox("Por favor, seleccione una fecha válida.")

        End If

    End Sub

    Private Sub ModificarCliente(sender As Object, e As EventArgs) Handles btnModificarCliente.Click

        Dim IdPersona As String = dgvClientes.CurrentRow.Cells("idpersona").Value.ToString()

        If Not cbxTelefonosMCliente.Items.Count = 0 Then

            If (IsDate(cbxDiaNMCliente.Text + "/" + cbxMesNMCliente.Text + "/" + cbxAnioNMCliente.Text)) Then

                Dim FechaSeleccionada As String = cbxDiaNMCliente.Text + "/" + cbxMesNMCliente.Text + "/" + cbxAnioNMCliente.Text
                conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "' WHERE idpersona = " + IdPersona + "")
                RecargarDatos(dgvClientes)

                Dim TelefonosPersona As New DataTable
                TelefonosPersona = conexion.EjecutarSelect("SELECT idpersona, telefono FROM TelefonoPersona WHERE idpersona = " + IdPersona + "")

                For Each telefono In cbxTelefonosMCliente.Items

                    If TelefonosPersona.Select("telefono = " + telefono + "").Count = 0 Then
                        conexion.EjecutarNonQuery("INSERT INTO TelefonoPersona VALUES (" + idpersona + ", '" + telefono + "')")
                    Else
                        conexion.EjecutarNonQuery("UPDATE ")
                    End If

                Next

            Else
                MsgBox("Por favor, ingrese una fecha válida.")
            End If

            MsgBox("Debe cargar los teléfonos de la persona antes de modificar sus datos.")
        End If


    End Sub

    Private Sub BajaCliente(sender As Object, e As EventArgs) Handles btnBajaCliente.Click

        Dim Valores As New Dictionary(Of Boolean, String)
        Valores.Add(True, "Activo")
        Valores.Add(False, "Inactivo")

        Dim Persona As New DataTable
        Persona = conexion.EjecutarSelect("SELECT idpersona, estado FROM cliente where nrodocumento = '" + txtDocumentoBCliente.Text + "'")

        'Si el cliente existe
        If (Persona.Rows.Count <> 0) Then
            Dim IdPersona As String = Persona.Rows(0)("idpersona").ToString()
            Dim EstadoActual As Boolean = Persona.Rows(0)("estado")
            Dim NuevoEstado As Boolean = Not EstadoActual
            If (conexion.EjecutarNonQuery("UPDATE Cliente SET estado = '" + NuevoEstado.ToString().Substring(0, 1) + "' WHERE idpersona = " + IdPersona + "")) Then

                RecargarDatos(dgvClientes)
                MsgBox("Presona pasó del estado " + Valores.Item(EstadoActual) + " a " + Valores.Item(NuevoEstado) + "")
            End If
        Else
            MsgBox("Ese cliente no existe. Por favor, verifique.")

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
        lblAyudaTelefono.Visible = True

    End Sub


    Private Sub VerTelefonos(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

        If TypeOf DirectCast(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            'Obtiene el ID de la persona seleccionada.
            Dim IdPersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("idpersona").Value.ToString
            Dim NombrePersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("nombre").Value.ToString + " " + DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("apellido").Value.ToString

            'Obtiene los teléfonos de la persona seleccionada y los carga en el DataGridView
            Dim VerTelefonos As New frmTelefonosCliente("Ver", NombrePersona)

            conexion.RellenarDataGridView(VerTelefonos.dgvTelefonos, "SELECT telefono FROM TelefonoPersona WHERE idpersona = " + IdPersona + " ")
            VerTelefonos.ShowDialog()

        End If

    End Sub

    Private Sub VerTelefonosMCliente(sender As Object, e As EventArgs) Handles btnTelefonosMCliente.Click

        Dim IdPersona As String = dgvClientes.CurrentRow.Cells("idpersona").Value.ToString
        Dim NombrePersona As String = dgvClientes.CurrentRow.Cells("nombre").Value.ToString + " " + dgvClientes.CurrentRow.Cells("apellido").Value.ToString

        'Obtiene los teléfonos de la persona seleccionada y los carga en el DataGridView, pero los borra de la BD (ya que serán ingresados nuevamente con (o sin) modificaciones)
        Dim TelefonosPersona As New DataTable
        Dim ListaTelefonos As New List(Of String)

        TelefonosPersona = conexion.EjecutarSelect("SELECT telefono FROM TelefonoPersona WHERE idpersona = " + IdPersona + " ")

        'Cargamos en una lista los teléfonos para no perderlos una vez que los borremos.
        For Each rw As DataRow In TelefonosPersona.Rows
            ListaTelefonos.Add(rw("telefono"))
        Next

        conexion.EjecutarNonQuery("DELETE FROM TelefonoPersona WHERE idpersona = " + IdPersona + "")

        Dim ModificarTelefonos As New frmTelefonosCliente("Modificar", NombrePersona, ListaTelefonos)

        If lblAyudaTelefono.Visible = True Then
            lblAyudaTelefono.Visible = False
        End If

        ModificarTelefonos.ShowDialog()


    End Sub

    Private Sub AgregarTelefonos(sender As Object, e As EventArgs) Handles btnAgregarTelefonosACliente.Click

        Dim ListaTelefonos As New List(Of String)

        For Each item In cbxTelefonosACliente.Items
            ListaTelefonos.Add(item.ToString)
        Next

        Dim AgregarTelefonos As New frmTelefonosCliente("Agregar", "", ListaTelefonos)

        AgregarTelefonos.ShowDialog()

    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click

        For Each control As Control In pnlFClientes.Controls
            VaciarControl(control)
        Next

    End Sub

    Private Sub lblBorrarTipoDoc_Click(sender As Object, e As EventArgs) Handles lblBorrarTipoDoc.Click
        cbxTipoDocumFCliente.SelectedItem = Nothing
    End Sub

End Class
