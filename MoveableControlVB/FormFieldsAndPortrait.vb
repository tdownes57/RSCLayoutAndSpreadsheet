''
''Added 1/6/2022 thomas d. 
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality ''Added 1/7/2022 td

Public Class FormFieldsAndPortrait
    Implements IDesignerForm ''Added 1/07/2021 td 

    Public ElementsCache_ManageBoth As ClassCacheManagement ''Added 1/07/2022
    Public ElementsCache_Edits As ClassElementsCache_Deprecated ''Added 1/07/2022 td 
    Public PersonalityCache_Recipients As ClassCachePersonality
    Public NewFileXML As Boolean ''Added 1/7/2022 
    Public Property LetsRefresh_CloseForm As Boolean ''Added 1/07/2021 td  
    Public ElementsCache_PathToXML As String ''Added 1/7/2022 

    ''Jan7 2022 ''Private mod_designer As New ClassDesigner()
    Private mod_designer As ClassDesigner ''Added 1/7/2022
    Private mod_eventsSingleton As New GroupMoveEvents_Singleton(mod_designer)
    Private mod_ctlLasttouched As New ClassLastControlTouched
    ''Deprecated.  Private mod_iRecordElementLastTouched As ClassRecordElementLastTouched

    Private mod_ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
    Private mod_ctlField1 As ciBadgeDesigner.CtlGraphicFldLabel
    Private mod_ctlField2 As ciBadgeDesigner.CtlGraphicFldLabel
    Private mod_ctlPortrait As ciBadgeDesigner.CtlGraphicPortrait
    Private mod_ctlStaticGraphic As ciBadgeDesigner.CtlGraphicStaticGraphic
    Private mod_ctlStaticText As ciBadgeDesigner.CtlGraphicStaticText

    Public Property BadgeLayout As BadgeLayoutClass Implements IDesignerForm.BadgeLayout
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As BadgeLayoutClass)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated) Implements IDesignerForm.RefreshElementsCache_Saved
        Throw New NotImplementedException()
    End Sub

    Public Sub RefreshPreview() Implements IDesignerForm.RefreshPreview
        Throw New NotImplementedException()
    End Sub

    Private Sub FormFieldsAndPortrait_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 1/4/2022 thomas d. 
        ''
        ''----Dim propRSC As ProportionalRSCControl

        ''Added 1/07/2022 & 10/13/2019 td
        Me.BadgeLayout = New BadgeLayoutClass
        Me.BadgeLayout.Height_Pixels = pictureBackgroundFront.Height
        Me.BadgeLayout.Width_Pixels = pictureBackgroundFront.Width

        mod_designer = New ClassDesigner() ''Added 1/7/2022 td
        mod_designer.ElementsCache_UseEdits = Me.ElementsCache_Edits
        mod_designer.ElementsCache_Manager = Me.ElementsCache_ManageBoth
        mod_designer.BadgeLayout_Class = New BadgeLayoutClass()
        mod_designer.BackgroundBox_Front = pictureBackgroundFront
        mod_designer.BackgroundBox_Backside = pictureBackgroundFront

        ''
        ''Instantiate element controls. 
        ''
        InstantiateElementControls()

    End Sub


    Private Sub InstantiateElementControls()
        ''
        ''Added 1/7/2022 thomas downes
        ''
        InstantiateQRCode()
        InstantiatePortrait()
        InstantiateField1()

    End Sub ''End of "Private Sub InstantiateElementControls()"


    Private Sub InstantiateQRCode()
        ''
        ''Added 1/4/2022 td 
        ''
        ''Dim ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
        Dim objElement As New ciBadgeElements.ClassElementQRCode
        Dim bHandleMouseEventsThroughFormVB6 As Boolean ''Added 1/7/2022 td

        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ''Added 1/7/2022
        bHandleMouseEventsThroughFormVB6 = RadioEventHandlersHookedThruForm.Checked ''Added 1/7/2022

        ''
        ''Added 1/7/2022 Thomas DOWNES
        ''
        mod_ctlQRCode = CtlGraphicQRCode.GetQRCode(objElement, "ctlQRCode",
          mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
          bHandleMouseEventsThroughFormVB6)

        mod_ctlQRCode.Visible = True
        mod_ctlQRCode.Left = 0
        mod_ctlQRCode.Top = 0
        Me.Controls.Add(mod_ctlQRCode)

        pictureBackgroundFront.SendToBack()

    End Sub ''End of "Private Sub InstantiateQRCode()"


    Private Sub InstantiatePortrait()
        ''
        ''Added 1/6/2022 td 
        ''
        Dim objElement As New ciBadgeElements.ClassElementPic
        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        mod_ctlPortrait = CtlGraphicPortrait.GetPortrait(objElement, "mod_ctlPortrait",
          mod_designer, True, mod_ctlLasttouched, mod_designer,
          mod_eventsSingleton)

        mod_ctlPortrait.Visible = True
        mod_ctlPortrait.Left = mod_ctlQRCode.Width
        mod_ctlPortrait.Top = mod_ctlQRCode.Height
        Me.Controls.Add(mod_ctlPortrait)

        pictureBackgroundFront.SendToBack()

    End Sub ''End of Private sub InstantiatePortrait() 


    Private Sub InstantiateField1()
        ''
        ''Added 1/6/2022 td 
        ''
        ''Jan7 2022 td''Dim objElement As New ciBadgeElements.ClassElementField
        Dim objElement As ciBadgeElements.ClassElementField

        ''Added 1/07/2022 td
        objElement = mod_designer.ElementsCache_UseEdits.ListFieldElements().FirstOrDefault()

        objElement.BadgeLayout = Me.BadgeLayout ''mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        mod_ctlField1 = CtlGraphicFldLabel.GetFieldElement(objElement, mod_designer,
                                            "mod_ctlField1", mod_designer, mod_designer,
                                            mod_ctlLasttouched, mod_eventsSingleton)

        mod_ctlField1.Visible = True
        mod_ctlField1.Top = mod_ctlField1.Width
        Dim intHeightPixels As Integer = objElement.BadgeLayout.Height_Pixels
        Me.Controls.Add(mod_ctlField1)
        pictureBackgroundFront.SendToBack()

        ''
        ''Major call !!  ----Thomas DOWNES
        ''
        mod_ctlField1.Refresh_Master() ''Added 1/6/2022 td 
        mod_ctlField1.Refresh() ''Added 1/6/2022 & 11/29/2021 td  


    End Sub


    Private Sub InstantiateStaticGraph()
        ''
        ''Added 1/6/2022 td 
        ''
        Dim objElement As New ciBadgeElements.ClassElementGraphic
        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        mod_ctlStaticGraphic = CtlGraphicStaticGraphic.GetStaticGraphic(objElement, "mod_ctlStaticGraphic", mod_designer, True, mod_ctlLasttouched,
           mod_eventsSingleton)

        mod_ctlStaticGraphic.Visible = True
        mod_ctlStaticGraphic.Left = mod_ctlQRCode.Width
        mod_ctlStaticGraphic.Top = mod_ctlQRCode.Height
        Me.Controls.Add(mod_ctlStaticGraphic)

        pictureBackgroundFront.SendToBack()

    End Sub ''End of Private sub InstantiateStaticGraphic() 


    Private Sub InstantiateStaticText()
        ''
        ''Added 1/6/2022 td 
        ''
        Dim objElement As New ciBadgeElements.ClassElementStaticText
        objElement.BadgeLayout = mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        mod_ctlStaticText = CtlGraphicStaticText.GetQRCode(objElement, "mod_ctlStaticText",
          mod_designer, True, mod_ctlLasttouched, mod_designer,
          mod_eventsSingleton)

        mod_ctlStaticText.Visible = True
        mod_ctlStaticText.Left = mod_ctlQRCode.Width
        mod_ctlStaticText.Top = mod_ctlQRCode.Height
        Me.Controls.Add(mod_ctlStaticText)

        pictureBackgroundFront.SendToBack()

    End Sub ''End of Private sub InstantiateStaticText() 


    Private Sub UnloadTheElementControls()
        ''
        ''Added 1/7/2022 thomas downes 
        ''
        mod_ctlField1.Dispose()
        mod_ctlPortrait.Dispose()
        mod_ctlQRCode.Dispose()

        mod_ctlField1.Visible = False
        mod_ctlPortrait.Visible = False
        mod_ctlQRCode.Visible = False

        Me.Controls.Remove(mod_ctlField1)
        Me.Controls.Remove(mod_ctlPortrait)
        Me.Controls.Remove(mod_ctlQRCode)

    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioEventHandlersHookedThruForm.CheckedChanged



    End Sub

    Private Sub ButtonRefreshTheForm_Click(sender As Object, e As EventArgs) Handles ButtonRefreshTheForm.Click

        ''Added 1/7/2022
        UnloadTheElementControls()
        InstantiateElementControls()


    End Sub
End Class