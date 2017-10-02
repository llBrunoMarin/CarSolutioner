'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerEmpleados
End Class

'EMPLEADOS
Partial Public Class frmMainMenu


    Private Sub FiltrosEmpleados(sender As Object, e As EventArgs) Handles txtNroDocFempleado.TextChanged, cbxSucursalFempleados.TextChanged,
                                                                            cbxTipoFempleados.TextChanged, txtNombreFempleado.TextChanged,
                                                                             txtApellidoFempleado.TextChanged

        Dim filtro As String

        filtro = String.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%'",
                                           "nrodocumento", txtNroDocFempleado.Text,
                                           "nombre", txtNombreFempleado.Text,
                                           "apellido", txtApellidoFempleado.Text) ' +
        'TipoFiltro(cbxTipoFempleados, "tipos") ' +
        'TipoFiltro(cbxSucursalFempleados, "idsucursal")

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

            Dim idPersonaInsertar As String

            Try
                idPersonaInsertar = conexion.EjecutarSelect("select idpersona from cliente where nrodocumento = '" & txtNroDocumentoCempleado.Text & "'").Rows(0)(0).ToString()

                If (conexion.EjecutarNonQuery("insert into empleado values ('" + idPersonaInsertar.ToString + "','" + cbxTipoCempleados.SelectedValue.ToString + "','" + txtNombreUsuarioCempleado.Text.ToString + "','t')") = True) Then

                    If (conexion.EjecutarNonQuery("insert into trabaja values ('" + txtNombreUsuarioCempleado.Text + "','" + cbxSucursalCempleados.SelectedValue.ToString + "','" + fechActual.ToString + "',NULL)") = True) Then

                        MsgBox("Empleado insertado correctamente")

                        RecargarDatos(dgvEmpleados)

                    End If
                Else

                    MsgBox(" ")
                End If
            Catch ex As Exception
                If (ex.Message = "No hay ninguna fila en la posición 0.") Then
                    MsgBox("No existe ese nro documento")
                End If
            End Try

        Else
            MsgBox("Por favor, rellene todos los campos.")
        End If
    End Sub

    Private Sub RellenarDatosEmpleado(sender As Object, e As EventArgs) Handles dgvEmpleados.SelectionChanged

        If Not IsNothing(dgvEmpleados.CurrentRow) Then

            ' cbxSucursalMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("idsucursalE").Value.ToString()
            cbxTipoMempleados.SelectedValue = dgvEmpleados.CurrentRow.Cells("tipoEmpNum").Value.ToString()

        End If

    End Sub

    Private Sub ModificarEmpleado(sender As Object, e As EventArgs) Handles btnModificarEmpleado.Click

        Dim FaltaDato As Boolean = False


        For Each ctrl As Control In pnlAEmp.Controls
            If TypeOf (ctrl) Is TextBox Then
                If DirectCast(ctrl, TextBox).Text = "" Then
                    FaltaDato = True
                End If
            Else
                If TypeOf (ctrl) Is ComboBox Then
                    If DirectCast(ctrl, ComboBox).SelectedItem Is Nothing Then
                        FaltaDato = True
                    End If
                End If
            End If
        Next

        If (FaltaDato) Then
            Dim idPersonaInsertar As String
            Dim NombreUsuarioEmpM As String
            Try
                idPersonaInsertar = conexion.EjecutarSelect("select idpersona from cliente where nrodocumento = '" & dgvEmpleados.CurrentRow.Cells("nrodocumentoE").Value.ToString() & "'").Rows(0)(0).ToString()

                NombreUsuarioEmpM = dgvEmpleados.CurrentRow.Cells("usuarioE").Value.ToString()

                If (conexion.EjecutarNonQuery("UPDATE trabaja SET idsucursal = " + cbxSucursalMempleados.SelectedValue.ToString() + ",   WHERE usuarioempleado = '" + NombreUsuarioEmpM + "'") = True) Then

                    If (conexion.EjecutarNonQuery("UPDATE empleado SET tipo = " + cbxTipoMempleados.SelectedValue.ToString() + ",   WHERE idpersona = '" + idPersonaInsertar + "'") = True) Then

                        MsgBox("TO correcto")
                        RecargarDatos(dgvEmpleados)

                    Else
                        MsgBox("Modifica el tipo!")
                    End If

                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Else
            MsgBox("holax")
        End If


    End Sub
End Class
