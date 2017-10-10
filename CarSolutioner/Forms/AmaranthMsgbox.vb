Public Class AmaranthMsgbox
    Public Sub New(Texto As String, Tipo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Select Case Tipo
            Case "Advertencia"
                lblTexto.Text = Texto
                lblTitulo.Text = "Advertencia"
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = False
                btnNo.Visible = False
                Me.Text = "Advertencia"

            Case "Error"
                lblTexto.Text = Texto
                lblTitulo.Text = "Error"
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = False
                btnNo.Visible = False
                Me.Text = "Error"

            Case "Si/No"
                lblTexto.Text = Texto
                lblTitulo.Text = "Elija una opción"
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = True
                btnNo.Visible = True

            Case Else

        End Select

    End Sub

    Private Sub AmaranthMsgbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Cerrar(sender As Object, e As EventArgs) Handles btnCerrarMsgbox.Click
        Me.Dispose()
    End Sub
End Class