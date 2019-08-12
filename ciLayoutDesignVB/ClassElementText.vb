''Added 7/18/2019 thomas downes
Public Class ClassElementText
    Implements IElement_Base, IElementText
    ''
    ''Added 7/18/2019 thomas downes
    ''
    ''
    ''7/29/2019 td''Public Property Info As IElementText

    ''-------------------------------------------------------------

    Public Property Font_AllInfo As System.Drawing.Font Implements IElementText.Font_AllInfo

    Public Property FontColor As System.Drawing.Color Implements IElementText.FontColor

    ''Added 8/12/2019 thomas downes  
    Public Property FontSize As Integer Implements IElementText.FontSize ''Added 8/12/2019 thomas downes  
    Public Property FontBold As Boolean Implements IElementText.FontBold ''Added 8/12/2019 thomas downes  
    Public Property FontItalics As Boolean Implements IElementText.FontItalics ''Added 8/12/2019 thomas downes  
    Public Property FontUnderline As Boolean Implements IElementText.FontUnderline ''Added 8/12/2019 thomas downes  

    Public Property BackColor As System.Drawing.Color Implements IElementText.BackColor

    Public Property FieldInCardData As String Implements IElementText.FieldInCardData

    Public Property FieldLabelCaption As String Implements IElementText.FieldLabelCaption

    ''7/25/2019 td''Prpoerty ExampleText As String ''Added 7/25/2019
    Public Property Text As String Implements IElementText.Text ''E.g. "George Washington" for FullName. 


    Public Property Alignment As System.Windows.Forms.HorizontalAlignment Implements IElementText.Alignment


    Public Property OrientationToLayout As String Implements IElementText.OrientationToLayout ''E.g. "L" (Landscape) (by far the most common) or "P" for Portrait  

    Public Property OrientationInDegrees As Integer Implements IElementText.OrientationInDegrees ''Default is 0, normal.  90 would be 1/4 turn clockwise.  180 is upside-down.  270 is the printing on the spine of a book sitting on the bookshelf.

    Public Property SelectedHighlighting As Boolean Implements IElement_Base.SelectedHighlighting ''Added 8/2/2019 td  


    ''-------------------------------------------------------------
    ''-------------------------------------------------------------
    ''-------------------------------------------------------------

    Public Property FormControl As Control Implements IElement_Base.FormControl ''Added 7/19/2019  

    Public Property ElementType As String Implements IElement_Base.ElementType ''Text, Pic, or Logo

    Public Property LayoutWidth As Integer Implements IElement_Base.LayoutWidth_Pixels ''This provides sizing context & scaling factors. 

    Public Property TopEdge_Pixels As Integer Implements IElement_Base.TopEdge_Pixels
    Public Property LeftEdge_Pixels As Integer Implements IElement_Base.LeftEdge_Pixels

    Public Property Width_Pixels As Integer Implements IElement_Base.Width_Pixels
    Public Property Height_Pixels As Integer Implements IElement_Base.Height_Pixels

    Public Property Border_Pixels As Integer Implements IElement_Base.Border_Pixels
    Public Property Border_Color As System.Drawing.Color Implements IElement_Base.Border_Color

    Public Property Back_Color As System.Drawing.Color Implements IElement_Base.Back_Color

    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub

    Public Sub New()
        ''
        ''Added 7/29/2019 td
        ''

    End Sub

End Class
