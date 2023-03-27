''
''Added 1/29/2022 thomas downes
''
Option Explicit On
Option Strict On
Option Infer Off

Imports System.Drawing ''Added 9/18/2019 td
''//Imports System.Drawing.Text ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces

''//Imports ciBadgeInterfaces ''Added 9/61/2019 thomas d. 
''//Imports System.Xml.Serialization ''Added 10/13/2019 thomas d.  
''//Imports ciBadgeSerialize ''Added 6/7/2022 thomas d.

#Disable Warning CA1707 ''Removal of underscores.

<Serializable>
Public Class ClassElementStaticTextV4
    Inherits ClassElementFieldOrTextV4
    ''---Implements IElement_Base, IElement_TextOnly
    ''
    ''Added 1/29/2022 thomas downes
    ''
    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


#Enable Warning CA1707
#Disable Warning CA1707

    Public Sub New(par_DisplayText As String,
                   par_intLeft_Pixels As Integer,
                   par_intTop_Pixels As Integer,
                   par_intHeight_Pixels As Integer,
                   par_intWidth_Pixels As Integer,
                   par_badgeLayoutDims As BadgeLayoutDimensionsClass)
        ''
        ''Added 9/15/2019 td
        ''
        ''2/21/2022 Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019
        Me.BadgeLayout = New BadgeLayoutDimensionsClass(par_badgeLayoutDims.Width_Pixels,
                                      par_badgeLayoutDims.Height_Pixels) ''Added 2/21/2022 td

        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels
        Me.Width_Pixels = par_intWidth_Pixels ''Added 8/17/2022

        ''Added 8/17/2022 td
        ''  Let's write to the base class. ("b" = "base")
        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels
        Me.Width_Pixels = par_intWidth_Pixels ''Added 8/17/2022

        ''Added 10//10/2019 td
        Me.Text_StaticLine = par_DisplayText

    End Sub

#Enable Warning CA1707

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

    End Sub


    ''
    ''Added 3/27/2023
    ''
    Public Overrides Sub Print(par_graphicsOfBadge As Graphics,
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

            ''Added 3/27/2023 td
            Dim strTextToDisplay As String ''Added 3/27/2023 td
            strTextToDisplay = pstrTextToDisplay
            If (strTextToDisplay = "") Then
                strTextToDisplay = Text_StaticLine
            End If

            ''3/16/2023 Dim image_element As Image = ImageForBadgeImage(par_recipient,
            ''                                         par_scaleW, par_scaleH)
            Dim image_element As Image = ImageForBadgeImage(par_scaleW,
                                                            par_scaleH, par_recipient,
                                           EnumCIBFields.Undetermined, strTextToDisplay)
            ''3/27/2023                    EnumCIBFields.Undetermined, Text_StaticLine)

            ''Added 3/27/2023
            If (par_graphicsOfBadge Is Nothing) Then Throw New NotImplementedException()

            par_graphicsOfBadge.DrawImage(image_element, locationPoint)
            ''              New PointF(intDesiredLeft, intDesiredTop));

        End If ''ENd of ""If (pboolNotShownOnBadge) Then... Else..."

    End Sub ''End of "Public Overridable Sub Print()"


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
        If (par_text = "") Then par_text = Text_StaticLine

        Return MyBase.ImageForBadgeImage(par_scaleW, par_scaleH,
                                         par_recipient, par_enumField,
                                         par_text, par_image)

    End Function ''end of ""Public Overrides Function ImageForBadgeImage""



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

#Disable Warning CA1707 ''Removal of underscores.  12/2022

    Public Function GenerateImage_ByDesiredLayoutWidth(pintDesiredLayoutWidth As Integer) As Image _
        ''--Implements IElement_TextOnly.GenerateImage_ByDesiredLayoutWidth
        ''
        ''    8/26 td''Public Function GenerateImage(pintLayoutHeight As Integer) As Image Implements IElementText.GenerateImage
        ''
        ''Added 8/14/2019 thomas downes 
        ''
        Dim obj_image As Image = Nothing

        Try
            ''
            ''Major call !!
            '' 
            ''Not ready yet. ---9/16 td''obj_image = _labelToImage.TextImage_Static(pintDesiredLayoutWidth, Me, Me, False, False)

        Catch ex As Exception
            ''Added 9/15/2019 td  
            ''---MessageBox.Show(ex.Message, "90022", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try

        Return obj_image

    End Function ''End of "Public Function GenerateImage_ByDesiredLayoutWidth() As Image Implements IElementText.GenerateImage_ByDesiredLayoutWidth"


End Class
