Public Class frmCambiosGenerales
    Dim conexion As ConnectionBD = Login.conexion
    Private Sub frmCambiosGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        tbcTabControl.ItemSize = New Size(0, 1)
        btnSucursales.PerformClick()

        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False

    End Sub

    Private Sub btnMinimizar_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub
    Dim idsucursalmod As String
    Private Sub Sidebar_Click(sender As Object, e As EventArgs) Handles btnSucursales.Click, btnCategorias.Click, btnMarcas.Click, btnModelos.Click

        ResetColors()

        Select Case sender.Name

            Case "btnSucursales"
                SetTabAndColors(btnSucursales, tbpSucursales, Color.White)

            Case "btnCategorias"
                SetTabAndColors(btnCategorias, tbpCategorias, Color.White)





            Case "btnMarcas"
                SetTabAndColors(btnMarcas, tbpMarcas, Color.White)

            Case "btnModelos"
                SetTabAndColors(btnModelos, tbpModelos, Color.White)


        End Select

    End Sub

    Sub ResetColors()

        'Recorrer todos los controles del panel Sidebar
        For Each control In pnlSidebar.Controls
            'Si el control es un botón
            If TypeOf control Is Button Then
                control.BackColor = Color.Transparent
                control.ForeColor = Color.White
                control.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 55, 55)
            End If

        Next

    End Sub

    Private Sub SetTabAndColors(boton As Button, pagina As TabPage, Color As Color)

        boton.BackColor = Color
        boton.FlatAppearance.MouseOverBackColor = Color
        boton.FlatAppearance.MouseDownBackColor = Color
        boton.ForeColor = Color.FromArgb(100, 38, 38)

        pagina.BackColor = Color
        tbcTabControl.SelectedTab = pagina

    End Sub


    Private Sub btnAddSuc_Click(sender As Object, e As EventArgs) Handles btnAddSuc.Click
        conexion.EjecutarNonQuery("INSERT INTO sucursal values (0, '" + txtNomSuc.Text + "', '" + txtCidSuc.Text + "', '" + txtDicSuc.Text + "','T')")
        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False
    End Sub

    Private Sub dataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
  Handles dgvSucursales.CellClick
        Dim nombresucmod As String
        Dim ciudadsucmod As String
        Dim direccionsucmod As String
        Dim estadosucmod As String

        Dim selectedRow = dgvSucursales.Rows(e.RowIndex)


        idsucursalmod = selectedRow.Cells("idsucursal").Value.ToString()
        nombresucmod = selectedRow.Cells("nombre").Value.ToString()
        ciudadsucmod = selectedRow.Cells("ciudad").Value.ToString()
        direccionsucmod = selectedRow.Cells("direccion").Value.ToString()
        estadosucmod = selectedRow.Cells("estado").Value.ToString()
        MsgBox(estadosucmod)

        If estadosucmod = "True" Then
            cboxestadosucmod.SelectedItem = "Activa"


        Else
            cboxestadosucmod.SelectedItem = "Inactiva"
        End If
        txtciudadsucmod.Text = ciudadsucmod
        txtnombresucmod.Text = nombresucmod
        txtdireccionsucmod.Text = direccionsucmod



    End Sub

    Private Sub btnmodsuc_Click(sender As Object, e As EventArgs) Handles btnmodsuc.Click
        Dim estado As String
        If cboxestadosucmod.SelectedItem = "Activa" Then
            estado = "t"
        ElseIf cboxestadosucmod.SelectedItem = "Inactiva" Then
            estado = "f"
        Else

        End If
        conexion.EjecutarNonQuery("UPDATE sucursal set nombre = '" + txtnombresucmod.Text + "', direccion = '" + txtdireccionsucmod.Text + "', ciudad = '" + txtciudadsucmod.Text + "', estado = '" + estado + "' where idsucursal = '" + idsucursalmod + "'")
        conexion.RellenarDataGridView(dgvSucursales, "SELECT * FROM SUCURSAL")
        dgvSucursales.Columns("idsucursal").Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class