Imports System.Data.SqlClient
Public Class Form1

    Private Shared i As Form1
    Public Shared ReadOnly Property instance() As Form1
        Get
            If i Is Nothing Then
                i = New Form1
            End If
            Return i
        End Get
    End Property

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripStatusLabel2.Text = DateString


    End Sub

    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        Dim f As EmployeeManager_AddNew = EmployeeManager_AddNew.instance()
        With f
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Dim ed As EmployeeManager_Edit = EmployeeManager_Edit.instance()
        With ed
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        Dim vi As Employee_settings = Employee_settings.instance()
        With vi
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim vi As EmployeeManager_View = EmployeeManager_View.instance
        With vi
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub AddNewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem1.Click
        Dim add As Booth_AddNew = Booth_AddNew.instance()
        With add
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        Dim del As Booth_Delete = Booth_Delete.instance()
        With del
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ActivateDeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateDeactivateToolStripMenuItem.Click
        Dim act As Booth_Act = Booth_Act.instance()
        With act
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub SettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingToolStripMenuItem.Click

    End Sub

    Private Sub TileHORIZONTALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileHORIZONTALToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub TileVERTICALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileVERTICALToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileCASCADEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TileCASCADEToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim f As New AboutBox
        f.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub StartTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartTransactionToolStripMenuItem.Click
        Dim st As Transaction_Start = Transaction_Start.instance()
        With st
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ViewTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTransactionToolStripMenuItem.Click
        Dim vi As Transaction_View = Transaction_View.instance()
        With vi
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ViewChargesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewChargesToolStripMenuItem.Click
        Dim vie As VechileCharge_View = VechileCharge_View.instance()
        With vie
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub EditToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem3.Click
        Dim edit As VechileCharge_Edit = VechileCharge_Edit.instance()
        With edit
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub AddNewTimingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewTimingToolStripMenuItem.Click
        Dim timeadd As Timing_New = Timing_New.instance()
        With timeadd
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub EditToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem2.Click
        Dim ed As Timing_Edit = Timing_Edit.instance()
        With ed
            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub ViewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem1.Click
        Dim ve As Timing_view = Timing_view.instance()

        With ve

            .MdiParent = Me
            .Show()
            .Focus()
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = TimeString
    End Sub

    Private Sub EmployeeManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeManageToolStripMenuItem.Click

    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel2.Click

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub
End Class
