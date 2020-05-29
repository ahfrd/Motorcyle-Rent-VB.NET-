Imports System.Data.Odbc
Public Class FormRegister
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.MaxLength = 6
        TextBox2.PasswordChar = "X"
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_login values ('" & TextBox1.Text & "','" & TextBox2.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Registrasi Berhasil", MsgBoxStyle.Information, "Information")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormLogin.Show()
        Me.Hide()
    End Sub
End Class