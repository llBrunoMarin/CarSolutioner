Module Metodos

    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Public Sub cargando(imagen As PictureBox)

        Dim retraso As Integer

        retraso = 2000 + GetTickCount


        While retraso >= GetTickCount
            Application.DoEvents()
            imagen.Visible = True
        End While

        imagen.Visible = False
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
                        Return " AND " + columna + " = " + DirectCast(ctrl, ComboBox).SelectedItem.ToString + ""
                    End If
                Else
                    Return ""
                End If

            Case GetType(NumericUpDown)
                Dim num As NumericUpDown = DirectCast(ctrl, NumericUpDown)

                If Not (num.Value = 0) Then
                    Return " AND " + columna + " = " + num.Value + ""
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


End Module

