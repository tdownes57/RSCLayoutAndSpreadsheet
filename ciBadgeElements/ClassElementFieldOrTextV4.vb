Option Explicit On
Option Strict On
Option Infer Off

Imports System.Drawing ''Added 9/18/2019 td  
Imports System.Drawing.Text ''Added 
Imports System.Windows.Forms ''Added 9/18/2019 td 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports ciBadgeFields ''Added 9/18/2019 td  
Imports System.Xml.Serialization ''Added 9/24/2019 thomas d. 
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
''Imports ciBadgeInterfaces ''Added 11/16/2019 thomas d. 
Imports AutoMapper ''Added 11/17/2021 thomas d.
Imports ciBadgeSerialize ''Added 6/07/2022 thomas d. 
Imports System.Security
''
''Added 1/29/2022 thomas d.
''

<Serializable>
Public Class ClassElementFieldOrTextV4
    Inherits ClassElementBase
    Implements IElement_TextOnly ''Jan29 2022 td'', IElement_TextField
    ''9/4/2022 Implements IElement_Base
    ''
    ''Copy pasted 1/29/2022 using code started 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText
    ''
    ''-------------------------------------------------------------
    ''//
    ''// Auto-Mappers  
    ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
    ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
    ''//   https://docs.automapper.org/en/latest/Setup.html
    ''//
    ''
    ''
    ''Added 5/27/2022 td
    ''
    ''5/28/2022 Public Shadows Property ConditionalExpressionValue As String ''5/28/2022 Implements IElement_Base.ConditionalExpressionValue
    ''5/28/2022 Public Shadows Property ConditionalExpressionField As EnumCIBFields ''5/28/2022 Implements IElement_Base.ConditionalExpressionField
    ''5/28/2022 Public Shadows Property ConditionalExpressionInUse As Boolean ''5/28/2022 Implements IElement_Base.ConditionalExpressionInUse



    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_Pic As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElementPic, ClassElementFieldV3)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_TextField As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_TextField, ClassElementFieldV3)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_TextOnly As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_TextOnly, ClassElementFieldV3)())
    <Xml.Serialization.XmlIgnore>
    Private Shared _mapConfig_Base As MapperConfiguration = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElement_Base, ClassElementFieldV3)())

    ''Public Shared Property oRecipient As ClassRecipient ''Added 10/16/2019 td  
    ''''11/16/2019 td''Public Shared Property Recipient As ClassRecipient ''Added 10/16/2019 td  

    ''Private Shared mod_sharedRecipInfo As IRecipient ''Added 12/01/2019 thomas d.
    ''''---4/22/2020 td---Private Shared ms_lastFieldIndex As Integer ''Added 4/22/2020 thomas downes

    ''<Xml.Serialization.XmlIgnore>
    ''Public Shared Property iRecipientInfo As IRecipient ''Added 10/16/2019 td  
    ''    Get
    ''        Return mod_sharedRecipInfo ''Added 12/01/2019 thomas d.  
    ''    End Get
    ''    Set(value As IRecipient)
    ''        ''Added 12/01/2019 td
    ''        ''1-15-2020 td''mod_sharedRecipInfo = mod_sharedRecipInfo
    ''        mod_sharedRecipInfo = value ''1-15-2020 td'' mod_sharedRecipInfo

    ''        ''----DIFFICULT AND CONFUSING------
    ''        oRecipient = Nothing ''Don't allow an object older reference to interfere with determining Recipient-related data. 12/01/2019 td
    ''    End Set
    ''End Property

