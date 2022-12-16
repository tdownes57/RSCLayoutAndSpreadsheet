using System;
using System.Diagnostics;
using System.Drawing;
//using System;  //using System.Drawing.Image;
using System.Reflection;
using System.Runtime.Remoting;
//using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;  // Added 11/26/2022 thomas downes
using __RSC_Error_Logging;   // Added 11/26/2022 thomas downes

namespace __RSCElementSelectGraphics
{

    //public struct Line
    //{
    //    //''
    //    //''Added 11/22/2022
    //    //''
    //    public Point point1; // As Point
    //    public Point point2; // As Point
    // } //End Structure



    public class RSCGraphics
    {
        public void DrawAndFillArrow(Graphics par_graph,
                    ClassArrowTriangles par_arrow,
                    System.Drawing.Color par_color,
                          int par_offsetX, int par_offsetY)
        {
            //
            // Added 12/16/2022 
            //
            int iWid = 1;
            Pen obj_pen = new Pen(par_color);
            DrawAndFillTriangle_Fill(par_graph, par_arrow.Triangle1,
                       iWid, obj_pen, false);
            DrawAndFillTriangle_Fill(par_graph, par_arrow.Triangle2,
                       iWid, obj_pen, false);

        }


        public void DrawAndFillArrow(PictureBox par_pictureBox, 
                        ClassArrowTriangles par_arrow, 
                        System.Drawing.Color par_color, 
                              int par_offsetX, int par_offsetY)
        {
            //
            // Added 11/26/2022 
            //
            int iWid = 1;
            AddImageIfNeeded(par_pictureBox);
            if (par_pictureBox.Image == null)
            {
                __RSC_Error_Logging.RSCErrorLogging.Log(57, "DrawAndFillArrow",
                      "PictureBox.Image is null");
                System.Diagnostics.Debugger.Break();
                return;
            }

            Pen obj_pen = new Pen(par_color);
            Graphics obj_graph = Graphics.FromImage(par_pictureBox.Image);
            DrawAndFillTriangle_Fill(obj_graph, par_arrow.Triangle1,
                       iWid, obj_pen, false);
            DrawAndFillTriangle_Fill(obj_graph, par_arrow.Triangle2,
                       iWid, obj_pen, false);
            par_pictureBox.Refresh();

        }


        private void DrawAndFillArrow(Image par_image,
                ClassArrowTriangles par_arrow,
                System.Drawing.Color par_color,
                      int par_offsetX, int par_offsetY)
        {
            //
            // Added 11/26/2022 
            //
            int iWid = 1;
            if (par_image == null)
            {
                __RSC_Error_Logging.RSCErrorLogging.Log(57, "DrawAndFillArrow",
                      "PictureBox.Image is null");
                System.Diagnostics.Debugger.Break();
                return;
            }

            Pen obj_pen = new Pen(par_color);
            Graphics obj_graph = Graphics.FromImage(par_image);
            DrawAndFillTriangle_Fill(obj_graph, par_arrow.Triangle1,
                       iWid, obj_pen, false);
            DrawAndFillTriangle_Fill(obj_graph, par_arrow.Triangle2,
                       iWid, obj_pen, false);


        }



        //Private Function GetPointFromLine_ByFractioning(par_line As Line, par_denominator As Integer,
        //                                         par_numerator As Integer,
        //                                         Optional pbBreakForZeros As Boolean = False) As Point
        private Point GetPointFromLine_ByFractioning(Line par_line, int par_denominator,
                                                 int par_numerator,
                                                 bool pbBreakForZeros = false) // As Point
        {
            //''
            //''Added 11/22/2022  
            //''
            int intX = 0;  //Dim intX As Integer
            int intY = 0;  //Dim intY As Integer

            //With par_line
            //  intX = CDbl(.point1.X) + ((CDbl(.point2.X - .point1.X) / CDbl(par_denominator)) * par_numerator)
            //  intY = CDbl(.point1.Y) + ((CDbl(.point2.Y - .point1.Y) / CDbl(par_denominator)) * par_numerator)
            //End With

            intX = (int)((double)par_line.point1.X + (double)par_numerator *
                                                    ((double)(par_line.point2.X - par_line.point1.X)
                                                      / (double)par_denominator));
            intY = (int)((double)par_line.point1.Y + (double)par_numerator *
                                                    ((double)(par_line.point2.Y - par_line.point1.Y)
                                                      / (double)par_denominator));

            if (pbBreakForZeros && (intX == 0 && intY == 0))
                System.Diagnostics.Debugger.Break();

            return new Point(intX, intY);

            //End Function ''End of ""Private Function GetPointFromLine_ByFractioning""

        }

