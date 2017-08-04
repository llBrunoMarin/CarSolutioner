Module CustomMenustrip

    'Le decimos a cual MenuStrip le queremos asignar nuestro propio Renderer.
    Public Sub CambiarRenderMenuStrip(menustrip As MenuStrip)
        menustrip.Renderer = New MyRenderer()

    End Sub

    'Creamos nuestro propio Renderer.
    Private Class MyRenderer
        'Nuestro renderer hereda todas las propiedades de ToolStripProfessionalRenderer
        Inherits ToolStripProfessionalRenderer
        Public Sub New()
            MyBase.New(New MyColors())
        End Sub

    End Class

    'Le asignamos nuestros colores personalizados a las propiedades del Renderer.
    Private Class MyColors

        Inherits ProfessionalColorTable
        Public Overrides ReadOnly Property MenuItemSelected() As Color
            Get
                Return Color.FromArgb(150, 38, 38)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientBegin() As Color
            Get
                Return Color.FromArgb(150, 38, 38)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelectedGradientEnd() As Color
            Get
                Return Color.FromArgb(150, 38, 38)
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemBorder() As Color
            Get
                Return Color.FromArgb(150, 38, 38)
            End Get
        End Property


    End Class


End Module
