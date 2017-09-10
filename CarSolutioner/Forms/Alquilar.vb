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
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()

    End Sub
    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated, Me.Load


        cantidadkm = frmMainMenu.cantidadkm
        fuente = dgvAlquilar.DataSource
        TipoReserva = frmMainMenu.tipo
        CategoriaReserva = frmMainMenu.categoria
        SucursalIReserva = frmMainMenu.sucursal
        nombre = frmMainMenu.nombre
        apellido = frmMainMenu.apellido
        ClienteReserva = frmMainMenu.nombre + " " + frmMainMenu.apellido
        ResFin = frmMainMenu.resFfin
        ResInicio = frmMainMenu.resFinicio


        dtpFAfin.Value = ResFin
        ' dtpFAinicio.Value = ResInicio
        dtpFRfin.Value = ResFin
        dtpFRInicio.Value = ResInicio
        dtpFAinicio.Value = ResInicio

        'estos llenan los datetime picker
        fechatramite = frmMainMenu.fechaTramite



        txtTipo.Text = TipoReserva
        txtCategoria.Text = CategoriaReserva
        txtSucursal.Text = SucursalIReserva
        txtCliente.Text = ClienteReserva


        fechatramite2 = fechatramite

        resfin2 = ResFin
        res2 = ResInicio


        'resta de fechas para saber los dias
        Dim resultado As TimeSpan
        resultado = ResFin - ResInicio
        diasalquilados = resultado.Days


        filtro = "categoria = '" + CategoriaReserva + "' AND tipo = '" + TipoReserva + "' AND sucursal = '" + SucursalIReserva + "'"

        fuente.Filter = filtro

        dgvAlquilar.DataSource = fuente

    End Sub


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
            Dim valorcategoria As DataTable = conexion.EjecutarSelect("Select idcategoria from categoria where nombre='" + CategoriaReserva + "'")
            Dim cat = ""
            For Each dr As DataRow In valorcategoria.Rows
                cat &= dr.Item(0).ToString
                idcategoria = cat
            Next
            Dim precio As DataTable = conexion.EjecutarSelect("Select tarifadiariabase,tarifax150kmdia,tarifax300kmdia,tarifakmlibredia from categoria where nombre='" + CategoriaReserva + "'")
            If cantidadkm = 1 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifax150kmdia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If
            If cantidadkm = 2 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifax300kmdia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If
            If cantidadkm = 3 Then
                precioxdia = precio.Rows(0).Item("tarifadiariabase")
                tarifakm = precio.Rows(0).Item("tarifakmlibredia")
                preciofinal = precioxdia * diasalquilados + tarifakm * diasalquilados
            End If

            Dim valortipo As DataTable = conexion.EjecutarSelect("Select idtipo from tipo where nombre='" + TipoReserva + "'")
                Dim tip = ""
                For Each dr As DataRow In valortipo.Rows
                    tip &= dr.Item(0).ToString
                    idtipo = tip
                Next

                Dim matricula As String
                matricula = selectedRow.Cells(0).Value.ToString

                Dim valorchasis As DataTable = conexion.EjecutarSelect("Select nrochasis from vehiculo where matricula='" + matricula + "'")
                Dim c = ""
                For Each dr As DataRow In valorchasis.Rows
                    c &= dr.Item(0).ToString
                    nrchasis = c
                Next

                Dim valorpersona As DataTable = conexion.EjecutarSelect("Select idpersona from cliente where nombre='" + nombre +
                                                                                        "'and apellido='" + apellido + "' ")

                Dim a = ""
                For Each ar As DataRow In valorpersona.Rows
                    a &= ar.Item(0).ToString
                    idpersona = a
                Next



                Dim valorsucursals As DataTable = conexion.EjecutarSelect("select idsucursalsalida from reserva where idpersona='" + idpersona + "'
and fechareservainicio='" + res2 + "'
and fechareservafin='" + resfin2 + "'


")
                Dim ss = ""
                For Each ar As DataRow In valorsucursals.Rows
                    ss = ar.Item(0).ToString
                    sucursalS = ss


                Next







                'este llegada 

                Dim valorsucursall As DataTable = conexion.EjecutarSelect("select idsucursalllegada from reserva where idpersona='" + idpersona + "'
and fechareservainicio='" + res2 + "'
and fechareservafin='" + resfin2 + "'


")
                Dim sl = ""
                For Each ar As DataRow In valorsucursals.Rows
                    sl = ar.Item(0).ToString
                    sucursalL = sl

                Next




            End If
            Dim resultado As MsgBoxResult
        resultado = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then



            conexion.RellenarDataGridView(dgvAlquilar, "insert into reserva values (0,'" + res2 + "','" + resfin2 + "','" + res2 + "',
            '" + resfin2 + "','" + cantidadkm + "','" + preciofinal + "','" + fechatramite2 + "',1,'" + nrchasis + "','" + idpersona + "','" + idcategoria + "','" + idtipo + "','" + sucursalS + "','" + sucursalL + "','" + conexion.Usuario + "')")
            dgvAlquilar.DataSource = fuente
            Me.Hide()

        End If

    End Sub

    Private Sub dgvAlquilar_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAlquilar.CellContentClick

    End Sub
End Class