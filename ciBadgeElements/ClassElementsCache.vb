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

    ''10/10/2019 td''Public Property SaveToXmlPath As String ''Added 9/29/2019 td
    Public Property PathToXml_Saved As String ''Added 9/29/2019 td

    Public Property ElementQRCode As ClassElementQRCode ''Added 10/8/2019 thomas d.  
    Public Property ElementSignature As ClassElementSignature ''Added 10/8/2019 thomas d.  

    ''10/14/2019 td''Private mod_listFields As New List(Of ClassFieldAny) ''Added 9/18/2019 td  
    Private mod_listFields_Standard As New List(Of ClassFieldStandard) ''Added 10/14/2019 td  
    Private mod_listFields_Custom As New List(Of ClassFieldCustomized) ''Added 10/14/2019 td  

    Private mod_listElementFields As New List(Of ClassElementField)
    Private mod_listElementPics As New List(Of ClassElementPic)
    Private mod_listElementStatics As New List(Of ClassElementStaticText)
    Private mod_listElementLaysections As New List(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes

    ''10/14/2019 td''Public Property ListOfFields As List(Of ClassFieldAny)
    ''    Get ''Added 9/28/2019 td
    ''        Return mod_listFields
    ''    End Get
    ''    Set(value As List(Of ClassFieldAny))
    ''        ''Added 9/28/2019 td
    ''        mod_listFields = value
    ''    End Set
    ''End Property

    Public Function ListOfFields_Any() As List(Of ClassFieldAny)
        ''
        ''Added 10/14/2019 thomas downes
        ''
        Dim obj_list As New List(Of ClassFieldAny)
        obj_list.AddRange(ListOfFields_Standard)
        obj_list.AddRange(ListOfFields_Custom)
        Return obj_list

    End Function ''End of "Public Function ListOfFields_Any() As List(Of ClassFieldAny)"

    Public Property ListOfFields_Standard As List(Of ClassFieldStandard)
        Get ''Added 10/14/2019 td
            Return mod_listFields_Standard
        End Get
        Set(value As List(Of ClassFieldStandard))
            ''Added 10/14/2019 td td
            mod_listFields_Standard = value
        End Set
    End Property

    Public Property ListOfFields_Custom As List(Of ClassFieldCustomized)
        Get ''Added 10/14/2019 td
            Return mod_listFields_Custom
        End Get
        Set(value As List(Of ClassFieldCustomized))
            ''Added 10/14/2019 td td
            mod_listFields_Custom = value
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

    Public Property ListOfElementPics As List(Of ClassElementPic)
        Get ''Added 10/13/2019 td
            Return mod_listElementPics
        End Get
        Set(value As List(Of ClassElementPic))
            ''Added 10/13/2019 td
            mod_listElementPics = value
        End Set
    End Property

    Public Property ListOfElementTexts As List(Of ClassElementStaticText)
        Get ''Added 10/14/2019 td
            Return mod_listElementStatics
        End Get
        Set(value As List(Of ClassElementStaticText))
            ''Added 10/14/2019 td
            mod_listElementStatics = value
        End Set
    End Property


    Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Property Pic_InitialDefault As Image ''Added 9/23/2019 td 

    ''10/14/2019 td''Public Function ListFields_Denigrated() As List(Of ClassFieldAny)
    ''    ''
    ''    ''Added 9/19/2019 thomas downes
    ''    ''
    ''    Return mod_listFields

    ''End Function ''End of "Public Function Fields() As List(Of ClassFieldAny)"

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
        If (MissingTheElementPic()) Then Return Nothing ''Added 10/12/2019 td

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

            ''10/14/2019 td''mod_listFields.Add(each_field_standard)
            mod_listFields_Standard.Add(each_field_standard)

        Next each_field_standard
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''Customized Fields (Collect the list items)  
        ''
        For Each each_field_customized As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            ''10/14/2019 td''mod_listFields.Add(each_field_customized)
            mod_listFields_Custom.Add(each_field_customized)

        Next each_field_customized
        ''----------------------------------------------------------------------------------------------------

    End Sub ''End of "Public Sub LoadFields(par_pictureBackground As PictureBox)"

    Public Sub LoadFieldElements(par_pictureBackground As PictureBox, par_layout As BadgeLayoutClass)
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
        ''10/14/2019 td''For Each each_field As ClassFieldAny In mod_listFields
        For Each each_field As ClassFieldAny In Me.ListOfFields_Any()

            ''Fields cannot link to elements.---9/18/2019 td''mod_listElementFields.Add(each_field.ElementFieldClass)

            ''Added 9/16/2019 td  
            ''Fields cannot link to elements.---9/18/2019 td''field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

            intFieldIndex += 1
            ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
            'intTop_Pixels = (c_intHeight_Pixels * (intFieldIndex - 1))
            intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

            ''Added 9/18/2019 td
            new_elementField = New ClassElementField(each_field, intLeft_Pixels, intTop_Pixels, c_intHeight_Pixels)
            new_elementField.FieldInfo = each_field
            new_elementField.FieldEnum = each_field.FieldEnumValue ''Added 10/12/2019 td

            ''Added 10/13/2019 td
            new_elementField.BadgeLayout = par_layout

            ''Added 9/19/2019 td
            mod_listElementFields.Add(new_elementField)

        Next each_field

    End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As PictureBox)"

    Public Sub LoadElement_Pic(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
        ''10/10/2019 td''Public Sub LoadPicElement(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
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

    End Sub ''End of "Public Sub LoadElement_Pic(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_QRCode(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
        ''
        ''Added 10/10/2019 td  
        ''
        Dim objElementQR As ClassElementQRCode ''Added 9/16/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\QRCodes")

        intLeft = par_intLeft ''9/19 td''(par_picturePortrait.Left - par_pictureBackground.Left)
        intTop = par_intTop ''9/19 td''(par_picturePortrait.Top - par_pictureBackground.Top)

        ''9/19/2019 td''objRectangle = New Rectangle(intLeft, intTop, par_picturePortrait.Width, par_picturePortrait.Height)
        objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

        objElementQR = New ClassElementQRCode(objRectangle, par_pictureBackground)

        ''10/10/2019 td''objElementQR.PicFileIndex = 1
        ''10/10/2019 td''mod_listElementPics.Add(objElementPic)

        Me.ElementQRCode = objElementQR

    End Sub ''End of "Public Sub LoadElement_QRCode(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_Signature(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
        ''
        ''Added 10/10/2019 td  
        ''
        Dim objElementSig As ClassElementSignature ''Added 10/10/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\Signatures")

        intLeft = par_intLeft ''9/19 td''(par_picturePortrait.Left - par_pictureBackground.Left)
        intTop = par_intTop ''9/19 td''(par_picturePortrait.Top - par_pictureBackground.Top)

        objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)
        objElementSig = New ClassElementSignature(objRectangle, par_pictureBackground)

        Me.ElementSignature = objElementSig

    End Sub ''End of "Public Sub LoadElement_Signature(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_Portrait(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)
        ''10/8/2019 td''Public Sub LoadPicElement(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)
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

    End Sub ''End of "Public Sub LoadElement_Portrait(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_Signature(par_picSignature As PictureBox, par_pictureBackground As PictureBox)
        ''
        ''Added 10/8/2019 & 9/16/2019 td  
        ''
        Dim objElementSig As ClassElementSignature ''Added 9/16/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        intLeft = (par_picSignature.Left - par_pictureBackground.Left)
        intTop = (par_picSignature.Top - par_pictureBackground.Top)

        objRectangle = New Rectangle(intLeft, intTop, par_picSignature.Width, par_picSignature.Height)

        objElementSig = New ClassElementSignature(objRectangle, par_pictureBackground)

        objElementSig.SigFileIndex = 1

        ''10/8/2019 td''mod_listElementPics.Add(objElementPic)
        Me.ElementSignature = objElementSig

    End Sub ''End of "Public Sub LoadElement_Signature(par_picSignature As PictureBox, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_QRCode(par_picQRCode As PictureBox, par_pictureBackground As PictureBox)
        ''
        ''Added 10/8/2019 & 9/16/2019 td  
        ''
        Dim objElementQR As ClassElementQRCode ''Added 9/16/2019 td 
        Dim objRectangle As Rectangle ''Added 9/16/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

        intLeft = (par_picQRCode.Left - par_pictureBackground.Left)
        intTop = (par_picQRCode.Top - par_pictureBackground.Top)

        objRectangle = New Rectangle(intLeft, intTop, par_picQRCode.Width, par_picQRCode.Height)

        objElementQR = New ClassElementQRCode(objRectangle, par_pictureBackground)

        ''10/8/2019 td''objElementQR.SigFileIndex = 1

        ''10/8/2019 td''mod_listElementPics.Add(objElementPic)
        Me.ElementQRCode = objElementQR

    End Sub ''End of "Public Sub LoadElement_QRCode(par_picQRCode As PictureBox, par_pictureBackground As PictureBox)"

    Public Sub LoadElement_Text(par_DisplayText As String, par_intLeft As Integer, par_intTop As Integer,
                                par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
        ''
        ''Added 10/10/2019 td  
        ''
        Dim objElementText As ClassElementStaticText ''Added 10/10/2019 td 
        Dim objRectangle As Rectangle ''Added 10/10/2019 td  
        Dim intLeft As Integer
        Dim intTop As Integer

        intLeft = (par_intLeft - par_pictureBackground.Left)
        intTop = (par_intTop - par_pictureBackground.Top)

        objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

        objElementText = New ClassElementStaticText(par_DisplayText, intLeft, intTop, par_intHeight)

        mod_listElementStatics.Add(objElementText)

    End Sub ''End of "Public Sub LoadElement_Text(par_DisplayText As String, par_intLeft As Integer, ...., par_pictureBackground As PictureBox)"

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
        ''10/14/2019 td''Dim copy_ofField As ClassFieldAny
        Dim copy_ofField_Stan As ClassFieldStandard
        Dim copy_ofField_Cust As ClassFieldCustomized
        Dim copy_ofElementField As ClassElementField ''Added 10/1/2019 td

        ''Added 10/13/2019 thomas d.
        objCopyOfCache.PathToXml_Saved = Me.PathToXml_Saved

        ''Added 9/29/2019 thomas downes  
        ''#1 10/14/2019 td''For Each each_field As ClassFieldAny In mod_listFields
        '' #2 10/14/2019 td''For Each each_field As ClassFieldAny In Me.ListOfFields_Any()
        ''
        ''    ''9/29/2019 td''objCopyOfCache.ListFields().Add(each_field.Copy())
        ''    copy_ofField = each_field.Copy()
        ''    objCopyOfCache.ListFields().Add(copy_ofField)
        ''    ListFields_NotUsed.Add(copy_ofField)
        ''
        ''    Try
        ''        dictionaryFields.Add(copy_ofField.FieldEnumValue, copy_ofField)
        ''    Catch ex_AddFailed As Exception
        ''        ''Added 10/10/2019 td
        ''        ''  The ID field is being added twice, for an unknown reason.  
        ''        System.Diagnostics.Debugger.Break()
        ''    End Try
        ''
        ''Next each_field

        ''Added 10/14/2019 td 
        ''  Copy the Standard fields. 
        ''
        For Each each_field_Stan As ClassFieldStandard In mod_listFields_Standard

            copy_ofField_Stan = each_field_Stan.Copy()
            objCopyOfCache.ListOfFields_Standard.Add(copy_ofField_Stan)
            ListFields_NotUsed.Add(copy_ofField_Stan)

            Try
                dictionaryFields.Add(copy_ofField_Stan.FieldEnumValue, copy_ofField_Stan)
            Catch ex_AddFailed As Exception
                ''Added 10/10/2019 td
                ''  The ID field is being added twice, for an unknown reason.  
                System.Diagnostics.Debugger.Break()
            End Try

        Next each_field_Stan

        ''Added 10/14/2019 td 
        ''  Copy the Custom fields. 
        ''
        For Each each_field_Cust As ClassFieldCustomized In mod_listFields_Custom

            copy_ofField_Cust = each_field_Cust.Copy()
            objCopyOfCache.ListOfFields_Custom.Add(copy_ofField_Cust)
            ListFields_NotUsed.Add(copy_ofField_Cust)

            Try
                dictionaryFields.Add(copy_ofField_Cust.FieldEnumValue, copy_ofField_Cust)
            Catch ex_AddFailed As Exception
                ''Added 10/10/2019 td
                ''  The ID field is being added twice, for an unknown reason.  
                System.Diagnostics.Debugger.Break()
            End Try

        Next each_field_Cust


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

            ''10/12/2019 td''dictionaryFields.TryGetValue(each_elementField.FieldInfo.FieldEnumValue, copy_ofElementField.FieldObject)
            dictionaryFields.TryGetValue(each_elementField.FieldEnum, copy_ofElementField.FieldObject)

            ''Added 10/13/2019 td
            copy_ofElementField.FieldInfo = CType(copy_ofElementField.FieldObject, ICIBFieldStandardOrCustom)

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

        ''Added 10/8/2019 thomas downes
        ''
        ''If the QR Code &/or Signature have been supplied, then we can proceed to copy them. 
        ''
        If (Me.ElementQRCode IsNot Nothing) Then objCopyOfCache.ElementQRCode = Me.ElementQRCode.Copy
        If (Me.ElementSignature IsNot Nothing) Then objCopyOfCache.ElementSignature = Me.ElementSignature.Copy

        ''Added 10/10/2019 thomas downes
        objCopyOfCache.PathToXml_Saved = Me.PathToXml_Saved

        Return objCopyOfCache

    End Function ''End of "Public Function Copy() As ClassElementsCache"

    Public Sub LinkElementsToFields()
        ''
        ''Added 10/12/2019 thomas d. 
        ''
        Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)

        ''Added 9/29/2019 thomas downes  
        For Each each_field As ClassFieldAny In mod_listFields
            Try
                dictionaryFields.Add(each_field.FieldEnumValue, each_field)
            Catch ex_AddFailed As Exception
                ''Added 10/12/2019 td
                System.Diagnostics.Debugger.Break()
            End Try
        Next each_field

        Dim found_field As ClassFieldAny ''Added 10/12/2019 td

        For Each each_elementField As ClassElementField In mod_listElementFields

            found_field = Nothing ''Initialize. ----10/12/2019 td

            dictionaryFields.TryGetValue(each_elementField.FieldEnum, found_field)

            each_elementField.FieldObject = found_field
            each_elementField.FieldInfo = found_field

        Next each_elementField

    End Sub ''End of "Public Sub LinkElementsToFields()"

    Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField
        ''
        ''Added 9/30/2019 td  
        ''
        Throw New NotImplementedException("Not implemented.   #x4591")


    End Function ''End of "Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField"

    Public Function MissingTheFields() As Boolean
        ''Added 10/10/2019 td 
        Return (0 = mod_listFields.Count)

    End Function ''ENd of "Public Function MissingTheFields() As Boolean"

    Public Function MissingTheElementFields() As Boolean
        ''Added 10/10/2019 td 
        Return (0 = mod_listElementFields.Count)

    End Function ''ENd of "Public Function MissingTheElementFields() As Boolean"

    Public Function MissingTheElementTexts() As Boolean
        ''Added 10/11/2019 td 
        ''10/14 td''Return (0 = mod_listElementStatics.Count)
        Return True ''Added 10/14/2019 td 

    End Function ''ENd of "Public Function MissingTheElementTexts() As Boolean"

    Public Function MissingTheElementPic() As Boolean
        ''Added 10/10/2019 td 
        Return (0 = mod_listElementPics.Count)

    End Function ''ENd of "Public Function MissingTheElementPic() As Boolean"

    Public Function MissingTheQRCode() As Boolean
        ''Added 10/10/2019 td 
        Return (Me.ElementQRCode Is Nothing)

    End Function ''ENd of "Public Function MissingTheQRCode() As Boolean"

    Public Function MissingTheSignature() As Boolean
        ''Added 10/10/2019 td 
        Return (Me.ElementSignature Is Nothing)

    End Function ''ENd of "Public Function MissingTheSignature() As Boolean"

    Public Function GetElementByFieldEnum(par_enum As EnumCIBFields) As ClassElementField
        ''
        ''Added 10 / 13 / 2019 td
        ''
        For Each each_elementField As ClassElementField In mod_listElementFields
            With each_elementField
                .FieldEnum = .FieldObject.FieldEnumValue ''This is a double-check that the Enum value matches. 
                If (.FieldEnum = par_enum) Then Return each_elementField
            End With ''End of "With each_elementField"
        Next each_elementField

        Return (Nothing)

    End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

    Public Function GetFieldByLabelCaption(par_caption As String) As ClassFieldAny
        ''Added 10/10/2019 td 
        Return (Nothing)

    End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

    Public Function GetElementByLabelCaption(par_caption As String) As ClassElementField
        ''Added 10/10/2019 td 
        Return (Nothing)

    End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

    Public Function GetElementByField(par_field As ClassFieldAny) As ClassElementField
        ''Added 10/10/2019 td 
        Return (Nothing)

    End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

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
