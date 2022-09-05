using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
using ciBadgeFields;    //Added 05/11/2022 td
using ciBadgeElements;  //Added 10/5/2019 td
using ciBadgeInterfaces; //Added 10/5/2019 td
using ciBadgeElemImage; //Added 10/14/2019 td  
using ciBadgeRecipients;  //Added 10/16/2019 td 
//using ciBadgeCachingPersonality;  //Added 12/4/2021 td 
using ciBadgeCachePersonality; //Added 12/4/2021 td
using System.Linq;

namespace ciBadgeGenerator
{

    //Public Sub RefreshPreview()
    //    ''
    //    ''Added 8/24/2019 td
    //    ''
    //    Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements
    //    Dim listOfTextImages As New List(Of Image) ''Added 8/26/2019 thomas downes
    //    Dim listOfElementTextFields As List(Of ClassElementField)
    //
    //    listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()
    //
    //    Dim obj_image As Image ''Added 8/24 td
    //    Dim obj_image_clone As Image ''Added 8/24 td
    //    Dim obj_image_clone_resized As Image ''Added 8/24/2019 td
    //
    //    ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")
    //
    //    obj_image = Me.BackgroundBox.Image
    //    obj_image_clone = CType(obj_image.Clone(), Image)
    //
    //    obj_image_clone_resized =
    //        LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)
    //
    //    ClassLabelToImage.ProportionsAreSlightlyOff(obj_image_clone_resized, True, "Clone Resized #1")
    //
    //    ''
    //    ''Major call !!
    //    ''
    //    objPrintLibElems.LoadImageWithElements(obj_image_clone_resized,
    //                                         listOfElementTextFields,
    //                                         listOfTextImages)
    //
    //    ''
    //    ''Major call, let's show the portrait !!  ---9/9/2019 td  
    //    ''
    //    objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
    //                                      Me.Layout_Width_Pixels(),
    //                                      obj_image_clone_resized,
    //                                       CtlGraphicPortrait_Lady.ElementInfo_Base,
    //                                       CtlGraphicPortrait_Lady.ElementInfo_Pic,
    //                                      CtlGraphicPortrait_Lady.picturePortrait.Image)
    //
    //    ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Clone Resized #1")
    //
    //    Me.PreviewBox.Image = obj_image_clone_resized
    //
    //End Sub ''end of "Private Sub RefreshPreview()"

    public class ClassMakeAssistant
    {
        //
        //Renamed from "ClassMakeBadge" on 5/21/2022 td. 
        //
        public string PathToFile_Sig = ""; //Added 10/12/2019 td
        public string PathToFile_QR = ""; //Added 11/26/2019 td
        public Image ImageQRCode;   //Added 10/14/2019 td 
        public Image ImageQRCode_Example;   //Added 1/17/2022 td 
        public string Messages = ""; //Added 11/18/2019 td 
        public static bool IncludeQR = true;  // Dec.7 2021 td //false; //Added 2/3/2020 thomas d. 
        public static bool IncludeSignature = true; //Dec.11 2021 //false;  //Added 2/3/2020 thomas d.

        public static bool OmitOutlyingElements = false;  // true; // Added 11/10/2021 td

        private const bool mod_cbOkayToUseExampleQRCode = false; //Added 1/17/2022 td
        private const bool c_bDontPreviewConditionalElems = false;  //Added 5/29/2022

        private string _vbCrLf
        {
            //Added 6/2/2022 td
            get
            {
                //return char.ConvertFromUtf32(32) +
                //       char.ConvertFromUtf32(12);
                return Environment.NewLine; 
            }
        }

        public Image ElementFieldToImage(ClassElementFieldV3 par_elementField,
                                            IBadgeLayoutDimensions par_layoutDimensions,
                                            ref string par_bugmessage,
                                            ref string par_textDisplayed)
        {
            //
            //Encapsulated 5/3/2020 td
            //
            string strTextToDisplay = par_elementField.LabelText_ToDisplay(false);
            par_textDisplayed = strTextToDisplay; // Added 11/18/2021 thomas downes

            Image image_textStandard = null;

            if (0 == par_elementField.Width_Pixels)
            {
                // ''Added 9/4/2019 thomas downes
                //MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
                //     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"
            }

            //
            //Try
            //
            try
            {
                //     ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                //     ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                //     ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)
                //
                //     ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                //     '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
                //
                //     ''9/5/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_imageBadgeCard.Width)
                //     ''9/8/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_elementField.BadgeLayout_Width)
                //
                //     Dim intDesiredLayout_Width As Integer ''added 9/8/2019 td
                //     intDesiredLayout_Width = par_imageBadgeCard.Width

                //----5/3/2020 td----int intDesiredLayout_Width = par_imageBadgeCard.Width;
                int intDesiredLayout_Width = par_layoutDimensions.Width_Pixels;

                //
                //     ''9/19/2019 td''image_textStandard =
                //     ''9/19/2019 td''    .TextDisplay.GenerateImage_ByDesiredLayoutWidth(intDesiredLayout_Width)
                //
                bool boolRotated = false; //Added 10/14/2019 td  

                // 10-17-2019 image_textStandard =
                //       modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
                //         par_elementField, par_elementField, ref boolRotated, false);  //''9/20/2019 td'', True)
                image_textStandard =
                       modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementField, par_elementField, 
                         ref boolRotated, false, par_elementField);  //7-29-2022 ref boolRotated, false);  //''9/20/2019 td'', True)

            }
            //            Catch ex_draw_invalid As InvalidOperationException
            catch (InvalidOperationException ex_draw_invalid)
            {
                //string strMessage_Invalid = ex_draw_invalid.Message;
                //throw new Exception("Let's throw the message.", ex_draw_invalid);
                par_bugmessage = ex_draw_invalid.Message + " ... " + ex_draw_invalid.ToString();

            } //End of "try {...} catch (....) {....}

            return image_textStandard;

        } //End of ""public Image ElementFieldToImage(....)"" 


        public Image MakeBadgeImage_ByIRecipient_Front(IBadgeLayoutDimensions par_layoutDims,
                            Image par_backgroundImage,
                            ClassElementsCache_Deprecated par_cache,
                            int par_badge_width_pixels,
                            int par_badge_height_pixels,
                            ciBadgeInterfaces.IRecipient par_iRecipientInfo,
                            Image par_recipientPic,
                                    List<string> par_listMessages = null,
                                    List<string> par_listFieldsIncluded = null,
                                    List<string> par_listFieldsNotIncluded = null)
        {
            //---Dec18 2021 ---public Image MakeBadgeImage_ByIRecipient
            //
            //Added 11/16/2019 Thomas Downes  
            //

            // 
            //Step #1:  Load the Recipient into the Elements Cache. 
            //
            // 12/2/2019 td //ClassElementField.iRecipientInfo = par_recipient;
            ClassElementFieldV3.iRecipientInfo = par_iRecipientInfo;
            //ClassElementField.oRecipient = par_recipient; //Added 1/15/2020 td

            //
            //Step #2:  Create the image of the badge-card for the above recipient. 
            //
            // Dec18 2021 //return MakeBadgeImage(par_layout, par_backgroundImage,
            return MakeBadgeImage_Front(par_layoutDims, par_backgroundImage,
                                    par_badge_width_pixels,
                                    par_badge_height_pixels,
                                    par_recipientPic,
                                    par_cache, par_iRecipientInfo,
                                    par_cache.ListOfElementFields_FrontV3,
                                    par_cache.ListOfElementFields_FrontV4,
                                    par_cache.ListOfElementTextsV3_Front,
                                    par_cache.ListOfElementTextsV4_Front,
                                    par_cache.ListOfElementGraphics_Front,
                                    null, null, null,
                                    par_listMessages,
                                    par_listFieldsIncluded,
                                    par_listFieldsNotIncluded);

        } //ENd of ""public Image MakeBadgeImage_ByIRecipient_Front(...) { .... } 


        public Image MakeBadgeImage_ByRecipient_Front(IBadgeLayoutDimensions par_layoutDims,
                                    Image par_backgroundImage,
                                    ClassElementsCache_Deprecated par_cache,
                                    int par_badge_width_pixels,
                                    int par_badge_height_pixels,
                                    ClassRecipient par_recipient,
                                    Image par_recipientPic)
        {
            //---Dec18 2021 td---public Image MakeBadgeImage_ByRecipient_Front(IBadgeLayout par_layout 
            //
            //Step #1:  Load the Recipient into the Elements Cache. 
            //
            // 10-16-2019 td// par_cache.LoadRecipient(par_recipient);
            // 11-16-2019 td// ClassElementField.oRecipient = par_recipient;

            ClassElementFieldV3.oRecipient = par_recipient;
            ClassElementFieldV3.iRecipientInfo = par_recipient;   //Added 1/15/2020 thomas d.

            //
            //Step #2:  Create the image of the badge-card for the above recipient. 
            //
            //10-09-2019 td //return MakeBadgeImage(par_backgroundImage, par_cache, par_badge_width_pixels, par_recipientPic);

            //12-18-2021 td //return MakeBadgeImage(par_layout, ...
            return MakeBadgeImage_Front(par_layoutDims,
                                    par_backgroundImage,
                                    par_badge_width_pixels,
                                    par_badge_height_pixels,
                                    par_recipientPic,
                                    par_cache,
                                    par_recipient);

        }  // End of ""public Image MakeBadgeImage_ByRecipient_Front(...) { ... }




