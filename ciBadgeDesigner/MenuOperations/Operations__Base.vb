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
    Implements IDeleteElement ''Added 8/15/2022 thomas d.
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
    Public Property ElementObject_Base As ciBadgeElements.ClassElementBase ''Added 7/19/2022 thomas d.

    Public MustOverride Property Element_Type As Enum_ElementType ''Added 1/19/2022 td 

    Public Property EventsForMoveability_Single As GroupMoveEvents_Singleton ''Suffixed 1/11/2022 Added 1/3/2022 td 
    Public Property EventsForMoveability_Group As GroupMoveEvents_Singleton ''Added 1/11/2022 td 
    Public Property LayoutFunctions As ILayoutFunctions ''Added 1/4/2022 td
    Public Property BadgeDimensions_DesignLayout As IBadgeLayoutDimensions ''Added 9/03/2022

    Public Property CtlCurrentForm As Form ''Added 5/5/2022 thomas d. 
    Public Property CtlCurrentControl As Control ''---Implements ICurrentElement.CtlCurrentElement

    ''Feb2 2022 ''Public Property MonemMovement_SingleControl As MonemControlMove_AllFunctionality ''Added 2/2/2022
    Public Property Monem_iMoveOrResizeFun As IMonemMoveOrResizeFunctionality ''Added 2/2/2022
    Public Property InfoRefresh As IRefreshCardPreview ''Added 5/10/2022 td

    Public Property Designer As ciBadgeDesigner.ClassDesigner ''Added 8/1/2022 td

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


    Public Sub DeleteElementIfConfirmed() Implements IDeleteElement.DeleteElementIfConfirmed
        ''
        ''Added 8/15/2022
        ''
        Delete_Element_From_Badge_BA1019(Me, New EventArgs)

    End Sub ''end of ""Public Sub DeleteElementIfConfirmed()""

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

            ''Hide the control for which the element has been deleted.  
            CtlCurrentControl.Visible = False ''Added 6/1/2022
            CtlCurrentElement.Visible = False ''Added 6/1/2022

            ''Remove the control.  
            Dim boolInCurrentForm As Boolean ''Added 6/1/2022 
            boolInCurrentForm = (Me.CtlCurrentForm.Controls.Contains(CtlCurrentControl))

            If boolInCurrentForm Then ''Added 6/1/2022
                Me.CtlCurrentForm.Controls.Remove(CtlCurrentControl)
            Else
                System.Diagnostics.Debugger.Break()
            End If ''End of ""If boolInCurrentForm Then... Else..."

            Application.DoEvents() ''Added 6/1/2022 
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
        ''5/27/2022 Me.CtlCurrentElement.ShowConditionalExpression()
        Me.CtlCurrentElement.ShowConditionalExpression_OpenDialog()

    End Sub ''End of ""Public Sub Add_Conditional_Expression_BA1080(sender As Object, e As EventArgs)""


    Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)
        ''
        ''Added 7/19/2022 & 5/31/2022 & 9/ 2/2019 thomas downes
        ''
        ''9/18/2019 td''Dim frm_ToShow As New DialogTextBorder
        ''9/18/2019 td''frm_ToShow.LoadFieldAndForm(Me.ElementInfo_Base, Me.ElementInfo_Text, Me.FieldInfo, Me.FormDesigner, Me)
        Dim frm_ToShowV1 As DialogTextBorder
        Dim frm_ToShowV2 As Dialog_BaseBorder ''Added 7/29/2022 td

        Dim intSave_Left As Integer ''Added 7/19/2022
        Dim intSave_Top As Integer ''Added 7/19/2022

        ''Save location.
        intSave_Left = Me.CtlCurrentElement.Left
        intSave_Top = Me.CtlCurrentElement.Top

        ''7/19/2022 ''frm_ToShow = New DialogTextBorder(Me.CtlCurrentElement, Me.ElementInfo_Base)
        ''7/29/2022 ''frm_ToShowV1 = New DialogTextBorder(Me.CtlCurrentElement, Me.ElementObject_Base)
        frm_ToShowV2 = New Dialog_BaseBorder(Me.CtlCurrentElement, Me.ElementObject_Base) ''7/29/2022 '', Me.ElementObject_Base)

        ''7/19/2022 ''frm_ToShowV1.ShowDialog()
        frm_ToShowV2.ShowDialog()

        ''Restore location.
        ''7/19/2022 ''frm_ToShowV1.Controls.Remove(Me.CtlCurrentElement)
        frm_ToShowV2.Controls.Remove(Me.CtlCurrentElement)
        Me.CtlCurrentForm.Controls.Add(Me.CtlCurrentElement)
        Me.CtlCurrentElement.Left = intSave_Left
        Me.CtlCurrentElement.Top = intSave_Top
        Me.CtlCurrentElement.BringToFront()

    End Sub ''End of ""Public Sub Border_Design_EE1000(sender As Object, e As EventArgs)""


    Public Sub Refresh_Element_Image_EE1301(sender As Object, e As EventArgs)
        ''
        ''Added 7/29/2022 thomas d. 
        ''
        Me.CtlCurrentElement.RefreshElementImage()
        Me.CtlCurrentElement.Refresh()

    End Sub ''End of ""Public Sub Refresh_Element_Image_EE1301"" 


    Public Sub Give_Layout_Information_EE1003(sender As Object, e As EventArgs)
        ''
        ''Added 9/3/2022 thomas downes
        ''
        Dim infoLayoutFuns As ILayoutFunctions
        Dim infoBadgeDimensions_DesignLayout As IBadgeLayoutDimensions
        ''Dim infoBadgeDimensions_FinalPrint As IBadgeLayoutDimensions
        Dim strBuilder As New System.Text.StringBuilder(200)

        infoLayoutFuns = Me.LayoutFunctions
        infoBadgeDimensions_DesignLayout = Me.BadgeDimensions_DesignLayout

        strBuilder.AppendLine("---Layout functions---")
        strBuilder.AppendLine(infoLayoutFuns.LayoutDebugName)
        strBuilder.AppendLine("Name of form: " & infoLayoutFuns.NameOfForm())
        strBuilder.AppendLine(infoLayoutFuns.LayoutDebugDescription)
        strBuilder.AppendLine()
        strBuilder.AppendLine("---Badge Dimensions---")
        strBuilder.AppendLine(infoBadgeDimensions_DesignLayout.NameForDebug)
        strBuilder.AppendLine(infoBadgeDimensions_DesignLayout.Description)

        ''Added 9/3/2022 thomas downes
        MessageBoxTD.Show_StatementLongform("Layout Description",
                strBuilder.ToString(), 1.0, 1.0)

    End Sub ''End of ""Public Sub Give_Layout_Information_EE1302(sender As Object, e As EventArgs)""


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
