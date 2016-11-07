Public Class Transaction_View
    Private Shared i As Transaction_View
    Public Shared ReadOnly Property instance() As Transaction_View
        Get
            If i Is Nothing Then
                i = New Transaction_View
            End If
            Return i
        End Get
    End Property

    Private Sub Transaction_View_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        i = Nothing
    End Sub
    Private Sub Transaction_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class