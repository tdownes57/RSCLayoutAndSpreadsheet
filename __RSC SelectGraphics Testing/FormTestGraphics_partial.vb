Imports __RSCElementSelectGraphics

Partial Public Class FormTestGraphics
    ''
    ''Added 11/27/2022 thomas downes 
    ''
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

    End Sub ''End of ""Private Sub DrawAndFillTriangle_Fill_Denigrated()""



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


End Class
