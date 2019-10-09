using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
using ciBadgeElements;  //Added 10/5/2019 td
using ciBadgeInterfaces; //Added 10/5/2019 td

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
        public Image MakeBadgeImage_ByRecipient(Image par_backgroundImage, 
                                    ClassElementsCache par_cache,
                                    int par_badge_width_pixels,
                                    IRecipient par_recipient, 
                                    Image par_recipientPic)
        {
            //
            //Step #1:  Load the Recipient into the Elements Cache. 
            //
            par_cache.LoadRecipient(par_recipient);

            //
            //Step #2:  Create the image of the badge-card for the above recipient. 
            //
            return MakeBadgeImage(par_backgroundImage, par_cache, par_badge_width_pixels, par_recipientPic);

        }

        public Image MakeBadgeImage(Image par_backgroundImage, ClassElementsCache par_cache, 
                                    int par_badge_width_pixels, Image par_recipientPic)
        {
            //Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

            //Image obj_imageWithElementFlds; //Added 10/9/2019 td 

            //''Added 9 / 6 / 2019 td
            ClassProportions.ProportionsAreSlightlyOff(par_backgroundImage, true, "Background Image");

            LayoutElements objPrintLibElems = new LayoutElements();

            //10-09-2019 td//Image obj_image_clone_resized = (Image)par_backgroundImage.Clone();
            Image obj_image = (Image)par_backgroundImage.Clone();

            //    ClassLabelToImage.ProportionsAreSlightlyOff(Me.BackgroundBox.Image, True, "Background Image")
            //
            //    obj_image = Me.BackgroundBox.Image
            //    obj_image_clone = CType(obj_image.Clone(), Image)
            //
            //    obj_image_clone_resized =
            //        LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)
            //
            //    Dim listOfElementTextFields As List(Of ClassElementField)
            //    listOfElementTextFields = Me.ElementsCache_Edits.ListFieldElements()

            List<ClassElementField> listOfElementTextFields;
            listOfElementTextFields = par_cache.ListFieldElements();

            const bool c_boolUseUntestedProc = false;  // true;  // false;  //Added 10/5/2019 td
            if (c_boolUseUntestedProc)
            {
                //
                // I don't think this procedure (LoadImageWithElement) is fully converted to C# yet. 
                //   If I recall, it's rather long and I was experiencing fatigue from the 
                //   late hour. ---10/9/2019 td
                //
                LoadImageWithElements(ref obj_image, listOfElementTextFields);
            }
            else
            {
                objPrintLibElems.LoadImageWithElements(ref obj_image, listOfElementTextFields);
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
                //                                    par_badge_width_pixels,
                //                                    ref obj_image,
                //                                    local_PicElementInfo_Base,
                //                                    local_PicElementInfo_Pic,
                //                                    ref par_recipientPic);
            }
            else
            {
                //
                //Added 10/9/2019 thomas d. 
                //
                ClassElementPic obj_elementPic = par_cache.ListPicElements()[0];

                objPrintLibElems.LoadImageWithPortrait(obj_image.Width,
                                                    par_badge_width_pixels,
                                                    ref obj_image,
                                                    (IElement_Base)obj_elementPic,
                                                    (IElementPic)obj_elementPic,
                                                    ref par_recipientPic);
            }

            // 10-9-2019 td // return null;
            return obj_image;  

        }

        //Public Sub LoadImageWithElements(ByRef par_imageBadgeCard As Image,
        //                           par_elements As List(Of ClassElementField),
        //                                Optional par_listTextImages As List(Of Image) = Nothing)
        //    ''9/18/2019 td---Public Sub LoadImageWithFieldValues(ByRef par_imageBadgeCard As Image,
        //    ''---                                par_standardFields As List(Of IFieldInfo_ElementPositions),
        //    ''---                                par_customFields As List(Of IFieldInfo_ElementPositions),
        //    ''---                                     Optional par_listTextImages As List(Of Image) = Nothing)        

        public void LoadImageWithElements(ref Image par_imageBadgeCard,
                                          List<ClassElementField> par_elements,
                                          List<Image> par_listTextImages = null)
        {
            //    ''Added 8/14/2019 td  
            //    ''
            //    Dim gr_Badge As Graphics ''= Graphics.FromImage(img)
            //    Dim intEachIndex As Integer ''Added 8/24/2019 td
            //    Dim bOutputAllImages As Boolean ''Added 8/26/2019 thomas d.

            Graphics gr_Badge;
            int intEachIndex = 0;
            bool bOutputAllImages;

            //
            //    ''9/8/2019 thomas d.
            //    ProportionsAreSlightlyOff(par_imageBadgeCard, True, "par_imageBadgeCard")

            ClassProportions.ProportionsAreSlightlyOff(par_imageBadgeCard, true, "par_imageBadgeCard");

            //
            //    bOutputAllImages = (par_listTextImages IsNot Nothing) ''Added 8/26/2019 thomas d.

            bOutputAllImages = (par_listTextImages == null);

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

                //
                //        ''9/3/2019 td''If (not each_elementField.IsDiplayedOnBadge) Then Continue for
                //
                //        ''
                //        ''Added 8/24/2019 thomas d.
                //        ''
                //        ''9/18 td''With each_elementField.Position_BL
                //
                //        With each_elementField
                //
                //            Select Case True
                //                Case (.LeftEdge_Pixels< 0)
                //                  Continue For

                if (0 > each_elementField.LeftEdge_Pixels) continue;

                //                Case(.TopEdge_Pixels< 0) ''Then
                //                  Continue For

                if (0 > each_elementField.TopEdge_Pixels) continue;

                //              Case(.LeftEdge_Pixels + .Width_Pixels > par_imageBadgeCard.Width) ''Then 
                //                    ''Continue For

                int intElementsRightEdge = (each_elementField.LeftEdge_Pixels + 
                                            each_elementField.Width_Pixels);
                if (intElementsRightEdge > par_imageBadgeCard.Width) continue;

                //                Case(.TopEdge_Pixels + .Height_Pixels > par_imageBadgeCard.Height) ''Then 
                //                    ''Continue For

                int intElementsBottomEdge = (each_elementField.TopEdge_Pixels +
                                            each_elementField.Height_Pixels);
                if (intElementsBottomEdge > par_imageBadgeCard.Height) continue;


                //            End Select
                //        End With ''End of "With each_elementField"


                //
                //        With each_elementField
                //
                //            Dim image_textStandard As Image
                //            ''9/20/2019 td''Dim intLeft As Integer
                //            ''9/20/2019 td''Dim intTop As Integer
                //
                //            ''9/3/2019 td''If(Not.IsDisplayedOnBadge) Then Continue For
                //          If(Not.FieldInfo.IsDisplayedOnBadge) Then Continue For
                //
                //            ''Added 9/4/2019 thomas downes
                //            ''9/12/2019 td''If(0 = .Position_BL.LayoutWidth_Pixels) Then
                //           If(0 = .Width_Pixels) Then
                //                ''Added 9/4/2019 thomas downes
                //                MessageBox.Show("We cannot scale the placement of the image.", "LayoutPrint_Redux",
                //                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                //            End If ''ENd of "If (0 = .Position_BL.BadgeLayout.Width_Pixels) Then"
                //
                //            Try
                //                ''gr.DrawImage(.TextDisplay.GenerateImage(.Position_BL.Height_Pixels),
                //                ''   .Position_BL.LeftEdge_Pixels, .Position_BL.TopEdge_Pixels,
                //                ''   .Position_BL.Width_Pixels, .Position_BL.Height_Pixels)
                //
                //                ''#1 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage(.Position_BL.Height_Pixels)
                //                '' #2 8/26/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByHeight(.Position_BL.Height_Pixels)
                //
                //                ''9/5/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(par_imageBadgeCard.Width)
                //                ''9/8/2019 td''image_textStandard = .TextDisplay.GenerateImage_ByDesiredLayoutWidth(each_elementField.BadgeLayout_Width)
                //
                //                Dim intDesiredLayout_Width As Integer ''added 9/8/2019 td
                //                intDesiredLayout_Width = par_imageBadgeCard.Width
                //
                //                ''9/19/2019 td''image_textStandard =
                //                ''9/19/2019 td''    .TextDisplay.GenerateImage_ByDesiredLayoutWidth(intDesiredLayout_Width)
                //
                //                image_textStandard =
                //                    modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
                //                        each_elementField, each_elementField, False, False) ''9/20/2019 td'', True)
                //
                //                If(bOutputAllImages) Then par_listTextImages.Add(image_textStandard) ''Added 8/26/2019 td
                //
                //                ''8/30/2019 td''.TextDisplay.Image_BL = image_textStandard ''Added 8/27/2019 td
                //                ''9/19/2019 td''.Position_BL.Image_BL = image_textStandard ''Added 8/27/2019 td
                //                .Image_BL = image_textStandard ''Added 8/27/2019 td
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
                //                decScalingFactor = (par_imageBadgeCard.Width / each_elementField.BadgeLayout.Width_Pixels)
                //
                //                Dim intDesignedLeft As Integer ''Designed = layout pre-production = The Left value when designed via the Layout Designer tool. --9/20
                //                Dim intDesignedTop As Integer ''Designed = layout pre-production = The Top value when designed via the Layout Designer tool.  --9/20
                //                Dim intDesiredLeft As Integer ''Desired = preview / print / production = The Left value on the print/preview version of the badge.  --9/20
                //                Dim intDesiredTop As Integer ''Desired = preview / print / production = The Top value on the print/preview version of the badge.  --9/20
                //
                //                intDesignedLeft = .LeftEdge_Pixels
                //                intDesignedTop = .TopEdge_Pixels
                //
                //                intDesiredLeft = CInt(intDesignedLeft * decScalingFactor)
                //                intDesiredTop = CInt(intDesignedTop * decScalingFactor)
                //
                //                gr_Badge.DrawImage(image_textStandard,
                //                             New PointF(intDesiredLeft, intDesiredTop))
                //
                //            Catch ex_draw_invalid As InvalidOperationException
                //                ''Error:  Object not available.
                //                Dim strMessage_Invalid As String
                //                strMessage_Invalid = ex_draw_invalid.Message
                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_Invalid, "10303",
                //                                MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)
                //            Catch ex_draw_any As System.Exception
                //                ''Error:  Object not available.
                //                Dim strMessage_any As String
                //                strMessage_any = ex_draw_any.Message
                //                ''Added 8/24 thomas d.
                //                MessageBox.Show(strMessage_any, "99943800",
                //                                MessageBoxButtons.OK,
                //                                MessageBoxIcon.Exclamation)
                //            End Try
                //        End With ''End of "With each_elementField"
                //
                //        ''---gr.Dispose()
                //
                //    Next each_elementField

            }


            //
            //    gr_Badge.Dispose()
            //
            //End Sub ''End of ''Private Sub LoadImageWithElements()''

        }




    }
}
