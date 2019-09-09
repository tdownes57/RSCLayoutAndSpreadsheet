''
''Added 9/8/2019 thomas downes
''
Imports ciBadgeInterfaces ''added 9/8 
''9/9/2019 td''Imports ControlManager
Imports MoveAndResizeControls_Monem
Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 
Imports System.Collections.Generic ''Added 9.6.2019 td 

Public Class FormMainEntry_v90
    ''
    ''Added 9/8/2019 thomas downes
    ''
    Private mod_imagePortrait As CtlGraphicPortrait
    Private Const mc_boolMoveableElements As Boolean = True
    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 7/31/2019 td 

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 9/08/2019 thomas downes 
        ''
        mod_imagePortrait = CtlGraphicPortrait_v90

        ''
        ''Major call !!
        ''
        LoadForm_LayoutElements()

        ControlMoverOrResizer_TD.Init(picturePreview,
                          picturePreview, 10, False) ''Added 9/08/2019 thomas downes

    End Sub ''End of "Private Sub FormDesignProtoTwo_Load"

    Private Sub LoadForm_LayoutElements()
        ''
        ''Added 9/9/2019 td
        ''
        Const c_boolLoadingForm As Boolean = True ''Added 8/28/2019 thomas downes  

        LoadElements_Fields_Master(c_boolLoadingForm)

        LoadElements_Picture()

        If (mc_boolMoveableElements) Then
            MakeElementsMoveable()
        End If

    End Sub ''ENd of "Private Sub LoadForm_LayoutElements()"

    Private Sub LoadElements_Fields_Master(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 9/03/2019 thomas downes 
        ''
        ''9/4 td''Const c_boolUseConsolidatedList As Boolean = False ''True
        Dim boolUseConsolidatedList As Boolean ''Added 9/5/2019 td  

        ''Added 9/5/2019 td  
        boolUseConsolidatedList = True ''9/5 td''(2 <= dropdownHowToLoadFlds.SelectedIndex)

        If (boolUseConsolidatedList) Then

            ''9/6/2019 td''LoadElements_Fields_OneList(par_boolLoadingForm, par_bUnloading)
            LoadElements_OneListOfFields(par_boolLoadingForm, par_bUnloading)

        Else

            LoadElements_Fields_TwoLists(par_boolLoadingForm, par_bUnloading)

        End If ''End of "If (boolUseConsolidatedList) Then ..... Else ...."

    End Sub ''ENd of "Private Sub LoadElements_Fields_Master()"

    Private Sub LoadElements_OneListOfFields(par_boolLoadingForm As Boolean, Optional par_bUnloading As Boolean = False)
        ''
        ''Added 9/6/2019 td  
        ''
        LoadElements_ByListOfFields(ClassFields.ListAllFields(), par_boolLoadingForm)

    End Sub

    Private Sub LoadField_JustOne(par_field As ICIBFieldStandardOrCustom)
        ''
        ''Added 9/6/2019 thomas d. 
        ''
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        Const c_bAddToMoveableClass As Boolean = True ''Added 9/8/2019 td 

        new_list.Add(par_field)

        LoadElements_ByListOfFields(new_list, True, False,
                                    c_bAddToMoveableClass)

    End Sub ''End of "Private Sub LoadField_JustOne(...)"

    Private Sub LoadElements_ByListOfFields(par_list As List(Of ICIBFieldStandardOrCustom),
                                           par_boolLoadingForm As Boolean,
                                           Optional par_bUnloading As Boolean = False,
                                            Optional par_bAddMoveability As Boolean = False)
        ''
        ''Added 9/03/2019 thomas downes 
        ''Modified 9/5/2019 thomas downes
        ''
        Dim intCountControlsAdded As Integer = 0 ''Added 9/03/2019 td 
        ''9/5/2019 td''Dim intTopEdge As Integer ''Added 7/28/2019 td
        ''9/5/2019 td''Dim intLeftEdge As Integer ''Added 9/03/2019 td
        Dim boolIncludeOnBadge As Boolean = False ''Added 9/03/2019 td
        Dim intStagger As Integer = 0 ''Added 9.6.2019 td 

        For Each each_field As ICIBFieldStandardOrCustom In par_list ''9/6/2019 td''ClassFields.ListAllFields()

            Dim label_control As CtlGraphicFldLabel

            ''Added 9/3/2019 thomas d. 
            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)
            If (Not boolIncludeOnBadge) Then
                AddToFlowPanelOfOmittedFlds(each_field)
                Continue For
            End If ''End of "If (Not boolIncludeOnBadge) Then"

            ''
            ''Has the user moved the field into place (and pressed the Save & Refresh link)??
            ''
            If (each_field.ElementInfo_Base Is Nothing) Then

                Dim new_element_text As New ClassElementText

                new_element_text.Height_Pixels = 30
                new_element_text.FontSize_Pixels = 25

                ''''9/6/2019 td''new_element_text.TopEdge_Pixels = (30 + (30 * intCountControlsAdded))
                ''intStagger = intCountControlsAdded
                ''new_element_text.TopEdge_Pixels = (intStagger * new_element_text.Height_Pixels)
                ''intCountControlsAdded += 1 ''Added 9/6/2019 td 

                ''new_element_text.LeftEdge_Pixels = new_element_text.TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                ''''   a nice diagonally-cascading effect. ---9/3/2019 td

                each_field.ElementInfo_Base = new_element_text
                each_field.ElementInfo_Text = new_element_text

            End If ''ENd of "If (each_field.ElementInfo_Base Is Nothing) Then"

            ''Added 9/5/2019 thomas d.
            each_field.ElementInfo_Base.LayoutWidth_Pixels = Me.Layout_Width_Pixels()

            ''#1 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, Me)
            '' #2 9/4/2019 td''label_control = New CtlGraphicFldLabel(each_field, new_element_text, Me)
            label_control = New CtlGraphicFldLabel(each_field, Me)

            ''Moved below. 9/5 td''label_control.Refresh_Master()
            label_control.Visible = each_field.IsDisplayedOnBadge ''BL = Badge Layout
            intCountControlsAdded += 1
            label_control.Name = "FieldControl" & CStr(intCountControlsAdded)

            ''9/8 td''label_control.BorderStyle = BorderStyle.FixedSingle

            ''Added 9/6/2019 thomas downes 
            ''
            ''   Stagger the elements on the badge layout, in a cascade from
            '' the upper-left to the lower-right. 
            '' ------9/6/2019 td
            ''
            If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then
                ''Added 9/6/2019 thomas downes 
                label_control.Width = CInt(pictureBack.Width / 3)
                With each_field.ElementInfo_Base
                    .Width_Pixels = label_control.Width
                    .Height_Pixels = label_control.Height
                    intStagger = intCountControlsAdded
                    .TopEdge_Pixels = (intStagger * .Height_Pixels)
                    .LeftEdge_Pixels = .TopEdge_Pixels ''Left = Top !! By setting Left = Top, we will create 
                    ''   a nice diagonally-cascading effect. ---9/3/2019 td
                    ''See above. 9/6/2019 td''intCountControlsAdded += 1 ''Added 9/6/2019 td 
                End With ''End of " With each_field.ElementInfo_Base"
            End If ''ENd of "If (0 = each_field.ElementInfo_Base.TopEdge_Pixels) Then"

            boolIncludeOnBadge = (par_boolLoadingForm And each_field.IsDisplayedOnBadge)

            If (boolIncludeOnBadge) Then

                Me.Controls.Add(label_control)
                label_control.Visible = True
                label_control.BringToFront() ''Added 9/7/2019 thomas d.  
                ''9/5/2019''label_control.Refresh_Image()
                label_control.GroupEdits = CType(Me, ISelectingElements) ''Added 8/1 td

                ''Added 9/7/2019 td
                label_control.Left = Me.Layout_Margin_Left_Add(each_field.ElementInfo_Base.LeftEdge_Pixels)
                label_control.Top = Me.Layout_Margin_Top_Add(each_field.ElementInfo_Base.TopEdge_Pixels)

                ''
                ''Major call !!  ----Thomas DOWNES
                ''
                label_control.Refresh_Master()

                ''Added 9/8/2019 td
                If (par_bAddMoveability) Then ControlMoverResizer_AddFieldCtl(label_control)

            ElseIf (par_bUnloading) Then
                ''9/3/2019 td''Me.Controls.Remove(label_control)
                Throw New NotImplementedException

            End If ''End of "If (boolInludeOnBadge) Then .... ElseIf (....) ...."

        Next each_field

        ''
        ''Added 8/27/2019 thomas downes
        ''
        pictureBack.SendToBack() ''Added 9/7/2019 thomas d.
        Me.Refresh() ''Added 8/28/2019 td   

        ''9/5/2019 td''MessageBox.Show($"Number of field controls now on the form: {intCountControlsAdded}", "",
        ''     MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of ''Private Sub LoadElements_Fields_OneList()''


End Class