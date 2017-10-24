Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Net

Module Metodos
    <Extension()>
    Public Sub Add(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub

    <Extension()>
    Public Function Round(dt As DateTime) As DateTime

        Dim t As DateTime
        t = dt.AddMinutes((60 - dt.Minute) Mod 10)
        Return t

    End Function

    Public Declare Function GetTickCount Lib "kernel32" () As Integer
    Public conexion As New ConnectionBD
    Public bgwCargar As New ComponentModel.BackgroundWorker


    Public Sub CargarTodosDatos(form As Form)
        Select Case form.Name
            Case "frmMainMenu"
                frmMainMenu.CargarDatos()
            Case "frmMainMenuInvitado"
                frmMainMenuInvitado.CargarDatos()

        End Select
    End Sub

    Public Sub RecargarDatosEspecificos(form As Form, dgv As DataGridView)
        Select Case form.Name
            Case "frmMainMenu"
                frmMainMenu.RecargarDatos(dgv)

            Case "frmMainMenuInvitado"
                frmMainMenuInvitado.RecargarDatos(dgv)

        End Select
    End Sub

    Public Sub VaciarPanel(panel As Panel)
        For Each item In panel.Controls

            If TypeOf item Is TextBox Then
                item.text = ""
            End If

            If TypeOf item Is ComboBox Then
                item.SelectedItem = Nothing
            End If

            If TypeOf item Is NumericUpDown Then
                DirectCast(item, NumericUpDown).Value = Nothing
            End If
        Next
    End Sub


    'Cargando
    Public Sub Cargando(milisegundos As Integer, form As Form)

        Dim retraso As Integer
        retraso = milisegundos + GetTickCount

        Select Case form.Name
            Case "frmMainMenu"
                While retraso >= GetTickCount
                    Application.DoEvents()
                    frmMainMenu.pcboxloading.Visible = True
                End While
                frmMainMenu.pcboxloading.Visible = False

            Case "frmMainMenuInvitado"
                'While retraso >= GetTickCount
                '    Application.DoEvents()
                '    frmMainMenu.pcboxloading.Visible = True
                'End While
                'frmMainMenu.pcboxloading.Visible = False

        End Select


    End Sub

    'Verifica una cédula que entra como parámetro
    Public Function VerificarCI(ci As String) As Boolean

        'Si el valor ingresado es numérico
        If IsNumeric(ci) Then

            'Si el largo del numero es exactamente 8
            If (ci.Length = 8) Then

                Dim verificador As String = ci.Substring(7, 1)
                Dim cedula As String = ci.Substring(0, 7)
                Dim Algoritmo() As Integer = {2, 9, 8, 7, 6, 3, 4}
                Dim Operacion As String
                Dim sumaVerificarCI As Integer
                Dim valor As Integer

                Try

                    For i = 0 To 6
                        'Multiplicar el caracter nro "i" de la cedula, por el carácter numero "i" del Algoritmo.
                        Operacion = (CInt(cedula.Substring(i, 1)) * Algoritmo(i)).ToString

                        'Si el resultado es de 2 cifras
                        If Operacion.Length = 2 Then

                            'Quedarse solo con la segunda.
                            sumaVerificarCI += Operacion.Substring(1, 1)

                        Else
                            'Sino, simplemente ir sumando los resultados en "SumaVerificarCI".
                            sumaVerificarCI += Operacion

                        End If



                    Next

                    'Guardo el valor de SumaVerificarCI para usarlo más tarde.
                    valor = sumaVerificarCI
                    Do
                        'Encontrar el siguiente nro + grande que SumaverificarCI
                        If Not (sumaVerificarCI.ToString.Substring(1, 1) = "0") Then
                            sumaVerificarCI = sumaVerificarCI + 1
                        End If

                    Loop Until (sumaVerificarCI.ToString.Substring(1, 1) = "0")


                    If sumaVerificarCI - valor = verificador Then

                        Return True

                    Else

                        MsgBox("Su cédula es inválida. Por favor verifique.", MsgBoxStyle.Critical, "CI Inválida")
                        Return False

                    End If

                Catch ex As Exception

                    MsgBox("Su cédula es inválida. Por favor verifique.", MsgBoxStyle.Critical, "CI Inválida")
                    Return False

                End Try

            Else
                MsgBox("Ingrese una cédula de largo válido por favor.", MsgBoxStyle.Critical, "CI Inválida")
                Return False
            End If

        Else
            MsgBox("Limítese solo a numeros en los campos numéricos, por favor.", MsgBoxStyle.Critical, "CI Inválida")
            Return False
        End If




    End Function

    'Establece el tipo de filtro que se está usando. Si no hay valor seleccionado de ese control, no se toma en cuenta en el filtro.
    Public Function TipoFiltro(ctrl As Control, columna As String) As String

        Select Case ctrl.GetType()

            Case GetType(ComboBox)

                Dim cbx As ComboBox = DirectCast(ctrl, ComboBox)

                If Not (cbx.SelectedItem Is Nothing) Then
                    If Not (cbx.DataSource Is Nothing) Then
                        Return " AND " + columna + " = " + DirectCast(ctrl, ComboBox).SelectedValue.ToString + ""
                    Else
                        'If (TypeOf (cbx.SelectedValue) Is String) Then

                        Return " AND " + columna + " = '" + DirectCast(ctrl, ComboBox).SelectedItem.ToString + "'"
                        ' Else
                        'Return " AND " + columna + " = " + DirectCast(ctrl, ComboBox).SelectedItem.ToString + ""
                        'End If
                    End If
                Else
                    Return ""
                End If

            Case GetType(NumericUpDown)
                Dim num As NumericUpDown = DirectCast(ctrl, NumericUpDown)

                If Not (num.Value = 0) Then
                    Return " AND " + columna + " = " + num.Value.ToString + ""
                Else
                    Return ""
                End If

            Case Else
                Return ""

        End Select


    End Function

    'Cargar datos combobox con una Tabla
    Public Sub CargarDatosComboBox(cbx As ComboBox, dt As DataTable, columna As String, value As String)

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext
        cbx.DataSource = dt.DefaultView

        cbx.DisplayMember = columna
        cbx.ValueMember = value

    End Sub

    'Cargar datos combobox con una Lista de Strings
    Public Sub CargarDatosComboBox(cbx As ComboBox, lt As List(Of String))

        '(El "new BindingContext" es para que los comboboxes que hacen referencia a una misma tabla no se seleccionen a la vez)
        cbx.BindingContext = New BindingContext
        cbx.DataSource = lt

    End Sub

    '"Vaciar" el control, dependiendo de su tipo.
    Public Sub VaciarControl(con As Control)

        Select Case con.GetType

            Case GetType(TextBox)
                DirectCast(con, TextBox).Text = Nothing

            Case GetType(ComboBox)
                DirectCast(con, ComboBox).SelectedItem = Nothing

            Case GetType(NumericUpDown)
                DirectCast(con, NumericUpDown).Value = 0

            Case Else

                Return

        End Select

    End Sub

    'Msgbox personalizado de AmaranthSolutions
    Public Function AmaranthMessagebox(Texto As String, Tipo As String) As DialogResult

        Dim AmaranthMsgbox As New AmaranthMsgbox(Texto, Tipo)
        Using AmaranthMsgbox
            Dim resultado As DialogResult = AmaranthMsgbox.ShowDialog()
            Return resultado
        End Using


    End Function

    'Ventana de autorización
    Public Function Autorizar(parent As IWin32Window) As DialogResult
        Dim autorizacion As New Autorizacion

        Using autorizacion
            Dim resultado As DialogResult = autorizacion.ShowDialog(parent)
            Return resultado
        End Using
    End Function

    'Verificar codigo de Descuento
    Public Function VerificarCodigo(codigo As String) As Boolean

        'Si el valor ingresado es numérico
        If IsNumeric(codigo) Then

            'Si el largo del numero es exactamente 8
            If (codigo.Length = 8) Then

                Dim dia As String = DateTime.Today.Day
                Dim minuto As String = DateTime.Now.ToString("mm")
                Dim mes As String = DateTime.Today.Month
                Dim verificador As String = codigo.Substring(7, 1)
                Dim cedula As String = codigo.Substring(0, 7)
                Dim algoritmo() As Integer = {2, 2, mes.Substring(0, 1), dia.Substring(0, 1), 6, 3, 4}
                Dim Operacion As String
                Dim sumaVerificarCI As Integer
                Dim valor As Integer

                Try

                    For i = 0 To 6
                        'Multiplicar el caracter nro "i" de la cedula, por el carácter numero "i" del Algoritmo.
                        Operacion = (CInt(cedula.Substring(i, 1)) * algoritmo(i)).ToString

                        'MsgBox("operacion" + Operacion)
                        'Si el resultado es de 2 cifras
                        If Operacion.Length = 2 Then

                            'Quedarse solo con la segunda.
                            sumaVerificarCI += Operacion.Substring(1, 1)
                        Else
                            'Sino, simplemente ir sumando los resultados en "SumaVerificarCI".
                            sumaVerificarCI += Operacion
                        End If

                    Next

                    'MsgBox(sumaVerificarCI)
                    'Guardo el valor de SumaVerificarCI para usarlo más tarde.
                    valor = sumaVerificarCI
                    Do
                        'Encontrar el siguiente nro + grande que SumaverificarCI
                        If Not (sumaVerificarCI.ToString.Substring(1, 1) = "0") Then
                            sumaVerificarCI = sumaVerificarCI + 1

                        End If

                    Loop Until (sumaVerificarCI.ToString.Substring(1, 1) = "0")
                    If sumaVerificarCI - valor = verificador Then

                        Return True

                    Else

                        MsgBox("Su codigo es inválido. Por favor verifique.")
                        Return False

                    End If

                Catch ex As Exception

                    MsgBox("Su codigo es inválido. Por favor verifique.")
                    Return False

                End Try

            ElseIf (codigo.Length = 9) Then
                Dim dia As String = DateTime.Today.Day
                Dim minuto As String = DateTime.Now.ToString("mm")
                Dim mes As String = DateTime.Today.Month
                Dim verificador As String = codigo.Substring(7, 2)
                Dim cedula As String = codigo.Substring(0, 7)
                Dim algoritmo() As Integer = {2, 2, 2, dia.Substring(0, 1), 6, 3, 4}
                Dim Operacion As String
                Dim sumaVerificarCI As Integer
                Dim valor As Integer

                Try

                    For i = 0 To 6
                        'Multiplicar el caracter nro "i" de la cedula, por el carácter numero "i" del Algoritmo.
                        Operacion = (CInt(cedula.Substring(i, 1)) * algoritmo(i)).ToString

                        'MsgBox("operacion" + Operacion)
                        'Si el resultado es de 2 cifras
                        If Operacion.Length = 2 Then

                            'Quedarse solo con la segunda.
                            sumaVerificarCI += Operacion.Substring(1, 1)
                        Else
                            'Sino, simplemente ir sumando los resultados en "SumaVerificarCI".
                            sumaVerificarCI += Operacion
                        End If

                    Next
                    'Guardo el valor de SumaVerificarCI para usarlo más tarde.
                    valor = sumaVerificarCI
                    Do
                        'Encontrar el siguiente nro + grande que SumaverificarCI
                        If Not (sumaVerificarCI.ToString.Substring(1, 1) = "0") Then
                            sumaVerificarCI = sumaVerificarCI + 1

                        End If

                    Loop Until (sumaVerificarCI.ToString.Substring(1, 1) = "0")
                    If sumaVerificarCI - valor = verificador Then

                        Return True
                    Else
                        MsgBox("Su codigo es inválido. Por favor verifique.")
                        Return False
                    End If
                Catch ex As Exception

                    MsgBox("Su codigo es inválido. Por favor verifique.")
                    Return False
                End Try
            Else
                MsgBox("Largo Inválido")
                Return False
            End If
        Else
            MsgBox("Limítese solo a numeros en los campos numéricos, por favor.")
            Return False
        End If

    End Function

    'Obtener IP
    Public Function GetIPAddress() As String

        Dim strIPAddress As String
        strIPAddress = Dns.GetHostByName(Dns.GetHostName()).AddressList(0).ToString()

        Return strIPAddress

    End Function

    'Obtener el tamaño de Columnas de un datagridview
    Public Function TamañoColumnasVisibles(dgv As DataGridView) As Single()

        Dim values = New Single() {}

        For Each column As DataGridViewColumn In dgv.Columns
            If column.Visible = True Then
                values.Add(column.Width)
            End If
        Next

        Return values
    End Function

    'Obtener cantidad de columnas visibles de un datagridview
    Public Function CantidadColumnasVisibles(dgv As DataGridView) As Integer
        Dim cantidad As Integer = 0
        For Each column As DataGridViewColumn In dgv.Columns
            If column.Visible = True Then
                cantidad = cantidad + 1
            End If
        Next

        Return cantidad
    End Function

    'Obtener fuente Century Gothic
    Public Function GetCentury() As iTextSharp.text.Font
        Dim fontName = "Century Gothic"
        If Not FontFactory.IsRegistered(fontName) Then
            Dim fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\fonts\GOTHIC.ttf"
            FontFactory.Register(fontPath)
        End If
        Return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
    End Function

    'Genera un documento PDF
    Public Sub AñadirTablaPDF(doc As Document, dgv As DataGridView, textoencabezado As String)

        'Se crea un objeto PDFTable con el numero de columnas del DataGridView. 

        Dim PdfTable As New PdfPTable(CantidadColumnasVisibles(dgv))
        Dim headerwidths As Single() = TamañoColumnasVisibles(dgv)

        'Se asignan algunas propiedades para el diseño del PDF.
        PdfTable.DefaultCell.Padding = 3
        PdfTable.SetWidths(headerwidths)
        PdfTable.WidthPercentage = 100
        PdfTable.DefaultCell.BorderWidth = 1


        PdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER

        Dim FuenteTitulo As New Font(GetCentury().BaseFont, 15.0F, FontStyle.Regular, New BaseColor(100, 38, 38))
        'Se crea el encabezado en el PDF (POR AHORA DESACTIVADO)
        Dim encabezado As New Paragraph(textoencabezado, FuenteTitulo)
        encabezado.Alignment = 1

        'Se crea el texto abajo del encabezado.
        'Dim texto As New Phrase("Reporte productos:" + Now.Date(), New Font(Font.Name = "Tahoma", 14, Font.BOLD))

        'Se capturan los nombres de las columnas del DataGridView.
        For i As Integer = 0 To dgv.ColumnCount - 1
            If dgv.Columns(i).Visible = True Then

                Dim century As New Font(GetCentury().BaseFont, 13.0F, FontStyle.Regular, BaseColor.WHITE)
                Dim texto As New Phrase(dgv.Columns(i).HeaderText, century)
                Dim cell As New PdfPCell(texto)
                cell.BackgroundColor = BaseColor.DARK_GRAY
                cell.HorizontalAlignment = 1 'CENTER
                PdfTable.AddCell(cell)

            End If
        Next

        PdfTable.HeaderRows = 1

        PdfTable.DefaultCell.BorderWidth = 0.5

        'Se generan las columnas del DataGridView. 
        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                If dgv.Columns(j).Visible = True Then

                    Dim century As New Font(GetCentury().BaseFont, 12.0F, FontStyle.Regular, BaseColor.BLACK)
                    Dim texto As New Phrase(dgv(j, i).Value.ToString(), century)
                    Dim cell As New PdfPCell(texto)
                    PdfTable.AddCell(cell)

                End If
            Next
            PdfTable.CompleteRow()
        Next

        'Se agrega el PDFTable al documento.
        doc.Add(encabezado)
        doc.Add(New Chunk(" "))
        doc.Add(PdfTable)



    End Sub

    Public Sub CrearPDF(dgv As DataGridView, textoencabezado As String)

        Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
        Dim fileName As String
        Dim dlg As New SaveFileDialog()
        dlg.Filter = "PDF Files|*.pdf"
        dlg.FilterIndex = 0

        If dlg.ShowDialog() = DialogResult.OK Then
            fileName = dlg.FileName
            PdfWriter.GetInstance(doc, New FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            doc.Open()
            AñadirTablaPDF(doc, dgv, textoencabezado)
            doc.Close()
        End If


    End Sub


End Module

