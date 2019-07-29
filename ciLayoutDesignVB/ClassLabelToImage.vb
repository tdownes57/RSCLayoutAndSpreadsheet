Option Explicit On ''Added 7/17/2019
Option Strict On ''Added 7/17/2019

''
''Added 7/17/2019
''
Imports System.Drawing.Image ''Added 7/17/2019

Public Class ClassLabelToImage
    ''
    ''Added 7/17/2019
    ''
    Public Function TextImage(par_design As IElementText, par_element As IElement) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''




        Return Nothing

    End Function ''End of "Public Function TextImage(par_label As Label) As Image"

    Private Sub ApplyTextToImage(ByRef par_image As Image)
        ''
        ''Added 5/7/2019 td  
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)
        gr = Graphics.FromImage(par_image)

        ''
        ''Resizing Images in VB.NET
        ''  https://stackoverflow.com/questions/2144592/resizing-images-in-vb-net
        ''

        ''gr.DrawString("Drawing text",
        ''              New Font("Tahoma", 14),
        ''              New SolidBrush(Color.Green),
        ''              10, 10)

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, Me.LabelControlForID)

        gr.DrawString("Person " & Me.RecipientID,
                      New Font("Tahoma", Me.LabelControlForID.Font.SizeInPoints),
                      New SolidBrush(Me.LabelControlForID.ForeColor),
                       Me.LabelControlForID.Left, Me.LabelControlForID.Top)

        ''Draw white space so that the text can be read more easily. 
        ApplyWhiteSpaceToImage(par_image, LabelControlForName)

        gr.DrawString(Me.RecipientName,
                      New Font("Tahoma", Me.LabelControlForName.Font.SizeInPoints),
                      New SolidBrush(Me.LabelControlForName.ForeColor),
                       Me.LabelControlForName.Left, Me.LabelControlForName.Top)

        gr.Dispose()

    End Sub ''End of ""Private Sub ApplyTextToImage(ByRef par_image As Image)

    Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByVal par_textboxOrLabel As Control)
        ''
        ''Added 5/10/2019 td  
        ''
        ''    https://docs.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawimage?view=netframework-4.8
        ''
        Dim gr As Graphics ''= Graphics.FromImage(img)

        ''Added 6/28/2019 td
        Me.PictureOfPureWhite.BackColor = CType((New System.Drawing.ColorConverter()).ConvertFromString("#000000"), Color)

        gr = Graphics.FromImage(par_image)

        With par_textboxOrLabel
            gr.DrawImage(Me.PictureOfPureWhite.Image, .Left, .Top, .Width, .Height)
        End With

        gr.Dispose()

    End Sub ''ENd of "Private Sub ApplyWhiteSpaceToImage(ByRef par_image As Image, ByRef par_textboxOrLabel As Control)"


    Public Function MakeImage_FromLabel(par_label As Label) As Image
        ''
        ''Added 7/17/2019 thomas downes
        ''




        Return Nothing

    End Function ''End of "Public Function MakeImage(par_label As Label) As Image"

End Class
