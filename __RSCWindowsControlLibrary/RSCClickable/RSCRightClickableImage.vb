''
''Added 8/15/2022 thomas downes 
''
Public Class RSCRightClickableImage

    Public Shared Function GetClickable() As RSCRightClickableImage
        ''
        ''Added 8/15/2022
        ''
        Dim objNewControl As New RSCRightClickable
        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperations1Gen As Operations__Generic = Nothing
        Dim objOperations2Use As Operations__Useless = Nothing
        Dim objOperationsRClickable As Operations_RClickableImage ''Added 8/15/2022 td 

        objOperationsRClickable = New Operations_RClickableImage()
        typeOps = objOperationsRClickable.GetType()
        objOperations = objOperationsRClickable

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        objNewControl = New RSCRightClickableImage(typeOps, objOperations)
        Return objNewControl

    End Function ''End of ""Public Shared Function GetClickable() As RSCRightClickableImage""


    Public Sub New(par_operationsType As Type,
                par_operationsAny As Object)

        ''Added 8/15/2022 td  
        mod_objOperationsAny = par_operationsAny
        mod_typeOperations = par_operationsType
        AddClickability()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class
