Option Explicit On
Option Strict On

Imports __RSCWindowsControlLibrary ''Added 1/3/2022 thomas downes
Imports ciBadgeDesigner ''Added 1/3/2022 thomas downes
''Imports ciBadgeInterfaces ''Added 1/3/2022 thomas downes

Public Class FormTestQRCode
    ''
    ''Added 1/3/2022 td
    ''
    Private mod_iControlLastTouched As ILastControlTouched ''Added 12/28/2021 td
    Private mod_objControlLastTouched As New ClassLastControlTouched ''ILastControlTouched ''Added 12/29/2021 td
    Private mod_designer As New ClassDesigner()

    ''Private CtlQrcode1 As CtlGraphicQRCode
    ''Private RSCMoveable1 As RSCMoveableControlVB


    Private Sub FormTestQRCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/2/2022 thomas downes
        ''
        mod_iControlLastTouched = mod_objControlLastTouched

        ''Encapsulated 1/3/2022 thomas downes
        Load_Controls()

    End Sub


    Private Sub Load_Controls()
        ''
        ''Encapsulated 1/3/2022 td
        ''
        ''Jan3 2022 td''Dim CtlQrcode1 As CtlGraphicQRCode
        Dim elementQR As New ciBadgeElements.ClassElementQRCode()

        ''----CtlQrcode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, True,
        ''     mod_iControlLastTouched)

        CtlQRCode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, False,
                                                mod_iControlLastTouched)
        ''CtlQrcode1.Visible = True
        With CtlQRCode1
            .Visible = True
            .Width = (3 * .Height)
            .Top = 10  ''CInt(0.7 * .Width) ''2 * .Width
            .AddMoveability()
        End With
        Me.Controls.Add(CtlQRCode1)


        ''
        ''Added 1/2/2022 thomas downes
        ''
        ''1/3/2022 td''Dim RSCMoveable1 As RSCMoveableControlVB
        ''Dim elementQR As New ciBadgeElements.ClassElementQRCode()
        ''CtlQrcode1 = CtlGraphicQRCode.GetQRCode(elementQR, "CtlQrcode1", mod_designer, True,
        ''     mod_iControlLastTouched)
        RscMoveableControlVB1 = RSCMoveableControlVB.GetControl(Module1Enumerations.EnumElementType.Field,
                                                       "CtlQrcode1",
                                                       mod_designer, False,
                                                       mod_iControlLastTouched)
        ''CtlQrcode1.Visible = True
        With RscMoveableControlVB1
            .Visible = True
            .Width = (3 * .Height)
            .Left = .Width
            .Top = .Height  ''CInt(0.7 * .Width) ''2 * .Width
            .AddMoveability()
        End With
        Me.Controls.Add(RscMoveableControlVB1)


    End Sub
End Class