        //    Private Sub DrawLinesBetweenLines(par_line1 As Line, par_line2 As Line,
        //                               par_iWid As Integer, par_graph As Graphics,
        //                               par_pen As Pen,
        //                               par_howManyLines As Integer,
        //                               Optional pbBreakForZeroes As Boolean = False)
        //    ''
        //    ''Added 11/22/2022
        //    ''
        //    Dim point1 As Point
        //    Dim point2 As Point

        //    ''
        //    ''Very pretty, but too many gaps!
        //    ''
        //    For index As Integer = 0 To par_howManyLines - 1

        //        point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines, index)
        //        point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines, index)
        //        par_graph.DrawLine(par_pen, point1, point2)

        //    Next index

        //    ''
        //    ''Draw(par_howManyLines* par_howManyLines) lines 
        //    ''
        //    For indexOut As Integer = 0 To par_howManyLines - 1
        //        point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines, indexOut, pbBreakForZeroes)
        //        For indexIn As Integer = 0 To par_howManyLines - 1
        //            point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines, indexIn, pbBreakForZeroes)
        //            par_graph.DrawLine(par_pen, point1, point2)
        //        Next indexIn
        //    Next indexOut

        //End Sub ''End of ""Private Sub DrawLinesBetweenLines()""


        private void DrawLinesBetweenLines(Line par_line1, Line par_line2,
                                       int par_iWid, Graphics par_graph,
                                       Pen par_pen,
                                       int par_howManyLines,
                                       bool pbBreakForZeroes = false)
        {
            //    ''
            //    ''Added 11/22/2022
            //    ''
            Point point1; // As Point
            Point point2; // As Point

            //Added 11/27/2022
            Debug.Assert(par_line1.point1 != par_line1.point2);
            Debug.Assert(par_line2.point1 != par_line2.point2);

            //    For indexOut As Integer = 0 To par_howManyLines - 1
            //        point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines, indexOut, pbBreakForZeroes)
            //        For indexIn As Integer = 0 To par_howManyLines - 1
            //            point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines, indexIn, pbBreakForZeroes)
            //            par_graph.DrawLine(par_pen, point1, point2)
            //        Next indexIn
            //    Next indexOut

            for (int indexOut = 0; indexOut < par_howManyLines - 1; ++indexOut)
            {
                point1 = GetPointFromLine_ByFractioning(par_line1, par_howManyLines,
                                           indexOut, pbBreakForZeroes);
                for (int indexIn = 0; indexIn < par_howManyLines; ++indexIn)
                {
                    point2 = GetPointFromLine_ByFractioning(par_line2, par_howManyLines,
                                         indexIn, pbBreakForZeroes);
                    par_graph.DrawLine(par_pen, point1, point2);
                }   //Next indexIn
            }  //  Next indexOut

        }

        //    Private Sub DrawAndFillTriangle_Fill(par_graph As Graphics, par_triangle As Triangle,
        //                                   par_iWid As Integer, par_pen As Pen,
        //                                 Optional pbBreakForZeroes As Boolean = False)
        //    ''
        //    ''Added 11/22/2022
        //    ''
        //    Dim iWid As Integer = par_iWid

        //    DrawLinesBetweenLines(par_triangle.line1, par_triangle.line2,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        //    DrawLinesBetweenLines(par_triangle.line1, par_triangle.line3,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)

