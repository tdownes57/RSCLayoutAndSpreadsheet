''
''Added 1/16/2022 thomas d. 
''
Imports __RSCWindowsControlLibrary ''Added 1/16/2022 thomas d. 

Public Class CtlClickableDesktop
    ''
    ''Added 1/16/2022 thomas d. 
    ''
    Public Overrides Sub InitializeClickability(par_formParent As Form,
                                                  par_flowLayoutPanel As FlowLayoutPanel) ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/15/2022 thomas downes
        ''
        Me.ParentDesignerForm = par_formParent
        Me.MyFlowLayoutPanel = par_flowLayoutPanel ''Added 1/5/2022 td  
        InitializeClickability()
        AddClickability()

    End Sub ''End of "Public Overridable Sub InitializeClickability"


    Public Overrides Sub InitializeClickability() ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/16/2022 td
        ''
        mod_objOperationsDesktop = New Operations_Desktop()
        mod_objOperationsAny = mod_objOperationsDesktop
        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.__Desktop,
                                                       mod_objOperationsDesktop.GetType(),
                                                       mod_objOperationsDesktop)


    End Sub
End Class
