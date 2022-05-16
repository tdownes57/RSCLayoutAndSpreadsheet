Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
''Imports ciBadgeDesigner
''Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 
Imports MoveAndResizeControls_Monem ''Added 2/02/2022 thomas d. 

Public MustInherit Class Operations__Base
    Implements ICurrentElement ''Added 12/28/2021 td
    Implements IRightClickMouseInfo ''Added 2/5/2022 td
    ''
    ''Added 12/12/2021 td
    ''
    ''Added keyword "MustInherit" on 1/21/2022, so that I could have the 
    ''  Public Property Element_Type have the same keyword ("MustInherit")
    ''  (which in turn caused the Class itself to require the same keyword).
    ''   ----1/21/2022 td
    ''

    Public Overridable Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property ElementsCacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements ICurrentElement.ElementsCacheManager

    ''Added 2/05/2022 td
    Public Property MouseclickX As Integer Implements IRightClickMouseInfo.MouseclickX
    Public Property MouseclickY As Integer Implements IRightClickMouseInfo.MouseclickY

    Public Property NameOfClass As String ''Added 12/30/2021 td
    Public Property ElementInfo_Base As IElement_Base ''Added 1/19/2022 thomas d. 
    Public MustOverride Property Element_Type As Enum_ElementType ''Added 1/19/2022 td 

    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td

    Public Property CtlCurrentForm As Form ''Added 5/5/2022 thomas d. 
    Public Property CtlCurrentControl As Control ''---Implements ICurrentElement.CtlCurrentElement

    ''Feb2 2022 ''Public Property MonemMovement_SingleControl As MonemControlMove_AllFunctionality ''Added 2/2/2022
    Public Property Monem_iMoveOrResizeFun As IMonemMoveOrResizeFunctionality ''Added 2/2/2022
    Public Property InfoRefresh As IRefreshCardPreview ''Added 5/10/2022 td


    Public Sub Switch_To_Other_Side_Of_Badge_BA1001(sender As Object, e As EventArgs)
        ''
        ''Stubbed 12/30/2021 td
        ''Programmed 1/17/2022 td 
        ''
        Dim enumCurrentSide As ciBadgeInterfaces.EnumWhichSideOfCard
        Dim enumSwitchToSide As ciBadgeInterfaces.EnumWhichSideOfCard
        Dim boolSuccess As Boolean ''Added 1/21/2022td

        enumCurrentSide = CtlCurrentElement.ElementInfo_Base.WhichSideOfCard

        If (enumCurrentSide = EnumWhichSideOfCard.EnumBackside) Then
            enumSwitchToSide = EnumWhichSideOfCard.EnumFrontside
        Else
            enumSwitchToSide = EnumWhichSideOfCard.EnumBackside
        End If

        ''Change the element's enumerated value. 
        CtlCurrentElement.ElementInfo_Base.WhichSideOfCard = enumSwitchToSide

        ''Important call. 
        ElementsCacheManager.SwitchElementToOtherSideOfCard(CtlCurrentElement.ElementInfo_Base, Me.Element_Type, boolSuccess)

        If (boolSuccess) Then
            ''Added 1/17/2022 td
            MessageBoxTD.Show_Statement("For the change to have a visible effect, you will need to switch to the " &
                                    "other side of the card.")
        Else
            ''Added 1/21/2022 td 
            MessageBoxTD.Show_Statement("Unfortunately, we could not find that element!!  Sorry!!")
        End If ''Endo  f'"If (boolSuccess) Then .... Else ...."

    End Sub ''End of Public Sub Move_To_Other_Side_Of_Badge_BA1001


    Public Sub Delete_Element_From_Badge_BA1019(sender As Object, e As EventArgs)
        ''
        ''Stubbed 1/19/2022 thomas downes
        ''
        Dim boolSuccess As Boolean
        Dim bElementIsPortraitPic As Boolean ''5/5/2022
        Dim bElementIsQRCode As Boolean ''5/5/2022
        Dim bElementIsSig As Boolean ''5/5/2022
        Dim bElementIsGraphic As Boolean ''5/16/2022
        Dim bElementIsStaticText As Boolean ''5/16/2022

        Dim bConfirmDelete As Boolean ''Added 5/5/20222
        Dim strTextForElement As String ''Added 5/10/2022 

        ''Added 5/10/2022 td
        strTextForElement = Me.Element_Type.ToString
        If (Me.Element_Type = Enum_ElementType.Field) Then
            strTextForElement &= (" - " & Me.CtlCurrentElement.ToString())
        End If

        ''Added 5/5/2022
        bConfirmDelete = MessageBoxTD.Show_Confirmed("Delete element?",
                                                     strTextForElement, True)
        If (Not bConfirmDelete) Then Exit Sub

        bElementIsPortraitPic = (CtlCurrentElement.ElemIfApplicable_IPic IsNot Nothing)
        bElementIsQRCode = (CtlCurrentElement.ElemIfApplicable_IQRCode IsNot Nothing)
        bElementIsSig = (CtlCurrentElement.ElemIfApplicable_ISig IsNot Nothing)
        bElementIsGraphic = (CtlCurrentElement.ElemIfApplicable_IGraphic IsNot Nothing)
        bElementIsStaticText = (CtlCurrentElement.ElemIfApplicable_ITextOnly IsNot Nothing)

        Application.DoEvents() ''Added 5/15/2022 

        ElementsCacheManager.DeleteElementFromCache(CtlCurrentElement.ElementInfo_Base,
                                                    Me.Element_Type, boolSuccess)

        ''Added 5/5/2022 td
        ''
        ''   Unfortunately, the function call above is not very reliable.  
        ''      Often it fails to find the element.  
        ''
        Dim oRSC As RSCMoveableControlVB = CtlCurrentElement

        With ElementsCacheManager
            If ((Not boolSuccess) And bElementIsPortraitPic) Then
                ''Pic = Portrait Picture
                .DeleteElementFromCache_Pic(oRSC.ElemIfApplicable_IPic, False, False, boolSuccess)

            ElseIf ((Not boolSuccess) And bElementIsQRCode) Then
                ''QR = QR Code
                .DeleteElementFromCache_QR(oRSC.ElemIfApplicable_IQRCode, False, False, boolSuccess)

            ElseIf ((Not boolSuccess) And bElementIsSig) Then
                ''Sig = Signature
                .DeleteElementFromCache_Sig(oRSC.ElemIfApplicable_ISig, False, False, boolSuccess)

            ElseIf ((Not boolSuccess) And bElementIsGraphic) Then
                ''Graphic = Static Graphic
                .DeleteElementFromCache_Graphic(oRSC.ElemIfApplicable_IGraphic, False, False, boolSuccess)

            ElseIf ((Not boolSuccess) And bElementIsStaticText) Then
                ''
                ''Text = Static Text
                ''
                ''VersionV3
                If (Not boolSuccess) Then
                    .DeleteElementFromCache_StaticTextV3(oRSC.ElemIfApplicable_ITextOnly, False, False, boolSuccess)
                End If
                ''Version V4
                If (Not boolSuccess) Then
                    .DeleteElementFromCache_StaticTextV4(oRSC.ElemIfApplicable_ITextOnly, False, False, boolSuccess)
                End If

            End If ''End of ""If ((Not boolSuccess) And bElementIsPortraitPic) Then... ElseIf... ElseIf...
        End With ''End of ""With ElementsCacheManager""

        If (boolSuccess) Then
            ''---MessageBoxTD.Show_Statement("For the change to have a visible effect, you will need to save & refresh.")
            MessageBoxTD.Show_Statement("The element been removed from the design-layout XML.",
                  "We will now try to remove it from the UI designer." & vbCrLf_Deux &
                  "You might need to save & refresh the layout-designer to clear it out.")
            ''Remove the control.  
            Me.CtlCurrentForm.Controls.Remove(CtlCurrentControl)
            Me.InfoRefresh.RefreshCardPreview() ''Added 5/10/2022 td
            ''Added 5/11/2022 td 
            Me.ElementsCacheManager.CacheForEditing.UserHasDeletedElements = True

        Else
            ''Added 1/21/2022 td 
            MessageBoxTD.Show_Statement("Unfortunately, we could Not find that element!!  Sorry!!")

        End If ''Endo  f'"If (boolSuccess) Then .... Else ...."

    End Sub ''End of Public Sub Delete_Element_From_Badge_BA1001


    Private Sub Rotate_90_Degrees_BA1079(sender As Object, e As EventArgs)
        ''
        ''Copy-pasted 1/24/2022 thomas downes
        ''Added 7/30/2019 thomas downes
        ''  
        ''Me.ElementInfo_Pic.OrientationToLayout = "L"

        ''9/2/2019 td''Select Case Me.ElementInfo_Pic.OrientationToLayout
        Select Case Me.ElementInfo_Base.OrientationToLayout
            Case "", " ", "P"
                Me.ElementInfo_Base.OrientationToLayout = "L"
            Case "L"
                Me.ElementInfo_Base.OrientationToLayout = "P"
            Case Else
                Me.ElementInfo_Base.OrientationToLayout = "P"
        End Select ''End of "Select Case Me.ElementInfo_Base.OrientationToLayout"

        ''Added 8/12/2019 thomas downes 
        ''   Increment by 90 degrees.  
        ''   This will enable the badge to be printed with the element oriented
        ''   correctly (with one out of four choices of orientation). 
        ''
        ''9/2/2019 td''Me.ElementInfo_Pic.OrientationDegrees += 90
        ''9/24/2019 td''  Me.ElementInfo_Base.OrientationInDegrees += 90

        With Me.ElementInfo_Base

            .OrientationInDegrees += 90

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of " With Me.ElementInfo_Base"

        ''#1 9/23/2019 td''RefreshImage()
        '' #2 9/23/2019 td''RefreshImage_NoMajorCalls()
        ''Jan24 2022 td''RefreshImage_ViaElemImage()
        ''Feb01 2022 td''Me.CtlCurrentElement.Refresh_Image(True)
        Me.CtlCurrentElement.Refresh_ImageV3(True)

        Me.CtlCurrentElement.Refresh()

        ''Added 9/20/2019 td
        ''Jan24 2022''Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Rotate90Degrees_BA1079()"


    Public Sub Add_or_Edit_Conditional_Expression_BA1080(sender As Object, e As EventArgs)
        ''
        ''Added 5/5/2022 td   
        ''
        Me.CtlCurrentElement.ShowConditionalExpression()

    End Sub ''End of ""Public Sub Add_Conditional_Expression_BA1080(sender As Object, e As EventArgs)""


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


End Class
