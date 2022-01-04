Option Explicit On
Option Strict On

Imports __RSCWindowsControlLibrary ''Added 1/3/2022 thomas downes
Imports ciBadgeDesigner ''Added 1/3/2022 thomas downes
Imports ciBadgeInterfaces ''Added 1/3/2022 thomas downes

Public Class FormTestQRCode
    ''
    ''Added 1/3/2022 td
    ''
    Private mod_iControlLastTouched As ILastControlTouched ''Added 12/28/2021 td
    Private mod_objControlLastTouched As New ClassLastControlTouched ''ILastControlTouched ''Added 12/29/2021 td
    Private mod_designer As New ClassDesigner()
    Private mod_oGroupMoveEvents As New GroupMoveEvents_Singleton(mod_designer, False)

    Private CtlQrcode_Runtime As CtlGraphicQRCode
    Private RSCMoveable_Runtime As RSCMoveableControlVB


    Private Sub FormTestQRCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/2/2022 thomas downes
        ''
        mod_iControlLastTouched = mod_objControlLastTouched

        ''Added 1/3/2022 thomas downes
        Const c_unloadDesignTime As Boolean = False
        If (c_unloadDesignTime) Then Unload_DesignTimeControls()
        If (Not c_unloadDesignTime) Then RscMoveableControlVB1.LastControlTouched_Info = mod_iControlLastTouched
        If (Not c_unloadDesignTime) Then SimpleChildOfRSCControl1.LastControlTouched_Info = mod_iControlLastTouched

        ''Encapsulated 1/3/2022 thomas downes
        Load_RunTimeControls()

    End Sub


    Private Sub Unload_DesignTimeControls()
        ''
        ''Added 1/3/2022 td
        ''
        CtlQRCode1.Dispose()
        Me.Controls.Remove(CtlQRCode1)

        RscMoveableControlVB1.Dispose()
        Me.Controls.Remove(RscMoveableControlVB1)

        Me.Refresh()

    End Sub




    Private Sub Load_RunTimeControls()
        ''
        ''Encapsulated 1/3/2022 td
        ''
        ''Jan3 2022 td''Dim CtlQrcode1 As CtlGraphicQRCode
        Dim elementQR As New ciBadgeElements.ClassElementQRCode()

        ''----CtlQrcode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, True,
        ''     mod_iControlLastTouched)

        CtlQrcode_Runtime = CtlGraphicQRCode.GetQRCode(elementQR,
                                                       "CtlQrcode_Runtime", mod_designer, False,
                                                mod_iControlLastTouched, mod_oGroupMoveEvents)
        ''CtlQrcode1.Visible = True
        With CtlQrcode_Runtime
            .Visible = True
            .BackColor = Color.Gray
            .Width = (3 * .Height)
            .Top = 10  ''CInt(0.7 * .Width) ''2 * .Width
            ''Jan4 2022 td''.AddMoveability()
            .AddMoveability(mod_oGroupMoveEvents, mod_designer)
        End With
        Me.Controls.Add(CtlQrcode_Runtime)


        ''
        ''Added 1/2/2022 thomas downes
        ''
        ''1/3/2022 td''Dim RSCMoveable1 As RSCMoveableControlVB
        ''Dim elementQR As New ciBadgeElements.ClassElementQRCode()
        ''CtlQrcode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, True,
        ''     mod_iControlLastTouched)
        RSCMoveable_Runtime = RSCMoveableControlVB.GetControl(Module1Enumerations.EnumElementType.Field,
                                                       "RscMoveable_Runtime",
                                                       mod_designer, False,
                                                       mod_iControlLastTouched,
                                                       mod_oGroupMoveEvents)

        ''CtlQrcode1.Visible = True
        With RSCMoveable_Runtime
            .Visible = True
            .BackColor = Color.Black
            .Width = (3 * .Height)
            .Left = .Width
            .Top = .Height  ''CInt(0.7 * .Width) ''2 * .Width
            ''Jan4 2022 td''.AddMoveability()
            .AddMoveability(mod_oGroupMoveEvents, mod_designer)
        End With ''End of "With RSCMoveable_Runtime"
        Me.Controls.Add(RSCMoveable_Runtime)


    End Sub
End Class