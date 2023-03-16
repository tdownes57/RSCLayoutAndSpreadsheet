Option Explicit On
Option Strict On
''
''Added 1/29/2022 thomas downes
''
Option Infer Off

''Imports System.Drawing ''Added 9/18/2019 td  
''Imports System.Drawing.Text ''Added 
''Imports System.Windows.Forms ''Added 9/18/2019 td 
Imports ciBadgeInterfaces ''Added 8/14/2019 thomas d. 8/14/2019 td  
Imports ciBadgeFields ''Added 9/18/2019 td  
''Imports System.Xml.Serialization ''Added 9/24/2019 thomas d. 
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
''Imports ciBadgeInterfaces ''Added 11/16/2019 thomas d. 
''Imports AutoMapper ''Added 11/17/2021 thomas d. 
Imports System.Windows.Forms ''Added 5/11/2022
Imports System.Drawing ''Added 3/08/2023 thomas downes
Imports ciBadgeElements


Public Class ClassElementFieldV4
    Inherits ClassElementFieldOrTextV4
    Implements IElement_TextField ''Added 1/29/2022 td
    ''
    ''Added 1/29/2022 thomas downes
    ''

    <Xml.Serialization.XmlIgnore>
    Public Shared Property oRecipient As ClassRecipient ''Added 10/16/2019 td  
    ''11/16/2019 td''Public Shared Property Recipient As ClassRecipient ''Added 10/16/2019 td  

    <Xml.Serialization.XmlIgnore>
    Private Shared mod_sharedRecipInfo As IRecipient ''Added 12/01/2019 thomas d.
    ''---4/22/2020 td---Private Shared ms_lastFieldIndex As Integer ''Added 4/22/2020 thomas downes

    <Xml.Serialization.XmlIgnore>
    Public Shared Property iRecipientInfo As IRecipient ''Added 10/16/2019 td  
        Get
            Return mod_sharedRecipInfo ''Added 12/01/2019 thomas d.  
        End Get
        Set(value As IRecipient)
            ''Added 12/01/2019 td
            ''1-15-2020 td''mod_sharedRecipInfo = mod_sharedRecipInfo
            mod_sharedRecipInfo = value ''1-15-2020 td'' mod_sharedRecipInfo

            ''----DIFFICULT AND CONFUSING------
            oRecipient = Nothing ''Don't allow an object older reference to interfere with determining Recipient-related data. 12/01/2019 td
        End Set
    End Property



    ''--16----Replaced by a Shared Property of the same name.---10/16/2019 td
    ''--16--10/16/2019 td''Added 9/10/2019 td     <Xml.Serialization.XmlIgnore>
    ''--16--10/16/2019 td''<Xml.Serialization.XmlIgnore>
    ''--16--10/16/2019 td''Public Property Recipient As IRecipient Implements IElement_TextField.Recipient

    ''Added 9/18/2019
    ''--5/10/2022--Public Property FieldObjectAny As ClassFieldAny ''Added 9/18/2019 td
    ''--5/10/2022--Public Property FieldObjectCustom As ClassFieldCustomized ''Added 12/13/2021 td
    ''--5/10/2022--Public Property FieldObjectStandard As ClassFieldStandard ''Added 12/13/2021 td

    ''Added 10/12/2019 thomas downes
    Public Property FieldEnum As EnumCIBFields Implements IElement_TextField.FieldEnum
    Public Property FieldIsCustomizable As Boolean Implements IElement_TextField.FieldIsCustomizable ''Added 5/11/2022

    ''--5/10/2022--<Xml.Serialization.XmlIgnore>
    ''--5/10/2022--Public Property FieldInfo As ICIBFieldStandardOrCustom Implements IElement_TextField.FieldInfo

    Public Property ExampleValue_ForElement As String Implements IElement_TextField.ExampleValue_ForElement ''Added 8/14/2019 td


    Public Sub New(par_control As Control)

        ''Added 7/19/2019 td
        ''
        Me.FormControl = par_control

    End Sub


