using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;  //Added 11/28/2019 td
using System.Web.Hosting; //Added 11/25/2019 td  

//
//This CS (C#) file was copied to this Desktop-VB project from the Web-CS project.
//   ----12/5/2021 td
//

namespace ciBadgeForWeb.App_Start
{
    public class DiskFilesCS
    {
        //
        //This CS (C#) file was copied to this Desktop-VB project from the Web-CS project.
        //   ----12/5/2021 td
        //
        //Added 11/15/2019 td  
        //
        private static string mod_fileTitleXML_Current = ""; //Added 11/28/2019 td 
        // 3-24-2020 td//private static string mod_fileTitleJSON_Current = ""; //Added 3/20/2020 td 

        private static bool mod_boolCorruptedFilename = false;  //Added 2/16/2020 td
        private static string mod_strCorruptedFilename = "";  //Added 2/16/2020 td

        // Added 3/24/2020 td
        //
        //   Here is a data structure to map the Left, Top, Width & Height properties
        //   to the corresponding JSON file.   ---3/24/2020 td
        //
        private static Dictionary<string, string> mod_dictionary_fileTitleJSON; // Added 3/24/2020 

        public static string PathToFile_BackImage(string pstrFileTitle, bool pboolAbsolute,
                  bool pboolResolve = false)
        {
            //
            //Added 1/14/2020
            //
            //bool boolNotYetDetermined = ("" == mod_fileTitleXML_Current);
            string strPathToFileJpeg = "";
            string strPathToFolderBackJpegs = DiskFolders.PathToFolderWithBacks(pboolAbsolute);
            bool boolMatchOfTitle = false;

            foreach (FileInfo file_Info in (new DirectoryInfo(strPathToFolderBackJpegs)).GetFiles(pstrFileTitle))
            {
                boolMatchOfTitle = (file_Info.Name.ToUpper() == pstrFileTitle.ToUpper());

                if (boolMatchOfTitle)
                {
                    strPathToFileJpeg = file_Info.FullName;
                    break;
                }
            }

            //strPathToFileJpeg = Path.Combine(strPathToFolderBackJpegs, );
            return strPathToFileJpeg;

        }

        public static void SpecifyCurrent_XML(string xmlDesiredCacheFile)
        {
            //Added 11/29/2019 td 
            mod_fileTitleXML_Current = xmlDesiredCacheFile;
        }

        public static string PathToFile_XML_Current(bool pboolAbsolute)
        {
            //
            //Added 11/28/2192
            //
            //return PathToFile_XML(pboolAbsolute);

            bool boolNotYetDetermined = ("" == mod_fileTitleXML_Current);
            bool boolExpectedFileType = false; // mod_fileTitleXML_Current.EndsWith(".xml");
            bool boolPossiblyCorrupt = false;  //Added 216/2019 td

            if (!(boolNotYetDetermined)) //Added 2/16/2020 thomas downes
            {
                boolExpectedFileType = mod_fileTitleXML_Current.EndsWith(".xml");
                boolPossiblyCorrupt = (!(boolExpectedFileType));
                if (boolPossiblyCorrupt)
                {
                    //Added 2/16/2020 thomas downes
                    mod_boolCorruptedFilename = true;
                    mod_strCorruptedFilename = mod_fileTitleXML_Current;
                    mod_fileTitleXML_Current = "";
                }
            }

            string strPathToFileXML = "";
            string strPathToFolderXML = DiskFolders.PathToFolder_XML(pboolAbsolute);

            if (boolNotYetDetermined)
            {
                // 2-4-2020 td //foreach (FileInfo file_Info in (new DirectoryInfo(strPathToFolderXML)).GetFiles("*.xml"))
                FileInfo[] array_fileInfos = (new DirectoryInfo(strPathToFolderXML)).GetFiles("*.xml");  //Added 2/4/2020 thomas downes
                foreach (FileInfo file_Info in array_fileInfos.OrderByDescending(n => n.LastWriteTime))
                {
                    //Added 2/16/2020 thomas downes
                    boolExpectedFileType = file_Info.Name.EndsWith(".xml");
                    boolPossiblyCorrupt = (!(boolExpectedFileType));
                    if (boolPossiblyCorrupt) continue;  //Skip this file!!

                    if (boolNotYetDetermined)
                    {
                        //
                        //We are selecting the most recently-edited file. 
                        //
                        mod_fileTitleXML_Current = file_Info.Name;
                        break;
                    }
                }
            }
            strPathToFileXML = Path.Combine(strPathToFolderXML, mod_fileTitleXML_Current);
            return strPathToFileXML;
        }

