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
    Public Property FieldObjectAny As ClassFieldAny ''Added 9/18/2019 td
    Public Property FieldObjectCustom As ClassFieldCustomized ''Added 12/13/2021 td
    Public Property FieldObjectStandard As ClassFieldStandard ''Added 12/13/2021 td

    ''Added 10/12/2019 thomas downes
    Public Property FieldEnum As EnumCIBFields Implements IElement_TextField.FieldEnum

    <Xml.Serialization.XmlIgnore>
    Public Property FieldInfo As ICIBFieldStandardOrCustom Implements IElement_TextField.FieldInfo

    Public Property ExampleValue_ForElement As String Implements IElement_TextField.ExampleValue_ForElement ''Added 8/14/2019 td

    Public Sub LoadFieldAny(parFieldAny As ClassFieldAny)
        ''
        ''Added 12/13/2021 Thomas Downes  
        ''
        Me.FieldInfo = CType(parFieldAny, ICIBFieldStandardOrCustom) ''par_fieldAny
        Me.FieldObjectAny = parFieldAny
        Me.FieldEnum = parFieldAny.FieldEnumValue ''ADded 12/13/2021 td

        ''Added 12/13/2021 thomas downes
        If (TypeOf parFieldAny Is ClassFieldCustomized) Then

            Me.FieldObjectCustom = CType(parFieldAny, ClassFieldCustomized) ''Added 12/13/2021 td

        ElseIf (TypeOf parFieldAny Is ClassFieldStandard) Then

            Me.FieldObjectStandard = CType(parFieldAny, ClassFieldStandard) ''Added 12/13/2021 td

        End If

    End Sub ''End of "Public Sub LoadFieldAny(par_fieldAny As ClassFieldAny)"


    Public Sub LoadByCopyingMembers(par_objectElementV4 As ClassElementFieldV4,
                                    par_ElementInfo_Base As IElement_Base,
                                    par_ElementInfo_Text As IElement_TextOnly,
                                    par_ElementInfo_Field As IElement_TextField,
                                    par_badgeLayout As BadgeLayoutClass)
        ''
        ''Added 1/29/2022 thomas downes
        ''
        MyBase.LoadbyCopyingMembers(par_objectElementV4,
                                    par_ElementInfo_Base,
                                    par_ElementInfo_Text,
                                    par_ElementInfo_Field,
                                    par_badgeLayout)

        ''--------------------------------------------------------------------------
        ''Step 2 of 2 -- Field-related properties.
        ''--------------------------------------------------------------------------
        ''
        Me.ExampleValue_ForElement = par_ElementInfo_Field.ExampleValue_ForElement
        ''See FieldInfo. ---9/18/2019 td''Me.FieldInCardData = par_ElementInfo_TextFld.FieldInCardData
        ''See FieldInfo. ---9/18/2019 td''Me.FieldLabelCaption = par_ElementInfo_TextFld.FieldLabelCaption
        Me.FieldInfo = par_ElementInfo_Field.FieldInfo ''Added 9/18/2019 td 

        ''Added 12/13/2021 
        Me.FieldObjectAny = par_objectElementV4.FieldObjectAny
        Me.FieldObjectCustom = par_objectElementV4.FieldObjectCustom
        Me.FieldObjectStandard = par_objectElementV4.FieldObjectStandard

        ''Added 10/13/2019 td
        Me.FieldEnum = par_ElementInfo_Field.FieldEnum

    End Sub


    Public Function IsDisplayedOnBadge_Visibly() As Boolean
        ''
        ''Added 1/8/2022 thomas downes
        ''
        ''Jan23 2022 td'' Dim structWhyOmit As New WhyOmitted
        Dim structWhyOmitV1 As New WhyOmitted_StructV1
        Dim structWhyOmitV2 As New WhyOmitted_StructV2

        ''1/24/2022 td''Return IsDisplayedOnBadge_Visibly(structWhyOmit)
        Return IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)

    End Function ''End of "Public Function IsDisplayedOnBadge_Visibly"


    Public Function IsDisplayedOnBadge_Visibly(ByRef par_whyOmitV1 As WhyOmitted_StructV1,
                                               ByRef par_whyOmitV2 As WhyOmitted_StructV2) As Boolean
        ''----Public Function IsDisplayedOnBadge_Visibly() As Boolean
        ''
        ''Added 9/19/2019 td  
        ''
        Dim bIncludedAndVisible As Boolean ''Added 1/24/2022 td
        Dim bRelevantToPersonality As Boolean ''Added 1/24/2022 td

        par_whyOmitV1.NotRelevantField = (Not Me.FieldInfo.IsRelevantToPersonality) ''Added 11/24/2021 
        par_whyOmitV1.OmitElement = (Not Me.Visible) ''Added 11/10/2021 td
        par_whyOmitV1.ElementVisibleIsFalse = (Not Me.Visible) ''Added 12/6/2021 thomas d. 
        par_whyOmitV1.OmitField = (Not Me.FieldInfo.IsDisplayedOnBadge) ''Added 11/10/20121 td  

        ''Added 1/23/2022 td
        With Me.FieldInfo

            bIncludedAndVisible = (.IsDisplayedOnBadge And Me.Visible) ''Added 1/24/2022 td
            If (bIncludedAndVisible) Then
                bRelevantToPersonality = .IsRelevantToPersonality
                bIncludedAndVisible = (.IsRelevantToPersonality And .IsDisplayedOnBadge And Me.Visible)
                bIncludedAndVisible = ((.IsRelevantToPersonality And .IsDisplayedOnBadge) And
                          (Me.Visible And Me.Width_Pixels <> 0 And Me.Height_Pixels <> 0))
            End If ''End of "If (bIncludedAndVisible) Then"

            par_whyOmitV2.OmitIrrelevantField = (Not .IsRelevantToPersonality)
            par_whyOmitV2.OmitInvisibleElement = (Not Me.Visible)
            par_whyOmitV2.OmitUnbadgedField = (Not .IsDisplayedOnBadge)
            par_whyOmitV2.OmitZeroHeight = (Me.Height_Pixels = 0)
            par_whyOmitV2.OmitZeroWidth = (Me.Width_Pixels = 0)

            ''Enumerated values
            If (Not .IsRelevantToPersonality) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.IrrelevantField
            If (Not Me.Visible) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.InvisibleElement
            If (Not .IsDisplayedOnBadge) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.UnbadgedField
            If (Me.Height_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroHeight
            If (Me.Width_Pixels = 0) Then par_whyOmitV2.EnumOmitReason = EnumOmitReasons.ZeroWidth

            ''Current date-time.
            ''----Not sure if we need to set the date here.
            ''--If (Not bIncludedAndVisible) Then par_whyOmitV2.SetDateTime()

        End With ''End of "With Me.FieldInfo"

        ''Jan24 2022 td''Return (Me.FieldInfo.IsDisplayedOnBadge And Me.Visible)
        Return (bIncludedAndVisible)

    End Function ''End of "Public Function IsDisplayedOnBadge_Visibly() As Boolean"


    Public Function ElementIndexIsFieldIndex() As Integer
        ''//
        ''// Added 11/18/2021 td 
        ''//
        Return FieldInfo.FieldIndex

    End Function ''End of Public Function ElementIndexIsFieldIndex 



    Public Function FieldNm_CaptionText() As String
        ''//Added 11/10/2021 thomas downes
        Return (FieldInfo.CIBadgeField & "/" & FieldInfo.DataEntryText)
    End Function


    Public Function LabelText_ToDisplay(par_isForLayout_OrPreview As Boolean,
                                        Optional par_iRecipInfo As IRecipient = Nothing,
                                        Optional pbAllowExampleValues As Boolean = True) As String
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

            Case (bOkayToUseExampleValues And (Me.FieldInfo.ExampleValue <> ""))
                ''10/16 td''Case (UseExampleValues And (Me.FieldInfo.ExampleValue <> ""))

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.ExampleValue

            Case (Me.FieldInfo.FieldLabelCaption <> "")

                ''Me.ElementInfo.Info.Text = Me.FieldInfo.ExampleValue
                Return Me.FieldInfo.FieldLabelCaption

            Case Else

                ''Default value.
                ''7/29 td''Me.ElementInfo.Info.Text = $"Field #{Me.FieldInfo.FieldIndex}"
                Return $"Field #{Me.FieldInfo.FieldIndex}"

        End Select ''End of "Select Case True"

        Return "Field Information"

    End Function ''End of "Public Function LabelText(par_previewExample As Boolean) As String"






End Class
