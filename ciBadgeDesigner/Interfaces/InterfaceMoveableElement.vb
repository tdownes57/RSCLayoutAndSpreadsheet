Option Explicit On ''Added 12/17/2021 thomas d
Option Strict On ''Added 12/17/2021 thomas d

Imports System.Windows.Forms ''Added 12/17/2021 td 

Public Interface IMoveableElement
    ''
    ''Added 12/17/2021 thomas d
    ''
    ''
    '' Well done!! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Sub EnableDragAndDrop_Moveable()

    Sub DisableDragAndDrop_Unmoveable()

    Function GetPictureBox() As PictureBox ''Added 12/17/2021 thomas d

    Sub DeleteIfConfirmed() ''Added 8/15/2022 Thomas Downes


End Interface
