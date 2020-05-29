Public Class FormMenuUtama
    Sub Terkunci()
        LogoutToolStripMenuItem.Enabled = False
    End Sub
    Private Sub FormMenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Terkunci()
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Call Terkunci()
        FormLogin.Show()
        Me.Hide()
    End Sub

    Private Sub BookingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookingToolStripMenuItem.Click
        FormBooking.Show()
        Me.Hide()
    End Sub
    Private Sub LangsungToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LangsungToolStripMenuItem.Click
        FormTransaksi.Show()
        Me.Hide()
    End Sub

    Private Sub LaporanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem1.Click
        FormLaporans.Show()
        Me.Hide()
    End Sub

    Private Sub DataPenyewaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenyewaToolStripMenuItem.Click
        FormDataPenyewa.Show()
        Me.Hide()
    End Sub

    Private Sub LaporanPeminjamanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPeminjamanToolStripMenuItem.Click
        FormLaporanPeminjaman.Show()
        Me.Hide()
    End Sub

    Private Sub DataMotorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMotorToolStripMenuItem.Click
        Me.Hide()
        FormDataMotor.Show()
    End Sub

    Private Sub LaporanMotorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPengembalianToolStripMenuItem.Click
        FormLaporanPengembalian.Show()
        Me.Hide()
    End Sub

    Private Sub PengembalianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengembalianToolStripMenuItem.Click
        FormPengembalian.Show()
        Me.Hide()
    End Sub
    Private Sub PencarianDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PencarianDataToolStripMenuItem.Click
        PencarianData.Show()
        Me.Hide()
    End Sub
End Class