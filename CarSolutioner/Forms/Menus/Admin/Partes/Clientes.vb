Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerClientes
End Class

'CLIENTES
Partial Public Class frmMainMenu

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

    Private Sub BorrarTipoDocFClientes(sender As Object, e As EventArgs) Handles lblBorrarTipoDocFCliente.Click
        cbxTipoDocumFCliente.SelectedItem = Nothing
    End Sub

    Private Sub FiltrosCliente(sender As Object, e As EventArgs) Handles txtDocumFClientes.TextChanged, txtNombreFClientes.TextChanged, txtApellidoFClientes.TextChanged, txtCorreoFClientes.TextChanged, txtEmpresaFClientes.TextChanged, cbxTipoDocumFCliente.SelectionChangeCommitted, chbxFechaFClientes.CheckStateChanged, cbxDiaNFCliente.SelectionChangeCommitted, cbxMesNFCliente.SelectionChangeCommitted, cbxAnioNFCliente.SelectionChangeCommitted, lblBorrarTipoDocFCliente.Click

        'Try
        Dim filtro As String

        If chbxFechaFClientes.Checked = True Then

            filtro = String.Format("{0} LIKE '{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%'" + TipoFiltro(cbxTipoDocumFCliente, "idtipodoc") + TipoFiltro(cbxDiaNFCliente, "dia") + TipoFiltro(cbxMesNFCliente, "mes") + TipoFiltro(cbxAnioNFCliente, "anio"), "nrodocumento", txtDocumFClientes.Text, "nombre", txtNombreFClientes.Text, "apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro

        Else

            filtro = String.Format("{0} LIKE '{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%' AND {6} LIKE '%{7}%' AND {8} LIKE '%{9}%'" + TipoFiltro(cbxTipoDocumFCliente, "idtipodoc"), "nrodocumento", txtDocumFClientes.Text, "nombre", txtNombreFClientes.Text, "apellido", txtApellidoFClientes.Text, "email", txtCorreoFClientes.Text, "empresa", txtEmpresaFClientes.Text)

            dgvClientes.DataSource.Filter = filtro

        End If

        'Catch ex As NullReferenceException

        'End Try

    End Sub

    Private Sub chbxEmpresa_CheckedChanged(sender As Object, e As EventArgs) Handles chbxEmpresaACliente.CheckedChanged
        If chbxEmpresaACliente.Checked = True Then
            txtEmpresaACliente.Enabled = True
            lblEmpresaACliente.Enabled = True
            txtEmpresaACliente.Text = ""
        Else
            txtEmpresaACliente.Enabled = False
            lblEmpresaACliente.Enabled = False
            txtEmpresaACliente.Text = "-"
        End If
    End Sub

    Private Sub AltaCliente(sender As Object, e As EventArgs) Handles btnIngresarACliente.Click
        Dim FechaSeleccionada As String = cbxDiaNACliente.Text + "/" + cbxMesNACliente.Text + "/" + cbxAnioNACliente.Text
        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlAClientes.Controls
            If TypeOf (ctrl) Is TextBox Then
                If ctrl.Text = "" Then
                    If Not ((ctrl.Name = "txtEmpresaACliente") Or (ctrl.Name = "txtCorreoACliente")) Then
                        FaltaDato = True
                    End If

                End If

            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next

        If Not (FaltaDato) Then
            If (IsDate(FechaSeleccionada)) Then
                If (Date.Now - Date.Parse(FechaSeleccionada)).Days / 365 > 18 Then
                    'TODO: Agregar posibilidad de insertar descuento en el alta de cliente
                    Dim ListaTelefonos As New List(Of String)

                    'Agrega cada item del combobox a la Lista
                    For Each item In cbxTelefonosACliente.Items
                        ListaTelefonos.Add(item.ToString)
                    Next
                    Dim numeros As String = ""
                    'Por cada item DISTINTO en la lista de telefonos (para evitar duplicados)
                    For Each Telefono In ListaTelefonos.Distinct()
                        If (numeros = "") Then
                            numeros += Telefono
                        Else
                            numeros += "," + Telefono
                        End If
                    Next

                    If Not numeros.Length > 255 Then


                        Dim nrodocRepetido As New DataTable
                        nrodocRepetido = conexion.EjecutarSelect("SELECT nrodocumento FROM cliente WHERE nrodocumento = '" + txtDocumACliente.Text + "'")

                        If nrodocRepetido.Rows.Count = 0 Then
                            Dim sentencia As String


                            sentencia = String.Format("INSERT INTO Cliente (idtipodoc, nrodocumento, nombre, apellido, email, fecnac, empresa, porcdescuento, estado, telefono) VALUES ( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", cbxTipoDocumACliente.SelectedValue, txtDocumACliente.Text, txtNombreACliente.Text, txtApellidoACliente.Text, txtCorreoACliente.Text, Date.Parse(FechaSeleccionada).ToString("dd/MM/yyyy"), If(txtEmpresaACliente.Text = "", "-", txtEmpresaACliente.Text), numDescuentoACliente.Value.ToString, "t", numeros.ToString)

                            If cbxTipoDocumACliente.SelectedValue = 1 Then
                                'Si la cédula es válida
                                If VerificarCI(txtDocumACliente.Text) Then
                                    'Si el cliente se ingresa satisfactoriamente, mostrar mensaje y agregar teléfonos.
                                    If conexion.EjecutarNonQuery(sentencia) Then

                                        Dim ip As String = GetIPAddress()
                                        Dim descripcion As String = "Ingreso al cliente con el numero de documento : " + txtDocumACliente.Text + " y con un descuento del : " + numDescuentoACliente.Value.ToString + "%"
                                        conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                                        AmaranthMessagebox("Cliente ingresado satisfactoriamente", "Continuar", Me)
                                        RecargarDatos(dgvClientes)

                                        For Each control As Control In pnlAClientes.Controls
                                            VaciarControl(control)
                                        Next
                                        cbxTelefonosACliente.DataSource = Nothing
                                    End If
                                End If
                            Else
                                'Si el cliente se ingresa satisfactoriamente, recargar y desactivar descuento.
                                If conexion.EjecutarNonQuery(sentencia) Then
                                    AmaranthMessagebox("Cliente ingresado satisfactoriamente", "Continuar", Me)

                                    Dim ip As String = GetIPAddress()
                                    Dim descripcion As String = "Ingreso al cliente con el numero de documento : " + txtDocumACliente.Text + " y con un descuento del : " + numDescuentoACliente.Value.ToString + "%"
                                    conexion.EjecutarNonQuery("INSERT INTO accion VALUES('" + ip + "','" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "','" + descripcion + "','" + conexion.Usuario.ToString + "')")

                                    RecargarDatos(dgvClientes)
                                    numDescuentoACliente.Enabled = False
                                    For Each control As Control In gbxFecNacACliente.Controls
                                        VaciarControl(control)
                                    Next
                                    For Each control As Control In pnlAClientes.Controls
                                        VaciarControl(control)
                                    Next
                                End If
                            End If
                        Else
                            AmaranthMessagebox("Ya existe un cliente con el mismo número de documento, por favor modifique. (#030)", "Error", Me)
                        End If
                    Else
                        AmaranthMessagebox("Ha ingresado demasiados telefonos. Por favor, elimine alguno. (#030)", "Error", Me)

                    End If

                Else
                    AmaranthMessagebox("Solo puede registrar clientes mayores a 18 años. (#031)", "Advertencia", Me)
                End If

            Else
                'Si la fecha seleccionada no es una fecha válida, mostramos un mensaje de error y salimos del Sub.
                AmaranthMessagebox("Por favor, seleccione una fecha válida. (#032)", "Advertencia", Me)
            End If
        Else
            'Si falta rellenar algún dato necesario:
            AmaranthMessagebox("Por favor, rellene todos los campos obligatorios. (#009)", "Advertencia", Me)
        End If

    End Sub

    Private Sub ModificarCliente(sender As Object, e As EventArgs) Handles btnModificarCliente.Click
        If Not dgvClientes.CurrentRow Is Nothing Then
            Dim FaltaDato As Boolean = False

            For Each ctrl As Control In pnlMClientes.Controls
                If TypeOf (ctrl) Is TextBox Then
                    If ctrl.Text = "" Then
                        If Not ((ctrl.Name = "txtEmpresaMCliente") Or (ctrl.Name = "txtCorreoMCliente")) Then
                            FaltaDato = True
                        End If

                    End If

                Else
                    If TypeOf (ctrl) Is ComboBox Then
                        If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                            FaltaDato = True
                        End If
                    End If
                End If
            Next

            If Not (FaltaDato) Then

                Dim IdPersona As String = dgvClientes.CurrentRow.Cells("idpersona").Value.ToString()
                Dim FechaSeleccionada As String = cbxDiaNMCliente.Text + "/" + cbxMesNMCliente.Text + "/" + cbxAnioNMCliente.Text

                If Not cbxTelefonosMCliente.Items.Count = 0 Then

                    If (IsDate(FechaSeleccionada)) Then

                        Dim TelefonosPersona As New DataTable
                        TelefonosPersona = conexion.EjecutarSelect("SELECT telefono FROM cliente WHERE idpersona = " + IdPersona + "")

                        Dim ListaTelefonos As New List(Of String)
                        'Agrega cada item del combobox a la Lista
                        For Each item In cbxTelefonosMCliente.Items
                            ListaTelefonos.Add(item.ToString)
                        Next
                        Dim numeros As String = ""
                        'Por cada item DISTINTO en la lista de telefonos (para evitar duplicados)
                        For Each Telefono In ListaTelefonos.Distinct()
                            If (numeros = "") Then
                                numeros += Telefono
                            Else
                                numeros += "," + Telefono
                            End If
                        Next
                        If Not numeros.Length > 255 Then
                            Dim telefonoM As String = TelefonosPersona.Rows(0)("telefono").ToString()
                            Dim idtipodocm As String = dgvClientes.CurrentRow.Cells("idtipodoc").Value.ToString()
                            Dim nrodocM As String = dgvClientes.CurrentRow.Cells("nrodocumento").Value.ToString()
                            Dim nombreM As String = dgvClientes.CurrentRow.Cells("nombre").Value.ToString
                            Dim apellidoM As String = dgvClientes.CurrentRow.Cells("apellido").Value.ToString()
                            Dim emailM As String = dgvClientes.CurrentRow.Cells("email").Value.ToString()
                            Dim empresaM As String = dgvClientes.CurrentRow.Cells("empresa").Value.ToString()
                            Dim descuentoM As String = dgvClientes.CurrentRow.Cells("porcdescuento").Value
                            Dim diaM As String = dgvClientes.CurrentRow.Cells("dia").Value.ToString()
                            Dim mesM As String = dgvClientes.CurrentRow.Cells("mes").Value.ToString()
                            Dim anioM As String = dgvClientes.CurrentRow.Cells("anio").Value.ToString()
                            Dim FechaModificar As String = diaM + "/" + mesM + "/" + anioM

                            If Not (cbxTipoDocumMCliente.SelectedValue = idtipodocm And txtDocumMCliente.Text.ToString = nrodocM And txtNombreMCliente.Text.ToString = nombreM And txtApellidoMCliente.Text.ToString = apellidoM And txtCorreoMCliente.Text.ToString = emailM And txtEmpresaMCliente.Text.ToString = empresaM And numDescuentoMCliente.Value.ToString = descuentoM And FechaSeleccionada = FechaModificar And telefonoM = numeros) Then

                                If Not (txtDocumMCliente.Text.ToString = nrodocM) Then

                                    Dim nrodocRepetido As New DataTable
                                    nrodocRepetido = conexion.EjecutarSelect("SELECT idpersona FROM cliente WHERE nrodocumento = '" + txtDocumMCliente.Text + "'")

                                    If nrodocRepetido.Rows.Count = 0 Then

                                        If (cbxTipoDocumMCliente.SelectedValue = 1) Then
                                            If (VerificarCI(txtDocumMCliente.Text.ToString) = True) Then
                                                'ponerinsert
                                                conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "',  apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "',  fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "', porcdescuento = '" + numDescuentoMCliente.Value.ToString + "', telefono ='" + numeros + "' WHERE idpersona = " + IdPersona + "")
                                                AmaranthMessagebox("Persona modificada satisfactoriamente.", "Continuar", Me)

                                                RecargarDatos(dgvClientes)
                                                numDescuentoMCliente.Enabled = False
                                            End If
                                        Else
                                            'ponerinsert
                                            conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "', porcdescuento = '" + numDescuentoMCliente.Value.ToString + "', telefono ='" + numeros + "' WHERE idpersona = " + IdPersona + "")
                                            AmaranthMessagebox("Persona modificada satisfactoriamente.", "Continuar", Me)

                                            RecargarDatos(dgvClientes)
                                            numDescuentoMCliente.Enabled = False
                                        End If
                                    Else
                                        AmaranthMessagebox("Ya existe un cliente con ese número de documento. (#030)", "Advertencia", Me)
                                    End If
                                Else
                                    If (cbxTipoDocumMCliente.SelectedValue = 1) Then
                                        If (VerificarCI(txtDocumMCliente.Text.ToString) = True) Then
                                            'ponerinsert
                                            conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "',  apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "',  fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "', porcdescuento = '" + numDescuentoMCliente.Value.ToString + "', telefono ='" + numeros + "' WHERE idpersona = " + IdPersona + "")

                                            MsgBox("Persona modificada satisfactoriamente.", "Continuar", Me)

                                            RecargarDatos(dgvClientes)
                                            numDescuentoMCliente.Enabled = False
                                        End If
                                    Else
                                        'ponerinsert
                                        conexion.EjecutarNonQuery("UPDATE Cliente SET idtipodoc = " + cbxTipoDocumMCliente.SelectedValue.ToString() + ", nrodocumento = '" + txtDocumMCliente.Text + "', nombre = '" + txtNombreMCliente.Text + "', apellido = '" + txtApellidoMCliente.Text + "', email = '" + txtCorreoMCliente.Text + "', fecnac = '" + FechaSeleccionada + "', empresa = '" + txtEmpresaMCliente.Text + "', porcdescuento = '" + numDescuentoMCliente.Value.ToString + "', telefono ='" + numeros + "' WHERE idpersona = " + IdPersona + "")
                                        AmaranthMessagebox("Persona modificada satisfactoriamente.", "Continuar", Me)

                                        RecargarDatos(dgvClientes)
                                        numDescuentoMCliente.Enabled = False
                                    End If
                                End If
                            Else
                                AmaranthMessagebox("Modifique algo por favor. (#010)", "Advertencia", Me)
                            End If
                        Else
                            AmaranthMessagebox("Ha ingresado demasiados teléfonos. Por favor, elimine alguno.", "Error", Me)

                        End If


                    Else
                        AmaranthMessagebox("Por favor, ingrese una fecha válida. (#032)", "Advertencia", Me)
                    End If

                Else
                    AmaranthMessagebox("Debe cargar los teléfonos de la persona antes de modificar sus datos. (#033)", "Advertencia", Me)
                End If
            Else
                AmaranthMessagebox("Rellene todos los campos obligatorios (*). (#009)", "Advertencia", Me)
            End If
        End If
    End Sub

    Private Sub BajaCliente(sender As Object, e As EventArgs) Handles btnBajaCliente.Click
        If Not dgvClientes.CurrentRow Is Nothing Then

            Dim Valores As New Dictionary(Of Boolean, String)
            Valores.Add(True, "Activo")
            Valores.Add(False, "Inactivo")
            Dim nrochasis As String = ""
            Dim idreserva As String = ""

            Dim Persona As New DataTable
            Persona = conexion.EjecutarSelect("SELECT idpersona, estado FROM cliente where nrodocumento = '" + txtDocumentoBCliente.Text + "'")

            If AmaranthMessagebox("Desea cambiar el estado de este cliente?", "Si/No", Me) = vbYes Then

                If Not (txtDocumentoBCliente.Text = "") Then

                    'Si el cliente existe
                    If (Persona.Rows.Count <> 0) Then
                        Dim IdPersona As String = Persona.Rows(0)("idpersona").ToString()

                        Dim alquileresActivos As New DataTable
                        Dim sentencia As String = "SELECT nrochasis FROM reserva WHERE idpersona = '" + IdPersona + "' AND estado = '1'"
                        alquileresActivos = conexion.EjecutarSelect(sentencia)
                        If Not (alquileresActivos.Rows.Count = 0) Then
                            nrochasis = alquileresActivos.Rows(0)("nrochasis").ToString
                        End If

                        If (nrochasis = "") Then

                            Dim ReservasActivasPersona As DataTable
                            Dim sentencia2 As String = "SELECT idreserva FROM Reserva WHERE idpersona = '" + IdPersona + "' AND estado = 1"
                            ReservasActivasPersona = conexion.EjecutarSelect(sentencia2)
                            If Not (ReservasActivasPersona.Rows.Count = 0) Then
                                idreserva = ReservasActivasPersona.Rows(0)("idreserva").ToString
                            End If

                            If (idreserva = "") Then
                                Dim EstadoActual As Boolean = Persona.Rows(0)("estado")
                                Dim NuevoEstado As Boolean = Not EstadoActual
                                'ponerinsert
                                If (conexion.EjecutarNonQuery("UPDATE Cliente SET estado = '" + NuevoEstado.ToString().Substring(0, 1) + "' WHERE idpersona = " + IdPersona + "")) Then
                                    RecargarDatos(dgvClientes)
                                    AmaranthMessagebox("Presona pasó del estado " + Valores.Item(EstadoActual) + " a " + Valores.Item(NuevoEstado) + "", "Continuar", Me)
                                Else
                                    AmaranthMessagebox("Por favor, verifique que pueda eliminar ese cliente. (#034)", "Error", Me)
                                End If
                            Else
                                AmaranthMessagebox("No puede cambiar el estado de este cliente debido a que tiene reservas activas. (#035)", "Error", Me)
                            End If
                        Else
                            AmaranthMessagebox("No puede cambiar el estado de este cliente debido a que tiene un alquiler activo. (#036)", "Error", Me)
                        End If

                    Else
                        AmaranthMessagebox("Ese cliente no existe. Por favor, verifique. (#037)", "Advertencia", Me)
                    End If
                Else
                    AmaranthMessagebox("Ingrese un número de documento. (#038)", "Advertencia", Me)
                End If
            End If
        End If

    End Sub

    Private Sub RellenarDatosCliente(sender As Object, e As EventArgs) Handles dgvClientes.SelectionChanged

        If Not IsNothing(dgvClientes.CurrentRow) Then

            cbxTipoDocumMCliente.SelectedValue = dgvClientes.CurrentRow.Cells("idtipodoc").Value.ToString()
            txtDocumMCliente.Text = dgvClientes.CurrentRow.Cells("nrodocumento").Value.ToString()
            txtNombreMCliente.Text = dgvClientes.CurrentRow.Cells("nombre").Value.ToString
            txtApellidoMCliente.Text = dgvClientes.CurrentRow.Cells("apellido").Value.ToString()
            txtCorreoMCliente.Text = dgvClientes.CurrentRow.Cells("email").Value.ToString()
            txtEmpresaMCliente.Text = dgvClientes.CurrentRow.Cells("empresa").Value.ToString()
            cbxDiaNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("dia").Value.ToString()
            cbxMesNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("mes").Value.ToString()
            cbxAnioNMCliente.SelectedItem = dgvClientes.CurrentRow.Cells("anio").Value.ToString()
            txtDocumentoBCliente.Text = dgvClientes.CurrentRow.Cells("nrodocumento").Value.ToString()
            numDescuentoMCliente.Value = dgvClientes.CurrentRow.Cells("porcdescuento").Value
            cbxTelefonosMCliente.DataSource = Nothing

        End If
        lblAyudaTelefono.Visible = True

    End Sub

    Private Sub DescuentoAltaCliente(sender As Object, e As EventArgs) Handles btnDescuentoACliente.Click

        If Autorizar(Me) = vbYes Then
            numDescuentoACliente.Enabled = True
        End If

    End Sub

    Private Sub DescuentoModifCliente(sender As Object, e As EventArgs) Handles btnDescuentoMCliente.Click
        If Autorizar(Me) = vbYes Then
            numDescuentoMCliente.Enabled = True
        End If
    End Sub

    Private Sub VerTelefonos(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClientes.CellContentClick

        If TypeOf DirectCast(sender, DataGridView).Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then

            'Obtiene el ID de la persona seleccionada.
            Dim IdPersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("idpersona").Value.ToString
            Dim NombrePersona As String = DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("nombre").Value.ToString + " " + DirectCast(sender, DataGridView).Rows(e.RowIndex).Cells("apellido").Value.ToString
            'Combobox que no se usa para nada pero lo requier el metodo
            Dim combo As New ComboBox
            combo.Visible = False

            'Obtiene los teléfonos de la persona seleccionada y los carga en el DataGridView
            Dim VerTelefonos As New frmTelefonosCliente("Ver", NombrePersona, combo)

            Dim telefonosPersona As New DataTable
            telefonosPersona = conexion.EjecutarSelect("SELECT telefono FROM cliente WHERE idpersona = " + IdPersona + " ")
            Dim telefonospersonaS As String
            telefonospersonaS = telefonosPersona.Rows(0)(0).ToString()

            Dim TelArray() As String = telefonospersonaS.Split(",")

            For Each item In TelArray
                VerTelefonos.dgvTelefonos.Rows.Add(item)
            Next
            VerTelefonos.ShowDialog()
        End If

    End Sub

    Private Sub VerTelefonosMCliente(sender As Object, e As EventArgs) Handles btnTelefonosMCliente.Click
        If Not dgvClientes.CurrentRow Is Nothing Then


            Dim TelefonosPersona As New DataTable
            Dim ListaTelefonos As New List(Of String)

            Dim IdPersona As String = dgvClientes.CurrentRow.Cells("idpersona").Value.ToString
            Dim NombrePersona As String = dgvClientes.CurrentRow.Cells("nombre").Value.ToString + " " + dgvClientes.CurrentRow.Cells("apellido").Value.ToString

            'Si aún no hay nada cargado en el ComboBox
            If cbxTelefonosMCliente.DataSource Is Nothing Then

                'Obtiene los teléfonos de la persona seleccionada y los carga en el DataGridView, pero los borra de la BD (ya que serán ingresados nuevamente con (o sin) modificaciones)
                TelefonosPersona = conexion.EjecutarSelect("SELECT telefono FROM cliente WHERE idpersona = " + IdPersona + " ")

                Dim telefonospersonaS As String = ""
                Try
                    telefonospersonaS = TelefonosPersona.Rows(0)(0).ToString()
                Catch ex As Exception

                End Try

                Dim TelArray() As String = telefonospersonaS.Split(",")

                'Cargamos en una lista los teléfonos para no perderlos una vez que los borremos.
                For Each item As String In TelArray
                    ListaTelefonos.Add(item)
                Next

            Else

                For Each item As String In cbxTelefonosMCliente.Items
                    ListaTelefonos.Add(item)
                Next

            End If

            Dim ModificarTelefonos As New frmTelefonosCliente("Modificar", NombrePersona, cbxTelefonosMCliente, ListaTelefonos)

            If lblAyudaTelefono.Visible = True Then
                lblAyudaTelefono.Visible = False
            End If

            ModificarTelefonos.ShowDialog()
        End If
    End Sub

    Private Sub AgregarTelefonos(sender As Object, e As EventArgs) Handles btnAgregarTelefonosACliente.Click

        Dim ListaTelefonos As New List(Of String)

        For Each item In cbxTelefonosACliente.Items
            ListaTelefonos.Add(item.ToString)
        Next

        Dim AgregarTelefonos As New frmTelefonosCliente("Agregar", "", cbxTelefonosACliente, ListaTelefonos)
        AgregarTelefonos.ShowDialog()

    End Sub

    Private Sub btnVaciarFClientes_Click(sender As Object, e As EventArgs) Handles btnVaciarFClientes.Click

        For Each control As Control In pnlFClientes.Controls
            VaciarControl(control)
        Next

        chbxFechaFClientes.Checked = Not chbxFechaFClientes.Checked

    End Sub

    'REPORTES
    Private Sub ExportarMasAlquileres(sender As Object, e As EventArgs) Handles btnExportarMasAlquileresRClientes.Click

        CrearPDF(dgvMasAlquileresRClientes, "Clientes con más Alquileres")

    End Sub

End Class
