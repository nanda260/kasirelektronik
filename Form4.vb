Imports MySql.Data.MySqlClient

Public Class Form4
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public query As String

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        da = New MySqlDataAdapter("select * from user", conn)
        ds = New DataSet
        da.Fill(ds, "kasir_elektronik")
        tabeluser.DataSource = ds.Tables("kasir_elektronik")

    End Sub

    ' Fungsi untuk melakukan koneksi ke database
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

    ' Fungsi untuk menampilkan data ke DataGridView
    Private Sub TampilData()
        Try
            Koneksi()
            query = "SELECT ID, Username, Password FROM user"
            da = New MySqlDataAdapter(query, conn)
            ds = New DataSet()
            da.Fill(ds, "user")
            tabeluser.DataSource = ds.Tables("user")
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    ' Tombol untuk kembali ke Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form3.Show()
        Close()
    End Sub

    ' Tombol untuk menghapus data
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        ' Cek apakah ada baris yang dipilih di DataGridView
        If tabeluser.SelectedRows.Count > 0 Then
            ' Ambil ID pengguna yang dipilih
            Dim selectedRow As DataGridViewRow = tabeluser.SelectedRows(0)
            Dim id As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)

            ' Konfirmasi penghapusan
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                ' Jika ya, lakukan penghapusan
                Try
                    Koneksi()

                    ' Query untuk menghapus data berdasarkan ID
                    query = "DELETE FROM user WHERE ID = @ID"
                    cmd = New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", id)

                    ' Eksekusi query untuk menghapus data
                    cmd.ExecuteNonQuery()

                    ' Beri pemberitahuan
                    MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Perbarui DataGridView setelah penghapusan
                    TampilData()

                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus data: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End If
        Else
            MessageBox.Show("Silakan pilih baris yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Event handler untuk klik di DataGridView (untuk memilih data)
    Private Sub tabeluser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabeluser.CellContentClick
        ' Bisa digunakan untuk mendapatkan data yang dipilih di DataGridView
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = tabeluser.Rows(e.RowIndex)
            Dim username As String = selectedRow.Cells("username").Value.ToString()
            MessageBox.Show("Username yang dipilih: " & username)
        End If
    End Sub

End Class