        public Image MakeBadgeImage_Front(IBadgeLayoutDimensions par_layoutDims,
                                    Image par_backgroundImage,
                                    int par_newBadge_width_pixels,
                                    int par_newBadge_height_pixels,
                                    Image par_recipientPic,
                                    ClassElementsCache_Deprecated par_cache,
                                    IRecipient par_iRecipientInfo = null,
                                    HashSet<ClassElementFieldV3> par_listElementFieldsV3 = null,
                                    HashSet<ClassElementFieldV4> par_listElementFieldsV4 = null,
                                    HashSet<ClassElementStaticTextV3> par_listElementTextsV3 = null,
                                    HashSet<ClassElementStaticTextV4> par_listElementTextsV4 = null,
                                    HashSet<ClassElementGraphic> par_listElementGraphics = null,
                                    ClassElementPortrait par_elementPic = null,
                                    ClassElementQRCode par_elementQR = null,
                                    ClassElementSignature par_elementSig = null,
                                    List<string> par_listMessages = null,
                                    List<string> par_listFieldsIncluded = null,
                                    List<string> par_listFieldsNotIncluded = null,
                                    ClassElementFieldV3 par_recentlyMoved = null)
        {
            //Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

            //Image obj_imageWithElementFlds; //Added 10/9/2019 td 

            //''Added 9 / 6 / 2019 td
            //    ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")

            par_backgroundImage =
                ClassProportions.Proportions_FixLayout(par_backgroundImage);

            ClassProportions.ProportionsAreSlightlyOff(par_backgroundImage, true, "Background Image");

            // 1-15-2020 td //LayoutElements objPrintLibElems = new LayoutElements();
            // 12-14-2021 td //LayoutElements objPrintLibElems = new LayoutElements(ClassElementField.iRecipientInfo);
            LayoutElements objPrintLibElems = null;
            if (par_iRecipientInfo != null) objPrintLibElems = new LayoutElements(par_iRecipientInfo);
            else objPrintLibElems = new LayoutElements(ClassElementFieldV3.iRecipientInfo);

            //    obj_image = Me.BackgroundBox.Image
            //    obj_image_clone = CType(obj_image.Clone(), Image)
            //
            //10-09-2019 td//Image obj_image_clone_resized = (Image)par_backgroundImage.Clone();

            const bool c_bSkipBackground = false;  // true;  // Added 1-16-2020 thomas downes
            Image obj_imageOutput;  // Added 1-16-2020 thomas downes

            if (c_bSkipBackground)
            {
                //Added 1-16-2020 thomas downes
                obj_imageOutput = new Bitmap(par_newBadge_width_pixels,
                                             par_newBadge_height_pixels);
                //Added 1-16-2020 thomas downes
                Graphics g = Graphics.FromImage(obj_imageOutput);
                g.Clear(Color.White);
            }
            else
            {
                obj_imageOutput = (Image)par_backgroundImage.Clone();

                //
                //    obj_image_clone_resized =
                //        LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

                Image obj_image_resized = ResizeImage_WidthAndHeight(obj_imageOutput,
                    par_newBadge_width_pixels, par_newBadge_height_pixels);

                obj_imageOutput = obj_image_resized;
            }

            //    Dim listOfElementTextFields As List(Of ClassElementField)
            //    listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()

            // 10-17-2019 td //List<ClassElementField> listOfElementTextFields;
            // Jan8 2022 //HashSet<ClassElementField> listOfElementFields; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019
            IEnumerable<ClassElementFieldV3> listOfElementFieldsV3; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019
            IEnumerable<ClassElementFieldV4> listOfElementFieldsV4; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019

            // Nov. 29 2021 //listOfElementFields = par_cache.ListFieldElements();
            // Moved below & suffixed w/ "V3". Feb. 10 2022 //if (par_listElementFields != null) listOfElementFields = par_listElementFields;

            // Dec. 7 2021  //else listOfElementFields = par_cache.ListFieldElements();
            // #1 Jan8 2022 td //else listOfElementFields = par_cache.ListOfBadgeDisplayElements_Flds_Front(false);
            // #2 Jan8 2022 td //else listOfElementFields = par_cache.ListOfElementFields_Front;
            if (par_listElementFieldsV3 != null) listOfElementFieldsV3 = par_listElementFieldsV3;
            else listOfElementFieldsV3 = par_cache.BadgeDisplayElements_Fields_FrontV3();

            //Added 2/10/2022 td
            if (par_listElementFieldsV4 != null) listOfElementFieldsV4 = par_listElementFieldsV4;
            else listOfElementFieldsV4 = par_cache.BadgeDisplayElements_Fields_FrontV4();

            const bool c_boolUseLocalProc = true;  // 11-9-2021 false;  // true;  // false;  //Added 10/5/2019 td
            if (c_boolUseLocalProc)
            {
                //
                // I think this procedure (LoadImageWithElement) is fully converted to C# yet. 
                //   If I recall, it's rather long and I was experiencing fatigue from the 
                //   late hour. ---10/9/2019 td
                //
                DateTime dateMostRecentUpdate = DateTime.MinValue;  // Default value.

                // I think this procedure is ready for testing. ---11/9/2021  
                //
                LoadImageWithElementFields(ref obj_imageOutput,
                        ref dateMostRecentUpdate,
                        par_cache,
                        listOfElementFieldsV3,
                        listOfElementFieldsV4,
                          par_iRecipientInfo, null,
                          par_listMessages,
                         par_listFieldsIncluded,
                         par_listFieldsNotIncluded,
                             par_recentlyMoved);

                //Added 11/29/2021 td  
                string strLastUpdate = dateMostRecentUpdate.ToString();

            }
            else
            {
                //
                // Call a method from the namespace LayoutElements. 
                //
                //-----objPrintLibElems.LoadImageWithElements(ref obj_imageOutput, listOfElementFields);

                //May29 2022 objPrintLibElems.LoadImageWithElements(ref obj_imageOutput,
                //         listOfElementFieldsV3,
                //         listOfElementFieldsV4,
                //         null, false, true,
                //         par_listFieldsIncluded,
                //         par_listFieldsNotIncluded);

                HashSet<Image> hashset_null = null;  //Added 5/29/2022 td

                objPrintLibElems.LoadImageWithElements(ref obj_imageOutput,
                         listOfElementFieldsV3,
                         listOfElementFieldsV4,
                         ref hashset_null, false, true,
                         ref par_listFieldsIncluded,
                         ref par_listFieldsNotIncluded);

            }

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
            }
            else
            {
                //
                //Added 10/9/2019 thomas d. 
                //
                //#1 10/17/2019 td''ClassElementPic obj_elementPic = par_cache.ListPicElements()[0];
                // #2 10/17/2019 td''ClassElementPic obj_elementPic = par_cache.ListOfElementPics.GetEnumerator().Current;

                // Nov. 29 2021 //ClassElementPic obj_elementPic = par_cache.ListOfElementPics.FirstOrDefault();
                ClassElementPortrait obj_elementPic;
                if (par_elementPic != null) obj_elementPic = par_elementPic;
                else obj_elementPic = par_cache.ListOfElementPics_Front.FirstOrDefault();

                // 10/12/2019 td//objPrintLibElems.LoadImageWithPortrait(par_newBadge_width_pixels,

                Image img_Step3Picture = obj_elementPic.GetStep3_Picture();
                if (img_Step3Picture == null) img_Step3Picture = par_recipientPic;

                if (img_Step3Picture != null)
                {
                    LoadImageWithPortrait_OrGraphic(img_Step3Picture,
                                        par_newBadge_width_pixels,
                                        par_layoutDims.Width_Pixels,
                                        ref obj_imageOutput,
                                        (IElement_Base)obj_elementPic,
                                        (IElementPic)obj_elementPic);
                    //
                    // End of "if (img_Step3Picture != null)"
                    //
                }
                //10-18 td  ref par_recipientPic);
            }

            //
            //Added 10/9/2019 thomas d. 
            //
            //--Nov. 29 2021--//if (par_cache.MissingTheSignature())
            if (par_cache.MissingTheSignature() && (par_elementSig == null))
            {
                //
                //There is not any Signature to display.
                //
            }
            else if (ClassMakeAssistant.IncludeSignature)
            {
                //
                //Add the Signature. 
                //
                //Jan19 2022 ''ClassElementSignature obj_elementSig = par_cache.ElementSig_RefCopy;
                ClassElementSignature obj_elementSig = par_cache.GetElementSig(false);

                //Added 11/29/2021 td
                if (par_elementSig != null) obj_elementSig = par_elementSig;

                string strPathToSigFile = this.PathToFile_Sig; //Added 10/12/2019 td

                LoadImageWithSignature(par_newBadge_width_pixels,
                                    par_layoutDims.Width_Pixels,
                                    ref obj_imageOutput,
                                    (IElement_Base)obj_elementSig,
                                    (IElementSig)obj_elementSig,
                                    strPathToSigFile);

                // 10-12-2019 td //ref par_recipientPic);

            }

            //
            //Added 10/14/2019 thomas d. 
            //Encapsulated 12/11/2021 thomas 
            //
            //Dec.11 2021 ''LoadImageWithQRCode_IfNeeded(par_cache, par_elementQR, 
            //                             par_layout.Width_Pixels, par_layout, 
            //                             ref obj_imageOutput);
            LoadImageWithQRCode_IfNeeded(par_cache, par_elementQR,
                                         par_newBadge_width_pixels, par_layoutDims,
                                         ref obj_imageOutput, false);


            //
            //Static-Text Elements 
            //
            //Jan8 2022 td // HashSet<ClassElementStaticText> listOfElementStaticTexts;
            //Jan8 2022 td // listOfElementStaticTexts = par_cache.ListOfElementTexts_Front;

            //Jan8 2022 td // Added 11/29/2021 td
            //Jan8 2022 td // if (par_elemStaticText != null) 
            //Jan8 2022 td // {
            //    listOfElementStaticTexts = new HashSet<ClassElementStaticText>();
            //    listOfElementStaticTexts.Add(par_elemStaticText);
            // }

            // Jan8 2022 //LoadImageWithStaticTexts(ref obj_imageOutput, listOfElementStaticTexts);
            // Jan31 2022 //LoadImageWithStaticTexts(ref obj_imageOutput, par_listElementTexts);
            LoadImageWithStaticTexts(ref obj_imageOutput, par_listElementTextsV3,
                                                         par_listElementTextsV4);

