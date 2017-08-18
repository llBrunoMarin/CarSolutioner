﻿Public Class frmCambiosGenerales

    Private Sub frmCambiosGenerales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbcTabControl.ItemSize = New Size(0, 1)
        btnSucursales.PerformClick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

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

    Private Sub tbpDocumento_Click(sender As Object, e As EventArgs) Handles tbpDocumento.Click

    End Sub
End Class