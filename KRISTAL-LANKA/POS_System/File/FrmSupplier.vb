Imports System.Data.SqlClient
Imports ConnData
Public Class FrmSupplier
   
    Private Sub FrmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height

        Me.WindowState = FormWindowState.Maximized
        SupBalance.Enabled = True
        CHQ1.Checked = False
        DTP1.Value = Format(Now, "yyyy-MM-dd")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        Gridstdload()
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
        ' FrmSupplier.Close()
        FrmSupplierRTN.Close()
        FrmUOP.Close()

        FrmUserControl.Close()
        'AboutBox1.Close()
    End Sub

    Private Sub CmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSave.Click
        If SupCode.Text = "" Or SupName.Text = "" Or SupAdd.Text = "" Or SupMobi.Text = "" Or SupOff.Text = "" Then
            MsgBox("Please fill the all feilds")
            Return
        Else
            cmd1 = New SqlCommand("Select * from Supplier where(SupCode='" & SupCode.Text & "')", con1)
            rdr1 = cmd1.ExecuteReader
            If rdr1.Read = True Then
                Dim result1 As DialogResult = MessageBox.Show("Do you want to Update the Current Supplier Details ?", "Update the Current Supplier Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If result1 = vbYes Then
                    '                           SupCode,        SupName,                        Address,                            SupMobi,                        SupOff,              SupMail,                    Remarks,                               SupBalance                           Active,                  LastUpdate                                      UName
                    cmd = New SqlCommand("update Supplier set SupName='" & SupName.Text & "',Address='" & SupAdd.Text & "',SupMobi='" & SupMobi.Text & "',SupOff='" & SupOff.Text & "',SupMail='" & SupMail.Text & "',Remarks='" & Remarks.Text & "',SupBalance='" & SupBalance.Text & "',Active='" & sACT & "',LastUpdate='" & Format(Now, "yyyy-MM-dd H:mm:ss") & "',UName='" & FrmMDI.UName.Text & "'where SupCode='" & SupCode.Text & "'", con)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Supplier Details Update Succeed.", "Supplier Details Updating", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Else
                Dim result1 As DialogResult = MessageBox.Show("Do you want to Add New Supplier ?", "Add New Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If result1 = vbYes Then
                    '                                                   SupCode,                SupName,             Address,                SupMobi,               SupOff,              SupMail,                Remarks,               SupBalance,              Active,                LastUpdate,                              UName
                    cmd = New SqlCommand("insert Supplier values ('" & SupCode.Text & "','" & SupName.Text & "','" & SupAdd.Text & "','" & SupMobi.Text & "','" & SupOff.Text & "','" & SupMail.Text & "','" & Remarks.Text & "','" & SupBalance.Text & "','" & sACT & "','" & Format(Now, "yyyy-MM-dd H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Add New Supplier Succeed.", "Add New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            End If



            ' SupCode, SupName, GrnDate, Descp, GrnAmnt, PayDate, Descr, PayAmnt
            'SupState
            cmd = New SqlCommand("Select count(SupCode) from SupState where(SupCode='" & SupCode.Text & "')", con)
            Dim xNu As Integer = 0
            xNu = cmd.ExecuteScalar
            If xNu = 0 Then
                If Val(SupBalance.Text) > 0 Then
                    '                                                   SupCode,                 SupName,                        GrnDate,                   Descp,                  GrnAmnt,                    PayDate,                        Descr,  PayAmnt
                    cmd = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & Format(Now, "yyyy-MM-dd") & "','" & "Opening Bal" & "','" & Val(SupBalance.Text) & "','" & Format(Now, "yyyy-MM-dd") & "','" & "-" & "','" & 0 & "')", con)
                    cmd.ExecuteNonQuery()
                End If
            ElseIf xNu > 0 Then
                cmd = New SqlCommand("Select count(Descp) from SupState where(SupCode='" & SupCode.Text & "'and Descp='" & "Opening Bal" & "' )", con)
                Dim xDWscrip As Integer = cmd.ExecuteScalar

                If xDWscrip > 0 Then
                ElseIf xDWscrip = 0 Then
                    '                                                   SupCode,                 SupName,                        GrnDate,                   Descp,                  GrnAmnt,                    PayDate,                        Descr,  PayAmnt
                    cmd = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & DTP1.Value & "','" & "Opening Bal" & "','" & Val(SupBalance.Text) & "','" & DTP1.Value & "','" & "-" & "','" & 0 & "')", con)
                    cmd.ExecuteNonQuery()
                End If
            End If

            Gridstdload()
            CmdCancel_Click(sender, EventArgs.Empty)
            rdr1.Close()
            SupBalance.Enabled = True
        End If
    End Sub
    Private Sub CmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancel.Click
        SupCode.Clear()
        SupName.Clear()
        SupAdd.Clear()
        SupMobi.Clear()
        SupOff.Clear()
        SupMail.Clear()
        Remarks.Clear()
        sACT = 1
        SupBalance.Clear()
        CHQ1.Checked = False
        SupBalance.Enabled = True
        SupCode.Focus()
        SupCode.ReadOnly = False
        DTP1.Value = Format(Now, "yyyy-MM-dd")
    End Sub

    Private Sub Gridstdload()
        ' cmd = New SqlCommand("Select * from ItemMaster ORDER BY cast(ItemCode as Int)ASC", con)
        cmd = New SqlCommand("select * from Supplier order by cast(SupCode as Int)ASC", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
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
    Private Sub FrmSupplier_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
    End Sub


    Private Sub SupCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SupCode.KeyDown
        If e.KeyCode = 13 Then
            If SupCode.Text = "" Then Return
            xSupCode(SupCode.Text)
        ElseIf e.KeyCode = 27 Then
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub

    Private Sub GRID1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellDoubleClick
        'cmd = New SqlCommand("select * from Supplier where(SupCode='" & GRID1.Item(0, GRID1.CurrentRow.Index).Value & "')", con)
        xSupCode(GRID1.Item(0, GRID1.CurrentRow.Index).Value)
        SupCode.Focus()

    End Sub
    Private Sub xSupCode(ByVal xSup As String)
        cmd = New SqlCommand("select * from Supplier where(SupCode='" & xSup & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            SupCode.Text = rdr("SupCode").ToString
            SupName.Text = rdr("SupName").ToString
            SupAdd.Text = rdr("Address").ToString
            SupMobi.Text = rdr("SupMobi").ToString
            SupOff.Text = rdr("SupOff").ToString
            SupMail.Text = rdr("SupMail").ToString
            Remarks.Text = rdr("Remarks").ToString
            SupBalance.Text = Format(rdr("SupBalance"), "0.00")
            If rdr("Active") = 0 Then
                CHQ1.Checked = True
            ElseIf rdr("Active") = 1 Then
                CHQ1.Checked = False
            End If
            'SupCode.ReadOnly = True
            'SupBalance.Enabled = False
        End If
        rdr.Close()
    End Sub

    Private Sub SupMobi_TextChanged(sender As Object, e As EventArgs) Handles SupMobi.TextChanged
        If IsNumeric(SupMobi.Text) = False Then SupMobi.Clear()
    End Sub

    Private Sub SupOff_TextChanged(sender As Object, e As EventArgs) Handles SupOff.TextChanged
        If IsNumeric(SupOff.Text) = False Then SupOff.Clear()
    End Sub

    Private Sub txtSupID_TextChanged(sender As Object, e As EventArgs) Handles txtSupID.TextChanged
        If txtSupID.Text = "" Then
            cmd = New SqlCommand("select * from Supplier order by cast(SupCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupCode like '" & txtSupID.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
        'SELECT Name FROM Person WHERE Name LIKE '%Jon%'
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("select * from Supplier order by cast(SupCode as Int)ASC", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Dim sACT As Integer = 1
    Private Sub CHQ1_CheckedChanged(sender As Object, e As EventArgs) Handles CHQ1.CheckedChanged
        If CHQ1.Checked = True Then
            sACT = 0
        ElseIf CHQ1.Checked = False Then
            sACT = 1
        End If
    End Sub

    Private Sub SupCode_TextChanged(sender As Object, e As EventArgs) Handles SupCode.TextChanged

    End Sub

    Private Sub BtnAdjust_Click(sender As Object, e As EventArgs) Handles BtnAdjust.Click
        If SupCode.Text = "" Or SupName.Text = "" Then Return
        Dim result1 As DialogResult = MessageBox.Show("Do you want to Adjust the Supplier Current Balance ?", "Adjust the Supplier Current Balance", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If result1 = vbYes Then
            Dim ccr As Double = 0
            Dim cdr As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(GrnAmnt),0)from SupState where SupCode='" & SupCode.Text & "'", con)
            ccr = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(PayAmnt),0)from SupState where SupCode='" & SupCode.Text & "'", con)
            cdr = cmd.ExecuteScalar
            Dim cusBal As Double = 0
            cusBal = ccr - cdr

            Dim curBal As Double = 0
            If Val(SupBalance.Text) > cusBal Then
                curBal = Val(SupBalance.Text) - cusBal
                '                                                       CusCode,            CusName,              InvDate,                      Descp,               InvAmnt,                RcvDate,               Descr,      RcvAmnt
                cmd = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & DateTime.Now.Date & "','" & "Debit Adjustment" & "','" & curBal & "','" & DateTime.Now.Date & "','" & "-" & "','" & 0 & "')", con)
                cmd.ExecuteNonQuery()


            ElseIf cusBal > Val(SupBalance.Text) Then
                curBal = cusBal - Val(SupBalance.Text)
                'CusCode, CusName, InvDate, Descp, InvAmnt, RcvDate, Descr, RcvAmnt
                cmd = New SqlCommand("Insert SupState values('" & SupCode.Text & "','" & SupName.Text & "','" & DateTime.Now.Date & "','" & "-" & "','" & 0 & "','" & DateTime.Now.Date & "','" & "Credit Adjustment" & "','" & curBal & "')", con)
                cmd.ExecuteNonQuery()

            End If
            'Aid,                                           BName,                      Description,                     Debit,         Credit,                             LastUpdate,                 UpTime,                          UName
            cmd = New SqlCommand("Insert BalAd values('" & SupName.Text & "','" & "Supplier Balance Adjusted" & "','" & cusBal & "','" & Val(SupBalance.Text) & "','" & DateTime.Now.Date & "','" & Format(Now, "H:mm:ss") & "','" & FrmMDI.UName.Text & "')", con)
            cmd.ExecuteNonQuery()

            '         CusCode,                                          CusName,              
            cmd1 = New SqlCommand("Update Supplier Set SupBalance='" & SupBalance.Text & "'where SupCode='" & SupCode.Text & "'", con1)
            cmd1.ExecuteNonQuery()
            MessageBox.Show("Supplier Balance Adjust Succeed.", "Supplier Balance Adjust", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            CmdCancel_Click(sender, EventArgs.Empty)
        End If
    End Sub
End Class