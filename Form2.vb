Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class Form2
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public query As String

    Public Sub Koneksi()
        Dim strconn As String
        Try
            strconn = "server=localhost;user=root;password=;database=kasir_elektronik"
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.ConnectionString = strconn
            conn.Open()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TampilData()
        Try
            Koneksi()
            da = New MySqlDataAdapter("SELECT * FROM user", conn)
            ds = New DataSet()
            da.Fill(ds, "kasir_elektronik")
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub btn_buatakun_Click(sender As Object, e As EventArgs) Handles btn_buatakun.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text


        If username = "" Or password = "" Then
            MessageBox.Show("Username dan password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Koneksi()
            query = "INSERT INTO user (username, password) VALUES (@username, @password)"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Akun kamu telah berhasil dibuat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtUsername.Clear()
            txtPassword.Clear()

        Catch ex As Exception
            MessageBox.Show("Gagal membuat akun: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btn_keformlogin_Click(sender As Object, e As EventArgs) Handles btn_keformlogin.Click
        Form1.Show()
        Close()
    End Sub
End Class
