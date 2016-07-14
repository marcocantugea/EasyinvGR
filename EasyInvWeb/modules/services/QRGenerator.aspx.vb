
Partial Class modules_services_QRGenerator
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim size As Integer = 0
        If Not IsNothing(Request.QueryString("param1")) Then
            Dim id As String = Request.QueryString("param1")
            If Not IsNothing(Request.QueryString("param2")) Then
                size = Integer.Parse(Request.QueryString("param2"))
            End If

            Dim text As String = ConfigurationManager.AppSettings("domain") & "/modules/inventory/deatilstockitem.aspx?q=" & id
            Dim _qrcodegen As New EasyinvCore.ext.QRCodeGenerator
            Dim img As String
            img = _qrcodegen.GenerateQRCode(text, Server.MapPath("~/img"))
            imgQRCode.ImageUrl = ConfigurationManager.AppSettings("domain") & "/" & img

            Select Case size
                Case 1
                    imgQRCode.Width = 100
                Case 2
                    imgQRCode.Width = 150
                Case 3
                    imgQRCode.Width = 200
                Case 4
                    imgQRCode.Width = 300
                Case 5
                    imgQRCode.Width = 400

            End Select

        End If
    End Sub
End Class
