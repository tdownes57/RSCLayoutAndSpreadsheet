''
''Added 7/31/2019 td  
''

Partial Public Class FormDesignProtoTwo
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 
    Private mod_FieldControlLastTouched As CtlGraphicFldLabel   ''Added 8/09/2019 thomas downes 

    Public Property ControlBeingMoved() As Control ''Added 8/4/2019 td
        Get
            ''Added 8/9/2019 td
            Return mod_FieldControlLastTouched
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            mod_FieldControlLastTouched = value
        End Set
    End Property

    Public Property ControlBeingModified() As Control ''Added 8/9/2019 td
        Get
            ''Added 8/9/2019 td
            Return mod_FieldControlLastTouched
        End Get
        Set(value As Control)
            ''Added 8/9/2019 td
            mod_FieldControlLastTouched = value
        End Set
    End Property

    Public Property LabelsDesignList_AllItems As List(Of CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_AllItems
        Get
            ''Added 8/3/2019 thomas downes
            Return mod_selectedCtls
        End Get
        Set
            ''Added 8/3/2019 thomas downes
            mod_selectedCtls = Value
        End Set
    End Property

    Public Sub LabelsDesignList_Add(par_control As CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_Add
        ''
        ''Added 8/3/2019 thomas downes
        ''
        mod_selectedCtls.Add(par_control)

    End Sub

    Public Sub LabelsDesignList_Remove(par_control As CtlGraphicFldLabel) Implements ISelectingElements.LabelsDesignList_Remove
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

            ''Added 8/5/2019 thomas downes  
            each_control.TempResizeInfo_W = each_control.Width
            each_control.TempResizeInfo_H = each_control.Height

        Next each_control

    End Sub ''End of "Private Sub Resizing_Start"  

    Private Sub Move_GroupMove_Continue(DeltaLeft As Integer, DeltaTop As Integer, DeltaWidth As Integer, DeltaHeight As Integer) Handles mod_groupedMove.MoveInUnison
        ''
        ''Added 8/3/2019 thomas downes  
        ''
        Dim boolMoving As Boolean ''Added 8/5/2/019 td  
        Dim boolResizing As Boolean ''Added 8/5/2/019 td  
        Dim bControlMovedIsInGroup As Boolean ''Added 8/5/2019 td  

        ''
        ''8/5/2019 thomas downes
        ''
        If (TypeOf ControlBeingMoved Is CtlGraphicFldLabel) Then
            Const c_bCheckThatControlIsGrouped As Boolean = True ''8/5/2019 thomas downes
            If (c_bCheckThatControlIsGrouped) Then ''8/5/2019 thomas downes
                bControlMovedIsInGroup = LabelsList_IsItemIncluded(ControlBeingMoved)
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
                boolMoving = (DeltaTop <> 0 Or DeltaLeft <> 0)
                If (boolMoving) Then
                    .Top += DeltaTop
                    .Left += DeltaLeft
                End If ''End if ''End of "If (boolMoving) Then"

                ''8/5/2019 TD''.Width += DeltaWidth
                ''8/5/2019 TD''.Height += DeltaHeight

                ''Modified 8/5/2019 thomas downes
                boolResizing = ((Not boolMoving) And (.TempResizeInfo_W > 0 And .TempResizeInfo_H > 0))
                If (boolResizing) Then
                    .Width = (.TempResizeInfo_W + DeltaWidth)
                    .Height = (.TempResizeInfo_H + DeltaHeight)
                End If ''End of "If (boolResizing) Then"

                ''8/5/2019 td''txtWidthDeltas.AppendText($"Width: {DeltaWidth}" & vbCrLf)
                ''8/5/2019 td''txtWidthDeltas.AppendText($"   Height: {DeltaHeight}" & vbCrLf)

            End With ''End of "With each_control"

        Next each_control

    End Sub ''End of "Private Sub Move_GroupMove_Continue"

    Private Sub Resizing_End() Handles mod_groupedMove.Resizing_End
        ''
        ''Added 8/5/2019 thomas downes  
        ''
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            each_control.TempResizeInfo_W = 0
            each_control.TempResizeInfo_H = 0

        Next each_control

    End Sub ''End of "Private Sub Move_GroupMove_End"

    Public Function LabelsList_CountItems() As Integer Implements ISelectingElements.LabelsList_CountItems

        ''Added 8/3/2019 td 
        Return mod_selectedCtls.Count

    End Function

    Public Function LabelsList_OneOrMoreItems() As Boolean Implements ISelectingElements.LabelsList_OneOrMoreItems

        ''Added 8/3/2019 td 
        Return (1 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_TwoOrMoreItems() As Boolean Implements ISelectingElements.LabelsList_TwoOrMoreItems

        ''Added 8/3/2019 td 
        Return (2 <= mod_selectedCtls.Count)

    End Function

    Public Function LabelsList_IsItemIncluded(par_control As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.LabelsList_IsItemIncluded

        ''Added 8/3/2019 td 
        Return (mod_selectedCtls.Contains(par_control))

    End Function


    Public Function LabelsList_IsItemUnselected(par_control As CtlGraphicFldLabel) As Boolean Implements ISelectingElements.LabelsList_IsItemUnselected

        ''Added 8/3/2019 td 
        Return (Not (mod_selectedCtls.Contains(par_control)))

    End Function

End Class