﻿'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerEmpleadosInvitado
End Class

'EMPLEADOS
Partial Public Class frmMainMenuInvitado

    Private Sub BorrarTipoEmpleado(sender As Object, e As EventArgs) Handles lblBorrarTipoFEmpleado.Click
        cbxTipoFempleados.SelectedItem = Nothing
    End Sub

    Private Sub BorrarSucEmpleado(sender As Object, e As EventArgs) Handles lblBorrarSucursalFEmpleado.Click
        cbxSucursalFempleados.SelectedItem = Nothing
    End Sub

    Private Sub VaciarDatos(sender As Object, e As EventArgs) Handles btnVaciarFEmpleado.Click

        For Each item In pnlFemp.Controls
            If TypeOf item Is TextBox Then
                item.text = ""
            End If

            If TypeOf item Is ComboBox Then
                item.SelectedItem = Nothing
            End If
        Next

    End Sub

    Private Sub FiltrosEmpleados(sender As Object, e As EventArgs) Handles txtNroDocFempleado.TextChanged, cbxSucursalFempleados.SelectionChangeCommitted, cbxTipoFempleados.SelectionChangeCommitted, txtNombreFempleado.TextChanged, txtApellidoFempleado.TextChanged, lblBorrarTipoFEmpleado.Click, lblBorrarSucursalFEmpleado.Click, btnVaciarFEmpleado.Click

        Dim filtro As String

        filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%'", "nrodocumento", txtNroDocFempleado.Text, "nombre", txtNombreFempleado.Text, "apellido", txtApellidoFempleado.Text) + TipoFiltro(cbxTipoFempleados, "idtipo") + TipoFiltro(cbxSucursalFempleados, "idsucursal")

        dgvEmpleados.DataSource.Filter = filtro

    End Sub

    Private Sub AltaEmpleado(sender As Object, e As EventArgs) Handles btnAltaEmpleado.Click

        Dim fechActual As String

        fechActual = DateTime.Now.ToString("dd/MM/yyyy")

        Dim FaltaDato As Boolean = False

        For Each ctrl As Control In pnlAEmp.Controls
            If TypeOf (ctrl) Is TextBox Then
                If Not ctrl.Name = "txtCorreoACliente" Then
                    If ctrl.Text = "" Then
                        FaltaDato = True
                        Exit For
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
            Dim idPersonaInsertar As New DataTable

            idPersonaInsertar = conexion.EjecutarSelect("SELECT idpersona FROM cliente WHERE nrodocumento = '" + txtNroDocumentoCempleado.Text.ToString + "'")


            If (idPersonaInsertar.Rows.Count <> 0) Then

                Dim idpersonaRepetido As New DataTable
                idpersonaRepetido = conexion.EjecutarSelect("SELECT idpersona FROM empleado where idpersona = '" + idPersonaInsertar.Rows(0)(0).ToString + "'")

                Dim NombreUsuarioEmpA As String = dgvEmpleados.CurrentRow.Cells("usuariosEmpleado").Value.ToString()

                If Not (NombreUsuarioEmpA = txtNombreUsuarioCempleado.Text) Then

                    If Not (idpersonaRepetido.Rows.Count <> 0) Then

                        Dim IdPersona As String = idPersonaInsertar.Rows(0)("idpersona").ToString()

                        If (conexion.EjecutarNonQuery("INSERT INTO empleado VALUES ('" + IdPersona + "','" + cbxTipoCempleados.SelectedValue.ToString + "','" + txtNombreUsuarioCempleado.Text.ToString + "','t')") = True) Then

                            If (conexion.EjecutarNonQuery("INSERT INTO trabaja VALUES ('" + txtNombreUsuarioCempleado.Text + "','" + cbxSucursalCempleados.SelectedValue.ToString + "','" + fechActual.ToString + "',NULL)") = True) Then

                                MsgBox("Empleado insertado correctamente")
                                RecargarDatos(dgvEmpleados)
                            End If
                        Else
                            MsgBox("Error en el insert")
                        End If
                    Else
                        MsgBox("Este empleado ya existe")
                    End If
                Else
                    AmaranthMessagebox("Ya existe un empleado con este nombre de usuario", "Advertencia")
                End If
            Else
                    MsgBox("Ese cliente no existe por favor verifique")
            End If
        Else
            MsgBox("Por favor, rellene todos los campos.")
        End If
    End Sub

    Private Sub RellenarDatosEmpleado(sender As Object, e As EventArgs) Handles dgvEmpleados.SelectionChanged

        If Not IsNothing(dgvEmpleados.CurrentRow) Then

            cbxSucursalMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("idsucursalEmpleado").Value.ToString()
            cbxTipoMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("idtipoEmpleado").Value.ToString()
            txtNroDocEempleado.Text = dgvEmpleados.CurrentRow.Cells("nrodocumentoEmpleado").Value.ToString()
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
        If Not (txtNroDocEempleado.Text = "") Then
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
        Else
            AmaranthMessagebox("Ingrese un número de documento", "Advertencia")
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
            Dim fechActual As String
            Dim TipoEmpleadoDGV As String
            Dim SucursalEmpleadoDGV As String
            fechActual = DateTime.Now.ToString("dd/MM/yyyy")

            Try

                idPersonaUsuarioEM = conexion.EjecutarSelect("SELECT idpersona FROM cliente WHERE nrodocumento = '" & dgvEmpleados.CurrentRow.Cells("nrodocumentoEmpleado").Value.ToString() & "'").Rows(0)(0).ToString()
                NombreUsuarioEmpM = dgvEmpleados.CurrentRow.Cells("usuariosEmpleado").Value.ToString()
                TipoEmpleadoDGV = dgvEmpleados.CurrentRow.Cells("idtipoEmpleado").Value.ToString()
                SucursalEmpleadoDGV = dgvEmpleados.CurrentRow.Cells("idsucursalEmpleado").Value.ToString()
                SucursalUsuarioEmpM = cbxSucursalMempleados.SelectedValue
                TipoUsuarioEmpM = cbxTipoMempleados.SelectedValue

                Dim test As New DataTable
                test = conexion.EjecutarSelect("SELECT * FROM trabaja WHERE usuarioempleado ='" + NombreUsuarioEmpM + "' and fechafin is NULL")
                If (test.Rows.Count <> 0) Then


                    Dim UsuarioEUpdate As String = test.Rows(0)("usuarioempleado").ToString()
                    Dim SucursalEUpdate As String = test.Rows(0)("idsucursal").ToString()
                    Dim FechaiEUpdate As String = Date.Parse(test.Rows(0)("fechainicio").ToString()).ToShortDateString

                    If Not (TipoUsuarioEmpM.ToString() = TipoEmpleadoDGV And SucursalUsuarioEmpM.ToString() = SucursalEmpleadoDGV) Then

                        If (TipoUsuarioEmpM.ToString() <> TipoEmpleadoDGV And SucursalUsuarioEmpM.ToString <> SucursalEmpleadoDGV) Then

                            conexion.EjecutarNonQuery("UPDATE empleado SET tipo = " + TipoUsuarioEmpM + " WHERE idpersona = '" + idPersonaUsuarioEM + "'")
                            conexion.EjecutarNonQuery("UPDATE trabaja SET fechafin = '" + fechActual + "' WHERE usuarioempleado = '" + UsuarioEUpdate + "' AND idsucursal = '" + SucursalEUpdate + "' AND fechainicio = '" + FechaiEUpdate + "'")
                            conexion.EjecutarNonQuery("INSERT INTO trabaja VALUES ('" + NombreUsuarioEmpM + "','" + SucursalUsuarioEmpM + "','" + fechActual + "',NULL)")

                            MsgBox("Empleado modificado correctamente")
                            RecargarDatos(dgvEmpleados)
                        ElseIf (TipoUsuarioEmpM.ToString() <> TipoEmpleadoDGV) Then
                            conexion.EjecutarNonQuery("UPDATE empleado SET tipo = " + TipoUsuarioEmpM + " WHERE idpersona = '" + idPersonaUsuarioEM + "'")
                            MsgBox("Tipo empleado modificado correctamente")
                            RecargarDatos(dgvEmpleados)
                        ElseIf (SucursalUsuarioEmpM.ToString <> SucursalEmpleadoDGV) Then
                            conexion.EjecutarNonQuery("UPDATE trabaja SET fechafin = '" + fechActual + "' WHERE usuarioempleado = '" + UsuarioEUpdate + "' AND idsucursal = '" + SucursalEUpdate + "' AND fechainicio = '" + FechaiEUpdate + "'")
                            conexion.EjecutarNonQuery("INSERT INTO trabaja VALUES ('" + NombreUsuarioEmpM + "','" + SucursalUsuarioEmpM + "','" + fechActual + "',NULL)")
                            MsgBox("Sucursal empleado modificada correctamente")
                            RecargarDatos(dgvEmpleados)

                        End If

                    Else
                            MsgBox("Debe modificar algo")
                    End If

                Else
                    MsgBox("error no existe ese empleado")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Faltan campos")
        End If


    End Sub



End Class