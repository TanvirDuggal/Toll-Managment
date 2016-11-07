Imports System.Data.SqlClient
Public Class Login
    
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()

        id = TextBox1.Text
        pass = TextBox2.Text

        Dim sql As String
        sql = "Select * from employee where EmpId='" & id & "' and password='" & pass & "'"

        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        If dr.HasRows Then
            Dim md As Form1 = Form1.instance()
            With md
                .Show()
                .Focus()
            End With
            Me.Hide()
        Else
            MessageBox.Show("NO ID FOUND")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If

        While dr.Read
            ename = dr("EmpName")
            type = dr("EmpType")
        End While
        boothid()
        dr.Close()
        con.Close()
    End Sub
    Sub boothid()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from timing where EmpId='" & id & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader()
        While dr.Read
            idbooth = dr("BoothId")

        End While
        dr.Close()
        con.Close()
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class