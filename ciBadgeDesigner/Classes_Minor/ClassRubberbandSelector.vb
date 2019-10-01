Option Explicit On
Option Strict On
Option Infer Off
''
''Added 9/8/2019 
''
''Simple Drawing Selection Shape (Or Rubberband Shape)       
''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
''
''Modified by Thomas Downes, 9/8/2019 
''
Imports ciBadgeInterfaces ''Added 9/20/2019 thomas downes
Imports System.Drawing ''Added 10/1/2019 td 
Imports System.Windows.Forms ''Added 10/1/2019 td

Public Class ClassRubberbandSelector
    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    ''  Modified by Thomas Downes, 9/8/2019 
    ''
    ''9/8/2019 td''Public ParentDesignForm As FormDesignProtoTwo
    Public PictureBack As PictureBox
    Public FieldControls_GroupEdit As List(Of CtlGraphicFldLabel)
    Public FieldControls_All As List(Of CtlGraphicFldLabel)
    Public LayoutFunctions As ILayoutFunctions ''Added 9/20/2019 thomas d

    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    Public Sub MouseDown(sender As Object, e As MouseEventArgs) ''9/8/2019''Handles pictureBack.MouseDown ''----Me.MouseDown
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        '-- 1.0  Flip the state.
        ''
        Dim bInsideAFieldControl As Boolean ''Added 9/20/2019 td
        Dim intX_AdjustedToForm As Integer ''Added 9/20/2019 td
        Dim intY_AdjustedToForm As Integer ''Added 9/20/2019 td

        ''Added 9/20/2019 td
        If (LayoutFunctions Is Nothing) Then System.Diagnostics.Debugger.Break()

        ''Added 9/20/2019 td
        intX_AdjustedToForm = LayoutFunctions.Layout_Margin_Left_Add(e.X)
        intY_AdjustedToForm = LayoutFunctions.Layout_Margin_Top_Add(e.Y)

        ''Added 9/20/2019 td
        bInsideAFieldControl = InsideAFieldControl(intX_AdjustedToForm, intY_AdjustedToForm)
        If (bInsideAFieldControl) Then Exit Sub

        Me._bRubberBandingOn = (Not _bRubberBandingOn)

        '-- 2.0 if the state is on
        If Me._bRubberBandingOn Then

            '-- 2.1 make sure the object exists (create if not)

            If _pClickStart = Nothing Then _pClickStart = New Point

            '-- 2.2 Save the mouse's start postition
            _pClickStart.X = e.X
            _pClickStart.Y = e.Y

            '-- 2.3 Save the current location for the immediate drawing
            _pNow.X = e.X
            _pNow.Y = e.Y

        End If ''End of " If Me._bRubberBandingOn Then"

        ''
        '-- 3.0 Invalidate and for the paint method to be called.
        ''
        ''------Me.Invalidate()
        PictureBack.Invalidate()

    End Sub ''End of Public Sub MouseDown  

    Public Sub MouseMove(sender As Object, e As MouseEventArgs) ''9/8/2019 td''Handles pictureBack.MouseMove ''----Me.MouseMove
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        '-- 1.0 If the rubber banding is on, set the current location, and force the redraw.

        If Me._bRubberBandingOn Then

            ''--------Me.pictureBack.Visible = False ''Temporarily hide the huge background picture box. 

            '-- 1.1 make sure the object exists (create if not)
            If _pNow = Nothing Then _pNow = New Point

            '-- 1.2 Save the current location for the immediate drawing
            Me._pNow.X = e.X
            Me._pNow.Y = e.Y

            ''
            '-- 1.3 Invalidate and for the paint method to be called.
            ''
            ''------Me.Invalidate()
            PictureBack.Invalidate()

        End If ''End of " If Me._bRubberBandingOn Then"

    End Sub ''END OF "Public Sub MouseMove()"

    Public Sub MouseUp(sender As Object, e As MouseEventArgs) ''9/8 td''Handles pictureBack.MouseUp ''----Me.MouseUp
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        '-- 1.0  Flip the state.

        Me._bRubberBandingOn = (Not Me._bRubberBandingOn)

        '-- 2.0 if the state is off
        If (Not Me._bRubberBandingOn) Then

            ''--------Me.pictureBack.Visible = True ''Restore the huge background picture box. 

            '-- 2.1 make sure the object exists (create if not)
            If _pClickStop = Nothing Then _pClickStop = New Point

            '-- 2.2 Save the mouse's stop position
            _pClickStop.X = e.X
            _pClickStop.Y = e.Y

            '-- 2.3 Invalidate and for the paint method to be called.
            ''
            ''------Me.Invalidate()
            PictureBack.Invalidate()

        End If ''End of " If Me._bRubberBandingOn Then"

    End Sub ''End of Public Sub MouseUp

    Public Sub Paint(sender As Object, e As PaintEventArgs) ''9/8 td''Handles pictureBack.Paint ''----Me.Paint
        ''
        ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
        ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
        ''
        '-- 1.0 The rectangle used by .NET to get the draw area

        Dim _rRectangle As New Rectangle

        '-- 2.0 The pen.  You can change the color or pixel width to your heart's content

        Dim _penNew As New Pen(Color.Black, 3)

        '-- 3.0 Set the rectangle's top left x/y to the click location.
        _rRectangle.X = _pClickStart.X
        _rRectangle.Y = _pClickStart.Y

        '-- 4.0  If the state is on...
        If Me._bRubberBandingOn Then

            '-- 4.1 Set the rectangle's  width using the 'now' mouse location just set in the 'Form1_MouseMove' event
            _rRectangle.Width = (Me._pNow.X - _pClickStart.X)
            _rRectangle.Height = (Me._pNow.Y - _pClickStart.Y)

        Else '-- else if we are done having the shape follow the mouse

            '-- 4.2 Set the rectangle's  width using the 'stop' mouse location just set in the 'Form1_MouseUp' event
            _rRectangle.Width = (Me._pClickStop.X - _pClickStart.X)
            _rRectangle.Height = (Me._pClickStop.Y - _pClickStart.Y)

        End If ''End of "If Me._bRubberBandingOn Then .... Else ...."

        '-- 5.0  Let's be cheeky and make it a dashed style
        _penNew.DashStyle = Drawing2D.DashStyle.Dash

        ''-- 6.0 Draw the elipse
        ''-- e.Graphics.DrawEllipse(_penNew, _rRectangle)

        ''
        ''-- 7.0 Notice the rectangle is the same thing!
        ''
        Const c_bTryToAllowBidirectional As Boolean = False ''False since it's
        '' not testing well.   -----9/8/2019 td

        Dim new_rect As Rectangle ''Added 9/8/2019 thomas d. 
        Dim boolBackwards_TryIt As Boolean ''Added 9/8/2019 thomas d. 

        boolBackwards_TryIt = (c_bTryToAllowBidirectional And
                                (_rRectangle.Width < 0 _
                               Or _rRectangle.Height < 0))

        If (boolBackwards_TryIt) Then

            new_rect = ReverseRectangle_IfNeeded(_rRectangle)
            e.Graphics.DrawRectangle(_penNew, new_rect)

        Else
            '-- 7.0 Notice the rectangle is the same thing!
            e.Graphics.DrawRectangle(_penNew, _rRectangle)

        End If ''End of "If (boolRectangleBackwards) Then .... Else ...."

        ''
        ''Added 9/20/2019 thomas d. 
        ''
        ''9/20/2019 td''Me.LayoutFunctions.HighlightSelectedFields(_rRectangle)

        Dim boolNonTrivial As Boolean

        boolNonTrivial = (_rRectangle.Width > 5 And _rRectangle.Height > 5) ''Added 9/20/2019 td

        If (boolNonTrivial) Then

            HighlightSelectedFields(_rRectangle)

        End If ''End of "if (boolNonTrivial) Then"

    End Sub ''End of Public Sub Paint  

    Private Function InsideAFieldControl(par_x As Integer, par_y As Integer) As Boolean
        ''
        ''Added 9/20/2019 td  
        ''
        Dim each_ctl As CtlGraphicFldLabel
        Dim boolInsideCtl As Boolean

        For Each each_ctl In Me.FieldControls_All
            ''Are the coordinates inside a field control?   
            boolInsideCtl = each_ctl.InsideMe(par_x, par_y)
            If (boolInsideCtl) Then Exit For
        Next each_ctl

        Return boolInsideCtl

    End Function ''End of "Private Function InsideAFieldControl(par_x As Integer, par_y As Integer) As Boolean"

    Private Sub HighlightSelectedFields(par_rect As Rectangle)
        ''
        ''Added 9/20/2019 td 
        ''
        Dim each_fieldCtl As CtlGraphicFldLabel

        If (Me.FieldControls_All Is Nothing) Then
            ''
            ''Perhaps the form is in "load" mode. ---9/20/2019 td
            ''
        Else

            For Each each_fieldCtl In Me.FieldControls_All

                each_fieldCtl.Highlight_IfInsideRubberband(par_rect)

                With Me.FieldControls_GroupEdit
                    If (Not .Contains(each_fieldCtl)) Then
                        .Add(each_fieldCtl) ''Added 9/20/2019 td
                    End If ''End of "If (Not .Contains(each_fieldCtl)) Then"
                End With ''End of "With Me.FieldControls_GroupEdit"

            Next each_fieldCtl

        End If ''end of "If (Me.FieldControls_All Is Nothing) Then"

    End Sub ''ENd of "Private Sub HighlightSelectedFields(par_rect As Rectangle)"

    Private Function ReverseRectangle_IfNeeded(par_rect As Rectangle) As Rectangle
        ''
        ''Added 9/8/2019 td
        ''
        Dim newRectangle As Rectangle

        Dim intTop_Start As Integer
        Dim intLeft_Start As Integer

        Dim intTop_Final As Integer
        Dim intLeft_Final As Integer

        Dim intFinal_Height As Integer
        Dim intFinal_Width As Integer

        With par_rect

            intTop_Start = .Top
            intLeft_Start = .Left

            If (.Width < 0 And .Height < 0) Then

                intTop_Final = (.Top - (-1 * .Height))
                intLeft_Final = (.Left - (-1 * .Height))

                intFinal_Width = (-1 * .Width)
                intFinal_Height = (-1 * .Height)

            ElseIf (.Width < 0) Then

                intLeft_Final = (.Left - (-1 * .Height))
                intFinal_Width = (-1 * .Width)

                ''The boring stuff is next.
                intLeft_Final = intLeft_Start
                intFinal_Height = (.Height)

            ElseIf (.Height < 0) Then

                intTop_Final = (.Top - (-1 * .Height))
                intFinal_Height = (-1 * .Height)

                ''The boring stuff is next.
                intTop_Final = intTop_Start
                intFinal_Width = (.Width)

            End If ''End of "If (.Width < 0 And .Height < 0) Then ... ElseIf ... ElseIf  ..."

        End With

