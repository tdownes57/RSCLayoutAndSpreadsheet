using System;
using System.Collections.Generic;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
//using ciBadgeFields;    //Added 05/11/2022 td
using ciBadgeElements;  //Added 10/5/2019 td
using ciBadgeInterfaces; //Added 10/5/2019 td
//using ciBadgeElemImage; //Added 10/14/2019 td  
//using ciBadgeRecipients;  //Added 10/16/2019 td 
//using ciBadgeCachingPersonality;  //Added 12/4/2021 td 
using ciBadgeCachePersonality; //Added 12/4/2021 td
//using System.Linq;


namespace ciBadgeGenerator
{
    //
    //Refactored 5/21/2022 thomas downes
    //
    public class ClassMakeBadge2022
    {
        //
        //Refactored 5/21/2022 thomas downes
        //
        public string PathToFile_Sig = ""; //Added 10/12/2019 td
        public string PathToFile_QR = ""; //Added 11/26/2019 td
        public Image ImageQRCode;   //Added 10/14/2019 td 
        public Image ImageQRCode_Example;   //Added 1/17/2022 td 
        public string Messages = ""; //Added 11/18/2019 td 
        public static bool IncludeQR = true;  // Dec.7 2021 td //false; //Added 2/3/2020 thomas d. 
        public static bool IncludeSignature = true; //Dec.11 2021 //false;  //Added 2/3/2020 thomas d.
        public static bool OmitOutlyingElements = false;  // true; // Added 11/10/2021 td


