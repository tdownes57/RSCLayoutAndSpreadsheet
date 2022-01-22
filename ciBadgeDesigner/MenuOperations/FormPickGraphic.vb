''
''Added 1/21/2022 thomas downes
''
Imports System.Drawing
Imports System.Resources

Public Class FormPickGraphic

    Public Property ListOfImages As List(Of Image)


    Private Sub FormPickGraphic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/21/2022 thomas downes
        ''
        Load_ApplicationResources()

        lOAD_iMAGESFROMFILE()


    End Sub


    Private Sub lOAD_iMAGESFROMFILE()




    End Sub


    Private Sub Load_ApplicationResources()
        ''ListOfImages.AddRange(My.Application)

        ''    // Create a resource manager.
        ''ResourceManager rm = New ResourceManager("rmc",
        ''                         TypeOf (Example).Assembly);

        ''Dim objRM As New resourcemanager("rmc", )
        Dim assembly As System.Reflection.Assembly
        assembly = Me.GetType.Assembly
        Dim myOtherAssembly As System.Reflection.Assembly
        myOtherAssembly = System.Reflection.Assembly.Load("ResourceAssembly")

        ' Creates the ResourceManager'.

        Dim resourceManager As New System.Resources.ResourceManager("ResourceNamespace.myResources", assembly)

        ''Dim resString As System.String
        Dim resObj As System.Drawing.Image
        ''resString = resourceManager.GetString("StringResource")
        resObj = CType(resourceManager.GetObject("ImageResource"),
            System.Drawing.Image)

    End Sub
End Class