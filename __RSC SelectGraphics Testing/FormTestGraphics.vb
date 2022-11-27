Imports System.Drawing
Imports System.Drawing.Text
Imports System.Reflection
Imports __RSCElementSelectGraphics

Public Class FormTestGraphics

    ''Private mod_objTriangle As Triangle ''Added 11/22/2022 
    Private mod_objArrow As New ArrowTriangleStructure ''Added 11/22/2022 
    Private mod_listOfArrows As New ClassListOfArrows ''Added 11/26/2022 

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


    Private Sub DrawBorder_PixelsWide_Denigrated(par_WidthInPixels As Integer,
                                      par_gr As Graphics,
                                      par_intWidth As Integer,
                                      par_intHeight As Integer,
                                      par_color As Color)
        ''
        ''Added 9/6/2019 td  
        ''
        Dim pen_border As System.Drawing.Pen
        Dim intLineIndex As Integer
        Dim intOffsetPixels As Integer

        For intLineIndex = 1 To (par_WidthInPixels)

            pen_border = New Pen(par_color, 1)

            intOffsetPixels = (intLineIndex - 1)

            par_gr.DrawRectangle(pen_border, New Rectangle(intOffsetPixels, intOffsetPixels,
                                                           -1 + par_intWidth - 2 * intOffsetPixels,
                                                           -1 + par_intHeight - 2 * intOffsetPixels))

        Next intLineIndex

    End Sub ''end of "Private Sub DrawBorder_PixelsWide(par_elementInfo_Base.Border_WidthInPixels, gr_element, intNewElementWidth, intNewElementHeight)"



    Private Sub DrawTriangle_PixelsWide_Denigrated(par_WidthInPixels As Integer,
                                      par_gr As Graphics,
                                      par_triangle As Triangle,
                                      par_color As Color,
                                        Optional par_pen As Pen = Nothing)
        ''
        ''Added 11/22/2022 td  
        ''
        Dim pen_border As System.Drawing.Pen
        ''Dim intLineIndex As Integer
        ''Dim intOffsetPixels As Integer
        Dim arrayOfPoints As Point()

        ''11/2022 ReDim arrayOfPoints(4)
        ReDim arrayOfPoints(3)
        arrayOfPoints(0) = par_triangle.line1.point1
        arrayOfPoints(1) = par_triangle.line2.point1
        arrayOfPoints(2) = par_triangle.line3.point1
        arrayOfPoints(3) = par_triangle.line3.point2

        ''---For intLineIndex = 1 To (par_WidthInPixels)

        If (par_pen IsNot Nothing) Then
            pen_border = par_pen
        Else
            pen_border = New Pen(par_color, par_WidthInPixels)
        End If

        ''intOffsetPixels = (intLineIndex - 1)

        par_gr.DrawLines(pen_border, arrayOfPoints)

        ''Next intLineIndex

    End Sub ''end of "Private Sub DrawTriangle_PixelsWide(par_elementInfo_Base.Border_WidthInPixels, gr_element, intNewElementWidth, intNewElementHeight)"


    Public Sub DrawLinesOfTriangle_NotUsed(pline1 As Line, pline2 As Line, pline3 As Line)
        ''
        ''Added 11/22/2022
        ''




    End Sub ''End of ""Public Sub DrawLinesOfTriangle(pline1 As Line, pline2 As Line, pline3 As Line)"


    Private Sub ButtonSaveArrow_Click(sender As Object, e As EventArgs) Handles ButtonSaveArrow.Click
        ''
        ''Added 11/26/2022
        ''
        Dim objArrow As ArrowTriangleStructure

        objArrow = mod_objArrow
        mod_listOfArrows.Add(objArrow)
        RefreshPanelOfArrows(mod_listOfArrows)


    End Sub


    Private Sub RefreshPanelOfArrows(par_list As ClassListOfArrows)
        ''
        ''Added 11/26/2022  
        ''
        Dim objRSCDraw As New __RSCElementSelectGraphics.RSCGraphics
        FlowLayoutPanel1.Controls.Clear()
        For Each eachArrow As ArrowTriangleStructure In par_list.List()

            Dim objBox As New PictureBox
            objBox.Width = PictureBoxForTriangle.Width
            objBox.Height = PictureBoxForTriangle.Height
            objRSCDraw.DrawAndFillArrow(objBox, eachArrow, 0, 0)



        Next eachArrow



    End Sub ''End of ""Private Sub RefreshPanelOfArrows""


    Private Sub ButtonTriangle_Click()
        ''
        ''Added 11/22/2022
        ''
        ''DrawAndFillTriangle()
        ''DrawAndFillTriangle_Denigrated(Color.Aqua)

        ''//Dim rscDraw = New __RSCElementSelectGraphics.RSCGraphics
        ''//Dim grDraw As Graphics = New Graphics()
        ''//rscDraw.DrawAndFillTriangle(grDraw, Color.Aqua, mod_objArrow.triangle2)

        DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1)

    End Sub


    Private Sub DrawSinglePointRSC(par_color As Drawing.Color, piX As Integer, piY As Integer)
        ''
        ''Added 11/22/2022
        ''
        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        Dim objRSCGraphics As New __RSCElementSelectGraphics.RSCGraphics
        Const c_Size As Integer = 2
        ''---objRSCGraphics.DrawSinglePoint(par_color, piX, piY)
        objRSCGraphics.DrawSinglePoint(graph_tri, par_color, piX, piY, c_Size)

