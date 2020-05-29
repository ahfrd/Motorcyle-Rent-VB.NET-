
Imports System.Data.Odbc
Public Class PencarianData
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Sub KondisiAwal()
        Koneksi()
        DA = New OdbcDataAdapter("Select * from tbl_telat", Conn)
        ds = New DataSet
        ds.Clear()
        DA.Fill(ds, "tbl_telat")
        DataGridView1.DataSource = (ds.Tables("tbl_telat"))
    End Sub

    Private Sub PencarianData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class