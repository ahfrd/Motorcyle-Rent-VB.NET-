Public Class FormLaporans
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AxCrystalReport1.SelectionFormula = "{tbl_transaksi.Tanggal} in date ('" & DateTimePicker1.Value & "') to date ('" & DateTimePicker2.Value & "')"
        AxCrystalReport1.ReportFileName = "LaporanTransaksi.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        FormMenuUtama.Show()
    End Sub
    Private Sub FormLaporans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm tt"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd hh:mm tt"
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class