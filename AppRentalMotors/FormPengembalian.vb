Imports System.Data.Odbc
Public Class FormPengembalian
    Dim ds As DataSet
    Dim CMD As New OdbcCommand
    Dim DA As OdbcDataAdapter
    Dim RD As OdbcDataReader
    Dim LokasiDB As String
    Sub KondisiAwal()
        Koneksi()
        DA = New OdbcDataAdapter("Select * from tbl_transaksi", Conn)
        ds = New DataSet
        ds.Clear()
        DA.Fill(ds, "tbl_transaksi")
        DataGridView1.DataSource = (ds.Tables("tbl_transaksi"))
    End Sub
    Private Sub FormPengembalian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm:ss tt"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd hh:mm:ss tt"
        Call KondisiAwal()
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox1.Text = random
        TextBox1.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            TextBox5.Text = DateDiff(DateInterval.Minute, DateTimePicker2.Value, DateTimePicker1.Value)

        Else
            TextBox5.Text = "0"
        End If
        If TextBox5.Text > 150 Then
            TextBox7.Text = 150000
        Else
            TextBox7.Text = 1000 * TextBox5.Text
        End If
        If TextBox6.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox8.Text = " " Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_pengembalian values ('" & TextBox1.Text & "','" & TextBox8.Text & "','" & TextBox2.Text & "','" & TextBox4.Text & "','" & DateTimePicker2.Text & "','" & TextBox5.Text & "','" & TextBox7.Text & "','" & DateTimePicker1.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
        End If
        If TextBox6.Text = "" Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OdbcCommand("DELETE FROM tbl_telat WHERE kdTransaksi = '" + TextBox6.Text + "'", Conn)
            CMD.ExecuteNonQuery()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox6.Text = "" Then
            MsgBox("Masukkan Kode Transaksi")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OdbcCommand("select * from tbl_transaksi where kdTransaksi='" & TextBox6.Text & "'", Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                DataGridView1.Show()
            End If
        End If
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            DataGridView1.Visible = False
        End If
        Call Koneksi()
        CMD = New OdbcCommand("select * from tbl_transaksi where kdTransaksi like '%" & TextBox6.Text & "%'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New OdbcDataAdapter("select * from tbl_transaksi where kdTransaksi like '%" & TextBox6.Text & "%'", Conn)
            ds = New DataSet
            DA.Fill(ds, "ketemu")
            DataGridView1.DataSource = ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CMD = New OdbcCommand("Select * from tbl_transaksi where NoIndentitas='" & DataGridView1.Item(1, i).Value & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            TextBox1.Focus()
        Else
            TextBox8.Text = RD.Item("Namapenyewa")
            TextBox3.Text = RD.Item("Alamat")
            TextBox2.Text = RD.Item("NomorPlat")
            TextBox4.Text = RD.Item("Hari")
            DateTimePicker2.Text = RD.Item("TanggalPengembalian")
            TextBox2.Focus()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox1.Text = random
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox1.Text = random
        Me.Hide()
        FormMenuUtama.Show()
    End Sub
End Class