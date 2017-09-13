Module Metodos

    'Devuelve el tipo de fecha que esta seleccionada (es decir, si es dia/mes/año, o si es dia/año, o solo mes, etc
    Public Function TipoDeFecha(dia As ComboBox, mes As ComboBox, año As ComboBox) As String

        Dim tipofecha As String = ""

        If (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And (año.SelectedItem = Nothing) Then
            tipofecha = "000"
        Else
            If (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And Not (año.SelectedItem = Nothing) Then
                tipofecha = "001"
            Else
                If (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And (año.SelectedItem = Nothing) Then
                    tipofecha = "010"
                Else
                    If (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And Not (año.SelectedItem = Nothing) Then
                        tipofecha = "011"
                    Else
                        If Not (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And (año.SelectedItem = Nothing) Then
                            tipofecha = "100"
                        Else
                            If Not (dia.SelectedItem = Nothing) And (mes.SelectedItem = Nothing) And Not (año.SelectedItem = Nothing) Then
                                tipofecha = "101"
                            Else
                                If Not (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And (año.SelectedItem = Nothing) Then
                                    tipofecha = "110"
                                Else
                                    If Not (dia.SelectedItem = Nothing) And Not (mes.SelectedItem = Nothing) And Not (año.SelectedItem = Nothing) Then
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
                Return ""

            Case "001"
                Return " AND anio = " + dia.SelectedItem.ToString + ""

            Case "010"
                Return " AND mes = " + mes.SelectedItem.ToString + ""

            Case "011"
                Return " AND mes = " + mes.SelectedItem.ToString + " AND anio = " + año.SelectedItem.ToString + ""

            Case "100"
                Return " AND dia = " + dia.SelectedItem.ToString + ""

            Case "101"
                Return " AND dia = " + dia.SelectedItem.ToString + " AND anio = " + año.SelectedItem.ToString + ""

            Case "110"
                Return " AND dia = " + dia.SelectedItem.ToString + " AND mes = " + mes.SelectedItem.ToString + ""

            Case "111"
                Return " AND dia = '" + dia.SelectedItem.ToString + "' AND mes = '" + mes.SelectedItem.ToString + "' AND anio = '" + año.SelectedItem.ToString + "'"

        End Select

    End Function

    'Verifica una cédula que entra como parámetro
    Function VerificarCI(ci As String) As Boolean

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

End Module
