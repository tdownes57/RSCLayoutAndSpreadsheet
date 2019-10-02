Option Explicit On
Option Strict On
''
''Created 9/8/2019 thomas downes  
''

Public Class ContextLayoutDesignToolstrip

    ''Public Sub LoadTheContextMenu(par_toolStripItems As ToolStripItemCollection)
    ''    ''
    ''    ''Created 9/8/2019 & 8/12/2019 thomas downes  
    ''    ''
    ''    ''Copied 9/8/2019 from Controls\CtlPartial_FieldLabel.vb
    ''    ''   (Contains Partial Class CtlGraphicFldLabel)
    ''    ''   (Code written 8/12/2019 thomas downes  
    ''    ''
    ''    ''8/16/2019 td''Dim new_item_fieldname As ToolStripMenuItem
    ''    Dim new_item_field As ToolStripMenuItem
    ''    Dim new_item_colors As ToolStripMenuItem
    ''    Dim new_item_font As ToolStripMenuItem
    ''    Dim new_item_refresh As ToolStripMenuItem ''Added 7/31/2019 td
    ''    Dim new_item_sizeInfo As ToolStripMenuItem ''Added 7/31/2019 td
    ''    Dim new_item_editExample As ToolStripMenuItem ''Added 8/110/2019 td
    ''    Dim new_item_offsetTextEtc As ToolStripMenuItem ''Added 8/15/2019 td  
    ''    Dim new_item_rotate90 As ToolStripMenuItem ''Added 8/17/2019 td  
    ''    Dim new_item_border As ToolStripMenuItem ''Added 9/02/2019 td  

    ''    ''8/12/2019 td''Static item_group_add As ToolStripMenuItem ''Added 8/2/2019 td
    ''    ''8/12/2019 td''Static item_group_omit As ToolStripMenuItem ''Added 8/2/2019 td

    ''    _item_fieldname = New ToolStripMenuItem("Field " & Me.FieldInfo.FieldLabelCaption)
    ''    ''8/16/2019 td''new_item_fieldname.Font.Bold = True ''Added 8/16/2019 td  
    ''    ''8/16/2019 td''new_item_fieldname.Font = modFonts.MakeItBold(new_item_fieldname.Font)
    ''    modFonts.MakeItBoldEtc(_item_fieldname.Font)

    ''    new_item_refresh = New ToolStripMenuItem("Refresh Element") ''Added 7/31/2019 td
    ''    new_item_sizeInfo = New ToolStripMenuItem("Size Information") ''Added 7/31/2019 td
    ''    new_item_field = New ToolStripMenuItem("Browse Field")

    ''    _item_group_add = New ToolStripMenuItem("Grouping Elements to Edit")
    ''    _item_group_omit = New ToolStripMenuItem("Remove from Grouped Elements")

    ''    new_item_colors = New ToolStripMenuItem("Set Colors")
    ''    new_item_font = New ToolStripMenuItem("Set Font")

    ''    ''Add 8/2/2019 thomas d.  
    ''    _item_group_alignLeft = New ToolStripMenuItem("Left-Hand Edge")
    ''    _item_group_alignRight = New ToolStripMenuItem("Right-Hand Edge")
    ''    ''Add 8/2/2019 thomas d.  
    ''    _item_group_alignWidth = New ToolStripMenuItem("Width")
    ''    _item_group_alignHeight = New ToolStripMenuItem("Height")

    ''    _item_group_alignTop = New ToolStripMenuItem("Top Edge")
    ''    _item_group_alignBottom = New ToolStripMenuItem("Bottom Edge")
    ''    _item_group_alignParent = New ToolStripMenuItem("Align Grouped Elements")

    ''    _item_group_switchDown = New ToolStripMenuItem("Switch Downward in List")
    ''    _item_group_switch__Up = New ToolStripMenuItem("Switch Upward in List")

    ''    ''Added 8/16/2019 td
    ''    _equalizeDistances_Top = New ToolStripMenuItem("Equalize Distances (between Top Edges)")
    ''    _equalizeDistances_Left = New ToolStripMenuItem("Equalize Distances (between Left Edges)")

    ''    ''
    ''    ''Added 8/10/2019 td
    ''    ''
    ''    new_item_editExample = New ToolStripMenuItem("Edit example value (for Layout Design)")

    ''    ''Added 8/15/2019 td  
    ''    new_item_offsetTextEtc = New ToolStripMenuItem("Position text within the element")

    ''    ''Added 8/17/2019 td  
    ''    new_item_rotate90 = New ToolStripMenuItem("Rotate text 90 degrees")

    ''    ''Added 9/02/2019 td  
    ''    new_item_border = New ToolStripMenuItem("Border Size and Color")

    ''    AddHandler new_item_field.Click, AddressOf OpenDialog_Field
    ''    AddHandler new_item_colors.Click, AddressOf OpenDialog_Color
    ''    AddHandler new_item_font.Click, AddressOf OpenDialog_Font

    ''    AddHandler new_item_refresh.Click, AddressOf RefreshElement_Field ''Added 7/31/2019 thomas d.
    ''    AddHandler new_item_sizeInfo.Click, AddressOf GiveSizeInfo_Field ''Added 7/31/2019 thomas d.

    ''    AddHandler _item_group_add.Click, AddressOf GroupEditElement_Add ''Added 8/01/2019 thomas d.
    ''    AddHandler _item_group_omit.Click, AddressOf GroupEditElement_Omit ''Added 8/01/2019 thomas d.

    ''    AddHandler _item_group_switchDown.Click, AddressOf SwitchCtl_Down ''Added 8/15/2019 thomas d.
    ''    AddHandler _item_group_switch__Up.Click, AddressOf SwitchCtl__Up ''Added 8/15/2019 thomas d.

    ''    ''Added 8/10/2019 thomas d.
    ''    AddHandler new_item_editExample.Click, AddressOf ExampleValue_Edit ''Added 8/10/2019 thomas d.

    ''    ''Added 8/15/2019 thomas d.
    ''    AddHandler new_item_offsetTextEtc.Click, AddressOf Open_OffsetTextDialog ''Added 8/15/2019 thomas d.

    ''    ''Added 8/17/2019 thomas d.
    ''    AddHandler new_item_rotate90.Click, AddressOf Rotate90Degrees ''Added 8/17 /2019 thomas d.

    ''    ''Added 8/17/2019 thomas d.
    ''    AddHandler new_item_border.Click, AddressOf BorderDesign ''Added 9/02 /2019 thomas d.

    ''    par_toolStripItems.Add(_item_fieldname)   ''ContextMenuStrip1.Items.Add(new_item_fieldname)
    ''    par_toolStripItems.Add(new_item_field)   ''ContextMenuStrip1.Items.Add(new_item_field)

    ''    par_toolStripItems.Add(new_item_colors)   ''ContextMenuStrip1.Items.Add(new_item_colors)
    ''    par_toolStripItems.Add(new_item_font)   ''ContextMenuStrip1.Items.Add(new_item_font)

    ''    ''Added 8/17/2019 td
    ''    par_toolStripItems.Add(new_item_offsetTextEtc)
    ''    par_toolStripItems.Add(new_item_rotate90)
    ''    par_toolStripItems.Add(new_item_border) ''Added 9/2/2019 td

    ''    ''Moved from below, 8/14/2019 td 
    ''    par_toolStripItems.Add(_item_group_alignParent)   ''ContextMenuStrip1.Items.Add(item_group_alignParent) ''Added 8/5/2019 thomas d.  

    ''    par_toolStripItems.Add(new_item_refresh)   ''ContextMenuStrip1.Items.Add(new_item_refresh) ''Added 7/31/2019 thomas d.  
    ''    par_toolStripItems.Add(new_item_sizeInfo)   ''ContextMenuStrip1.Items.Add(new_item_sizeInfo) ''Added 7/31/2019 thomas d.

    ''    ''If (Me.GroupEdits.LabelsList_IsItemUnselected(Me)) Then
    ''    par_toolStripItems.Add(_item_group_add)   ''ContextMenuStrip1.Items.Add(new_item_group_add) ''Added 8/01/2019 thomas d.  
    ''    ''End If

    ''    ''If (Me.GroupEdits.LabelsList_IsItemIncluded(Me)) Then
    ''    par_toolStripItems.Add(_item_group_omit)   ''ContextMenuStrip1.Items.Add(new_item_group_omit) ''Added 8/01/2019 thomas d.  
    ''    ''End If

    ''    ''Add 8/16/2019 thomas d.  
    ''    par_toolStripItems.Add(_item_group_switch__Up)
    ''    par_toolStripItems.Add(_item_group_switchDown)

    ''    ''Add 8/2/2019 thomas d.  
    ''    ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignLeft) ''Added 8/01/2019 thomas d.  
    ''    ''8/5/2019 td''ContextMenuStrip1.Items.Add(new_item_group_alignRight) ''Added 8/01/2019 thomas d.  

    ''    ''Add 8/5/2019 thomas d.  
    ''    ''Moved to the top.par_toolStripItems.Add(_item_group_alignParent)   ''ContextMenuStrip1.Items.Add(item_group_alignParent) ''Added 8/5/2019 thomas d.

    ''    Dim toolstripAlignParent As ToolStripMenuItem = CType(_item_group_alignParent, ToolStripMenuItem)

    ''    ''Added 8/10/2019 thomas d.
    ''    par_toolStripItems.Add(new_item_editExample)   ''ContextMenuStrip1.Items.Add(new_item_editExample) ''Added 8/10/2019 thomas d.  

    ''    ''
    ''    ''Add 8/5/2019 thomas d.  
    ''    ''
    ''    With toolstripAlignParent.DropDownItems

    ''        .Add(_item_group_alignLeft)
    ''        .Add(_item_group_alignRight)

    ''        .Add(_item_group_alignTop)
    ''        .Add(_item_group_alignBottom)

    ''        .Add(_item_group_alignWidth)
    ''        .Add(_item_group_alignHeight)

    ''        ''Added 8/16/2019 thoimas downes 
    ''        .Add(_equalizeDistances_Top)
    ''        .Add(_equalizeDistances_Left)

    ''    End With ''End of "With toolstripAlignParent.DropDownItems"

    ''    ''
    ''    ''Add 8/5/2019 thomas d.  
    ''    ''
    ''    AddHandler _item_group_alignLeft.Click, AddressOf Alignment_Master
    ''    AddHandler _item_group_alignRight.Click, AddressOf Alignment_Master

    ''    AddHandler _item_group_alignTop.Click, AddressOf Alignment_Master
    ''    AddHandler _item_group_alignBottom.Click, AddressOf Alignment_Master

    ''    AddHandler _item_group_alignWidth.Click, AddressOf Alignment_Master
    ''    AddHandler _item_group_alignHeight.Click, AddressOf Alignment_Master

    ''    ''Add 8/16/2019 thomas d.  
    ''    AddHandler _equalizeDistances_Left.Click, AddressOf Alignment_Master
    ''    AddHandler _equalizeDistances_Top.Click, AddressOf Alignment_Master

    ''End Sub ''End of "Private Sub LoadTheContextMenu()" 

End Class
