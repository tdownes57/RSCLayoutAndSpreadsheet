Option Explicit On
Option Strict On
Option Infer Off
''
''Added 9/16/2019 thomas downes
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
''9/19/2019 td''Imports ciLayoutPrintLib ''Added 9/18/2019 td 

<Serializable>
Public Class ClassElementsCache
    ''
    ''Added 9/16/2019 thomas downes
    ''
    Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 

    Public Property SaveToXmlPath As String ''Added 9/29/2019 td

    Private mod_listFields As New List(Of ClassFieldAny) ''Added 9/18/2019 td  
    Private mod_listElementFields As New List(Of ClassElementField)
    Private mod_listElementPics As New List(Of ClassElementPic)
    Private mod_listElementStatics As New List(Of ClassElementStaticText)
    Private mod_listElementLaysections As New List(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes

    Public Property ListOfFields As List(Of ClassFieldAny)
        Get ''Added 9/28/2019 td
            Return mod_listFields
        End Get
        Set(value As List(Of ClassFieldAny))
            ''Added 9/28/2019 td
            mod_listFields = value
        End Set
    End Property

    Public Property ListOfElementFields As List(Of ClassElementField)
        Get ''Added 9/28/2019 td
            Return mod_listElementFields
        End Get
        Set(value As List(Of ClassElementField))
            ''Added 9/28/2019 td
            mod_listElementFields = value
        End Set
    End Property

    Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Property Pic_InitialDefault As Image ''Added 9/23/2019 td 

    Public Function ListFields() As List(Of ClassFieldAny)
        ''
        ''Added 9/19/2019 thomas downes
        ''
        Return mod_listFields

    End Function ''End of "Public Function Fields() As List(Of ClassFieldAny)"

    Public Function ListFieldElements() As List(Of ClassElementField)
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementFields

    End Function ''End of "Public Function FieldElements() As List(Of ClassElementText)"

    Public Function PicElement() As ClassElementPic
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementPics(0)

    End Function ''End of "Public Function PicElement() As ClassElementPic"

    Public Function ListPicElements() As List(Of ClassElementPic)
        ''
        ''Added 9/17/2019 thomas downes
        ''
        Return mod_listElementPics

    End Function ''End of " Public Function ListPicElements() As List(Of ClassElementPic)"

    Public Function ListStaticTextElements() As List(Of ClassElementStaticText)
        ''
        ''Added 9/16/2019 thomas downes
        ''
        Return mod_listElementStatics

    End Function ''End of "Public Function ListStaticTextElements() As List(Of ClassElementStaticText)"

    Public Function LaysectionElements() As List(Of ClassElementLaysection)
        ''
        ''Added 9/17/2019 thomas downes
        ''
        Return mod_listElementLaysections

    End Function ''End of "Public Function StaticTextElements() As List(Of ClassElementStaticText)"

    Public Sub LoadFields()
        ''
        ''Added 9/18/2019 td
        ''
        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 1 of 2.  Initialize the lists. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Initialize the list) 
        ''
        ClassFieldStandard.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Initialize the list)  
        ''
        ClassFieldCustomized.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''
        ''End of "Part 1 of 2.  Initialize the lists." 
        ''
        ''----------------------------------------------------------------------------------------------------

        ''
        ''Part 2 of 2.  Collect the list items. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Collect the list items)  
        ''
        For Each each_field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            mod_listFields.Add(each_field_standard)

        Next each_field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Customized Fields (Collect the list items)  
        ''
        For Each each_field_customized As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            mod_listFields.Add(each_field_customized)

        Next each_field_customized
        ''----------------------------------------------------------------------------------------------------

    End Sub ''End of "Public Sub LoadFields(par_pictureBackground As PictureBox)"

    Public Sub LoadFieldElements(par_pictureBackground As PictureBox)
        ''
        ''Added 9/16/2019 thomas d. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 1 of 2.  Initialize the lists. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Initialize the list) 
        ''
        ''Moved to Public Sub LoadFields.---9/18 td''ClassFieldStandard.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Initialize the list)  
        ''
        ''Moved to Public Sub LoadFields.---9/18 td''ClassFieldCustomized.InitializeHardcodedList_Students(True)

        ''----------------------------------------------------------------------------------------------------
        ''
        ''End of "Part 1 of 2.  Initialize the lists." 
        ''
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''
        ''Part 2 of 2.  Collect the list items. 
        ''
        ''----------------------------------------------------------------------------------------------------
        ''Standard Fields (Collect the list items)  
        ''
        ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

        ''    mod_listElementFields.Add(field_standard.ElementFieldClass)

        ''    ''Added 9/16/2019 td  
        ''    field_standard.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

        ''Next field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Custom Fields (Collect the list items) 
        ''
        ''For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

        ''    mod_listElementFields.Add(field_custom.ElementFieldClass)

        ''    ''Added 9/16/2019 td  
        ''    field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

        ''Next field_custom
        ''----------------------------------------------------------------------------------------------------

        Dim new_elementField As ClassElementField ''Added 9/18/2019 td
        Dim intFieldIndex As Integer ''Added 9/18/2019 td
        Dim intLeft_Pixels As Integer ''Added 9/18/2019 td
        Dim intTop_Pixels As Integer ''Added 9/18/2019 td
        Const c_intHeight_Pixels As Integer = 30 ''Added 9/18/2019 td

        ''Added 9/18/2019 td
        For Each each_field As ClassFieldAny In mod_listFields

            ''Fields cannot link to elements.---9/18/2019 td''mod_listElementFields.Add(each_field.ElementFieldClass)

            ''Added 9/16/2019 td  
            ''Fields cannot link to elements.---9/18/2019 td''field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

            intFieldIndex += 1
            ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = (c_intHeight_Pixels * (intFieldIndex - 1))
            intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

            ''Added 9/18/2019 td
            new_elementField = New ClassElementField(each_field, intLeft_Pixels, intTop_Pixels, c_intHeight_Pixels)
            new_elementField.FieldInfo = each_field

            ''Added 9/19/2019 td
            mod_listElementFields.Add(new_elementField)

        Next each_field

    End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As PictureBox)"

    Public Sub LoadPicElement(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
        ''
        ''Added 9/16/2019 td  
        ''
        Dim objElementPic As ClassElementPic ''Added 9/16/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        intLeft = par_intLeft ''9/19 td''(par_picturePortrait.Left - par_pictureBackground.Left)
        intTop = par_intTop ''9/19 td''(par_picturePortrait.Top - par_pictureBackground.Top)

        ''9/19/2019 td''objRectangle = New Rectangle(intLeft, intTop, par_picturePortrait.Width, par_picturePortrait.Height)
        objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

        objElementPic = New ClassElementPic(objRectangle, par_pictureBackground)

        objElementPic.PicFileIndex = 1

        mod_listElementPics.Add(objElementPic)

    End Sub ''End of "Public Sub LoadPicElement(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"

    Public Sub LoadPicElement(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)
        ''
        ''Added 9/16/2019 td  
        ''
        Dim objElementPic As ClassElementPic ''Added 9/16/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        intLeft = (par_picturePortrait.Left - par_pictureBackground.Left)
        intTop = (par_picturePortrait.Top - par_pictureBackground.Top)

        objRectangle = New Rectangle(intLeft, intTop, par_picturePortrait.Width, par_picturePortrait.Height)

        objElementPic = New ClassElementPic(objRectangle, par_pictureBackground)

        objElementPic.PicFileIndex = 1

        mod_listElementPics.Add(objElementPic)

    End Sub ''End of "Public Sub LoadPicElement(par_pictureBackground As PictureBox)"

    Public Sub LoadRecipient(par_recipient As IRecipient)
        ''
        ''Added 10/5/2019 thomas downwe
        ''
        For Each each_elementField As ClassElementField In ListOfElementFields
            ''
            ''Attach the Recipient.  
            ''
            each_elementField.Recipient = par_recipient

        Next each_elementField

    End Sub ''End of "Public Sub LoadRecipient(par_recipient As IRecipient)"

    Public Function Copy() As ClassElementsCache
        ''
        ''Added 9/17/2019 thomas downes  
        ''
        Dim objCopyOfCache As New ClassElementsCache
        Dim ListFields_NotUsed As New List(Of ClassFieldAny)
        Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)
        Dim copy_ofField As ClassFieldAny
        Dim copy_ofElementField As ClassElementField ''Added 10/1/2019 td

        ''Added 9/29/2019 thomas downes  
        For Each each_field As ClassFieldAny In mod_listFields
            ''9/29/2019 td''objCopyOfCache.ListFields().Add(each_field.Copy())
            copy_ofField = each_field.Copy()
            objCopyOfCache.ListFields().Add(copy_ofField)
            ListFields_NotUsed.Add(copy_ofField)
            dictionaryFields.Add(copy_ofField.FieldEnumValue, copy_ofField)
        Next each_field

        ''Added 9/17/2019 thomas downes  
        For Each each_elementField As ClassElementField In mod_listElementFields
            ''
            ''Add a copy of the element-field.
            ''
            ''10/011/2019 td''objCopyOfCache.ListFieldElements().Add(each_elementField.Copy())

            copy_ofElementField = each_elementField.Copy()

            ''
            ''I need to utilize the dictionary object to fix the field reference of the 
            ''  copied element. -----9/229/2019 td 
            ''
            ''10/1/2019 td''Throw New NotImplementedException("Fix the field reference!")

            dictionaryFields.TryGetValue(each_elementField.FieldInfo.FieldEnumValue, copy_ofElementField.FieldObject)

            objCopyOfCache.ListFieldElements().Add(copy_ofElementField)

        Next each_elementField

        ''Added 9/17/2019 thomas downes  
        For Each each_elementPic As ClassElementPic In mod_listElementPics
            objCopyOfCache.ListPicElements().Add(each_elementPic.Copy())
        Next each_elementPic

        ''Added 9/17/2019 thomas downes  
        For Each each_elementStaticText As ClassElementStaticText In mod_listElementStatics
            objCopyOfCache.ListStaticTextElements().Add(each_elementStaticText.Copy())
        Next each_elementStaticText

        Return objCopyOfCache

    End Function ''End of "Public Function Copy() As ClassElementsCache"

    Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField
        ''
        ''Added 9/30/2019 td  
        ''



    End Function ''End of "Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField"

    ''Private Sub LoadElements_Picture()
    ''    ''
    ''    ''Added 7/31/2019 thomas downes 
    ''    ''
    ''    ''7/31 td''Dim new_picControl As CtlGraphicPortrait ''Added 7/31/2019 td  

    ''    ''Added 8/22/2019 THOMAS D.
    ''    ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

    ''    If (ClassElementPic.ElementPicture Is Nothing) Then

    ''        ClassElementPic.ElementPicture = New ClassElementPic

    ''        With ClassElementPic.ElementPicture

    ''            .Width = CtlGraphicPortrait_Lady.Width
    ''            .Height = CtlGraphicPortrait_Lady.Height

    ''            .TopEdge = CtlGraphicPortrait_Lady.Top
    ''            .LeftEdge = CtlGraphicPortrait_Lady.Left

    ''            ''Added 8/12/2019 td
    ''            Dim bSwitchWidthHeight As Boolean ''Added 8/12/2019 td
    ''            bSwitchWidthHeight = ("L" = ClassElementPic.ElementPicture.OrientationToLayout)

    ''            ''Added 8/12/2019 td
    ''            ''Switch width & height.  
    ''            If (bSwitchWidthHeight) Then
    ''                ''Switch width & height.  
    ''                .Width = CtlGraphicPortrait_Lady.Height
    ''                .Height = CtlGraphicPortrait_Lady.Width
    ''            End If ''End of "If (bSwitchWidthHeight) Then"

    ''            ''Added 9/13/2019 td 
    ''            .BadgeLayout = New BadgeLayoutClass(pictureBack.Width, pictureBack.Height)

    ''        End With ''End of "With field_standard.ElementInfo"

    ''    End If ''End of "If (ClassElementPic.ElementPicture Is Nothing) Then"

    ''    ''#1 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture)
    ''    '' #2 7/31/2019 td''new_picControl = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
    ''    ''      CType(ClassElementPic.ElementPicture, IElementPic))
    ''    '' #2 7/31/2019 td''Me.Controls.Add(new_picControl)

    ''    ''
    ''    ''DIFFICULT & CONFUSING.....  Let's regenerate the control referenced above.  
    ''    ''
    ''    CtlGraphicPortrait_Lady = New CtlGraphicPortrait(ClassElementPic.ElementPicture,
    ''                                             CType(ClassElementPic.ElementPicture, IElementPic), Me)

    ''    Me.Controls.Add(CtlGraphicPortrait_Lady)

    ''    With CtlGraphicPortrait_Lady

    ''        .Top = ClassElementPic.ElementPicture.TopEdge
    ''        .Left = ClassElementPic.ElementPicture.LeftEdge
    ''        .Width = ClassElementPic.ElementPicture.Width
    ''        .Height = ClassElementPic.ElementPicture.Height

    ''        ''Added 8/18/2019 td
    ''        .picturePortrait.Image = mod_imageLady

    ''    End With ''End of "With CtlGraphicPortrait1"

    ''End Sub ''End of " Private Sub LoadElements_Picture()"


End Class
