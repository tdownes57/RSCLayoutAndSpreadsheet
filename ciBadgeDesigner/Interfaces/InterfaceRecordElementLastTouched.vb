﻿Option Explicit On ''Added 12/17/2021 thomas d
Option Strict On ''Added 12/17/2021 thomas d
''
''Added 12/17/2021 thomas d
''
Imports System.Windows.Forms ''Added 12/17/2021 td 
Imports ciBadgeInterfaces ''Added 12/17/2021 td

Public Interface IRecordElementLastTouched
    ''
    ''Added 12/17/2021 thomas d
    ''
    ''
    '' Well done!! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Sub RecordElementLastTouched(par_elementMoved As IMoveableElement,
                                 par_elementClicked As IClickableElement)

    ''Jan10 2022 td''Sub Remove_Moveability(par_elementMoved As IMoveableElement)
    ''Jan10 2022 td''Sub Remove_Clickability(par_elementClicked As IClickableElement)

    ''''Added 12/17/2021 td''Sub Add_Moveability(par_elementMoved As IMoveableElement)
    ''''Dec23 2021 ''Sub Add_Moveability(par_control As Control, par_iSave As ISaveToModel, par_elementMoved As IMoveableElement)

    ''Jan10 2022 td''Sub Add_Moveability(par_control As Control, par_iSave As ISaveToModel, par_elementMoved As IMoveableElement, par_resizeProportionally As Boolean)

    ''Jan10 2022 td''Sub Add_Clickability(par_elementClicked As IClickableElement)


End Interface
