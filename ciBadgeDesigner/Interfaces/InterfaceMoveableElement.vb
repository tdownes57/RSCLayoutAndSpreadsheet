Option Explicit On ''Added 12/17/2021 thomas d
Option Strict On ''Added 12/17/2021 thomas d

Imports System.Windows.Forms ''Added 12/17/2021 td 

Public Interface IMoveableElement
    ''
    ''Added 12/17/2021 thomas d
    ''
    Sub EnableDragAndDrop_Moveable()

    Sub DisableDragAndDrop_Unmoveable()

    Function GetPictureBox() As PictureBox ''Added 12/17/2021 thomas d


End Interface