        public static string PathToFile_XML_Next(bool pboolAbsolute)
        {
            //
            //Added 11/28/2192
            //
            bool boolNotYetDetermined = ("" == mod_fileTitleXML_Current);
            string strPathToFileXML = "";
            string strPathToFolderXML = DiskFolders.PathToFolder_XML(pboolAbsolute);
            bool boolMatchesCurrent = false;
            bool boolGrabThisNextFile = false;
            FileInfo obj_nextFileInfo = null;
            bool boolTrySecondAttempt = false;
            bool boolStartFromBeginningAgain = false;
            bool boolExpectedFileType = false; //Added 2/16/2019 td     mod_fileTitleXML_Current.EndsWith(".xml");
            bool boolPossiblyCorrupt = false;  //Added 2/16/2019 td

            if (boolNotYetDetermined)
            {
                mod_fileTitleXML_Current = PathToFile_XML_Current(pboolAbsolute);
                //Added 3/24/2020 Thomas Downes
                //    The Boolean var. boolNotYetDetermined is True, so we know that
                //    the web application hasn't used this XML yet.  So there is a 
                //    good case to be made that we can go ahead and return the 
                //    XML path that was just located/found. 
                //    ----3/24/2020 thomas downes  
                return mod_fileTitleXML_Current;

            }

            while (true)
            {
                foreach (FileInfo each_file_Info in (new DirectoryInfo(strPathToFolderXML)).GetFiles("*.xml"))
                {
                    //Added 2/16/2019 td
                    boolExpectedFileType = each_file_Info.Name.EndsWith(".xml");  //Added 2/16/2019 td
                    boolPossiblyCorrupt = (!(boolExpectedFileType));  //Added 2/16/2019 td
                    if (boolPossiblyCorrupt) continue;  //Added 2/16/2019 td

                    if (boolGrabThisNextFile)
                    {
                        obj_nextFileInfo = each_file_Info;
                        break;
                    }
                    boolMatchesCurrent = (each_file_Info.Name == mod_fileTitleXML_Current);
                    if (boolMatchesCurrent)
                    {
                        //mod_fileTitleXML_Current = each_file_Info.Name;
                        //break;
                        //-----Prepare for the next interation. 
                        boolGrabThisNextFile = true;
                    }
                    //If we've come full circle, grab the first XML file.
                    if (boolStartFromBeginningAgain)
                    {
                        //We've come full circle, so grab the first XML file.
                        obj_nextFileInfo = each_file_Info;
                        break;
                    }
                }
                if (obj_nextFileInfo != null) break; // = true;
                //Let's avoid infinite loops!!
                if (obj_nextFileInfo == null && boolTrySecondAttempt) break; // = true;
                if (obj_nextFileInfo == null) boolTrySecondAttempt = true;
                //Take the very first file. ---11/29/2019 td
                if (obj_nextFileInfo == null) boolStartFromBeginningAgain = true;
            }

            if (obj_nextFileInfo == null) throw new Exception("We are unable to locate any additional XML files.");
            if (obj_nextFileInfo != null) mod_fileTitleXML_Current = obj_nextFileInfo.Name;
            strPathToFileXML = Path.Combine(strPathToFolderXML, mod_fileTitleXML_Current);
            return strPathToFileXML;
        }

