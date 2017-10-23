Public Class frmModificarReserva
    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionadaAlquiler
    Private Sub btnCerrarMsgbox_Click(sender As Object, e As EventArgs) Handles btnCerrarMsgbox.Click

        Me.DialogResult = vbNo
        Me.Dispose()

    End Sub

    Private Sub frmModificarReserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosComboBox(cbxTipo, conexion.Tipos.Select("estado = true").CopyToDataTable, "nombre", "idtipo")
        CargarDatosComboBox(cbxCategoria, conexion.Categorias.Select("estado = true").CopyToDataTable, "nombre", "idcategoria")
        ReservaSeleccionada.IdNuevaCategoria = cbxCategoria.SelectedValue
        ReservaSeleccionada.IdTipo = cbxTipo.SelectedValue
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Dim sentencia As String = "SELECT  V.*, Ma.nombre marca, Ma.idmarca, Mo.nombre modelo, T.nombre tipo, T.idtipo, C.nombre categoria, S.nombre Sucursal From Vehiculo V, Categoria C, Marca Ma, Modelo Mo, Tipo T, Sucursal S Where V.idsucursal = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "' AND V.idcategoria = '" + ReservaSeleccionada.IdNuevaCategoria.ToString + "' AND Mo.idtipo = '" + ReservaSeleccionada.IdTipo.ToString + "' AND V.idcategoria = C.idcategoria And V.idmodelo = Mo.idmodelo And Mo.Idmarca = Ma.Idmarca And Mo.Idtipo = T.idtipo And V.idsucursal = S.idsucursal And V.estado = 't' And  V.nrochasis Not IN (Select nrochasis FROM Mantenimiento WHERE (TO_DATE('" + Date.Now.ToString("dd/MM/yyyy HH:mm") + "', '%d/%m/%Y %H:%M') BETWEEN fechainicio AND fechafin ))"
        Dim Disponibles As New DataTable
        Disponibles = conexion.EjecutarSelect(sentencia)

        If Disponibles.Rows.Count <> 0 Then
            Me.DialogResult = vbYes
            Dim AlquilarReserva As New frmAlquilar(Disponibles, frmAlquilar.VistaAlquilar.Editado, ReservaSeleccionada)
            AlquilarReserva.ShowDialog(frmMainMenu)
            Me.Dispose()
        Else
            AmaranthMessagebox("No hay vehículos disponibles con estas características. Por favor, intente nuevamente.", "Error")
        End If

    End Sub

    Private Sub cbxCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategoria.SelectionChangeCommitted, cbxTipo.SelectionChangeCommitted
        ReservaSeleccionada.IdNuevaCategoria = cbxCategoria.SelectedValue
        ReservaSeleccionada.IdTipo = cbxTipo.SelectedValue
    End Sub

End Class