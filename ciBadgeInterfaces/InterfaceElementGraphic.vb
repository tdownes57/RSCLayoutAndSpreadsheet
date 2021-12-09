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
    Property GraphicImageName As Image
    Property GraphicImage As Image

    Property BackgroundIsTransparent As Boolean ''Added 12/8/2021  

    Sub LoadGraphicImage() ''Added 12/8/2021 Thomas Downes 

End Interface
