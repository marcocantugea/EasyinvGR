
Partial Class modules_services_saveextphoto
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("param1")) And Not IsNothing(Request.QueryString("param2")) Then

        End If
    End Sub
End Class
