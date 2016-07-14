
Partial Class modules_services_addindCheckInventory
    Inherits System.Web.UI.Page

    Dim capures As New EasyinvCore.com.objects.InventoryCaptureCollection


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(Request("p")) Then
            Dim str As String = Request("p")
            If str.Contains("|") Then
                Dim items() As String = str.Split("|")
                For Each item As String In items
                    SaveItem(item)
                Next
            End If
        Else
            If Not IsNothing(Request.QueryString("p")) Then
                Dim str As String = Request.QueryString("p")
                If str.Contains("|") Then
                    Dim items() As String = str.Split("|")
                    For Each item As String In items
                        SaveItem(item)
                    Next
                End If
            End If

        End If

        SaveData()
    End Sub

    Protected Sub SaveItem(ByVal value As String)
        If Not IsNothing(value) Then
            If Not value.Equals("") Then
                Dim v() As String = value.Split(":")
                Dim stockunitid As String = v(0)
                Dim realqty As Integer = Integer.Parse(v(1))
                Dim location As String = v(2)

                Dim newinvcapture As New EasyinvCore.com.objects.inventorycapture
                newinvcapture.STOCKUNITID = stockunitid
                newinvcapture.REALQUATITY = realqty
                newinvcapture.CODE = location
                newinvcapture.fechamod = Date.Now.ToString("MM/dd/yyyy")
                capures.Add(newinvcapture)

            End If
        End If

    End Sub

    Protected Sub SaveData()
        If capures.Items.Count > 0 Then
            Dim _ADOEasyInv As New EasyinvCore.com.ADO.ADOEasyInv
            Try
                _ADOEasyInv.AddInventoryCapture(capures)
                Response.Write("0")
            Catch ex As Exception
                Response.Write("1")
            End Try

        End If
    End Sub

End Class
