Public Class Form3
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show("Anda berhasil logout!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles ButtonAdmin.MouseEnter
        ButtonAdmin.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles ButtonAdmin.MouseLeave
        ButtonAdmin.ForeColor = Color.Blue
    End Sub

    Private Sub ButtonPenjualan_MouseEnter(sender As Object, e As EventArgs) Handles ButtonPenjualan.MouseEnter
        ButtonPenjualan.ForeColor = Color.White
    End Sub

    Private Sub ButtonPenjualan_MouseLeave(sender As Object, e As EventArgs) Handles ButtonPenjualan.MouseLeave
        ButtonPenjualan.ForeColor = Color.Blue
    End Sub

    Private Sub ButtonStok_MouseEnter(sender As Object, e As EventArgs) Handles ButtonStok.MouseEnter
        ButtonStok.ForeColor = Color.White
    End Sub

    Private Sub ButtonStok_MouseLeave(sender As Object, e As EventArgs) Handles ButtonStok.MouseLeave
        ButtonStok.ForeColor = Color.Blue
    End Sub

    Private Sub ButtonLaporan_MouseEnter(sender As Object, e As EventArgs) Handles ButtonLaporan.MouseEnter
        ButtonLaporan.ForeColor = Color.White
    End Sub

    Private Sub ButtonLaporan_MouseLeave(sender As Object, e As EventArgs) Handles ButtonLaporan.MouseLeave
        ButtonLaporan.ForeColor = Color.Blue
    End Sub

    Private Sub ButtonInfo_MouseEnter(sender As Object, e As EventArgs) Handles ButtonInfo.MouseEnter
        ButtonInfo.ForeColor = Color.White
    End Sub

    Private Sub ButtonInfo_MouseLeave(sender As Object, e As EventArgs) Handles ButtonInfo.MouseLeave
        ButtonInfo.ForeColor = Color.Blue
    End Sub

    Private Sub ButtonAdmin_Click(sender As Object, e As EventArgs) Handles ButtonAdmin.Click
        Form4.Show()
    End Sub

    Private Sub ButtonPenjualan_Click(sender As Object, e As EventArgs) Handles ButtonPenjualan.Click
        Form5.Show()
    End Sub

    Private Sub ButtonStok_Click(sender As Object, e As EventArgs) Handles ButtonStok.Click
        Form6.Show()
    End Sub

    Private Sub ButtonLaporan_Click(sender As Object, e As EventArgs) Handles ButtonLaporan.Click
        Form7.Show()
    End Sub

    Private Sub ButtonInfo_Click(sender As Object, e As EventArgs) Handles ButtonInfo.Click
        forminfo.Show()
    End Sub
End Class