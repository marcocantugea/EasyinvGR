
Partial Class modules_inventory_deatilstockitem
    Inherits System.Web.UI.Page
    Dim _ADOEasyInv As New EasyinvCore.com.ADO.ADOEasyInv
    Dim detailstocktype As EasyinvCore.com.objects.stocktype
    Dim isPageRefresh As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            ViewState("ViewStateId") = System.Guid.NewGuid.ToString()
            Session("SessionId") = ViewState("ViewStateId").ToString()
        Else
            If ViewState("ViewStateId").ToString <> Session("SessionId").ToString Then
                isPageRefresh = True
            End If
            Session("SessionId") = System.Guid.NewGuid.ToString()
            ViewState("ViewStateId") = Session("SessionId").ToString()
        End If



        If Not Page.IsPostBack Then
            If Not IsNothing(Request.QueryString("q")) Then
                Dim stockunitid As Long = Long.Parse(Request.QueryString("q"))
                detailstocktype = New EasyinvCore.com.objects.stocktype

                detailstocktype.STOCKUNITID = stockunitid
                _ADOEasyInv.GetStockType(detailstocktype)
                detailstocktype.GetStockInventory()

                Dim datagridcollection As New Collection
                datagridcollection.Add(detailstocktype)
                grvResults.DataSource = datagridcollection
                grvResults.DataBind()

                dgvLocations.DataSource = detailstocktype.Stockinventory.Items
                dgvLocations.DataBind()
                hdstocktypeid.Value = detailstocktype.STOCKUNITID

            End If
        Else
            If Not isPageRefresh Then
                If FileUpload1.HasFile And Not IsNothing(hdstocktypeid.Value) Then
                    Try
                        Dim filetmp As String = Server.MapPath("photos/parts/") & "TMP" & FileUpload1.FileName
                        Dim fileper As String = Server.MapPath("photos/parts/") & Date.Now.ToString("hhmmss") & FileUpload1.FileName
                        Dim fileweb As String = "photos/parts/" & Date.Now.ToString("hhmmss") & FileUpload1.FileName
                        FileUpload1.PostedFile.SaveAs(filetmp)

                        'reducre the jpeg file
                        Dim _ImageReziser As New EasyinvCore.com.file.ImageResizer
                        _ImageReziser.ResizeImage(filetmp, fileper, 0.5)
                        System.IO.File.Delete(filetmp)

                        Dim newphoto As New EasyinvCore.com.objects.stocktypephoto
                        newphoto.pathphoto = fileweb
                        newphoto.STOCKTYPEID = hdstocktypeid.Value
                        _ADOEasyInv.AddPhotoToStockType(newphoto)
                        'Response.Write("File uploaded.")
                        FileUpload1.Dispose()
                        FileUpload1 = New FileUpload
                    Catch ex As Exception
                        Response.Write("Error exception :" & ex.Message.ToString)
                    End Try
                End If
            End If
        End If
    End Sub

    Public Sub LoadInfo()

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
    End Sub

    Protected Sub Unnamed1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim url As String = ConfigurationManager.AppSettings("domain") & "/modules/services/QRGenerator.aspx?param1=" & Request.QueryString("q") & "&param2=" & cmbqrsize.SelectedValue
        Response.Write("<script> window.open( '" & url & "','_blank' ); </script>")
        'Response.End()
    End Sub
End Class
