Option Explicit On
Option Strict On
''
''Added 5/18/2022 
''
''---Imports MoveAndResizeControls_Monem
Imports __RSCWindowsControlLibrary
Imports ciBadgeInterfaces ''Added 5/18/2022 td

Public Class CtlMoveableBackground
    ''
    ''Added 5/18/2022 
    ''
    Public Event ElementGraphic_RightClicked(par_control As UserControl) ''Added 5/18/2022 td
    Public Event ElementGraphic_LeftClicked(par_control As UserControl) ''Added 5/18/2022 td

    Private mod_strImageFileLocation As String = ""
    Private mod_designer As New ClassDesigner
    ''5/18/2022 Private mod_objEventsMoveGroupOfCtls As New MonemControlMove_AllFunctionality
    Private mod_objGroupMoveEvents As ciBadgeInterfaces.GroupMoveEvents_Singleton ''(mod_designer)
    Private mod_objSingleMoveEvents As ciBadgeInterfaces.GroupMoveEvents_Singleton ''(mod_designer)
    Private mod_image As Drawing.Image ''Added 6/3/2022 td

    Public Property ImageFileLocation As String
        ''
        ''Added 5/18/2022 
        ''
        Get
            Return mod_strImageFileLocation
        End Get
        Set(value As String)
            mod_strImageFileLocation = value

        End Set

    End Property


    Public Property ImageBackgroundImage As Drawing.Image
        ''
        ''Added 6/03/2022 
        ''
        Get
            ''Added 6/03/2022 
            Return mod_image
        End Get
        Set(value As Drawing.Image)
            ''Added 6/03/2022 
            mod_image = value
        End Set

    End Property

    ''
    ''Added 5/18/2022 
    ''
    ''----Public InfoLayoutFun As ciBadgeInterfaces.ILayoutFunctions
    Public ctlMoveable2 As CtlGraphicStaticGraphic


    Public Function GetPictureBox() As PictureBox
        ''
        ''Added 5/18/2022 
        ''
        If (ctlMoveable2 IsNot Nothing) Then
            Return ctlMoveable2.Picture_Box
        ElseIf (ctlMoveable1 IsNot Nothing) Then
            Return ctlMoveable1.Picture_Box
        End If ''End of ""If (ctlMoveable2 IsNot Nothing) Then... ElseIf..."

    End Function ''End of ""Public Function GetPictureBox() As PictureBox""


    Public Function GetPositionX() As Integer
        ''
        ''Added 6/03/2022 
        ''
        Return ctlMoveable1.Left

    End Function ''---Public Function GetPositionX() As Integer


    Public Function GetPositionY() As Integer
        ''
        ''Added 6/03/2022 
        ''
        Return ctlMoveable1.Top

    End Function ''----Public Function GetPositionY() As Integer


    Public Sub LoadImageFromFileLocation()
        ''
        ''Added 5/18/2022 
        ''
        If (ctlMoveable2 IsNot Nothing) Then

            ctlMoveable2.LoadImageFromFileLocation(Me.ImageFileLocation)

        ElseIf (ctlMoveable1 IsNot Nothing) Then

            ctlMoveable1.LoadImageFromFileLocation(Me.ImageFileLocation)

        End If ''End of ""If (ctlMoveable2 IsNot Nothing) Then... ElseIf..."

    End Sub ''End of ""Public Sub LoadImageFromFileLocation()""


    Public Sub LoadImageFromImage(par_image As Drawing.Image)
        ''
        ''Added 5/18/2022 
        ''
        mod_image = par_image ''Added 6/11/2022 

        If (ctlMoveable2 IsNot Nothing) Then

            ctlMoveable2.LoadImageFromImage(par_image)

        ElseIf (ctlMoveable1 IsNot Nothing) Then

            ctlMoveable1.LoadImageFromImage(par_image)

        End If ''End of ""If (ctlMoveable2 IsNot Nothing) Then... ElseIf..."

    End Sub ''End of ""Public Sub LoadImageFromImage()""


    Public Sub Load_Control() ''5/18/2022 (sender As Object, e As EventArgs) Handles MyBase.Load
        ''5/18/2022 Private Sub CtlMoveableBackground_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 5/18/2022 
        ''
        Const c_boolCreateFreshControl As Boolean = False

        mod_designer = New ClassDesigner()
        mod_objGroupMoveEvents = New GroupMoveEvents_Singleton(mod_designer, False, True)
        mod_objSingleMoveEvents = New GroupMoveEvents_Singleton(mod_designer, False, True)

        If (c_boolCreateFreshControl) Then

            Const c_AddToLocalControls As Boolean = True
            ctlMoveable2 = CreateFreshGraphicsControl(ctlMoveable1, c_AddToLocalControls)
            mod_designer.BackgroundBox_Front = ctlMoveable2.pictureStaticGraphic
            ctlMoveable2.Picture_Box.SizeMode = PictureBoxSizeMode.Normal ''Normal... Don't change the size to fit the box.

        Else

            ''#1 5/18/2022 ctlMoveable1.AddMoveability(Me.InfoLayoutFun, mod_objEventsMoveGroupOfCtls)
            ''#1 5/18/2022 ctlMoveable1.AddMoveability(Me.InfoLayoutFun, mod_objGroupMoveEvents,
            ''#2 5/18/2022                 mod_objSingleMoveEvents)
            ctlMoveable1.AddMoveability(mod_designer, mod_objGroupMoveEvents,
                                          mod_objSingleMoveEvents)
            ctlMoveable1.Picture_Box.SizeMode = PictureBoxSizeMode.Normal ''Normal... Don't change the size to fit the box.

            mod_designer.BackgroundBox_Front = ctlMoveable1.pictureStaticGraphic

        End If ''End of ""If (c_boolCreateFreshControl) Then ... Else..."

        ''Added 5/18/2022 
        If (mod_image Is Nothing) Then
            LoadImageFromFileLocation()

        ElseIf (c_boolCreateFreshControl) Then
            ''6/3/2022 ctlMoveable2.LoadImageFromFileLocation(mod_image)
            ctlMoveable2.LoadImageFromImage(mod_image)

        Else
            ctlMoveable1.LoadImageFromImage(mod_image)

        End If ''End of ""If (mod_image Is Nothing) Then... ElseIf... Else..." 

    End Sub ''End of ""Public Sub Load_Control()""


    Private Function CreateFreshGraphicsControl(par_modelForSize As CtlGraphicStaticGraphic,
                                       pboolAddToUserControl As Boolean) As CtlGraphicStaticGraphic
        ''
        ''Added 5/18/2022 td  
        ''
        ''--May2022--Dim ctlGraphicsStatic1 As CtlGraphicStaticGraphic

        ''--May2022--ctlGraphicsStatic1 = New CtlGraphicStaticGraphic()
        ''--May2022--With ctlGraphicsStatic1

        Dim ctlNewMoveable As CtlGraphicStaticGraphic

        ctlNewMoveable = New CtlGraphicStaticGraphic()

        If (ctlNewMoveable Is Nothing) Then
            System.Diagnostics.Debugger.Break()
        End If ''End of ""If (ctlNewMoveable Is Nothing) Then... "

        With ctlNewMoveable
            ''5/18/2022 td''.AddMoveability(Me.InfoLayoutFun)
            .AddMoveability(mod_designer)
            .Top = 0
            .Left = 0
            If (ctlNewMoveable Is Nothing) Then
                System.Diagnostics.Debugger.Break()
            Else
                ''.Width = ctlMoveable1.Width
                ''.Height = ctlMoveable1.Height
                .Width = par_modelForSize.Width
                .Height = par_modelForSize.Height
            End If ''End of ""If (ctlNewMoveable Is Nothing) Then... Else..."
        End With ''End of ""With ctlNewMoveable""

        If (pboolAddToUserControl) Then
            Me.Controls.Clear()
            ''--May2022--Me.Controls.Add(ctlGraphicsStatic1)
            Me.Controls.Add(ctlNewMoveable)
        End If

        Return ctlNewMoveable

    End Function ''End of ""Private Function CreateFreshGraphicsControl()""

    Private Sub ctlMoveable1_ElementGraphic_RightClicked(par_control As CtlGraphicStaticGraphic) Handles ctlMoveable1.ElementGraphic_RightClicked
        ''
        ''Added 5/18/2022 thomas downes 
        ''
        RaiseEvent ElementGraphic_RightClicked(Me)


    End Sub

    Private Sub ctlMoveable1_ElementGraphic_LeftClicked(par_control As CtlGraphicStaticGraphic) Handles ctlMoveable1.ElementGraphic_LeftClicked
        ''
        ''Added 5/18/2022 thomas downes
        ''
        RaiseEvent ElementGraphic_LeftClicked(Me)


    End Sub

    Private Sub ctlMoveable1_Element_LeftClicked(par_control As RSCMoveableControlVB, par_e As EventArgs) _
           Handles ctlMoveable1.Element_LeftClicked
        ''
        ''Added 5/18/2022 thomas downes
        ''
        RaiseEvent ElementGraphic_LeftClicked(Me)

    End Sub

End Class
