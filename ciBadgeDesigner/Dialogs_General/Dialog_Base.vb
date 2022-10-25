Option Explicit On ''Added 8/03/2022 td
Option Strict On ''Added 8/03/2022 td
''
''Added 7/28/2022 Thomas Downes 
''
Imports __RSCWindowsControlLibrary ''Added 7/29/2022 td 
Imports ciBadgeElements ''Added 8/03/2022 td 
Imports ciBadgeInterfaces ''Added 8/04/2022 thomas d. 
Imports ciBadgeCachePersonality ''Added 10/24/2022 td

Public Class Dialog_Base
    Implements ILayoutFunctions ''Added 8/5/2022 td
    ''
    ''Added 7/28/2022 Thomas Downes 
    ''
    Protected mod_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4
    Protected mod_controlRSCMoveable As RSCMoveableControlVB
    Protected mod_elementBase As ciBadgeElements.ClassElementBase ''Added 7/29/2022 td
    Protected mod_elementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/03/2022 td
    Protected mod_controlLastTouched As Control ''Added 9/01/2022 

    Protected ControlBelongsToPanel As Boolean = False ''Added 7/28/2022 td

    Private mod_bLetsUseEnumeratedArrowLR As Boolean
    Private mod_enumArrowLeftOrRight As EnumArrowIsWhere

    Private mod_elementsCache As ClassElementsCache_Deprecated ''Added 10/24/2022 thomas d.
    ''#1 10/12/2022 Private mod_listRSCColors As List(Of RSCColor) ''Added 8/10/2022 td
    ''#2 10/12/2022 Private mod_listRSCColors As HashSet(Of RSCColor) ''Added 8/10/2022 td
    Private mod_listRSCColors As List(Of RSCColor) ''Added 8/10/2022 td
    Private mod_hashRSCColors As HashSet(Of RSCColor) ''Added 8/10/2022 td
    Private mod_listFontFamilyNames As HashSet(Of String) ''Added 8/10/2022 td

    ''8/4/2022 Private mod_objLayoutFunctions As ciBadgeInterfaces.BadgeLayoutClass ''Added 8/04/2022 
    Private mod_designerParentForm As ciBadgeDesigner.ClassDesigner ''Added 8/05/2022
    Private mod_objLayoutFunctions As ciBadgeDesigner.ClassDesigner ''Added 8/04/2022 
    Private WithEvents mod_objEventsRSC_Elem As GroupMoveEvents_Singleton ''Added 8/4/2022 td
    Private WithEvents mod_objEventsRSC_Gold As GroupMoveEvents_Singleton ''Added 8/4/2022 td
    Private Const mod_c_bCreateDesignerObject As Boolean = False ''Added 8/6/2022 td
    Private mod_bLoading As Boolean = True ''Added 8/6/2022

    Private Enum EnumArrowIsWhere
        Undetermined
        LeftOfElement
        RightOfElement
    End Enum


    Public Const LayoutWidth_Pixels As Integer = 603
    Public Const LayoutHeight_Pixels As Integer = 380

    Public Shared Function GetBadgeLayoutClass() As BadgeLayoutDimensionsClass
        ''
        ''Added 8/18/2022 thomas downes
        ''
        Dim obj_dimensions = New BadgeLayoutDimensionsClass()

        obj_dimensions.Width_Pixels = LayoutWidth_Pixels
        obj_dimensions.Height_Pixels = LayoutHeight_Pixels
        Return obj_dimensions

    End Function ''End of ""Public Shared Function GetBadgeLayoutClass() As BadgeLayoutDimensionsClass""


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 8/18/2022 
        panelDisplayElement.Width = Dialog_Base.LayoutWidth_Pixels
        panelDisplayElement.Height = Dialog_Base.LayoutHeight_Pixels

        ''Added 9/3/2022
        Me.LayoutDebugName = "Dialog_Base"
        Me.LayoutDebugDescription = "The editing a single element. Panel for ID background is full size. (Dialog_Base)"

    End Sub


    ''Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
    ''               par_elementBase As ciBadgeElements.ClassElementBase,
    ''               par_imageOfBadge As Drawing.Image)
    ''
    ''    ''Added 7/29/2022 thomas 
    ''    PanelDisplayElement.BackgroundImage = par_imageOfBadge
    ''End Sub

    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_elementsCache As ciBadgeCachePersonality.ClassElementsCache_Deprecated,
                   par_elementBase As ciBadgeElements.ClassElementBase,
                   par_infoElementBase As ciBadgeInterfaces.IElement_Base,
                   par_designer As ciBadgeDesigner.ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)
        ''
        ''Added 10/24/2022 
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ''Encapsulated 10/24/2022
        New_Load(par_controlFieldOrTextV4,
                   par_elementsCache.ListOfFontFamilyNames,
                   par_elementsCache.ListOfRSCColors,
                   par_elementBase,
                   par_infoElementBase,
                   par_designer, par_events,
                   par_imageOfBadge)

        ''Added 10/24/2022 thomas d.
        mod_elementsCache = par_elementsCache

    End Sub



    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_hashRSCColors As HashSet(Of RSCColor),
                   par_elementBase As ciBadgeElements.ClassElementBase,
                   par_infoElementBase As ciBadgeInterfaces.IElement_Base,
                   par_designer As ciBadgeDesigner.ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ''
        ''Encapsulated 10/24/2022 td
        ''
        New_Load(par_controlFieldOrTextV4,
                   par_listFontFamilyNames,
                   par_hashRSCColors,
                   par_elementBase,
                   par_infoElementBase,
                   par_designer, par_events,
                   par_imageOfBadge)

    End Sub


    Private Sub New_Load(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_hashRSCColors As HashSet(Of RSCColor),
                   par_elementBase As ciBadgeElements.ClassElementBase,
                   par_infoElementBase As ciBadgeInterfaces.IElement_Base,
                   par_designer As ciBadgeDesigner.ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)
        ''
        ''Encapsulated 10/24/2022 td
        ''
        ' This call is required by the designer.
        ''Not needed in the encapsulation. 10./24/2022 InitializeComponent()

        ''Added 8/18/2022 
        panelDisplayElement.Width = Dialog_Base.LayoutWidth_Pixels
        panelDisplayElement.Height = Dialog_Base.LayoutHeight_Pixels

        Try
            ' Add any initialization after the InitializeComponent() call.
            mod_controlFieldOrTextV4 = par_controlFieldOrTextV4
            mod_controlRSCMoveable = par_controlFieldOrTextV4 ''Added 7/29/2022 td
            mod_elementBase = par_elementBase ''Added 7/29/2022 thomas d.  
            mod_elementInfo_Base = par_infoElementBase ''Added 8/3/2022 
            mod_objEventsRSC_Elem = par_events ''Added 8/06/2022 td

            mod_hashRSCColors = par_hashRSCColors ''Added 10/12/2022
            mod_listRSCColors = par_hashRSCColors.ToList() ''Added 10/12/2022

            ''8/4/2022 mod_objLayoutFunctions = par_designer ''Added 8/4/2022 td
            mod_designerParentForm = par_designer ''Added 8/05/2022 td

            If (mod_c_bCreateDesignerObject) Then ''Added 8/6/2022 td
                ''Added 8/6/2022 td
                mod_objLayoutFunctions = New ClassDesigner() ''Added 8/4/2022 td
                mod_controlRSCMoveable.LayoutFunctions = mod_objLayoutFunctions

            Else
                ''Added 8/6/2022 td
                mod_controlRSCMoveable.LayoutFunctions = Me
                mod_controlFieldOrTextV4.LayoutFunctions = Me

            End If ''End of ""If (mod_c_bCreateDesignerObject) Then... Else..."

            ''Added 7/29/2022 td
            panelDisplayElement.BackgroundImage = par_imageOfBadge

            ''Encapsulated 7/29.2022  thomas downes
            PositionElement(mod_controlFieldOrTextV4, mod_elementBase)
            PositionArrow(mod_controlFieldOrTextV4) ''Added 8/03/2022 td

            mod_controlFieldOrTextV4.Visible = True
            mod_controlFieldOrTextV4.BringToFront()


        Catch ex_MyBaseNew As Exception
            ''
            ''Added 8/17/2022 td
            ''
            System.Diagnostics.Debugger.Break()

        End Try


