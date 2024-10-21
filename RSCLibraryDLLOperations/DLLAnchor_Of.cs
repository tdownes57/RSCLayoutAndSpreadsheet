using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace RSCLibraryDLLOperations
{
    public class DLLAnchor<TControl>
    {
        /// <summary>
        /// This item will serve as an anchor (fixed point).
        /// The range of item(s) will be placed immediately BEFORE 
        /// or AFTER the anchor.
        /// </summary>
        public TControl? _anchorItem;

        /// <summary>
        /// Indicates that the range will be inserted BEFORE
        /// the anchor-item. 
        /// Ultimately, the anchor-item will FOLLOW 
        /// the inserted range. (Confusing!)
        /// </summary>
        public bool _doInsertRangeBeforeThis;

        /// <summary>
        /// Indicates that the range will be inserted AFTER
        /// the anchor-item. 
        /// Ultimately, the anchor-item will be located PRIOR 
        /// to the inserted range. (Confusing!)
        /// </summary>
        public bool _doInsertRangeAfterThis;

        /// <summary>
        /// For for operations which are the (initial) load an empty list. 
        /// </summary>
        public bool _isForEmptyList;

        public DLLAnchor(bool pbIsForEmptyList)
        {
            //
            // Added 10/20/2024 
            //
            _anchorItem = default(TControl);
            _isForEmptyList = pbIsForEmptyList;
        }


    }
}