        public static string PathToFile_XML_NotInUse(bool pboolAbsolute)
        {
            //Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

            //return "";
            //return "~/XML/ciLayoutDesignVB.xml";

            string strPathToFile_Virtual = "/XML/ciLayoutDesignVB_new.xml";
            string strPathToFile_Absolute = HostingEnvironment.MapPath(strPathToFile_Virtual);

            if (pboolAbsolute) return strPathToFile_Absolute;
            return strPathToFile_Virtual;

        }

        public static string PathToFile_Sig(bool pboolAbsolute, bool pboolResolveURL = false)
        {
            //Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

            //return System.IO.Path.Combine("C:\\Users\\tdown\\source",
            //    "repos\\ciLayout\\ciLayoutDesignVB\\bin\\Debug",
            //    "Images\\Signatures\\Declaration_bmp.bmp");

            // 11/26/2019 td//return "~/Images/Signatures/Declaration_bmp.bmp";

            string strPathToFile_Virtual = "~/Images/Signatures/Declaration_bmp.bmp";
            string strPathToFile_Absolute = HostingEnvironment.MapPath(strPathToFile_Virtual);

            if (pboolAbsolute) return strPathToFile_Absolute;

            // Added 11/2/2021 td
            // ResolveUrl() without Page
            //    https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
            //
            if (pboolResolveURL) return ResolveUrl(strPathToFile_Virtual);
            
            return strPathToFile_Virtual;

        }


        public static string PathToFile_QRCode(bool pboolAbsolute, bool pboolResolve = false)
        {
            //Return My.Application.Info.DirectoryPath & "\Images\Signatures\Declaration_bmp.bmp"

            //return System.IO.Path.Combine("C:\\Users\\tdown\\source",
            //    "repos\\ciLayout\\ciLayoutDesignVB\\bin\\Debug",
            //    "Images\\QRCodes\\ExampleQR.png");

            //return "~/Images/QRCodes/ExampleQR.png";

            string strPathToFile_Virtual = "~/Images/QRCodes/ExampleQR.png";
            string strPathToFile_Absolute = HostingEnvironment.MapPath(strPathToFile_Virtual);

            if (pboolAbsolute) return strPathToFile_Absolute;

            // Added 11/2/2021 td
            // ResolveUrl() without Page
            //    https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
            //
            if (pboolResolve) return ResolveUrl(strPathToFile_Virtual);

            return strPathToFile_Virtual;

        }


        public static string PathToFile_PortraitPic(string pstrRecipientID)
        {
            //
            //Added 2/21/2020 td
            //
            //string strPathToFolder = "C:\\Users\\tdown\\source\\repos\\ciBadgeForWeb\\ciBadgeForWeb\\Images\\PictureExamples";
            string strVirtualPathToFolder = "~/Images/PictureExamples";

            //string strPathToFile = System.IO.Path.Combine(strPathToFolder, pstrRecipientID + ".jpg");
            string strVirtualPathToFile = (strVirtualPathToFolder + "/" + (pstrRecipientID + ".jpg"));

            try
            {
                //
                //https://forums.asp.net/t/1839913.aspx?Convert+Relative+Path+to+Absolute+Path
                //
                //string AbsolutePath = Server.MapPath(RelativePath);
                string strAbsolutePathToFile = HostingEnvironment.MapPath(strVirtualPathToFile);
                return (strAbsolutePathToFile);
            }
            catch (Exception ex_GetImageByID) // As Exception
            {
                //''aDDED 11 / 21 / 2019 TD
                string strErrMessage = ex_GetImageByID.Message;
                return null;
            }
        }


