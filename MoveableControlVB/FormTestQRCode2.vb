''
''Added 1/4/2022 thomas d. 
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces

Public Class FormTestQRCode2

    Private mod_designer As New ClassDesigner()
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(mod_designer)
    Private mod_ctlLasttouched As New ClassLastControlTouched

    Private mod_ctlSignat As ciBadgeDesigner.CtlGraphicSignature
    Private mod_ctlPropRSC As ProportionalRSCControl

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
        InstantiateRSC_Proportional()
        InstantiateRSC_SimpleChild2()

    End Sub


    Private Sub InstantiateQRCode()
        ''
        ''Added 1/4/2022 td 
        ''
        Dim ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
        Dim objElement As New ciBadgeElements.ClassElementQRCode

        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        ctlQRCode = CtlGraphicQRCode.GetQRCode(objGetParametersForGetControl, objElement,
                                               Me, "ctlQRCode", mod_designer, True,
                                               mod_ctlLasttouched, mod_eventsSingleton)

        ctlQRCode.Visible = True
        Me.Controls.Add(ctlQRCode)

        PictureBox_BadgeFront.SendToBack()

    End Sub


    Private Sub InstantiateSignature()
        ''
        ''Added 1/4/2022 td 
        ''
        ''Dim ctlSignat As ciBadgeDesigner.CtlGraphicSignature
        Dim objElement As New ciBadgeElements.ClassElementSignature

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        mod_ctlSignat = CtlGraphicSignature.GetSignature(objGetParametersForGetControl,
                                                         objElement, Me, "ctlSignat",
                                                          mod_designer, True, mod_ctlLasttouched,
                                                          mod_eventsSingleton,
                                                          DiskFilesVB.PathToFile_Sig())

        mod_ctlSignat.Visible = True
        Me.Controls.Add(mod_ctlSignat)

        PictureBox_BadgeFront.SendToBack()

    End Sub ''End of "Private Sub InstantiateSignature()"


    Private Sub InstantiateRSC_Proportional()
        ''
        ''Added 1/4/2022 td
        ''
        Dim ctlPropRSC As ProportionalRSCControl

        mod_ctlPropRSC = ProportionalRSCControl.GetRSCControl(mod_designer,
                                                          mod_eventsSingleton,
                                                          mod_ctlLasttouched)
        mod_ctlPropRSC.Visible = True
        mod_ctlPropRSC.Left = mod_ctlSignat.Width
        Me.Controls.Add(mod_ctlPropRSC)
        PictureBox_BadgeFront.SendToBack()

    End Sub


    Private Sub InstantiateRSC_SimpleChild2()
        ''
        ''Added 1/4/2022 td
        ''
        Dim ctlSimple2RSC As SimpleChildOfRSCControl2

        ctlSimple2RSC = SimpleChildOfRSCControl2.GetRSCControl(mod_designer,
                                                          mod_eventsSingleton,
                                                          mod_ctlLasttouched)
        ctlSimple2RSC.Visible = True
        ctlSimple2RSC.Left = mod_ctlSignat.Width
        ctlSimple2RSC.Top = mod_ctlPropRSC.Height
        Me.Controls.Add(ctlSimple2RSC)
        PictureBox_BadgeFront.SendToBack()

    End Sub

End Class