Imports System.Drawing
Imports System.Drawing.Text
Imports System.IO
Imports System.Net.Http.Headers
Imports System.Reflection
Imports System.Runtime.Intrinsics.X86
Imports __RSCElementSelectGraphics
''Imports __RSCWindowsControlLibrary
''Imports ciBadgeSerialize

Public Class FormTestGraphics

    ''Private mod_objTriangle As Triangle ''Added 11/22/2022 
    ''12/14/2022 Private mod_objArrow As New ArrowTriangleStructure ''Added 11/22/2022 
    Private mod_objCurrentArrow As New ClassArrowTriangles ''Structure ''Added 11/22/2022 
    Private mod_listOfArrows As New ClassListOfArrows ''Added 11/26/2022 
    Private mod_colorArrows As Drawing.Color ''Added 11/27/2022
    ''Private mod_stackPoints As New Stack(Of Drawing.Point) ''Added 12/13/2022
    ''Private mod_queuePoints As New Queue(Of Drawing.Point) ''Added 12/13/2022
    Private mod_listPoints As New List(Of Drawing.Point) ''Added 12/13/2022
    Private mod_stackPoints As New Stack(Of Drawing.Point) ''Added 12/14/2022
    Private mod_stackPoints_Undone As New Stack(Of Drawing.Point) ''Added 12/14/2022
    Private mod_graphics As Drawing.Graphics ''Added 12/16/2022

    ''Public Structure Line
    ''    ''
    ''    ''Added 11/22/2022
    ''    ''
    ''    Public point1 As Point
    ''    Public point2 As Point
    ''End Structure

    ''Public Structure Triangle
    ''    ''
    ''    ''Added 11/22/2022
    ''    ''
    ''    Public line1 As Line
    ''    Public line2 As Line
    ''    Public line3 As Line
    ''End Structure



    Private Sub ButtonSaveArrow_Click(sender As Object, e As EventArgs) Handles ButtonSaveArrow.Click
        ''
        ''Added 11/26/2022
        ''
        ''12/14/2022 Dim objArrow As ArrowTriangleStructure
        Dim objArrow As ClassArrowTriangles ''Structure

        mod_objCurrentArrow.Name = textNameOfArrow.Text.Trim()
        If (mod_objCurrentArrow.Name = "") Then
            MessageBoxTD.Show_Statement("You need to supply a name for the arrow.")
            Exit Sub
        End If ''Endof ""If (mod_objArrow.Name = "") Then""

        objArrow = mod_objCurrentArrow
        mod_listOfArrows.Add(objArrow)
        ''Added 12/13/2022
        ''---mod_listOfArrows.SaveToXML("ListOfArrows.xml")
        mod_listOfArrows.SaveToXML("ListOfArrowsOfTriangles.xml")
        Me.Refresh() ''Added 12/16/2022

