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
    ''Dec17, 2021''Implements IRecallClickable

    ''10/3/2019 td''Implements ILayoutFunctions ''-----, ISelectingElements, ILayoutFunctions
    ''
    ''Added 7/18/2019 Thomas DOWNES
    ''
    Public Property LetsRefresh_CloseForm As Boolean ''Added 10/13/2019 td  
    Public Property LetsRefresh_CardBackside As Boolean ''Added 1/26/2022 td  
    Public Property NewFileXML As Boolean ''Added 10/13/2019 td

    ''1/14/2020 td''Public Property PersonalityCache As ciBadgeCustomer.PersonalityCache_NotInUse ''Added 10/11/2019 td 
    ''12/4/2021''Public Property PersonalityCache_Recipients As ciBadgeElements.ClassPersonalityCache ''Added 10/11/2019 td 
    Public Property PersonalityCache_Recipients As ciBadgeCachePersonality.ClassCachePersonality ''Added 10/11/2019 td 
    Public Property BadgeLayout As BadgeLayoutClass Implements IDesignerForm.BadgeLayout ''Added 10/13/2019 td

    ''Added 9/16/2019 thomas downes
    ''Dec14 2021 td''Public Property ElementsCache_Saved As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_Edits As New ClassElementsCache_Deprecated ''Added 9/16/2019 thomas downes
    Public Property ElementsCache_ManageBoth As ClassCacheManagement ''Added 12/5/2021 thomas downes
    Public Property ElementsCache_PathToXML As String ''Added 12/14/2021 thomas Downes

    ''Public Property LastTouchedMoveableElement As IMoveableElement ''Added 12/17/2021 td
    ''Public Property LastTouchedClickableElement As IClickableElement ''Added 12/17/2021 td

    Private WithEvents mod_designer As New ciBadgeDesigner.ClassDesigner ''Added 10/3/2019 td

    ''#1 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls_NA As New MoveAndResizeControls_Monem.ControlMove_RaiseEvents ''Added 8/3/2019 td  
    '' #2 8-3-2019 td''Private WithEvents mod_moveAndResizeCtls As New MoveAndResizeControls_Monem.ControlMove_GroupMove ''Added 8/3/2019 td  
    ''#1 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(Me) ''8/4/2019 td''New ClassGroupMove
    '' #2 10/3/2019 td''Private WithEvents mod_groupedMove As New ClassGroupMove(mod_designer) ''8/4/2019 td''New ClassGroupMove

    Private mod_oGroupMoveEvents As New GroupMoveEvents_Singleton(mod_designer, False) ''Added 1/4/2022 td  

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
        ''Jan9 2022 td''CtlGraphicStaticText1.LayoutFunctions = CType(mod_designer, ILayoutFunctions)

        ''Added 1/22/2022 td 
        ComponentClickIDFrontside1.PictureBoxControl = pictureBackgroundFront
        ComponentClickIDBackside1.PictureBoxControl = pictureBackgroundBackside
        ComponentClickIDFrontside1.ParentDesignerForm = Me ''pictureBackgroundFront
        ComponentClickIDBackside1.ParentDesignerForm = Me ''pictureBackgroundBackside

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
                    Me.ElementsCache_Edits.LoadNewElement_Signature(0, 0,
                                CtlGraphicSignature1.Width,
                                CtlGraphicSignature1.Height,
                                pictureBackgroundFront)
                End If ''End of "If (Me.ElementsCache_Edits.MissingTheSignature()) Then"

                .ElementClass_Obj = Me.ElementsCache_Edits.GetElementSig(False)

            End If ''End of "If (.ElementClass_Obj Is Nothing) Then"

            ''
            ''Set the path to the Signature File. 
            ''
            .ElementClass_Obj.SigFilePath = DiskFilesVB.PathToFile_Sig()

        End With ''End of "With CtlGraphicSignature1"

    End Sub ''End of "Public Sub New"

    Private Sub Form__Main_Demo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        ClassLabelToImage.Proportions_FixTheWidth(pictureBackgroundBackside) ''Added Dec. 14 2021
        ClassLabelToImage.Proportions_FixTheWidth(picturePreview)

        ''Double-check the proportions are correct. ---9/6/2019 td
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront, True)
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundBackside, True) ''Added Dec. 14 2021
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
        ''Dec.14 2021 td''Me.ElementsCache_Saved.Pic_InitialDefault = mod_imageLady
        If (Me.ElementsCache_Edits Is Nothing) Then
            MessageBox.Show("No cache is detected.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) ''Added 12/20/2021 td
            Return
        End If ''End of "If (Me.ElementsCache_Edits Is Nothing) Then"
        Me.ElementsCache_Edits.Pic_InitialDefault = mod_imageLady

        ''Added 12/5/2021 thomas d. 
        ''----++Moved below from here at 8:21 p.m. 12/5/2021 thomas downes
        ''----Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, Me.ElementsCache_Saved)

        ''Added 10/13/2019 thomas d. 
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_Portrait = Nothing ''Jan14 2022 td''CtlGraphicPortrait_Lady
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_QRCode = Nothing ''Jan14 2022 td''CtlGraphicQRCode1
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.CtlGraphic_Signat = Nothing ''Jan14 2022 td''CtlGraphicSignature1

        ''Added 11/29/2021 thomas downes
        ''++++/++++ I have removed the object reference from the mod_designer class.---1/8/2022 td
        ''++++mod_designer.CtlGraphic_StaticText_temp = CtlGraphicStaticText1

        ''Added 10/13/2019 thomas d.
        ''11/28/2021 Encapsulated to Load_Designer. 11/28/2021''
        mod_designer.DesignerForm_Interface = CType(Me, IDesignerForm)

        Me.Controls.Remove(CtlGraphicPortrait_Lady) ''Added 7/31/2019 thomas d. 
        Me.Controls.Remove(CtlGraphicSignature1) ''Added 10/12/2019 thomas d. 
        Me.Controls.Remove(CtlGraphicStaticText1) ''Added 12/19/2021 thomas d. 
        Me.Controls.Remove(CtlGraphicQRCode1) ''Added 1/14/2022 thomas d. 

        ''Added 10/11/2019 thomas downes 
        ''Jan9 2022 td''Me.CtlGraphicStaticText1.LayoutFunctions = CType(mod_designer, ILayoutFunctions)

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
        ''Dec14 2021''Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()

        ''Dec12 2021''Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generates a new GUID.
        ''Dec14 2021''With Me.ElementsCache_Saved
        ''    .Id_GUID = New Guid() ''Generates a new GUID. 
        ''    .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6) ''Added 12/12/2021  
        ''End With ''eND OF "With Me.ElementsCache_Saved"

        ''Added 12/5/2021 thomas d. 
        ''   Moved here from at 8:21 p.m. 12/5/2021 thomas downes
        ''----Dec14 2021---Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, Me.ElementsCache_Saved)
        Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, False, Me.ElementsCache_PathToXML) ''Added 12/14/2021 thomas d. 

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

        ''
        ''Context Menus!!  ----12/13/2021 td 
        ''
        Const c_bBaseControlWillLoadMenuCaches As Boolean = True ''True. See project __RSCWindowControlLibrary,
        ''  folder RSCMoveableControlVB, Sub AddClickability().  --1/5/2022 td
        Const c_bFormWillLoadMenuCaches As Boolean = False ''Added 1/5/2022 td

        If (c_bFormWillLoadMenuCaches) Then ''Added 1/5/2022 td

            MenuCache_FieldElements.ColorDialog1 = (New ColorDialog)
            MenuCache_FieldElements.FontDialog1 = (New FontDialog)
            MenuCache_FieldElements.Designer = mod_designer
            MenuCache_FieldElements.LayoutFunctions = mod_designer
            MenuCache_FieldElements.SelectingElements = mod_designer
            ''Dec.12 2021''MenuCache_ElemFlds.CacheOfFieldsEtc = Me.ElementsCache_Edits ''Added 12/12/2021 thomas d.
            Dim bool1, bool2 As Boolean  ''Added 12/12/2021 thomas d.
            Me.ElementsCache_ManageBoth.CheckCacheIsLatestForEdits(bool1, bool2, True) ''Added 12/12/2021 thomas d.
            MenuCache_FieldElements.GenerateMenuItems_IfNeeded(Me.ElementsCache_Edits)

            ''Added 12/13/2021 td
            MenuCache_GraphicElements.ColorDialog1 = (New ColorDialog)
            MenuCache_GraphicElements.Designer = mod_designer
            MenuCache_GraphicElements.LayoutFunctions = mod_designer
            MenuCache_GraphicElements.GenerateMenuItems_IfNeeded(Me.ElementsCache_Edits)

            MenuCache_Background.ColorDialog1 = (New ColorDialog)
            MenuCache_Background.Designer = mod_designer
            MenuCache_Background.LayoutFunctions = mod_designer
            MenuCache_Background.GenerateMenuItems_IfNeeded()

            ''Added 12/15/2021 td
            MenuCache_StaticText.ColorDialog1 = (New ColorDialog)
            MenuCache_StaticText.Designer = mod_designer
            MenuCache_StaticText.LayoutFunctions = mod_designer
            MenuCache_StaticText.GenerateMenuItems_IfNeeded(Me.ElementsCache_Edits)

        End If ''End of ""If (c_bFormWillLoadMenuCaches) Then""

        ''Added 12/3/2021 td
        pictureBackgroundFront.Refresh()

        ''Added 1/18/2022 thomas
        ComponentClickableDesktop1.InitializeClickability(Me, flowRelevantLinkLabels)
        ComponentClickableDesktop1.InitializeFunctionality(Me, Me, Me.mod_designer, Me.mod_designer)
        ComponentClickableDesktop1.AddClickability()

        ''Added 1/22/2022 thomas
        ComponentClickIDFrontside1.InitializeClickability(Me, flowRelevantLinkLabels)
        ComponentClickIDFrontside1.InitializeFunctionality(Me, Me, Me.mod_designer, Me.mod_designer)
        ComponentClickIDFrontside1.AddClickability()

        ''Added 1/22/2022 thomas
        ComponentClickIDBackside1.InitializeClickability(Me, flowRelevantLinkLabels)
        ComponentClickIDBackside1.InitializeFunctionality(Me, Me, Me.mod_designer, Me.mod_designer)
        ComponentClickIDBackside1.AddClickability()

    End Sub ''End of "Private Sub Form_Load"  


    Private Sub Unload_Designer(pboolResetToFrontOfCard As Boolean,
                                Optional pboolIncludePortrait As Boolean = True)
        ''
        ''Added 11/28/2021 thomas downes
        ''
        ''1/14/2022 td''mod_designer.UnloadDesigner(pboolResetToFrontOfCard)
        mod_designer.UnloadDesigner(pboolResetToFrontOfCard, pboolIncludePortrait)

        ''Added 12/14/20021 td 
        Me.CtlGraphicQRCode1 = Nothing
        Me.CtlGraphicSignature1 = Nothing
        Me.CtlGraphicStaticText1 = Nothing
        If (pboolIncludePortrait) Then Me.CtlGraphicPortrait_Lady = Nothing

    End Sub ''End of "Private Sub Unload_Designer()"  


    Private Sub Load_Designer()
        ''
        ''Encapsulated 11/28/2021 thomas downes
        ''
        Dim boolBacksideOfCard As Boolean ''Added 12/14/2021 td
        boolBacksideOfCard = (mod_designer.EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)

        ''Added 1/14/2022 td
        With ElementsCache_Edits
            If (.GetElementQR(False) IsNot Nothing) Then
                If (.GetElementQR(False).Image_BL Is Nothing) Then
                    .GetElementQR(False).Image_BL = My.Resources.QR_Code_Example
                End If
            End If
        End With

        ''Added 1/14/2022 td
        With ElementsCache_Edits
            If (.GetElementSig(False) IsNot Nothing) Then
                If (.GetElementSig(False).Image_BL Is Nothing) Then
                    .GetElementSig(False).Image_BL = My.Resources.Declaration_Sig_JPG
                End If
            End If
        End With

        ''If (CtlGraphicQRCode1 Is Nothing) Then
        ''    ''Added 12/3/2021 td  
        ''    ''----Dec6, 2021----CtlGraphicQRCode1 = New CtlGraphicQRCode
        ''    If (ElementsCache_Edits.ElementQRCode Is Nothing) Then Throw New Exception("The QR element is a null reference.")
        ''    ''1/2/2022 td''CtlGraphicQRCode1 = New CtlGraphicQRCode(ElementsCache_Edits.ElementQRCode, mod_designer)
        ''    CtlGraphicQRCode1 = CtlGraphicQRCode.GetQRCode(ElementsCache_Edits.ElementQRCode,
        ''                                   "CtlGraphicQRCode1", mod_designer, c_proportionalQR,
        ''                                    Nothing, LastControlTouched)
        ''    CtlGraphicQRCode1.Visible = True
        ''    Me.Controls.Add(CtlGraphicQRCode1)
        ''End If ''End of "If (CtlGraphicQRCode1 = Nothing) Then"
        ''
        ''''Added 12/12/2021 thomas  
        ''CtlGraphicQRCode1.Visible = True
        ''If (Controls.Contains(CtlGraphicQRCode1)) Then
        ''    If (False) Then MessageBox.Show("Let's not add a 2nd reference to the QR code.")
        ''Else
        ''    Me.Controls.Add(CtlGraphicQRCode1)
        ''End If ''ENd of "If (Controls.Contains(CtlGraphicQRCode1)) Then ... Else ..."

        ''Added 12/3/2021 thomas downes
        If (Me.PersonalityCache_Recipients Is Nothing) Then
            ''----Me.PersonalityCache_FutureUse = New ciBadgeElements.ClassElementsCache_Deprecated()
            Dim boolDummy As Boolean
            Me.PersonalityCache_Recipients = Startup.LoadCachedData_Personality_FutureUse(Me, boolDummy)
        End If ''End of "If (Me.PersonalityCache_FutureUse Is Nothing) Then"

        ''Added 10/13/2019 thomas d. 
        Const c_bLoadControlReferencesWithoutCheckingCache As Boolean = True ''False ''True
        If (c_bLoadControlReferencesWithoutCheckingCache) Then
            ''This code makes no reference to the elements cache, and so is pretty suspect!! ----1/14/2022
            mod_designer.CtlGraphic_Portrait = CtlGraphicPortrait_Lady
            mod_designer.CtlGraphic_QRCode = CtlGraphicQRCode1
            mod_designer.CtlGraphic_Signat = CtlGraphicSignature1
        End If ''End of "If (c_boolLoadControlReferencesWithoutCheckingCache) Then"
        ''+++/+++ I have removed this object reference from the mod_designer class. Jan8 2022 td
        ''+++mod_designer.CtlGraphic_StaticText_temp = CtlGraphicStaticText1 ''Added 11/30/2021 td

        ''Added 10/13/2019 thomas d.
        mod_designer.DesignerForm_Interface = CType(Me, IDesignerForm)

        With mod_designer

            .ElementsCache_UseEdits = Me.ElementsCache_Edits ''Added 10/10/2019 td 
            ''12/14/2021 td''.ElementsCache_Saved = Me.ElementsCache_Saved ''Added 10/10/2019 td 
            .ElementsCache_Manager = Me.ElementsCache_ManageBoth ''Added 12/14/2021 td

            ''Modified 12/3/2021 td 
            ''12/3/2021 td''.BackgroundBox = Me.pictureBack
            .BackgroundBox_Front = Me.pictureBackgroundFront
            .BackgroundBox_Backside = Me.pictureBackgroundBackside ''Added 12/10/2021 thomas downes
            .BackgroundBox_JustAButton = Me.pictureJustAButton ''Added 1/21/2022

            ''''Added 12/3/2021 thomas downes
            ''Dim objectBackgroundImage As Bitmap
            ''Dim strBackgroundImage_Path As String = ""
            ''Dim strBackgroundImage_Title As String = ""

            ''''12/14/2021''strBackgroundImage_Path = .ElementsCache_UseEdits.BackgroundImage_Front_Path
            ''strBackgroundImage_Path = .ElementsCache_UseEdits.GetBackgroundImage_Path(.EnumSideOfCard)
            ''If (strBackgroundImage_Path Is Nothing) Then strBackgroundImage_Path = ""

            ''If ("" = strBackgroundImage_Path) Then
            ''    strBackgroundImage_Path = DiskFilesVB.PathToFile_Background_FirstOrDefault(strBackgroundImage_Title)
            ''    ''.ElementsCache_Saved.BackgroundImage_Front_FTitle = strBackgroundImage_Title
            ''    ''.ElementsCache_Saved.BackgroundImage_Front_Path = strBackgroundImage_Path
            ''    .ElementsCache_UseEdits.BackgroundImage_Front_FTitle = strBackgroundImage_Title
            ''    .ElementsCache_UseEdits.BackgroundImage_Front_Path = strBackgroundImage_Path
            ''End If ''End of ''If ("" = strBackgroundImage_Path) The

            ''If (System.IO.File.Exists(strBackgroundImage_Path)) Then
            ''    objectBackgroundImage = New Bitmap(strBackgroundImage_Path)
            ''    If (boolBacksideOfCard) Then
            ''        .BackgroundBox_Backside.BackgroundImage = objectBackgroundImage
            ''    Else
            ''        .BackgroundBox_Front.BackgroundImage = objectBackgroundImage
            ''    End If ''end of "If (boolBacksideOfCard) Then... Else ..."
            ''End If ''End of "If (System.IO.File.Exists(strBackgroundImage_Path)) Then"

            .PreviewBox = Me.picturePreview
            .DesignerForm = Me
            .DesignerForm_DoubleCheckRef = Me ''Added 1/14/2022 td
            .FlowFieldsNotListed = Me.flowlayoutOmittedBin
            .CheckboxAutoPreview = Me.checkAutoPreview
            .CheckboxInstantPreview = Me.checkInstantPreview ''Added 12/6/2021 thomas d.
            ''10/10/2019 td''.ExamplePortraitImage = mod_imageLady
            .ExampleImage_Portrait = mod_imageLady

            .ExampleImage_Signature = mod_imageSignature ''Added 10/12/2019 td
            .StatusLabelWarningLabel = StatusLabelWarningError ''Added 12/22/2021 td
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
                Dim objElementPic As ClassElementPortrait ''Prior to 12/21/2021 td

                ''Fun with enumeration!!! 
                Const c_bEnumerationTechnicalWay As Boolean = True
                Const c_bEnumerationCleverWay As Boolean = False
                If (c_bEnumerationTechnicalWay) Then
                    Dim enumeratorPics As IEnumerator(Of ClassElementPortrait) ''Prior to 12/21/2021 td
                    enumeratorPics = Me.ElementsCache_Edits.ListOfElementPics_Front().GetEnumerator() ''Added 12/21/2021 td
                    If (enumeratorPics.Current Is Nothing) Then enumeratorPics.MoveNext() ''Added 12/21/2021 td
                    objElementPic = enumeratorPics.Current() ''Added 12/21/2021 td
                ElseIf (c_bEnumerationCleverWay) Then
                    For Each objElementPic In Me.ElementsCache_Edits.ListOfElementPics_Front()
                        ''The var. objElementPic is now assigned to the first object in the list. ---12/21/21
                        Exit For
                    Next objElementPic
                End If ''End of "If (c_bEnumerationTechnicalWay) Then ... ElseIf ..."

                ''
                ''If the Element-Portrait hasn't been found on the "Front" side of the ID Card,
                ''  then let's check the backside.  ---1/14/2022 td
                ''
                If (objElementPic Is Nothing) Then
                    ''Jan14 2022 ''System.Diagnostics.Debugger.Break()
                    For Each objElementPic In Me.ElementsCache_Edits.ListOfElementPics_Back()
                        ''The var. objElementPic is now assigned to the first object in the list. ---12/21/21
                        Exit For
                    Next objElementPic
                    If (objElementPic Is Nothing) Then
                        System.Diagnostics.Debugger.Break()
                    End If
                End If ''End of "If (objElementPic Is Nothing) Then"

                ''.Initial_Pic_Left = Me.ElementsCache_Edits.PicElement_Front().LeftEdge_Pixels
                ''.Initial_Pic_Top = Me.ElementsCache_Edits.PicElement_Front().TopEdge_Pixels
                ''.Initial_Pic_Width = Me.ElementsCache_Edits.PicElement_Front().Width_Pixels
                ''.Initial_Pic_Height = Me.ElementsCache_Edits.PicElement_Front().Height_Pixels

                If (objElementPic IsNot Nothing) Then ''Added 1/9/2022 thomas d. 
                    .Initial_Pic_Left = objElementPic.LeftEdge_Pixels
                    .Initial_Pic_Top = objElementPic.TopEdge_Pixels
                    .Initial_Pic_Width = objElementPic.Width_Pixels
                    .Initial_Pic_Height = objElementPic.Height_Pixels
                End If ''End of "If (objElementPic IsNot Nothing) Then"

            End If ''End of "If (Me.NewFileXML) Then .... Else ..."

            ''Added 12/12/2021
            If (Me.ElementsCache_Edits.BadgeHasTwoSidesOfCard) Then
                ''Added 12/12/2021
                ''  Change ">>> Add backside of ID Card." to ">>> Show backside of ID Card.".
                labelProceedToBackside.Text = labelProceedToBackside.Tag.ToString()

                ''Added 1/21/2022
                pictureJustAButton.Visible = True ''Added 1/21/2022
                pictureJustAButton.SendToBack() ''Added 1/21/2022

            End If ''end of "If (Me.ElementsCache_Edits.BadgeHasTwoSidesOfCard) Then"

            ''Added 1/14/2022 td
            .DesignerForm_DoubleCheckRef = Me

            ''
            ''Major call !!! 
            ''
            ''Jan4 2022 td''.LoadDesigner("Form__Main_Demo's Form_Load ", mod_oGroupMoveEvents)
            ''Jan26 2022 td''.LoadDesigner("Form__Main_Demo's Form_Load ", mod_oGroupMoveEvents)

            .StartWithBacksideOfCard = Me.LetsRefresh_CardBackside ''Added 1/26/2022

            ''
            ''Major call !!! 
            ''
            .LoadDesigner("Form__Main_Demo's Form_Load ", mod_oGroupMoveEvents, Me.LetsRefresh_CardBackside)
            Me.LetsRefresh_CardBackside = False ''Return to default value. ---1/26/2022

        End With ''ENd of "With mod_designer"

    End Sub ''End of "Private Sub LoadDesigner()"


    Public Sub RefreshElementsCache_Saved(par_cache As ClassElementsCache_Deprecated) Implements IDesignerForm.RefreshElementsCache_Saved
        ''
        ''Added 10/13/2019 td
        ''
        ''#1 12/14/2021 td''Me.ElementsCache_Saved = par_cache
        ''#1 12/14/2021 td''Me.ElementsCache_ManageBoth.RefreshElementsCache_Saved()

        ''Added Dec. 14 2021
        ''----Throw New NotImplementedException("I am unclear what this is for. In any case, call an existing or new Sub of ElementsCache_ManageBoth.")

        ElementsCache_ManageBoth.LoadBothCachesUsingSamePathToXML()

    End Sub ''End of "Public Sub RefreshElementsCache_Saved"


    Public Sub RefreshPreview() Implements IDesignerForm.RefreshPreview

        ''Added 12/27/2021
        mod_designer.RefreshPreview()

    End Sub



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
        Const c_serializeToDisk_Initially As Boolean = False
        Const c_serializeToDisk_Ultimately As Boolean = True

        ''12/12/2021 td''mod_designer.SaveLayout(False)
        mod_designer.SaveLayout(c_serializeToDisk_Initially)

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
        ''**-**Probably not needed, they are object references pointing to the same object.
        ''**Me.ElementsCache_Edits = mod_designer.ElementsCache_Edits
        ''---Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy()

        ''Dec14 2021''Me.ElementsCache_ManageBoth.Save()
        ''Moved to "Else" below. ''Const c_bCacheManagerSerializes As Boolean = False
        ''Moved to "Else" below. ''Me.ElementsCache_ManageBoth.Save(c_bCacheManagerSerializes)

        ''
        ''Serialize to disk (if constant is True) !!  
        ''
        If (c_serializeToDisk_Ultimately) Then
            ''
            ''Serialize to disk. 
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

                ''Added 1/13/2022  Copied from 12/10/2022 thomas d. 
                If (Not String.IsNullOrEmpty(.PathToXML)) Then
                    Dim strPathToFileJpg As String = ""
                    strPathToFileJpg = .PathToXML.Replace(".xml", ".jpg")
                    ''Create an image file (in JPEG form). ---1/5/2022 td 
                    ElementsCache_ManageBoth.CreateBadgeLayoutImageFile(Me.picturePreview.Image, strPathToFileJpg)
                End If ''End of "If (Not String.IsNullOrEmpty(...)) Then"

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
            ''Added 12/14/2021 td
            ''
            Dim strPathToXML As String
            strPathToXML = objSerializationClass.PathToXML
            Me.ElementsCache_ManageBoth.RefreshSaved_ViaPathXML(strPathToXML)

        Else
            ''Moved from above, Dec14 2021 td
            Const c_bCacheManagerSerializes As Boolean = False
            ''Jan5 2022 td''Me.ElementsCache_ManageBoth.Save(c_bCacheManagerSerializes)
            Me.ElementsCache_ManageBoth.Save(c_bCacheManagerSerializes, "", picturePreview.Image)

        End If ''Endof "If (c_serializeToDisk_Ultimately) Then ... Else ..."

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

        ''Added 1/5/2022 thomas d.
        ''My.Settings.PathToXML_Saved_ElementsCache = Me.ElementsCache_PathToXML
        ''My.Settings.PathToSavedXML_Last = Me.ElementsCache_PathToXML
        ''My.Settings.Save()
        Startup.SaveFullPathToFileXML(Me.ElementsCache_PathToXML)

        ''
        ''Step 2 of 3.  Decide the next step. 
        ''
        Const c_boolStartNewWindow As Boolean = True ''10/13/2019 td''False ''9/5 td'' True ''Added 9/3/2019 thomas d. 

        If (c_boolStartNewWindow) Then ''Added 9/3/2019 thomas d. 

            ''10/13 td''Dim frm_ToShow As New FormDesignProtoTwo()
            ''10/13 td''frm_ToShow.Show()

            Me.LetsRefresh_CloseForm = True ''Added 10/13/2019 td
            Me.LetsRefresh_CardBackside = (Me.mod_designer.ShowingTheBackside()) ''Added 1/26/2022 td
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
        ''Dec.14 2021''Me.mod_designer.RefreshPreview_Redux()
        Me.mod_designer.RefreshPreview_Redux_Front(Nothing, ClassElementField.oRecipient)

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
        Me.ElementsCache_Edits = Nothing ''Dump the current cache. ---12/14/2021 td

        ''Dec14 2021''Me.ElementsCache_Edits = Startup.LoadCachedData_Elements_Deprecated(Me, boolNew)
        Me.ElementsCache_Edits = Startup.LoadCachedData_Elements_Deprecated(Me, boolNew, Me.ElementsCache_PathToXML)

        ''Dec14 2021''Me.ElementsCache_Saved = Me.ElementsCache_Edits.Copy(False)
        ''Added Dec14 2021
        ''12/14/2021 td''Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits)
        Me.ElementsCache_ManageBoth = New ClassCacheManagement(Me.ElementsCache_Edits, False, Me.ElementsCache_PathToXML)

        ''Dec12 2021''Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generates a new GUID.
        ''Dec14 2021 td''With Me.ElementsCache_Saved
        ''    .Id_GUID = New Guid() ''Generates a new GUID. 
        ''    .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6) ''Added 12/12/2021  
        ''End With ''eND OF "With Me.ElementsCache_Saved"

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
            ''1/5/2022''mod_designer.LoadDesigner(strWhyCalled)
            ''1/26/2022''mod_designer.LoadDesigner(strWhyCalled, mod_oGroupMoveEvents)
            mod_designer.StartWithBacksideOfCard = Me.LetsRefresh_CardBackside
            mod_designer.LoadDesigner(strWhyCalled, mod_oGroupMoveEvents, Me.LetsRefresh_CardBackside)

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
        pictureJustAButton.SendToBack() ''Added 1/21/2022 td

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
        pictureJustAButton.SendToBack() ''Added 1/21/2022

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
        ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundBackside, True) ''Added 12/11/2021 td 
        ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview, True)

        ''Added 9/8/2019 td
        ''12/3/2021 td''ClassLabelToImage.ProportionsAreSlightlyOff(ctlBackgroundZoom1.Image, True)
        If pictureBackgroundFront.BackgroundImage IsNot Nothing Then
            ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundFront.BackgroundImage, True)
        End If
        If pictureBackgroundBackside.BackgroundImage IsNot Nothing Then
            ClassLabelToImage.ProportionsAreSlightlyOff(pictureBackgroundBackside.BackgroundImage, True) ''Added 12/11//2021 td 
        End If

        If picturePreview.Image IsNot Nothing Then
            ClassLabelToImage.ProportionsAreSlightlyOff(picturePreview.Image, True)
        End If

        ''
        ''Refresh the preview picture box. 
        ''
        ''10/3/2019 td''RefreshPreview()
        '' 1/13/2022 td''mod_designer.RefreshPreview_Redux_Front()
        mod_designer.RefreshPreview_CurrentSide()

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

        ''Added 1/18/2022 td
        Dim diag_res As DialogResult ''Added 1/18/2022 td
        diag_res = __RSCWindowsControlLibrary.MessageBoxTD.Show_QuestionYesNo("Confirm, remove **all** field-based elements (e.g. first name, last name, ID, etc.?")
        If (diag_res = DialogResult.None) Then
            Return
        ElseIf (diag_res <> DialogResult.Yes) Then
            __RSCWindowsControlLibrary.MessageBoxTD.Show_Statement("Unconfirmed, so we won't proceed.")
            Return
        End If

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
                each_controlField.ElementInfo_TextOnly = Nothing

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
        ''Dim objSerializationClass As New ciBadgeSerialize.ClassSerial
        ''With objSerializationClass

        ''    ''.TypeOfObject = (TypeOf List(Of ICIBFieldStandardOrCustom))
        ''
        ''    SaveFileDialog1.FileName = "" ''Added 11/24/2021 thomas downes
        ''    SaveFileDialog1.ShowDialog()
        ''    .PathToXML = SaveFileDialog1.FileName
        ''
        ''    ''Added 9/24/2019 thomas 
        ''    .SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)
        ''
        ''    Const c_SerializeToBinary As Boolean = False ''Added 9/30/2019 td
        ''    If (c_SerializeToBinary) Then _
        ''    .SerializeToBinary(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved)
        ''
        ''End With ''End of "With objSerializationClass"

        SaveFileDialog1.FileName = "" ''Added 11/24/2021 thomas downes
        SaveFileDialog1.InitialDirectory = My.Settings.PathToLastDirectoryForXMLFile
        SaveFileDialog1.FileName = My.Settings.FileTitleOfXMLFile

        SaveFileDialog1.ShowDialog()

        ''Added 12/17/2021 td 
        If (String.IsNullOrEmpty(SaveFileDialog1.FileName)) Then Return

        ''Added 12/14/2021 td
        If (IO.File.Exists(SaveFileDialog1.FileName)) Then

            ''Added 12/14/2021 td
            Dim bConfirmOverwrite As Boolean
            bConfirmOverwrite = (DialogResult.Yes = MessageBox.Show("Confirm overwrite?" &
                                                                    vbCrLf_Deux & SaveFileDialog1.FileName, "Confirm?",
                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))

            If (Not bConfirmOverwrite) Then MessageBox.Show("Confirmation incomplete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If (Not bConfirmOverwrite) Then Return

        ElseIf (Not IO.Directory.Exists(IO.Path.GetDirectoryName(SaveFileDialog1.FileName))) Then

            ''Added 12/14/2021 td 
            MessageBox.Show("Folder path is not recognized as an existing folder.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return

        End If ''ENdof "If (IO.File.Exists(SaveFileDialog1.FileName)) Then ... Else ..."

        ''Added 12/14/2021 td
        Dim strSaveFileAs_FullFileName As String
        strSaveFileAs_FullFileName = (SaveFileDialog1.FileName & ".xml").Replace(".xml.xml", ".xml")

        ElementsCache_Edits.PathToXml_Saved = strSaveFileAs_FullFileName  ''Save the file path. ---12/14/2021 td
        ElementsCache_Edits.XmlFile_Path_Deprecated = strSaveFileAs_FullFileName ''Save the full file path. ---12/14/2021 td
        Me.ElementsCache_PathToXML = strSaveFileAs_FullFileName  ''Save the file path. ----12/14/2021 td 
        Const c_bSaveToFileXML As Boolean = True
        ''Jan5 2022''ElementsCache_ManageBoth.Save(c_bSaveToFileXML, strSaveFileAs_FullFileName)
        ElementsCache_ManageBoth.Save(c_bSaveToFileXML, strSaveFileAs_FullFileName,
             picturePreview.Image)

        ''Added 12/14/2021 td 
        Dim boolSavedWell_Exists As Boolean
        Dim boolSavedWell_JustNow As Boolean
        Dim objFileInfo As IO.FileInfo
        Dim dateModified As Date
        ''Dim dateDiff As dateDifference

        ''Dec14 2021''boolSavedWell_Exists = (IO.File.Exists(SaveFileDialog1.FileName))
        boolSavedWell_Exists = (IO.File.Exists(strSaveFileAs_FullFileName))

        If (boolSavedWell_Exists) Then

            ''--objFileInfo = New IO.FileInfo(SaveFileDialog1.FileName)
            objFileInfo = New IO.FileInfo(strSaveFileAs_FullFileName)
            dateModified = objFileInfo.LastWriteTime()
            boolSavedWell_JustNow = ((DateTime.Now - dateModified).TotalSeconds < 15)

            If (Not boolSavedWell_JustNow) Then
                Throw New IO.FileNotFoundException("Why is the XML file-modify date " & dateModified.ToString("MM/dd HH:mm"))
            End If ''End of "If (Not boolSavedWell_JustNow) Then"

            ''Dec14 2021''Me.ElementsCache_PathToXML = SaveFileDialog1.FileName
            Me.ElementsCache_PathToXML = strSaveFileAs_FullFileName ''SaveFileDialog1.FileName
            Me.ElementsCache_Edits.XmlFile_FTitle_Deprecated = objFileInfo.Name ''Added 12/14/2021 

        Else
            Throw New IO.FileNotFoundException("where is XML file? file was not saved?")
        End If ''End of "If (boolSavedWell_Exists) Then ... Else ..."

        ''
        ''
        ''Save the new file XML in the Settings. 
        ''
        ''
        ''My.Settings.PathToLastDirectoryForXMLFile = objFileInfo.DirectoryName
        ''My.Settings.PathToSavedXML_Prior3 = My.Settings.PathToSavedXML_Prior2
        ''My.Settings.PathToSavedXML_Prior2 = My.Settings.PathToSavedXML_Prior1
        ''My.Settings.PathToSavedXML_Prior1 = My.Settings.PathToSavedXML_Last
        ''My.Settings.PathToSavedXML_Last = strSaveFileAs_FullFileName
        ''My.Settings.PathToXML_Saved_ElementsCache = strSaveFileAs_FullFileName
        ''My.Settings.Save()
        Startup.SaveFullPathToFileXML(strSaveFileAs_FullFileName)

        ''
        ''Specify the XML cache file, in the Window caption. ---12/14/2021 td 
        ''
        Dim strFileTitleXML As String ''Added 12/1/4/2021 td
        strFileTitleXML = (New IO.FileInfo(SaveFileDialog1.FileName)).Name
        Me.Text = String.Format("RSC ID Card - Desktop - {0} - {1}",
                                            strFileTitleXML, SaveFileDialog1.FileName)

        ''Not sure if this will be useful. ---12/14/2021 td
        ''My.Resources.PathToSavedXML_Prior6 = My.Resources.PathToSavedXML_Prior5
        ''My.Resources.PathToSavedXML_Prior5 = My.Resources.PathToSavedXML_Prior4
        ''My.Resources.PathToSavedXML_Prior4 = My.Resources.PathToSavedXML_Prior3
        ''My.Resources.PathToSavedXML_Prior3 = My.Resources.PathToSavedXML_Prior2
        ''My.Resources.PathToSavedXML_Prior2 = My.Resources.PathToSavedXML_Prior1
        ''My.Resources.PathToSavedXML_Prior1 = My.Resources.PathToSavedXML_Last
        ''My.Resources.PathToSavedXML_Last = SaveFileDialog1.FileName

        ''End If ''End of "If (IO.File.Exists(SaveFileDialog1.FileName)) Then"

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

        ''Added 1/5/2022 thomas downes
        s_strFolder = My.Settings.PathToLastDirectoryForXMLFile

        If (String.IsNullOrEmpty(s_strFolder)) Then s_strFolder = My.Application.Info.DirectoryPath

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = s_strFolder
        OpenFileDialog1.ShowDialog()

        ''Added 11/24/2021 
        Dim bConfirmFileExists As Boolean
        Dim strFullPathToXML As String ''Added 11/30/2021 td

        strFullPathToXML = OpenFileDialog1.FileName ''Added 11/30/2021 td
        bConfirmFileExists = System.IO.File.Exists(strFullPathToXML)

        If (Not bConfirmFileExists) Then
            ''Added 11/30/2021
            MessageBox.Show("Unable to open the file, unfortunately.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If ''End of "If (Not bConfirmFileExists) Then"

        ''
        ''Encapsulated 11/30/2021
        ''
        LoadBothCachesUsingSamePathToXML(strFullPathToXML)

        ''
        ''Save the file path to the form's String Property. ---12/15/2021 
        ''
        Me.ElementsCache_PathToXML = strFullPathToXML
        ''My.Settings.PathToXML_Saved_ElementsCache = strFullPathToXML
        ''My.Settings.Save()
        Startup.SaveFullPathToFileXML(strFullPathToXML)

        ''
        ''Specify the XML cache file, in the Window caption. ---12/14/2021 td 
        ''
        Dim strFileTitleXML As String ''Added 12/1/4/2021 td
        strFileTitleXML = (New IO.FileInfo(strFullPathToXML)).Name
        Me.Text = String.Format("RSC ID Card - Desktop - {0} - {1}",
                          strFileTitleXML, strFullPathToXML)

    End Sub


    Private Sub LoadBothCachesUsingSamePathToXML(par_strPathToXml As String,
                                           Optional ByRef pboolFailed As Boolean = False)
        ''
        ''Encapsulated 11/30/2021
        ''
        ''Dec14 2021 ''Throw New NotImplementedException("Use ElementsCache_ManageBoth.")

        With Me.ElementsCache_ManageBoth
            ''12/15/2021 td''Me.ElementsCache_Edits = .LoadBothCachesUsingSamePathToXML()
            Me.ElementsCache_Edits = .LoadBothCachesUsingSamePathToXML(par_strPathToXml)
        End With

        ''Dim objDeserial As New ciBadgeSerialize.ClassDeserial
        ''Dim bConfirmFileExists As Boolean
        ''''11/30/2021 td''Dim objCache As ClassDesignerListenToMover_Deprecated
        ''Dim objCache_FromXml_1 As ClassElementsCache_Deprecated
        ''Dim objCache_FromXml_2 As ClassElementsCache_Deprecated

        ''With objDeserial

        ''    .PathToXML = par_strPathToXml ''OpenFileDialog1.FileName

        ''    ''Added 11/24/2021 
        ''    bConfirmFileExists = System.IO.File.Exists(.PathToXML)
        ''    If (Not bConfirmFileExists) Then
        ''        pboolFailed = True
        ''        Return
        ''    End If

        ''    ''9/30 td''objCache =
        ''    ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

        ''    objCache_FromXml_1 =
        ''    CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

        ''    objCache_FromXml_2 =
        ''    CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

        ''End With ''End of "With objDeserial"

        ''''
        ''''Major call !!  
        ''''
        ''''++/++Does nothing. 11/30/2021 td
        ''''++Form__Main_PreDemo.OpenElementsCache(objCache)

        ''''Added 11/30/2021 thomas d. 
        ''Me.ElementsCache_Saved = objCache_FromXml_1
        ''Me.ElementsCache_Edits = objCache_FromXml_2

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
            ''Dec. 14 2021 td''Me.ElementsCache_Edits = Me.ElementsCache_Saved.Copy()
            Const c_boolUseSavedCache As Boolean = True ''Added 12/14/2021 td
            Me.ElementsCache_Edits = Me.ElementsCache_ManageBoth.UndoEdits(c_boolUseSavedCache)

            ''Added 10/13/2019 td
            mod_designer.ElementsCache_UseEdits = Me.ElementsCache_Edits

            ''
            ''Step 3 of 4.  Relink all of the elements to the controls. 
            ''
            Dim each_element As ClassElementField ''Added 10/13/2019 td

            ''Added 10/13/2019 td
            For Each each_ctl As CtlGraphicFldLabel In mod_designer.ListOfFieldLabels()

                each_element = Me.ElementsCache_Edits.GetElementByFieldEnum(each_ctl.FieldInfo.FieldEnumValue)
                each_ctl.ElementClass_Obj = each_element
                each_ctl.ElementInfo_Base = each_element
                ''Jan2 2022 td''each_ctl.ElementInfo_Field = each_element
                each_ctl.ElementInfo_TextField = each_element
                each_ctl.ElementInfo_TextOnly = each_element

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

    Private Sub mod_designer_ElementRightClicked(par_control As CtlGraphicFldLabel) Handles mod_designer.ElementFieldRightClicked
        ''
        ''Added 10/13/2019 thomas downes  
        ''
        MenuCache_FieldElements.CtlCurrentElement = par_control ''Added 10/14/2019 td  
        MenuCache_FieldElements.Operations_Edit.CtlCurrentElement = par_control ''Added 10/14/2019 td

        ContextMenuStrip1.Items.Clear()

        ''Add a ToolStripMenuItem which will tell which Field is being displayed 
        ''  on the selected (right-clicked) control. 
        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader0) ''Added 12/13/2021 
        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader1) ''Added 12/12/2021 

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then
            ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader2) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuHeader3) ''Added 12/13/2021 

            Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer_ElementRightClicked(...")
            Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementRightClicked")
            ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
            ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
            ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
            objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

        End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''Let's add a separator bar. 
        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuSeparator) ''Added 12/13/2021

        ''
        ''Major step!!!   Add all the editing-related menu items!!
        ''
        ContextMenuStrip1.Items.AddRange(MenuCache_FieldElements.Tools_EditElementMenu)

        ''Added 12/13/2021 td
        ''  Change the text "Field: {0} ({1})" to "Field: School Name (fstrField1)".
        With MenuCache_FieldElements.Tools_MenuHeader1
            ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
            .Text = String.Format(.Tag.ToString(), par_control.FieldInfo.FieldLabelCaption,
                                                    par_control.FieldInfo.CIBadgeField)
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader1"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        With MenuCache_FieldElements.Tools_MenuHeader0
            .Text = String.Format(.Tag.ToString(), par_control.Name)
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"

        ''10/13 td''ContextMenuStrip1.Show()
        ''10/13 td''ContextMenuStrip1.Show(par_control, New Point(par_control.Left, par_control.Top))
        ''12/28/2021 TD''ContextMenuStrip1.Show(par_control, New Point(0, 0))

        ''Added 12/28/2021 Thomas Downes
        Dim objDisplayMenu As New ClassDisplayContextMenu(ContextMenuStrip1)
        Const c_intRandom As Integer = 5
        With objDisplayMenu
            If (c_intRandom = 1) Then .ContextMenuDisplay(par_control)
            If (c_intRandom = 2) Then .ContextMenuOpen(par_control)
            If (c_intRandom = 3) Then .ContextMenuShow(par_control)
            If (c_intRandom = 4) Then .DisplayContextMenu(par_control)
            If (c_intRandom = 5) Then .DisplayPopupMenu(par_control)
            If (c_intRandom = 6) Then .DisplayRightclickMenu(par_control)
            If (c_intRandom = 7) Then .OpenContextMenu(par_control)
            If (c_intRandom = 8) Then .OpenPopupMenu(par_control)
            If (c_intRandom = 9) Then .OpenRightclickMenu(par_control)
        End With ''End of "With objDisplayMenu"

    End Sub ''End of "Private Sub mod_designer_ElementRightClicked"


    Private Sub mod_designer_ElementRightClicked(par_control As CtlGraphicPortrait) Handles mod_designer.ElementPortraitRightClicked
        ''
        ''Added 12/22/2021 thomas downes  
        ''
        MenuCache_FieldElements.CtlCurrentElement = Nothing ''par_control ''Added 10/14/2019 td  
        MenuCache_FieldElements.Operations_Edit.CtlCurrentElement = Nothing ''par_control ''Added 10/14/2019 td

        ContextMenuStrip1.Items.Clear()

        ''Add a ToolStripMenuItem which will tell which Field is being displayed 
        ''  on the selected (right-clicked) control. 
        ContextMenuStrip1.Items.Add(MenuCache_Portrait.Tools_MenuHeader0) ''Added 12/13/2021 
        ContextMenuStrip1.Items.Add(MenuCache_Portrait.Tools_MenuHeader1) ''Added 12/12/2021 

        Dim bool_addExtraHeadersToContextMenus As Boolean ''Added 12/13/2021 td
        bool_addExtraHeadersToContextMenus = AddExtraHeadersToolStripMenuItem.Checked

        ''Added header items. 
        If (bool_addExtraHeadersToContextMenus) Then
            ''Added 12/13/2021 
            ContextMenuStrip1.Items.Add(MenuCache_Portrait.Tools_MenuHeader2) ''Added 12/12/2021 
            ContextMenuStrip1.Items.Add(MenuCache_Portrait.Tools_MenuHeader3) ''Added 12/13/2021 

            Dim objMenuHeader3_1 As New ToolStripMenuItem("mod_designer.ElementPortraitRightClicked(...")
            Dim objMenuHeader3_2 As New ToolStripMenuItem("   ... Handles mod_designer.ElementPortraitRightClicked")
            ContextMenuStrip1.Items.Add(objMenuHeader3_1) ''Added 12/13/2021 
            ''Dec.13 ''ContextMenuStrip1.Items.Add(objMenuHeader3_2) ''Added 12/13/2021 
            ''  Make 3_2 a sub-item under 3_1. ---12/13/2021 td 
            objMenuHeader3_1.DropDownItems.Add(objMenuHeader3_2)

        End If ''End of "If (mod_letsAddExtraHeadersForContextMenus) Then"

        ''Let's add a separator bar. 
        ContextMenuStrip1.Items.Add(MenuCache_FieldElements.Tools_MenuSeparator) ''Added 12/13/2021

        ''
        ''Major step!!!   Add all the editing-related menu items!!
        ''
        ContextMenuStrip1.Items.AddRange(MenuCache_FieldElements.Tools_EditElementMenu)

        ''Added 12/13/2021 td
        ''  Change the text "Control: {0}" to "Control: CtlGraphicPortrait1".
        With MenuCache_Portrait.Tools_MenuHeader1
            ''Dim objHeader1 As ToolStripItem = MenuCache_ElemFlds.Tools_MenuHeader1
            .Text = String.Format(.Tag.ToString(), par_control.Name)
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader1"

        ''Added 12/13/2021 td
        ''  Change the text "Context-Menu for Control: {0}" to "Context-Menu for Control: ....".
        With MenuCache_FieldElements.Tools_MenuHeader0
            .Text = String.Format(.Tag.ToString(), par_control.Name)
        End With ''End of "With MenuCache_ElemFlds.Tools_MenuHeader0"

        ''12/28/2021 TD''ContextMenuStrip1.Show(par_control, New Point(0, 0))

        ''Added 12/28/2021 Thomas Downes
        Dim objDisplayMenu As New ClassDisplayContextMenu(ContextMenuStrip1)
        Const c_intRandom As Integer = 5
        With objDisplayMenu
            If (c_intRandom = 1) Then .ContextMenuDisplay(par_control)
            If (c_intRandom = 2) Then .ContextMenuOpen(par_control)
            If (c_intRandom = 3) Then .ContextMenuShow(par_control)
            If (c_intRandom = 4) Then .DisplayContextMenu(par_control)
            If (c_intRandom = 5) Then .DisplayPopupMenu(par_control)
            If (c_intRandom = 6) Then .DisplayRightclickMenu(par_control)
            If (c_intRandom = 7) Then .OpenContextMenu(par_control)
            If (c_intRandom = 8) Then .OpenPopupMenu(par_control)
            If (c_intRandom = 9) Then .OpenRightclickMenu(par_control)
        End With ''End of "With objDisplayMenu"

    End Sub ''End of "Private Sub mod_designer_ElementRightClicked"


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

            mod_designer.RefreshPreview_Redux_Front()

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

                '' Dec18 2021 td''img_Prod = objBadgeGenerator.MakeBadgeImage_ByRecipient(Me.BadgeLayout,
                img_Prod = objBadgeGenerator.MakeBadgeImage_ByRecipient_Front(Me.BadgeLayout,
                                        pictureBackgroundFront.BackgroundImage,
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

        mod_designer.RefreshPreview_Redux_Front()
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

        mod_designer.RefreshPreview_Redux_Front()
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
        Me.ElementsCache_Edits.BackgroundImage_Front_Path = objShow.ImageFilePath
        Me.ElementsCache_Edits.BackgroundImage_Front_Path = objShow.ImageFileInfo.Name

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
        Dim bBacksideOfCard As Boolean ''Added 12/10/2021 td

        If (objShow.ImageFileInfo IsNot Nothing) Then
            strPathToFilename = objShow.ImageFileInfo.FullName
            ''ClassElementsCache_Deprecated.Singleton.BackgroundImage_Path = strPathToFilename
            '' 12/3/2021 td''ctlBackgroundZoom1.ImageLocation = strPathToFilename
            '' 12/3/2021 td''PictureBox1.ImageLocation = strPathToFilename

            ''Dec.13 2021''bBacksideOfCard = (mod_designer.EnumSideOfCard = modFactoryControls.EnumWhichSideOfCard.EnumBackside)
            bBacksideOfCard = (mod_designer.EnumSideOfCard_Current = EnumWhichSideOfCard.EnumBackside)

            If (bBacksideOfCard) Then
                ''Backside of Card.  
                pictureBackgroundBackside.BackgroundImage = (New Bitmap(strPathToFilename))
                pictureBackgroundBackside.BackgroundImageLayout = ImageLayout.Zoom
                Me.ElementsCache_Edits.BackgroundImage_Backside_Path = strPathToFilename
                Me.ElementsCache_Edits.BackgroundImage_Backside_FTitle = objShow.ImageFileInfo.Name
            Else
                ''Frontside of card. 
                pictureBackgroundFront.BackgroundImage = (New Bitmap(strPathToFilename))
                pictureBackgroundFront.BackgroundImageLayout = ImageLayout.Zoom
                ''Added 12/3/2021 td
                Me.ElementsCache_Edits.BackgroundImage_Front_Path = strPathToFilename
                Me.ElementsCache_Edits.BackgroundImage_Front_FTitle = objShow.ImageFileInfo.Name
            End If ''eNd of "If (bBacksideOfCard) Then ,,,, Else ..."


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


    Public Function SizeAnyRSCMoveableControl() As Size Implements IDesignerForm.SizeAnyRSCMoveableControl
        ''Jan19 2022''Public Function HeightAnyRSCMoveableControl() As Size Implements IDesignerForm.SizeAnyRSCMoveableControl
        ''
        ''Added 1/18/2022 thomas d.
        ''
        Dim each_RSC As __RSCWindowsControlLibrary.RSCMoveableControlVB
        Dim boolSuccess As Boolean ''Added 1/22/2022 thomas d. 
        Dim intExceptions As Integer = 0 ''Added 1/22/2022 thomas d.
        Dim intSuccesses As Integer = 0 ''Added 1/22/2022 thomas d.
        Dim objSize_output As New Size ''Added 1/22/2022

        Dim intCountOfControls As Integer ''Added 1/23/2022
        Dim intCountOfControls_NonZero As Integer ''Added 1/23/2022
        Dim intSumOfHeights As Integer ''Added 1/23/2022
        Dim intSumOfWidths As Integer ''Added 1/23/2022

        For Each each_control As Control In Me.Controls
            ''
            ''Added 1/24/2022 thomas downes
            ''
            intCountOfControls += 1

            If (each_control.Width = 0) Then Continue For
            If (each_control.Height = 0) Then Continue For

            intCountOfControls_NonZero += 1

            ''--If (TypeOf each_control Then '' Is __RSCWindowsControlLibrary) Then
            Try
                each_RSC = CType(each_control, __RSCWindowsControlLibrary.RSCMoveableControlVB)
                objSize_output = each_RSC.Size
                intSuccesses += 1 ''Added 1/22/2022 thomas d.
                boolSuccess = True ''Added 1/22/2022 thomas d.
                ''Return each_RSC.Height
            Catch
                intExceptions += 1 ''Added 1/22/2022 thomas d.
            End Try
            ''--End If

        Next each_control

        Return objSize_output

    End Function ''End of "Public Function SizeAnyRSCMoveableControl() As Size"


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
        ''  If confirmed, show the backside of the card. 
        ''
        Dim bTwoSidesExist As Boolean = (Me.ElementsCache_Edits.BadgeHasTwoSidesOfCard)

        If (bTwoSidesExist) Then
            ''
            ''Proceed with the procedure, display the backside of the badge.
            ''   ---12/12/2021 td
            ''
        Else
            ''Added 12/12/2021 thomas downes
            Dim diag_result As DialogResult
            diag_result = MessageBox.Show("Are you sure you want to add a 2nd side?", "Confirm",
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button3)
            If (diag_result <> DialogResult.Yes) Then Return ''Exit the procedure.
            Me.ElementsCache_Edits.BadgeHasTwoSidesOfCard = True
        End If ''End of "If (bTwoSidesExist) Then ... Else ..."

        ''
        ''Encapsulated 1/26/2022 td
        ''
        ProceedToBackside()

    End Sub

    Public Sub ProceedToBackside()
        ''
        ''Encapsulated 1/26/2022 td
        ''
        ''Display the text ">>> Show backside of card" 
        ''  instead of ">>> Add backside of card".
        ''  ---12/12/2021 
        labelProceedToBackside.Text = labelProceedToBackside.Tag.ToString()

        ''Dec.10 2021 thomas downes
        Unload_Designer(False)

        pictureBackgroundBackside.Visible = True ''By default, when the form opens, this control is invisible. 
        pictureBackgroundFront.SendToBack()

        pictureJustAButton.Visible = True ''Added 1/21/2022
        pictureJustAButton.SendToBack() ''Added 1/21/2022

        Dim boolSuccess As Boolean

        mod_designer.DesignerForm_DoubleCheckRef = Me ''Added 1/14/2022 td

        ''Major call!! 
        mod_designer.SwitchSideOfCard(boolSuccess)
        mod_designer.BackgroundBox_Front = pictureBackgroundBackside
        mod_designer.BackgroundBox_JustAButton = pictureJustAButton ''Added 1/21/2022

        If (boolSuccess) Then
            labelProceedToBackside.Visible = False
            LabelReturnToFrontSide.Visible = True
            labelBacksideOfBadgecard.Visible = True ''Added 12/10/2021 thomas
        End If ''End of "If (boolSuccess) Then"

    End Sub ''End of "Public Sub ProceedToBackside()"


    Public Sub ProceedToBackSide_SetupBacksideLabels() Implements IDesignerForm.ProceedToBackSide_SetupBacksideLabels
        ''
        ''Added 1/26/2022 thomas
        ''
        ''Display the text ">>> Show backside of card" 
        ''  instead of ">>> Add backside of card".
        ''  ---12/12/2021 
        labelProceedToBackside.Text = labelProceedToBackside.Tag.ToString()
        labelProceedToBackside.Visible = False
        LabelReturnToFrontSide.Visible = True
        labelBacksideOfBadgecard.Visible = True ''Added 12/10/2021 thomas

    End Sub ''End of  Public Sub ProceedToBackSide_SetupBacksideLabels()


    Private Sub ExitRecipientModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitRecipientModeToolStripMenuItem.Click
        ''
        ''Added 12/8/2021 thomas downes
        ''
        flowSidebar.Visible = False
        ClassElementField.iRecipientInfo = Nothing
        ClassElementField.oRecipient = Nothing
        mod_designer.RefreshPreview_Redux_Front()

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

        pictureBackgroundFront.SendToBack() ''Added 1/14/2022 td 
        pictureBackgroundBackside.SendToBack()
        mod_designer.BackgroundBox_Front = pictureBackgroundFront

        pictureJustAButton.SendToBack() ''Added 1/21/2022 td
        mod_designer.BackgroundBox_JustAButton = pictureJustAButton ''Added 1/21/2022

    End Sub

    Private Sub CloseListOfRecipentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseListOfRecipentsToolStripMenuItem.Click

        ''Added 12/14/2021 td 
        ''---ExitRecipientModeToolStripMenuItem.PerformClick()
        ExitRecipientModeToolStripMenuItem_Click(sender, e)

    End Sub

    Private Sub Form__Main_Demo_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        ''
        ''Added 1/16/2022 td
        ''
        If (e.Button = MouseButtons.Right) Then
            ComponentClickableDesktop1.ParentDesignerForm = Me
            ComponentClickableDesktop1.ClickableDesktop_MouseUp(sender, e)
        End If

    End Sub

    Private Sub pictureJustAButton_Click(sender As Object, e As EventArgs) Handles pictureJustAButton.Click
        ''
        ''Added 1/21/2022 td
        ''
        If (LabelReturnToFrontSide.Visible) Then

            LabelReturnToFrontSide_Click(pictureBackgroundBackside, New EventArgs)

        Else

            labelProceedToBackside_Click(pictureBackgroundFront, New EventArgs)

        End If


    End Sub

    Private Sub pictureBackgroundFront_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBackgroundFront.MouseUp
        ''
        ''Added 1/16/2022 td
        ''
        If (e.Button = MouseButtons.Right) Then
            ComponentClickIDFrontside1.ParentDesignerForm = Me
            ComponentClickIDFrontside1.ParentControl = pictureBackgroundFront
            ComponentClickIDFrontside1.ClickableDesktop_MouseUp(sender, e)
        End If ''End of "If (e.Button = MouseButtons.Right) Then"

    End Sub

    Private Sub pictureBackgroundBackside_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBackgroundBackside.MouseUp
        ''
        ''Added 1/22/2022 td
        ''
        If (e.Button = MouseButtons.Right) Then
            ComponentClickIDBackside1.ParentDesignerForm = Me
            ComponentClickIDBackside1.ParentControl = pictureBackgroundFront
            ComponentClickIDBackside1.ClickableDesktop_MouseUp(sender, e)
        End If ''End of "If (e.Button = MouseButtons.Right) Then"

    End Sub

    ''Public Sub RecordElementLastTouched(par_elementMoved As IMoveableElement, par_elementClicked As IClickableElement) Implements IRecordLastTouched.RecordElementLastTouched
    ''    ''
    ''    ''Added 12/17/2021 td
    ''    ''
    ''    ''----Throw New NotImplementedException()
    ''    Me.LastTouchedClickableElement = par_elementClicked
    ''    Me.LastTouchedMoveableElement = par_elementMoved

    ''End Sub



End Class