ExitHandler:
        PictureBoxForTriangle.Refresh()

    End Sub


    Private Sub DrawAndFillTriangleRSC(par_color As Drawing.Color,
                                    Optional par_triangle As Triangle = Nothing,
                                    Optional pbBreakForZeroes As Boolean = False)
        ''
        ''Added 11/22/2022
        ''
        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        Dim objRSCGraphics As New __RSCElementSelectGraphics.RSCGraphics

        objRSCGraphics.DrawAndFillTriangle(graph_tri, par_color,
                par_triangle, pbBreakForZeroes)

ExitHandler:
        PictureBoxForTriangle.Refresh()

    End Sub ''endof ""Private Sub DrawAndFillTriangleRSC""


    Private Sub DrawAndFillTriangle_Denigrated(par_color As Drawing.Color,
                                    Optional par_triangle As Triangle = Nothing,
                                    Optional pbBreakForZeroes As Boolean = False)
        ''
        ''Added 11/22/2022
        ''
        Dim objPen As Pen
        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        Dim iWid As Integer = 1 ''3

        ''11/22/2022 td''graph_tri.Clear(Color.White)

        ''Dim g_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)

        Dim objTriangle As Triangle = par_triangle '' = New Triangle

        If (objTriangle.Equals(New Triangle())) Then

            Dim objLine1 As New Line
            Dim objLine2 As New Line
            Dim objLine3 As New Line

            ''objTriangle.line1 = objLine1
            ''objTriangle.line1 = objLine1
            ''objTriangle.line1 = objLine1

            With PictureBoxForTriangle
                objLine1.point1 = New Point(0, 0)
                objLine1.point2 = New Point(0, .Height - iWid)
                objLine2.point1 = New Point(0, .Height - iWid)
                objLine2.point2 = New Point(.Width - iWid, .Height - iWid)
                objLine3.point1 = New Point(.Width - iWid, .Height - iWid)
                objLine3.point2 = New Point(0, 0)
            End With

            objTriangle.line1 = objLine1
            objTriangle.line2 = objLine2
            objTriangle.line3 = objLine3

        End If ''End of ""If (par_triangle Is Nothing) Then""

        ''objPen = New Pen(par_color, par_WidthInPixels)
        objPen = New Pen(par_color, iWid)

        DrawAndFillTriangle_Border_Denigrated(graph_tri, objTriangle, iWid, objPen)
        DrawAndFillTriangle_Fill_Denigrated(graph_tri, objTriangle, iWid, objPen, pbBreakForZeroes)

