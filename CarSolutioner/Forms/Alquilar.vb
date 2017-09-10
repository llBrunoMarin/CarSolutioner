Public Class frmAlquilar

    Dim conexion As ConnectionBD = Login.conexion
    Dim CategoriaReserva As String
    Dim nombre As String
    Dim apellido As String
    Dim TipoReserva As String
    Dim SucursalIReserva As String
    Dim ClienteReserva As String
    Dim ResInicio As Date
    Dim ResFin As Date

    Dim cantidadkm As String
    Dim fechatramite2 As String
    Dim fechatramite As Date
    Dim tarifakm As Integer
    Dim resfin2 As String
    Dim res2 As String
    Dim idpersonaI As Integer
    Dim diasalquilados As Integer
    Dim filtro As String
    Dim fuente As New BindingSource

    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated, Me.Load

        'obtenemos fuente del dgvAlquilar
        fuente = dgvAlquilar.DataSource

        cantidadkm = frmMainMenu.cantidadkm
        TipoReserva = frmMainMenu.tipo
        CategoriaReserva = frmMainMenu.categoria
        SucursalIReserva = frmMainMenu.sucursal
        nombre = frmMainMenu.nombre
        apellido = frmMainMenu.apellido
        'Juntamos nombre con apellido 
        ClienteReserva = frmMainMenu.nombre + " " + frmMainMenu.apellido
        ResFin = frmMainMenu.resFfin
        ResInicio = frmMainMenu.resFinicio
        fechatramite = frmMainMenu.fechaTramite

        'estos llenan los datetime picker
        dtpFRInicio.Value = ResInicio
        dtpFRfin.Value = ResFin
        dtpFAinicio.Value = ResInicio
        dtpFAfin.Value = ResFin

        txtTipo.Text = TipoReserva
        txtCategoria.Text = CategoriaReserva
        txtSucursal.Text = SucursalIReserva
        txtCliente.Text = ClienteReserva
        fechatramite2 = fechatramite
        'Pasamos las variables date a string para poder hacer el insert
        resfin2 = ResFin
        res2 = ResInicio

        'Resta de fechas para saber los dias
        Dim resultado As TimeSpan
        resultado = ResFin - ResInicio
        diasalquilados = resultado.Days

        'filtramos el dgv con las reservas para esa persona
        filtro = "categoria = '" + CategoriaReserva + "' AND tipo = '" + TipoReserva + "' AND sucursal = '" + SucursalIReserva + "'"
        fuente.Filter = filtro
        dgvAlquilar.DataSource = fuente

    End Sub

    'Doble click en el dgv alquilar
    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal r As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAlquilar.CellMouseDoubleClick

        Dim nrchasis As String
        Dim idpersona As String
        Dim sucursalS As String
        Dim sucursalL As String
        Dim idcategoria As String
        Dim preciokm As String
        Dim idtipo As String
        Dim precioxdia
        Dim preciofinal As String

        If r.RowIndex >= 0 AndAlso r.ColumnIndex >= 0 Then
            Dim selectedRow = dgvAlquilar.Rows(r.RowIndex)
            'Cuentas para el precio final 
            Dim valorcategoria As DataTable = conexion.EjecutarSelect("Select idcategoria from categoria where nombre='" + CategoriaReserva + "'")
            Dim cat = ""
            For Each dr As DataRow In valorcategoria.Rows
                cat &= dr.Item(0).ToString
                idcategoria = cat
            Next
            'Cuentas para el precio final 
            Dim precio As DataTable = conexion.EjecutarSelect("Select tarifadiariabase,tarifax150kmdia,tarifax300kmdia,tarifakmlibredia from categoria where nombre='" + CategoriaReserva + "'")
            If cantidadkm = 1 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifax150kmdia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If
            'Cuentas para el precio final 
            If cantidadkm = 2 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifax300kmdia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If
            'Cuentas para el precio final 
            If cantidadkm = 3 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifakmlibredia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If

            'Obtenemos el id de tipo de reserva
            Dim valortipo As DataTable = conexion.EjecutarSelect("Select idtipo from tipo where nombre='" + TipoReserva + "'")
            Dim tipoid = ""
            For Each dr As DataRow In valortipo.Rows
                tipoid &= dr.Item(0).ToString
                idtipo = tipoid
            Next

            'Obtenemos el nro de chasis, tenemos la matricula
            Dim matricula As String
            matricula = selectedRow.Cells(0).Value.ToString
            Dim valorchasis As DataTable = conexion.EjecutarSelect("Select nrochasis from vehiculo where matricula='" + matricula + "'")
            Dim chas = ""
            For Each dr As DataRow In valorchasis.Rows
                chas &= dr.Item(0).ToString
                nrchasis = chas
            Next

            'Obtenemos el id de persona, tenemos apellido y nombre
            Dim valorpersona As DataTable = conexion.EjecutarSelect("Select idpersona from cliente where nombre='" + nombre + "'
                                                                                                   and apellido='" + apellido + "' ")
            Dim idp = ""
            For Each ar As DataRow In valorpersona.Rows
                idp &= ar.Item(0).ToString
                idpersona = idp
            Next
            'Obtenemos idsucursalllegada y idsucursalsalida
            Dim sucursales As DataTable = conexion.EjecutarSelect("select idsucursalllegada,idsucursalsalida from reserva where idpersona='" + idpersona + "'
                                                                                                              and fechareservainicio='" + res2 + "'
                                                                                                              and fechareservafin='" + resfin2 + "'")
            sucursalS = sucursales.Rows(0).Item("idsucursalsalida")
            sucursalL = sucursales.Rows(0).Item("idsucursalllegada")
        End If

        Dim resultado As MsgBoxResult
        resultado = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then
            conexion.RellenarDataGridView(dgvAlquilar, "insert into reserva values (0,'" + res2 + "','" + resfin2 + "','" + res2 + "',
            '" + resfin2 + "','" + cantidadkm + "','" + preciofinal + "','" + fechatramite2 + "',1,'" + nrchasis + "','" + idpersona + "',
            '" + idcategoria + "','" + idtipo + "','" + sucursalS + "','" + sucursalL + "','" + conexion.Usuario + "')")

            'Asignamos la fuente nuevamente para poder filtrar todas las veces que quieramos
            dgvAlquilar.DataSource = fuente
            MsgBox("Alquiler Ingresado")
            Me.Hide()

        End If

    End Sub

    'Boton cerrar
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

End Class