ExitHandler:
        textNameOfArrow.Text = "" ''Clear the box. 
        RefreshPanelOfArrows(mod_listOfArrows)
    End Sub


    Private Sub RefreshPanelOfArrows(par_list As ClassListOfArrows)
        ''
        ''Added 11/26/2022  
        ''
        Dim objRSCDraw As New __RSCElementSelectGraphics.RSCGraphics

        FlowLayoutPanel1.Controls.Clear()

        ''12/14/2022 For Each eachArrow As ArrowTriangleStructure In par_list.List()
        For Each eachArrow As ClassArrowTriangles In par_list.List()

            Dim objPictureBox As New PictureBox With {
                    .Width = PictureBoxForTriangle.Width,
                    .Height = PictureBoxForTriangle.Height,
                    .BackColor = PictureBoxForTriangle.BackColor,
                    .Visible = True
                }
            ''objRSCDraw.DrawAndFillArrow(objPictureBox, eachArrow, mod_color, 0, 0)
            objRSCDraw.DrawAndFillArrow(objPictureBox, eachArrow, mod_colorArrows, 0, 0)
            FlowLayoutPanel1.Controls.Add(objPictureBox)
            objPictureBox.Invalidate()
            ToolTip1.SetToolTip(objPictureBox, eachArrow.Name)
            AddHandler objPictureBox.Click, AddressOf PanelPictureBox_Click
            objPictureBox.Tag = eachArrow

        Next eachArrow

        FlowLayoutPanel1.Refresh()


    End Sub ''End of ""Private Sub RefreshPanelOfArrows""


    Private Sub PanelPictureBox_Click(objectSender As Object, e As EventArgs) _
        Handles PictureBoxDummy.Click ''Find "AddHandler ..."
        ''
        ''Added 12/13/2022 
        ''
        Dim boolDeleteArrow As Boolean

        boolDeleteArrow =
          MessageBoxTD.Show_Confirm("Delete this arrow?",
                                    MessageBoxDefaultButton.Button2)

        Dim objControl As Control
        Dim objArrow As ClassArrowTriangles ''ArrowTriangleStructure
        objControl = CType(objectSender, Control)
        ''objArrow = CType(objControl.Tag, ArrowTriangleStructure)
        objArrow = CType(objControl.Tag, ClassArrowTriangles) ''ArrowTriangleStructure)

        If (boolDeleteArrow) Then
            mod_listOfArrows.Remove(objArrow)
            RefreshPanelOfArrows(mod_listOfArrows)

        Else
            mod_objCurrentArrow = objArrow
            Me.Refresh()

        End If ''ENd of ""If (boolDeleteArrow) Then... Else..."


    End Sub



    Private Sub ButtonTriangle_Click()
        ''
        ''Added 11/22/2022
        ''
        ''DrawAndFillTriangle()
        ''DrawAndFillTriangle_Denigrated(Color.Aqua)

        ''//Dim rscDraw = New __RSCElementSelectGraphics.RSCGraphics
        ''//Dim grDraw As Graphics = New Graphics()
        ''//rscDraw.DrawAndFillTriangle(grDraw, Color.Aqua, mod_objArrow.triangle2)

        ''//DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1)
        DrawAndFillTriangleRSC(mod_colorArrows, mod_objCurrentArrow.Triangle1)

    End Sub


    Private Sub DrawSinglePointRSC(par_color As Drawing.Color, piX As Integer, piY As Integer)
        ''
        ''Added 11/22/2022
        ''
        If (PictureBoxForTriangle.Image Is Nothing) Then
            Throw New BadImageFormatException
        End If

        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        Dim objRSCGraphics As New __RSCElementSelectGraphics.RSCGraphics
        Const c_Size As Integer = 5 ''2
        ''---objRSCGraphics.DrawSinglePoint(par_color, piX, piY)
        objRSCGraphics.DrawSinglePoint(graph_tri, par_color, piX, piY, c_Size)

ExitHandler:
        PictureBoxForTriangle.Refresh()

    End Sub


    Private Sub DrawAndFillTriangleRSC(par_color As Drawing.Color,
                                    Optional par_triangle As ClassTriangle = Nothing,
                                       Optional par_offsetX As Integer = 0,
                                       Optional par_offsetY As Integer = 0,
                                       Optional par_scale As Single = 1.0,
                                    Optional pbBreakForZeroes As Boolean = False)
        ''
        ''Added 11/22/2022
        ''
        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        Dim objRSCGraphics As New __RSCElementSelectGraphics.RSCGraphics

        ''//objRSCGraphics.DrawAndFillTriangle(graph_tri, par_color,
        ''//        par_triangle, pbBreakForZeroes)
        objRSCGraphics.DrawAndFillTriangle(graph_tri, par_color,
                par_triangle, par_offsetX, par_offsetY, par_scale, pbBreakForZeroes)