        public static string PathToFile_JSON_Current(bool pboolAbsolute, string pstrFileSuffix = "")
        {
            //-----public static string PathToFile_JSON_Current()
            //
            //Added 3/20/2020 Thomas Downes  
            //
            //   Here we will reference a module-level static data structure (a Dictionary) to map
            //   the Left, Top, Width & Height properties of the generated image element, 
            //   to the corresponding JSON file.   ---3/24/2020 td
            //
            //return PathToFile_JSON(pboolAbsolute);

            //bool boolNotYetDetermined = ("" == mod_fileTitleJSON_Current);

            //Added 3/24/2020 td
            if (null == mod_dictionary_fileTitleJSON)
            {
                //Added 3/24/2020 td
                mod_dictionary_fileTitleJSON = new Dictionary<string, string>(); 
            }
            //Added 3/24/2020 td
            //
            //   Here we will reference a module-level static data structure (a Dictionary) to map
            //   the Left, Top, Width & Height properties of the generated image element, 
            //   to the corresponding JSON file.   ---3/24/2020 td
            //
            bool boolFileTitleFoundStored = (mod_dictionary_fileTitleJSON.ContainsKey(pstrFileSuffix));
            bool booNotYetDetermined = (false == boolFileTitleFoundStored);

            bool boolExpectedFileType = false; // mod_fileTitleJSON_Current.EndsWith(".JSON");
            bool boolPossiblyCorrupt = false;  //Added 216/2019 td
            string fileTitleJSON_Current = "-----1957------"; //Added 3/24 td  

            //if (!(boolNotYetDetermined)) //Added 2/16/2020 thomas downes
            if (boolFileTitleFoundStored)
            {
                //
                //   Here we will reference a module-level static data structure (a Dictionary) to map
                //   the Left, Top, Width & Height properties of the generated image element, 
                //   to the corresponding JSON file.   ---3/24/2020 td
                //
                fileTitleJSON_Current = mod_dictionary_fileTitleJSON[pstrFileSuffix];

                boolExpectedFileType = (fileTitleJSON_Current.EndsWith(".json") ||
                                        fileTitleJSON_Current.EndsWith(".JSON"));

                boolPossiblyCorrupt = (!(boolExpectedFileType));
                if (boolPossiblyCorrupt)
                {
                    //Added 2/16/2020 thomas downes
                    mod_boolCorruptedFilename = true;
                    //mod_strCorruptedFilename = mod_fileTitleJSON_Current;
                    mod_strCorruptedFilename = fileTitleJSON_Current;
                    //mod_fileTitleJSON_Current = "";
                    mod_dictionary_fileTitleJSON.Remove(pstrFileSuffix);
                }
            }

            string strPathToFileJSON = "";
            string strPathToFolderJSON = DiskFolders.PathToFolder_JSON(pboolAbsolute);
            var json_directory = new DirectoryInfo(strPathToFolderJSON); // Added 3/24/2020 td

            if (booNotYetDetermined)
            {
                //string strSearchPatter = "*.JSON" 
                //
                // Include a file-suffix, if requested via parameter. ---3-24-2020 thomas downes
                //
                string strSearchPattern = ("*" + pstrFileSuffix + ".json");  //Added 3-24-2020 thomas d.

                // 2-4-2020 td //foreach (FileInfo file_Info in (new DirectoryInfo(strPathToFolderJSON)).GetFiles("*.JSON"))
                // 3-24-2020 TD //FileInfo[] array_fileInfos = (new DirectoryInfo(strPathToFolderJSON)).GetFiles("*.JSON");  //Added 2/4/2020 thomas downes
                FileInfo[] array_fileInfos = json_directory.GetFiles(strSearchPattern);  //Added 2/4/2020 thomas downes

                foreach (FileInfo file_Info in array_fileInfos.OrderByDescending(n => n.LastWriteTime))
                {
                    //Added 2/16/2020 thomas downes
                    boolExpectedFileType = file_Info.Name.EndsWith(".json");
                    boolPossiblyCorrupt = (!(boolExpectedFileType));
                    if (boolPossiblyCorrupt) continue;  //Skip this file!!

                    if (booNotYetDetermined)
                    {
                        //
                        //We are selecting the most recently-edited file. 
                        //
                        //---mod_fileTitleJSON_Current = file_Info.Name;  // Don't include the full path. 
                        fileTitleJSON_Current = file_Info.Name;  // Don't include the full path.
                        // Don't include the full path.
                        mod_dictionary_fileTitleJSON.Add(pstrFileSuffix, file_Info.Name);
                        break;
                    }
                }
            }

            //3-24 td //strPathToFileJSON = Path.Combine(strPathToFolderJSON, mod_fileTitleJSON_Current);
            bool bHasSlashAlready = (fileTitleJSON_Current.Contains("/") ||
                                     fileTitleJSON_Current.Contains("\\"));
            if (bHasSlashAlready)
            {
                return strPathToFileJSON;
            }
            else
            {
                strPathToFileJSON = Path.Combine(strPathToFolderJSON, fileTitleJSON_Current);
                return strPathToFileJSON;
            }
        }

