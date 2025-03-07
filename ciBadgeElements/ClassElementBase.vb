﻿Option Explicit On
Option Strict On
''
''Added 1/8/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 1/8/2022 thomas downes
Imports System.Drawing ''Added 9/18/2019 td 
Imports System.Windows.Forms ''Added 9/18/2019 td 
Imports System.Xml.Serialization ''Added 9/5/2022 & 9/24/2019 td

#Disable Warning CA1036 ''Warning CA1036: Since it implements IComparable", ClassElementBase 
''  should define operators == > < <= >= <>.   ---3/30/2023

Public Class ClassElementBase
    ''9/05/2022 Implements IElement_Base_InDevelopment  ''//_Temporary
    Implements IElement_Base  ''//_Temporary
    Implements IComparable(Of ClassElementBase) ''Added 3/27/2023
    ''Not implemented yet.  ----Implements IElement_Base
    ''
    ''Added 1/8/2022 thomas downes
    ''
    ''Added 1/23/2022 td
    Public Property WhyOmitted As WhyOmitted_StructV2 Implements IElement_Base.WhyOmitted

#Disable Warning CA1707 ''Underscores-in-names

    ''Added 5/5/2022 td
    Public Property ConditionalExpressionInUse As Boolean
    Public Property ConditionalExpressionField As EnumCIBFields
    Public Property ConditionalExpressionValue As String
    Public Property ConditionalExp_LastEdited As Date ''Added 5/5/2022
    Public Property ConditionalExp_AllowBlanks As Boolean ''Added 5/30/2022
    Public Property ConditionalExp_PreviewDisplay As Boolean ''Added 5/30/2022

    ''
    ''I need to copy-paste (or rather, "cut-paste") all members from ClassElementField (or ClassElementLaysection)
    ''  which implement IElement_Base.  ----1/8/2022 td
    ''
    ''Or, I can un-comment the code below, which was copy-pasted from ClassElementLaysection. ---1/8/2022 td
    ''
    ''
    ''-----------------------------------------------------------------------------------------------------------------
    ''----- The following was copy-pasted from ClassElementLaysection, then commented out of service. ---1/8/2022 td
    ''-----------------------------------------------------------------------------------------------------------------

    ''Private mod_cache As ClassElementsCache_DontUse

    Public Property BadgeDisplayIndex As Integer Implements IElement_Base.BadgeDisplayIndex ''Added 11/24/2021 td
    Public Property WhichSideOfCard As EnumWhichSideOfCard Implements IElement_Base.WhichSideOfCard ''Added 12/13/2021 td
    Public Property DateEdited As Date Implements IElement_Base.DateEdited ''Added 12/18/2021 thomas downes  
    Public Property DateSaved As Date Implements IElement_Base.DateSaved ''Added 12/18/2021 thomas downes

    ''Public Property SubLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String = "Text" Implements IElement_Base.ElementType ''Text, Pic, or Logo

    ''''9/11/2019 td''Public Property LayoutWidth_Pixels As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 
    Public Property BadgeLayoutDims As BadgeLayoutDimensionsClass Implements IElement_Base.BadgeLayoutDims ''Added 9/11/2019 td  

    ''Public Property TopEdge_Pixels As Integer = 0 Implements IElement_Base.TopEdge_Pixels
    ''Public Property LeftEdge_Pixels As Integer = 0 Implements IElement_Base.LeftEdge_Pixels

    ''Public Property Width_Pixels As Integer = 253 Implements IElement_Base.Width_Pixels
    ''Public Property Height_Pixels As Integer = 33 Implements IElement_Base.Height_Pixels

    <XmlIgnore>
    Public Property Border_Color As System.Drawing.Color = Color.Black Implements IElement_Base.Border_Color
    Public Property Border_Displayed As Boolean = True Implements IElement_Base.Border_Displayed ''Added 9/9/2019 td 

    ''''8/29/2019 td''Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_WidthInPixels As Integer = 1 Implements IElement_Base.Border_WidthInPixels

    <XmlElement("Border_Color")>
    Public Property Border_Color_HTML As String
        ''Added 9/6/2022 & 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Border_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Border_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property


    ''Added 8/3/2022 thomas downes
    Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels ''Added 8/3/2022 thomas downes
    Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels  ''Added 8/3/2022 thomas downes

    ''Added 8/4/2022 thomas downes
    Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels ''Added 8/04/2022 thomas downes
    Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels  ''Added 8/04/2022 thomas downes

    <XmlIgnore>
    Public Property Back_Color As System.Drawing.Color = Color.White Implements IElement_Base.Back_Color

    Public Property Back_Transparent As Boolean = False Implements IElement_Base.Back_Transparent ''Added 9/4/2019 thomas d. 

    <XmlElement("Back_Color")>
    Public Property Back_Color_HTML As String
        ''Added 9/6/2022 & 10/13/2019 td
        Get
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Return ColorTranslator.ToHtml(Me.Back_Color)
        End Get
        Set(value As String)
            ''  https://stackoverflow.com/questions/376234/best-solution-for-xmlserializer-and-system-drawing-color
            Me.Back_Color = ColorTranslator.FromHtml(value)
        End Set
    End Property


    ''Added 8/2/2019 td
    ''' <summary>
    ''' Selected for processing a subset of elements. Selection is indicated graphically.
    ''' </summary>
    ''' <returns></returns>
    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td 

    ''Alias Prorerty. ---Added 3/16/2023 td 
    Public Property SelectedToProcessSubset As Boolean Implements IElement_Base.SelectedToProcessSubset ''Alias Prorerty. ---Added 3/16/2023 td 

    Public Property PositionalMode As String Implements IElement_Base.PositionalMode ''Added 8/14/2019 td 

    Public Property OrientationToLayout As String Implements IElement_Base.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElement_Base.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    ''BL = Badge Layout
    <Xml.Serialization.XmlIgnore>
    Public Property Image_BL As Image Implements IElement_Base.Image_BL ''Added 8/27/2019 td

    Public Property Visible As Boolean = True Implements IElement_Base.Visible ''Added 9/18/2019 td  


    ''VB6 property to address layering. This is to address the issue of overlapping. ---12/19/2021 thomasd. 
    Public Property ZOrder As Integer Implements IElement_Base.ZOrder

    ''MS.NET solution to address layering. This is also to address the issue of overlapping. ---3/26/2023 thomasd.
    Public Property ChildIndex As Integer Implements IElement_Base.ChildIndex ''MS.NET property to address layering. 

    ''3/24/2023    Get  ''Public Property ZOrder As Integer
    ''        ''9/5/2022 Throw New NotImplementedException()
    ''        Return 0
    ''
    ''    End Get
    ''    Set(value As Integer)
    ''        ''9/5/2022 Throw New NotImplementedException()
    ''    End Set
    ''End Property


    Public Overridable Function ImageForBadgeImage(par_scaleW As Single,
                            par_scaleH As Single,
                            par_enumMode As EnumPrintMode,
                            Optional ByRef par_recipient As IRecipient = Nothing,
                            Optional ByVal par_enumField As EnumCIBFields = EnumCIBFields.Undetermined,
                            Optional ByRef par_text As String = "",
                            Optional ByRef par_image As Image = Nothing) As Image ''3/8/2022 Implements IElement_Base.ImageForBadgeImage
        ''This function is inspired/prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023 thomas clifton downes
        ''
        ''    Throw New NotImplementedException()

        ''12/31/2022 Return Nothing
        ''12/31/2022 Return New Bitmap(MyBase.Width_Pixels, MyBase.Height_Pixels)
        Return Nothing

    End Function ''End of ""Public Function ImageForBadgeImage""


    ''
    ''Added 3/09/2023
    ''
    Public Overridable Sub Print(par_graphicsOfBadge As Graphics,
                                       par_printMode As EnumPrintMode,
                                       par_recipient As IRecipient,
                                       par_scaleW As Single,
                                       par_scaleH As Single,
                                       ByRef pboolNotShownOnBadge As Boolean,
                                       Optional pboolDisplayRegardless As Boolean = False,
                                       Optional pstrTextToDisplay As String = "")

        ''This function is inspired/prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023 thomas clifton downes

        pboolNotShownOnBadge = (Not Me.Visible)

        ''3/9/2023''If (pboolNotShownOnBadge) Then
        If (pboolNotShownOnBadge And (Not pboolDisplayRegardless)) Then
            ''
            ''Don't print on the badge.
            ''    (Override is False: pboolDisplayRegardless)
            ''
        Else
            Dim locationPoint As Point = New Drawing.Point(CInt(LeftEdge_Pixels * par_scaleW),
                                             CInt(TopEdge_Pixels * par_scaleH))

            ''3/16/2023 Dim image_element As Image = ImageForBadgeImage(par_recipient,
            ''                                         par_scaleW, par_scaleH)
            Dim image_element As Image = ImageForBadgeImage(par_scaleW, par_scaleH,
                                                            par_printMode, par_recipient,
                                                            EnumCIBFields.Undetermined,
                                                            "", Nothing)

            ''Aded 3/27/2023 
            If (par_graphicsOfBadge Is Nothing) Then Exit Sub

            par_graphicsOfBadge.DrawImage(image_element, locationPoint)
            ''              New PointF(intDesiredLeft, intDesiredTop));

        End If ''ENd of ""If (pboolNotShownOnBadge) Then... Else..."

    End Sub ''End of "Public Overridable Sub Print()"


    ''
    ''Added 3/05/2023
    ''
    Public Overridable Function GetImageForPrinting(par_recipient As IRecipient,
                                       par_scaleW As Single,
                                       par_scaleH As Single,
                                       par_enumPrintMode As EnumPrintMode,
                                       ByRef pboolNotShownOnBadge As Boolean,
                                       Optional ByRef par_location As Drawing.Point = Nothing) As Image
        ''This function is prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023
        pboolNotShownOnBadge = (Not Me.Visible)

        par_location = New Drawing.Point(CInt(LeftEdge_Pixels * par_scaleW),
                                         CInt(TopEdge_Pixels * par_scaleH))

        ''3/09/2023 Return ImageForBadgeImage(par_recipient, par_scale)
        ''3/16/2023 Return ImageForBadgeImage(par_recipient, par_scaleW, par_scaleH)
        ''3/31/2023 Return ImageForBadgeImage(par_scaleW, par_scaleH, par_recipient)
        Return ImageForBadgeImage(par_scaleW, par_scaleH, par_enumPrintMode, par_recipient)

    End Function ''End of "Public Function GetImage() As Image"


    ''Added 1/23/2022 td
    ''Moved up to top 5/5/2022 ''Public Property WhyOmitted As WhyOmitted_StructV2 Implements IElement_Base_InDevelopment.WhyOmitted

