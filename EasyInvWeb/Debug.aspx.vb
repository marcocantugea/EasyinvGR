Imports System.Web.Script.Serialization
Imports System.Security.Cryptography

Partial Class Debug
    Inherits System.Web.UI.Page



    Public Function CreateQuery() As String
        ' cremaos y llenamos nuestro objeto de stocktypephoto
        Dim newobj As New EasyinvCore.com.objects.stocktypephoto
        newobj.STOCKTYPEID = 22342342
        newobj.pathphoto = "photos/tmp/photo.jpg"

        'creamos nuestro querybuilder
        'al momento de crear nuestro objeto debemos decirle que es tipo stocktypephoto
        Dim querybuilder As New EasyinvCore.com.ADO.QueryBuilder(Of EasyinvCore.com.objects.stocktypephoto)
        'tenemos que definir que instruccion vamos a crear
        querybuilder.TypeQuery = EasyinvCore.com.ADO.TypeQuery.Insert
        'ahora debemos darle la informacion que tomara para hacer nuestro query
        querybuilder.Entity = newobj
        'ahora tenemos que generear nuestra instruccion y tenemos que decirle que tabla de nuestra base
        'de datos usara
        querybuilder.BuildInsert("stocktypephotos")

        'regreamos nuestro query construido
        Return querybuilder.Query

    End Function


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
        Dim results As New EasyinvCore.com.objects.StockTypeCollection
        _ADOEasyinv.SearchStockType(txtSearch.Text, results)

        Response.Write(JSONParse(results.Items))

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

    Public Function JSONParse(ByVal collection As List(Of EasyinvCore.com.objects.stocktype)) As String
        Dim js As New JavaScriptSerializer()
        Return js.Serialize(collection)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'declaramos nuestra variable de resultado la cual va a obtener
        'objetos de tipo stocktypephoto
        Dim resultado As New EasyinvCore.com.objects.StockTypePhotoCollection
        'declaramos nuestro objeto ADO
        Dim _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv

        'buscamos las fotos del stockunitid = 248030605
        _ADOEasyinv.GetPhotosStock(248030605, resultado)

        'asociamos los datos del resusltado con el gridview
        'debemos regresar los objetos con la propiedad items
        GridView1.DataSource = resultado.Items
        'se imprime el gridview
        GridView1.DataBind()


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

    Public Sub LlenarCollection()
        'Declaramos nuestro objeto de stocktypephoto
        Dim newobj As New EasyinvCore.com.objects.stocktypephoto
        'asignamos valores al objeto 
        newobj.STOCKTYPEID = 240938938
        newobj.pathphoto = "esta es una prueba"

        'creamos nuestra coleccion de datos
        Dim newcollection As New EasyinvCore.com.objects.StockTypePhotoCollection
        'agregamos el objeto a la coleccion 
        newcollection.Add(newobj)


        'Leer coleccion de datos
        For Each objeto As EasyinvCore.com.objects.stocktypephoto In newcollection.Items
            'imprime en pantalla el valor de stocktypeid
            Console.WriteLine(objeto.STOCKTYPEID.ToString)
        Next

    End Sub



End Class
