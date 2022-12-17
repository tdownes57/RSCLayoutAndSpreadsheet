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

            //Added 12/16/2022
            m_width = m_triangle1.GetWidth(1.0f);
            if (m_width < m_triangle2.GetWidth(1.0f))
            {
                m_width = m_triangle2.GetWidth(1.0f);
            }
            //Added 12/16/2022
            m_height = m_triangle1.GetHeight(1.0f);
            if (m_height < m_triangle2.GetHeight(1.0f))
            {
                m_height = m_triangle2.GetHeight(1.0f);
            }

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


        public bool isFull(bool pbRefreshCount)
        {
            //
            //Added 12/14/2022
            //
            //12-16-22 bool bBothFull = (m_triangle1.isFull() && m_triangle2.isFull());
            bool bBothFull = (m_triangle1.isFull(pbRefreshCount) 
                && m_triangle2.isFull(pbRefreshCount));
            return (bBothFull);
        }


        public ClassTriangle GetTriangle(int p_index)
        {
            if (p_index == 1) return m_triangle1;
            else if (p_index == 2) return m_triangle2;
            else throw new ArgumentException("Invalid index");
        }


        public int GetHeight(float par_scale)
        {
            //Added 12/16/2022
            if (0 < m_triangle1.CountNonzeroPoints()) Debug.Assert(m_height > 0);
            //return m_height;
            return (int)(par_scale * m_height);
        }


        public int GetWidth(float par_scale)
        {
            //Added 12/16/2022
            if (0 < m_triangle1.CountNonzeroPoints()) Debug.Assert(m_width > 0);
            //return m_width;
            return (int)(par_scale * m_width);
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
            //--if (false == m_triangle1.isFull())
            if (false == m_triangle1.isFull(true))
            {
                m_triangle1.AddPoint(par_point);
                
                //Added 12/16/2022
                if (par_point.X > m_width) m_width = par_point.X;
                if (par_point.Y > m_height) m_height = par_point.Y;

                return true;
            }

            //---else if(false == m_triangle1.isFull())
            else if (false == m_triangle1.isFull(true))
            {
                m_triangle2.AddPoint(par_point);
                
                //Added 12/16/2022
                if (par_point.X > m_width) m_width = par_point.X;
                if (par_point.Y > m_height) m_height = par_point.Y;

                return true;
            }
            return false;

        }


        public void RefreshMaxDimensionsEtc()
        {
            //
            // Refresh the data members which are statistical in nature
            //   and are not serialized. 
            //
            // Added 12/16/2022 thomas downes
            //
            m_triangle1.RefreshMaxDimensionsEtc();
            m_triangle2.RefreshMaxDimensionsEtc();

            m_width = 0;
            m_width = (m_width > m_triangle1.GetWidth(1.0f) ? m_width : m_triangle1.GetWidth(1.0f));
            m_width = (m_width > m_triangle2.GetWidth(1.0f) ? m_width : m_triangle2.GetWidth(1.0f));

            m_height = 0;
            m_height = (m_height > m_triangle1.GetHeight(1.0f) ? m_height : m_triangle1.GetHeight(1.0f));
            m_height = (m_height > m_triangle2.GetHeight(1.0f) ? m_height : m_triangle2.GetHeight(1.0f));

        }

    }

}