#Disable Warning CA1707

    Public Function ConditionalExpressionIsFalse(par_iRecipientInfo As IRecipient,
                                                 Optional pbDefaultValue As Boolean = False,
                                                 Optional pbReturnThisIfRecipNull As Boolean = False) As Boolean
        ''
        ''Added 5/29/2022 td
        ''
        Dim strRecipientValue As String
        Dim bSuccessfulMatch As Boolean
        Dim bFailsToMatch As Boolean

        ''Check to see if we can quickly return the default value of False,
        ''  which will allow the conditionally-visibly element to be printed.
        ''  ----5/29/2022 td  
        If (Not ConditionalExpressionInUse) Then Return pbDefaultValue ''False
        If (ConditionalExpressionField = EnumCIBFields.Undetermined) Then Return pbDefaultValue ''False

        ''--May2022 If (par_iRecipientInfo Is Nothing) Then System.Diagnostics.Debugger.Break()
        ''--May2022 If (par_iRecipientInfo Is Nothing) Then Throw New ArgumentException("blah")
        If (par_iRecipientInfo Is Nothing) Then Return pbReturnThisIfRecipNull

        strRecipientValue = par_iRecipientInfo.GetTextValue(ConditionalExpressionField)
        bSuccessfulMatch = (strRecipientValue = Me.ConditionalExpressionValue)
        bFailsToMatch = (Not bSuccessfulMatch)

        ''If they are relevant, check for blank values.
        If (ConditionalExp_AllowBlanks) Then
            If String.IsNullOrWhiteSpace(strRecipientValue) Then
                bFailsToMatch = False
            End If ''End of ""If String.IsNullOrWhiteSpace(strRecipientValue) Then""
        End If ''End of ""If (ConditionalExp_AllowBlanks) Then""

        Return bFailsToMatch

    End Function ''End of ""Public Function ConditionalExpressionIsFalse""

