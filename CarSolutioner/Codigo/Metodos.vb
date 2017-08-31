Module Metodos

    Public Function prueba(dia As ComboBox, mes As ComboBox, año As TextBox)

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
