Imports System.Data.SqlClient
Public Class Booth_Delete
    Private Shared i As Booth_Delete
    Public Shared ReadOnly Property instance() As Booth_Delete
        Get
            If i Is Nothing Then
                i = New Booth_Delete
            End If
            Return i
        End Get
    End Property

    Private Sub Booth_Delete_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        i = Nothing
    End Sub
    Private Sub Booth_Delete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()

        Dim sql As String
        sql = "Select * from booth"
        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()

        While dr.Read
            ComboBox1.Items.Add(dr("BoothId"))
        End While
        dr.Close()
        con.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()

        Dim sql As String
        sql = "Delete from booth where BoothId='" & ComboBox1.SelectedItem & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, con)
        comm.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("BOOTH DELEATED")
        ComboBox1.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()

        Dim sql As String
        sql = "Select * from booth where BoothId='" & ComboBox1.SelectedItem & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            TextBox1.Text = dr("Status")
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class