#Enable Warning CA1707
#Disable Warning CA1707

    Public Function ConditionalExpressionIsTrue(par_iRecipientInfo As IRecipient,
                                                 pboolDefaultValue As Boolean) As Boolean
        ''
        ''Added 5/29/2022 td
        ''
        Dim strRecipientValue As String
        Dim bSuccessfulMatch As Boolean

        ''Check to see if we can quickly return the default value (usually True),
        ''  which will allow the conditionally-visibly element to be printed.
        ''  ----5/29/2022 td  
        If (Not ConditionalExpressionInUse) Then Return pboolDefaultValue
        If (ConditionalExpressionField = EnumCIBFields.Undetermined) Then Return pboolDefaultValue
        If (par_iRecipientInfo Is Nothing) Then Return pboolDefaultValue

        strRecipientValue = par_iRecipientInfo.GetTextValue(ConditionalExpressionField)
        bSuccessfulMatch = (strRecipientValue = Me.ConditionalExpressionValue)

        ''If they are relevant, check for blank values.
        If (ConditionalExp_AllowBlanks) Then
            If String.IsNullOrWhiteSpace(strRecipientValue) Then
                bSuccessfulMatch = True
            End If ''End of ""If String.IsNullOrWhiteSpace(strRecipientValue) Then""
        End If ''End of ""If (ConditionalExp_AllowBlanks) Then""

        Return bSuccessfulMatch

    End Function ''End of ""Public Function ConditionalExpressionIsTrue""

