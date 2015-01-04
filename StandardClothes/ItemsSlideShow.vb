Public Class ItemsSlideShow

    Dim Stmt As String
    Dim b As Boolean = False


    Private Sub ItemsSlideShow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd.CommandText = "select item_name from items where photo is not null"
        dr = cmd.ExecuteReader
        Do While Not dr.Read = False
            SourceList.Items.Add(dr("Item_Name"))
        Loop
        dr.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To SourceList.Items.Count - 1
            DestinationList.Items.Add(SourceList.Items(0))
            SourceList.Items.RemoveAt(0)
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To SourceList.SelectedIndices.Count - 1
            DestinationList.Items.Add(SourceList.Items(SourceList.SelectedIndices(0)))
            SourceList.Items.Remove(SourceList.Items(SourceList.SelectedIndices(0)))
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DestinationList.SelectedItems.Count > 0 Then
            SourceList.Items.Add(DestinationList.SelectedItem)
            DestinationList.Items.RemoveAt(DestinationList.SelectedIndex)
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SourceList.Items.AddRange(DestinationList.Items)
        DestinationList.Items.Clear()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        If DestinationList.Items.Count <= 0 Then
            cls.MsgComplete()
        Else
            Stmt = "select photo from items where item_name in ("

            If DestinationList.Items.Count <= 0 Then
                cls.MsgExclamation("لا يوجد عناصر لعرضها")
            Else
                For i As Integer = 0 To DestinationList.Items.Count - 1
                    DestinationList.SetSelected(i, True)
                    'MsgBox(DestinationList.SelectedItem)
                    If b = False Then
                        Stmt = Stmt & " N'" & DestinationList.SelectedItem & "'"
                        b = True
                    Else
                        Stmt = Stmt & " , N'" & DestinationList.SelectedItem & "'"
                    End If
                Next
                Stmt = Stmt & " )"
                b = False
                'MsgBox(Stmt)
                cmd.CommandText = Stmt
                da.SelectCommand = cmd
                SlideShowTbl.Rows.Clear()
                da.Fill(SlideShowTbl)
                Dim m As New SlideShow
                m.ShowDialog()
            End If

        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub
End Class