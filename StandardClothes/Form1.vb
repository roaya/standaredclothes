Imports System.Runtime.InteropServices
Imports System.Management

Public Class Main
    Dim b As New BindingSource
    Dim objMOS As ManagementObjectSearcher
    Dim objMOC As Management.ManagementObjectCollection
    Dim objMO As Management.ManagementObject
    Dim PwdDefault As String
    Dim Rpt As New Report_Stock_Balance
    Dim PnlSze As New Size(239, 673)
    Dim searchWin As New GeneralSearch
    Dim STable As New GeneralDataSet.SearchTableDataTable
    Dim DtlTbl As New DataTable
    Private Property BtnItemsSlideShow As Object
    Dim TblItems As New GeneralDataSet.ItemsDataTable
    Dim TblCusts As New GeneralDataSet.CustomersDataTable


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Dim ReturnedProperty = "", ProcID As String
            'ProcID = "178BFBFF00100F23"

            REM ProcID = "BFEBFBFF000206A7"
            ''''"BFEBFBFF00000F43"

            ' objMOS = New ManagementObjectSearcher("Select ProcessorID From Win32_Processor")
            'objMOC = objMOS.Get

            'For Each objMO In objMOC

            'ReturnedProperty = objMO("ProcessorID")

            'Next

            'If ReturnedProperty <> ProcID Then
            'cls.MsgCritical("Â–Â «·‰”Œ… €Ì— „—Œ’… ··⁄„· ⁄·Ì Â–« «·ÃÂ«“")
            'End
            'End If






            Dim x As New LoginForm

            x.ShowDialog()
            SetPermission()
            If ShowLogReport = True Then
                Dim n As New LogRpt
                n.DataGridView1.DataSource = LogTbl

                n.ShowDialog()
            End If

            TxtStockName.Text = ProjectSettings.CurrentStockName
            TxtUserName.Text = UserNameVar


            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Alert") = True Then
                Dim m As New Alerts

                m.ShowDialog()
            End If

            '-------------------------Set Trial Version---------------------
            'If IsTrial = True Then
            '    cmd.CommandText = "select count(*) from Items_Stocks_T_D"
            '    If cmd.ExecuteScalar <= 0 Then
            '        cls.MsgCritical(" „ «‰ Â«¡ «·› —… «· Ã—Ì»Ì… «·Œ«’… »«·»—‰«„Ã")
            '        End
            '    Else
            '        cmd.CommandText = "update Items_Stocks_T_D set stock_id=stock_id + 1 where item_id = 990"
            '        cmd.ExecuteNonQuery()
            '        cmd.CommandText = "select stock_id from Items_Stocks_T_D where item_id = 990"
            '        If cmd.ExecuteScalar >= 1010 Then
            '            cmd.CommandText = "delete from Items_Stocks_T_D"
            '            cmd.ExecuteNonQuery()
            '            cls.MsgCritical(" „ «‰ Â«¡ «·› —… «· Ã—Ì»Ì… «·Œ«’… »«·»—‰«„Ã")
            '            End
            '        End If
            '    End If
            'End If
            '---------------------------------------------------------------

            Dim b As New BindingSource
            cmd.CommandText = "select Gen_Back_Photo from App_Preferences where serial_pk=1"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("MainBkG"))
            b.DataSource = MyDs
            b.DataMember = "MainBkG"
            'PictureBox1.DataBindings.Add("backgroundImage", b, "Gen_Back_Photo", True)

            'MenuPurchaseOrderDesigner.Visible = False

            SetDefaultValues()

            '«·„Œ«“‰ToolStripMenuItem1.Visible = False

            'MenuExpensesElectricity.Visible = False
            'MenuExpensesWater.Visible = False
            'MenuExpensesLib.Visible = False


            Me.Opacity = 100

            GrdSearch.DataSource = STable
            GrdSearch.Columns(0).Visible = False
            GrdSearch.Columns(1).HeaderText = "‰Ê⁄ «·»Ì«‰« "
            GrdSearch.Columns(2).HeaderText = "«·»Ì«‰ «· Ê÷ÌÕÌ"
            GrdSearch.Columns(3).HeaderText = "Ê’› «·»Ì«‰« "
            GrdSearchDetails.DataSource = DtlTbl
            Panel10.Visible = False
            Panel6.Visible = False
            Panel7.Visible = False


            Panel9.Visible = False


            Panel13.Visible = False


            Panel15.Visible = False
            Panel17.Visible = False
            Panel5.Visible = False
            MenuManagementPanel.Visible = False
            Panel3.Visible = False
            MenuManagementPanel.Visible = False
            Panel2.Visible = False
            FirstbalancePanel.Visible = False
            Panel4.Visible = False
            MenuMostDepAll.Visible = False
            MenuStatMostCredit.Visible = False

            Panel19.Visible = False
            Panel24.Visible = False



            Panel21.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False

            Panel15.Visible = False


            cmd.CommandText = "select shift_detail_id from shifts_details where End_Money is NULL and employee_id=" & EmpIDVar
            Try
                CurrentShiftID = cmd.ExecuteScalar
            Catch
                CurrentShiftID = 0
            End Try

            Try
                cmd.CommandText = "select auto_shift from app_preferences"
                If CurrentShiftID = 0 And cmd.ExecuteScalar = True Then
                    cmd.CommandText = "insert into shifts_Details(shift_ID,Start_Money,Start_Date,Real_start_Time,Employee_ID) values(1,0,getdate(),getdate()," & EmpIDVar & ")"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "select max(shift_detail_id) from shifts_details"
                    CurrentShiftID = cmd.ExecuteScalar
                End If
            Catch
            End Try




            Try
                cmd.CommandText = "select category from app_preferences"
                cls.RefreshData("select * from Items where category_id=" & cmd.ExecuteScalar, TblItems)
                cls.RefreshData("select * from Customers", TblCusts)

                Item.DataSource = TblItems
                Item.DisplayMember = "item_Name"
                Item.ValueMember = "item_id"

                Cust.DataSource = TblCusts
                Cust.DisplayMember = "Customer_Name"
                Cust.ValueMember = "Customer_Id"
            Catch
            End Try


            AddShortcuts()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Sub SetDefaultValues()
        cmd.CommandText = "select count(*) from discount_cards where card_id = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT [dbo].[discount_cards] ON; insert into discount_cards(card_id,card_code,card_status,expired_date,card_value) values(0,'0',N'„‰ ÂÌ',getdate(),0); SET IDENTITY_INSERT [dbo].[discount_cards] Off;"
            cmd.ExecuteNonQuery()
        End If
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Ages where Age_id = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Ages ON;INSERT INTO Ages(Age_ID,Age_Desc) VALUES(0,N'⁄«„');SET IDENTITY_INSERT dbo.Ages OFF;"
            cmd.ExecuteNonQuery()
        End If
        cmd.CommandText = "update ages set from_age=0 , to_age=0"
        cmd.ExecuteNonQuery()
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Corporations where Corporation_id = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Corporations ON;INSERT INTO dbo.Corporations(Corporation_ID,Corporation_Name) VALUES(0,N'⁄«„');SET IDENTITY_INSERT dbo.Corporations OFF;"
            cmd.ExecuteNonQuery()
        End If
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Gender where Gender_id = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Gender ON;INSERT INTO dbo.Gender(Gender_ID,Gender_Name) VALUES(0,N'⁄«„');SET IDENTITY_INSERT dbo.Gender OFF;"
            cmd.ExecuteNonQuery()
        End If
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Items_Types where Type_ID = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Items_Types ON;INSERT INTO Items_Types(Type_ID,Type_Name) VALUES(0,N'⁄«„');SET IDENTITY_INSERT dbo.Items_Types OFF;"
            cmd.ExecuteNonQuery()
        End If
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Item_Sizes where Size_ID = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Item_Sizes ON;INSERT INTO Item_Sizes(Size_ID,Size_Name) VALUES(0,N'⁄«„');SET IDENTITY_INSERT dbo.Item_Sizes OFF;"
            cmd.ExecuteNonQuery()
        End If
        '--------------------------------------------------------------
        cmd.CommandText = "select count(*) from Categories where Category_ID = 0"
        If cmd.ExecuteScalar <= 0 Then
            cmd.CommandText = "SET IDENTITY_INSERT dbo.Categories ON;INSERT INTO dbo.Categories(Category_ID,Category_Name,Generic_Desc,Category_Discount) VALUES(0,N'⁄«„',NULL,0);SET IDENTITY_INSERT dbo.Ages OFF;"
            cmd.ExecuteNonQuery()
        End If
    End Sub



    Sub SetPermission()
        Try
            For i As Integer = 0 To LogTbl.Rows.Count - 1

                If LogTbl.Rows(i).Item(0) = "‰«›–…«·»ÕÀ" Then
                    Panel11.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «· ﬁ”Ì„«  «·«œ«—ÌÂ" Then
                    MenuManagement.Visible = LogTbl.Rows(i).Item(1)

                    MenuManagementPanel.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„ÊŸ›Ì‰" Then
                    MenuEmployees.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·Õ÷Ê— Ê «·«‰’—«›" Then
                    MenuAttendance.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·√Ã«“« " Then
                    MenuVacations.Visible = LogTbl.Rows(i).Item(1)

                    '''''' ' '''''''''''''''''''stocks''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„Õ·« " Then
                    MenuStocks.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·√’‰«›" Then
                    MenuItems.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «œŒ«· √—’œ… «Ê· „œÂ" Then
                    MenuBalance.Visible = LogTbl.Rows(i).Item(1)
                    Panel2.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·‘—ﬂ« " Then
                    MenuCompanies.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·»‰Êœ" Then
                    MenuCategories.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·‰Ê⁄" Then
                    MenuGender.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·›∆…" Then
                    MenuItemTypes.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„ﬁ«”« " Then
                    Button5.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «· ’‰Ì›«  «·⁄„—Ì…" Then
                    MenuAges.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·«Â·«ﬂ" Then
                    MenuItemsOut.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ «· ÕÊÌ·" Then
                    MenuAdjustments.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… —»ÿ «·√’‰«› »«·„Õ·« " Then
                    MenuItemsStocks.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·Ã—œ" Then
                    «·Ã—œToolStripMenuItem.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… ⁄—÷ «·√’‰«›" Then
                    MenuSlideShow.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„Â„« " Then
                    MenuEmpTasks.Visible = LogTbl.Rows(i).Item(1)


                    ''''''''''''''''''''''''''''''''''''customers'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–…«·⁄„·«¡" Then
                    Panel4.Visible = LogTbl.Rows(i).Item(1)
                    »Ì«‰« ·⁄„·«¡ToolStripMenuItem.Visible = LogTbl.Rows(i).Item(1)
                    Panel3.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ «— Ã«⁄ ⁄„Ì·" Then
                    MenuCustomerReturns.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ ÕÃ“ √’‰«›" Then
                    MenuCustomerRequest.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ œ›⁄ ⁄„Ì·" Then
                    MenuCustomerPayments.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… ﬂÊ»Ê‰«  «·Œ’„" Then
                    MenuDiscountCard.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… ⁄—÷ «·√”⁄«—" Then
                    MenuSalesOffer.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "›« Ê—… «·„»Ì⁄« " Then
                    MenuSalesOrder.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''vendors''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„Ê—œÌ‰" Then
                    MenuVendors.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ œ›⁄ „Ê—œ" Then
                    MenuVendorPayments.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «–‰ «— Ã«⁄ „Ê—œ" Then
                    MenuVendorReturns.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… —»ÿ «·„Ê—œ »«·’‰›" Then
                    MenuItemsVendors.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "›« Ê—… «·„‘ —Ì« " Then
                    MenuPurchaseOrder.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… —’Ìœ «Ê· „œÂ ··⁄„·«¡" Then
                    FirstCustomersBalance.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… —’Ìœ «Ê· „œÂ ··„Ê—œÌ‰" Then
                    BtnFirstVendorsBalance.Visible = LogTbl.Rows(i).Item(1)
                    '''''''''''''''''''''''''''''' ' accounting'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·„’—Ê›« " Then
                    «·„’—Ê›« ToolStripMenuItem.Visible = LogTbl.Rows(i).Item(1)
                    Panel6.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·«Ì—«œ« " Then
                    Button1.Visible = LogTbl.Rows(i).Item(1)
                    Panel9.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… Õ”«»«  ‘∆Ê‰ «·⁄«„·Ì‰" Then
                    «·«Ì—«œ« ToolStripMenuItem.Visible = LogTbl.Rows(i).Item(1)
                    Panel7.Visible = LogTbl.Rows(i).Item(1)
                    Panel8.Visible = LogTbl.Rows(i).Item(1)
                    Panel5.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ Õ÷Ê— «·„ÊŸ›Ì‰" Then
                    MenuQueryAttendAbsent.Visible = LogTbl.Rows(i).Item(1)
                    MenuQueryAttendAbsent.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''queries'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·„ÊŸ› »«·„”„Ì «·ÊŸÌ›Ì" Then
                    QueryEmpByJobID.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ »Ì«‰«  «·„ﬂ«›« " Then
                    MenuQueryEmployeesRewards.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ »Ì«‰«  «·Œ’Ê„« " Then
                    MenuQueryEmployeesDiscounts.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ »Ì«‰«  ⁄«„… ⁄‰ «·„ÊŸ›" Then
                    MenuQueryEmpGeneral.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ »Ì«‰«  «·√’‰«›" Then
                    MenuMainQueryItems.Visible = LogTbl.Rows(i).Item(1)


                    'ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ —’Ìœ «·’‰› »«·„Õ·" Then
                    '    QueryItemsByStock.Visible = LogTbl.Rows(i).Item(1)




                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·«Â·«ﬂ" Then
                    MenuMainQueryDep.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·Ã—œ" Then
                    «·„Œ«“‰ToolStripMenuItem1.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·—’Ìœ «·¬Ã· ··⁄„Ì·" Then
                    MenuQueryCusCredit.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ ﬂÊ»Ê‰«  «·Œ’„" Then
                    MenuMostCustDisCards.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ ﬂ„Ì…  ⁄«„·«  «·⁄„Ì·" Then
                    MenuMostCustOrders.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·—’Ìœ «·¬Ã· ··„Ê—œ" Then
                    MenuQueryVenCredit.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ ﬂ„Ì…  ⁄«„·«  «·„Ê—œ" Then
                    MenuMostVenOrders.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ «·√’‰«› «·„— »ÿ… »«·„Ê—œ" Then
                    ToolStripMenuItem41.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«” ⁄·«„ »Ì«‰«  «·„’—Ê›« " Then
                    MainMenuExpenses.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''statistics''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— ‘—«¡" Then
                    MenuMostPurchase.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— „»Ì⁄« + ”⁄— «·ﬁÿ«⁄Ì" Then
                    MenuMostSalesOne.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— „»Ì⁄« + ”⁄— «·Ã„·…" Then
                    MenuMostSalesAll.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— „»Ì⁄« »«·ÌÊ„ + ”⁄— «·ﬁÿ«⁄Ì" Then

                    MenuMostSalesOneByDay.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— „»Ì⁄« »«·ÌÊ„ + ”⁄— «·Ã„·…" Then
                    MenuMostSalesAllByDay.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·’‰› «·√ﬂÀ— «Â·«ﬂ«" Then
                    «·’‰›«·√ﬂÀ—«Â·«ﬂ«ToolStripMenuItem.Visible = LogTbl.Rows(i).Item(1)
                    MenuMostDepAll.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «Ã„«·Ì «·„»Ì⁄«  »«·„ÊŸ›" Then
                    MenuMostSalesEmpAll.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «Ã„«·Ì «·„»Ì⁄«  »«·„ÊŸ› + »«·› —…" Then
                    MenuMostSalesEmpPeriod.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = "«Õ’«∆Ì… «·⁄„·«¡ »—’Ìœ «·¬Ã·" Then
                    «·⁄„·«¡ToolStripMenuItem2.Visible = LogTbl.Rows(i).Item(1)
                    MenuStatMostCredit.Visible = LogTbl.Rows(i).Item(1)


                    ''''''''''''''''''''''''''''''''''''''''''''reports'''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ›Ê« Ì— «·„‘ —Ì« " Then
                    MeMainPurchaseOrder.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ›Ê« Ì— «·„»Ì⁄« " Then
                    MenuMainSalesOrder.Visible = LogTbl.Rows(i).Item(1)
                    btnitemsdiscounts.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— „— Ã⁄ «·⁄„·«¡" Then
                    MenuMainCustReturns.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— „— Ã⁄ «·„Ê—œÌ‰" Then
                    MenuMainVendorsReturns.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ÿ·»«  «·⁄„·«¡" Then
                    MenuMainCustRequest.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— «–‰ «· ÕÊÌ·" Then
                    MenuMainAdjustments.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ÿ»«⁄… «·»«—ﬂÊœ" Then
                    MenuPrintbarcode.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì—  ﬁÌÌ„ «·„Œ“‰" Then
                    MenuReportStockValue.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì—  ﬁÌÌ„ «·„Œ“‰ »«·‰œ" Then
                    Button8.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— «Ã„«·Ï Õ—ﬂÂ «·»Ì⁄ Ê«·‘—«¡" Then
                    Button9.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— Õ—ﬂÂ «·„Œ“‰" Then
                    MenuInvLog.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ÿ»«⁄… ﬂ—Ê  «·„ÊŸ›Ì‰" Then
                    BtnReportEmpCards1.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ÿ»«⁄… Œ·›ÌÂ ﬂ—Ê  «·„ÊŸ›Ì‰" Then
                    BtnReportEmpCards2.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— «·„’—Ê›« " Then
                    Button6.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— „œ›Ê⁄«  «·⁄„·«¡" Then
                    Button7.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— „œ›Ê⁄«  «·„Ê—œÌ‰" Then
                    Button10.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— Œ’Ê„«  «·«’‰«›" Then
                    btnitemsdiscounts.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— ⁄—÷ «·«’‰«›" Then
                    BtnShowItem.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— «·œŒ· «·ÌÊ„Ï" Then
                    BtnDailyIncom.Visible = LogTbl.Rows(i).Item(1)
                ElseIf LogTbl.Rows(i).Item(0) = " ﬁ—Ì— «·«’‰«› «· Ï ﬁ«—»  ⁄·Ï «·«‰ Â«¡" Then
                    BtnItemsExpired.Visible = LogTbl.Rows(i).Item(1)


                    ''''''''''''''''''''''''''''''''''''''''''''''settings'''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·Ê—œÌ« " Then
                    MenuPeriods.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «⁄œ«œ«  «·»—‰«„Ã" Then
                    MenuUserPreferences.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «⁄«œÂ «·‰Ÿ«„ ··Ê÷⁄ «·«› —«÷Ï" Then
                    MenuSetDefault.Visible = LogTbl.Rows(i).Item(1)

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «Ê«„— «·‰Ÿ«„" Then
                    SystemCommands.Visible = LogTbl.Rows(i).Item(1)


                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·«Ã«“«  «·—”„ÌÂ" Then
                    BtnOfficialVacations.Visible = LogTbl.Rows(i).Item(1)



                ElseIf LogTbl.Rows(i).Item(0) = " ›«’Ì· «·Ê—œÌ« " Then
                    MenuShiftsDetails.Visible = LogTbl.Rows(i).Item(1)




                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… «·«Œ ’«—« " Then
                    BtnEmpsShortcuts.Visible = LogTbl.Rows(i).Item(1)

                    ''''''''''''''''''''''''''''''''''''''''''''''security''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… „Ã„Ê⁄«  «·√„«‰" Then
                    MenuSecurityGroupHeader.Visible = LogTbl.Rows(i).Item(1)
                    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… ’·«ÕÌ«  „Ã„Ê⁄«  «·√„«‰" Then
                    MenuSecurityGroupDetails.Visible = LogTbl.Rows(i).Item(1)
                    '    BtnSecurityGroupDetails.Visible = LogTbl.Rows(i).Item(1)

                    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ElseIf LogTbl.Rows(i).Item(0) = "‰«›–… »Ì«‰«  «·„” Œœ„Ì‰" Then
                    MenuUsers.Visible = LogTbl.Rows(i).Item(1)
                    '    BtnUsers.Visible = LogTbl.Rows(i).Item(1)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            Next
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub ReportPurchaseByEmpID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportPurchaseByItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioItemName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportPurchaseByVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioVendorID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportPurchaseByTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioTotalBill.Checked = True
        m.Show()
    End Sub

    Private Sub ReportPurchaseByStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioStockID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportPurchaseByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportPurchaseOrder
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    '---------------------------------------------------------------------

    Private Sub ReportSalesByEmpID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportsalesByItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioItemName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportSalesByCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioCustomerID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportSalesByTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioTotalBill.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportSalesByStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioStockID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub ReportSalesByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportSalesOrder
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    '----------------------------------------------------------------

    Private Sub MenuReportCustReqByEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustReqByItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioItemName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustReqByCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioCustomerID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustReqByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustReqByStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioStockID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustReqByExpired_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCustomerRequest
        m.RadioExpired.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    '------------------------------------------------------------------------

    Private Sub MenuReportCustRetByEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustRetByItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioItemName.Checked = True
        m.Show()
    End Sub

    Private Sub MenuReportCustRetByCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioCustomerID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustRetByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustRetByStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioStockID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportCustRetByTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportCusReturns
        m.RadioTotalBill.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    '---------------------------------------------------------------------------------------------

    Private Sub MenuReportVenRetByEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportVenRetByItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioItemName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportVenRetByVen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioVendorID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportVenRetByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportVenRetByStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioStockID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportVenRetByTotal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ReportVenReturns
        m.RadioTotalBill.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub



    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    TxtDateNow.Text = Now.ToString("MM/dd/yyyy")
    '    TxtTimeNow.Text = Now.ToLongTimeString
    'End Sub

    Private Sub MenuSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            PwdDefault = InputBox("√œŒ· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„", ProjectTitle)
            If PwdDefault = "osloup123" Then
                cls.MsgInfo("»—Ã«¡ «·«‰ Ÿ«— Õ Ì Ì „ «·«‰ Â«¡")
                Me.Cursor = Cursors.WaitCursor
                cmd.CommandText = "DELETE FROM Adjustment_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Sales_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Discount_Level"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Levels"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Attendance"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Sales_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Adjustment_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Cards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Discounts"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Added_Hours"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Rewards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Tasks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Vacations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Pay_Salary"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Ages"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Gender"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Item_Sizes"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Types"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Corporations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Rewards_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Security_Group_Details SET Granted =1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Seq_Table SET Curr_Val = 1"
                cmd.ExecuteNonQuery()
                Me.Cursor = Cursors.Default
                cls.MsgInfo(" „ «⁄«œ… «·‰Ÿ«„ ··Ê÷⁄ «·«› —«÷Ì »—Ã«¡ «⁄«œ… «· ‘€Ì·")
                End
            Else
                cls.MsgCritical("Œÿ√ ›Ì «œŒ«· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„")
            End If
        Catch ex As Exception
            cls.MsgCritical("Œÿ√ ›Ì «œŒ«· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„")
        End Try
    End Sub

    Private Sub MenuReportStockValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim s As String
            s = InputBox("√œŒ· ﬂ·„… «·”—", ProjectTitle)
            If s = "" Or s <> "251" Or s Is Nothing Then
                cls.MsgExclamation("ﬂ·„… ”— Œ«ÿ∆Â")
            Else
                MyDs.Tables("Vu_Stock_Value").Rows.Clear()
                cmd.CommandText = "SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL," & _
        " I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL FROM Items I , Items_Stocks SI ," & _
        " Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID AND S.Stock_ID=" & ProjectSettings.CurrentStockID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Vu_Stock_Value"))
                Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = Rpt
                m.MdiParent() = Me
                m.Show()
            End If
        Catch ex As Exception
            cls.WriteError("Œÿ√ ›Ì  ‘€Ì· «· ﬁ—Ì—", "Stock Balance")
        End Try
    End Sub

    Private Sub SystemCommands_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New FrmWindows
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub MenuManagement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuManagement.Click
        MenuManagementPanel.Visible = True

    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MenuManagementPanel.Visible = False

    End Sub

    Private Sub MenuEmployees_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmployees.Click
        MenuManagementPanel.Visible = False

    End Sub

    Private Sub MenuAttendance_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAttendance.Click
        MenuManagementPanel.Visible = False

    End Sub

    Private Sub MenuVacations_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVacations.Click
        MenuManagementPanel.Visible = False

    End Sub

    Private Sub MenuEmpTasks_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpTasks.Click
        MenuManagementPanel.Visible = False

    End Sub

    Private Sub MenuBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBalance.Click
        Panel2.Visible = False
        If FirstbalancePanel.Visible = False Then
            FirstbalancePanel.Visible = True
            FirstbalancePanel.Height = 52
        End If


    End Sub

    Private Sub «œŒ«·«·«—’œ…»«·’‰›ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «œŒ«·«·«—’œ…»«·’‰›ToolStripMenuItem.Click

        FirstbalancePanel.Height = 52 * 2
        firstbalancebyitem.Visible = True
    End Sub

    Private Sub «·Ã—œToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·Ã—œToolStripMenuItem.Click
        Panel2.Visible = True
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuStocks_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStocks.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuItems_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItems.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuCategories_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCategories.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuCompanies_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCompanies.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuItemTypes_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemTypes.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuGender_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuGender.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New ItemSizes
        m.MdiParent() = Me
        m.Show()
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuAges_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAges.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuItemsOut_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemsOut.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuAdjustments_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAdjustments.Click
        Dim m As New Adjustments
        m.MdiParent() = Me
        m.Show()
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuItemsStocks_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemsStocks.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub

    Private Sub MenuSlideShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSlideShow.Click
        Panel2.Visible = False
        FirstbalancePanel.Visible = False
        firstbalancebyitem.Visible = False
    End Sub


    Private Sub »Ì«‰« ·⁄„·«¡ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles »Ì«‰« ·⁄„·«¡ToolStripMenuItem.Click

        If Panel4.Visible = False Then
            Panel4.Visible = True
            Panel4.Height = 52
        End If
    End Sub

    Private Sub ›∆« «·⁄„·«¡ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ›∆« «·⁄„·«¡ToolStripMenuItem.Click
        Panel4.Height = 104
        Panel3.Visible = True
    End Sub

    Private Sub MenuCustomerReturns_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerReturns.Click
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub MenuCustomerRequest_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerRequest.Click
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub MenuCustomerPayments_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerPayments.Click
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub MenuDiscountCard_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDiscountCard.Click
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    Private Sub MenuSalesOffer_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalesOffer.Click
        Panel3.Visible = False
        Panel4.Visible = False
    End Sub

    'Private Sub √—‘Ì›«·›Ê« Ì—ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Panel5.Visible = False Then
    '        Panel6.Visible = False
    '        Panel5.Visible = True
    '        Panel5.Height = 56
    '    End If
    'End Sub

    'Private Sub Õ–›«·«—‘Ì›«·”«»ﬁToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel5.Height = 140
    '    Panel6.Visible = True
    'End Sub

    'Private Sub MenuPurchaseOrderDesigner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel5.Visible = False
    '    Panel6.Visible = False
    'End Sub

    'Private Sub MenuPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPurchaseOrder.Click
    '    Panel6.Visible = False
    '    Panel5.Visible = False
    'End Sub

    'Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Panel8.Visible = False Then
    '        Panel8.Visible = False
    '        Panel7.Visible = True
    '        Panel7.Height = 56
    '    End If
    'End Sub

    'Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel7.Height = 140
    '    Panel8.Visible = True
    'End Sub

    'Private Sub MenuSalesOrder_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Panel7.Visible = False
    '    Panel8.Visible = False
    'End Sub

    Private Sub «·’‰›«·√ﬂÀ—„»Ì⁄«ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·’‰›«·√ﬂÀ—„»Ì⁄«ToolStripMenuItem.Click
        Panel13.Visible = True
        Panel15.Visible = False
        Panel17.Visible = False
        MenuMostDepAll.Visible = False
        MenuStatMostCredit.Visible = False
    End Sub

    Private Sub «·√ﬂÀ—„»Ì⁄«»«·ÌÊ„ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·√ﬂÀ—„»Ì⁄«»«·ÌÊ„ToolStripMenuItem.Click
        Panel15.Visible = True
        Panel13.Visible = False
        Panel17.Visible = False
        MenuMostDepAll.Visible = False
        MenuStatMostCredit.Visible = False
    End Sub

    Private Sub «Ã„«·Ì«·„»Ì⁄ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «Ã„«·Ì«·„»Ì⁄ToolStripMenuItem.Click
        Panel17.Visible = True
        Panel15.Visible = False
        Panel13.Visible = False
        MenuMostDepAll.Visible = False
        MenuStatMostCredit.Visible = False
    End Sub

    Private Sub «·’‰›«·√ﬂÀ—«Â·«ﬂ«ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·’‰›«·√ﬂÀ—«Â·«ﬂ«ToolStripMenuItem.Click
        MenuMostDepAll.Visible = True
        Panel15.Visible = False
        Panel13.Visible = False
        Panel17.Visible = False
        MenuStatMostCredit.Visible = False
    End Sub

    Private Sub «·⁄„·«¡ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·⁄„·«¡ToolStripMenuItem2.Click
        MenuStatMostCredit.Visible = True
        Panel15.Visible = False
        Panel13.Visible = False
        Panel17.Visible = False
        MenuMostDepAll.Visible = False
    End Sub

    Private Sub MenuMostPurchase_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostPurchase.Click
        MenuStatMostCredit.Visible = False
        Panel15.Visible = False
        Panel13.Visible = False
        Panel17.Visible = False
        MenuMostDepAll.Visible = False
    End Sub


    '====================================================================
    Private Sub ‘∆Ê‰«·⁄«„·Ì‰ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ‘∆Ê‰«·⁄«„·Ì‰ToolStripMenuItem.Click
        Panel19.Visible = True
        Panel24.Visible = False



        Panel21.Visible = False
        Panel22.Visible = False

        Panel23.Visible = False

        Panel19.Height = 135

    End Sub

    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·„Œ«“‰ToolStripMenuItem1.Click, «·„Œ«“‰ToolStripMenuItem1.Click
        If Panel24.Visible = False Then
            ' «·„Œ«“‰ToolStripMenuItem1
            Panel24.Visible = True
            Panel19.Visible = False



            Panel21.Visible = False
            Panel22.Visible = False

            Panel23.Visible = False

            Panel24.Height = 26 * 4
        End If
    End Sub

    Private Sub MenuMainQueryItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainQueryItems.Click

        Panel19.Visible = False


        Panel21.Visible = False
        Panel22.Visible = False

        Panel23.Visible = False


        Dim m As New QueryAllItem2
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub «·«’‰«›Ê«·„Õ·« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·«’‰«›Ê«·„Õ·« ToolStripMenuItem.Click


        Panel19.Visible = False



        Panel21.Visible = False
        Panel22.Visible = False

        Panel23.Visible = False



        Dim m As New QueryItemsStocks
        m.MdiParent() = Me
        m.Show()

    End Sub

    Private Sub —’Ìœ’‰›„Õœœ»«·„Õ·« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Panel19.Visible = False

        Panel21.Visible = False
        Panel22.Visible = False

        Panel23.Visible = False


    End Sub

    Private Sub MenuMainQueryDep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainQueryDep.Click
        Panel21.Visible = False
        Panel19.Visible = False



        Panel22.Visible = False
        Panel23.Visible = False

        Dim m As New QueryItemsDep
        m.RadioStockName.Checked = True
        m.MdiParent() = Me
        m.Show()

    End Sub



    Private Sub «·⁄„·«¡ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·⁄„·«¡ToolStripMenuItem1.Click
        Panel22.Visible = True
        Panel24.Visible = False
        Panel19.Visible = False



        Panel21.Visible = False

        Panel23.Visible = False

        Panel22.Height = 26 * 3
    End Sub

    Private Sub MainMenuExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuExpenses.Click

        Panel22.Visible = False
        Panel24.Visible = False
        Panel19.Visible = False



        Panel21.Visible = False

        Panel23.Visible = False

        Dim m As New QueryExpensesByPeriod
        m.MdiParent = Me
        m.Show()



    End Sub

    Private Sub Button46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        If Panel23.Visible = False Then
            Panel23.Visible = True
            Panel24.Visible = False
            Panel19.Visible = False



            Panel21.Visible = False
            Panel22.Visible = False


            Panel23.Height = 26 * 3
        End If
    End Sub

    Private Sub ToolStripMenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem41.Click
        Dim m As New QueryItemsVendors
        m.RadioVendorName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMainQueryCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainQueryCheck.Click
        Panel21.Visible = True
        Panel19.Visible = False



        Panel22.Visible = False



        Panel24.Height = 26 * 10
        Panel21.Height = 26 * 6
    End Sub

    Private Sub MenuDepartments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDepartments.Click
        Dim m As New Departments
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuJobs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuJobs.Click
        Dim m As New Jobs
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuEmployees_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmployees.Click
        Dim m As New Employees
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAttendance.Click
        Dim m As New Attendance()
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuVacations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVacations.Click
        Dim m As New EmployeesVacations
        m.MdiParent() = Me
        m.Show()
    End Sub


    Private Sub MenuAddHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmpAddedHours
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub MenuEmpTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpTasks.Click
        Dim m As New EmployeesTasks
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuStocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStocks.Click
        Dim m As New Stocks
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuEmpRewards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmployeesRewards
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuRewardsCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New RewardsCategories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuDiscountCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New DiscountCategories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuEmpDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmployeesDiscounts
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItems.Click
        Dim m As New Items
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCategories.Click
        Dim m As New Categories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCompanies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCompanies.Click
        Dim m As New Corporations
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuItemTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemTypes.Click
        Dim m As New ItemTypes
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuGender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuGender.Click
        Dim m As New Gender
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub MenuAges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuAges.Click
        Dim m As New Ages
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub MenuUserPreferences_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUserPreferences.Click
        Dim m As New FrmUserPreferences
        m.MdiParent() = Me
        m.Show()
    End Sub

    'Private Sub MenuSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalesOrder.Click


    '    If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Style") = "⁄«œÌ…" Then
    '        Dim m As New SalesOrderNormal
    '        m.MdiParent = Me
    '        m.Show()
    '    ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Style") = "„ﬁ”„…" Then
    '        Dim n As New SalesOrderButtons
    '        n.MdiParent = Me
    '        n.Show()
    '    ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Style") = "›· —" Then
    '        Dim x As New SalesOrderFilter
    '        x.MdiParent = Me
    '        x.Show()
    '    End If
    'End Sub

    Private Sub MenuPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPurchaseOrder.Click
        If MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = " ›’Ì·ÌÂ" Then
            Dim m As New PurchaseOrderNormal
            m.MdiParent() = Me
            m.Show()

        ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = "„›« ÌÕ" Then
            Dim m As New PurchaseOrderButtons
            m.MdiParent() = Me
            m.Show()

        End If
        'ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = "„ﬁ”„…" Then
        '    Dim n As New PurchaseOrderButtons
        '    n.MdiParent() = Me
        '    n.Show()
        'ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = "›· —" Then
        '    Dim x As New PurchaseOrderFilter
        '    x.MdiParent() = Me
        '    x.Show()
        'End If
    End Sub

    Private Sub MenuFirstBalanceStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFirstBalanceStock.Click
        Dim m As New FirstBalanceStock
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuFirstBalanceItemName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFirstBalanceItemName.Click
        Dim m As New FirstBalanceItemName
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuFirstBalanceBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFirstBalanceBarcode.Click
        Dim m As New FirstBalanceItemBarcode
        m.MdiParent = Me
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuItemsOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemsOut.Click
        Dim m As New ItemsDep
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCheckHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCheckHeader.Click
        Dim m As New CheckHeader
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCheckDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCheckDetails.Click
        Dim m As New CheckDetails
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMaxCustCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMaxCustCredit.Click
        Dim m As New CustomerLevels
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMaxCustDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMaxCustDiscount.Click
        Dim m As New CustomerDiscountLevel
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCustomerRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerRequest.Click
        Dim m As New CustomerRequest
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCustomerPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerPayments.Click
        Dim m As New CustomersPayments
        m.MdiParent() = Me
        m.Show()
    End Sub


    Private Sub MenuSalesOffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalesOffer.Click
        Dim m As New SalesOffer
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuDiscountCard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDiscountCard.Click
        Dim m As New Discount_Cards
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuCustomerReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomerReturns.Click
        Dim m As New ReturnsCustomers
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuVendors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVendors.Click
        Dim m As New Vendors
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuVendorReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVendorReturns.Click
        Dim m As New ReturnsVendors
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuVendorPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVendorPayments.Click
        Dim m As New VendorsPayments
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuItemsVendors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemsVendors.Click
        Dim m As New ItemsVendors
        m.MdiParent() = Me
        m.Show()
    End Sub




    Private Sub EmpDiscountCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New DiscountCategories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub EmpDiscountDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New EmployeesDiscounts
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMostPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostPurchase.Click
        Try
            MyDs.Tables("Most_Purchase").Clear()
            cmd.CommandText = "select * from most_purchase"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Purchase"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostPurchase
            rpt.SetDataSource(MyDs.Tables("Most_Purchase"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesOne.Click
        Try
            MyDs.Tables("Most_Sales_One").Clear()
            cmd.CommandText = "select * from Most_Sales_One"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_One"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesOne
            rpt.SetDataSource(MyDs.Tables("Most_Sales_One"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesAll.Click
        Try
            MyDs.Tables("Most_Sales_All").Clear()
            cmd.CommandText = "select * from Most_Sales_All"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesAll
            rpt.SetDataSource(MyDs.Tables("Most_Sales_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesOneByDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesOneByDay.Click
        Try
            MyDs.Tables("Most_Sales_All").Clear()
            cmd.CommandText = "select * from Most_Sales_One_Day"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesAll
            rpt.SetDataSource(MyDs.Tables("Most_Sales_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesAllByDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesAllByDay.Click
        Try
            MyDs.Tables("Most_Sales_All").Clear()
            cmd.CommandText = "select * from Most_Sales_All_Day"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesAll
            rpt.SetDataSource(MyDs.Tables("Most_Sales_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesEmpAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesEmpAll.Click
        Try
            MyDs.Tables("Most_Sales_Emp_All").Clear()
            cmd.CommandText = "select * from Most_Sales_Emp_All"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Sales_Emp_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostSalesEmpAll
            rpt.SetDataSource(MyDs.Tables("Most_Sales_Emp_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostSalesEmpPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostSalesEmpPeriod.Click
        Dim m As New ShowAllReportByPeriod
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMostDepAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostDepAll.Click
        Try
            MyDs.Tables("Most_Dep_All").Clear()
            cmd.CommandText = "select * from Most_Dep_All"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Dep_All"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostDepAll
            rpt.SetDataSource(MyDs.Tables("Most_Dep_All"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

 



    Private Sub MenuQueryAttendAbsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryAttendAbsent.Click
        Dim m As New QueryAttendance
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryEmployeesDiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryEmployeesDiscounts.Click
        Dim m As New QuerEmployeesDiscounts
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryEmployeesRewards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryEmployeesRewards.Click
        Dim m As New QueryEmployeesRewards
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuSlideShowDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSlideShow.Click
        Dim m As New ItemsSlideShow
        m.MdiParent() = Me
        m.Show()
    End Sub

  





    'Private Sub MenuQueryMaxCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim m As New QueryCustomerLevel
    '    m.MdiParent() = Me
    '    m.Show()
    'End Sub

    Private Sub MenuCustomers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCustomers.Click
        Dim m As New Customers
        m.MdiParent() = Me
        m.Show()
    End Sub

   

    Private Sub MenuQueryCusCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryCusCredit.Click
        Try
            MyDs.Tables("Most_Customer_Credit").Rows.Clear()
            cmd.CommandText = "select customer_name , TOTAL_CREDIT from Most_Customer_Credit order by customer_name"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Customer_Credit"))
            Dim m As New ShowAllQueries
            m.DataGridView1.DataSource = MyDs.Tables("Most_Customer_Credit")
            m.DataGridView1.Columns(0).HeaderText = "«”„ «·⁄„Ì·"
            m.DataGridView1.Columns(1).HeaderText = "«Ã„«·Ì «·¬Ã·"
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuStatMostCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuStatMostCredit.Click
        Try
            MyDs.Tables("Most_Customer_Credit").Clear()
            cmd.CommandText = "select * from Most_Customer_Credit"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_Customer_Credit"))
            Dim m As New ShowAllReports
            Dim rpt As New StatMostCusCredit
            rpt.SetDataSource(MyDs.Tables("Most_Customer_Credit"))
            m.CrystalReportViewer1.ReportSource = rpt
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub


    Private Sub MenuMostCustOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostCustOrders.Click
        Try
            Dim t As New DataTable
            t.Rows.Clear()
            cmd.CommandText = "SELECT CUSTOMER_NAME as '«”„ «·⁄„Ì·',Total_Order as '«Ã„«·Ì ﬁÌ„… ›Ê« Ì— «·„»Ì⁄« ',Count_Orders as '⁄œœ «·›Ê« Ì—',Total_Cash as '«Ã„«·Ì «·‰ﬁœÌ',Total_Credit as '«Ã„«·Ì «·¬Ã·',Count_Items as '⁄œœ «·√’‰«› ›Ì ﬂ· «·›Ê« Ì—' FROM Most_Cust_Orders "
            da.SelectCommand = cmd
            da.Fill(t)
            Dim m As New ShowAllQueries
            m.DataGridView1.DataSource = t
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostCustDisCards_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostCustDisCards.Click
        Try
            Dim t As New DataTable
            t.Rows.Clear()
            cmd.CommandText = "SELECT CUSTOMER_NAME as '«”„ «·⁄„Ì·',Total_cards as '«Ã„«·Ì ⁄œœ ﬂÊ»Ê‰«  «·Œ’„' FROM Most_Cust_Cards "
            da.SelectCommand = cmd
            da.Fill(t)
            Dim m As New ShowAllQueries
            m.DataGridView1.DataSource = t
            m.MdiParent() = Me
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub



    Private Sub MenuQueryVenCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryVenCredit.Click
        Try
            MyDs.Tables("Most_vendor_Credit").Rows.Clear()
            cmd.CommandText = "select vendor_name , TOTAL_CREDIT from Most_vendor_Credit order by vendor_name"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Most_vendor_Credit"))
            Dim m As New ShowAllQueries
            m.DataGridView1.DataSource = MyDs.Tables("Most_vendor_Credit")
            m.DataGridView1.Columns(0).HeaderText = "«”„ «·„Ê—œ"
            m.DataGridView1.Columns(1).HeaderText = "«Ã„«·Ì «·¬Ã·"
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub

    Private Sub MenuMostVenOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMostVenOrders.Click
        Try
            Dim t As New DataTable
            t.Rows.Clear()
            cmd.CommandText = "SELECT vendor_NAME as '«”„ «·„Ê—œ',Total_Order as '«Ã„«·Ì ﬁÌ„… ›Ê« Ì— «·„‘ —Ì« ', Count_Orders as '⁄œœ «·›Ê« Ì—',Total_Cash as '«Ã„«·Ì «·‰ﬁœÌ',Total_Credit as '«Ã„«·Ì «·¬Ã·',Count_Items as '⁄œœ «·√’‰«› ›Ì ﬂ· «·›Ê« Ì—' FROM Most_Ven_Orders "
            da.SelectCommand = cmd
            da.Fill(t)
            Dim m As New ShowAllQueries
            m.DataGridView1.DataSource = t
            m.Show()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Main Form")
        End Try
    End Sub




    Private Sub QueryEmpByJobID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryEmpByJobID.Click
        Dim m As New QueryEmpByJobDep
        m.RadioJobID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryExpensesByCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryExpensesByPeriod
        m.RadioExpenseCategory.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub




    '-------------------------------------------------------------------






    Private Sub MenuPrintbarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPrintbarcode.Click
        Dim m As New PrintBarCode
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuSecurityGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSecurityGroupHeader.Click
        Dim m As New SecurityGroupHeader
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuSecurityGroupDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSecurityGroupDetails.Click
        Dim m As New SecurityGroupDetails
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuUsers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUsers.Click
        Dim m As New AppUsers
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryStocksByAge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryAllItem5
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryEmpGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuQueryEmpGeneral.Click
        Dim m As New QueryByEmployee
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryExpensesByExpenseName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryExpensesByPeriod
        m.RadioExpenseName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuQueryExpensesByEmName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New QueryExpensesByPeriod
        m.RadioEmployeeName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuPeriods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPeriods.Click
        Dim m As New Shifts
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuItemsStocks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItemsStocks.Click
        Dim m As New ItemsStocks
        m.MdiParent() = Me
        m.Show()
    End Sub





    Private Sub MenuMainAdjustments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainAdjustments.Click
        Dim m As New ReportAdjustments
        m.RadioStockName.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MeMainPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MeMainPurchaseOrder.Click
        Dim m As New ReportPurchaseOrder
        m.RadioEmployeeID.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMainSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainSalesOrder.Click
        Dim m As New ReportSalesOrder
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMainCustRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainCustRequest.Click
        Dim m As New ReportCustomerRequest
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMainCustReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainCustReturns.Click
        Dim m As New ReportCusReturns
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuMainVendorsReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMainVendorsReturns.Click
        Dim m As New ReportVenReturns
        m.RadioDates.Checked = True
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuReportStockValue_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuReportStockValue.Click
        Try
            Dim s As String
            s = InputBox("√œŒ· ﬂ·„… «·”—", ProjectTitle)
            If s = "" Or s <> "251" Or s Is Nothing Then
                cls.MsgExclamation("ﬂ·„… ”— Œ«ÿ∆Â")
            Else
                MyDs.Tables("Vu_Stock_Value").Rows.Clear()
                cmd.CommandText = "SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL," & _
        " I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL,S.Logo FROM Items I , Items_Stocks SI ," & _
        " Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID AND S.Stock_ID=" & ProjectSettings.CurrentStockID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Vu_Stock_Value"))
                Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
                Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = Rpt
                m.MdiParent() = Me
                m.Show()
            End If
        Catch ex As Exception
            cls.WriteError("Œÿ√ ›Ì  ‘€Ì· «· ﬁ—Ì—", "Stock Balance")
        End Try
    End Sub

    Private Sub MenuSetDefault_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSetDefault.Click
        Try
            PwdDefault = InputBox("√œŒ· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„", ProjectTitle)
            If PwdDefault = "osloup123" Then
                cls.MsgInfo("»—Ã«¡ «·«‰ Ÿ«— Õ Ì Ì „ «·«‰ Â«¡")
                Me.Cursor = Cursors.WaitCursor
                cmd.CommandText = "DELETE FROM Adjustment_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Sales_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Discount_Level"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Levels"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Attendance"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Sales_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Adjustment_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Cards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Discounts"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Added_Hours"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Rewards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Tasks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Vacations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Pay_Salary"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Ages"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Gender"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Item_Sizes"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Types"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Corporations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Rewards_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Security_Group_Details SET Granted =1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Seq_Table SET Curr_Val = 1"
                cmd.ExecuteNonQuery()
                Me.Cursor = Cursors.Default
                cls.MsgInfo(" „ «⁄«œ… «·‰Ÿ«„ ··Ê÷⁄ «·«› —«÷Ì »—Ã«¡ «⁄«œ… «· ‘€Ì·")
                End
            Else
                cls.MsgCritical("Œÿ√ ›Ì «œŒ«· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„")
            End If
        Catch ex As Exception
            cls.MsgCritical("Œÿ√ ›Ì «œŒ«· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„")
        End Try
    End Sub

    Private Sub SystemCommands_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemCommands.Click
        Dim m As New FrmWindows
        PwdDefault = InputBox("√œŒ· ﬂ·„… «·”— «·Œ«’… »«·‰Ÿ«„", ProjectTitle)
        If PwdDefault = "roaya123" Then
            m.MdiParent() = Me
            m.Show()
        End If
    End Sub

    Private Sub «·„’—Ê›« ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·„’—Ê›« ToolStripMenuItem.Click

        Panel6.Visible = True
        Panel9.Visible = False
        Panel7.Visible = False
        Panel8.Visible = False
    End Sub






    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Panel7.Visible = True
        Panel6.Visible = False
        Panel8.Visible = True
        Panel9.Visible = False
        Panel5.Visible = False
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles «·«Ì—«œ« ToolStripMenuItem.Click


        Panel7.Visible = True
        Panel6.Visible = False
        Panel8.Visible = False
        Panel9.Visible = False

    End Sub


    Private Sub MenuExpensesHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExpensesHeader.Click
        Dim m As New ExpensesMaster
        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuExpensesElectricity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ExpensesDetails
        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuExpensesWater_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ExpensesDetails
        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuExpensesLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New ExpensesDetails
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuExpensesOther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExpensesOther.Click
        Dim m As New ExpensesDetails
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuEmpAddedHours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpAddedHours.Click
        Panel8.Visible = False
        Panel5.Visible = False
        Dim m As New EmpAddedHours
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuPaySalaries_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPaySalaries.Click
        Panel8.Visible = False
        Panel5.Visible = False
        Dim m As New PaySalary

        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuEmpRewardsCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpRewardsCategories.Click
        Dim m As New RewardsCategories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub MenuEmpRewards_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEmpRewards.Click
        Dim m As New EmployeesRewards
        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuIncomeByPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuIncomeByPeriod.Click
        Dim m As New TotalMoney
        m.MdiParent() = Me
        m.Show()
    End Sub
    Private Sub MenuIncomeToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuIncomeToday.Click
        Try
            cmd.CommandText = "SELECT ISNULL(SUM(Cash_Value),0) FROM Sales_Header  WHERE Bill_Date BETWEEN '" & Now.ToString("MM/dd/yyyy") & "' and '" & Now.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar)
        Catch ex As Exception
            cls.WriteError(ex.Message, "User Pref")
        End Try
    End Sub
    Private Sub TotalSaleIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalSaleIncome.Click
        Dim s As String
        s = InputBox("√œŒ· ﬂ·„… «·”—", ProjectTitle)
        If s = "" Or s <> "251" Or s Is Nothing Then
            cls.MsgExclamation("ﬂ·„… ”— Œ«ÿ∆Â")
        Else
            Dim m As New ProfitSales
            m.MdiParent() = Me
            m.Show()
        End If
    End Sub

    Private Sub BtnEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmp.Click
        EmployeesPanel.Visible = True
        StocksPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub BtnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStock.Click
        StocksPanel.Visible = True
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub BtnCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCust.Click
        CustomersPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub BtnVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVendor.Click
        VendorsPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        accountantspanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub Btnqueries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btnqueries.Click
        QueryPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub BtnStatistics_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStatistics.Click
        StatisticsPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        ReportsPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        SecurityPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub



    Private Sub BtnSecurity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSecurity.Click
        SecurityPanel.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        PanelSettings.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub
    Private Sub BtnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSettings.Click
        PanelSettings.Visible = True
        StocksPanel.Visible = False
        EmployeesPanel.Visible = False
        CustomersPanel.Visible = False
        VendorsPanel.Visible = False
        accountantspanel.Visible = False
        QueryPanel.Visible = False
        StatisticsPanel.Visible = False
        ReportsPanel.Visible = False
        SecurityPanel.Visible = False
        PnlSze.Height = 673
        PnlSze.Width = 239
        Panel1.Size = PnlSze
    End Sub


    Private Sub BtnActivatePanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActivatePanel.Click
        PnlSze.Height = 673
        If Panel1.Size.Width = 10 Then
            PnlSze.Width = 239
            Panel1.Size = PnlSze
        Else
            PnlSze.Width = 10
            Panel1.Size = PnlSze
        End If
    End Sub

    Private Sub MenuSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuSalesOrder.Click
        If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Style") = "„»”ÿÂ" Then
            Dim m As New simpleSalesOrderNormal
            m.MdiParent = Me
            m.Dock = DockStyle.Right
            m.Show()
        ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Style") = " ›’Ì·ÌÂ" Then
            Dim m As New SalesOrderNormal
            m.MdiParent = Me
            m.Show()

        Else
            Dim m As New SalesOrderButtons
            m.MdiParent = Me
            m.Show()
        End If

    End Sub

    'Private Sub MenuPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPurchaseOrder.Click
    '    Dim m As New PurchaseOrderNormal
    '    m.MdiParent = Me
    '    m.Show()
    'End Sub


    Private Sub MenuInvLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuInvLog.Click
        Dim m As New FrmReportInventoryLog
        m.MdiParent = Me
        m.Show()
    End Sub



    Private Sub BtnReportEmpCards1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReportEmpCards1.Click
        Dim m As New PrintEmpCards
        m.ShowDialog()
    End Sub

    Private Sub BtnReportEmpCards2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReportEmpCards2.Click
        MyDs.Tables("EmpBarCodeTable").Rows.Clear()
        For I As Integer = 0 To 3
            r = MyDs.Tables("EmpBarCodeTable").NewRow
            r("Employee_name1") = " "
            MyDs.Tables("EmpBarCodeTable").Rows.Add(r)
        Next

        Dim m As New ShowAllReports
        Dim rptcrd As New RptEmpCards2
        rptcrd.SetDataSource(MyDs.Tables("EmpBarCodeTable"))
        m.CrystalReportViewer1.ReportSource = rptcrd

        m.ShowDialog()

    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Panel7.Visible = False
        Panel6.Visible = False
        Panel8.Visible = False
        Panel9.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Panel8.Visible = False
        Panel5.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New DiscountCategories
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New EmployeesDiscounts
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim m As New frmreportitemsstocks
        m.MdiParent() = Me
        m.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New Frm_Total_Stocks
        m.MdiParent() = Me
        m.Show()
    End Sub



    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim m As New FrmReportExpenses
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New FrmReportcustomersPayments
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim m As New FrmReportVendorsPayments
        m.MdiParent = Me
        m.Show()

    End Sub



    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim searchWin As New GeneralSearch
        searchWin.MdiParent = Me
        searchWin.Dock = DockStyle.Left
        searchWin.Show()
    End Sub

    Private Sub TxtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearch.KeyDown
        STable.Rows.Clear()
        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()
        Try


            If e.KeyCode = Keys.Enter And TxtSearch.Text <> "" Then
                cmd.CommandText = "select customer_id as ColID,N'⁄„·«¡' as ColType,customer_name as ColName,N'«·»Ì«‰«  «·‘Œ’ÌÂ ··⁄„Ì·' as ColDesc from customers where customer_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Vendor_id as ColID,N'„Ê—œÌ‰' as ColType,Vendor_name as ColName,N'«·»Ì«‰«  «·‘Œ’ÌÂ ··„Ê—œ' as ColDesc from Vendors where Vendor_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «· ›’Ì·ÌÂ ··√’‰«›' as ColDesc from Items where Item_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «· ›’Ì·ÌÂ ··√’‰«›' as ColDesc from Items where barcode like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Employee_id as ColID,N'»Ì«‰«  «·⁄«„·Ì‰' as ColType,Employee_name as ColName,N'»Ì«‰«  «· ›’Ì·ÌÂ ··⁄«„·Ì‰' as ColDesc from employees where employee_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Expense_Detail_ID as ColID,N'«·„’—Ê›« ' as ColType,Expense_name as ColName,N' ›«’Ì· «·„’—Ê›« ' as ColDesc from Expenses_Details where Expense_Name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Expense_Category_ID as ColID,N'»‰Êœ «·„’—Ê›« ' as ColType,Expense_Category_name as ColName,N'»Ì«‰«  »‰Êœ «·„’—Ê›« ' as ColDesc from Expenses_Header where Expense_Category_Name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Stock_ID as ColID,N'«·„Õ·« ' as ColType,Stock_Name as ColName,N'»Ì«‰«  «·„Õ·« ' as ColDesc from Stocks where Stock_Name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Category_id as ColID,N'»‰Êœ «·„Œ“‰' as ColType,Category_name as ColName,N'»Ì«‰«  »‰Êœ «·„Œ“‰' as ColDesc from categories where Category_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select corporation_id as ColID,N'«·‘—ﬂ« ' as ColType,corporation_name as ColName,N'»Ì«‰«  «·‘—ﬂ«  «· ›’Ì·ÌÂ' as ColDesc from corporations where corporation_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Type_ID as ColID,N'«·›∆« ' as ColType,Type_name as ColName,N'»Ì«‰«  ›∆«  «·√’‰«›' as ColDesc from Items_Types where Type_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                cmd.CommandText = "select Gender_ID as ColID,N'«·‰Ê⁄' as ColType,Gender_name as ColName,N'«·‰Ê⁄' as ColDesc from Gender where Gender_name like N'%" & TxtSearch.Text & "%'"
                da.SelectCommand = cmd
                da.Fill(STable)
                '------------------------------------------
                'cmd.CommandText = "select distinct item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «·√’‰«› »«·‘—ﬂ« ' as ColDesc from dbo.Query_All_Items where Corporation_Name like N'%" & TxtSearch.Text & "%'"
                'da.SelectCommand = cmd
                'da.Fill(STable)
                ''------------------------------------------
                'cmd.CommandText = "select distinct item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «·√’‰«› »«·‰Ê⁄' as ColDesc from dbo.Query_All_Items where Gender_Name like N'%" & TxtSearch.Text & "%'"
                'da.SelectCommand = cmd
                'da.Fill(STable)
                ''------------------------------------------
                'cmd.CommandText = "select distinct item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «·√’‰«› »«·„ﬁ«”' as ColDesc from dbo.Query_All_Items where Size_Name like N'%" & TxtSearch.Text & "%'"
                'da.SelectCommand = cmd
                'da.Fill(STable)
                ''------------------------------------------
                'cmd.CommandText = "select distinct item_id as ColID,N'»Ì«‰«  «·√’‰«›' as ColType,item_name as ColName,N'»Ì«‰«  «·√’‰«› »«·›∆Â' as ColDesc from dbo.Query_All_Items where Type_Name like N'%" & TxtSearch.Text & "%'"
                'da.SelectCommand = cmd
                'da.Fill(STable)
                Panel10.Visible = True
            End If
        Catch ex As Exception
            Dim S As String
        End Try

    End Sub
    Private Sub GrdSearch_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearch.RowHeaderMouseDoubleClick

        DtlTbl.Rows.Clear()
        DtlTbl.Columns.Clear()
        Try


            Select Case GrdSearch.SelectedRows(0).Cells("ColType").Value
                Case "⁄„·«¡"
                    cmd.CommandText = "select customer_id , customer_name as N'«”„ «·⁄„Ì·', address as N'«·⁄‰Ê«‰', Mobile as N'«·„Ê»«Ì·', Tele as N'«· ·Ì›Ê‰' from customers where customer_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "„Ê—œÌ‰"
                    cmd.CommandText = "select vendor_id , vendor_name as N'«”„ «·„Ê—œ', address as N'«·⁄‰Ê«‰', Mobile as N'«·„Ê»«Ì·', Tele as N'«· ·Ì›Ê‰' from vendors where vendor_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "»Ì«‰«  «·⁄«„·Ì‰"
                    cmd.CommandText = "select employee_id , employee_name as N'«”„ «·„ÊŸ›', address as N'«·⁄‰Ê«‰', Mobile as N'«·„Ê»«Ì·', Tele as N'«· ·Ì›Ê‰' from employees where employee_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "»‰Êœ «·„’—Ê›« "
                    cmd.CommandText = "select Expense_Detail_id , Expense_name as N'«”„ «·„’—Ê›', Expense_Value as N'ﬁÌ„… «·„’—Ê›', Expense_Date as N' «—ÌŒ «·„’—Ê›' from Expenses_Details where Expense_Category_ID = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "»Ì«‰«  «·√’‰«›"
                    cmd.CommandText = "select distinct item_id , Stock_Name as N'«”„ «·„Õ·' ,item_name as N'«”„ «·’‰›', barcode as N'«·»«—ﬂÊœ', purchase_price as N'”⁄— «·‘—«¡', sale_price as N'”⁄— «·ﬁÿ«⁄Ì' , sale_total_price as N'”⁄— «·Ã„·Â',Balance as N'«·—’Ìœ' from Query_All_Items where item_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "«·„Õ·« "
                    cmd.CommandText = "select distinct item_id ,Stock_Name as N'«”„ «·„Õ·' ,item_name as N'«”„ «·’‰›', barcode as N'«·»«—ﬂÊœ', purchase_price as N'”⁄— «·‘—«¡', sale_price as N'”⁄— «·ﬁÿ«⁄Ì' , sale_total_price as N'”⁄— «·Ã„·Â',Balance as N'«·—’Ìœ' from Query_All_Items where stock_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "»‰Êœ «·„Œ“‰"
                    cmd.CommandText = "select distinct item_id ,Stock_Name as N'«”„ «·„Õ·' ,item_name as N'«”„ «·’‰›', barcode as N'«·»«—ﬂÊœ', purchase_price as N'”⁄— «·‘—«¡', sale_price as N'”⁄— «·ﬁÿ«⁄Ì' , sale_total_price as N'”⁄— «·Ã„·Â',Balance as N'«·—’Ìœ' from Query_All_Items where category_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "«·‘—ﬂ« "
                    cmd.CommandText = "select distinct item_id ,Stock_Name as N'«”„ «·„Õ·' ,item_name as N'«”„ «·’‰›', barcode as N'«·»«—ﬂÊœ', purchase_price as N'”⁄— «·‘—«¡', sale_price as N'”⁄— «·ﬁÿ«⁄Ì' , sale_total_price as N'”⁄— «·Ã„·Â',Balance as N'«·—’Ìœ' from Query_All_Items where corporation_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
                Case "«·›∆« "
                    cmd.CommandText = "select distinct item_id ,Stock_Name as N'«”„ «·„Õ·' ,item_name as N'«”„ «·’‰›', barcode as N'«·»«—ﬂÊœ', purchase_price as N'”⁄— «·‘—«¡', sale_price as N'”⁄— «·ﬁÿ«⁄Ì' , sale_total_price as N'”⁄— «·Ã„·Â',Balance as N'«·—’Ìœ' from Query_All_Items where Type_id = " & GrdSearch.SelectedRows(0).Cells("ColID").Value
            End Select

            da.SelectCommand = cmd
            da.Fill(DtlTbl)
            GrdSearchDetails.Columns(0).Visible = False
        Catch ex As Exception
            Dim M As Integer
        End Try
    End Sub

    Private Sub GrdSearchDetails_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GrdSearchDetails.RowHeaderMouseDoubleClick

        Try
            Select Case GrdSearchDetails.SelectedRows(0).Cells(0).OwningColumn.Name
                Case "customer_id"
                    Dim m As New Customers
                    m.SearchCustomerID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "vendor_id"
                    Dim m As New Vendors
                    m.SearchvendorID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "employee_id"
                    Dim m As New Employees
                    m.SearchEmployeeID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "Expense_Detail_id"
                    Dim m As New ExpensesDetails
                    m.SearchExpenseDetailID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
                Case "item_id"
                    Dim m As New Items
                    m.SearchItemID = GrdSearchDetails.SelectedRows(0).Cells(0).Value
                    m.ShowDialog()
            End Select
        Catch ex As Exception
            Dim M As Integer
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Panel10.Visible = False
        TxtSearch.Text = ""
    End Sub


    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel7.Visible = False
        Panel6.Visible = False
        Panel8.Visible = False
        Panel9.Visible = False
        Dim m As New TotalMoney
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New SalesOrderButtons
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button11_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOfficialVacations.Click
        Dim m As New officialVacations
        m.MdiParent = Me
        m.Show()

    End Sub


    Private Sub Button13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmpsShortcuts.Click
        Dim m As New Employees_Shortcuts
        m.MdiParent = Me
        m.Show()
    End Sub

    Public Sub AddShortcuts()
        cls.RefreshData("select * from employees_shortcuts where employee_id=" & EmpIDVar, MyDs.Tables("employees_shortcuts"))
        For i As Integer = 0 To MyDs.Tables("employees_shortcuts").Rows.Count - 1
            Dim b As New Button

            b.BackColor = Color.LightBlue

            b.FlatStyle = FlatStyle.Flat
            b.FlatAppearance.BorderSize = 1
            b.FlatAppearance.MouseOverBackColor = Color.AliceBlue
            b.FlatAppearance.MouseDownBackColor = Color.LightBlue
            'b.ForeColor = Color.White

            b.Size = p1
            b.Font = fnt1
            b.Text = MyDs.Tables("employees_shortcuts").Rows(i).Item("Form_Name")
            AddHandler b.Click, AddressOf ShortcutAction
            FC.Controls.Add(b)
        Next
    End Sub

    Public Sub ShortcutAction(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text = "«·«œ«—« " Then
            Dim m As New Departments
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·ÊŸ«∆›" Then
            Dim m As New Jobs
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·„ÊŸ›Ì‰" Then
            Dim m As New Employees
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "»‰Êœ «·Œ’Ê„« " Then
            Dim m As New DiscountCategories
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "Œ’Ê„«  «·„ÊŸ›Ì‰" Then
            Dim m As New EmployeesDiscounts
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "»‰Êœ «·„ﬂ«›¬ " Then
            Dim m As New RewardsCategories
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "„ﬂ«›¬  «·„ÊŸ›Ì‰" Then
            Dim m As New EmployeesRewards
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·√Ã«“« " Then
            Dim m As New EmployeesVacations
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·„Â„« " Then
            Dim m As New EmployeesTasks
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·√’‰«› «·√”«”Ì…" Then
            Dim m As New Items
            m.MdiParent = Me
        ElseIf sender.text = "»‰Êœ «·√’‰«› «·√”«”Ì…" Then
            Dim m As New Categories
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·„Œ«“‰" Then
            Dim m As New Stocks
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«œŒ«· —’Ìœ √Ê· «·„œ…" Then
            Dim m As New FirstBalanceStock
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "√–Ê‰«  «· ÕÊÌ·" Then
            Dim m As New Adjustments
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "√Â·«ﬂ «·√’‰«›" Then
            Dim m As New ItemsDep
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·Ã—œ" Then
            Dim m As New CheckHeader
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = " ›«’Ì· «·Ã—œ" Then
            Dim m As New CheckDetails
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "›∆… «·Œ’„ ··⁄„·«¡" Then
            Dim m As New CustomerDiscountLevel
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "›∆… «·√Ã· ··⁄„·«¡" Then
            Dim m As New CustomerLevels
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·⁄„·«¡" Then
            Dim m As New Customers
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "›Ê« Ì— «·„»Ì⁄« " Then
            If MyDs.Tables("app_preferences").Rows(0).Item("Sal_Def_Style") = "⁄«œÌ…" Then
                Dim m As New SalesOrderNormal
                m.MdiParent = Me
                m.Show()
            ElseIf MyDs.Tables("app_preferences").Rows(0).Item("Sal_Def_Style") = "„»”ÿÂ" Then
                Dim m As New simpleSalesOrderNormal
                m.MdiParent = Me
                m.Show()
            Else
                Dim m As New SalesOrderButtons
                m.MdiParent = Me
                m.Show()
            End If

        ElseIf sender.text = "„— Ã⁄«  «·⁄„·«¡" Then
            Dim m As New ReturnsCustomers
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·„Ê—œÌ‰" Then
            Dim m As New Vendors
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "—»ÿ „Ê—œ »«·√’‰«›" Then
            Dim m As New ItemsVendors
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "›« Ê—… „‘ —Ì« " Then
            If MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = " ›’Ì·ÌÂ" Then
                Dim m As New PurchaseOrderNormal
                m.MdiParent() = Me
                m.Show()

            ElseIf MyDs.Tables("App_Preferences").Rows(0).Item("Pur_Def_Style") = "„›« ÌÕ" Then
                Dim m As New PurchaseOrderButtons
                m.MdiParent() = Me
                m.Show()
            End If
        ElseIf sender.text = "„— Ã⁄«  «·„Ê—œÌ‰" Then
            Dim m As New ReturnsVendors
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "»‰Êœ «·„’—Ê›« " Then
            Dim m As New ExpensesMaster
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "„’—Ê›«  ⁄«„…" Then
            Dim m As New ExpensesDetails
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "„— »«  «·„ÊŸ›Ì‰" Then
            Dim m As New PaySalary
            m.MdiParent = Me
            m.Show()


        ElseIf sender.text = " ﬁ—Ì— ›Ê« Ì— «·„‘ —Ì« " Then
            Dim m As New ReportPurchaseOrder
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = " ﬁ—Ì— ›Ê« Ì— «·„»Ì⁄« " Then
            Dim m As New ReportSalesOrder
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = " ﬁ—Ì— „— Ã⁄«  «·„Ê—œÌ‰" Then
            Dim m As New ReportVenReturns
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = " ﬁ—Ì— „— Ã⁄«  «·⁄„·«¡" Then
            Dim m As New ReportCusReturns
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "ÿ»«⁄… «·»«—ﬂÊœ" Then
            Dim m As New PrintBarCode
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "ﬂ‘› Õ”«» «·»‰ﬂ" Then
            Dim m As New DiscountCategories
            m.MdiParent = Me
            m.Show()


        ElseIf sender.text = " ﬁ—Ì— «·«—’œ… «·⁄«„" Then
            Dim m As New FrmReportItemsStocks
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = " ﬁ—Ì— «–Ê‰«  «· ÕÊÌ·" Then
            Dim m As New ReportAdjustments
            m.MdiParent = Me
            m.Show()

        ElseIf sender.text = "ÿ·»«  «·⁄„·«¡" Then
            Dim m As New CustomerRequest
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = " ﬁ—Ì— ÿ·»«  «·⁄„·«¡" Then
            Dim m As New ReportCustomerRequest
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = " ﬁ—Ì—  ﬁÌÌ„ «·„Œ“‰" Then
            Try
                Dim s As String
                s = InputBox("√œŒ· ﬂ·„… «·”—", ProjectTitle)
                If s = "" Or s <> "251" Or s Is Nothing Then
                    cls.MsgExclamation("ﬂ·„… ”— Œ«ÿ∆Â")
                Else
                    MyDs.Tables("Vu_Stock_Value").Rows.Clear()
                    cmd.CommandText = "SELECT I.ITEM_NAME,SI.BALANCE,I.PURCHASE_PRICE,I.PURCHASE_PRICE*SI.BALANCE AS PUR_TOTAL,I.Sale_Price,I.Sale_Price*SI.Balance AS SAL_TOTAL," & _
            " I.Sale_Total_Price,I.Sale_Total_Price*SI.Balance AS SAL_ALL_TOTAL,S.Logo FROM Items I , Items_Stocks SI ," & _
            " Stocks S WHERE I.Item_ID=SI.Item_ID AND S.Stock_ID=SI.Stock_ID AND S.Stock_ID=" & ProjectSettings.CurrentStockID
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Vu_Stock_Value"))
                    Rpt.SetDataSource(MyDs.Tables("Vu_Stock_Value"))
                    Rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    Dim m As New ShowAllReports
                    m.CrystalReportViewer1.ReportSource = Rpt
                    m.MdiParent() = Me
                    m.Show()
                End If
            Catch ex As Exception
                cls.WriteError("Œÿ√ ›Ì  ‘€Ì· «· ﬁ—Ì—", "Stock Balance")
            End Try
        ElseIf sender.text = " ﬁÌÌ„ «·„Œ“‰ »«·»‰œ" Then
            Dim m As New frmreportitemsstocks
            m.MdiParent() = Me
            m.Show()
        ElseIf sender.text = "«Ã„«·Ì Õ—ﬂ… «·»Ì⁄ Ê «·‘—«¡" Then
            Dim m As New Frm_Total_Stocks
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "Õ—ﬂ… «·„Œ“‰" Then
            Dim m As New FrmReportInventoryLog
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "ﬂ—Ê  «·„ÊŸ›Ì‰" Then
            Dim m As New PrintEmpCards
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "Œ·›Ì… ﬂ—Ê  «·„ÊŸ›Ì‰" Then
            MyDs.Tables("EmpBarCodeTable").Rows.Clear()
            For I As Integer = 0 To 3
                r = MyDs.Tables("EmpBarCodeTable").NewRow
                r("Employee_name1") = " "
                MyDs.Tables("EmpBarCodeTable").Rows.Add(r)
            Next

            Dim m As New ShowAllReports
            Dim rptcrd As New RptEmpCards2
            rptcrd.SetDataSource(MyDs.Tables("EmpBarCodeTable"))
            m.CrystalReportViewer1.ReportSource = rptcrd

            m.ShowDialog()
        ElseIf sender.text = "„œ›Ê⁄«  «·⁄„·«¡" Then
            Dim m As New FrmReportcustomersPayments
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "„œ›Ê⁄«  «·„Ê—œÌ‰" Then
            Dim m As New FrmReportVendorsPayments
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«⁄œ«œ«  «·»—‰«„Ã" Then
            Dim m As New FrmUserPreferences
            m.MdiParent = Me
            m.Show()
        ElseIf sender.text = "«·„’—Ê›« " Then
            Dim m As New FrmReportExpenses
            m.MdiParent = Me
            m.Show()
        End If


    End Sub

    Private Sub ShowHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowHide.Click
        If FC.Visible = True Then
            FC.Visible = False
            ShowHide.BackgroundImage = My.Resources.Show_Panel
        Else
            FC.Visible = True
            ShowHide.BackgroundImage = My.Resources.Hide_Panel

        End If
    End Sub

    Private Sub btnitemsdiscounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnitemsdiscounts.Click
        Dim m As New Report_Items_Prices
        m.MdiParent = Me
        m.Show()
    End Sub

    Private Sub Button13_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowItem.Click
        Dim M As New BarcodeShow
        M.MdiParent = Me
        M.Show()
    End Sub

   
    Private Sub FirstCustomersBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstCustomersBalance.Click
        Panel3.Visible = False
        Panel4.Visible = False
        Dim M As New FirstBalancecustomers
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub BtnFirstVendorsBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirstVendorsBalance.Click
        Dim M As New FirstBalanceVendors
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuShiftsDetails.Click
        Dim M As New Shifts_details
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub Button15_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDailyIncom.Click
        Dim M As New FrmReportIncom
        M.MdiParent = Me
        M.Show()
    End Sub

    Private Sub Button14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItemsExpired.Click
        Dim m As New FrmOrderBalance
        m.MdiParent = Me
        m.Show()

    End Sub

    Private Sub Button11_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New Alerts
        m.MdiParent = Me
        m.Show()
    End Sub


    Private Sub NumericUpDown1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cust.SelectedValue = Nothing Then
                cls.MsgExclamation("»—Ã«¡ «œŒ· «”„ «·„ÊŸ›")
                Exit Sub
            End If
            If Item.SelectedValue = Nothing Then
                cls.MsgExclamation("»—Ã«¡ «œŒ· «”„ «·’‰›")
                Exit Sub
            End If
            If Quantity.Value = 0 Then
                cls.MsgExclamation("»—Ã«¡ «œŒ· «·ﬂ„ÌÂ ")
                Exit Sub
            End If

            Dim Price As Integer
            Dim Stock As Integer
            Dim Bill As Integer


            Try

                cmd.CommandText = "select Sal_Def_Qty from app_preferences"
                Stock = cmd.ExecuteScalar

                cmd.CommandText = "select sale_Price from items where item_id=" & Item.SelectedValue
                Price = cmd.ExecuteScalar

            Catch
                Price = 0
            End Try


            If Price = 0 Then
                cls.MsgExclamation("»—Ã«¡ «Œ Ì«— «”„ «·„Œ“‰ „‰ «⁄œ«œ«  «·‰Ÿ«„")
                Exit Sub
            End If



            cmd.CommandText = "select dbo.Is_Balance_Fit(" & Item.SelectedValue & "," & Quantity.Value & " , " & Stock & ")"
            If cmd.ExecuteScalar = 0 Then
                cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & Item.Text & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…")
                Exit Sub
            End If


            cmd.CommandText = "select curr_val from seq_Table where seq_Id=2"
            Bill = cmd.ExecuteScalar

            cmd.CommandText = "Execute Commit_Sales_Order_Header " & Bill & ",'" & Today.ToString("MM/dd/yyyy") & "','" & Today.TimeOfDay.ToString & "'," & Cust.SelectedValue & "," & Price & ",N'·« ÌÊÃœ'," & "0," & EmpIDVar & "," & Total.Text & ",0,N'‰ﬁœÌ','',''," & Stock & ",NULL,N'ﬁÿ«⁄Ì',''," & CurrentShiftID
            cmd.ExecuteNonQuery()

            cmd.CommandText = "update seq_Table set curr_val=curr_val+1 where seq_id=2"
            cmd.ExecuteNonQuery()

            cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE - " & Quantity.Value & " WHERE ITEM_ID = " & Item.SelectedValue & " AND STOCK_ID = " & Stock
            cmd.ExecuteNonQuery()

            cmd.CommandText = "INSERT INTO SALES_DETAILS(BILL_ID,ITEM_ID,QUANTITY,PRICE,DISCOUNT_TYPE,DISCOUNT_VALUE,Total_Item) VALUES (" & Bill & "," & Item.SelectedValue & "," & Quantity.Value & "," & Price & "," & "N'·« ÌÊÃœ'," & "0," & Total.Text & ")"
            cmd.ExecuteNonQuery()

            cls.Commit_Inv_Tran(Bill, Today, Total.Text, Item.SelectedValue, Quantity.Value * Price, "›« Ê—… „»Ì⁄« ", Stock)


            cls.MsgInfo("·ﬁœ  „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ")
            Quantity.Value = 0

        End If


    End Sub

    Private Sub Emp_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Cust.MouseDoubleClick
        Try
            cmd.CommandText = "select category from app_preferences"
            cls.RefreshData("select * from Items where category_id=" & cmd.ExecuteScalar, TblItems)
            cls.RefreshData("select * from employees", TblCusts)
        Catch
        End Try
    End Sub

    Private Sub Quantity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quantity.ValueChanged
        Try
            cmd.CommandText = "select sale_Price from items where item_id=" & Item.SelectedValue
            Total.Text = Quantity.Value * cmd.ExecuteScalar
        Catch
            Total.Text = 0
        End Try
    End Sub

    Private Sub Item_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item.SelectionChangeCommitted
        Try
            cmd.CommandText = "select sale_Price from items where item_id=" & Item.SelectedValue
            Total.Text = Quantity.Value * cmd.ExecuteScalar
        Catch
            Total.Text = 0
        End Try
    End Sub

    Private Sub BtnAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAccounts.Click
        Dim m As New CustomersVendorsAccount
        m.MdiParent = Me
        m.Show()
    End Sub
End Class