#Enable Warning CA1707

    Public Function GetSize() As Drawing.Size

        ''Added 12/08/2022 thomas downes
        Return New Size(Me.Width_Pixels, Me.Height_Pixels)

    End Function

    Public Function CompareTo(other As ClassElementBase) As Integer _
        Implements IComparable(Of ClassElementBase).CompareTo

        ''3/27/2023 TD'' Throw New NotImplementedException()
        If (other Is Nothing) Then Throw New NotImplementedException()

        If (ZOrder < other.ZOrder) Then
            ''
            ''Lower ZOrders should be sorted first.
            ''   (I'm not sure how it was in VB6.) 
            ''
            ''3/27/2023 Return ("A".CompareTo("Z")) 
            Return -1 ''3/27/2023 ("A".CompareTo("Z")) ''1 or -1 ??

        ElseIf (ZOrder > other.ZOrder) Then
            ''
            ''Bigger ZOrders should be sorted last.
            ''   (I'm not sure how it was in VB6.) 
            ''
            ''3/27/2023 Return ("Z".CompareTo("A")) ''1 or -1 ??
            Return 1 ''3/27/2023 ("A".CompareTo("Z")) ''1 or -1 ??

        Else

            ''Return 0
            Return 0 '' "A".CompareTo("A") ''Probably 0. 

        End If ''ENd of ""If (ElementBase.ZOrder < other.ElementBase.ZOrder) Then... ElseIf ... Else ..."


    End Function
End Class
