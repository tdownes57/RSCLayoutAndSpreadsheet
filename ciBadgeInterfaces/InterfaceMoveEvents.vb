''
''Added 1/3/2022 thomas downes 
''
Imports System.Windows.Forms

Public Interface InterfaceMoveEvents
    ''
    ''Added 1/3/2022 thomas downes 
    ''
    ''void GroupMove_Change(int DeltaLeft, int DeltaTop, int DeltaWidth, int DeltaHeight);
    ''void ControlBeingMoved(Control par_control);
    ''void Resizing_Initiate();
    ''void Resizing_Terminate(ISaveToModel par_iSave);
    ''void Moving_Terminate(Control par_control, ISaveToModel par_iSave); //Modified 12/17/2021 //Added 9/13/2019 td 
    ''void Control_IsMoving();

    ''
    '' Well done! Interfaces should not contain properties, but rather methods.
    '' ---2/07/2023 tcd
    ''
    Sub GroupMove_Change(DeltaLeft As Integer, DeltaTop As Integer,
                         DeltaWidth As Integer, DeltaHeight As Integer,
                         pbEditedLocationAlready As Boolean)
    Sub ControlBeingMoved(par_control As Control)
    Sub Resizing_Initiate()

    Sub Resizing_TerminateV1(par_iSave As ISaveToModel) ''// Suffixed w/ V1 On 1/26/2022

    ''Added 1/26/2022 td
    ''6/6/2022 Sub Resizing_TerminateV2(par_iSave As ISaveToModel,
    ''                       par_iRefreshImage As IRefreshElementImage,
    ''                       par_iRefreshPreview As IRefreshCardPreview)
    Sub Resizing_TerminateV2(par_iSave As ISaveToModel,
                           par_iRefreshImage As IRefreshElementImage,
                           par_iRefreshPreview As IRefreshCardPreview,
                             par_bResizedHeight As Boolean)

    Sub Moving_Terminate(par_control As Control, par_iSave As ISaveToModel) ''//Modified 12/17/2021 
    Sub Control_IsMoving()

    ''Added 8/31/2022 td
    Sub Control_WasClicked(par_control As Control) ''Added 8/31/2022 td

    ''Added 12/24/2022 td
    Sub MouseDown(par_control As Control) ''Added 12/24/2022 td

    ''Added 1/09/2023 td
    Sub MouseUpShiftKey(par_control As Control) ''Added 1/09/2023 td
    Sub MouseUpCtrlKey(par_control As Control) ''Added 1/09/2023 td


End Interface
