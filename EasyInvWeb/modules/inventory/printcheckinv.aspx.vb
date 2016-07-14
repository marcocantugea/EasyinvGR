
Partial Class modules_inventory_printcheckinv
    Inherits System.Web.UI.Page


    Dim location_result As EasyinvCore.com.objects.StockInventoryCollection
    Dim _ADOEasyinv As EasyinvCore.com.ADO.ADOEasyInv
    Dim inputsresult As EasyinvCore.com.objects.InventoryInputDetailCollection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request.QueryString("param1")) And Not IsNothing(Request.QueryString("param2")) Then
            Try
                location_result = New EasyinvCore.com.objects.StockInventoryCollection
                _ADOEasyinv = New EasyinvCore.com.ADO.ADOEasyInv
                inputsresult = New EasyinvCore.com.objects.InventoryInputDetailCollection
                Dim location = Request.QueryString("param1")
                Dim fecha As String = Request.QueryString("param2")


                _ADOEasyinv.GetStockInventoryByLocation(location, location_result)
                _ADOEasyinv.GetInputsDetail(location, fecha, inputsresult)

                dgvPrintCheckinv.Columns(0).Visible = True
                dgvPrintCheckinv.DataSource = location_result.Items
                dgvPrintCheckinv.DataBind()

                lbllocation.Text = location
                lbldate.Text = fecha

            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        End If
    End Sub


    Protected Function getValue(ByVal stockunitid As String) As String
        Dim valuereturn As String = ""

        For Each input As EasyinvCore.com.objects.inventoryinputdetail In inputsresult.Items
            If stockunitid = input.STOCKUNITID Then
                valuereturn = input.REALQUATITY
            End If
        Next

        Return valuereturn
    End Function

End Class
