Imports System.Data.SqlClient
Public Class Booth_AddNew
    Private Shared i As Booth_AddNew
    Public Shared ReadOnly Property instance() As Booth_AddNew
        Get
            If i Is Nothing Then
                i = New Booth_AddNew
            End If
            Return i
        End Get
    End Property
    Dim bth As String
    Dim bthn, bthc As String
    Dim btc As String
    Dim act As Boolean
    Dim actt As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getbooth()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()

        bthc = bthc + 1

        If (bthc < 10) Then
            bthc = "0" + "0" + bthc
        ElseIf (bthc > 10 And bthc < 100) Then
            bthc = "0" + bthc
        End If

        btc = "BTC" + bthc
        act = False
        actt = Convert.ToString(act)

        Dim sql As String
        sql = "Insert into booth(BoothId,Status) values(" + "'" + btc + "','" + actt + "'" + ")"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        comm.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("NEW BOOTH ADDED")

        Label2.Visible = True
        Label3.Visible = True
        TextBox1.Visible = True
        TextBox2.Visible = True

        TextBox1.Text = btc
        TextBox2.Text = actt
    End Sub

    Private Sub Booth_AddNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub

    Private Sub Booth_AddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Sub getbooth()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()

        Dim sql As String
        sql = "Select * from booth"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        If dr.HasRows() Then
            While dr.Read
                bth = dr("BoothId")
            End While
            bthn = bth.Remove(0, 3)
            bthc = Convert.ToInt32(bthn)
        Else
            btc = "BTC" + "000"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class