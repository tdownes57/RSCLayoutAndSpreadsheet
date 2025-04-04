﻿Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
Option Infer Off ''Added 8/29/2019 td  

''
''Added 7/25/2019 thomas d 
''
Imports ciBadgeInterfaces ''Added 8/28/2019 thomas downes 
Imports ciBadgeFields ''Added 9/18/2019 thomas downes 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeElemImage ''Added 9/20/2019 td 

Public Class CtlGraphicFldLabel_NotInUse
    ''
    ''Added 7/25/2019 thomas d 
    ''Suffixed with "_NotInUse", 10/3/2019 td 
    ''
    ''9/3/2019 td''Public Shared Generator As ClassLabelToImage
    Public Shared LabelToImage As ClassLabelToImage

    ''Added 9/13/2019 td  
    Public Shared UseExampleValues As Boolean

    ''7/26/2019 td''Public FieldInfo As ClassFieldCustomized
    ''7/26/2019 td''Public ElementInfo As ClassElementText
    Public FieldInfo As ICIBFieldStandardOrCustom

    ''#1 8/29/2019 td''Public ElementInfo As ClassElementText
    '' #2 8/29/2019 td''Public ElementInfo_Text As ClassElementText

    Public ElementClass_Obj As ClassElementField ''Added 9/4/2019 thomas downes
    Public ElementInfo_Text As ciBadgeInterfaces.IElement_TextField
    Public ElementInfo_Base As ciBadgeInterfaces.IElement_Base

    Public GroupEdits As ISelectingElements ''Added 7/31/2019 thomas downes  
    Public SelectedHighlighting As Boolean ''Added 8/2/2019 td
    Public ExampleTextToDisplay As String = "" ''Added 9/19/2019 td

    Private mod_includedInGroupEdit As Boolean ''Added 8/1/2019 thomas downes 

    Private Const mod_c_boolMustSetBackColor As Boolean = False ''False, since we have an alternate Boolean 
    ''   below which works fine (i.e. mod_c_bRefreshMustReinitializeImage = True).
    ''   We don't need to set the Background Color of the PictureBox control.  ----7/31/2019 thomas d. 

    Private Const mod_c_bRefreshMustResizeImage As Boolean = True ''True, since otherwise the background color 
    ''  is (frustratingly) limited to the original control size, _NOT_ the resized control's full area
    ''  (enlarged via user click-and-drag), unfortunately.  ----7/31/2019 thomas d.  

    Public ReadOnly Property Picture_Box As PictureBox
        Get
            ''Added 7/28/2019 td 
            Return Me.pictureLabel
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 9/19/2019 td
        ''9/19/2019 td''Throw New NotImplementedException("This initializer is not allowed.  A element-of-field must be supplied.")

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

    Public Sub New_Deprecated(par_field As ClassFieldStandard,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
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
            ''This Sub New is deprecated.---9/18/2019 td''Me.ElementClass_Obj = par_field.ElementFieldClass
            Me.ElementInfo_Base = CType(Me.ElementClass_Obj, IElement_Base)
            Me.ElementInfo_Text = CType(Me.ElementClass_Obj, IElement_TextField)
        Else
            ''
            ''Added 9/4/2019 thomas d.
            ''
            ''This Sub New is deprecated.---9/18/2019 td''Me.ElementClass_Obj = par_elementText
            Me.ElementInfo_Base = CType(par_elementText, IElement_Base)
            Me.ElementInfo_Text = CType(par_elementText, IElement_TextField)
        End If ''End of "If (par_elementText Is Nothing) Then .... Else ...."

        ''Added 8/9/2019 td
        ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    End Sub

    Public Sub New_Deprecated(par_field As ClassFieldCustomized,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
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
            ''This Sub New is deprecated.  ---9/18/2019 td''Me.ElementClass_Obj = par_field.ElementFieldClass
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
        ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    End Sub ''ENd of "Public Sub New_Deprecated"

    Public Sub New_Deprecated(par_field As ICIBFieldStandardOrCustom,
                   Optional par_formDesigner As FormDesignProtoTwo = Nothing,
                   Optional par_elementText As ClassElementField = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''
        Me.FieldInfo = par_field

        ''Added 9/3/2019 td
        ''  9/4/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
        ''  9/4/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

        ''
        ''Refactored 9/4/2019 td  
        ''
        If (par_elementText Is Nothing) Then
            ''9/15/2019 td''Me.ElementClass_Obj = Nothing ''9/4/2019 td''par_field.ElementInfo

            Me.ElementClass_Obj = New ClassElementField

            ''
            ''------ IMPORTANT ------------------
            ''------ POTENTIALLY CONFUSING-------
            ''
            ''-------Fields no longer contain links to Elements. ---9/18/2019 td 
            ''-----Me.ElementClass_Obj.LoadbyCopyingMembers(par_field.ElementInfo_Base, par_field.ElementInfo_Text)

            ''  9/15/2019 td''Me.ElementInfo_Base = CType(par_field.ElementInfo_Base, IElement_Base)
            ''  9/15/2019 td''Me.ElementInfo_Text = CType(par_field.ElementInfo_Text, IElement_Text)

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

        ''Added 9/3/2019 td
        ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner

    End Sub ''ENd of "Public Sub New_Deprecated"

    Public Sub New(par_elementField As ClassElementField,
                  par_layout As ILayoutFunctions)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.FieldInfo = par_elementField.FieldInfo

        Me.ElementClass_Obj = par_elementField
        Me.ElementInfo_Base = CType(par_elementField, IElement_Base)
        Me.ElementInfo_Text = CType(par_elementField, IElement_TextField)
        Me.LayoutFunctions = par_layout

        ''Added 9/20/2019 td 
        ''   Add an alert to the user that the element is not rendered
        ''   on the Badge.  ----9/20/2019 td 
        Dim bElementInvisibleOnBadge As Boolean
        bElementInvisibleOnBadge = (Not Me.ElementInfo_Base.Visible)
        LinkInvisible.Visible = bElementInvisibleOnBadge

    End Sub ''ENd of "Public Sub New "

    Public Sub Refresh_Master(Optional pboolDialogApplyButton As Boolean = False)
        ''
        ''Added 9/5/2019 thomas d 
        ''
        If (pboolDialogApplyButton) Then System.Diagnostics.Debugger.Break() ''Added 9/19/2019 td  
        If (pboolDialogApplyButton) Then MessageBox.Show(Me.LayoutFunctions.NameOfForm()) ''Added 9/19/2019 td  

        Refresh_PositionAndSize()

        ''#1 9/15 td''Refresh_Image
        '' #2 9/15 tdRefresh_Image(False)
        Refresh_Image(False)

ExitHandler:
        ''
        ''Check for Label-Control size discrepancies.  ---9/23 thomas d.    
        ''
        Dim boolWidthDisparity As Boolean ''Added 9/23/2019 td 
        Dim boolHeightDisparity As Boolean ''Added 9/23/2019 td 
        Dim intTry As Integer ''Why this is needed, is not clear.
        Dim bDisparity_Neither As Boolean ''Added 9/23/2019 td 

        For intTry = 1 To 3 ''Why this is needed, is not clear. It's needed in conjunction with rotations. 

            ''Check for Label-Control size discrepancies.  ---9/23 thomas d.    
            boolWidthDisparity = (Math.Abs(Me.Width - Me.pictureLabel.Width) > 5) Or
                            (Math.Abs(Me.pictureLabel.Width - Me.pictureLabel.Image.Width) > 5)
            boolHeightDisparity = (Math.Abs(Me.Height - Me.pictureLabel.Height) > 5) Or
                                (Math.Abs(Me.pictureLabel.Height - Me.pictureLabel.Image.Height) > 5)

            bDisparity_Neither = (Not (boolWidthDisparity Or boolHeightDisparity))
            If (bDisparity_Neither) Then Exit For

            ''Why this is needed, is not clear.
            Me.pictureLabel.Width = Me.pictureLabel.Image.Width
            Me.pictureLabel.Height = Me.pictureLabel.Image.Height

        Next intTry

        ''Issue a program-execuation break, if needed.     
        If (boolWidthDisparity) Then System.Diagnostics.Debugger.Break()
        If (boolHeightDisparity) Then System.Diagnostics.Debugger.Break()

    End Sub ''End of "Public Sub Refresh_Master()"

    Public Sub Refresh_PositionAndSize()
        ''
        ''Added 9/5/2019 thomas d 
        ''
        ''9/19/2019 td''Me.Left = Me.FormDesigner.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        ''9/19/2019 td''Me.Top = Me.FormDesigner.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Left = Me.LayoutFunctions.Layout_Margin_Left_Add(Me.ElementInfo_Base.LeftEdge_Pixels)
        Me.Top = Me.LayoutFunctions.Layout_Margin_Top_Add(Me.ElementInfo_Base.TopEdge_Pixels)

        Me.Width = Me.ElementInfo_Base.Width_Pixels
        Me.Height = Me.ElementInfo_Base.Height_Pixels

    End Sub ''End of "Public Sub Refresh_PositionAndSize()"

    Public Sub Refresh_Image(pbRefreshSize As Boolean,
                             Optional pboolResizeLabelControl As Boolean = True,
                             Optional pboolRefreshLabelControl As Boolean = True,
                             Optional pboolRefreshUserControl As Boolean = False)
        ''
        ''Added 7/25/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText(
        ''8/4/2019''If (String.IsNullOrEmpty(Me.ElementInfo.Text)) Then ElementInfo.Text = LabelText()

        Dim boolScaleFontSize As Boolean ''Added 9/15/2019 thomas d. 

        ElementInfo_Text.Text = LabelText()

        ''Me.ElementInfo.Width = pictureLabel.Width
        ''Me.ElementInfo.Height = pictureLabel.Height

        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = Me.ParentForm.Font ''Me.Font
        ''7/30/2019 td''Me.ElementInfo.Font_DrawingClass = New Font("Times New Roman", 25, FontStyle.Italic)

        boolScaleFontSize = (Me.ElementInfo_Text.FontSize_ScaleToElementYesNo)
        If (boolScaleFontSize And Me.ElementClass_Obj Is Nothing) Then
            ''Added 9/19/2019 td 
            MessageBox.Show("Where is the Element-Field Class???   We will need it to scale the Font.", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If ''End of "If (boolScaleFontSize) Then"

        If (Me.ElementInfo_Text.Font_DrawingClass Is Nothing) Then
            ''
            ''Initialize the font. 
            ''
            ''9/6/2019 tdMe.ElementInfo_Text.Font_DrawingClass = New Font("Times New Roman", 15, FontStyle.Regular)

            With Me.ElementInfo_Text
                ''9/6/2019 td''.FontSize = 15
                .FontSize_Pixels = 25 ''9/6/2019 ''15
                .FontBold = False
                .FontItalics = False
                .FontUnderline = False ''Added 9/6/2019 thomas downes
                .FontFamilyName = "Times New Roman"
                ''9/6/2019 td''.Font_DrawingClass = New Font(.FontFamilyName, .FontSize_Pixels, FontStyle.Regular, GraphicsUnit.Pixel)
                .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
            End With

        End If ''end of " If (Me.ElementInfo.Font_DrawingClass Is Nothing) Then"

        ''Me.ElementInfo.BackColor = Me.ParentForm.BackColor
        ''Me.ElementInfo.FontColor = Me.ParentForm.ForeColor

        ''Added 8/18/2019 thomas downes 
        If (pbRefreshSize) Then
            ''
            ''Adjust the size of the label graphic. 
            ''
            pictureLabel.Width = Me.ElementInfo_Base.Width_Pixels
            pictureLabel.Height = Me.ElementInfo_Base.Height_Pixels

            ''Added 9/15/2019 thomas d.
            boolScaleFontSize = (Me.ElementInfo_Text.FontSize_ScaleToElementYesNo)
            If (boolScaleFontSize) Then
                ''Added 9/15/2019 thomas d.
                Me.ElementClass_Obj.Font_ScaleAdjustment(Me.ElementInfo_Base.Height_Pixels)
            End If ''End of "If (boolScaleFontSize) Then"

        End If ''end if "If (pbRefreshSize) then"

        If (LabelToImage Is Nothing) Then LabelToImage = New ClassLabelToImage

        ''
        ''Added 7/31/2019 thomas 
        ''
        Dim boolReinitializeImage As Boolean ''Added 7/31/2019 thomas
        Const c_bMustReinitializeToResize As Boolean = True ''Added 7/31/2019 thomas
        boolReinitializeImage = (c_bMustReinitializeToResize And mod_c_bRefreshMustResizeImage)

        If (boolReinitializeImage) Then
            ''
            ''Destroy & recreate the .Image member from scratch, to allow for a new size. ----7/31/2019 td
            ''
            pictureLabel.Image = Nothing

            If (pictureLabel.Width > 0 And pictureLabel.Height > 0) Then
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, pictureLabel.Height))
            ElseIf (pictureLabel.Width > 0 And pictureLabel.Height = 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Height = Zero (0). ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(pictureLabel.Width, 15))
            ElseIf (pictureLabel.Width = 0 And pictureLabel.Height > 0) Then
                ''Don't allow a run-time error to occur, due to a parameter of Width = Zero (0).  ----8/3/2019 td
                pictureLabel.Image = (New Bitmap(15, pictureLabel.Height))
            End If

        End If ''End of "If (boolReinitializeImage) Then"

        ''7/29/2019 td''pictureLabel.Image = Generator.TextImage(Me.ElementInfo, Me.ElementInfo)
        ''8/18/2019 td''Generator.TextImage(pictureLabel.Image, Me.ElementInfo, Me.ElementInfo)

        Dim boolRotated As Boolean ''Added 8/18/2019 td

        ''Added 8/18/2019 td
        ''9/3/2019 td''LabelToImage.TextImage(pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        Dim intBadgeLayoutWidth As Integer ''Added 9/3/2019 thomas d.
        ''9/19/2019 td''intLayoutWidth = Me.FormDesigner.Layout_Width_Pixels()
        intBadgeLayoutWidth = Me.LayoutFunctions.Layout_Width_Pixels()

        ''9/4/2019 td''LabelToImage.TextImage(intLayoutWidth, pictureLabel.Image, Me.ElementInfo_Text, Me.ElementInfo_Base, boolRotated)

        ''
        ''Major call !!
        ''
        Dim newTextImage As Image ''Added 9/20/2019 td  

        Const c_boolUseNewestProjectReference As Boolean = True ''Added 9/20/2019 td 
        If (c_boolUseNewestProjectReference) Then

            newTextImage =
            modGenerate.TextImage_ByElemInfo(intBadgeLayoutWidth,
                                   Me.ElementInfo_Text,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        Else
            ''9/20/2019 td''pictureLabel.Image =
            newTextImage =
            LabelToImage.TextImage_Field(intBadgeLayoutWidth, Me.ElementInfo_Text,
                                   Me.ElementInfo_Base,
                                   boolRotated, True)
        End If ''End of "If (c_boolUseNewestProjectReference) Then ..... Else ...."

        ''Added 9/20/2019 td
        pictureLabel.Image = newTextImage

        ''Added 9/23/2019 td
        Application.DoEvents() ''Give the PictureBox control time to make any adjustments it might want to do. 

ExitHandler:
        If (pboolResizeLabelControl) Then ''Added9/23/2019 td 

            ''Added 8/18/2019 td
            Dim intNewImageWidth As Integer ''Added 8/18/2019 td
            Dim intNewImageHeight As Integer ''Added 9/20/2019 td

            ''9/20/2019 td''intNewImageWidth = pictureLabel.Image.Width
            intNewImageWidth = newTextImage.Width ''Added 9/20/2019 td
            intNewImageHeight = newTextImage.Height ''Added 9/20/2019 td

            If (boolRotated) Then ''Added 8/18/2019 td
                ''
                ''Rotated Images ---  Any special programming needed? 
                ''
                ''Adjust the controls to the image size.
                ''   Is there any special programming for rotated images?   Probably not! ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height
                pictureLabel.Width = intNewImageWidth ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight ''Straightforward.   No reversal is needed here, despite the rotation. ---9/20 td 
                Application.DoEvents()
                pictureLabel.Invalidate() ''Forces it to be repainted.  

                Me.Height = pictureLabel.Height
                Application.DoEvents()
                Me.Width = pictureLabel.Width
            Else
                ''
                ''Adjust the controls to the image size. ---9/3/2019 td 
                ''
                ''9/20/2019 td''pictureLabel.Width = pictureLabel.Image.Width
                ''9/20/2019 td''pictureLabel.Height = pictureLabel.Image.Height
                pictureLabel.Width = intNewImageWidth
                Application.DoEvents()
                pictureLabel.Height = intNewImageHeight
                Application.DoEvents()
                Me.Height = pictureLabel.Height
                Application.DoEvents()
                Me.Width = pictureLabel.Width

            End If ''End if "If (boolRotated) Then .... Else ...."

        End If ''End of "If (par_boolResizeLabelControl) Then ..... Else ...."

        ''Added 7/31/2019 td
        If (mod_c_boolMustSetBackColor And (ElementInfo_Text IsNot Nothing)) Then
            ''
            ''A desperate attempt to get the background color to extend to the full, resized control.
            ''
            Dim boolColorDiscrepancy As Boolean = False ''Added 7/31/2019 td
            ''8/29 td''boolColorDiscrepancy = (Me.ElementInfo_Text.BackColor <> Me.ElementInfo_Text.Back_Color)

            If (boolColorDiscrepancy) Then
                MessageBox.Show("Warning, there is a discrepancy in the color information.", "ciLayout",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If ''ENd of "If (boolColorDiscrepancy) Then"

            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color
            ''8/29/2019 td''pictureLabel.BackColor = Me.ElementInfo_Text.BackColor
            pictureLabel.BackColor = Me.ElementInfo_Base.Back_Color

        End If ''End of "If (mod_c_boolMustSetBackColor And (ElementInfo IsNot Nothing)) Then"

        If (pboolRefreshLabelControl) Then
            ''8/19/2019 td''pictureLabel.Refresh()
            pictureLabel.Invalidate() ''Forces it to be re-painted. ---9/21/2019 td 
            pictureLabel.Refresh()
        End If ''End of "If (par_boolRefreshLabelControl) Then"

        If (pboolRefreshUserControl) Then
            Me.Refresh()
        End If ''ENd of "If (par_boolRefreshUserControl) Then"

    End Sub ''End of Public Sub Refresh_Image

    Public Sub SaveToModel()
        ''
        ''Added 7/29/2019 thomas d 
        ''
        ''7/29 td''Me.ElementInfo.Info = CType(Me.ElementInfo, IElementText)

        ''Me.ElementInfo.Text = Me.LabelText()

        ''9/5/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.Top
        ''9/5/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.Left

        ''9/19/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
        ''9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''
        ''Width & Height
        ''
        ''       (Account for rotated text, if applicable.) 
        ''
        If (Me.Rotated_0degrees()) Then
            ''
            ''Normal.  Easy-peasy.  The text is not rotated at all. 
            ''
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height
        ElseIf (Me.Rotated_180_360()) Then
            ''
            ''Normal, easy-peasy. 
            ''
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

        ElseIf (Me.Rotated_90_270()) Then
            ''
            ''-------DIFFICULT/CONFUSING-----
            ''This is rotated, so let's pull a switcheroo. 
            ''   ----9/23/2019 TD  
            ''
            If (Me.Width < Me.Height) Then
                Me.ElementInfo_Base.Width_Pixels = Me.Height
                Me.ElementInfo_Base.Height_Pixels = Me.Width
            Else
                ''Added 9/23/2019 td 
                Throw New Exception("Logically, this should not occur. #1957 " &
                                    "(Because the function Me.Rotated_90_270() says, we are rotated. " &
                                    "  (The function checks the Element.))")
            End If ''End of "If (Me.Width < Me.Height) Then"
        Else
            ''Added 9/23/2019 td 
            Throw New Exception("Logically, this should Not occur. #1958  " &
                                "(because we have accounted for all rotational positions).")
        End If ''End of "If (Me.Rotated_0degrees()) Then .... ElseIf .... ElseIf ...."

        ''Added 9/4/2019 thomas downes
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''9/5/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        ''9/5/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        ''Me.ElementInfo.Font_DrawingClass = Me.Font
        ''Me.ElementInfo.BackColor = Me.BackColor
        ''Me.ElementInfo.FontColor = Me.ForeColor

        ''
        ''Added 9/15/2019 thomas d. 
        ''
        ''9/18/2019 td''
        ''Select Case True
        ''    Case Me.FieldInfo.IsStandard
        ''        ''
        ''        ''Standard field. 
        ''        ''
        ''        ''Added 9/15/2019 thomas d.
        ''        ClassFieldStandard.CopyElementInfo(Me.FieldInfo.FieldIndex,
        ''                                           Me.ElementInfo_Base, Me.ElementInfo_Text)
        ''
        ''    Case Else
        ''        ''
        ''        ''Customized field.
        ''        ''
        ''        ''Added 9/15/2019 thomas d.
        ''        ClassFieldCustomized.CopyElementInfo(Me.FieldInfo.FieldEnumValue,
        ''                                           Me.ElementInfo_Base, Me.ElementInfo_Text)
        ''
        ''End Select

    End Sub ''End of Public Sub SaveToModel

    Public Function Rotated_90_270() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolTextImageRotated_0_180 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_Obj.OrientationInDegrees

            Case 90, 270

                ''Double-check the orientation.  ----9/23/2019 td
                boolTextImageRotated_0_180 = (Me.pictureLabel.Image.Width > Me.pictureLabel.Image.Height)
                If (boolTextImageRotated_0_180) Then
                    Throw New Exception("Image dimensions are Not expected.")
                End If ''End of "If (boolImageRotated_0_180) Then"

                Return True

            Case Else : Return False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

    End Function ''End of "Public Function Rotated_90_270() As Boolean"

    Public Function Rotated_0degrees() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        Dim boolTextImageRotated_90_270 As Boolean ''Added 9/23/2019 thomas d.  

        Select Case Me.ElementClass_Obj.OrientationInDegrees

            Case 0, 360

                ''Double-check the orientation.  ----9/23/2019 td
                boolTextImageRotated_90_270 = (Me.pictureLabel.Image.Width < Me.pictureLabel.Image.Height)
                If (boolTextImageRotated_90_270) Then
                    Throw New Exception("Image dimensions are Not expected.")
                End If ''End of "If (boolImageRotated_90_270) Then"

                Return True

            Case Else : Return False

        End Select ''ENd of "Select Case Me.ElementClass_Obj.OrientationInDegrees"

    End Function ''End of "Public Function Rotated_0degrees() As Boolean"

    Public Function Rotated_180_360() As Boolean
        ''
        ''Added 9/23/2019 thomas d.  
        ''
        ''  This function is the numerical equivalent of, Portrait vs. Landscape.
        ''   (This function purposely _ignores_ the rotational distinction
        ''   between 180 degrees & 360 degrees. ----9/23/2019 td)
        ''
        Dim boolReturnValue As Boolean
        Dim boolTextImageRotated_90_270 As Boolean ''Added 9/23/2019 thomas d.  
        Const c_SemiCircle_Degrees As Integer = 180

        boolReturnValue = (0 = (Me.ElementClass_Obj.OrientationInDegrees Mod c_SemiCircle_Degrees))

        ''Double-check the orientation.  ----9/23/2019 td
        If (boolReturnValue) Then
            boolTextImageRotated_90_270 = (Me.pictureLabel.Image.Width < Me.pictureLabel.Image.Height)
            If (boolTextImageRotated_90_270) Then
                Throw New Exception("Image dimensions are Not expected.")
            End If ''End of "If (boolImageRotated_90_360) Then"
        End If ''End of "If (boolReturnValue) Then"

        Return boolReturnValue

    End Function ''End of "Public Function Rotated_180_360() As Boolean"

    Public Function LabelText() As String
        ''
        ''Added 7/25/2019 thomas d 
        ''
        Select Case True

            Case (Me.ExampleTextToDisplay.Trim() <> "")
                ''
                ''Added 9/18/2019 td 
                ''
                Return Me.ExampleTextToDisplay

            Case (Me.ElementInfo_Text.ExampleValue_ForElement <> "")
                ''
                ''Added 9/18/2019 td 
                ''
                Return Me.ElementInfo_Text.ExampleValue_ForElement

            Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.ExampleValue

            Case (Me.FieldInfo.FieldLabelCaption <> "")

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.FieldLabelCaption

            Case Else

                ''Default value.
                ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
                Return $"Field #{Me.FieldInfo.FieldIndex}"

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText() As String"

    Public Function InsideMe(par_intX As Integer, par_intY As Integer) As Boolean
        ''
        ''Added 9/20/2019 td  
        ''
        Dim boolInsideHorizontally As Boolean
        Dim boolInsideVertically As Boolean
        Dim boolInside_BothWays As Boolean

        boolInsideHorizontally = (Me.Left <= par_intX And par_intX <= (Me.Left + Me.Width))
        boolInsideVertically = (Me.Top <= par_intY And par_intY <= (Me.Top + Me.Height))

        boolInside_BothWays = (boolInsideHorizontally And boolInsideVertically)
        Return boolInside_BothWays

    End Function ''eND OF "Public Function InsideMe(par_intX, par_intY As Integer) As Boolean"

    Public Sub Highlight_IfInsideRubberband(par_rubberband As Rectangle)
        ''
        ''Added 9/20/2019 thomas downes
        ''
        Dim boolRubBandIsAll_LeftOfMe As Boolean
        Dim boolRubBandIsAll_RightOfMe As Boolean
        Dim boolRubBandIsAll_AboveMe As Boolean
        Dim boolRubBandIsAll_BelowMe As Boolean

        Dim boolBandIsInsideMeHorizontally As Boolean
        Dim boolBandIsInsideMeVertically As Boolean
        Dim boolBandIsInsideMe_BothWays As Boolean
        Dim boolBandOverlapsWithMe As Boolean

        Dim obj_rectangleAdjusted As Rectangle

        Dim intRbandInDesignForm_Left As Integer
        Dim intRbandInDesignForm_Top As Integer

        With par_rubberband ''Added 9/20/2019 td

            ''Rband = Rubberband 
            intRbandInDesignForm_Left = Me.LayoutFunctions.Layout_Margin_Left_Add(.Left)
            intRbandInDesignForm_Top = Me.LayoutFunctions.Layout_Margin_Top_Add(.Top)

            ''Added 9/20/2019 td
            obj_rectangleAdjusted =
                New Rectangle(intRbandInDesignForm_Left,
                              intRbandInDesignForm_Top,
                                     .Width, .Height)

        End With ''End of "With par_rubberband"

        With obj_rectangleAdjusted

            boolRubBandIsAll_AboveMe = ((.Top + .Height) < Me.Top)
            boolRubBandIsAll_BelowMe = ((Me.Top + Me.Height) < .Top)

            boolRubBandIsAll_LeftOfMe = (.Left + .Width < Me.Left)
            boolRubBandIsAll_RightOfMe = ((Me.Left + Me.Width) < .Left)

        End With ''End of " With par_rubberband"

        boolBandIsInsideMeHorizontally = (Not (boolRubBandIsAll_LeftOfMe Or boolRubBandIsAll_RightOfMe))
        boolBandIsInsideMeVertically = (Not (boolRubBandIsAll_AboveMe Or boolRubBandIsAll_BelowMe))

        boolBandIsInsideMe_BothWays = (boolBandIsInsideMeHorizontally And boolBandIsInsideMeVertically)
        boolBandOverlapsWithMe = boolBandIsInsideMe_BothWays

        If (boolBandOverlapsWithMe) Then
            Me.ElementClass_Obj.SelectedHighlighting = True
            Me.Refresh_Image(False)
        End If ''End of "If (boolBandOverlapsWithMe) Then"

    End Sub ''End of "Public Sub Highlight_IfInsideRubberband()"

    Private Sub RefreshElement_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        If (Me.Rotated_0degrees) Then
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height
        ElseIf (Me.Rotated_180_360) Then
            Me.ElementInfo_Base.Width_Pixels = Me.Width
            Me.ElementInfo_Base.Height_Pixels = Me.Height

        ElseIf (Me.Rotated_90_270) Then
            ''---DIFFICULT & CONFUSING---
            ''   It's rotated to 90 or 270 degrees, so let's 
            ''   pull a "switcheroo" on the Width & Height. 
            Me.ElementInfo_Base.Width_Pixels = Me.Height
            Me.ElementInfo_Base.Height_Pixels = Me.Width
        Else
            Throw New Exception("Logical error #42")
        End If ''ENd of "If (Me.Rotated_0degrees) Then ... ElseIf .... ElseIf ...."

        ''Added 9/5/2019 td 
        Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
        Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

        ''Added 9/4/2019 td
        ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
        Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

        Application.DoEvents()
        Me.Refresh_Image(True)
        Application.DoEvents()
        Me.Refresh()

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub GiveSizeInfo_Field(sender As Object, e As EventArgs)
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim strMessageToUser As String = ""

        strMessageToUser &= (vbCrLf & $"Height of Picture control: {pictureLabel.Height}")
        strMessageToUser &= (vbCrLf & $"Height of Custom Graphics control: {Me.Height}")
        strMessageToUser &= (vbCrLf & $"Element-Info Property (Height): {Me.ElementInfo_Base.Height_Pixels}")
        strMessageToUser &= (vbCrLf & $"Picture control's Image Height: {pictureLabel.Image.Height}")

        MessageBox.Show(strMessageToUser, "", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub ''End of "Private Sub RefreshElement_Field(sender As Object, e As EventArgs)"

    Private Sub CtlGraphicFldLabel_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ''
        ''Addd 7/31/2019 td
        ''
        ''9/4/2019 td''If (Me.ElementInfo_Text IsNot Nothing) Then
        If (Me.ElementInfo_Base IsNot Nothing) Then

            Const c_bAvoidAntiflowDesign As Boolean = True ''Avoid "BadDesign" / "bad design".  ---Added 9/23/2019 td

            If (c_bAvoidAntiflowDesign) Then
                ''
                ''The "Else" code (below) violates the "Fields-->Elements-->UserGraphicsControl-->Layout"
                ''   sequence, since it supports a "UserGraphicsControl-->Element" flow.   That 
                ''   flow (UserGraphicsControl-->Element) is maybe okay in some respects, !perhaps!, 
                ''   but probably not here.
                ''   -----9/23 td
                ''
            Else

                Me.ElementInfo_Base.Width_Pixels = Me.Width
                Me.ElementInfo_Base.Height_Pixels = Me.Height
                ''Me.RefreshImage()

                ''Added 9/5/2019 td 
                ''9/19/2019 td''Me.ElementInfo_Base.TopEdge_Pixels = Me.FormDesigner.Layout_Margin_Top_Omit(Me.Top)
                ''9/19/2019 td''Me.ElementInfo_Base.LeftEdge_Pixels = Me.FormDesigner.Layout_Margin_Left_Omit(Me.Left)

                Me.ElementInfo_Base.TopEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Top_Omit(Me.Top)
                Me.ElementInfo_Base.LeftEdge_Pixels = Me.LayoutFunctions.Layout_Margin_Left_Omit(Me.Left)

                ''Added 9/4/2019 td
                ''9/12/2019 td''Me.ElementInfo_Base.LayoutWidth_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''9/19/2019 td''Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.FormDesigner.Layout_Width_Pixels()
                ''9/19/2019 td''Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.FormDesigner.Layout_Height_Pixels()

                Me.ElementInfo_Base.BadgeLayout.Width_Pixels = Me.LayoutFunctions.Layout_Width_Pixels()
                Me.ElementInfo_Base.BadgeLayout.Height_Pixels = Me.LayoutFunctions.Layout_Height_Pixels()

            End If ''ENd of "If (c_boolAvoidAntidesignedCode) Then .... Else ..."

        End If ''End of "If (Me.ElementInfo_Base IsNot Nothing) Then"

    End Sub

    Private Sub pictureLabel_DragOver(sender As Object, e As DragEventArgs) Handles pictureLabel.DragOver

    End Sub

    Private Sub TextTypeExample_KeyPress(sender As Object, e As KeyPressEventArgs) ''9/10/2019 td''Handles textTypeExample.KeyPress
        ''
        ''Added 8/10/2019 td
        ''
        ''If (e.KeyChar = ) Then
        ''
        ''End If

    End Sub

    Private Sub TextTypeExample_KeyUp(sender As Object, e As KeyEventArgs) Handles textTypeExample.KeyDown

        ''Added 8/10/2019 thomas downes  
        If (e.KeyCode = Keys.Enter) Then

            Me.FieldInfo.ExampleValue = textTypeExample.Text
            Me.ElementInfo_Text.Text = textTypeExample.Text
            Me.textTypeExample.Visible = False

            ''Added 9/20/2019 td  
            Me.ElementInfo_Text.ExampleValue_ForElement = textTypeExample.Text
            Me.ElementClass_Obj.ExampleValue_ForElement = textTypeExample.Text ''Redundant command. 

            ''Added 9/10/2019 td
            Me.Refresh_Master()

            ''Added 9/20/2019 td
            Me.LayoutFunctions.AutoPreview_IfChecked()

        End If ''End If ''End of "If (e.KeyCode = Keys.Enter) Then"

    End Sub

    Private Sub LinkInvisible_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkInvisible.LinkClicked
        ''
        ''Added 9/19/2019 td  
        ''
        Dim intResult As DialogResult
        Dim bUserDesiresTo_Display As Boolean

        intResult = MessageBox.Show("Want this element to appear on the Badge?", "",
                  MessageBoxButtons.OK, MessageBoxIcon.Question)

        bUserDesiresTo_Display = (intResult = DialogResult.OK Or intResult = DialogResult.Yes)

        If (bUserDesiresTo_Display) Then

            ''Added 9/20/2019 td 
            ''   Add an alert to the user that the element is not rendered
            ''   on the Badge.  ----9/20/2019 td
            ''
            Me.ElementInfo_Base.Visible = True

            Dim bElementInvisibleOnBadge As Boolean
            bElementInvisibleOnBadge = False ''False, since invisible is the opposite of "Displayed". 
            LinkInvisible.Visible = bElementInvisibleOnBadge ''Hide the link-label, it's not needed anymore. 

        End If ''End of "If (bUserDesiresTo_Display) Then"

    End Sub
End Class
