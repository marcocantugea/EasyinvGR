Imports System.Web.Script.Serialization

Partial Class modules_services_searchstocktype
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Request.QueryString("searchcode")) Then
                Dim searchtext As String = Request.QueryString("searchcode")
                Dim _ADOEasyInv As New EasyinvCore.com.ADO.ADOEasyInv
                Dim result As New EasyinvCore.com.objects.StockTypeCollection
                Try
                    _ADOEasyInv.SearchStockType(searchtext, result)
                    Dim parsejson As New JavaScriptSerializer()
                    Response.Write(parsejson.Serialize(result.Items))
                Catch ex As Exception
                    Response.Write("Eror Exception: " & ex.Message.ToString)
                End Try
            End If
        End If
    End Sub
End Class
