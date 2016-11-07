Imports System.Data.SqlClient
Public Class Timing_view
    Private Shared i As Timing_view
    Public Shared ReadOnly Property instance() As Timing_view
        Get
            If i Is Nothing Then
                i = New Timing_view
            End If
            Return i
        End Get
    End Property

    Private Sub Timing_view_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Timing_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Close()
    End Sub
End Class