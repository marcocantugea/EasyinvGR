
Namespace com.objects
    Public Class inventoryintpus

        Private _CODE As String
        Private _fechamod As Date

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