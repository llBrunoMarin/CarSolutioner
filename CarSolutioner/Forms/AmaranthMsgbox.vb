Public Class AmaranthMsgbox
    Public Sub New(Texto As String, Tipo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Select Case Tipo
            Case "Advertencia"
                lblTexto.Text = Texto
                lblTitulo.Text = "Advertencia"

                pbxAdvertencia.Visible = True
                pbxError.Visible = False
                pbxContinuar.Visible = False
                pbxPregunta.Visible = False

                btnSi.Visible = False
                btnNo.Visible = False
                btnAccept.Visible = True
                Me.Text = "Advertencia"

            Case "Error"
                lblTexto.Text = Texto
                lblTitulo.Text = "Error"

                pbxError.Visible = True
                pbxContinuar.Visible = False
                pbxAdvertencia.Visible = False
                pbxPregunta.Visible = False

                btnSi.Visible = False
                btnNo.Visible = False
                btnAccept.Visible = True
                Me.Text = "Error"

            Case "Si/No"
                lblTexto.Text = Texto
                lblTitulo.Text = "Elija una opción"

                pbxPregunta.Visible = True
                pbxContinuar.Visible = False
                pbxError.Visible = False
                pbxAdvertencia.Visible = False

                btnSi.Visible = True
                btnNo.Visible = True
                btnAccept.Visible = False
            Case "Continuar"
                lblTexto.Text = Texto
                lblTitulo.Text = "Continuar"

                pbxAdvertencia.Visible = False
                pbxContinuar.Visible = True
                pbxError.Visible = False
                pbxPregunta.Visible = False

                btnSi.Visible = False
                btnNo.Visible = False
                btnAccept.Visible = True
            Case Else

        End Select

    End Sub

    Private Sub AmaranthMsgbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Si(sender As Object, e As EventArgs) Handles btnSi.Click
        Me.DialogResult = vbYes
        Me.Dispose()
    End Sub

    Private Sub No(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.DialogResult = vbNo
        Me.Dispose()
    End Sub


    Private Sub Cerrar(sender As Object, e As EventArgs) Handles btnCerrarMsgbox.Click
        Me.DialogResult = DialogResult.None
        Me.Dispose()
    End Sub

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        Me.DialogResult = DialogResult.None
        Me.Dispose()
    End Sub
End Class