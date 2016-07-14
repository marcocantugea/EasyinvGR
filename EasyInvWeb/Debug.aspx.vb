Imports System.Web.Script.Serialization
Imports System.Security.Cryptography

Partial Class Debug
    Inherits System.Web.UI.Page



    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        _ADOEasyinv.SearchStockType(txtSearch.Text, results)

        Response.Write(JSONParse(results.Items))

    End Sub

    Public Function JSONParse(ByVal collection As List(Of EasyinvCore.com.objects.stocktype)) As String
        Dim js As New JavaScriptSerializer()
        Return js.Serialize(collection)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Response.Cookies("UIDC").Values.Count > 0 Then
            If Not Response.Cookies("UIDC")("uidc").Equals("") Then
                Response.Write("Welcome back " & Response.Cookies("UIDC")("uidc"))
            End If
        Else
            Dim name As String = "Marco Cantu Gea"
            Dim deparment As Integer = 1
            Dim uidc As String
            Dim createuidc As String = name & "\mur\" & deparment.ToString
            Dim md5Hash As MD5 = MD5.Create()

            uidc = GetMd5Hash(md5Hash, createuidc)

            'Response.Cookies("UIDC")("name") = name
            'Response.Cookies("UIDC")("deparment") = deparment
            Response.Cookies("UIDC")("uidc") = uidc
            Response.Cookies("UIDC").Expires = Date.Now.AddDays(28)


        End If
    End Sub

    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash


    ' Verify a hash against a string.
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash

End Class
