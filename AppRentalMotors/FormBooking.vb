Imports System.Data.Odbc
Public Class FormBooking
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Sub KondisiAwal()
        Koneksi()
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox1.Text = random
        TextBox1.Enabled = False
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        DateTimePicker1.ResetText()
    End Sub
    Private Sub FormBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm:ss"
        Me.WindowState = FormWindowState.Maximized
        Call KondisiAwal()
        TextBox2.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_booking values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox4.Text & "','" & DateTimePicker1.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di Input dan simpan kode booking", MsgBoxStyle.Information, "Information")
            Call KondisiAwal()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        FormMenuUtama.Show()
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox1.Text = random
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
End Class