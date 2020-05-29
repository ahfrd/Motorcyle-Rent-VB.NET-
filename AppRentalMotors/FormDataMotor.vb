Imports System.Data.Odbc
Public Class FormDataMotor
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Sub KondisiAwal()
        Koneksi()
        DA = New OdbcDataAdapter("Select * from tbl_motor", Conn)
        ds = New DataSet
        ds.Clear()
        DA.Fill(ds, "tbl_motor")
        DataGridView1.DataSource = (ds.Tables("tbl_motor"))
    End Sub
    Private Sub FormDataMotor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormMenuUtama.Show()
    End Sub
End Class