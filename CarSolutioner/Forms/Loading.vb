Public Class Loading
    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmrTimer.Start()
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs) Handles tmrTimer.Tick

        frmMainMenu.Show()
        Me.Dispose()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class