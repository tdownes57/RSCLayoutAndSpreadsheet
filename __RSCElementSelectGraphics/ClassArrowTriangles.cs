using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;  // Added 12/13/2022

namespace __RSCElementSelectGraphics
{
    public class ClassArrowTriangles
    {
        private string m_name;
        private ClassTriangle m_triangle1;
        private ClassTriangle m_triangle2;

        public ClassArrowTriangles()
        {
            m_name = "";
            m_triangle1 = new ClassTriangle();
            m_triangle2 = new ClassTriangle();
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


        public ClassTriangle GetTriangle(int p_index)
        {
            if (p_index == 1) return m_triangle1;
            else if (p_index == 2) return m_triangle2;
            else throw new ArgumentException("Invalid index");
        }


        public void AddPoint(int par_x, int par_y)
        {
            AddPoint(new Point(par_x, par_y));
        }


        public bool AddPoint(Point par_point)
        {
            if (false == m_triangle1.isFull())
            {
                m_triangle1.AddPoint(par_point);
                return true;
            }
            else if(false == m_triangle1.isFull())
            {
                m_triangle2.AddPoint(par_point);
                return true;
            }
            return false;

        }



    }
    }
