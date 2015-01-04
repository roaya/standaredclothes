Public NotInheritable Class SplashScreen1
    Dim i As Integer = 0
    Dim b As Boolean = False
    Dim Direction As Boolean = True

    Private Sub SplashScreen1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If b = True Then
            e.Cancel = False
        Else
            e.Cancel = True

        End If
    End Sub

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Direction = True Then
            If Me.Opacity = 1 Then
                Direction = False

            Else
                Me.Opacity = Me.Opacity + 0.1

            End If

        Else
            If Me.Opacity = 0 Then
                Timer1.Enabled = False
                b = True
                Me.Close()

            Else
                Me.Opacity = Me.Opacity - 0.1
            End If
        End If

    End Sub
End Class
