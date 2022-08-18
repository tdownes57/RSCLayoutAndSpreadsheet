Option Explicit On ''Added 8/03/2022 td
Option Strict On ''Added 8/03/2022 td
''
''Added 7/28/2022 Thomas Downes 
''
Imports __RSCWindowsControlLibrary ''Added 7/29/2022 td 
Imports ciBadgeElements ''Added 8/03/2022 td 
Imports ciBadgeInterfaces ''Added 8/04/2022 thomas d. 

Public Class Dialog_Base
    Implements ILayoutFunctions ''Added 8/5/2022 td
    ''
    ''Added 7/28/2022 Thomas Downes 
    ''
    Protected mod_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4
    Protected mod_controlRSCMoveable As RSCMoveableControlVB
    Protected mod_elementBase As ciBadgeElements.ClassElementBase ''Added 7/29/2022 td
    Protected mod_elementInfo_Base As ciBadgeInterfaces.IElement_Base ''Added 8/03/2022 td

    Protected ControlBelongsToPanel As Boolean = False ''Added 7/28/2022 td

    Private mod_bLetsUseEnumeratedArrowLR As Boolean
    Private mod_enumArrowLeftOrRight As EnumArrowIsWhere

    Private mod_listRSCColors As HashSet(Of RSCColor) ''Added 8/10/2022 td
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


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    ''Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
    ''               par_elementBase As ciBadgeElements.ClassElementBase,
    ''               par_imageOfBadge As Drawing.Image)
    ''
    ''    ''Added 7/29/2022 thomas 
    ''    PanelDisplayElement.BackgroundImage = par_imageOfBadge
    ''End Sub


    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_listRSCColors As HashSet(Of RSCColor),
                   par_elementBase As ciBadgeElements.ClassElementBase,
                   par_infoElementBase As ciBadgeInterfaces.IElement_Base,
                   par_designer As ciBadgeDesigner.ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        Try
            ' Add any initialization after the InitializeComponent() call.
            mod_controlFieldOrTextV4 = par_controlFieldOrTextV4
            mod_controlRSCMoveable = par_controlFieldOrTextV4 ''Added 7/29/2022 td
            mod_elementBase = par_elementBase ''Added 7/29/2022 thomas d.  
            mod_elementInfo_Base = par_infoElementBase ''Added 8/3/2022 
            mod_objEventsRSC_Elem = par_events ''Added 8/06/2022 td

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

                panelArrowLeft.Top = .Top
                panelArrowLeft.Left = .Left - panelArrowLeft.Width

            End If ''End of ""If (Me.ControlBelongsToPanel) Then""

        End With ''End of ""With mod_controlFieldOrTextV4""

    End Sub ''End of ""Public Sub New"" 


    Public Sub New(par_controlRSCMoveable As RSCMoveableControlVB,
                   par_elementBase As ciBadgeElements.ClassElementBase)

        ' This call is required by the designer.
        InitializeComponent()

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


    Public Function Layout_Width_Pixels() As Integer Implements ILayoutFunctions.Layout_Width_Pixels
        ''Added 9/3/2019 thomas downes
        ''8/5/2022 td Return Me.BackgroundBox_Front.Width
        Return Me.panelDisplayElement.Width
    End Function ''End of "Public Function Layout_Width_Pixels() As Integer"

    Public Function Layout_Height_Pixels() As Integer Implements ILayoutFunctions.Layout_Height_Pixels
        ''Added 9/11/2019 Never Forget 
        ''8/5/2022 td Return Me.BackgroundBox_Front.Height
        Return Me.panelDisplayElement.Height
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
            Return Nothing
        End Get
        Set(value As Control)
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

                    panelArrowLeft.Top = .Top
                    panelArrowLeft.Left = .Left - panelArrowLeft.Width

                End With ''End of ""With mod_controlRSCMoveable""

            Else
                Me.Controls.Add(mod_controlFieldOrTextV4)

                ''---''Center the control within the Panel, even if it doesn't belong to the Panel. 
                ''---.Left = PanelDisplayElement.Left + CInt((PanelDisplayElement.Width - .Width) / 2)
                ''---.Top = PanelDisplayElement.Top + CInt((PanelDisplayElement.Height - .Height) / 2)

                ''Added 8/3/2022 td
                ''8/04/2022 td''.Left = PanelDisplayElement.Left + par_element.Left
                ''8/04/2022 td''.Top = PanelDisplayElement.Top + par_element.Top

                If (0 = par_element.TopEdge_bPixels) Then System.Diagnostics.Debugger.Break()
                If (0 = par_element.LeftEdge_bPixels) Then System.Diagnostics.Debugger.Break()

                .Top = panelDisplayElement.Top + par_element.TopEdge_bPixels
                .Left = panelDisplayElement.Left + par_element.LeftEdge_bPixels

                ''Arrow should point to the control
                panelArrowLeft.Top = .Top
                panelArrowLeft.Left = .Left - panelArrowLeft.Width

                ''Added 8/3/2022
                panelArrowLeft.Visible = True
                panelArrowRight.Visible = False

            End If ''End of ""If (ControlBelongsToPanel) Then... Else..."

        End With ''end of ""With par_control"  

    End Sub ''End of ""Protected Sub PositionElement""


    Private Sub PositionArrow(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
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

                    If (panelArrowLeft.Left < 0) Then
                        ''
                        ''Not okay, might look a bit lame.
                        ''   Let's switch to the right-side gold arrow.
                        ''
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                        panelArrowLeft.Visible = False
                        panelArrowRight.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftOrRight)
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement

                    Else
                        ''
                        ''The left-side gold arrow works fine.
                        ''
                        ''Added 8/3/2022
                        panelArrowLeft.Visible = True
                        panelArrowRight.Visible = False
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement

                    End If 'end of ""If (panelArrowLeft.Left < 0) Then... Else....""

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

                    If (panelArrowLeft.Left < 0) Then
                        ''
                        ''Not okay, might look a bit lame.
                        ''   Let's switch to the right-side gold arrow.
                        ''
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                        panelArrowLeft.Visible = False
                        panelArrowRight.Visible = True
                        PositionArrow(par_control, mod_enumArrowLeftOrRight)
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement
                    Else
                        ''
                        ''The left-side gold arrow works fine.
                        ''
                        ''Added 8/3/2022
                        panelArrowLeft.Visible = True
                        panelArrowRight.Visible = False
                        ''Added 8/6/2022
                        mod_bLetsUseEnumeratedArrowLR = True
                        mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement

                    End If 'end of ""If (panelArrowLeft.Left < 0) Then ... Else...""

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

        panelArrowRight.Visible = True
        intArrowWidth = panelArrowRight.Width
        panelArrowLeft.Visible = False

        With par_control

            If (Me.ControlBelongsToPanel) Then

                panelArrowRight.Top = .Top + panelDisplayElement.Top
                panelArrowRight.Left = .Left - intArrowWidth + panelDisplayElement.Left

            Else

                panelArrowRight.Top = .Top
                ''8/4/2022''panelArrowRight.Left = .Left - intArrowWidth
                panelArrowRight.Left = .Left + .Width

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

            ''
            ''Added 8/6/2022 td
            ''
            If (panelArrowLeft.Height > .Height) Then
                ''Added 8/6/2022 td
                panelArrowLeft.Height = .Height
            End If ''eND OF ""If (panelArrowLeft.Height > .Height) Then""

        End With ''ENd of ""With par_control""

        panelArrowRight.BringToFront() ''Added 8/6/2022 = True ''Added 8/6/2022 

    End Sub ''End of ""Private Sub PositionArrow_Right(par_control As RSCMoveableControlVB)""


    Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)
        ''
        ''Added 7/29/2022
        ''
        Dim intArrowWidth As Integer

        panelArrowLeft.Visible = True
        panelArrowRight.Visible = False
        intArrowWidth = panelArrowLeft.Width

        With par_control

            If (Me.ControlBelongsToPanel) Then

                panelArrowLeft.Top = par_control.Top + panelDisplayElement.Top
                panelArrowLeft.Left = par_control.Left - intArrowWidth + panelDisplayElement.Left

            Else

                panelArrowLeft.Top = par_control.Top
                panelArrowLeft.Left = par_control.Left - intArrowWidth

            End If ''end of ""If (Me.ControlBelongsToPanel) Then.... Else..."

            ''Added 8/6/2022 td
            If (panelArrowLeft.Height > .Height) Then
                ''Added 8/6/2022 td
                panelArrowLeft.Height = .Height
            End If ''eND OF ""If (panelArrowLeft.Height > .Height) Then""

        End With ''ENd of ""With par_control""

        panelArrowLeft.BringToFront() ''Added 8/6/2022 = True ''Added 8/6/2022 


    End Sub ''End of ""Private Sub PositionArrow_Left(par_control As RSCMoveableControlVB)""


    Private Sub Dialog_Base_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 7/28/2022 Thomas Downes 
        ''
        ''#1 8/4/2022 mod_objLayoutFunctions = New ciBadgeInterfaces.BadgeLayoutClass
        ''#2 8/4/2022 mod_objLayoutFunctions = New ciBadgeDesigner.
        ''#3 8/4/2022 panelArrowLeft.AddMoveability(mod_objLayoutFunctions)
        ''#3 8/4/2022 panelArrowRight.AddMoveability(mod_objLayoutFunctions)

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

            panelArrowLeft.AddMoveability(mod_objLayoutFunctions, mod_objEventsRSC_Gold)
            panelArrowRight.AddMoveability(mod_objLayoutFunctions, mod_objEventsRSC_Gold)

        Else

            panelArrowLeft.AddMoveability(Me, mod_objEventsRSC_Gold)
            panelArrowRight.AddMoveability(Me, mod_objEventsRSC_Gold)

        End If ''End of "" If (mod_c_bCreateDesignerObject) Then... Else..."

        ''
        ''Added 8/6/2022
        ''
        panelArrowLeft.RemoveSizeability()
        panelArrowRight.RemoveSizeability()

