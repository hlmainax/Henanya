
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports ConnData
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer
Imports CrystalDecisions.Shared
Imports Microsoft.Win32
Imports POS_System.NewFunc
Imports Table = CrystalDecisions.CrystalReports.Engine.Table

Public Class FrmRpts
    Dim xSERVER As String = Nothing
    Dim xPW As String = Nothing
    Private Sub GridLd()
        cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
        cmd = New SqlCommand("Select * from Supplier order by SupName", con)
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
        xAcountLoad(CmbAccount)
    End Sub
    Private Sub FrmRpts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'xSERVER = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Henanya\1.0", "Server", Nothing)
        'xPW = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Henanya\1.0", "DatabasePw", Nothing)
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Maximized
        DTP1.Value = Format(Now, "yyyy-MM-dd")
        DTP2.Value = Format(Now, "yyyy-MM-dd")
        GridLd()
        Me.ControlBox = False
        xBANK()
        ItemLoad()
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
        'FrmRpts.Close()
        FrmRtn.Close()
        FrmSALESRE.Close()
        FrmSTCKENTER.Close()
        FrmSupPament.Close()
        FrmSupplier.Close()
        FrmSupplierRTN.Close()
        FrmUOP.Close()
        FrmUserControl.Close()
        Panel1.Width = Me.Width - 50
        Panel1.Width = Me.Height - 75

        'AboutBox1.Close()
    End Sub
    Private Sub xBANK()
        cmd = New SqlCommand("Select * from Bank_Main ", con)
        rdr = cmd.ExecuteReader
        CmbAccount1.Items.Clear()
        While rdr.Read
            CmbAccount1.Items.Add(rdr("AccNo") & " - " & rdr("BankName"))
        End While
        rdr.Close()
    End Sub
    Private Sub ItemLoad()
        'cmd = New SqlCommand("Select Distinct * from Inv_Sub ", con)
        'rdr = cmd.ExecuteReader
        'CmbItem.Items.Clear()
        'While rdr.Read
        '    CmbItem.Items.Add(rdr("ItemCode") & " - " & rdr("ItemName"))
        'End While
        'rdr.Close()
    End Sub



    Private Function xCRINFO(ByVal xRPT As ReportClass)

        Dim xSERVER As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Henanya\1.0", "Server", Nothing)
        Dim xPW As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Henanya\1.0", "DatabasePw", Nothing)
        xRPT.DataSourceConnections.Clear()
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table
        With crConnectionInfo
            .ServerName = xSERVER
            .DatabaseName = "Henanya"
            .UserID = "sa"
            .Password = xPW
        End With
        CrTables = xRPT.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        Return xRPT
    End Function

    Private Sub FrmRpts_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Panel1.Location = New System.Drawing.Point(((Me.Width - Panel1.Width) / 2), ((Me.Height - Panel1.Height - 100) / 2))
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim RptCus As New RPT1
        '  RptRaw.RecordSelectionFormula = " {Raw_Collect.ColDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Raw_Collect.ColDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Farmer_Master.FrmRout}='" & CmbRoute.Text & "'"
        'RptSALE.Load()
        xCRINFO(RptCus)
        CrystalReportViewer1.ReportSource = RptCus
        'CrystalReportViewer1.Zoom(1)
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim RptSup As New RPT2
        Dim xGN As Double = 0
        Dim xPay As Double = 0

        '  RptRaw.RecordSelectionFormula = " {Raw_Collect.ColDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Raw_Collect.ColDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Farmer_Master.FrmRout}='" & CmbRoute.Text & "'"
        'RptSALE.Load()
        xCRINFO(RptSup)
        CrystalReportViewer1.ReportSource = RptSup
        'CrystalReportViewer1.Zoom(1)
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim RptItm As New RPT3
        xCRINFO(RptItm)
        CrystalReportViewer1.ReportSource = RptItm
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Return
        Dim report3 As New RptDaySummerya
        'Dim xCASH As Double = 0
        'Dim xCRD As Double = 0
        'Dim xCOLLEC As Double = 0
        'Dim xCHQ As Double = 0
        'Dim xCHQRC As Double = 0
        'Dim xSPAY As Double = 0
        'Dim xEXP As Double = 0


        'cmd = New SqlCommand("Select count(INVNo) from Inv_Main where(InvType='" & "CASH" & "'and LastUpdate='" & DTP1.Value & "')", con)
        'Dim xINT As Integer = 0
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(InvType='" & "CASH" & "'and LastUpdate='" & DTP1.Value & "')", con)
        '    xCASH = cmd.ExecuteScalar
        'End If
        'xINT = 0

        'cmd = New SqlCommand("Select count(INVNo) from Inv_Main where(InvType='" & "CREDIT" & "'and LastUpdate='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(InvType='" & "CREDIT" & "'and LastUpdate='" & DTP1.Value & "')", con)
        '    xCASH = cmd.ExecuteScalar
        'End If
        'xINT = 0

        'cmd = New SqlCommand("Select count(RcptNo) from Receipt_Main where(RcvDT='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(RcvAmt) from Receipt_Main where(RcvDT='" & DTP1.Value & "')", con)
        '    xCOLLEC = cmd.ExecuteScalar
        'End If
        'xINT = 0

        'cmd = New SqlCommand("Select count(PayNo) from SUPPayment where(PayMethod='" & "CHEQUE" & "'and PayDate='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(Amount) from SUPPayment where(PayMethod='" & "CHEQUE" & "'and PayDate='" & DTP1.Value & "')", con)
        '    xCHQ = cmd.ExecuteScalar
        'End If
        'xINT = 0


        'cmd = New SqlCommand("Select count(INVNo) from ChqRcv where(LastUpdate='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(Amount) from ChqRcv where(LastUpdate='" & DTP1.Value & "')", con)
        '    xCHQRC = cmd.ExecuteScalar
        'End If
        'xINT = 0

        'cmd = New SqlCommand("Select count(PayNo) from SUPPayment where(PayMethod='" & "CASH" & "'and PayDate='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(Amount) from SUPPayment where(PayMethod='" & "CASH" & "'and PayDate='" & DTP1.Value & "')", con)
        '    xSPAY = cmd.ExecuteScalar
        'End If
        'xINT = 0


        'cmd = New SqlCommand("Select count(PayAccount) from Pay_Master where(LastUpdate='" & DTP1.Value & "')", con)
        'xINT = cmd.ExecuteScalar
        'If xINT > 0 Then
        '    cmd = New SqlCommand("Select sum(Amnt) from Pay_Master where(LastUpdate='" & DTP1.Value & "')", con)
        '    xEXP = cmd.ExecuteScalar
        'End If
        'xINT = 0


        cmd = New SqlCommand("Delete from DaySumer", con)
        cmd.ExecuteNonQuery()

        Dim Expencess As String = ""
        cmd = New SqlCommand("Select * from Pay_Master where(LastUpdate='" & DTP1.Value & "'and Description<>'" & "Suplier Payment" & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("PayAccount") = "-" Then
            Else
                ' rdr("Amnt") 
                '                                                  Type,                   Discription,         Description1,       AMount,              SDate
                cmd1 = New SqlCommand("Insert DaySumer values('" & "Expences" & "','" & rdr("PayAccount") & "','" & "-" & "','" & rdr("Amnt") & "','" & DTP1.Value & "')", con1)
                cmd1.ExecuteNonQuery()

            End If
        End While
        rdr.Close()

        cmd = New SqlCommand("Select * from SUPPayment where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            cmd1 = New SqlCommand("Select SupName from Supplier where(SupCode='" & rdr("SupCode") & "')", con1)
            rdr1 = cmd1.ExecuteReader()
            If rdr1.Read = True Then
                If rdr("SupCode") = "-" Then
                ElseIf rdr1("SupName") = "-" Then
                Else
                    '                                                  Type,                   Discription,         Description1,                  AMount,              SDate
                    cmd2 = New SqlCommand("Insert DaySumer values('" & "Payments" & "','" & rdr1("SupName") & "','" & rdr("ChqPaid") & "','" & rdr("Amount") & "','" & DTP1.Value & "')", con2)
                    cmd2.ExecuteNonQuery()
                End If
            End If
            rdr1.Close()
        End While
        rdr.Close()




        cmd = New SqlCommand("Select * from Receipt_Main where(RcvDT='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("CusName") = "-" Then
            Else
                '                                                  Type,                   Discription,         Description1,                  AMount,              SDate
                cmd1 = New SqlCommand("Insert DaySumer values('" & "Cash Receipts" & "','" & rdr("CusName") & "','" & "-" & "','" & rdr("RcvAmt") & "','" & DTP1.Value & "')", con1)
                cmd1.ExecuteNonQuery()
            End If

        End While
        rdr.Close()

        cmd = New SqlCommand("Select * from ChqRcv where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("CusName") = "-" Then
            Else
                '                                                  Type,                   Discription,         Description1,                  AMount,              SDate
                cmd1 = New SqlCommand("Insert DaySumer values('" & "CHQ Receipts" & "','" & rdr("CusName") & "','" & rdr("CHQNo") & "','" & rdr("Amount") & "','" & DTP1.Value & "')", con1)
                cmd1.ExecuteNonQuery()
            End If

        End While
        rdr.Close()


        cmd = New SqlCommand("Select * from GRN_Main where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            '                                                   Type,                   Discription,         Description1,                  AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & "Purchasing" & "','" & rdr("SupName") & "','" & rdr("InvNo") & "','" & rdr("NetAmnt") & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()


        cmd = New SqlCommand("Select * from SLRTN_Main where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            '                                                   Type,                   Discription,         Description1,      AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & "Sales Returns" & "','" & rdr("InvNo") & "','" & "-" & "','" & rdr("Amount") & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()




        cmd = New SqlCommand("Select * from SUPRTN_Main where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            '                                                   Type,                      Discription,         Description1,      AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & "Purchase Returns" & "','" & rdr("SupName") & "','" & "-" & "','" & rdr("Amount") & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()

        cmd = New SqlCommand("Select * from CHQPAY_Sub where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            '                                                   Type,                      Discription,             Description1,          AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & "Cheque Paids" & "','" & rdr("SupName") & "','" & rdr("CHQNo") & "','" & rdr("CHQAmnt") & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()





        Dim xDamount As Double = 0
        cmd = New SqlCommand("Select * from Acc_Main where(LastUpdate='" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            If rdr("Debit") = 0 Then
                xDamount = rdr("Credit")
            ElseIf rdr("Credit") = 0 Then
                xDamount = rdr("Debit")
            End If
            '                                                       Type,                      Discription,         Description1,      AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & rdr("BankName") & "','" & rdr("Description") & "','" & "-" & "','" & xDamount & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()




        cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate='" & DTP1.Value & "'and InvType='" & "CREDIT" & "')", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            '                                                       Type,                 Discription,         Description1,      AMount,              SDate
            cmd1 = New SqlCommand("Insert DaySumer values('" & "Credit Sales" & "','" & rdr("CusName") & "','" & "-" & "','" & rdr("InvAmnt") & "','" & DTP1.Value & "')", con1)
            cmd1.ExecuteNonQuery()
        End While
        rdr.Close()




        '
        Dim xBFA As Double = 0
        'cmd = New SqlCommand("Select * from CashFlow where(LastUpdate='" & DTP1.Value & "')", con)
        'rdr = cmd.ExecuteReader
        'If rdr.Read = True Then
        '    cmd1 = New SqlCommand("Select DayBal from CashFlow where(LastUpdate='" & DTP1.Value & "')", con1)
        '    xBFA = cmd1.ExecuteScalar
        'End If
        'rdr.Close()


        Dim odt As DateTime = "2023-01-01"
        Dim opBals As Double = 0
        cmd = New SqlCommand("Select BfBal from CashFlow where LastUpdate='" & odt.Date & "'", con)
        opBals = cmd.ExecuteScalar

        xBFA = GetOpBal(odt.Date, DTP1.Value.Date)
        xBFA += opBals

        Dim cashSales As Double = 0
        Dim cashReceipts As Double = 0
        Dim cashWdraw As Double = 0
        Dim exp As Double = 0
        Dim suppay As Double = 0
        Dim deposit As Double = 0
        Dim crPays As Double = 0
        Dim slRtn As Double = 0
        Dim crdSls As Double = 0

        Dim dcs As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CASH" & "'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        cashSales = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        crdSls = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(ByCard),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        crPays = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(RcvAmt),0)from Receipt_Main where RcvDT>='" & DTP1.Value.Date & "'and RcvDT <='" & DTP2.Value.Date & "'", con)
        cashReceipts = cmd.ExecuteScalar
        ' cashReceipts = cashReceipts - crPays

        cmd = New SqlCommand("Select ISNULL(SUM(Credit),0)from Acc_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'and Description like'%" & "Cash Widraw" & "%'", con)
        cashWdraw = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'and Description like'" & "Suplier Payment" & "'", con)
        suppay = cmd.ExecuteScalar


        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        exp = cmd.ExecuteScalar
        exp = exp - (suppay + cashWdraw)

        cmd = New SqlCommand("Select ISNULL(SUM(Debit),0)from Acc_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'and Description like'%" & "CASH  Deposit" & "%'", con)
        deposit = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0)from SLRTN_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        slRtn = cmd.ExecuteScalar
        Dim Chq As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(ByCash),0)from Inv_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate <='" & DTP2.Value.Date & "'", con)
        Chq = cmd.ExecuteScalar


        Dim nowBal As Double = 0

        nowBal = (cashSales + cashReceipts) - (exp + suppay + deposit + slRtn)
        xBFA += nowBal












        'report3.SetParameterValue("xCASHSL", xCASH)
        'report3.SetParameterValue("xCRSL", xCRD)
        'report3.SetParameterValue("xCOLLEC", xCOLLEC)
        'report3.SetParameterValue("xCHQ", xCOLLEC)
        'report3.SetParameterValue("xCHQPAY", xCHQ)
        'report3.SetParameterValue("xEXP", xEXP)
        'report3.SetParameterValue("xPAY", xSPAY)
        'report3.SetParameterValue("xExpences", Expencess)
        'report3.SetParameterValue("xPayments", Paymentsa)
        report3.SetParameterValue("xBF", xBFA)
        report3.SetParameterValue("xDT", DTP1.Text)

        'cmd1 = New SqlCommand("Delete from DaySummery where(LastUpdate='" & DTP1.Value & "')", con1)
        'cmd1.ExecuteNonQuery()



        'cmd = New SqlCommand("Select * from DaySummery where(LastUpdate='" & DTP1.Value & "')", con)
        'rdr = cmd.ExecuteReader
        'If rdr.Read = True Then

        'Else
        '    '                                                   Exp,        ExpAmnt,      SupPay,   SpPayAmnt,    CashRcv,     RcvAmnt,    ChqPays,      PayAmnt,               LastUpdate
        '    cmd1 = New SqlCommand("Insert DaySummery values('" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End If
        'rdr.Close()

        'cmd = New SqlCommand("Select * from Pay_Master where(LastUpdate='" & DTP1.Value & "'and Description<>'" & "Supplier Payment" & "')", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    '                                                   Exp,                           ExpAmnt,          SupPay,   SpPayAmnt,    CashRcv,     RcvAmnt,    ChqPays,      PayAmnt,               LastUpdate
        '    cmd1 = New SqlCommand("Insert DaySummery values('" & rdr("PayAccount") & "','" & rdr("Amnt") & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()

        'cmd = New SqlCommand("Select * from SUPPayment where(LastUpdate='" & DTP1.Value & "')", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    '                                                   Exp,         ExpAmnt,       SupPay,                                 SpPayAmnt,                    CashRcv,     RcvAmnt,    ChqPays,      PayAmnt,               LastUpdate
        '    cmd1 = New SqlCommand("Insert DaySummery values('" & "-" & "','" & 0 & "','" & rdr("SupCode") & "-" & rdr("ChqPaid") & "','" & rdr("Amount") & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()

        'cmd = New SqlCommand("Select * from Receipt_Main where(RcvDT='" & DTP1.Value & "')", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    '                                                   Exp,         ExpAmnt,       SupPay,     SpPayAmnt,     CashRcv,              RcvAmnt,                 ChqPays,      PayAmnt,               LastUpdate
        '    cmd1 = New SqlCommand("Insert DaySummery values('" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & rdr("CusName") & "','" & rdr("RcvAmt") & "','" & "-" & "','" & 0 & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()


        'cmd = New SqlCommand("Select * from ChqRcv where(LastUpdate='" & DTP1.Value & "')", con)
        'rdr = cmd.ExecuteReader
        'While rdr.Read
        '    '                                                   Exp,         ExpAmnt,       SupPay,     SpPayAmnt,     CashRcv,  RcvAmnt,       ChqPays,                                       PayAmnt,               LastUpdate
        '    cmd1 = New SqlCommand("Insert DaySummery values('" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & "-" & "','" & 0 & "','" & rdr("CusName") & "-" & rdr("CHQNo") & "','" & rdr("Amount") & "','" & Format(Now, "yyyy-MM-dd") & "')", con1)
        '    cmd1.ExecuteNonQuery()
        'End While
        'rdr.Close()


        report3.RecordSelectionFormula = "{DaySumer.SDate} ='" & Format(DTP1.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim report3 As New RPT5
        report3.RecordSelectionFormula = "{Stock_Main.BalanceQty} <>0"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()


        ' report5.RecordSelectionFormula = "{Pay_Master.LastUpdate} ='" & xxd & "'"
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim report3 As New RPT6
        report3.SetParameterValue("xFROM", DTP1.Text)
        report3.SetParameterValue("xTO", DTP2.Text)

        report3.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Pay_Master.Description}<>'" & "Suplier Payment" & "'"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Dim report6 As New RPT7
        report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim report19 As New RPT19
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report19.RecordSelectionFormula = "{Receipt_Main.RcvDT} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Receipt_Main.RcvDT} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report19)
        CrystalReportViewer1.ReportSource = report19
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim report20 As New RPTCSI
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report20.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Inv_Sub.CusCode}<>'" & "" & "'"
        xCRINFO(report20)
        CrystalReportViewer1.ReportSource = report20
        CrystalReportViewer1.Refresh()
        ' Dim reportPRFT As New RPTPROFIT
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim report6 As New RPTPROFIT
        Dim xCost As Double = 0
        Dim xSold As Double = 0
        cmd = New SqlCommand("Select ISNULL(sum(InvAmnt),0)from Inv_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        xSold = cmd.ExecuteScalar
        cmd = New SqlCommand("Select ISNULL(sum(CPrice*Qty),0)from Inv_Sub where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        xCost = cmd.ExecuteScalar

        Dim rtnCost As Double = 0
        Dim rtnValue As Double = 0
        cmd = New SqlCommand("Select ISNULL(sum(Amount),0)from SLRTN_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        rtnValue = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(sum(CPrice*Qty),0)from SLRTN_Sub where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        rtnCost = cmd.ExecuteScalar



        'report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        'xCRINFO(report6)
        report6.SetParameterValue("xcst", xCost - rtnCost)
        report6.SetParameterValue("xsls", xSold - rtnValue)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub CusName_TextChanged(sender As Object, e As EventArgs) Handles CusName.TextChanged
        If CusName.Text = "" Then
            cmd = New SqlCommand("Select * from Cus_Master order by CusName", con)
        Else
            cmd = New SqlCommand("Select * from Cus_Master where CusName like '%" & CusName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID1.Rows.Clear()
        While rdr.Read
            GRID1.Rows.Add(rdr("CusCode"), rdr("CusName"))
        End While
        rdr.Close()
    End Sub

    Private Sub GRID1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentClick

    End Sub

    Private Sub GRID1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID1.CellContentDoubleClick
        CusCoode.Text = GRID1.Item(0, GRID1.CurrentRow.Index).Value
        CusName.Text = GRID1.Item(1, GRID1.CurrentRow.Index).Value
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim report01 As New RPT10
        report01.RecordSelectionFormula = "{Cust_Sub.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim report01 As New RPT10
        report01.RecordSelectionFormula = "{Cust_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Cust_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Cust_Sub.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Dim report01 As New RptCusSt
        report01.RecordSelectionFormula = "{CusState.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report01)
        CrystalReportViewer1.ReportSource = report01
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim report6 As New RptDamage
        report6.RecordSelectionFormula = "{DMG_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {DMG_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub
    Dim CusCode As String = Nothing
    Private Sub GRID2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentClick

    End Sub

    Private Sub GRID2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRID2.CellContentDoubleClick
        txtSupCode.Text = GRID2.Item(0, GRID2.CurrentRow.Index).Value
        txtSupName.Text = GRID2.Item(1, GRID2.CurrentRow.Index).Value
    End Sub

    Private Sub txtSupName_TextChanged(sender As Object, e As EventArgs) Handles txtSupName.TextChanged
        If txtSupName.Text = "" Then
            cmd = New SqlCommand("Select * from Supplier order by SupName", con)
        Else
            cmd = New SqlCommand("Select * from Supplier where SupName like '%" & txtSupName.Text & "%' ", con)
        End If
        rdr = cmd.ExecuteReader
        GRID2.Rows.Clear()
        While rdr.Read
            GRID2.Rows.Add(rdr("SupCode"), rdr("SupName"))
        End While
        rdr.Close()
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Dim report6 As New RptSupRtn
        report6.RecordSelectionFormula = "{SUPRTN_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {SUPRTN_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {SUPRTN_Sub.SupCode}='" & txtSupCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Dim reportMRN As New RptShopBL
        reportMRN.RecordSelectionFormula = "{MrningCash.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {MrningCash.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(reportMRN)
        CrystalReportViewer1.ReportSource = reportMRN
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        Dim reportCRD As New RptCashTaken
        reportCRD.RecordSelectionFormula = "{CreditTaken_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CreditTaken_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(reportCRD)
        CrystalReportViewer1.ReportSource = reportCRD
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Dim report19 As New RPT19
        ' report7.RecordSelectionFormula = "{Receipt_Main.RcvDT} ='" & FrmREPORT.TextBox1.Text & "'"
        report19.RecordSelectionFormula = "{Receipt_Main.CusName} ='" & CusName.Text & "'"
        xCRINFO(report19)
        CrystalReportViewer1.ReportSource = report19
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        If CmbAccount.Text = "" Then Return
        Dim report3 As New RPT6
        report3.SetParameterValue("xFROM", DTP1.Text)
        report3.SetParameterValue("xTO", DTP2.Text)
        report3.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Pay_Master.PayAccount}='" & CmbAccount.Text & "'"
        xCRINFO(report3)
        CrystalReportViewer1.ReportSource = report3
        CrystalReportViewer1.Refresh()





        'Dim reportCRT As New RptCreditTaken
        'reportCRT.RecordSelectionFormula = "{Credit_Taken.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Credit_Taken.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        'xCRINFO(reportCRT)
        'CrystalReportViewer1.ReportSource = reportCRT
        'CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        If CmbAccount.Text = "" Then Return
        Dim reportCRT As New RptCreditTaken
        reportCRT.RecordSelectionFormula = "{Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        xCRINFO(reportCRT)
        CrystalReportViewer1.ReportSource = reportCRT
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked
        Dim reportPNL As New RptPNL
        Dim aINT As Integer = 0
        Dim xTotalSales As Double = 0
        Dim xTotalCosts As Double = 0
        Dim xGrossProfit As Double = 0
        Dim xTotalRetuns As Double = 0
        Dim xTotalRtCosts As Double = 0
        Dim xRtnLost As Double = 0
        Dim xEspences As Double = 0
        Dim xNetProfit As Double = 0






        cmd = New SqlCommand("Select count(Amount) from SLRTN_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select sum(Amount) from SLRTN_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalRetuns = cmd.ExecuteScalar
            cmd = New SqlCommand("Select sum(CPrice*Qty) from SLRTN_Sub where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalRtCosts = cmd.ExecuteScalar
            xRtnLost = xTotalRetuns - xTotalRtCosts
        End If
        aINT = 0


        cmd = New SqlCommand("Select count(INVNo) from Inv_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select ISNULL(sum(InvAmnt),0) from Inv_Main where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalSales = cmd.ExecuteScalar
            xTotalSales = xTotalSales - xTotalRetuns
            cmd = New SqlCommand("Select ISNULL(sum(CPrice*Qty),0) from Inv_Sub where(LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xTotalCosts = cmd.ExecuteScalar
            xTotalCosts = xTotalCosts - xTotalRtCosts
            xGrossProfit = xTotalSales - xTotalCosts
        End If
        aINT = 0




        cmd = New SqlCommand("Select count(Amnt) from Pay_Master where(Description <>'" & "Suplier Payment" & "'and LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
        aINT = cmd.ExecuteScalar
        If aINT > 0 Then
            cmd = New SqlCommand("Select sum(Amnt) from Pay_Master where(Description <>'" & "Suplier Payment" & "'and LastUpdate >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and LastUpdate <='" & Format(DTP2.Value, "yyyy-MM-dd") & "')", con)
            xEspences = cmd.ExecuteScalar
        End If
        xNetProfit = xGrossProfit - xEspences
        Dim netsls = 0
        netsls = xTotalSales - xTotalRetuns
        Dim xTotalSalesS As String = xFRMT(xTotalSales)
        Dim xTotalCostsS As String = xFRMT(xTotalCosts)
        Dim xGrossProfitS As String = xFRMT(xGrossProfit)
        Dim xTotalRetunsS As String = xFRMT(xTotalRetuns)
        Dim xTotalRtCostsS As String = xFRMT(xTotalRtCosts)
        Dim xRtnLostS As String = xFRMT(xRtnLost)
        Dim xEspencesS As String = xFRMT(xEspences)
        Dim xNetProfitS As String = xFRMT(xNetProfit)
        Dim xnsls As String = xFRMT(netsls)
        reportPNL.SetParameterValue("xTSLS", xTotalSalesS)
        reportPNL.SetParameterValue("xTCOST", xTotalCostsS)
        reportPNL.SetParameterValue("xGPRF", xGrossProfitS)
        reportPNL.SetParameterValue("xRTNS", xTotalRetunsS)
        reportPNL.SetParameterValue("xRCOST", xTotalRtCostsS)
        reportPNL.SetParameterValue("xLOST", xRtnLostS)
        reportPNL.SetParameterValue("xEXPN", xEspencesS)
        reportPNL.SetParameterValue("xNETPF", xNetProfitS)
        reportPNL.SetParameterValue("xnsls", xnsls)
        reportPNL.RecordSelectionFormula = "{Pay_Master.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Pay_Master.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Pay_Master.Description} <>'" & "Suplier Payment" & "'"
        ' reportPNL.RecordSelectionFormula = "{Credit_Taken.CusName}='" & CmbAccount.Text & "'"
        xCRINFO(reportPNL)
        CrystalReportViewer1.ReportSource = reportPNL
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel22.LinkClicked
        If txtSupName.Text = "" Then Return
        'Dim xInteger As Integer = 0
        'cmd = New SqlCommand("Select Count(SupCode) from CHQPAY_Sub where(SupName='" & txtSupName.Text & "')", con)
        'xInteger = cmd.ExecuteScalar
        'Dim xChqpaid As Double = 0
        'If xInteger > 0 Then
        cmd = New SqlCommand("Select sum(SupBalance) from Supplier where(SupName='" & txtSupName.Text & "')", con)
        xChqpaid = cmd.ExecuteScalar
        'End If
        Dim reportCRT As New SupPayments
        reportCRT.SetParameterValue("xSUPNAME", txtSupName.Text)
        reportCRT.SetParameterValue("xCURBAL", xChqpaid)

        reportCRT.RecordSelectionFormula = "{Supplier.SupName}='" & txtSupName.Text & "'"
        xCRINFO(reportCRT)
        CrystalReportViewer1.ReportSource = reportCRT
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
        Dim NumberOfDays As Integer = DateDiff(DateInterval.Day, DTP1.Value, DTP2.Value)
        Dim TotalSales As Double = 0
        cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select ISNULL(sum(InvAmnt),0) from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con1)
            TotalSales = cmd1.ExecuteScalar
        End If
        rdr.Close()
        NumberOfDays = NumberOfDays + 1
        Dim AverageSales As Double = TotalSales / NumberOfDays
        Dim Avera As New RptAverage
        Avera.SetParameterValue("xFROM", DTP1.Text)
        Avera.SetParameterValue("xTO", DTP2.Text)
        Avera.SetParameterValue("xNO", NumberOfDays)
        Avera.SetParameterValue("xAVG", AverageSales)
        Avera.RecordSelectionFormula = "{Inv_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(Avera)
        CrystalReportViewer1.ReportSource = Avera
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        If CmbAccount1.Text = "" Then Return
        Dim BAccountNumber As String = CmbAccount1.Text.Split(" - ")(0)
        Dim TotalCR As Double = 0
        Dim TotalDR As Double = 0
        cmd = New SqlCommand("Select * from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select sum(Credit) from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con1)
            TotalCR = cmd1.ExecuteScalar

            cmd1 = New SqlCommand("Select sum(Debit) from Acc_Main where(AccNo='" & BAccountNumber & "'and LastUpdate< '" & DTP1.Value & "')", con1)
            TotalDR = cmd1.ExecuteScalar
        End If
        rdr.Close()
        Dim AccSum As New RptAccountSum
        AccSum.SetParameterValue("xACC", CmbAccount1.Text)
        AccSum.SetParameterValue("xFROM", DTP1.Text)
        AccSum.SetParameterValue("xTO", DTP2.Text)
        AccSum.SetParameterValue("xBF", TotalDR - TotalCR)
        'AccSum.SetParameterValue("xAVG", AverageSales)
        AccSum.RecordSelectionFormula = "{Acc_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Acc_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(AccSum)
        CrystalReportViewer1.ReportSource = AccSum
        CrystalReportViewer1.Refresh()


    End Sub

    Private Sub LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        'If CmbItem.Text = "" Then Return
        'Dim ItemCodeS As String = CmbItem.Text.Split(" - ")(0)
        Dim report6 As New RPT7
        report6.RecordSelectionFormula = "{Inv_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {Inv_Sub.ItemCode}='" & ItemCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel26_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel26.LinkClicked
        Dim ds As New DataSet3
        Dim Tables As DataTable = ds.Tables.Add("DayEnd")
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Columns.Add("Csl", GetType(String))
        Tables.Columns.Add("Crc", GetType(String))
        Tables.Columns.Add("Cwd", GetType(String))
        Tables.Columns.Add("Exp", GetType(String))
        Tables.Columns.Add("Pay", GetType(String))
        Tables.Columns.Add("Dep", GetType(String))
        Tables.Columns.Add("Rtn", GetType(String))
        Tables.Columns.Add("Crd", GetType(String))
        Tables.Columns.Add("Op", GetType(String))
        Tables.Columns.Add("Chq", GetType(String))
        Tables.Rows.Clear()
        Dim dd As DateTime = DTP1.Value.Date
        Dim dd1 As DateTime = DTP2.Value.Date
        'dd = dd.AddDays(-1)
        'dd1 = dd1.AddDays(-1)
        Dim dayBal As Double = 0
        Dim opDate As DateTime = "2023-01-01"
        Dim oldBal As Double = 0

        'Dim opBal As Double = 0
        'cmd = New SqlCommand("Select BfBal from CashFlow where LastUpdate='" & opDate.Date & "'", con)
        'opBal = cmd.ExecuteScalar




        'cmd = New SqlCommand("Select DayBal from CashFlow where LastUpdate='" & dd.AddDays(-1) & "'", con)
        'dayBal = cmd.ExecuteScalar
        'Dim opBalance As Double = 0
        'opBalance = GetOpBal(DTP1.Value.Date, DTP2.Value.Date)

        Dim opDate1 As DateTime = "2023-01-01"


        'Dim ddo As Double = GetOpBal(opDate.Date, DTP1.Value.Date)
        'opBal = opBal + ddo
        While (dd <= dd1)
            Dim cashSales As Double = 0
            Dim cashReceipts As Double = 0
            Dim cashWdraw As Double = 0
            Dim exp As Double = 0
            Dim suppay As Double = 0
            Dim deposit As Double = 0
            Dim crPays As Double = 0
            Dim slRtn As Double = 0
            Dim crdSls As Double = 0
            Dim opBal As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(amn),0) from Op where Dte='" & dd & "'", con)
            opBal = cmd.ExecuteScalar
            Dim dcs As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CASH" & "'and LastUpdate='" & dd & "'", con)
            cashSales = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate='" & dd & "'", con)
            crdSls = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(ByCard),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate='" & dd & "'", con)
            crPays = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(RcvAmt),0)from Receipt_Main where RcvDT='" & dd & "'", con)
            cashReceipts = cmd.ExecuteScalar
            ' cashReceipts = cashReceipts - crPays

            cmd = New SqlCommand("Select ISNULL(SUM(Credit),0)from Acc_Main where LastUpdate='" & dd & "'and Description like'%" & "Cash Widraw" & "%'", con)
            cashWdraw = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate='" & dd & "'and Description like'" & "Suplier Payment" & "'", con)
            suppay = cmd.ExecuteScalar


            cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate='" & dd & "'", con)
            exp = cmd.ExecuteScalar
            exp = exp - (suppay + cashWdraw)

            cmd = New SqlCommand("Select ISNULL(SUM(Debit),0)from Acc_Main where LastUpdate='" & dd & "'and Description like'%" & "Cash Deposit" & "%'", con)
            deposit = cmd.ExecuteScalar

            cmd = New SqlCommand("Select ISNULL(SUM(Amount),0)from SLRTN_Main where LastUpdate='" & dd & "'", con)
            slRtn = cmd.ExecuteScalar

            Dim Chq As Double = 0
            'cmd = New SqlCommand("Select ISNULL(SUM(ByCash),0)from Inv_Main where LastUpdate='" & dd & "'", con)
            'Chq = cmd.ExecuteScalar

            Dim rcvChq As Double = 0
            cmd = New SqlCommand("Select ISNULL(SUM(Amount),0)from ChqRcv where LastUpdate='" & dd & "'", con)
            rcvChq = cmd.ExecuteScalar
            Chq += rcvChq


            Tables.Rows.Add(dd, cashSales, cashReceipts, cashWdraw, exp, suppay, deposit, slRtn, crdSls, opBal, Chq)
            Dim nowBal As Double = 0

            nowBal = (opBal + cashSales + cashReceipts) - (exp + suppay + deposit + slRtn)
            opBal = nowBal
            dd = dd.AddDays(1)
        End While



        Dim xxc As New RptDayEndNew
        xxc.SetDataSource(ds.Tables(1))
        'xxc.SetParameterValue("xfr", DTP1.Text)
        'xxc.SetParameterValue("xto", DTP2.Text)
        'xxc.SetParameterValue("exp", Format(pays, "0.00"))
        'xxc.SetParameterValue("spy", Format(spays, "0.00"))
        'xxc.SetParameterValue("bls", Format(cashbalance, "0.00"))
        'xxc.SetParameterValue("crd", Format(creditSales, "0.00"))
        'xxc.SetParameterValue("rcv", Format(cashReceipts, "0.00"))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()





        'Dim report6 As New RptStatement
        'Dim TotalSales As Double = 0
        'cmd = New SqlCommand("Select * from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con)
        '    rdr = cmd.ExecuteReader
        'If rdr.Read = True Then
        '    cmd1 = New SqlCommand("Select sum(InvAmnt) from Inv_Main where(LastUpdate>= '" & DTP1.Value & "'and LastUpdate<='" & DTP2.Value & "')", con1)
        '    TotalSales = cmd1.ExecuteScalar
        'End If
        'rdr.Close()
        'report6.SetParameterValue("xSLS", TotalSales)
        'report6.RecordSelectionFormula = "{CashFlow.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CashFlow.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        'xCRINFO(report6)
        'CrystalReportViewer1.ReportSource = report6
        'CrystalReportViewer1.Refresh()
    End Sub
    Private Function GetOpBal(ByVal opDate As DateTime, ByVal endDat As DateTime)
        Dim dayBal As Double = 0
        Dim cashSales As Double = 0
        Dim cashReceipts As Double = 0
        Dim cashWdraw As Double = 0
        Dim exp As Double = 0
        Dim suppay As Double = 0
        Dim deposit As Double = 0
        Dim crPays As Double = 0
        Dim slRtn As Double = 0
        Dim crdSls As Double = 0

        Dim dcs As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CASH" & "'and LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        cashSales = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        crdSls = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(ByCard),0)from Inv_Main where InvType='" & "CREDIT" & "'and LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        crPays = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(RcvAmt),0)from Receipt_Main where RcvDT>='" & opDate & "'and RcvDT<'" & endDat & "'", con)
        cashReceipts = cmd.ExecuteScalar
        ' cashReceipts = cashReceipts - crPays

        cmd = New SqlCommand("Select ISNULL(SUM(Credit),0)from Acc_Main where LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'and Description like'%" & "Cash Widraw" & "%'", con)
        cashWdraw = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'and Description like'" & "Suplier Payment" & "'", con)
        suppay = cmd.ExecuteScalar


        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0)from Pay_Master where LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        exp = cmd.ExecuteScalar
        exp = exp - (suppay + cashWdraw)

        cmd = New SqlCommand("Select ISNULL(SUM(Debit),0)from Acc_Main where LastUpdate>='" & opDate & "'and LastUpdate< '" & endDat & "'and Description like'%" & "CASH  Deposit" & "%'", con)
        deposit = cmd.ExecuteScalar

        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0)from SLRTN_Main where LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        slRtn = cmd.ExecuteScalar
        Dim Chq As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(ByCash),0)from Inv_Main where LastUpdate>='" & opDate & "'and LastUpdate<'" & endDat & "'", con)
        Chq = cmd.ExecuteScalar

        ' Tables.Rows.Add(dd, cashSales, cashReceipts, cashWdraw, exp, suppay, deposit, slRtn, crdSls, dayBal, Chq)
        Dim nowBal As Double = 0
        nowBal = (cashSales + cashReceipts) - (exp + suppay + deposit + slRtn)
        dayBal = nowBal
        Return dayBal
    End Function

    Private Sub LinkLabel27_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel27.LinkClicked
        Dim report6 As New RptDayInv
        report6.RecordSelectionFormula = "{Inv_Main.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {Inv_Main.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub ItemCode_TextChanged(sender As Object, e As EventArgs) Handles ItemCode.TextChanged
        cmd = New SqlCommand("Select * from Inv_Sub where ItemCode = '" & ItemCode.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            ItemName.Text = rdr("ItemName")
        Else
            ItemName.Clear()
        End If
        rdr.Close()
    End Sub

    Private Sub LinkLabel20_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        If txtSupCode.Text = "" Then Return
        Dim xGN As Double = 0
        Dim xPay As Double = 0
        cmd = New SqlCommand("Select * from SupState where SupCode='" & txtSupCode.Text & "'", con)
        rdr = cmd.ExecuteReader
        If rdr.Read = True Then
            cmd1 = New SqlCommand("Select sum(GrnAmnt) from SupState where(SupCode='" & txtSupCode.Text & "')", con1)
            xGN = cmd1.ExecuteScalar
            cmd1 = New SqlCommand("Select sum(PayAmnt) from SupState where(SupCode='" & txtSupCode.Text & "')", con1)
            xPay = cmd1.ExecuteScalar
            cmd1 = New SqlCommand("Update Supplier set SupBalance='" & xGN - xPay & "'where SupCode='" & txtSupCode.Text & "'", con1)
            cmd1.ExecuteNonQuery()
        End If
        rdr.Close()
        Dim report6 As New RptSupState
        report6.SetParameterValue("xFROM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        ' report6.RecordSelectionFormula = "{SupState.GrnDate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {SupState.GrnDate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {SupState.SupName}='" & txtSupName.Text & "'"
        report6.RecordSelectionFormula = "{SupState.SupCode}='" & txtSupCode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel28_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked
        Dim report6 As New RptDmg
        report6.SetParameterValue("xFROM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{DMG_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {DMG_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel29_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
        If CusCoode.Text = "" Then Return
        Dim report6 As New RptRcvdChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{ChqRcv.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {ChqRcv.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {ChqRcv.CHQNo} <>'" & "-" & "'and {ChqRcv.CusCode}='" & CusCoode.Text & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel33_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select * from Edt where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("ItemCode"), rdr("ImtmName"), rdr("Description"), rdr("NewDes"), Format(rdr("LastUpdate"), "yyyy-MM-dd"))
        End While
        rdr.Close()
        Dim xxc As New RptLogs
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xf", DTP1.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel34.LinkClicked
        Dim ds As New DataSet1
        Dim Table As DataTable = ds.Tables.Add("Tbl")
        Table.Columns.Add("Ic", GetType(String))
        Table.Columns.Add("In", GetType(String))
        Table.Columns.Add("Old", GetType(String))
        Table.Columns.Add("New", GetType(String))
        Table.Columns.Add("Dte", GetType(String))
        Table.Rows.Clear()
        cmd = New SqlCommand("Select * from CHQPAY_Sub where Status='" & "STOPED" & "'", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Table.Rows.Add(rdr("BankAcc"), rdr("CHQNo"), Format(rdr("CHQUpdate"), "yyyy-MM-dd"), rdr("CHQAmnt"), rdr("SupName"))
        End While
        rdr.Close()
        Dim xxc As New RtpStopped
        xxc.SetDataSource(ds.Tables(1))
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Dim ds As New DataSet1
        Dim Tables As DataTable = ds.Tables.Add("Tbl")
        Tables.Columns.Add("Ic", GetType(String))
        Tables.Columns.Add("In", GetType(String))
        Tables.Columns.Add("Old", GetType(String))
        Tables.Columns.Add("New", GetType(String))
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Rows.Clear()

        Dim cashSales As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'and InvType='" & "CASH" & "'", con)
        cashSales = cmd.ExecuteScalar


        Dim creditSales As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(InvAmnt),0) from Inv_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'and InvType='" & "CREDIT" & "'", con)
        creditSales = cmd.ExecuteScalar


        Dim cashReceipts As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(RcvAmt),0) from Receipt_Main where RcvDT>='" & DTP1.Value.Date & "'and RcvDT<='" & DTP2.Value.Date & "'", con)
        cashReceipts = cmd.ExecuteScalar

        Dim cashDeposits As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Debit),0) from Acc_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        cashDeposits = cmd.ExecuteScalar

        Dim pays As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0) from Pay_Master where  LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        pays = cmd.ExecuteScalar

        'Cash Widraw for EXP - RASHAD EXP
        Dim cashWidraws As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Credit),0) from Acc_Main where Description Like '%" & "Cash Widraw" & "%'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        cashWidraws = cmd.ExecuteScalar
        'Suplier Payment




        'Cash Paid For KULIN 
        Dim supPayBnk As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Credit),0) from Acc_Main where Description Like '%" & "Cash Paid For" & "%'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        supPayBnk = cmd.ExecuteScalar

        Dim supplierPay As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0) from Pay_Master where Description like'%" & "Suplier Payment" & "%'and LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        supplierPay = cmd.ExecuteScalar


        Dim slsRtn As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0) from SLRTN_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        slsRtn = cmd.ExecuteScalar



        Dim spays As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0) from SUPPayment where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'and Amount>0", con)
        spays = cmd.ExecuteScalar



        Dim cashExp As Double = pays - (cashWidraws + supplierPay)
        Dim cashCollections As Double = 0
        cashCollections = cashSales + cashReceipts
        Dim cashOuts As Double = 0
        cashOuts = cashDeposits + cashExp + slsRtn + supplierPay
        Dim cashbalance = cashCollections - cashOuts

        cmd = New SqlCommand("select SUPPayment.SupCode,Supplier.SupName,ISNULL(SUM(SUPPayment.Amount),0) as  CourseCost from SUPPayment inner join Supplier on SUPPayment.SupCode = Supplier.SupCode where SUPPayment.LastUpdate>='" & DTP1.Value.Date & "'and SUPPayment.LastUpdate<='" & DTP2.Value.Date & "' group by SUPPayment.SupCode,Supplier.SupName", con)
        'cmd = New SqlCommand("Select ItemCode,ItemName, Sum (Qty)  from Inv_Sub  where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'Group by ItemCode ", con)
        'cmd = New SqlCommand("Select ItemCode,ItemName,Qty,LastUpdate from Inv_Sub where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'", con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Tables.Rows.Add(rdr("SupCode"), rdr("SupName"), Format(rdr("CourseCost"), "0.00"))
        End While
        rdr.Close()

        'Dim odt As DateTime = "2023-01-01"
        'Dim opBals As Double = 0
        'cmd = New SqlCommand("Select BfBal from CashFlow where LastUpdate='" & odt.Date & "'", con)
        'opBals = cmd.ExecuteScalar

        Dim odt As DateTime = DTP1.Value.Date
        Dim opBals As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(amn),0) from OP where Dte='" & odt.Date & "'", con)
        opBals = cmd.ExecuteScalar


        Dim chqs As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0) from ChqRcv where Status='" & "ON-HAND" & "'", con)
        chqs = cmd.ExecuteScalar

        Dim bnk As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Debit-Credit),0) from Acc_Main ", con)
        bnk = cmd.ExecuteScalar



        Dim dayBal As Double = 0
        dayBal = GetOpBal(odt.Date, DTP1.Value.Date)
        dayBal += opBals






        Dim xxc As New MothEndRpt
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xfr", DTP1.Text)
        xxc.SetParameterValue("xto", DTP2.Text)
        xxc.SetParameterValue("sls", Format(cashSales, "0.00")) '
        xxc.SetParameterValue("exp", Format(cashExp, "0.00")) '
        xxc.SetParameterValue("spy", Format(supplierPay, "0.00")) '
        xxc.SetParameterValue("bls", Format(cashbalance + dayBal, "0.00"))
        xxc.SetParameterValue("crd", Format(creditSales, "0.00")) '
        xxc.SetParameterValue("rcv", Format(cashReceipts, "0.00")) '
        xxc.SetParameterValue("xdep", Format(cashDeposits, "0.00")) '
        xxc.SetParameterValue("xBexp", Format(cashWidraws, "0.00")) '
        xxc.SetParameterValue("xChqP", Format(supPayBnk, "0.00")) '
        xxc.SetParameterValue("tsls", Format((cashSales + creditSales) - slsRtn, "0.00")) '
        xxc.SetParameterValue("texp", Format(pays - supplierPay, "0.00")) '
        xxc.SetParameterValue("tpays", Format(spays, "0.00")) '
        xxc.SetParameterValue("xbf", Format(dayBal, "0.00")) '
        xxc.SetParameterValue("xchq", Format(chqs, "0.00")) '
        xxc.SetParameterValue("xbnk", Format(bnk, "0.00")) '
        'Dim tBal As Double = 0
        'tBal = (cashSales + creditSales) - ((pays - supplierPay) + spays)
        'xxc.SetParameterValue("tbal", Format(tBal, "0.00")) '
        Dim texps As Double = 0
        texps = pays - supplierPay
        Dim tsPays As Double = 0
        tsPays = spays
        Dim tBal As Double = 0
        tBal = creditSales - cashReceipts
        Dim toSLS As Double = cashSales + creditSales
        Dim ctb As Double = 0
        ctb = toSLS - (tBal + tsPays + texps)

        Dim cTOUT As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(CusBalance),0)from Cus_Master", con)
        cTOUT = cmd.ExecuteScalar
        Dim totalSales As Double = (cashSales + creditSales) - slsRtn
        Dim totalEpences As Double = pays - supplierPay
        Dim totalPayments As Double = spays
        Dim ff As Double = 0
        ff = (totalSales + dayBal) - (totalEpences + totalPayments + cTOUT)



        Dim tBalance As Double = 0
        Dim cashBal As Double = 0
        cashBal = cashbalance + dayBal
        tBalance = totalSales - (texps + spays + cTOUT + chqs + cashBal + bnk)



        'xxc.SetParameterValue("tbal", Format(ctb + dayBal, "0.00")) '
        'xxc.SetParameterValue("tbal", Format(ff, "0.00")) '
        xxc.SetParameterValue("tbal", Format(tBalance, "0.00")) '
        xxc.SetParameterValue("xCTM", Format(cTOUT, "0.00")) '
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub LinkLabel36_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
        Dim ds As New DataSet1
        Dim Tables As DataTable = ds.Tables.Add("Tbl")
        Tables.Columns.Add("Ic", GetType(String))
        Tables.Columns.Add("In", GetType(String))
        Tables.Columns.Add("Old", GetType(String))
        Tables.Columns.Add("New", GetType(String))
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Rows.Clear()
        Dim sql As String = "SELECT * FROM SLRTN_Sub where LastUpdate>='" & DTP1.Value.Date & "'and SLRTN_Sub.LastUpdate<='" & DTP2.Value.Date & "'"
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader
        While rdr.Read
            Dim cst As String = ""
            If rdr("CusCode") = "" Then
                cst = "CASH CUSTOMER"
            Else
                cmd1 = New SqlCommand("Select CusName from Cus_Master where CusCode='" & rdr("CusCode") & "'", con1)
                rdr1 = cmd1.ExecuteReader
                If rdr1.Read = True Then
                    cst = rdr1("CusName").ToString()
                End If
                rdr1.Close()
            End If
            Tables.Rows.Add(rdr("ItemCode"), rdr("ItemName"), rdr("SoldPrice"), rdr("Qty"), cst)
        End While
        rdr.Close()
        Dim rtnA As Double = 0
        cmd = New SqlCommand("Select ISNULL(SUM(Amount),0)from SLRTN_Main where LastUpdate>='" & DTP1.Value.Date & "'and SLRTN_Main.LastUpdate<='" & DTP2.Value.Date & "'", con)
        rtnA = cmd.ExecuteScalar
        Dim dd As String = Format(rtnA, "0.00")
        Dim xxc As New RptRtn
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xfr", DTP1.Text)
        xxc.SetParameterValue("xto", DTP2.Text)
        xxc.SetParameterValue("xNet", dd)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()

    End Sub

    Private Sub LinkLabel29_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel29.LinkClicked
        Dim report6 As New RptRcvdChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{ChqRcv.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {ChqRcv.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {ChqRcv.CHQNo} <>'" & "-" & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel30_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim report6 As New RptChqPay
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{CHQPAY_Sub.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CHQPAY_Sub.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'and {CHQPAY_Sub.CHQNo} <>'" & "-" & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel31_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel31.LinkClicked

        Dim report6 As New RptDepChq
        report6.SetParameterValue("xFRM", DTP1.Text)
        report6.SetParameterValue("xTO", DTP2.Text)
        report6.RecordSelectionFormula = "{CHQ_Dep.LastUpdate} >='" & Format(DTP1.Value, "yyyy-MM-dd") & "'and {CHQ_Dep.LastUpdate} <='" & Format(DTP2.Value, "yyyy-MM-dd") & "'"
        xCRINFO(report6)
        CrystalReportViewer1.ReportSource = report6
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel38_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel38.LinkClicked
        Dim ds As New DataSet1
        Dim Tables As DataTable = ds.Tables.Add("Tbl")
        Tables.Columns.Add("Ic", GetType(String))
        Tables.Columns.Add("In", GetType(String))
        Tables.Columns.Add("Old", GetType(String))
        Tables.Columns.Add("New", GetType(String))
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Rows.Clear()
        cmd = New SqlCommand("Select * from Inv_Main where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'and InvType='" & "CREDIT" & "'order by LastUpdate", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Tables.Rows.Add(Format(rdr("lastUpdate"), "yyyy-MM-dd"), rdr("Cusname"), rdr("InvAmnt"), "0", "0")
        End While
        rdr.Close()

        Dim xxc As New RptCrList
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xfr", DTP1.Text)
        xxc.SetParameterValue("xto", DTP2.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel37_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel37.LinkClicked
        Dim ds As New DataSet1
        Dim Tables As DataTable = ds.Tables.Add("Tbl")
        Tables.Columns.Add("Ic", GetType(String))
        Tables.Columns.Add("In", GetType(String))
        Tables.Columns.Add("Old", GetType(String))
        Tables.Columns.Add("New", GetType(String))
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Rows.Clear()
        Dim sql As String = "SELECT SUPPayment.PayDate,SUPPayment.SupCode,SUPPayment.Amount,Supplier.SupName FROM SUPPayment INNER JOIN Supplier ON SUPPayment.SupCode = Supplier.SupCode where SUPPayment.PayDate>='" & DTP1.Value.Date & "'and SUPPayment.PayDate<='" & DTP2.Value.Date & "'and SUPPayment.Amount>0 order by SUPPayment.PayDate "
        cmd = New SqlCommand(sql, con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Tables.Rows.Add(Format(rdr("PayDate"), "yyyy-MM-dd"), rdr("SupName"), rdr("Amount"), "0", "0")
        End While
        rdr.Close()

        Dim xxc As New RptSpList
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xfr", DTP1.Text)
        xxc.SetParameterValue("xto", DTP2.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LinkLabel39_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel39.LinkClicked
        Dim ds As New DataSet3
        Dim Tables As DataTable = ds.Tables.Add("DayEnd")
        Tables.Columns.Add("Dte", GetType(String))
        Tables.Columns.Add("Csl", GetType(String))
        Tables.Columns.Add("Crc", GetType(String))
        Tables.Columns.Add("Cwd", GetType(String))
        Tables.Columns.Add("Exp", GetType(String))
        Tables.Columns.Add("Pay", GetType(String))
        Tables.Columns.Add("Dep", GetType(String))
        Tables.Columns.Add("Rtn", GetType(String))
        Tables.Columns.Add("Crd", GetType(String))
        Tables.Columns.Add("Op", GetType(String))
        Tables.Columns.Add("Chq", GetType(String))
        Tables.Rows.Clear()

        cmd = New SqlCommand("Select * from BalAd where LastUpdate>='" & DTP1.Value.Date & "'and LastUpdate<='" & DTP2.Value.Date & "'order by Aid", con)
        rdr = cmd.ExecuteReader()
        While rdr.Read
            Tables.Rows.Add(rdr("BName"), rdr("Description"), rdr("Debit"), rdr("Credit"), Format(rdr("LastUpdate"), "yyyy-MM-dd"), rdr("UpTime"), rdr("UName"), "-", "-", "-", "-")
        End While
        rdr.Close()

        Dim xxc As New RptBalAd
        xxc.SetDataSource(ds.Tables(1))
        xxc.SetParameterValue("xfr", DTP1.Text)
        xxc.SetParameterValue("xto", DTP2.Text)
        CrystalReportViewer1.ReportSource = xxc
        CrystalReportViewer1.Refresh()

    End Sub
End Class