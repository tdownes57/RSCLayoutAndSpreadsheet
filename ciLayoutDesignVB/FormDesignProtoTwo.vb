''
''Added 7/18/2019 Thomas DOWNES
''

Public Class FormDesignProtoTwo
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''

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
        LoadElements



    End Sub

    Private Sub LoadElements()
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        mod_Pic = New ClassElementPic

        mod_RecipientID = New ClassElementText
        mod_NameFull = New ClassElementText

        mod_Text1 = New ClassElementText
        mod_Text2 = New ClassElementText


    End Sub ''End of ''Private Sub LoadElements()''

End Class