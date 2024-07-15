using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __RSCSpreadsheet
{
    internal class ClassCanCopyItself : ICopyMyself<ClassCanCopyItself>
    {
        private int _someNumber;

         public ClassCanCopyItself CopyOfMe()
        {

            //return this;

            // Let's create a deep copy, 
            //   rather than a shallow copy. 
            //
            ClassCanCopyItself result = new ClassCanCopyItself();
            result._someNumber = _someNumber;
            return result;

        }

    }
}