        //    DrawLinesBetweenLines(par_triangle.line2, par_triangle.line1,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        //    DrawLinesBetweenLines(par_triangle.line2, par_triangle.line3,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)

        //    DrawLinesBetweenLines(par_triangle.line3, par_triangle.line1,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)
        //    DrawLinesBetweenLines(par_triangle.line3, par_triangle.line2,
        //                          iWid, par_graph, par_pen, 20, pbBreakForZeroes)

        //End Sub ''End of ""Private Sub DrawAndFillTriangle_Fill()""

        private void DrawAndFillTriangle_Fill(Graphics par_graph, 
                                       ClassTriangle par_triangle,
                                       int par_iWid, Pen par_pen,
                                       bool pbBreakForZeroes = false)
        {
            //''
            //''Added 11/22/2022
            //''
            //Dim iWid As Integer = par_iWid
            int iWid = par_iWid;

            DrawLinesBetweenLines(par_triangle.GetLine(1), par_triangle.GetLine(2),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);
            DrawLinesBetweenLines(par_triangle.GetLine(1), par_triangle.GetLine(3),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);

            DrawLinesBetweenLines(par_triangle.GetLine(2), par_triangle.GetLine(1),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);
            DrawLinesBetweenLines(par_triangle.GetLine(2), par_triangle.GetLine(3),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);

            DrawLinesBetweenLines(par_triangle.GetLine(3), par_triangle.GetLine(1),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);
            DrawLinesBetweenLines(par_triangle.GetLine(3)   , par_triangle.GetLine(2),
                              iWid, par_graph, par_pen, 20, pbBreakForZeroes);

        } // End Sub ''End of ""Private Sub DrawAndFillTriangle_Fill()""


        //    Private Sub DrawTriangle_PixelsWide(par_WidthInPixels As Integer,
        //                              par_gr As Graphics,
        //                              par_triangle As Triangle,
        //                              par_color As Color,
        //                                Optional par_pen As Pen = Nothing)
        //    ''
        //    ''Added 11/22/2022 td  
        //    ''
        //    Dim pen_border As System.Drawing.Pen
        //    ''Dim intLineIndex As Integer
        //    ''Dim intOffsetPixels As Integer
        //    Dim arrayOfPoints As Point()

        //    ''11/2022 ReDim arrayOfPoints(4)
        //    ReDim arrayOfPoints(3)
        //    arrayOfPoints(0) = par_triangle.line1.point1
        //    arrayOfPoints(1) = par_triangle.line2.point1
        //    arrayOfPoints(2) = par_triangle.line3.point1
        //    arrayOfPoints(3) = par_triangle.line3.point2

        //    ''---For intLineIndex = 1 To(par_WidthInPixels)

        //    If(par_pen IsNot Nothing) Then
        //        pen_border = par_pen
        //    Else
        //        pen_border = New Pen(par_color, par_WidthInPixels)
        //    End If

        //    ''intOffsetPixels = (intLineIndex - 1)

        //    par_gr.DrawLines(pen_border, arrayOfPoints)

        //    ''Next intLineIndex

        //End Sub ''end of "Private Sub DrawBorder_PixelsWide(par_elementInfo_Base.Border_WidthInPixels, gr_element, intNewElementWidth, intNewElementHeight)"

