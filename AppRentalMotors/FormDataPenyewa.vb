Imports System.Data.Odbc
Public Class FormDataPenyewa
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Sub KondisiAwal()
        Koneksi()
        DA = New OdbcDataAdapter("Select * from tbl_penyewa", Conn)
        ds = New DataSet
        ds.Clear()
        DA.Fill(ds, "tbl_penyewa")
        DataGridView1.DataSource = (ds.Tables("tbl_penyewa"))
    End Sub
    Private Sub FormDataPenyewa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormMenuUtama.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Me.WindowState = FormWindowState.Maximized
    End Sub
End Class
