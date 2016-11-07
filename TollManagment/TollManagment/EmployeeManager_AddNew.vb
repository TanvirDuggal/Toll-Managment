Imports System.Data.SqlClient
Public Class EmployeeManager_AddNew
    Dim fname As String
    Dim nname As String
    Dim addr As String
    Dim city As String
    Dim state As String
    Dim pin As String
    Dim contact As String
    Dim email As String
    Dim pass As String
    Dim cpass As String
    Dim etype As String
    Dim id As String
    Dim nid As String
    Dim fid As String
    Dim eid As String
    Private Shared i As EmployeeManager_AddNew
    Public Shared ReadOnly Property instance() As EmployeeManager_AddNew
        Get
            If i Is Nothing Then
                i = New EmployeeManager_AddNew
            End If
            Return i
        End Get
    End Property

    Private Sub EmployeeManager_AddNew_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub EmployeeManager_AddNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        con.Open()
        Dim sql As String
        sql = "Select * from department"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()

        While dr.Read
            ComboBox2.Items.Add(dr("Department"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Sub GetEmployeeId()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        con.Open()
        Dim sql As String
        sql = "select * from employee"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        If dr.HasRows() Then
            While dr.Read
                id = dr("EmpId")
            End While
            dr.Close()

            nid = id.Remove(0, 3)

            fid = Convert.ToInt32(nid)
        Else
            eid = "TAN" + "001"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso (e.KeyChar <> ControlChars.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso (e.KeyChar <> ControlChars.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ComboBox1.SelectedItem = ""
        ComboBox2.SelectedItem = ""

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        GetEmployeeId()
        Dim conn As New SqlConnection("Data Source=(localDB)\v11.0; AttachDBFilename=|DataDirectory|\TollManagment.mdf; Integrated Security=True; ")
        conn.Open()


        fname = TextBox1.Text
        addr = TextBox2.Text
        city = TextBox3.Text
        state = ComboBox1.SelectedItem
        pin = TextBox4.Text
        contact = TextBox5.Text
        email = TextBox6.Text
        pass = TextBox7.Text
        cpass = TextBox8.Text
        etype = ComboBox2.SelectedItem

        fid = fid + 1
        If (fid < 10) Then
            fid = "0" + "0" + fid
        ElseIf fid < 100 And fid >= 10 Then
            fid = "0" + fid
        End If

        eid = "TAN" + fid

        Dim sql As String

        If (pass = cpass) Then
            sql = "Insert into employee(EmpId, EmpName, Address, City, State, Pincode, Contact, Email, Password, EmpType) values(" + "'" + eid + "'" + ", '" + fname + "'," + "'" + addr + "' , '" + city + "' , '" + state + "' , '" + pin + "' , '" + contact + "' , '" + email + "' , '" + pass + "' , '" + etype + " ' " + ")"
            Dim comm As SqlCommand = New SqlCommand(sql, conn)
            comm.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("RECORD INSERTED")
        Else
            MessageBox.Show("REENTER YOUR PASSWORD")
            Button2_Click(sender, e)
        End If
        


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    End Sub
End Class