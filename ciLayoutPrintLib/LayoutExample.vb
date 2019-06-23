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

            ''6/20/2019 td''Return .GenerateBuildImage()
            Return .GenerateBuildImage(imageDummy, pboolLargeLandscape, pboolSmallLandscape)

        End With ''End of "With mod_print"

    End Function ''End of "Public Function GenerateImage()"

End Class ''End of Class LayoutExample
