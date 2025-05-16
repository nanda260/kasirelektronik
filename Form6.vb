Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient

Public Class Form6
    Public conn As New MySqlConnection
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As MySqlCommand
    Public query As String

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Koneksi()
        da = New MySqlDataAdapter("select * from produk", conn)
        ds = New DataSet
        da.Fill(ds, "kasir_elektronik")
        tabelstok.DataSource = ds.Tables("kasir_elektronik")

    End Sub
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
            query = "SELECT id, nama, stok, harga FROM produk"
            da = New MySqlDataAdapter(query, conn)
            ds = New DataSet()
            da.Fill(ds, "produk")
            tabelstok.DataSource = ds.Tables("produk")
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Close()
    End Sub

    Private Sub Clear()
        TextBoxID.Clear()
        TextBoxNama.Clear()
        TextBoxStok.Clear()
        TextBoxHarga.Clear()
    End Sub
    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        Try
            Koneksi()

            query = "INSERT INTO produk (id, nama, stok, harga) VALUES (@id, @nama, @stok, @harga)"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", TextBoxID.Text)
            cmd.Parameters.AddWithValue("@nama", TextBoxNama.Text)
            cmd.Parameters.AddWithValue("@stok", TextBoxStok.Text)
            cmd.Parameters.AddWithValue("@harga", TextBoxHarga.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            Clear()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menambah data: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonUbah_Click(sender As Object, e As EventArgs) Handles ButtonUbah.Click
        Try
            Koneksi()
            query = "UPDATE produk SET nama=@nama, stok=@stok, harga=@harga WHERE id=@id"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", TextBoxID.Text)
            cmd.Parameters.AddWithValue("@nama", TextBoxNama.Text)
            cmd.Parameters.AddWithValue("@stok", TextBoxStok.Text)
            cmd.Parameters.AddWithValue("@harga", TextBoxHarga.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            Clear()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal mengubah data: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonHapus_Click(sender As Object, e As EventArgs) Handles ButtonHapus.Click
        Try
            Koneksi()
            query = "DELETE FROM produk WHERE id=@id"
            cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@id", TextBoxID.Text)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data berhasil dihapus.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TampilData()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menghapus data: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonKosongkan_Click(sender As Object, e As EventArgs) Handles ButtonKosongkan.Click
        Clear()

    End Sub

    Private Sub tabelstok_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabelstok.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = tabelstok.Rows(e.RowIndex)
            TextBoxID.Text = row.Cells("id").Value.ToString()
            TextBoxNama.Text = row.Cells("nama").Value.ToString()
            TextBoxStok.Text = row.Cells("stok").Value.ToString()
            TextBoxHarga.Text = row.Cells("harga").Value.ToString()
        End If
    End Sub
End Class