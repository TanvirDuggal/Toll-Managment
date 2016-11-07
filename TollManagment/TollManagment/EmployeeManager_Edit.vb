Imports System.Data.SqlClient

Public Class EmployeeManager_Edit
    Dim addr, city, state, pin, cont, email, etype, pass, id, nam As String

    Private Shared i As EmployeeManager_Edit
    Public Shared ReadOnly Property instance() As EmployeeManager_Edit
        Get
            If i Is Nothing Then
                i = New EmployeeManager_Edit
            End If
            Return i
        End Get
    End Property

    Private Sub EmployeeManager_Edit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub EmployeeManager_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        conn.Open()

        Dim sql As String

        sql = "Select * from employee"
        Dim comm As SqlCommand = New SqlCommand(sql, conn)

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
        conn.Close()

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        addr = TextBox1.Text
        city = TextBox2.Text
        state = ComboBox3.SelectedItem
        pin = TextBox3.Text
        cont = TextBox4.Text
        email = TextBox5.Text

        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        conn.Open()

        Dim sql As String

        sql = "Update employee set Address='" & addr & "', City='" & city & "', State='" & state & "', Pincode='" & pin & "', Contact='" & cont & "', Email='" & email & "' , Password='" & pass & "', EmpType='" & etype & "' where EmpId='" & ComboBox1.SelectedItem & "'"


        Dim comm As SqlCommand = New SqlCommand(sql, conn)
        comm.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("RECORD UPDATED")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        conn.Open()

        Dim sql As String

        sql = "Select * from employee where EmpId='" & ComboBox1.SelectedItem & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, conn)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            ComboBox2.Text = dr("EmpName")
            TextBox1.Text = dr("Address")
            TextBox2.Text = dr("City")
            ComboBox3.Text = dr("State")
            TextBox3.Text = dr("Pincode")
            TextBox4.Text = dr("Contact")
            TextBox5.Text = dr("Email")
        End While

        dr.Close()
        conn.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        conn.Open()

        Dim sql As String

        sql = "Select * from employee where EmpName='" & ComboBox2.SelectedItem & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, conn)

        Dim dr As SqlDataReader
        dr = comm.ExecuteReader

        While dr.Read
            ComboBox1.Text = dr("EmpId")
            TextBox1.Text = dr("Address")
            TextBox2.Text = dr("City")
            ComboBox3.Text = dr("State")
            TextBox3.Text = dr("Pincode")
            TextBox4.Text = dr("Contact")
            TextBox5.Text = dr("Email")
        End While

        dr.Close()
        conn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class