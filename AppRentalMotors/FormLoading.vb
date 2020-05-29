
Public Class FormLoading

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value += 2
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Stop()
            MessageBox.Show("Selamat Datang", "info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FormLogin.Show()
            Me.Hide()

        End If

    End Sub
End Class

