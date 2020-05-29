Imports System.Data.Odbc
Public Class FormLogin
    Dim CMD As New OdbcCommand
    Dim RD As OdbcDataReader

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("data login belum lengkap")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OdbcCommand("select * from tbl_petugas where Kode_petugas='" & TextBox1.Text & "' and passwordpetugas='" & TextBox2.Text & "'", Conn)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows Then
                Me.Close()
                FormMenuUtama.Show()
                FormMenuUtama.LogoutToolStripMenuItem.Enabled = True
                FormMenuUtama.DataToolStripMenuItem.Enabled = True
                FormMenuUtama.TransaksiToolStripMenuItem.Enabled = False
                FormMenuUtama.LaporanToolStripMenuItem.Enabled = True
                FormMenuUtama.PencarianDataToolStripMenuItem.Enabled = True
            Else
                Call Koneksi()
                CMD = New OdbcCommand("select * from tbl_login where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'", Conn)
                RD = CMD.ExecuteReader
                RD.Read()

                If RD.HasRows Then
                    Me.Close()
                    FormMenuUtama.Show()
                    FormMenuUtama.LogoutToolStripMenuItem.Enabled = True
                    FormMenuUtama.DataToolStripMenuItem.Enabled = False
                    FormMenuUtama.TransaksiToolStripMenuItem.Enabled = True
                    FormMenuUtama.LaporanToolStripMenuItem.Enabled = False
                    FormMenuUtama.PencarianDataToolStripMenuItem.Enabled = True
                Else
                    MsgBox("Password Atau id salah", MsgBoxStyle.Information, "Information")
                End If
            End If
        End If
    End Sub

    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.MaxLength = 7
        TextBox2.PasswordChar = "X"
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FormRegister.Show()
        Me.Hide()
    End Sub
End Class