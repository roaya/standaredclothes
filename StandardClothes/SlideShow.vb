Public Class SlideShow

    Dim b As New BindingSource
    Dim i As Integer = 0

    Private Sub SlideShow_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub SlideShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        b.DataSource = SlideShowTbl
        PictureBox1.DataBindings.Add("backgroundImage", b, "Photo", True)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        i = i + 1
        If i >= SlideShowTbl.Rows.Count Then
            i = 0
            b.MoveFirst()
        Else
            b.MoveNext()
        End If

    End Sub
End Class