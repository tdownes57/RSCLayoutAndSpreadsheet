''
''Added 12/28/2021 thomas d.
''
Imports ciBadgeDesigner ''Added 12/28 
Imports ciBadgeInterfaces ''Added 12/28/2021 
Imports __RSCWindowsControlLibrary ''Added 12/29/2021 thomas d. 


Public Class FormTestingVB

    Private MenuCache_NonShared_Field As MenuCache_NonShared
    Private MenuCache_NonShared_Portrait As MenuCache_NonShared
    Private MenuCache_NonShared_QRCode As MenuCache_NonShared
    Private MenuCache_NonShared_Signature As MenuCache_NonShared
    Private MenuCache_NonShared_StaticText As MenuCache_NonShared
    Private MenuCache_NonShared_GraphicText As MenuCache_NonShared

    ''Added 12/28/2021 thomas
    Private mod_designer As New ClassDesigner()
    Private moveableControlLizRiley As MoveableControlVB
    Private mod_desktop_RSCClickable As RSCMoveableControlVB ''Added 12/30/2021 td

    Private mod_iControlLastTouched As ILastControlTouched ''Added 12/28/2021 td
    Private mod_objControlLastTouched As ILastControlTouched ''Added 12/29/2021 td

    Private Const mc_bAddMoveabilityWithinConstructor As Boolean = False
    Private Const mc_bAddClickabilityWithinConstructor As Boolean = False
    Private Const mc_bAddMoveabilityAfterConstructor As Boolean = True
    Private Const mc_bAddClickabilityAfterConstructor As Boolean = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/28/2021 thomas d.
        ''
        ''MenuCache_Generic.GenerateMenuItems_IfNeeded() ''Dec28 2021 td'' (Nothing)

        Dim objCtlLastTouched As New ClassLastControlTouched ''Added 12/28/2021 td
        mod_iControlLastTouched = objCtlLastTouched ''Added 12/28/2021 td
        mod_objControlLastTouched = objCtlLastTouched ''Added 12/29/2021 td

        ''''Added 12/28/2021 thomas d.
        ''Dim operationsField As New Operations_Generic ''Operations_Field
        ''Dim operationsPortrait As New Operations_Useless ''Operations_Portrait
        ''Dim operationsQRCode As New Operations_Generic ''Operations_QRCode
        ''Dim operationsSignature As New Operations_Useless ''Operations_Signature
        ''Dim operationsStaticText As New Operations_Generic ''Operations_StaticText
        ''Dim operationsGraphicText As New Operations_Useless ''Operations_GraphicText 

        ''MenuCache_NonShared_Field = New MenuCache_NonShared(EnumElementType.Field,
        ''                                                    operationsField.GetType(),
        ''                                                    operationsField)
        ''MenuCache_NonShared_Portrait = New MenuCache_NonShared(EnumElementType.Portrait,
        ''                                                    operationsPortrait.GetType(),
        ''                                                    operationsPortrait)
        ''MenuCache_NonShared_QRCode = New MenuCache_NonShared(EnumElementType.QRCode,
        ''                                                    operationsQRCode.GetType(),
        ''                                                    operationsQRCode)
        ''MenuCache_NonShared_Signature = New MenuCache_NonShared(EnumElementType.Signature,
        ''                                                    operationsSignature.GetType(),
        ''                                                    operationsSignature)
        ''MenuCache_NonShared_StaticText = New MenuCache_NonShared(EnumElementType.StaticText,
        ''                                                    operationsStaticText.GetType(),
        ''                                                    operationsStaticText)
        ''MenuCache_NonShared_GraphicText = New MenuCache_NonShared(EnumElementType.Signature,
        ''                                                    operationsGraphicText.GetType(),
        ''                                                    operationsGraphicText)

        ''''Added 12/28/2021 td
        ''MoveableControlVB1.MyToolstripItemCollection = MenuCache_NonShared_Field.Tools_EditElementMenu
        ''MoveableControlVB2.MyToolstripItemCollection = MenuCache_NonShared_Portrait.Tools_EditElementMenu


        ''************************************************************************
        ''Created the following Subs
        ''     Step1_Unload_DesignTimeControls()
        ''     Step2a_Load_RuntimeControls_NonProportional()
        ''     Step2b_Load_RuntimeControls_ResizeProportionally()
        ''*************************************************************************

        Step1a_Unload_DesignTimeControls_Moveable()
        Step1b_Unload_DesignTimeControls_RSCMoveable()

        ''
        ''Load the Runtime Controls (MoveableControlVB)
        ''
        Step2a_Load_RuntimeControls_NonProportional_Local()
        Const c_bProportion_False As Boolean = False
        Step2b_Load_RuntimeControls_NonProportional_RSC(c_bProportion_False)
        Step2c_Load_RuntimeControls_ResizeProportionally()


    End Sub ''End of "Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load"


    Private Sub Step1a_Unload_DesignTimeControls_Moveable()
        ''
        ''Encapsulated 12/29/2021 thomas downes
        ''
        MoveableControlVB1.Visible = False
        MoveableControlVB2.Visible = False
        MoveableControlVB3.Visible = False
        MoveableControlVB4.Visible = False

        MoveableControlVB1.Dispose()
        MoveableControlVB2.Dispose()
        MoveableControlVB3.Dispose()
        MoveableControlVB4.Dispose()

        Me.Controls.Remove(MoveableControlVB1)
        Me.Controls.Remove(MoveableControlVB2)
        Me.Controls.Remove(MoveableControlVB3)
        Me.Controls.Remove(MoveableControlVB4)

        MoveableControlVB1 = Nothing
        MoveableControlVB2 = Nothing
        MoveableControlVB3 = Nothing
        MoveableControlVB4 = Nothing

    End Sub ''End of "Private Sub Unload_DesignTimeControls"


    Private Sub Step1b_Unload_DesignTimeControls_RSCMoveable()
        ''
        ''Encapsulated 12/29/2021 thomas downes
        ''
        RscMoveableControlVB1.Visible = False
        RscMoveableControlVB2.Visible = False
        RscMoveableControlVB3.Visible = False
        CtlGraphicQRCode1.Visible = False ''Added Jan2 2022
        CtlGraphicSignature1.Visible = False ''Added Jan2 2022

        RscMoveableControlVB1.Dispose()
        RscMoveableControlVB2.Dispose()
        RscMoveableControlVB3.Dispose()
        CtlGraphicSignature1.Dispose() ''Added Jan2 2022
        CtlGraphicSignature1.Dispose() ''Added Jan2 2022

        Me.Controls.Remove(RscMoveableControlVB1)
        Me.Controls.Remove(RscMoveableControlVB2)
        Me.Controls.Remove(RscMoveableControlVB3)
        Me.Controls.Remove(CtlGraphicQRCode1) ''Added Jan2 2022
        Me.Controls.Remove(CtlGraphicSignature1) ''Added Jan2 2022

        RscMoveableControlVB1 = Nothing
        RscMoveableControlVB2 = Nothing
        RscMoveableControlVB3 = Nothing
        CtlGraphicQRCode1 = Nothing ''Added Jan2 2022
        CtlGraphicSignature1 = Nothing ''Added Jan2 2022

        ''
        ''Clickable desktop....
        ''
        RscClickableDesktop.Visible = False ''12/30/2021
        RscClickableDesktop.Dispose() ''12/30/2021
        Me.Controls.Remove(RscClickableDesktop) ''.Dispose() ''12/30/2021
        RscClickableDesktop = Nothing ''Added 12/30/2021 td

    End Sub ''End of "Private Sub Step1b_Unload_DesignTimeControls_RSCMoveable"



    Private Sub Step2a_Load_RuntimeControls_NonProportional_Local()
        ''
        ''Encapsulated 12/29/2021 thomas downes
        ''
        ''Added 12/28/2021 thomas
        ''Const c_bAddMoveabilityWithinConstructor As Boolean = False
        ''Const c_bAddClickabilityWithinConstructor As Boolean = False
        ''Const c_bAddMoveabilityAfterConstructor As Boolean = True
        ''Const c_bAddClickabilityAfterConstructor As Boolean = True

        Const c_bProportion_False As Boolean = False

        ''Control #1 of 3. 
        ''Jan2 2022''Dim objSaveToModel1 As New ClassSaveToModel
        MoveableControlVB1 = MoveableControlVB.GetControl(EnumElementType.Field,
                                "MoveableControlVB1", c_bProportion_False,
                                mod_designer,
                                mod_iControlLastTouched)
        ''Jan2 2022''          objSaveToModel1, mod_designer,

        MoveableControlVB1.Left = 0
        MoveableControlVB1.Top = 0
        MoveableControlVB1.Visible = True
        MoveableControlVB1.LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/29/2021 td
        Me.Controls.Add(MoveableControlVB1)


        ''Control #2 of 3. 
        ''Jan2 2022 td''Dim objSaveToModel2 As New ClassSaveToModel
        MoveableControlVB2 = MoveableControlVB.GetControl(EnumElementType.Field,
                                "MoveableControlVB2", c_bProportion_False,
                                mod_designer,
                                mod_iControlLastTouched)
        ''Jan2 2022 td''   objSaveToModel2, mod_designer,

        MoveableControlVB2.Left = 0
        MoveableControlVB2.Top = 0
        MoveableControlVB2.Visible = True
        MoveableControlVB2.LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/29/2021 td
        Me.Controls.Add(MoveableControlVB2)


        ''Control #3 of 3. 
        ''Jan2 2022 td''Dim objSaveToModel3 As New ClassSaveToModel
        MoveableControlVB3 = MoveableControlVB.GetControl(EnumElementType.Field,
                                "MoveableControlVB3", c_bProportion_False,
                                mod_designer,
                                mod_iControlLastTouched)
        ''Jan2 2022 td''   objSaveToModel3, mod_designer,

        MoveableControlVB3.Left = 0
        MoveableControlVB3.Top = 0
        MoveableControlVB3.Visible = True
        MoveableControlVB3.LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/29/2021 td
        Me.Controls.Add(MoveableControlVB3)


        ''Dim objOperations1 As New Operations__Useless()
        ''MoveableControlVB1 = New MoveableControlVB(EnumElementType.Undetermined, False,
        ''                                           objSaveToModel1,
        ''                                           CType(mod_designer, ILayoutFunctions),
        ''                                           mod_designer, objOperations1.GetType(),
        ''                                           objOperations1,
        ''                                           mc_bAddMoveabilityWithinConstructor,
        ''                                            mc_bAddClickabilityWithinConstructor,
        ''                                            mod_iControlLastTouched)

        ''objOperations1.CtlCurrentElement = MoveableControlVB1
        ''Moved up.......MoveableControlVB1.Left = 0
        ''Moved up.......MoveableControlVB1.Top = 0
        ''Moved up.......MoveableControlVB1.Visible = True
        ''Moved up.......Me.Controls.Add(MoveableControlVB1)
        ''If (mc_bAddMoveabilityAfterConstructor) Then MoveableControlVB1.AddMoveability()
        ''If (mc_bAddClickabilityAfterConstructor) Then MoveableControlVB1.AddClickability()
        ''MoveableControlVB1.Name = "MoveableControlVB1"

        ''Control #2 of 3. 
        ''Dim objSaveToModel2 As New ClassSaveToModel
        ''Dim objOperations2 As New Operations__Generic()
        ''MoveableControlVB2 = New MoveableControlVB(EnumElementType.Undetermined, False,
        ''                                           objSaveToModel1,
        ''                                           CType(mod_designer, ILayoutFunctions),
        ''                                           mod_designer, objOperations2.GetType(),
        ''                                           objOperations2,
        ''                                            mc_bAddMoveabilityWithinConstructor,
        ''                                            mc_bAddClickabilityWithinConstructor,
        ''                                            mod_iControlLastTouched)

        ''objOperations2.CtlCurrentElement = MoveableControlVB2
        ''MoveableControlVB2.Left = 0
        ''MoveableControlVB2.Top = 10 + (MoveableControlVB1.Top + MoveableControlVB1.Height)
        ''MoveableControlVB2.Visible = True
        ''MoveableControlVB2.LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/29/2021 td
        ''If (mc_bAddMoveabilityAfterConstructor) Then MoveableControlVB2.AddMoveability()
        ''If (mc_bAddClickabilityAfterConstructor) Then MoveableControlVB2.AddClickability()
        ''Me.Controls.Add(MoveableControlVB2)
        ''MoveableControlVB2.Name = "MoveableControlVB2"

        ''Control #3 of 3. 
        ''Dim objSaveToModel3 As New ClassSaveToModel
        ''Dim objOperations3 As New Operations__Useless()
        ''MoveableControlVB3 = New MoveableControlVB(EnumElementType.Undetermined, False,
        ''                                           objSaveToModel3,
        ''                                           CType(mod_designer, ILayoutFunctions),
        ''                                           mod_designer, objOperations3.GetType(),
        ''                                           objOperations3,
        ''                                            mc_bAddMoveabilityWithinConstructor,
        ''                                            mc_bAddClickabilityWithinConstructor,
        ''                                            mod_iControlLastTouched)
        ''objOperations3.CtlCurrentElement = MoveableControlVB3
        ''MoveableControlVB3.Left = 0
        ''MoveableControlVB3.Top = 10 + (MoveableControlVB2.Top + MoveableControlVB2.Height)
        ''MoveableControlVB3.Visible = True
        ''MoveableControlVB3.LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/29/2021 td
        ''If (mc_bAddMoveabilityAfterConstructor) Then MoveableControlVB3.AddMoveability()
        ''If (mc_bAddClickabilityAfterConstructor) Then MoveableControlVB3.AddClickability()
        ''Me.Controls.Add(MoveableControlVB3)
        ''MoveableControlVB3.Name = "MoveableControlVB3"


    End Sub


    Private Sub Step2b_Load_RuntimeControls_NonProportional_RSC(par_proportionSize As Boolean)
        ''
        ''Encapsulated 12/29/2021 thomas downes
        ''
        '' RSC Controls
        ''
        ''
        ''Control #1 of 3. 
        ''Jan2 2022 td''Dim objSaveToModelRSC As New ClassSaveToModel
        Dim RSCMoveableControlVB11 = RSCMoveableControlVB.GetControl(EnumElementType.Field,
                                "RSCMoveableControlVB1", mod_designer, par_proportionSize,
                                mod_iControlLastTouched)

        RSCMoveableControlVB11.Left = RSCMoveableControlVB11.Width
        RSCMoveableControlVB11.Top = 0
        RSCMoveableControlVB11.Visible = True
        Me.Controls.Add(RSCMoveableControlVB11)

        ''
        ''Hidden, for right-clicking the desktop.  
        ''
        ''1/2/2022 td''Dim desktop_objSaveToModelRSC As New ClassSaveToModel
        mod_desktop_RSCClickable = RSCMoveableControlVB.GetControl(EnumElementType.Field,
                                "desktop_RSC_Clickable", mod_designer, par_proportionSize,
                                mod_iControlLastTouched)

        mod_desktop_RSCClickable.Left = 0
        mod_desktop_RSCClickable.Top = 0
        mod_desktop_RSCClickable.Width = 10
        mod_desktop_RSCClickable.Height = 10
        mod_desktop_RSCClickable.Visible = False
        Me.Controls.Add(mod_desktop_RSCClickable)


    End Sub ''End of "Private Sub Step2b_Load_RuntimeControls_NonProportional_RSC()"


    Private Sub Step2c_Load_RuntimeControls_ResizeProportionally()
        ''
        ''Encapsulated 12/29/2021 thomas downes
        ''
        Const c_bResizeProportionally As Boolean = True

        ''
        ''Resize-Proportionally (Per Ratio Width-Height) Control #1 of 2.
        ''
        ''Jan2 2022''Dim objSaveToModel41 As New ClassSaveToModel
        Dim objOperations41 As New Operations__Useless()
        moveableControlLizRiley = New MoveableControlVB(EnumElementType.Undetermined,
                                                         c_bResizeProportionally,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperations41.GetType(),
                                                   objOperations41,
                                                    mc_bAddMoveabilityWithinConstructor,
                                                    mc_bAddClickabilityWithinConstructor,
                                                    mod_iControlLastTouched)

        objOperations41.CtlCurrentElement = moveableControlLizRiley
        With moveableControlLizRiley
            .LastControlTouched_Obj = mod_objControlLastTouched ''Added 12/31/2021 td
            MoveableControlLiz.Visible = False ''Hide the design-time control. 
            .Left = MoveableControlLiz.Left ''0
            .Width = MoveableControlLiz.Width
            .Height = MoveableControlLiz.Height
            ''Dec28 ''.Top = 10 + (MoveableControlVB3.Top + MoveableControlVB3.Height)
            .Top = MoveableControlLiz.Top
            ''Dec29 2021 ''.BackgroundImage = My.Resources.JaneMulvey
            .BackgroundImage = My.Resources.Liz_20_percent
            .BackgroundImageLayout = ImageLayout.Zoom
            Dim singleRatioWtoH As Single
            singleRatioWtoH = CType(.BackgroundImage.Width, Single) / .BackgroundImage.Height
            .Width = (.Height * singleRatioWtoH)
            .Visible = True ''Show the run-time control. 
            If (mc_bAddMoveabilityAfterConstructor) Then .AddMoveability()
            If (mc_bAddClickabilityAfterConstructor) Then .AddClickability()
            .Name = "moveableControlLizRiley"
        End With
        Me.Controls.Add(moveableControlLizRiley)



        ''
        ''Background Image, for the Front of Badge 
        ''
        ''   Resize-Proportionally (Per Ratio Width-Height) Control #1 of 2.
        ''
        Const c_bAddMoveabilityForBackground As Boolean = False ''Added 12/28/2021 td 
        ''1/2 2022 td''Dim objSaveToModelBack As New ClassSaveToModel
        Dim objOperationsBack As New Operations__Useless()
        Me.Controls.Remove(MoveableControlVBBack)
        MoveableControlVBBack.Visible = True
        Dim tempBack As MoveableControlVB = MoveableControlVBBack
        MoveableControlVBBack = New MoveableControlVB(EnumElementType.Undetermined,
                                                      c_bResizeProportionally,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperationsBack.GetType(),
                                                   objOperationsBack,
                                                    c_bAddMoveabilityForBackground,
                                                    mc_bAddClickabilityWithinConstructor,
                                                    mod_iControlLastTouched)
        objOperationsBack.CtlCurrentElement = MoveableControlVBBack
        With MoveableControlVBBack
            .Left = tempBack.Left ''0
            .Width = tempBack.Width
            .Height = tempBack.Height
            ''Dec28 ''.Top = 10 + (MoveableControlVB3.Top + MoveableControlVB3.Height)
            .Top = tempBack.Top
            .BackgroundImage = My.Resources.layout_cyanDiag
            .BackgroundImageLayout = ImageLayout.Zoom
            Dim singleRatioWtoH As Single
            singleRatioWtoH = CType(.BackgroundImage.Width, Single) / .BackgroundImage.Height
            .Width = (.Height * singleRatioWtoH)
            .Visible = True
            If (c_bAddMoveabilityForBackground And mc_bAddMoveabilityAfterConstructor) Then .AddMoveability()
            If (mc_bAddClickabilityAfterConstructor) Then .AddClickability()
            .Name = "MoveableControlVBBack"
        End With
        ''Add it to the form.  
        Me.Controls.Add(MoveableControlVBBack)

        ''
        ''Added 1/2/2022 thomas downes
        ''
        Dim CtlQrcode1 As CtlGraphicQRCode
        Dim elementQR As New ciBadgeElements.ClassElementQRCode()
        CtlQrcode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, True,
                                                mod_iControlLastTouched)
        CtlQrcode1.Visible = True
        Me.Controls.Add(CtlQrcode1)


        ''
        ''Added 1/2/2022 thomas downes
        ''
        Dim CtlSignature1 As CtlGraphicSignature
        Dim elementSig As New ciBadgeElements.ClassElementSignature()
        CtlSignature1 = CtlGraphicSignature.GetSignature(elementSig, "CtlSignature1", mod_designer, True,
                                                mod_iControlLastTouched,
                                                  DiskFilesVB.PathToFile_Sig())
        CtlSignature1.Visible = True
        Me.Controls.Add(CtlSignature1)


    End Sub ''End of "Private Sub Step2c_Load_RuntimeControls_ResizeProportionally"

    Private Sub FormTestingVB_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        ''
        ''Added 12/30/2021 td
        ''
        mod_desktop_RSCClickable.PerformRightClick(e.X, e.Y)


    End Sub
End Class
