Option Explicit On
Option Infer Off
Option Strict On

''
''Added 7/18/2019 Thomas DOWNES
''
Imports MoveAndResizeControls_Monem
''9/9/2019 td''Imports ControlManager
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d.  
''10/3/2019 td''Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 
''10/3/2019 td''Imports System.Collections.Generic ''Added 9.6.2019 td
Imports ciBadgeFields ''Added 9/18/2019 td 
Imports ciBadgeElements ''Added 9/18/2019 td
Imports ciBadgeDesigner ''Added 10/3/2019 td
Imports ciBadgeRecipients ''Added 10/11/2019 thomas d.  
Imports ciBadgeCustomer ''Added 10/11/2019 thomas d.  

Public Class FormDesignProtoTwo
    ''10/3/2019 td''Implements ILayoutFunctions ''-----, ISelectingElements, ILayoutFunctions
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    Public Property PersonalityCache As ciBadgeCustomer.PersonalityCache ''Added 10/11/2019 td 

    ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Saved As New ClassElementsCache ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache ''Added 9/16/2019 thomas downes

    Private mod_designer As New ciBadgeDesigner.ClassDesigner ''Added 10/3/2019 td

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(mod_designer) ''8/4/2019 td''New ClassGroupMove

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    Private Const mc_boolBreakpoints As Boolean = True

    ''Added 8/18/2019 td
    Private mod_imageLady As Image ''8/18/2019 td'' = CtlGraphicPortrait_Lady.picturePortrait.Image
    Private mod_imageSignature As Image ''Added 10/12/2019 td

    ''Added 9/8/2019 td
    '' #2 10/3/2019 td''Private mod_rubberbandClass As ClassRubberbandSelector

    ''Added 9/20/2019 td  
    '' #2 10/3/2019 td''Private mod_listOfFieldControls As New List(Of CtlGraphicFldLabel)

    ''Private mod_generator As LayoutElementGenerator

    ''Private mod_Pic As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Logo As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_NameFull As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_RecipientID As IElement ''Added 7/18/2019 thomas downes 

    ''Private mod_Text1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Text2 As IElement
    ''Private mod_Text3 As IElement
    ''Private mod_Text4 As IElement
    ''Private mod_Text5 As IElement
    ''Private mod_Text6 As IElement
    ''Private mod_Text7 As IElement
    ''Private mod_Text8 As IElement

    ''Private mod_Date1 As IElement ''Added 7/18/2019 thomas downes 
    ''Private mod_Date2 As IElement
    ''Private mod_Date3 As IElement

    Private vbCrLf_Deux As String = (vbCrLf & vbCrLf) ''Added 7/31/2019 td 

    ''Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
    ''    ''Added 9/3/2019 thomas downes
    ''    Return pictureBack.Width
    ''End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    ''Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
    ''    ''Added 9/11/2019 Never Forget 
    ''    Return pictureBack.Height
    ''End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    ''Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsLeft - pictureBack.Left)
    ''End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    ''Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsLeft + pictureBack.Left)
    ''End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    ''Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsTop - pictureBack.Top)
    ''End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    ''Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsTop + pictureBack.Top)
    ''End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"

    ''Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
    ''    ''
    ''    ''Added 8/14/2019 td 
    ''    ''
    ''    ''OkayToShowFauxContextMenu()
    ''    Return DemoModeActiveToolStripMenuItem.Checked
    ''
    ''End Function ''End of "Public Function OkayToShowFauxContextMenu() As Boolean"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ''Added 10/12/2019 td
        CtlGraphicText1.LayoutFunctions = CType(mod_designer, ILayoutFunctions)

        ''Added 10/12/2019 td
        With CtlGraphicSignature1

            If (.ElementClass_Obj Is Nothing) Then
                ''.ElementClass_Obj = New ClassElementSignature
                ''.ElementInfo_Base = .ElementClass_Obj
                ''.ElementInfo_Sig = .ElementClass_Obj

                If (Me.ElementsCache_Edits.MissingTheSignature()) Then
                    ''
                    ''Major call!!
                    ''
                    Me.ElementsCache_Edits.LoadElement_Signature(0, 0,
                                CtlGraphicSignature1.Width,
                                CtlGraphicSignature1.Height,
                                pictureBack)
                End If ''End of "If (Me.ElementsCache_Edits.MissingTheSignature()) Then"

                .ElementClass_Obj = Me.ElementsCache_Edits.ElementSignature

            End If ''End of "If (.ElementClass_Obj Is Nothing) Then"

            ''
            ''Set the path to the Signature File. 
            ''
            .ElementClass_Obj.SigFilePath = DiskFiles.PathToFile_Sig()

        End With ''End of "With CtlGraphicSignature1"

    End Sub

    Private Sub FormDesignProtoTwo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/18/2019 thomas downes 
        ''
        ''Moved below.  9/20 td''Initiate_RubberbandSelector() ''Added 9/8/2019 thomas d. 

        ''
        ''Check that the proportions are correct. 
        ''
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(pictureBack)
        ''9/8/2019 td''ClassLabelToImage.Proportions_CorrectWidth(picturePreview)
        ClassLabelToImage.Proportions_FixTheWidth(pictureBack)
        ClassLabelToImage.Proportions_FixTheWidth(picturePreview)

        ''Double-check the proportions are correct. ---9/6/2019 td
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBack, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True)

        ''
        ''I forget, what was this going to do originally?  ---9/6/2019 td
        ''
        ''9/8/2019 td''LoadElementGenerator_NotInUse()

        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel1)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel2)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel3)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel4)
        ''Deleted 9/4/2019 td''Me.Controls.Remove(GraphicFieldLabel5)

        ''7/31/2019 td''Me.Controls.Remove(pictureboxPic) ''Added 7/31/2019 thomas d. 
        mod_imageLady = CtlGraphicPortrait_Lady.Picture_Box.Image
        ''mod_imageSignature = CtlGraphicSignature1.pictureSignature.Image

        ''Added 9/23/2019 td 
        ''
        ''   Save a link to the "CIB Version 9.0 Lady" so that the 
        ''   procedure ciBadgeElemImage.modGenerate's Public Sub PicImage_ByElement 
        ''   can have an image to utilize, instead of requiring that the image
        ''   be passed as an parameter.  ---9/23/2019 td
        ''
        Me.ElementsCache_Saved.Pic_InitialDefault = mod_imageLady
        Me.ElementsCache_Edits.Pic_InitialDefault = mod_imageLady

        ''Added 10/13/2019 thomas d. 
        mod_designer.CtlGraphic_Portrait = CtlGraphicPortrait_Lady
        mod_designer.CtlGraphic_QRCode = CtlGraphicQRCode1
        mod_designer.CtlGraphic_Signat = CtlGraphicSignature1

        Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 
        Me.Controls.Remove(CtlGraphicSignature1) ''Added 10/12/2019 thomas d. 

        ''Added 10/11/2019 thomas downes 
        Me.CtlGraphicText1.LayoutFunctions = CType(mod_designer, ILayoutFunctions)

        ''Encapsulated 7/31/2019 td
        ''
        ''Major call !!
        ''
        ''9/8/2019 td''Load_Form()

        ''Added 10/10/2019 td
        Dim strPathToXML As String = ""
        Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  

        ''Added 10/10/2019 td
        ''10/13/2019 td''strPathToXML = My.Settings.PathToXML_Saved
        strPathToXML = DiskFiles.PathToFile_XML

        If (strPathToXML = "") Then
            boolNewFileXML = True
            ''10/12/2019 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            strPathToXML = DiskFiles.PathToFile_XML
            My.Settings.PathToXML_Saved = strPathToXML
            My.Settings.Save()
        Else
            boolNewFileXML = (Not System.IO.File.Exists(strPathToXML))
        End If ''End of "If (strPathToXML <> "") Then .... Else ..."

        ''Added 10/09/2019 td
        If (strPathToXML <> "") Then
            Me.ElementsCache_Saved.PathToXml_Saved = strPathToXML
        End If ''End of "If (strPathToXML <> "") Then"

        ''
        ''Major call!!
        ''
        If (boolNewFileXML) Then ''Condition added 10/10/2019 td  
            Me.ElementsCache_Saved.LoadFields()
            Me.ElementsCache_Saved.LoadFieldElements(pictureBack)
        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = strPathToXML
            Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)

            ''Added 10/12/2019 td
            Me.ElementsCache_Saved.LinkElementsToFields()

        End If ''End of "If (boolNewFileXML) Then .... Else ..."

        ''Added 9/19/2019 td
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer

        ''Added 9/19/2019 td
        intPicLeft = CtlGraphicPortrait_Lady.Left - pictureBack.Left
        intPicTop = CtlGraphicPortrait_Lady.Top - pictureBack.Top
        intPicWidth = CtlGraphicPortrait_Lady.Width
        intPicHeight = CtlGraphicPortrait_Lady.Height

        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
        If (boolNewFileXML) Then
            ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
        End If ''End of "If (boolNewFileXML) Then"

        ''Added 9/24/2019 thomas 
        ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()

        With mod_designer

            .ElementsCache_Edits = Me.ElementsCache_Edits ''Added 10/10/2019 td 
            .ElementsCache_Saved = Me.ElementsCache_Saved ''Added 10/10/2019 td 

            .BackgroundBox = Me.pictureBack
            .PreviewBox = Me.picturePreview
            .DesignerForm = Me
            .FlowFieldsNotListed = Me.flowFieldsNotListed
            .CheckboxAutoPreview = Me.checkAutoPreview
            ''10/10/2019 td''.ExamplePortraitImage = mod_imageLady
            .ExampleImage_Portrait = mod_imageLady

            .ExampleImage_Signature = mod_imageSignature ''Added 10/12/2019 td
            .PathToSigFile = DiskFiles.PathToFile_Sig() ''Added 10/12/2019 td

            ''10/1/2019''intPicLeft = CtlGraphicPortrait_Lady.Left - pictureBack.Left
            ''10/1/2019''intPicTop = CtlGraphicPortrait_Lady.Top - pictureBack.Top
            ''10/1/2019''intPicWidth = CtlGraphicPortrait_Lady.Width
            ''10/1/2019''intPicHeight = CtlGraphicPortrait_Lady.Height

            If (boolNewFileXML) Then
                .Initial_Pic_Left = .Layout_Margin_Left_Omit(Me.CtlGraphicPortrait_Lady.Left)
                .Initial_Pic_Top = .Layout_Margin_Top_Omit(Me.CtlGraphicPortrait_Lady.Top)
                .Initial_Pic_Width = Me.CtlGraphicPortrait_Lady.Width
                .Initial_Pic_Height = Me.CtlGraphicPortrait_Lady.Height
            Else
                ''Added for deserialization from a saved XML file. 
                ''  ---10/10/2019 td
                .Initial_Pic_Left = Me.ElementsCache_Edits.PicElement().LeftEdge_Pixels
                .Initial_Pic_Top = Me.ElementsCache_Edits.PicElement().TopEdge_Pixels
                .Initial_Pic_Width = Me.ElementsCache_Edits.PicElement().Width_Pixels
                .Initial_Pic_Height = Me.ElementsCache_Edits.PicElement().Height_Pixels

            End If ''End of "If (boolNewFileXML) Then .... Else ..."

            ''
            ''Major call !!! 
            ''
            .LoadDesigner()

        End With ''ENd of "With mod_designer"

        ''
        ''Major call!!  
        ''
        ''9/17/2019 td''LoadForm_LayoutElements()
        ''9/20/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits)
        ''10/3/2019 td''LoadForm_LayoutElements(Me.ElementsCache_Edits, mod_listOfFieldControls)

        ''Added 9/24/2019 thomas 
        ''9/29/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (My.Application.Info.DirectoryPath & "\Serialization_" & DateTime.Today.ToString("mmm_dd") & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.PicElement().GetType,
        ''                           Me.ElementsCache_Saved.PicElement,
        ''                           False, False)

    End Sub




    Private Sub SaveLayout()
        ''
        ''Added 7/29/2019 td
        ''
        Dim each_graphicalLabel As CtlGraphicFldLabel
        Dim each_portraitLabel As CtlGraphicPortrait ''Added 7/31/2019 td

        ''
        ''Step #1 of 2. 
        ''
        mod_designer.SaveLayout()

        ''For Each each_control As Control In Me.Controls
        ''
        ''    If (TypeOf each_control Is CtlGraphicFldLabel) Then
        ''
        ''        each_graphicalLabel = CType(each_control, CtlGraphicFldLabel)
        ''
        ''        each_graphicalLabel.SaveToModel()
        ''
        ''    ElseIf (TypeOf each_control Is CtlGraphicPortrait) Then
        ''        ''
        ''        ''Added 7/31/2019 thomas downes  
        ''        ''
        ''        each_portraitLabel = CType(each_control, CtlGraphicPortrait)
        ''        each_portraitLabel.SaveToModel()
        ''
        ''    End If ''end of "If (TypeOf each_control Is GraphicFieldLabel) Then .... ElseIf ..."
        ''
        ''Next each_control

        ''
        ''
        ''Step #2 of 3.
        ''
        Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()

        ''
        ''Serialize !!  
        ''
        Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

        With objSerializationClass

            ''.TypeOfObject = (TypeOf List(Of ICIBFieldStandardOrCustom))

            ''10/10/2019 td''SaveFileDialog1.ShowDialog()
            ''10/10/2019 td''.PathToXML = SaveFileDialog1.FileName

            .PathToXML = Me.ElementsCache_Saved.PathToXml_Saved

            ''Added 9/24/2019 thomas 
            .SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

            Const c_SerializeToBinary As Boolean = False ''Added 9/30/2019 td
            If (c_SerializeToBinary) Then _
            .SerializeToBinary(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved)

        End With ''End of "With objSerializationClass"

    End Sub ''End of "PRivate Sub SaveLayout()"  

    ''Private Sub RefreshPreview()
    ''    ''
    ''    ''Added 8/24/2019 td
    ''    ''
    ''    ''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
    ''    ''9/18 td''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
    ''    Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements
    ''
    ''    ''Deprecated. 9/18/2019 td''Dim listOfElementText_Stdrd As List(Of IFieldInfo_ElementPositions)
    ''    ''Deprecated. 9/18/2019 td''Dim listOfElementText_Custom As List(Of IFieldInfo_ElementPositions)
    ''
    ''    Dim listOfTextImages As New List(Of Image) ''Added 8/26/2019 thomas downes 
    ''    Dim listOfElementTextFields As List(Of ClassElementField)
    ''
    ''    ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students
    ''
    ''    ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
    ''    ''      ClassFieldStandard.ListOfFields_Students,
    ''    ''      ClassFieldCustomized.ListOfFields_Students)
    ''
    ''    ''9/4/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
    ''    ''9/4/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()
    ''
    ''    ''Deprecated. 9/18/2019 td''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd(Me.Layout_Width_Pixels())
    ''    ''Deprecated. 9/18/2019 td''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom(Me.Layout_Width_Pixels())
    ''
    ''    listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()
    ''
    ''    ''8/24 td''picturePreview.SizeMode = PictureBoxSizeMode.Zoom
    ''    ''8/24 td''picturePreview.Image = pictureBack.Image
    ''    ''8/24 td''picturePreview.Image = CType(pictureBack.Image.Clone(), Image)
    ''
    ''    Dim obj_image As Image ''Added 8/24 td
    ''    Dim obj_image_clone As Image ''Added 8/24 td
    ''    Dim obj_image_clone_resized As Image ''Added 8/24/2019 td
    ''
    ''    ''Added 9/6/2019 td 
    ''    ClassLabelToImage.ProportionsAreSlightlyOff(pictureBack.Image, True, "Background Image")
    ''
    ''    ''Added 8/24/2019 td
    ''    obj_image = pictureBack.Image
    ''    obj_image_clone = CType(obj_image.Clone(), Image)
    ''
    ''    ''Dim gr_resize As Graphics = New Bitmap(obj_image_clone)
    ''
    ''    ''8/26/2019 td''obj_image_clone_resized = ciLayoutPrintLib.LayoutPrint.ResizeImage_ToHeight(obj_image_clone, True,
    ''    ''8/26/2019 td''      picturePreview.Height)
    ''
    ''    ''Added 8/26/2019 thomas downes
    ''    obj_image_clone_resized =
    ''        LayoutPrint.ResizeBackground_ToFitBox(obj_image, picturePreview, True)
    ''
    ''    ''Added 9/6/2019 td 
    ''    ClassLabelToImage.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")
    ''
    ''    ''
    ''    ''Major call !!
    ''    ''
    ''    ''9/18 td''objPrintLib.LoadImageWithFieldValues(obj_image_clone_resized,
    ''    ''     listOfElementText_Stdrd,
    ''    ''     listOfElementText_Custom,
    ''    ''     listOfTextImages)
    ''    ''9/19 td''objPrintLib.LoadImageWithFieldValues(obj_image_clone_resized,
    ''    ''9/19 td''    listOfElementTextFields,
    ''    ''9/19 td''    listOfTextImages)
    ''    objPrintLibElems.LoadImageWithElements(obj_image_clone_resized,
    ''                                         listOfElementTextFields,
    ''                                         listOfTextImages)
    ''
    ''    ''
    ''    ''Major call, let's show the portrait !!  ---9/9/2019 td  
    ''    ''
    ''    objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
    ''                                      Me.Layout_Width_Pixels(),
    ''                                      obj_image_clone_resized,
    ''                                       CtlGraphicPortrait_Lady.ElementInfo_Base,
    ''                                       CtlGraphicPortrait_Lady.ElementInfo_Pic,
    ''                                      CtlGraphicPortrait_Lady.picturePortrait.Image)
    ''
    ''    ''Added 9/8/2019 td
    ''    Const c_bListEachElementImage As Boolean = False ''Added 9/8/2019 td
    ''    Const c_bTestingReview As Boolean = False ''Added 9/8/2019 td
    ''
    ''    If (c_bListEachElementImage And c_bTestingReview) Then ''Added 9/8/2019 td
    ''        ''Added 8/26/2019 thomas downes  
    ''        Dim frm_ToShow1 As New FormDisplayImageList1(listOfTextImages)
    ''        frm_ToShow1.Show()
    ''
    ''        ''Added 8/27/2019 thomas downes  
    ''        ''9/19 td''Dim frm_ToShow2 As New FormDisplayImageList2(ClassFieldStandard.ListOfFields_Students,
    ''        ''9/19 td''    ClassFieldCustomized.ListOfFields_Students)
    ''
    ''        Dim frm_ToShow2 As New FormDisplayImageList2(listOfElementTextFields)
    ''        frm_ToShow2.Show()
    ''
    ''    End If ''End of "If (c_bHelpProgrammer And c_bTestingReview) Then"
    ''
    ''    ''Added 9/6/2019 td 
    ''    ClassLabelToImage.ProportionsAreSlightlyOff(pictureBack.Image, True, "Clone Resized #1")
    ''
    ''    ''8/26 td''picturePreview.Image = obj_image_clone_resized
    ''    picturePreview.Image = obj_image_clone_resized
    ''    picturePreview.Refresh()
    ''
    ''End Sub ''end of "Private Sub RefreshPreview()"

    Private Sub LoadElementGenerator_NotInUse()
        ''
        ''Added 7/18/2019 
        ''
        ''mod_generator = New LayoutElementGenerator



    End Sub

    ''Private Sub PictureboxPic_Click(sender As Object, e As EventArgs)
    ''End Sub

    ''Private Sub PictureBox10_Click(sender As Object, e As EventArgs)
    ''End Sub

    ''Private Sub GraphicFieldLabel1_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel1.Load
    ''End Sub

    ''Private Sub GraphicFieldLabel4_Load(sender As Object, e As EventArgs) Handles GraphicFieldLabel4.Load
    ''End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FileSaveMenuItem.Click
        ''
        ''Added 7/29/2019 td  
        ''
        ''103/2019 td''SaveLayout()
        mod_designer.SaveLayout()

    End Sub

    Private Sub FormDesignProtoTwo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 7/31/2019 td  
        dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveLayout()

    End Sub

    Private Sub LinkSaveAndRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 7/31/2019 td
        ''
        ''
        ''Step 1 of 3.   Save the user's work. 
        ''
        SaveLayout()

        ''
        ''Step 2 of 3.  Decide the next step. 
        ''
        Const c_boolStartNewWindow As Boolean = False ''9/5 td'' True ''Added 9/3/2019 thomas d. 
        If (c_boolStartNewWindow) Then ''Added 9/3/2019 thomas d. 
            Dim frm_ToShow As New FormDesignProtoTwo()
            frm_ToShow.Show()
            Me.Close()
            Exit Sub
        End If ''End of "If (c_boolStartNewWindow) Then"

        ''
        ''Step 3 of 3.  Refresh the representation of the elements on the form. 
        ''
        RefreshTheSetOfDisplayedElements()

    End Sub

    Private Sub RefreshTheSetOfDisplayedElements()
        ''
        ''Step 1 of 5.   Create a dictionary of elements. 
        ''
        Dim dictonary_elmntInfo_control As New Dictionary(Of IElement_Base, CtlGraphicFldLabel)
        Dim dictonary_field_control As New Dictionary(Of ICIBFieldStandardOrCustom,
            CtlGraphicFldLabel)
        Dim dictonary_elmntObj_control As New Dictionary(Of ClassElementField, CtlGraphicFldLabel) ''Added 9/17/2019 td

        ''
        ''Step 2 of 5.   Refresh the existing controls. 
        ''
        ''Added 7/31/2019 td
        For Each each_control As Control In Me.Controls

            ''9/5 td''If (TypeOf each_control Is CtlGraphicFldLabel) Then Me.Controls.Remove(each_control)
            ''9/5 td''If (TypeOf each_control Is CtlGraphicPortrait) Then Me.Controls.Remove(each_control)

            ''9/5 td''Select Case True
            ''    Case (TypeOf each_control Is CtlGraphicFldLabel)
            ''        each_control.Visible = False
            ''        Me.Controls.Remove(each_control)
            ''    Case (TypeOf each_control Is CtlGraphicPortrait)
            ''        each_control.Visible = False
            ''        Me.Controls.Remove(each_control)
            ''End of 9/5 td''End Select

            ''Added 9/5/2019 td
            If (TypeOf each_control Is CtlGraphicPortrait) Then Continue For

            ''Added 9/5/2019 td
            If (Not (TypeOf each_control Is CtlGraphicFldLabel)) Then Continue For

            ''Added 9/5/2019 td
            Dim each_field_control As CtlGraphicFldLabel = CType(each_control, CtlGraphicFldLabel)
            each_field_control.Refresh_Master()
            each_field_control.Refresh()

            ''Added 9/6/2019 td 
            ''
            ''   Build a dictionary of control-element.
            ''
            dictonary_elmntInfo_control.Add(each_field_control.ElementInfo_Base, each_field_control)
            dictonary_field_control.Add(each_field_control.FieldInfo, each_field_control)

            ''Added 9/17/2019 td
            dictonary_elmntObj_control.Add(each_field_control.ElementClass_Obj, each_field_control)

        Next each_control

        ''
        ''Step 3 of 5.   Make a list of the elements which are not yet populated on the form. 
        ''
        ''Dim list_fieldsNotLoadedYet_Custom As New List(Of ClassFieldCustomized)
        ''Dim list_fieldsNotLoadedYet_Standrd As New List(Of ClassFieldStandard)

        Dim list_fieldsNotLoadedYet_Any As New List(Of ICIBFieldStandardOrCustom)
        Dim list_elementsNotLoadedYet_Any As New List(Of ClassElementField) ''Added 9/17/2019 td  
        Dim boolMissingFromForm As Boolean
        Dim boolNotDisplayed_ButShouldBe As Boolean

        ''
        ''Step #3(a)  List the undisplayed fields.  
        ''
        For Each each_field As ICIBFieldStandardOrCustom In ClassFields.ListAllFields()
            ''
            ''Added 9/6/2019 td
            ''
            boolMissingFromForm = (Not dictonary_field_control.ContainsKey(each_field))

            boolNotDisplayed_ButShouldBe = (boolMissingFromForm And each_field.IsDisplayedOnBadge)

            If (boolNotDisplayed_ButShouldBe) Then
                ''
                ''Add it to a list. 
                ''
                list_fieldsNotLoadedYet_Any.Add(each_field)

            End If ''End of "If (boolNotDisplayed_ButShouldBe) Then"

        Next each_field

        ''
        ''Step #3(b)  List the undisplayed elements.    ---Added 9/17/2019 td
        ''
        For Each each_element As ClassElementField In Me.ElementsCache_Edits.ListFieldElements()
            ''
            ''Added 9/17/2019 td
            ''
            ''9/17/2019 td''boolMissingFromForm = (Not dictonary_elmntInfo_control.ContainsKey(each_element))
            boolMissingFromForm = (Not dictonary_elmntObj_control.ContainsKey(each_element))

            boolNotDisplayed_ButShouldBe = (boolMissingFromForm And each_element.FieldInfo.IsDisplayedOnBadge)

            If (boolNotDisplayed_ButShouldBe) Then
                ''
                ''Add it to a list. 
                ''
                list_elementsNotLoadedYet_Any.Add(each_element)

            End If ''End of "If (boolNotDisplayed_ButShouldBe) Then"

        Next each_element

        ''
        ''Step 4 of 5.   Load the missing elements onto the form, if any.  
        ''
        Dim bSomeDisplayableFldsAreNotLoaded As Boolean

        bSomeDisplayableFldsAreNotLoaded = (0 < list_fieldsNotLoadedYet_Any.Count)

        If (bSomeDisplayableFldsAreNotLoaded) Then
            ''Load the missing elements. 
            ''9/6/2019 td''Load_Fields_ByList(list_elementsNotLoadedYet_Any)
            ''9/17/2019 td''LoadElements_ByListOfFields(list_fieldsNotLoadedYet_Any,
            ''9/17/2019 td''                            True, False, True)
            ''10/3/2019 tdLoadFieldControls_ByListOfElements(list_elementsNotLoadedYet_Any, True, False, True)

            mod_designer.LoadDesigner()

        End If ''End of "If (bSomeDisplayableFieldsAreNotLoaded) Then"

        ''
        ''Step 5 of 5.   Regenerate the form. 
        ''
        ''9/5/2019 td''Me.Refresh()
        Application.DoEvents()

        ''
        ''Step 6 of 6.   Reload the fields onto the form. 
        ''
        ''9/3/2019 td''Load_Form()
        ''9/5/2019 td''LoadElements_Fields_Master(False, False)

    End Sub ''ENd of "Private Sub RefreshTheSetOfDisplayedElements"

    ''Public Sub AutoPreview_IfChecked() Implements ILayoutFunctions.AutoPreview_IfChecked
    ''    ''
    ''    ''Refresh the preview picture box. 
    ''    ''
    ''    If (checkAutoPreview.Checked) Then
    ''        SaveLayout()
    ''        RefreshPreview()
    ''    End If ''End of "If (checkAutoPreview.Checked) Then"

    ''End Sub ''End of  "Private Sub AutoPreview_IfChecked()"

    ''Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent

    ''    ''Added 9/19/2019 td
    ''    Return RightClickMenuParent

    ''End Function

    ''Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
    ''    ''Added 9/19/2019
    ''    Return Me.Name
    ''End Function

    ''Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
    ''    ''Added 9/23/2019
    ''    ''Not needed. ---9/23 td''Me.Invalidate() ''Causes the form to be re-painted.
    ''    ''Not needed. ---9/23 td''Application.DoEvents()
    ''End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    ''Private Sub PictureAdjuster_MouseClick(sender As Object, e As MouseEventArgs) Handles graphicAdjuster.MouseClick
    ''    ''
    ''    ''Added 8/9/2019 thomas downes
    ''    ''
    ''    Dim intX As Integer
    ''    Dim intY As Integer
    ''    Dim objControlToModify As CtlGraphicFldLabel
    ''    Dim intGroupedControlsCount As Integer
    ''    Dim boolGroupedCtls As Boolean

    ''    intX = e.X
    ''    intY = e.Y

    ''    intGroupedControlsCount = mod_selectedCtls.Count
    ''    boolGroupedCtls = (0 < intGroupedControlsCount)

    ''    objControlToModify = mod_FieldControlLastTouched

    ''    Select Case True

    ''        Case ((0 < intX And intX < 45) And (0 < intY And intY < 45))

    ''            objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Left

    ''        Case ((45 < intX And intX < 90) And (45 < intY And intY < 90))

    ''            objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Center

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.TextAlignment = HorizontalAlignment.Right

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            ''objControlToModify.ElementInfo.Fo  ntSize += 1

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            ''objControlToModify.ElementInfo.FontSize -= 1

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            ''objControlToModify.ElementInfo.FontSize -= 1

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''        Case ((90 < intX And intX < 135) And (0 < intY And intY < 180))

    ''            objControlToModify.ElementInfo_Text.FontColor = Color.Lavender

    ''    End Select ''En do f"Select Case True"

    ''End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles picturePreview.Click

    End Sub

    Private Sub DemoModeActiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DemoModeActiveToolStripMenuItem.Click

        ''Added 8/14/2019 td 
        DemoModeActiveToolStripMenuItem.Checked = (Not DemoModeActiveToolStripMenuItem.Checked)

    End Sub

    Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()

        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Custom()
        frm_ToShow.ShowDialog()
        RefreshTheSetOfDisplayedElements()
        pictureBack.SendToBack()

    End Sub

    Private Sub CustomFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomFieldsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''
        Dim frm_ToShow As New ListCustomFieldsFlow()

        ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Custom()
        frm_ToShow.ShowDialog()
        RefreshTheSetOfDisplayedElements()
        pictureBack.SendToBack()

    End Sub

    Private Sub StandardFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardFieldsToolStripMenuItem.Click
        ''
        ''Added 8/19/2019 thomas downes
        '' 
        Dim frm_ToShow As New ListStandardFields()
        frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Standard()
        frm_ToShow.ShowDialog()
        RefreshTheSetOfDisplayedElements()
        pictureBack.SendToBack()

    End Sub

    Private Sub LinkRefreshPreview_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshPreview.LinkClicked
        ''
        ''Added 8/24/2019 thomas downes
        ''
        ClassLabelToImage.Proportions_FixTheWidth(picturePreview)

        ''
        ''Check that the proportions are correct. 
        ''
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBack, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True)

        ''Added 9/8/2019 td
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBack.Image, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview.Image, True)

        ''
        ''Refresh the preview picture box. 
        ''
        ''10/3/2019 td''RefreshPreview()
        mod_designer.RefreshPreview_Redux()

        '''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        ''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        ''Dim listOfElementText_Stdrd As List(Of IElementWithText)
        ''Dim listOfElementText_Custom As List(Of IElementWithText)

        '''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        '''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        '''      ClassFieldStandard.ListOfFields_Students,
        '''      ClassFieldCustomized.ListOfFields_Students)

        ''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        ''picturePreview.SizeMode = PictureBoxSizeMode.Zoom
        ''picturePreview.Image = pictureBack.Image

        ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''                                     listOfElementText_Stdrd,
        ''                                     listOfElementText_Custom)

    End Sub

    Private Sub PictureBack_Click(sender As Object, e As EventArgs) Handles pictureBack.Click

    End Sub

    Private Sub LinkLabelSave1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LinkLabelSave1.LinkClicked,
            LinkLabelSave2.LinkClicked
        ''
        ''Added 9/3/2019 thomas downes
        ''
        ''Step 1 of 3.   Save the user's work. 
        ''
        SaveLayout()

    End Sub

    Private Sub LinkRemoveElements_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRemoveElements.LinkClicked
        ''
        ''Added 9/3/2019 thomas downes
        ''
        Dim each_controlField As CtlGraphicFldLabel
        Dim list_controlFields As New List(Of CtlGraphicFldLabel)

        ''Me.mod_ControlLastTouched = Nothing
        ''Me.mod_ElementLastTouched = Nothing ''9/14 td
        ''Me.mod_FieldControlLastTouched = Nothing
        ''Me.mod_selectedCtls.Clear()

        ''
        ''Part 1 of 2.  Create a list of the controls you want to detach from the form. 
        ''
        For Each each_control As Control In Me.Controls

            If (TypeOf each_control Is CtlGraphicFldLabel) Then

                each_controlField = CType(each_control, CtlGraphicFldLabel)
                ''9/20/2019 td''each_controlField.FormDesigner = Nothing
                each_controlField.LayoutFunctions = Nothing ''Added 9/20/2019 td
                each_controlField.Parent = Nothing
                each_controlField.FieldInfo = Nothing
                each_controlField.ElementInfo_Base = Nothing
                each_controlField.ElementInfo_Text = Nothing

                ''Add it to the list.   (Important!) 
                list_controlFields.Add(each_controlField)

            End If ''End of "If (TypeOf each_control Is CtlGraphicFldLabel) Then"

        Next each_control

        ''
        ''Part 2 of 2.  Detach each listed control from the form. 
        ''
        For Each each_controlField In list_controlFields

            Me.Controls.Remove(each_controlField)

        Next each_controlField

    End Sub

    ''Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) ''9/7/2019 td''Handles linkSaveAndRefresh.LinkClicked
    ''    ''
    ''    ''Added 9/7/2019 thomas d
    ''    ''
    ''    ''9/17/2019 td''Dim field_to_add As ICIBFieldStandardOrCustom
    ''    ''9/17/2019 td''field_to_add = CType(CType(sender, LinkLabel).Tag, ICIBFieldStandardOrCustom)
    ''    ''9/17/2019 td''If (field_to_add Is Nothing) Then Exit Sub
    ''    ''9/17/2019 td''field_to_add.IsDisplayedOnBadge = True
    ''    ''9/17/2019 td''LoadField_JustOne(field_to_add)

    ''    Dim element_to_add As ClassElementField ''Added 9/17/2019 td
    ''    element_to_add = CType(CType(sender, LinkLabel).Tag, ClassElementField)
    ''    If (element_to_add Is Nothing) Then Exit Sub
    ''    element_to_add.FieldInfo.IsDisplayedOnBadge = True
    ''    LoadFieldControl_JustOne(element_to_add) ''Modified 9/17/2019 td

    ''    flowFieldsNotListed.Controls.Remove(CType(sender, LinkLabel))

    ''End Sub ''End of "Private Sub AddField_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)"

    '''
    '''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    '''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    '''
    '''9/8/2019 td''Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    '''9/8/2019 td''Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    '''9/8/2019 td''Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    '''9/8/2019 td''Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    ''Private Sub Layout_MouseDown(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseDown ''----Me.MouseDown
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    mod_rubberbandClass.MouseDown(sender, e)

    ''End Sub

    ''Private Sub Layout_MouseMove(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseMove ''----Me.MouseMove
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    If (mod_rubberbandClass IsNot Nothing) Then
    ''        mod_rubberbandClass.MouseMove(sender, e)
    ''    End If

    ''End Sub

    ''Private Sub Layout_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseUp ''----Me.MouseUp
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    mod_rubberbandClass.MouseUp(sender, e)

    ''End Sub

    ''Private Sub Layout_Paint(sender As Object, e As PaintEventArgs) Handles pictureBack.Paint ''----Me.Paint
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    If (mod_rubberbandClass IsNot Nothing) Then
    ''        mod_rubberbandClass.Paint(sender, e)
    ''    End If ''End of "If (mod_rubberbandClass IsNot Nothing) Then"

    ''End Sub

    Private Sub HighRez_CheckedChanged(sender As Object, e As EventArgs) Handles chkHighResolution.CheckedChanged

        ''Added 9/8/2019 thomas downes
        ClassLabelToImage.UseHighResolutionTips = CType(sender, CheckBox).Checked

    End Sub

    Private mod_DataEntryV9 As Boolean = False ''Added 9/8/2019 thomas downes
    Private Sub ModeV9ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModeV9ToolStripMenuItem.Click
        ''
        ''Added 9/8/2019 td
        ''
        With ModeV9ToolStripMenuItem
            .Checked = (Not .Checked)
            mod_DataEntryV9 = True
        End With ''End of "With ModeV9ToolStripMenuItem"

    End Sub

    Private Sub FileSaveAs_Click(sender As Object, e As EventArgs) Handles FileSaveAsMenuItem.Click
        ''
        ''Added 9/9/2019 thomas downes 
        ''
        Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

        With objSerializationClass

            ''.TypeOfObject = (TypeOf List(Of ICIBFieldStandardOrCustom))

            SaveFileDialog1.ShowDialog()
            .PathToXML = SaveFileDialog1.FileName

            ''Added 9/24/2019 thomas 
            .SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

            Const c_SerializeToBinary As Boolean = False ''Added 9/30/2019 td
            If (c_SerializeToBinary) Then _
            .SerializeToBinary(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved)

        End With ''End of "With objSerializationClass"

    End Sub

    Private Sub LinkCloseSidebar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkCloseSidebar.LinkClicked

        ''Added 9/11/2019 Never forget.
        ''
        flowSidebar.Visible = False

    End Sub

    Private Sub ChkIncludeExampleValues_Click(sender As Object, e As EventArgs) Handles chkIncludeExampleValues.Click
        ''
        ''We have .AutoChecked = False !!   Therefore, please look for Checkbox.Checked = .... below.
        ''    ----9/13/2019 Thomas downes
        ''
        ''Added 9/13/2019 td 
        Dim diag_res As DialogResult ''Added 9/13/2019 td
        Const c_boolCheckBeforeSave As Boolean = False ''Added 9/13/2019 td 

        If (c_boolCheckBeforeSave) Then
            ''Added 9/13/2019 td 
            diag_res = MessageBox.Show("A side effect of this is, your present layout work will be __saved__.", "",
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            If (vbCancel = diag_res) Then Exit Sub
        End If ''Endolf "If (c_boolCheckBeforeSave) Then"

        ''Added 9/13/2019 thomas downes
        chkIncludeExampleValues.Checked = (Not chkIncludeExampleValues.Checked)
        CtlGraphicFldLabel.UseExampleValues = chkIncludeExampleValues.Checked
        SaveLayout()
        RefreshTheSetOfDisplayedElements()

        ''Addded 9/13/2019 td
        ''10/8/2019 td''AutoPreview_IfChecked()
        mod_designer.AutoPreview_IfChecked()

    End Sub

    Private Sub ChkIncludeExampleValues_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludeExampleValues.CheckedChanged
        ''
        ''We have .AutoChecked = False, so please see the Click event.  ----9/13/2019 
        ''
    End Sub

    Private Sub RightClickMenuParent_Click(sender As Object, e As EventArgs) Handles RightClickMenuParent.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

        Static s_strFolder As String
        Dim objCache As ClassElementsCache

        If (String.IsNullOrEmpty(s_strFolder)) Then s_strFolder = My.Application.Info.DirectoryPath

        OpenFileDialog1.InitialDirectory = s_strFolder
        OpenFileDialog1.ShowDialog()

        Dim objDeserial As New ciBadgeSerialize.ClassDeserial

        With objDeserial

            .PathToXML = OpenFileDialog1.FileName

            ''9/30 td''objCache =
            ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

            objCache =
            CType(.DeserializeFromXML(GetType(ClassElementsCache), False), ClassElementsCache)

        End With

        ''
        ''Major call !!  
        ''
        FormMain.OpenElementsCache(objCache)

    End Sub

    Private Sub LinkRevertToLastSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRevertToLastSave.LinkClicked
        ''
        ''Added 10/2/2019 thomas downes
        ''
        Dim intConfirm As DialogResult

        intConfirm = MessageBox.Show("Do you want to undo all of the changes you made " &
                                     " since you last saved?", "",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (intConfirm = DialogResult.Yes) Then

            ''Discard the user's edits.
            Me.ElementsCache_Edits = Nothing

            ''Copy the saved work, to become the new starting point.
            Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()

            ''
            ''Step 3 of 3.  Refresh the representation of the elements on the form. 
            ''
            RefreshTheSetOfDisplayedElements()

        End If ''End of "If (intConfirm = DialogResult.Yes) Then"

    End Sub

    Private Sub ShowBadgeRecipientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowBadgeRecipientsToolStripMenuItem.Click
        ''
        ''Added 10/11/2019 thomas downes
        ''
        Dim list_recips As List(Of ClassRecipient) ''Added 10/11/2019 thomas downes
        Dim each_recip As ClassRecipient ''Added 10/11/2019 thomas downes

        With flowSidebar

            .Width = 200
            .Visible = True
            .Controls.Clear()

            list_recips = Me.PersonalityCache.ListOfRecipients

            For Each each_recip In list_recips



            Next each_recip

        End With


    End Sub ''End of "Private Sub ShowBadgeRecipientsToolStripMenuItem_Click"

End Class