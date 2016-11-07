Imports System.Data.SqlClient
Public Class Timing_New
    Dim ename, eid As String
    Dim etype As String = "Booth Incharge"
    Dim slotid, timeIN, timeOUT As String
    Dim boothid As String
    Dim tddate As Date = Date.Today()
    Private Shared i As Timing_New
    Public Shared ReadOnly Property instance() As Timing_New
        Get
            If i Is Nothing Then
                i = New Timing_New
            End If
            Return i
        End Get
    End Property

    Private Sub Timing_New_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Timing_New_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        timenow()
        booth()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from employee where EmpType='" & etype & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader()
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
        eid = ComboBox1.SelectedItem
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from employee where EmpId='" & ComboBox1.SelectedItem & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)

        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            ComboBox2.Text = dr("EmpName")
        End While
        Label3.Visible = True
        ComboBox3.Visible = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ename = ComboBox2.SelectedItem
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from employee where EmpName='" & ComboBox2.SelectedItem & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            ComboBox1.Text = dr("EmpId")
        End While
        Label3.Visible = True
        ComboBox3.Visible = True

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
    Sub booth()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from booth"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            ComboBox3.Items.Add(dr("BoothId"))
        End While
        dr.Close()
        con.Close()
    End Sub

    Sub timenow()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from timeslot"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            ComboBox4.Items.Add(dr("SlotID"))
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        boothid = ComboBox3.SelectedItem
        Label5.Visible = True
        ComboBox4.Visible = True
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        slotid = ComboBox4.SelectedItem
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Select * from timeslot where SlotID='" & slotid & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = com.ExecuteReader
        While dr.Read
            timeIN = dr("StartTime")
            timeOUT = dr("EndTime")
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True;")
        con.Open()
        Dim sql As String
        sql = "Insert into timing(TimeIN, TimeOUT, EmpId, BoothId, SlotNo, Date) values('" & timeIN & "','" & timeOUT & "','" & eid & "','" & boothid & "','" & slotid & "','" & tddate & "'" & ")"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        com.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Slot Alloted To : " & ename & ", " & eid)
        idbooth = boothid
    End Sub
End Class