        private void DrawTriangle_PixelsWide(int par_WidthInPixels,
                                  Graphics par_gr,
                                  ClassTriangle par_triangle,
                                  Color par_color,
                                  Pen par_pen = null, 
                                  bool pboolOmitAnyZeroes = true)
        {
            //''
            //''Added 11 / 22 / 2022 td
            //''
            Pen pen_border; // As System.Drawing.Pen
                            //int intLineIndex; // As Integer
                            //int intOffsetPixels; // As Integer

            int numNonZeroPoints = par_triangle.CountNonzeroPoints();

            Point[] arrayOfPoints; // = new Point[4];  // Point[3];

            if (numNonZeroPoints == 3) arrayOfPoints = new Point[4];
            else if (numNonZeroPoints == 2) arrayOfPoints = new Point[2];
            else if (numNonZeroPoints == 1) 
            {
                // Added 12/15/2022 thomas downes
                //----arrayOfPoints = new Point[1];  //Won't be used. 
                DrawSinglePoint(par_gr, par_color,
                         par_triangle.Point1.X,
                         par_triangle.Point1.Y,
                         par_WidthInPixels);
                return; 
             }
            else return;

            //''11 / 2022 ReDim arrayOfPoints(4)
            //ReDim arrayOfPoints(3)
            //arrayOfPoints[0] = par_triangle.line1.point1;
            //arrayOfPoints[1] = par_triangle.line2.point1;
            //arrayOfPoints[2] = par_triangle.line3.point1;
            //arrayOfPoints[3] = par_triangle.line3.point2;

            //----if (numNonZeroPoints == 4)
            if (numNonZeroPoints == 3)
            {
                // Connect the dots. The 4th dot is semi-redundant but 
                //    closes the loop. --12/14/2022
                arrayOfPoints[0] = par_triangle.Point1;
                arrayOfPoints[1] = par_triangle.Point2;
                arrayOfPoints[2] = par_triangle.Point3;
                arrayOfPoints[3] = par_triangle.Point1;
            }
            else
            {
                arrayOfPoints[0] = par_triangle.Point1;
                arrayOfPoints[1] = par_triangle.Point2;
            }

            //''-- - For intLineIndex = 1 To(par_WidthInPixels)

            if (par_pen != null)
                pen_border = par_pen;
            else
                pen_border = new Pen(par_color, par_WidthInPixels);
            //End If

            //''intOffsetPixels = (intLineIndex - 1)

            //par_gr.DrawLines(pen_border, arrayOfPoints);
            par_gr.DrawLines(pen_border, arrayOfPoints);

            //''Next intLineIndex

        }  // End Sub ''end of "Private Sub DrawTriangle_PixelsWide(par_elementInfo_Base.Border_WidthInPixels, gr_element, intNewElementWidth, intNewElementHeight)"


        //Private Sub DrawAndFillTriangle_Border(par_graph As Graphics, par_triangle As Triangle,
        //                                par_iWid As Integer, par_pen As Pen)
        //''
        //''Added 11/22/2022
        //''
        //Dim iWid As Integer = par_iWid

        //''DrawLines(line1, line2, line3)
        //''DrawTriangle_PixelsWide(3, g_tri, objTriangle, Color.Black)
        //DrawTriangle_PixelsWide(iWid, par_graph, par_triangle, Color.Black, par_pen)

        //ExitHandler:
        //''PictureBoxForTriangle.Refresh()

        //End Sub ''End of ""Private Sub DrawAndFillTriangle_Border()""

        private void DrawAndFillTriangle_Border(Graphics par_graph,
                             ClassTriangle par_triangle,
                              int par_iWid, Pen par_pen)
        {
            //''
            //''Added 11/22/2022
            //''
            int iWid = par_iWid;

            //''DrawLines(line1, line2, line3)
            //''DrawTriangle_PixelsWide(3, g_tri, objTriangle, Color.Black)
            DrawTriangle_PixelsWide(iWid, par_graph, par_triangle, Color.Black, par_pen);

            //ExitHandler:
            //''PictureBoxForTriangle.Refresh()

            //End Sub ''End of ""Private Sub DrawAndFillTriangle_Border()""
        }

        //Private Sub DrawAndFillTriangle(par_color As Drawing.Color,
        //                        Optional par_triangle As Triangle = Nothing,
        //                        Optional pbBreakForZeroes As Boolean = False)
        //        ''
        //        ''Added 11/22/2022
        //        ''
        //        Dim objPen As Pen
        //        Dim graph_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)
        //        Dim iWid As Integer = 1 ''3

        //        ''11/22/2022 td''graph_tri.Clear(Color.White)

