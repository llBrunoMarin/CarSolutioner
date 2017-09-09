Public Class Alquilar
    Dim conexion As ConnectionBD = Login.conexion
    Dim categoria As String
    Dim tipo As String
    Dim sucursal As String
    Dim cliente As String
    Private Sub Alquilar_Load(sender As Object, e As EventArgs) Handles MyBase.Load








    End Sub

    Private Sub dgvAlquilar_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAlquilar.CellContentClick

    End Sub
    Public Sub cargardatos()
        Dim sentencia As String = "SELECT V.matricula Matricula,
                                                  Ma.nombre Marca,
                                                    Mo.nombre Modelo,
                                                    T.nombre Tipo,
                                                    V.anio Anio,
                                                    C.nombre Categoria,
                                                    V.deducible Deducible,
                                                    V.aireacondicionado Aire,
                                                    V.cantidaddepuertas Puertas,
                                                    V.cantidaddepasajeros Pasajeros,
                                                    V.cantidaddemaletas Maletas,
                                                    V.esmanual Manual,
                                                    V.kilometraje KM,
                                                    S.Nombre Sucursal FROM Vehiculo V, Categoria C,
                                                    Marca Ma, Modelo Mo, Tipo T, Sucursal S WHERE V.idcategoria = C.idcategoria 
                                                    AND V.idmodelo = Mo.idmodelo
                                                    AND Mo.Idmarca = Ma.Idmarca
                                                    AND Mo.Idtipo = T.idtipo
                                                   
                                                    AND V.idsucursal = S.idsucursal AND V.estado = 't'

                                                   "
        conexion.RellenarDataGridView(dgvAlquilar, sentencia)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Dim fuente As New BindingSource
        fuente = dgvAlquilar.DataSource




        tipo = frmMainMenu.tipo
        categoria = frmMainMenu.categoria
        sucursal = frmMainMenu.sucursal
        cliente = frmMainMenu.cliente

        txttipo.Text = tipo
        txtcat.Text = categoria
        txtsucursal.Text = sucursal
        txtcliente.Text = cliente
        Dim filtro As String







        filtro = String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                                       "categoria", categoria, "Tipo", tipo, "sucursal", sucursal)

        fuente.Filter = filtro
        fuente.DataSource = fuente.DataSource.totable
        dgvAlquilar.DataSource = dgvAlquilar.DataSource.DataSource.ToTable(False, "matricula", "marca", "modelo", "anio", "deducible", "aire", "pasajeros", "maletas", "manual", "km")

    End Sub
    Private Sub btnVaciarFRes_Click(sender As Object, e As EventArgs) Handles btnVaciarFRes.Click, dgvAlquilar.CellDoubleClick
        Dim resultado As MsgBoxResult
        resultado = MsgBox("Estas seguro que deseas alquilnar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then

        End If
    End Sub

End Class