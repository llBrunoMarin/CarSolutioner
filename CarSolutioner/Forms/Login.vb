Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.Integration


Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pboxLoading.Hide()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Loading()
        'Las operaciones que tienen que ver con el login, las hacemos en SEGUNDO PLANO (para que no laguee interfaz)
        bgwLogin.RunWorkerAsync()

    End Sub

    Private Sub Loading()

        'ACÁ PONER EL CÓDIGO DE LAS COSAS QUE VAN A CAMBIAR CUANDO SE EMPIEZE A CARGAR ALGO

        pboxLoading.Visible = True
        txtContraseña.Visible = False
        txtUsuario.Visible = False
        btnLogin.Visible = False
        lblpass.Visible = False
        lbluser.Visible = False
        lbldataincorrect.Visible = False
        PictureBox2.Visible = False
        Dim retraso As Integer

        retraso = 2000 + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

    End Sub


    'Hacer operaciones de LOGIN, establece el Tipo de Usuario una vez que termina. Si termina con un error, establece el tipo de usuario según el error.
    Private Sub bgwLogin_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwLogin.DoWork



        conexion.Usuario = txtUsuario.Text
            conexion.Contraseña = txtContraseña.Text

            conexion.Conectar(conexion.Usuario, conexion.Contraseña)
            conexion.Cerrar()




    End Sub

    'Este código se ejecuta solamente cuando el método "DoWork" termina de ejecutarse.
    Private Sub bgwLogin_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwLogin.RunWorkerCompleted

        Select Case conexion.ConnectionStatus
            Case "Opened"

                'Conseguimos el Tipo de Usuario de la persona conectada:
                Dim tipousuario As New DataTable
                tipousuario = conexion.EjecutarSelect("SELECT tipo from empleado where usuario = '" & conexion.Usuario & "' ;")

                Try
                    Select Case tipousuario.Rows(0).Item(0)

                        Case 1
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

                    pboxLoading.Visible = False
                    lbldataincorrect.Text = "Usuario carece de rango."
                    lbldataincorrect.Visible = True
                    txtContraseña.Visible = True
                    txtUsuario.Visible = True
                    PictureBox2.Visible = True
                    btnLogin.Visible = True
                    lblpass.Visible = True
                    lbluser.Visible = True

                End Try

            Case "BadCredentials"
                pboxLoading.Visible = False
                lbldataincorrect.Text = "Datos incorrectos."
                lbldataincorrect.Visible = True
                txtContraseña.Visible = True
                txtUsuario.Visible = True
                btnLogin.Visible = True
                lblpass.Visible = True
                PictureBox2.Visible = True
                lbluser.Visible = True

            Case "NetworkFailure"

            Case "MissingData"
                pboxLoading.Visible = False
                lbldataincorrect.Text = "Faltan datos"
                lbldataincorrect.Visible = True
                txtContraseña.Visible = True
                txtUsuario.Visible = True
                btnLogin.Visible = True
                lblpass.Visible = True
                PictureBox2.Visible = True
                lbluser.Visible = True

            Case Else
                pboxLoading.Visible = False
                lbldataincorrect.Text = "Ups!, ha ocurrido un error, contacta al soporte."
                lbldataincorrect.Visible = True
                txtContraseña.Visible = True
                txtUsuario.Visible = True
                btnLogin.Visible = True
                lblpass.Visible =
                     PictureBox2.Visible = True
                lbluser.Visible = True

        End Select

    End Sub


    Private Sub lblInvitado_Click(sender As Object, e As EventArgs) Handles Label3.Click
        'MainMenuInvitado.Show()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub Minimizar_Click(sender As Object, e As EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub tmrTimer_Tick(sender As Object, e As EventArgs) Handles tmrTimer.Tick

        'Controla el mensaje de Mayúsculas activadas
        If My.Computer.Keyboard.CapsLock = True Then
            lblmayus.Visible = True
        Else
            lblmayus.Visible = False
        End If

    End Sub

    Private Sub pboxLoading_Click(sender As Object, e As EventArgs) Handles pboxLoading.Click

    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        txtContraseña.PasswordChar = Nothing
        PictureBox2.Image = CarSolutioner.My.Resources.show
    End Sub
    Private Sub PictureBox2_MouseDowns(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp
        txtContraseña.PasswordChar = "●"
        PictureBox2.Image = CarSolutioner.My.Resources.hide2
    End Sub

End Class