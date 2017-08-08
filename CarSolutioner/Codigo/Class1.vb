Public Class Class1
    Dim _dt As New DataTable
    Dim _bool As Boolean


    Public Property dt() As DataTable
        Get
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
        End Set
    End Property

    Public Property bool() As Boolean
        Get
            Return _bool
        End Get
        Set(ByVal value As Boolean)
            _bool = value
        End Set
    End Property

End Class
