''
''Added 8/29/2019 thomas downes 
''
Imports ciBadgeInterfaces ''Added 8/29/2019 thomas d.
Imports ciBadgeFields ''Added 9/18/2019 td 
Imports ciBadgeElements ''Added 9/18/2019 td 
Imports ciBadgeDesigner ''Added 10/3/2019 td   

Public Class DialogTextBorder ''Added 8/29/2019 thomas d.
    ''
    ''Added 8/29/2019 thomas downes 
    ''
    Public FieldInfo As ICIBFieldStandardOrCustom

    Public CtlGraphicFldLabel1 As CtlGraphicFieldV3 ''Added 7/19/2022
    Public CtlRSCMoveable1 As __RSCWindowsControlLibrary.RSCMoveableControlVB

    Private mod_bIsLoading As Boolean = True ''Added 7/21/2022 thomas downes  

    ''Added 8/17/2019 td  
    ''8/29 td''Public FontOffset_X As Integer
    ''8/29 td''Public FontOffset_Y As Integer
    ''8/29 td''Public FontSize As Integer
    ''8/29 td''Public Font_DrawingClass As Font ''Added 8/17/2019 td 
    ''8/29 td''Public TextAlignment As System.Windows.Forms.HorizontalAlignment ''Added 8/18/2019 td  

    ''Obselete.  9/18 td''Public Border_SizeInPixels As Integer ''Added 8/29/2019 td
    ''Obselete.  9/18 td''Public Border_Color As Drawing.Color ''Added 8/29/2019 td
    ''Obselete.  9/18 td''Public Border_Displayed As Boolean ''Added 9/9/2019 td  

    Public Property Border_SizeInPixels_NotInUse As Integer
        Get
            ''
            ''Obselete.  Instead, call this form's .UpdateInfo_ViaInterface method. 
            ''   ----9/18/2019 td 
            ''
            Return -1
        End Get
        Set(value As Integer)

        End Set
    End Property

    ''8/29/2019 td''Public ElementInfo As ciBadgeInterfaces.IElementText ''Added 8/16/2019 td

    ''12/31/2021 td''Public ElementCopy_Info_Text As ciBadgeInterfaces.IElement_TextField ''Added 8/16/2019 td
    Public ElementCopy_Info_TextField As ciBadgeInterfaces.IElement_TextField ''Added 8/16/2019 td
    Public ElementCopy_Info_TextOnly As ciBadgeInterfaces.IElement_TextOnly ''Added 12/31/2021 td
    Public ElementCopy_Info_Base As ciBadgeInterfaces.IElement_Base ''Added 8/16/2019 td
    ''Renamed ElementObject_Base 7/22/2022 ''Public Element_Base As ClassElementBase ''Added 7/19/2022 td

    Public ElementObject_ForLayout_NotUsed As ClassElementFieldV3 ''Added 9/18/2019 td
    ''2/4/2022 td''Public ElementObject_Copy As ClassElementFieldLbl ''Added 9/18/2019 td
    Public ElementObject_CopyV3 As ClassElementFieldV3 ''Added 9/18/2019 td
    Public ElementObject_CopyV4 As ClassElementFieldV4 ''Added 2/04/2022 td
    '' 7/22/2022 ''Public Element_Base As ClassElementBase ''Added 7/19/2022 td
    Public ElementObject_Base As ClassElementBase ''Renamed 7/22/2022 Added 7/19/2022 td

    Public GroupEdits As ISelectingElements ''Added 8/15/2019 thomas downes  

    ''9/19/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 8/15/2019 td  
    Public LayoutFunctions As ILayoutFunctions ''Added 9/19/2019 td  

    Public OriginalElementControlV3 As CtlGraphicFieldV3 ''Added 8/15/2019 td  
    Public OriginalElementControlV4 As CtlGraphicFieldV4 ''Added 2/04/2022 td  

    Public UserConfirmed As Boolean ''Added 9/18/2019 thomas d. 


    Public Sub New(par_element_fromLayout As ClassElementFieldV3, par_element_copy As ClassElementFieldV3)
        ''
        ''Added 9/18/2019 thomas d. 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''

        ''Just to be extra cautious, let's use a copy of the copy.   :-)  ----9/18/2019 td
        Me.ElementObject_CopyV3 = par_element_copy.Copy()

        ''9/18/2019 td''Me.ElementObject_ForLayout_NotUsed = par_element_fromLayout
        Me.ElementObject_ForLayout_NotUsed = Nothing ''9/18/2019 td''par_element_fromLayout

        ''Added 9/18/2019 td 
        Me.ElementCopy_Info_Base = CType(Me.ElementObject_CopyV3, IElement_Base)
        Me.ElementCopy_Info_TextField = CType(Me.ElementObject_CopyV3, IElement_TextField)

        ''Added 7/20/2022 td
        Me.CtlLeftRightBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
        Me.CtlLeftRightBorderWidth.ElementObject_Base = Me.ElementObject_Base ''renamed 7/22/2022

    End Sub ''ENd of "Public Sub New(par_element_fromLayout As ClassElementFieldV3, par_element_copy As ClassElementFieldV3)"


    Public Sub New(par_element_fromLayoutV4 As ClassElementFieldV4,
                   par_element_copyV4 As ClassElementFieldV4)
        ''
        ''Added 9/18/2019 thomas d. 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''

        ''Just to be extra cautious, let's use a copy of the copy.   :-)  ----9/18/2019 td
        ''Me.ElementObject_CopyV4 = par_element_copyV4.Copy()

        ''9/18/2019 td''Me.ElementObject_ForLayout_NotUsed = par_element_fromLayout
        Me.ElementObject_ForLayout_NotUsed = Nothing ''9/18/2019 td''par_element_fromLayout

        ''Added 9/18/2019 td 
        Me.ElementCopy_Info_Base = CType(Me.ElementObject_CopyV4, IElement_Base)
        Me.ElementCopy_Info_TextField = CType(Me.ElementObject_CopyV4, IElement_TextField)

    End Sub ''ENd of "Public Sub New(par_element_fromLayout As ClassElementField, par_element_copy As ClassElementField)"


    Public Sub New(par_control As __RSCWindowsControlLibrary.RSCMoveableControlVB,
                   par_elementBase As ClassElementFieldOrTextV4)
        ''
        ''Added 7/19/2022 & 2/04/2022 thomas d. 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''
        Me.CtlRSCMoveable1 = par_control
        Me.ElementCopy_Info_Base = CType(par_elementBase, IElement_Base)
        Me.ElementCopy_Info_TextField = CType(par_elementBase, IElement_TextField)
        Me.ElementObject_Base = par_elementBase ''Added 8/19/2022 thomas downes

    End Sub


    Public Sub New(par_control As __RSCWindowsControlLibrary.RSCMoveableControlVB,
                   par_elementBase As ClassElementBase)
        ''
        ''Added 7/19/2022 & 2/04/2022 thomas d. 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''
        ' Add any initialization after the InitializeComponent() call.
        ''
        Me.CtlRSCMoveable1 = par_control

        Try
            Me.ElementCopy_Info_Base = CType(par_elementBase, IElement_Base)
        Catch ex_ctype1 As Exception
            ''Added 7/22/2022 td 
            System.Diagnostics.Debugger.Break()
        End Try

        ''Added 7/22/2022 td 
        Try
            Me.ElementCopy_Info_TextField = CType(par_elementBase, IElement_TextField)
        Catch ex_ctype2 As Exception
            ''Added 7/22/2022 td 
            ''
            '' This exception will occur for Static-Text elements. ---7/22/2022 td
            ''
            ''System.Diagnostics.Debugger.Break()
        End Try

        ''7/22/2022 Me.Element_Base = par_elementBase
        Me.ElementObject_Base = par_elementBase

        Me.Controls.Add(Me.CtlRSCMoveable1)

        CenterTheFieldControl(Me.CtlRSCMoveable1)

        ''Added 7/22/2022 thomas downes
        If (Me.ElementObject_Base IsNot Nothing) Then
            chkBorderDisplayed.Checked = Me.ElementObject_Base.Border_bDisplayed
        ElseIf (Me.ElementCopy_Info_Base IsNot Nothing) Then
            chkBorderDisplayed.Checked = Me.ElementCopy_Info_Base.Border_Displayed
        End If ''|End of ""If (Me.ElementObject_Base IsNot Nothing) Then... ElseIf..."

        ''Added 9/13/2019 thomas downes
        Me.CtlLeftRightBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base

        ''Added 7/21/2022 thomas downes 
        Me.CtlLeftRightBorderWidth.ElementObject_Base = Me.ElementObject_Base

        ''Added 7/21/2022 thomas downes 
        Me.CtlLeftRightBorderWidth.LoadControls()

        ''Added 7/21/2022 thomas downes 
        With Me.CtlLeftRightBorderWidth.ElementObject_Base
            If (.Border_bColor = Drawing.Color.Empty) Then
                .Border_bColor = Drawing.Color.Black
            End If
        End With ''End of ""With Me.CtlLeftRightBorderWidth.ElementObject_Base""


    End Sub ''End of ""Public Sub New(...)"   


    Public Sub UpdateInfo_ViaInterface(par_elementInfo As IElement_Base, Optional par_overrideConfirmation As Boolean = False)
        ''
        ''This is perhaps like an "dependency injection" to "push" the 
        ''   new settings out to the the parent designer form.
        ''   ----9/18/2019 td 
        ''
        ''      ''added 9/17 td
        ''
        ''This allows the parental designer form to "grab" the new settings.  ---9/18/2019 td
        ''
        With par_elementInfo

            If (Me.UserConfirmed) Then

                ''9/18/2019 td''.Border_Color = Me.Border_Color
                ''9/18/2019 td''.Border_Displayed = Me.Border_Displayed
                ''9/18/2019 td''.Border_WidthInPixels = Me.Border_SizeInPixels

                .Border_Color = Me.ElementCopy_Info_Base.Border_Color
                .Border_Displayed = Me.ElementCopy_Info_Base.Border_Displayed
                .Border_WidthInPixels = Me.ElementCopy_Info_Base.Border_WidthInPixels

            ElseIf (Not par_overrideConfirmation) Then

                ''Added 9/18/2019 td 
                MessageBox.Show("Settings have not been confirmed.", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If ''End of "If (Me.UserConfirmed) Then .... ElseIf ... "
        End With

    End Sub ''Public Sub UpdateInfo_ViaInterface(par_elementInfo As IElement_Base)


    Public Sub LoadFieldAndFormV3(par_layoutFun As ILayoutFunctions,
                                par_originalCtlV3 As CtlGraphicFieldV3)

        ''
        ''Added 9/18/2019 td
        ''
        ''Denigrated. 9/19/2019 td''Me.FormDesigner = par_formDesigner
        Me.LayoutFunctions = par_layoutFun ''Added 9/19/2019 td  

        ''2/4/2022 td''Me.OriginalElementControl = par_originalCtl
        Me.OriginalElementControlV3 = par_originalCtlV3

        Me.CtlGraphicFldLabel1 = par_originalCtlV3 ''Added 7/19/2022

        ''7/19/2022 With CtlGraphicFldLabel1
        ''
        ''    ''5/11/2022 .FieldInfo = Me.ElementObject_CopyV3.FieldInfo
        ''    .FieldEnumValue = Me.ElementObject_CopyV3.FieldEnum
        ''    .FieldIsCustom = Me.ElementObject_CopyV3.FieldIsCustomizable
        ''    .ExampleTextToDisplay = Me.ElementObject_CopyV3.ExampleValue_ForElement
        ''
        ''    ''Added 1/5/2022 td
        ''    ''  Populate the handy interface references.
        ''    ''  
        ''    Me.ElementCopy_Info_Base = Me.ElementObject_CopyV3
        ''    Me.ElementCopy_Info_TextOnly = Me.ElementObject_CopyV3
        ''    Me.ElementCopy_Info_TextField = Me.ElementObject_CopyV3
        ''
        ''    ''Added 9/18/2019 td 
        ''    .ElementInfo_Base = Me.ElementCopy_Info_Base
        ''    ''12/31/2021 td''.ElementInfo_Text = Me.ElementCopy_Info_Text
        ''    .ElementInfo_TextOnly = Me.ElementCopy_Info_TextOnly
        ''    .ElementInfo_TextField = Me.ElementCopy_Info_TextField ''Added 12/31/2021 thomas downes
        ''
        ''    ''Denigrated. 9/19/2019 td''.FormDesigner = par_formDesigner
        ''    .LayoutFunctions = par_layoutFun ''Added 9/19/2019 td 
        ''
        ''    .Width = .ElementInfo_Base.Width_Pixels
        ''    .Height = .ElementInfo_Base.Height_Pixels
        ''
        ''    ''Jan5 2022 td''.Refresh_Image(True)
        ''    .Refresh_ImageV3(True, True, True, True, Me.ElementObject_CopyV3)
        ''
        ''End With ''End of "With CtlGraphicFldLabel1"

        ''Added 9/13/2019 thomas downes
        Me.CtlLeftRightBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base

        ''Added 7/21/2022 thomas downes 
        Me.CtlLeftRightBorderWidth.ElementObject_Base = Me.ElementObject_Base

        ''12/31/2021 ''Me.CtlBorderWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlLeftRightBorderWidth.ElementInfo_TextOnly = Me.ElementCopy_Info_TextOnly ''added 12/31/2021
        Me.CtlLeftRightBorderWidth.ElementInfo_TextField = Me.ElementCopy_Info_TextField ''added 12/31/2021

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

        ''Added 7/22/2022 thomas downes
        chkBorderDisplayed.Checked = Me.ElementCopy_Info_Base.Border_Displayed
        chkBorderDisplayed.Checked = Me.ElementObject_Base.Border_bDisplayed

    End Sub ''End of "Public Sub LoadFieldAndFormV3(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"


    Public Sub LoadFieldAndFormV4(par_layoutFun As ILayoutFunctions,
                                par_originalCtlV4 As CtlGraphicFieldV4)

        ''
        ''Added 2/04/2022 td
        ''
        ''Denigrated. 9/19/2019 td''Me.FormDesigner = par_formDesigner
        Me.LayoutFunctions = par_layoutFun ''Added 9/19/2019 td  
        ''2/4/2022 td ''Me.OriginalElementControl = par_originalCtl
        Me.OriginalElementControlV4 = par_originalCtlV4

        ''Added 7/16/2022 
        If (Me.ElementObject_CopyV4 Is Nothing) Then
            Me.ElementObject_CopyV4 =
                par_originalCtlV4.ElementClass_ObjV4.CopyToElementFieldV4()
            ''System.Diagnostics.Debugger.Break()
        End If ''End of ""If (Me.ElementObject_CopyV4 Is Nothing) Then""

        ''Added 7/22/2022 thomas downes
        chkBorderDisplayed.Checked = Me.ElementCopy_Info_Base.Border_Displayed
        chkBorderDisplayed.Checked = Me.ElementObject_Base.Border_bDisplayed

        ''7/17/2022 td''With CtlGraphicFldLabel1
        ''7/19/2022 With CtlGraphicFieldV41
        With CtlRSCMoveable1

            ''5/11/2022 td''.FieldInfo = Me.ElementObject_CopyV4.FieldInfo
            ''7/15/2022 td''.FieldEnumValue = Me.ElementObject_CopyV4.FieldEnum
            ''7/15/2022 td''.FieldIsCustom = Me.ElementObject_CopyV4.FieldIsCustomizable ''Added 5/11/2022 td

            ''Added 1/5/2022 td
            ''  Populate the handy interface references.
            ''  
            Me.ElementCopy_Info_Base = Me.ElementObject_CopyV4
            Me.ElementCopy_Info_TextOnly = Me.ElementObject_CopyV4
            Me.ElementCopy_Info_TextField = Me.ElementObject_CopyV4

            ''Added 9/18/2019 td 
            .ElementInfo_Base = Me.ElementCopy_Info_Base
            ''12/31/2021 td''.ElementInfo_Text = Me.ElementCopy_Info_Text
            ''7/15/2022 td''.ElementInfo_TextOnly = Me.ElementCopy_Info_TextOnly
            ''7/15/2022 td''.ElementInfo_TextField = Me.ElementCopy_Info_TextField ''Added 12/31/2021 thomas downes

            ''Denigrated. 9/19/2019 td''.FormDesigner = par_formDesigner
            .LayoutFunctions = par_layoutFun ''Added 9/19/2019 td 

            .Width = .ElementInfo_Base.Width_Pixels
            .Height = .ElementInfo_Base.Height_Pixels

            ''Jan5 2022 td''.Refresh_Image(True)
            ''Feb5 2022 td''.Refresh_ImageV3(True, True, True, True, Me.ElementObject_Copy)
            .Refresh_ImageV4(True, True, True, True, Me.ElementObject_CopyV4)

        End With ''End of "With CtlGraphicFldLabel1"

        ''Added 9/13/2019 thomas downes
        Me.CtlLeftRightBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
        ''12/31/2021 ''Me.CtlBorderWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
        Me.CtlLeftRightBorderWidth.ElementInfo_TextOnly = Me.ElementCopy_Info_TextOnly ''added 12/31/2021
        Me.CtlLeftRightBorderWidth.ElementInfo_TextField = Me.ElementCopy_Info_TextField ''added 12/31/2021

        ''Position it at the center horizontally. 
        CenterTheFieldControl()

    End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"



    ''--------9/19/2019 td----------------------------------------------------------------------------------------------
    ''Denigrated.  9/19/2019 td''Public Sub LoadFieldAndForm(par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''
    ''    ''
    ''    ''Added 9/18/2019 td
    ''    ''
    ''    Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl
    ''
    ''    With CtlGraphicFldLabel1
    ''
    ''        .FieldInfo = Me.ElementObject_Copy.FieldInfo
    ''
    ''        ''Added 9/18/2019 td 
    ''        .ElementInfo_Base = Me.ElementCopy_Info_Base
    ''        .ElementInfo_Text = Me.ElementCopy_Info_Text
    ''
    ''        .FormDesigner = par_formDesigner
    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .Refresh_Image(True)
    ''
    ''    End With ''End of "With CtlGraphicFldLabel1"
    ''
    ''    ''Added 9/13/2019 thomas downes
    ''    Me.CtlBorderWidth.ElementInfo_Base = Me.ElementCopy_Info_Base
    ''    Me.CtlBorderWidth.ElementInfo_Text = Me.ElementCopy_Info_Text
    ''
    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()
    ''
    ''End Sub ''End of "Public Sub LoadFieldAndForm(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''--------10/3/2019 td----------------------------------------------------------------------------------------------
    ''Public Sub LoadFieldAndForm_NotInUse(par_elementInfo_Base As IElement_Base,
    ''                            par_elementInfo_Text As IElement_TextField,
    ''                            par_fieldInfo As ICIBFieldStandardOrCustom,
    ''                            par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''    ''
    ''    ''Modelled after DialogTextOffset, 8/29/2019  
    ''    ''Modified on 8/29/2019 td
    ''    ''
    ''    Me.FieldInfo = par_fieldInfo

    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Base = par_elementInfo_Base ''Added 9/3/2019 td
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Text = par_elementInfo_Text ''Added 8/16 td

    ''    ''Added 8/17/2019 td
    ''    ''
    ''    ''8/29 td''Me.FontOffset_X = par_elementInfo.FontOffset_X
    ''    ''8/29 td''Me.FontOffset_Y = par_elementInfo.FontOffset_Y
    ''    ''8/29 td''Me.FontSize = par_elementInfo.FontSize
    ''    ''8/29 td''Me.Font_DrawingClass = par_elementInfo.Font_DrawingClass

    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_SizeInPixels = par_elementInfo_Base.Border_WidthInPixels
    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_Color = par_elementInfo_Base.Border_Color
    ''    ''Obselete/Not is use.---9/18/2019 td''Me.Border_Displayed = par_elementInfo_Base.Border_Displayed ''Added 9/9/2019 td 

    ''    ''Added 8/15/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl

    ''    With CtlGraphicFldLabel1

    ''        ''8/29/2019 td''.ElementBaseInfo = par_elementBaseInfo ''Added 8/29/2019 thomas downes
    ''        .ElementInfo_Base = par_elementInfo_Base ''Added 8/29/2019 thomas downes
    ''        .ElementInfo_Text = par_elementInfo_Text

    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels

    ''        .FieldInfo = par_fieldInfo
    ''        .LabelText()  ''par_elementInfo.Text)
    ''        ''Denigrated. ---9/19/2019 td''.FormDesigner = par_formDesigner
    ''        .Refresh_Image(True)

    ''    End With ''End of "With CtlGraphicFldLabel1"

    ''    ''Added 9/13/2019 thomas downes
    ''    Me.CtlBorderWidth.ElementInfo_Base = par_elementInfo_Base
    ''    Me.CtlBorderWidth.ElementInfo_Text = par_elementInfo_Text

    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''8/29 td''LabelNumberOffsetX.Text = String.Format(LabelNumberOffsetX.Tag.ToString, Me.FontOffset_X)
    ''    ''8/29 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_Y)
    ''    ''8/29 td''LabelFontSizeNum.Text = String.Format(LabelFontSizeNum.Tag.ToString, Me.FontSize)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''9/13/2019 td''LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''    ''Added 9/9/2019 thomas downes 
    ''    ''9/18/2019 td''chkBorderDisplayed.Checked = Me.Border_Displayed
    ''    chkBorderDisplayed.Checked = Me.ElementCopy_Info_Base.Border_Displayed

    ''End Sub ''End of "Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    ''Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo,
    ''                            par_originalCtl As CtlGraphicFldLabel)
    ''
    ''    Me.FieldInfo = par_field
    ''
    ''    ''9/3/2019 td''Me.ElementInfo_Text = par_field.ElementInfo
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
    ''    ''This procedure is obselete. ---9/18/2019 td''Me.ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)
    ''
    ''    ''Added 8/15/2019 td
    ''    ''Denigrated. ---9/19/2019 td''Me.FormDesigner = par_formDesigner
    ''    Me.OriginalElementControl = par_originalCtl
    ''
    ''    With CtlGraphicFldLabel1
    ''        .FieldInfo = par_field
    ''
    ''        ''9/3/2019 td''.ElementInfo_Text = par_field.ElementInfo
    ''        ''Deprecated.  9/18/2019 td''.ElementInfo_Text = CType(par_field.ElementFieldClass, IElement_TextField)
    ''        ''Deprecated.  9/18/2019 td''.ElementInfo_Base = CType(par_field.ElementFieldClass, IElement_Base)
    ''
    ''        ''Denigrated. ---9/19/2019 td''.FormDesigner = par_formDesigner
    ''        .Width = .ElementInfo_Base.Width_Pixels
    ''        .Height = .ElementInfo_Base.Height_Pixels
    ''        .Refresh_Image(True)
    ''
    ''    End With ''End of "With CtlGraphicFldLabel1"
    ''
    ''    ''Position it at the center horizontally. 
    ''    CenterTheFieldControl()
    ''
    ''End Sub ''End of "Public Sub LoadFieldAndForm_NotInUse(par_field As ClassFieldStandard, par_formDesigner As FormDesignProtoTwo)"

    Private Sub CenterTheFieldControl(Optional par_control As UserControl = Nothing)
        ''
        ''Position it at the center horizontally. 
        ''8/15/2019 td
        ''
        If (par_control IsNot Nothing) Then
            With par_control

                .Left = CInt((Me.Width - .Width) / 2)
                .Top = CInt((Me.Height - .Height) / 2)
                Exit Sub

            End With
        End If ''end of ""If (par_control IsNot Nothing) Then""


        If (CtlGraphicFldLabel1 IsNot Nothing) Then
            With CtlGraphicFldLabel1

                .Left = CInt((Me.Width - .Width) / 2)
                .Top = CInt((Me.Height - .Height) / 2)

            End With
        End If ''End of ""If (CtlGraphicFldLabel1 IsNot Nothing) Then""

        ''Added 7/19/2022 thomas downes
        If (CtlRSCMoveable1 IsNot Nothing) Then
            With CtlRSCMoveable1

                .Left = CInt((Me.Width - .Width) / 2)
                .Top = CInt((Me.Height - .Height) / 2)

            End With
        End If ''End of ""If (CtlRSCMoveable1 IsNot Nothing) Then""

    End Sub ''End of ""Private Sub CenterTheFieldControl()""


    ''Private Sub ButtonIncrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/16/2019 td
    ''    ''
    ''    ''8/29/2019 td''Me.FontOffset_X += 1
    ''    ''8/29/2019 td''Me.ElementInfo_Text.FontOffset_X += 1

    ''    Me.Border_SizeInPixels += 1
    ''    Me.ElementInfo_Base.Border_WidthInPixels += 1

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''   8/29/2019 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)
    ''    ''
    ''    LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''End Sub

    ''Private Sub ButtonDecrease_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 8/29/2019 td
    ''    ''
    ''    ''8/29/2019 td''Me.FontOffset_X -= 1
    ''    ''8/29/2019 td''Me.ElementInfo_Text.FontOffset_X -= 1

    ''    Me.Border_SizeInPixels -= 1
    ''    Me.ElementInfo_Base.Border_WidthInPixels -= 1

    ''    CtlGraphicFldLabel1.ElementInfo_Text = Me.ElementInfo_Text
    ''    CtlGraphicFldLabel1.Refresh_Image(True)

    ''    ''Added 8/17/2019 thomas downes 
    ''    ''  8/29/2019 td''LabelNumberOffsetY.Text = String.Format(LabelNumberOffsetY.Tag.ToString, Me.FontOffset_X)
    ''    ''
    ''    LabelBorderWidth.Text = String.Format(LabelBorderWidth.Tag.ToString, Me.Border_SizeInPixels)

    ''End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Me.UserConfirmed = True ''Added 9/18/2019 td
        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ChkBorderDisplayed_CheckedChanged(sender As Object, e As EventArgs) Handles chkBorderDisplayed.CheckedChanged

        Dim bDisplayBorder As Boolean ''Added 7/21/2022 td

        If (mod_bIsLoading) Then Exit Sub ''Added 7/21/2022 td

        ''Added 9/9/2019 thomas downes
        ''
        ''9/13/2019 td''ButtonDecrease.Enabled = chkBorderDisplayed.Checked
        ''9/13/2019 td''ButtonIncrease.Enabled = chkBorderDisplayed.Checked
        ''9/13/2019 td''LabelBorderWidth.Enabled = chkBorderDisplayed.Checked

        bDisplayBorder = chkBorderDisplayed.Checked ''Added 7/21/2022 thomas downes

        CtlLeftRightBorderWidth.Enabled = chkBorderDisplayed.Checked

        ''Added 7/21/2022 td
        If (Me.ElementObject_Base IsNot Nothing) Then
            Me.ElementObject_Base.Border_bDisplayed = bDisplayBorder
        Else
            Me.ElementCopy_Info_Base.Border_Displayed = bDisplayBorder
        End If ''End of ""If (Me.ElementObject_Base IsNot Nothing) Then.... Else...."

        ''7/21/2022 RaiseEvent EventUpdateRequest()
        CtlBorderWidth_EventUpdateRequest()

    End Sub


    Private Sub CtlBorderWidth_EventUpdateRequest() Handles CtlLeftRightBorderWidth.EventUpdateRequest
        ''
        ''Added 9/14/2019
        ''
        ''Added 9/13/2019 thomas downes
        ''
        ''7/17/2022----With Me.CtlGraphicFldLabel1
        ''7/15/2022 td''With Me.CtlGraphicFieldV41
        With Me.CtlRSCMoveable1

            ''---Me.CtlGraphicFldLabel1.Width = Me.ElementInfo_Base.Width_Pixels
            ''---Me.CtlGraphicFldLabel1.Height = Me.ElementInfo_Base.Height_Pixels
            ''7/15/2022 td''Me.CtlGraphicFieldV41.Refresh_ImageV3(True)
            .RefreshElementImage()

        End With ''End of ""With Me.CtlGraphicFieldV41""

    End Sub

    Private Sub DialogTextBorder_Load(sender As Object, e As EventArgs) Handles MyBase.Load



ExitHandler:
        ''Added 7/21/2022 thomas downes
        mod_bIsLoading = False ''We are done loading. 

    End Sub


End Class

