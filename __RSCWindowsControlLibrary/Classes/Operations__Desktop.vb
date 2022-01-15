Option Explicit On
Option Strict On
Option Infer Off
''
''Added 1/15/2022 td
''

Imports ciBadgeInterfaces
''----Imports ciBadgeDesigner
''----Imports ciBadgeElements

Public Class Operations__Desktop
    Implements ICurrentElement ''Added 1/15/2022 td
    ''
    ''Added 1/15/2022 td
    ''
    ''Names of procedures in this module: 
    ''
    Public Property Parent_MenuCache As MenuCache_Generic ''Added 12/12/2021 td 

    ''Dec28 2021 td''Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    ''Dec28 2021 td''Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 
    Public MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public ParentDesignerForm As IDesignerForm_Desktop ''Added 1/15/2022 td

    ''Dec28 2021''Public Property CtlCurrentElement As MoveableControlVB ''#1 Dec282021 td
    ''Jan15 2022 td''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td

    Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As RSCMoveableControlVB)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Sub New()
        ''
        ''Added 1/15/2022 td
        ''

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"


    Public Sub New(par_currentForm As IDesignerForm_Desktop,
                   par_iLayoutFunctions As ILayoutFunctions)
        ''
        ''Added 12/28/2021 td
        ''
        ''Jan15 2022''Me.CtlCurrentForm = par_currentForm
        Me.ParentDesignerForm = par_currentForm

        ''Jan11 2022''Me.EventsForMoveability = par_eventsForMoveability ''Added 1/3/2022 thomas d. 
        ''Me.EventsForMoveability_Group = par_eventsForMoveability_Group ''Added 1/3/2022 thomas d. 
        ''Me.EventsForMoveability_Single = par_eventsForMoveability_Single ''Added 1/3/2022 thomas d. 
        Me.LayoutFunctions = par_iLayoutFunctions ''Added 1/4/2022 td

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"





End Class
