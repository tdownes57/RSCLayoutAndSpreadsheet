//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace __RSCElementSelectGraphics
{
    public class ClassTriangle
    {
        private Point m_point1; // As Point
        private Point m_point2; // As Point
        private Point m_point3; // As Point
        private int m_numPoints;  // Must be less than or equal to 3.

        public Point Point1
        {
            get { return m_point1; }
            set { m_point1 = value; }
        }

        public Point Point2
        {
            get { return m_point2; }
            set { m_point2 = value; }
        }

        public Point Point3
        {
            get { return m_point3; }
            set { m_point3 = value; }
        }


        public ClassTriangle()
        {
            m_point1 = new Point();
            m_point2 = new Point(); 
        }


        public Point GetPoint(int p_index)
        {
            if (p_index == 1) return m_point1;
            else if (p_index == 2) return m_point2;
            else if (p_index == 3) return m_point3;
            else throw new ArgumentException("Invalid index");
        }


        public Line GetLine(int p_index)
        {
            //Added 12/14/2022 
            if (p_index == 1) return new Line { point1 = m_point1, point2 = m_point2 };
            if (p_index == 2) return new Line { point1 = m_point2, point2 = m_point3 };
            if (p_index == 3) return new Line { point1 = m_point3, point2 = m_point1 };
            throw new ArgumentException();
        }


        public void SetLine(int p_index, Line p_line)
        {
            //Added 12/14/2022 
            if (p_index == 1) { m_point1 = p_line.point1; m_point2 = p_line.point2; }
            if (p_index == 2) { m_point2 = p_line.point1; m_point3 = p_line.point2; }
            if (p_index == 3) { m_point3 = p_line.point1; m_point1 = p_line.point2; }
            throw new ArgumentException();
        }


        public void AddPoint(int par_x, int par_y)
        {
            AddPoint(new Point(par_x, par_y));  
        }


        public void AddPoint(Point par_point)
        {
            if (m_numPoints > 3) throw new System.Exception("Too many points. Max is 3.");
            if (m_numPoints == 0) m_point1 = par_point;
            if (m_numPoints == 1) m_point2 = par_point;
            if (m_numPoints == 2) m_point3 = par_point;
            ++m_numPoints;
        }


        public bool isFull()
        {
            return m_numPoints == 3;
        }


        public bool Full()
        {
            return m_numPoints == 3;
        }


    }
}
