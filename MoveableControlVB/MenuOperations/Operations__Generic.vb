Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/27/2021 & 10/1/2019 td
''

Imports ciBadgeInterfaces
Imports ciBadgeDesigner
''----Imports ciBadgeElements

Public Class Operations__Generic
    Implements ICurrentElement ''Added 12/28/2021 td
    ''
    ''Added 10/1/2019 td
    ''
    ''Names of procedures in this module: 
    ''  Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
    ''  Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)
    ''  Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
    ''  Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
    ''   Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
    ''  Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
    ''  Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
    ''  Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs) 
    ''   --- Private Sub CreateVisibleButtonMaster(par_strText As String,
    ''
    Public Property Parent_MenuCache As MenuCache_Generic ''Added 12/12/2021 td 

    ''Dec28 2021 td''Public WithEvents MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    ''Dec28 2021 td''Public WithEvents MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 
    Public MyLinkLabel As New LinkLabel ''Added 10/11/2019 td 
    Public MyToolstripItem As New ToolStripMenuItem ''Added 10/11/2019 td 

    ''Dec28 2021''Public Property CtlCurrentElement As MoveableControlVB ''#1 Dec282021 td
    Public Property CtlCurrentElement As MoveableControlVB Implements ICurrentElement.CtlCurrentElement

    ''2021''ciBadgeDesigner.CtlGraphicFldLabel ''CtlGraphicFldLabel
    ''Public Property LayoutFunctions As ILayoutFunctions ''Added 10/3/2019 td 
    ''Public Property Designer As ciBadgeDesigner.ClassDesigner
    ''Public Property ColorDialog1 As ColorDialog ''Added 10/3/2019 td 
    ''Public Property FontDialog1 As FontDialog ''Added 10/3/2019 td 

    ''''---not needed 10/3/2019 td----Public Property GroupEdits As ClassGroupMove ''Added 10/3/2019 td 
    ''Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 

    ''Added 12/12/2021 thomas 
    ''Public Property ListOfFields_Standard As HashSet(Of ciBadgeFields.ClassFieldStandard)
    ''Public Property ListOfFields_Custom As HashSet(Of ciBadgeFields.ClassFieldCustomized)
    ''12/28/2021 thomas''Public Property CacheOfFieldsEtc As ciBadgeCachePersonality.ClassElementsCache_Deprecated

    Private mod_fauxMenuEditSingleton As CtlGraphPopMenuEditSingle ''Added 10/3/2019 td 


    Public Sub New() ''Dec28, 2021''par_currentControlVB As MoveableControlVB)
        ''
        ''Added 12/28/2021 td
        ''
        ''Dec28, 2021''Me.CtlCurrentElement = par_currentControlVB

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"


    Public Sub New(par_currentControlVB As MoveableControlVB)
        ''
        ''Added 12/28/2021 td
        ''
        Me.CtlCurrentElement = par_currentControlVB

    End Sub ''End of "Public Sub New(par_currentControlVB As MoveableControlVB)"

    ''Names of procedures in this module: 
    ''  Public Sub Open_Field_Of_Element_EE1011(sender As Object, e As EventArgs)
    ''  Public Sub Choose_Background_Color_EE1010(sender As Object, e As EventArgs)
    ''  Public Sub Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)
    ''  Public Sub ExampleValue_Edit_EE1006(sender As Object, e As EventArgs)
    ''   Public Sub Open_OffsetText_Dialog_EE1007(sender As Object, e As EventArgs)
    ''  Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
    ''  Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
    ''  Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs) 
    ''   --- Private Sub CreateVisibleButtonMaster(par_strText As String,
    ''
    Public Sub Name_Of_This_Control_GG7011(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        MessageBoxTD.Show_Statement("The name of this control is: " & Me.CtlCurrentElement.Name)

    End Sub


    Public Sub This_Is_A_Generic_Operation_GG7001(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub This_Is_A_Generic_Operation_GG7002(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub This_Is_A_Generic_Operation_GG7003(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''

    End Sub


    Public Sub Moveability_Add_GG7004(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.AddMoveability()

    End Sub


    Public Sub Moveability_Remove_GG7005(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveMoveability()

    End Sub


    Public Sub RightClickability_Add_GG7006(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.AddClickability()

    End Sub


    Public Sub RightClickability_Remove_GG7007(sender As Object, e As EventArgs)
        ''
        ''Added 12/28/2021 thomas downes  
        ''
        CtlCurrentElement.RemoveClickability()

    End Sub



    Public Sub How_Context_Menus_Are_Generated_EE9001(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 12/12/2021 thomas downes  
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"


    Private Sub CreateVisibleButtonMaster(par_strText As String, par_handler As EventHandler,
                                          ByRef pboolExitEarly As Boolean,
                                           Optional pboolAlignment As Boolean = False)
        ''10/10/2019 td''Private Sub CreateVisibleButton_Master(
        ''
        ''Added 8/13/2019 td  
        ''
        ''10/2/2019 td''If (mod_bBypassCreateButton) Then
        ''    ''Added 8/13/2019 td  
        ''    pboolExitEarly = False  ''Reinitialize. 
        ''    mod_bBypassCreateButton = False ''Reinitialize. 

        ''10/2/2019 td''ElseIf (Me.LayoutFunctions.OkayToShowFauxContextMenu()) Then
        ''    ''8/14/2019 td''ElseIf (mc_CreateVisibleButtonForDemo) Then
        ''    ''9/19/2019 td''ElseIf (Me.FormDesigner.OkayToShowFauxContextMenu()) Then
        ''    ''
        ''    ''Added 8 / 13 / 2019 td 
        ''    ''
        ''    ''8/14/2019 td''CreateVisibleButton(par_strText, par_handler)
        ''    CreateFauxContextMenu(par_strText, par_handler, pboolAlignment)
        ''    mod_bBypassCreateButton = True ''Reinitialize. 
        ''    pboolExitEarly = True

        ''End If ''End of "If (mod_bBypassCreateButton) Then .... ElseIf (mc_CreateVisibleButtonForDemo) Then ...."

    End Sub ''End of "Private Sub CreateMouseButton_Master(par_strText As String, par_handler As EventHandler)"


End Class
