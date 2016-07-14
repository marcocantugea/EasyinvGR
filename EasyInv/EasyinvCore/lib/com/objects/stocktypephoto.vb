
Namespace com.objects
    Public Class stocktypephoto

        Private _IDstocktypephoto As Integer = -1
        Private _pathphoto As String
        Private _STOCKTYPEID As Long

        Public Property STOCKTYPEID() As Long
            Get
                Return _STOCKTYPEID
            End Get
            Set(ByVal value As Long)
                _STOCKTYPEID = value
            End Set
        End Property

        Public Property pathphoto() As String
            Get
                Return _pathphoto
            End Get
            Set(ByVal value As String)
                _pathphoto = value
            End Set
        End Property

        Public Property IDstocktypephoto() As Integer
            Get
                Return _IDstocktypephoto
            End Get
            Set(ByVal value As Integer)
                _IDstocktypephoto = value
            End Set
        End Property

    End Class
End Namespace
