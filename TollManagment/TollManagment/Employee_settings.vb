Imports System.Data.SqlClient
Public Class Employee_settings
    Dim id, pass As String
    Dim passold, passnew, passcon As String
    Private Shared i As Employee_settings
    Public Shared ReadOnly Property instance() As Employee_settings
        Get
            If i Is Nothing Then
                i = New Employee_settings
            End If
            Return i
        End Get
    End Property
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Label2.Visible = True
        ComboBox1.Visible = True

    End Sub

    

    Private Sub Employee_settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub

    Private Sub Employee_settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Else
                ComboBox1.Items.Add(dr("EmpId"))
            End If
        End While
        dr.Close()
        conn.Close()
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
            pass = dr("Password")
        End While

        dr.Close()
        conn.Close()

        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        Button1.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True; ")
        conn.Open()

        passold = TextBox2.Text
        passnew = TextBox3.Text
        passcon = TextBox1.Text

        If pass = passold Then
            If passnew = passcon Then
                Dim sql As String
                sql = "Update employee set Password='" & passcon & "'" & "where EmpId='" & ComboBox1.SelectedItem & "'"
                Dim comm As SqlCommand = New SqlCommand(sql, conn)
                comm.ExecuteNonQuery()
                conn.Close()
                MessageBox.Show("PASSWORD UPDATED")
                Me.Close()
            Else
                MessageBox.Show("NEW PASSWORD DIDNOT MATCH")
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
            End If
        Else
            MessageBox.Show("RECHECK YOUR PASSWORD")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class