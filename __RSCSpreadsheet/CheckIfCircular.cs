using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __RSCSpreadsheet
{
    //
    // Will the class below compile??  
    //
    internal class CheckIfCircular : InterfaceCheckIfCircular<CheckIfCircular>
    {

        public CheckIfCircular ReturnClassOfType()
        {
            //
            // Return a class of this same type.  
            //
            return new CheckIfCircular();

        }


    }
}
