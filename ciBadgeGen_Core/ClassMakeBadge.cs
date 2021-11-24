using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
using ciBadgeElements;  //Added 10/5/2019 td
using ciBadgeInterfaces; //Added 10/5/2019 td
using ciBadgeElemImage; //Added 10/14/2019 td  
using ciBadgeRecipients;  //Added 10/16/2019 td 
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


    public class ClassMakeBadge
    {
        public string PathToFile_Sig = ""; //Added 10/12/2019 td
        public string PathToFile_QR = ""; //Added 11/26/2019 td
        public Image ImageQRCode;   //Added 10/14/2019 td 
        public string Messages = ""; //Added 11/18/2019 td 

        public static bool IncludeQR = false; //Added 2/3/2020 thomas d. 
        public static bool IncludeSignature = false;  //Added 2/3/2020 thomas d.

        public Image MakeBadgeImage_ByIRecipient(IBadgeLayout par_layout,
                            Image par_backgroundImage,
                            ClassElementsCache_Deprecated par_cache,
                            int par_badge_width_pixels,
                            int par_badge_height_pixels,
                            ciBadgeInterfaces.IRecipient par_recipient,
                            Image par_recipientPic)
        {
            //
            //Added 11/16/2019 Thomas Downes  
            //

            // 
            //Step #1:  Load the Recipient into the Elements Cache. 
            //
            // 12/2/2019 td //ClassElementField.iRecipientInfo = par_recipient;
            ClassElementField.iRecipientInfo = par_recipient;
            //ClassElementField.oRecipient = par_recipient; //Added 1/15/2020 td

            //
            //Step #2:  Create the image of the badge-card for the above recipient. 
            //
            return MakeBadgeImage(par_layout, par_backgroundImage, par_cache,
                                    par_badge_width_pixels,
                                    par_badge_height_pixels,
                                    par_recipientPic);

        }

        public Image MakeBadgeImage_ByRecipient(IBadgeLayout par_layout,
                                    Image par_backgroundImage,
                                    ClassElementsCache_Deprecated par_cache,
                                    int par_badge_width_pixels,
                                    int par_badge_height_pixels,
                                    ClassRecipient par_recipient,
                                    Image par_recipientPic)
        {
            // 
            //Step #1:  Load the Recipient into the Elements Cache. 
            //
            // 10-16-2019 td// par_cache.LoadRecipient(par_recipient);
            // 11-16-2019 td// ClassElementField.oRecipient = par_recipient;
      
            ClassElementField.oRecipient = par_recipient;
            ClassElementField.iRecipientInfo = par_recipient;   //Added 1/15/2020 thomas d.

            //
            //Step #2:  Create the image of the badge-card for the above recipient. 
            //
            //10-09-2019 td //return MakeBadgeImage(par_backgroundImage, par_cache, par_badge_width_pixels, par_recipientPic);
            return MakeBadgeImage(par_layout, par_backgroundImage, par_cache,
                                    par_badge_width_pixels,
                                    par_badge_height_pixels,
                                    par_recipientPic);

        }

        public Image MakeBadgeImage(IBadgeLayout par_layout,
                                    Image par_backgroundImage,
                                    ClassElementsCache_Deprecated par_cache,
                                    int par_newBadge_width_pixels,
                                    int par_newBadge_height_pixels,
                                    Image par_recipientPic)
        {
            //Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

            //Image obj_imageWithElementFlds; //Added 10/9/2019 td 

            //''Added 9 / 6 / 2019 td
            //    ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")

            par_backgroundImage = 
                ClassProportions.Proportions_FixLayout(par_backgroundImage);
            
            ClassProportions.ProportionsAreSlightlyOff(par_backgroundImage, true, "Background Image");

            // 1-15-2020 td //LayoutElements objPrintLibElems = new LayoutElements();
            LayoutElements objPrintLibElems = new LayoutElements(ClassElementField.iRecipientInfo);

            //    obj_image = Me.BackgroundBox.Image
            //    obj_image_clone = CType(obj_image.Clone(), Image)
            //
            //10-09-2019 td//Image obj_image_clone_resized = (Image)par_backgroundImage.Clone();
            
            const bool c_bSkipBackground = true;  // Added 1-16-2020 thomas downes
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
            HashSet<ClassElementField> listOfElementFields; // <<<<<<<<<<<<<< I have removed the word "Text" from the name.   It's confusing since there are Static-Text controls. --10/17/2019
            listOfElementFields = par_cache.ListFieldElements();

            const bool c_boolUseUntestedProc = false;  // true;  // false;  //Added 10/5/2019 td
            if (c_boolUseUntestedProc)
            {
                //
                // I don't think this procedure (LoadImageWithElement) is fully converted to C# yet. 
                //   If I recall, it's rather long and I was experiencing fatigue from the 
                //   late hour. ---10/9/2019 td
                //
                LoadImageWithElements(ref obj_imageOutput, listOfElementFields);
            }
            else
            {
                objPrintLibElems.LoadImageWithElements(ref obj_imageOutput, listOfElementFields);
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
                ClassElementPic obj_elementPic = par_cache.ListOfElementPics.FirstOrDefault();

                // 10/12/2019 td//objPrintLibElems.LoadImageWithPortrait(par_newBadge_width_pixels,

                Image img_Step3Picture = obj_elementPic.GetStep3_Picture();
                if (img_Step3Picture == null) img_Step3Picture = par_recipientPic;

                LoadImageWithPortrait(img_Step3Picture,
                                        par_newBadge_width_pixels,
                                        par_layout.Width_Pixels,
                                        ref obj_imageOutput,
                                        (IElement_Base)obj_elementPic,
                                        (IElementPic)obj_elementPic); 
                                        //10-18 td  ref par_recipientPic);
            }

            //
            //Added 10/9/2019 thomas d. 
            //
            if (par_cache.MissingTheSignature())
            {
                //
                //There is not any Signature to display.
                //
            }
            else if (ClassMakeBadge.IncludeSignature)
            {
                //
                //Add the Signature. 
                //
                ClassElementSignature obj_elementSig = par_cache.ElementSignature;

                string strPathToSigFile = this.PathToFile_Sig; //Added 10/12/2019 td

                LoadImageWithSignature(par_newBadge_width_pixels,
                                    par_layout.Width_Pixels,
                                    ref obj_imageOutput,
                                    (IElement_Base)obj_elementSig,
                                    (IElementSig)obj_elementSig,
                                    strPathToSigFile);
                                    // 10-12-2019 td //ref par_recipientPic);

            }

            //
            //Added 10/14/2019 thomas d. 
            //
            if (par_cache.MissingTheQRCode())
            {
                //
                //There is not any QR Code to display.
                //
            }
            else if (ClassMakeBadge.IncludeQR)
            {
                //
                //Add the QR Code. 
                //
                ClassElementQRCode obj_elementQR = par_cache.ElementQRCode;

                //string strPathToFile_QR = ""; //this.PathToFile_QR; //Added 10/14/2019 td

                //strPathToFile_QR = obj_elementQR.PathToFile_

                LoadImageWithQRCode(par_newBadge_width_pixels,
                                    par_layout.Width_Pixels,
                                    ref obj_imageOutput,
                                    (IElement_Base)obj_elementQR,
                                    (IElementQRCode)obj_elementQR,
                                    ref this.ImageQRCode);
                // 10-12-2019 td //ref par_recipientPic);

            }

            //
            //Static-Text Elements 
            //
            HashSet<ClassElementStaticText> listOfElementStaticTexts;
            listOfElementStaticTexts = par_cache.ListOfElementTexts;
            LoadImageWithStaticTexts(ref obj_imageOutput, listOfElementStaticTexts);

            // 10-9-2019 td // return null;
            return obj_imageOutput;

        }



        public void LoadImageWithPortrait(Image par_imageStep3Picture,
                         int pintDesiredLayoutWidth,
                         int pintDesignedLayoutWidth,
                         ref Image par_imageBadgeCard,
                         IElement_Base par_elementBase,
                         IElementPic par_elementPic)
        {
            //
            //Added 9/9/2019 thomas d.
            //
            Image imagePortraitResized;
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
                              HashSet<ClassElementStaticText> par_elements,
                              HashSet<Image> par_listTextImages = null)
        {
            //
            //Stubbed 10/14/2019 thomas d. 
            //

        }

        public void LoadImageWithElements(ref Image par_imageBadgeCard,
                                          HashSet<ClassElementField> par_elements,
                                          List<Image> par_listTextImages = null)
        {
            //    ''Added 8/14/2019 td  
            //    ''
            //    Dim gr_Badge As Graphics ''= Graphics.FromImage(img)
            //    Dim intEachIndex As Integer ''Added 8/24/2019 td
            //    Dim bOutputAllImages As Boolean ''Added 8/26/2019 thomas d.

            Graphics gr_Badge;
            int intEachIndex = 0;
            bool bOutputListOfAllImages;
            //string strTextToDisplay = ""; //Added 10/17/2019 thomas d

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
            //    ''
            //    ''9/18/2019 td''For Each each_elementField As IFieldInfo_ElementPositions In par_standardFields
            //    For Each each_elementField As ClassElementField In par_elements

            foreach (ClassElementField each_elementField in par_elements)
            {
                //
                //        intEachIndex += 1

                intEachIndex += 1;

                //Encapsulated 10/17/2019 td  
                AddElementFieldToImage(each_elementField, par_imageBadgeCard,
                       gr_Badge, bOutputListOfAllImages, par_listTextImages);

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

            }

            
            gr_Badge.Dispose();
            
            //End Sub ''End of ''Private Sub LoadImageWithElements()''

        }

        private void AddElementFieldToImage(ClassElementField par_elementField,
                                            Image par_imageBadgeCard,
                                            Graphics par_graphics,
                                            bool pboolReturnListOfImages,
                                            List<Image> par_listTextImages)
        {
            //
            //Encapsulated 10/17/2019 td
            //
            string strTextToDisplay = par_elementField.LabelText_ToDisplay(false);

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
            if (0 > par_elementField.LeftEdge_Pixels) return;

            //                Case(.TopEdge_Pixels< 0) ''Then
            //                  Continue For

            if (0 > par_elementField.TopEdge_Pixels) return;  //10-17 continue;

            //    Case(.LeftEdge_Pixels + .Width_Pixels > par_imageBadgeCard.Width) ''Then 
            //                    ''Continue For

            int intElementsRightEdge = (par_elementField.LeftEdge_Pixels +
                                        par_elementField.Width_Pixels);
            if (intElementsRightEdge > par_imageBadgeCard.Width) return;  //10-17 continue;

            //                Case(.TopEdge_Pixels + .Height_Pixels > par_imageBadgeCard.Height) ''Then 
            //                    ''Continue For

            int intElementsBottomEdge = (par_elementField.TopEdge_Pixels +
                                        par_elementField.Height_Pixels);
            if (intElementsBottomEdge > par_imageBadgeCard.Height) return;  //10-17 continue;


            //            End Select
            //        End With ''End of "With par_elementField"


            //
            //        With par_elementField
            //
            //            Dim image_textStandard As Image

            Image image_textStandard;
            WhyOmitted struct_omitted = new WhyOmitted(); //Added 11/24/2021 td 

            //            ''9/20/2019 td''Dim intLeft As Integer
            //            ''9/20/2019 td''Dim intTop As Integer
            //
            //            ''9/3/2019 td''If(Not.IsDisplayedOnBadge) Then Continue For
            //          If(Not FieldInfo.IsDisplayedOnBadge) Then Continue For

            //Added 10/14/2019 td
            //---if (!(par_elementField.IsDisplayedOnBadge_Visibly())) return;  //10-17 continue;
            if (!(par_elementField.IsDisplayedOnBadge_Visibly(ref struct_omitted))) return;  //10-17 continue;

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
                         par_elementField, par_elementField, ref boolRotated, false);  //''9/20/2019 td'', True)
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

            }
            //            Catch ex_draw_invalid As InvalidOperationException
            catch (InvalidOperationException ex_draw_invalid)
            {
                //                ''Error:  Object not available.
                //                Dim strMessage_Invalid As String
                //                strMessage_Invalid = ex_draw_invalid.Message
                string strMessage_Invalid = ex_draw_invalid.Message;
                throw new Exception("Let's throw the message.", ex_draw_invalid);

                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_Invalid, "10303",
                //                                MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)
            }
            //            Catch ex_draw_any As System.Exception
            catch (Exception ex_draw_any)
            {
                //                ''Error:  Object not available.
                //                Dim strMessage_any As String
                //                strMessage_any = ex_draw_any.Message
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                throw new Exception("Let's throw the message.", ex_draw_any);

                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_any, "99943800",
                //                                MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)
                //            End Try
                //        End With ''End of "With par_elementField"
            }
            //
            //        ''---gr.Dispose()
            //
            //    Next par_elementField
        }



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




    }
}
