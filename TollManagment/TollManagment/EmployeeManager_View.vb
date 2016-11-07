Imports System.Data.SqlClient
Public Class EmployeeManager_View
    Private Shared i As EmployeeManager_View
    Public Shared ReadOnly Property instance() As EmployeeManager_View
        Get
            If i Is Nothing Then
                i = New EmployeeManager_View
            End If
            Return i
        End Get
    End Property

    Private Sub EmployeeManager_View_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub EmployeeManager_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        con.Open()

        Dim sql As String
        sql = "Select * from employee"

        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()

        While dr.Read
            If dr("EmpId") = "TAN00" Then
                ComboBox1.Items.Add("")
                ComboBox2.Items.Add("")
            Else
                ComboBox1.Items.Add(dr("EmpId"))
                ComboBox2.Items.Add(dr("EmpName"))

            End If
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        con.Open()

        Dim sql As String
        sql = "Select * from employee where EmpId='" & ComboBox1.Text & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            ComboBox2.Text = dr("EmpName")
            TextBox1.Text = dr("Address")
            TextBox2.Text = dr("City")
            TextBox3.Text = dr("State")
            TextBox4.Text = dr("Pincode")
            TextBox5.Text = dr("Contact")
            TextBox6.Text = dr("Email")
        End While
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        con.Open()

        Dim sql As String
        sql = "Select * from employee where EmpName='" & ComboBox2.Text & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            ComboBox1.Text = dr("EmpId")
            TextBox1.Text = dr("Address")
            TextBox2.Text = dr("City")
            TextBox3.Text = dr("State")
            TextBox4.Text = dr("Pincode")
            TextBox5.Text = dr("Contact")
            TextBox6.Text = dr("Email")
            TextBox7.Text = dr("EmpType")
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class