ExitHandler:
        PictureBoxForTriangle.Refresh()

    End Sub ''End of ""Private Sub DrawAndFillTriangle_Denigrated()""



    Private Sub DrawAndFillTriangle_Fill_Denigrated(par_graph As Graphics, par_triangle As Triangle,
                                           par_iWid As Integer, par_pen As Pen,
                                         Optional pbBreakForZeroes As Boolean = False)
        ''
        ''Added 11/22/2022
        ''
        Dim iWid As Integer = par_iWid

        DrawLinesBetweenLines(par_triangle.line1, par_triangle.line2,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        DrawLinesBetweenLines(par_triangle.line1, par_triangle.line3,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)

        DrawLinesBetweenLines(par_triangle.line2, par_triangle.line1,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        DrawLinesBetweenLines(par_triangle.line2, par_triangle.line3,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)

        DrawLinesBetweenLines(par_triangle.line3, par_triangle.line1,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        DrawLinesBetweenLines(par_triangle.line3, par_triangle.line2,
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes)

    End Sub ''End of ""Private Sub DrawAndFillTriangle_Fill()""



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


    Private Sub DrawAndFillTriangle_Border_Denigrated(par_graph As Graphics, par_triangle As Triangle,
                                           par_iWid As Integer, par_pen As Pen)
        ''
        ''Added 11/22/2022
        ''
        Dim iWid As Integer = par_iWid

        ''DrawLines(line1, line2, line3)
        ''DrawTriangle_PixelsWide(3, g_tri, objTriangle, Color.Black)
        DrawTriangle_PixelsWide_Denigrated(iWid, par_graph, par_triangle, Color.Black, par_pen)

ExitHandler:
        ''PictureBoxForTriangle.Refresh()

    End Sub ''End of ""Private Sub DrawAndFillTriangle_Border_Denigrated()""


    ''//Private Sub PictureBoxForBorder_Click(sender As Object, e As EventArgs) Handles PictureBoxForBorder.Click
    ''//
    ''//End Sub

    Private Sub FormTestGraphics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With PictureBoxForTriangle

            .Image = New Bitmap(.Width - 1, Height - 1)

        End With

        With PictureBoxForBorder

            .Image = New Bitmap(.Width - 1, Height - 1)

        End With

    End Sub


    Private Sub PictureBoxForTriangle_Click(sender As Object, e As EventArgs) Handles PictureBoxForTriangle.Click

        ''See the Handles PictureBoxForTriangle.MouseUp

    End Sub


    Private Sub PictureBoxForTriangle_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBoxForTriangle.MouseUp

        ''Static objTriangle As Triangle
        Dim bPoint1L1Empty As Boolean
        Dim bPoint1L2Empty As Boolean
        Dim bPoint1L3Empty As Boolean

        ''
        ''Draw a dot where the user clicked!  
        ''
        ''DrawSinglePoint(Color.Black, e.X, e.Y)
        DrawSinglePointRSC(Color.Black, e.X, e.Y)

        ''
        ''Build Triangle  
        ''
        ''With mod_objTriangle  
        With mod_objArrow.triangle1

            bPoint1L1Empty = (.line1.point1.X = 0)
            bPoint1L2Empty = (.line2.point1.X = 0)
            bPoint1L3Empty = (.line3.point1.X = 0)

            If (bPoint1L1Empty) Then
                .line1.point1.X = e.X
                .line1.point1.Y = e.Y
            ElseIf (bPoint1L2Empty) Then
                .line2.point1.X = e.X
                .line2.point1.Y = e.Y
            ElseIf (bPoint1L3Empty) Then
                .line3.point1.X = e.X
                .line3.point1.Y = e.Y

                ''Complete the triangle.
                .line1.point2 = .line2.point1
                .line2.point2 = .line3.point1
                .line3.point2 = .line1.point1

                ''Draw & fill the triangle.
                ''DrawAndFillTriangle(Color.Aqua, mod_objTriangle, True)
                ''DrawAndFillTriangle(Color.Aqua, mod_objArrow.triangle1, True)
                DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)

                ''Clear the triangle.
                .line1.point1 = New Point()
                .line1.point2 = New Point()

                .line2.point1 = New Point()
                .line2.point2 = New Point()

                .line3.point1 = New Point()
                .line3.point2 = New Point()

            End If ''End of ""If (bPoint1L1Empty) Then... ElseIf ... ElseIf ..."

        End With ''End of ""With mod_objArrow.triangle1""

    End Sub ''End of "... Handles MouseUp"

    Private Sub ButtonClearBoxForTriangle_Click(sender As Object, e As EventArgs) Handles ButtonClearBoxForTriangle.Click

        ''Added 11/22/2022 
        With PictureBoxForTriangle
            .Image = New Bitmap(.Width - 1, .Height - 1)
            .Refresh()
        End With

    End Sub


End Class
