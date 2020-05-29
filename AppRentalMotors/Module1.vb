Imports System.Data.Odbc
Module Module1
    Public Conn As OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public LokasiData As String
    Sub Koneksi()
        LokasiData = "Driver={MySQL ODBC 3.51 Driver};database=test;server=localhost;uid=root"
        Conn = New OdbcConnection(LokasiData)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
End Module