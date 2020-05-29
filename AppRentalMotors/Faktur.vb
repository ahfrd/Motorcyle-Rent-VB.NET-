Public Class Faktur
    Private Sub Faktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim random As Integer
        Randomize()
        random = (1000000 * Rnd()) + 1
        Label20.Text = random
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Visible = False
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
        Button1.Visible = True
    End Sub
End Class
