Option Explicit On
Option Strict On
Option Infer Off
''
''Added 9/9/2019 td  
''
Imports ciBadgeInterfaces ''Added 9/9/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td 

Public Class CtlMainEntryBox_v90

    ''
    ''   This is to store the initial Width & Height, when resizing.
    ''
    Public FormDesigner As FormMainEntry_v90 ''Added 9/9/2019 td  

    Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)

    Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)

    Public FieldInfo As ICIBFieldStandardOrCustom

    Public ElementClass_Obj As ClassElementField ''Added 9/4/2019 thomas downes
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

    Public Sub New_NotInUse(par_field As ICIBFieldStandardOrCustom)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''9/4/2019 td''Me.ElementInfo_Text = New ClassElementText(Me)

        Dim obj_elementText As ClassElementField ''Added 9/4/2019 thomas d.
        obj_elementText = New ClassElementField(Me) ''Added 9/4/2019 thomas d.
        Me.ElementClass_Obj = obj_elementText ''Added 9/4/2019 thomas d.
        Me.ElementInfo_Base = CType(obj_elementText, IElement_Base) ''Added 9/4/2019 thomas d.
        Me.ElementInfo_Text = CType(obj_elementText, IElement_TextField)  ''Added 9/4/2019 thomas d.

    End Sub

    Public Sub New(par_field As ClassFieldStandard,
                   Optional par_formDesigner As FormMainEntry_v90 = Nothing,
                   Optional par_elementText As ClassElementField = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''Added 9/3/2019 thomas downes
        ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

        ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
        ''9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            Me.ElementClass_Obj = par_field.ElementFieldClass
            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 9/9 & 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New(par_field As ClassFieldCustomized,
                   Optional par_formDesigner As FormMainEntry_v90 = Nothing,
                   Optional par_elementText As ClassElementField = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''Added 9/3/2019 thomas downes
        ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo, IElement_Base)

        ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
        ''#1 9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        '' #2 9/4/2019 td''Me.ElementClass_Obj = par_field.ElementInfo
        '' #2 9/4/2019 td''Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
        '' #2 9/4/2019 td''Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            Me.ElementClass_Obj = par_field.ElementFieldClass
            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 8/9/2019 td
        Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New(par_field As ICIBFieldStandardOrCustom,
                   Optional par_formDesigner As FormMainEntry_v90 = Nothing,
                   Optional par_elementText As ClassElementField = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_field

        ''Added 9/3/2019 td
        ''9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
        ''9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            Me.ElementClass_Obj = Nothing ''9/4/2019 td''par_field.ElementInfo
            Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
            Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_TextField)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 9/3/2019 td
        Me.FormDesigner = par_formDesigner

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
        Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_FontSizes()
        ''
        ''Stubbed 9/9/2019 thomas d 
        ''



    End Sub

End Class