        public static string PathToFile_JSON_Next(bool pboolAbsolute, string pstrFileSuffix = "")
        {
            //
            //Added 11/28/2192
            //
            // 3-24-2020 td//bool boolNotYetDetermined = ("" == mod_fileTitleJSON_Current);
            bool bFoundInDictionary = mod_dictionary_fileTitleJSON.ContainsKey(pstrFileSuffix);
            bool boolNotYetDetermined = (false == bFoundInDictionary);  // Added 3/24/2020 td
            string strPathToFileJSON = "";
            string strPathToFolderJSON = DiskFolders.PathToFolder_JSON(pboolAbsolute);
            bool boolMatchesCurrent = false;
            bool boolGrabThisNextFile = false;
            FileInfo obj_nextFileInfo = null;
            bool boolTrySecondAttempt = false;
            bool boolStartFromBeginningAgain = false;
            bool boolExpectedFileType = false; //Added 2/16/2019 td     mod_fileTitleJSON_Current.EndsWith(".JSON");
            bool boolPossiblyCorrupt = false;  //Added 2/16/2019 td
            string fileTitleJSON_Current = "";  //Added 3/24/2020 td  
            string fileTitleJSON_Next = "";  //Added 3/24/2020 td  

            //Added 3/24/2020 td
            fileTitleJSON_Current = PathToFile_JSON_Current(pboolAbsolute);
            var json_directory = new DirectoryInfo(strPathToFolderJSON); // Added 3/24/2020 td

            //Added 3/24/2020 td
            //   If the file title didn't already exist in the Dictionary (prior to 
            //   this ..._Next function being called), then the _Next file can simply 
            //   be the newly-found "Current" file.
            //(In other words, var. boolNotYetDetermined being True implies that the ..._Current 
            //   function hasn't been called before, so we can return the file title
            //   that the ..._Current function would have returned.)
            //-----3/24/2020 td 
            //
            if (boolNotYetDetermined) return fileTitleJSON_Current; 
            
            string strSearchPattern = ("*" + pstrFileSuffix + ".json");  //Added 3-24-2020 thomas d.

            while (true)
            {
                // 3-24 td//foreach (FileInfo each_file_Info in (new DirectoryInfo(strPathToFolderJSON)).GetFiles("*.JSON"))
                foreach (FileInfo each_file_Info in json_directory.GetFiles(strSearchPattern))
                {
                    //Added 2/16/2019 td
                    boolExpectedFileType = each_file_Info.Name.EndsWith(".json") ||
                                           each_file_Info.Name.EndsWith(".JSON");  //Added 2/16/2019 td

                    boolPossiblyCorrupt = (!(boolExpectedFileType));  //Added 2/16/2019 td
                    if (boolPossiblyCorrupt) continue;  //Added 2/16/2019 td

                    if (boolGrabThisNextFile)
                    {
                        obj_nextFileInfo = each_file_Info;
                        break;
                    }

                    //boolMatchesCurrent = (each_file_Info.Name == mod_fileTitleJSON_Current);
                    boolMatchesCurrent = (each_file_Info.Name == fileTitleJSON_Current);
                    if (boolMatchesCurrent)
                    {
                        //mod_fileTitleJSON_Current = each_file_Info.Name;
                        //break;
                        //-----Prepare for the next interation. 
                        boolGrabThisNextFile = true;
                    }
                    //If we've come full circle, grab the first JSON file.
                    if (boolStartFromBeginningAgain)
                    {
                        //We've come full circle, so grab the first JSON file.
                        obj_nextFileInfo = each_file_Info;
                        break;
                    }
                }
                if (obj_nextFileInfo != null) break; // = true;
                //Let's avoid infinite loops!!
                if (obj_nextFileInfo == null && boolTrySecondAttempt) break; // = true;
                if (obj_nextFileInfo == null) boolTrySecondAttempt = true;
                //Take the very first file. ---11/29/2019 td
                if (obj_nextFileInfo == null) boolStartFromBeginningAgain = true;
            }

            if (obj_nextFileInfo == null) throw new Exception("We are unable to locate any additional JSON files.");
            //
            // Use the new ("_Next") file we've found. 
            //
            if (obj_nextFileInfo != null)
            {
                fileTitleJSON_Next = obj_nextFileInfo.Name;
                //Save this file title, probably replacing the one that's there already.
                //      ---3/24/2020 thomas downes
                mod_dictionary_fileTitleJSON[pstrFileSuffix] = fileTitleJSON_Next;
                //Output the full path to the file. 
                strPathToFileJSON = Path.Combine(strPathToFolderJSON, fileTitleJSON_Next);
                return strPathToFileJSON;
            }
            else
            {
                //Added 3/24/2020 thomas downes
                return "----no file. JSON_Next-----";
            }
        }


