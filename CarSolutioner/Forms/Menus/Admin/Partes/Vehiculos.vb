'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerVehiculos
End Class

'VEHICULOS
Partial Public Class frmMainMenu

    Private Sub CargasMarca(sender As Object, e As EventArgs) Handles cbxMarcaAVeh.SelectionChangeCommitted, cbxMarcaFVeh.SelectionChangeCommitted

        Dim Modelos As DataTable = conexion.EjecutarSelect("SELECT * from modelo")

        If Modelos.Select("nombre = 'Otro'").Count = 0 Then
            Modelos.Rows.Add(0, "Otro")
        End If

        If sender Is cbxMarcaAVeh Then

            Dim MarcaSeleccionada As String = (conexion.EjecutarSelect("SELECT idmarca from marca where marca = '" + cbxMarcaAVeh.SelectedValue.ToString + "'")).Rows(0)(0).ToString

            cbxModeloAVeh.BindingContext = New BindingContext
            cbxModeloAVeh.DataSource = Modelos.Select("idmarca = '" + MarcaSeleccionada + "'").CopyToDataTable.DefaultView
            cbxModeloAVeh.DisplayMember = "nombre"
            cbxModeloAVeh.ValueMember = "nombre"

        ElseIf sender Is cbxMarcaFVeh Then

            Dim MarcaSeleccionada As String = (conexion.EjecutarSelect("SELECT idmarca from marca where marca = '" + cbxMarcaFVeh.SelectedValue.ToString + "'")).Rows(0)(0).ToString

            cbxModeloFVeh.BindingContext = New BindingContext
            cbxModeloFVeh.DataSource = Modelos.Select("idmarca = '" + MarcaSeleccionada + "'").CopyToDataTable.DefaultView
            cbxModeloFVeh.DisplayMember = "nombre"
            cbxModeloFVeh.ValueMember = "nombre"

        End If

    End Sub


End Class