            // 10-9-2019 td // return null;
            return obj_imageOutput;

        }



        public void LoadImageWithPortrait_OrGraphic(Image par_imageStep3Picture,
                         int pintDesiredLayoutWidth,
                         int pintDesignedLayoutWidth,
                         ref Image par_imageBadgeCard,
                         IElement_Base par_elementBase,
                         IElementPic par_elementPic)
        {
            //---Jan22 2022--public void LoadImageWithPortrait(Image par_imageStep3Picture,
            //
            //Added 9/9/2019 thomas d.
            //
            Image imagePortraitResized;
            Graphics gr_Badge;  // As Graphics '' = Graphics.FromImage(img)
            Double decScalingFactor;  // As Double ''Added 9 / 4 / 2019 thomas downes ''9 / 4 td''Decimal
            int intLeft_Desired; // As Integer
            int intTop_Desired; // As Integer
            int intWidth_Desired; // As Integer

            //Added 5-21-2022 thomas downes
            if (null == par_imageStep3Picture) return;
            if (null == par_imageBadgeCard) return;

            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");

            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            decScalingFactor = ((double)pintDesiredLayoutWidth /
                                        pintDesignedLayoutWidth);

            //With par_elementBase
            intLeft_Desired = (int)(par_elementBase.LeftEdge_Pixels * decScalingFactor);
            intTop_Desired = (int)(par_elementBase.TopEdge_Pixels * decScalingFactor);
            intWidth_Desired = (int)(par_elementBase.Width_Pixels * decScalingFactor);
            //End With

            //''9 / 9 / 2019 td''gr_Badge.DrawImage(par_imagePortrait, New PointF(intLeft_Desired, intTop_Desired))

            // 10-18 td//imagePortraitResized = ResizeImage_ToWidth(par_imagePortrait, intWidth_Desired);
            imagePortraitResized = ResizeImage_ToWidth(par_imageStep3Picture, intWidth_Desired);

            gr_Badge.DrawImage(imagePortraitResized, new PointF(intLeft_Desired, intTop_Desired));

            gr_Badge.Dispose();

        }  // End Sub ''end of "Public Sub LoadImageWithPortrait()"


        public void LoadImageWithSignature(int pintDesiredLayoutWidth,
                                 int pintDesignedLayoutWidth,
                                 ref Image par_imageBadgeCard,
                                 IElement_Base par_elementBase,
                                 IElementSig par_elementSig,
                                 string par_strPathToSigFile)
        {
            //
            //Added 10/12/2019 thomas d.
            //
            Image imageSignaResized;
            Graphics gr_Badge;  // As Graphics '' = Graphics.FromImage(img)
            Double decScalingFactor;  // As Double ''Added 9 / 4 / 2019 thomas downes ''9 / 4 td''Decimal
            int intLeft_Desired; // As Integer
            int intTop_Desired; // As Integer
            int intWidth_Desired; // As Integer

            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");

            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            decScalingFactor = ((double)pintDesiredLayoutWidth /
                                        pintDesignedLayoutWidth);

            //With par_elementBase
            intLeft_Desired = (int)(par_elementBase.LeftEdge_Pixels * decScalingFactor);
            intTop_Desired = (int)(par_elementBase.TopEdge_Pixels * decScalingFactor);
            intWidth_Desired = (int)(par_elementBase.Width_Pixels * decScalingFactor);
            //End With

            //''9 / 9 / 2019 td''gr_Badge.DrawImage(par_imagePortrait, New PointF(intLeft_Desired, intTop_Desired))

            // 10-12-2019 td//imageSignaResized = ResizeImage_ToWidth(par_imageSignature, intWidth_Desired);

            //Added 10/12/2019 td 
            par_elementSig.SigFilePath = par_strPathToSigFile;
            string strErrorMessage = "";
            Image imageSignature = par_elementSig.GetImage_Signature(true, ref strErrorMessage);

            imageSignaResized = ResizeImage_ToWidth(imageSignature, intWidth_Desired);

            gr_Badge.DrawImage(imageSignaResized, new PointF(intLeft_Desired, intTop_Desired));

            gr_Badge.Dispose();

        }  // End Sub ''end of "Public Sub LoadImageWithSignature()"



        public void LoadImageWithQRCode_IfNeeded(ClassElementsCache_Deprecated par_cache,
                                                 ClassElementQRCode par_elementQR,
                                                 int par_newBadge_width_pixels,
                                                 IBadgeLayoutDimensions par_infoBadgeLayoutDims,
                                                 ref Image pref_imageOutput,
                                                 bool pboolBacksideOfCard)
        {
            //
            // Added 12/11/2021 thomas downes 
            //

            //--Nov.29 2021--if (par_cache.MissingTheQRCode())
            if (par_cache.MissingTheQRCode() && (par_elementQR == null))
            {
                //
                //There is not any QR Code to display.
                //
            }
            else if (ClassMakeAssistant.IncludeQR)
            {
                //
                //Add the QR Code. 
                //
                //1/19/2022 td//ClassElementQRCode obj_elementQR = par_cache.ElementQR_RefCopy;
                ClassElementQRCode obj_elementQR = par_cache.GetElementQR(pboolBacksideOfCard);

                //Added 11/29/2021 td
                if (par_elementQR != null) obj_elementQR = par_elementQR;

                // Added 127/2021 thomas d.
                if (this.ImageQRCode == null) this.ImageQRCode = obj_elementQR.Image_BL;

                //string strPathToFile_QR = ""; //this.PathToFile_QR; //Added 10/14/2019 td

                //strPathToFile_QR = obj_elementQR.PathToFile_

                LoadImageWithQRCode(par_newBadge_width_pixels,
                                    par_infoBadgeLayoutDims.Width_Pixels,
                                    ref pref_imageOutput,
                                    (IElement_Base)obj_elementQR,
                                    (IElementQRCode)obj_elementQR,
                                    ref this.ImageQRCode);
                // 10-12-2019 td //ref par_recipientPic);

            }


        }


        public void LoadImageWithQRCode_IfNeeded(IBadgeSideLayoutElementsV1 par_infoBadgeCache,
                                         ClassElementQRCode par_elementQR,
                                         int par_newBadge_width_pixels,
                                         IBadgeLayoutDimensions par_infoBadgeLayoutDims,
                                         ref Image pref_imageOutput)
        {
            //
            // Added 12/26/2021 thomas downes 
            //

            if (par_elementQR == null)
            {
                //
                //There is not any QR Code to display.
                //
            }
            else
            {
                //
                //Add the QR Code. 
                //
                ClassElementQRCode obj_elementQR = par_elementQR;

                //Added 1/17/2022 td
                if (obj_elementQR.Image_BL == null)
                {
                    //Added 1/17/2022 td
                    obj_elementQR.Image_BL = GetExampleQRCode_IfItsOkay();
                }

                this.ImageQRCode = obj_elementQR.Image_BL;

                LoadImageWithQRCode(par_newBadge_width_pixels,
                                    par_infoBadgeLayoutDims.Width_Pixels,
                                    ref pref_imageOutput,
                                    (IElement_Base)obj_elementQR,
                                    (IElementQRCode)obj_elementQR,
                                    ref this.ImageQRCode);

            }

        }


        public void LoadImageWithQRCode(int pintDesiredLayoutWidth,
                                 int pintDesignedLayoutWidth,
                                 ref Image par_imageBadgeCard,
                                 IElement_Base par_elementBase,
                                 IElementQRCode par_elementQR,
                                 ref Image par_imageQRCode)
        {
            //
            //Added 10/12/2019 thomas d.
            //
            Image imageQRCodeResized;
            Graphics gr_Badge;  // As Graphics '' = Graphics.FromImage(img)
            Double decScalingFactor;  // As Double ''Added 9 / 4 / 2019 thomas downes ''9 / 4 td''Decimal
            int intLeft_Desired; // As Integer
            int intTop_Desired; // As Integer
            int intWidth_Desired; // As Integer

            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");

            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            decScalingFactor = ((double)pintDesiredLayoutWidth /
                                        pintDesignedLayoutWidth);

            //With par_elementBase
            intLeft_Desired = (int)(par_elementBase.LeftEdge_Pixels * decScalingFactor);
            intTop_Desired = (int)(par_elementBase.TopEdge_Pixels * decScalingFactor);
            intWidth_Desired = (int)(par_elementBase.Width_Pixels * decScalingFactor);
            //End With

            //''9 / 9 / 2019 td''gr_Badge.DrawImage(par_imagePortrait, New PointF(intLeft_Desired, intTop_Desired))

            imageQRCodeResized = ResizeImage_ToWidth(par_imageQRCode, intWidth_Desired);

            gr_Badge.DrawImage(imageQRCodeResized, new PointF(intLeft_Desired, intTop_Desired));

            gr_Badge.Dispose();

        }  // End Sub ''end of "Public Sub LoadImageWithQRCode()"



        //Public Sub LoadImageWithElements(ByRef par_imageBadgeCard As Image,
        //                           par_elements As List(Of ClassElementField),
        //                                Optional par_listTextImages As List(Of Image) = Nothing)
        //    ''9/18/2019 td---Public Sub LoadImageWithFieldValues(ByRef par_imageBadgeCard As Image,
        //    ''---                                par_standardFields As List(Of IFieldInfo_ElementPositions),
        //    ''---                                par_customFields As List(Of IFieldInfo_ElementPositions),
        //    ''---                                     Optional par_listTextImages As List(Of Image) = Nothing)        

        public void LoadImageWithStaticTexts(ref Image par_imageBadgeCard,
                              HashSet<ClassElementStaticTextV3> par_elementsV3,
                              HashSet<ClassElementStaticTextV4> par_elementsV4,
                              HashSet<Image> par_listTextImages = null,
                              ClassElementBase par_elementBaseToOmit = null)
        {
            //
            //Stubbed 10/14/2019 thomas d. 
            //
            Graphics gr_Badge;
            //Jan31 2022 //int intEachIndex = 0;
            int intEachIndexV3 = 0;
            int intEachIndexV4 = 0;
            bool bOutputListOfAllImages;
            bool each_boolMatchBaseToOmit = false;  //Added 8/01/2022 thomas downes
            bool boolCheckMatchBaseToOmit = false;  //Added 8/01/2022 thomas downes

            boolCheckMatchBaseToOmit = (par_elementBaseToOmit != null); //Added 8/01/2022 td
            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");
            bOutputListOfAllImages = (par_listTextImages != null);
            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            foreach (ClassElementStaticTextV3 each_elementStaticV3 in par_elementsV3)
            {
                intEachIndexV3 += 1;

                // Added 1/31/2022 td //AddElementStaticToImage(each_elementStatic, 
                AddElementStaticToImageV3(each_elementStaticV3, par_imageBadgeCard,
                       gr_Badge, bOutputListOfAllImages, par_listTextImages);

            }

            // Added 1/31/2022 thomas downes
            foreach (ClassElementStaticTextV4 each_elementStaticV4 in par_elementsV4)
            {
                //
                //Omit the specified element-base to omit. 
                //
                if (boolCheckMatchBaseToOmit)
                {
                    //Skip the element w/ specified base (par_elementBaseToOmit).
                    each_boolMatchBaseToOmit = (par_elementBaseToOmit == (ClassElementBase)each_elementStaticV4);
                    if (each_boolMatchBaseToOmit) continue; //Skip the current element. 
                }

                intEachIndexV4 += 1;
                AddElementStaticToImageV4(each_elementStaticV4, par_imageBadgeCard,
                       gr_Badge, bOutputListOfAllImages, par_listTextImages);

            }

            gr_Badge.Dispose();

        }


        public void LoadImageWithStaticGraphics(ref Image par_imageBadgeCard,
                      HashSet<ClassElementGraphic> par_listOfElements_Graphics,
                      int par_newBadge_width_pixels,
                      int par_layout_width_pixels,
                      ref WhyOmitted_StructV1 pref_enum_whyNotV1,
                      ref WhyOmitted_StructV2 pref_enum_whyNotV2,
                      ClassElementBase par_elementBaseToOmit = null)
        {
            //''New optional parameter "par_elementBaseToOmit" allows us to focus on individual elements
            //''   against a background which includes visual/ non - editable(image only) versions of
            //''   all other elements(which are not currently being edited).
            //''   ---8/01/2022 td
            //
            //LoadImageWithStaticGraphics(ref obj_imageOutput,
            //    par_layoutElements.ListElementGraphics,
            //    par_newBadge_width_pixels,
            //    par_layoutDims.Width_Pixels);
            //
            //Added 1/22/2022 thomas d. 
            //
            pref_enum_whyNotV1 = new WhyOmitted_StructV1();  //Added 1/23/2022 td
            Graphics gr_Badge;
            int intEachIndex = 0;
            //bool bOutputListOfAllImages;
            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");
            //bOutputListOfAllImages = (par_listTextImages != null);
            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            //
            // Iterate through the graphic elements. 
            //
            foreach (ClassElementGraphic each_elementStatic in par_listOfElements_Graphics)
            {
                //
                //Added 8/1/2022 
                //
                if (par_elementBaseToOmit == each_elementStatic as ClassElementBase)
                {
                    //''Optional parameter "par_elementBaseToOmit" allows us to focus on individual elements
                    //''   against a background which includes visual/ non - editable(image only) versions of
                    //''   all other elements(which are not currently being edited).
                    //''-- - 8 / 1 / 2022 td
                    continue;
                }    

                intEachIndex += 1;

                //Added 1/23/2022 td
                if (each_elementStatic.GraphicImageFullPath == null) // continue; //Added 1/23/2022 td
                {
                    pref_enum_whyNotV2.OmitNullImage = true; //Added 1/23/2022 td
                    pref_enum_whyNotV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td
                    continue; //Added 1/23/2022 td
                }
                if (each_elementStatic.Width_Pixels <= 0) // continue; //Added 1/23/2022 td
                {
                    pref_enum_whyNotV1.OmitWidth = true;
                    pref_enum_whyNotV2.OmitZeroWidth = true; //Added 1/23/2022 td
                    pref_enum_whyNotV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td
                    continue; //Added 1/23/2022 td
                }
                if (each_elementStatic.Height_Pixels <= 0) // continue; //Added 1/23/2022 td
                {
                    pref_enum_whyNotV1.OmitHeight = true;
                    pref_enum_whyNotV2.OmitZeroHeight = true;       //Added 1/23/2022 td
                    pref_enum_whyNotV2.SetDateTime(DateTime.Now);   //Added 1/23/2022 td
                    continue; //Added 1/23/2022 td
                }

                //AddElementGraphicToImage(each_elementStatic, par_imageBadgeCard,
                //       gr_Badge, bOutputListOfAllImages, par_listTextImages);

                Bitmap image_graphic = new Bitmap(each_elementStatic.GraphicImageFullPath);

                //Major call !!
                LoadImageWithPortrait_OrGraphic(image_graphic,
                                    par_newBadge_width_pixels,
                                    par_layout_width_pixels,
                                    ref par_imageBadgeCard,
                                    (IElement_Base)each_elementStatic,
                                    null);   // Jan22 2022 td //(IElement_Base)each_elementStatic);

            }

            gr_Badge.Dispose();

        }


        public void LoadImageWithElementFields(ref Image par_imageBadgeCard,
                                          ref DateTime par_datetimeLastUpdated,
                                          ClassElementsCache_Deprecated par_cache,
                                          IEnumerable<ClassElementFieldV3> par_elementFieldsV3,
                                          IEnumerable<ClassElementFieldV4> par_elementFieldsV4,
                                          IRecipient par_iRecipientInfo = null,
                                          List<Image> par_listTextImages = null,
                                          List<String> par_listMessages = null,
                                          List<String> par_listFieldsIncluded = null,
                                          List<String> par_listFieldsNotIncluded = null,
                                          ClassElementFieldV3 par_recentlyMovedV3 = null,
                                          ClassElementFieldV4 par_recentlyMovedV4 = null,
                                          ClassElementBase par_elementBaseToOmit = null)
        {
            //    ''Added 8/14/2019 td  
            //    ''
            //    Dim gr_Badge As Graphics ''= Graphics.FromImage(img)
            //    Dim intEachIndex As Integer ''Added 8/24/2019 td
            //    Dim bOutputAllImages As Boolean ''Added 8/26/2019 thomas d.

            Graphics gr_Badge;
            int intEachIndexV3 = 0;
            int intEachIndexV4 = 0;   //Added 2/10/2022 thomas d.
            bool bOutputListOfAllImages;
            //string strTextToDisplay = ""; //Added 10/17/2019 thomas d
            bool boolCheckMatchBaseToOmit = false; //Added 8/01/2022 td
            bool each_boolMatchBaseToOmit = false; //Added 8/01/2022 td

            //
            //    ''9/8/2019 thomas d.
            //    ProportionsAreSlightlyOff(par_imageBadgeCard, True, "par_imageBadgeCard")

            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");

            //
            //    bOutputAllImages = (par_listTextImages IsNot Nothing) ''Added 8/26/2019 thomas d.

            //10-17 td //bOutputAllImages = (par_listTextImages == null);
            bOutputListOfAllImages = (par_listTextImages != null);

            //
            //    gr_Badge = Graphics.FromImage(par_imageBadgeCard)

            gr_Badge = Graphics.FromImage(par_imageBadgeCard);

            //
            //    ''
            //    ''
            //    ''All Fields 
            //    ''
            //      ''
            //    ''9/18/2019 td''For Each each_elementField As IFieldInfo_ElementPositions In par_standardFields
            //    For Each each_elementField As ClassElementField In par_elements

            //
            // Element Fields, Version #3
            //
            if (par_elementFieldsV3 is null) par_elementFieldsV3 = new List<ClassElementFieldV3>();

            foreach (ClassElementFieldV3 each_elementFieldV3 in par_elementFieldsV3)
            {
                //
                // Element Field, Version #3     
                //
                //        intEachIndex += 1
                par_datetimeLastUpdated = MaxDateTime(each_elementFieldV3.DatetimeUpdated,
                    par_datetimeLastUpdated);

                // Added 11/29/2021 td  
                //----if (each_elementField == par_recentlyMoved) System.Diagnostics.Debugger.Break();

                intEachIndexV3 += 1;


                if (each_elementFieldV3.Visible)  //.FieldInfo.IsDisplayedOnBadge) // Added 1/24/2022 thomas d.
                {
                    //Added 5/11/2022 
                    ClassFieldAny each_field_any =
                        par_cache.GetFieldByFieldEnum(each_elementFieldV3.FieldEnum);

                    //Encapsulated 10/17/2019 td  
                    AddElementFieldToImageV3(each_elementFieldV3, each_field_any,
                           par_imageBadgeCard,
                           gr_Badge, bOutputListOfAllImages, par_listTextImages,
                           par_iRecipientInfo,
                           par_listMessages,
                           par_listFieldsIncluded,
                           par_listFieldsNotIncluded);

                } // End of "if (each_elementField.FieldInfo.IsDisplayedOnBadge)"

            }

            //
            // Element Fields, Version #4
            //
            if (par_elementFieldsV4 is null) par_elementFieldsV4 = new List<ClassElementFieldV4>();

            //Added 8/1/2022 td
            boolCheckMatchBaseToOmit = (par_elementBaseToOmit != null);

            foreach (ClassElementFieldV4 each_elementFieldV4 in par_elementFieldsV4)
            {
                //
                //Omit the specified element-base to omit. 
                //
                if (boolCheckMatchBaseToOmit)
                {
                    //Skip the element w/ specified base (par_elementBaseToOmit).
                    each_boolMatchBaseToOmit = (par_elementBaseToOmit == (ClassElementBase)each_elementFieldV4);
                    if (each_boolMatchBaseToOmit) continue; //Skip the current element. 
                }

                //
                // Element Field, Version #4     
                //
                par_datetimeLastUpdated = MaxDateTime(each_elementFieldV4.DatetimeUpdated,
                    par_datetimeLastUpdated);

                // Added 5/11/2022 td
                ModEnumsAndStructs.EnumCIBFields each_eCIBField = each_elementFieldV4.FieldEnum;
                ClassFieldAny each_field_any = par_cache.GetFieldByFieldEnum(each_eCIBField);

                intEachIndexV4 += 1;

                // May29 2022
                // If an element is set up to be conditionally-displayed based on 
                //   recipient-specific data, should that same element be drawn on 
                //   idcard-preview images (badge previews)?
                //   -----Thomas Downes, 5/29/2022
                //   //const bool c_bPreviewConditionalElems = true;  //Not used. 
                //const bool c_bDontPreviewConditionalElems = false;
                bool bReturnThisIfRecipientNull = (!(each_elementFieldV4.ConditionalExp_PreviewDisplay));
                bool boolSuppressConditionally = each_elementFieldV4
                                .ConditionalExpressionIsFalse(par_iRecipientInfo, false,
                                   bReturnThisIfRecipientNull);


                // 5-11-2022 if (each_elementFieldV4.FieldInfo.IsDisplayedOnBadge) // Added 1/24/2022 thomas d.
                if (boolSuppressConditionally)
                {
                    // Don't display the element for the current recipient. ---5/29/2022
                    //
                }
                else if (each_elementFieldV4.Visible) // Added 1/24/2022 thomas d.
                {
                    //Encapsulated 10/17/2019 td  
                    AddElementFieldToImageV4(each_elementFieldV4,
                            each_field_any,
                            par_imageBadgeCard,
                            gr_Badge, bOutputListOfAllImages, par_listTextImages,
                            par_iRecipientInfo,
                            par_listMessages,
                            par_listFieldsIncluded,
                            par_listFieldsNotIncluded);

                } // End of "if (each_elementField.FieldInfo.IsDisplayedOnBadge)"

            }

            // Added 11/29/2021 td 
            //---each_elementField.DatetimeUpdated = DateTime.Now;
            //---not needed here---par_datetimeLastUpdated = MaxDateTime(each_elementField.DatetimeUpdated,
            //    par_datetimeLastUpdated);

            ////Added 10/17/2019 td
            //strTextToDisplay = each_elementField.LabelText_ToDisplay(false);
            //
            ////
            ////        ''9/3/2019 td''If (not each_elementField.IsDiplayedOnBadge) Then Continue for
            ////
            ////        ''
            ////        ''Added 8/24/2019 thomas d.
            ////        ''
            ////        ''9/18 td''With each_elementField.Position_BL
            ////
            ////        With each_elementField
            ////
            ////            Select Case True
            ////                Case (.LeftEdge_Pixels< 0)
            ////                  Continue For
            //
            //if (0 > each_elementField.LeftEdge_Pixels) continue;
            //
            ////                Case(.TopEdge_Pixels< 0) ''Then
            ////                  Continue For
            //
            //if (0 > each_elementField.TopEdge_Pixels) continue;
            //
            ////              Case(.LeftEdge_Pixels + .Width_Pixels > par_imageBadgeCard.Width) ''Then 
            ////                    ''Continue For
            //
            //int intElementsRightEdge = (each_elementField.LeftEdge_Pixels +
            //                            each_elementField.Width_Pixels);
            //if (intElementsRightEdge > par_imageBadgeCard.Width) continue;
            //  
            ////                Case(.TopEdge_Pixels + .Height_Pixels > par_imageBadgeCard.Height) ''Then 
            ////                    ''Continue For
            //
            //int intElementsBottomEdge = (each_elementField.TopEdge_Pixels +
            //                            each_elementField.Height_Pixels);
            //if (intElementsBottomEdge > par_imageBadgeCard.Height) continue;
            //
            //
            ////            End Select
            ////        End With ''End of "With each_elementField"
            //
            //
            ////
            ////        With each_elementField
            ////
            ////            Dim image_textStandard As Image
            //
            //Image image_textStandard;  
            //
            ////            ''9/20/2019 td''Dim intLeft As Integer
            ////            ''9/20/2019 td''Dim intTop As Integer
            ////
            ////            ''9/3/2019 td''If(Not.IsDisplayedOnBadge) Then Continue For
            ////          If(Not FieldInfo.IsDisplayedOnBadge) Then Continue For
            //
            ////Added 10/14/2019 td
            //if (!(each_elementField.IsDisplayedOnBadge_Visibly())) continue;
            //
            ////
            ////            ''Added 9/4/2019 thomas downes
            ////            ''9/12/2019 td''If(0 = .Position_BL.LayoutWidth_Pixels) Then
            ////           If(0 = .Width_Pixels) Then
            //if (0 == each_elementField.Width_Pixels)
            //{
            //    // ''Added 9/4/2019 thomas downes
            //    //MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
            //    //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"
            //}
            //
            ////
            ////            Try
            //try
            //{
            //    //                ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
            //    //                ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
            //    //                ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)
            //    //
            //    //                ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
            //    //                '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
            //    //
            //    //                ''9/5/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_imageBadgeCard.Width)
            //    //                ''9/8/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(each_elementField.BadgeLayout_Width)
            //    //
            //    //                Dim intDesiredLayout_Width As Integer ''added 9/8/2019 td
            //    //                intDesiredLayout_Width = par_imageBadgeCard.Width
            //  
            //    int intDesiredLayout_Width = par_imageBadgeCard.Width;
            //    
            //    //
            //    //                ''9/19/2019 td''image_textStandard =
            //    //                ''9/19/2019 td''    .TextDisplay.GenerateImage_ByDesiredLayoutWidth(intDesiredLayout_Width)
            //    //
            //    bool boolRotated = false; //Added 10/14/2019 td  
            //
            //    // 10-17-2019 image_textStandard =
            //    //       modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
            //    //         each_elementField, each_elementField, ref boolRotated, false);  //''9/20/2019 td'', True)
            //    image_textStandard =
            //           modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
            //             each_elementField, each_elementField, ref boolRotated, false);  //''9/20/2019 td'', True)
            //                                                                             //
            //                                                                             //                 If(bOutputAllImages) Then par_listTextImages.Add(image_textStandard) ''Added 8/26/2019 td
            //
            //    if (bOutputAllImages) par_listTextImages.Add(image_textStandard);
            //
            //    //
            //    //                ''8/30/2019 td''.TextDisplay.Image_BL = image_textStandard ''Added 8/27/2019 td
            //    //                ''9/19/2019 td''.Position_BL.Image_BL = image_textStandard ''Added 8/27/2019 td
            //    //                .Image_BL = image_textStandard ''Added 8/27/2019 td
            //    each_elementField.Image_BL = image_textStandard;
            //
            //    //
            //    //                ''9/4/2019 td''intLeft = .Position_BL.LeftEdge_Pixels
            //    //                ''9/4/2019 td''intTop = .Position_BL.TopEdge_Pixels
            //    //
            //    //                Dim decScalingFactor As Double ''Added 9/4/2019 thomas downes ''9/4 td''Decimal
            //    //
            //    //                ''9/12/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.LayoutWidth_Pixels)
            //    //                ''9/19/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.BadgeLayout.Width_Pixels)
            //    //
            //    //                ''---+--9/20/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Width_Pixels)
            //    //                ''---+--9/20/2019 td''intLeft = CInt(.LeftEdge_Pixels* decScalingFactor)
            //    //                ''---+--9/20/2019 td''intTop = CInt(.TopEdge_Pixels* decScalingFactor)
            //    //                ''---+--9/20/2019 td''gr_Badge.DrawImage(image_textStandard,
            //    //                ''---+--9/20/2019 td''             New PointF(intLeft, intTop))
            //    //
            //    //                ''Added 9/20/2019 td
            //
            //    decimal decScalingFactor = ((decimal)par_imageBadgeCard.Width / 
            //                                 each_elementField.BadgeLayout.Width_Pixels);
            //    
            //    //                Dim intDesignedLeft As Integer ''Designed = layout pre-production = The Left value when designed via the Layout Designer tool. --9/20
            //    //                Dim intDesignedTop As Integer ''Designed = layout pre-production = The Top value when designed via the Layout Designer tool.  --9/20
            //    //                Dim intDesiredLeft As Integer ''Desired = preview / print / production = The Left value on the print/preview version of the badge.  --9/20
            //    //                Dim intDesiredTop As Integer ''Desired = preview / print / production = The Top value on the print/preview version of the badge.  --9/20
            //    //
            //    //                intDesignedLeft = .LeftEdge_Pixels
            //    //                intDesignedTop = .TopEdge_Pixels
            //
            //    int intDesignedLeft = each_elementField.LeftEdge_Pixels;  //Added 10/14/2019 td 
            //    int intDesignedTop = each_elementField.TopEdge_Pixels;  //Added 10/14/2019 td
            //
            //    //
            //    //                intDesiredLeft = CInt(intDesignedLeft * decScalingFactor)
            //    //                intDesiredTop = CInt(intDesignedTop * decScalingFactor)
            //
            //    int intDesiredLeft = (int)(intDesignedLeft * decScalingFactor);
            //    int intDesiredTop = (int)(intDesignedTop * decScalingFactor);
            //
            //    gr_Badge.DrawImage(image_textStandard,
            //                       new PointF(intDesiredLeft, intDesiredTop));
            //  
            //}
            ////            Catch ex_draw_invalid As InvalidOperationException
            //catch (InvalidOperationException ex_draw_invalid)
            //{
            //    //                ''Error:  Object not available.
            //    //                Dim strMessage_Invalid As String
            //    //                strMessage_Invalid = ex_draw_invalid.Message
            //    string strMessage_Invalid = ex_draw_invalid.Message;
            //    throw new Exception("Let's throw the message.", ex_draw_invalid);
            //
            //    //                ''Added 8/24 thomas d.
            //    //                MessageBox.Show(strMessage_Invalid, "10303",
            //    //                                MessageBoxButtons.OK,
            //    //                                MessageBoxIcon.Exclamation)
            //}
            ////            Catch ex_draw_any As System.Exception
            //catch (Exception ex_draw_any)
            //{
            //    //                ''Error:  Object not available.
            //    //                Dim strMessage_any As String
            //    //                strMessage_any = ex_draw_any.Message
            //    string strMessage_any;
            //    strMessage_any = ex_draw_any.Message;
            //    throw new Exception("Let's throw the message.", ex_draw_any);
            //
            //    //                ''Added 8/24 thomas d.
            //    //                MessageBox.Show(strMessage_any, "99943800",
            //    //                                MessageBoxButtons.OK,
            //    //                                MessageBoxIcon.Exclamation)
            //    //            End Try
            //    //        End With ''End of "With each_elementField"
            //}
            ////
            ////        ''---gr.Dispose()
            ////
            ////    Next each_elementField

            //}


            gr_Badge.Dispose();

            //End Sub ''End of ''Private Sub LoadImageWithElements()''

        }


        private void AddElementFieldToImageV3(ClassElementFieldV3 par_elementField,
                                            ClassFieldAny par_field_any,
                                            Image par_imageBadgeCard,
                                            Graphics par_graphics,
                                            bool pboolReturnListOfImages,
                                            List<Image> par_listTextImages,
                                            IRecipient par_iRecipientInfo = null,
                                            List<String> par_listMessages = null,
                                            List<String> par_listFieldsIncluded = null,
                                            List<String> par_listFieldsNotIncluded = null)
        {
            //
            //Encapsulated 10/17/2019 td
            //
            // Dec14 2021 // string strTextToDisplay = par_elementField.LabelText_ToDisplay(false);
            string strTextToDisplay = par_elementField.LabelText_ToDisplay(false,
                par_iRecipientInfo, false, par_field_any);

            //Added 11/10/2021 td
            WhyOmitted_StructV1 structWhyOmittedV1 = new WhyOmitted_StructV1();
            WhyOmitted_StructV2 structWhyOmittedV2 = new WhyOmitted_StructV2();  //Added 1/23/2022 td
            structWhyOmittedV2.EnumOmitReason = EnumOmitReasons._Undetermined;   //Added 1/23/2022 td

            //Added 1/24/2022 td


            //
            //        ''9/3/2019 td''If (not par_elementField.IsDiplayedOnBadge) Then Continue for
            //n
            //        ''
            //        ''Added 8/24/2019 thomas d.
            //        ''
            //        ''9/18 td''With par_elementField.Position_BL
            //
            //        With par_elementField
            //
            //            Select Case True
            //                Case (.LeftEdge_Pixels< 0)
            //                  Continue For

            // 10-17-2019 td // if (0 > par_elementField.LeftEdge_Pixels) continue;
            if (OmitOutlyingElements && (0 > par_elementField.LeftEdge_Pixels)) //return;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitCoordinateX = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingCoordinateX = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateX;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                { par_listFieldsNotIncluded.Add(par_elementField.FieldNm_CaptionText() + " - LeftEdge < 0"); }
                //Jan24 2022 td //return;  //10-17 continue;

            }

            //                Case(.TopEdge_Pixels< 0) ''Then
            //                  Continue For

            if (OmitOutlyingElements && (0 > par_elementField.TopEdge_Pixels))
            {
                // Added 11/10/2021  
                structWhyOmittedV1.OmitCoordinateY = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingCoordinateY = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateY;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                { par_listFieldsNotIncluded.Add(par_elementField.FieldNm_CaptionText() + " - TopEdge < 0"); }
                //Jan24 2022 td //return;  //10-17 continue;

            }

            //    Case(.LeftEdge_Pixels + .Width_Pixels > par_imageBadgeCard.Width) ''Then 
            //                    ''Continue For

            int intElementsRightEdge = (par_elementField.LeftEdge_Pixels +
                                        par_elementField.Width_Pixels);
            bool bRightEdgeOutsideBadge = (intElementsRightEdge > par_imageBadgeCard.Width);

            if (OmitOutlyingElements && (bRightEdgeOutsideBadge))
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitWidth = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingEdgeRight = true;  // Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingEdgeRight;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                { par_listFieldsNotIncluded.Add(par_elementField.FieldNm_CaptionText() + " - RightEdge > BadgeWidth"); }
                //Jan24 2022 td //return;  //10-17 continue;

            }

            //                Case(.TopEdge_Pixels + .Height_Pixels > par_imageBadgeCard.Height) ''Then 
            //                    ''Continue For

            int intElementsBottomEdge = (par_elementField.TopEdge_Pixels +
                                        par_elementField.Height_Pixels);
            bool bBottomOutsideBadge = (intElementsBottomEdge > par_imageBadgeCard.Height);

            if (OmitOutlyingElements && bBottomOutsideBadge) //return;  //10-17 continue;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitHeight = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingEdgeBottom = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingEdgeBottom;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                { par_listFieldsNotIncluded.Add(par_elementField.FieldNm_CaptionText() + " - BottomEdge > BadgeHeight"); }
                //Jan24 2022 td //return;  //10-17 continue;

            }

            //            End Select
            //        End With ''End of "With par_elementField"


            //
            //        With par_elementField
            //
            //            Dim image_textStandard As Image

            Image image_textStandard;

            //            ''9/20/2019 td''Dim intLeft As Integer
            //            ''9/20/2019 td''Dim intTop As Integer
            //
            //            ''9/3/2019 td''If(Not.IsDisplayedOnBadge) Then Continue For
            //          If(Not FieldInfo.IsDisplayedOnBadge) Then Continue For

            //Added 10/14/2019 td
            //+++if (!(par_elementField.IsDisplayedOnBadge_Visibly(structWhyOmitted)))
            // #1 Jan24 2022 //bool bElementSuppressed = (!(par_elementField.IsDisplayedOnBadge_Visibly(ref structWhyOmittedV1)));
            // #2 Jan24 2022 //bool bElementSuppressed = (!(par_elementField.IsDisplayedOnBadge_Visibly(ref structWhyOmittedV1, 
            //               //                                                           ref structWhyOmittedV2)));

            //Jan24 2022 td //if (bElementSuppressed)
            if (structWhyOmittedV2.__Omitted)
            {
                //Added 5/11/2022 td
                string strDataEntryText = par_field_any.DataEntryText;

                //Added 11/9/2021 td
                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString()
                        //  + $"  - (\"{par_elementField.FieldInfo.DataEntryText}\") "
                        + $"  - (\"{strDataEntryText}\") "
                        + " since !IsDisplayedOnBadge_Visibly(). "
                        + structWhyOmittedV1.OmitFieldMsg()
                        + structWhyOmittedV1.OmitElementMsg());

                //
                // If it's being omitted, skip to the next element (without 
                //   actually adding it to the ID Card). ---1/24/2022 td
                //
                return;  //10-17 continue;

            }

            //
            //            ''Added 9/4/2019 thomas downes
            //            ''9/12/2019 td''If(0 = .Position_BL.LayoutWidth_Pixels) Then
            //           If(0 = .Width_Pixels) Then
            if (0 == par_elementField.Width_Pixels)
            {
                // ''Added 9/4/2019 thomas downes
                //MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
                //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"
                if (par_listMessages != null)
                    par_listMessages.Add("We cannot scale the placement of the image...." +
                            par_elementField.FieldEnum.ToString());

            }

            //
            //Try
            try
            {
                //                ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                //                ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                //                ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)
                //
                //                ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                //                '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
                //
                //                ''9/5/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_imageBadgeCard.Width)
                //                ''9/8/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_elementField.BadgeLayout_Width)
                //
                //                Dim intDesiredLayout_Width As Integer ''added 9/8/2019 td
                //                intDesiredLayout_Width = par_imageBadgeCard.Width

                int intDesiredLayout_Width = par_imageBadgeCard.Width;

                //
                //                ''9/19/2019 td''image_textStandard =
                //                ''9/19/2019 td''    .TextDisplay.GenerateImage_ByDesiredLayoutWidth(intDesiredLayout_Width)
                //
                bool boolRotated = false; //Added 10/14/2019 td  

                // 10-17-2019 image_textStandard =
                //       modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
                //         par_elementField, par_elementField, ref boolRotated, false);  //''9/20/2019 td'', True)
                image_textStandard =
                       modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementField, par_elementField, 
                         ref boolRotated, false, par_elementField);  //July29 2022 ref boolRotated, false); //''9/20/2019 td'', True)
                                                   //
                                                   //                 If(bOutputAllImages) Then par_listTextImages.Add(image_textStandard) ''Added 8/26/2019 td

                if (pboolReturnListOfImages) par_listTextImages.Add(image_textStandard);

                //
                //                ''8/30/2019 td''.TextDisplay.Image_BL = image_textStandard ''Added 8/27/2019 td
                //                ''9/19/2019 td''.Position_BL.Image_BL = image_textStandard ''Added 8/27/2019 td
                //                .Image_BL = image_textStandard ''Added 8/27/2019 td
                par_elementField.Image_BL = image_textStandard;

                //
                //                ''9/4/2019 td''intLeft = .Position_BL.LeftEdge_Pixels
                //                ''9/4/2019 td''intTop = .Position_BL.TopEdge_Pixels
                //
                //                Dim decScalingFactor As Double ''Added 9/4/2019 thomas downes ''9/4 td''Decimal
                //
                //                ''9/12/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.LayoutWidth_Pixels)
                //                ''9/19/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Position_BL.BadgeLayout.Width_Pixels)
                //
                //                ''---+--9/20/2019 td''decScalingFactor = (par_imageBadgeCard.Width / .Width_Pixels)
                //                ''---+--9/20/2019 td''intLeft = CInt(.LeftEdge_Pixels* decScalingFactor)
                //                ''---+--9/20/2019 td''intTop = CInt(.TopEdge_Pixels* decScalingFactor)
                //                ''---+--9/20/2019 td''gr_Badge.DrawImage(image_textStandard,
                //                ''---+--9/20/2019 td''             New PointF(intLeft, intTop))
                //
                //                ''Added 9/20/2019 td

                decimal decScalingFactor = ((decimal)par_imageBadgeCard.Width /
                                             par_elementField.BadgeLayout.Width_Pixels);

                //                Dim intDesignedLeft As Integer ''Designed = layout pre-production = The Left value when designed via the Layout Designer tool. --9/20
                //                Dim intDesignedTop As Integer ''Designed = layout pre-production = The Top value when designed via the Layout Designer tool.  --9/20
                //                Dim intDesiredLeft As Integer ''Desired = preview / print / production = The Left value on the print/preview version of the badge.  --9/20
                //                Dim intDesiredTop As Integer ''Desired = preview / print / production = The Top value on the print/preview version of the badge.  --9/20
                //
                //                intDesignedLeft = .LeftEdge_Pixels
                //                intDesignedTop = .TopEdge_Pixels

                int intDesignedLeft = par_elementField.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop = par_elementField.TopEdge_Pixels;  //Added 10/14/2019 td

                //
                //                intDesiredLeft = CInt(intDesignedLeft * decScalingFactor)
                //                intDesiredTop = CInt(intDesignedTop * decScalingFactor)

                int intDesiredLeft = (int)(intDesignedLeft * decScalingFactor);
                int intDesiredTop = (int)(intDesignedTop * decScalingFactor);

                par_graphics.DrawImage(image_textStandard,
                                   new PointF(intDesiredLeft, intDesiredTop));

                //Added 11/9/2021 thomas downes
                if (par_listFieldsIncluded != null)
                    par_listFieldsIncluded.Add(par_elementField.FieldEnum.ToString());

            }
            //            Catch ex_draw_invalid As InvalidOperationException
            catch (InvalidOperationException ex_draw_invalid)
            {
                //                ''Error:  Object not available.
                //                Dim strMessage_Invalid As String
                //                strMessage_Invalid = ex_draw_invalid.Message
                string strMessage_Invalid = ex_draw_invalid.Message;

                //---throw new Exception("Let's throw the message.", ex_draw_invalid);
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_invalid.Message + "..." + par_elementField.FieldEnum.ToString());

                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_Invalid, "10303",
                //                           MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)

                //Added 11/9/2021 thomas downes
                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString());

            }
            //            Catch ex_draw_any As System.Exception
            catch (Exception ex_draw_any)
            {
                //                ''Error:  Object not available.
                //                Dim strMessage_any As String
                //                strMessage_any = ex_draw_any.Message
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                //---throw new Exception("Let's throw the message.", ex_draw_any);
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_any.Message + "..." + par_elementField.FieldEnum.ToString());

                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_any, "99943800",
                //                                MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)
                //            End Try
                //        End With ''End of "With par_elementField"
                //Added 11/9/2021 thomas downes
                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString());

            }
            //
            //        ''---gr.Dispose()
            //
            //    Next par_elementField
        }


        private void AddElementFieldToImageV4(ClassElementFieldV4 par_elementField,
                            ClassFieldAny par_field_any,
                            Image par_imageBadgeCard,
                            Graphics par_graphics,
                            bool pboolReturnListOfImages,
                            List<Image> par_listTextImages,
                            IRecipient par_iRecipientInfo = null,
                            List<String> par_listMessages = null,
                            List<String> par_listFieldsIncluded = null,
                            List<String> par_listFieldsNotIncluded = null)
        {
            //
            //Encapsulated 10/17/2019 td
            //
            //May29 2022 string strTextToDisplay = par_elementField.LabelText_ToDisplay(false,
            //                   par_iRecipientInfo, false);
            string strTextToDisplay = par_elementField.LabelText_ToDisplay(false,
                                         par_iRecipientInfo, false, par_field_any);

            WhyOmitted_StructV1 structWhyOmittedV1 = new WhyOmitted_StructV1();
            WhyOmitted_StructV2 structWhyOmittedV2 = new WhyOmitted_StructV2();  //Added 1/23/2022 td
            structWhyOmittedV2.EnumOmitReason = EnumOmitReasons._Undetermined;   //Added 1/23/2022 td

            if (OmitOutlyingElements && (0 > par_elementField.LeftEdge_Pixels)) //return;
            {
                structWhyOmittedV1.OmitCoordinateX = true;
                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingCoordinateX = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateX;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                {
                    // 5-11-2022 par_listFieldsNotIncluded
                    //     .Add(par_elementField.FieldNm_CaptionText() + " - LeftEdge < 0");
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldNameCaptionText() + " - LeftEdge < 0");
                }

            }

            if (OmitOutlyingElements && (0 > par_elementField.TopEdge_Pixels))
            {
                structWhyOmittedV1.OmitCoordinateY = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingCoordinateY = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateY;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                {
                    // 5-11-2022 par_listFieldsNotIncluded
                    //    .Add(par_elementField.FieldNm_CaptionText() + " - TopEdge < 0");
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldNameCaptionText() + " - TopEdge < 0");
                }

            }

            int intElementsRightEdge = (par_elementField.LeftEdge_Pixels +
                                        par_elementField.Width_Pixels);
            bool bRightEdgeOutsideBadge = (intElementsRightEdge > par_imageBadgeCard.Width);

            if (OmitOutlyingElements && (bRightEdgeOutsideBadge))
            {
                structWhyOmittedV1.OmitWidth = true;
                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingEdgeRight = true;  // Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingEdgeRight;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                {
                    //''par_listFieldsNotIncluded
                    //''    .Add(par_elementField.FieldNm_CaptionText() + " - RightEdge > BadgeWidth");
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldNameCaptionText() + " - RightEdge > BadgeWidth");
                }

            }

            int intElementsBottomEdge = (par_elementField.TopEdge_Pixels +
                                        par_elementField.Height_Pixels);
            bool bBottomOutsideBadge = (intElementsBottomEdge > par_imageBadgeCard.Height);

            if (OmitOutlyingElements && bBottomOutsideBadge) //return;  //10-17 continue;
            {
                structWhyOmittedV1.OmitHeight = true;

                structWhyOmittedV2.__Omitted = true;
                structWhyOmittedV2.OmitOutlyingEdgeBottom = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingEdgeBottom;  //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now); //Added 1/23/2022 td

                if (par_listFieldsNotIncluded != null)
                {
                    //5-11-2022 par_listFieldsNotIncluded
                    //    .Add(par_elementField.FieldNm_CaptionText() + " - BottomEdge > BadgeHeight");
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldNameCaptionText() + " - BottomEdge > BadgeHeight");
                }

            }

            Image image_textStandard;
            if (structWhyOmittedV2.__Omitted)
            {
                //Added 11/9/2021 td
                if (par_listFieldsNotIncluded != null)
                    //par_listFieldsNotIncluded.Add(par_elementField.FieldInfo.CIBadgeField
                    //    + $"  - (\"{par_elementField.FieldInfo.DataEntryText}\") "
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString()
                        + $"  - (\"{par_field_any.DataEntryText}\") "
                        + " since !IsDisplayedOnBadge_Visibly(). "
                        + structWhyOmittedV1.OmitFieldMsg()
                        + structWhyOmittedV1.OmitElementMsg());

                //
                // If it's being omitted, skip to the next element (without 
                //   actually adding it to the ID Card). ---1/24/2022 td
                //
                return;  //10-17 continue;

            }

            if (0 == par_elementField.Width_Pixels)
            {
                //MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
                //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"
                if (par_listMessages != null)
                    par_listMessages.Add("We cannot scale the placement of the image...." +
                            par_elementField.FieldEnum.ToString());

            }


            try
            {
                int intDesiredLayout_Width = par_imageBadgeCard.Width;
                bool boolRotated = false; //Added 10/14/2019 td
                                          
                image_textStandard =
                       modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementField, par_elementField, 
                         ref boolRotated, false, par_elementField);  // 7-29-2022 ref boolRotated, false);

                if (pboolReturnListOfImages) par_listTextImages.Add(image_textStandard);

                par_elementField.Image_BL = image_textStandard;

                decimal decScalingFactorW = ((decimal)par_imageBadgeCard.Width /
                                             par_elementField.BadgeLayout.Width_Pixels);
                //Added 9/4/2022 thomas downes 
                decimal decScalingFactorH = ((decimal)par_imageBadgeCard.Height /
                                             par_elementField.BadgeLayout.Height_Pixels);

                int intDesignedLeft_V4 = par_elementField.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop_V4 = par_elementField.TopEdge_Pixels;  //Added 10/14/2019 td
                //9_5_2022 int intDesignedLeft_Base = par_elementField.LeftEdge_bPixels;  //Added 10/14/2019 td 
                //9_5_2022 int intDesignedTop_Base = par_elementField.TopEdge_bPixels;  //Added 10/14/2019 td
                int intDesignedLeft_Base = par_elementField.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop_Base = par_elementField.TopEdge_Pixels;  //Added 10/14/2019 td

                //Added 9/4/2022 thomas downes
                if (intDesignedLeft_Base != intDesignedLeft_V4) System.Diagnostics.Debugger.Break();
                if (intDesignedLeft_Base != intDesignedLeft_V4) System.Diagnostics.Debugger.Break();

                int intDesiredLeft = (int)(intDesignedLeft_V4 * decScalingFactorW);
                int intDesiredTop = (int)(intDesignedTop_V4 * decScalingFactorH);

                par_graphics.DrawImage(image_textStandard,
                                   new PointF(intDesiredLeft, intDesiredTop));

                if (par_listFieldsIncluded != null)
                    par_listFieldsIncluded.Add(par_elementField.FieldEnum.ToString());

            }
            catch (InvalidOperationException ex_draw_invalid)
            {
                string strMessage_Invalid = ex_draw_invalid.Message;

                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_invalid.Message + "..." + par_elementField.FieldEnum.ToString());

                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString());

            }
            catch (Exception ex_draw_any)
            {
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_any.Message + "..." + par_elementField.FieldEnum.ToString());

                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString());

            }

        }


        private void AddElementStaticToImageV3(ClassElementStaticTextV3 par_elementStaticV3,
                                    Image par_imageBadgeCard,
                                    Graphics par_graphics,
                                    bool pboolReturnListOfImages,
                                    HashSet<Image> par_listTextImages,
                                    List<String> par_listMessages = null)
        {
            //---AddElementStaticToImageV3(ClassElementStaticTextV3 par_elementStaticV3,
            //
            //Added 12/26/2021 td
            //
            string strTextToDisplay = par_elementStaticV3.Text_StaticLine;
            bool bMultiline = par_elementStaticV3.Text_IsMultiLine;
            if (bMultiline && (par_elementStaticV3.Text_ListOfLines != null &&
                               par_elementStaticV3.Text_ListOfLines.Count > 1))
            {
                strTextToDisplay = par_elementStaticV3.Text_ListOfLines[0] + _vbCrLf +
                                   par_elementStaticV3.Text_ListOfLines[1];
            }

            WhyOmitted_StructV1 structWhyOmittedV1 = new WhyOmitted_StructV1();
            WhyOmitted_StructV2 structWhyOmittedV2 = new WhyOmitted_StructV2();

            if (OmitOutlyingElements && (0 > par_elementStaticV3.LeftEdge_Pixels)) //return;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitCoordinateX = true;
                structWhyOmittedV2.OmitOutlyingCoordinateX = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateX; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            if (OmitOutlyingElements && (0 > par_elementStaticV3.TopEdge_Pixels))
            {
                // Added 11/10/2021  
                structWhyOmittedV1.OmitCoordinateY = true;
                structWhyOmittedV2.OmitOutlyingCoordinateY = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateY; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            int intElementsRightEdge = (par_elementStaticV3.LeftEdge_Pixels +
                                        par_elementStaticV3.Width_Pixels);

            if (OmitOutlyingElements && (intElementsRightEdge > par_imageBadgeCard.Width))
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitWidth = true;
                structWhyOmittedV2.OmitZeroWidth = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.ZeroWidth; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            int intElementsBottomEdge = (par_elementStaticV3.TopEdge_Pixels +
                                        par_elementStaticV3.Height_Pixels);

            if (OmitOutlyingElements && (intElementsBottomEdge > par_imageBadgeCard.Height)) //return;  //10-17 continue;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitHeight = true;
                structWhyOmittedV2.OmitZeroHeight = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.ZeroHeight; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;  //10-17 continue;
            }

            Image image_textStandard;
            bool bElementSuppressed = (!(par_elementStaticV3.Visible));
            if (bElementSuppressed)
            {
                return;
            }

            if (0 == par_elementStaticV3.Width_Pixels)
            {
                if (par_listMessages != null)
                    par_listMessages.Add("We cannot scale the placement of the image...." +
                            par_elementStaticV3.Text_StaticLine);

            }

            try
            {

                int intDesiredLayout_Width = par_imageBadgeCard.Width;

                bool boolRotated = false; //Added 10/14/2019 td  

                image_textStandard =
                    modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementStaticV3, par_elementStaticV3, ref boolRotated, false, par_elementStaticV3);

                if (pboolReturnListOfImages) par_listTextImages.Add(image_textStandard);

                par_elementStaticV3.Image_BL = image_textStandard;

                decimal decScalingFactor = ((decimal)par_imageBadgeCard.Width /
                                             par_elementStaticV3.BadgeLayoutDims.Width_Pixels);

                int intDesignedLeft = par_elementStaticV3.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop = par_elementStaticV3.TopEdge_Pixels;  //Added 10/14/2019 td

                int intDesiredLeft = (int)(intDesignedLeft * decScalingFactor);
                int intDesiredTop = (int)(intDesignedTop * decScalingFactor);

                par_graphics.DrawImage(image_textStandard,
                                   new PointF(intDesiredLeft, intDesiredTop));

                //''---if (par_listFieldsIncluded != null)
                //''---    par_listFieldsIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (InvalidOperationException ex_draw_invalid)
            {
                string strMessage_Invalid = ex_draw_invalid.Message;

                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_invalid.Message + "..." + par_elementStaticV3.Text_StaticLine);

                //if (par_listFieldsNotIncluded != null)
                //    par_listFieldsNotIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (Exception ex_draw_any)
            {
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_any.Message + "..." + par_elementStaticV3.Text_StaticLine);

                //''if (par_listFieldsNotIncluded != null)
                //''    par_listFieldsNotIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }

        }  //End of "AddElementStaticToImageV3




        private void AddElementStaticToImageV4(ClassElementStaticTextV4 par_elementStaticV4,
                            Image par_imageBadgeCard,
                            Graphics par_graphics,
                            bool pboolReturnListOfImages,
                            HashSet<Image> par_listTextImages,
                            List<String> par_listMessages = null)
        {
            //---AddElementStaticToImageV3(ClassElementStaticTextV3 par_elementStaticV3,
            //
            //Added 12/26/2021 td
            //
            string strTextToDisplay = "";
            bool boolIsMultiLine = false;
            bool boolIsMultiLine_LineZero = false;
            bool boolIsMultiLine_IterateArray = false;

            // Added 6/10/2022
            // First default.
            strTextToDisplay = par_elementStaticV4.Text_StaticLine;

            boolIsMultiLine = (par_elementStaticV4.Text_IsMultiLine);
            boolIsMultiLine_LineZero = (boolIsMultiLine &&
                (par_elementStaticV4.Text_ListOfLines != null) &&
                (par_elementStaticV4.Text_ListOfLines.Count >= 1));

            // Added 6/10/2022
            // Second default.
            if (boolIsMultiLine_LineZero)
            {
                // Added 6/10/2022
                strTextToDisplay = par_elementStaticV4.Text_ListOfLines[0];
            }

            boolIsMultiLine_IterateArray = (boolIsMultiLine &&
                (par_elementStaticV4.Text_ListOfLines != null) &&
                (par_elementStaticV4.Text_ListOfLines.Count > 1));

            //
            // Append the lines together. ---6/10/2022 td
            //
            //if (par_elementStaticV4.Text_ListOfLines != null)
            if (boolIsMultiLine_IterateArray)
            { 
                strTextToDisplay = par_elementStaticV4.Text_ListOfLines[0];

                if (par_elementStaticV4.Text_IsMultiLine)
                {
                    //6-10-2022 td //strTextToDisplay = par_elementStaticV4.Text_ListOfLines[0] +
                    //    Environment.NewLine +
                    //    par_elementStaticV4.Text_ListOfLines[1];
                    int intLengthOfArray = par_elementStaticV4.Text_ListOfLines.Count;

                    for (int i_LineIndex = 1; i_LineIndex < intLengthOfArray; i_LineIndex++)
                    {
                        strTextToDisplay = strTextToDisplay +
                            Environment.NewLine +
                            par_elementStaticV4.Text_ListOfLines[i_LineIndex];
                    }

                }
                else
                {
                    strTextToDisplay = par_elementStaticV4.Text_StaticLine;
                }
            }

            WhyOmitted_StructV1 structWhyOmittedV1 = new WhyOmitted_StructV1();
            WhyOmitted_StructV2 structWhyOmittedV2 = new WhyOmitted_StructV2();

            if (OmitOutlyingElements && (0 > par_elementStaticV4.LeftEdge_Pixels)) //return;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitCoordinateX = true;
                structWhyOmittedV2.OmitOutlyingCoordinateX = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateX; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            if (OmitOutlyingElements && (0 > par_elementStaticV4.TopEdge_Pixels))
            {
                // Added 11/10/2021  
                structWhyOmittedV1.OmitCoordinateY = true;
                structWhyOmittedV2.OmitOutlyingCoordinateY = true;   //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.OutlyingCoordinateY; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            int intElementsRightEdge = (par_elementStaticV4.LeftEdge_Pixels +
                                        par_elementStaticV4.Width_Pixels);

            if (OmitOutlyingElements && (intElementsRightEdge > par_imageBadgeCard.Width))
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitWidth = true;
                structWhyOmittedV2.OmitZeroWidth = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.ZeroWidth; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;
            }

            int intElementsBottomEdge = (par_elementStaticV4.TopEdge_Pixels +
                                        par_elementStaticV4.Height_Pixels);

            if (OmitOutlyingElements && (intElementsBottomEdge > par_imageBadgeCard.Height)) //return;  //10-17 continue;
            {
                // Added 11/10/2021
                structWhyOmittedV1.OmitHeight = true;
                structWhyOmittedV2.OmitZeroHeight = true;  //Added 1/23/2022 td
                structWhyOmittedV2.EnumOmitReason = EnumOmitReasons.ZeroHeight; //Added 1/23/2022 td
                structWhyOmittedV2.SetDateTime(DateTime.Now);  //Added 1/23/2022 td
                return;  //10-17 continue;
            }

            Image image_textStandard;
            bool bElementSuppressed = (!(par_elementStaticV4.Visible));
            if (bElementSuppressed)
            {
                return;
            }

            if (0 == par_elementStaticV4.Width_Pixels)
            {
                if (par_listMessages != null)
                    par_listMessages.Add("We cannot scale the placement of the image...." +
                            par_elementStaticV4.Text_StaticLine);

            }

            try
            {

                int intDesiredLayout_Width = par_imageBadgeCard.Width;

                bool boolRotated = false; //Added 10/14/2019 td  

                image_textStandard =
                    modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementStaticV4,
                         par_elementStaticV4,
                         ref boolRotated, false,
                         par_elementStaticV4);

                if (pboolReturnListOfImages) par_listTextImages.Add(image_textStandard);

                par_elementStaticV4.Image_BL = image_textStandard;

                decimal decScalingFactor = ((decimal)par_imageBadgeCard.Width /
                                             par_elementStaticV4.BadgeLayout.Width_Pixels);

                int intDesignedLeft = par_elementStaticV4.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop = par_elementStaticV4.TopEdge_Pixels;  //Added 10/14/2019 td

                int intDesiredLeft = (int)(intDesignedLeft * decScalingFactor);
                int intDesiredTop = (int)(intDesignedTop * decScalingFactor);

                par_graphics.DrawImage(image_textStandard,
                                   new PointF(intDesiredLeft, intDesiredTop));

                //''---if (par_listFieldsIncluded != null)
                //''---    par_listFieldsIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (InvalidOperationException ex_draw_invalid)
            {
                string strMessage_Invalid = ex_draw_invalid.Message;

                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_invalid.Message + "..." +
                        par_elementStaticV4.Text_StaticLine);

                //if (par_listFieldsNotIncluded != null)
                //    par_listFieldsNotIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (Exception ex_draw_any)
            {
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_any.Message + "..." +
                        par_elementStaticV4.Text_StaticLine);

                //''if (par_listFieldsNotIncluded != null)
                //''    par_listFieldsNotIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }

        }  //End of "AddElementStaticToImageV4







        //    Public Shared Function ResizeImage_ToWidth(ByVal InputImage As Image, ByVal par_intWidth As Integer) As Image
        //    ''
        //    ''Added 7/13/2019 Thomas Downes
        //    ''
        //    Dim intNewHeight As Integer
        //
        //    intNewHeight = CInt(par_intWidth* (InputImage.Height / InputImage.Width))
        //
        //    Return New Bitmap(InputImage, New Size(par_intWidth, intNewHeight))
        //
        //End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

        //Public Shared Function ResizeImage_ToHeight(ByVal InputImage As Image, ByVal pbDummy As Boolean, ByVal par_intHeight As Integer) As Image
        //    ''
        //    ''Added 7/13/2019 Thomas Downes
        //    ''
        //    Dim intNewWidth As Integer
        //
        //    intNewWidth = CInt(par_intHeight* (InputImage.Width / InputImage.Height))
        //
        //    Return New Bitmap(InputImage, New Size(intNewWidth, par_intHeight))
        //
        //End Function ''Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal parSizingBox As Control) As Image

        public Image ResizeImage_WidthAndHeight(Image par_image, int par_intNewWidth, int par_intNewHeight)
        {
            //
            //Example of call: 
            //   ResizeImage_WidthAndHeight(obj_image, par_badge_width_pixels, par_badge_height_pixels);
            //
            const bool c_boolApplyWhiteBackground = true;   //Added 10/14/2019 td 

            // 10/14/2019 td// return new Bitmap(par_image, new Size(par_intNewWidth, par_intNewHeight));

            if (c_boolApplyWhiteBackground)
            {
                Bitmap new_bmp = new Bitmap(par_image, new Size(par_intNewWidth, par_intNewHeight));
                Bitmap white_background = new Bitmap(par_intNewWidth, par_intNewHeight);
                //Graphics gr_white = white_background.grapho
                Graphics gr_white = Graphics.FromImage(white_background);
                gr_white.Clear(Color.White);
                gr_white.DrawImage(new_bmp, 0, 0);
                return white_background;
            }
            else
            {
                return new Bitmap(par_image, new Size(par_intNewWidth, par_intNewHeight));
            }

        }

        public Image ResizeImage_ToHeight(Image par_image, int par_intNewHeight)
        {
            //
            //Example of call: 
            //   ResizeImage_WidthAndHeight(obj_image, par_badge_width_pixels, par_badge_height_pixels);
            //
            decimal dec_proportionsWH = ((decimal)par_image.Width) / ((decimal)par_image.Height);
            int intNewWidth = (int)(((decimal)par_intNewHeight) * dec_proportionsWH);

            return new Bitmap(par_image, new Size(intNewWidth, par_intNewHeight));
        }

        public Image ResizeImage_ToWidth(Image par_image, int par_intNewWidth)
        {
            //
            //Example of call: 
            //   ResizeImage_WidthAndHeight(obj_image, par_badge_width_pixels, par_badge_height_pixels);
            //
            try
            {
                decimal dec_proportionsHW = ((decimal)par_image.Height) / ((decimal)par_image.Width);
                int intNewHeight = (int)(((decimal)par_intNewWidth) * dec_proportionsHW);
                return new Bitmap(par_image, new Size(par_intNewWidth, intNewHeight));
            }
            catch (Exception ex_resize)
            {
                //Added 11/18/2019 td  
                this.Messages += ("_______ " + ex_resize.Message);
                return null;
            }
        }

        private DateTime MaxDateTime(DateTime pdatetime1, DateTime pdatetime2)
        {
            //Added 11/29/2021 td
            if (pdatetime1 >= pdatetime2) return pdatetime1;
            return pdatetime2;
        }


        private Image GetExampleQRCode_IfItsOkay()
        {
            //
            //Added 1/17/2022 thomas downes
            //
            if (mod_cbOkayToUseExampleQRCode)
            {
                return this.ImageQRCode_Example;
            }
            else return null;

        } // End of ""private Image GetExampleQRCode_IfItsOkay()""



    }
}