#Disable Warning CA1707 ''Warning, "Remove underscores."

    Public Shared Function GetMapperConfiguration_Pic() As AutoMapper.MapperConfiguration
        ''
        '' Added 11/17/2021 thomas downes
        ''
        ''//
        ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
        ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
        ''//   https://docs.automapper.org/en/latest/Setup.html
        ''//
        ''
        ''//Initialize the mapper
        ''[[Dim config As MapperConfiguration

        ''config = New MapperConfiguration(cfg => cfg.CreateMap(IElement_Base, IElementPic))
        ''config = New MapperConfiguration(Sub(cfg) cfg.CreateMap(IElementPic, IElement_Base))
        ''config = New MapperConfiguration()

        ''[[Dim actionX As Action(Of IMapperConfigurationExpression) = Sub(cfg) cfg.CreateMap(IElementPic, IElement_Base)
        ''[[Dim actionX As Action(Of IMapperConfigurationExpression) = Sub(cfg) cfg.CreateMap(Of ClassElementPic, ClassElementField)()
        ''___Dim config As MapperConfiguration
        ''___config = New MapperConfiguration(Sub(cfg) cfg.CreateMap(Of IElementPic, IElement_Base)())

        Return _mapConfig_Pic

    End Function ''End of ""

#Disable Warning CA1707 ''Warning "Remove underscores from member names."

    Public Property Text_StaticLine As String Implements IElement_TextOnly.Text_StaticLine ''E.g. "George Washington" for FullName. 
    Public Property Text_IsMultiLine As Boolean Implements IElement_TextOnly.Text_IsMultiLine ''Added 5/31/2022


    Private _ListOfLines As List(Of String) ''Added 12/31/2022 td
    Public ReadOnly Property Text_ListOfLines As List(Of String) ''12/31/2022 Implements IElement_TextOnly.Text_ListOfLines ''Added 5/31/2022
        Get
            ''Added 12/31/2022
            Return _ListOfLines
        End Get
    End Property


    Public Property Text_Formula As String Implements IElement_TextOnly.Text_Formula ''E.g. "{fstrFirstName} {fstrLastName}" for FullName. 
    Public Property Text_ExampleValue As String Implements IElement_TextOnly.Text_ExampleValue ''Added 5/31/2022


    Public Property Id_GUID As System.Guid  ''Added 9/30/2019 td 

    ''Shadows 12/12/2022''Public Property BadgeDisplayIndex As Integer ''9/4/2022 Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td 
    ''Shadows 12/12/2022''Public Property WhichSideOfCard As EnumWhichSideOfCard ''9/4/2022 Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    ''Shadows 12/12/2022''Public Property DateEdited As Date ''9/4/2022 Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    ''Shadows 12/12/2022''Public Property DateSaved As Date ''9/4/2022 Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

    ''Moved below, and underscore removed. 6/7/2022  <Xml.Serialization.XmlIgnore>
    ''Moved below, and underscore removed. 6/7/2022  Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextOnly.Font_DrawingClass

    ''Jan29 2022 td''Public Property ExampleValue_ForElement As String Implements IElement_TextField.ExampleValue_ForElement ''Added 8/14/2019 td 

    <XmlIgnore>
    Public Property FontColor As System.Drawing.Color Implements IElement_TextOnly.FontColor

    <XmlElement("FontColor")>
    Public Property FontColor_HTML As String
        ''Added 10/14/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.FontColor)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.FontColor = ColorTranslator.FromHtml(value)
        End Set
    End Property


    ''Added 8/12/2019 thomas downes  
    Public Property FontSize_Pixels As Single = 25 Implements IElement_TextOnly.FontSize_Pixels ''Added 8/12/2019 thomas downes  
    Public Property FontBold_Deprecated As Boolean Implements IElement_TextOnly.FontBold_Deprecated ''Added 8/12/2019 thomas downes  
    Public Property FontItalics_Deprecated As Boolean Implements IElement_TextOnly.FontItalics_Deprecated ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline_Deprecated As Boolean Implements IElement_TextOnly.FontUnderline_Deprecated ''Added 8/12/2019 thomas downes  
    ''Added 9/6/2019 thomas downes  
    Public Property FontFamilyName As String = "Times New Roman" Implements IElement_TextOnly.FontFamilyName ''Added 9/6/2019 thomas downes  

    ''Added 6/7/2022 td  
    Public Property FontMaxGalkin As ciBadgeSerialize.SerializableFontByMaxGalkin Implements IElement_TextOnly.FontMaxGalkin
    ''Redundant, not needed. 6/7/2022  Public Property Font_FamilyName As String Implements IElement_TextOnly.Font_FamilyName ''Added 6/07/2022 

    <Xml.Serialization.XmlIgnore>
    Public Property FontDrawingClass As System.Drawing.Font Implements IElement_TextOnly.FontDrawingClass
        ''6/7/2022 Public Property Font_DrawingClass As System.Drawing.Font Implements IElement_TextOnly.Font_DrawingClass
        Get
            ''Added 6/07/2022 td
            If (Me.FontMaxGalkin Is Nothing) Then Me.FontMaxGalkin = SerializableFontByMaxGalkin.DefaultFont
            Return Me.FontMaxGalkin.ToFont_AnyUnits()
        End Get

        Set(value As System.Drawing.Font)
            ''Added 6/07/2022 td
            Me.FontMaxGalkin = SerializableFontByMaxGalkin.FromFont(value)
        End Set

    End Property

    ''Added 8/15/2019 thomas downes  
    ''9/12/2019 td''Public Property FontSize_IsLocked As Boolean Implements IElement_Text.FontSize_IsLocked ''Added 8/15/2019 thomas downes  
    ''6/2/2022 Public Property FontSize_ScaleToElementRatio As Double Implements IElement_TextOnly.FontSize_ScaleToElementRatio ''Added 9/12/2019 thomas downes  
    ''6/2/2022 Public Property FontSize_ScaleToElementYesNo As Boolean = True Implements IElement_TextOnly.FontSize_ScaleToElementYesNo ''Added 9/12/2019 thomas downes  

    Public Property FontSize_AutoScaleToElementRatio As Double Implements IElement_TextOnly.FontSize_AutoScaleToElementRatio ''Added 9/12/2019 thomas downes  
    Public Property FontSize_AutoScaleToElementYesNo As Boolean = True Implements IElement_TextOnly.FontSize_AutoScaleToElementYesNo ''Added 9/12/2019 thomas downes  
    Public Property FontSize_AutoSizePromptUser As Boolean = True Implements IElement_TextOnly.FontSize_AutoSizePromptUser ''Added 6/02/2022 thomas downes  


    Public Property FontOffset_X As Integer Implements IElement_TextOnly.FontOffset_X ''Added 8/15/2019 thomas downes  
    Public Property FontOffset_Y As Integer Implements IElement_TextOnly.FontOffset_Y ''Added 8/15/2019 thomas downes  

    Public Property TextAlignment As System.Windows.Forms.HorizontalAlignment Implements IElement_TextOnly.TextAlignment

    ''See Interface IElement_Base. ---8/29/2019 td''Public Property BackColor As System.Drawing.Color Implements IElement_Text.BackColor

    ''This is stored in FieldInfo.--9/18/2019 td''Public Property FieldInCardData As String Implements IElement_TextOnly.FieldInCardData

    ''This is stored in FieldInfo.--9/18/2019 td''Public Property FieldLabelCaption As String Implements IElement_TextOnly.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019

    ''
    ''See also, "Public Function LabelText(par_isForLayoutPreview As Boolean) As String".  ---10/16/2019 td 
    ''
    ''Public Property Text_Static As String Implements IElement_TextOnly.Text_Static ''E.g. "George Washington" for FullName. 
    ''Public Property Text_Formula As String Implements IElement_TextOnly.Text_Formula ''E.g. "{fstrFirstName} {fstrLastName}" for FullName. 

    ''''--16----Replaced by a Shared Property of the same name.---10/16/2019 td
    ''''--16--10/16/2019 td''Added 9/10/2019 td     <Xml.Serialization.XmlIgnore>
    ''''--16--10/16/2019 td''<Xml.Serialization.XmlIgnore>
    ''''--16--10/16/2019 td''Public Property Recipient As IRecipient Implements IElement_TextField.Recipient

    ''''Added 9/18/2019
    ''Public Property FieldObjectAny As ClassFieldAny ''Added 9/18/2019 td
    ''Public Property FieldObjectCustom As ClassFieldCustomized ''Added 12/13/2021 td
    ''Public Property FieldObjectStandard As ClassFieldStandard ''Added 12/13/2021 td

    ''''Added 10/12/2019 thomas downes
    ''Public Property FieldEnum As EnumCIBFields Implements IElement_TextField.FieldEnum

    ''''Added 9/17/2019 td 
    ''<Xml.Serialization.XmlIgnore>
    ''Public Property FieldInfo As ICIBFieldStandardOrCustom Implements IElement_TextField.FieldInfo

    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    ''Shadows 12/12/2022''Public Property PositionalMode As String ''9/4/2022 Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    ''Shadows 12/12/2022''Public Property OrientationToLayout As String ''9/4/2022 Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    ''Shadows 12/12/2022''Public Property OrientationInDegrees As Integer ''9/4/2022 Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    ''Shadows 12/12/2022''<Xml.Serialization.XmlIgnore>
    ''Shadows 12/12/2022''Public Property Image_BL As Image ''9/4/2022 Implements IElement_Base.Image_BL ''Added 8/27/2019 td

    ''Moved below. 8/27/2019 td''Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    ''Shadows 12/12/2022''<Xml.Serialization.XmlIgnore>
    ''Shadows 12/12/2022''Public Property FormControl As Control ''9/4/2022 Implements IElement_Base.FormControl ''Added 7/19/2019  

    ''Shadows 12/12/2022''Public Property ElementType As String = "Text" ''9/4/2022 Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayout As BadgeLayoutDimensionsClass ''9/4/2022 Implements IElement_Base.BadgeLayout ''Added 9/11/2019 td  

    ''9/4/2022 ''Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    ''9/4/2022 ''Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels


    ''9/23/20198 td''Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    ''9/23/20198 td''Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels


    ''9/5/2022 Private mod_width_pixels As Integer = 253 ''Added 9/23/2019 td 
    ''9/5/2022 Public Property Width_Pixels As Integer ''9/4/2022 Implements IElement_Base.Width_Pixels
    ''    Get
    ''        Return mod_width_pixels
    ''    End Get
    ''    Set(value As Integer)

    ''        mod_width_pixels = value

    ''        ''
    ''        ''Are we initializing Height & Width?   
    ''        ''
    ''        Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
    ''        Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
    ''        intOtherPropertyValue = mod_height_pixels
    ''        boolLikelyInitializing = (0 = intOtherPropertyValue)
    ''        If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

    ''        ''
    ''        ''Inform software developer of programming which violates design expectations.
    ''        ''
    ''        Dim boolTallerThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim boolMultiLineText As Boolean ''Added 6/10/2022 thomas downe

    ''        ''Added 9/23/2019 thomas downes
    ''        boolMultiLineText = Text_IsMultiLine ''Added 6/10/2022
    ''        boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
    ''        boolGiveDisallowedMsg = boolTallerThanWidth
    ''        If (boolMultiLineText) Then
    ''            ''
    ''            ''With multiline text, you can't expect that width > height. ---6/10/2022
    ''            ''
    ''        ElseIf (boolGiveDisallowedMsg) Then
    ''            ''6/6/2022 Throw New Exception("The Height cannot exceed the width #1 (rotation is _not_ an exception to this).")
    ''            System.Diagnostics.Debugger.Break()
    ''        End If ''End of "If (boolMultiLineText) Then.... ElseIf (boolGiveDisallowedMsg) Then"

    ''        ''Added 9/23/2019 td
    ''        Const c_False_RegardlessOfRotation As Boolean = False
    ''        ''June10 2022 CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels,
    ''        ''                                      c_False_RegardlessOfRotation)
    ''        CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels,
    ''                                  c_False_RegardlessOfRotation,
    ''                                    Text_IsMultiLine)

    ''    End Set
    ''End Property


    ''9/5/2022 Private mod_height_pixels As Integer = 33 ''Added 9/23/2019 td 
    ''9/5/2022 Public Property Height_Pixels As Integer ''9/4/2022 Implements IElement_Base.Height_Pixels
    ''    Get
    ''        Return mod_height_pixels
    ''    End Get
    ''    Set(value As Integer)

    ''        mod_height_pixels = value

    ''        ''
    ''        ''Are we initializing Height & Width?   
    ''        ''
    ''        Dim boolLikelyInitializing As Boolean ''Added 9/23/2019 thomas d. 
    ''        Dim intOtherPropertyValue As Integer ''Added 9/23/2019 thomas d. 
    ''        intOtherPropertyValue = mod_width_pixels
    ''        boolLikelyInitializing = (0 = intOtherPropertyValue)
    ''        If (boolLikelyInitializing) Then Exit Property ''Added 9/23/2019 td 

    ''        ''
    ''        ''Inform software developer of programming which violates design expectations.
    ''        ''
    ''        Dim boolTallerThanWidth As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim boolGiveDisallowedMsg As Boolean ''Added 9/23/2019 thomas downes
    ''        Dim boolTextMultiline As Boolean ''Added 6/10/2022 thomas downes

    ''        boolTextMultiline = Text_IsMultiLine ''Added 6/10/2022 thomas downes

    ''        ''Added 9/23/2019 thomas downes
    ''        boolTallerThanWidth = (mod_height_pixels > mod_width_pixels)
    ''        boolGiveDisallowedMsg = boolTallerThanWidth

    ''        If (boolTextMultiline) Then
    ''            ''
    ''            ''For multiline text, it doesn't make sense to try & enforce a width > height 
    ''            ''  rule. ---6/10/2022 
    ''            ''Added 6/10/2022 thomas d.
    ''            ''
    ''        ElseIf (boolGiveDisallowedMsg) Then
    ''            ''2/2/2022 td''Throw New Exception("The Height cannot exceed the width #2 (rotation is _not_ an exception to this).")
    ''            ''6/6/2022 td''Throw New Exception("Programmer needs to check for Rotation-by-90, & then switch Height & Width " &
    ''            ''                    "whenever a Resize occurs.  The Height cannot exceed the width. " &
    ''            ''                    "By a line of programming to switch Height & Width, a rotated element " &
    ''            ''                    "can easily abide by this rule.")
    ''            System.Diagnostics.Debugger.Break()

    ''        End If ''End of "If (boolGiveDisallowedMsg) Then"

    ''        ''Added 9/23/2019 td
    ''        Const c_False_RegardlessOfRotation As Boolean = False
    ''        ''6/10/2022 CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels,
    ''        ''                                     c_False_RegardlessOfRotation)
    ''        CheckWidthVsLength_OfText(mod_width_pixels, mod_height_pixels,
    ''                                  c_False_RegardlessOfRotation,
    ''                                   Text_IsMultiLine)

    ''    End Set
    ''End Property


    Public Function Width_Pixels_MoveableDivImage(Optional psingleScaling As Single = 1.0) As Integer
        ''Added 12/11/2021 
        Return Width_Pixels_Step2TextHandler(psingleScaling)

    End Function

    Public Function Width_Pixels_Step2TextHandler(Optional psingleScaling As Single = 1.0) As Integer
        ''
        ''Added 12/10/2021 Thomas Downes  
        ''
        Select Case (Me.OrientationInDegrees)
            Case 90, 270

                ''Switch the values of Width & Height, so that the
                ''   website's BadgeLayoutDesigner / Step2TextHandler
                ''   can show the element in its proper sizing. 
                ''   ---12/10/2021 td   
                ''Dec.10 2021 ''Return mod_width_pixels 
                ''Dec.11 2021 ''Return mod_height_pixels
                ''9/5/2022 td''Return CInt(CSng(mod_height_pixels) * psingleScaling)
                Return CInt(CSng(Me.Height_Pixels) * psingleScaling)

            Case Else '' Case 0, 180, 360

                ''Dec.11 2021 ''Return mod_width_pixels 
                ''9/5/2022 td''Return CInt(CSng(mod_width_pixels) * psingleScaling)
                Return CInt(CSng(Me.Width_Pixels) * psingleScaling)

        End Select

    End Function ''End of "Public Function Width_Pixels_Step2TextHandler"


    Public Function Height_Pixels_MoveableDivImage(Optional psingleScaling As Single = 1.0) As Integer
        ''Added 12/11/2021 
        Return Height_Pixels_Step2TextHandler(psingleScaling)
    End Function


    Public Function Height_Pixels_Step2TextHandler(Optional psingleScaling As Single = 1.0) As Integer
        ''
        ''Added 12/10/2021 Thomas Downes  
        ''
        Dim blIsRotatedSoSwitchWH As Boolean ''Added 12/11/2021 

        blIsRotatedSoSwitchWH = IsRotated_SwitchWidthHeight() ''Added 12/11/2021 

        Select Case blIsRotatedSoSwitchWH ''RotatedSwitch_WidthHeight() ''(Me.OrientationInDegrees)

            Case True '' 90, 270

                ''Switch the values of Width & Height, so that the
                ''   website's BadgeLayoutDesigner / Step2TextHandler
                ''   can show the element in its proper sizing. 
                ''   ---12/10/2021 td   
                ''Dec.10 2021 ''Return mod_height_pixels 
                ''Dec.11 2021 ''Return mod_width_pixels
                ''9/05/2022 Return CInt(CSng(mod_width_pixels) * psingleScaling)
                Return CInt(CSng(Me.Width_Pixels) * psingleScaling)

            Case Else '' Case 0, 180, 360

                ''Dec.11 2021 ''Return mod_height_pixels
                ''9/05/2022 Return CInt(CSng(mod_height_pixels) * psingleScaling)
                Return CInt(CSng(Me.Height_Pixels) * psingleScaling)

        End Select ''End of "Select Case RotatedSwitch_WidthHeight()"

        ''Select Case (Me.OrientationInDegrees)
        ''    Case 90, 270
        ''
        ''        ''Switch the values of Width & Height, so that the
        ''        ''   website's BadgeLayoutDesigner / Step2TextHandler
        ''        ''   can show the element in its proper sizing. 
        ''        ''   ---12/10/2021 td   
        ''        ''Dec.10 2021 ''Return mod_height_pixels 
        ''        Return mod_width_pixels
        ''
        ''    Case Else '' Case 0, 180, 360
        ''
        ''        Return mod_height_pixels
        ''
        ''End Select

    End Function ''End of "Public Function Height_Pixels_Step2TextHandler"


    Public Function IsRotated_SwitchWidthHeight() As Boolean
        ''---Dec11 2021---Public Function RotatedSwitch_WidthHeight() As Boolean
        ''
        ''Added 12/10/2021 Thomas Downes  
        ''
        Select Case (Me.OrientationInDegrees)
            Case 90, 270

                ''Switch the values of Width & Height, so that the
                ''   website's BadgeLayoutDesigner / Step2TextHandler
                ''   can show the element in its proper sizing. 
                ''   ---12/10/2021 td   
                ''Dec.10 2021 ''Return mod_height_pixels 
                ''Dec.10 2021 ''Return mod_width_pixels
                Return True

            Case Else '' Case 0, 180, 360

                ''----Return mod_height_pixels
                Return False

        End Select ''End of "Select Case (Me.OrientationInDegrees)"

    End Function ''End of "Public Function RotatedSwitch_WidthHeight"


#Disable Warning CA1707 '' "No underscores in names!"

    ''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    ''Shadows 12/12/2022''Public Property Border_WidthInPixels As Integer = 1 ''9/4/2022 Implements IElement_Base.Border_WidthInPixels

    ''Shadows 12/12/2022''<XmlIgnore>
    ''Shadows 12/12/2022''Public Property Border_Color As System.Drawing.Color = Color.Black ''9/4/2022 Implements IElement_Base.Border_Color
    ''Shadows 12/12/2022''Public Property Border_Displayed As Boolean = True ''9/4/2022 Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

    ''Shadows 12/12/2022''<XmlElement("Border_Color")>
    Public Property Border_Color_HTML_NotUsed As String
        ''Added 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Border_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Border_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property

    ''Shadows the base. 12/12/2022 ''<XmlIgnore>
    ''Shadows the base. 12/12/2022 ''Public Property Back_Color As System.Drawing.Color = Color.White ''9/4/2022 Implements IElement_Base.Back_Color
    ''Shadows the base. 12/12/2022 ''Public Property Back_Transparent As Boolean = False ''9/4/2022 Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
    ''    [XmlElement("ClrGrid")]
    ''Public String ClrGridHtml
    ''{
    ''    Get { Return ColorTranslator.ToHtml(clrGrid); }
    ''    Set { ClrGrid = ColorTranslator.FromHtml(value); }
    ''}

    ''Shadows the base. 12/12/2022 ''<XmlElement("Back_Color")>
    Public Property Back_Color_HTML_NotUsed As String
        ''Added 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Back_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Back_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property

    ''Shadows the base. 12/12/2022 ''Public Property SelectedHighlighting As Boolean ''9/4/2022 Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  

    ''Shadows the base. 12/12/2022 ''Public Property Visible As Boolean = True ''9/4/2022 Implements IElement_Base.Visible ''Added 9/19/2019 td  

    Public Property DatetimeUpdated As DateTime = DateTime.MinValue ''Added 11/29/2021 thomas downes
    Public Property CaptionSuffixIfNeeded As String = "" ''Added 12/21/2021 thomas downes

    ''Shadows the base. 12/12/2022 ''Public Property ZOrder As Integer ''9/4/2022 Implements IElement_Base.ZOrder
    ''  Get
    ''    Return 0 ''Throw New NotImplementedException()
    ''  End Get
    ''  Set(value As Integer)
    ''    Return ''---Throw New NotImplementedException()
    ''  End Set
    ''End Property

    ''9/18/2019 td''Private _labelToImage As New ClassLabelToImage ''Added 9/3/2019 td  
    ''Moved up. 9/30/2019 td''Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


    Public Sub New(par_fieldInfo As ICIBFieldStandardOrCustom,
                   par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''9/17 td''Public Sub New(par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''
        ''Added 9/15/2019 td
        ''
        ''Me.FieldInfo = par_fieldInfo ''Added 9/17/2019 td 
        ''Me.FieldEnum = par_fieldInfo.FieldEnumValue ''Added 10/12/2019 thomas d. 

        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

        ''9/4/2022 Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.LeftEdge_Pixels = par_intLeft_Pixels
        ''9/4/2022 Me.TopEdge_Pixels = par_intTop_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels

        Me.Height_Pixels = par_intHeight_Pixels

        ''---''Added 4/22/2020 thomas downes
        ''---Me.FieldIndex`

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

    End Sub


    ''Public Sub LoadFieldAny(parFieldAny As ClassFieldAny)
    ''    ''
    ''    ''Added 12/13/2021 Thomas Downes  
    ''    ''
    ''    Me.FieldInfo = CType(parFieldAny, ICIBFieldStandardOrCustom) ''par_fieldAny
    ''    Me.FieldObjectAny = parFieldAny
    ''    Me.FieldEnum = parFieldAny.FieldEnumValue ''ADded 12/13/2021 td

    ''    ''Added 12/13/2021 thomas downes
    ''    If (TypeOf parFieldAny Is ClassFieldCustomized) Then

    ''        Me.FieldObjectCustom = CType(parFieldAny, ClassFieldCustomized) ''Added 12/13/2021 td

    ''    ElseIf (TypeOf parFieldAny Is ClassFieldStandard) Then

    ''        Me.FieldObjectStandard = CType(parFieldAny, ClassFieldStandard) ''Added 12/13/2021 td

    ''    End If

    ''End Sub ''End of "Public Sub LoadFieldAny(par_fieldAny As ClassFieldAny)"


    ''Public Function ElementIndexIsFieldIndex() As Integer
    ''    ''//
    ''    ''// Added 11/18/2021 td 
    ''    ''//
    ''    Return FieldInfo.FieldIndex

    ''End Function ''End of Public Function ElementIndexIsFieldIndex 



    ''Public Function FieldNm_CaptionText() As String
    ''    ''//Added 11/10/2021 thomas downes
    ''    Return (FieldInfo.CIBadgeField & "/" & FieldInfo.DataEntryText)
    ''End Function


    ''Public Function IsDisplayedOnBadge_Visibly() As Boolean
    ''    ''
    ''    ''Added 1/8/2022 thomas downes
    ''    ''
    ''    ''Jan23 2022 td'' Dim structWhyOmit As New WhyOmitted
    ''    Dim structWhyOmitV1 As New WhyOmitted_StructV1
    ''    Dim structWhyOmitV2 As New WhyOmitted_StructV2

    ''    ''1/24/2022 td''Return IsDisplayedOnBadge_Visibly(structWhyOmit)
    ''    Return IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)

    ''End Function ''End of "Public Function IsDisplayedOnBadge_Visibly"


    ''Public Function IsDisplayedOnBadge_Visibly(ByRef par_whyOmitV1 As WhyOmitted_StructV1,
    ''                                           ByRef par_whyOmitV2 As WhyOmitted_StructV2) As Boolean
    ''    ''----Public Function IsDisplayedOnBadge_Visibly() As Boolean
    ''    ''
    ''    ''Added 9/19/2019 td  
    ''    ''
    ''    Dim bIncludedAndVisible As Boolean ''Added 1/24/2022 td
    ''    Dim bRelevantToPersonality As Boolean ''Added 1/24/2022 td

    ''    par_whyOmitV1.NotRelevantField = (Not Me.FieldInfo.IsRelevantToPersonality) ''Added 11/24/2021 
    ''    par_whyOmitV1.OmitElement = (Not Me.Visible) ''Added 11/10/2021 td
    ''    par_whyOmitV1.ElementVisibleIsFalse = (Not Me.Visible) ''Added 12/6/2021 thomas d. 
    ''    par_whyOmitV1.OmitField = (Not Me.FieldInfo.IsDisplayedOnBadge) ''Added 11/10/20121 td  

    ''    ''Added 1/23/2022 td
    ''    With Me.FieldInfo

    ''        bIncludedAndVisible = (.IsDisplayedOnBadge And Me.Visible) ''Added 1/24/2022 td
    ''        If (bIncludedAndVisible) Then
    ''            bRelevantToPersonality = .IsRelevantToPersonality
    ''            bIncludedAndVisible = (.IsRelevantToPersonality And .IsDisplayedOnBadge And Me.Visible)
    ''            bIncludedAndVisible = ((.IsRelevantToPersonality And .IsDisplayedOnBadge) And
    ''                      (Me.Visible And Me.Width_Pixels <> 0 And Me.Height_Pixels <> 0))
    ''        End If ''End of "If (bIncludedAndVisible) Then"

    ''        par_whyOmitV2.OmitIrrelevantField = (Not .IsRelevantToPersonality)
    ''        par_whyOmitV2.OmitInvisibleElement = (Not Me.Visible)
    ''        par_whyOmitV2.OmitUnbadgedField = (Not .IsDisplayedOnBadge)
    ''        par_whyOmitV2.OmitZeroHeight = (Me.Height_Pixels = 0)
    ''        par_whyOmitV2.OmitZeroWidth = (Me.Width_Pixels = 0)

    ''        ''Enumerated values
    ''        If (Not .IsRelevantToPersonality) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.IrrelevantField
    ''        If (Not Me.Visible) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.InvisibleElement
    ''        If (Not .IsDisplayedOnBadge) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.UnbadgedField
    ''        If (Me.Height_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroHeight
    ''        If (Me.Width_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroWidth

    ''        ''Current date-time.
    ''        ''----Not sure if we need to set the date here.
    ''        ''--If (Not bIncludedAndVisible) Then par_whyOmitV2.SetDateTime()

    ''    End With ''End of "With Me.FieldInfo"

    ''    ''Jan24 2022 td''Return (Me.FieldInfo.IsDisplayedOnBadge And Me.Visible)
    ''    Return (bIncludedAndVisible)

    ''End Function ''End of "Public Function IsDisplayedOnBadge_Visibly() As Boolean"

    ''8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
    ''    ''
    ''    ''Added 8/14/2019 thomas downes 
    ''    ''
    ''    Dim obj_image As Image = Nothing
    ''
    ''    ''8/15/2019 td''GenerateImage(obj_image, Me, Me)
    ''    GenerateImage(pintLayoutHeight, obj_image, Me, Me)
    ''
    ''    Return obj_image
    ''
    ''End of 8/26 td''End Function ''End of "Public Function GenerateImage() As Image Implements IElementText.GenerateImage"

    Public Function GenerateImage_ByDesiredLayoutWidth_Deprecated(pintDesiredLayoutWidth As Integer) As Image _
        Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutWidth
        ''
        ''    8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
        ''
        ''Added 8/14/2019 thomas downes 
        ''
        Dim obj_image As Image = Nothing

        ''8/15/2019 td''GenerateImage(obj_image, Me, Me)
        ''8/26/2019 td''GenerateImage(pintLayoutHeight, obj_image, Me, Me)

        ''9/3/2019 td''GenerateImage(pintDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(pintDesiredLayoutWidth, obj_image, Me, Me, False)

        Try
            ''
            ''Major call !!
            ''
            ''9/16/2019 td''obj_image = _labelToImage.TextImage(pintDesiredLayoutWidth, Me, Me, False, False)
            ''Deprecated.  9/18/2019 td''obj_image = _labelToImage.TextImage_Field(pintDesiredLayoutWidth, Me, Me, False, False)

        Catch ex As Exception
            ''Added 9/15/2019 td  
            MessageBox.Show(ex.Message, "90022", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth_Deprecated() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"


    Public Function GenerateImage_ByDesiredLayoutHeight_Deprecated(pintDesiredLayoutHeight As Integer) As Image _
        Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutHeight
        ''
        ''Added 8/26/2019 thomas downes 
        ''
        ''   This assumes the Badge is currently being displayed in Landscape mode, like so: 
        ''
        ''    ----------------------------
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    |                          |
        ''    ----------------------------   
        ''
        ''
        Dim obj_image As Image = Nothing
        Dim intDesiredLayoutWidth As Integer
        Dim doubleCorrectRatioW_to_H As Double = 0 ''Added 9/4/2019 td

        ''Added 9/4/2019 td
        ''9/18/2019 td''doubleCorrectRatioW_to_H = ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio()

        ''9/4 td''intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * ciLayoutPrintLib.LayoutPrint.LongSideToShortRatio())

        intDesiredLayoutWidth = CInt(pintDesiredLayoutHeight * doubleCorrectRatioW_to_H)

        ''9/3/2019 td''GenerateImage(intDesiredLayoutWidth, obj_image, Me, Me)
        ''9/4/2019 td''_labelToImage.TextImage(intDesiredLayoutWidth, obj_image, Me, Me, False)

        ''9/16/2019 td''obj_image = _labelToImage.TextImage(intDesiredLayoutWidth, Me, Me, False, False)
        ''Deprecated. 9/18/2019td''obj_image = _labelToImage.TextImage_Field(intDesiredLayoutWidth, Me, Me, False, False)

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutHeight_Deprecated() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"


    Public Overrides Function ImageForBadgeImage(par_scaleW As Single,
                                    par_scaleH As Single,
                     Optional ByRef par_recipient As IRecipient = Nothing,
                     Optional ByVal par_enumField As EnumCIBFields = EnumCIBFields.Undetermined,
                     Optional ByRef par_text As String = "",
                     Optional ByRef par_image As Image = Nothing) As Image

        ''This function is inspired/prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023 thomas clifton downes
        ''
        ''03/2022  Public Function GenerateImage_NotInUse
        ''03/2023  pdoubleScalingH As Double,
        ''03/2023  
        ''03/2023  ByRef par_image As Image,
        ''03/2023  par_elementInfo_Text As IElement_TextOnly,
        ''03/2023  par_elementInfo_Base As IElement_Base) As Image
        ''
        ''Added 8/14 & 7/17/2019 thomas downes
        ''
        ''Retired in favor of ClassLabelToImage.TextImage(), on 9/3/2019 td  
        ''
        Dim gr_local_image_of_element As Graphics ''= Graphics.FromImage(img)
        Dim pen_backcolor As Pen
        Dim pen_highlighting As Pen ''Added 8/2/2019 thomas downes  
        Dim pen_border As Pen ''Added 9/3/2019 thomas downes  
        Dim brush_forecolor As Brush
        Dim brush_backcolor As Brush ''Added 8/28/2019 td
        Dim doubleW_div_H As Double ''Added 8/15/2019 td  
        ''3/12/2022 Dim doubleScaling As Double ''Added 8/15/2019 td  
        Dim intNewElementWidth As Integer ''Added 8/15 
        Dim intNewElementHeight As Integer ''Added 8/15
        Dim strTextForElement As String = "" ''Added 3/15/2023

        ''3/15/2023 Application.DoEvents()

        ''Added 3/16/2023 td
        Dim bParFieldGiven As Boolean ''Added 3/16/2023 td
        Dim bParFieldUnknown As Boolean ''Added 3/16/2023 td

        ''Added 3/16/2023 td
        bParFieldGiven = (par_enumField <> EnumCIBFields.Undetermined)
        bParFieldUnknown = (par_enumField = EnumCIBFields.Undetermined)

        If (bParFieldUnknown) Then
            strTextForElement = par_text
        ElseIf (par_text <> "") Then
            strTextForElement = par_text
        ElseIf (bParFieldUnknown Or par_recipient Is Nothing) Then
            ''Added 3/16/2023 thomas downes 
            strTextForElement = par_text ''par_recipient.GetTextValue(Me.field)
        ElseIf (bParFieldGiven And par_recipient IsNot Nothing) Then
            ''Added 3/16/2023 thomas downes 
            strTextForElement = par_recipient.GetTextValue(par_enumField)
        End If ''End of ""If (par_enumField = EnumCIBFields.Undetermined) Then ... ElseIf ... Else ...""

        ''Added 3/16/2023 td
        If ("" = strTextForElement) Then
            strTextForElement = "[undetermined]"
        End If ''End of ""If ("" = strTextForElement) Then""

        ''Added 8/15/2019 td
        doubleW_div_H = (Me.Width_Pixels / Me.Height_Pixels)
        ''8/24 td''doubleScaling = (pintFinalLayoutWidth / par_element.LayoutWidth_Pixels)
        ''3/12/2022 doubleScaling = (pintDesiredLayoutWidth / Me.Width_Pixels)

        If (par_image Is Nothing) Then
            ''Create the image from scratch, if needed. 
            ''7/29 td''par_image = New Bitmap(par_element.Width_Pixels, par_element.Height_Pixels)

            ''Added 8/15/2019 td
            ''3/12/2022 intNewElementWidth = CInt(doubleScaling * par_elementInfo_Base.Width_Pixels)
            ''3/12/2022 intNewElementHeight = CInt(doubleScaling * par_elementInfo_Base.Height_Pixels)
            intNewElementWidth = CInt(par_scaleW * Me.Width_Pixels)
            intNewElementHeight = CInt(par_scaleH * Me.Height_Pixels)

            ''Added 8/15/2019 td
            ''
            If (False) Then ''9/18/2019 td''If (ClassLabelToImage.UseHighResolutionTips) Then

                ''9/6/2019 td''par_image = New Bitmap(intNewElementWidth, intNewElementHeight)
                par_image = New Bitmap(intNewElementWidth, intNewElementHeight,
                                       Imaging.PixelFormat.Format32bppPArgb)

            Else
                par_image = New Bitmap(intNewElementWidth, intNewElementHeight)

            End If ''end of "If (ClassLabelToImage.UseHighResolutionTips) Then ... Else"

        End If ''End of "If (par_image Is Nothing) Then"

        ''3/09/2023 gr = Graphics.FromImage(par_image)
        ''3/09/2023 gr_local_image_of_element = Graphics.FromImage(local_image_of_element)
        gr_local_image_of_element = Graphics.FromImage(par_image)

        With gr_local_image_of_element
            ''
            'Set various modes to higher quality
            ''  https://stackoverflow.com/questions/2478502/when-creating-an-bitmap-image-from-scratch-in-vb-net-the-quality-stinks
            ''
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            .TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        End With ''End of "With gr_local_image_of_element"

        ''8/29/2019 td''pen_backcolor = New Pen(par_design.BackColor)
        ''3/12/2023 pen_backcolor = New Pen(par_elementInfo_Base.Back_Color)
        pen_backcolor = New Pen(Me.Back_Color)
        ''pen_backcolor = New Pen(Color.White)

        ''Added 8/28/2019 td
        ''8/29/2019 td''brush_backcolor = New SolidBrush(par_elementInfo_Text.BackColor)
        ''3/12/2023 brush_backcolor = New SolidBrush(par_elementInfo_Base.Back_Color)
        brush_backcolor = New SolidBrush(Me.Back_Color)
        gr_local_image_of_element.FillRectangle(brush_backcolor, 0, 0,
                                                intNewElementWidth, intNewElementHeight)

        ''Added 9/3/2019 td
        pen_border = New Pen(Me.Border_Color,
                             Me.Border_WidthInPixels)

        ''8/5/2019 td''pen_highlighting = New Pen(Color.YellowGreen, 5)
        pen_highlighting = New Pen(Color.Yellow, 6)

        brush_forecolor = New SolidBrush(Me.FontColor)

        ''
        ''Draw the select background color, so that hopefully the text can be read easily.
        ''
        ''7/30/2019 td''gr.DrawRectangle(Brushes.White....

        ''
        ''  https://stackoverflow.com/questions/5183856/converting-from-a-color-to-a-brush
        ''
        Using br_brush As SolidBrush = New SolidBrush(Me.Back_Color)
            ''8/15 td''gr.FillRectangle(br_brush,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr_local_image_of_element.FillRectangle(br_brush,
                         New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
        End Using

        ''
        ''Added 9/03/2019 td
        ''
        Dim boolNonzeroBorder As Boolean ''9/9 td 
        If (Me.Border_Displayed) Then
            boolNonzeroBorder = (0 < Me.Border_WidthInPixels)
            If (boolNonzeroBorder) Then
                ''Added 9/03/2019 td
                gr_local_image_of_element.DrawRectangle(pen_border,
                        New Rectangle(0, 0, intNewElementWidth, intNewElementHeight))
            End If ''End of "If (boolNonzeroBorder) Then"
        End If ''End of "If (Me.Border_Displayed) Then"

        ''
        ''Added 8/02/2019 td
        ''
        If (Me.SelectedHighlighting) Then
            ''Added 8/2/2019 td
            ''8/5/2019 td''gr.DrawRectangle(pen_highlighting,
            ''             New Rectangle(0, 0, par_element.Width_Pixels, par_element.Height_Pixels))
            gr_local_image_of_element.DrawRectangle(pen_highlighting,
                         New Rectangle(3, 3, intNewElementWidth - 6, intNewElementHeight - 6))
        End If ''End of "If (par_element.SelectedHighlighting) Then"

        ''7/30/2019''gr.DrawString(par_design.Text, par_design.Font_DrawingClass, brush_forecolor, New Point(0, 0))

        ''Font TextFont = New Font("Times New Roman", 25, FontStyle.Italic);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 20);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 85);
        ''    e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        ''    e.Graphics.DrawString("Sample Text", TextFont, Brushes.Black, 20, 150);

        ''3/9/2023 gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        ''6/ /2022 par_elementInfo_Text.Font_DrawingClass, Brushes.Black, 20, 5)
        ''#1 3/9/2023 gr.DrawString(par_elementInfo_Text.Text_StaticLine,
        ''#1 3/9/2023         par_elementInfo_Text.FontDrawingClass, Brushes.Black, 20, 5)
        '' #2 3/9/2023 gr.DrawString(par_elementInfo_Text.Text_StaticLine,
        '' #2 3/9/2023         par_elementInfo_Text.FontDrawingClass, brush_forecolor, 20, 5)

        Dim stringSize As SizeF = New SizeF()
        Dim font_scaled As System.Drawing.Font ''Added 9/8/2019 td

        With Me ''03/09/2023 With par_elemTextFld

            ''Added 11/24/2021 thomas downes
            '']]]If (.FontSize_Pixels < 5) Then .FontSize_Pixels = 7 ''Throw New Exception("Font Size is less than 10. Hard to read.")
            ''//If (.FontSize_Pixels < 5) Then Throw New Exception("Font Size is less than 10. Hard to read.")

            ''Added 9/15/2019 thomas d.
            If (.FontFamilyName Is Nothing) Then
                ''Added 9/15/2019 thomas d.
                System.Diagnostics.Debugger.Break()
            End If ''End of "If (.FontFamilyName Is Nothing) Then"

            ''Added 9/15/2019 td
            ''6/2022  If (.Font_DrawingClass Is Nothing) Then
            If (.FontDrawingClass Is Nothing) Then
                ''Added 9/15/2019 td
                ''6/07/2022 .Font_DrawingClass = modFonts.MakeFont(.FontFamilyName, .FontSize_Pixels, .FontBold, .FontItalics, .FontUnderline)
                .FontDrawingClass = .FontMaxGalkin.ToFont_AnyUnits()

            Else
                Dim bRegenerateFontObjectClass As Boolean ''Added 9/23/2019 td 
                ''6/2022 bRegenerateFontObjectClass = (CInt(.Font_DrawingClass.Size) <> .FontSize_Pixels) ''Added 9/23/2019 td 
                bRegenerateFontObjectClass = (CInt(.FontDrawingClass.Size) <> .FontSize_Pixels) ''Added 9/23/2019 td 
                If (bRegenerateFontObjectClass) Then ''Added 9/23/2019 td 
                    ''Added 9/23/2019 td 
                    .FontDrawingClass = modFonts.SetFontSize_Pixels(.FontDrawingClass, .FontSize_Pixels)
                End If ''End of '"If (bRegenerateFont) Then .... ElseIf ...."
            End If ''End of '"If (.Font_DrawingClass Is Nothing) Then .... ElseIf ...."

            ''Added 9/8/2019 td
            ''6/2022 font_scaled = modFonts.ScaledFont(.Font_DrawingClass, doubleScaling)
            ''9/13/2022 td''font_scaled = modFonts.ScaledFont(.FontDrawingClass, doubleScaling)
            font_scaled = modFonts.ScaledFont(.FontDrawingClass, CDbl(par_scaleH))

            ''Added 2/25/2023 
            If (.FontColor = Color.Empty) Then
                .FontColor = Color.Black
            End If

            ''Added 8/17/2019 td
            Dim singleOffsetX As Integer = .FontOffset_X
            Dim singleOffsetY As Integer = .FontOffset_Y

            ''Added 8/23/2022 thomas downes
            Using br_brushForecolor As SolidBrush = New SolidBrush(.FontColor)

                ''Added 8/18/2019 td
                Select Case .TextAlignment''Added 8/18/2019 td

                    Case HorizontalAlignment.Left

                        ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black, singleOffsetX, singleOffsetY)
                        ''8/23/2019 td''gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
                        ''                          singleOffsetX, singleOffsetY)
                        ''3/16/2023 td''gr_local_image_of_element.DrawString(par_text, font_scaled, br_brushForecolor,
                        ''                   singleOffsetX, singleOffsetY)
                        gr_local_image_of_element.DrawString(strTextForElement, font_scaled, br_brushForecolor,
                                          singleOffsetX, singleOffsetY)

                    Case HorizontalAlignment.Center
                        ''// Measure string.
                        ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                        ''3/16/2023 td ''stringSize = gr_local_image_of_element.MeasureString(par_text, font_scaled)
                        stringSize = gr_local_image_of_element.MeasureString(strTextForElement, font_scaled)

                        Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                        ''Added 8/18/2019 td 
                        ''3/16/2023 singleOffsetX_AlignRight = (singleOffsetX + (local_image_of_element.Width - stringSize.Width) / 2)
                        singleOffsetX_AlignRight = (singleOffsetX + (par_image.Width - stringSize.Width) / 2)

                        ''Added 8/18/2019 td
                        ''
                        ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                        ''                            singleOffsetX_AlignRight, singleOffsetY)
                        ''8/23/2019 td''gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
                        ''                 singleOffsetX_AlignRight, singleOffsetY)
                        gr_local_image_of_element.DrawString(par_text, font_scaled, br_brushForecolor,
                                  singleOffsetX_AlignRight, singleOffsetY)

                    Case HorizontalAlignment.Right
                        ''// Measure string.
                        ''
                        ''9/8/2019 td''stringSize = gr_element.MeasureString(.Text, .Font_DrawingClass)
                        ''3/16/2023 td ''stringSize = gr_local_image_of_element.MeasureString(par_text, font_scaled)
                        stringSize = gr_local_image_of_element.MeasureString(strTextForElement, font_scaled)

                        Dim singleOffsetX_AlignRight As Single ''Added 8/18/2019 td 
                        ''3/16/2023 td ''singleOffsetX_AlignRight = (local_image_of_element.Width - stringSize.Width - singleOffsetX)
                        singleOffsetX_AlignRight = (par_image.Width - stringSize.Width - singleOffsetX)

                        ''Added 8/18/2019 td 
                        ''9/8/2019 td''gr_element.DrawString(.Text, .Font_DrawingClass, Brushes.Black,
                        ''                           singleOffsetX_AlignRight, singleOffsetY)
                        ''8/23/2019 td''gr_element.DrawString(par_Text, font_scaled, Brushes.Black,
                        ''                           singleOffsetX_AlignRight, singleOffsetY)
                        ''3/16/2023 td ''gr_local_image_of_element.DrawString(par_text, font_scaled, br_brushForecolor,
                        ''                singleOffsetX_AlignRight, singleOffsetY)
                        gr_local_image_of_element.DrawString(strTextForElement, font_scaled, br_brushForecolor,
                                  singleOffsetX_AlignRight, singleOffsetY)

                End Select ''End of "Select Case par_design.TextAlignment"

            End Using

        End With ''ENd of "With Me"

        Return par_image ''Return Nothing

    End Function ''End of "Public Function GenerateImage_NotInUse(par_label As Label) As Image"


    Public Overridable Function Copy() As ClassElementFieldOrTextV4
        ''
        ''Added 2/4/2022 & 9/17/2019 
        ''
        Dim objCopy As New ClassElementFieldOrTextV4

        ''10/12/2019 td''objCopy.LoadbyCopyingMembers(Me, Me)
        ''10/13/2019 td''objCopy.LoadbyCopyingMembers(Me, Me, Me)
        ''12/13/2021 td''objCopy.LoadbyCopyingMembers(Me, Me, Me, Me.BadgeLayout)
        ''02/04/2022 td''objCopy.LoadByCopyingMembers(Me, Me, Me, Me, Me.BadgeLayout)
        ''09/05/2022 td''objCopy.LoadbyCopyingMembers(Me, Me, Me, Me.BadgeLayout)
        objCopy.LoadbyCopyingMembersV1(Me, Me, Me, Me.BadgeLayout)

        Return objCopy

    End Function ''End of "Public Function Copy() As ClassElementFieldOrTextV4"



    Public Sub LoadbyCopyingMembersV2b(par_objectElementV4 As ClassElementFieldOrTextV4,
                                    par_Element_Base As ClassElementBase,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_badgeLayout As BadgeLayoutDimensionsClass)
        ''
        ''This function was originally overloaded... NOW suffixed. ----9/4/2022  
        ''
        Me.Back_Color = par_objectElementV4.Back_Color
        Me.Back_Transparent = par_objectElementV4.Back_Transparent
        Me.BadgeLayout = par_objectElementV4.BadgeLayout
        ''9/4/2022 Me.Border_Color = par_ElementInfo_Base.Border_Color
        ''9/5/2022 Me.Border_bColor = par_Element_Base.Border_bColor
        Me.Border_Color = par_Element_Base.Border_Color

        Me.Border_Displayed = par_objectElementV4.Border_Displayed
        Me.Border_WidthInPixels = par_objectElementV4.Border_WidthInPixels
        Me.Height_Pixels = par_objectElementV4.Height_Pixels
        ''9/4/2022 Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        ''9/4/2022 Me.LeftEdge_bPixels = par_ElementInfo_Base.LeftEdge_Pixels
        ''9/05/2022 Me.LeftEdge_bPixels = par_Element_Base.LeftEdge_bPixels
        Me.LeftEdge_Pixels = par_Element_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_objectElementV4.OrientationInDegrees
        Me.OrientationToLayout = par_objectElementV4.OrientationToLayout
        Me.PositionalMode = par_objectElementV4.PositionalMode
        Me.SelectedHighlighting = par_objectElementV4.SelectedHighlighting
        ''9/4/2022 Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels
        ''9/4/2022 Me.TopEdge_bPixels = par_ElementInfo_Base.TopEdge_Pixels
        ''9/05/2022 Me.TopEdge_bPixels = par_Element_Base.TopEdge_bPixels
        Me.TopEdge_Pixels = par_Element_Base.TopEdge_Pixels
        Me.Width_Pixels = par_objectElementV4.Width_Pixels

        Me.BadgeLayout = New BadgeLayoutDimensionsClass
        Me.BadgeLayout.Height_Pixels = par_badgeLayout.Height_Pixels
        Me.BadgeLayout.Width_Pixels = par_badgeLayout.Width_Pixels
        Me.FontBold_Deprecated = par_ElementInfo_Text.FontBold_Deprecated
        Me.FontColor = par_ElementInfo_Text.FontColor
        Me.FontFamilyName = par_ElementInfo_Text.FontFamilyName
        Me.FontItalics_Deprecated = par_ElementInfo_Text.FontItalics_Deprecated ''Deprecated 6/2022
        Me.FontOffset_X = par_ElementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_ElementInfo_Text.FontOffset_Y
        Me.FontSize_Pixels = par_ElementInfo_Text.FontSize_Pixels
        Me.FontSize_AutoScaleToElementRatio = par_ElementInfo_Text.FontSize_AutoScaleToElementRatio
        Me.FontSize_AutoScaleToElementYesNo = par_ElementInfo_Text.FontSize_AutoScaleToElementYesNo
        Me.FontSize_AutoSizePromptUser = par_ElementInfo_Text.FontSize_AutoSizePromptUser ''Added 6/2/2022
        Me.FontUnderline_Deprecated = par_ElementInfo_Text.FontUnderline_Deprecated ''Deprecated 6/2022
        Me.FontMaxGalkin = par_ElementInfo_Text.FontMaxGalkin
        Me.TextAlignment = par_ElementInfo_Text.TextAlignment

    End Sub


    Public Sub LoadbyCopyingMembersV2a(par_objectElementV4 As ClassElementFieldOrTextV4,
                                    par_Element_Base As ClassElementBase,
                                    par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_badgeLayout As BadgeLayoutDimensionsClass)
        ''
        ''This function was originally overloaded... NOW suffixed. ----9/4/2022  
        ''
        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        ''9/5/2022 Me.BadgeLayout = par_ElementInfo_Base.BadgeLayout
        Me.BadgeLayout = par_ElementInfo_Base.BadgeLayoutDims
        ''9/4/2022 Me.Border_Color = par_ElementInfo_Base.Border_Color
        ''9/5/2022 Me.Border_bColor = par_Element_Base.Border_bColor
        Me.Border_Color = par_Element_Base.Border_Color

        Me.Border_Displayed = par_ElementInfo_Base.Border_Displayed
        Me.Border_WidthInPixels = par_ElementInfo_Base.Border_WidthInPixels
        Me.Height_Pixels = par_ElementInfo_Base.Height_Pixels
        ''9/4/2022 Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        ''9/4/2022 Me.LeftEdge_bPixels = par_ElementInfo_Base.LeftEdge_Pixels
        ''9/5/2022 Me.LeftEdge_bPixels = par_Element_Base.LeftEdge_bPixels
        Me.LeftEdge_Pixels = par_Element_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_ElementInfo_Base.OrientationInDegrees
        Me.OrientationToLayout = par_ElementInfo_Base.OrientationToLayout
        Me.PositionalMode = par_ElementInfo_Base.PositionalMode
        Me.SelectedHighlighting = par_ElementInfo_Base.SelectedHighlighting
        ''9/4/2022 Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels
        ''9/4/2022 Me.TopEdge_bPixels = par_ElementInfo_Base.TopEdge_Pixels
        ''9/5/2022 Me.TopEdge_bPixels = par_Element_Base.TopEdge_bPixels
        Me.TopEdge_Pixels = par_Element_Base.TopEdge_Pixels
        Me.Width_Pixels = par_ElementInfo_Base.Width_Pixels

        Me.BadgeLayout = New BadgeLayoutDimensionsClass
        Me.BadgeLayout.Height_Pixels = par_badgeLayout.Height_Pixels
        Me.BadgeLayout.Width_Pixels = par_badgeLayout.Width_Pixels
        Me.FontBold_Deprecated = par_ElementInfo_Text.FontBold_Deprecated
        Me.FontColor = par_ElementInfo_Text.FontColor
        Me.FontFamilyName = par_ElementInfo_Text.FontFamilyName
        Me.FontItalics_Deprecated = par_ElementInfo_Text.FontItalics_Deprecated ''Deprecated 6/2022
        Me.FontOffset_X = par_ElementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_ElementInfo_Text.FontOffset_Y
        Me.FontSize_Pixels = par_ElementInfo_Text.FontSize_Pixels
        Me.FontSize_AutoScaleToElementRatio = par_ElementInfo_Text.FontSize_AutoScaleToElementRatio
        Me.FontSize_AutoScaleToElementYesNo = par_ElementInfo_Text.FontSize_AutoScaleToElementYesNo
        Me.FontSize_AutoSizePromptUser = par_ElementInfo_Text.FontSize_AutoSizePromptUser ''Added 6/2/2022
        Me.FontUnderline_Deprecated = par_ElementInfo_Text.FontUnderline_Deprecated ''Deprecated 6/2022
        Me.FontMaxGalkin = par_ElementInfo_Text.FontMaxGalkin
        Me.TextAlignment = par_ElementInfo_Text.TextAlignment

    End Sub ''End of ""Public Sub LoadbyCopyingMembers""

#Enable Warning CA1707
#Disable Warning CA1707

    Public Sub LoadbyCopyingMembersV1(par_objectElementV4 As ClassElementFieldOrTextV4,
                                    par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_badgeLayout As BadgeLayoutDimensionsClass)
        ''2/4/2022 td ''     par_ElementInfo_Field As IElement_TextField,
        ''
        ''This function was originally overloaded... NOW suffixed. ----9/4/2022  
        ''
        ''Added 9/13/2019 thomas downes
        ''
        ''--------------------------------------------------------------------------
        ''Step 1 of 2 -- Base properties.
        ''--------------------------------------------------------------------------
        ''
        ''//
        ''// Auto-Mappers  
        ''//   https://stackoverflow.com/questions/16534253/c-sharp-converting-base-class-to-child-class
        ''//   https://dotnettutorials.net/lesson/automapper-in-c-sharp/
        ''//   https://docs.automapper.org/en/latest/Setup.html
        ''//
        ''Dim objMapper As New Mapper(_mapConfig_Base)
        ''objMapper.Map(Of ClassElementField)(par_ElementInfo_Base)

        ''Added 9/05/2022 td
        If (par_ElementInfo_Base Is Nothing) Then
            System.Diagnostics.Debugger.Break()
        End If ''end of ""If (par_ElementInfo_Base Is Nothing) Then""

        Me.Back_Color = par_ElementInfo_Base.Back_Color
        Me.Back_Transparent = par_ElementInfo_Base.Back_Transparent
        ''9/5/2022 Me.BadgeLayout = par_ElementInfo_Base.BadgeLayout
        Me.BadgeLayout = par_ElementInfo_Base.BadgeLayoutDims
        Me.Border_Color = par_ElementInfo_Base.Border_Color
        Me.Border_Displayed = par_ElementInfo_Base.Border_Displayed
        Me.Border_WidthInPixels = par_ElementInfo_Base.Border_WidthInPixels
        Me.Height_Pixels = par_ElementInfo_Base.Height_Pixels
        ''9/4/2022 Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        ''9/5/2022 Me.LeftEdge_bPixels = par_ElementInfo_Base.LeftEdge_Pixels
        Me.LeftEdge_Pixels = par_ElementInfo_Base.LeftEdge_Pixels
        Me.OrientationInDegrees = par_ElementInfo_Base.OrientationInDegrees
        Me.OrientationToLayout = par_ElementInfo_Base.OrientationToLayout
        Me.PositionalMode = par_ElementInfo_Base.PositionalMode
        Me.SelectedHighlighting = par_ElementInfo_Base.SelectedHighlighting
        ''9/4/2022 Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels
        ''9/5/2022 Me.TopEdge_bPixels = par_ElementInfo_Base.TopEdge_Pixels
        Me.TopEdge_Pixels = par_ElementInfo_Base.TopEdge_Pixels
        Me.Width_Pixels = par_ElementInfo_Base.Width_Pixels

        ''''--------------------------------------------------------------------------
        ''''Step 2 of 2 -- Field-related properties.
        ''''--------------------------------------------------------------------------
        ''''
        ''Me.ExampleValue_ForElement = par_ElementInfo_Field.ExampleValue_ForElement
        ''''See FieldInfo. ---9/18/2019 td''Me.FieldInCardData = par_ElementInfo_TextFld.FieldInCardData
        ''''See FieldInfo. ---9/18/2019 td''Me.FieldLabelCaption = par_ElementInfo_TextFld.FieldLabelCaption
        ''Me.FieldInfo = par_ElementInfo_Field.FieldInfo ''Added 9/18/2019 td 
        ''
        ''''Added 12/13/2021 
        ''Me.FieldObjectAny = par_objectElement.FieldObjectAny
        ''Me.FieldObjectCustom = par_objectElement.FieldObjectCustom
        ''Me.FieldObjectStandard = par_objectElement.FieldObjectStandard
        ''
        ''''Added 10/13/2019 td
        ''Me.FieldEnum = par_ElementInfo_Field.FieldEnum

        ''Added 10/13/2019 td
        Me.BadgeLayout = New BadgeLayoutDimensionsClass
        Me.BadgeLayout.Height_Pixels = par_badgeLayout.Height_Pixels
        Me.BadgeLayout.Width_Pixels = par_badgeLayout.Width_Pixels

        Me.FontBold_Deprecated = par_ElementInfo_Text.FontBold_Deprecated
        Me.FontColor = par_ElementInfo_Text.FontColor
        Me.FontFamilyName = par_ElementInfo_Text.FontFamilyName
        Me.FontItalics_Deprecated = par_ElementInfo_Text.FontItalics_Deprecated ''Deprecated 6/2022
        Me.FontOffset_X = par_ElementInfo_Text.FontOffset_X
        Me.FontOffset_Y = par_ElementInfo_Text.FontOffset_Y
        Me.FontSize_Pixels = par_ElementInfo_Text.FontSize_Pixels
        ''6/2/2022 Me.FontSize_ScaleToElementRatio = par_ElementInfo_Text.FontSize_ScaleToElementRatio
        ''6/2/2022 Me.FontSize_ScaleToElementYesNo = par_ElementInfo_Text.FontSize_ScaleToElementYesNo
        Me.FontSize_AutoScaleToElementRatio = par_ElementInfo_Text.FontSize_AutoScaleToElementRatio
        Me.FontSize_AutoScaleToElementYesNo = par_ElementInfo_Text.FontSize_AutoScaleToElementYesNo
        Me.FontSize_AutoSizePromptUser = par_ElementInfo_Text.FontSize_AutoSizePromptUser ''Added 6/2/2022

        Me.FontUnderline_Deprecated = par_ElementInfo_Text.FontUnderline_Deprecated ''Deprecated 6/2022

        ''6/7/2022 td''Me.Font_DrawingClass = par_ElementInfo_Text.Font_DrawingClass
        Me.FontMaxGalkin = par_ElementInfo_Text.FontMaxGalkin

        ''---See above. ---9/18/2019 td
        ''---Me.ExampleValue = par_ElementInfo_TextFld.ExampleValue

        ''Added 9/19/2019 td 
        Me.TextAlignment = par_ElementInfo_Text.TextAlignment

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"


    Public Sub Font_AutoScaleAdjustment(par_intNewHeightInPixels As Integer)
        ''June2 2022 Public Sub Font_ScaleAdjustment(par_intNewHeightInPixels As Integer) 
        ''
        ''Renamed 6/02/2022 td 
        ''Added 9/15/2019 td  
        ''
        ''Added 6/6/2022 thomas d.
        If (FontSize_AutoScaleToElementRatio = 0) Then
            FontSize_AutoScaleToElementRatio = 0.8
        End If

        ''6/2/2022 If FontSize_ScaleToElementYesNo Then
        If FontSize_AutoScaleToElementYesNo Then

            FontSize_Pixels = CSng(FontSize_AutoScaleToElementRatio * par_intNewHeightInPixels)
            ''6/2022 Font_DrawingClass = modFonts.SetFontSize_Pixels(Font_DrawingClass, FontSize_Pixels)
            FontDrawingClass = modFonts.SetFontSize_Pixels(FontDrawingClass, FontSize_Pixels)

        End If ''End of "If FontSize_AutoScaleToElementYesNo Then"

    End Sub ''End of "Public Sub Font_AutoScaleAdjustment()" 


    Public Shared Sub CheckWidthVsLength_OfText(intWidth As Integer, intHeight As Integer,
                                     boolRotated As Boolean, par_bIsMultiline As Boolean)
        ''
        ''Double-check the orientation.  ----9/23/2019 td
        ''
        Dim boolTextImageRotated_0_180 As Boolean = (intWidth > intHeight) ''Vs. Portrait comparison, (intWidth < intHeight)
        Dim boolTextImageRotated_90_270 As Boolean = (intWidth < intHeight) ''Vs. Portrait comparison, (intWidth > intHeight)
        Dim boolTextIsMultiline As Boolean ''Added 6/10/2022

        boolTextIsMultiline = par_bIsMultiline ''Added 6/10/2022 

        If (boolTextIsMultiline) Then
            ''
            ''The width/height expecations don't apply for >1 lines of text. ---6/10/2022 
            ''
        ElseIf (boolTextImageRotated_0_180 And boolRotated) Then
            ''6/6/2022 Throw New Exception("Image dimensions are not expected. (Rotation of text expected)")
            System.Diagnostics.Debugger.Break()
        ElseIf (boolTextImageRotated_90_270 And (Not boolRotated)) Then
            ''6/6/2022 Throw New Exception("Image dimensions are not expected.  (Unexpected rotation of text is detected)")
            System.Diagnostics.Debugger.Break()
        End If ''End of "If (boolImageRotated_0_180 and boolRotated) Then .... ElseIf ..."

    End Sub ''ENd of "Public Shared Sub CheckWidthVsLength_OfText()"

    ''Public Function LabelText_ToDisplay(par_isForLayout_OrPreview As Boolean,
    ''                                    Optional par_iRecipInfo As IRecipient = Nothing,
    ''                                    Optional pbAllowExampleValues As Boolean = True) As String
    ''    ''
    ''    ''Added 10/16/2016 & 7/25/2019 thomas d 
    ''    ''
    ''    ''This was copied from CtlGraphicFldLabel.vb on 10/16/2019 td
    ''    ''
    ''    Dim bOkayToUseExampleValues As Boolean ''Added 10/16/2019 td  

    ''    ''11/18/2019 td''bOkayToUseExampleValues = par_isForLayout_OrPreview
    ''    Dim boolNotAFinalPrint As Boolean ''Added 11/18/2019 td
    ''    boolNotAFinalPrint = par_isForLayout_OrPreview ''Added 11/18/2019 td
    ''    bOkayToUseExampleValues = (boolNotAFinalPrint And pbAllowExampleValues)

    ''    Select Case True

    ''        Case (par_iRecipInfo IsNot Nothing)
    ''            ''
    ''            ''Added 12/14/2021 thomas d. 
    ''            ''
    ''            Return par_iRecipInfo.GetTextValue(Me.FieldEnum)

    ''        Case (ClassElementFieldV3.oRecipient IsNot Nothing)
    ''            ''
    ''            ''Added 10/16/2019 thomas d. 
    ''            ''
    ''            Return ClassElementFieldV3.oRecipient.GetTextValue(Me.FieldEnum)

    ''            ''Case (Me.ExampleTextToDisplay.Trim() <> "")
    ''            ''    ''
    ''            ''    ''Added 9/18/2019 td 
    ''            ''    ''
    ''            ''    Return Me.ExampleTextToDisplay

    ''        Case (ClassElementFieldV3.iRecipientInfo IsNot Nothing)

    ''            Return ClassElementFieldV3.iRecipientInfo.GetTextValue(Me.FieldEnum)

    ''        Case (bOkayToUseExampleValues And (Me.ExampleValue_ForElement <> ""))
    ''            ''10/16 td''Case (Me.ExampleValue_ForElement <> "")
    ''            ''
    ''            ''Added 9/18/2019 td 
    ''            ''
    ''            Return Me.ExampleValue_ForElement

    ''        Case (bOkayToUseExampleValues And (Me.FieldInfo.ExampleValue <> ""))
    ''            ''10/16 td''Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

    ''            ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
    ''            Return Me.FieldInfo.ExampleValue

    ''        Case (Me.FieldInfo.FieldLabelCaption <> "")

    ''            ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
    ''            Return Me.FieldInfo.FieldLabelCaption

    ''        Case Else

    ''            ''Default value.
    ''            ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
    ''            Return $"Field #{Me.FieldInfo.FieldIndex}"

    ''    End Select ''End of "Select Case True"

    ''    Return "Field Information"

    ''End Function ''End of "Public Function LabelText(par_previewExample As Boolean) As String"


    Public Overridable Function ImageForBadgeImage_Stub(par_recipient As IRecipient,
                                                 par_scaleW As Single,
                                                   par_scaleH As Single) As Image ''9/4/2022 Implements IElement_Base.ImageForBadgeImage
        ''3/08/2022 Public Overloads Function ImageForBadgeImage(par_recipient As IRecipient,

        ''Throw New NotImplementedException()
        '9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
        Return New Bitmap(MyBase.Width_Pixels, MyBase.Height_Pixels)

    End Function


End Class ''End of "Class ClassElementField"  
