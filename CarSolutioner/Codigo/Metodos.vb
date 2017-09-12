Module Metodos

    Public Function TipoDeFecha(dia As ComboBox, mes As ComboBox, año As TextBox)

        Dim tipofecha As String = ""

        If (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And (año.Text = "") Then
            tipofecha = "000"
        Else
            If (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And Not (año.Text = "") Then
                tipofecha = "001"
            Else
                If (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And (año.Text = "") Then
                    tipofecha = "010"
                Else
                    If (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And Not (año.Text = "") Then
                        tipofecha = "011"
                    Else
                        If Not (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And (año.Text = "") Then
                            tipofecha = "100"
                        Else
                            If Not (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And Not (año.Text = "") Then
                                tipofecha = "101"
                            Else
                                If Not (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And (año.Text = "") Then
                                    tipofecha = "110"
                                Else
                                    If Not (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And Not (año.Text = "") Then
                                        tipofecha = "111"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Select Case tipofecha

            Case "000"
                Return "Nada"

            Case "001"
                Return "Año"

            Case "010"
                Return "Mes"

            Case "011"
                Return "Mes/Año"

            Case "100"
                Return "Dia"

            Case "101"
                Return "Dia/Año"

            Case "110"
                Return "Dia/Mes"

            Case "111"
                Return "Dia/Mes/Año"

            Case Else
                Return "Error"

        End Select

    End Function

    Function VerificarCI(ci As String) As Boolean

        Dim verificador As String = ci.Substring(7, 1)
        Dim cedula As String = ci.Substring(0, 7)
        Dim Algoritmo() As Integer = {2, 9, 8, 7, 6, 3, 4}
        Dim Operacion As String
        Dim sumaVerificarCI As Integer
        Dim valor As Integer

        'Si el valor ingresado es numérico
        If IsNumeric(ci) Then

            'Si el largo del numero es exactamente 8
            If (ci.Length = 8) Then

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
    ''Recorre un contenedor en busca de todos los contenedores de un tipo (en este caso, ComboBox, todavia no le encontramos uso)
    'Public Function TodosLosControles(ByRef parent As Control) As List(Of ComboBox)

    '    Dim list As New List(Of ComboBox)
    '    Dim ControlesContenedor As New Stack(Of Control)

    '    ControlesContenedor.Push(parent)
    '    While ControlesContenedor.Count > 0

    '        For Each child As Control In ControlesContenedor.Pop().Controls

    '            If child.HasChildren Then
    '                ControlesContenedor.Push(child)
    '            End If

    '            If child.GetType Is GetType(ComboBox) Then
    '                list.Add(child)
    '            End If

    '        Next

    '    End While

    '    Return list

    'End Function

End Module
