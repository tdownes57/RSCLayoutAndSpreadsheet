''
''Added 12/30/2021 
''
Imports ciBadgeInterfaces ''Added 1/24/2022 td
Imports ciBadgeDesigner ''Added 1/24/2022 td
Imports ciBadgeElements
Imports ciBadgeCachePersonality ''Added 1/24/2022 td
Imports __RSCWindowsControlLibrary ''Added 1/24/2022 thomas d.

Public MustInherit Class Operations__Graphic
    Inherits Operations__Base

    ''
    ''Added 12/30/2021 
    ''
    ''Added keyword "MustInherit" on 1/21/2022, so that I could have the 
    ''  Public Property Element_Type have the same keyword ("MustInherit")
    ''  (which in turn caused the Class itself to require the same keyword).
    ''   ----1/21/2022 td
    ''

    Public Sub Remove_Proportional_Sizing_SG1001(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        MyBase.Monem_iMoveOrResizeFun.RemoveProportionality = True

    End Sub

    Public Sub Restore_Proportional_Sizing_SG1002(sender As Object, e As EventArgs)
        ''
        ''Added 2/02/2022 thomas downes
        ''         
        If (MyBase.Monem_iMoveOrResizeFun IsNot Nothing) Then
            ''Added 2/02/2022 thomas downes
            MyBase.Monem_iMoveOrResizeFun.RemoveProportionality = False
        End If ''End of "If (MyBase.Monem_iMoveOrResizeFun IsNot Nothing) Then"

    End Sub




End Class
