Public Class frmAlquilar

    Dim conexion As ConnectionBD = Login.conexion
    Dim CategoriaReserva As String
    Dim nombre As String
    Dim apellido As String
    Dim TipoReserva As String
    Dim SucursalIReserva As String
    Dim ClienteReserva As String
    Dim ResInicio As String
    Dim ResFin As String
    Dim ResFin2 As Date
    Dim ResInicio2 As String
    Dim fechatramite As Date
    Dim fechatramite2 As String
    Dim idpersonaI As Integer


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Hide()

    End Sub
    'Agregar resalquiler fin para cambiar con la q este en el form, por si la quiere cambiar 
    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated, Me.Load

        Dim fuente As New BindingSource

        fuente = dgvAlquilar.DataSource
        TipoReserva = frmMainMenu.tipo
        CategoriaReserva = frmMainMenu.categoria
        SucursalIReserva = frmMainMenu.sucursal
        nombre = frmMainMenu.nombre
        apellido = frmMainMenu.apellido
        ClienteReserva = frmMainMenu.nombre + " " + frmMainMenu.apellido
        ResInicio = frmMainMenu.resFinicio
        ResFin = frmMainMenu.resFfin
        fechatramite = frmMainMenu.fechaTramite
        txtTipo.Text = TipoReserva
        txtCategoria.Text = CategoriaReserva
        txtSucursal.Text = SucursalIReserva
        txtCliente.Text = ClienteReserva
        ResFin = dtpFRfin.ToString
        ResInicio = dtpFRinicio.ToString

        ResInicio = dtpFRinicio.Value.ToString("dd-MM-yyyy")
        ResFin = dtpFRfin.Value.ToString("dd-MM-yyyy")
        fechatramite2 = fechatramite

        Dim filtro As String
        filtro = "categoria = '" + CategoriaReserva + "' AND tipo = '" + TipoReserva + "' AND sucursal = '" + SucursalIReserva + "'"

        fuente.Filter = filtro
        dgvAlquilar.Columns(7).Visible = False
        dgvAlquilar.DataSource = fuente

    End Sub


    Public Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal r As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvAlquilar.CellMouseDoubleClick

        Dim nrchasis As String
        Dim idpersona As String
        Dim sucursalS As Integer
        Dim sucursalL As Integer

        If r.RowIndex >= 0 AndAlso r.ColumnIndex >= 0 Then

            Dim selectedRow = dgvAlquilar.Rows(r.RowIndex)

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

            'Arreglar esto, no devuelve la variable q dice que sucursales son las de llegada y salida. el primero es la de salida el 2do de llegada

            'Este salida

            'Dim valorSucursalS As DataTable = conexion.EjecutarSelect("Select idsucursalsalida from reserva where idpersona ='" + idpersona + "'
            '                                                            and fechareservainicio='" + ResInicio + "'and fechareservafin='" + ResFin + "'")
            'Dim ss = ""
            'For Each ar As DataRow In valorSucursalS.Rows
            '    ss = ar.Item(0).ToString
            '    sucursalS = ss
            'Next

            'Este llegada 

            'Dim valorSucursalL As DataTable = conexion.EjecutarSelect("Select idsucursalllegada from reserva where nombre ='" + idpersona + "' 
            '                                                            and fechareservainicio='" + ResInicio + "' and fechareservafin='" + ResFin + "'")
            'Dim sl = ""
            'For Each ar As DataRow In valorSucursalS.Rows
            '    sl = ar.Item(0).ToString
            '    sucursalL = sl
            'Next
            ' MsgBox(idpersona)
            ' MsgBox(sucursalS)
            ' MsgBox(sucursalS)

        End If
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Estas seguro que deseas alquilar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then

            'Este insert funca pero solo con la primer reserva, tienen q arreglar lo de arriba asi lo pueden hacer con cualquier reserva
            'viene el nombre de usuariola idpersona tdo bien, no funca eso de las sucursales.
            'idpersona parsear a int-
            conexion.RellenarDataGridView(dgvAlquilar, "insert into reserva values (0,'" + ResInicio + "','" + ResFin + "','" + ResInicio + "',
            '" + ResFin + "',3,5000,'" + fechatramite2 + "',1,'" + nrchasis + "','" + idpersona + "',3,1,1,1,'" + conexion.Usuario + "')")

            Me.Hide()
        End If

    End Sub

End Class