ExitHandler:
        PictureBoxForTriangle.Refresh()

    End Sub ''endof ""Private Sub DrawAndFillTriangleRSC""




    Private Sub DrawLinesBetweenLines(par_line1 As Line, par_line2 As Line,
                                      par_iWid As Integer, par_graph As Graphics,
                                      par_pen As Pen,
                                      par_howManyLines As Integer,
                                      Optional pbBreakForZeroes As Boolean = False)
        ''
        ''Added 11/22/2022
        ''
        Dim point1 As Point
        Dim point2 As Point

        ''
        ''Very pretty, but too many gaps!
        ''
        For index As Integer = 0 To par_howManyLines - 1

            point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines, index)
            point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines, index)
            par_graph.DrawLine(par_pen, point1, point2)

        Next index

        ''
        ''Draw (par_howManyLines * par_howManyLines) lines 
        ''
        For indexOut As Integer = 0 To par_howManyLines - 1
            point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines, indexOut, pbBreakForZeroes)
            For indexIn As Integer = 0 To par_howManyLines - 1
                point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines, indexIn, pbBreakForZeroes)
                par_graph.DrawLine(par_pen, point1, point2)
            Next indexIn
        Next indexOut

    End Sub ''End of ""Private Sub DrawLinesBetweenLines()""


    Private Function GetPointFromLine_ByFractioning(par_line As Line, par_denominator As Integer,
                                                    par_numerator As Integer,
                                                    Optional pbBreakForZeros As Boolean = False) As Point
        ''
        ''Added 11/22/2022  
        ''
        Dim intX As Integer
        Dim intY As Integer

        With par_line
            intX = CDbl(.point1.X) + ((CDbl(.point2.X - .point1.X) / CDbl(par_denominator)) * par_numerator)
            intY = CDbl(.point1.Y) + ((CDbl(.point2.Y - .point1.Y) / CDbl(par_denominator)) * par_numerator)
        End With

        If (pbBreakForZeros AndAlso (intX = 0 And intY = 0)) Then
            System.Diagnostics.Debugger.Break()
        End If

        Return New Point(intX, intY)

    End Function ''End of ""Private Function GetPointFromLine_ByFractioning""



    ''//Private Sub PictureBoxForBorder_Click(sender As Object, e As EventArgs) Handles PictureBoxForBorder.Click
    ''//
    ''//End Sub

    Private Sub FormTestGraphics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 11/27/2022 
        mod_colorArrows = Drawing.Color.BlueViolet

        With PictureBoxForTriangle

            .Image = New Bitmap(.Width - 1, Height - 1)

        End With

        With PictureBoxForBorder

            .Image = New Bitmap(.Width - 1, Height - 1)

        End With

        ''Encapsulated 12/13/2022
        LoadListOfArrowsFromXML(True)

        RSCGraphics.ArrowNorth = mod_listOfArrows("N")
        RSCGraphics.ArrowNE = mod_listOfArrows("NE")
        RSCGraphics.ArrowEast = mod_listOfArrows("E")
        RSCGraphics.ArrowSE = mod_listOfArrows("SE")
        RSCGraphics.ArrowSouth = mod_listOfArrows("S")
        RSCGraphics.ArrowSW = mod_listOfArrows("SW")
        RSCGraphics.ArrowWest = mod_listOfArrows("W")
        RSCGraphics.ArrowNW = mod_listOfArrows("NW")
        RSCGraphics.FillArrayOfArrows() ''Added 12/17/2022 Thomas Downes
        ''Me.Invalidate()
        ''Me.Refresh()
        TimerRefresh.Enabled = True

        ''Added 12/16/2022
        ''Me.BackgroundImage = New Bitmap(-1 + Me.Width, -1 + Me.Height)
        ''mod_graphics = New Graphics(Me.BackgroundImage)

    End Sub


    Private Sub LoadListOfArrowsFromXML(pboolFillPanel As Boolean)

        ''Added 12/13/2022
        ''If (IO.File.Exists("ListOfArrows.xml")) Then
        If (IO.File.Exists("ListOfArrowsOfTriangles.xml")) Then
            ''mod_listOfArrows = ClassListOfArrows.LoadFromXML("ListOfArrows.xml")
            Try
                mod_listOfArrows = ClassListOfArrows.LoadFromXML("ListOfArrowsOfTriangles.xml")

                ''Added 12/16/2022
                ''  Refresh the data members which are not serialized. 
                For Each eachArrow As ClassArrowTriangles In mod_listOfArrows.List
                    eachArrow.RefreshMaxDimensionsEtc()
                Next eachArrow

            Catch obj_exception As FileNotFoundException
                ''File doesn't exist yet.  Hit F5 to continue. ---12/14/2022
                Debugger.Break()

            Finally
                ''12/2022 If (pboolFillPanel) Then
                If (pboolFillPanel AndAlso mod_listOfArrows IsNot Nothing) Then
                    RefreshPanelOfArrows(mod_listOfArrows)
                End If ''ENdo f ""If (pboolFillPanel) Then""
            End Try
        End If ''End of ""If (IO.File.Exists(...)) Then"

    End Sub ''ENd of "" Private Sub LoadListOfArrowsFromXML(pboolFillPanel As Boolean)""


    Private Sub PictureBoxForTriangle_Click(sender As Object, e As EventArgs) Handles PictureBoxForTriangle.Click

        ''See the Handles PictureBoxForTriangle.MouseUp

    End Sub


    Private Sub PictureBoxForTriangle_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBoxForTriangle.MouseUp


        ''Added 12/13/2022 
        ''Dec16 2022''If (mod_objCurrentArrow.isFull()) Then
        If (mod_objCurrentArrow.isFull(True)) Then
            MessageBoxTD.Show_Statement("The Arrow has been created.")
            Return
        Else
            mod_listPoints.Add(New Point(e.X, e.Y))
        End If ''End of ""If (mod_objCurrentArrow.isFull()) Then... Else..."

        ''
        ''Draw a dot where the user clicked!  
        ''
        ''DrawSinglePoint(Color.Black, e.X, e.Y)
        DrawSinglePointRSC(Color.Black, e.X, e.Y)

        ''Encapsulated 12/13/2022
        ''--Dim bCompletedTriangle1 As Boolean
        ''--Dim bCompletedTriangle2 As Boolean
        ''--BuildTriangle_Denigrated(e.X, e.Y, bCompletedTriangle1, bCompletedTriangle2)
        Dim new_queue As New Queue(Of Point)(mod_listPoints)
        mod_objCurrentArrow = BuildArrowTriangles(new_queue)

