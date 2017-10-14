Public Class Reserva
    Dim ReservaSeleccionada As ReservaSeleccionada = frmMainMenu.ReservaSeleccionadaReserva


    Private Sub Reserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Reserva de: " + ReservaSeleccionada.NomCliente + ""
        dtpInicio.Value = ReservaSeleccionada.FechaReservaInicio
        dtpFin.Value = ReservaSeleccionada.FechaReservaFin
        txtSucursalPartida.Text = conexion.Sucursales.Select("idsucursal = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtSucursalDestino.Text = conexion.Sucursales.Select("idsucursal = '" + ReservaSeleccionada.IdSucursalDestino.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtCategoriaElegida.Text = conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtCantidadDias.Text = (dtpFin.Value - dtpInicio.Value).Days + 1
        txtKMElegidos.Text = conexion.Kilometros.Select("id = '" + ReservaSeleccionada.IdCantKM.ToString + "'").CopyToDataTable.Rows(0)("km").ToString
        txtDescuentoCliente.Text = ReservaSeleccionada.DescuentoCliente.ToString

        'Valores Seleccionados
        Dim TarifaDiariaBase As Integer
        Dim TarifaDiariaKM As Integer
        Dim CostoAlqEstimado As Integer
        Dim DescuentoCalc As Integer
        Dim CostoTotalEstimado

        Select Case ReservaSeleccionada.IdCantKM
            Case 1
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(2).ToString)
            Case 2
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
            Case 3
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)

        End Select

        CostoAlqEstimado = (TarifaDiariaBase + TarifaDiariaKM) * ((dtpFin.Value - dtpInicio.Value).Days + 1)
        DescuentoCalc = (CostoAlqEstimado * ReservaSeleccionada.DescuentoCliente) / 100
        CostoTotalEstimado = CostoAlqEstimado - DescuentoCalc

        ReservaSeleccionada.CostoTotal = CostoTotalEstimado

        txtCostoAlqEstimado.Text = CostoAlqEstimado.ToString()
        txtDescuento.Text = DescuentoCalc.ToString()
        txtCostoTotalEstimado.Text = CostoTotalEstimado.ToString()


    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click

        conexion.EjecutarNonQuery("INSERT INTO Reserva VALUES (0, NULL, NULL, '" + ReservaSeleccionada.FechaReservaInicio.ToString("yyyy-MM-dd hh:mm") + "', '" + ReservaSeleccionada.FechaReservaFin.ToString("yyyy-MM-dd hh:mm") + "', '" + ReservaSeleccionada.IdCantKM + "', '" + ReservaSeleccionada.CostoTotal + "', '" + Date.Today.ToString("yyyy-MM-dd hh:mm") + "', 1, NULL, '" + ReservaSeleccionada.IdCliente.ToString + "', '" + ReservaSeleccionada.IdCategoria.ToString + "', '" + ReservaSeleccionada.IdTipo.ToString + "', '" + ReservaSeleccionada.IdSucursalPartida.ToString + "', '" + ReservaSeleccionada.IdSucursalDestino.ToString + "', '" + conexion.Usuario + "'  )")
        frmMainMenu.CargarDatos()
        AmaranthMessagebox("Reserva ingresada correctamente!", "Continuar")
        Me.Dispose()

    End Sub
End Class