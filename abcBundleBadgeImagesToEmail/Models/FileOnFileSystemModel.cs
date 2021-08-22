using System;
using System.Collections.Generic;
using System.Text;

namespace abcBundleBadgeImagesToEmail_Core.Models
{
    //
    //    https://codewithmukesh.com/blog/file-upload-in-aspnet-core-mvc/
    //
    public class FileOnFileSystemModel : FileModel
    {
        public string FilePath { get; set; }
    }
}
