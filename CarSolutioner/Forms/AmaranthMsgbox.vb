Public Class AmaranthMsgbox
    Public Sub New(Texto As String, Tipo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Select Case Tipo
            Case "Advertencia"
                lblTexto.Text = Texto
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = False
                btnNo.Visible = False
                Me.Text = "Advertencia"

            Case "Error"
                lblTexto.Text = Texto
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = False
                btnNo.Visible = False
                Me.Text = "Error"

            Case "Si/No"
                lblTexto.Text = Texto
                'pboxAdvertencia.Visible = True
                'pboxError.Visible = False
                'pboxSiNo.Visible = False
                btnSi.Visible = True
                btnNo.Visible = True

            Case Else

        End Select
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub AmaranthMsgbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SiNo(sender As Object, e As EventArgs)

    End Sub
End Class