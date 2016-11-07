Imports System.Data.SqlClient
Public Class Transaction_Start
    Dim ttype, tway, vtype, vno, slip, paid, charge, ccharge, tranid As String
    Dim tranid2 As String
    Dim tranid3 As String
    Dim tranid4 As String
    Dim onecharg, twocharg, onechargee, twochargee As String
    Dim dateIN As Date
    Dim slipreturn, vechilereturn, vechilenoreturn, extra As String
    Dim extrac, extrar As Single
    Dim extrahour As Single
    Dim datee As String
    Dim dateOUT As Date
    Dim time1 As Long
    Private Shared i As Transaction_Start
    Public Shared ReadOnly Property instance() As Transaction_Start
        Get
            If i Is Nothing Then
                i = New Transaction_Start
            End If
            Return i
        End Get
    End Property

    Private Sub Transaction_Start_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Transaction_Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label13.Text = ename
        Label15.Text = id
        Label11.Text = idbooth
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
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
    Sub gettran()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.open()
        Dim sql As String
        sql = "Select * from transact"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        If dr.HasRows() Then
            While dr.Read
                tranid = dr("SlipNo")
            End While
            tranid2 = tranid.Remove(0, 3)
            tranid3 = Convert.ToInt32(tranid2)
        Else
            tranid4 = "TRN" + "000"
        End If

    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged

        If RadioButton3.Checked = True Then
            GroupBox1.Visible = True
            GroupBox2.Visible = False
            ttype = "New Transaction"

        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            GroupBox2.Visible = True
            GroupBox1.Visible = False
            ttype = "Return"
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            tway = "One Way"
            Label20.Visible = True
            ComboBox1.Visible = True
            Label1.Visible = True
            TextBox1.Visible = True
            Label2.Visible = True
            TextBox2.Visible = True
            Label3.Visible = True
            TextBox3.Visible = True
            Label5.Visible = True
            TextBox4.Visible = True
            Button1.Visible = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            tway = "Two Way"
            Label20.Visible = True
            ComboBox1.Visible = True
            Label1.Visible = True
            TextBox1.Visible = True
            Label2.Visible = True
            TextBox2.Visible = True
            Label3.Visible = True
            TextBox3.Visible = True
            Label5.Visible = True
            TextBox4.Visible = True
            Button1.Visible = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Select * from vechilecharge where VechileType='" & ComboBox1.SelectedItem & "'"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader
        While dr.Read
            onecharg = dr("OneWayCharge")
            twocharg = dr("TwoWayCharge")
        End While

        If RadioButton1.Checked = True Then
            charge = onecharg
        ElseIf RadioButton2.Checked = True Then
            charge = twocharg
        End If

        TextBox2.Text = charge
        ccharge = Convert.ToInt32(charge)
        dr.Close()
        con.Close()
    End Sub


    Private Sub TextBox3_LostFocus(sender As Object, e As EventArgs) Handles TextBox3.LostFocus
        paid = TextBox3.Text
        TextBox4.Text = paid - ccharge
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gettran()
        vtype = ComboBox1.SelectedItem
        vno = TextBox1.Text
        dateIN = Now.ToString
        tranid3 = tranid3 + 1
        If (tranid3 < 10) Then
            tranid3 = "0" + "0" + tranid3
        ElseIf (tranid3 >= 10 And tranid3 < 100) Then
            tranid3 = "0" + tranid3
        End If

        tranid4 = "TRN" + tranid3
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Insert into transact(TransID, EmpName, EmpId, TransType, TransWay, VechileType, VechileNo, SlipNo, Charges, DateIN, BoothIN) values('" & tranid4 & "','" & ename & "','" & id & "','" & ttype & "','" & tway & "','" & vtype & "','" & vno & "','" & tranid4 & "','" & charge & "','" & dateIN & "','" & idbooth & "'" & ")"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        comm.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("TRANSACTION COMPLETE" & vbCrLf & "SLIP NO : " & tranid4)

        RadioButton3.Checked = False
        RadioButton4.Checked = False
        GroupBox1.Visible = False
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox6_LostFocus(sender As Object, e As EventArgs) Handles TextBox6.LostFocus

        slipreturn = TextBox6.Text
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Select * from transact where SlipNo='" & slipreturn & "'"
        Dim comm As SqlCommand = New SqlCommand(sql, con)
        Dim dr As SqlDataReader
        dr = comm.ExecuteReader()
        While dr.Read
            vechilereturn = dr("VechileType")
            vechilenoreturn = dr("VechileNo")
            datee = dr("DateIN")
        End While
        'extracal()
        TextBox5.Text = vechilenoreturn
        TextBox7.Text = vechilereturn
        TextBox8.Text = datee
        dateOUT = Now.ToString
        TextBox9.Text = dateOUT
        time1 = DateDiff(DateInterval.Hour, dateOUT, Convert.ToDateTime(datee))
        time1 = Math.Abs(time1)
        If (time1 <= 24) Then
            extrar = 0
            extrahour = 0
        ElseIf (time1 > 24) Then
            extrar = ((time1 - 24) / 12) * extrac
            extrahour = time1 - 24
        End If
        extrar = Math.Ceiling(extrar)
        TextBox11.Text = extrahour
        TextBox10.Text = extrar
    End Sub
    Sub extracal()
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sqll As String
        sqll = "Select * from vechilecharge where VechileType='" & vechilereturn & "'"
        Dim commm As SqlCommand = New SqlCommand(sqll, con)
        Dim der As SqlDataReader
        der = commm.ExecuteReader()
        While der.Read
            extra = der("ExtraCharges")
        End While
        extrac = Convert.ToInt32(extra)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection("Data Source=(localDB)\v11.0;AttachDBFilename=|DataDirectory|\TollManagment.mdf;Integrated Security=True")
        con.Open()
        Dim sql As String
        sql = "Update transact set DateOUT='" & dateOUT & "',BoothOUT='" & idbooth & "' ,ExtraCharges='" & TextBox10.Text & "' ,ExtraHour='" & TextBox11.Text & "'"
        Dim com As SqlCommand = New SqlCommand(sql, con)
        com.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("TRANSACTION COMPLETE" & vbCrLf & "SLIP NO. : " & slipreturn)
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        GroupBox2.Visible = False
        RadioButton4.Checked = False
    End Sub
End Class