ExitHandler:
        newRectangle = New Rectangle(intLeft_Final, intTop_Final,
                                 intFinal_Width, intFinal_Height)

        ''-----par_rect = newRectangle
        Return newRectangle

    End Function ''End of "Private Sub ReverseRectangle_IfNeeded(ByRef par_rect As Rectangle)"

    ''
    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''
    ''Private _bRubberBandingOn As Boolean = False '-- State to control if we are drawing the rubber banding object
    ''Private _pClickStart As New Point '-- The place where the mouse button went 'down'.
    ''Private _pClickStop As New Point '-- The place where the mouse button went 'up'.
    ''Private _pNow As New Point '-- Holds the current mouse location to make the shape appear to follow the mouse cursor.

    ''Private Sub FormDesignProtoTwo_MouseDown(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseDown ''----Me.MouseDown
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    '-- 1.0  Flip the state.
    ''    ''
    ''    Me._bRubberBandingOn = (Not _bRubberBandingOn)

    ''    '-- 2.0 if the state is on
    ''    If Me._bRubberBandingOn Then

    ''        '-- 2.1 make sure the object exists (create if not)

    ''        If _pClickStart = Nothing Then _pClickStart = New Point

    ''        '-- 2.2 Save the mouse's start postition
    ''        _pClickStart.X = e.X
    ''        _pClickStart.Y = e.Y

    ''        '-- 2.3 Save the current location for the immediate drawing
    ''        _pNow.X = e.X
    ''        _pNow.Y = e.Y

    ''    End If ''End of " If Me._bRubberBandingOn Then"

    ''    ''
    ''    '-- 3.0 Invalidate and for the paint method to be called.
    ''    ''
    ''    ''------Me.Invalidate()
    ''    Me.pictureBack.Invalidate()

    ''End Sub

    ''Private Sub FormDesignProtoTwo_MouseMove(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseMove ''----Me.MouseMove
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    '-- 1.0 If the rubber banding is on, set the current location, and force the redraw.

    ''    If Me._bRubberBandingOn Then

    ''        ''--------Me.pictureBack.Visible = False ''Temporarily hide the huge background picture box. 

    ''        '-- 1.1 make sure the object exists (create if not)
    ''        If _pNow = Nothing Then _pNow = New Point

    ''        '-- 1.2 Save the current location for the immediate drawing
    ''        Me._pNow.X = e.X
    ''        Me._pNow.Y = e.Y

    ''        ''
    ''        '-- 1.3 Invalidate and for the paint method to be called.
    ''        ''
    ''        ''------Me.Invalidate()
    ''        Me.pictureBack.Invalidate()

    ''    End If ''End of " If Me._bRubberBandingOn Then"


    ''End Sub

    ''Private Sub FormDesignProtoTwo_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBack.MouseUp ''----Me.MouseUp
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    '-- 1.0  Flip the state.

    ''    Me._bRubberBandingOn = (Not Me._bRubberBandingOn)

    ''    '-- 2.0 if the state is off
    ''    If (Not Me._bRubberBandingOn) Then

    ''        ''--------Me.pictureBack.Visible = True ''Restore the huge background picture box. 

    ''        '-- 2.1 make sure the object exists (create if not)
    ''        If _pClickStop = Nothing Then _pClickStop = New Point

    ''        '-- 2.2 Save the mouse's stop postition
    ''        _pClickStop.X = e.X
    ''        _pClickStop.Y = e.Y

    ''        '-- 2.3 Invalidate and for the paint method to be called.
    ''        ''
    ''        ''------Me.Invalidate()
    ''        Me.pictureBack.Invalidate()

    ''    End If ''End of " If Me._bRubberBandingOn Then"

    ''End Sub

    ''Private Sub FormDesignProtoTwo_Paint(sender As Object, e As PaintEventArgs) Handles pictureBack.Paint ''----Me.Paint
    ''    ''
    ''    ''  Simple Drawing Selection Shape (Or Rubberband Shape)       
    ''    ''  https://www.dreamincode.net/forums/topic/59049-simple-drawing-selection-shape-or-rubberband-shape/
    ''    ''
    ''    '-- 1.0 The rectangle used by .NET to get the draw area

    ''    Dim _rRectangle As New Rectangle

    ''    '-- 2.0 The pen.  You can change the color or pixel width to your heart's content

    ''    Dim _penNew As New Pen(Color.Black, 3)

    ''    '-- 3.0 Set the rectangle's top left x/y to the click location.
    ''    _rRectangle.X = _pClickStart.X
    ''    _rRectangle.Y = _pClickStart.Y

    ''    '-- 4.0  If the state is on...
    ''    If Me._bRubberBandingOn Then

    ''        '-- 4.1 Set the rectangle's  width using the 'now' mouse location just set in the 'Form1_MouseMove' event
    ''        _rRectangle.Width = Me._pNow.X - _pClickStart.X
    ''        _rRectangle.Height = Me._pNow.Y - _pClickStart.Y

    ''    Else '-- else if we are done having the shape follow the mouse

    ''        '-- 4.2 Set the rectangle's  width using the 'stop' mouse location just set in the 'Form1_MouseUp' event
    ''        _rRectangle.Width = Me._pClickStop.X - _pClickStart.X
    ''        _rRectangle.Height = Me._pClickStop.Y - _pClickStart.Y

    ''    End If ''End of "If Me._bRubberBandingOn Then .... Else ...."

    ''    '-- 5.0  Let's be cheeky and make it a dashed style
    ''    _penNew.DashStyle = Drawing2D.DashStyle.Dash

    ''    '-- 6.0 Draw the elipse
    ''    '-- e.Graphics.DrawEllipse(_penNew, _rRectangle)

    ''    '-- 7.0 Notice the rectangle is the same thing!
    ''    e.Graphics.DrawRectangle(_penNew, _rRectangle)

    ''End Sub

End Class
