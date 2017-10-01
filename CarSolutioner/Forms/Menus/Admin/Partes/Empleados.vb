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
                                           "apellido", txtApellidoFempleado.Text) '+
        'TipoFiltro(cbxTipoFempleados, "id") '+
        'TipoFiltro(cbxSucursalFempleados, "idsucursal")
        Dim tiposeleccionado As String
        tiposeleccionado = cbxTipoFempleados.SelectedValue
        MsgBox(tiposeleccionado)

        dgvEmpleados.DataSource.Filter = filtro

    End Sub

    Private Sub AltaEmpleado(sender As Object, e As EventArgs) Handles btnAltaEmpleado.Click

        Dim fechActual As String

        fechActual = DateTime.Now.ToString("dd/MM/yyyy")

        ' Empleado: idpersona, tipo, usuario, estado  hehe cliente idpersona
        ' Trabaja:  usuarioempleado ==  usuario,
        ' Idsucursal == idsucursal Sucur, fechainicio, fechafin


        Dim idPersonaInsertar As String = conexion.EjecutarSelect("SELECT idpersona FROM Cliente WHERE nrodocumento = '" & txtNroDocumentoCempleado.Text & "'").Rows(0)(0).ToString()
        conexion.EjecutarNonQuery("Insert into empleado values (" + idPersonaInsertar + "," + cbxTipoCempleados.Text + ",'" +
                                                                    txtNombreUsuarioCempleado.Text + "," + cbxTipoCempleados.SelectedValue + ")")
        conexion.EjecutarNonQuery("insert into trabaja values (" + txtNombreUsuarioCempleado.Text + "," + cbxSucursalCempleados.SelectedValue + "," + fechActual + ",'0')")



        'vbDouble.
        'txtNroDocumentoCempleado.Text
        'cbxTipoCempleados.SelectedValue
        'cbxSucursalCempleados.SelectedValue
        'txtNombreUsuarioCempleado.Text






    End Sub


End Class
