Namespace com.objects
    Public Class inventoryinputdetail


        Private _CODE As String
        Private _fechamod As Date
        Private _STOCKUNITID As Long
        Private _REALQUANTITY As Integer
        Private _IDinvcap As Integer = -1

        Public Property IDinvcap() As Integer
            Get
                Return _IDinvcap
            End Get
            Set(ByVal value As Integer)
                _IDinvcap = value
            End Set
        End Property

        Public Property REALQUATITY() As Integer
            Get
                Return _REALQUANTITY
            End Get
            Set(ByVal value As Integer)
                _REALQUANTITY = value
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

        Public Property fechamod() As String
            Get
                Return _fechamod.ToString("MM/dd/yyyy")
            End Get
            Set(ByVal value As String)
                _fechamod = Date.Parse(value)
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

    End Class
End Namespace