Imports System.Data.SqlClient
Imports ConnData
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Microsoft.Win32
Public Class FrmRPT1
    Dim xSERVER As String = Nothing
    Dim xPW As String = Nothing
    Private Sub FrmRPT1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xSERVER = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "Server", Nothing)
        xPW = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\HNSOLU001\1.0", "DatabasePw", Nothing)
        Me.Width = Screen.PrimaryScreen.Bounds.Width + 20
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Maximized
        If FrmMDI.txtCNT.Text = "1000" Then
            Dim RPTITMWS As New RPTDINV
            RPTITMWS.RecordSelectionFormula = "{Inv_Main.LastUpdate} ='" & FrmHRPORT.DTP1.Value & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = RPTITMWS.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            CrystalReportViewer1.ReportSource = RPTITMWS
            CrystalReportViewer1.Refresh()
        ElseIf FrmMDI.txtCNT.Text = "4004" Then
            Dim ds As New DataSet1
            Dim Tables As DataTable = ds.Tables.Add("Tbl")
            Tables.Columns.Add("Ic", GetType(String))
            Tables.Columns.Add("In", GetType(String))
            Tables.Columns.Add("Old", GetType(String))
            Tables.Columns.Add("New", GetType(String))
            Tables.Columns.Add("Dte", GetType(String))
            Tables.Rows.Clear()
            cmd = New SqlCommand("Select * from Tth where dte>='" & FrmHRPORT.DTP1.Value.Date & "'and dte<='" & FrmHRPORT.DTP2.Value.Date & "'", con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                Tables.Rows.Add(Format(rdr("dte"), "yyyy-MM-dd"), rdr("ino"), rdr("amn"))
            End While
            rdr.Close()
            Dim xxc As New RPTDINV
            xxc.SetDataSource(ds.Tables(1))
            xxc.SetParameterValue("xFr", FrmHRPORT.DTP1.Text)
            xxc.SetParameterValue("xto", FrmHRPORT.DTP2.Text)
            CrystalReportViewer1.ReportSource = xxc
            CrystalReportViewer1.Refresh()



        ElseIf FrmMDI.txtCNT.Text = "2000" Then
            Dim RPTSITM As New RPTSTITM
            'RPTSITM.RecordSelectionFormula = "{Inv_Main.LastUpdate} ='" & FrmHRPORT.DTP1.Value & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = RPTSITM.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            CrystalReportViewer1.ReportSource = RPTSITM
            CrystalReportViewer1.Refresh()
        ElseIf FrmMDI.txtCNT.Text = "3000" Then
            Dim RPT6 As New RPTPAY
            RPT6.RecordSelectionFormula = "{Pay_Master.LastUpdate} ='" & FrmHRPORT.DTP1.Value & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = RPT6.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            CrystalReportViewer1.ReportSource = RPT6
            CrystalReportViewer1.Refresh()
        ElseIf FrmMDI.txtCNT.Text = "4000" Then
            Dim sls As String = ""
            cmd = New SqlCommand("Select ISNULL(SUM(amn),0) from Tth where dte>='" & FrmHRPORT.DTP1.Value.Date & "'and dte<='" & FrmHRPORT.DTP2.Value.Date & "'", con)
            sls = cmd.ExecuteScalar
            Dim Exp As String = "0"
            'cmd = New SqlCommand("Select ISNULL(SUM(Amnt),0) from Pay_Master where Description like '%" & "CASH PAID" & "%'and LastUpdate>='" & FrmHRPORT.DTP1.Value.Date & "'and LastUpdate<='" & FrmHRPORT.DTP2.Value.Date & "'", con)
            'Exp = cmd.ExecuteScalar
            Dim dd As Double = 0
            If sls > 0 Then
                dd = sls / 100 * 15
                Exp = dd.ToString()
            End If


            Dim RPTDS As New RptDD
            RPTDS.SetParameterValue("sls", sls)
            RPTDS.SetParameterValue("exp", Exp)
            RPTDS.SetParameterValue("dte", FrmHRPORT.DTP1.Text)

            CrystalReportViewer1.ReportSource = RPTDS
            CrystalReportViewer1.Refresh()

        ElseIf FrmMDI.txtCNT.Text = "1122" Then
            Dim RPTVEG As New RPTVEG
            RPTVEG.RecordSelectionFormula = "{Inv_Sub.IType} ='" & "Veg" & "'and {Inv_Sub.LastUpdate}='" & FrmHRPORT.DTP1.Value & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = RPTVEG.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            CrystalReportViewer1.ReportSource = RPTVEG
            CrystalReportViewer1.Refresh()
        ElseIf FrmMDI.txtCNT.Text = "1123" Then
            Dim RPTSITM As New RPT5
            Dim xTY As String = "Veg"
            RPTSITM.RecordSelectionFormula = "{Stock_Main.IType} ='" & xTY & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = RPTSITM.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next
            CrystalReportViewer1.ReportSource = RPTSITM
            CrystalReportViewer1.Refresh()

        ElseIf FrmMDI.txtCNT.Text = "1124" Then
            Dim reportCRD As New PRTCARDPAY
            'Dim xTY As String = "Veg"
            reportCRD.RecordSelectionFormula = "{SalesMaster.LastUpdate}>'" & FrmHRPORT.DTP1.Value & "'and {SalesMaster.LastUpdate}<'" & FrmHRPORT.DTP2.Value & "'"
            'report3.RecordSelectionFormula = "{Salesmaster.LastUpdate} ='" & FrmREPORT.DTP1.Value.ToString("yyyy-MM-dd") & "'"
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            With crConnectionInfo
                .ServerName = xSERVER
                .DatabaseName = "Kristal_Lanka"
                .UserID = "sa"
                .Password = xPW
            End With

            CrTables = reportCRD.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            CrystalReportViewer1.ReportSource = reportCRD
            CrystalReportViewer1.Refresh()
        End If
    End Sub
End Class