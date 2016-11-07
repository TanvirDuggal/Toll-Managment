Imports System.Data.SqlClient
Public Class Timing_Edit
    Private Shared i As Timing_Edit
    Public Shared ReadOnly Property instance() As Timing_Edit
        Get
            If i Is Nothing Then
                i = New Timing_Edit
            End If
            Return i
        End Get
    End Property

    Private Sub Timing_Edit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Timing_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Select * from timeslot"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader()
        While dr.Read
            ComboBox1.Items.Add(dr("SlotID"))
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Select * from timeslot where SlotID='" & ComboBox1.SelectedItem & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            TextBox1.Text = dr("StartTime")
            TextBox2.Text = dr("EndTime")
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Update timeslot set StartTime='" & TextBox1.Text & "', EndTime='" & TextBox2.Text & "' where SlotID='" & ComboBox1.SelectedItem & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        com.ExecuteNonQuery()
        MessageBox.Show("TIME SLOT UPDATED")

        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
End Class