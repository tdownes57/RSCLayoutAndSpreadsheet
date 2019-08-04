''
''Added 7/31/2019 td  
''

Partial Public Class FormDesignProtoTwo
    ''
    ''Added 7/31/2019 thomas downes  
    ''
    Private mod_selectedCtls As New List(Of CtlGraphicFldLabel)   ''Added 8/03/2019 thomas downes 


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

    Private Sub Move_GroupMove(DeltaLeft As Integer, DeltaTop As Integer, DeltaWidth As Integer, DeltaHeight As Integer) Handles mod_groupedMove.MoveInUnison
        ''
        ''Added 8/3/2019 thomas downes  
        ''
        For Each each_control As CtlGraphicFldLabel In mod_selectedCtls

            With each_control

                ''Added 8/3/2019 thomas downes  
                .Top += DeltaTop
                .Left += DeltaLeft
                .Width += DeltaWidth
                .Height += DeltaHeight

            End With ''End of "With each_control"

        Next each_control

    End Sub ''End of "Private Sub mod_moveAndResizeCtls_GroupMove"

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