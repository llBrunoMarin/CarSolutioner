Public Class Reconectar
    Dim conexion As ConnectionBD = Login.conexion
    Private Declare Function GetTickCount Lib "kernel32" () As Integer
    Private Sub load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblreconnect.Text = "Se ha perdido la conexion, pulse reconectar para reintentarlo."

        If Application.OpenForms().OfType(Of frmMainMenu).Any Then
            frmMainMenu.Enabled = False


        Else


        End If



    End Sub
    Function Reconectar_Load() Handles btnreconectar.Click


        If btnreconectar.Text = "Reconectar" Then
            Dim retraso As Integer

            retraso = 3000 + GetTickCount


            While retraso >= GetTickCount
                Application.DoEvents()
                pboxreconnecting.Visible = True
                lblreconnect.Text = "Intentando reconectar"

            End While



            If conexion.ReConexion(conexion.Usuario, conexion.Contraseña) = "Verdadero" Or conexion.ReConexion(conexion.Usuario, conexion.Contraseña) = "BadCredentials" Then

                conexion.Cerrar()
                lblreconnect.Text = "Conexion establecida, pulse continuar."

                pboxreconnecting.Visible = False
                btnreconectar.Visible = False
                Login.pboxLoading.Visible = False
                Login.lbldataincorrect.Text = "Ingrese nuevamente"
                Login.lbldataincorrect.Visible = True
                Login.txtContraseña.Visible = True
                Login.txtUsuario.Visible = True
                Login.btnLogin.Visible = True
                Login.lblpass.Visible = True
                Login.lbluser.Visible = True


            Else
                lblreconnect.Text = "No se pudo reanudar la conexion."
                pboxreconnecting.Visible = False
            End If
        Else

        End If


    End Function



    Private Sub Reconectar_Load(sender As Object, e As EventArgs) Handles btnreconectar.Click

    End Sub

    Private Sub btncontinuar_Click(sender As Object, e As EventArgs) Handles btncontinuar.Click
        Me.Dispose()

        If Application.OpenForms().OfType(Of frmMainMenu).Any Then
            frmMainMenu.Enabled = False


        Else
        End If
    End Sub

End Class