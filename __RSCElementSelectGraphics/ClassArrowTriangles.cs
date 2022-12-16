using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Security.Permissions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
using System.Xml.Serialization;  // Added 12/13/2022

namespace __RSCElementSelectGraphics
{

    [Serializable]
    public class ClassArrowTriangles
    {
        private string m_name;
        private ClassTriangle m_triangle1;
        private ClassTriangle m_triangle2;
        private int m_width;
        private int m_height;

        public ClassArrowTriangles()
        {
            m_name = "";
            m_triangle1 = new ClassTriangle();
            m_triangle2 = new ClassTriangle();
        }


        public ClassArrowTriangles(Queue<System.Drawing.Point> par_queue)
        {
            m_name = "";
            m_triangle1 = new ClassTriangle(par_queue);
            m_triangle2 = new ClassTriangle(par_queue);

        }


        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public ClassTriangle Triangle1
        {
            get { return m_triangle1; }   // get method
            set { m_triangle1 = value; }  // set method
        }

        public ClassTriangle Triangle2
        {
            get { return m_triangle2; }   // get method
            set { m_triangle2 = value; }  // set method
        }


        public bool isFull()
        {
            //Added 12/14/2022 
            bool bBothFull = (m_triangle1.isFull() && m_triangle2.isFull());
            return (bBothFull);
        }


        public ClassTriangle GetTriangle(int p_index)
        {
            if (p_index == 1) return m_triangle1;
            else if (p_index == 2) return m_triangle2;
            else throw new ArgumentException("Invalid index");
        }


        public int GetHeight()
        {
            //Added 12/16/2022
            Debug.Assert(m_height > 0);
            return m_height;
        }


        public int GetWidth()
        {
            //Added 12/16/2022
            Debug.Assert(m_width > 0);
            return m_width;
        }



        public void AddPoint(int par_x, int par_y)
        {
            AddPoint(new Point(par_x, par_y));
            //Added 12/16/2022
            if (par_x > m_width) m_width = par_x;
            if (par_y > m_height) m_height = par_y;
        }


        public bool AddPoint(Point par_point)
        {
            if (false == m_triangle1.isFull())
            {
                m_triangle1.AddPoint(par_point);
                
                //Added 12/16/2022
                if (par_point.X > m_width) m_width = par_point.X;
                if (par_point.Y > m_height) m_height = par_point.Y;

                return true;
            }
            else if(false == m_triangle1.isFull())
            {
                m_triangle2.AddPoint(par_point);
                
                //Added 12/16/2022
                if (par_point.X > m_width) m_width = par_point.X;
                if (par_point.Y > m_height) m_height = par_point.Y;

                return true;
            }
            return false;

        }



    }
    }
