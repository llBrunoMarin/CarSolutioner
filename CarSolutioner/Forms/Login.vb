Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.Integration
Public Class Login

    Public conexion As New ConnectionBD
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Private Sub tmrTimer_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick

        'Controla el mensaje de Mayúsculas activadas
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
            If (conexion.Conectar(conexion.Usuario, conexion.Contraseña)) Then
                'Cerrar esa conexión
                conexion.Cerrar()

                'Conseguimos el Tipo de Usuario de la persona conectada:
                Dim tipousuario As New DataTable
                tipousuario = conexion.EjecutarSelect("SELECT tipo from empleado where usuario = '" & conexion.Usuario & "' ;")

                Try
                    Select Case tipousuario.Rows(0).Item(0)

                        Case 1
                            Me.Hide()
                            frmMainMenu.Show()

                        Case 2
                            Me.Hide()
                            'MainMenuAdmin.Show()

                        Case 3
                            Me.Hide()
                            'MainMenuMod.Show()

                        Case 4
                            Me.Hide()
                            'MainMenuEmp.Show()

                    End Select

                Catch ex As IndexOutOfRangeException

                    MsgBox("Tu usuario parece no tener un tipo asignado. Contáctate con el técnico de la empresa para que así sea.", MsgBoxStyle.Information, "Datos Incorrectos")

                End Try

            End If

        Else

            MsgBox("Usuario y/o Contraseña incorrectos.", MsgBoxStyle.Information, "Datos Incorrectos")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub Minimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub login_Enter(sender As Object, e As KeyEventArgs) Handles txtContraseña.KeyDown, txtUsuario.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            Call Sub() btnLogin_Click(btnLogin, e)
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub lblInvitado_Click(sender As Object, e As EventArgs) Handles Label3.Click
        'MainMenuInvitado.Show()
    End Sub
End Class