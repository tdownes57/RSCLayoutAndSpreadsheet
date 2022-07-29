using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
using ciBadgeElements;  //Added 10/5/2019 td
using ciBadgeInterfaces; //Added 10/5/2019 td
using ciBadgeElemImage; //Added 10/14/2019 td  
using ciBadgeRecipients;  //Added 10/16/2019 td 
//using ciBadgeCachingPersonality;  //Added 12/4/2021 td 
using ciBadgeCachePersonality; //Added 12/4/2021 td
using ciBadgeFields;  //Added 5/11/2022 td
//Feb10 2022 //using System.Linq;

//
// Added 2/10/2022 thomas d. 
//

namespace ciBadgeGenerator
{
    class ClassMakeBadgeV4_NotUsed
    {
        //
        // Added 2/10/2022 thomas d. 
        //
        public static bool OmitOutlyingElements = false;  // true; // Added 11/10/2021 td

        private void AddElementFieldToImageV4(ClassElementFieldV4 par_elementField,
                                    ClassFieldAny par_field,
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
            string strTextToDisplay = par_elementField.LabelText_ToDisplay(false, par_iRecipientInfo, false);

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
                    par_listFieldsNotIncluded
                        //.Add(par_elementField.FieldNm_CaptionText()
                        .Add(par_elementField.FieldNameCaptionText()
                        + " - LeftEdge < 0"); 
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
                    // 5-11-2022 ''par_listFieldsNotIncluded
                    //''    .Add(par_elementField.FieldNm_CaptionText() + " - TopEdge < 0");
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldEnum.ToString() + " - TopEdge < 0");
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
                    par_listFieldsNotIncluded
                        //.Add(par_elementField.FieldNm_CaptionText()
                        .Add(par_elementField.FieldNameCaptionText()
                         + " - RightEdge > BadgeWidth"); 
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
                { par_listFieldsNotIncluded.Add(par_elementField.FieldNameCaptionText() + " - BottomEdge > BadgeHeight"); }

            }

            Image image_textStandard;
            if (structWhyOmittedV2.__Omitted)
            {
                //Added 11/9/2021 td
                if (par_listFieldsNotIncluded != null)
                {
                    // Added 5/11/2022 td 
                    string strDataEntry = par_field.DataEntryText;

                    par_listFieldsNotIncluded.Add(par_elementField.FieldEnum.ToString()
                        + $"  - (\"{strDataEntry}\") "
                        + " since !IsDisplayedOnBadge_Visibly(). "
                        + structWhyOmittedV1.OmitFieldMsg()
                        + structWhyOmittedV1.OmitElementMsg());
                }

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
                //  5/11/2022 par_elementField.FieldInfo.CIBadgeField);

            }

            try
            {
                int intDesiredLayout_Width = par_imageBadgeCard.Width;
                bool boolRotated = false; //Added 10/14/2019 td  
                image_textStandard =
                       modGenerate.TextImage_ByElemInfo(strTextToDisplay, intDesiredLayout_Width,
                         par_elementField, par_elementField, ref boolRotated, false, par_elementField);

                if (pboolReturnListOfImages) par_listTextImages.Add(image_textStandard);

                par_elementField.Image_BL = image_textStandard;

                decimal decScalingFactor = ((decimal)par_imageBadgeCard.Width /
                                             par_elementField.BadgeLayout.Width_Pixels);

                int intDesignedLeft = par_elementField.LeftEdge_Pixels;  //Added 10/14/2019 td 
                int intDesignedTop = par_elementField.TopEdge_Pixels;  //Added 10/14/2019 td
                int intDesiredLeft = (int)(intDesignedLeft * decScalingFactor);
                int intDesiredTop = (int)(intDesignedTop * decScalingFactor);

                par_graphics.DrawImage(image_textStandard,
                                   new PointF(intDesiredLeft, intDesiredTop));

                if (par_listFieldsIncluded != null)
                    par_listFieldsIncluded.Add(par_elementField.FieldEnum.ToString());
                //   par_listFieldsIncluded.Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (InvalidOperationException ex_draw_invalid)
            {
                string strMessage_Invalid = ex_draw_invalid.Message;

                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_invalid.Message + 
                        "..." + par_elementField.FieldEnum.ToString());
                //      "..." + par_elementField.FieldInfo.CIBadgeField);

                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldEnum.ToString());
                // 5/2022 td  .Add(par_elementField.FieldInfo.CIBadgeField);

            }
            catch (Exception ex_draw_any)
            {
                string strMessage_any;
                strMessage_any = ex_draw_any.Message;
                if (par_listMessages != null)
                    par_listMessages.Add(ex_draw_any.Message + "..." + 
                        par_elementField.FieldEnum.ToString());
                // 5-11-2022  par_elementField.FieldInfo.CIBadgeField);

                if (par_listFieldsNotIncluded != null)
                    par_listFieldsNotIncluded
                        .Add(par_elementField.FieldEnum.ToString());
                        // 5-11-2022  .Add(par_elementField.FieldInfo.CIBadgeField);

            }
        }

    }



}

