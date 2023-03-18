Option Strict On
Option Explicit On

Imports System.Drawing
Imports ciBadgeElements
Imports ciBadgeInterfaces

''
''Added 1/13/2022 td 
''
Public Class ClassBadgeSideLayoutV2
    Implements IBadgeSideLayoutElementsV2
    ''
    ''Added 1/13/2022 td 
    ''
    ''   What was my purpose here?  How does V2 differ from V1?
    ''
    ''   What V2 came first in my mind, interface IBadgeSideLayoutElementsV2
    ''     or Class ClassBadgeSideLayoutV2?
    ''
    ''  As of 3/2023, I think I recall the purpose of V2 is to leverage the following
    ''
    ''     Property ElementLists As ClassElementLists ''Added 2/10/2022 thomas downes
    ''
    ''  which replaces the following of V1:  
    ''
    ''     Property ListElementFieldsV3 As HashSet(Of ClassElementFieldV3)
    ''     Property ListElementFieldsV4 As HashSet(Of ClassElementFieldV4)
    ''     Property ListElementStaticTextsV3 As HashSet(Of ClassElementStaticTextV3)
    ''     Property ListElementStaticTextsV4 As HashSet(Of ClassElementStaticTextV4)
    ''     Property ListElementPortraits As HashSet(Of ClassElementPortrait)
    ''     Property ListElementQRCodes As HashSet(Of ClassElementQRCode)
    ''     Property ListElementSignatures As HashSet(Of ClassElementSignature)
    ''     Property ListElementStaticTexts As HashSet(Of ClassElementStaticTextV3)
    ''     Property ListElementGraphics As HashSet(Of ClassElementGraphic)
    ''     Property ListElementLaysections As HashSet(Of ClassElementLaysection)
    ''
    '' ---3/17/2023 td
    ''
    <System.Xml.Serialization.XmlIgnore>
    Public Property BackgroundImage As Image Implements IBadgeSideLayoutElementsV2.BackgroundImage
    Public Property BackgroundImage_Path As String = "" ''Added 1/14/2020 td
    Public Property BackgroundImage_FTitle As String = "" ''Added 1/14/2020 td

    ''Private mod_listElementFields As New HashSet(Of ClassElementFieldV3)
    ''Private mod_listElementPics As New HashSet(Of ClassElementPortrait)
    ''Private mod_listElementStatics As New HashSet(Of ClassElementStaticTextV3)
    ''Private mod_listElementGraphics As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
    ''Private mod_listElementLaysections As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019

    <System.Xml.Serialization.XmlIgnore>
    Public Property RecipientPortrait1 As Image Implements IBadgeSideLayoutElementsV2.RecipientPortrait1

    <System.Xml.Serialization.XmlIgnore>
    Public Property RecipientPortrait2_RarelyUsed As Image Implements IBadgeSideLayoutElementsV2.RecipientPortrait2_RarelyUsed
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As Image)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property

    Public Property par_iRecipientInfo As IRecipient Implements IBadgeSideLayoutElementsV2.par_iRecipientInfo
    ''    Get
    ''        Throw New NotImplementedException()
    ''    End Get
    ''    Set(value As IRecipient)
    ''        Throw New NotImplementedException()
    ''    End Set
    ''End Property


    ''Added 2/10/2022 td
    Public Property ElementLists As ClassElementLists Implements IBadgeSideLayoutElementsV2.ElementLists


    ''
    ''Added 3/05/2023
    ''
    Public Function GetImageForPrinting(par_recipient As IRecipient,
                        par_scaleW As Single,
                        par_scaleH As Single,
                        par_layoutBadgeDims As BadgeLayoutDimensionsClass,
                        Optional pbSkipBackground As Boolean = False) As Image
        ''
        ''This function is prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023
        ''
        ''This code is refactored from C# code of Namespace.Class.Function
        ''  ciBadgeGeneratorCS.ClassMakeBadge2022.MakeBadgeImage_AnySide.
        ''   ---3/07/2023
        ''
        Dim obj_imageOutput As Image ''//;  // Added 1-16-2020 thomas downes
        Dim g As Graphics
        ''Const bool bSkipBackground = (c_bLetsSkipBackground ||
        ''               (par_layoutElements.BackgroundImage Is Nothing)) ''//;

        ''// May20 200 //if (c_bSkipBackground)
        If (pbSkipBackground) Then
            ''{
            ''    //Added 1-16-2020 thomas downes
            obj_imageOutput = New Bitmap(par_layoutBadgeDims.Width_Pixels,
                                         par_layoutBadgeDims.Height_Pixels)
            ''//Added 1-16-2020 thomas downes
            g = Graphics.FromImage(obj_imageOutput)
            g.Clear(Color.White)

            ''End If '' } //End of ""if (bSkipBackground){....}

        Else
            ''//{
            ''//Dec18 2021 td//obj_imageOutput = (Image)par_backgroundImage.Clone();
            ''obj_imageOutput = par_layoutElements.BackgroundImage.Clone() ''//;

            ''    //
            ''    //    obj_image_clone_resized =
            ''    //        LayoutPrint.ResizeBackground_ToFitBox(obj_image, Me.PreviewBox, True)

            Dim obj_image_resized As Image '' = objAssistant.ResizeImage_WidthAndHeight(obj_imageOutput,
            ''  par_newBadge_width_pixels, par_newBadge_height_pixels);
            Dim objImageFromFile As Image

            objImageFromFile = New Bitmap(Me.BackgroundImage_Path)
            obj_image_resized = New Bitmap(objImageFromFile, New Size(par_layoutBadgeDims.Width_Pixels,
                                                                      par_layoutBadgeDims.Height_Pixels))
            ''Bitmap white_background = New Bitmap(par_intNewWidth, par_intNewHeight)
            ''Graphics gr_white = Graphics.FromImage(white_background)
            ''gr_white.Clear(Color.White)
            ''gr_white.DrawImage(obj_image_resized, 0, 0)
            obj_imageOutput = obj_image_resized

            g = Graphics.FromImage(obj_imageOutput)

        End If ''//} //End of ""if (bSkipBackground){....} else {.....}

        ''// 1-15-2020 td //LayoutElements objPrintLibElems = New LayoutElements();
        ''// 12-14-2021 td //LayoutElements objPrintLibElems = New LayoutElements(ClassElementField.iRecipientInfo);
        ''//LayoutElements objPrintLibElems = null;
        ''Dim objPrintLibElems As ciLayoutPrintLib.LayoutElements = Nothing
        ''If (par_iRecipientInfo IsNot Nothing) Then
        ''    objPrintLibElems = New ciLayoutPrintLib.LayoutElements(par_iRecipientInfo)
        ''Else
        ''    objPrintLibElems = New ciLayoutPrintLib.LayoutElements(ClassElementFieldV3.iRecipientInfo)
        ''End If

        ''//Modified 5/29/2022
        ''//objPrintLibElems.LoadImageWithElements(ref obj_imageOutput,
        ''//                                       ref listOfElementFieldsV3,
        ''//                                       ref listOfElementFieldsV4,
        ''//                                       ref hashset_null, False, True,
        ''//                                       ref par_listFieldsIncluded,
        ''//                                       ref par_listFieldsNotIncluded)
        ''objPrintLibElems.LoadImageWithElements(obj_imageOutput,
        ''                                listOfElementFieldsV3,
        ''                                listOfElementFieldsV4,
        ''                                hashset_null, False, True,
        ''                                par_listFieldsIncluded,
        ''                                par_listFieldsNotIncluded)

        ''Added 3/07/2023 thomas downes
        Dim eachImage As Image
        Dim bInvisibleOnBadge As Boolean
        For Each objElementBase As ClassElementBase In Me.ElementLists.ListOfElements_Base()

            Dim pointLocationOnBadge As Point
            bInvisibleOnBadge = True ''Default value.
            eachImage = objElementBase.GetImageForPrinting(par_recipient,
                                                           par_scaleW, par_scaleH,
                                             bInvisibleOnBadge, pointLocationOnBadge)

            If (bInvisibleOnBadge Or (eachImage Is Nothing)) Then
                ''
                ''Skip it, we won't put it on the badge or identity card. 
                ''
            Else
                g.DrawImage(eachImage, pointLocationOnBadge)

            End If

        Next objElementBase
        Return obj_imageOutput

    End Function ''End of "Public Function GetImageForPrinting() As Image"


    ''Public Property ListElementFields As HashSet(Of ClassElementFieldV3) Implements IBadgeSideLayoutElementsV2.ListElementFields
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As HashSet(Of ClassElementField))
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementStaticTexts As HashSet(Of ClassElementStaticTextV3) Implements IBadgeSideLayoutElementsV2.ListElementStaticTexts
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As HashSet(Of ClassElementStaticText))
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementGraphics As HashSet(Of ClassElementGraphic) Implements IBadgeSideLayoutElementsV2.ListElementGraphics
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As HashSet(Of ClassElementGraphic))
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementPortraits As HashSet(Of ClassElementPortrait) Implements IBadgeSideLayoutElementsV2.ListElementPortraits
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As ClassElementPic)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementQRCodes As HashSet(Of ClassElementQRCode) Implements IBadgeSideLayoutElementsV2.ListElementQRCodes
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As ClassElementQRCode)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementSignatures As HashSet(Of ClassElementSignature) Implements IBadgeSideLayoutElementsV2.ListElementSignatures
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As ClassElementSignature)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property ListElementLaysections As HashSet(Of ClassElementLaysection) Implements IBadgeSideLayoutElementsV2.ListElementLaysections
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As ClassElementSignature)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    Public Shared Function CompareRSC(par1 As ClassElementBase, par2 As ClassElementBase) As Integer
        ''
        ''Added 3/18/2023 Thomas  
        ''
        If (par1.ZOrder > par2.ZOrder) Then Return 1
        If (par1.ZOrder < par2.ZOrder) Then Return -1
        Return 0

    End Function ''End of ""Public Shared Function CompareRSC""


    Public Function GetQueueOfAllElements() As Queue(Of ClassElementBase)
        ''
        ''Added 3/18/2023 Thomas  
        ''
        Dim objList As New List(Of ClassElementBase)

        ''3/18/2023 objList.AddRange(ElementLists.ListElementFieldsV3)
        objList.AddRange(ElementLists.ListElementFieldsV4)
        objList.AddRange(ElementLists.ListElementGraphics)
        objList.AddRange(ElementLists.ListElementPortraits)
        ''3/18/2023 objList.AddRange(ElementLists.ListElementStaticsV3)
        objList.AddRange(ElementLists.ListElementStaticsV4)
        objList.AddRange(ElementLists.ListElementQRCodes)
        objList.AddRange(ElementLists.ListElementSignatures)

        ''--++++This is a function & returns a new list. 
        ''--++objList.OrderBy(Function(x) x.ZOrder)

        objList.Sort(Function(x, y) CompareRSC(x, y))
        Return New Queue(Of ClassElementBase)(objList)

    End Function ''End of ""Public Function GetQueueOfAllElements()""


End Class


