'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerEmpleados
End Class

'EMPLEADOS
Partial Public Class frmMainMenu

    Private Sub BorrarTipoEmpleado(sender As Object, e As EventArgs) Handles lblBorrarTipoFEmpleado.Click
        cbxTipoFempleados.SelectedItem = Nothing
    End Sub
    Private Sub BorrarSucEmpleado(sender As Object, e As EventArgs) Handles lblBorrarSucursalFEmpleado.Click
        cbxSucursalFempleados.SelectedItem = Nothing
    End Sub
    Private Sub FiltrosEmpleados(sender As Object, e As EventArgs) Handles txtNroDocFempleado.TextChanged, cbxSucursalFempleados.TextChanged,
                                                                            cbxTipoFempleados.SelectionChangeCommitted, txtNombreFempleado.TextChanged,
                                                                             txtApellidoFempleado.TextChanged, lblBorrarTipoFEmpleado.Click, lblBorrarSucursalFEmpleado.Click

        Dim filtro As String

        filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%'",
                                           "nrodocumento", txtNroDocFempleado.Text,
                                           "nombre", txtNombreFempleado.Text,
                                           "apellido", txtApellidoFempleado.Text) + TipoFiltro(cbxTipoFempleados, "idtipo") '+ TipoFiltro(cbxSucursalFempleados, "idsucursalE")

        dgvEmpleados.DataSource.Filter = filtro

    End Sub

    Private Sub AltaEmpleado(sender As Object, e As EventArgs) Handles btnAltaEmpleado.Click

        Dim fechActual As String

        fechActual = DateTime.Now.ToString("dd/MM/yyyy")

        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlAEmp.Controls
            If TypeOf (ctrl) Is ComboBox Then
                If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                    FaltaDato = True
                End If
            End If
        Next

        If Not (FaltaDato) Then
            Dim idPersonaInsertar As New DataTable

            idPersonaInsertar = conexion.EjecutarSelect("select idpersona from cliente where nrodocumento = '" & txtNroDocumentoCempleado.Text & "'")

            If (idPersonaInsertar.Rows.Count <> 0) Then
                Dim IdPersona As String = idPersonaInsertar.Rows(0)("idpersona").ToString()

                If (conexion.EjecutarNonQuery("insert into empleado values ('" + IdPersona + "','" + cbxTipoCempleados.SelectedValue.ToString + "','" + txtNombreUsuarioCempleado.Text.ToString + "','t')") = True) Then

                    If (conexion.EjecutarNonQuery("insert into trabaja values ('" + txtNombreUsuarioCempleado.Text + "','" + cbxSucursalCempleados.SelectedValue.ToString + "','" + fechActual.ToString + "',NULL)") = True) Then

                        MsgBox("Empleado insertado correctamente")
                        RecargarDatos(dgvEmpleados)

                    End If
                Else
                    MsgBox(" noseqpaso")
                End If

            Else
                MsgBox("Ese cliente no existe. Por favor, verifique.")

            End If

        Else
            MsgBox("Por favor, rellene todos los campos.")
        End If
    End Sub

    Private Sub RellenarDatosEmpleado(sender As Object, e As EventArgs) Handles dgvEmpleados.SelectionChanged

        If Not IsNothing(dgvEmpleados.CurrentRow) Then

            cbxSucursalMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("idsucursalE").Value.ToString()
            cbxTipoMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("idtipo").Value.ToString()
            txtNroDocEempleado.Text = dgvEmpleados.CurrentRow.Cells("nrodocumentoE").Value.ToString()
        End If

    End Sub

    Private Sub ActualizarEstadoEmpleado(sender As Object, e As EventArgs) Handles btnEstadoEmpleado.Click

        Dim Valores As New Dictionary(Of Boolean, String)
        Valores.Add(True, "Activo")
        Valores.Add(False, "Inactivo")

        Dim idpersonaUsuarioEmpA As New DataTable

        idpersonaUsuarioEmpA = conexion.EjecutarSelect("SELECT empleado.idpersona, empleado.estado, 
                                                               cliente.nrodocumento, cliente.idpersona
                                                               FROM empleado,cliente 
                                                               WHERE cliente.idpersona = empleado.idpersona
                                                               AND nrodocumento = '" & txtNroDocEempleado.Text & "'")

        If (idpersonaUsuarioEmpA.Rows.Count <> 0) Then
            Dim IdPersona As String = idpersonaUsuarioEmpA.Rows(0)("idpersona").ToString()
            Dim EstadoActual As Boolean = idpersonaUsuarioEmpA.Rows(0)("estado")
            Dim NuevoEstado As Boolean = Not EstadoActual
            If (conexion.EjecutarNonQuery("UPDATE empleado SET estado ='" + NuevoEstado.ToString().Substring(0, 1) + "' WHERE idpersona = " + IdPersona + "")) Then

                MsgBox("Empleado pasó del estado " + Valores.Item(EstadoActual) + " a " + Valores.Item(NuevoEstado) + "")
                RecargarDatos(dgvEmpleados)
            End If
        Else
            MsgBox("Ese cliente no existe. Por favor, verifique.")

        End If


    End Sub


    Private Sub ModificarEmpleado(sender As Object, e As EventArgs) Handles btnModificarEmpleado.Click

        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlAEmp.Controls
            If TypeOf (ctrl) Is ComboBox Then
                If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                    FaltaDato = True
                End If
            End If
        Next

        If Not (FaltaDato) Then
            Dim idPersonaUsuarioEM As String
            Dim NombreUsuarioEmpM As String
            Dim SucursalUsuarioEmpM As String
            Dim TipoUsuarioEmpM As String
            Try

                idPersonaUsuarioEM = conexion.EjecutarSelect("select idpersona from cliente where nrodocumento = '" & dgvEmpleados.CurrentRow.Cells("nrodocumentoE").Value.ToString() & "'").Rows(0)(0).ToString()
                NombreUsuarioEmpM = dgvEmpleados.CurrentRow.Cells("usuarioE").Value.ToString()
                SucursalUsuarioEmpM = cbxSucursalMempleados.SelectedValue.ToString()
                TipoUsuarioEmpM = cbxTipoMempleados.SelectedValue.ToString()

                If (conexion.EjecutarNonQuery("UPDATE trabaja SET idsucursal = " + SucursalUsuarioEmpM + " WHERE usuarioempleado = '" + NombreUsuarioEmpM + "'") = True) Then
                    If (conexion.EjecutarNonQuery("UPDATE empleado SET tipo = " + TipoUsuarioEmpM + "   WHERE idpersona = '" + idPersonaUsuarioEM + "'") = True) Then

                        MsgBox("Empleado Modificado Correctamente")
                        RecargarDatos(dgvEmpleados)

                    Else
                        MsgBox("Modifica el tipo!")
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Else
            MsgBox("Faltan campos")
        End If


    End Sub
End Class