ExitHandler:
        mod_bLoading = False

    End Sub ''End of ... Handles Form_Load  

    Private Sub CheckBoxArrow_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxArrowVisible.CheckedChanged

        ''Added 8/6/2022
        If mod_bLoading Then Exit Sub

        ''Added 7/29/2022
        If (checkBoxArrowVisible.Checked) Then

            panelArrowLeft.Visible = (mod_enumArrowLeftOrRight = EnumArrowIsWhere.LeftOfElement)
            panelArrowRight.Visible = (mod_enumArrowLeftOrRight = EnumArrowIsWhere.RightOfElement)

        Else
            panelArrowLeft.Visible = False
            panelArrowRight.Visible = False

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
        Throw New NotImplementedException()
    End Function

    Public Sub AutoPreview_IfChecked(Optional par_controlElement As Control = Nothing, Optional par_stillMoving As Boolean = False) Implements ILayoutFunctions.AutoPreview_IfChecked
        ''Added 8/6/2022
        Throw New NotImplementedException()
    End Sub

    Public Function RightClickMenu_Parent() As ToolStripMenuItem Implements ILayoutFunctions.RightClickMenu_Parent
        ''Added 8/6/2022
        Throw New NotImplementedException()
    End Function

    Public Function NameOfForm() As String Implements ILayoutFunctions.NameOfForm
        ''Added 8/6/2022
        Throw New NotImplementedException()
    End Function

    Public Sub RedrawForm() Implements ILayoutFunctions.RedrawForm
        ''Added 8/6/2022
        Throw New NotImplementedException()
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

    Private Sub ButtonFont_Click(sender As Object, e As EventArgs) Handles ButtonFont.Click
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
                                                       mod_listRSCColors,
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

    Private Sub ButtonColor_Click(sender As Object, e As EventArgs) Handles ButtonColor.Click
        ''
        ''Added 8/07/2022 thomas downes
        ''
        Dim listRSCColors As HashSet(Of RSCColor) ''Added 8/10/2022 thomas
        listRSCColors = mod_listRSCColors

        Dim objFormToShow As New Dialog_BaseChooseColor(mod_controlFieldOrTextV4,
                                       mod_listFontFamilyNames,
                                       listRSCColors,
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
        End If ''ENd of ""If (Me.Controls.Contains(mod_controlFieldOrTextV4) = False) Then""

    End Sub
End Class