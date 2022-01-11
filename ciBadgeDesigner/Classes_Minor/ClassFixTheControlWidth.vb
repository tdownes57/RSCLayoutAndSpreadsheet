Option Explicit On ''Added 7/17/2019
Option Strict On ''Added 7/17/2019

''
''Added 7/17/2019
''
Imports System.Drawing.Image ''Added 7/17/2019
Imports System.Drawing.Text ''Added 7/30/2019
Imports System.Drawing ''Added 7/30/2019 td 
Imports System.Windows.Forms ''Added 10/1/2019 td
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 
Imports ciBadgeElements ''Added 10/1/2019 td 
Imports ciBadgeGenerator ''Added 10/5/2019 td  

''Public Enum EnumImageOrControl
''    Undetermined
''    Image
''    Contl
''End Enum

Public Class ClassFixTheControlWidth
    ''
    ''Created 10/5/2019 td  
    ''

    Public Shared Sub Proportions_FixTheWidth(par_control As Control)
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        If (par_control Is Nothing) Then Return  ''Don't try to fix the width of a null-reference control. ---1/10/2022 td

        par_control.Width = CInt(par_control.Height * LongSideToShortRatio())

    End Sub ''End of "Public Shared Sub Proportions_FixTheWidth(par_control As Control)"


    Public Shared Function LongSideToShortRatio() As Double
        ''
        ''Added 8/26/2019 thomas downes
        ''
        ''The website 
        ''   https://tinyurl.com/yyqyosz3    
        ''    (  https://www.identicard.com/store/id-card-and-credentials/standard-id-cards/pvc-and-composite-id-cards-for-custom-id-badges ) 
        ''
        ''says
        ''
        ''    We offer PVC cards in several different sizes and thickness levels, but the most common PVC ID card size
        ''       is CR80/credit card size (2.13" x 3.38").
        ''
        ''My measurements of the PVC card on my desk is:
        ''
        ''       2 1/8 inches by 3 3/8 inches, 
        ''
        ''      or  17/8 inches by  27/8 inches
        ''
        '' and so leads me to the ratio of 27 to 17.  
        ''
        ''   ------8/26/2019 td 
        ''
        Return (27 / 17) ''Approx. 1.588, or  3.38 / 2.13 

    End Function ''eDN OF "Public Shared Function LongSideToShortRatio() As Double"

    Public Shared Function ProportionsAreSlightlyOff(par_image As Image, pboolVerbose As Boolean,
                                                     Optional par_strNameOfImage As String = "") As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        If (par_image Is Nothing) Then Return False ''Added 12/2/2021 td

        doubleW_div_H = (par_image.Width / par_image.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)
        ''10/5/2019 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Image, par_strNameOfImage)

        Return ClassProportions.ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose,
                                            EnumImageOrControl.Image, par_strNameOfImage)

    End Function ''End of "Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ProportionsAreSlightlyOff(par_control As Control, pboolVerbose As Boolean,
                                                     Optional par_strNameOfImage As String = "") As Boolean
        ''10/9/2019 td''Public Shared Function ProportionsAreSlightlyOff(par_control As Control, pboolVerbose As Boolean) As Boolean
        ''
        ''Added 9/5/2019 thomas downes  
        ''
        Dim doubleW_div_H As Double

        If (par_control Is Nothing) Then Return False ''Leave the function if there is a Null reference. ---Added 12/2/2021 td

        doubleW_div_H = (par_control.Width / par_control.Height)

        ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_control.Name)
        ''10/5/2019 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Contl, par_control.Name)

        ''10/9/2019 td''Return ClassProportions.ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose,
        ''10/9/2019 td''    EnumImageOrControl.Contl, par_control.Name)

        If ("" = par_strNameOfImage) Then par_strNameOfImage = par_control.Name

        Return ClassProportions.ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose,
                      EnumImageOrControl.Contl, par_strNameOfImage)

    End Function ''End of "Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double) As Boolean"

    Public Shared Function ImageSizeDiffersFromControl(par_control As Control, par_image As Image,
                                                             pboolVerbose As Boolean) As Boolean
        ''
        ''Added 10/9/2019 thomas downes  
        ''
        Dim boolDifferentSize_Width As Boolean
        Dim boolDifferentSize_Height As Boolean
        Dim boolDifferentSize As Boolean

        boolDifferentSize_Width = (Math.Abs(par_control.Width - par_image.Width) > 3)
        boolDifferentSize_Height = (Math.Abs(par_control.Width - par_image.Width) > 3)
        boolDifferentSize = (boolDifferentSize_Height Or boolDifferentSize_Width)

        If (boolDifferentSize) Then
            Throw New Exception($"Uh-oh, the size of control {par_control.Name} differ from the image.")
        End If ''End of "If (boolDifferentSize) Then"

        Return boolDifferentSize

    End Function ''End of "Public Shared Function ImageSizeDiffersFromControl(par_control As Control, par_image As Image, ....) As Boolean"

End Class
