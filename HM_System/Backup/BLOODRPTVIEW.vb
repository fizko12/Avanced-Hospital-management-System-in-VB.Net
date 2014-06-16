Imports CrystalDecisions.CrystalReports.Engine

Public Class BLOODRPTVIEW

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim cryRpt As New ReportDocument
        cryRpt.Load("D:\HM System\crystalreport2.rpt")
        CrystalReportViewer1.ReportSource = cryRpt
        CrystalReportViewer1.Refresh()
    End Sub


End Class