using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Was I tired? 10/5/2019 td//using System.Drawing.Image; //''Added 7/17/2019
using System.Drawing.Text; //''Added 7/30/2019
using System.Drawing; //''Added 7/30/2019 td
//---=----Really needed? ---10/5/2019 td
//---=--using System.Windows.Forms; //''Added 10/1/2019 td
using ciBadgeInterfaces; //''Added 8/14/2019 thomas d.
using ciBadgeElements; //''Added 10/1/2019 td

namespace ciBadgeGenerator
{
    //Public Enum EnumImageOrControl
    //    Undetermined
    //    Image
    //    Contl
    //End Enum

    //public enum EnumImageOrControl { Undetermined, Image, Contl}

    public class ClassProportions //10/5/2019 td'' public class ClassElementToImage
    {
        //''
        //''Added 10/5/2019 td
        //''
        //''    Modelled after the proportion functions in ClassLabelToImage, created 7/17/2019
        //''
        //Public Shared UseHighResolutionTips As Boolean = False ''Added 9/8/2019 td

        public static bool UseHighResolutionTips = false;

        public static double LongSideToShortRatio()
        {
            //''
            //''Added 8/26/2019 thomas downes
            //''
            //''The website 
            //''   https://tinyurl.com/yyqyosz3    
            //''    (https://www.identicard.com/store/id-card-and-credentials/standard-id-cards/pvc-and-composite-id-cards-for-custom-id-badges ) 
            //''
            //''says
            //''
            //''    We offer PVC cards in several different sizes and thickness levels, but the most common PVC ID card size
            //''       is CR80/credit card size(2.13" x 3.38").
            //''
            //''My measurements of the PVC card on my desk is:
            //''
            //''       2 1/8 inches by 3 3/8 inches, 
            //''
            //''      or  17/8 inches by  27/8 inches
            //''
            //'' and so leads me to the ratio of 27 to 17.  
            //''
            //''   ------8/26/2019 td 
            //''
            //Return(27 / 17) ''Approx. 1.588, or  3.38 / 2.13

            // 10-8-2019 td// return (27 / 17);  //''Approx. 1.588, or  3.38 / 2.13

            return (27d / 17d);  //''Approx. 1.588, or  3.38 / 2.13

            //End Function ''eDN OF "Public Shared Function LongSideToShortRatio() As Double"

        }  //End of "public static double LongSideToShortRatio()"

        //Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean
        //    ''
        //    ''Added 9/4/2019 thomas downes  
        //    ''
        //    Dim doubleExpectedRatio As Double ''Added 9/6/2019 td
        //    Dim doubleDifference As Double ''Added 9/8/2019 td
        //    Dim doubleDifference_x100 As Double ''Added 9/8/2019 td
        //
        //    ''---9/6/2019 td ''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - LongSideToShortRatio())))
        //
        //    ''Added 9/6/2019 td
        //    doubleExpectedRatio = LongSideToShortRatio()
        //
        //    ''9/6/2019 td''RatioIsLikelyBad = (1 > (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))
        //    ''9/8/2019 td''RatioIsLikelyBad = (1 < (100 * Math.Abs(par_doubleW_div_H - doubleExpectedRatio)))
        //
        //    doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpectedRatio)
        //    doubleDifference_x100 = (100 * doubleDifference)
        //
        //    Dim boolDiffersMoreThanPoint99 As Boolean
        //    Dim boolReturnValue As Boolean
        //
        //    boolDiffersMoreThanPoint99 = (0.99 < doubleDifference_x100)
        //    boolReturnValue = boolDiffersMoreThanPoint99
        //    Return boolReturnValue
        //
        //End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"


        public static bool RatioIsLikelyBad(double par_doubleW_div_H, double par_percentDiffAllowed = 0.99)
        {
            //---- public static bool RatioIsLikelyBad(double par_doubleW_div_H)
            //
            // Modified 11/3/2021 thomas downes
            //
            double doubleExpectedRatio;
            double doubleDifference;
            double doubleDifference_x100;

            doubleExpectedRatio = LongSideToShortRatio();
            doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpectedRatio);
            doubleDifference_x100 = (100 * doubleDifference);

            //----bool boolDiffersMoreThanPoint99 = (0.99 < doubleDifference_x100);
            bool boolDiffersMoreThanPoint99 = (doubleDifference_x100 > par_percentDiffAllowed);
            bool boolReturnValue = boolDiffersMoreThanPoint99;
            return boolReturnValue;

        } // ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"


        //Public Shared Function ProportionsAreSlightlyOff(par_image As Image, pboolVerbose As Boolean,
        //                                             Optional par_strNameOfImage As String = "") As Boolean
        //    ''
        //    ''Added 9/5/2019 thomas downes  
        //    ''
        //    Dim doubleW_div_H As Double
        //
        //    doubleW_div_H = (par_image.Width / par_image.Height)
        //
        //    ''9/6 td''Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, par_strNameOfImage)
        //    Return ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Image, par_strNameOfImage)
        //
        //End Function ''End of "Public Shared Function RatioIsLikelyBad(par_doubleW_div_H As Double) As Boolean"

