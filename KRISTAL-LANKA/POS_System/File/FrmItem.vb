Imports System.Data.SqlClient
Imports ConnData
Public Class FrmItem

    Private Sub CmdExit_Click(sender As Object, e As EventArgs) Handles CmdExit.Click
        Me.Close()
        Dim xw As Integer = Screen.PrimaryScreen.Bounds.Width
        If xw < 1920 Then
            FrmCash1.Show()
            FrmCash1.BringToFront()
        Else
            FrmCashier.Show()
            FrmCashier.MdiParent = FrmMDI
            FrmCashier.BringToFront()
        End If
    End Sub

    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        FrmAct.Close()
        frmBackup.Close()
        FrmBANK.Close()
        FrmCashier.Close()
        FrmCat1.Close()
        FrmCat2.Close()
        FrmCHQPAY.Close()
        FrmCustomer.Close()
        FrmDMG.Close()
        FrmErrorCorrec.Close()
        FrmExcel.Close()
        FrmGRNRPT.Close()
        FrmGRN.Close()
        'FrmItem.Close()
        frmPchange.Close()
        FrmRCPT.Close()
        FrmREPORT.Close()
        FrmRPT.Close()
        FrmRPT1.Close()
        FrmRpts.Close()
        FrmRtn.Close()
        FrmSALESRE.Close()
        FrmSTCKENTER.Close()
        FrmSupPament.Close()
        FrmSupplier.Close()
        FrmSupplierRTN.Close()
        FrmUOP.Close()
        FrmUserControl.Close()
        'ItemList()
        cmd = New SqlCommand("Select Count(ItemCode) from Stock_Main", con)
        Dim aa As Integer = 0
        aa = cmd.ExecuteScalar
        If aa = 0 Then
            cmd = New SqlCommand("Select * from ItemMaster", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                '                   AutoID,                           ItemCode,                  ItemName,                  UOM,                    CostPrice,                   SellPrice,         RcvQty,   SaleQty,      DmgQty,  RtnQty,     BalanceQty,   PisicalQty,     LastUpdate,                         UName,           WsPrice,                    IType
                cmd1 = New SqlCommand("Insert Stock_Main values('" & rdr("ItemCode") & "','" & rdr("ItemName") & "','" & rdr("Uom") & "','" & rdr("CostPrice") & "','" & rdr("SellPrice") & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & 0 & "','" & "NON" & "')", con1)
                cmd1.ExecuteNonQuery()
            End While
            rdr.Close()
        End If
        ' AboutBox1.Close()
    End Sub

    Private Sub FrmItem_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown

        If e.KeyCode = 13 Then
            xITEMCD(ItemCode.Text)
            ItemCode.Focus()


        ElseIf e.KeyCode = 113 Then
            Panel2.Show()
            Panel1.Hide()
            txtItemCode_TextChanged(sender, EventArgs.Empty)
            txtItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If

    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        End If
    End Sub

   
    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged
        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()

    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID1.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID1.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged

        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where ItemName like '" & txtItemName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()

    End Sub

    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If ItemCode.Text = "" Then Return
        If Val(SellPrice.Text) < Val(CostPrice.Text) Then
            MsgBox("Error Price")
            Return
        ElseIf Val(SellPrice.Text) < Val(WsalePr.Text) Then
            MsgBox("Error Price")
            Return
        ElseIf Val(WsalePr.Text) < Val(CostPrice.Text) Then
            If Val(WsalePr.Text) = 0 Then
            Else
                MsgBox("Error Price")
                Return
            End If


        End If



        'Dim xINAME As String = ItemName.Text
        'convertQuotes(xINAME)
        Dim xCV As Integer = 0
        cmd = New SqlCommand("Select count(ItemCode) from Stock_Main where(ItemCode='" & ItemCode.Text & "')", con)
        xCV = cmd.ExecuteScalar




        cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then

            Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the Current Items Details ?", "Update the Current Items Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                'ItemCode,                                               ItemName,                      Cat1,               Cat1Name,                                Cat2,                       Cat2Name,                          Description,                     SupCode,                        SupName,                       Uom,                        CostPrice,                       SellPrice,                     Inact,                                   LastUpdate,                                        UName,                  ROLevel,WSPrice
                cmd1 = New SqlCommand("Update ItemMaster set ItemName='" & ItemName.Text & "',Cat1='" & CatCode1.Text & "',Cat1Name='" & CatName1.Text & "',Cat2='" & CatCode2.Text & "',Cat2Name='" & CatName2.Text & "',Description='" & Descrip.Text & "',SupCode='" & SupCode.Text & "',SupName='" & SupName.Text & "',Uom='" & UOM.Text & "',CostPrice='" & CostPrice.Text & "',SellPrice='" & SellPrice.Text & "',Inact='" & CHK1.CheckState & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',ROLevel='" & "9" & "',WSPrice='" & WsalePr.Text & "'where ItemCode='" & ItemCode.Text & "'", con1)
                cmd1.ExecuteNonQuery()

                If Val(OpeningBal.Text) > 0 Then
                    If xCV = 0 Then
                        '                   AutoID,                           ItemCode,                          ItemName,                      UOM,                    CostPrice,                   SellPrice,                 RcvQty,                  SaleQty,      DmgQty,  RtnQty,             BalanceQty,                 PisicalQty,                     LastUpdate,                         UName,                      WsPrice,                    IType
                        cmd1 = New SqlCommand("Insert Stock_Main values('" & ItemCode.Text & "','" & ItemName.Text.Replace("'", "") & "','" & UOM.Text & "','" & Val(CostPrice.Text) & "','" & Val(SellPrice.Text) & "','" & Val(OpeningBal.Text) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(OpeningBal.Text) & "','" & Val(OpeningBal.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & Val(WsalePr.Text) & "','" & "NON" & "')", con1)
                        cmd1.ExecuteNonQuery()
                    End If

                    cmd1 = New SqlCommand("Update Stock_Main Set WsPrice='" & Val(WsalePr.Text) & "',RcvQty='" & Val(OpeningBal.Text) & "',BalanceQty='" & Val(OpeningBal.Text) & "',PisicalQty='" & Val(OpeningBal.Text) & "'where ItemCode='" & ItemCode.Text & "'", con1)
                    cmd1.ExecuteNonQuery()
                End If


                MessageBox.Show("Item Update Succeed.", "Item Updating", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        Else

            Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Item ?", "Add New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                '                                                          ItemCode,            ItemName,                 Cat1,                  Cat1Name,             Cat2,                  Cat2Name,              Description,           SupCode,                SupName,              Uom,                CostPrice,                SellPrice,                  Inact                           LastUpdate                              UName                   UName
                cmd1 = New SqlCommand("Insert ItemMaster values('" & ItemCode.Text & "','" & ItemName.Text.Replace("'", "") & "','" & CatCode1.Text & "','" & CatName1.Text & "','" & CatCode2.Text & "','" & CatName2.Text & "','" & Descrip.Text & "','" & SupCode.Text & "','" & SupName.Text & "','" & UOM.Text & "','" & CostPrice.Text & "','" & SellPrice.Text & "','" & CHK1.CheckState & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "9" & "','" & WsalePr.Text & "')", con1)
                cmd1.ExecuteNonQuery()
                '                   AutoID,                           ItemCode,                          ItemName,                      UOM,                    CostPrice,                   SellPrice,                 RcvQty,                  SaleQty,      DmgQty,  RtnQty,             BalanceQty,                 PisicalQty,                     LastUpdate,                         UName,                      WsPrice,                    IType
                cmd1 = New SqlCommand("Insert Stock_Main values('" & ItemCode.Text & "','" & ItemName.Text.Replace("'", "") & "','" & UOM.Text & "','" & Val(CostPrice.Text) & "','" & Val(SellPrice.Text) & "','" & Val(OpeningBal.Text) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & Val(OpeningBal.Text) & "','" & Val(OpeningBal.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & FrmMDI.UName.Text & "','" & Val(WsalePr.Text) & "','" & "NON" & "')", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("Add New Item Succeed.", "Add New Item", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If


        End If
            rdr.Close()
        CmdCancel_Click(sender, EventArgs.Empty)
    End Sub
    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "'")

    End Function
    Private Sub CHK1_CheckedChanged(sender As Object, e As EventArgs) Handles CHK1.CheckedChanged
        If CHK1.Checked = True Then
            CHK1.CheckState = 1
        Else
            CHK1.CheckState = 0

        End If
    End Sub

    Private Sub CatCode2_KeyDown(sender As Object, e As KeyEventArgs) Handles CatCode2.KeyDown
        If e.KeyCode = 113 Then
            Panel3.Show()
            Panel2.Hide()
            Panel1.Hide()
            txtCat2Code_TextChanged(sender, EventArgs.Empty)
            txtCat2Code.Focus()
        ElseIf e.KeyCode = 13 Then
            xCatCode(CatCode2.Text)
            CatCode2.Focus()
        ElseIf e.KeyCode = 27 Then
            CatCode1.Clear()
            CatName1.Clear()
            CatCode2.Clear()
            CatName2.Clear()
            CatCode2.Focus()
        End If
    End Sub


    Private Sub txtCat2Code_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat2Code.KeyDown
        If e.KeyCode = 27 Then
            txtCat2Code.Clear()
            txtCat2Name.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtCat2Name.Focus()
        End If
    End Sub

    Private Sub txtCat2Code_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Code.TextChanged
        If txtCat2Code.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 order by CatCode2", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatCode2 like '" & txtCat2Code.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("CatCode2"), rdr("CatName2"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtCat2Name_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCat2Name.KeyDown
        If e.KeyCode = 27 Then
            txtCat2Code.Clear()
            txtCat2Name.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub txtCat2Name_TextChanged(sender As Object, e As EventArgs) Handles txtCat2Name.TextChanged
        If txtCat2Name.Text = "" Then
            cmd = New SqlCommand("Select * from CatLevel2 order by CatCode2", con)
        Else
            cmd = New SqlCommand("Select * from CatLevel2 where CatName2 like '%" & txtCat2Name.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("CatCode2"), rdr("CatName2"))
        End While
        rdr.Close()
    End Sub
    Private Sub xCatCode(ByRef xCat As String)
        cmd = New SqlCommand("Select * from CatLevel2 where(CatCode2='" & xCat & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            CatCode1.Text = rdr("CatCode1").ToString
            CatName1.Text = rdr("CatName1").ToString
            CatCode2.Text = rdr("CatCode2").ToString
            CatName2.Text = rdr("CatName2").ToString
            CatCode2.Focus()
        End If
        rdr.Close()
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xCatCode(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
        Panel1.Show()
        CatCode2.Focus()
    End Sub

    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xCatCode(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            CatCode2.Focus()
        ElseIf e.KeyCode = 27 Then
            txtCat2Code.Focus()
        End If
    End Sub

    Private Sub txtSupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupCode.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            SupCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupCode.TextChanged
        If txtSupCode.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active='" & 1 & "' order by SupName ", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupCode.Text & "%'and Active='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown

        If e.KeyCode = 13 Then
            xSUPID(SupCode.Text)
            SupCode.Focus()
            ' Panel1.Hide()


        ElseIf e.KeyCode = 113 Then

            Panel4.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Hide()
            txtSupCode_TextChanged(sender, EventArgs.Empty)
            txtSupCode.Focus()
        ElseIf e.KeyCode = 27 Then
            SupName.Clear()
            SupCode.Clear()
            SupCode.Focus()

        End If
    End Sub


    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
            Panel1.Show()
            SupCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active='" & 1 & "' order by SupName", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%'and Active ='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub
    Private Sub xSUPID(ByVal xSID As String)
        cmd = New SqlCommand("Select * from Supplier where(SupCode='" & xSID & "') ", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Active") = 1 Then
                SupCode.Text = rdr("SupCode").ToString
                SupName.Text = rdr("SupName").ToString
            Else
                MsgBox("Suplier Not Active Yet")
            End If

        End If
        rdr.Close()
    End Sub


   
    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        ItemCode.Clear()
        ItemName.Clear()
        CatCode1.Clear()
        CatName1.Clear()
        CatCode2.Clear()
        CatName2.Clear()
        Descrip.Clear()
        SupCode.Clear()
        SupName.Clear()
        UOM.Clear()
        CostPrice.Clear()
        SellPrice.Clear()
        WsalePr.Clear()
        CHK1.Checked = False
        OpeningBal.Clear()
        ListBox1.Items.Clear()
        ' ItemList()
        ItemCode.Focus()

        '*************************************************(Verry Important)
        Dim TestString As String = "Mid Function Demo"
        ' Returns "Mid". 
        Dim FirstWord As String = Mid(TestString, 14, 4)

        TextBox1.Text = FirstWord
        '**************************************************
        
    End Sub


    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        xSUPID(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
        SupCode.Focus()
        Panel1.Show()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.Rows.Count = 0 Then Return
            xSUPID(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
            SupCode.Focus()
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
        ElseIf e.KeyCode = 27 Then
            txtSupCode.Focus()
        End If
    End Sub

    Private Sub xITEMCD(ByVal xITCOD As String)
        cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & xITCOD & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ' ItemCode, ItemName, Cat1, Cat1Name, Cat2, Cat2Name, Description, SupCode, SupName, Uom, CostPrice, SellPrice, Inact
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            CatCode1.Text = rdr("Cat1").ToString
            CatName1.Text = rdr("Cat1Name").ToString
            CatCode2.Text = rdr("Cat2").ToString
            CatName2.Text = rdr("Cat2Name").ToString
            Descrip.Text = rdr("Description").ToString
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
            UOM.Text = rdr("Uom").ToString
            SellPrice.Text = Format(rdr("SellPrice"), "0.00").ToString
            CostPrice.Text = Format(rdr("CostPrice"), "0.00").ToString
            WsalePr.Text = rdr("WSPrice").ToString
            WsalePr.Text = Format(Val(WsalePr.Text), "0.00").ToString

            If rdr("Inact") = 1 Then
                CHK1.Checked = True
            Else
                CHK1.Checked = False
            End If
        Else
            ' ItemCode.Clear()
            ItemName.Clear()
            CatCode1.Clear()
            CatName1.Clear()
            CatCode2.Clear()
            CatName2.Clear()
            Descrip.Clear()
            SupCode.Clear()
            SupName.Clear()
            UOM.Clear()
            SellPrice.Clear()
            CostPrice.Clear()
            WsalePr.Clear()
            OpeningBal.Clear()
            CHK1.Checked = False
            ItemCode.Focus()


        End If
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        xITEMCD(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        Panel1.Show()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub GRID1_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID1.KeyDown
        If e.KeyCode = 13 Then
            If GRID1.Rows.Count = 0 Then Return
            xITEMCD(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
            Panel1.Show()
            Panel2.Hide()
            Panel3.Hide()
            Panel4.Hide()
        ElseIf e.KeyCode = 27 Then

            txtItemCode.Focus()
        End If
    End Sub

    Private Sub CostPrice_TextChanged(sender As Object, e As EventArgs) Handles CostPrice.TextChanged
        If IsNumeric(CostPrice.Text) = False Then CostPrice.Clear()
        'If Val(CostPrice.Text) > Val(SellPrice.Text) Then CostPrice.Clear()
    End Sub

    Private Sub SellPrice_TextChanged(sender As Object, e As EventArgs) Handles SellPrice.TextChanged
        If IsNumeric(SellPrice.Text) = False Then SellPrice.Clear()
        'If Val(SellPrice.Text) < Val(CostPrice.Text) Then SellPrice.Clear()
    End Sub

    Private Sub WsalePr_TextChanged(sender As Object, e As EventArgs) Handles WsalePr.TextChanged
        If IsNumeric(WsalePr.Text) = False Then WsalePr.Clear()
        'If Val(SellPrice.Text) < Val(WsalePr.Text) Then WsalePr.Text = SellPrice.Text
        'If Val(CostPrice.Text) > Val(WsalePr.Text) Then WsalePr.Text = CostPrice.Text


    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If ItemCode.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to delete this item ?", "Delete an Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            cmd = New SqlCommand("Delete from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("Delete from Stock_Main where(ItemCode='" & ItemCode.Text & "')", con)
            cmd.ExecuteNonQuery()


            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged
        'cmd1 = New SqlCommand("Select ItemCode,ItemName,SellPrice from ItemMaster where ItemCode Like'%" & ItemCode.Text & "'", con1)
        'rdr1 = cmd1.ExecuteReader
        'ListBox1.Items.Clear()
        'While rdr1.Read
        '    ListBox1.Items.Add(rdr1("ItemCode") & " - " & rdr1("ItemName") & " - " & rdr1("SellPrice"))
        'End While
        'rdr1.Close()
    End Sub


    Private Sub ItemList()
        cmd = New SqlCommand("Select ItemCode,ItemName,SellPrice from ItemMaster order by ItemCode ", con)
        rdr = cmd.ExecuteReader
        ListBox1.Items.Clear()
        While rdr.Read
            ListBox1.Items.Add(rdr("ItemCode") & " - " & rdr("ItemName") & " - " & rdr("SellPrice"))
        End While
        rdr.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ItemList()
    End Sub
End Class