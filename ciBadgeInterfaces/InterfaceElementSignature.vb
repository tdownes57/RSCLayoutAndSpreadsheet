''
''Added 10/08/2019 & 7/18/2019 Thomas DOWNES
''
''  "Program to the Interface, not the Implementation"  
''     Gang of Four
''      https://www.tutorialspoint.com/design_pattern/design_pattern_overview
''
Imports System.Drawing  ''Added 10/12/2019 td

Public Interface IElementSig
    ''
    ''Sig = Signature, e.g. from a Topaz Signature Pad. 
    ''
    ''Added 10/08/2019 td
    ''
    Property SigFileType As String ''E.g. Image/PNG or Image/BMP 
    Property SigFileTitleExt As String ''E.g. 12345.jpg or 12345.png

    ''Added 8/12/2019 thomas downes  
    Property SigFileIndex As Integer ''Added 8/12/2019 thomas downes
    Property SigFilePath As String ''Added 10/12/2019 thomas downes

    Function GetImage_Signature(pboolRefresh As Boolean,
                                ByRef pref_message As String) As Image ''Added 110/12/2019 td

    Property Recipient As IRecipient ''Added 9/9/2019   

End Interface ''End of "Public Interface IElementSig"




