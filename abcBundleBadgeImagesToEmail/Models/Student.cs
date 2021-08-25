using System;
using System.Collections.Generic;
using System.Text;

//
//   https://codewithmukesh.com/blog/entity-framework-core-in-aspnet-core/
//
namespace abcBundleBadgeImagesToEmail_Core.Models
{
    //
    //   https://codewithmukesh.com/blog/entity-framework-core-in-aspnet-core/
    //
    public class Student : Entity
    {
        public int Age { get; set; }
        public int Roll { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
    }
}
