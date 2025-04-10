﻿Option Explicit On
Option Strict On
''
''Added 6/14/2019 Thomas Downes   
''
Imports System.Drawing

Public Class LayoutExample
    ''
    ''Added 6/14/2019 Thomas Downes  
    ''
    ''7/5/2019 td''Private mod_form As New FormLayoutEg
    ''7/5/2019 td''Private mod_print As New ciLayoutPrintLib.LayoutPrint

    Public Shared PathToFolderWithBacks As String ''Added 12/11/2019 td

    Private Shared mod_form As New FormLayoutEg
    Private Shared mod_print As New ciLayoutPrintLib.LayoutPrint
    Private Shared mod_backIndex As Integer ''Added 7/5/2019 td 

    Public Property RecipientID As String ''Added 6/13/2019
    Public Property RecipientName As String ''Added 6/13/2019
    Public Property RecipientPhoto As Image ''Added 6/20/2019

    Public Property RecipientFaceImage As Image ''Added 6/20/2019 td 

    ''Added 7/6/2019 thomas downes
    ''    Width of Badge, in Landscape mode.
    Public Property WidthInPixels_Land As Integer ''Added 7/6/2019 

    Sub New()

        mod_form.PicturePersonLarge.Image = Global.ciLayoutPrintLib.My.Resources.v9_lady

        ''Added 1/12/2020 thomas d.
        If (0 = mod_form.panelLayout.Width) Then
            mod_form.Show()
            mod_form.Visible = False ''User doesn't need to see the form. 
            ''Added 1/12/2020 td 
            If (0 = mod_form.panelLayout.Width) Then
                ''Added 1/12/2020 thomas d.
                Throw New Exception("Stubborn Panel Layout Width..... is still zero.")
            End If ''End of "If (0 = mod_form.panelLayout.Width) Then"
        End If ''End of "If (0 = mod_form.panelLayout.Width) Then"

        With mod_print

            .LabelControlForID = mod_form.LabelRecipientID
            .LabelControlForName = mod_form.labelRecipientName

            .PanelLayout = mod_form.panelLayout

            ''Added 7/6/2019 td
            .PanelLayout.BackgroundImageLayout = Windows.Forms.ImageLayout.Zoom

            ''Added 7/6/2019 thomas downes
            If (0 < WidthInPixels_Land) Then
                .PanelLayout.Width = WidthInPixels_Land

                ''Added 7/7/2019 td
                ''   Let's maintain the shape.
                ''  
                .PanelLayout.Height = CInt(CSng(.PanelLayout.Width) * CILayoutBadge.RatioBadge_HeightToWidth_Land_1)

            End If ''end of " If (0 < WidthInPixels_Land) Then"

            .PictureBoxReview = mod_form.pictureboxReview
            .PictureOfPureWhite = mod_form.picturePureWhite
            .PicturePersonImageLarge = mod_form.PicturePersonLarge
            .PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            ''Added 6/20/2019 thoma downes
            If (Me.RecipientPhoto IsNot Nothing) Then .PicturePersonImageLarge.Image = Me.RecipientPhoto

        End With ''End of "With mod_print"

    End Sub ''End of "With mod_print"

    Public Sub UpdateLabelPositions(par_textPosition As CILayoutText)
        ''
        ''Added 6/27/2019
        ''
        mod_form.labelRecipientName.Top = par_textPosition.TopEdgePositionPixels
        mod_form.labelRecipientName.Left = par_textPosition.LeftEdgePositionPixels

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

        mod_form.labelRecipientName.BackColor = Drawing.Color.FromArgb(intColorInDecimalInteger)

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

    Public Shared Sub RefreshChoiceOfBackground_Last(pboolCantLoadImages As Boolean)
        ''
        ''Added 7/5/2019 td
        ''
        ''7/6 td''Dim boolNoImagesAvailable As Boolean

        Try
            With mod_print
                ''7/6/2019 td''.PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()
                .PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage(pboolCantLoadImages)
            End With ''End of "With mod_print"

            ''Added 7/5/2019 td
            mod_backIndex = BackImageExamples.CurrentIndex

        Catch ex As Exception
            ''Added 7/5/2019 td
            Dim strErrMessage As String
            If (True) Then strErrMessage = ex.Message
        End Try

    End Sub ''End of "Public Shared Sub RefreshChoiceOfBackground_Last"

    Public Shared Sub RefreshChoiceOfBackground_ByIndex(par_intChoice As Integer)
        ''
        ''Added 7/5/2019 td
        ''
        Try
            With mod_print
                ''7/5/2019 td''.PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()
                .PanelLayout.BackgroundImage = BackImageExamples.Item(par_intChoice)
            End With ''End of "With mod_print"

            ''Added 7/5/2019 td
            BackImageExamples.CurrentIndex = par_intChoice
            ''Models.Background.CurrentlySelectedBackIndex = par_intChoice;  //Added 11/2/2021 Thomas Downes 
            mod_backIndex = par_intChoice

        Catch ex As Exception
            ''Added 7/5/2019 td
            Dim strErrMessage As String
            If (True) Then strErrMessage = ex.Message
        End Try

    End Sub ''End of "Public Function RefreshChoiceOfBackground_ByIndex"

    Public Shared Sub RefreshChoiceOfBackground_Next()
        ''
        ''Added 7/5/2019 td
        ''
        Try
            mod_backIndex += 1

            If (mod_backIndex >= BackImageExamples.Count()) Then mod_backIndex = 0

            With mod_print
                .PanelLayout.BackgroundImage = BackImageExamples.Item(mod_backIndex)
            End With ''End of "With mod_print"

        Catch ex As Exception
            ''Added 7/5/2019 td
            Dim strErrMessage As String
            If (True) Then strErrMessage = ex.Message
        End Try

    End Sub ''End of "Public Function RefreshChoiceOfBackground_Next"

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
            .PanelLayout.BackgroundImageLayout = Windows.Forms.ImageLayout.Zoom ''Added 7/6/2019 td

            ''Added 7/6/2019 thomas downes
            ''
            If (0 <> Me.WidthInPixels_Land) Then
                .PanelLayout.Width = Me.WidthInPixels_Land
                ''See above.''.PanelLayout.BackgroundImageLayout = Windows.Forms.ImageLayout.Zoom
                ''
                ''Added 7/7/2019 td
                ''   Let's maintain the shape.
                .PanelLayout.Height = CInt(CSng(.PanelLayout.Width) * CILayoutBadge.RatioBadge_HeightToWidth_Land_1)
            End If ''End of "If (0 <> Me.WidthInPixels_Land) Then"

            .PictureBoxReview = mod_form.pictureboxReview
            .PicturePersonImageLarge = mod_form.PicturePersonLarge
            .PictureOfPureWhite = mod_form.picturePureWhite
            .PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            .PicturePersonImageLarge.Image = par_portraitpic

            ''Added 7/5/2019 td
            ''Try
            ''    .PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()
            ''Catch ex As Exception
            ''    ''Added 7/5/2019 td
            ''    Dim strErrMessage As String
            ''    If (True) Then strErrMessage = ex.Message
            ''End Try

            ''6/20/2019 td''Return .GenerateBuildImage()
            Return .GenerateBuildImage_Master(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

        End With ''End of "With mod_print"

    End Function ''End of "Public Function GenerateImage()"

    Public Function GenerateImage_BackgroundOnly(Optional pboolLargeLandscape As Boolean = False,
                                                Optional pboolSmallLandscape As Boolean = False,
                                                 Optional ByRef pboolNoImagesLoaded As Boolean = False) As Image
        ''
        ''Added 6/28/2019 thomas downes  
        ''
        Dim imageDummy As Image = Nothing ''Added 6/20/2019 thomas downes 

        With mod_print

            ''6/28/2019 td''.RecipientID = par_RecipientID
            ''6/28/2019 td''.RecipientName = par_RecipientName
            ''6/28/2019 td''.RecipientPic = par_portraitpic ''Added 6/20/2019 td  

            .PanelLayout = mod_form.panelLayout
            .PanelLayout.BackgroundImageLayout = Windows.Forms.ImageLayout.Zoom ''Added 7/6/2019 td

            ''Added 7/6/2019 thomas downes
            ''
            If (0 <> Me.WidthInPixels_Land) Then
                .PanelLayout.Width = Me.WidthInPixels_Land
                ''See above.''.PanelLayout.BackgroundImageLayout = Windows.Forms.ImageLayout.Zoom

                ''Added 7/7/2019 td
                ''   Let's maintain the shape.
                ''
                .PanelLayout.Height = CInt(CSng(.PanelLayout.Width) * CILayoutBadge.RatioBadge_HeightToWidth_Land_1)

            End If ''End of "If (0 <> Me.WidthInPixels_Land) Then"

            ''added 12/11/2019
            BackImageExamples.PathToFolderWithBacks = LayoutExample.PathToFolderWithBacks

            ''Added 7/5/2019 td
            ''7/6/2019 td''.PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage()
            ''7/6/2019 td''.PanelLayout.BackgroundImage = BackImageExamples.GetLatestImage(pboolNoImagesLoaded)
            .PanelLayout.BackgroundImage = BackImageExamples.GetCurrentImage(pboolNoImagesLoaded)

            ''Added 1/11/2020 td
            If (.PanelLayout.Width = 0) Then Throw New Exception("Error, unluckily Panel Layout has zero width.")
            If (.PanelLayout.Height = 0) Then Throw New Exception("Error, unluckily Panel Layout has zero height.")

            ''Added 7/6/2019 td
            If (pboolNoImagesLoaded) Then Return Nothing ''Exit Function

            ''6/28/2019 td''.PictureBoxReview = mod_form.pictureboxReview
            ''6/28/2019 td''.PicturePersonImageLarge = mod_form.PicturePersonLarge
            ''6/28/2019 td''.PictureOfPureWhite = mod_form.picturePureWhite
            ''6/28/2019 td''.PicturePersonWithinLayout = mod_form.PicturePersonInLayout

            ''.PicturePersonImageLarge.Image = par_portraitpic

            ''6/20/2019 td''Return .GenerateBuildImage()
            ''6/28/2019 td''Return .GenerateBuildImage(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

            ''#1 7/6/2019 td''Return .GenerateBuildImage_BackgroundOnly(imageDummy, pboolLargeLandscape, pboolSmallLandscape)
            '' #2 7/6/2019 td''Return .GenBackgroundOnly_CropIt(imageDummy, pboolLargeLandscape, pboolSmallLandscape)
            Return .GenBackgroundOnly_Zoom(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

        End With ''End of "With mod_print"

    End Function ''End of "Public Function GenerateImage()"

End Class ''End of Class LayoutExample
