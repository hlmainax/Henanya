Imports System.Data.SqlClient
Imports ConnData
Imports System.Windows.Forms.PrintDialog
Imports System.Windows.Forms.PrintPreviewDialog
Imports System.Drawing.Printing.PrintDocument
Imports POS_System.NewFunc

Public Class FrmGRN
    Dim xUNITID As String = Nothing
    Dim xAAA As Integer = 0, zAAA As Integer = 0
    Private Sub FrmGRN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim xW As Integer = Screen.PrimaryScreen.Bounds.Width + 40
        Dim xH As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = xW
        Me.Height = xH

        Me.WindowState = FormWindowState.Maximized
        Panel2.Hide()
        Panel3.Hide()
        UnitID.Text = Trim(FrmMDI.ToolStripStatusLabel2.Text)
        UNIL()
        xGRN()
        xYES = False
        CHQ1.Checked = True
        CHQ1.Checked = False
        ListItem.Hide()
        DTP1.Value = Format(Now, "yyyy-MM-dd")

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
        FrmItem.Close()
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
        'AboutBox1.Close()







        'For Each f As Form In My.Application.OpenForms
        '    If f.Name = Me.Name Then
        '    ElseIf f.Name = "FrmMDI" Then
        '    ElseIf f.Name = "FrmLoggin" Then
        '    Else
        '        f.Dispose()
        '    End If
        '    'Me.SomeListBox.Items.Add(f)
        'Next
        'xUNITID = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\TestApp\1.0", "UnitID", Nothing)
    End Sub
    Private Sub UNIL()
        cmd = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xAAA = rdr("GRN")
            GRNNo.Text = rdr("UnitID") & "GRN" & (Format(xAAA))
        End If
        rdr.Close()
    End Sub

    Private Sub FrmGRN_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
        Me.Panel2.Location = New System.Drawing.Point(((Me.Width - Panel2.Width) / 2), ((Me.Height - Panel2.Height - 100) / 2))
        Me.Panel3.Location = New System.Drawing.Point(((Me.Width - Panel3.Width) / 2), ((Me.Height - Panel3.Height - 100) / 2))
        'Me.Panel4.Location = New System.Drawing.Point(((Me.Width - Panel4.Width) / 2), ((Me.Height - Panel4.Height - 100) / 2))
    End Sub

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

    Private Sub SupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles SupCode.KeyDown
        If e.KeyCode = 113 Then
            Panel1.Hide()
            Panel2.Hide()
            Panel3.Show()
            txtSupCode_TextChanged(sender, EventArgs.Empty)
            txtSupCode.Focus()
        ElseIf e.KeyCode = 13 Then
            xSUPP(SupCode.Text)
            SupCode.Focus()

        ElseIf e.KeyCode = 27 Then
            SupCode.Clear()
            SupName.Clear()
            SupCode.Focus()

        End If
    End Sub
    Private Sub txtSupCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupCode.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtSupName.Focus()
        End If
    End Sub

    Private Sub txtSupCode_TextChanged(sender As Object, e As EventArgs) Handles txtSupCode.TextChanged
        If txtSupCode.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active ='" & 1 & "'", con)
        Else
            'cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupCode.Text & "%'and Active ='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub


    Private Sub xSUPP(ByVal xSPCD As String)
        cmd = New SqlCommand("Select * from Supplier where(SupCode='" & xSPCD & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            If rdr("Active") = 1 Then
                SupCode.Text = rdr("SupCode").ToString
                SupName.Text = rdr("SupName").ToString
            ElseIf rdr("Active") = 0 Then
                MsgBox("Supplier Not Active Yet")
            End If

        End If
        rdr.Close()
    End Sub

    Private Sub txtSupName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupName.KeyDown
        If e.KeyCode = 27 Then
            txtSupCode.Clear()
            txtSupName.Clear()
            GRID3.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID3.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtSupCode.Focus()
        End If
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier where Active ='" & 1 & "'", con)
        Else
            'cmd = New SqlCommand("Select * from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' ", con)
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%'and Active='" & 1 & "'", con)
        End If
        rdr = cmd.ExecuteReader
        GRID3.Rows.Clear()
        While rdr.Read
            GRID3.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub txtItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemCode.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemCode.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Right Then
            txtItemName.Focus()
        End If
    End Sub

   
    Private Sub txtItemCode_TextChanged(sender As Object, e As EventArgs) Handles txtItemCode.TextChanged




        If txtItemCode.Text = "" Then
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where InAct = 0 order by ItemCode ", con)
        Else
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where ItemCode like '" & txtItemCode.Text & "%' and Inact = 0 Order By ItemCode ", con)

        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()


    End Sub

    Private Sub txtItemName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtItemName.KeyDown
        If e.KeyCode = 27 Then
            txtItemCode.Clear()
            txtItemName.Clear()
            GRID2.Rows.Clear()
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            GRID2.Focus()
        ElseIf e.KeyCode = Keys.Left Then
            txtItemCode.Focus()
        End If
    End Sub

    Private Sub txtItemName_TextChanged(sender As Object, e As EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where Inact=0 order by ItemCode", con)
        Else
            cmd = New SqlCommand("Select ItemCode,ItemName from ItemMaster where ItemName like '%" & txtItemName.Text & "%'and InAct=0 order by ItemCode ", con)

        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        End While
        rdr.Close()
    End Sub

    Private Sub xITM(ByVal xITC As String)
        cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & xITC & "'and InAct=0)", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemCode.Text = rdr("ItemCode").ToString
            ItemName.Text = rdr("ItemName").ToString
            Price.Text = rdr("CostPrice").ToString
            Price.Text = Format(Val(Price.Text), "0.00").ToString
            WsPrice.Text = rdr("WSPrice").ToString
            WsPrice.Text = Format(Val(WsPrice.Text), "0.00").ToString
            SPrice.Text = rdr("SellPrice").ToString
            SPrice.Text = Format(Val(SPrice.Text), "0.00").ToString
            UOM.Text = rdr("Uom").ToString
            Price.Focus()
        End If
        rdr.Close()

    End Sub

    Private Sub ItemCode_KeyDown(sender As Object, e As KeyEventArgs) Handles ItemCode.KeyDown
        If e.KeyCode = 13 Then
            xITM(ItemCode.Text)
            ListItem.Hide()
            ' ItemCode.Focus()
        ElseIf e.KeyCode = Keys.Down Then
            If ItemCode.Text = "" Then
            Else
                'ListItem.Focus()
                'ListItem.Show()
                'ListItem.SelectedIndex = -1
                'ListItem.SelectedItem = -1

            End If

        ElseIf e.KeyCode = 27 Then
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            WsPrice.Clear()
            SPrice.Clear()
            UOM.Clear()
            Qty.Clear()
            FreeIs.Clear()
            Tot.Clear()

            ListItem.Hide()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub GRID3_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID3.CellContentDoubleClick
        xSUPP(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel1.Show()
        SupCode.Focus()
    End Sub

    Private Sub GRID3_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID3.KeyDown
        If e.KeyCode = 13 Then
            If GRID3.Rows.Count = 0 Then Return
            xSUPP(GRID3.Item(0, GRID3.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            SupCode.Focus()
        End If
    End Sub
    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
        Panel2.Hide()
        Panel3.Hide()
        Panel1.Show()
        ItemCode.Focus()
    End Sub
    Private Sub GRID2_KeyDown(sender As Object, e As KeyEventArgs) Handles GRID2.KeyDown
        If e.KeyCode = 13 Then
            If GRID2.Rows.Count = 0 Then Return
            xITM(GRID2.Item(0, GRID2.CurrentRow.Index).Value)
            Panel2.Hide()
            Panel3.Hide()
            Panel1.Show()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            txtItemCode.Focus()
        End If
    End Sub
    Private Sub Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty.KeyDown
        If e.KeyCode = 13 Then
            FreeIs.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub Qty_TextChanged(sender As Object, e As EventArgs) Handles Qty.TextChanged
        'If IsNumeric(Qty.Text) = False Then Qty.Clear()
        Tot.Text = Val(Price.Text) * Val(Qty.Text)
            Tot.Text = Format(Val(Tot.Text), "0.00")
    End Sub

    Dim rowIndes As Double = 0
    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        rowIndes = GRID1.CurrentRow.Index
        xITM(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        ListItem.Hide()
        Qty.Text = GRID1.Item(6, GRID1.CurrentRow.Index).Value
        FreeIs.Text = GRID1.Item(7, GRID1.CurrentRow.Index).Value
        Tot.Text = GRID1.Item(8, GRID1.CurrentRow.Index).Value
        GRID1.Rows.RemoveAt(GRID1.CurrentRow.Index)

        Dim xTOT As Double = 0
        Dim xSt As Double = 0
        For Each row As DataGridViewRow In GRID1.Rows
            xTOT += row.Cells(8).Value
            xSt += Val(row.Cells(4).Value) * Val(row.Cells(6).Value)
        Next
        Total.Text = xTOT
        Total.Text = Format(Val(Total.Text), "0.00")
        txtPrf.Text = xSt - xTOT
        txtPrf.Text = Format(Val(txtPrf.Text), "0.00")

    End Sub
 
    Private Sub xGRN()
        cmd = New SqlCommand("Select * from GRN_Main where(Status='" & "Pending" & "')", con)
        rdr = cmd.ExecuteReader
        GRID101.Rows.Clear()
        While rdr.Read
            GRID101.Rows.Add(rdr("GRNNo"), rdr("InvNo"), rdr("GType"))
        End While
        rdr.Close()
    End Sub
    Dim xYES As Boolean = False
    Private Sub CmdSave_Click(sender As Object, e As EventArgs) Handles CmdSave.Click
        If GRNNo.Text = "" Or GRID1.Rows.Count = 0 Or UnitID.Text = "" Or InvNo.Text = "" Then Return
       
        Dim xTT As Boolean = False
        cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "'and Status='" & "Done" & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            xTT = True
        End If
        rdr.Close()
        If xTT = True Then
            cmd1 = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con1)
            rdr1 = cmd1.ExecuteReader
            If rdr1.Read = True Then
                zAAA = rdr1("GRN")
            End If
            rdr1.Close()
            cmd1 = New SqlCommand("Update Workstation set GRN='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con1)
            cmd1.ExecuteNonQuery()
            UNIL()
        End If

        cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            'GRNNo,                                         GRNDate,                  InvNo,               UnitID,                               SupCode,                       SupName,                            Amount,                          Disc,                   NetAmnt,                                LastUpdate,                                   UpTime,                                  UName, Status

            cmd1 = New SqlCommand("Update GRN_Main set GRNDate='" & DTP1.Text & "',InvNo='" & InvNo.Text & "',UnitID='" & UnitID.Text & "',SupCode ='" & SupCode.Text & "',SupName='" & SupName.Text & "',Amount='" & Val(Total.Text) & "',Disc='" & Val(txtDisc.Text) & "',NetAmnt='" & Val(txtNET.Text) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd") & "',UpTime='" & Format(Now, "H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',Status='" & "Pending" & "',GType='" & xTYP & "'where GRNNo='" & GRNNo.Text & "'", con1)
            cmd1.ExecuteNonQuery()
            cmd1 = New SqlCommand("Delete from GRN_Sub where(GRNNo='" & GRNNo.Text & "')", con1)
            cmd1.ExecuteNonQuery()

            For i As Integer = 0 To GRID1.RowCount - 1
                '                       AutoID,                 GRNNo,                  SupCode,                 ItemCode,                  ItemName,                    UOM,                   CostPrice,                      Qty,                        FreeQty,                    Amount,                          LastUpdate,                            UName
                '                      AutoID,                    GRNNo,                  SupCode,                    ItemCode,               ItemName,                    UOM,                   CostPrice,                                                 Qty,                       FreeQty,                    Amount,                          LastUpdate,                            UName

                cmd1 = New SqlCommand("Insert GRN_Sub values('" & GRNNo.Text & "','" & SupCode.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & Val(GRID1(7, i).Value) & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(8, i).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(3, i).Value) & "')", con1)
                cmd1.ExecuteNonQuery()
            Next
        Else
            cmd1 = New SqlCommand("Insert GRN_Main values('" & GRNNo.Text & "','" & Format(Now, "yyyy-MM-dd ") & "','" & InvNo.Text & "','" & UnitID.Text & "','" & SupCode.Text & "','" & SupName.Text & "','" & Val(Total.Text) & "','" & Val(txtDisc.Text) & "','" & Val(txtNET.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "Pending" & "','" & xTYP & "')", con1)
            cmd1.ExecuteNonQuery()

            For i As Integer = 0 To GRID1.RowCount - 1
                '                       AutoID,                 GRNNo,                  SupCode,                 ItemCode,                  ItemName,                    UOM,                   CostPrice,                      Qty,                        FreeQty,                    Amount,                          LastUpdate,                            UName
                '                      AutoID,                    GRNNo,                  SupCode,                    ItemCode,               ItemName,                    UOM,                   CostPrice,                                                 Qty,                       FreeQty,                    Amount,                          LastUpdate,                            UName

                cmd1 = New SqlCommand("Insert GRN_Sub values('" & GRNNo.Text & "','" & SupCode.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & Val(GRID1(7, i).Value) & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(8, i).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(3, i).Value) & "')", con1)
                cmd1.ExecuteNonQuery()
            Next



            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""
      
            cmd1 = New SqlCommand("Select * from Workstation where(UnitID='" & UnitID.Text & "')", con1)
            rdr1 = cmd1.ExecuteReader
            If rdr1.Read = True Then
                zAAA = rdr1("GRN")
            End If
            rdr1.Close()
            cmd1 = New SqlCommand("Update Workstation set GRN='" & zAAA + 1 & "'  where(UnitID='" & UnitID.Text & "')", con1)
            cmd1.ExecuteNonQuery()
            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""


        End If
        rdr.Close()
        '++++++++++++++++++++
        xGRN()
        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub

    Private Sub CmdCancel_Click(sender As Object, e As EventArgs) Handles CmdCancel.Click
        SupCode.Clear()
        SupName.Clear()
        ItemCode.Clear()
        ItemName.Clear()
        Price.Clear()
        WsPrice.Clear()
        SPrice.Clear()
        UOM.Clear()
        UOM.Text = "UNIT"
        Qty.Clear()
        Tot.Clear()
        Total.Clear()
        FreeIs.Clear()
        InvNo.Clear()
        GRID1.Rows.Clear()
        SupCode.Focus()
        DTP1.Text = Format(Now, "yyyy-MM-dd")
        CHQ1.Checked = True
        CHQ1.Checked = False
        xYES = False
        ListItem.Hide()
        xItemfind = False
        ListItem.Items.Clear()
        rowIndes = 0
        txtPrf.Clear()
        UNIL()
    End Sub

    Private Sub Price_TextChanged(sender As Object, e As EventArgs) Handles Price.TextChanged
        If IsNumeric(Price.Text) = False Then Return
        Tot.Text = Val(Price.Text) * Val(Qty.Text)
        Tot.Text = Format(Val(Tot.Text), "0.00")
    End Sub
    Dim xItemfind As Boolean = False
    Private Sub ItemCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemCode.TextChanged
        'If ItemCode.Text = "" Then
        '    xItemfind = False
        '    ListItem.Hide()
        '    cmd3 = New SqlCommand("Select ItemCode,ItemName from ItemMaster where InAct = 0 order by ItemCode ", con3)
        'Else
        '    cmd3 = New SqlCommand("select ItemCode,ItemName from ItemMaster  where ItemCode like '%" & ItemCode.Text & "%'", con3)
        '    ' = New SqlCommand("Select * from ItemMaster where ItemCode like '" & ItemCode.Text & "%' and Inact = 0 Order By ItemCode ", con3)
        '    xItemfind = True
        'End If
        'If xItemfind = True Then
        '    ListItem.Show()
        '    rdr3 = cmd3.ExecuteReader
        '    ListItem.Items.Clear()
        '    While rdr3.Read
        '        ListItem.Items.Add(rdr3("ItemCode") & " - " & rdr3("ItemName"))
        '        'GRID2.Rows.Add(rdr("ItemCode"), rdr("ItemName"))
        '    End While
        '    rdr3.Close()
        'Else
        '    ListItem.Hide()
        'End If

    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub
    Private Sub AddPrice(ByVal itemCode As String)

    End Sub

    Private Sub FreeIs_KeyDown(sender As Object, e As KeyEventArgs) Handles FreeIs.KeyDown
        If e.KeyCode = 13 Then
            If SupCode.Text = "" Or ItemCode.Text = "" Then Return


            'Dim xAMT As Double
            'Dim RowTrue As Boolean = False, RowID As Integer = 0
            'For Each row As DataGridViewRow In GRID1.Rows
            '    If (row.Cells(0).Value = ItemCode.Text And row.Cells(2).Value = Price.Text) Then
            '        RowTrue = True : RowID = row.Index : xAMT = row.Cells(8).Value : Exit For
            '    End If
            'Next
            'If RowTrue = True Then
            '    GRID1.Rows(RowID).Cells(6).Value = Val(Qty.Text)
            '    GRID1.Rows(RowID).Cells(7).Value = Val(FreeIs.Text)
            '    GRID1.Rows(RowID).Cells(8).Value = Val(Tot.Text)
            'Else

            '    If rowIndes > 0 Then
            '        GRID1.Rows.Insert(rowIndes, ItemCode.Text, ItemName.Text, Val(Price.Text), Val(WsPrice.Text), Val(SPrice.Text), UOM.Text, Val(Qty.Text), Val(FreeIs.Text), Val(Tot.Text))
            '        GRID1.FirstDisplayedScrollingRowIndex = GRID1.RowCount - 1
            '        'Clear the last selection
            '        GRID1.ClearSelection()
            '        'Select the last row.
            '        GRID1.Rows(rowIndes).Selected = True
            '    Else

            '        GRID1.Rows.Add(ItemCode.Text, ItemName.Text, Val(Price.Text), Val(WsPrice.Text), Val(SPrice.Text), UOM.Text, Val(Qty.Text), Val(FreeIs.Text), Val(Tot.Text))
            '        GRID1.FirstDisplayedScrollingRowIndex = GRID1.RowCount - 1
            '        'Clear the last selection
            '        GRID1.ClearSelection()
            '        'Select the last row.
            '        GRID1.Rows(GRID1.RowCount - 1).Selected = True
            '    End If
            GRID1.Rows.Add(ItemCode.Text, ItemName.Text, Val(Price.Text), Val(WsPrice.Text), Val(SPrice.Text), UOM.Text, Val(Qty.Text), Val(FreeIs.Text), Val(Tot.Text))
                GRID1.FirstDisplayedScrollingRowIndex = GRID1.RowCount - 1
                'Clear the last selection
                GRID1.ClearSelection()
            'Select the last row.
            GRID1.Rows(GRID1.RowCount - 1).Selected = True
            cmd = New SqlCommand("Select * from ItemMaster where(ItemCode='" & ItemCode.Text & "')", con)
            rdr = cmd.ExecuteReader
            If rdr.Read = True Then
                'cmd1 = New SqlCommand("Update ItemMaster set ItemName='" & ItemName.Text & "',CostPrice='" & Val(Price.Text) & "',SellPrice='" & Val(SPrice.Text) & "',WSPrice='" & Val(WsPrice.Text) & "'where ItemCode='" & ItemCode.Text & "'", con1)
                'cmd1.ExecuteNonQuery()
            Else
                cmd1 = New SqlCommand("Insert ItemMaster values('" & ItemCode.Text & "','" & ItemName.Text.Replace("'", "") & "','" & "00" & "','" & "00" & "','" & "00" & "','" & "00" & "','" & "Descrip" & "','" & SupCode.Text & "','" & SupName.Text & "','" & UOM.Text & "','" & Val(Price.Text) & "','" & Val(SPrice.Text) & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "9" & "','" & Val(WsPrice.Text) & "')", con1)
                cmd1.ExecuteNonQuery()
            End If
            rdr.Close()

            '  End If
            Dim xTOT As Double = 0
            Dim xSt As Double = 0
            For Each row As DataGridViewRow In GRID1.Rows
                xTOT += row.Cells(8).Value
                xSt += Val(row.Cells(4).Value) * Val(row.Cells(6).Value)
            Next
            Total.Text = xTOT
            Total.Text = Format(Val(Total.Text), "0.00")
            txtPrf.Text = xSt - xTOT
            txtPrf.Text = Format(Val(txtPrf.Text), "0.00")
            ItemCode.Clear()
            ItemName.Clear()
            Price.Clear()
            WsPrice.Clear()
            SPrice.Clear()
            UOM.Clear()
            UOM.Text = "UNIT"
            Qty.Clear()
            FreeIs.Clear()
            Tot.Clear()
            ListItem.Hide()
            ItemCode.Focus()
        End If
      
    End Sub

    Private Sub FreeIs_TextChanged(sender As Object, e As EventArgs) Handles FreeIs.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cmd = New SqlCommand("Select * from GRN_Sub", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    Dim xQTY As Double = rdr("Qty")
        '    Dim xQTY1 As Double = rdr("FreeQty")
        '    '       AutoID,                                            ItemCode,                   ItemName,           UOM,                   CostPrice,          SellPrice,            RcvQty,                   SaleQty,       DmgQty,   RtnQty,               BalanceQty,                          PisicalQty,                           LastUpdate, UName, WsPrice
        '    cmd1 = New SqlCommand("Insert Stock_Main values('" & rdr("ItemCode") & "','" & rdr("ItemName") & "','" & rdr("UOM") & "','" & rdr("CostPrice") & "','" & 0 & "','" & xQTY + xQTY1 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & xQTY + xQTY1 & "','" & xQTY + xQTY1 & "','" & rdr("LastUpdate") & "','" & FrmMDI.UName.Text & "','" & 0 & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()
    End Sub

    Private Sub CmdSav_Click(sender As Object, e As EventArgs) Handles CmdSav.Click
        If GRNNo.Text = "" Or GRID1.Rows.Count = 0 Or UnitID.Text = "" Or InvNo.Text = "" Then Return
        If xYES = True Then
            Dim result1 As DialogResult = MessageBox.Show("All the Items,Amount and Qty Is Correct ?", "GRN Posting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If result1 = vbYes Then
                cmd = New SqlCommand("Select * from Supplier where SupCode='" & SupCode.Text & "'", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    Dim xAMT As Double = rdr("SupBalance")
                    cmd1 = New SqlCommand("Update Supplier Set SupBalance='" & xAMT + Val(Total.Text) & "'where SupCode='" & SupCode.Text & "'", con1)
                    cmd1.ExecuteNonQuery()
                End If
                rdr.Close()
                For i As Integer = 0 To GRID1.RowCount - 1
                    cmd1 = New SqlCommand("Update ItemMaster set SellPrice='" & Val(GRID1(4, i).Value) & "',WSPrice='" & Val(GRID1(3, i).Value) & "'where ItemCode='" & GRID1(0, i).Value & "'", con1)
                    cmd1.ExecuteNonQuery()
                    cmd = New SqlCommand("Select * From ItemMaster where ItemCode='" & GRID1(0, i).Value & "'", con)
                    rdr = cmd.ExecuteReader
                    If rdr.Read = True Then
                        xCPRICE = rdr("CostPrice").ToString
                        xSPRICE = rdr("SellPrice").ToString
                    End If
                    rdr.Close()
                    '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~`
                    'Stock Update New===>>>>>>>>>>>
                    cmd = New SqlCommand("Select * from Stock_Main where ItemCode='" & GRID1(0, i).Value & "'and SellPrice='" & Val(GRID1(4, i).Value) & "'", con)
                    rdr = cmd.ExecuteReader
                    If rdr.Read = True Then
                        If rdr("CostPrice") = Val(GRID1(2, i).Value) Then
                            cmd1 = New SqlCommand("Update Stock_Main Set RcvQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',BalanceQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',PisicalQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',SellPrice='" & Val(GRID1(4, i).Value) & "'where ItemCode='" & GRID1(0, i).Value & "'and SellPrice='" & GRID1(4, i).Value & "'", con1)
                            cmd1.ExecuteNonQuery()
                        ElseIf rdr("CostPrice") <> Val(GRID1(2, i).Value) Then

                            Dim CurrentQty As Double = rdr("BalanceQty")
                            Dim CurrentCostValue As Double = rdr("CostPrice") * CurrentQty
                            Dim NewQty As Double = Val(GRID1(6, i).Value)
                            Dim NewCost As Double = Val(GRID1(2, i).Value)
                            Dim NewCostVal As Double = NewQty * NewCost

                            Dim NewQtyTotalValue As Double = CurrentCostValue + NewCostVal
                            Dim NewTotalQty As Double = CurrentQty + NewQty
                            Dim NewCostPrice As Double = NewQtyTotalValue / NewTotalQty

                            cmd1 = New SqlCommand("Update Stock_Main Set RcvQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',BalanceQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',PisicalQty+='" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',CostPrice='" & NewCostPrice & "',SellPrice='" & Val(GRID1(4, i).Value) & "'where ItemCode='" & GRID1(0, i).Value & "'and SellPrice='" & GRID1(4, i).Value & "'", con1)
                            cmd1.ExecuteNonQuery()
                            cmd1 = New SqlCommand("Update ItemMaster set CostPrice='" & NewCostPrice & "',SellPrice='" & Val(GRID1(4, i).Value) & "',WSPrice='" & Val(GRID1(3, i).Value) & "'where ItemCode='" & GRID1(0, i).Value & "'", con1)
                            cmd1.ExecuteNonQuery()
                        End If

                    Else
                        '                             AutoID,                ItemCode,                   ItemName,                   UOM,                       CostPrice,                        SellPrice,                             RcvQty,                                              SaleQty,    DmgQty,     RtnQty,                          BalanceQty,                                                  PisicalQty,                                      LastUpdate,                         UName,                       WsPrice
                        cmd1 = New SqlCommand("Insert Stock_Main values('" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(4, i).Value) & "','" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "','" & 0 & "','" & 0 & "','" & 0 & "','" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "','" & (Val(GRID1(6, i).Value) + Val(GRID1(7, i).Value)) & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(GRID1(3, i).Value) & "','" & "NON" & "')", con1)
                        cmd1.ExecuteNonQuery()
                    End If
                    rdr.Close()
                    '===========>>>>>>>>
                    '    'Stock Update.....................................................................
                    '    cmd = New SqlCommand("Select * from Stock_Main where ItemCode='" & GRID1(0, i).Value & "'and CostPrice='" & xCPRICE & "'", con)
                    '    rdr = cmd.ExecuteReader
                    '    If rdr.Read = True Then
                    '        Dim xBLQTY As Double = rdr("BalanceQty").ToString
                    '        Dim xPCQty As Double = rdr("PisicalQty").ToString
                    '        Dim xRQTY As Double = Val(GRID1(6, i).Value)
                    '        Dim xFQTY As Double = Val(GRID1(7, i).Value)
                    '        Dim xWSP As Double = Val(GRID1(3, i).Value)
                    '        cmd1 = New SqlCommand("Update Stock_Main Set RcvQty='" & xRQTY + xFQTY + rdr("RcvQty") & "',BalanceQty='" & xBLQTY + xRQTY + xFQTY & "',PisicalQty='" & xPCQty + xRQTY + xFQTY & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',WsPrice='" & xWSP & "'where ItemCode='" & GRID1(0, i).Value & "'and CostPrice='" & xCPRICE & "'", con1)
                    '        cmd1.ExecuteNonQuery()
                    '    Else
                    '        Dim xRQTY As Double = Val(GRID1(6, i).Value)
                    '        Dim xFQTY As Double = Val(GRID1(7, i).Value)
                    '        Dim xWSP As Double = Val(GRID1(3, i).Value)
                    '        Dim NewCost As Double = Val(GRID1(2, i).Value)
                    '        Dim NewQty As Double = Val(GRID1(6, i).Value)
                    '        Dim NewValue As Double = Val(GRID1(2, i).Value) * Val(GRID1(6, i).Value)
                    '        '                             AutoID,                ItemCode,                   ItemName,                   UOM,                 CostPrice,               SellPrice,           RcvQty,                 SaleQty,    DmgQty,     RtnQty,      BalanceQty,                 PisicalQty,                LastUpdate,                                      UName,         WsPrice
                    '        cmd1 = New SqlCommand("Insert Stock_Main values('" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & xCPRICE & "','" & xSPRICE & "','" & xRQTY + xFQTY & "','" & 0 & "','" & 0 & "','" & 0 & "','" & xRQTY + xFQTY & "','" & xRQTY + xFQTY & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & xWSP & "','" & xTYP & "')", con1)
                    '        cmd1.ExecuteNonQuery()
                    '    End If
                    '    rdr.Close()
                Next
                '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2
                cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
                rdr = cmd.ExecuteReader
                If rdr.Read = True Then
                    'GRNNo,                                         GRNDate,                  InvNo,               UnitID,                               SupCode,                       SupName,                            Amount,                          Disc,                   NetAmnt,                                LastUpdate,                                   UpTime,                                  UName, Status

                    cmd1 = New SqlCommand("Update GRN_Main set GRNDate='" & DTP1.Text & "',InvNo='" & InvNo.Text & "',UnitID='" & UnitID.Text & "',SupCode ='" & SupCode.Text & "',SupName='" & SupName.Text & "',Amount='" & Val(Total.Text) & "',Disc='" & Val(txtDisc.Text) & "',NetAmnt='" & Val(txtNET.Text) & "',LastUpdate='" & Format(Now, "yyyy-MM-dd") & "',UpTime='" & Format(Now, "H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "',Status='" & "Pending" & "',GType='" & xTYP & "'where GRNNo='" & GRNNo.Text & "'", con1)
                    cmd1.ExecuteNonQuery()

                    cmd1 = New SqlCommand("Delete from GRN_Sub where(GRNNo='" & GRNNo.Text & "')", con1)
                    cmd1.ExecuteNonQuery()

                    For i As Integer = 0 To GRID1.RowCount - 1
                        '                       AutoID,                 GRNNo,                  SupCode,                 ItemCode,                  ItemName,                    UOM,                   CostPrice,                      Qty,                        FreeQty,                    Amount,                          LastUpdate,                            UName
                        '                      AutoID,                    GRNNo,                  SupCode,                    ItemCode,               ItemName,                    UOM,                   CostPrice,                                                 Qty,                       FreeQty,                    Amount,                          LastUpdate,                            UName

                        cmd1 = New SqlCommand("Insert GRN_Sub values('" & GRNNo.Text & "','" & SupCode.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & Val(GRID1(7, i).Value) & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(8, i).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(3, i).Value) & "')", con1)
                        cmd1.ExecuteNonQuery()
                    Next
                Else
                    cmd1 = New SqlCommand("Insert GRN_Main values('" & GRNNo.Text & "','" & Format(Now, "yyyy-MM-dd ") & "','" & InvNo.Text & "','" & UnitID.Text & "','" & SupCode.Text & "','" & SupName.Text & "','" & Val(Total.Text) & "','" & Val(txtDisc.Text) & "','" & Val(txtNET.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & "Pending" & "','" & xTYP & "')", con1)
                    cmd1.ExecuteNonQuery()

                    For i As Integer = 0 To GRID1.RowCount - 1
                        '                       AutoID,                 GRNNo,                  SupCode,                 ItemCode,                  ItemName,                    UOM,                   CostPrice,                      Qty,                        FreeQty,                    Amount,                          LastUpdate,                            UName
                        '                      AutoID,                    GRNNo,                  SupCode,                    ItemCode,               ItemName,                    UOM,                   CostPrice,                                                 Qty,                       FreeQty,                    Amount,                          LastUpdate,                            UName

                        cmd1 = New SqlCommand("Insert GRN_Sub values('" & GRNNo.Text & "','" & SupCode.Text & "','" & GRID1(0, i).Value & "','" & GRID1(1, i).Value & "','" & GRID1(5, i).Value & "','" & Val(GRID1(7, i).Value) & "','" & Val(GRID1(2, i).Value) & "','" & Val(GRID1(6, i).Value) & "','" & Val(GRID1(8, i).Value) & "','" & Format(Now, "yyyy-MM-dd") & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "','" & Val(GRID1(4, i).Value) & "','" & Val(GRID1(3, i).Value) & "')", con1)
                        cmd1.ExecuteNonQuery()
                    Next
                End If
                rdr.Close()
                cmd = New SqlCommand("Update GRN_Main set Status='" & "Done" & "'where GRNNo='" & GRNNo.Text & "'", con)
                cmd.ExecuteNonQuery()

                '                                                    SupCode,           SupName,                    GrnDate,           Descp,                GrnAmnt,          PayDate,               Descr,       PayAmnt
                cmd1 = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & DTP1.Value & "','" & "GRN" & "','" & Val(txtNET.Text) & "','" & DTP1.Value & "','" & "-" & "','" & 0 & "')", con1)
                cmd1.ExecuteNonQuery()
                MessageBox.Show("GRN Post Succeed.", "GRN Posting", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
            ElseIf xYES = False Then

            End If
       


        xGRN()
        CmdCancel_Click(sender, EventArgs.Empty)

    End Sub
    Dim xCPRICE As Double = 0
    Dim xSPRICE As Double = 0
  
    Private Sub GRID101_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID101.CellContentDoubleClick
        GRNNo.Text = GRID101.Item(0, GRID101.CurrentRow.Index).Value
        InvNo.Text = GRID101.Item(1, GRID101.CurrentRow.Index).Value
        cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            DTP1.Text = rdr("GRNDate")
            SupCode.Text = rdr("SupCode")
            SupName.Text = rdr("SupName")
            Total.Text = rdr("Amount").ToString
            Total.Text = Format(Val(Total.Text), "0.00")
            txtDisc.Text = rdr("Disc").ToString
            txtDisc.Text = Format(Val(txtDisc.Text), "0.00")
            txtNET.Text = rdr("NetAmnt").ToString
            txtNET.Text = Format(Val(txtNET.Text), "0.00")
            If rdr("GType") = "Veg" Then
                CHQ1.Checked = True
            ElseIf rdr("GType") <> "Veg" Then
                CHQ1.Checked = False
            End If
        End If
        rdr.Close()
        cmd = New SqlCommand("Select * from GRN_Sub where(GRNNo='" & GRNNo.Text & "')", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            'cmd1 = New SqlCommand("Select * From ItemMaster where ItemCode='" & rdr("ItemCode") & "'", con1)
            'rdr1 = cmd1.ExecuteReader
            'If rdr1.Read = True Then
            '    xCPRICE = rdr1("WSPrice").ToString
            '    xSPRICE = rdr1("SellPrice").ToString
            'End If
            'rdr1.Close()
            GRID1.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("CostPrice"), rdr("WsPrice"), rdr("SellPrice"), rdr("UOM"), rdr("Qty"), rdr("FreeQTY"), Format(rdr("Amount"), "0.00"))

        End While
        rdr.Close()

        xYES = True

        Dim xTOT As Double = 0
        Dim xSt As Double = 0
        For Each row As DataGridViewRow In GRID1.Rows
            xTOT += row.Cells(8).Value
            xSt += Val(row.Cells(4).Value) * Val(row.Cells(6).Value)
        Next
        Total.Text = xTOT
        Total.Text = Format(Val(Total.Text), "0.00")
        txtPrf.Text = xSt - xTOT
        txtPrf.Text = Format(Val(txtPrf.Text), "0.00")


    End Sub

    Private Sub Total_TextChanged(sender As Object, e As EventArgs) Handles Total.TextChanged
        txtNET.Text = Val(Total.Text) - Val(txtDisc.Text)
        txtNET.Text = Format(Val(txtNET.Text), "0.00")
    End Sub

    Private Sub txtDisc_TextChanged(sender As Object, e As EventArgs) Handles txtDisc.TextChanged
        txtNET.Text = Val(Total.Text) - Val(txtDisc.Text)
        txtNET.Text = Format(Val(txtNET.Text), "0.00")
    End Sub

    Private Sub GRID101_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID101.CellContentClick

    End Sub
    Dim xTYP As String = Nothing

    Private Sub ListItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListItem.SelectedIndexChanged

    End Sub

    Private Sub CHQ1_CheckedChanged(sender As Object, e As EventArgs) Handles CHQ1.CheckedChanged
        If CHQ1.Checked = True Then
            xTYP = "Veg"
        ElseIf CHQ1.Checked = False Then
            xTYP = "NonVeg"
        End If
    End Sub

    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub

    Private Sub ListItem_KeyDown(sender As Object, e As KeyEventArgs) Handles ListItem.KeyDown
        If e.KeyCode = 13 Then
            If ListItem.SelectedItem = "" Then Return
            Dim oItemCode As String = ListItem.SelectedItem
            Dim first_word As String = oItemCode.Split(" ")(0)
            ItemCode.Text = first_word
            xITM(ItemCode.Text)
            ListItem.Hide()
            ItemCode.Focus()
        ElseIf e.KeyCode = 27 Then
            ListItem.Items.Clear()
            ListItem.Hide()
            ItemCode.Focus()
        End If
    End Sub

    Private Sub InvNo_TextChanged(sender As Object, e As EventArgs) Handles InvNo.TextChanged

    End Sub

    Private Sub SupCode_MouseClick(sender As Object, e As MouseEventArgs) Handles SupCode.MouseClick
        Panel1.Hide()
        Panel2.Hide()
        Panel3.Show()
        txtSupCode_TextChanged(sender, EventArgs.Empty)
        txtSupCode.Focus()
    End Sub

    Private Sub InvNo_GotFocus(sender As Object, e As EventArgs) Handles InvNo.GotFocus
        InvNo.BackColor = Color.Yellow
    End Sub

    Private Sub InvNo_LostFocus(sender As Object, e As EventArgs) Handles InvNo.LostFocus
        InvNo.BackColor = Color.Aquamarine
    End Sub

    Private Sub SupCode_GotFocus(sender As Object, e As EventArgs) Handles SupCode.GotFocus
        SupCode.BackColor = Color.Yellow
    End Sub

    Private Sub SupCode_LostFocus(sender As Object, e As EventArgs) Handles SupCode.LostFocus
        SupCode.BackColor = Color.White
    End Sub

    Private Sub WsPrice_TextChanged(sender As Object, e As EventArgs) Handles WsPrice.TextChanged

    End Sub

    Private Sub Price_KeyDown(sender As Object, e As KeyEventArgs) Handles Price.KeyDown
        If e.KeyCode = 13 Then
            WsPrice.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub SPrice_TextChanged(sender As Object, e As EventArgs) Handles SPrice.TextChanged

    End Sub

    Private Sub WsPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles WsPrice.KeyDown
        If e.KeyCode = 13 Then
            SPrice.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub SPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles SPrice.KeyDown
        If e.KeyCode = 13 Then
            Qty.Focus()
        ElseIf e.KeyCode = 27 Then
            ItemCode.Focus()
        End If
    End Sub

    Private Sub ItemCode_GotFocus(sender As Object, e As EventArgs) Handles ItemCode.GotFocus
        ItemCode.BackColor = Color.Yellow
    End Sub

    Private Sub ItemCode_LostFocus(sender As Object, e As EventArgs) Handles ItemCode.LostFocus
        ItemCode.BackColor = Color.White
    End Sub

    Private Sub Price_GotFocus(sender As Object, e As EventArgs) Handles Price.GotFocus
        Price.BackColor = Color.Yellow
    End Sub

    Private Sub Price_LostFocus(sender As Object, e As EventArgs) Handles Price.LostFocus
        Price.BackColor = Color.White
    End Sub

    Private Sub WsPrice_GotFocus(sender As Object, e As EventArgs) Handles WsPrice.GotFocus
        WsPrice.BackColor = Color.Yellow
    End Sub

    Private Sub WsPrice_LostFocus(sender As Object, e As EventArgs) Handles WsPrice.LostFocus
        WsPrice.BackColor = Color.White
    End Sub

    Private Sub SPrice_GotFocus(sender As Object, e As EventArgs) Handles SPrice.GotFocus
        SPrice.BackColor = Color.Yellow
    End Sub

    Private Sub SPrice_LostFocus(sender As Object, e As EventArgs) Handles SPrice.LostFocus
        SPrice.BackColor = Color.White
    End Sub

    Private Sub FreeIs_GotFocus(sender As Object, e As EventArgs) Handles FreeIs.GotFocus
        FreeIs.BackColor = Color.Yellow
    End Sub

    Private Sub FreeIs_LostFocus(sender As Object, e As EventArgs) Handles FreeIs.LostFocus
        FreeIs.BackColor = Color.White
    End Sub

    Private Sub txtDisc_GotFocus(sender As Object, e As EventArgs) Handles txtDisc.GotFocus
        txtDisc.BackColor = Color.Yellow
    End Sub

    Private Sub txtDisc_LostFocus(sender As Object, e As EventArgs) Handles txtDisc.LostFocus
        txtDisc.BackColor = Color.White
    End Sub

    Private Sub txtSupCode_GotFocus(sender As Object, e As EventArgs) Handles txtSupCode.GotFocus
        txtSupCode.BackColor = Color.Yellow
    End Sub

    Private Sub txtSupCode_LostFocus(sender As Object, e As EventArgs) Handles txtSupCode.LostFocus
        txtSupCode.BackColor = Color.White
    End Sub

    Private Sub txtSupName_GotFocus(sender As Object, e As EventArgs) Handles txtSupName.GotFocus
        txtSupName.BackColor = Color.Yellow
    End Sub

    Private Sub txtSupName_LostFocus(sender As Object, e As EventArgs) Handles txtSupName.LostFocus
        txtSupName.BackColor = Color.White
    End Sub

    Private Sub ListItem_DoubleClick(sender As Object, e As EventArgs) Handles ListItem.DoubleClick

    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If GRNNo.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to delete this GRN ?", "GRN Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            '  cmd = New SqlCommand("Select * from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
            cmd = New SqlCommand("Delete from GRN_Main where(GRNNo='" & GRNNo.Text & "')", con)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("Delete from GRN_Sub where(GRNNo='" & GRNNo.Text & "')", con)
            cmd.ExecuteNonQuery()
            MessageBox.Show("GRN Delete Succeed.", "GRN Delete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            xGRN()
            CmdCancel_Click(sender, e)

        End If


    End Sub

    Private Sub ItemName_TextChanged(sender As Object, e As EventArgs) Handles ItemName.TextChanged

    End Sub

    Private Sub ListItem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListItem.MouseDoubleClick
        If ListItem.SelectedItem = "" Then Return
        Dim oItemCode As String = ListItem.SelectedItem
        Dim first_word As String = oItemCode.Split(" ")(0)
        ItemCode.Text = first_word
        xITM(ItemCode.Text)
        ListItem.Hide()
        ItemCode.Focus()
    End Sub
End Class