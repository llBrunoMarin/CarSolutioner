Public Class frmTelefonosCliente

    Dim ComboBoxTelefonos As ComboBox
    Public Sub New(ModoVista As String, Nombre As String, combo As ComboBox, Optional ListaTelefonos As List(Of String) = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        'Si inicializamos el formulario como "Ver", nos mostrará solo el DataGridView, sin permitir edición.
        'Sino, nos mostrará el DataGridView + el botón de Agregar o Modificar, y nos permitirá editar.

        lblNombrePersona.Text = "Telefono de: " + Nombre

        Select Case ModoVista
            Case "Ver"
                dgvTelefonos.Size = New Size(366, 288)
                dgvTelefonos.ReadOnly = True
                btnAgregar.Visible = False
                btnModificar.Visible = False
                lblAyuda.Visible = False
                lblNombrePersona.Visible = True

            Case "Agregar"
                btnAgregar.Visible = True
                btnModificar.Visible = False
                lblNombrePersona.Visible = False
                dgvTelefonos.AutoGenerateColumns = False
                dgvTelefonos.ReadOnly = False
                dgvTelefonos.Size = New Size(254, 131)

                For Each item In ListaTelefonos
                    dgvTelefonos.Rows.Add(item)
                Next

                Me.ComboBoxTelefonos = combo

            Case "Modificar"
                btnAgregar.Visible = False
                btnModificar.Visible = True
                lblNombrePersona.Visible = True
                dgvTelefonos.AutoGenerateColumns = False
                dgvTelefonos.ReadOnly = False
                dgvTelefonos.Size = New Size(254, 131)
                btnCerrar.Visible = False

                For Each item In ListaTelefonos
                    dgvTelefonos.Rows.Add(item)
                Next

                Me.ComboBoxTelefonos = combo

            Case Else

        End Select


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

    Private Sub AgregarTelefonos(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim ListaTelefonos As New List(Of String)

        For Each rw As DataGridViewRow In dgvTelefonos.Rows

            If Not rw.Cells(0).Value Is Nothing Then

                ListaTelefonos.Add(rw.Cells(0).Value.ToString())

            End If

        Next

        ComboBoxTelefonos.DataSource = ListaTelefonos

        Me.Dispose()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub frmTelefonosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click

        Dim ListaTelefonos As New List(Of String)

        For Each rw As DataGridViewRow In dgvTelefonos.Rows

            If Not rw.Cells(0).Value Is Nothing Then


                ListaTelefonos.Add(rw.Cells(0).Value.ToString())

            End If

        Next

        ComboBoxTelefonos.DataSource = ListaTelefonos

        Me.Dispose()
    End Sub
End Class