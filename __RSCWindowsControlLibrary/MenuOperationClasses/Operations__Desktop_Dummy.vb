﻿Option Explicit On
Option Strict On
Option Infer Off

''
''Added 1/15/2022 td
''
Imports ciBadgeInterfaces
''3/2023 Imports ciBadgeDesigner
''----Imports ciBadgeElements
Imports ciBadgeCachePersonality ''Added 1/18/2022 td

Public Class Operations__Desktop_Dummy
    Implements ICurrentElement ''Added 1/15/2022 td
    ''
    ''Added 1/15/2022 td
    ''
    ''Names of procedures in this module: 
    ''
    Public Property Parent_MenuCache As MenuCache_Generic_NotUsed ''Added 12/12/2021 td 

    ''Dec28 2021 td''Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    ''Dec28 2021 td''Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 
    Public MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    Public ParentDesignerForm_NotInUse As IDesignerForm_Desktop ''Added 1/15/2022 td
    Public ParentDesignerForm As IDesignerForm ''Added 1/18/2022 td
    Public ParentForm As Form ''Added 1/18/2022 Thomas DOWNES
    ''Cannot be placed here.''Public Designer As ClassDesigner ''Added 1/18/2022 td

    ''Dec28 2021''Public Property CtlCurrentElement As MoveableControlVB ''#1 Dec282021 td
    ''Jan15 2022 td''Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td

    Public Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property CtlCurrentControl As Control ''---Implements ICurrentElement.CtlCurrentElement

    Public Sub New()
        ''
        ''Added 1/15/2022 td
        ''

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"


    Public Sub New(par_currentForm As IDesignerForm,
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


    Public Sub This_Is_A_Desktop_Operation_DD2002(sender As Object, e As EventArgs)
        ''
        ''Added 1/15/2021 thomas downes  
        ''
        MessageBoxTD.Show_Statement("You probably right-clicked the desktop!!")

    End Sub



End Class
