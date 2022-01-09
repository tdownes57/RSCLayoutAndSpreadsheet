Option Explicit On ''Added 8/16/2019 td 
Option Strict On ''Added 8/16/2019 td 
''
''Added 7/30/2019 thomas downes
''
Imports ciBadgeInterfaces ''Added 10/1/2019 td  

Partial Public Class CtlGraphicStaticText
    ''
    ''Added 9/3/2019 td
    ''
    ''   This is to store the initial Width & Height, when resizing.
    ''
    ''10/1/2019 td''Public FormDesigner As FormDesignProtoTwo ''Added 8/9/2019 td  
    ''Jan8 2022 td''Public LayoutFunctions As ILayoutFunctions ''Added 10/1/2019 td  

    Public TempResizeInfo_W As Integer = 0 ''Intial resizing width.  (Before any adjustment is made.)
    Public TempResizeInfo_H As Integer = 0 ''Intial resizing height.  (Before any adjustment is made.)

    Public TempResizeInfo_Left As Integer = 0 ''Intial resizing Left.  (Before any adjustment is made.)
    Public TempResizeInfo_Top As Integer = 0 ''Intial resizing Top.  (Before any adjustment is made.)


End Class
