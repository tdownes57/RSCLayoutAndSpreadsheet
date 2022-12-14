//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;

namespace __RSCElementSelectGraphics
{
    //internal class DefineStructures
    //{
    //}

    public struct Line
    {
        //''
        //''Added 11/22/2022
        //''
        public Point point1; // As Point
        public Point point2; // As Point
    } //End Structure


    public struct Triangle_Deprecated  //Public Structure Triangle
    {
        //''
        //''Added 11/22/2022
        //''
        public Line line1; // As Line
        public Line line2; // As Line
        public Line line3; // As Line
    } // End Structure


    public struct ArrowTriangleStructure  //Public Structure Arrow
    {
        //''
        //''Added 11/22/2022
        //''
        public string Name; // E.g. "South" or "NW" (Northwest)
        public Triangle_Deprecated triangle1; // As Triangle
        public Triangle_Deprecated triangle2; // As Triangle

    } // End Structure





}
