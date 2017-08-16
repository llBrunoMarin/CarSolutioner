'Ignorar, es para que no abra un Designer.
<System.ComponentModel.DesignerCategory("")>
Public Class NoDesignerReservas
End Class

Partial Public Class MainMenu

    Private Sub chboxFechaFRes_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFechaFRes.CheckedChanged
        If chboxFechaFRes.Checked Then
            dtpFAResF.Enabled = True
            dtpFAResI.Enabled = True
        Else
            dtpFAResF.Enabled = False
            dtpFAResI.Enabled = False
        End If
    End Sub


End Class