        public static bool ProportionsAreSlightlyOff(Image par_image, bool pboolVerbose, string par_strNameOfImage = "")
        {
            //    ''
            //    ''Added 10/5/2019 & 9/5/2019 thomas downes  
            //    ''

            // 10-8-2019 td // double doubleW_div_H = (par_image.Width / par_image.Height);
            double doubleW_div_H = ((double)par_image.Width / (double)par_image.Height);

            bool boolReturnValue = ProportionsAreSlightlyOff(doubleW_div_H, pboolVerbose, EnumImageOrControl.Image, par_strNameOfImage);

            return boolReturnValue;

        }


        //Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double, pboolVerbose As Boolean,
        //                                             Optional par_enum As EnumImageOrControl = EnumImageOrControl.Undetermined,
        //                                             Optional par_strImageOrControl As String = "") As Boolean
        //    ''
        //    ''Added 9/5/2019 thomas downes  
        //    ''
        //    Dim strRatioCurrent As String ''Double
        //    Dim strRatioDesired As String ''Double
        //    ''Dim doubleW_div_H As Double
        //    Dim boolRatioIsBad As Boolean
        //    Dim strObjectType As String = ""
        //
        //    boolRatioIsBad = RatioIsLikelyBad(par_doubleW_div_H)
        //
        //    Select Case par_enum
        //        Case EnumImageOrControl.Image : strObjectType = "(image)"
        //        Case EnumImageOrControl.Contl : strObjectType = "(control)"
        //    End Select
        //
        //    If (pboolVerbose And boolRatioIsBad) Then
        //        ''Added 9/6/2019 Thomasd.
        //        strRatioDesired = LongSideToShortRatio().ToString("0.00")
        //        strRatioCurrent = par_doubleW_div_H.ToString("0.00")
        //        MessageBox.Show($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.", "",
        //                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        //    End If ''End of "If (pboolVerbose) Then"
        //
        //    Return boolRatioIsBad
        //
        //End Function ''End of "Public Shared Function ProportionsAreSlightlyOff(par_doubleW_div_H As Double) As Boolean"

