Namespace com.objects
    Public Class inventorycapture

        Private _IDinvcap As Integer = -1
        Private _STOCKUNITID As Long
        Private _REALQUATITY As Integer
        Private _CODE As String
        Private _fechamod As Date

        Public Property fechamod() As Date
            Get
                Return _fechamod
            End Get
            Set(ByVal value As Date)
                _fechamod = value
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

        Public Property REALQUATITY() As Integer
            Get
                Return _REALQUATITY
            End Get
            Set(ByVal value As Integer)
                _REALQUATITY = value
            End Set
        End Property

        Public Property STOCKUNITID() As String
            Get
                Return _STOCKUNITID
            End Get
            Set(ByVal value As String)
                _STOCKUNITID = value
            End Set
        End Property

        Public Property IDinvcap() As Integer
            Get
                Return _IDinvcap
            End Get
            Set(ByVal value As Integer)
                _IDinvcap = value
            End Set
        End Property

    End Class
End Namespace
