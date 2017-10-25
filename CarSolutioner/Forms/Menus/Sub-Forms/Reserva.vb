Public Class Reserva
    Dim ReservaSeleccionada As ReservaSeleccionada
    Public Enum Tipo
        Agregar
        Modificar
    End Enum

    Dim AltaModif As Tipo
    Public Sub New(reserva As ReservaSeleccionada, tipo As Reserva.Tipo)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ReservaSeleccionada = reserva
        Me.AltaModif = tipo

    End Sub

    Private Sub Reserva_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTitulo.Text = "Reserva de: " + ReservaSeleccionada.NomCliente + ""
        dtpInicio.Value = ReservaSeleccionada.FechaReservaInicio
        dtpFin.Value = ReservaSeleccionada.FechaReservaFin
        txtSucursalPartida.Text = conexion.Sucursales.Select("idsucursal = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtSucursalDestino.Text = conexion.Sucursales.Select("idsucursal = '" + ReservaSeleccionada.IdSucursalDestino.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtCategoriaElegida.Text = conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)("nombre").ToString
        txtCantidadDias.Text = (dtpFin.Value - dtpInicio.Value).Days
        txtKMElegidos.Text = conexion.Kilometros.Select("id = '" + ReservaSeleccionada.IdCantKM.ToString + "'").CopyToDataTable.Rows(0)("km").ToString
        txtDescuentoCliente.Text = ReservaSeleccionada.DescuentoCliente.ToString

        CalcularCosto()

    End Sub

    Private Sub CalcularCosto()
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
                lblAdvertencia.Text = "Atención: Esto quiere decir que el cliente podrá recorrer un máximo de " + (150 * ((dtpFin.Value - dtpInicio.Value).Days)).ToString + " KM en total en todo el alquiler."
            Case 2
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(3).ToString)
                lblAdvertencia.Text = "Atención: Esto quiere decir que el cliente podrá recorrer un máximo de " + (300 * ((dtpFin.Value - dtpInicio.Value).Days)).ToString + " KM en total en todo el alquiler."

            Case 3
                TarifaDiariaBase = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(1).ToString)
                TarifaDiariaKM = CInt(conexion.Categorias.Select("idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "'").CopyToDataTable.Rows(0)(4).ToString)
                lblAdvertencia.Text = "Atención: Esto quiere decir que el cliente podrá recorrer todos los KM que desee en todo el alquiler."

        End Select

        CostoAlqEstimado = (TarifaDiariaBase + TarifaDiariaKM) * ((dtpFin.Value - dtpInicio.Value).Days)
        DescuentoCalc = (CostoAlqEstimado * ReservaSeleccionada.DescuentoCliente) / 100
        CostoTotalEstimado = CostoAlqEstimado - DescuentoCalc

        ReservaSeleccionada.CostoTotal = CostoTotalEstimado

        txtCostoAlqEstimado.Text = CostoAlqEstimado.ToString()
        txtDescuento.Text = DescuentoCalc.ToString()
        txtCostoTotalEstimado.Text = CostoTotalEstimado.ToString()

    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click

        If Me.AltaModif = Tipo.Agregar Then
            conexion.EjecutarNonQuery("INSERT INTO Reserva VALUES (0, NULL, NULL, '" + ReservaSeleccionada.FechaReservaInicio.ToString("yyyy-MM-dd HH:mm") + "', '" + ReservaSeleccionada.FechaReservaFin.ToString("yyyy-MM-dd HH:mm") + "', '" + ReservaSeleccionada.IdCantKM.ToString + "', '" + ReservaSeleccionada.CostoTotal.ToString + "', '" + Date.Now.ToString("yyyy-MM-dd HH:mm") + "', 1, NULL, '" + ReservaSeleccionada.IdCliente.ToString + "', '" + ReservaSeleccionada.IdCategoria.ToString + "', '" + ReservaSeleccionada.IdTipo.ToString + "', '" + ReservaSeleccionada.IdSucursalPartida.ToString + "', '" + ReservaSeleccionada.IdSucursalDestino.ToString + "', '" + conexion.Usuario + "'  )")
            AmaranthMessagebox("Reserva ingresada correctamente", "Continuar", Me)
        Else

            Dim sentencia As String = "UPDATE RESERVA SET fechaalquilerinicio = NULL, 
                                       fechaalquilerfin = NULL,
                                       fechareservainicio = '" + ReservaSeleccionada.FechaReservaInicio.ToString("yyyy-MM-dd HH:mm") + "', 
                                       fechareservafin = '" + ReservaSeleccionada.FechaReservaFin.ToString("yyyy-MM-dd HH:mm") + "', 
                                       cantidadkm = '" + ReservaSeleccionada.IdCantKM.ToString + "',
                                       costototal = '" + ReservaSeleccionada.CostoTotal.ToString + "', 
                                       estado = '1', 
                                       nrochasis = NULL, idpersona = '" + ReservaSeleccionada.IdCliente.ToString + "', 
                                       idcategoria = '" + ReservaSeleccionada.IdCategoria.ToString + "', 
                                       idtipo = '" + ReservaSeleccionada.IdTipo.ToString + "',
                                       idsucursalsalida = '" + ReservaSeleccionada.IdSucursalPartida.ToString + "', 
                                       idsucursalllegada = '" + ReservaSeleccionada.IdSucursalDestino.ToString + "'
                                       WHERE idreserva = '" + ReservaSeleccionada.IdReserva.ToString + "'"

            conexion.EjecutarNonQuery(sentencia)

            AmaranthMessagebox("Reserva modificada correctamente", "Continuar", Me)
        End If

        RecargarDatosEspecificos(Me.Owner, "dgvReservas")
        Me.Dispose()

    End Sub

    Private Function CargarDescuentoCliente(id As Integer) As Integer
        Return CInt(conexion.EjecutarSelect("SELECT porcdescuento FROM Cliente WHERE idpersona = '" + id.ToString + "'").Rows(0)(0).ToString)
    End Function

    Private Sub btnAgregarDescuentoCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarDescuentoCliente.Click
        If Autorizar(Me) = vbYes Then

            Dim descuento As New DescuentoPersonalCliente(ReservaSeleccionada.IdCliente)
            descuento.ShowDialog()
            txtDescuentoCliente.Enabled = True
            txtDescuentoCliente.Text = CargarDescuentoCliente(ReservaSeleccionada.IdCliente)
            txtDescuentoCliente.Enabled = False
            ReservaSeleccionada.DescuentoCliente = txtDescuentoCliente.Text
            CalcularCosto()
        Else

        End If
    End Sub
End Class