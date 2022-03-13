Option Explicit On
Option Strict On
Option Infer Off
''
''Added 9/9/2019 td  
''
Imports ciBadgeInterfaces ''Added 9/9/2019 td 
''Not needed here. ---10/3/2019 td''Imports ciBadgeFields ''Added 9/18/2019 td 
Imports ciBadgeElements ''Added 9/18/2019 td 

Public Class CtlMainEntryBox_v90

    ''
    ''   This is to store the initial Width & Height, when resizing.
    ''
    ''Denigrated. 9/19/2019 td''Public FormDesigner As FormMainEntry_v90 ''Added 9/9/2019 td  
    Public LayoutFunctions As ciBadgeInterfaces.ILayoutFunctions ''Added 8/9/2019 td  

    Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)

    Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)

    Public FieldInfo As ICIBFieldStandardOrCustom

    Public ElementClass_Obj As ClassElementFieldV3 ''Added 9/4/2019 thomas downes
    Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base
    Public GroupEdits As ISelectingElements ''Added 7/31/2019 thomas downes  
    Public SelectedHighlighting As Boolean ''Added 8/2/2019 td
    Private mod_includedInGroupEdit As Boolean ''Added 8/1/2019 thomas downes 


    Private Sub CtlMainEntryBox_v90_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub Refresh_Master()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        Refresh_PositionAndSize()

        ''9/9/2019 td''Refresh_Image()
        Refresh_FontSizes()

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        ''10/3/2019 td''Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''10/3/2019 td''Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_FontSizes()
        ''
        ''Stubbed 9/9/2019 thomas d 
        ''



    End Sub

End Class
