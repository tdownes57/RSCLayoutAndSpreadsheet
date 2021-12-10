Option Explicit On
Option Infer Off
Option Strict On

''
''Added 7/18/2019 Thomas DOWNES
''
Imports System.Collections.Generic
Imports System.Linq
Imports ciBadgeCachePersonality ''Added 12/4/2021 thomas downes  
Imports ciBadgeCustomer ''Added 10/11/2019 thomas d.  
Imports ciBadgeDesigner ''Added 10/3/2019 td
Imports ciBadgeElements ''Added 9/18/2019 td
''10/3/2019 td''Imports ciLayoutPrintLib ''Added 8/28/2019 thomas d. 
''10/3/2019 td''Imports System.Collections.Generic ''Added 9.6.2019 td
Imports ciBadgeFields ''Added 9/18/2019 td 
''9/9/2019 td''Imports ControlManager
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d.  
Imports ciBadgeRecipients ''Added 10/11/2019 thomas d.  
Imports EmailingFilesViaGmail_Framework ''Added 9/17/2021 thomas downes 
Imports MoveAndResizeControls_Monem

Public Class Form__Main_Demo
    Implements IDesignerForm ''Added 10/13/2019 td 
    ''10/3/2019 td''Implements ILayoutFunctions ''-----, ISelectingElements, ILayoutFunctions
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    Public Property LetsRefresh_CloseForm As Boolean ''Added 10/13/2019 td  
    Public Property NewFileXML As Boolean ''Added 10/13/2019 td

    ''1/14/2020 td''Public Property PersonalityCache As ciBadgeCustomer.PersonalityCache_NotInUse ''Added 10/11/2019 td 
    ''12/4/2021''Public Property PersonalityCache_Recipients As ciBadgeElements.ClassPersonalityCache ''Added 10/11/2019 td 
    Public Property PersonalityCache_Recipients As ciBadgeCachePersonality.ClassCachePersonality ''Added 10/11/2019 td 
    Public Property BadgeLayout As BadgeLayoutClass Implements IDesignerForm.BadgeLayout ''Added 10/13/2019 td

    ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Saved As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_ManageBoth As ClassCacheManagement ''Added 12/5/2021 thomas downes

    Private WithEvents mod_designer As New ciBadgeDesigner.ClassDesigner ''Added 10/3/2019 td

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(mod_designer) ''8/4/2019 td''New ClassGroupMove

    Private Const mc_boolAllowGroupMovements As Boolean = True ''False ''True ''False ''Added 8/3/2019 td  
    Private Const mc_boolBreakpoints As Boolean = True
    Private mod_boolDebugMode As Boolean = True ''Added 12/6/2021 thomas downes

    ''Added 8/18/2019 td
    Private mod_imageLady As Image ''8/18/2019 td'' = CtlGraphicPortrait_Lady.picturePortrait.Image
    Private mod_imageSignature As Image ''Added 10/12/2019 td

    ''Added 8/20/2021 thomas downes
    Private mod_strRecipientID As String = "001" ''Added 8/20/2021 thomas downes

    Private mod_strEmailAddress As String = "tomdownes1@gmail.com" ''Added 9/17/2021 thomas downes

    Private dictonary_elmntInfo_control As New Dictionary(Of IElement_Base, CtlGraphicFldLabel)

    Private dictonary_field_control As New Dictionary(Of ICIBFieldStandardOrCustom, CtlGraphicFldLabel)
    Private dictonary_elmntObj_control As New Dictionary(Of ClassElementField, CtlGraphicFldLabel) ''Added 9/17/2019 td
    Private dictonary_elmntObj_captions As New Dictionary(Of String, CtlGraphicFldLabel) ''Added 11/24/2019 td

    Private list_fieldsNotLoadedYet_Any As New HashSet(Of ICIBFieldStandardOrCustom)
    Private list_elementsNotLoadedYet_Any As New HashSet(Of ClassElementField) ''Added 9/17/2019 td 

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
    ''    Return ctlBackgroundZoom1.Width
    ''End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    ''Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
    ''    ''Added 9/11/2019 Never Forget 
    ''    Return ctlBackgroundZoom1.Height
    ''End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    ''Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsLeft - ctlBackgroundZoom1.Left)
    ''End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    ''Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsLeft + ctlBackgroundZoom1.Left)
    ''End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    ''Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsTop - ctlBackgroundZoom1.Top)
    ''End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    ''Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
    ''    ''Added 9/5/2019 thomas downes
    ''    Return (par_intPixelsTop + ctlBackgroundZoom1.Top)
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
                                pictureBackgroundFront)
                End If ''End of "If (Me.ElementsCache_Edits.MissingTheSignature()) Then"

                .ElementClass_Obj = Me.ElementsCache_Edits.ElementSignature

            End If ''End of "If (.ElementClass_Obj Is Nothing) Then"

            ''
            ''Set the path to the Signature File. 
            ''
            .ElementClass_Obj.SigFilePath = DiskFilesVB.PathToFile_Sig()

        End With ''End of "With CtlGraphicSignature1"

    End Sub ''End of "Public Sub New"

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
        ClassLabelToImage.Proportions_FixTheWidth(pictureBackgroundFront)
        ClassLabelToImage.Proportions_FixTheWidth(picturePreview)

        ''Double-check the proportions are correct. ---9/6/2019 td
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True)

        ''Added 10/13/2019 td
        Me.BadgeLayout = New BadgeLayoutClass
        Me.BadgeLayout.Height_Pixels = pictureBackgroundFront.Height
        Me.BadgeLayout.Width_Pixels = pictureBackgroundFront.Width

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

        ''Added 12/5/2021 thomas d. 
        ''----++Moved below from here at 8:21 p.m. 12/5/2021 thomas downes
        ''----Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, Me.ElementsCache_Saved)

        ''Added 10/13/2019 thomas d. 
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_Portrait = CtlGraphicPortrait_Lady
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_QRCode = CtlGraphicQRCode1
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_Signat = CtlGraphicSignature1
        ''Added 11/29/2021 thomas downes
        mod_designer.CtlGraphic_Text = CtlGraphicText1

        ''Added 10/13/2019 thomas d.
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.DesignerForm_Interface = CType(Me, IDesignerForm)

        Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 
        Me.Controls.Remove(CtlGraphicSignature1) ''Added 10/12/2019 thomas d. 

        ''Added 10/11/2019 thomas downes 
        Me.CtlGraphicText1.LayoutFunctions = CType(mod_designer, ILayoutFunctions)

        ''Encapsulated 7/31/2019 td
        ''
        ''Major call !!
        ''
        ''9/8/2019 td''Load_Form()

        ''-------------------------------------------------------------------------
        ''
        ''  See class Startup for cache-initialization work. ----10/13/2019 td
        ''
        ''-------------------------------------------------------------------------

        ''10/13/2019 td''Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()

        ''Why? Simply to have a separate copy? To keep a wall
        ''   between edits and the non-edited version, in case
        ''   the user elects to dump their work.  (Not every
        ''   work session bears fruit.  Often we are dissatisfied
        ''   with our work.  Consider a writer who throws away
        ''   a type-written page.  ----11/30/2021
        Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()
        Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generates a new GUID. 

        ''Added 12/5/2021 thomas d. 
        ''   Moved here from at 8:21 p.m. 12/5/2021 thomas downes
        Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, Me.ElementsCache_Saved)

        ''
        ''Encapsulated 11/28/2021 thomas downes
        ''
        Load_Designer()

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

        MenuCache_ElemFlds.ColorDialog1 = (New ColorDialog)
        MenuCache_ElemFlds.FontDialog1 = (New FontDialog)
        MenuCache_ElemFlds.Designer = mod_designer
        MenuCache_ElemFlds.LayoutFunctions = mod_designer
        MenuCache_ElemFlds.SelectingElements = mod_designer
        MenuCache_ElemFlds.GenerateMenuItems_IfNeeded()

        MenuCache_Background.ColorDialog1 = (New ColorDialog)
        MenuCache_Background.Designer = mod_designer
        MenuCache_Background.LayoutFunctions = mod_designer
        MenuCache_Background.GenerateMenuItems_IfNeeded()

        ''Added 12/3/2021 td
        pictureBackgroundFront.Refresh()

    End Sub ''End of "Private Sub Form_Load"  


    Private Sub Unload_Designer(pboolResetToFrontOfCard As Boolean)
        ''
        ''Added 11/28/2021 thomas downes
        ''
        mod_designer.UnloadDesigner(pboolResetToFrontOfCard)

    End Sub ''End of "Private Sub Unload_Designer()"  


    Private Sub Load_Designer()
        ''
        ''Encapsulated 11/28/2021 thomas downes
        ''
        If (CtlGraphicQRCode1 Is Nothing) Then
            ''Added 12/3/2021 td  
            ''----Dec6, 2021----CtlGraphicQRCode1 = New CtlGraphicQRCode
            If (ElementsCache_Edits.ElementQRCode Is Nothing) Then Throw New Exception("The QR element is a null reference.")
            CtlGraphicQRCode1 = New CtlGraphicQRCode(ElementsCache_Edits.ElementQRCode, mod_designer)
            CtlGraphicQRCode1.Visible = True
            Me.Controls.Add(CtlGraphicQRCode1)
        End If ''End of "If (CtlGraphicQRCode1 = Nothing) Then"

        ''Added 12/3/2021 thomas downes
        If (Me.PersonalityCache_Recipients Is Nothing) Then
            ''----Me.PersonalityCache_FutureUse = New ciBadgeElements.ClassElementsCache_Deprecated()
            Dim boolDummy As Boolean
            Me.PersonalityCache_Recipients = Startup.LoadCachedData_Personality_FutureUse(Me, boolDummy)
        End If ''End of "If (Me.PersonalityCache_FutureUse Is Nothing) Then"

        ''Added 10/13/2019 thomas d. 
        mod_designer.CtlGraphic_Portrait = CtlGraphicPortrait_Lady
        mod_designer.CtlGraphic_QRCode = CtlGraphicQRCode1
        mod_designer.CtlGraphic_Signat = CtlGraphicSignature1
        mod_designer.CtlGraphic_Text = CtlGraphicText1 ''Added 11/30/2021 td

        ''Added 10/13/2019 thomas d.
        mod_designer.DesignerForm_Interface = CType(Me, IDesignerForm)

        With mod_designer

            .ElementsCache_Edits = Me.ElementsCache_Edits ''Added 10/10/2019 td 
            .ElementsCache_Saved = Me.ElementsCache_Saved ''Added 10/10/2019 td 

            ''Modified 12/3/2021 td 
            ''12/3/2021 td''.BackgroundBox = Me.pictureBack
            .BackgroundBox = Me.pictureBackgroundFront

            ''Added 12/3/2021 thomas downes
            Dim objectBackgroundImage As Bitmap
            Dim strBackgroundImage_Path As String = ""
            Dim strBackgroundImage_Title As String = ""

            strBackgroundImage_Path = .ElementsCache_Edits.BackgroundImage_Path
            If (strBackgroundImage_Path Is Nothing) Then strBackgroundImage_Path = ""

            If ("" = strBackgroundImage_Path) Then
                strBackgroundImage_Path = DiskFilesVB.PathToFile_Background_FirstOrDefault(strBackgroundImage_Title)
                .ElementsCache_Saved.BackgroundImage_FTitle = strBackgroundImage_Title
                .ElementsCache_Saved.BackgroundImage_Path = strBackgroundImage_Path
                .ElementsCache_Edits.BackgroundImage_FTitle = strBackgroundImage_Title
                .ElementsCache_Edits.BackgroundImage_Path = strBackgroundImage_Path
            End If ''End of ''If ("" = strBackgroundImage_Path) The

            If (System.IO.File.Exists(strBackgroundImage_Path)) Then
                objectBackgroundImage = New Bitmap(strBackgroundImage_Path)
                .BackgroundBox.BackgroundImage = objectBackgroundImage
            End If ''End of "If (System.IO.File.Exists(strBackgroundImage_Path)) Then"

            .PreviewBox = Me.picturePreview
            .DesignerForm = Me
            .FlowFieldsNotListed = Me.flowFieldsNotListed
            .CheckboxAutoPreview = Me.checkAutoPreview
            .CheckboxInstantPreview = Me.checkInstantPreview ''Added 12/6/2021 thomas d.
            ''10/10/2019 td''.ExamplePortraitImage = mod_imageLady
            .ExampleImage_Portrait = mod_imageLady

            .ExampleImage_Signature = mod_imageSignature ''Added 10/12/2019 td
            .PathToSigFile = DiskFilesVB.PathToFile_Sig() ''Added 10/12/2019 td

            ''10/1/2019''intPicLeft = CtlGraphicPortrait_Lady.Left - ctlBackgroundZoom1.Left
            ''10/1/2019''intPicTop = CtlGraphicPortrait_Lady.Top - ctlBackgroundZoom1.Top
            ''10/1/2019''intPicWidth = CtlGraphicPortrait_Lady.Width
            ''10/1/2019''intPicHeight = CtlGraphicPortrait_Lady.Height

            If (Me.NewFileXML) Then
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

            End If ''End of "If (Me.NewFileXML) Then .... Else ..."

            ''
            ''Major call !!! 
            ''
            .LoadDesigner("Form__Main_Demo's Form_Load ")

        End With ''ENd of "With mod_designer"

    End Sub ''End of "Private Sub LoadDesigner()"


    Public Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated) Implements IDesignerForm.RefreshElementsCache_Saved
        ''
        ''Added 10/13/2019 td
        ''
        Me.ElementsCache_Saved = par_cache

    End Sub ''End of "Public Sub RefreshElementsCache_Saved"

    Private Sub AutoPreview()
        ''
        ''Added 11/26/2021 thomas downes
        ''
        Try
            mod_designer.AutoPreview_IfChecked()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            MessageBox.Show(ex.ToString)
        End Try

    End Sub ''Private Sub AutoPreview()


    Private Sub SaveLayout()
        ''
        ''Added 7/29/2019 td
        ''
        ''Dim each_graphicalLabel As CtlGraphicFldLabel
        ''Dim each_portraitLabel As CtlGraphicPortrait ''Added 7/31/2019 td

        ''
        ''Step #1 of 2. 
        ''
        mod_designer.SaveLayout(False)

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
        Me.ElementsCache_Edits = mod_designer.ElementsCache_Edits
        Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()

        ''
        ''Serialize !!  
        ''
        Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

        With objSerializationClass

            ''.TypeOfObject = (TypeOf List(Of ICIBFieldStandardOrCustom))

            ''10/10/2019 td''SaveFileDialog1.ShowDialog()
            ''10/10/2019 td''.PathToXML = SaveFileDialog1.FileName

            ''Added 10/13/2019 td 
            If (String.IsNullOrEmpty(Me.ElementsCache_Edits.PathToXml_Saved)) Then
                Me.ElementsCache_Edits.PathToXml_Saved = DiskFilesVB.PathToFile_XML_ElementsCache()
            End If ''End of "If (String.IsNullOrEmpty(Me.ElementsCache_Edits.PathToXml_Saved)) Then"

            .PathToXML = Me.ElementsCache_Edits.PathToXml_Saved
            .PathToXML_Binary = Me.ElementsCache_Edits.PathToXml_Binary ''Added 11/29/2019 thomas d.

            ''Added 9/24/2019  thomas 
            ''  ''10/13/2019 td''.SerializeToXML(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits, False, True)
            ''11/29/2019 td''.SerializeToXML(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits, False, False)

            ''11/29/2019 td''Const c_SerializeToBinary As Boolean = False ''Added 9/30/2019 td
            ''11/29/2019 td''If (c_SerializeToBinary) Then _
            ''11/29/2019 td''.SerializeToBinary(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits)

            Dim boolUseBinary As Boolean ''Added 11/29/2019 td
            boolUseBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat

            If (boolUseBinary) Then
                .SerializeToBinary(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits)
            Else
                .SerializeToXML(Me.ElementsCache_Edits.GetType, Me.ElementsCache_Edits, False, False)
            End If ''End of "If (boolUseBinary) Then ... Else ...."

        End With ''End of "With objSerializationClass"

        ''
        ''Added 12/10/2021 thomas downes
        ''


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
    ''    ''8/24 td''picturePreview.Image = ctlBackgroundZoom1.Image
    ''    ''8/24 td''picturePreview.Image = CType(ctlBackgroundZoom1.Image.Clone(), Image)
    ''
    ''    Dim obj_image As Image ''Added 8/24 td
    ''    Dim obj_image_clone As Image ''Added 8/24 td
    ''    Dim obj_image_clone_resized As Image ''Added 8/24/2019 td
    ''
    ''    ''Added 9/6/2019 td 
    ''    ClassLabelToImage.ProportionsAreSlightlyOff(ctlBackgroundZoom1.Image, True, "Background Image")
    ''
    ''    ''Added 8/24/2019 td
    ''    obj_image = ctlBackgroundZoom1.Image
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
    ''    ClassLabelToImage.ProportionsAreSlightlyOff(ctlBackgroundZoom1.Image, True, "Clone Resized #1")
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
        mod_designer.SaveLayout(True)

    End Sub

    Private Sub FormDesignProtoTwo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ''
        ''Added 7/31/2019 thomas downes
        ''
        Dim dia_result As DialogResult
        Dim closing_reason As CloseReason

        closing_reason = e.CloseReason

        ''Added 7/31/2019 td  
        ''10/13/2019 td''dia_result = MessageBox.Show("Save your work?  (Currently, this does _NOT_ save your work permanently to your PC.) " &
        ''                             vbCrLf_Deux & "(Allows the window to be re-opened from the parent application, with your work retained.)", "ciLayout",
        ''                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (Not Me.LetsRefresh_CloseForm) Then ''Added 10/13/2019 td
            ''Ask the user if she wishes to save her work.  -----10/13/2019 td 
            dia_result = MessageBox.Show("Save your work?  " &
                                     vbCrLf_Deux & "(Allows the window to be re-opened, with your work retained.)", "ciLayout",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        End If ''End of "If (Not Me.LetsRefresh_CloseForm) Then"

        If (dia_result = DialogResult.Cancel) Then e.Cancel = True
        If (dia_result = DialogResult.Yes) Then SaveLayout()

    End Sub ''End of "Private Sub FormDesignProtoTwo_FormClosing"

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
        Const c_boolStartNewWindow As Boolean = True ''10/13/2019 td''False ''9/5 td'' True ''Added 9/3/2019 thomas d. 

        If (c_boolStartNewWindow) Then ''Added 9/3/2019 thomas d. 

            ''10/13 td''Dim frm_ToShow As New FormDesignProtoTwo()
            ''10/13 td''frm_ToShow.Show()

            Me.LetsRefresh_CloseForm = True ''Added 10/13/2019 td
            Me.Close()
            Exit Sub

        Else
            ''
            ''Step 3 of 3.  Refresh the representation of the elements on the form. 
            ''
            ''Dec. 10, 2021''RefreshTheSetOfDisplayedElements()
            RefreshTheSetOfDisplayedElements(False)

        End If ''End of "If (c_boolStartNewWindow) Then  ..... Else .."

    End Sub ''End of "Private Sub LinkSaveAndRefresh_LinkClicked"

    Private Sub Recipient_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) ''10/17 td''Handles linkSaveAndRefresh.LinkClicked
        ''
        ''Added 10/17/2019 td
        ''
        Dim sender_link As LinkLabel
        sender_link = CType(sender, LinkLabel)
        ClassElementField.oRecipient = CType(sender_link.Tag, ClassRecipient)
        Me.mod_designer.RefreshPreview_Redux()

    End Sub ''End of "Private Sub Recipient_LinkClicked"

    Private Sub RefreshTheSetOfDisplayedElements(pboolResetToFrontOfCard As Boolean) ''_WontPreview()
        ''
        ''Added 11/28/2021 Thomas Downes 
        ''
        If (mod_designer IsNot Nothing) Then
            ''Major call!!  
            ''----mod_designer.UnloadDesigner__()
            ''Dec.10 2021''Unload_Designer()
            Unload_Designer(pboolResetToFrontOfCard)

        End If ''End of "If (mod_designer IsNot Nothing) Then"

        mod_designer = New ClassDesigner()

        ''Added 11/30/2021 td
        Dim boolNew As Boolean
        Me.ElementsCache_Edits = Startup.LoadCachedData_Elements_Deprecated(Me, boolNew)
        Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy(False)
        Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generate a new Guid.

        ''
        ''Major call!!
        ''
        Load_Designer()

    End Sub ''End of "Private Sub RefreshTheSetOfDisplayedElements()"


    Private Sub RefreshTheSetOfDisplayedElements_Deprecated(Optional pboolRemoveAndRebuild As Boolean = False)
        ''
        ''Step 1 of 5.   Create a dictionary of elements. 
        ''
        ''Dim dictonary_elmntInfo_control As New Dictionary(Of IElement_Base, CtlGraphicFldLabel)

        ''Dim dictonary_field_control As New Dictionary(Of ICIBFieldStandardOrCustom, CtlGraphicFldLabel)
        ''Dim dictonary_elmntObj_control As New Dictionary(Of ClassElementField, CtlGraphicFldLabel) ''Added 9/17/2019 td
        ''Dim dictonary_elmntObj_captions As New Dictionary(Of String, CtlGraphicFldLabel) ''Added 11/24/2019 td
        Dim intControlCount As Integer ''Added 10/13/2019 td  

        ''Added 11/26/2021 
        ''  Throw away the controls that are already on the form.  
        ''
        If (pboolRemoveAndRebuild) Then
            For Each each_control As CtlGraphicFldLabel In dictonary_elmntInfo_control.Values
                each_control.Visible = False
                Me.Controls.Remove(each_control)
            Next each_control
            ''Added 11/26/2021 thomas downes
            dictonary_elmntInfo_control.Clear()
            dictonary_elmntObj_captions.Clear()
            dictonary_field_control.Clear()
        End If ''End of "If (pboolRemoveAndRebuild) Then"

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

            intControlCount += 1

            ''Added 9/6/2019 td 
            ''
            ''   Build a dictionary of control-element.
            ''
            If (pboolRemoveAndRebuild) Then ''Added 11/26/2021 

                Try
                    dictonary_elmntInfo_control.Add(each_field_control.ElementClass_Obj, each_field_control)
                Catch
                    MsgBox("Likely duplicate of element Interface/Information.", MsgBoxStyle.Exclamation, "RefreshTheSetOfDisplayedElements")
                End Try

                dictonary_field_control.Add(each_field_control.FieldInfo, each_field_control)

                ''Added 9/17/2019 td
                Try
                    dictonary_elmntObj_control.Add(each_field_control.ElementClass_Obj, each_field_control)

                    ''Added 11/24/21 thomas downes
                    ''  This will help to prevent duplicates. 
                    dictonary_elmntObj_captions.Add(each_field_control.ElementClass_Obj.FieldNm_CaptionText, each_field_control)

                Catch
                    MsgBox("Possible duplicate of Element Object.", MsgBoxStyle.Exclamation, "RefreshTheSetOfDisplayedElements")
                End Try

            End If ''end of "If (pboolRemoveAndRebuild) Then"

        Next each_control

        ''
        ''Step 3 of 5.   Make a list of the elements which are not yet populated on the form. 
        ''
        ''---Dim list_fieldsNotLoadedYet_Custom As New List(Of ClassFieldCustomized)
        ''---Dim list_fieldsNotLoadedYet_Standrd As New List(Of ClassFieldStandard)

        ''Dim list_fieldsNotLoadedYet_Any As New List(Of ICIBFieldStandardOrCustom)
        ''Dim list_elementsNotLoadedYet_Any As New List(Of ClassElementField) ''Added 9/17/2019 td  
        ''Dim list_fieldsNotLoadedYet_Any As New HashSet(Of ICIBFieldStandardOrCustom)
        ''Dim list_elementsNotLoadedYet_Any As New HashSet(Of ClassElementField) ''Added 9/17/2019 td  

        list_fieldsNotLoadedYet_Any.Clear()
        list_elementsNotLoadedYet_Any.Clear()

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
        Dim bWeCanCheckPriorLoad As Boolean ''Added 11/28/2021 thomas downes
        Dim each_element As ClassElementField ''Added 11/28/2021 td
        bWeCanCheckPriorLoad = (0 < dictonary_elmntInfo_control.Count)

        If (bWeCanCheckPriorLoad) Then
            ''
            ''We have a list of the field-elements previously added, so therefore
            ''   we can check the current list against that list (and see if there
            ''   are field-elements which need to exist, but don't exist yet). 
            ''   ---11/28/2021 
            ''
            For Each each_element In Me.ElementsCache_Edits.ListFieldElements()
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

        End If ''End of "If (bWeCanCheckPriorLoad) Then"

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

            Dim strWhyCalled As String
            strWhyCalled = "RefreshTheSetOfDisplayedElements - bSomeDisplayableFieldsAreNotLoaded"

            ''#1_11/28/2021 td''mod_designer.LoadDesigner()
            '' #2_11/28/2021 td''mod_designer.LoadDesigner(strWhyCalled)
            '' #2_11/28/2021 td''mod_designer.LoadFieldControls_ByListOfElements(list_elementsNotLoadedYet_Any, True, False, True)
            mod_designer.LoadDesigner(strWhyCalled)

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

    ''Private Sub UserControlsToolStripMenuItem_Click(sender As Object, e As EventArgs)
    ''    ''
    ''    ''Added 7/17/2019 thomas downes
    ''    ''
    ''    Dim frm_ToShow As New ListCustomFieldsFlow()

    ''    ''Dec. 6, 2021 td
    ''    ''Me.ElementsCache_ManageBoth.OutputToTextFile_CustomFields(Me.ElementsCache_Edits.ListOfFields_Custom, "Prior to editing")

    ''    ''7/26/2019 td''frm_ToShow.ListOfFields = GetCurrentPersonality_Fields()
    ''    ''12/4/2021 td''frm_ToShow.ListOfFields = Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom()
    ''    ''12/5/2021 td''frm_ToShow.ListOfFields = Form__Main_PreDemo.GetCurrentPersonality_Fields_Custom()
    ''    frm_ToShow.ListOfFields = Me.ElementsCache_Edits.ListOfFields_Custom
    ''    frm_ToShow.CacheManager = Me.ElementsCache_ManageBoth ''Added 12/6/2021 td 
    ''    frm_ToShow.ShowDialog()
    ''    RefreshTheSetOfDisplayedElements()
    ''    PictureBox1.SendToBack()

    ''    ''Dec. 6, 2021 td 
    ''    If (frm_ToShow.ClosingOK_SoSaveWork) Then
    ''        ''Dec. 6, 2021 td 
    ''        Me.ElementsCache_ManageBoth.Save()
    ''        ''--Me.ElementsCache_Saved = Me.ElementsCache_ManageBoth.CacheSaved()

    ''    End If ''ENd of "If (frm_ToShow.ClosingOK_SoSaveWork) Then"

    ''    ''Dec. 6, 2021 td
    ''    Me.ElementsCache_ManageBoth.OutputToTextFile_CustomFields(Me.ElementsCache_Edits.ListOfFields_Custom, "After editing")

    ''End Sub

    Private Sub CustomFields_Click(sender As Object, e As EventArgs) Handles CustomFieldsToolStripMenuItem.Click
        ''
        ''Added 7/17/2019 thomas downes
        ''Encapsulated 12/6/2021 thomas downes
        ''
        ShowFieldsToEdit_Custom()

    End Sub

    Private Sub ShowFieldsToEdit_Custom()
        ''
        ''Encapsulated 12/6/2021 thomas downes
        ''
        Const c_boolDebugMode As Boolean = True ''Added 12/6/2021 td 

        ''Major call !!
        modAllowFieldEdits.ShowFieldsToEdit_Custom(Me.ElementsCache_ManageBoth, Me.ElementsCache_Edits, c_boolDebugMode)

        ''Refresh the form.  
        ''Dec.10, 2021''RefreshTheSetOfDisplayedElements()
        RefreshTheSetOfDisplayedElements(False)
        pictureBackgroundFront.SendToBack()

    End Sub


    Private Sub ShowFieldsToEdit_Custom_Deprecated()
        ''
        ''Rendered obselete 12/6/2021 thomas downes
        ''
        ''See module modAllowFieldEdits for the same-named procedure.
        '' (Highlight all of the code and hit the "Uncomment" button twice.)
        ''    ---12/6/2021 td
        ''
    End Sub ''End of "Private Sub ShowFieldsToEdit_Custom" 

    ''Private Sub StandardFieldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StandardFieldsToolStripMenuItem.Click
    ''    ''
    ''    ''Added 8/19/2019 thomas downes
    ''    '' 
    ''    Dim frm_ToShow As New ListStandardFields()
    ''
    ''    ''10/14/2019 td''frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Standard()
    ''    frm_ToShow.ListOfFields = Me.ElementsCache_Edits.ListOfFields_Standard()
    ''    frm_ToShow.ShowDialog()
    ''    RefreshTheSetOfDisplayedElements()
    ''    PictureBox1.SendToBack()
    ''
    ''End Sub

    Private Sub StandardFields_Click(sender As Object, e As EventArgs) Handles StandardFieldsToolStripMenuItem.Click
        ''
        ''Encapsulated 12/6/2021 td 
        ''
        ShowFieldsToEdit_Standard()

        ''    Dim frm_ToShow As New ListStandardFields()
        ''    ''10/14/2019 td''frm_ToShow.ListOfFields = FormMain.GetCurrentPersonality_Fields_Standard()
        ''    frm_ToShow.ListOfFields = Me.ElementsCache_Edits.ListOfFields_Standard()
        ''    frm_ToShow.ShowDialog()
        ''    RefreshTheSetOfDisplayedElements()
        ''    PictureBox1.SendToBack()

    End Sub

    Private Sub ShowFieldsToEdit_Standard()
        ''
        ''Encapsulated 12/6/2021 thomas downes  
        ''Modified 12/6/2021 thomas d. 
        ''
        Const c_boolDebugMode As Boolean = True ''Added 12/6/2021 td 

        ''Major call !!
        modAllowFieldEdits.ShowFieldsToEdit_Standard(Me.ElementsCache_ManageBoth, Me.ElementsCache_Edits, c_boolDebugMode)

        ''Refresh the form.  
        ''Dec. 10, 2021''RefreshTheSetOfDisplayedElements()
        RefreshTheSetOfDisplayedElements(False)
        pictureBackgroundFront.SendToBack()

    End Sub ''End of "Private Sub ShowFieldsToEdit_Standard" 

    Private Sub LinkRefreshPreview_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRefreshPreview.LinkClicked
        ''
        ''Added 8/24/2019 thomas downes
        ''
        ClassLabelToImage.Proportions_FixTheWidth(picturePreview)

        ''
        ''Check that the proportions are correct. 
        ''
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True)

        ''Added 9/8/2019 td
        ''12/3/2021 td''ClassLabelToImage.ProportionsAreSlightlyOff(ctlBackgroundZoom1.Image, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront.BackgroundImage, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview.Image, True)

        ''
        ''Refresh the preview picture box. 
        ''
        ''10/3/2019 td''RefreshPreview()
        mod_designer.RefreshPreview_Redux()

        ''8/24 td''Dim objPrintLib As New ciLayoutPrintLib.CILayoutBadge
        ''Dim objPrintLib As New ciLayoutPrintLib.LayoutPrint_Redux
        ''Dim listOfElementText_Stdrd As List(Of IElementWithText)
        ''Dim listOfElementText_Custom As List(Of IElementWithText)

        ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''      ClassFieldStandard.ListOfFields_Students,
        ''      ClassFieldCustomized.ListOfFields_Students)

        ''listOfElementText_Stdrd = ClassFieldStandard.ListOfElementsText_Stdrd()
        ''listOfElementText_Custom = ClassFieldCustomized.ListOfElementsText_Custom()

        ''picturePreview.SizeMode = PictureBoxSizeMode.Zoom
        ''picturePreview.Image = ctlBackgroundZoom1.Image

        ''objPrintLib.LoadImageWithFieldValues(picturePreview.Image,
        ''                                     listOfElementText_Stdrd,
        ''                                     listOfElementText_Custom)

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
        ''Dim list_controlFields As New List(Of CtlGraphicFldLabel)
        Dim list_controlFields As New HashSet(Of CtlGraphicFldLabel)

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

    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    ''9/8/2019 td''Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    ''9/8/2019 td''Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    ''9/8/2019 td''Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    ''9/8/2019 td''Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    ''Private Sub Layout_MouseDown(sender As Object, e As MouseEventArgs) Handles ctlBackgroundZoom1.MouseDown ''----Me.MouseDown
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    mod_rubberbandClass.MouseDown(sender, e)

    ''End Sub

    ''Private Sub Layout_MouseMove(sender As Object, e As MouseEventArgs) Handles ctlBackgroundZoom1.MouseMove ''----Me.MouseMove
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    If (mod_rubberbandClass IsNot Nothing) Then
    ''        mod_rubberbandClass.MouseMove(sender, e)
    ''    End If

    ''End Sub

    ''Private Sub Layout_MouseUp(sender As Object, e As MouseEventArgs) Handles ctlBackgroundZoom1.MouseUp ''----Me.MouseUp
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    mod_rubberbandClass.MouseUp(sender, e)

    ''End Sub

    ''Private Sub Layout_Paint(sender As Object, e As PaintEventArgs) Handles ctlBackgroundZoom1.Paint ''----Me.Paint
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

            SaveFileDialog1.FileName = "" ''Added 11/24/2021 thomas downes
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
        ''Dec. 10, 2021''RefreshTheSetOfDisplayedElements()
        RefreshTheSetOfDisplayedElements(False)

        ''Addded 9/13/2019 td
        ''10/8/2019 td''AutoPreview_IfChecked()
        ''11/26/2021''mod_designer.AutoPreview_IfChecked()
        AutoPreview()

    End Sub

    Private Sub ChkIncludeExampleValues_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludeExampleValues.CheckedChanged
        ''
        ''We have .AutoChecked = False, so please see the Click event.  ----9/13/2019 
        ''
    End Sub

    Private Sub RightClickMenuParent_Click(sender As Object, e As EventArgs) Handles RightClickMenuParent.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ''
        ''Menu item "File" | "Open Layout XML..."  
        ''
        ''This allows the user to select the XML file of their choosing. 
        ''
        Static s_strFolder As String

        If (String.IsNullOrEmpty(s_strFolder)) Then s_strFolder = My.Application.Info.DirectoryPath

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = s_strFolder
        OpenFileDialog1.ShowDialog()

        ''Added 11/24/2021 
        Dim bConfirmFileExists As Boolean
        Dim strPathToXML As String ''Added 11/30/2021 td

        strPathToXML = OpenFileDialog1.FileName ''Added 11/30/2021 td
        bConfirmFileExists = System.IO.File.Exists(strPathToXML)
        If (Not bConfirmFileExists) Then
            ''Added 11/30/2021
            MessageBox.Show("Unable to open the file, unfortunately.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If ''End of "If (Not bConfirmFileExists) Then"

        ''
        ''Encapsulated 11/30/2021
        ''
        LoadBothCachesUsingSamePathToXML(strPathToXML)

    End Sub


    Private Sub LoadBothCachesUsingSamePathToXML(par_strPathToXml As String,
                                           Optional ByRef pboolFailed As Boolean = False)
        ''
        ''Encapsulated 11/30/2021
        ''
        Dim objDeserial As New ciBadgeSerialize.ClassDeserial
        Dim bConfirmFileExists As Boolean
        ''11/30/2021 td''Dim objCache As ClassDesignerListenToMover_Deprecated
        Dim objCache_FromXml_1 As ClassElementsCache_Deprecated
        Dim objCache_FromXml_2 As ClassElementsCache_Deprecated

        With objDeserial

            .PathToXML = par_strPathToXml ''OpenFileDialog1.FileName

            ''Added 11/24/2021 
            bConfirmFileExists = System.IO.File.Exists(.PathToXML)
            If (Not bConfirmFileExists) Then
                pboolFailed = True
                Return
            End If

            ''9/30 td''objCache =
            ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

            objCache_FromXml_1 =
            CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

            objCache_FromXml_2 =
            CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

        End With ''End of "With objDeserial"

        ''
        ''Major call !!  
        ''
        ''++/++Does nothing. 11/30/2021 td
        ''++Form__Main_PreDemo.OpenElementsCache(objCache)

        ''Added 11/30/2021 thomas d. 
        Me.ElementsCache_Saved = objCache_FromXml_1
        Me.ElementsCache_Edits = objCache_FromXml_2

    End Sub ''End of "Private Sub LoadBothCachesUsingSamePathToXML"

    Private Sub LinkRevertToLastSave_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkRevertToLastSave.LinkClicked
        ''
        ''Added 10/2/2019 thomas downes
        ''
        Dim intConfirm As DialogResult

        intConfirm = MessageBox.Show("Do you want to undo all of the changes you made " &
                                     " since you last saved?", "",
                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If (intConfirm = DialogResult.Yes) Then

            ''Step 1. Discard the user's edits.
            Me.ElementsCache_Edits = Nothing

            ''Step 2. Copy the saved work, to become the new starting point.
            Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()

            ''Added 10/13/2019 td
            mod_designer.ElementsCache_Edits = Me.ElementsCache_Edits

            ''
            ''Step 3 of 4.  Relink all of the elements to the controls. 
            ''
            Dim each_element As ClassElementField ''Added 10/13/2019 td

            ''Added 10/13/2019 td
            For Each each_ctl As CtlGraphicFldLabel In mod_designer.ListOfFieldLabels()

                each_element = Me.ElementsCache_Edits.GetElementByFieldEnum(each_ctl.FieldInfo.FieldEnumValue)
                each_ctl.ElementClass_Obj = each_element
                each_ctl.ElementInfo_Base = each_element
                each_ctl.ElementInfo_Field = each_element
                each_ctl.ElementInfo_Text = each_element

            Next each_ctl

            ''
            ''Step 4 of 4.  Refresh the representation of the elements on the form. 
            ''
            ''Dec.10 2021''RefreshTheSetOfDisplayedElements()
            RefreshTheSetOfDisplayedElements(True)

        End If ''End of "If (intConfirm = DialogResult.Yes) Then"

    End Sub

    Private Sub ShowBadgeRecipientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowBadgeRecipientsToolStripMenuItem.Click
        ''
        ''Added 10/11/2019 thomas downes
        ''
        Dim list_recips As List(Of ClassRecipient) ''Added 10/11/2019 thomas downes
        Dim each_recip As ClassRecipient ''Added 10/11/2019 thomas downes
        Dim new_LinkLabel As LinkLabel ''Added 10/14/2019 td  

        With flowSidebar

            .Width = 100
            .Visible = True
            .Controls.Clear()
            .BringToFront()
            .AutoScroll = True

            ''11/30/2021 td''list_recips = Me.PersonalityCache.ListOfRecipients
            If (Me.PersonalityCache_Recipients Is Nothing) Then
                ''
                ''Added 12/3/2021 thomas downes 
                ''
                Dim boolNewFileXML As Boolean
                Me.PersonalityCache_Recipients = Startup.LoadCachedData_Personality_FutureUse(Me, boolNewFileXML)

            End If ''end of "If (Me.PersonalityCache_FutureUse Is Nothing) Then"

            list_recips = Me.PersonalityCache_Recipients.ListOfRecipients
            ''Added 12/3/2021 td
            If (list_recips Is Nothing) Then
                ''Added 12/3/2021 td
                list_recips = Startup.LoadData_Recipients_Students()
                Me.PersonalityCache_Recipients.ListOfRecipients = list_recips
            End If ''End of "If (list_recips Is Nothing) Then"

            For Each each_recip In list_recips

                ''Added 10/14/2019 td  
                new_LinkLabel = New LinkLabel
                With new_LinkLabel
                    .Visible = True
                    .Tag = each_recip ''Added 10/17/2019 td
                    .Text = (each_recip.fstrFirstName & " " & each_recip.fstrLastName)
                End With

                ''Added 10/17/2019 td
                .Controls.Add(new_LinkLabel)

                ''Added 10/17/2019 td
                AddHandler new_LinkLabel.LinkClicked, AddressOf Recipient_LinkClicked

            Next each_recip

        End With ''end of "With flowSidebar" 

    End Sub ''End of "Private Sub ShowBadgeRecipientsToolStripMenuItem_Click"

    Private Sub mod_designer_ElementRightClicked(par_control As CtlGraphicFldLabel) Handles mod_designer.ElementRightClicked
        ''
        ''Added 10/13/2019 thomas downes  
        ''
        MenuCache_ElemFlds.CtlCurrentElement = par_control ''Added 10/14/2019 td  
        MenuCache_ElemFlds.Operations_Edit.CtlCurrentElement = par_control ''Added 10/14/2019 td

        ContextMenuStrip1.Items.Clear()
        ContextMenuStrip1.Items.AddRange(MenuCache_ElemFlds.Tools_EditElementMenu)

        ''10/13 td''ContextMenuStrip1.Show()
        ''10/13 td''ContextMenuStrip1.Show(par_control, New Point(par_control.Left, par_control.Top))
        ContextMenuStrip1.Show(par_control, New Point(0, 0))

    End Sub

    Private Sub LinkLabelOpenPreviewFile_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenPreviewFileBMP.LinkClicked

        ''Added 10/14 & 5/7/2019 td  
        Dim img As System.Drawing.Image
        Dim strOutputPathToFolder As String
        Dim strOutputPathToFileBMP As String
        Dim strStudentID As String = mod_strRecipientID ''Added 8/20/2021 thomas downes  

        img = picturePreview.Image

        strOutputPathToFolder = DiskFolders.PathToFolder_Preview()

        ''8/20/2021 td''strOutputPathToFileBMP = (strOutputPathToFolder & "\Preview_" &
        ''  DateTime.Now.ToString("MMdd_hhmmss") & ".bmp")
        strOutputPathToFileBMP = (strOutputPathToFolder & "\Badge_" &
            strStudentID & "_" &
            DateTime.Now.ToString("MMdd_hhmmss") & ".bmp")

        '' 5/7/2019 td''img.Save("Test.jpg", Imaging.ImageFormat.Png)
        ''10/14/2019 td''img.Save("Test.bmp", Imaging.ImageFormat.Bmp)

        img.Save(strOutputPathToFileBMP, Imaging.ImageFormat.Bmp)

        '' 5/7/2019 td''System.Diagnostics.Process.Start("Test.jpg")
        ''10/14/2019 td''System.Diagnostics.Process.Start("Test.bmp")

        System.Diagnostics.Process.Start(strOutputPathToFileBMP)

    End Sub ''End of " Private Sub LinkLabelOpenPreviewFile_LinkClicked"

    Private Sub mod_designer_BackgroundRightClicked(par_mouse_x As Integer, par_mouse_y As Integer) Handles mod_designer.BackgroundRightClicked

        ''Added 10/15/2019 td 
        ContextMenuStrip1.Items.Clear()
        ContextMenuStrip1.Items.AddRange(MenuCache_Background.Tools_BackgroundMenu)
        ContextMenuStrip1.Show(pictureBackgroundFront, New Point(par_mouse_x, par_mouse_y))

    End Sub

    Private Sub PrintAllBadgesToFileFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAllBadgesToFileFolderToolStripMenuItem.Click
        ''
        ''Added 10/18/2019 thomas d.  
        ''
        ''Encapsulated 12/3/2021 Thomas Downes
        MakeBadgeImageFilesInFolder()

    End Sub

    Private Sub MakeBadgeImageFilesInFolder()
        ''
        ''Encapsulated 12/3/2021 Thomas Downes
        ''
        Dim strPathToFolder As String
        Dim strOutputPathToFileBMP As String
        Dim img_Prod As Image
        Dim strFolderSuffix As String
        Dim objBadgeGenerator As New ciBadgeGenerator.ClassMakeBadge ''Added 12/3/2021 Thomas Downes

        strFolderSuffix = DateTime.Now.ToString("MMdd_hhmmss")

        strPathToFolder = DiskFolders.PathToFolder_Production(strFolderSuffix)

        For Each each_recip As ClassRecipient In PersonalityCache_Recipients.ListOfRecipients
            ''
            ''Added 10/18/2019 td 
            ''
            ClassElementField.oRecipient = each_recip

            mod_designer.RefreshPreview_Redux()

            ''
            '' Include the recipient ID, a.k.a. student ID.  
            ''
            'strOutputPathToFileBMP = System.IO.Path.Combine(strPathToFolder,
            '                        (each_recip.RecipientID() & ".bmp"))
            mod_strRecipientID = each_recip.RecipientID.ToString

            Const c_strFileType As String = "jpg" '' "bmp"

            If (c_strFileType = "bmp") Then
                ''
                ''Bitmap images. 
                ''
                strOutputPathToFileBMP = System.IO.Path.Combine(strPathToFolder,
                                    (mod_strRecipientID & ".bmp"))

                img_Prod = picturePreview.Image
                img_Prod.Save(strOutputPathToFileBMP, Imaging.ImageFormat.Bmp)

            Else
                ''
                ''Jpeg images. 
                ''
                strOutputPathToFileBMP = System.IO.Path.Combine(strPathToFolder,
                                    (mod_strRecipientID & ".jpg"))

                img_Prod = picturePreview.Image
                img_Prod = objBadgeGenerator.MakeBadgeImage_ByRecipient(Me.BadgeLayout, pictureBackgroundFront.BackgroundImage,
                                                                        Me.ElementsCache_Edits,
                                                                        Me.BadgeLayout.Width_Pixels,
                                                                        Me.BadgeLayout.Height_Pixels, each_recip, Nothing)
                img_Prod.Save(strOutputPathToFileBMP, Imaging.ImageFormat.Jpeg)

            End If ''End of "If (c_strFileType = "bmp") Then .... Else ...."

        Next each_recip

ExitHandler:
        ClassElementField.oRecipient = Nothing ''Clear out the member of data.   
        System.Diagnostics.Process.Start(strPathToFolder)

    End Sub

    Private Sub LinkLabelEmailBadgeJPG_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelEmailBadgeJPG.LinkClicked

        ''//
        ''//  Added 8/20/2021 Thomas Downes   
        ''//
        ''Call LinkLabelOpenPreviewFile_LinkClicked(sender, e)

        Dim image_output As Image ''Added 9/18/2021 td 
        Dim strOutputPathToFolder As String = ""
        Dim strOutputPathToFileJPG As String = ""
        Dim strStudentID As String

        strStudentID = mod_strRecipientID ''Added 8/20/2021 thomas downes  

        strOutputPathToFolder = DiskFolders.PathToFolder_Preview()
        strOutputPathToFileJPG = (strOutputPathToFolder & "\Badge_" &
            strStudentID & "_" &
            DateTime.Now.ToString("MMdd_hhmmss") & ".jpg")

        mod_designer.RefreshPreview_Redux()
        image_output = picturePreview.Image
        image_output.Save(strOutputPathToFileJPG, Imaging.ImageFormat.Jpeg)

        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpUsername = "tomdownes1@gmail.com"
        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpSpaghetti = "search#1957Bb"
        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpEnableSSL = True
        EmailingFiles.SmtpServerAddress = "smtp.gmail.com"

        EmailingFiles.SendViaEmail_OneFile(mod_strEmailAddress, strOutputPathToFileJPG)

    End Sub

    Private Sub LinkLabelOpenPreviewFileJPG_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelOpenPreviewFileJPG.LinkClicked
        ''
        ''Added 8/20/2021 td
        ''
        Dim img As System.Drawing.Image
        Dim strOutputPathToFolder As String
        Dim strOutputPathToFileJPG As String
        Dim strStudentID As String = mod_strRecipientID ''Added 8/20/2021 thomas downes  

        img = picturePreview.Image

        strOutputPathToFolder = DiskFolders.PathToFolder_Preview()

        strOutputPathToFileJPG = (strOutputPathToFolder & "\Badge_" &
            strStudentID & "_" &
            DateTime.Now.ToString("MMdd_hhmmss") & ".jpg")

        img.Save(strOutputPathToFileJPG, Imaging.ImageFormat.Jpeg)
        System.Diagnostics.Process.Start(strOutputPathToFileJPG)

    End Sub

    Private Sub EmailAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailAddressToolStripMenuItem.Click
        ''
        '' Added 9/17/2021 thomas downes
        ''
        mod_strEmailAddress =
        InputBox("Set the email address you want to use (to receive badge image files).",
                 "Set email address", "tomdownes1@gmail.com")

    End Sub

    Private Sub LinkLabelEmailBadgeJpeg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelEmailBadgeJpeg.LinkClicked
        ''
        '' Added 9/27/2021 Thomas Downes  
        ''
        Dim image_output As Image ''Added 9/18/2021 td 

        mod_designer.RefreshPreview_Redux()
        image_output = picturePreview.Image
        ''image_output.Save(strOutputPathToFileJPG, Imaging.ImageFormat.Jpeg)

        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpUsername = "tomdownes1@gmail.com"
        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpSpaghetti = "Dd"
        EmailingFilesViaGmail_Framework.EmailingFiles.SmtpEnableSSL = True
        EmailingFiles.SmtpServerAddress = "smtp.gmail.com"

        ''EmailingFiles.SendViaEmail_OneFile(mod_strEmailAddress, strOutputPathToFileJPG)

        Dim strTitleOfJpegImage As String
        Dim strStudentID As String = mod_strRecipientID ''Added 8/20/2021 thomas downes  

        strTitleOfJpegImage = ("Badge_" &
            strStudentID & "_" &
            DateTime.Now.ToString("MMdd_hhmmss") & ".jpg")

        EmailingFiles.SendViaEmail_OneImage(mod_strEmailAddress,
             image_output,
             strTitleOfJpegImage,
             "", "", "")

        ''Added 9/27/2021 Thomas Downes
        MessageBox.Show("Check for emailed image (as attached Jpeg file).", "ABC Badge",
                        MessageBoxButtons.OK,
                       MessageBoxIcon.Information)

    End Sub

    Private Sub UploadNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadNewToolStripMenuItem.Click
        ''
        ''Added 11/24/2021 thomas d. 
        ''
        ''Static s_strFolder As String
        ''Dim objCache As ClassElementsCache_Deprecated

        ''If (String.IsNullOrEmpty(s_strFolder)) Then s_strFolder = My.Application.Info.DirectoryPath

        ''OpenFileDialog1.FileName = ""
        ''OpenFileDialog1.InitialDirectory = s_strFolder
        ''OpenFileDialog1.ShowDialog()

        ''''Added 11/24/2021 
        ''Dim bConfirmFileExists As Boolean
        ''bConfirmFileExists = System.IO.File.Exists(OpenFileDialog1.FileName)
        ''If (Not bConfirmFileExists) Then Return

        Dim objShow As New FormUploadBackground
        '' 12/3/2021 td''objShow.Show()
        objShow.ShowDialog()

        ''Added 12/3/2021 td
        Dim bConfirmFileExists As Boolean ''Added 12/3/2021 td
        bConfirmFileExists = System.IO.File.Exists(objShow.ImageFilePath)
        If (Not bConfirmFileExists) Then Return ''Added 12/3/2021 td

        ''Added 12/3/2021 td
        Me.ElementsCache_Edits.BackgroundImage_Path = objShow.ImageFilePath
        Me.ElementsCache_Edits.BackgroundImage_Path = objShow.ImageFileInfo.Name

    End Sub

    Private Sub SelectFromExistingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectFromExistingToolStripMenuItem.Click
        ''
        ''Added 11/24/2021 thomas d. 
        ''
        ''
        ''Added 11/25/2021 td
        ''
        Dim objShow As New FormListBackgrounds
        objShow.ShowDialog()

        Dim strPathToFilename As String
        If (objShow.ImageFileInfo IsNot Nothing) Then
            strPathToFilename = objShow.ImageFileInfo.FullName
            ''ClassElementsCache_Deprecated.Singleton.BackgroundImage_Path = strPathToFilename
            '' 12/3/2021 td''ctlBackgroundZoom1.ImageLocation = strPathToFilename
            '' 12/3/2021 td''PictureBox1.ImageLocation = strPathToFilename
            pictureBackgroundFront.BackgroundImage = (New Bitmap(strPathToFilename))
            pictureBackgroundFront.BackgroundImageLayout = ImageLayout.Zoom

            ''Added 12/3/2021 td
            Me.ElementsCache_Edits.BackgroundImage_Path = strPathToFilename
            Me.ElementsCache_Edits.BackgroundImage_FTitle = objShow.ImageFileInfo.Name

            ''Added 12/3/2021 td
            Me.mod_designer.AutoPreview_IfChecked()

        End If ''If (objShow.ImageFileInfo IsNot Nothing) Then

    End Sub

    Private Sub UploadBackgroundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadBackgroundToolStripMenuItem.Click
        ''
        ''Added 11/25/2021 td
        ''
        ''Dim objShow As New FormListBackgrounds
        ''objShow.Show()
        Dim objShow As New FormUploadBackground
        objShow.Show()

    End Sub

    Private Sub CheckDupedElementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckDupedElementsToolStripMenuItem.Click
        ''
        ''Added 11/28/2021 Thomas Downes  
        ''
        Dim strListedDataBuilder As New System.Text.StringBuilder(500)
        ''Dim arrayElements As List(Of Control)
        Dim arrayElemCaptions As New List(Of String)
        Dim eachFieldLabel As CtlGraphicFldLabel
        Dim boolIsFieldElement As Boolean

        ''arrayElements = New List(Of Control)(CType(Me.Controls,
        ''                      IEnumerable(Of Control)))

        For Each eachControl As Control In Me.Controls ''arrayElements ''.OrderBy()

            boolIsFieldElement = (TypeOf eachControl Is CtlGraphicFldLabel)
            If boolIsFieldElement Then
                eachFieldLabel = CType(eachControl, CtlGraphicFldLabel)
                ''strListedData.AppendLine(eachFieldLabel.FieldInfo.FieldLabelCaption)
                arrayElemCaptions.Add(eachFieldLabel.FieldInfo.FieldLabelCaption &
                                      "..." & eachFieldLabel.WhyWasICreated)
            End If ''End of "If boolIsFieldElement Then"

        Next eachControl

        ''Sort alphabetically. 
        arrayElemCaptions.Sort()

        For Each eachCaption As String In arrayElemCaptions  ''arrayElements ''.OrderBy

            strListedDataBuilder.AppendLine(eachCaption)

        Next eachCaption

        ''
        ''Finishing up. 
        ''
        If (False) Then DisplayStringDataInNotepad(strListedDataBuilder.ToString())

    End Sub


    Private Sub DisplayStringDataInNotepad(par_stringData As String)
        ''
        ''Added 11/28/2021 thomas downes  
        ''
        Dim strRandomFolder As String
        Dim strRandomFilePath As String
        Dim strRandomTitle As String

        strRandomFolder = DiskFolders.PathToFolder_Preview()
        strRandomTitle = String.Format("Elements {0:HHmmss}.txt", DateTime.Now)
        strRandomFilePath = System.IO.Path.Combine(strRandomFolder, strRandomTitle)
        System.IO.File.WriteAllText(strRandomFilePath, par_stringData)
        System.Diagnostics.Process.Start(strRandomFilePath)

    End Sub ''ENd of "Private Sub DisplayStringDataInNotepad()"

    Private Sub UnloadDesignerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UnloadDesignerToolStripMenuItem.Click

        ''Added 11/28/2021 td
        ''
        ''Major call!  
        ''
        Unload_Designer(True)

        ''Added 12/10/2021 thomas downes
        ''
        ''  The designer, when unloaded, will switch back to the frontside
        ''   of the card.  
        ''
        labelProceedToBackside.Visible = True ''The lable should be visible when the //front// of the badge is displayed. 
        labelBacksideOfBadgecard.Visible = False
        LabelReturnToFrontSide.Visible = False

    End Sub

    Private Sub ReloadDesignerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadDesignerToolStripMenuItem.Click

        ''Added 11/28/2021 td
        ''--Unload_Designer()
        ''--mod_designer = New ClassDesigner()
        ''--Load_Designer()
        ''Dec. 10 2021''RefreshTheSetOfDisplayedElements()
        RefreshTheSetOfDisplayedElements(True)

        ''Added 12/10/2021
        labelBacksideOfBadgecard.Visible = False
        LabelReturnToFrontSide.Visible = False
        labelProceedToBackside.Visible = True

    End Sub

    Private Sub CtlGraphicQRCode1_Click(sender As Object, e As EventArgs) Handles CtlGraphicQRCode1.Click

    End Sub

    Private Sub CtlGraphicQRCode1_Load(sender As Object, e As EventArgs) Handles CtlGraphicQRCode1.Load

        Dim objQR As New CtlGraphicQRCode


    End Sub

    Private Sub zz(sender As Object, e As EventArgs) Handles MyBase.Click

    End Sub

    Private Sub pictureBack_Click(sender As Object, e As EventArgs)
        ''
        ''See "Private Sub BackgroundBox_Click(...)" in module ClassDesigner.
        ''    ("RaiseEvent BackgroundRightClicked(e.X, e.Y)")
        ''   ----12/1/2021 thomas
        ''
    End Sub

    Private Sub pictureBack_MouseClick(sender As Object, e As MouseEventArgs)
        ''
        ''See "Private Sub BackgroundBox_Click(...)" in module ClassDesigner.
        ''    ("RaiseEvent BackgroundRightClicked(e.X, e.Y)")
        ''   ----12/1/2021 thomas
        ''
    End Sub

    Private Sub pictureBack_MouseDown(sender As Object, e As MouseEventArgs)
        ''
        ''See "Private Sub BackgroundBox_Click(...)" in module ClassDesigner.
        ''    ("RaiseEvent BackgroundRightClicked(e.X, e.Y)")
        ''   ----12/1/2021 thomas
        ''
    End Sub

    Private Sub checkAutoPreview_CheckedChanged(sender As Object, e As EventArgs) Handles checkAutoPreview.CheckedChanged

        ''Added 12/8/2021 thomas downes
        ''   Do something to indicate a "sine qua non" relationship.
        ''
        checkInstantPreview.Enabled = checkAutoPreview.Checked

    End Sub


    Private Sub labelProceedToBackside_Click(sender As Object, e As EventArgs) Handles labelProceedToBackside.Click
        ''
        ''Added 12/8/2021 thomas downes 
        ''
        ''  Show the backside of the card. 
        ''
        labelProceedToBackside.Text = labelProceedToBackside.Tag.ToString()
        ''Dec.10 2021 thomas downes
        Unload_Designer(False)
        pictureBackgroundBackside.Visible = True ''By default, when the form opens, this control is invisible. 
        pictureBackgroundFront.SendToBack()
        Dim boolSuccess As Boolean

        mod_designer.SwitchSideOfCard(boolSuccess)
        mod_designer.BackgroundBox = pictureBackgroundBackside

        If (boolSuccess) Then
            labelProceedToBackside.Visible = False
            LabelReturnToFrontSide.Visible = True
            labelBacksideOfBadgecard.Visible = True ''Added 12/10/2021 thomas
        End If ''End of "If (boolSuccess) Then"

    End Sub


    Private Sub ExitRecipientModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitRecipientModeToolStripMenuItem.Click
        ''
        ''Added 12/8/2021 thomas downes
        ''
        flowSidebar.Visible = False
        ClassElementField.iRecipientInfo = Nothing
        ClassElementField.oRecipient = Nothing
        mod_designer.RefreshPreview_Redux()

    End Sub

    Private Sub LabelReturnToFrontSide_Click(sender As Object, e As EventArgs) Handles LabelReturnToFrontSide.Click
        ''
        ''Added 12/8/2021 thomas downes 
        ''
        ''  Return to the frontside of the card. 
        ''
        Dim boolSuccess As Boolean
        ''Dec.10 2021''Unload_Designer()
        Unload_Designer(False)
        mod_designer.SwitchSideOfCard(boolSuccess)
        If (boolSuccess) Then
            labelProceedToBackside.Visible = True ''If the user is seeing the Front, they may change minds and want to see the Back again. 
            LabelReturnToFrontSide.Visible = False
            labelBacksideOfBadgecard.Visible = False ''Added 12/10/2021 thomas
        End If ''End of "If (boolSuccess) Then"
        pictureBackgroundBackside.SendToBack()
        mod_designer.BackgroundBox = pictureBackgroundFront

    End Sub
End Class