        public static string PathToFile_TempBadges(bool pboolAbsolute, string pstrRecipientID, bool pboolResolve = false)
        {
            //---public static string PathToFile_TempBadges(bool pboolAbsolute, string pstrRecipientID)
            //
            //Added 9/17/2021 td
            //
            //string strPathToFolder = "C:\\Users\\tdown\\source\\repos\\ciBadgeForWeb\\ciBadgeForWeb\\Images\\PictureExamples";
            string strPathToFolder_Virtual = "~/Images/TempBadges";

            //string strPathToFile = System.IO.Path.Combine(strPathToFolder, pstrRecipientID + ".jpg");
            string strPathToFile_Virtual = (strPathToFolder_Virtual + "/" + (pstrRecipientID + ".jpg"));

            //string strPathToFile_Virtual = "~/Images/QRCodes/ExampleQR.png";
            //
            //https://forums.asp.net/t/1839913.aspx?Convert+Relative+Path+to+Absolute+Path
            //
            string strPathToFile_Absolute = HostingEnvironment.MapPath(strPathToFile_Virtual);

            if (pboolAbsolute) return strPathToFile_Absolute;

            // Added 11/2/2021 td
            // ResolveUrl() without Page
            //    https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
            //
            if (pboolResolve) return ResolveUrl(strPathToFile_Virtual);

            return strPathToFile_Virtual;

        }


        // <summary>
        // ResolveUrl() without Page
        //    https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
        // Returns a site relative HTTP path from a partial path starting out with a ~.
        // Same syntax that ASP.Net internally supports but this method can be used
        // outside of the Page framework.
        // 
        // Works like Control.ResolveUrl including support for ~syntax
        // but returns an absolute URL.
        // </summary>
        // <param name = "par_originalUrl" > Any Url including those starting with ~</param>
        // <returns>relative url</returns>
        // https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
        public static string ResolveUrl(string par_originalUrl)
        {
            //  ResolveUrl() without Page
            //  https://weblog.west-wind.com/posts/2007/Sep/18/ResolveUrl-without-Page
            //
            if (par_originalUrl == null)
                return null;

            // *** Absolute path - just return
            if (par_originalUrl.IndexOf("://") != -1)
                return par_originalUrl;

            // *** Fix up image path for ~ root app dir directory
            if (par_originalUrl.StartsWith("~"))
            {
                string newUrl = "";
                if (HttpContext.Current != null)
                    newUrl = HttpContext.Current.Request.ApplicationPath +
                          par_originalUrl.Substring(1).Replace("//", "/");
                else
                    // *** Not context: assume current directory is the base directory
                    throw new ArgumentException("Invalid URL: Relative URL not allowed.");

                // *** Just to be sure fix up any double slashes
                return newUrl;
            }

            return par_originalUrl;
        }




    }
}