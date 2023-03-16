''
''Added 1/6/2022 thomas d. 
''
Imports ciBadgeDesigner
Imports ciBadgeInterfaces
Imports ciBadgeCachePersonality ''Added 1/7/2022 td

Public Class FormFieldsAndPortrait
    Implements IDesignerForm ''Added 1/07/2021 td 

    Private WithEvents mod_toolstripItem As ToolStripItem ''Added 1/17/2022 td
    Private WithEvents mod_linkLabel As LinkLabel ''Added 1/18/2022 td

    Public Sub ShowForm() Implements IDesignerForm.ShowForm

        ''Added 1/15/2022 td
        Me.Show()

    End Sub

    Public Sub ShowForm_AsDialog() Implements IDesignerForm.ShowForm_AsDialog

        ''Added 1/15/2022 td
        Me.ShowDialog()

    End Sub


    Public Property MyPictureBackgroundFront As PictureBox Implements IDesignerForm.MyPictureBackgroundFront
        ''Added 1/15/2022
        Get
            Return pictureBackgroundFront
        End Get
        Set(value As PictureBox)
            pictureBackgroundFront = value
        End Set
    End Property


    Public Property MyText As String Implements IDesignerForm.MyText
        ''Added 1/15/2022
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property


    Public Property ElementsCache_ManageBoth As ClassCacheManagement Implements IDesignerForm.ElementsCache_ManageBoth ''Added 1/07/2022
    Public Property ElementsCache_Edits As ClassElementsCache_Deprecated Implements IDesignerForm.ElementsCache_Edits ''Added 1/07/2022 td 

    ''12/2022 Public Property PersonalityCache_Recipients As ClassCacheOnePersonalityConfig Implements IDesignerForm.PersonalityCache_Recipients
    Public Property PersonalityCache_Recipients As CachePersnltyCnfgLRecips Implements IDesignerForm.PersonalityCache_Recipients

    Public Property NewFileXML As Boolean Implements IDesignerForm.NewFileXML    ''Added 1/7/2022 
    Public Property LetsRefresh_CloseForm As Boolean Implements IDesignerForm.LetsRefresh_CloseForm  ''Added 1/07/2021 td  
    Public Property ElementsCache_PathToXML As String Implements IDesignerForm.ElementsCache_PathToXML   ''Added 1/7/2022 

    ''Jan7 2022 ''Private mod_designer As New ClassDesigner()
    Private mod_designer As ClassDesigner ''Added 1/7/2022
    Private mod_eventsSingleton As GroupMoveEvents_Singleton ''(mod_designer)
    Private mod_ctlLasttouched As New ClassLastControlTouched
    ''Deprecated.  Private mod_iRecordElementLastTouched As ClassRecordElementLastTouched

    Private mod_ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
    Private mod_ctlField1_V3 As ciBadgeDesigner.CtlGraphicFieldV3
    Private mod_ctlField1_V4 As ciBadgeDesigner.CtlGraphicFieldV4 ''Added 12/25/2022 td

    Private mod_ctlField2_V3 As ciBadgeDesigner.CtlGraphicFieldV3
    Private mod_ctlField2_V4 As ciBadgeDesigner.CtlGraphicFieldV4 ''Added 12/25/2022 td

    Private mod_ctlPortrait As ciBadgeDesigner.CtlGraphicPortrait
    Private mod_ctlStaticGraphic As ciBadgeDesigner.CtlGraphicStaticGraphic
    Private mod_ctlStaticText As ciBadgeDesigner.CtlGraphicStaticTextV3

    ''12/2022 Public Property BadgeLayout As BadgeLayoutClass Implements IDesignerForm.BadgeLayout
    Public Property BadgeLayout As BadgeLayoutDimensionsClass Implements IDesignerForm.BadgeLayout

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
        ''12/2022 Me.BadgeLayout = New BadgeLayoutClass
        Me.BadgeLayout = New BadgeLayoutDimensionsClass
        Me.BadgeLayout.Height_Pixels = pictureBackgroundFront.Height
        Me.BadgeLayout.Width_Pixels = pictureBackgroundFront.Width

        ''Added 1/9/2022 td
        Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, False, Me.ElementsCache_PathToXML) ''Added 12/14/2021 thomas d

        mod_designer = New ClassDesigner() ''Added 1/7/2022 td
        mod_designer.DesignerForm = Me ''Added 1/10/2022 td 
        mod_designer.ElementsCache_UseEdits = Me.ElementsCache_Edits
        mod_designer.ElementsCache_Manager = Me.ElementsCache_ManageBoth
        ''12/2022 mod_designer.BadgeLayout_Class = New BadgeLayoutClass()
        mod_designer.BadgeLayout_Class = New BadgeLayoutDimensionsClass()
        mod_designer.BackgroundBox_Front = pictureBackgroundFront
        mod_designer.BackgroundBox_Backside = pictureBackgroundFront
        ''1/21/2022''mod_designer.BackgroundBox_JustAButton = pictureJustAButton

        ''Added 1/10/2022 td
        mod_eventsSingleton = New GroupMoveEvents_Singleton(mod_designer)

        ''May not be needed. 1/10/2022 td''mod_designer.LoadDesigner("FormFieldsAndPortrait_Load", mod_eventsSingleton)

        ''
        ''Major call!!   Instantiate element controls. 
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

        ''Added 1/8/2022 thomas downes
        InstantiateStaticText()
        InstantiateStaticGraph()

        ''Added 1/15/2022 thomas downes
        RscClickableDesktop1.InitializeClickability(Me, FlowLayoutPanelForContextLinks)

    End Sub ''End of "Private Sub InstantiateElementControls()"


    Private Sub InstantiateQRCode()
        ''
        ''Added 1/4/2022 td 
        ''
        ''Dim ctlQRCode As ciBadgeDesigner.CtlGraphicQRCode
        Dim objElement As New ciBadgeElements.ClassElementQRCode
        Dim bHandleMouseEventsThroughFormVB6 As Boolean ''Added 1/7/2022 td
        Dim sizeSuggested As Size ''Added 3/10/2022 

        ''12/2022 objElement.BadgeLayout = mod_designer.BadgeLayout_Class
        objElement.BadgeLayoutDims = mod_designer.BadgeLayout_Class

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        ''Added 1/7/2022
        bHandleMouseEventsThroughFormVB6 = RadioEventHandlersHookedThruForm.Checked ''Added 1/7/2022

        ''Added 3/10/2022 td
        sizeSuggested.Width = CInt(Me.Width / 6) '' (.Width / 8)
        sizeSuggested.Height = CInt(Me.Width / 6) ''Same as .Width property setting, just above. ''----sizeSuggested.Width  

        ''
        ''Added 1/7/2022 Thomas DOWNES
        ''
        mod_ctlQRCode = CtlGraphicQRCode.GetQRCode(objGetParametersForGetControl,
                                                   objElement, Me, "ctlQRCode",
          mod_designer, sizeSuggested, True, mod_ctlLasttouched, mod_eventsSingleton,
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
        Dim objElement As New ciBadgeElements.ClassElementPortrait
        ''12/2022 objElement.BadgeLayout = mod_designer.BadgeLayout_Class
        objElement.BadgeLayoutDims = mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        mod_ctlPortrait = CtlGraphicPortrait.GetPortrait(objGetParametersForGetControl,
                                                         objElement, Me, "mod_ctlPortrait",
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
        Dim objElementV3 As ciBadgeElements.ClassElementFieldV3
        Dim objElementV4 As ciBadgeElements.ClassElementFieldV4 ''Added 12/25/2022

        ''Added 1/07/2022 td
        objElementV3 = mod_designer.ElementsCache_UseEdits.ListFieldElementsV3().FirstOrDefault()
        objElementV4 = mod_designer.ElementsCache_UseEdits.ListFieldElementsV4().FirstOrDefault()

        ''12/2022 objElement.BadgeLayout = Me.BadgeLayout ''mod_designer.BadgeLayout_Class
        objElementV3.BadgeLayoutDims = Me.BadgeLayout ''mod_designer.BadgeLayout_Class
        objElementV4.BadgeLayoutDims = Me.BadgeLayout ''mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        Dim sizeSuggested As Size ''Added 3/10/2022
        sizeSuggested = New Size(Me.Width / 4, Me.Height / 10) ''Added 3/10/2022

        ''12/25/2022 mod_ctlField1_V3 = CtlGraphicFieldV3.GetFieldElement(objGetParametersForGetControl,
        ''                                                    objElement, Me, mod_designer,
        ''                                    "mod_ctlField1", mod_designer, sizeSuggested, mod_designer,
        ''                                    mod_ctlLasttouched, mod_eventsSingleton)
        ''mod_ctlField1_V3.Visible = True
        ''mod_ctlField1_V3.Top = mod_ctlField1_V3.Width

        mod_ctlField1_V4 = CtlGraphicFieldV4.GetFieldControl(objGetParametersForGetControl,
                                                            objElementV4, Me, mod_designer,
                                            "mod_ctlField1", mod_designer, sizeSuggested, mod_designer,
                                            mod_ctlLasttouched, mod_eventsSingleton)

        mod_ctlField1_V4.Visible = True
        mod_ctlField1_V4.Top = mod_ctlField1_V4.Width

        ''12/2022 Dim intHeightPixels As Integer = objElement.BadgeLayout.Height_Pixels
        Dim intHeightPixels As Integer = objElementV4.BadgeLayoutDims.Height_Pixels

        ''12/25/2022 Me.Controls.Add(mod_ctlField1)
        Me.Controls.Add(mod_ctlField1_V4)
        pictureBackgroundFront.SendToBack()

        ''
        ''Major call !!  ----Thomas DOWNES
        ''
        ''12/25/2022 mod_ctlField1.Refresh_Master() ''Added 1/6/2022 td 
        ''12/25/2022 mod_ctlField1.Refresh() ''Added 1/6/2022 & 11/29/2021 td  
        mod_ctlField1_V4.Refresh_Master() ''Added 1/6/2022 td 
        mod_ctlField1_V4.Refresh() ''Added 1/6/2022 & 11/29/2021 td  


    End Sub


    Private Sub InstantiateStaticGraph()
        ''
        ''Added 1/6/2022 td 
        ''
        Dim objElement As New ciBadgeElements.ClassElementGraphic
        ''12/2022 objElement.BadgeLayout = mod_designer.BadgeLayout_Class
        objElement.BadgeLayoutDims = mod_designer.BadgeLayout_Class

        ''Added 1/9/2022 td
        If (0 = ElementsCache_Edits.ListOfElementGraphics_Front.Count) Then
            ElementsCache_Edits.ListOfElementGraphics_Front.Add(objElement)
            ElementsCache_ManageBoth.Save(True)
        End If ''End of "If (0 = ElementsCache_Edits.ListOfElementGraphics_Front.Count) Then"

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        Const c_bUseMonemProportionalClass As Boolean = True ''Added 1/10/2022 td

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        ''Added 3/10/2022 td
        Dim sizeSuggested As Size ''Added 3/10/2022
        sizeSuggested.Width = CInt(Me.Width / 3) '' (.Width / 3)
        sizeSuggested.Height = CInt(Me.Height / 6) ''Same as .Width property setting, just above. ''----sizeSuggested.Width  

        mod_ctlStaticGraphic = CtlGraphicStaticGraphic.GetStaticGraphic(objGetParametersForGetControl,
                objElement, Me, "mod_ctlStaticGraphic", mod_designer, sizeSuggested, True,
                mod_ctlLasttouched, mod_eventsSingleton, c_bUseMonemProportionalClass)

        mod_ctlStaticGraphic.Visible = True
        mod_ctlStaticGraphic.Width = (5 * mod_ctlStaticGraphic.Height) ''Added 1/08/2022 td
        mod_ctlStaticGraphic.Left = mod_ctlQRCode.Width
        mod_ctlStaticGraphic.Top = mod_ctlQRCode.Height
        Me.Controls.Add(mod_ctlStaticGraphic)

        pictureBackgroundFront.SendToBack()

    End Sub ''End of Private sub InstantiateStaticGraphic() 


    Private Sub InstantiateStaticText()
        ''
        ''Added 1/6/2022 td 
        ''
        Dim objElement As New ciBadgeElements.ClassElementStaticTextV3
        ''12/2022 objElement.BadgeLayout = mod_designer.BadgeLayout_Class
        objElement.BadgeLayoutDims = mod_designer.BadgeLayout_Class

        ''mod_ctlPortrait = CtlGraphicSignature.GetSignature(objElement, "ctlSignature",
        ''  mod_designer, True, mod_ctlLasttouched, mod_eventsSingleton,
        ''  DiskFilesVB.PathToFile_Sig())

        ''Added 1/17/2022 td
        Dim objGetParametersForGetControl As ciBadgeDesigner.ClassGetElementControlParams
        objGetParametersForGetControl = mod_designer.GetParametersToGetElementControl()

        ''Added 3/10/2022 td
        Dim sizeSuggested As Size
        sizeSuggested.Width = CInt(Me.Width / 6) '' (.Width / 8)
        sizeSuggested.Height = CInt(Me.Height / 10) ''----sizeSuggested.Width  

        mod_ctlStaticText = CtlGraphicStaticTextV3.GetStaticText(objGetParametersForGetControl,
                                                         objElement, Me, "mod_ctlStaticText",
          mod_designer, sizeSuggested, mod_designer, mod_ctlLasttouched, mod_eventsSingleton)

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
        ''3/16/2023 mod_ctlField1.Dispose()
        ''3/16/2023 mod_ctlField1_V3.Dispose()
        mod_ctlField1_V3.Dispose()
        mod_ctlField1_V4.Dispose()
        mod_ctlField2_V3.Dispose()
        mod_ctlField2_V4.Dispose()
        mod_ctlPortrait.Dispose()
        mod_ctlQRCode.Dispose()

        ''3/16/2023 mod_ctlField1.Visible = False
        mod_ctlField1_V3.Visible = False
        mod_ctlField1_V4.Visible = False
        mod_ctlField2_V3.Visible = False
        mod_ctlField2_V4.Visible = False
        mod_ctlPortrait.Visible = False
        mod_ctlQRCode.Visible = False

        ''3/16/2023 Me.Controls.Remove(mod_ctlField1)
        Me.Controls.Remove(mod_ctlField1_V3)
        Me.Controls.Remove(mod_ctlField1_V4)
        Me.Controls.Remove(mod_ctlField2_V3)
        Me.Controls.Remove(mod_ctlField2_V4)
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

    Private Sub FormFieldsAndPortrait_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        ''
        ''Added 1/15/2022 td
        ''
        RscClickableDesktop1.ClickableDesktop_MouseUp(sender, e)


    End Sub

    Private Sub mod_toolstripItem_MouseUp(sender As Object, e As MouseEventArgs) Handles mod_toolstripItem.MouseUp
        ''
        ''Added for an investigation, 1/17/2022
        ''

    End Sub

    Private Sub mod_toolstripItem_Click(sender As Object, e As EventArgs) Handles mod_toolstripItem.Click
        ''
        ''Added for an investigation, 1/17/2022
        ''
    End Sub

    Private Sub mod_linkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles mod_linkLabel.LinkClicked
        ''
        ''Added for an investigation, 1/17/2022
        ''

    End Sub

    Private Sub mod_linkLabel_MouseClick(sender As Object, e As MouseEventArgs) Handles mod_linkLabel.MouseClick
        ''
        ''Added for an investigation, 1/17/2022
        ''

    End Sub
End Class