Imports MySql.Data.MySqlClient

Public Class Form1
    Public conn As New MySqlConnection
    Public cmd As MySqlCommand
    Public query As String

    Private Sub Koneksi()
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

    ' Fungsi untuk login
    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text

        If username = "" Or password = "" Then
            MessageBox.Show("Username dan password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try

            Koneksi()

            query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@password", password)

            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If result > 0 Then
                Form3.Show()
            Else

                MessageBox.Show("Username atau password salah atau belum terdaftar!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            txtUsername.Clear()
            txtPassword.Clear()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btn_formbuatakun_Click(sender As Object, e As EventArgs) Handles btn_formbuatakun.Click
        Form2.Show()
    End Sub
End Class
