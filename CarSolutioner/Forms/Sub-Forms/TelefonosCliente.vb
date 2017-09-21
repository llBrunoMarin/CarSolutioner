Public Class frmTelefonosCliente

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(ModoVista As String)

        ' This call is required by the designer.
        InitializeComponent()

        'Si inicializamos el formulario como "Ver", nos mostrará solo el DataGridView, sin permitir edición.
        'Sino, nos mostrará el DataGridView + el botón de Agregar, y nos permitirá editar.

        If ModoVista = "Ver" Then
            dgvTelefonos.Size = New Size(260, 237)
            dgvTelefonos.ReadOnly = True
            btnAgregarTelefonos.Visible = False
            lblAyuda.Visible = False
        End If


    End Sub

    Public Sub New(ListaTelefonos As List(Of String))

        ' This call is required by the designer.
        InitializeComponent()

        dgvTelefonos.AutoGenerateColumns = False
        dgvTelefonos.ReadOnly = False
        dgvTelefonos.Size = New Size(167, 131)
        btnAgregarTelefonos.Visible = True

        For Each item In ListaTelefonos
            dgvTelefonos.Rows.Add(item)
        Next
    End Sub

    Private Sub dgvTelefonos_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTelefonos.EditingControlShowing
        Dim tb As TextBox = e.Control
        AddHandler tb.KeyPress, AddressOf NotNumeric
    End Sub

    Private Sub NotNumeric(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub AgregarTelefonos(sender As Object, e As EventArgs) Handles btnAgregarTelefonos.Click

        Dim ListaTelefonos As New List(Of String)

        For Each rw As DataGridViewRow In dgvTelefonos.Rows

            If Not rw.Cells(0).Value Is Nothing Then

                ListaTelefonos.Add(rw.Cells(0).Value.ToString())

            End If

        Next

        frmMainMenu.cbxTelefonosACliente.DataSource = ListaTelefonos

        Me.Dispose()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub frmTelefonosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class