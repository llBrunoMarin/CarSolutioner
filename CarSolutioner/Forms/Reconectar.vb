Public Class Reconectar


    Private Sub loading()
        Dim retraso As Integer

        retraso = 3000 + GetTickCount


        While retraso >= GetTickCount
            Application.DoEvents()
            pboxreconnecting.Visible = True
            lblreconnect.Text = "Intentando reconectar"
            btnreconectar.Visible = False
            btncontinuar.Visible = False
        End While

    End Sub

    Private Sub Reconectar_Load(sender As Object, e As EventArgs) Handles btnreconectar.Click
        btnreconectar.Visible = True
        lblreconnect.Text = "Se ha perdido la conexion, pulse reconectar para reintentarlo."
        pboxreconnecting.Visible = False
        loading()
        bgwcargando.RunWorkerAsync()
    End Sub

    Private Sub btncontinuar_Click(sender As Object, e As EventArgs) Handles btncontinuar.Click
        Me.Dispose()
        Login.bgwLogin.RunWorkerAsync()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Dispose()

    End Sub

    Private Sub bgwcargando_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwcargando.DoWork

        conexion.Conectar(conexion.Usuario, conexion.Contraseña)


    End Sub

    Private Sub bgwcargando_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwcargando.RunWorkerCompleted
        Select Case conexion.ConnectionStatus

            Case "Opened"
                conexion.ConnectionStatus = "Opened"
                lblreconnect.Text = "Conexion establecida, pulse continuar."
                pboxreconnecting.Visible = False

                btncontinuar.Visible = True

            Case "BadCredentials"
                conexion.ConnectionStatus = "BadCredentials"
                btncontinuar.Visible = True
                lblreconnect.Text = "Conexion establecida, pulse continuar."
                pboxreconnecting.Visible = False
                Login.lbldataincorrect.Text = "Datos Incorrectos."
                Login.lbldataincorrect.Visible = True
                Login.txtContraseña.Visible = True
                Login.txtUsuario.Visible = True
                Login.btnLogin.Visible = True
                Login.lblpass.Visible = True
                Login.lbluser.Visible = True

            Case "NetworkFailure"
                lblreconnect.Text = "No se pudo reanudar la conexion."
                pboxreconnecting.Visible = False
                btnreconectar.Visible = True


        End Select

    End Sub
End Class