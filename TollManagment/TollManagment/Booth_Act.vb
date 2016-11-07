Imports System.Data.SqlClient
Public Class Booth_Act
    Dim act As Boolean
    Dim actt As String

    Private Shared i As Booth_Act
    Public Shared ReadOnly Property instance() As Booth_Act
        Get
            If i Is Nothing Then
                i = New Booth_Act
            End If
            Return i
        End Get
    End Property

    Private Sub Booth_Act_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Booth_Act_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


        actt = TextBox1.Text
        act = Convert.ToBoolean(actt)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()

        act = Not act

        actt = Convert.ToString(act)

        Dim sql As String
        sql = "Update booth set Status='" & actt & "'" & "where BoothId='" & ComboBox1.SelectedItem & "'"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        comm.ExecuteNonQuery()
        con.Close()
        If actt = "True" Then
            MessageBox.Show("BOOTH ACTIVATED")
            TextBox1.Text = actt
        ElseIf actt = "False" Then
            MessageBox.Show("BOOTH DEACTIVATED")
            TextBox1.Text = actt
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class