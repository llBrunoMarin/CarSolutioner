﻿Public Class frmAlquilar

    Dim conexion As ConnectionBD = Login.conexion
    Dim CategoriaReserva As String
    Dim TipoReserva As String
    Dim SucursalIReserva As String
    Dim ClienteReserva As String

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Hide()

    End Sub

    Private Sub Alquilar_Activated(sender As Object, e As EventArgs) Handles Me.Activated, Me.Load

        Dim fuente As New BindingSource
        fuente = dgvAlquilar.DataSource
        TipoReserva = frmMainMenu.tipo
        CategoriaReserva = frmMainMenu.categoria
        SucursalIReserva = frmMainMenu.sucursal
        ClienteReserva = frmMainMenu.cliente

        txtTipo.Text = TipoReserva
        txtCategoria.Text = CategoriaReserva
        txtSucursal.Text = SucursalIReserva
        txtCliente.Text = ClienteReserva

        Dim filtro As String
        filtro = "categoria = '" + CategoriaReserva + "' AND tipo = '" + TipoReserva + "' AND sucursal = '" + SucursalIReserva + "'"

        fuente.Filter = filtro
        fuente.DataSource.ToTable(False, "matricula", "marca", "modelo", "anio", "deducible", "aire", "pasajeros", "maletas", "manual", "km")
        dgvAlquilar.DataSource = fuente

    End Sub

    Private Sub btnVaciarFRes_Click(sender As Object, e As EventArgs) Handles btnVaciarFRes.Click, dgvAlquilar.CellDoubleClick

        Dim resultado As MsgBoxResult
        resultado = MsgBox("Estas seguro que deseas alquilnar el vehiculo?", MsgBoxStyle.YesNo, "Desea continuar?")
        If resultado = vbYes Then

        End If

    End Sub

End Class