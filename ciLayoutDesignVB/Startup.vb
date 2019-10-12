Option Explicit On
Option Strict On
Option Infer On
''
''Added 10/11/2019 td  
''
Imports ciBadgeInterfaces ''Added 10/11/2019 thomas d. 

Public Class Startup
    ''
    ''Added 10/11/2019 td  
    ''
    Public Shared Sub Main()
        ''
        ''Added 10/11/2019 td  
        ''

        ''
        ''Initialize a Customer Cache, or at least a Personality Cache.
        ''
        ''   (Or, at the very bare minimum, a Badge Layout Cache.)  
        ''



        ''
        ''
        ''If we are emphasizing Layout Design, then open up the 
        ''   form which currently demostrates Layout Design the best.  
        ''
        ''
        Dim obj_formToShow As New FormDesignProtoTwo ''Added 10/11/2019 td 

        ''Not needed. 10/11/2019 td'obj_formToShow.CtlGraphicText1.LayoutFunctions = CType(obj_formToShow., ILayoutFunctions)

        obj_formToShow.ShowDialog() ''Added 10/11/2019 td 


    End Sub ''End of "Public Sub Main()"



End Class
