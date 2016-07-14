
Partial Class modules_inventory_captureinventory
    Inherits System.Web.UI.Page

    Protected Sub btnSearchCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCode.Click
        Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        Dim location_result As New EasyinvCore.com.objects.StockInventoryCollection
        Dim searchcodeval As String = txtSearchcode.Text


        If searchcodeval.Substring(0, 1).Equals("/") Then
            Try
                Dim tam As Integer = searchcodeval.Length() - 1
                _ADOEasyinv.GetStockInventoryByLocation(searchcodeval.Substring(1, tam), location_result)

                grvResults.Columns(0).Visible = True
                grvResults.DataSource = location_result.Items
                grvResults.DataBind()

            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        Else
            Try
                _ADOEasyinv.SearchStockType(searchcodeval, results)
                grvResults.Columns(0).Visible = False
                grvResults.DataSource = results.Items
                grvResults.DataBind()


            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        End If



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub grvResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grvResults.RowCommand
        If e.CommandName = "VIEWDETAIL" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = grvResults.Rows(index)
            Response.Redirect("deatilstockitem.aspx?q=" & row.Cells(4).Text)
        End If
    End Sub

    Protected Sub grvResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvResults.SelectedIndexChanged

    End Sub

    Protected Sub btnsearchnozero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearchnozero.Click
        Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        Dim location_result As New EasyinvCore.com.objects.StockInventoryCollection
        Dim searchcodeval As String = txtSearchcode.Text


        If searchcodeval.Substring(0, 1).Equals("/") Then
            Try
                Dim tam As Integer = searchcodeval.Length() - 1
                _ADOEasyinv.GetStockInventoryByLocation(searchcodeval.Substring(1, tam), location_result)

                Dim newresult As New EasyinvCore.com.objects.StockInventoryCollection

                For Each item As EasyinvCore.com.objects.stockinventory In location_result.Items
                    Dim newobj As EasyinvCore.com.objects.stockinventory
                    If item.GetStock > 0 Then
                        newobj = item
                        newresult.Add(newobj)
                    End If
                Next


                grvResults.Columns(0).Visible = True
                grvResults.DataSource = newresult.Items
                grvResults.DataBind()

            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        Else
            Try
                _ADOEasyinv.SearchStockType(searchcodeval, results)

                Dim newresult As New EasyinvCore.com.objects.StockTypeCollection

                For Each item As EasyinvCore.com.objects.stocktype In results.Items
                    Dim newobj As EasyinvCore.com.objects.stocktype
                    If item.GetStock > 0 Then
                        newobj = item
                        newresult.Add(newobj)
                    End If
                Next

                grvResults.Columns(0).Visible = False
                grvResults.DataSource = newresult.Items
                grvResults.DataBind()


            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        End If
    End Sub
End Class
