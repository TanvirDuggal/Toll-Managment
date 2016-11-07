Imports System.Data.SqlClient
Public Class VechileCharge_View
    Private Shared i As VechileCharge_View
    Public Shared ReadOnly Property instance() As VechileCharge_View
        Get
            If i Is Nothing Then
                i = New VechileCharge_View
            End If
            Return i
        End Get
    End Property
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub VechileCharge_View_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub

    Private Sub VechileCharge_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|TollManagment.mdf;Integrated Security=True;")
        con.Open()

        Dim sql As String
        sql = "Select * from vechilecharge"

        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        While dr.Read
            ComboBox1.Items.Add(dr("VechileType"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|TollManagment.mdf;Integrated Security=True;")
        con.Open()

        Dim sql As String
        sql = "Select * from vechilecharge where VechileType='" & ComboBox1.SelectedItem & "'"
        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            TextBox1.Text = dr("OneWayCharge")
            TextBox2.Text = dr("TwoWayCharge")
            TextBox3.Text = dr("ExtraCharge")
        End While

        dr.Close()
        con.Close()
    End Sub
End Class