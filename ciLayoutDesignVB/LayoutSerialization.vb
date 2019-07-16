Option Explicit On
Option Strict On

''
''Added 7/15/2019 thomas downes  
''

Public Class LayoutSerialization
    ''
    ''Added 7/15/2019 thomas downes
    ''
    ''   Copy the elements of the layout to a class which is not a Windows Form
    ''   but which will act as a "container" for the layout-relevant Windows controls.
    ''
    ''   The container class will have Serialize and Deserialize commands. 
    ''
    ''
    Public BadgeLayoutWidth As Integer
    Public BadgeLayoutHeight As Integer

    Public LandscapeOrPortrait As String

    Public PicImage1 As PictureBox
    Public PicImage2 As PictureBox

    Public NameFirst As Label
    Public NameLast As Label
    Public NameMiddle As Label
    Public NameFullDisplayed As Label

    Public TextField01 As Label
    Public TextField02 As Label
    Public TextField03 As Label
    Public TextField04 As Label
    Public TextField05 As Label
    Public TextField06 As Label

    Public DateField01 As Label
    Public DateField02 As Label
    Public DateField03 As Label
    Public DateField04 As Label
    Public DateField05 As Label
    Public DateField06 As Label



End Class
