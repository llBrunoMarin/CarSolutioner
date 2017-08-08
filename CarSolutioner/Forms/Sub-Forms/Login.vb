Public Class Login

    Public conexion As New ConnectionBD
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


        If Not (txtContraseña.Text = "" Or txtUsuario.Text = "") Then

            conexion.Usuario = txtUsuario.Text
            conexion.Contraseña = txtContraseña.Text

            'Si conecta:
            If (conexion.conectar(conexion.Usuario, conexion.Contraseña)) Then
                'Cerrar esa conexión
                conexion.cerrar()

                'Abrir, ejecutar un select, y cerrar conexión.
                Dim tipousuario As New DataTable
                tipousuario = conexion.EjecutarSelect("SELECT tipo from empleado where usuario = '" & conexion.Usuario & "' ;")

                Select Case tipousuario.Rows(0).Item(0)
                    Case 1
                        Me.Hide()
                        MainMenu.Show()

                        'Case 2
                        '    Me.Hide()
                        '    MainMenuGerente.Show()

                        'Case 3
                        '    Me.Hide()
                        '    MainMenuModerador.Show()

                        'Case 4
                        '    Me.Hide()
                        '    MainMenuEmpleado.Show()

                End Select

            End If

        Else

            MsgBox("Usuario y/o Contraseña incorrectos.", MsgBoxStyle.Information, "Datos Incorrectos")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub login_Enter(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown, txtUsuario.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            Call Sub() btnLogin_Click(btnLogin, e)
            e.SuppressKeyPress = True
        End If
    End Sub

End Class