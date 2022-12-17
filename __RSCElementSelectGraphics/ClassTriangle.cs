//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.IO.Ports;
using System.Diagnostics;

namespace __RSCElementSelectGraphics
{
    [Serializable]
    public class ClassTriangle
    {
        private Point m_point1; // As Point
        private Point m_point2; // As Point
        private Point m_point3; // As Point
        private int m_numPoints;  // Must be less than or equal to 3.
        private int m_width = 0;  //Added 12/16/2022 
        private int m_height = 0; //Added 12/16/2022

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
            m_point3 = new Point();
        }

        public ClassTriangle(Queue<Point> par_queue) : this()
        {
            //
            // Added 12/15/2022
            //
            while (m_numPoints < 3 && par_queue.Count > 0)
            {
                Point obj_point = par_queue.Dequeue();
                if (m_numPoints == 0) m_point1 = obj_point;
                else if (m_numPoints == 1)
                {
                    Debug.Assert(obj_point != m_point1);
                    m_point2 = obj_point;
                }
                else if (m_numPoints == 2) 
                {
                    Debug.Assert(obj_point != m_point1);
                    Debug.Assert(obj_point != m_point2);
                    m_point3 = obj_point;
                }
                // Added 12/15/2022 
                if (m_numPoints < 3) ++m_numPoints;

                //Added 12/16/2022
                if (obj_point.X > m_width) m_width = obj_point.X;
                if (obj_point.Y > m_height) m_height = obj_point.Y;
            }
        }


        public int CountNonzeroPoints()
        {
            //Added 12/14/2022
            const bool c_boolRefreshTheCount = true;  
            isFull(c_boolRefreshTheCount); //Added 12/16/2022 
            return m_numPoints;
        }


        public Point GetPoint(int p_index, float par_scale = 1.00f)
        {
            if (par_scale == 1.00f)
            {
                if (p_index == 1) return m_point1;
                else if (p_index == 2) return m_point2;
                else if (p_index == 3) return m_point3;
                else throw new ArgumentException("Invalid index");
            }
            else
            {
                Debug.Assert(0 < par_scale);
                if (p_index == 1) return GetPoint(m_point1, par_scale);
                else if (p_index == 2) return GetPoint(m_point2, par_scale);
                else if (p_index == 3) return GetPoint(m_point3, par_scale);
                else throw new ArgumentException("Invalid index");
            }
        }


        public Point GetPoint(Point par_point, float par_scale = 1.00f)
        {
            // Added 12/16/2022 
            return new Point((int)(par_scale * par_point.X), 
                             (int)(par_scale * par_point.Y));
        }


        public Line GetLine(int p_index, float par_scale = 1.00f)
        {
            //Added 12/14/2022 
            // if (p_index == 1) return new Line { point1 = m_point1, point2 = m_point2 };
            // if (p_index == 2) return new Line { point1 = m_point2, point2 = m_point3 };
            // if (p_index == 3) return new Line { point1 = m_point3, point2 = m_point1 };
            if (p_index == 1) return new Line { point1 = GetPoint(1, par_scale), 
                                                point2 = GetPoint(2, par_scale) };
            if (p_index == 2) return new Line { point1 = GetPoint(2, par_scale), 
                                                point2 = GetPoint(3, par_scale) };
            if (p_index == 3) return new Line { point1 = GetPoint(3, par_scale), 
                                                point2 = GetPoint(1, par_scale) };
            throw new ArgumentException();
        }


        public int GetWidth(float par_scale)
        {
            //return m_width;   //Added 12/16/2022
            return (int)(par_scale * m_width);  //Added 12/16/2022
        }

        public int GetHeight(float par_scale)
        {
            //return m_height;   //Added 12/16/2022
            return (int)(par_scale * m_height);   //Added 12/16/2022
        }


        public Line line1() {  return new Line { point1 = m_point1, point2 = m_point2 }; }
        public Line line2() { return new Line { point1 = m_point2, point2 = m_point3 }; }
        public Line line3() { return new Line { point1 = m_point3, point2 = m_point1 }; }


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


        public bool isFull(bool pbRefreshCount)
        {
            if (pbRefreshCount) // Added 12/16/2022 thomas downes
            {
                m_numPoints = ((m_point1.X > 0 ? 1 : 0) 
                           + (m_point2.X > 0 ? 1 : 0)
                           + (m_point3.X > 0 ? 1 : 0));
            }
            
            return (3 == m_numPoints);
        }


        public bool Full(bool pbRefreshCount = false)
        {
            //return m_numPoints == 3;
            return isFull(pbRefreshCount);

        }


        public void RefreshMaxDimensionsEtc()
        {
            //
            // Refresh the data members which are statistical in nature
            //   and are not serialized. 
            //
            // Added 12/16/2022 thomas downes
            //
            m_numPoints = ((m_point1.X > 0 ? 1 : 0)
                           + (m_point2.X > 0 ? 1 : 0)
                           + (m_point3.X > 0 ? 1 : 0));

            m_width = 0;
            m_width = (m_width > m_point1.X ? m_width : m_point1.X);
            m_width = (m_width > m_point2.X ? m_width : m_point2.X);
            m_width = (m_width > m_point3.X ? m_width : m_point3.X);
            
            m_height = 0;
            m_height = (m_height > m_point1.Y ? m_height : m_point1.Y);
            m_height = (m_height > m_point2.Y ? m_height : m_point2.Y);
            m_height = (m_height > m_point3.Y ? m_height : m_point3.Y);

        }


    }
}
