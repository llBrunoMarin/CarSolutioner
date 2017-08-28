Module Metodos

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
