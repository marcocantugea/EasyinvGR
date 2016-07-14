
Partial Class modules_services_deletestockphoto
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("param1")) Then
            Dim stockphoto As New EasyinvCore.com.objects.stocktypephoto
            stockphoto.IDstocktypephoto = Request.QueryString("param1")
            Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
            Try
                _ADOEasyinv.GetPhotoStock(stockphoto)
                _ADOEasyinv.DeletePhoto(stockphoto)
                System.IO.File.Delete(Server.MapPath("~/modules/inventory/" & stockphoto.pathphoto))
            Catch ex As Exception
                Response.Write("Error on:" & ex.Message.ToString)
            End Try


        End If

    End Sub
End Class
