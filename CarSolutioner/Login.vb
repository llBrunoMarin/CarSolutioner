Public Class Login
    Public conexion As New ConnectionDB

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Keyboard.CapsLock = True Then
            lblmayus.Visible = True
        Else
            lblmayus.Visible = False
        End If
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        conexion.SetUsuario(txtUsuario.Text)
        conexion.SetContraseña(txtContraseña.Text)

        If (conexion.conectar(conexion.GetUsuario, conexion.GetContraseña)) Then
            Me.Hide()
            MainMenu.Show()
            conexion.cerrar()

        Else
            txtContraseña.Text = ""
            txtUsuario.Text = ""
            conexion.cerrar()

        End If


    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub login_Enter(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown, txtUsuario.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            Call Sub() btnLogin_Click(btnLogin, e)
            e.SuppressKeyPress = True
        End If
    End Sub
End Class