        //        ''Dim g_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)

        //        Dim objTriangle As Triangle = par_triangle '' = New Triangle

        //        If(objTriangle.Equals(New Triangle())) Then

        //            Dim objLine1 As New Line
        //            Dim objLine2 As New Line
        //            Dim objLine3 As New Line

        //            ''objTriangle.line1 = objLine1
        //            ''objTriangle.line1 = objLine1
        //            ''objTriangle.line1 = objLine1

        //            With PictureBoxForTriangle
        //                objLine1.point1 = New Point(0, 0)
        //                objLine1.point2 = New Point(0, .Height - iWid)
        //                objLine2.point1 = New Point(0, .Height - iWid)
        //                objLine2.point2 = New Point(.Width - iWid, .Height - iWid)
        //                objLine3.point1 = New Point(.Width - iWid, .Height - iWid)
        //                objLine3.point2 = New Point(0, 0)
        //            End With

        //            objTriangle.line1 = objLine1
        //            objTriangle.line2 = objLine2
        //            objTriangle.line3 = objLine3

        //        End If ''End of ""If (par_triangle Is Nothing) Then""

        //        ''objPen = New Pen(par_color, par_WidthInPixels)
        //        objPen = New Pen(par_color, iWid)

        //        DrawAndFillTriangle_Border(graph_tri, objTriangle, iWid, objPen)
        //        DrawAndFillTriangle_Fill(graph_tri, objTriangle, iWid, objPen, pbBreakForZeroes)

        //ExitHandler:
        //        PictureBoxForTriangle.Refresh()
        //
        //End Sub ''End of ""Private Sub DrawAndFillTriangle()""


        public void DrawSinglePoint(Graphics par_graph, Color par_color, 
            int par_X, int par_Y, int par_size)
        {
            //''
            //''Added 11/24/2022
            //''
            Pen objPen;
            Brush objBrush = new SolidBrush(par_color);
            Rectangle objRect = new Rectangle(par_X, par_Y, par_size, par_size);
            objPen = new Pen(par_color, par_size);
            par_graph.FillRectangle(objBrush, objRect);


        }

        public void DrawAndFillTriangle(Graphics par_graph, Color par_color,
                                    ClassTriangle par_triangle,
                                    bool pbBreakForZeroes = false,
                                    bool pbOmitAnyZeroes = true)
        {
            //''
            //''Added 11/22/2022
            //''
            Pen objPen;
            
            //Graphics graph_tri = Graphics.FromImage(PictureBoxForTriangle.Image);
            int iWid = 1; // ''3

            //''11 / 22 / 2022 td''graph_tri.Clear(Color.White)

            //''Dim g_tri As Graphics = Graphics.FromImage(PictureBoxForTriangle.Image)

            ClassTriangle objTriangle = par_triangle; //'' = New Triangle

            /*If(objTriangle.Equals(New Triangle())) Then

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

            End If ''End of ""If(par_triangle Is Nothing) Then""
            */

            //''objPen = New Pen(par_color, par_WidthInPixels)
            objPen = new Pen(par_color, iWid);

            if (par_triangle.isFull())
            {
                DrawAndFillTriangle_Border(par_graph, objTriangle, iWid, objPen);
                DrawAndFillTriangle_Fill(par_graph, objTriangle, iWid, objPen, pbBreakForZeroes);
            }
            else
            {
                //Added 12/14/2022  
                //12/14/2022 DrawTriangle_PixelsWide(par_graph, objTriangle, iWid 
                DrawTriangle_PixelsWide(iWid, par_graph, objTriangle, 
                    par_color, objPen, pbOmitAnyZeroes);
            }

             // ExitHandler:
            //PictureBoxForTriangle.Refresh()

        } // End Sub ''End of ""Private Sub DrawAndFillTriangle()""


        private void AddImageIfNeeded(PictureBox par_box )
        {
            if (par_box.Image == null)
            par_box.Image = new Bitmap(par_box.Width - 1, par_box.Height - 1);

        }





    }
}
