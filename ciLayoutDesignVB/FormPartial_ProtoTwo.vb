Option Explicit On
Option Strict On
Option Infer Off

''
''Added 7/31/2019 td  
''
Imports ciBadgeInterfaces ''Added 9/19/2019 td  
Imports ciBadgeDesigner ''Added 10/3/2019 td  

Partial Public Class FormDesignProtoTwo
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 
    Private mod_FieldControlLastTouched As CtlGraphicFldLabel   ''Added 8/09/2019 thomas downes 
    Private mod_ControlLastTouched As Control ''Added 8/12/2019 thomas d. 
    Private mod_ElementLastTouched As Control ''Let's change this to IElement_Base soon. ---Added 9/14/2019 td 
    Private Const mc_bAddBorderOnlyWhileResizing As Boolean = True ''Added 9/11/2019 thomas d. 

    Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved ''Added 8/4/2019 td
        Get
            ''Added 8/9/2019 td
            ''10/3/2019 td''Return mod_FieldControlLastTouched 
            Return CType(mod_FieldControlLastTouched, Control)
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlGraphicFldLabel)
                mod_ElementLastTouched = CType(value, Control) ''Added 9/14 
                mod_ControlLastTouched = value ''Added 8/1/2019 
            Catch
                ''Added 8/12/2019 td  
                mod_ControlLastTouched = value
                mod_ElementLastTouched = CType(value, Control)
            End Try
        End Set
    End Property ''End of "Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved"

    Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified ''Added 8/9/2019 td
        Get
            ''
            ''Added 8 / 9 / 2019 td
            ''
            ''8/12/2019 td''Return mod_FieldControlLastTouched
            Return mod_ControlLastTouched ''Added 8/12/2019 td  
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            mod_ControlLastTouched = value ''Added 8/12/2019 td
            mod_ElementLastTouched = value ''Added 9/14/2019 td
            Try
                ''9/9/2019 td''mod_FieldControlLastTouched = value
                mod_FieldControlLastTouched = CType(value, CtlGraphicFldLabel)

                ''Added 9/11/2019 td  
                If (mc_bAddBorderOnlyWhileResizing) Then
                    mod_FieldControlLastTouched.BorderStyle = BorderStyle.FixedSingle
                End If ''End of "If (mc_bAddBorderOnlyWhileResizing) Then"

            Catch
                ''Not all moveable controls are Field-Label controls. - ----8/12/2019 thomas d.  
            End Try
        End Set
    End Property ''End of "Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified"

    Public Property LabelsDesignList_AllItems As List(Of CtlGraphicFldLabel) ''-----Implements ISelectingElements.LabelsDesignList_AllItems
        Get
            ''Added 8/3/2019 thomas downes
            Return mod_selectedCtls
        End Get
        Set
            ''Added 8/3/2019 thomas downes
            mod_selectedCtls = Value
        End Set
    End Property

    Public Sub LabelsDesignList_Add(par_control As CtlGraphicFldLabel) ''-----Implements ISelectingElements.LabelsDesignList_Add
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Add(par_control)

    End Sub

    Public Sub LabelsDesignList_Remove(par_control As CtlGraphicFldLabel) ''-----Implements ISelectingElements.LabelsDesignList_Remove
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Remove(par_control)

    End Sub

    Private Sub Resizing_Start() Handles mod_groupedMove.Resizing_Start
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (mc_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.FixedSingle
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            ''Added 8/5/2019 thomas downes  
            each_control.TempResizeInfo_W = each_control.Width
            each_control.TempResizeInfo_H = each_control.Height

            ''Added 8/12/2019 thomas downes  
            ''   The user might want might to resize using the left edge (or the top edge). 
            ''
            each_control.TempResizeInfo_Left = each_control.Left
            each_control.TempResizeInfo_Top = each_control.Top

        Next each_control

    End Sub ''End of "Private Sub Resizing_Start"  

    Private Sub Move_GroupMove_Continue(DeltaLeft As Integer, DeltaTop As Integer, DeltaWidth As Integer, DeltaHeight As Integer) Handles mod_groupedMove.MoveInUnison
        ''
        ''Added 8/3/2019 thomas downes  
        ''
        Dim boolMoving As Boolean ''Added 8/5/2/019 td  
        Dim boolResizing As Boolean ''Added 8/5/2/019 td  
        Dim bResize_RightOrBottom As Boolean ''Added 8/12/019 td  
        Dim bResize_LeftOrTop As Boolean ''Added 8/12/019 td  
        Dim bControlMovedIsInGroup As Boolean ''Added 8/5/2019 td  

        ''
        ''8/5/2019 thomas downes
        ''
        If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then
            Const c_bCheckThatControlIsGrouped As Boolean = True ''8/5/2019 thomas downes
            If (c_bCheckThatControlIsGrouped) Then ''8/5/2019 thomas downes
                ''9/9 td''bControlMovedIsInGroup = LabelsList_IsItemIncluded(ControlBeingMoved)
                bControlMovedIsInGroup = LabelsList_IsItemIncluded(CType(ControlBeingMoved, CtlGraphicFldLabel))
                If (Not bControlMovedIsInGroup) Then Exit Sub
            End If ''End of "If (c_bCheckThatControlIsGrouped) Then"
        Else
            ''
            ''Perhaps the Portrait is being moved.   Don't allow other things to be 
            ''  moved around as well.  ---8/5/2019 td
            ''
            Exit Sub

        End If ''End of "If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then .... Else ...."

        ''
        ''The control being moved or resized is part of a group.   
        ''
        ''8/4/2019 td''For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Don't re-move the control being directly moved...!! 
            ''  Causes ugly screen flicker!!
            ''     --8/4/2019 td
            If (each_control Is Me.ControlBeingMoved) Then Continue For
            If (each_control Is Me.ControlBeingMoved.Parent) Then Continue For

            With each_control

                ''Added 8/3/2019 th omas downes  
                ''8/12/2019 td''boolMoving = (DeltaTop <> 0 Or DeltaLeft <> 0)
                boolMoving = ((DeltaTop <> 0 And DeltaHeight = 0) Or
                              (DeltaLeft <> 0 And DeltaWidth = 0))

                If (boolMoving) Then
                    .Top += DeltaTop
                    .Left += DeltaLeft
                End If ''End if ''End of "If (boolMoving) Then"

                ''8/5/2019 TD''.Width += DeltaWidth
                ''8/5/2019 TD''.Height += DeltaHeight

                ''Modified 8/5/2019 thomas downes
                boolResizing = ((Not boolMoving) And (.TempResizeInfo_W > 0 And .TempResizeInfo_H > 0))

                If (boolResizing) Then
                    ''
                    ''Added 8/12/2019 thomas d. 
                    ''
                    bResize_LeftOrTop = (DeltaLeft <> 0 Or DeltaTop <> 0) ''-----DIFFICULT AND CONFUSING !!!!!    The user might want might to resize 
                    ''    using the left edge (Or the top edge).  ----8/12/2019 td
                    bResize_RightOrBottom = ((Not bResize_LeftOrTop) And (DeltaWidth <> 0 Or DeltaHeight <> 0))

                    If (bResize_RightOrBottom) Then
                        ''
                        ''This is the simpler situation !! 
                        ''
                        .Width = (.TempResizeInfo_W + DeltaWidth)
                        .Height = (.TempResizeInfo_H + DeltaHeight)

                    ElseIf (bResize_LeftOrTop) Then
                        ''
                        ''Added 8/12/2019 thomas d.
                        ''
                        ''-----DIFFICULT AND CONFUSING !!!!!
                        ''    The user might want might to resize using the left edge (Or the top edge). 
                        ''
                        ''8/12/2019 TD''.Top = (.TempResizeInfo_Top + DeltaTop)
                        ''8/12/2019 TD''.Left = (.TempResizeInfo_Left + DeltaLeft)

                        .Top += DeltaTop
                        .Left += DeltaLeft
                        .Width += DeltaWidth
                        .Height += DeltaHeight

                    End If ''End of "If (bResize_RightOrBottom) Then .... ElseIf (bResize_LeftOrTop) Then ..."

                End If ''End of "If (boolResizing) Then"

                ''8/5/2019 td''txtWidthDeltas.AppendText($"Width: {DeltaWidth}" & vbCrLf)
                ''8/5/2019 td''txtWidthDeltas.AppendText($"   Height: {DeltaHeight}" & vbCrLf)

            End With ''End of "With each_control"

        Next each_control

    End Sub ''End of "Private Sub MoveInUnison"

    Private Sub Resizing_End() Handles mod_groupedMove.Resizing_End
        ''
        ''Added 8/5/2019 thomas downes  
        ''

        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            ''Added 9/11/2019 td  
            If (mc_bAddBorderOnlyWhileResizing) Then
                each_control.BorderStyle = BorderStyle.None
            End If ''End of "If (mc_boolAddBorderWhileResizing) Then"

            each_control.TempResizeInfo_W = 0
            each_control.TempResizeInfo_H = 0

            ''Added 9/11/2019 td
            each_control.Refresh_Image(True)

        Next each_control

        ''Added 9/11/2019 Never Forget
        ''   This is needed in case it's not a group of controls being resized, 
        ''   but just a single control. ---9/11 td 
        ''
        ''9/14/2019 td''If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then

        Dim boolResizedAFieldCtl As Boolean ''Added 9/14/2019 td
        boolResizedAFieldCtl = (TypeOf mod_ControlLastTouched Is CtlGraphicFldLabel)

        If (boolResizedAFieldCtl) Then ''Added 9/14/2019 td

            With mod_FieldControlLastTouched

                If (.Rotated_0degrees) Then
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Height
                ElseIf (.Rotated_180_360) Then
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Width
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Height
                ElseIf (.Rotated_90_270) Then
                    ''
                    ''---- POTENTIALLY CONFUSING -----
                    ''Switch them up !!  
                    .ElementInfo_Base.Width_Pixels = mod_FieldControlLastTouched.Height
                    .ElementInfo_Base.Height_Pixels = mod_FieldControlLastTouched.Width
                End If ''End of "If (.Rotated_180_360) Then"

                ''Added 9/12/2019 td  
                With .ElementInfo_Text
                    If .FontSize_ScaleToElementYesNo Then
                        ''Change the Font Size, to account for the new Height of the Element !!
                        ''  ---9/12/2019 td 
                        .FontSize_Pixels = CSng(mod_FieldControlLastTouched.Height * .FontSize_ScaleToElementRatio)
                    End If ''End of "If .FontSize_ScaleToElementYesNo Then"
                End With ''End of "With .ElementInfo_Text"

                .Refresh_Image(True)

            End With ''End of "With mod_FieldControlLastTouched"

        End If ''End of "If (mod_ElementLastTouched = mod_FieldControlLastTouched) Then"

        ''Added 9/13/2019 td 
        AutoPreview_IfChecked()

    End Sub ''End of "Private Sub Resizing_End() Handles mod_groupedMove.Resizing_End"

    Private Sub MovingElement_End() Handles mod_groupedMove.Moving_End

        ''Added 9/13/2019 td 
        AutoPreview_IfChecked()

    End Sub

    Private Sub SwitchControls_Down(par_ctl As CtlGraphicFldLabel) ''-----Implements ISelectingElements.SwitchControls_Down
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextLowerControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextLowerControl(par_ctl))

    End Sub ''End of "Private Sub SwitchControls_Down(par_ctl As CtlGraphicFldLabel)"

    Private Sub SwitchControls___Up(par_ctl As CtlGraphicFldLabel) ''-----Implements ISelectingElements.SwitchControls___Up
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        If (GetNextHigherControl(par_ctl) Is Nothing) Then Exit Sub ''Added 8/16/2019 td 

        SwitchWithOtherCtl(par_ctl, GetNextHigherControl(par_ctl))

    End Sub ''End of "Private Sub SwitchWithNextHigher(par_ctl As CtlGraphicFldLabel)"

    Private Sub SwitchWithOtherCtl(par_one As CtlGraphicFldLabel, par_two As CtlGraphicFldLabel)
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        Dim intTemp_Left, intTemp_Top As Integer

        intTemp_Left = par_one.Left
        intTemp_Top = par_one.Top

        par_one.Left = par_two.Left
        par_one.Top = par_two.Top

        par_two.Left = intTemp_Left
        par_two.Top = intTemp_Top

    End Sub ''End of "Private Sub SwitchWithOtherCtl(par_one As CtlGraphicFldLabel, par_two As .....)"

    Private Function HasAtLeastOne_Down(par_ctl As CtlGraphicFldLabel) As Boolean ''-----Implements ISelectingElements.HasAtLeastOne_Down
        ''Added 8/15/2019 thomas downes  
        Return (GetNextLowerControl(par_ctl) IsNot Nothing)
    End Function

    Private Function HasAtLeastOne____Up(par_ctl As CtlGraphicFldLabel) As Boolean ''-----Implements ISelectingElements.HasAtLeastOne__Up
        ''Added 8/15/2019 thomas downes  
        Return (GetNextHigherControl(par_ctl) IsNot Nothing)
    End Function

    Private Function GetNextLowerControl(par_ctl As CtlGraphicFldLabel) As CtlGraphicFldLabel
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        ''---For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        ''---Next each_control
        Try
            Return mod_selectedCtls.Where(Function(ctl) ctl.Top > par_ctl.Top).OrderBy(Function(ctl) ctl.Top).First
        Catch ex_linq As Exception
            ''Apparently the command above fails is there are not any lower controls.  --8/16 td 
            Return Nothing
        End Try

    End Function ''End of "Private Function GetNextLowerControl"

    Private Function GetNextHigherControl(par_ctl As CtlGraphicFldLabel) As CtlGraphicFldLabel
        ''
        ''Added 8/15/2019 thomas downes  
        ''
        ''---For Each each_control As CtlGraphicFldLabel In mod_selectedCtls
        ''---Next each_control

        Try
            Return mod_selectedCtls.Where(Function(ctl) ctl.Top < par_ctl.Top).OrderByDescending(Function(ctl) ctl.Top).First
        Catch ex_linq As Exception
            ''Apparently the command above fails is there are not any higher controls.  --8/16 td 
            Return Nothing
        End Try

    End Function ''End of "Private Function GetNextHigherControl"

    Public Function LabelsList_CountItems() As Integer ''-----Implements ISelectingElements.LabelsList_CountItems

        ''Added 8/3/2019 td 
        Return mod_selectedCtls.Count

    End Function

    Public Function LabelsList_OneOrMoreItems() As Boolean ''-----Implements ISelectingElements.LabelsList_OneOrMoreItems

        ''Added 8/3/2019 td 
        Return (1 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_TwoOrMoreItems() As Boolean ''-----Implements ISelectingElements.LabelsList_TwoOrMoreItems

        ''Added 8/3/2019 td 
        Return (2 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean ''-----Implements ISelectingElements.LabelsList_IsItemIncluded

        ''Added 8/3/2019 td 
        Return (mod_selectedCtls.Contains(par_control))

    End Function


    Public Function LabelsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean ''-----Implements ISelectingElements.LabelsList_IsItemUnselected

        ''Added 8/3/2019 td 
        Return (Not (mod_selectedCtls.Contains(par_control)))

    End Function

End Class