ExitHandler:

        With mod_controlFieldOrTextV4
            ''
            ''Center the control. 
            ''
            If (Me.ControlBelongsToPanel) Then
                .Left = CInt((panelDisplayElement.Width - .Width) / 2)
                .Top = CInt((panelDisplayElement.Height - .Height) / 2)

                RscElementArrowLeft1.Top = .Top
                RscElementArrowLeft1.Left = .Left - RscElementArrowLeft1.Width

            End If ''End of ""If (Me.ControlBelongsToPanel) Then""

        End With ''End of ""With mod_controlFieldOrTextV4""

        ''Added 9/3/2022
        Me.LayoutDebugName = "Dialog_Base"
        Me.LayoutDebugDescription = "The editing a single element. Panel for ID background is full size. (Dialog_Base)"

    End Sub ''End of ""Public Sub New_Load"" 


    Public Sub New(par_controlRSCMoveable As RSCMoveableControlVB,
                   par_elementBase As ciBadgeElements.ClassElementBase)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 8/18/2022 
        panelDisplayElement.Width = Dialog_Base.LayoutWidth_Pixels
        panelDisplayElement.Height = Dialog_Base.LayoutHeight_Pixels

        ' Add any initialization after the InitializeComponent() call.
        mod_controlRSCMoveable = par_controlRSCMoveable ''Added 7/29/2022 td
        mod_elementBase = par_elementBase ''Added 7/29/2022 thomas d.  

        ''Added 8/6/2022 td
        mod_controlRSCMoveable.LayoutFunctions = Me

        ''Added 7/29/2022 thomas downes
        ''7/29/2022 td ''With mod_controlFieldOrTextV4
        With mod_controlRSCMoveable
            ''
            ''Add the control to the appropriate Controls collection.
            ''Center the control. 
            ''
            PositionElement(par_controlRSCMoveable, mod_elementBase)
            PositionArrow(par_controlRSCMoveable) ''Added 8/3/2022 td

            ''7/29/2022 If (ControlBelongsToPanel) Then
            ''    ''
            ''    ''Add the control to the panel. Centering will happen at the ExitHandler.
            ''    ''
            ''    ''7/29/2022 Me.PanelDisplayElement.Controls.Add(mod_controlFieldOrTextV4)
            ''    Me.PanelDisplayElement.Controls.Add(mod_controlRSCMoveable)
            ''
            ''7/29/2022 Else
            ''    ''7/29/2022 Me.Controls.Add(mod_controlFieldOrTextV4)
            ''    Me.Controls.Add(mod_controlRSCMoveable)
            ''    ''Center the control within the Panel, even if it doesn't belong to the Panel. 
            ''    .Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
            ''    .Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)
            ''    ''Arrow should point to the control
            ''    panelArrow.Top = .Top
            ''    panelArrow.Left = .Left - panelArrow.Width

            ''End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With

        ''7/29/2022 mod_controlFieldOrTextV4.Visible = True
        ''7/29/2022 mod_controlFieldOrTextV4.BringToFront()
        mod_controlRSCMoveable.Visible = True
        mod_controlRSCMoveable.BringToFront()

