using System;
using System.Collections.Generic;
using System.Text;

namespace abcBundleBadgeImagesToEmail_Core
{
    //     Send Emails with ASP.NET Core in 5 EASY Steps – Guide
    //     https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
    //
    public class MailRequest
    {
        /// <summary>
        /// Send Emails with ASP.NET Core in 5 EASY Steps – Guide
        /// https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
        /// </summary>
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        //
        //   https://codewithmukesh.com/blog/file-upload-in-aspnet-core-mvc/
        //   https://codewithmukesh.com/blog/entity-framework-core-in-aspnet-core/
        //   
        public List<IFormFile> Attachments { get; set; }

    }
}
