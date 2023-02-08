Imports System.Drawing ''Added 12/8/2021 thomas downes
''
''Added 12/8/2021 thomas downes  
''

Public Interface IElementGraphic ''Dec.8 2021''InterfaceElementGraphic
    ''
    ''Added 12/8/2021 thomas downes  
    ''
    ''This Interface is for static graphic images.  The graphic image 
    ''   does not change, it's static, across all Recipients belonging 
    ''   to the Personality. 
    ''
    ''Examples...... a logo.
    ''
    ''            Or maybe an small photograph of a building.  
    ''
    ''
    '' Oops! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Property GraphicImageName As String
    Property GraphicImage As Image
    Property GraphicImageFullPath As String ''Added 1/22/2022 td

    Property BackgroundIsTransparent As Boolean ''Added 12/8/2021  

    Sub LoadGraphicImage() ''Added 12/8/2021 Thomas Downes 

End Interface
