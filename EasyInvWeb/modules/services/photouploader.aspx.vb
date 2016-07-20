
Partial Class modules_services_photouploader
    Inherits System.Web.UI.Page

    Private _PhotoTMPCol As New Collection
    Private _ADOEasyinv As New EasyinvCore.com.ADO.ADOEasyInv
    Private _DataSource As New Collection


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            FindAllPhotosOnTMP()
            Dim totphotos As Integer = 1
            Dim index As Integer = 1
            For Each i As Object In _PhotoTMPCol
                Try
                    Dim filefound As IO.FileInfo = CType(i, IO.FileInfo)
                    Dim partno As String = i.Name.Substring(0, filefound.Name.Length - 4)
                    Dim results As New EasyinvCore.com.objects.StockTypeCollection

                    If totphotos <= 50 Then
                        FindPart(partno, results)
                        For Each item As EasyinvCore.com.objects.stocktype In results.Items
                            Dim tmpobj As New TMPPhotoSotckitem
                            tmpobj.id = index
                            tmpobj.Photoname = filefound.Name
                            tmpobj.Photopath = filefound.FullName
                            tmpobj.STOCKTYPECODE = item.STOCKTYPECODE
                            tmpobj.NAME = item.NAME
                            tmpobj.PNAME = item.PNAME
                            tmpobj.STOCKTYPEID = item.STOCKTYPEID
                            tmpobj.STOCKUNITID = item.STOCKUNITID
                            _DataSource.Add(tmpobj)
                            index += 1
                            totphotos += 1
                        Next
                    End If
                Catch ex As Exception
                    Console.WriteLine(ex.Message.ToString)
                End Try


            Next


            Session("DataSource") = _DataSource
            GridView1.DataSource = _DataSource
            GridView1.DataBind()
        Else
            If Not IsNothing(Session("DataSource")) Then
                _DataSource = Session("DataSource")
            End If

        End If
    End Sub

    Public Sub FindAllPhotosOnTMP()
        Dim FilesEntries() As String = System.IO.Directory.GetFiles(Server.MapPath("~/modules/services/photo/tmp"))
        For Each i As String In FilesEntries
            Dim objfile As New IO.FileInfo(i)
            _PhotoTMPCol.Add(objfile)
        Next
    End Sub

    Public Sub FindPart(ByVal texttoserach As String, ByVal results As EasyinvCore.com.objects.StockTypeCollection)
        Try
            _ADOEasyinv.SearchStockType(texttoserach, results)
        Catch ex As Exception
            Console.WriteLine(ex.Message.ToString)
        End Try
    End Sub

    Public Class TMPPhotoPart
        Private _fileObj As IO.FileInfo
        Private _Stocktypes As New EasyinvCore.com.objects.StockTypeCollection

        Public Property Stocktypes() As EasyinvCore.com.objects.StockTypeCollection
            Get
                Return _Stocktypes
            End Get
            Set(ByVal value As EasyinvCore.com.objects.StockTypeCollection)
                _Stocktypes = value
            End Set
        End Property

        Public Property fileobj() As IO.FileInfo
            Get
                Return _fileObj
            End Get
            Set(ByVal value As IO.FileInfo)
                _fileObj = value
            End Set
        End Property
    End Class

    Public Class TMPPhotoSotckitem
        Private _id As Integer = -1
        Private _Photoname As String
        Private _Photopath As String
        Private _STOCKTYPEID As Long
        Public _STOCKTYPECODE As String
        Private _NAME As String
        Private _STOCKUNITID As Long
        Private _CODE As String
        Private _PNAME As String
        Private _imagepath As String


        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public ReadOnly Property tmpimagepath() As String
            Get
                Return ConfigurationManager.AppSettings("domain") & "/modules/services/photo/tmp/" & _Photoname
            End Get
        End Property

        Public Property Photopath() As String
            Get
                Return _Photopath
            End Get
            Set(ByVal value As String)
                _Photopath = value
            End Set
        End Property


        Public Property Photoname() As String
            Get
                Return _Photoname
            End Get
            Set(ByVal value As String)
                _Photoname = value
            End Set
        End Property

        Public Property PNAME() As String
            Get
                Return _PNAME
            End Get
            Set(ByVal value As String)
                _PNAME = value
            End Set
        End Property

        Public ReadOnly Property PARTNAME() As String
            Get
                Return _NAME
            End Get
        End Property

        Public ReadOnly Property CODE() As String
            Get
                Return _STOCKTYPECODE
            End Get
        End Property


        Public Property STOCKUNITID() As Long
            Get
                Return _STOCKUNITID
            End Get
            Set(ByVal value As Long)
                _STOCKUNITID = value
            End Set
        End Property

        Public Property NAME() As String
            Get
                Return _NAME
            End Get
            Set(ByVal value As String)
                _NAME = value
            End Set
        End Property

        Public Property STOCKTYPECODE() As String
            Get
                Dim amoscopycode As String
                '01234567890123
                '196901001014
                amoscopycode = _STOCKTYPECODE.Substring(0, 3)
                amoscopycode = amoscopycode & "." & _STOCKTYPECODE.Substring(3, 3)
                amoscopycode = amoscopycode & "." & _STOCKTYPECODE.Substring(6, 3)
                amoscopycode = amoscopycode & "." & _STOCKTYPECODE.Substring(9, 3)
                Return _STOCKTYPECODE
            End Get
            Set(ByVal value As String)
                _STOCKTYPECODE = value
            End Set
        End Property

        Public Property STOCKTYPEID() As Long
            Get
                Return _STOCKTYPEID
            End Get
            Set(ByVal value As Long)
                _STOCKTYPEID = value
            End Set
        End Property

    End Class

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim row As GridViewRow = GridView1.Rows(index)

        If e.CommandName = "SaveLinkRel" Then
            Dim newphoto As New EasyinvCore.com.objects.stocktypephoto
            newphoto.pathphoto = SaveImage(row.Cells(2).Text)
            Dim label As Label = CType(row.Cells(5).FindControl("lblstockunitid"), Label)
            newphoto.STOCKTYPEID = Long.Parse(label.Text)

            Dim _ADOEasyInv As New EasyinvCore.com.ADO.ADOEasyInv
            _ADOEasyInv.AddPhotoToStockType(newphoto)

            If DeleteImageFile(row.Cells(2).Text) Then
                'Console.WriteLine("Delete : " & Server.MapPath("~/modules/services/photo/tmp/") & row.Cells(1).Text)
                IO.File.Delete(Server.MapPath("~/modules/services/photo/tmp/") & row.Cells(2).Text)
            End If

            deleteRowInDaraSource(index + 1)

        End If

        If e.CommandName = "DeleteLinkRel" Then
            If DeleteImageFile(row.Cells(2).Text) Then
                IO.File.Delete(Server.MapPath("~/modules/services/photo/tmp/") & row.Cells(2).Text)
            End If
            deleteRowInDaraSource(index + 1)

        End If

    End Sub

    Public Function SaveImage(ByVal filename As String) As String
        Dim fileweb As String = "photos/parts/" & Date.Now.ToString("hhmmss") & filename
        Try
            Dim filetmp As String = Server.MapPath("photo/tmp/") & filename
            Dim fileper As String = Server.MapPath("../inventory/photos/parts/") & Date.Now.ToString("hhmmss") & filename


            'reducre the jpeg file
            Dim _ImageReziser As New EasyinvCore.com.file.ImageResizer
            _ImageReziser.ResizeImage(filetmp, fileper, 0.5)

        Catch ex As Exception
            Response.Write("Error exception :" & ex.Message.ToString)
        End Try
        Return fileweb
    End Function


    Public Function DeleteImageFile(ByVal filename As String) As Boolean

        Dim exist As Boolean = False
        Dim count As Integer = 0
        For Each r As GridViewRow In GridView1.Rows
            If r.Cells(2).Text = filename Then
                count += 1
            End If
        Next

        If count >= 2 Then
            exist = False
        Else
            exist = True
        End If

        Return exist
    End Function

    Public Sub deleteRowInDaraSource(ByVal index As Integer)
        If Not IsNothing(_DataSource) Then
            If _DataSource.Count > 0 Then
                _DataSource.Remove(index)
                GridView1.DataSource = _DataSource
                GridView1.DataBind()
            End If
        End If
    End Sub


End Class
