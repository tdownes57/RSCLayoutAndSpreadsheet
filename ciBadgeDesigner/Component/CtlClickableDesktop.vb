''
''Added 1/16/2022 thomas d. 
''
Imports __RSCWindowsControlLibrary ''Added 1/16/2022 thomas d. 
Imports ciBadgeCachePersonality ''Added 1/18/2022 thomas d.
Imports ciBadgeInterfaces ''Added 1/18/2022 thomas d.

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

        ''InitializeClickability()
        ''AddClickability()

    End Sub ''End of "Public Overridable Sub InitializeClickability"


    Public Sub InitializeFunctionality(par_iDesignerForm As IDesignerForm,
                                                par_formParent As Form,
                                       par_iLayoutFunctions As ILayoutFunctions,
                                       par_objectDesigner As ClassDesigner) ''Jan15 2022'' par_designer As ClassDesigner)
        ''
        ''Added 1/16/2022 td
        ''
        mod_objOperationsDesktop = New Operations_Desktop()

        ''----DIFFICULT & CONFUSING----
        ''  Why does it take three(3) lines to assign the .DesignerClass property?
        ''  Answer: Because the property .DesignerClass exists in the child class,
        ''  __NOT__ in the parent class.  The object mod_objOperationsDesktop 
        ''  was declared as the parent type, not the child type.  Plus the syntax
        ''  in VB.NET is less compact than the syntax of C#.  
        ''               ---January 18 2022
        ''
        Dim objOperationsDesktop As Operations_Desktop
        objOperationsDesktop = CType(mod_objOperationsDesktop, Operations_Desktop)
        objOperationsDesktop.DesignerClass = par_objectDesigner

        mod_objOperationsAny = mod_objOperationsDesktop
        mod_menuCacheNonShared = New MenuCache_NonShared(EnumElementType.__Desktop,
                                                       mod_objOperationsDesktop.GetType(),
                                                       mod_objOperationsDesktop)

        ''Added 1/18/2022 td
        With mod_objOperationsDesktop
            .ParentDesignerForm = par_iDesignerForm
            .ParentForm = par_formParent
            .LayoutFunctions = par_iLayoutFunctions

        End With

    End Sub ''End of "Public Overloads Sub InitializeFunctionality"



End Class