        public static bool ProportionsAreSlightlyOff(double par_doubleW_div_H, bool pboolVerbose_ThrowError,
                                                     EnumImageOrControl par_enum = EnumImageOrControl.Undetermined,
                                                     string par_strImageOrControl = "")
        {
            //    ''
            //    ''Added 10/5/2019 & 9/5/2019 thomas downes  
            //    ''
            //    Dim strRatioCurrent As String ''Double
            //    Dim strRatioDesired As String ''Double
            //    ''Dim doubleW_div_H As Double
            //    Dim boolRatioIsBad As Boolean
            //    Dim strObjectType As String = ""

            string strRatioCurrent;
            string strRatioDesired;
            bool boolRatioIsBad;
            string strObjectType = "";

            boolRatioIsBad = RatioIsLikelyBad(par_doubleW_div_H);

            switch (par_enum)
            {
                case EnumImageOrControl.Image: strObjectType = "(image)"; break;
                case EnumImageOrControl.Contl: strObjectType = "(control)"; break;
                default: strObjectType = par_strImageOrControl; break;
            }

            if (pboolVerbose_ThrowError && boolRatioIsBad)
            {
                //
                //''Added 9 / 6 / 2019 Thomasd.
                //
                strRatioDesired = LongSideToShortRatio().ToString("0.00");
                strRatioCurrent = par_doubleW_div_H.ToString("0.00");

                //MessageBox.Show($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.", "",
                //                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                //
                throw new Exception($"Uh-oh, the proportions of {strObjectType} [{par_strImageOrControl}] are {strRatioCurrent} instead of {strRatioDesired}.");
            }

            return boolRatioIsBad;

        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //We won't convert the function above to C# since it references System.Windows.Forms.
        //   Instead, see CIBadgeDesigner.ClassFixTheWidth.  
        //   ---10/5/2019 Thomas D. 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //Public Shared Sub Proportions_FixTheWidth(par_control As Control)
        //    ''
        //    ''Added 9/5/2019 thomas downes  
        //    ''
        //    par_control.Width = CInt(par_control.Height) * LongSideToShortRatio())
        //
        //End Sub ''End of "Public Shared Sub Proportions_FixTheWidth(par_control As Control)"

        public static Image Proportions_FixLayout(Image par_image)
        {
            //
            //Added 11/16/2019 td  
            //
            bool boolAllIsGood;

            boolAllIsGood = (!(ProportionsAreSlightlyOff(par_image, false)));

            if (boolAllIsGood) return par_image;

            if (par_image.Width <= par_image.Height)
            {
                //Orientation is Portrait.  
                return new Bitmap(par_image,
                  new Size(par_image.Width,
                    (int)(par_image.Width * LongSideToShortRatio())));
            }

            return new Bitmap(par_image,
                new Size(par_image.Width,
                (int)(par_image.Width / LongSideToShortRatio())));

        }

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //We won't convert the function above to C# since it references System.Windows.Forms.
        //   ---10/5/2019 Thomas D. 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //We won't convert the function below to C#, since it's not needed.
        //   The image-generating tech was ported to CIElementToImage, and is
        //   called by the following:
        //
        //          image_textStandard =
        //                modGenerate.TextImage_ByElemInfo(intDesiredLayout_Width,
        //                each_elementField, each_elementField, False, False) ''9/20/2019 td'', True)
        //
        //   which is called by 
        //
        //         ciLayoutPrintLib.LayoutElements objPrintLibElems = new LayoutElements();
        //         objPrintLibElems.LoadImageWithElements(ref obj_image_clone_resized, listOfElementTextFields);
        //
        //  The function Public Function TextImage_Field(.....) is obselete. 
        //
        //   ---10/5/2019 Thomas D. 
        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        //Public Function TextImage_Field(pintDesiredLayoutWidth As Integer,
        //                          par_elementInfo_TextFld As IElement_TextField,
        //                          par_elementInfo_Base As IElement_Base,
        //                          ByRef pref_rotated As Boolean,
        //                          ByVal par_bIsDesignStage As Boolean,
        //                          Optional par_pictureBox As PictureBox = Nothing,
        //                          Optional par_graphicalCtl As CtlGraphicFldLabel = Nothing) As Image
        //''
        //''Added 7/17/2019 thomas downes
        //''


        public static bool BackgroundIsDoubleSided(Image par_imageBackground)
        {
            //    ''
            //    ''Added 11/3/2021 thomas downes  
            //    ''
            //    ''Let's check to see if the Background Image is meant to supply
            //    ''   the background for each side--front-side & back-side of the badges. 
            //    ''
            //    ''The left-hand half of the image is for the front side of the badge. 
            //    ''The right-hand half of the image is for the back side of the badge. 
            //    ''
            //double doubleW_div_H = ((double)par_image.Width / (double)par_image.Height);
            //==double halfOfWidth_OneSide = par_imageBackground.Width / (double)(2.0);
            //==double doubleW_div_H = (halfOfWidth_OneSide / (double)par_imageBackground.Height);

            double doubleProportionW_div_H = ((double)par_imageBackground.Width / 
                                    (double)par_imageBackground.Height);

            double doubleProportion_Halved = (doubleProportionW_div_H / (double)2.0);
            //bool bWidthIsDoubleExpected = ProportionsAreDoubleSided(doubleW_div_H);

            bool bHalfWidthIsCorrectRatio = RatioOfSidesWithinRange_1point6(doubleProportion_Halved);
            bool bBackgroundIsDoubleSided = bHalfWidthIsCorrectRatio;
            return bBackgroundIsDoubleSided;

        }


        public static bool RatioOfSidesWithinRange_1point6(double par_doubleW_div_H, 
                                double par_dblRangeEndLow = 1.52, 
                                double par_dblRangeEndHigh = 1.65)
        {
            //    // double par_dblRangeEndLow = 1.55,
            //
            // Added 11/3/2021 thomas 
            //
            double doubleExpectedRatio_1point6;
            //double doubleDifference; 
            //double doubleDifference_x100;

            doubleExpectedRatio_1point6 = LongSideToShortRatio(); // (27d / 17d);  //''Approx. 1.588, or  3.38 / 2.13
            //doubleDifference = Math.Abs(par_doubleW_div_H - doubleExpectedRatio);
            //doubleDifference_x100 = (100 * doubleDifference);

            //----bool boolDiffersMoreThanPoint99 = (0.99 < doubleDifference_x100);
            //---bool boolDiffersMoreThanPoint99 = (doubleDifference_x100 > par_percentDiffAllowed);
            bool boolOkayRangePointLow = (par_doubleW_div_H >= par_dblRangeEndLow);
            bool boolOkayRangePointHigh = (par_doubleW_div_H <= par_dblRangeEndHigh);

            bool boolReturnValue = (boolOkayRangePointLow && boolOkayRangePointHigh);
            return boolReturnValue;

        } // ''End of "Public Shared Function RatioOfSidesWithinRange_1point6"


        public static bool ProportionsAreDoubleSided(Image par_image)
        {
            //    ''
            //    ''Added 11/3/2021 thomas downes  
            //    ''
            return BackgroundIsDoubleSided(par_image);

        }


        public static bool ProportionsAreDoubleSided(double par_doubleW_div_H)
        {
            //    ''
            //    ''Added 11/3/2021 thomas downes  
            //    ''
            //bool boolOneSideIsSlightlyOff = (ProportionsAreSlightlyOff(doubleW_div_H, false, 
            //          EnumImageOrControl.Image, "Parameterized image"));

            double dbHalfOfWidth_div_Height = par_doubleW_div_H / (double)2.0;

            //bool boolOneSideIsSlightlyOff = RatioIsLikelyBad(par_doubleW_div_H, 10);
            bool boolOneSideIsSlightlyOff = RatioIsLikelyBad(dbHalfOfWidth_div_Height, 10);

            bool boolOneSideIsPrettyOkay = (false == boolOneSideIsSlightlyOff);
            bool boolDoublingWontHurt = boolOneSideIsPrettyOkay;
            bool boolImageDisplaysTwoSides = boolDoublingWontHurt;
            return boolImageDisplaysTwoSides;

        }





    }
}