ExitHandler:
        ''If (bCompletedTriangle1) Then
        ''    DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ''ElseIf (bCompletedTriangle2) Then
        ''    DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle2, True)
        ''End If
        ''DrawArrowTriangles(mod_objCurrentArrow)
        RefreshCurrentArrowPanel()

    End Sub


    Private Sub RefreshCurrentArrowPanel()

        ''PictureBoxForTriangle.Image
        With PictureBoxForTriangle
            .Image = New Bitmap(.Width - 1, Height - 1)
        End With
        DrawArrowTriangles(mod_objCurrentArrow)

    End Sub ''End of "Private Sub RefreshCurrentArrowPanel()


    Private Sub DrawArrowTriangles(par_arrow As ClassArrowTriangles)

        ''If (bCompletedTriangle1) Then
        ''    DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ''ElseIf (bCompletedTriangle2) Then
        ''    DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle2, True)
        ''End If

        DrawAndFillTriangleRSC(Color.Black, par_arrow.Triangle1, True)
        DrawAndFillTriangleRSC(Color.Black, par_arrow.Triangle2, True)

    End Sub ''Private Sub DrawArrowTriangles()


    Private Function BuildArrowTriangles(par_queuePoints As Queue(Of Point)) As ClassArrowTriangles
        ''
        ''Added 12/14/2022
        ''
        ''---mod_objCurrentArrow = New ClassArrowTriangles(par_queuePoints)
        ''--Return New ClassArrowTriangles(par_queuePoints)

        Dim objArrowTriangles As ClassArrowTriangles
        objArrowTriangles = New ClassArrowTriangles(par_queuePoints)
        Return objArrowTriangles

    End Function ''End of Private Function BuildArrowTriangles()


    Private Sub BuildTriangle_Denigrated(par_eX As Integer, par_eY As Integer,
                              ByRef pbCompletedTriangle1 As Boolean,
                              ByRef pbCompletedTriangle2 As Boolean)
        ''
        ''Build Triangle  
        ''
        ''With mod_objTriangle  
        ''Static objTriangle As Triangle
        Dim temp_triangle As New ClassTriangle
        Dim bTriangle1_L1Empty As Boolean
        Dim bTriangle1_L2Empty As Boolean
        Dim bTriangle1_L3Empty As Boolean
        Dim bTriangle2_L1Empty As Boolean
        Dim bTriangle2_L2Empty As Boolean
        Dim bTriangle2_L3Empty As Boolean
        Dim bTriangle1Empty As Boolean
        Dim bTriangle2Empty As Boolean
        Dim bNeitherIsEmpty As Boolean

        Dim bFillingTriangle1 As Boolean
        Dim bFillingTriangle2 As Boolean
        Dim bFillingTriangleNew As Boolean
        ''Parameterized. Dim bCompletedTriangle1 As Boolean
        ''Parameterized. Dim bCompletedTriangle2 As Boolean

        With mod_objCurrentArrow.Triangle1
            ''bPoint1L1Empty = (.line1.point1.X = 0)
            ''bPoint1L2Empty = (.line2.point1.X = 0)
            ''bPoint1L3Empty = (.line3.point1.X = 0)
            bTriangle1_L1Empty = (0 = .GetLine(1).point1.X)
            bTriangle1_L2Empty = (0 = .GetLine(2).point1.X)
            bTriangle1_L3Empty = (0 = .GetLine(3).point1.X)
            ''If (bPoint1L1Empty) Then temp_triangle = mod_objArrow.triangle1
            ''bTriangle1Empty = (bPoint1L1Empty And bPoint1L2Empty)
            ''bTriangle1Empty = (bPoint1L1Empty And bPoint1L3Empty)
            bTriangle1Empty = (bTriangle1_L1Empty And bTriangle1_L3Empty)
        End With

        With mod_objCurrentArrow.Triangle2
            ''--bPoint2L1Empty = (.line1.point1.X = 0)
            ''--bPoint2L2Empty = (.line2.point1.X = 0)
            ''--bPoint2L3Empty = (.line3.point1.X = 0)
            ''bPoint2L1Empty = (0 = .GetLine(1).point1.X)
            ''bPoint2L2Empty = (0 = .GetLine(2).point1.X)
            ''bPoint2L3Empty = (0 = .GetLine(3).point1.X)
            bTriangle2_L1Empty = (0 = .GetLine(1).point1.X)
            bTriangle2_L2Empty = (0 = .GetLine(2).point1.X)
            bTriangle2_L3Empty = (0 = .GetLine(3).point1.X)
        End With ''End of ""With mod_objArrow.triangle1""

        ''bTriangle2Empty = (bPoint2L3Empty) ''Then temp_triangle = mod_objArrow.triangle1
        bTriangle2Empty = (bTriangle2_L2Empty) ''Then temp_triangle = mod_objArrow.triangle1
        bNeitherIsEmpty = (False = (bTriangle2Empty Or bTriangle2Empty))

        ''Dim bFillingTriangle1 As Boolean
        ''Dim bFillingTriangle2 As Boolean
        ''Dim bFillingTriangleNew As Boolean
        ''Dim bCompletedTriangle1 As Boolean
        ''Dim bCompletedTriangle2 As Boolean

        If (bTriangle1_L1Empty Or bTriangle1_L2Empty Or bTriangle1_L3Empty) Then
            bFillingTriangle1 = True
            temp_triangle = mod_objCurrentArrow.Triangle1
        ElseIf (bTriangle2_L1Empty Or bTriangle2_L2Empty Or bTriangle2_L3Empty) Then
            bFillingTriangle2 = True
            temp_triangle = mod_objCurrentArrow.Triangle2
        Else
            bFillingTriangleNew = True
        End If

        ''12/14/2022 With temp_triangle ''mod_objArrow.triangle1
        ''
        ''    If (bFillingTriangleNew) Then
        ''        .line1().point1.X = par_eX ''e.X
        ''        .line1().point1.Y = par_eY ''e.Y
        ''    ElseIf (bTriangle1_L1Empty) Then
        ''        .line1().point1.X = par_eX ''e.X
        ''        .line1().point1.Y = par_eY ''e.Y
        ''    ElseIf (bTriangle1_L2Empty) Then
        ''        .line2().point1.X = par_eX ''e.X
        ''        .line2().point1.Y = par_eY ''e.Y
        ''    ElseIf (bTriangle1_L3Empty) Then
        ''        .line3().point1.X = par_eX ''e.X
        ''        .line3().point1.Y = par_eY ''e.Y
        ''
        ''        ''Complete the triangle.
        ''        .line1().point2 = .line2.point1
        ''        .line2().point2 = .line3.point1
        ''        .line3().point2 = .line1.point1
        ''        pbCompletedTriangle1 = True
        ''
        ''    ElseIf (bTriangle2_L1Empty) Then
        ''        .line1().point1.X = par_eX
        ''        .line1().point1.Y = par_eY
        ''    ElseIf (bTriangle2_L2Empty) Then
        ''        .line2().point1.X = par_eX
        ''        .line2().point1.Y = par_eY
        ''    ElseIf (bTriangle2_L3Empty) Then
        ''        .line3().point1.X = par_eX
        ''        .line3().point1.Y = par_eY
        ''
        ''        ''Complete the triangle.
        ''        .line1.point2 = .line2.point1
        ''        .line2.point2 = .line3.point1
        ''        .line3.point2 = .line1.point1
        ''        pbCompletedTriangle2 = True
        ''
        ''        ''Draw & fill the triangle.
        ''        ''DrawAndFillTriangle(Color.Aqua, mod_objTriangle, True)
        ''        ''DrawAndFillTriangle(Color.Aqua, mod_objArrow.triangle1, True)
        ''        ''----Nov27---DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ''
        ''        ''----Nov27---''Clear the triangle.
        ''        ''----Nov27---.line1.point1 = New Point()
        ''        ''----Nov27---.line1.point2 = New Point()
        ''        ''----Nov27---.line2.point1 = New Point()
        ''        ''----Nov27---.line2.point2 = New Point()
        ''        ''----Nov27---.line3.point1 = New Point()
        ''        ''----Nov27---.line3.point2 = New Point()
        ''
        ''    End If ''End of ""If (bPoint1L1Empty) Then... ElseIf ... ElseIf ..."
        ''
        ''End With ''End of ""With temp_triangle""

        If (bFillingTriangle1) Then ''(bPoint1L3Empty) Then ''If (bTriangle1Empty) Then
            mod_objCurrentArrow.Triangle1 = temp_triangle
            ''Moved below.''DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ElseIf (bFillingTriangle2) Then ''ElseIf (bPoint2L3Empty) Then ''(bTriangle2Empty) Then
            mod_objCurrentArrow.Triangle2 = temp_triangle
            ''Moved below.''DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle2, True)
        ElseIf (bFillingTriangleNew) Then ''ElseIf (bNeitherIsEmpty) Then
            mod_objCurrentArrow.Triangle1 = temp_triangle
            mod_objCurrentArrow.Triangle2 = New ClassTriangle ''New Triangle
            ''--DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        End If

    End Sub ''End of "Private Sub BuildTriangle"

    Private Sub ButtonClearBoxForTriangle_Click(sender As Object, e As EventArgs) Handles ButtonClearBoxForTriangle.Click

        ''Added 11/22/2022 
        With PictureBoxForTriangle
            .Image = New Bitmap(.Width - 1, .Height - 1)
            .Refresh()
        End With

        ''Added 12/15/2022 
        mod_objCurrentArrow = New ClassArrowTriangles()
        mod_listPoints.Clear()
        mod_stackPoints.Clear()

    End Sub

    Private Sub PictureBoxInner_Click(sender As Object, e As EventArgs) Handles PictureBoxInner.Click

    End Sub

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click

        ''Added 12/13/2022
        mod_listOfArrows.SaveToXML("ListOfArrows.xml")
        mod_listOfArrows = Nothing ''Clear the list / delete the reference. 
        FlowLayoutPanel1.Controls.Clear()

        ''RefreshPanelOfArrows(mod_listOfArrows)
        ''LoadListOfArrowsFromXML 
        TimerRefresh.Enabled = True

    End Sub

    Private Sub TimerRefresh_Tick(sender As Object, e As EventArgs) Handles TimerRefresh.Tick

        ''Added 12/13/2022
        ''If (IO.File.Exists("ListOfArrows.xml")) Then
        ''  mod_listOfArrows = ClassListOfArrows.LoadFromXML("ListOfArrows.xml")
        ''  RefreshPanelOfArrows(mod_listOfArrows)
        ''End If ''End of ""If (IO.File.Exists(...)) Then"
        TimerRefresh.Enabled = False
        FlowLayoutPanel1.Controls.Clear()

        ''Me.Invalidate() ''Added 12/17/2022
        ''Me.Refresh() ''Added 12/17/2022 
        ''Me.repaint
        Application.DoEvents()
        LoadListOfArrowsFromXML(True)
        TimerRefresh.Enabled = False

    End Sub

    Private Sub LinkUndoLatestClick_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkUndoLatestClick.LinkClicked

        ''Added 12/14/2022 
        If (0 < mod_listPoints.Count) Then

            Dim intCountSize As Integer
            Dim objPoint As Point ''Added 12/15/2022 thomas downes

            intCountSize = mod_listPoints.Count
            objPoint = mod_listPoints.Item(-1 + intCountSize)
            Debug.Assert(objPoint.X > 0)
            mod_listPoints.RemoveAt(-1 + intCountSize)
            ''-----mod_stackPoints.Pop() ''Remove the top Point on the Stat
            mod_stackPoints_Undone.Push(objPoint)

            ''Added 12/15/2022 thomas d.
            Dim new_queue As New Queue(Of Point)(mod_listPoints)
            mod_objCurrentArrow = BuildArrowTriangles(new_queue)

            RefreshCurrentArrowPanel()

        End If ''end of ""If (0 < mod_listPoints.Count) Then""


    End Sub


    Private Sub FormTestGraphics_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        ''Added 12/16/2022 
        Dim objRSCGraphics As New __RSCElementSelectGraphics.RSCGraphics
        Dim objArrowTriangles As ClassArrowTriangles
        ''__RSCElementSelectGraphics e.Graphics

        If (0 < mod_listOfArrows.List.Count) Then
            ''
            ''Find an Arrow (of Triangles) to draw.
            ''
            If (mod_objCurrentArrow Is Nothing) Then
                objArrowTriangles = mod_listOfArrows.List.Last()
            Else
                objArrowTriangles = mod_objCurrentArrow
            End If ''End of ""If (mod_objCurrentArrow Is Nothing) Then... Else""

            ''
            ''Check to see if the Arrow is complete, and then 
            ''  draw the complete arrow. 
            ''
            If (objArrowTriangles.isFull(True)) Then

                With objRSCGraphics

                    ''.DrawAndFillTriangle(e.Graphics, mod_colorArrows, mod_listOfArrows.List(0))
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows, 0, 0)

                    ''Dim intOffsetX As Integer, intOffsetY As Integer
                    ''With objArrowTriangles
                    ''    intOffsetX = PictureBoxForBorder.Left - .GetWidth(1.0F)
                    ''    intOffsetY = PictureBoxForBorder.Top - .GetHeight(1.0F)
                    ''End With

                    ''''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows, 0, 0)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          intOffsetX, intOffsetY)

                    ''With objArrowTriangles
                    ''    intOffsetX = PictureBoxForBorder.Left - .GetWidth(1.0F)
                    ''    intOffsetY = PictureBoxForBorder.Top + PictureBoxForBorder.Height '' - .GetHeight(1.0F)
                    ''End With

                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          intOffsetX, intOffsetY)

                    ''-----------------------------------------------------------------------
                    ''Print all positions of the clock!!
                    ''-----------------------------------------------------------------------
                    ''
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 12)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 1.5)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 3)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 4.5)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 6)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 7.5)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 9)
                    ''.DrawAndFillArrow(e.Graphics, objArrowTriangles, mod_colorArrows,
                    ''          PictureBoxForBorder, 10.5)

                    ''-----------------------------------------------------------------------
                    ''Print all positions of the clock!!
                    ''-----------------------------------------------------------------------
                    ''
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 0)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 1)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 3)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 4)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 6)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 7)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 9)
                    .DrawAndFillArrow(e.Graphics, mod_colorArrows, PictureBoxForBorder, 10)

                End With ''End of ""With objRSCGraphics""

            End If ''End of ""If (objArrowTriangles.isFull()) Then""
        End If ''End of ""If (0 < mod_listOfArrows.List.Count) Then""

    End Sub

    Private Sub LinkLabelPaintArrows_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelPaintArrows.LinkClicked

        ''Added 12/17/2022
        Me.Refresh()

    End Sub
End Class
