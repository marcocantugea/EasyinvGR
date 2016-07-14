
Partial Class modules_inventory_checkinventory
    Inherits System.Web.UI.Page

    Dim location_result As EasyinvCore.com.objects.StockInventoryCollection
    Dim _ADOEasyinv As EasyinvCore.com.ADO.ADOEasyInv
    Dim inputsresult As EasyinvCore.com.objects.InventoryInputDetailCollection

    Protected Sub btnSearchCode_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchCode.Click
        location_result = New EasyinvCore.com.objects.StockInventoryCollection
        _ADOEasyinv = New EasyinvCore.com.ADO.ADOEasyInv
        inputsresult = New EasyinvCore.com.objects.InventoryInputDetailCollection
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        location_result = New EasyinvCore.com.objects.StockInventoryCollection
        Dim searchcodeval As String = txtSearch.Text


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
            If searchcodeval.Substring(0, 1).Equals("?") Then
                Dim inputs As New EasyinvCore.com.objects.inventoryInputsCollection
                _ADOEasyinv.GetInvenotryInputs(inputs)
                dgvLoadResults.DataSource = inputs.Items
                dgvLoadResults.DataBind()
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

        End If
    End Sub

   
    Protected Sub dgvLoadResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles dgvLoadResults.RowCommand
        If e.CommandName = "LOADDATA" Then
            Try
                location_result = New EasyinvCore.com.objects.StockInventoryCollection
                _ADOEasyinv = New EasyinvCore.com.ADO.ADOEasyInv
                inputsresult = New EasyinvCore.com.objects.InventoryInputDetailCollection
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = dgvLoadResults.Rows(index)
                Dim location = row.Cells(0).Text
                Dim fecha As String = row.Cells(1).Text


                _ADOEasyinv.GetStockInventoryByLocation(location, location_result)
                _ADOEasyinv.GetInputsDetail(location, fecha, inputsresult)

                dgvLoadResults.Visible = False

                grvResults.Columns(0).Visible = True
                grvResults.DataSource = location_result.Items
                grvResults.DataBind()


            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        End If
    End Sub

    Protected Sub dgvLoadResults_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles dgvLoadResults.RowUpdated

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

    Protected Sub btnSearch0stock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch0stock.Click
        location_result = New EasyinvCore.com.objects.StockInventoryCollection
        _ADOEasyinv = New EasyinvCore.com.ADO.ADOEasyInv
        inputsresult = New EasyinvCore.com.objects.InventoryInputDetailCollection
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        location_result = New EasyinvCore.com.objects.StockInventoryCollection
        Dim searchcodeval As String = txtSearch.Text


        If searchcodeval.Substring(0, 1).Equals("/") Then
            Try
                Dim tam As Integer = searchcodeval.Length() - 1
                _ADOEasyinv.GetStockInventoryByLocation(searchcodeval.Substring(1, tam), location_result)

                Dim newrecords As New EasyinvCore.com.objects.StockInventoryCollection

                For Each item As EasyinvCore.com.objects.stockinventory In location_result.Items
                    Dim obj As New EasyinvCore.com.objects.stockinventory
                    If item.GetStock > 0 Then
                        obj = item
                        newrecords.Add(obj)
                    End If
                Next

                grvResults.Columns(0).Visible = True
                grvResults.DataSource = newrecords.Items
                grvResults.DataBind()

            Catch ex As Exception
                Response.Write("Error exception : " & ex.Message)
            End Try
        Else
            If searchcodeval.Substring(0, 1).Equals("?") Then
                Dim inputs As New EasyinvCore.com.objects.inventoryInputsCollection
                _ADOEasyinv.GetInvenotryInputs(inputs)
                dgvLoadResults.DataSource = inputs.Items
                dgvLoadResults.DataBind()
            Else
                Try

                    _ADOEasyinv.SearchStockType(searchcodeval, results)

                    Dim newrecords As New EasyinvCore.com.objects.StockTypeCollection

                    For Each item As EasyinvCore.com.objects.stocktype In results.Items
                        Dim obj As New EasyinvCore.com.objects.stocktype
                        If item.GetStock > 0 Then
                            obj = item
                            newrecords.Add(obj)
                        End If
                    Next

                    grvResults.Columns(0).Visible = False
                    grvResults.DataSource = newrecords.Items
                    grvResults.DataBind()


                Catch ex As Exception
                    Response.Write("Error exception : " & ex.Message)
                End Try
            End If

        End If
    End Sub
End Class
