''
''Added 1/4/2022 thomas d. 
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces

Public Class FormTestQRCode2

    Private mod_designer As New ClassDesigner()
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(mod_designer)
    Private mod_ctlLasttouched As New ClassLastControlTouched

    Private Sub FormTestQRCode2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/4/2022 thomas d. 
        ''
        Dim propRSC As ProportionalRSCControl

        mod_designer.BadgeLayout_Class = New BadgeLayoutClass()

        mod_designer.BackgroundBox_Front = PictureBox_BadgeFront
        mod_designer.BackgroundBox_Backside = PictureBox_BadgeFront

        InstantiateQRCode()
        InstantiateSignature()

    End Sub


    Private Sub InstantiateQRCode()
        ''
        ''Added 1/4/2022 td 
        ''
        Dim ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
        Dim objElement As New ciBadgeElements.ClassElementQRCode

        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ctlQRCode = CtlGraphicQRCode.GetQRCode(objElement, "ctlQRCode",
          mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton)

        ctlQRCode.Visible = True
        Me.Controls.Add(ctlQRCode)

        PictureBox_BadgeFront.SendToBack()

    End Sub


    Private Sub InstantiateSignature()
        ''
        ''Added 1/4/2022 td 
        ''
        Dim ctlSignat As ciBadgeDesigner.CtlGraphicSignature
        Dim objElement As New ciBadgeElements.ClassElementSignature

        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ctlSignat = CtlGraphicSignature.GetSignature(objElement, "ctlSignat",
          mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
          DiskFilesVB.PathToFile_Sig())

        ctlSignat.Visible = True
        Me.Controls.Add(ctlSignat)

        PictureBox_BadgeFront.SendToBack()

    End Sub



End Class