        public Image MakeBadgeImage_AnySide(IBadgeLayoutDimensions par_layoutDims,
                            IBadgeSideLayoutElementsV1 par_layoutElements,
                            ClassElementsCache_Deprecated par_cache,
                            int par_newBadge_width_pixels,
                            int par_newBadge_height_pixels,
                            IRecipient par_iRecipientInfo = null,
                            List<string> par_listMessages = null,
                            List<string> par_listFieldsIncluded = null,
                            List<string> par_listFieldsNotIncluded = null,
                            ClassElementFieldV3 par_recentlyMovedV3 = null,
                            ClassElementFieldV4 par_recentlyMovedV4 = null)
        {
            //
            // Added 12/18/2021 td
            //
            bool bMissingElementPortrait = false; //Added 1/14/2022 td

            //Added 5/21/2022 thomas 
            ClassMakeAssistant objAssistant = new ClassMakeAssistant(); //Added 5/21/2022
            objAssistant.ImageQRCode = this.ImageQRCode;
            objAssistant.ImageQRCode_Example = this.ImageQRCode_Example;
            objAssistant.PathToFile_QR = this.PathToFile_QR;
            objAssistant.PathToFile_Sig = this.PathToFile_Sig;
            objAssistant.Messages = this.Messages;
            this.Messages = ""; //We will integrate concatenate this.Messages & objAssistant.Messages later, at the end of this procedure. 

            if (par_layoutElements.BackgroundImage != null)  //Added May 20, 2022
            {
                par_layoutElements.BackgroundImage =
                    ClassProportions.Proportions_FixLayout(par_layoutElements.BackgroundImage);

                ClassProportions.ProportionsAreSlightlyOff(par_layoutElements.BackgroundImage, true, "Background Image");
            }

            // 1-15-2020 td //LayoutElements objPrintLibElems = new LayoutElements();
            // 12-14-2021 td //LayoutElements objPrintLibElems = new LayoutElements(ClassElementField.iRecipientInfo);
            LayoutElements objPrintLibElems = null;
            if (par_iRecipientInfo != null) objPrintLibElems = new LayoutElements(par_iRecipientInfo);
            else objPrintLibElems = new LayoutElements(ClassElementFieldV3.iRecipientInfo);

            //    obj_image = Me.BackgroundBox.Image
            //    obj_image_clone = CType(obj_image.Clone(), Image)
            //
            //10-09-2019 td//Image obj_image_clone_resized = (Image)par_backgroundImage.Clone();

            const bool c_bLetsSkipBackground = false;  // true;  // Added 1-16-2020 thomas downes
            Image obj_imageOutput;  // Added 1-16-2020 thomas downes
            bool bSkipBackground = (c_bLetsSkipBackground ||
                                   (par_layoutElements.BackgroundImage == null));

            // May20 200 //if (c_bSkipBackground)
            if (bSkipBackground)
            {
                //Added 1-16-2020 thomas downes
                obj_imageOutput = new Bitmap(par_newBadge_width_pixels,
                                             par_newBadge_height_pixels);
                //Added 1-16-2020 thomas downes
                Graphics g = Graphics.FromImage(obj_imageOutput);
                g.Clear(Color.White);

            } //End of ""if (bSkipBackground){....}

            else
            {
                //Dec18 2021 td//obj_imageOutput = (Image)par_backgroundImage.Clone();
                obj_imageOutput = (Image)par_layoutElements.BackgroundImage.Clone();

                //
                //    obj_image_clone_resized =
                //        LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

                Image obj_image_resized = objAssistant.ResizeImage_WidthAndHeight(obj_imageOutput,
                    par_newBadge_width_pixels, par_newBadge_height_pixels);

                obj_imageOutput = obj_image_resized;

            } //End of ""if (bSkipBackground){....} else {.....}

            //
            // Field-Related Elements
            //
            HashSet<ClassElementFieldV3> listOfElementFieldsV3; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019
            HashSet<ClassElementFieldV4> listOfElementFieldsV4; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019

            //Dec18 2021//if (par_listElementFields != null) listOfElementFields = par_listElementFields;
            listOfElementFieldsV3 = par_layoutElements.ListElementFieldsV3;
            listOfElementFieldsV4 = par_layoutElements.ListElementFieldsV4;

            //Dec18 2021//else listOfElementFields = par_cache.ListOfBadgeDisplayElements_Flds_Front(false);

            const bool c_boolUseLocalProc = true;  // 11-9-2021 false;  // true;  // false;  //Added 10/5/2019 td
            if (c_boolUseLocalProc)
            {
                //
                // I think this procedure (LoadImageWithElement) is fully converted to C# yet. 
                //   If I recall, it's rather long and I was experiencing fatigue from the 
                //   late hour. ---10/9/2019 td
                //
                DateTime dateMostRecentUpdate = DateTime.MinValue;  // Default value.

                //
                // I think this procedure is ready for testing. ---11/9/2021  
                //
                objAssistant.LoadImageWithElementFields(ref obj_imageOutput,
                        ref dateMostRecentUpdate,
                        par_cache,
                        listOfElementFieldsV3,
                        listOfElementFieldsV4,
                          par_iRecipientInfo, null,
                          par_listMessages,
                         par_listFieldsIncluded,
                         par_listFieldsNotIncluded,
                             par_recentlyMovedV3);

                //Added 11/29/2021 td  
                string strLastUpdate = dateMostRecentUpdate.ToString();

            }  //End of ""if (c_boolUseLocalProc) {....} 

            else
            {
                //
                // Call a method from the namespace LayoutElements. 
                //
                //objPrintLibElems.LoadImageWithElements(ref obj_imageOutput, listOfElementFields);

                //objPrintLibElems.LoadImageWithElements(ref obj_imageOutput,
                //         listOfElementFieldsV3,
                //         listOfElementFieldsV4,
                //         null, false, true,
                //         par_listFieldsIncluded,
                //         par_listFieldsNotIncluded);

                HashSet<Image> hashset_null = null;  //Added 5/29/2022

                //Modified 5/29/2022
                objPrintLibElems.LoadImageWithElements(ref obj_imageOutput,
                                         listOfElementFieldsV3,
                                         listOfElementFieldsV4,
                                         ref hashset_null, false, true,
                                         ref par_listFieldsIncluded,
                                         ref par_listFieldsNotIncluded);

            } //End of ""if (c_boolUseLocalProc) {....} else {....}""

            //''
            //''Major call, let's show the portrait !!  ---9/9/2019 td  
            //''
            //objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
            //                    par_badge_width_pixels,
            //                    obj_image_clone_resized,
            //                    CtlGraphicPortrait_Lady.ElementInfo_Base,
            //                    CtlGraphicPortrait_Lady.ElementInfo_Pic,
            //                    CtlGraphicPortrait_Lady.picturePortrait.Image);

            const bool c_bIgnorePicDataInCache = false; //Added 10/9/2019 thomas d. 

            if (c_bIgnorePicDataInCache)
            {
                //ClassElementPic objElementPic = new ClassElementPic();
                //
                //// Added 10/8/2019 td  
                //objElementPic.Width_Pixels = par_recipientPic.Width;
                //objElementPic.Height_Pixels = par_recipientPic.Height;
                //
                //IElement_Base local_PicElementInfo_Base = (IElement_Base)objElementPic;
                //IElementPic local_PicElementInfo_Pic = (IElementPic)objElementPic;
                ////Image recipient_pic_Image = par_recipient.GetPic();
                //
                //objPrintLibElems.LoadImageWithPortrait(obj_image.Width,
                //                         par_badge_width_pixels,
                //                         ref obj_image,
                //                         local_PicElementInfo_Base,
                //                         local_PicElementInfo_Pic,
                //                         ref par_recipientPic);

            } //End of ""if (c_bIgnorePicDataInCache) {.....}

            else
            {
                //
                //Added 10/9/2019 thomas d. 
                //
                //#1 10/17/2019 td''ClassElementPic obj_elementPic = par_cache.ListPicElements()[0];
                // #2 10/17/2019 td''ClassElementPic obj_elementPic = par_cache.ListOfElementPics.GetEnumerator().Current;

                // Nov. 29 2021 //ClassElementPic obj_elementPic = par_cache.ListOfElementPics.FirstOrDefault();
                // May 21, 2022 //ClassElementPortrait obj_elementPic = null;
                HashSet<ClassElementPortrait> obj_elementPicList = null;

                // May 15, 2022 //if (par_layoutElements.ElementPortrait_1st == null)
                if (0 == par_layoutElements.ListElementPortraits.Count)
                {
                    bMissingElementPortrait = true; //Added 1/14/2022 td
                    if (bMissingElementPortrait) { }  //Added 1/14/2022 td

                } // End of ""if (0 == par_layoutElements.ListElementPortraits.Count)""

                else
                {
                    //''5/15/2022 td''obj_elementPic = par_layoutElements.ElementPortrait_1st;
                    obj_elementPicList = par_layoutElements.ListElementPortraits;

                } // End of ""if (0 == par_layoutElements.ListElementPortraits.Count){....} else {....}"

                // Dec18 2021 td// else obj_elementPic = par_cache.ListOfElementPics_Front.FirstOrDefault();

                // 10/12/2019 td//objPrintLibElems.LoadImageWithPortrait(par_newBadge_width_pixels,

                //Image img_Step3Picture = obj_elementPic.GetStep3_Picture();
                //if (img_Step3Picture == null) img_Step3Picture = par_recipientPic;
                Image img_Step3Picture = null;  // 5/20/2022 par_layoutElements.RecipientPic;

                //
                //    
                //  
                //May 21 2022 //if (obj_elementPic == null) //Added 1/14/2022 td
                //May 21 2022 //{
                //
                // The badge, or this side of the badge, has not any Portrait (by design!).  ---1/14/2022
                //
                // Let's check the list of portraits. ---5/16/2022 td
                //
                foreach (ClassElementPortrait each_elementPic
                              in par_layoutElements.ListElementPortraits)
                {
                    //Check to see if our Image reference is null.  ---5/16/2022
                    //if (img_Step3Picture == null)
                    //{
                    //    System.Diagnostics.Debugger.Break();
                    //}

                    //Added 5/21/2022 td  
                    if (par_iRecipientInfo == null)
                    {
                        img_Step3Picture = par_layoutElements.RecipientPic;
                    }  //end of ""if (par_iRecipientInfo == null)""
                    else
                    {
                        //Added 5/20/2022 td
                        img_Step3Picture = par_iRecipientInfo.GetPortraitImage();
                    } //End of ""if (par_iRecipientInfo == null) {...} else {....}""

                    // Major call. ---5/16/2022 td
                    objAssistant.LoadImageWithPortrait_OrGraphic(img_Step3Picture,
                                par_newBadge_width_pixels,
                                par_layoutDims.Width_Pixels,
                                ref obj_imageOutput,
                                (IElement_Base)each_elementPic,
                                (IElementPic)each_elementPic);

                }  //End of ""foreach (ClassElementPortrait each_elementPic ...) {...}""

            }  //End of ""if (c_bIgnorePicDataInCache) {.....} ... else {...}


            //May 21 2022 //}
            //else   //if (img_Step3Picture != null)
            //{
            //    //
            //    //There is a Portrait element which we will need to populate 
            //    //
            //    //Added 5/20/2022 td
            //    if (par_iRecipientInfo == null)
            //    {
            //        img_Step3Picture = par_layoutElements.RecipientPic;
            //    }
            //    else
            //    {
            //        //Added 5/20/2022 td
            //        img_Step3Picture = par_iRecipientInfo.GetPortraitImage();
            //    }

            //    //
            //    // Place the Portrait onto the image. ----Jan14 2022
            //    //
            //    if (img_Step3Picture != null)
            //    {
            //        LoadImageWithPortrait_OrGraphic(img_Step3Picture,
            //                        par_newBadge_width_pixels,
            //                        par_layoutDims.Width_Pixels,
            //                        ref obj_imageOutput,
            //                        (IElement_Base)obj_elementPic,
            //                        (IElementPic)obj_elementPic);
            //    }

            //
            //    End of "if (img_Step3Picture != null)"
            //
            //}

            //10-18 td  ref par_recipientPic);

            //
            //Added 10/9/2019 thomas d. 
            //
            //--Nov. 29 2021--//if (par_cache.MissingTheSignature())
            //--Dec18 2021 //if (par_cache.MissingTheSignature() && (par_elementSig == null))
            //--May 15, 2022 //if (par_layoutElements.ElementSignature_1st == null)
            
            if (0 == par_layoutElements.ListElementSignatures.Count)
            {
                //
                //There is not any Signature to display.
                //
            }
            else //May 21, 2022 //else if (ClassMakeBadgePreJune2022.IncludeSignature)
            {
                //
                //Add the Signature. 
                //
                //05-15-2022 TD //ClassElementSignature obj_elementSig = par_layoutElements.ElementSignature_1st;

                //Added 11/29/2021 td
                //05-15-2022 TD //if (par_layoutElements.ElementSignature_1st != null) 
                //05-15-2022 TD //    obj_elementSig = par_layoutElements.ElementSignature_1st;

                string strPathToSigFile = this.PathToFile_Sig; //Added 10/12/2019 td

                foreach (ClassElementSignature each_elementSig
                          in par_layoutElements.ListElementSignatures)
                {
                    //
                    // Major call!!
                    //
                    objAssistant.LoadImageWithSignature(par_newBadge_width_pixels,
                                        par_layoutDims.Width_Pixels,
                                        ref obj_imageOutput,
                                        (IElement_Base)each_elementSig,
                                        (IElementSig)each_elementSig,
                                        strPathToSigFile);
                }

            } // Endof ""if (0 == par_layoutElements.ListElementSignatures.Count) {....} else {....}""

            // 10-12-2019 td //ref par_recipientPic);

            //
            //Added 10/14/2019 thomas d. 
            //Encapsulated 12/11/2021 thomas 
            //
            //Dec.11 2021 ''LoadImageWithQRCode_IfNeeded(par_cache, par_elementQR, 
            //                             par_layout.Width_Pixels, par_layout, 
            //                             ref obj_imageOutput);
            //Dec.18 2021 ''LoadImageWithQRCode_IfNeeded(par_cache, par_elementQR,
            //                             par_newBadge_width_pixels, par_layoutDims,
            //                             ref obj_imageOutput);
            //Dec.26 2021 ''LoadImageWithQRCode_IfNeeded(null, 
            //                           par_layoutElements.ElementQR,
            //                             par_newBadge_width_pixels, par_layoutDims,
            //                             ref obj_imageOutput);

            foreach (ClassElementQRCode each_elementQR
                      in par_layoutElements.ListElementQRCodes)
            {
                //
                // Major call!!
                //
                objAssistant.LoadImageWithQRCode_IfNeeded(par_layoutElements,
                               //par_layoutElements.ElementQRCode_1st,
                               each_elementQR,
                               par_newBadge_width_pixels, par_layoutDims,
                               ref obj_imageOutput);
            }

            //
            //Static-Text Elements, Version 3 
            //
            HashSet<ClassElementStaticTextV3> listOfElementStaticTextsV3;
            //Dec18 2021 //listOfElementStaticTexts = par_cache.ListOfElementTexts_Front;
            listOfElementStaticTextsV3 = par_layoutElements.ListElementStaticTextsV3;

            //
            //Static-Text Elements, Version 4 
            //
            HashSet<ClassElementStaticTextV4> listOfElementStaticTextsV4;
            listOfElementStaticTextsV4 = par_layoutElements.ListElementStaticTextsV4;

            //----Added 11/29/2021 td
            //if (par_elemStaticText != null)
            //{
            //    listOfElementStaticTexts = new HashSet<ClassElementStaticText>();
            //    listOfElementStaticTexts.Add(par_elemStaticText);
            //}

            //
            // Load image with static texts.  
            //
            // Added 1/31/2022 td //LoadImageWithStaticTexts(ref obj_imageOutput, listOfElementStaticTexts);
            objAssistant.LoadImageWithStaticTexts(ref obj_imageOutput,
                                     listOfElementStaticTextsV3,
                                     listOfElementStaticTextsV4);

            //Added 1/22/2022 thomas d.
            //LoadImageWithPortrait(img_Step3Picture,
            //                par_newBadge_width_pixels,
            //                par_layoutDims.Width_Pixels,
            //                ref obj_imageOutput,
            //                (IElement_Base)obj_elementPic,
            //                (IElementPic)obj_elementPic);

            WhyOmitted_StructV1 structWhyOmittedV1 = new WhyOmitted_StructV1();  // Added 1/23/2022 td
            WhyOmitted_StructV2 structWhyOmittedV2 = new WhyOmitted_StructV2();  // Added 1/23/2022 td

            objAssistant.LoadImageWithStaticGraphics(ref obj_imageOutput,
                            par_layoutElements.ListElementGraphics,
                            par_newBadge_width_pixels,
                            par_layoutDims.Width_Pixels,
                            ref structWhyOmittedV1,
                            ref structWhyOmittedV2);

            //
            // ExitHandler 
            //
            this.Messages += (Environment.NewLine + Environment.NewLine +
                objAssistant.Messages);

            // 10-9-2019 td // return null;
            return obj_imageOutput;

        }  //End of ""public Image MakeBadgeImage_AnySide {....}""

    } //End of ""public class ClassMakeBadge2022""  

} //End of ""namespace ciBadgeGenerator""
