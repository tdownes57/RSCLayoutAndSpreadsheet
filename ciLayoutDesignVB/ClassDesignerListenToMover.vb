Public Class ClassDesignerListenToMover_Deprecated
    ''
    ''Added 11/29/2021 thomas Downes
    ''
    ''   This class module is deprecated. 
    ''
    ''   See project ciBadgeDesigner for this class,
    ''       ClassDesignerListenToMover. 
    ''
    ''   ----11/29/2021 td 
    ''
    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/1/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me.LayoutFunctions) ''8/4/2019 td''New ClassGroupMove


    ''Private WithEvents mod_groupedMove As New ClassGroupMoveEvents(Me) ''8/4/2019 td''New ClassGroupMove

    ''Private WithEvents mod_sizingEvents_Pics As New ClassGroupMoveEvents(Me) ''Added 10/9/2019 td  
    ''Private WithEvents mod_sizingEvents_QR As New ClassGroupMoveEvents(Me) ''Added 10/12/2019 td  
    ''Private WithEvents mod_sizingEvents_Sig As New ClassGroupMoveEvents(Me) ''Added 10/12/2019 td  

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    Private Const mc_boolBreakpoints As Boolean = True
    Private Const mc_boolMoveGrowInUnison As Boolean = True ''Added 10/10/2019 td 





End Class
