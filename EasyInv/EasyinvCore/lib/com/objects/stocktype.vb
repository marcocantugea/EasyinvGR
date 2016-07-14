Imports EasyinvCore.com.ADO

Namespace com.objects
    Public Class stocktype

        Private _STOCKTYPEID As Long
        Public _STOCKTYPECODE As String
        Private _NAME As String
        Private _STOCKUNITID As Long
        Private _Stockinventory As StockInventoryCollection
        Private _photos As New StockTypePhotoCollection
        Private _CODE As String
        Private _PNAME As String

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

        Public Property Photos() As StockTypePhotoCollection
            Get
                Return _photos
            End Get
            Set(ByVal value As StockTypePhotoCollection)
                _photos = value
            End Set
        End Property

        Public Sub GetStockInventory()
            Dim _ADOEasyInv As New ADOEasyInv
            _ADOEasyInv.GetStockInventory(Me)
        End Sub

        Public ReadOnly Property GetStock() As Integer
            Get
                Dim result = 0
                Dim _ADOEasyInv As New ADOEasyInv
                result = _ADOEasyInv.GetOnHandStockType(Me)
                Return result
            End Get
        End Property

        Public Property Stockinventory() As StockInventoryCollection
            Get
                Return _Stockinventory
            End Get
            Set(ByVal value As StockInventoryCollection)
                _Stockinventory = value
            End Set
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
                Return amoscopycode
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
End Namespace
