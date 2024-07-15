using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __RSCSpreadsheet
{
    internal interface InterfaceCheckIfCircular<TClass> where TClass : class
    {
        //
        // Very simple, standard generic function.   
        //
        TClass ReturnClassOfType(); 
        
    }
}
