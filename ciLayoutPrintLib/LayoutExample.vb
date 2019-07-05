Option Explicit On
Option Strict On
''
''Added 6/14/2019 Thomas Downes   
''
Imports System.Drawing

Public Class LayoutExample
    ''
    ''Added 6/14/2019 Thomas Downes  
    ''
    Private mod_form As New FormLayoutEg
    Private mod_print As New ciLayoutPrintLib.LayoutPrint

    Public Property RecipientID As String ''Added 6/13/2019
    Public Property RecipientName As String ''Added 6/13/2019
    Public Property RecipientPhoto As Image ''Added 6/20/2019

    Public Property RecipientFaceImage As Image ''Added 6/20/2019 td 

    Sub New()

        mod_form.PicturePersonLarge.Image = Global.ciLayoutPrintLib.My.Resources.v9_lady

        With mod_print

            .LabelControlForID = mod_form.LabelRecipientID
            .LabelControlForName = mod_form.labelRecipientName

            .PanelLayout = mod_form.panelLayout

            .PictureBoxReview = mod_form.pictureboxReview
            .PictureOfPureWhite = mod_form.picturePureWhite
            .PicturePersonImageLarge = mod_form.PicturePersonLarge
            .PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            ''Added 6/20/2019 thoma downes
            If (Me.RecipientPhoto IsNot Nothing) Then .PicturePersonImageLarge.Image = Me.RecipientPhoto

        End With

    End Sub ''End of "With mod_print"

    Public Sub UpdateLabelPositions(par_textPosition As CILayoutText)
        ''
        ''Added 6/27/2019
        ''
        Me.mod_form.labelRecipientName.Top = par_textPosition.TopEdgePositionPixels
        Me.mod_form.labelRecipientName.Left = par_textPosition.LeftEdgePositionPixels

        ''Added 6/28/2019 thomas c.d.
        ''
        ''Me.mod_form.LabelRecipientID.BackColor = par_textPosition.BackgroundColor;

        ''     //This gives us an array of 3 strings each representing a number in text form.
        ''var splitString = stringArray[i].Split(','); 

        ''//converts the array of 3 strings in to an array of 3 ints.
        ''var splitInts = splitString.Select(item >= Int.Parse(item)).ToArray(); 

        ''//takes each element of the array of 3 And passes it in to the correct slot
        ''colorArray[i] = System.Drawing.Color.FromArgb(splitInts[0], splitInts[1], splitInts[2]); 

        ''Color.FromArgb()

        Dim strHexColor As String ''Added 6/28/2019 td 
        Dim intColorInDecimalInteger As Integer

        strHexColor = par_textPosition.BackgroundColor.Replace("#", "") ''Added 6/28/2019 thomas downes 
        intColorInDecimalInteger = ConvertHexToInteger(strHexColor)
        Me.mod_form.labelRecipientName.BackColor = Drawing.Color.FromArgb(intColorInDecimalInteger)

    End Sub ''End of "Public Sub UpdateLabelPositions(......)"

    Public Function ConvertHexToInteger(par_strHexColor As String) As Integer
        ''
        ''Added 6/28/2019 thomas downes 
        ''
        ''   https://theburningmonk.com/2010/02/converting-hex-to-int-in-csharp/
        ''
        Dim intOutput As Integer

        ''Added 6/28/2019 thomas downes 
        intOutput = Integer.Parse(par_strHexColor, Globalization.NumberStyles.HexNumber)
        Return intOutput

    End Function ''End of "Public Function ConvertHexToInteger(par_strHexColor As String) As Integer" 

    Public Function GenerateImage(par_RecipientID As String, par_RecipientName As String,
                                  par_portraitpic As Image,
                                  Optional pboolLargeLandscape As Boolean = False,
                                  Optional pboolSmallLandscape As Boolean = False) As Image
        '6/20 td''Public Function GenerateImage(par_RecipientID As String, par_RecipientName As String, par_portraitpic As Image) As Image
        ''
        ''Added 6/14/2019 thomas downes   
        ''
        Dim imageDummy As Image = Nothing ''Added 6/20/2019 thomas downes 

        With mod_print

            ''.RecipientID = Me.RecipientID
            ''.RecipientName = Me.RecipientName
            .RecipientID = par_RecipientID
            .RecipientName = par_RecipientName
            .RecipientPic = par_portraitpic ''Added 6/20/2019 td  

            .PanelLayout = mod_form.panelLayout
            .PictureBoxReview = mod_form.pictureboxReview
            .PicturePersonImageLarge = mod_form.PicturePersonLarge
            .PictureOfPureWhite = mod_form.picturePureWhite
            .PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            .PicturePersonImageLarge.Image = par_portraitpic

            ''Added 7/5/2019 td
            Try
                .PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()
            Catch ex As Exception
                ''Added 7/5/2019 td
                Dim strErrMessage As String
                If (True) Then strErrMessage = ex.Message
            End Try

            ''6/20/2019 td''Return .GenerateBuildImage()
            Return .GenerateBuildImage(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

        End With ''End of "With mod_print"

    End Function ''End of "Public Function GenerateImage()"

    Public Function GenerateImage_BackgroundOnly(Optional pboolLargeLandscape As Boolean = False,
                                                Optional pboolSmallLandscape As Boolean = False) As Image
        ''
        ''Added 6/28/2019 thomas downes  
        ''
        Dim imageDummy As Image = Nothing ''Added 6/20/2019 thomas downes 

        With mod_print

            ''6/28/2019 td''.RecipientID = par_RecipientID
            ''6/28/2019 td''.RecipientName = par_RecipientName
            ''6/28/2019 td''.RecipientPic = par_portraitpic ''Added 6/20/2019 td  

            .PanelLayout = mod_form.panelLayout

            ''Added 7/5/2019 td
            .PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()

            ''6/28/2019 td''.PictureBoxReview = mod_form.pictureboxReview
            ''6/28/2019 td''.PicturePersonImageLarge = mod_form.PicturePersonLarge
            ''6/28/2019 td''.PictureOfPureWhite = mod_form.picturePureWhite
            ''6/28/2019 td''.PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            ''.PicturePersonImageLarge.Image = par_portraitpic

            ''6/20/2019 td''Return .GenerateBuildImage()
            ''6/28/2019 td''Return .GenerateBuildImage(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

            Return .GenerateBuildImage_BackgroundOnly(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

        End With ''End of "With mod_print"

    End Function ''End of "Public Function GenerateImage()"

End Class ''End of Class LayoutExample
