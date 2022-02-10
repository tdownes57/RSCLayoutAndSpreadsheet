''
''Added 12/30/2021 
''
Imports System.Drawing ''Added 2/3/2022 td
Imports __RSCWindowsControlLibrary ''Added 2/3/2022 td
''
''Added 12/30/2021 
''

Public MustInherit Class Operations__Text
    Inherits Operations__Base
    ''
    ''Added 12/30/2021 
    ''
    ''Added keyword "MustInherit" on 1/21/2022, so that I could have the 
    ''  Public Property Element_Type have the same keyword ("MustInherit")
    ''  (which in turn caused the Class itself to require the same keyword).
    ''   ----1/21/2022 td
    ''
    Public Overridable Property ElementInfo_TextOnly As ciBadgeInterfaces.IElement_TextOnly

    Public Property CtlCurrentRSCControl As __RSCWindowsControlLibrary.RSCMoveableControlVB
    Public Property CtlCurrentElementFieldV3 As ciBadgeDesigner.CtlGraphicFieldV3
    Public Property CtlCurrentElementFieldV4 As ciBadgeDesigner.CtlGraphicFieldV4
    Public Property CtlCurrentStaticTextV3 As CtlGraphicStaticTextV3
    Public Property CtlCurrentStaticTextV4 As CtlGraphicStaticTextV4
    Public Property CtlCurrentFieldOrTextV4 As CtlGraphicFieldOrTextV4

    Public Property SelectingElements As ISelectingElements ''Added 10/3/2019 td 
    Public Property ColorDialog1 As ColorDialog ''Added 2/2/2022 & 10/3/2019 td 
    Public Property FontDialog1 As FontDialog ''Added 2/2/2022 & 10/3/2019 td 

    Private Sub Dummy_Open_Dialog_for_Color_TE9401()
        ''
        ''The following procedure will be found at runtime via Reflection & linked via an
        ''    AddHandler command. ----2/9/2022 td 
        ''
        Open_Dialog_for_Color_TE9401(New Object(), New EventArgs())

    End Sub

    Public Sub Open_Dialog_for_Color_TE9401(sender As Object, e As EventArgs)
        ''
        ''Added 2/9/2022 td & 7/30/2019 thomas downes
        ''
        ColorDialog1 = New ColorDialog ''Added 2/9/2022 td
        ColorDialog1.ShowDialog()

        For Each each_ctl As CtlGraphicFieldOrTextV4 In Me.AllRelevantElements_OrJustOne()
            ''
            ''Added 8/3/2019 td  
            ''
            With each_ctl
                ''7/30/2019 td''Me.ElementInfo.FontColor = ColorDialog1.Color
                ''8/29/2019 td''Me.ElementInfo.BackColor = ColorDialog1.Color
                Me.ElementInfo_Base.Back_Color = ColorDialog1.Color

                ''Me.ElementInfo_Base.Width_Pixels = Me.Width
                ''Me.ElementInfo_Base.Height_Pixels = Me.Height

                Application.DoEvents()
                Application.DoEvents()

                ''--.Refresh_Image(True)
                ''--Me.Refresh()

                ''Added 2/09/2022 thomas d.
                Application.DoEvents()
                Application.DoEvents()
                .Refresh_ImageV3(True)
                .Refresh()

            End With ''End of "With each_ctl"

        Next each_ctl

        ''Added 2/09/2022 thomas d.
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub Open_Dialog_Color_TE9401()"

    Public Sub Open_Dialog_for_Font_TE1009(sender As Object, e As EventArgs)
        ''
        ''Added 7/30/2019 thomas downes
        ''       ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        Dim boolExitEarly As Boolean ''Added 8/13/2019 td

        ''10/10/2019 td''CreateVisibleButton_Master("Choose a text font", AddressOf OpenDialog_Font, boolExitEarly)
        ''10/10/2019 td''Application.DoEvents()

        ''Added 8/17/2019 td
        ''10/10/2019 td''If (mod_fauxMenuEditSingleton Is Nothing) Then mod_fauxMenuEditSingleton = New CtlGraphPopMenuEditSingle

        ''10/10/2019 td''mod_fauxMenuEditSingleton.SizeToExpectations()

        If (boolExitEarly) Then Exit Sub ''Added 8/13/2019 td

        ''Added 2/03/2022 thomas d.
        If (FontDialog1 Is Nothing) Then FontDialog1 = New FontDialog

        ''Feb2 2022 td''Me.FontDialog1.Font = Me.CtlCurrentElementField.ElementClass_Obj.Font_DrawingClass ''Added 7/31/2019 td  
        Me.FontDialog1.Font = Me.ElementInfo_TextOnly.Font_DrawingClass ''Added 7/31/2019 td  

        ''
        ''Major call !!   Show the font-selection dialog to the user. 
        '' 
        Me.FontDialog1.ShowDialog()

        ''Me.ElementInfo.Font_DrawingClass = FontDialog1.Font
        ''Application.DoEvents()
        ''Application.DoEvents()
        ''RefreshImage()
        ''Me.Refresh()

        ''Dim boolGroupwiseUnselected As Boolean ''Added 2/3/2022 td
        ''Dim bNotPartOfSelectedGroup As Boolean ''Added 2/3/2022 thomas d. 
        ''Dim intCountItemsInGroup As Integer ''Added 2/3/2022 td
        ''Dim bNoSelectedItemsExist As Boolean ''Added 2/3/2022 td
        Dim b1_RightclickedAsSingleItem As Boolean ''Added 2/3/2022 thomas d.
        Dim b2_SelectedAsPartOfAGroup As Boolean ''Added 2/3/2022 thomas d.

        ''''------------------DIFFICULT AND CONFUSING------------------------------------------------------------
        ''boolGroupwiseUnselected = (Me.SelectingElements.ElementsList_IsItemUnselected(Me.CtlCurrentRSCControl))
        ''intCountItemsInGroup = Me.SelectingElements.ElementsList_CountItems()
        ''bNoSelectedItemsExist = (0 = intCountItemsInGroup)
        ''bNotPartOfSelectedGroup = (bNoSelectedItemsExist OrElse boolGroupwiseUnselected)
        ''b1_RightclickedAsSingleItem = bNotPartOfSelectedGroup
        ''b2_SelectedAsPartOfAGroup = (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentRSCControl))

        b1_RightclickedAsSingleItem = GroupedWithOtherSelectedElements_Not() ''Is it a singleton?
        b2_SelectedAsPartOfAGroup = GroupedWithOtherSelectedElements_Yes() ''Is it grouped? 

        ''
        ''Next, proceed with one of the following choices:
        ''
        ''   (1) Modify the font of the single control.
        ''   (2) Modify the font of each control in a group of controls. 
        ''
        If (b1_RightclickedAsSingleItem) Then
            ''
            ''The current control is NOT part of a group of selected items. ---2/3/2022 td
            ''
            Me.CtlCurrentFieldOrTextV4.ElementInfo_TextOnly.Font_DrawingClass = Me.FontDialog1.Font

            ''Added 10/17/2019 td 
            If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then
                ''Added 10/17/2019 td 
                MsgBox("Program error, unexpected Font Unit", MsgBoxStyle.Exclamation, "OpenDialog_Font")
            Else
                Me.CtlCurrentFieldOrTextV4.ElementInfo_TextOnly.FontSize_Pixels = Me.FontDialog1.Font.Size  ''Added 8/17/2019 td
            End If ''End of "If (Me.FontDialog1.Font.Unit = GraphicsUnit.Pixel) Then ... Else ..."

            Application.DoEvents()
            Application.DoEvents()

            ''9/15/2019 td''Refresh_Image()
            ''10/3/2019 td''Refresh_Image(False)
            ''10/3/2019 td''Me.Refresh()
            Me.CtlCurrentFieldOrTextV4.Refresh_ImageV3(False)
            Me.CtlCurrentFieldOrTextV4.Refresh()


        ElseIf (b2_SelectedAsPartOfAGroup) Then

            ''Added 8/3/2019 td 
            ''1/12/2022 td''Dim objElements As HashSet(Of CtlGraphicFldLabel)
            ''Feb3 2022 td''Dim objElementsSelected As HashSet(Of RSCMoveableControlVB)

            ''10/3/2019 td''objElements = CType(Me.ParentForm, ISelectingElements).LabelsDesignList_AllItems
            ''Feb3 2022 td''objElementsSelected = Me.SelectingElements.ElementsDesignList_AllItems

            ''Feb3 2022 td''For Each each_ctl As CtlGraphicFldLabelV3 In objElementsSelected

            For Each each_ctl As CtlGraphicFieldOrTextV4 In Me.AllRelevantElements_OrJustOne()
                ''
                ''Added 8/3/2019 td  
                ''
                With each_ctl

                    ''Added 10/17/2019 td  
                    If (FontDialog1.Font.Unit <> GraphicsUnit.Pixel) Then

                        ''---Throw New Exception("Unexpected Font Unit")
                        MessageBoxTD.Show_Statement("Program error, unexpected Font Unit")

                    End If ''End of "If (FontDialog1.Font.Unit <> GraphicsUnit.Pixel) Then"

                    .ElementInfo_TextOnly.Font_DrawingClass = FontDialog1.Font
                    ''Added 10/17/2019 td  
                    .ElementInfo_TextOnly.FontSize_Pixels = FontDialog1.Font.Size

                    Application.DoEvents()
                    Application.DoEvents()
                    .Refresh_ImageV3(True)
                    .Refresh()

                End With

            Next each_ctl

        End If ''End of "If (Me.SelectingElements.ElementsList_IsItemUnselected(Me)) Then... Else ..."

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Private Sub "Open_Dialog_Font_EE1009(sender As Object, e As EventArgs)"


    Public Sub Remove_Proportional_Resizing_Of_Font_TE1003(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        ElementInfo_TextOnly.FontSize_ScaleToElementYesNo = False ''False, as we are removing 
        ''  the automated font-resizing. 

    End Sub ''end of "Public Sub Remove_Proportional_Resizing_Of_Font_TE1003"


    Public Sub Restore_Proportional_Resizing_Of_Font_TE1003(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        ElementInfo_TextOnly.FontSize_ScaleToElementYesNo = True ''True, as we are restoring 
        ''  the automated font-resizing. 

    End Sub ''end of "Public Sub Remove_Proportional_Resizing_Of_Font_TE1003"


    Public Sub Rotate90_Degrees_Clockwise_TE1001(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        Const c_counterclockwise As Boolean = False ''False, it's actually clockwise, not counter-clockwise. 
        Rotate90_Degrees(c_counterclockwise)

    End Sub

    Public Sub Rotate90_Degrees_Counterclockwise_TE1002(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        Const c_counterclockwise As Boolean = True ''True, counter-clockwise.
        Rotate90_Degrees(c_counterclockwise)

    End Sub


    Private Sub Rotate90_Degrees(Optional pbCounterclockwise As Boolean = False)
        ''Feb2 2022''Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)
        ''
        ''Added 8/17/2019 thomas downes
        ''         ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''2/2/2022 ''With Me.CtlCurrentElementField.ElementInfo_Base
        With Me.CtlCurrentElement.ElementInfo_Base

            Select Case .OrientationToLayout
                Case "", " ", "P"
                    .OrientationToLayout = "L"
                Case "L"
                    .OrientationToLayout = "P"
                Case Else
                    .OrientationToLayout = "P"

            End Select ''End of "Select Case .OrientationToLayout"

            ''Added 8/12/2019 thomas downes 
            ''
            ''   Increment by 90 degrees.  
            ''    This will enable the badge to be printed with the element oriented
            ''   correctly (with one out of four choices of orientation). 
            ''
            ''Feb2 2022 td''.OrientationInDegrees += 90
            If (pbCounterclockwise) Then
                .OrientationInDegrees -= 90 ''Added 2/2/2022
            Else
                .OrientationInDegrees += 90 ''Added 2/2/2022
            End If ''End of "If (pbCounterclockwise) Then ... Else ..."

            ''Added 9/23/2019 td
            If (360 <= .OrientationInDegrees) Then
                ''Remove 360 degrees (the full circle) from the 
                ''    property value.   We don't want to have to 
                ''    do modulo arithmetic (divide by 360 & get 
                ''    the remainder).  ---9/23/2019 td 
                ''     
                .OrientationInDegrees = (.OrientationInDegrees - 360)
            End If ''End of "If (360 <= .OrientationInDegrees) Then"

        End With ''End of "With Me.ElementInfo_Base"

        '' 9/15 td''Refresh_Image()
        '' 9/23 td''Refresh_Image(True)
        '' 9/23 td''Me.Refresh()
        ''10/17/2019 td''Me.Refresh_Master()
        ''2/02/2022 td''Me.CtlCurrentElementField.Refresh_Master()
        Me.CtlCurrentElement.Refresh_Master()

        ''Added 9/13/2019 td
        ''9/19/2019 td''Me.FormDesigner.AutoPreview_IfChecked()
        Me.LayoutFunctions.AutoPreview_IfChecked()

    End Sub ''eNd of "Public Sub Rotate90_Degrees_EE1001(sender As Object, e As EventArgs)"


    Protected Function AllRelevantElements_OrJustOne() As List(Of CtlGraphicFieldOrTextV4)
        ''
        ''Added 2/3/2022 td
        ''
        Dim listFieldOrTextCtls As New List(Of CtlGraphicFieldOrTextV4)
        Dim eachRSCControl As RSCMoveableControlVB
        Dim eachFieldOrTextControl As CtlGraphicFieldOrTextV4
        Dim intCountOfNonFieldOrTextControls As Integer

        If (GroupedWithOtherSelectedElements_Yes()) Then
            ''
            ''We have a group of items. 
            ''
            For Each eachRSCControl In Me.SelectingElements.ElementsDesignList_AllItems
                ''
                ''Added 8/3/2019 td  
                ''
                Try
                    eachFieldOrTextControl = CType(eachRSCControl, CtlGraphicFieldOrTextV4)
                    listFieldOrTextCtls.Add(eachFieldOrTextControl)
                Catch ex As Exception
                    intCountOfNonFieldOrTextControls += 1
                End Try

            Next eachRSCControl

        Else
            ''
            '' Let's add the singleton.  
            ''
            If (Me.CtlCurrentFieldOrTextV4 Is Nothing) Then
                Throw New Exception("Null-reference is found")
            End If
            listFieldOrTextCtls.Add(Me.CtlCurrentFieldOrTextV4)

        End If ''Ednof "If (GroupedWithOtherSelectedElements_Yes()) ... Else...

        Return listFieldOrTextCtls

    End Function ''End of "Protected Function AllRelevantElements_OrJustOne() As List(Of CtlGraphicFieldOrTextV4)"


    Protected Function GroupedWithOtherSelectedElements_Yes() As Boolean
        ''
        ''Added 2/3/2022 td
        ''
        Dim bInGroupOfSelectedElements As Boolean
        Dim bIsASingleElement As Boolean

        GroupedWithOtherElements_YesOrNo(bInGroupOfSelectedElements, bIsASingleElement)
        Return bInGroupOfSelectedElements

    End Function

    Protected Function GroupedWithOtherSelectedElements_Not() As Boolean
        ''
        ''Added 2/3/2022 td
        ''
        Dim bInGroupOfSelectedElements As Boolean
        Dim bIsASingleElement As Boolean

        GroupedWithOtherElements_YesOrNo(bInGroupOfSelectedElements, bIsASingleElement)
        Return bIsASingleElement

    End Function

    Private Sub GroupedWithOtherElements_YesOrNo(ByRef pref_bGrouped As Boolean,
                                                 Optional ByRef pref_bSingle As Boolean = True)
        ''
        ''Added 2/3/2022 td
        ''
        Dim boolGroupwiseUnselected As Boolean = True ''Added 2/3/2022 td
        Dim bNotPartOfSelectedGroup As Boolean ''Added 2/3/2022 thomas d. 
        Dim intCountItemsInGroup As Integer ''Added 2/3/2022 td
        Dim bNoSelectedItemsExist As Boolean ''Added 2/3/2022 td
        Dim b1_SelectedAsPartOfAGroup As Boolean ''Added 2/3/2022 thomas d.
        Dim b2_RightclickedAsSingleItem As Boolean ''Added 2/3/2022 thomas d.

        ''------------------DIFFICULT AND CONFUSING------------------------------------------------------------
        If (Me.SelectingElements Is Nothing) Then
            ''
            ''The Group-Selecting class is Null.
            ''
            boolGroupwiseUnselected = True
            intCountItemsInGroup = 0
            bNoSelectedItemsExist = True
            bNotPartOfSelectedGroup = True
            b2_RightclickedAsSingleItem = True
            b1_SelectedAsPartOfAGroup = False

        Else
            boolGroupwiseUnselected = (Me.SelectingElements.ElementsList_IsItemUnselected(Me.CtlCurrentRSCControl))
            intCountItemsInGroup = Me.SelectingElements.ElementsList_CountItems()
            bNoSelectedItemsExist = (0 = intCountItemsInGroup)
            bNotPartOfSelectedGroup = (bNoSelectedItemsExist OrElse boolGroupwiseUnselected)
            b2_RightclickedAsSingleItem = bNotPartOfSelectedGroup
            b1_SelectedAsPartOfAGroup = (Me.SelectingElements.ElementsList_IsItemIncluded(Me.CtlCurrentRSCControl))

        End If ''End of "If (Me.SelectingElements Is Nothing) Then ... Else ..."

        ''Set first ByRef parameter
        pref_bGrouped = b1_SelectedAsPartOfAGroup
        ''Optional ByRef parameter.
        pref_bSingle = b2_RightclickedAsSingleItem

    End Sub ''End of "Private Sub GroupedWithOtherElements_YesOrNo"


End Class
