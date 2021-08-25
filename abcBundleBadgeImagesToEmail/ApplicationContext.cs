using System;
using System.Collections.Generic;
using System.Text;
//using System.Windows.Forms;  // Added 8/23/2021 thomas downes
//using System.Data.Entity;  // Added 8/23/2021 thomas downes
using Microsoft.EntityFrameworkCore;  // Added 8/23/2021 thomas downes  

namespace abcBundleBadgeImagesToEmail_Core
{
    //
    //  https://codewithmukesh.com/blog/entity-framework-core-in-aspnet-core/
    //
    public class ApplicationContext : DbContext, IApplicationContext
    {
        //
        //   https://codewithmukesh.com/blog/entity-framework-core-in-aspnet-core/
        //
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        
        //public DbSet<Product> Products { get; set; }
        public DbSet<Models.FileModel> Products { get; set; }

    }
}