ExitHandler:

        ''7/29/2022 With mod_controlFieldOrTextV4
        ''With mod_controlRSCMoveable
        ''    ''
        ''    ''Center the control. 
        ''    ''
        ''    If (Me.ControlBelongsToPanel) Then
        ''        .Left = CInt((PanelDisplayElement.Width - .Width) / 2)
        ''        .Top = CInt((PanelDisplayElement.Height - .Height) / 2)
        ''
        ''        panelArrow.Top = .Top
        ''        panelArrow.Left = .Left - panelArrow.Width
        ''
        ''    End If ''End of ""If (Me.ControlBelongsToPanel) Then""
        ''
        ''End With ''End of ""With mod_controlRSCMoveable""

    End Sub ''End of ""Public Sub New"" 


    ''Added 9/03/2022 thomas downes
    Public Property LayoutDebugName As String Implements ILayoutFunctions.LayoutDebugName
    Public Property LayoutDebugDescription As String Implements ILayoutFunctions.LayoutDebugDescription


    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes
        ''8/5/2022 td Return Me.BackgroundBox_Front.Width
        ''8/17/2022 td Return Me.panelDisplayElement.Width
        Return Dialog_Base.LayoutWidth_Pixels

    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/11/2019 Never Forget 
        ''8/5/2022 td Return Me.BackgroundBox_Front.Height
        ''8/17/2022 td Return Me.panelDisplayElement.Height
        Return Dialog_Base.LayoutHeight_Pixels

    End Function ''End of "Public Function Layout_Height_Pixels() As Integer"

    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes

        ''Added 9/05/2019 td 
        ''8/05/2022 td ''Return (par_intPixelsLeft - Me.BackgroundBox_Front.Left)
        Return (par_intPixelsLeft - Me.panelDisplayElement.Left)

    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        ''8/05/2022 td ''Return (par_intPixelsLeft - Me.BackgroundBox_Front.Left)
        Return (par_intPixelsLeft + Me.panelDisplayElement.Left)

    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        ''8/05/2022 td ''Return (par_intPixelsTop - Me.BackgroundBox_Front.Top)
        Return (par_intPixelsTop - Me.panelDisplayElement.Top)

    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        ''8/05/2022 td ''Return (par_intPixelsTop + Me.BackgroundBox_Front.Top)
        Return (par_intPixelsTop + Me.panelDisplayElement.Top)

    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"


    Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved ''Added 8/4/2019 td
        Get
            Return Nothing
        End Get
        Set(value As Control)
        End Set
    End Property ''End of "Public Property ControlBeingMoved() As Control Implements ILayoutFunctions.ControlBeingMoved"

    Public Property ControlBeingModified() As Control _
        Implements ILayoutFunctions.ControlBeingModified ''Added 8/9/2019 td
        Get
            ''9/1/2022 Return Nothing
            Return mod_controlLastTouched
        End Get
        Set(value As Control)
            mod_controlLastTouched = value
        End Set
    End Property ''End of "Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified"


    Public Property ControlThatWasClicked() As Control _
        Implements ILayoutFunctions.ControlThatWasClicked ''Added 8/9/2019 td
        Get
            Return mod_controlLastTouched
        End Get
        Set(value As Control)
            mod_controlLastTouched = value
        End Set
    End Property ''End of "Public Property ControlBeingModified() As Control Implements ILayoutFunctions.ControlBeingModified"


    Protected Sub PositionElement(par_control As RSCMoveableControlVB,
                                  par_element As ClassElementBase)
        ''
        ''Added 7/29/2022, 7/28/2022 thomas downes
        ''
        ''7/29/2022 With mod_controlFieldOrTextV4
        With par_control
            ''
            ''Add the control to the appropriate Controls collection.
            ''Center the control. 
            ''
            If (ControlBelongsToPanel) Then
                ''
                ''Add the control to the panel. Centering will happen at the ExitHandler.
                ''
                Me.panelDisplayElement.Controls.Add(mod_controlFieldOrTextV4)

                ''7/29/2022 With mod_controlFieldOrTextV4
                With mod_controlRSCMoveable
                    ''
                    ''Center the control within the panel. 
                    ''
                    .Left = CInt((panelDisplayElement.Width - .Width) / 2)
                    .Top = CInt((panelDisplayElement.Height - .Height) / 2)

                    RscElementArrowLeft1.Top = .Top
                    RscElementArrowLeft1.Left = .Left - RscElementArrowLeft1.Width

                End With ''End of ""With mod_controlRSCMoveable""

            Else
                Me.Controls.Add(mod_controlFieldOrTextV4)

                ''---''Center the control within the Panel, even if it doesn't belong to the Panel. 
                ''---.Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
                ''---.Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)

                ''Added 8/3/2022 td
                ''8/04/2022 td''.Left = PanelDisplayElement.Left + par_element.Left
                ''8/04/2022 td''.Top = PanelDisplayElement.Top + par_element.Top

                If (0 = par_element.TopEdge_Pixels) Then System.Diagnostics.Debugger.Break()
                If (0 = par_element.LeftEdge_Pixels) Then System.Diagnostics.Debugger.Break()

                ''9/05/2022 .Top = panelDisplayElement.Top + par_element.TopEdge_bPixels
                ''9/05/2022 .Left = panelDisplayElement.Left + par_element.LeftEdge_bPixels
                .Top = panelDisplayElement.Top + par_element.TopEdge_Pixels
                .Left = panelDisplayElement.Left + par_element.LeftEdge_Pixels

                ''Arrow should point to the control
                RscElementArrowLeft1.Top = .Top
                RscElementArrowLeft1.Left = .Left - RscElementArrowLeft1.Width

                ''Added 8/3/2022
                RscElementArrowLeft1.Visible = True
                RscElementArrowRight1.Visible = False

            End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With ''end of ""With par_control"  

    End Sub ''End of ""Protected Sub PositionElement""


    Private Sub PositionArrow(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        With panelDisplayElement
            ''Remove the arrow panels from the ID-card display box. ---8/22/2022
            If (.Controls.Contains(RscElementArrowLeft1)) Then .Controls.Remove(RscElementArrowLeft1)
            If (.Controls.Contains(RscElementArrowRight1)) Then .Controls.Remove(RscElementArrowRight1)
        End With

        With Me ''The parent form (dialog).
            ''Add the arrow panels to the form, if needed. ---8/22/2022 
            If (Not .Controls.Contains(RscElementArrowLeft1)) Then .Controls.Add(RscElementArrowLeft1)
            If (Not .Controls.Contains(RscElementArrowRight1)) Then .Controls.Add(RscElementArrowRight1)
        End With

        With par_control

            If (Me.ControlBelongsToPanel) Then
                ''
                ''The element is "locked" within the Panel (or Picture Box).
                ''
                If (mod_bLetsUseEnumeratedArrowLR) Then

                    PositionArrow(par_control, mod_enumArrowLeftOrRight)

                Else
                    ''
                    ''Major call!!  Let's try the Left side, as a first-pass attempt.
                    ''
                    PositionArrow(par_control, EnumArrowIsWhere.LeftOfElement)

                    If (RscElementArrowLeft1.Left < 0) Then
                        ''
                        ''Not okay, might look a bit lame.
                        ''   Let's switch to the right-side gold arrow.
                        ''
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                        RscElementArrowLeft1.Visible = False
                        RscElementArrowRight1.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftOrRight)
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement

                    Else
                        ''
                        ''The left-side gold arrow works fine.
                        ''
                        ''Added 8/3/2022
                        RscElementArrowLeft1.Visible = True
                        RscElementArrowRight1.Visible = False
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement

                    End If 'end of ""If (RscElementArrowLeft1.Left < 0) Then... Else....""

                End If ''End of ""If (mod_bCheckArrowLR) Then... Else..."


            Else
                ''
                ''The element is free to move about the form....
                ''  __NOT__ "locked" within the Panel (or Picture Box).
                ''
                If (mod_bLetsUseEnumeratedArrowLR) Then

                    PositionArrow(par_control, mod_enumArrowLeftOrRight)

                Else
                    ''
                    ''Major call!!  Let's try the Left side, as a first-pass attempt.
                    ''
                    PositionArrow(par_control, EnumArrowIsWhere.LeftOfElement)

                    If (RscElementArrowLeft1.Left < 0) Then
                        ''
                        ''Not okay, might look a bit lame.
                        ''   Let's switch to the right-side gold arrow.
                        ''
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                        RscElementArrowLeft1.Visible = False
                        RscElementArrowRight1.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftOrRight)
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                    Else
                        ''
                        ''The left-side gold arrow works fine.
                        ''
                        ''Added 8/3/2022
                        RscElementArrowLeft1.Visible = True
                        RscElementArrowRight1.Visible = False
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement

                    End If 'end of ""If (RscElementArrowLeft1.Left < 0) Then ... Else...""

                End If ''End of ""If (mod_bCheckArrowLR) Then... Else..."

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

        End With ''End of ""With par_control""


    End Sub ''End of ""Private Sub PositionArrow(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow(par_control As RSCMoveableControlVB, par_enum As EnumArrowIsWhere)
        ''
        ''Added 7/29/2022
        ''
        If (par_enum = EnumArrowIsWhere.RightOfElement) Then

            PositionArrow_Right(par_control)

        Else
            PositionArrow_Left(par_control)

        End If ''End of ""If (par_enum = EnumArrowIsWhere.RightOfElement) Then.... Else..."

    End Sub ''End of ""Private Sub PositionArrow(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow_Right(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        Dim intArrowWidth As Integer

        RscElementArrowRight1.Visible = True
        intArrowWidth = RscElementArrowRight1.Width
        RscElementArrowLeft1.Visible = False

        With par_control

            If (Me.ControlBelongsToPanel) Then

                RscElementArrowRight1.Top = .Top + panelDisplayElement.Top
                RscElementArrowRight1.Left = .Left - intArrowWidth + panelDisplayElement.Left

            Else

                RscElementArrowRight1.Top = .Top
                ''8/4/2022''RscElementArrowLef1.Left = .Left - intArrowWidth
                RscElementArrowRight1.Left = .Left + .Width

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

            ''
            ''Added 8/6/2022 td
            ''
            If (RscElementArrowLeft1.Height > .Height) Then
                ''Added 8/6/2022 td
                RscElementArrowLeft1.Height = .Height
            End If ''eND OF ""If (RscElementArrowLeft1.Height > .Height) Then""

        End With ''ENd of ""With par_control""

        RscElementArrowRight1.BringToFront() ''Added 8/6/2022 = True ''Added 8/6/2022 

    End Sub ''End of ""Private Sub PositionArrow_Right(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        Dim intArrowWidth As Integer

        RscElementArrowLeft1.Visible = True
        RscElementArrowRight1.Visible = False
        intArrowWidth = RscElementArrowLeft1.Width

        With par_control

            If (Me.ControlBelongsToPanel) Then

                RscElementArrowLeft1.Top = par_control.Top + panelDisplayElement.Top
                RscElementArrowLeft1.Left = par_control.Left - intArrowWidth + panelDisplayElement.Left

            Else

                RscElementArrowLeft1.Top = par_control.Top
                RscElementArrowLeft1.Left = par_control.Left - intArrowWidth

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

            ''Added 8/6/2022 td
            If (RscElementArrowLeft1.Height > .Height) Then
                ''Added 8/6/2022 td
                RscElementArrowLeft1.Height = .Height
            End If ''eND OF ""If (RscElementArrowLeft1.Height > .Height) Then""

        End With ''ENd of ""With par_control""

        RscElementArrowLeft1.BringToFront() ''Added 8/6/2022 = True ''Added 8/6/2022 


    End Sub ''End of ""Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)""


    Private Sub Dialog_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/28/2022 Thomas Downes 
        ''
        ''#1 8/4/2022 mod_objLayoutFunctions = New ciBadgeInterfaces.BadgeLayoutClass
        ''#2 8/4/2022 mod_objLayoutFunctions = New ciBadgeDesigner.
        ''#3 8/4/2022 RscElementArrowLeft1.AddMoveability(mod_objLayoutFunctions)
        ''#3 8/4/2022 RscElementArrowRight1.AddMoveability(mod_objLayoutFunctions)

        ''Added 8/6/2022
        checkBoxArrowVisible.Checked = True
        checkArrowMovesWithElem.Checked = True

        ''Added 8/4/2022
        If (mod_objEventsRSC_Gold Is Nothing) Then
            mod_objEventsRSC_Gold = New GroupMoveEvents_Singleton(mod_objLayoutFunctions, True, True)
        End If ''End of ""If (mod_objEventsRSC Is Nothing) Then""

        If (mod_c_bCreateDesignerObject) Then

            mod_objLayoutFunctions.BackgroundBox_Front = panelDisplayElement
            mod_objLayoutFunctions.ElementsCache_UseEdits = mod_designerParentForm.ElementsCache_UseEdits
            mod_objLayoutFunctions.LoadDesigner("Loading Dialog_Base", False, False, mod_objEventsRSC_Elem)

            RscElementArrowLeft1.AddMoveability(mod_objLayoutFunctions, mod_objEventsRSC_Gold)
            RscElementArrowRight1.AddMoveability(mod_objLayoutFunctions, mod_objEventsRSC_Gold)

        Else

            RscElementArrowLeft1.AddMoveability(Me, mod_objEventsRSC_Gold)
            RscElementArrowRight1.AddMoveability(Me, mod_objEventsRSC_Gold)

        End If ''End of "" If (mod_c_bCreateDesignerObject) Then... Else..."

        ''
        ''Added 8/6/2022
        ''
        RscElementArrowLeft1.RemoveSizeability()
        RscElementArrowRight1.RemoveSizeability()

ExitHandler:
        mod_bLoading = False

    End Sub ''End of ... Handles Form_Load  

    Private Sub CheckBoxArrow_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxArrowVisible.CheckedChanged

        ''Added 8/6/2022
        If mod_bLoading Then Exit Sub

        ''Added 7/29/2022
        If (checkBoxArrowVisible.Checked) Then

            RscElementArrowLeft1.Visible = (mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement)
            RscElementArrowRight1.Visible = (mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement)

        Else
            RscElementArrowLeft1.Visible = False
            RscElementArrowRight1.Visible = False

        End If ''Endof "" If (checkBoxArrowVisible.Checked) Then... Else..." 

    End Sub

    Private Sub PanelDisplayElement_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        ''Added 8/2/2022
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 8/2/2022
        Me.Close()

    End Sub

    Public Function OkayToShowFauxContextMenu() As Boolean Implements ILayoutFunctions.OkayToShowFauxContextMenu
        ''Added 8/6/2022
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        ''Added 8/6/2022
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Sub

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent
        ''Added 8/6/2022
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        ''Added 8/6/2022
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Function

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        ''Added 8/6/2022
        ''9/1/2022 Throw New NotImplementedException()
        System.Diagnostics.Debugger.Break()
    End Sub

    Private Sub mod_objEventsRSC_Moving_End(par_control As Control, par_iSaveToModel As ISaveToModel) Handles mod_objEventsRSC_Elem.Moving_End

        ''Added 8/6/2022
        ''8/6/2022 td ''PositionArrow(mod_controlRSCMoveable)

        If (checkArrowMovesWithElem.Checked = False) Then

            Exit Sub

        ElseIf (mod_controlFieldOrTextV4 IsNot Nothing) Then

            PositionArrow(mod_controlFieldOrTextV4)

        Else
            PositionArrow(mod_controlRSCMoveable)

        End If ''End of ""If (mod_controlFieldOrTextV4 IsNot Nothing) Then..Else.. ""

    End Sub

    Private Sub ButtonFont_Click(sender As Object, e As EventArgs) Handles buttonFont.Click
        ''
        ''Added 8/07/2022 thomas downes
        ''
        ''8/07/2022 Dim objFormToShow As New Dialog_BaseEditElement(Me.CtlCurrentFieldOrTextV4,
        ''                      Me.ElementObject_Base,
        ''                      Me.ElementInfo_Base,
        ''                      Me.Designer,
        ''                      Me.Designer.GroupMoveEvents,
        ''                      imageOfBadgeSansElement)
        Dim objFormToShow As New Dialog_BaseChooseFont(mod_controlFieldOrTextV4,
                                                       mod_listFontFamilyNames,
                                                       mod_hashRSCColors,
                                       mod_elementBase,
                                       mod_elementInfo_Base,
                                       mod_designerParentForm,
                                       mod_objEventsRSC_Elem,
                                       panelDisplayElement.BackgroundImage)

        objFormToShow.ShowDialog()

ExitHandler:
        ''Added 8/07/2022
        If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then
            Me.Controls.Add(mod_controlFieldOrTextV4)
            mod_controlFieldOrTextV4.BringToFront()
        End If ''ENd of ""If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then""

    End Sub

    Private Sub ButtonColor_Click(sender As Object, e As EventArgs) Handles buttonColor.Click
        ''
        ''Added 8/07/2022 thomas downes
        ''
        Dim listRSCColors As List(Of RSCColor) ''Added 8/10/2022 thomas
        Dim hashRSCColors As HashSet(Of RSCColor) ''Added 8/10/2022 thomas

        listRSCColors = mod_listRSCColors
        hashRSCColors = mod_hashRSCColors

        ''Dim objFormToShow As New Dialog_BaseChooseColor(mod_controlFieldOrTextV4,
        ''                               mod_listFontFamilyNames,
        ''                               hashRSCColors,
        ''                               mod_elementBase,
        ''                               mod_elementInfo_Base,
        ''                               mod_designerParentForm,
        ''                               mod_objEventsRSC_Elem,
        ''                               panelDisplayElement.BackgroundImage)
        Dim objFormToShow As New Dialog_BaseChooseColor(mod_controlFieldOrTextV4,
                                       mod_elementsCache,
                                       mod_elementBase,
                                       mod_elementInfo_Base,
                                       mod_designerParentForm,
                                       mod_objEventsRSC_Elem,
                                       panelDisplayElement.BackgroundImage)

        objFormToShow.ShowDialog()

ExitHandler:
        ''Added 8/07/2022
        If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then
            Me.Controls.Add(mod_controlFieldOrTextV4)
            mod_controlFieldOrTextV4.BringToFront()
        End If ''ENd of ""If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then""

    End Sub

    Private Sub ButtonBorder_Click(sender As Object, e As EventArgs) Handles buttonBorder.Click
        ''
        ''Added 8/19/2022 thomas downes
        ''
        Dim objFormToShow As New Dialog_BaseBorder(mod_controlFieldOrTextV4, mod_elementBase)
        objFormToShow.ShowDialog()

ExitHandler:
        ''Added 8/07/2022
        If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then
            Me.Controls.Add(mod_controlFieldOrTextV4)
            mod_controlFieldOrTextV4.BringToFront()
        End If ''ENd of ""If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then""

    End Sub

    Private Sub buttonRotation_Click(sender As Object, e As EventArgs) Handles buttonRotation.Click
        ''
        ''Added 8/19/2022 thomas downes
        ''
        Dim objFormToShow As New Dialog_BaseRotation(mod_controlFieldOrTextV4, mod_elementBase)
        objFormToShow.ShowDialog()

ExitHandler:
        ''Added 8/07/2022
        If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then
            Me.Controls.Add(mod_controlFieldOrTextV4)
            mod_controlFieldOrTextV4.BringToFront()
        End If ''ENd of ""If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then""

    End Sub
End Class