#Enable Warning CA1707
#Disable Warning CA1707

    Public Sub New(par_fieldInfo As ICIBFieldStandardOrCustom,
                   par_intLeft_Pixels As Integer,
                   par_intTop_Pixels As Integer,
                   par_intWidth_Pixels As Integer,
                   par_intHeight_Pixels As Integer)
        ''
        ''9/17 td''Public Sub New(par_intLeft_Pixels As Integer, par_intTop_Pixels As Integer, par_intHeight_Pixels As Integer)
        ''
        ''Added 5/11/2022 & 9/15/2019 td
        ''
        If (par_fieldInfo Is Nothing) Then Throw New ArgumentException("Null parameter.")

        ''5/10/2022 td''Me.FieldInfo = par_fieldInfo ''Added 9/17/2019 td 
        Me.FieldEnum = par_fieldInfo.FieldEnumValue ''Added 10/12/2019 thomas d. 
        Me.FieldIsCustomizable = par_fieldInfo.IsCustomizable ''Added 5/11/2022 td

        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

        ''9/05/2022 Me.LeftEdge_Pixels = par_intLeft_Pixels
        ''9/05/2022 Me.TopEdge_Pixels = par_intTop_Pixels
        ''#2 9/05/2022 Me.LeftEdge_bPixels = par_intLeft_Pixels
        ''#2 9/05/2022  Me.TopEdge_bPixels = par_intTop_Pixels
        Me.LeftEdge_Pixels = par_intLeft_Pixels
        Me.TopEdge_Pixels = par_intTop_Pixels
        Me.Height_Pixels = par_intHeight_Pixels

        ''Added 12/29/2022 Thomas Downes
        Me.Width_Pixels = par_intWidth_Pixels

        ''---''Added 4/22/2020 thomas downes
        ''---Me.FieldIndex`

    End Sub

#Enable Warning CA1707

    Public Sub New()
        ''
        ''Added 5/11/2022 & 7/29/2019 td
        ''
        Me.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutDimensionsClass ''Added 9/12/2019

    End Sub


    Public Sub LoadFieldAny(parFieldAny As ClassFieldAny)
        ''
        ''Added 12/13/2021 Thomas Downes  
        ''
        ''--5/10/2022--Me.FieldInfo = CType(parFieldAny, ICIBFieldStandardOrCustom) ''par_fieldAny
        ''--5/10/2022--Me.FieldObjectAny = parFieldAny
        Me.FieldEnum = parFieldAny.FieldEnumValue ''ADded 12/13/2021 td

        ''Added 12/13/2021 thomas downes
        If (TypeOf parFieldAny Is ClassFieldCustomized) Then

            ''--5/10/2022--Me.FieldObjectCustom = CType(parFieldAny, ClassFieldCustomized) ''Added 12/13/2021 td

        ElseIf (TypeOf parFieldAny Is ClassFieldStandard) Then

            ''--5/10/2022--Me.FieldObjectStandard = CType(parFieldAny, ClassFieldStandard) ''Added 12/13/2021 td

        End If

    End Sub ''End of "Public Sub LoadFieldAny(par_fieldAny As ClassFieldAny)"


#Enable Warning CA1707
#Disable Warning CA1707

    ''12/2022 Public Overloads Sub LoadByCopyingMembersV2a(par_objectElementV4 As ClassElementFieldV4,
    ''                                par_Element_Base As ClassElementBase,
    ''                                par_ElementInfo_Base As IElement_Base,
    ''                                par_ElementInfo_Text As IElement_TextOnly,
    ''                                par_ElementInfo_Field As IElement_TextField,
    ''                                par_badgeLayout As BadgeLayoutDimensionsClass)
    ''    ''
    ''    ''Added 1/29/2022 thomas downes
    ''    ''
    ''End Sub ''End of ""Public Overloads Sub LoadByCopyingMembersV2a""

#Enable Warning CA1707
#Disable Warning CA1707

    ''12/2022 Public Overloads Sub LoadByCopyingMembersV2b(par_objectElementV4 As ClassElementFieldV4,
    ''                                par_Element_Base As ClassElementBase,
    ''                                par_ElementInfo_Text As IElement_TextOnly,
    ''                                par_ElementInfo_Field As IElement_TextField,
    ''                                par_badgeLayout As BadgeLayoutDimensionsClass)
    ''    ''
    ''    ''Added 1/29/2022 thomas downes
    ''    ''
    ''End Sub ''End of ""Public Overloads Sub LoadByCopyingMembersV2a""


#Enable Warning CA1707
#Disable Warning CA1707

    Public Overloads Sub LoadByCopyingMembersV1(par_objectElementV4 As ClassElementFieldV4,
                                    par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_ElementInfo_Field As IElement_TextField,
                                    par_badgeLayout As BadgeLayoutDimensionsClass)
        ''
        ''Added 1/29/2022 thomas downes
        ''
        MyBase.LoadbyCopyingMembersV1(par_objectElementV4,
                                    par_ElementInfo_Base,
                                    par_ElementInfo_Text,
                                    par_badgeLayout)
        ''2/4/2022 td ''            par_ElementInfo_Field,
        ''2/4/2022 td ''            par_badgeLayout)

        ''--------------------------------------------------------------------------
        ''Step 2 of 2 -- Field-related properties.
        ''--------------------------------------------------------------------------
        ''
        If (par_ElementInfo_Field Is Nothing) Then Throw New ArgumentException("Par_ElementInfo_Field is null-value.")

        Me.ExampleValue_ForElement = par_ElementInfo_Field.ExampleValue_ForElement
        ''See FieldInfo. ---9/18/2019 td''Me.FieldInCardData = par_ElementInfo_TextFld.FieldInCardData
        ''See FieldInfo. ---9/18/2019 td''Me.FieldLabelCaption = par_ElementInfo_TextFld.FieldLabelCaption
        ''--5/10/2022--Me.FieldInfo = par_ElementInfo_Field.FieldInfo ''Added 9/18/2019 td 

        ''Added 12/13/2021 
        ''--5/10/2022--Me.FieldObjectAny = par_objectElementV4.FieldObjectAny
        ''--5/10/2022--Me.FieldObjectCustom = par_objectElementV4.FieldObjectCustom
        ''--5/10/2022--Me.FieldObjectStandard = par_objectElementV4.FieldObjectStandard

        ''Added 10/13/2019 td
        Me.FieldEnum = par_ElementInfo_Field.FieldEnum

    End Sub ''eND OF ""Public Overloads Sub LoadByCopyingMembersV1""

#Enable Warning CA1707

    ''Public Function IsDisplayedOnBadge_Visibly() As Boolean
    ''    ''
    ''    ''Added 1/8/2022 thomas downes
    ''    ''
    ''    ''Jan23 2022 td'' Dim structWhyOmit As New WhyOmitted
    ''    Dim structWhyOmitV1 As New WhyOmitted_StructV1
    ''    Dim structWhyOmitV2 As New WhyOmitted_StructV2

    ''    ''1/24/2022 td''Return IsDisplayedOnBadge_Visibly(structWhyOmit)
    ''    Return IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)

    ''End Function ''End of "Public Function IsDisplayedOnBadge_Visibly"


    ''Public Function IsDisplayedOnBadge_Visibly(ByRef par_whyOmitV1 As WhyOmitted_StructV1,
    ''                                           ByRef par_whyOmitV2 As WhyOmitted_StructV2) As Boolean
    ''    ''----Public Function IsDisplayedOnBadge_Visibly() As Boolean
    ''    ''
    ''    ''Added 9/19/2019 td  
    ''    ''
    ''    Dim bIncludedAndVisible As Boolean ''Added 1/24/2022 td
    ''    Dim bRelevantToPersonality As Boolean ''Added 1/24/2022 td

    ''    par_whyOmitV1.NotRelevantField = (Not Me.FieldInfo.IsRelevantToPersonality) ''Added 11/24/2021 
    ''    par_whyOmitV1.OmitElement = (Not Me.Visible) ''Added 11/10/2021 td
    ''    par_whyOmitV1.ElementVisibleIsFalse = (Not Me.Visible) ''Added 12/6/2021 thomas d. 
    ''    par_whyOmitV1.OmitField = (Not Me.FieldInfo.IsDisplayedOnBadge) ''Added 11/10/20121 td  

    ''    ''Added 1/23/2022 td
    ''    With Me.FieldInfo

    ''        bIncludedAndVisible = (.IsDisplayedOnBadge And Me.Visible) ''Added 1/24/2022 td
    ''        If (bIncludedAndVisible) Then
    ''            bRelevantToPersonality = .IsRelevantToPersonality
    ''            bIncludedAndVisible = (.IsRelevantToPersonality And .IsDisplayedOnBadge And Me.Visible)
    ''            bIncludedAndVisible = ((.IsRelevantToPersonality And .IsDisplayedOnBadge) And
    ''                      (Me.Visible And Me.Width_Pixels <> 0 And Me.Height_Pixels <> 0))
    ''        End If ''End of "If (bIncludedAndVisible) Then"

    ''        par_whyOmitV2.OmitIrrelevantField = (Not .IsRelevantToPersonality)
    ''        par_whyOmitV2.OmitInvisibleElement = (Not Me.Visible)
    ''        par_whyOmitV2.OmitUnbadgedField = (Not .IsDisplayedOnBadge)
    ''        par_whyOmitV2.OmitZeroHeight = (Me.Height_Pixels = 0)
    ''        par_whyOmitV2.OmitZeroWidth = (Me.Width_Pixels = 0)

    ''        ''Enumerated values
    ''        If (Not .IsRelevantToPersonality) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.IrrelevantField
    ''        If (Not Me.Visible) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.InvisibleElement
    ''        If (Not .IsDisplayedOnBadge) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.UnbadgedField
    ''        If (Me.Height_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroHeight
    ''        If (Me.Width_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroWidth

    ''        ''Current date-time.
    ''        ''----Not sure if we need to set the date here.
    ''        ''--If (Not bIncludedAndVisible) Then par_whyOmitV2.SetDateTime()

    ''    End With ''End of "With Me.FieldInfo"

    ''    ''Jan24 2022 td''Return (Me.FieldInfo.IsDisplayedOnBadge And Me.Visible)
    ''    Return (bIncludedAndVisible)

    ''End Function ''End of "Public Function IsDisplayedOnBadge_Visibly() As Boolean"


    ''Public Function ElementIndexIsFieldIndex() As Integer
    ''    ''//
    ''    ''// Added 11/18/2021 td 
    ''    ''//
    ''    Return FieldInfo.FieldIndex

    ''End Function ''End of Public Function ElementIndexIsFieldIndex 



    ''Public Function FieldNm_CaptionText() As String
    ''    ''//Added 11/10/2021 thomas downes
    ''    Return (FieldInfo.CIBadgeField & "/" & FieldInfo.DataEntryText)
    ''End Function

    Public Function FieldNameCaptionText() As String
        ''//Added 11/10/2021 thomas downes
        ''5/11/2022 td''Return (FieldInfo.CIBadgeField & "/" & FieldInfo.DataEntryText)
        Return (FieldEnum.ToString())

    End Function ''End of ""Public Function FieldNmCaptionText() As String""


#Disable Warning CA1707 ''Remove underscores. 

    Public Function LabelText_ToDisplay(par_isForLayout_OrPreview As Boolean,
                                        Optional par_iRecipInfo As IRecipient = Nothing,
                                        Optional pbAllowExampleValues As Boolean = True,
                                        Optional par_fieldAny As ClassFieldAny = Nothing) As String
        ''
        ''Added 10/16/2016 & 7/25/2019 thomas d 
        ''
        ''This was copied from CtlGraphicFldLabel.vb on 10/16/2019 td
        ''
        Dim bOkayToUseExampleValues As Boolean ''Added 10/16/2019 td  

        ''11/18/2019 td''bOkayToUseExampleValues = par_isForLayout_OrPreview
        Dim boolNotAFinalPrint As Boolean ''Added 11/18/2019 td
        boolNotAFinalPrint = par_isForLayout_OrPreview ''Added 11/18/2019 td
        bOkayToUseExampleValues = (boolNotAFinalPrint And pbAllowExampleValues)

        Select Case True

            Case (par_iRecipInfo IsNot Nothing)
                ''
                ''Added 12/14/2021 thomas d. 
                ''
                Return par_iRecipInfo.GetTextValue(Me.FieldEnum)

            Case (ClassElementFieldV3.oRecipient IsNot Nothing)
                ''
                ''Added 10/16/2019 thomas d. 
                ''
                Return ClassElementFieldV3.oRecipient.GetTextValue(Me.FieldEnum)

                ''Case (Me.ExampleTextToDisplay.Trim() <> "")
                ''    ''
                ''    ''Added 9/18/2019 td 
                ''    ''
                ''    Return Me.ExampleTextToDisplay

            Case (ClassElementFieldV3.iRecipientInfo IsNot Nothing)

                Return ClassElementFieldV3.iRecipientInfo.GetTextValue(Me.FieldEnum)

            Case (bOkayToUseExampleValues And (Me.ExampleValue_ForElement <> ""))
                ''10/16 td''Case (Me.ExampleValue_ForElement <> "")
                ''
                ''Added 9/18/2019 td 
                ''
                Return Me.ExampleValue_ForElement

                ''Case (bOkayToUseExampleValues And (Me.FieldInfo.ExampleValue <> ""))
                ''    ''10/16 td''Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

                ''    ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                ''    Return Me.FieldInfo.ExampleValue

                ''Case (Me.FieldInfo.FieldLabelCaption <> "")

                ''    ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                ''    Return Me.FieldInfo.FieldLabelCaption

            Case (par_fieldAny IsNot Nothing) ''Added 5/29/2022 & 5/12/2022 td

                ''Added 5/29/2022 & 5/12/2022 td
                Return par_fieldAny.FieldLabelCaption

            Case Else

                ''Default value.
                ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
                ''--5/10/2022--Return $"Field #{Me.FieldInfo.FieldIndex}"
                Return FieldEnum.ToString() ''Modified 5/10/2022 td 

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText(par_previewExample As Boolean) As String"


    Public Function CopyToElementFieldV4() As ClassElementFieldV4
        ''--#2 July25 2022 --Public Overloads Function Copy(pboolDummy As Boolean)
        ''--#1 ??? 2022 --Public Overloads Function Copy(pboolDummy As Boolean) As ClassElementFieldOrTextV4
        ''
        ''Added 7/16/2022 & 2/4/2022 & 9/17/2019 
        ''
        Dim objCopy As New ClassElementFieldV4
        ''9/05/2022 td''objCopy.LoadByCopyingMembers(Me, Me, Me, Me.BadgeLayout)
        objCopy.LoadbyCopyingMembersV1(Me, Me, Me, Me.BadgeLayout)

        Return objCopy

    End Function ''End of "Public Function CopyToElementFieldV4() As ClassElementFieldV4"


    ''
    ''Added 3/05/2023
    ''
    Public Overrides Function GetImageForPrinting(par_recipient As IRecipient,
                                       par_scaleW As Single,
                                       par_scaleH As Single,
                                       ByRef pboolNotShownOnBadge As Boolean,
                                       Optional ByRef par_location As Drawing.Point = Nothing) As Image
        ''This function is prompted by my study of C++.
        ''   Objects should be responsible for the processing of their 
        ''   contents, following the principle of information hiding 
        ''   or encapsulation. 
        ''  ---3/05/2023
        pboolNotShownOnBadge = (Not Me.Visible)

        par_location = New Drawing.Point(CInt(LeftEdge_Pixels * par_scaleW),
                                         CInt(TopEdge_Pixels * par_scaleH))

        ''3/09/2023 Return ImageForBadgeImage(par_recipient, par_scale)
        ''3/16/2023 Return ImageForBadgeImage(par_recipient, par_scaleW, par_scaleH)
        Return ImageForBadgeImage(par_scaleW, par_scaleH, par_recipient)

    End Function ''End of "Public Function GetImageForPrinting() As Image"


    Public Overrides Function ImageForBadgeImage(par_scaleW As Single,
                                                 par_scaleH As Single,
                     Optional ByRef par_recipient As IRecipient = Nothing,
                     Optional ByVal par_enumField As EnumCIBFields = EnumCIBFields.Undetermined,
                     Optional ByRef par_text As String = "",
                     Optional ByRef par_image As Image = Nothing) As Image ''Implements IElement_Base.ImageForBadgeImage
        ''    Throw New NotImplementedException()

        ''12/31/2022 Return Nothing
        ''12/31/2022 Return New Bitmap(MyBase.Width_Pixels, MyBase.Height_Pixels)
        ''3/09/2022 Return Nothing

        ''3/09/2022 Dim intDesiredLayout_Width As Integer '' = par_imageBadgeCard.Width
        ''3/09/2022 Dim intDesiredLayout_Height As Integer '' = par_imageBadgeCard.Height ''//Added 3/9/2023 & 9/13/2022 td
        Dim boolRotated As Boolean = False ''//Added 3/9/2022 & 10/14/2019 td
        Dim image_textStandard As Image
        Dim strTextToDisplay As String ''Added 3/09/2023 td

        strTextToDisplay = LabelText_ToDisplay(False)

        ''3/16/2023  image_textStandard =
        ''    modGenerate.TextImage_ByElemInfo(strTextToDisplay,
        ''    par_scaleW, par_scaleH, Me, Me,
        ''       boolRotated, False) ''//;  // 7-29-2022 ref boolRotated, False);
        image_textStandard =
            MyBase.ImageForBadgeImage(par_scaleW, par_scaleH,
                                      par_recipient, EnumCIBFields.Undetermined,
                                      strTextToDisplay) ''//;  // 7-29-2022 ref boolRotated, False);

        ''3/9/2023   intDesiredLayout_Width,
        ''3/9/2023   intDesiredLayout_Height,
        ''3/9/2023      par_elementField, par_elementField,
        ''3/9/2023      ref boolRotated, False, par_elementField) ''//;  // 7-29-2022 ref boolRotated, False);

        Return image_textStandard

    End Function ''End of ""Public Function ImageForBadgeImage""



End Class
