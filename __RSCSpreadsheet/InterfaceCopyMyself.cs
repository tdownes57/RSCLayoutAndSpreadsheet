using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __RSCSpreadsheet
{
    internal interface ICopyMyself<TClass> where TClass : class
    {

        TClass CopyOfMe(); 
        
    }
}
