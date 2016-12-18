Imports System.IO
Imports System.Security.Cryptography

Public Class LoginForm

    Dim b As Boolean = False

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Login()


    End Sub

    Sub Login()

        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Or ServerNameTextBox.Text = "" Then
            cls.MsgExclamation("«œŒ· »Ì«‰«  «· ”ÃÌ·")
        Else

            Try
                If cn.State = ConnectionState.Closed Then
                    cls.OpenConn("StandardClothes", ServerNameTextBox.Text, "sa", "pass@word1", True)
                End If
            Catch ex As Exception
                cls.MsgCritical("Â‰«ﬂ Œÿ√ ›Ì «·« ’«· »«·”—›— »—Ã«¡ «· √ﬂœ „‰ „⁄·Ê„«  «·« ’«·")
                cls.WriteError(ex.Message, "Main")
                Exit Sub
            End Try



            cmd.CommandText = "select count(*) from app_users where user_name ='" & UsernameTextBox.Text & "' and user_password ='" & PasswordTextBox.Text & "'"
            If cmd.ExecuteScalar > 0 Then
                cmd.CommandText = "select distinct employee_id , employee_name , Account_Status from Emp_Security where user_name ='" & UsernameTextBox.Text & "'"
                dr = cmd.ExecuteReader
                If Not dr.Read = False Then
                    EmpIDVar = dr("employee_id")
                    EmpNameVar = dr("employee_name")
                    UserNameVar = UsernameTextBox.Text
                    If dr("Account_Status") = 0 Then
                        cls.MsgCritical("Â–« «·Õ”«» „€·ﬁ »—Ã«¡ «·« ’«· »„œÌ— «·‰Ÿ«„")
                        End
                    End If
                End If
                If dr.IsClosed = False Then
                    dr.Close()
                End If


                FillDataSet()
                WriteAuth()

                cls.MsgInfo("  „ «· ”ÃÌ· »‰Ã«Õ „—Õ»« " & EmpNameVar)
                b = True
                Me.Close()
            Else
                cls.MsgExclamation("Œÿ√ ›Ì «· ”ÃÌ· √⁄œ «· ”ÃÌ· „—… «Œ—Ì")
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
            End If
        End If

    End Sub

    Public Sub FillDataSet()

        ProgressBar1.Visible = True
        ProgressTxt.Visible = True
        Dim FillTbl() As String = {"Table_Columns", "App_Preferences", "Periods", "Stocks"}
        For i As Integer = 0 To FillTbl.Length - 1
            ProgressBar1.Value = ProgressBar1.Value + 10
            ProgressTxt.Text = "%" & ProgressBar1.Value
            cmd.CommandText = "select * from " & FillTbl(i)
            da.Fill(MyDs.Tables(FillTbl(i)))
        Next

        ProjectSettings.CurrentStockID = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath & "\Stk.Conf.Oslp")
        ProgressBar1.Value = ProgressBar1.Value + 10
        ProgressTxt.Text = "%" & ProgressBar1.Value


        cmd.CommandText = "select Privilege_name as '«”„ «·’·«ÕÌ…', Granted as '„ «Õ… / €Ì— „ «Õ…' from Emp_Security where employee_id = " & EmpIDVar
        da.SelectCommand = cmd
        da.Fill(LogTbl)
        If CheckViewRpt.Checked = True Then
            ShowLogReport = True
        End If

        ProgressBar1.Value = ProgressBar1.Value + 10
        ProgressTxt.Text = "%" & ProgressBar1.Value

        cmd.CommandText = "select stock_name from stocks where stock_id = " & ProjectSettings.CurrentStockID
        ProjectSettings.CurrentStockName = cmd.ExecuteScalar

        ProgressBar1.Value = 100
        ProgressTxt.Text = "%100"

    End Sub



    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If b = True Then
            e.Cancel = False
        Else
            End
            'e.Cancel = True
        End If

    End Sub


    Private Sub UsernameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UsernameTextBox.KeyDown, PasswordTextBox.KeyDown, ServerNameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub


    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
    End Sub


    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReadAuth()
        If UsernameTextBox.Text <> "" Then
            CheckSaveLogin.Checked = True
        End If
    End Sub

#Region "Auth"

    Structure MyStruct
        Dim RID As Integer
        <VBFixedString(35)> Dim UName As String
        <VBFixedString(35)> Dim UPwd As String
        <VBFixedString(35)> Dim Srvr As String
    End Structure


    Public Sub AddRecord()

        Dim k As New MyStruct
        k.RID = 1
        k.UName = UsernameTextBox.Text
        k.UPwd = PasswordTextBox.Text
        k.Srvr = ServerNameTextBox.Text
        FileOpen(1, My.Application.Info.DirectoryPath & "\LgU.Oslp", OpenMode.Random, OpenAccess.Write, OpenShare.Default)

        FilePut(1, k, 1)
        FileClose(1)

    End Sub

    Sub WriteAuth()
        If CheckSaveLogin.Checked = True Then
            Dim fs As New IO.FileStream(My.Application.Info.DirectoryPath & "\LgU.Oslp", IO.FileMode.Create)
            fs.Close()
            AddRecord()
        Else
            If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\LgU.Oslp") Then
                My.Computer.FileSystem.DeleteFile(My.Application.Info.DirectoryPath & "\LgU.Oslp")
            End If
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Server.Srvr") Then
            My.Computer.FileSystem.WriteAllText("Server.Srvr", ServerNameTextBox.Text, False)
        End If

    End Sub

    Sub ReadAuth()

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\LgU.Oslp") = True Then

            Dim j As New MyStruct
            Dim i As Integer
            FileOpen(1, My.Application.Info.DirectoryPath & "\LgU.Oslp", OpenMode.Random, OpenAccess.Read, OpenShare.Default)
            Do While EOF(1) = False
                FileGet(1, j)
                i = j.RID
                UsernameTextBox.Text = j.UName
                PasswordTextBox.Text = j.UPwd
                ServerNameTextBox.Text = j.Srvr
            Loop
            FileClose(1)
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Server.Srvr") Then
            ServerNameTextBox.Text = My.Computer.FileSystem.ReadAllText("Server.Srvr")
        End If

    End Sub


#End Region

End Class