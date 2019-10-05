using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;   //Added 10/5/2019 td
using ciLayoutPrintLib; //Added 10/5/2019 td
using ciBadgeElements;  //Added 10/5/2019 td

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
        public Image MakeBadgeImage(Image par_backgroundImage, ClassElementsCache par_cache)
        {
            //Dim objPrintLibElems As New ciLayoutPrintLib.LayoutElements

            //''Added 9 / 6 / 2019 td
            ClassLabelToImage.ProportionsAreSlightlyOff(par_backgroundImage, true, "Background Image");

            LayoutElements objPrintLibElems = new LayoutElements();

            Image obj_image_clone_resized = (Image)par_backgroundImage.Clone();

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

            objPrintLibElems.LoadImageWithElements(ref obj_image_clone_resized, listOfElementTextFields);




            //''
            //''Major call, let's show the portrait !!  ---9/9/2019 td  
            //''
            objPrintLibElems.LoadImageWithPortrait(obj_image_clone_resized.Width,
                                              Me.Layout_Width_Pixels(),
                                              obj_image_clone_resized,
                                               CtlGraphicPortrait_Lady.ElementInfo_Base,
                                               CtlGraphicPortrait_Lady.ElementInfo_Pic,
                                              CtlGraphicPortrait_Lady.picturePortrait.Image);




        }


    }
}
