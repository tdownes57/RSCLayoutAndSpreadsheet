Option Explicit On
Option Infer On
Option Strict On
''
''Added 7/18/2019 Thomas DOWNES
''
Imports ControlManager

Public Class FormDesignProtoTwo
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    Private mod_generator As LayoutElementGenerator

    Private mod_Pic As IElement ''Added 7/18/2019 thomas downes 
    Private mod_Logo As IElement ''Added 7/18/2019 thomas downes 

    Private mod_NameFull As IElement ''Added 7/18/2019 thomas downes 
    Private mod_RecipientID As IElement ''Added 7/18/2019 thomas downes 

    Private mod_Text1 As IElement ''Added 7/18/2019 thomas downes 
    Private mod_Text2 As IElement
    Private mod_Text3 As IElement
    Private mod_Text4 As IElement
    Private mod_Text5 As IElement
    Private mod_Text6 As IElement
    Private mod_Text7 As IElement
    Private mod_Text8 As IElement

    Private mod_Date1 As IElement ''Added 7/18/2019 thomas downes 
    Private mod_Date2 As IElement
    Private mod_Date3 As IElement

    Private Sub FormDesignProtoTwo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        LoadElementGenerator

        LoadElements()

        MakeElementsMoveable()


    End Sub

    Private Sub MakeElementsMoveable()
        ''
        ''Added 7/19/2019 thomas downes  
        ''

    End Sub

    Private Sub LoadElements()
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        mod_Pic = New ClassElementPic(pictureboxPic)

        mod_RecipientID = mod_generator.GetRecipientID(GraphicFieldLabel1) ''New ClassElementText
        mod_NameFull = mod_generator.GetFullName(GraphicFieldLabel2) ''New ClassElementText

        mod_Text1 = mod_generator.GetTextField1(gr) ''New ClassElementText
        mod_Text2 = mod_generator.GetTextField2(PictureBox13) ''New ClassElementText
        mod_Text3 = mod_generator.GetTextField3(PictureBox14)

        mod_Date1 = mod_generator.GetDateField1(PictureBox15) ''New ClassElementText
        mod_Date2 = mod_generator.GetDateField2(PictureBox16) ''New ClassElementText





    End Sub ''End of ''Private Sub LoadElements()''

    Private Sub LoadElementGenerator()
        ''
        ''Added 7/18/2019 
        ''
        mod_generator = New LayoutElementGenerator



    End Sub

    Private Sub PictureboxPic_Click(sender As Object, e As EventArgs) Handles pictureboxPic.Click

    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GraphicFieldLabel1_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel1.Load

    End Sub

    Private Sub GraphicFieldLabel4_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel4.Load

    End Sub
End Class