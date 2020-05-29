Imports System.Data.Odbc
Public Class FormTransaksi
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
        DataGridView2.DataSource = (ds.Tables("tbl_motor"))
        Koneksi()
        DA = New OdbcDataAdapter("Select * from tbl_booking", Conn)
        ds = New DataSet
        ds.Clear()
        DA.Fill(ds, "tbl_booking")
        DataGridView1.DataSource = (ds.Tables("tbl_booking"))
        CMD = New OdbcCommand("select * FROM tbl_motor", Conn)
        RD = CMD.ExecuteReader
        Do While RD.Read
            ComboBox1.Items.Add(RD.Item(0))
        Loop
    End Sub
    Private Sub FormTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd hh:mm tt"
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd hh:mm tt"
        Me.WindowState = FormWindowState.Maximized
        Call KondisiAwal()
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox6.Text = random
        TextBox7.Enabled = False
        TextBox6.Enabled = False
        TextBox8.Enabled = False
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Totalharga As Integer
        Totalharga = Val(ComboBox2.Text) * Val(TextBox7.Text)
        TextBox8.Text = Totalharga
        If TextBox6.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox3.Text = " " Or TextBox7.Text = " " Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_transaksi values ('" & TextBox6.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "','" & ComboBox3.Text & "','" & TextBox8.Text & "','" & ComboBox2.Text & "','" & DateTimePicker1.Text & "','" & DateTimePicker2.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox3.Text = " " Or TextBox7.Text = " " Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_penyewa values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
            MsgBox("Transaksi berhasil di Proses", MsgBoxStyle.Information, "Information")
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox3.Text = " " Or TextBox7.Text = " " Then
            MsgBox("Data belum lengkap, Pastikan anda mengisi semua data terlebih dahulu")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into tbl_telat values ('" & TextBox6.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & DateTimePicker2.Text & "')"
            CMD = New OdbcCommand(simpan, Conn)
            CMD.ExecuteNonQuery()
        End If
        DateTimePicker2.Value = DateAdd(DateInterval.Day, Val(ComboBox2.Text), DateTimePicker1.Value.Date)
        Faktur.Label11.Text = TextBox1.Text()
        Faktur.Label12.Text = TextBox2.Text()
        Faktur.Label13.Text = DateTimePicker1.Text()
        Faktur.Label14.Text = TextBox3.Text()
        Faktur.Label15.Text = TextBox4.Text()
        Faktur.Label16.Text = TextBox6.Text()
        Faktur.Label17.Text = ComboBox3.Text()
        Faktur.Label18.Text = TextBox8.Text()
        Faktur.Label22.Text = ComboBox2.Text
        Faktur.Label24.Text = ComboBox1.Text
        Faktur.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        FormMenuUtama.Show()
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox6.Text = random
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        TextBox7.Text = ""
        ComboBox2.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim random As Integer
        Randomize()
        random = (1000 * Rnd()) + 1
        TextBox6.Text = random
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        ComboBox3.Text = ""
        TextBox7.Text = ""
        ComboBox2.Text = ""
        TextBox8.Text = ""
        DateTimePicker1.ResetText()
        DateTimePicker2.ResetText()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox5.Text = "" Then
            MsgBox("Masukkan Kode Booking")
            Exit Sub
        Else
            Call Koneksi()
            CMD = New OdbcCommand("select * from tbl_booking where kode_booking='" & TextBox5.Text & "'", Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows Then
                DataGridView1.Show()
            End If
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Call Koneksi()
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        CMD = New OdbcCommand("Select * from tbl_booking where NomorIdentitas='" & DataGridView1.Item(1, i).Value & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            TextBox1.Focus()
        Else
            TextBox1.Text = RD.Item("NomorIdentitas")
            TextBox2.Text = RD.Item("Nama_penyewa")
            TextBox3.Text = RD.Item("Alamat")
            TextBox4.Text = RD.Item("NomorTelpon")
            DateTimePicker1.Text = RD.Item("tgl_book")
            TextBox2.Focus()
        End If
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "12" Then
            ComboBox2.Text = "1 Hari"
            ComboBox2.Enabled = False
        Else
            ComboBox2.Enabled = True
        End If
        Dim hargasewa As Integer
        hargasewa = ComboBox3.Text
        If hargasewa = 12 Then
            TextBox7.Text = 50000
        Else
            TextBox7.Text = 100000
        End If
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then
            DataGridView1.Visible = False
        End If
        Call Koneksi()
        CMD = New OdbcCommand("select * from tbl_booking where kode_booking like '%" & TextBox5.Text & "%'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Call Koneksi()
            DA = New OdbcDataAdapter("select * from tbl_booking where kode_booking like '%" & TextBox5.Text & "%'", Conn)
            ds = New DataSet
            DA.Fill(ds, "ketemu")
            DataGridView1.DataSource = ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If
    End Sub
End Class