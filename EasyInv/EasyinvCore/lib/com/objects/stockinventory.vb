Namespace com.objects
    Public Class stockinventory

        Private _STOCKTYPEID As Long
        Public _STOCKTYPECODE As String
        Private _NAME As String
        Private _STOCKUNITID As Long
        Private _STOCKLOCATIONID As Long
        Private _ONHAND As Integer
        Private _CODE As String
        Private _PARTNAME As String
        Private _PNAME As String

        Public Property PNAME() As String
            Get
                Return _PNAME
            End Get
            Set(ByVal value As String)
                _PNAME = value
            End Set
        End Property

        Public ReadOnly Property GetStock() As Integer
            Get
                Return _ONHAND
            End Get
        End Property

        Public Property PARTNAME() As String
            Get
                Return _PARTNAME
            End Get
            Set(ByVal value As String)
                _PARTNAME = value
            End Set
        End Property

        Public Property CODE() As String
            Get
                Return _CODE
            End Get
            Set(ByVal value As String)
                _CODE = value
            End Set
        End Property

        Public Property ONHAND() As Integer
            Get
                Return _ONHAND
            End Get
            Set(ByVal value As Integer)
                _ONHAND = value
            End Set
        End Property

        Public Property STOCKLOCATIONID() As Long
            Get
                Return _STOCKLOCATIONID
            End Get
            Set(ByVal value As Long)
                _STOCKLOCATIONID = value
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
