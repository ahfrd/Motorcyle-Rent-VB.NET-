Public Class FormLaporanPeminjaman
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AxCrystalReport1.ReportFileName = "LaporanPeminjaman.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        FormMenuUtama.Show()
    End Sub
    Private Sub FormLaporanPeminjaman_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub AxCrystalReport1_Enter(sender As Object, e As EventArgs) Handles AxCrystalReport1.Enter

    End Sub
End Class