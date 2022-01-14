Option Explicit On
Option Strict On
Option Infer Off
''
''Added 1/13/2022 thomas downes 
''
Imports System.Windows.Forms ''Added 10/1/2019 thomas downes 
Imports ciBadgeInterfaces ''Added 10/1/2019 thomas downes 
Imports ciBadgeElements ''Added 10/1/2019 thomas downes 
Imports System.Drawing ''Added 10/1/2019 thomas downes 
Imports ciLayoutPrintLib ''Added 10/1/2019 td
Imports ciBadgeCachePersonality ''Added 12/4/2021 thomas d. 
Imports System.IO ''Added 12/3/2021 thomas d.
Imports __RSCWindowsControlLibrary ''Added 1/02/2022 thomas d. 

Public Class ClassDesigner2Sides
    Implements ILayoutFunctions, ISelectingElements, IRecordElementLastTouched, IRefreshPreview
    Implements ILastControlTouchedRSC ''Added 1/2/2022 td 
    ''
    ''Added 1/13/2022 thomas downes 
    ''
    Public Event ElementFieldRightClicked(par_control As CtlGraphicFldLabel) ''Added 10/1/2019 td
    Public Event ElementPortraitRightClicked(par_control As CtlGraphicPortrait) ''Added 12/22/2021 td
    Public Event ElementQRCodeRightClicked(par_control As CtlGraphicQRCode) ''Added 12/15/2021 td
    Public Event ElementSignatRightClicked(par_control As CtlGraphicSignature) ''Added 12/15/2021 td
    Public Event ElementStaticTextRightClicked(par_control As CtlGraphicStaticText) ''Added 12/15/2021 td
    Public Event BackgroundRightClicked(par_mouse_x As Integer, par_mouse_y As Integer) ''Added 10/15/2019 td

    Public WithEvents DesignerForm As Form
    Public WithEvents BackgroundBox_Front As PictureBox
    Public WithEvents BackgroundBox_Backside As PictureBox ''Added 12/10/2021 thomas downes

    Private mod_designerListener As ClassDesignerEventListener
    Public LetEventListenerAddMoveability As Boolean = False ''1/5/2022 td''True ''Added 12/23/2021 td  
    Public LetBaseControlAddMoveability As Boolean = True ''True. See __RSC WindowsControlLibrary\RSCMoveableControlVB.  ---Added 1/05/2022 td  

    Public EnumSideOfCard As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside ''Added 12/8/2021 Thomas downes  

    Public Property PreviewLayoutAsImage As Boolean = True ''Added 10.1.2019 thomas d. 

    Public Property ControlBeingModified As Control Implements ILayoutFunctions.ControlBeingModified
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Control)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ControlBeingMoved As Control Implements ILayoutFunctions.ControlBeingMoved
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Control)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property LastControlTouchedRSC As RSCMoveableControlVB Implements ILastControlTouchedRSC.LastControlTouchedRSC
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As RSCMoveableControlVB)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ElementsDesignList_AllItems As HashSet(Of RSCMoveableControlVB) Implements ISelectingElements.ElementsDesignList_AllItems
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As HashSet(Of RSCMoveableControlVB))
            Throw New NotImplementedException()
        End Set
    End Property

    Public BadgeLayout_Class As ciBadgeInterfaces.BadgeLayoutClass ''Added 10/9/2019 td  
    Private mod_ctlLasttouched As New ClassLastControlTouched ''Added 1/4/2022 td

    Private Const mod_bAddHandlersForRightClick As Boolean = False ''Added 1/5/2022 td

    Public WithEvents PreviewBox As PictureBox

    Public CheckboxAutoPreview As CheckBox ''Added 10/1/2019 td
    Public CheckboxInstantPreview As CheckBox ''Added 12/6/2021 td
    Public DesignerForm_Interface As IDesignerForm ''Added 10/13/2019 td  

    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        Throw New NotImplementedException()
    End Function

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        Throw New NotImplementedException()
    End Function

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        Throw New NotImplementedException()
    End Function

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        Throw New NotImplementedException()
    End Sub

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent
        Throw New NotImplementedException()
    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        Throw New NotImplementedException()
    End Function

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        Throw New NotImplementedException()
    End Sub

    Public Sub RefreshPreview() Implements IRefreshPreview.RefreshPreview
        Throw New NotImplementedException()
    End Sub

    Public Sub RecordElementLastTouched(par_elementMoved As IMoveableElement, par_elementClicked As IClickableElement) Implements IRecordElementLastTouched.RecordElementLastTouched
        Throw New NotImplementedException()
    End Sub

    Public Sub ElementsDesignList_Add(par_control As CtlGraphicFldLabel) Implements ISelectingElements.ElementsDesignList_Add
        Throw New NotImplementedException()
    End Sub

    Public Sub ElementsDesignList_Remove(par_control As CtlGraphicFldLabel) Implements ISelectingElements.ElementsDesignList_Remove
        Throw New NotImplementedException()
    End Sub

    Public Function ElementsList_CountItems() As Integer Implements ISelectingElements.ElementsList_CountItems
        Throw New NotImplementedException()
    End Function

    Public Function ElementsList_OneOrMoreItems() As Boolean Implements ISelectingElements.ElementsList_OneOrMoreItems
        Throw New NotImplementedException()
    End Function

    Public Function ElementsList_TwoOrMoreItems() As Boolean Implements ISelectingElements.ElementsList_TwoOrMoreItems
        Throw New NotImplementedException()
    End Function

    Public Function ElementsList_IsItemIncluded(par_control As RSCMoveableControlVB) As Boolean Implements ISelectingElements.ElementsList_IsItemIncluded
        Throw New NotImplementedException()
    End Function

    Public Function ElementsList_IsItemUnselected(par_control As RSCMoveableControlVB) As Boolean Implements ISelectingElements.ElementsList_IsItemUnselected
        Throw New NotImplementedException()
    End Function

    Public Function HasAtLeastOne__Up(par_control As RSCMoveableControlVB) As Boolean Implements ISelectingElements.HasAtLeastOne__Up
        Throw New NotImplementedException()
    End Function

    Public Function HasAtLeastOne_Down(par_control As RSCMoveableControlVB) As Boolean Implements ISelectingElements.HasAtLeastOne_Down
        Throw New NotImplementedException()
    End Function

    Public Sub SwitchControls___Up(par_control As RSCMoveableControlVB) Implements ISelectingElements.SwitchControls___Up
        Throw New NotImplementedException()
    End Sub

    Public Sub SwitchControls_Down(par_control As RSCMoveableControlVB) Implements ISelectingElements.SwitchControls_Down
        Throw New NotImplementedException()
    End Sub
End Class
