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

        If Not (FaltaDato) Then

            Dim idPersonaInsertar As String

            Try
                idPersonaInsertar = conexion.EjecutarSelect("select idpersona from cliente where nrodocumento = '" & txtNroDocumentoCempleado.Text & "'").Rows(0)(0).ToString()

                If (conexion.EjecutarNonQuery("insert into empleado values ('" + idPersonaInsertar.ToString + "',
                                                                    '" + cbxTipoCempleados.SelectedValue.ToString + "',
                                                                    '" + txtNombreUsuarioCempleado.Text.ToString + "','t')") = True And
                                                                    conexion.EjecutarNonQuery("insert into trabaja values ('" + txtNombreUsuarioCempleado.Text + "',
                                                                    '" + cbxSucursalCempleados.SelectedValue.ToString + "',
                                                                    '" + fechActual.ToString + "',NULL)") = True) Then

                    MsgBox("Empleado insertado correctamente")

                    RecargarDatos(dgvEmpleados)

                Else
                    MsgBox("Existe un error, ya existe es usuario")
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

            txtNroDocMempleado.Text = dgvEmpleados.CurrentRow.Cells("nrodocumentoE").Value.ToString()
            txtNombreUsuarioMEmpleado.Text = dgvEmpleados.CurrentRow.Cells("nombreE").Value.ToString
            cbxTipoMempleados.SelectedIndex = cbxTipoMempleados.FindString(dgvEmpleados.CurrentRow.Cells("tipoE").Value.ToString())
            cbxSucursalMempleados.SelectedIndex = cbxSucursalMempleados.FindString(dgvEmpleados.CurrentRow.Cells("sucursalesE").Value.ToString())

        End If

    End Sub

End Class
