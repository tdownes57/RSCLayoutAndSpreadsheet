Imports System.Drawing
Imports System.Drawing.Text
Imports System.Reflection
Imports __RSCElementSelectGraphics
Imports __RSCWindowsControlLibrary
Imports ciBadgeSerialize

Public Class FormTestGraphics

    ''Private mod_objTriangle As Triangle ''Added 11/22/2022 
    Private mod_objArrow As New ArrowTriangleStructure ''Added 11/22/2022 
    Private mod_listOfArrows As New ClassListOfArrows ''Added 11/26/2022 
    Private mod_colorArrows As Drawing.Color ''Added 11/27/2022

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
        Dim objArrow As ArrowTriangleStructure

        mod_objArrow.Name = textNameOfArrow.Text.Trim()
        If (mod_objArrow.Name = "") Then
            MessageBoxTD.Show_Statement("You need to supply a name for the arrow.")
            Exit Sub
        End If ''Endof ""If (mod_objArrow.Name = "") Then""

        objArrow = mod_objArrow
        mod_listOfArrows.Add(objArrow)
        ''Added 12/13/2022
        mod_listOfArrows.SaveToXML("ListOfArrows.xml")

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
        For Each eachArrow As ArrowTriangleStructure In par_list.List()

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

        Next eachArrow

        FlowLayoutPanel1.Refresh()


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

        ''//DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1)
        DrawAndFillTriangleRSC(mod_colorArrows, mod_objArrow.triangle1)

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

        ''Added 12/13/2022
        If (IO.File.Exists("ListOfArrows.xml")) Then
            mod_listOfArrows = ClassListOfArrows.LoadFromXML("ListOfArrows.xml")
            RefreshPanelOfArrows(mod_listOfArrows)
        End If ''End of ""If (IO.File.Exists(...)) Then"

    End Sub


    Private Sub PictureBoxForTriangle_Click(sender As Object, e As EventArgs) Handles PictureBoxForTriangle.Click

        ''See the Handles PictureBoxForTriangle.MouseUp

    End Sub


    Private Sub PictureBoxForTriangle_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBoxForTriangle.MouseUp

        ''Static objTriangle As Triangle
        Dim temp_triangle As New Triangle
        Dim bPoint1L1Empty As Boolean
        Dim bPoint1L2Empty As Boolean
        Dim bPoint1L3Empty As Boolean
        Dim bPoint2L1Empty As Boolean
        Dim bPoint2L2Empty As Boolean
        Dim bPoint2L3Empty As Boolean
        Dim bTriangle1Empty As Boolean
        Dim bTriangle2Empty As Boolean
        Dim bNeitherIsEmpty As Boolean

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
            ''If (bPoint1L1Empty) Then temp_triangle = mod_objArrow.triangle1
            ''bTriangle1Empty = (bPoint1L1Empty And bPoint1L2Empty)
            bTriangle1Empty = (bPoint1L1Empty And bPoint1L3Empty)
        End With

        With mod_objArrow.triangle2
            bPoint2L1Empty = (.line1.point1.X = 0)
            bPoint2L2Empty = (.line2.point1.X = 0)
            bPoint2L3Empty = (.line3.point1.X = 0)
        End With ''End of ""With mod_objArrow.triangle1""

        ''bTriangle2Empty = (bPoint2L3Empty) ''Then temp_triangle = mod_objArrow.triangle1
        bTriangle2Empty = (bPoint2L2Empty) ''Then temp_triangle = mod_objArrow.triangle1
        bNeitherIsEmpty = (False = (bTriangle2Empty Or bTriangle2Empty))

        Dim bFillingTriangle1 As Boolean
        Dim bFillingTriangle2 As Boolean
        Dim bFillingTriangleNew As Boolean
        Dim bCompletedTriangle1 As Boolean
        Dim bCompletedTriangle2 As Boolean

        If (bPoint1L1Empty Or bPoint1L2Empty Or bPoint1L3Empty) Then
            bFillingTriangle1 = True
            temp_triangle = mod_objArrow.triangle1
        ElseIf (bPoint2L1Empty Or bPoint2L2Empty Or bPoint2L3Empty) Then
            bFillingTriangle2 = True
            temp_triangle = mod_objArrow.triangle2
        Else
            bFillingTriangleNew = True
        End If

        With temp_triangle ''mod_objArrow.triangle1

            If (bFillingTriangleNew) Then
                .line1.point1.X = e.X
                .line1.point1.Y = e.Y
            ElseIf (bPoint1L1Empty) Then
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
                bCompletedTriangle1 = True

            ElseIf (bPoint2L1Empty) Then
                .line1.point1.X = e.X
                .line1.point1.Y = e.Y
            ElseIf (bPoint2L2Empty) Then
                .line2.point1.X = e.X
                .line2.point1.Y = e.Y
            ElseIf (bPoint2L3Empty) Then
                .line3.point1.X = e.X
                .line3.point1.Y = e.Y

                ''Complete the triangle.
                .line1.point2 = .line2.point1
                .line2.point2 = .line3.point1
                .line3.point2 = .line1.point1
                bCompletedTriangle2 = True

                ''Draw & fill the triangle.
                ''DrawAndFillTriangle(Color.Aqua, mod_objTriangle, True)
                ''DrawAndFillTriangle(Color.Aqua, mod_objArrow.triangle1, True)
                ''----Nov27---DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)

                ''----Nov27---''Clear the triangle.
                ''----Nov27---.line1.point1 = New Point()
                ''----Nov27---.line1.point2 = New Point()
                ''----Nov27---.line2.point1 = New Point()
                ''----Nov27---.line2.point2 = New Point()
                ''----Nov27---.line3.point1 = New Point()
                ''----Nov27---.line3.point2 = New Point()

            End If ''End of ""If (bPoint1L1Empty) Then... ElseIf ... ElseIf ..."

        End With ''End of ""With temp_triangle""

        If (bFillingTriangle1) Then ''(bPoint1L3Empty) Then ''If (bTriangle1Empty) Then
            mod_objArrow.triangle1 = temp_triangle
            ''Moved below.''DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ElseIf (bFillingTriangle2) Then ''ElseIf (bPoint2L3Empty) Then ''(bTriangle2Empty) Then
            mod_objArrow.triangle2 = temp_triangle
            ''Moved below.''DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle2, True)
        ElseIf (bFillingTriangleNew) Then ''ElseIf (bNeitherIsEmpty) Then
            mod_objArrow.triangle1 = temp_triangle
            mod_objArrow.triangle2 = New Triangle
            ''--DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        End If

ExitHandler:
        If (bCompletedTriangle1) Then
            DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle1, True)
        ElseIf (bCompletedTriangle2) Then
            DrawAndFillTriangleRSC(Color.Black, mod_objArrow.triangle2, True)
        End If

    End Sub ''End of "... Handles MouseUp"

    Private Sub ButtonClearBoxForTriangle_Click(sender As Object, e As EventArgs) Handles ButtonClearBoxForTriangle.Click

        ''Added 11/22/2022 
        With PictureBoxForTriangle
            .Image = New Bitmap(.Width - 1, .Height - 1)
            .Refresh()
        End With

    End Sub

    Private Sub PictureBoxInner_Click(sender As Object, e As EventArgs) Handles PictureBoxInner.Click

    End Sub
End Class
