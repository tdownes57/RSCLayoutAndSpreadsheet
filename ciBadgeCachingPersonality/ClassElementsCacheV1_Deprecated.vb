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
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
Imports ciBadgeElements ''Added 12/4/2021 thomas downes  

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassElementsCache_Deprecated
        ''
        ''Added 9/16/2019 thomas downes....
        ''
        Public Shared Singleton As ClassElementsCache_Deprecated ''Let's use
        '' the pattern mentioned in https://en.wikipedia.org/wiki/Singleton_pattern

        Public Property Id_GUID As System.Guid ''Added 9/30/2019 td 
        Public Property Id_GUID6 As String ''Added 12/12/2021 td 
        Public Property Id_GUID6_CopiedFrom As String ''Added 12/12/2021 td 

        ''10/10/2019 td''Public Property SaveToXmlPath As String ''Added 9/29/2019 td
        Public Property PathToXml_Saved As String ''Added 9/29/2019 td
        Public Property PathToXml_Opened As String ''Added 12/14/2021 td
        Public Property PathToXml_Binary As String ''Added 11/29/2019 td

        ''Added 2/04/2020 td
        ''Deprecated 12/14/2021 thoams downes
        Public Property XmlFile_Path_Deprecated As String = "" ''Added 2/04/2020 td
        Public Property XmlFile_FTitle_Deprecated As String = "" ''Added 2/04/2020 td

        ''Added 12/14/2021 thomas
        Public Property Personality As ClassPersonalityConfig ''Added 12/14/2021 thomas

        ''Added 1/14/2020 td
        Public Property BackgroundImage_Front_Path As String = "" ''Added 1/14/2020 td
        Public Property BackgroundImage_Front_FTitle As String = "" ''Added 1/14/2020 td

        ''Added 12/10/2020 td
        Public Property BackgroundImage_Backside_Path As String = "" ''Added 12/10/2020 td
        Public Property BackgroundImage_Backside_FTitle As String = "" ''Added 12/10/2020 td

        ''I have added the <...XmlIgnore> attribute. See ListOfElementQRCodes.  ---1/14/2022 td
        ''Jan18 2022 ''<Xml.Serialization.XmlIgnore>
        ''Jan18 2022 ''Public Property ElementQR_RefCopy As ClassElementQRCode ''Added 10/8/2019 thomas d.  

        ''I have added the <...XmlIgnore> attribute.  See ListOfElementSignatures.  ---1/14/2022 td
        ''Jan18 2022 ''<Xml.Serialization.XmlIgnore>
        ''Jan18 2022 ''Public Property ElementSig_RefCopy As ClassElementSignature ''Added 10/8/2019 thomas d.  

        Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

        ''Added 1/12/2020 thomas d. 
        Public Property PathToBackgroundImageFile_Deprecated As String ''Deprecated 2/4/2020 td.   Added 1/12/2019 thomas downes

        <Xml.Serialization.XmlIgnore>
        Public Property Pic_InitialDefault As Image ''Added 9/23/2019 td 

        Public Property DateAndTimeUpdated As DateTime ''Added 11/29/2021 thomas d. 

        ''Added 12/12/2021 Thomas Downes
        Public Property BadgeHasTwoSidesOfCard As Boolean ''Added 12/12/2021 td  

        ''Added 5/11/2022 Thomas Downes
        Public Property UserHasDeletedElements As Boolean ''Added 5/11/2022 td  


        ''10/14/2019 td''Private mod_listFields As New List(Of ClassFieldAny) ''Added 9/18/2019 td  

        ''10/17/2019 td''Private mod_listFields_Standard As New List(Of ClassFieldStandard) ''Added 10/14/2019 td  
        ''10/17/2019 td''Private mod_listFields_Custom As New List(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        ''10/17/2019 td''Private mod_listElementFields As New List(Of ClassElementField)
        ''10/17/2019 td''Private mod_listElementPics As New List(Of ClassElementPic)
        ''10/17/2019 td''Private mod_listElementStatics As New List(Of ClassElementStaticText)
        ''10/17/2019 td''Private mod_listElementLaysections As New List(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes

        Private mod_listFields_Standard As New HashSet(Of ClassFieldStandard) ''Added 10/14/2019 td  
        Private mod_listFields_Custom As New HashSet(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        Private mod_dictionary_FStandard As New Dictionary(Of EnumCIBFields, ClassFieldStandard) ''Added 10/14/2019 td  
        Private mod_dictionary_FCustom As New Dictionary(Of EnumCIBFields, ClassFieldCustomized) ''Added 10/14/2019 td  

        Private Const mod_bOkayToUseExampleQRCode As Boolean = True ''Added 1/17/2022
        Private Const mod_bOkayToUseExampleSignature As Boolean = True ''Added 1/17/2022

        ''
        ''Badge Elements -- Includes Pics & Graphics, Static Texts & Fields
        ''
        ''#1 Jan8 2022 td''Private mod_listBadgeElements_Front As New HashSet(Of ClassElementField) ''Added 11/26/2021 td
        ''#2 Jan8 2022 td''Private mod_listBadgeElements_Front As New HashSet(Of ClassElementBase) ''Modified 1/8/2022 ---Added 11/26/2021 td
        ''#2 Jan8 2022 td''Private mod_listBadgeElements_Backside As New HashSet(Of ClassElementBase) ''Modified 1/8/2022 td  ---Added 11/26/2021 td

        ''Front side of ID Card / Badge Card  ----1/8/2022 td
        Private mod_listElementFields_FrontV3 As New HashSet(Of ClassElementFieldV3)
        Private mod_listElementFields_FrontV4 As New HashSet(Of ClassElementFieldV4)
        Private mod_listElementPics_Front As New HashSet(Of ClassElementPortrait)
        Private mod_listElementStaticsV3_Front As New HashSet(Of ClassElementStaticTextV3)
        Private mod_listElementStaticsV4_Front As New HashSet(Of ClassElementStaticTextV4)
        Private mod_listElementGraphics_Front As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
        Private mod_listElementLaysections_Front As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes
        Private mod_listElementQRCodes_Front As New HashSet(Of ClassElementQRCode) ''Added 1/14/2022 tdownes
        Private mod_listElementSignatures_Front As New HashSet(Of ClassElementSignature) ''Added 1/14/2022 tdownes

        ''Back side of ID Card / Badge Card  ----1/8/2022 td
        Private mod_listElementFields_BacksideV3 As New HashSet(Of ClassElementFieldV3)
        Private mod_listElementFields_BacksideV4 As New HashSet(Of ClassElementFieldV4) ''Added 2/08/2022 td
        Private mod_listElementPics_Backside As New HashSet(Of ClassElementPortrait)
        Private mod_listElementStaticsV3_Backside As New HashSet(Of ClassElementStaticTextV3)
        Private mod_listElementStaticsV4_Backside As New HashSet(Of ClassElementStaticTextV4)
        Private mod_listElementGraphics_Backside As New HashSet(Of ClassElementGraphic) ''Added 1/8/2022 td
        Private mod_listElementLaysections_Backside As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes
        Private mod_listElementQRCodes_Backside As New HashSet(Of ClassElementQRCode) ''Added 1/14/2022 tdownes
        Private mod_listElementSignatures_Backside As New HashSet(Of ClassElementSignature) ''Added 1/14/2022 tdownes

        ''Added 1/14/2020 thomas dow nes
        Private Structure BackgroundTitleAndWidth
            Dim sFileTitle As String
            Dim iPixelsWidth As Integer
        End Structure
        Private mod_dictionaryBackgroundImages As New Dictionary(Of BackgroundTitleAndWidth, Image) ''Added 1/14/2020 thomas downes

        ''10/14/2019 td''Public Property ListOfFields As List(Of ClassFieldAny)
        ''    Get ''Added 9/28/2019 td
        ''        Return mod_listFields
        ''    End Get
        ''    Set(value As List(Of ClassFieldAny))
        ''        ''Added 9/28/2019 td
        ''        mod_listFields = value
        ''    End Set
        ''End Property

        Public Function GetElementQR(par_backside As Boolean) As ClassElementQRCode
            ''Added 1/18/2022
            If (par_backside) Then
                Return ListOfElementQRCodes_Back.FirstOrDefault
            Else
                Return ListOfElementQRCodes_Front.FirstOrDefault
            End If ''End of "If (par_backside) Then ... Else ..."
        End Function ''End of "Public Function GetElementQR(par_backside As Boolean) As ClassElementSignature"

        Public Function GetElementSig(par_backside As Boolean) As ClassElementSignature
            ''Added 1/18/2022
            If (par_backside) Then
                Return ListOfElementSignatures_Back.FirstOrDefault
            Else
                Return ListOfElementSignatures_Front.FirstOrDefault
            End If ''End of "If (par_backside) Then ... Else ..."
        End Function ''End of "Public Function GetElementSig(par_backside As Boolean) As ClassElementSignature"


        Public Function GetAllBadgeSideLayoutElements(par_enumWhichSide As EnumWhichSideOfCard,
                                                      par_iBadgeLayout As IBadgeLayoutDimensions,
                                         Optional pbBackgroundInfoUpdated As Boolean = True) _
                                                      As ClassBadgeSideLayoutV1
            ''
            ''Added 12/22/2021 thomas downes
            ''
            Dim objSide As New ClassBadgeSideLayoutV1
            Dim bBackside As Boolean

            bBackside = (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside)

            If (bBackside) Then
                ''
                ''Back side of card. 
                ''
                ''5/20/2022 td'' objSide.BackgroundImage = Me.GetBackgroundImage(par_enumWhichSide)
                objSide.BackgroundImage = Me.GetBackgroundImage(par_enumWhichSide,
                                                                par_iBadgeLayout,
                                                                pbBackgroundInfoUpdated)

                ''Jan13 2022''objSide.ElementPic = Me.ListOfElementPics_Back().FirstOrDefault()
                ''May15 2022 ''objSide.ElementPortrait_1st = Me.ListOfElementPics_Back().FirstOrDefault()

                ''May15 2022 ''objSide.ElementQRCode_1st = Me.ListOfElementQRCodes_Back().FirstOrDefault() ''Jan16 2022 td''Me.ElementQR_RefCopy
                ''May15 2022 ''objSide.ElementSignature_1st = Me.ListOfElementSignatures_Back().FirstOrDefault() ''Jan16 2022 td''Me.ElementSig_RefCopy

                ''Added 1/17/2022 td
                ''If (objSide.ElementQRCode Is Nothing) Then Me.ElementQR_RefCopy = Nothing
                ''If (objSide.ElementSignature Is Nothing) Then Me.ElementSig_RefCopy = Nothing

                objSide.ListElementFieldsV3 = Me.ListOfElementFields_BacksideV3
                objSide.ListElementGraphics = Me.ListOfElementGraphics_Backside ''Jan22 2022 td''Nothing
                objSide.ListElementStaticTextsV3 = Me.ListOfElementTextsV3_Backside
                objSide.ListElementStaticTextsV4 = Me.ListOfElementTextsV4_Backside ''Added 2/1/2022 td

                ''Added 1/14/2022 thomas
                objSide.ListElementPortraits = Me.ListOfElementPics_Back
                objSide.ListElementQRCodes = Me.ListOfElementQRCodes_Back
                objSide.ListElementSignatures = Me.ListOfElementSignatures_Back

                ''Added 1/14/2022 thomas
                ''========================================================================
                ''QR Code
                ''========================================================================
                ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
                ''We are making a transition, from the older cache property ElementQRCode,
                ''  toward the new cache property of ListOfElementQRCodes_Back.
                ''We are looking for the non-null object, if it exists. 
                ''========================================================================
                ''Dim boolBacksideQR As Boolean = ((Me.ElementQR_RefCopy IsNot Nothing) AndAlso
                ''    Me.ElementQR_RefCopy.WhichSideOfCard = EnumWhichSideOfCard.EnumBackside)
                ''
                ''If boolBacksideQR Then
                ''    objSide.ElementQRCode = Me.ElementQR_RefCopy
                ''ElseIf (Me.ElementQR_RefCopy Is Nothing) Then
                ''    Me.ElementQR_RefCopy = Me.ListOfElementQRCodes_Back.FirstOrDefault()
                ''    objSide.ElementQRCode = Me.ElementQR_RefCopy
                ''End If

                ''Added 1/14/2022 thomas
                ''========================================================================
                ''Signature
                ''========================================================================
                ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
                ''We are making a transition, from the older cache property ElementSignature,
                ''  toward the new cache property of ListOfElementSignatures_Back.
                ''We are looking for the non-null object, if it exists.  ---1/14/2022 td
                ''========================================================================
                ''Dim boolBacksideSig As Boolean = ((Me.ElementSig_RefCopy IsNot Nothing) AndAlso
                ''    Me.ElementSig_RefCopy.WhichSideOfCard = EnumWhichSideOfCard.EnumBackside)
                ''
                ''If (boolBacksideSig) Then
                ''    objSide.ElementSignature = Me.ElementSig_RefCopy
                ''ElseIf (Me.ElementSig_RefCopy Is Nothing) Then
                ''    Me.ElementSig_RefCopy = Me.ListOfElementSignatures_Back.FirstOrDefault()
                ''    objSide.ElementSignature = Me.ElementSig_RefCopy
                ''End If

            Else
                ''
                ''Front side of card. 
                ''
                ''5/20/2022 ''objSide.BackgroundImage = Me.GetBackgroundImage(par_enumWhichSide)
                objSide.BackgroundImage = Me.GetBackgroundImage(par_enumWhichSide,
                                                                par_iBadgeLayout,
                                                                pbBackgroundInfoUpdated)

                ''Jan13 2022 ''objSide.ElementPic = Me.ListOfElementPics_Front().FirstOrDefault()
                ''May15 2022 ''objSide.ElementPortrait_1st = Me.ListOfElementPics_Front().FirstOrDefault()
                ''Moved below, with a condition.--1/14/2022 td''objSide.ElementQRCode = Me.ElementQRCode
                ''Moved below, with a condition.--1/14/2022 td''objSide.ElementSignature = Me.ElementSignature
                objSide.ListElementFieldsV3 = Me.ListOfElementFields_FrontV3
                objSide.ListElementGraphics = Me.ListOfElementGraphics_Front ''Jan22 2022 td''Nothing
                objSide.ListElementStaticTextsV3 = Me.ListOfElementTextsV3_Front
                objSide.ListElementStaticTextsV4 = Me.ListOfElementTextsV4_Front ''Added 2/1/2022 td

                ''Added 1/16/2022 td
                ''May15 2022 ''objSide.ElementQRCode_1st = Me.ListOfElementQRCodes_Front().FirstOrDefault()
                ''May15 2022 ''objSide.ElementSignature_1st = Me.ListOfElementSignatures_Front().FirstOrDefault()

                ''Added 1/14/2022 thomas
                objSide.ListElementPortraits = Me.ListOfElementPics_Front
                objSide.ListElementQRCodes = Me.ListOfElementQRCodes_Front
                objSide.ListElementSignatures = Me.ListOfElementSignatures_Front

                ''========================================================================
                ''QR Code
                ''========================================================================
                ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
                ''We are making a transition, from the older cache property ElementQRCode,
                ''  toward the new cache property of ListOfElementQRCodes_Front.
                ''We are looking for the non-null object, if it exists. 
                ''Please note, the use of the <> unequals operator.   Added 1/14/2022 thomas
                ''========================================================================
                ''Dim boolFrontsideQR As Boolean = (Me.ElementQR_RefCopy IsNot Nothing AndAlso
                ''    Me.ElementQR_RefCopy.WhichSideOfCard <> EnumWhichSideOfCard.EnumBackside)
                ''
                ''If boolFrontsideQR Then
                ''    objSide.ElementQRCode = Me.ElementQR_RefCopy
                ''ElseIf (Me.ElementQR_RefCopy Is Nothing) Then
                ''    Me.ElementQR_RefCopy = Me.ListOfElementQRCodes_Front.FirstOrDefault()
                ''    objSide.ElementQRCode = Me.ElementQR_RefCopy
                ''End If

                ''========================================================================
                ''Signature 
                ''========================================================================
                ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
                ''We are making a transition, from the older cache property ElementSignature,
                ''  toward the new cache property of ListOfElementSignatures_Front.
                ''We are looking for the non-null object, if it exists.  ---1/14/2022 td
                ''Please note, the use of the <> unequals operator.  ---1/14/2022 thomas
                ''========================================================================
                ''Dim boolFrontsideSig As Boolean = (Me.ElementSig_RefCopy IsNot Nothing AndAlso
                ''    Me.ElementSig_RefCopy.WhichSideOfCard <> EnumWhichSideOfCard.EnumBackside)
                ''
                ''If (boolFrontsideSig) Then
                ''    objSide.ElementSignature = Me.ElementSig_RefCopy
                ''ElseIf (Me.ElementSig_RefCopy Is Nothing) Then
                ''    Me.ElementSig_RefCopy = Me.ListOfElementSignatures_Front.FirstOrDefault()
                ''    objSide.ElementSignature = Me.ElementSig_RefCopy
                ''End If

            End If ''End of "If (bBackside) Then ... Else ..."

            ''
            ''Added 1/17/2022 td  
            ''
            If (mod_bOkayToUseExampleQRCode) Then
                ''5/15/2022 If (objSide.ElementQRCode_1st IsNot Nothing) Then
                ''5/15/2022 With objSide.ElementQRCode_1st
                For Each each_ElemQRCode As ClassElementQRCode In objSide.ListElementQRCodes
                    If (each_ElemQRCode.Image_BL Is Nothing) Then
                        each_ElemQRCode.Image_BL = My.Resources.ExampleQRCode
                    End If ''End of ""If (each_ElemQRCode.Image_BL Is Nothing) Then""
                Next each_ElemQRCode
                ''5/15/2022 End With
            End If ''End of "If (mod_bOkayToUseExampleQRCode) Then"

            ''
            ''Added 1/17/2022 td  
            ''
            If (mod_bOkayToUseExampleSignature) Then
                ''5/15/2022 If (objSide.ElementSignature_1st IsNot Nothing) Then
                ''    With objSide.ElementSignature_1st
                ''        If (.Image_BL Is Nothing) Then
                ''            .Image_BL = My.Resources.ExampleSignature
                ''        End If
                ''    End With
                ''End If
                For Each each_ElemSig As ClassElementSignature In objSide.ListElementSignatures
                    If (each_ElemSig.Image_BL Is Nothing) Then
                        each_ElemSig.Image_BL = My.Resources.ExampleQRCode
                    End If ''End of ""If (each_ElemQRCode.Image_BL Is Nothing) Then""
                Next each_ElemSig
            End If ''End of "If (mod_bOkayToUseExampleSignature) Then"

            Return objSide

        End Function ''End of "Public Function GetAllBadgeSideLayoutElements"


        Public Function ListOfFields_SC_Any() As List(Of ClassFieldAny)
            ''
            ''Added 10/14/2019 thomas downes
            ''
            '' SC = Standard & Custom (Fields)  
            '' CS = Custom & Standard (Fields)  
            ''
            Dim output_list_any As New List(Of ClassFieldAny)
            ''Added 5/10/2022
            Dim local_dict_standard As New Dictionary(Of EnumCIBFields, ClassFieldStandard)
            Dim local_dict_any As New Dictionary(Of EnumCIBFields, ClassFieldAny)
            ''----Dim obj_list_custom As List(Of ClassFieldStandard)

            ''5/10/2022 obj_list.AddRange(ListOfFields_Standard)
            ''5/10/2022 obj_list.AddRange(ListOfFields_Custom)

            ''Standard Fields
            Application.DoEvents() ''Allow any latent de-serialization to take place. ---5/10/2022

            If (0 = mod_listFields_Standard.Count) Then
                ''We need to populate the list of standard fields.
                mod_listFields_Standard = ClassFieldStandard.GetInitializedList_Standard("Recip",
                    local_dict_standard)
            End If ''End of ""If (0 = mod_listFields_Standard.Count) Then""

            ''Added 5/10/2022 td
            If (30 < mod_listFields_Standard.Count) Then
                ''Added 5/10/2022 td
                Throw New Exception("The normal number of standard fields is 17, not >30.")
            End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

            output_list_any.AddRange(mod_listFields_Standard)

            ''Start building a 2nd dictionary, for both standard & custom.
            ''    This is to enforce that a field should have a unique
            ''    field-enumeration value. ---5/10/2022
            For Each each_stanF As ClassFieldStandard In mod_listFields_Standard
                local_dict_any.Add(each_stanF.FieldEnumValue, each_stanF)
            Next each_stanF

            ''Custom fields
            Application.DoEvents() ''Allow any latent de-serialization to take place. ---5/10/2022

            If (0 = mod_listFields_Custom.Count) Then
                ''We need to populate the list of custom fields.
                mod_listFields_Custom = ClassFieldCustomized.GetInitializedList_Custom("Recip")
            End If ''End of ""If (0 = mod_listFields_Standard.Count) Then""

            ''Added 5/10/2022 td
            If (30 < mod_listFields_Standard.Count) Then
                ''Added 5/10/2022 td
                Throw New Exception("The normal number of standard fields is 17, not >30.")
            End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

            Dim boolSubstantive As Boolean ''Added 5/10/2022 td
            For Each each_customF As ClassFieldCustomized In mod_listFields_Custom
                boolSubstantive = (each_customF.FieldEnumValue <> EnumCIBFields.Undetermined)
                If (boolSubstantive) Then
                    local_dict_any.Add(each_customF.FieldEnumValue, each_customF)
                    ''Complete work on the output.
                    output_list_any.Add(each_customF)
                End If ''End of ""If (boolSubstantive) Then"
            Next each_customF

            Return output_list_any

        End Function ''End of "Public Function ListOfFields_Any() As List(Of ClassFieldAny)"


        Public Function ListOfFields_SC_CreateCopies() As List(Of ClassFieldAny)
            ''
            ''Added 11/15/2021 thomas downes
            ''
            ''Create copies of the Field objects. 
            ''
            '' SC = Standard & Custom (Fields)  
            '' CS = Custom & Standard (Fields)  
            ''
            Dim obj_list As New List(Of ClassFieldAny)

            ''11/15/2021 td'' obj_list.AddRange(ListOfFields_Standard)
            For Each objFieldS As ClassFieldStandard In ListOfFields_Standard
                ''Make a copy.
                obj_list.Add(objFieldS.Copy())
            Next objFieldS

            ''11/15/2021 td'' obj_list.AddRange(ListOfFields_Custom)
            For Each objFieldC As ClassFieldCustomized In ListOfFields_Custom
                ''Make a copy.
                obj_list.Add(objFieldC.Copy())
            Next objFieldC

            Return obj_list

        End Function ''End of "Public Function ListOfFields_CreateCopies() As List(Of ClassFieldAny)"


        Public Function ListOfFields_SC_ForEditing(ByVal pboolRefreshList As Boolean,
                                                   Optional par_recipInfo As IRecipient = Nothing) As List(Of ClassFieldAny)
            ''
            ''Added 2/20/2020 thomas downes
            ''
            ''SC = Standard & Custom (Fields)  
            ''CS = Custom & Standard (Fields)  
            ''
            Const c_bEditablesOnly As Boolean = True

            ''March14 2022''Return ListOfFields_Any(par_recipInfo, c_bEditablesOnly, False)
            ''March19 2022''Return ListOfFields_SC_AddRecipInfo(par_recipInfo, c_bEditablesOnly, False)
            Return ListOfFields_SC_AddRecipInfo(par_recipInfo, c_bEditablesOnly, pboolRefreshList)

        End Function ''End of "Public Function ListOfFields_SC_ForEditing"


        Public Function ListOfFields_SC_AddRecipInfo(Optional par_recipInfo As IRecipient = Nothing,
                                     Optional ByVal pboolEditablesOnly As Boolean = True,
                                     Optional ByVal pboolRefreshList As Boolean = False,
                                     Optional ByVal pbRelevantFieldsOnly As Boolean = True) _
                                     As List(Of ClassFieldAny)
            ''
            ''Added 10/14/2019 thomas downes
            ''Renamed to "ListOfFields_CS_AddRecipInfo" from "ListOfFields_Any" on March 14 2022.
            ''
            ''SC = Standard & Custom (Fields)  
            ''CS = Custom & Standard (Fields)  
            ''
            ''Step 1 of 3.  Concatenate the Standard & Custom field-lists into a single list. 
            ''
            Static s_obj_listOutput As List(Of ClassFieldAny)
            Dim temporary_listRemove As New List(Of ClassFieldAny)
            Dim bDisplayForEdits As Boolean ''Added 2/20/2020 thomas downes
            Dim bFieldIsRelevant As Boolean ''Added 4/13/2022
            ''----Const c_boolRefreshList As Boolean = False ''Added 2/20/2020
            Dim bReferenceNewRecipInfo As Boolean = True ''Added 2/20/2020
            Dim bStaticOutputIsNothing As Boolean = True ''Added 3/14/2020
            Dim boolUseListAsItIs As Boolean = False ''Added 4/13/2022 td

            ''Added 2/20/2020
            bReferenceNewRecipInfo = (par_recipInfo IsNot Nothing)
            ''Added 3/14/2022
            bStaticOutputIsNothing = (s_obj_listOutput Is Nothing)

            ''
            ''Added 2/20/2020 thomas downes
            ''
            ''Step #1 of 2. Create (or refresh) the list of output fields. 
            ''
            If (pboolRefreshList Or bStaticOutputIsNothing) Then
                ''
                ''Populate the static output list.
                ''
                s_obj_listOutput = New List(Of ClassFieldAny)
                s_obj_listOutput.AddRange(ListOfFields_Standard)
                s_obj_listOutput.AddRange(ListOfFields_Custom)

                ''#1 March13 2022 ''ElseIf (bReferenceNewRecipInfo) Then

            Else
                ''
                ''We are _NOT_ refreshing the content of the list.
                ''   (We might, however, refresh the associated Recipient / Recipient Info.)
                ''  ---4/13/2022
                ''
                boolUseListAsItIs = True

            End If ''End of "If (pboolRefreshList Or s_obj_listOutput Is Nothing) Then"

            ''#1 March13 2022 ''ElseIf (bReferenceNewRecipInfo) Then

            ''
            ''Step #2 of 2.... Append recipient data (if applicable) and return the output list.
            ''
            If (bReferenceNewRecipInfo) Then
                ''
                ''Add a reference to recipient info.
                ''
                For Each each_field As ClassFieldAny In s_obj_listOutput
                    ''Add a reference to recipient info. 
                    each_field.iRecipientInfo = CType(par_recipInfo, IRecipient)
                Next each_field

                ''Return the list, with the updated RecipientInfo.
                ''April 13, 2022 ---Let's not exit the function just yet, we need to remove unneeded items!
                ''April 13, 2022 Return s_obj_listOutput
                If (boolUseListAsItIs) Then Return s_obj_listOutput ''Added 4/13/2022

            Else
                ''Probably won't ever execute, due to the "If" and "ElseIf" conditions above. 
                ''April 13, 2022 ---Let's not exit the function just yet, we need to remove unneeded items!
                ''April 13, 2022 Return s_obj_listOutput
                If (boolUseListAsItIs) Then Return s_obj_listOutput ''Added 4/13/2022

            End If ''End of "If (bReferenceNewRecipInfo) Then .... Else ...."

            ''
            ''Step 2 of 3.  Load the current recipient into each field. 
            ''
            ''Added 12/1/2019 thomas d
            For Each each_field As ClassFieldAny In s_obj_listOutput

                ''Added 2/20/2020 thomas downes  
                bDisplayForEdits = (each_field.IsDisplayedForEdits)
                bFieldIsRelevant = (each_field.IsRelevantToPersonality)

                If (bDisplayForEdits And bFieldIsRelevant) Then
                    ''---4/2022---If bDisplayForEdits Then
                    ''
                    ''Great!   We don't need to remove it. 
                    ''
                ElseIf (pboolEditablesOnly Or pbRelevantFieldsOnly) Then ''4/2022 (pboolEditablesOnly) Then
                    ''Added 2/20/2020 thomas downes
                    ''
                    ''If unneeded, add the uneeded field to the list of fields to be removed. 
                    ''
                    Dim bNotEditable_SoRemove As Boolean ''Added 4/13/2022
                    Dim bNotRelevant_SoRemove As Boolean ''Added 4/13/2022
                    bNotEditable_SoRemove = ((Not bDisplayForEdits) And pboolEditablesOnly)
                    bNotRelevant_SoRemove = ((Not bFieldIsRelevant) And pbRelevantFieldsOnly)

                    If (bNotEditable_SoRemove) Then
                        temporary_listRemove.Add(each_field)
                    ElseIf (bNotRelevant_SoRemove) Then
                        temporary_listRemove.Add(each_field)
                    End If
                    ''Continue For

                End If ''End of "If (bDisplayForEdits) Then ... Else ..."

            Next each_field


            ''Added 2/20/2020 thomas d
            ''
            ''  Remove unneeded fields. 
            ''
            If (pboolEditablesOnly) Then
                For Each each_field As ClassFieldAny In temporary_listRemove
                    ''Added 2/20/2020 thomas downes  
                    s_obj_listOutput.Remove(each_field)
                Next each_field
            End If ''end of "If (pboolEditablesOnly) Then"

            ''
            ''Add a reference to recipient info. 
            ''
            If (bReferenceNewRecipInfo) Then
                For Each each_field As ClassFieldAny In s_obj_listOutput
                    ''Add a reference to recipient info. 
                    each_field.iRecipientInfo = CType(par_recipInfo, IRecipient)
                Next each_field
            End If ''End of "If (c_bReferenceNewRecipInfo) Then"

            ''
            ''Step 3 of 3.  Return the list.  
            ''
            Return s_obj_listOutput

        End Function ''End of "Public Function ListOfFields_Any(par_recipInfo As IRecipient) As List(Of ClassFieldAny)"


        Public Function ListOfFields_AnyRelevent() As List(Of ClassFieldAny)
            ''
            ''Added 5/12/2022 td
            ''
            Dim output_list As New List(Of ClassFieldAny)
            For Each each_stan As ClassFieldStandard In mod_listFields_Standard
                If (each_stan.IsRelevantToPersonality) Then output_list.Add(each_stan)
            Next
            For Each each_cust As ClassFieldCustomized In mod_listFields_Custom
                If (each_cust.IsRelevantToPersonality) Then output_list.Add(each_cust)
            Next
            Return output_list

        End Function ''End of ""Public Function ListOfFields_AnyRelevent()""


        Public Shared DeserializationCompleted As Boolean = True ''Default is True. Added 5/10/2022

        Public Property ListOfFields_Standard As HashSet(Of ClassFieldStandard) ''10/17 ''As List(Of ClassFieldStandard)
            Get ''Added 10/14/2019 td

                Application.DoEvents() ''Allow any latent de-serialization to take place.---5/10/2022 

                ''Add 5/7/2022 thomas
                If (DeserializationCompleted) Then ''Added 5/10/2022
                    If (0 = mod_listFields_Standard.Count) Then
                        mod_listFields_Standard = ClassFieldStandard.GetInitializedList_Standard("Recipients",
                                                        mod_dictionary_FStandard)
                    End If ''End of ""If (0 = mod_listFields_Standard.Count) Then""
                End If ''End of ""If (DeserializationCompleted) Then""

                ''Added 5/10/2022 td
                If (30 < mod_listFields_Standard.Count) Then
                    ''Added 5/10/2022 td
                    Throw New Exception("The normal number of standard fields is 17, not >30.")
                End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

                Return mod_listFields_Standard

            End Get

            Set(value As HashSet(Of ClassFieldStandard))
                ''Added 10/14/2019 td td
                mod_listFields_Standard = value
            End Set

        End Property


        Public Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized) '' List(Of ClassFieldCustomized)
            Get ''Added 10/14/2019 td

                Application.DoEvents() ''Allow any latent de-serialization to take place. 

                ''Added 5/10/2022 td
                If (30 < mod_listFields_Standard.Count) Then
                    ''Added 5/10/2022 td
                    Throw New Exception("The normal number of standard fields is 17, not >30.")
                End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

                ''Added 5/09/2022 thomas d.
                ''   Initialize the list, if necessary. 
                If (DeserializationCompleted) Then ''Added 5/10/2022
                    If (0 = mod_listFields_Custom.Count) Then
                        mod_listFields_Custom = ClassFieldCustomized.GetInitializedList_Custom("Recipients")
                    End If ''End of ""If (0 = mod_listFields_Custom.Count) Then""
                End If ''End of ""If (DeserializationCompleted) Then""

                ''Added 5/10/2022 td
                If (30 < mod_listFields_Standard.Count) Then
                    ''Added 5/10/2022 td
                    Throw New Exception("The normal number of standard fields is 17, not >30.")
                End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

                ''Added 5/7/2022 td
                Return mod_listFields_Custom


            End Get

            Set(value As HashSet(Of ClassFieldCustomized)) '' List(Of ClassFieldCustomized))
                ''Added 10/14/2019 td td
                mod_listFields_Custom = value
            End Set

        End Property


        ''This is deprecated!!  Use ListOfElementFields_Front instead. ---12/21/2021 td
        <Xml.Serialization.XmlIgnore>
        Public Property ListOfElementFields As HashSet(Of ClassElementFieldV3)  ''---List(Of ClassElementField)
            Get ''Added 9/28/2019 td
                ''
                ''This is deprecated!!  Use ListOfElementFields_Front instead. ---12/21/2021 td
                ''
                Return mod_listElementFields_FrontV3
            End Get
            Set(value As HashSet(Of ClassElementFieldV3))  ''---List(Of ClassElementField))
                ''Added 9/28/2019 td
                ''
                ''This is deprecated!!  Use ListOfElementFields_Front instead. ---12/21/2021 td
                ''
                mod_listElementFields_FrontV3 = value
            End Set
        End Property


        Public Property ListOfElementFields_FrontV3 As HashSet(Of ClassElementFieldV3)  ''---List(Of ClassElementField)
            Get ''Added 9/28/2019 td
                Return mod_listElementFields_FrontV3
            End Get
            Set(value As HashSet(Of ClassElementFieldV3))  ''---List(Of ClassElementField))
                ''Added 9/28/2019 td
                mod_listElementFields_FrontV3 = value
            End Set
        End Property


        Public Property ListOfElementFields_FrontV4 As HashSet(Of ClassElementFieldV4)  ''---List(Of ClassElementField)
            Get ''Added 2/10/2022 td
                Return mod_listElementFields_FrontV4
            End Get
            Set(value As HashSet(Of ClassElementFieldV4))  ''---List(Of ClassElementField))
                ''Added 2/10/2022 td
                mod_listElementFields_FrontV4 = value
            End Set
        End Property


        Public Property ListOfElementFields_BacksideV3 As HashSet(Of ClassElementFieldV3)  ''---List(Of ClassElementField)
            Get ''Added 12/18/2021 td
                Return mod_listElementFields_BacksideV3
            End Get
            Set(value As HashSet(Of ClassElementFieldV3))  ''---List(Of ClassElementField))
                ''Added 12/18/2021 td
                mod_listElementFields_BacksideV3 = value
            End Set
        End Property


        Public Property ListOfElementFields_BacksideV4 As HashSet(Of ClassElementFieldV4)  ''---List(Of ClassElementField)
            Get ''Added 2/08/2022 td
                Return mod_listElementFields_BacksideV4
            End Get
            Set(value As HashSet(Of ClassElementFieldV4))  ''---List(Of ClassElementField))
                ''Added 2/08/2022 td
                mod_listElementFields_BacksideV4 = value
            End Set
        End Property


        Public Function ListOfElementFields_BothsidesV3() As HashSet(Of ClassElementFieldV3)
            ''
            ''Added 12/18/2021 td
            ''
            Dim objHashset As HashSet(Of ClassElementFieldV3)

            ''1/8/2022 td''objHashset = New HashSet(Of ClassElementField)(mod_listBadgeElements_Front)
            objHashset = New HashSet(Of ClassElementFieldV3)(mod_listElementFields_FrontV3)

            ''Added any elements currently on the backside of the card. 
            For Each each_elemBack As ClassElementFieldV3 In mod_listElementFields_BacksideV3
                objHashset.Add(each_elemBack)
            Next

            Return objHashset

        End Function ''End of "Public Function ListOfElementFields_BothsidesV3"


        Public Function ListOfElementFields_BothsidesV4() As HashSet(Of ClassElementFieldV4)
            ''Added 2/10/2022 td
            Dim objHashset As HashSet(Of ClassElementFieldV4)
            objHashset = New HashSet(Of ClassElementFieldV4)(mod_listElementFields_FrontV4)
            ''Added any elements currently on the backside of the card. 
            For Each each_elemBack As ClassElementFieldV4 In mod_listElementFields_BacksideV4
                objHashset.Add(each_elemBack)
            Next
            Return objHashset
        End Function ''End of "Public Function ListOfElementFields_BothsidesV4"


        ''Public Function BadgeDisplayElements_Fields(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
        ''    ''
        ''    ''Added 11/24/2021 thomas downes 
        ''    ''
        ''    Return ListOfBadgeDisplayElements_Flds_Front(pboolRefresh)
        ''
        ''End Function

        Public Function BadgeDisplayElements_Fields_FrontV3() As IEnumerable(Of ClassElementFieldV3)
            ''
            ''Added 1/08/2022 thomas downes 
            ''
            ''Return ListOfBadgeDisplayElements_Flds_Front(pboolRefresh)

            With mod_listElementFields_FrontV3
                Return .Where(Function(objEl) objEl.IsDisplayedOnBadge_Visibly())
            End With

        End Function ''End of "Public Function BadgeDisplayElements_Fields_FrontV3"

        Public Function BadgeDisplayElements_Fields_FrontV4() As IEnumerable(Of ClassElementFieldV4)
            ''Added 2/10/2022 thomas downes 
            With mod_listElementFields_FrontV4
                ''5/10/2022 Return .Where(Function(objEl) objEl.IsDisplayedOnBadge_Visibly())
            End With

            ''Added 5/10/2022 td 
            Dim output_list As New List(Of ClassElementFieldV4)
            Dim each_elementfieldV4 As ClassElementFieldV4
            Dim each_field As ClassFieldAny
            Dim each_include As Boolean

            For Each each_elementfieldV4 In mod_listElementFields_FrontV4

                Const c_boolHyperstrict As Boolean = False ''Added 5/10/2022 td
                If (c_boolHyperstrict) Then
                    ''
                    ''Like a heartless bureaucrat, let's make sure every T is crossed. 
                    ''
                    each_field = GetFieldByFieldEnum(each_elementfieldV4.FieldEnum)

                    each_include = (each_field.IsRelevantToPersonality Or
                                each_field.IsDisplayedOnBadge_Front)

                    If each_include Then
                        output_list.Add(each_elementfieldV4)
                    End If

                Else
                    output_list.Add(each_elementfieldV4)

                End If ''End of ""If (c_boolHyperstrict) Then... Else..."

            Next each_elementfieldV4

            Return output_list

        End Function ''End of "Public Function BadgeDisplayElements_Fields_FrontV4"


        ''Public Function ListOfBadgeDisplayElements_Flds_Front(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
        ''    ''---Dec.8 2021--Public Function ListOfBadgeDisplayElements_Flds(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
        ''    ''
        ''    ''Added 11/26/2021  
        ''    ''
        ''    ''Jan8 2022 td''If (pboolRefresh Or (mod_listBadgeElements_Front Is Nothing)) Then
        ''    If (pboolRefresh Or (mod_listElementFields_Front Is Nothing)) Then

        ''        ''----Dec.8 2021---RefreshListOfBadgeDisplayElements_Flds()
        ''        RefreshListOfBadgeDisplayElements_Flds_Front()

        ''    End If ''End of "If (pboolRefresh Or (mod_listBadgeElements_Front Is Nothing)) Then"

        ''    ''Jan8 2022''---Return mod_listBadgeElements_Front
        ''    Return mod_listElementFields_Front

        ''End Function ''end of "Public Function ListOfBadgeDisplayElements_Flds_Front()"


        ''Public Function ListOfBadgeDisplayElements_Flds_Backside(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
        ''    ''
        ''    ''Added 12/08/2021  
        ''    ''
        ''    If (pboolRefresh Or (mod_listBadgeElements_Backside Is Nothing)) Then
        ''        ''Major call!!
        ''        RefreshListOfBadgeDisplayElements_Flds_Backside()

        ''    End If ''End of "If (pboolRefresh Or (mod_listBadgeElements_Back Is Nothing)) Then"

        ''    ''Jan8 2022 td''Return mod_listBadgeElements_Backside
        ''    Return mod_listElementFields_Backside

        ''End Function ''end of "Public Function ListOfBadgeDisplayElements_Flds_Backside()"


        Public Function ListOfBadgeDisplayElements_Flds_FrontV3(Optional pboolSkip13 As Boolean = True,
                                            Optional pboolSkip14 As Boolean = True) _
                                            As List(Of ClassElementFieldV3)
            ''
            ''--Jan.8 2022--Public Sub RefreshListOfBadgeDisplayElements_Flds_Front
            ''--Dec.8 2021--Public Sub RefreshListOfBadgeDisplayElements_Flds
            ''
            ''Added 11/24/2021 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            ''Jan08 2022 ''Dim new_list As New HashSet(Of ClassElementField)  ''End of "List(Of ClassElementField)"
            Dim new_list As New List(Of ClassElementFieldV3)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementFieldV3
            Dim boolOnDisplay As Boolean
            Dim structWhyOmitV1 As New ciBadgeElements.WhyOmitted_StructV1
            Dim structWhyOmitV2 As New ciBadgeInterfaces.WhyOmitted_StructV2 ''Added 1/24/2022
            Dim indexBadgeDisplay As Integer

            For Each each_element In mod_listElementFields_FrontV3
                ''
                ''Major call. 
                ''
                ''Jan24 2022''boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmit)
                boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)

                If (boolOnDisplay) Then
                    new_list.Add(each_element)
                    indexBadgeDisplay += 1
                    ''Added 11/26/2021 thomas downes
                    ''   Let's accomodate the fact that the webside has Badge Display #s 1, 2, 3, ... 12 and 15 ... 19.
                    ''   (Notice that #s 13 & 14 are not in use, as an obselete gap between standard & custom fields.) 
                    If (pboolSkip13 And indexBadgeDisplay = 13) Then indexBadgeDisplay = 14
                    If (pboolSkip14 And indexBadgeDisplay = 14) Then indexBadgeDisplay = 15

                    each_element.BadgeDisplayIndex = indexBadgeDisplay
                    ''Added 11/29/2021 td
                    each_element.DatetimeUpdated = DateTime.Now

                End If ''End of "If (boolOnDisplay) Then"
            Next each_element

            ''Jan.8 2022''mod_listBadgeElements_Front = new_list
            Return new_list

        End Function ''End of "Public Function RefreshListOfBadgeDisplayElements_Flds_Front()"


        Public Function ListOfBadgeDisplayElements_Flds_BacksideV3(Optional pboolSkip13 As Boolean = True,
                                                      Optional pboolSkip14 As Boolean = True) _
                                                     As List(Of ClassElementFieldV3)
            ''--Jan.8 2022--Public Sub RefreshListOfBadgeDisplayElements_Flds_Backside
            ''--Dec.8 2021--Public Sub RefreshListOfBadgeDisplayElements_Flds
            ''
            ''Added 12/8/2021 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            ''Jan8 2022 td''Dim new_list As New HashSet(Of ClassElementField)  ''End of "List(Of ClassElementField)"
            Dim new_list As New List(Of ClassElementFieldV3)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementFieldV3
            Dim boolOnDisplay As Boolean
            Dim structWhyOmitV1 As New ciBadgeElements.WhyOmitted_StructV1
            Dim structWhyOmitV2 As New ciBadgeInterfaces.WhyOmitted_StructV2 ''Added 1/24/2022 td
            Dim indexBadgeDisplay As Integer

            If (mod_listElementFields_BacksideV3 Is Nothing) Then mod_listElementFields_BacksideV3 = New HashSet(Of ClassElementFieldV3)

            For Each each_element In mod_listElementFields_BacksideV3
                ''
                ''Major call. 
                ''
                ''Jan24 2022''boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmit)
                boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)

                If (boolOnDisplay) Then
                    new_list.Add(each_element)
                    indexBadgeDisplay += 1
                    ''Added 11/26/2021 thomas downes
                    ''   Let's accomodate the fact that the webside has Badge Display #s 1, 2, 3, ... 12 and 15 ... 19.
                    ''   (Notice that #s 13 & 14 are not in use, as an obselete gap between standard & custom fields.) 
                    If (pboolSkip13 And indexBadgeDisplay = 13) Then indexBadgeDisplay = 14
                    If (pboolSkip14 And indexBadgeDisplay = 14) Then indexBadgeDisplay = 15

                    each_element.BadgeDisplayIndex = indexBadgeDisplay
                    ''Added 11/29/2021 td
                    each_element.DatetimeUpdated = DateTime.Now

                End If ''End of "If (boolOnDisplay) Then"
            Next each_element

            ''Save to the module-level list, suffixed "_Backside". 
            ''Jan8 2022''mod_listBadgeElements_Backside = new_list
            Return new_list

        End Function ''End of "Public Function ListOfBadgeDisplayElements_Flds_BacksideV3()"


        Public Function ListOfBadgeDisplayElements_Flds_FrontV4(Optional pboolSkip13 As Boolean = True,
                                            Optional pboolSkip14 As Boolean = True) _
                                            As List(Of ClassElementFieldV4)
            ''
            ''Added 1/08/2022 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            Dim new_list As New List(Of ClassElementFieldV4)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementFieldV4
            Dim boolOnDisplay As Boolean
            Dim structWhyOmitV1 As New ciBadgeElements.WhyOmitted_StructV1
            Dim structWhyOmitV2 As New ciBadgeInterfaces.WhyOmitted_StructV2 ''Added 1/24/2022
            Dim indexBadgeDisplay As Integer

            For Each each_element In mod_listElementFields_FrontV4
                ''
                ''Major call. 
                ''
                ''---5/3/2022 td---boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)
                boolOnDisplay = each_element.Visible ''Added 5/11/2022 td

                If (boolOnDisplay) Then
                    new_list.Add(each_element)
                    indexBadgeDisplay += 1
                    ''Added 11/26/2021 thomas downes
                    ''   Let's accomodate the fact that the webside has Badge Display #s 1, 2, 3, ... 12 and 15 ... 19.
                    ''   (Notice that #s 13 & 14 are not in use, as an obselete gap between standard & custom fields.) 
                    If (pboolSkip13 And indexBadgeDisplay = 13) Then indexBadgeDisplay = 14
                    If (pboolSkip14 And indexBadgeDisplay = 14) Then indexBadgeDisplay = 15

                    each_element.BadgeDisplayIndex = indexBadgeDisplay
                    ''Added 11/29/2021 td
                    each_element.DatetimeUpdated = DateTime.Now

                End If ''End of "If (boolOnDisplay) Then"
            Next each_element

            Return new_list

        End Function ''End of "Public Function RefreshListOfBadgeDisplayElements_Flds_FrontV4()"


        Public Function ListOfBadgeDisplayElements_Flds_BacksideV4(Optional pboolSkip13 As Boolean = True,
                                                      Optional pboolSkip14 As Boolean = True) _
                                                     As List(Of ClassElementFieldV4)
            ''
            ''Added 2/08/2022 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            Dim new_list As New List(Of ClassElementFieldV4)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementFieldV4
            Dim boolOnDisplay As Boolean
            Dim structWhyOmitV1 As New ciBadgeElements.WhyOmitted_StructV1
            Dim structWhyOmitV2 As New ciBadgeInterfaces.WhyOmitted_StructV2 ''Added 1/24/2022 td
            Dim indexBadgeDisplay As Integer

            If (mod_listElementFields_BacksideV4 Is Nothing) Then mod_listElementFields_BacksideV4 = New HashSet(Of ClassElementFieldV4)

            For Each each_element In mod_listElementFields_BacksideV4
                ''
                ''Major call. 
                ''
                ''Jan24 2022''boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmit)
                ''5/03/022 td''boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmitV1, structWhyOmitV2)
                boolOnDisplay = each_element.Visible

                If (boolOnDisplay) Then
                    new_list.Add(each_element)
                    indexBadgeDisplay += 1
                    ''Added 11/26/2021 thomas downes
                    ''   Let's accomodate the fact that the webside has Badge Display #s 1, 2, 3, ... 12 and 15 ... 19.
                    ''   (Notice that #s 13 & 14 are not in use, as an obselete gap between standard & custom fields.) 
                    If (pboolSkip13 And indexBadgeDisplay = 13) Then indexBadgeDisplay = 14
                    If (pboolSkip14 And indexBadgeDisplay = 14) Then indexBadgeDisplay = 15

                    each_element.BadgeDisplayIndex = indexBadgeDisplay
                    ''Added 11/29/2021 td
                    each_element.DatetimeUpdated = DateTime.Now

                End If ''End of "If (boolOnDisplay) Then"
            Next each_element

            ''Save to the module-level list, suffixed "_Backside". 
            ''Jan8 2022''mod_listBadgeElements_Backside = new_list
            Return new_list

        End Function ''End of "Public Function ListOfBadgeDisplayElements_Flds_BacksideV4()"


        ''This is deprecated!!  Use ListOfElementPics_Front instead. ---12/21/2021 td
        ''March3 2022''<Xml.Serialization.XmlIgnore>
        Public Function ListOfElementPics_BothSides() As HashSet(Of ClassElementPortrait)  ''---List(Of ClassElementPic)
            ''March3 2022''Get ''Added 10/13/2019 td
            ''
            ''This property is Deprecated, so return Nothing. ----12/20/2021 thomas d.
            ''
            ''March3 2022 ''Return mod_listElementPics_Front ''Nothing ''Dec20 2021''mod_listElementPics_Front

            Dim objOutput As HashSet(Of ClassElementPortrait) ''Added 3/3/2022 td

            objOutput = New HashSet(Of ClassElementPortrait)(mod_listElementPics_Front)

            For Each each_portrait As ClassElementPortrait In mod_listElementPics_Backside
                objOutput.Add(each_portrait)
            Next each_portrait

            Return objOutput

            ''March3 2022''End Get
            ''March3 2022''Set(value As HashSet(Of ClassElementPortrait))  ''---List(Of ClassElementPic))
            ''Added 10/13/2019 td
            ''
            ''This is deprecated!!  Use ListOfElementFields_Front instead. ---12/21/2021 td
            ''
            ''March3 2022''mod_listElementPics_Front = value
            ''March3 2022''End Set

        End Function ''March3 2022''Property


        Public Property ListOfElementPics_Front As HashSet(Of ClassElementPortrait)  ''---List(Of ClassElementPic)
            Get ''Added 10/13/2019 td
                Return mod_listElementPics_Front
            End Get
            Set(value As HashSet(Of ClassElementPortrait))  ''---List(Of ClassElementPic))
                ''Added 10/13/2019 td
                mod_listElementPics_Front = value
            End Set
        End Property


        Public Property ListOfElementPics_Back As HashSet(Of ClassElementPortrait)  ''---List(Of ClassElementPic)
            Get ''Added 12/18/2021 td
                Return mod_listElementPics_Backside
            End Get
            Set(value As HashSet(Of ClassElementPortrait))  ''---List(Of ClassElementPic))
                ''Added 12/18/2021 td
                mod_listElementPics_Backside = value
            End Set
        End Property


        Public Property ListOfElementQRCodes_Front As HashSet(Of ClassElementQRCode)  ''---List(Of ClassElementPic)
            Get ''Added 1/14/2022 td
                Return mod_listElementQRCodes_Front
            End Get
            Set(value As HashSet(Of ClassElementQRCode))  ''---List(Of ClassElementPic))
                ''Added 1/14/2022 td
                mod_listElementQRCodes_Front = value
            End Set
        End Property


        Public Property ListOfElementQRCodes_Back As HashSet(Of ClassElementQRCode)  ''---List(Of ClassElementPic)
            Get ''Added 1/14/2022 td
                Return mod_listElementQRCodes_Backside
            End Get
            Set(value As HashSet(Of ClassElementQRCode))  ''---List(Of ClassElementPic))
                ''Added 1/14/2022 td
                mod_listElementQRCodes_Backside = value
            End Set
        End Property



        Public Property ListOfElementSignatures_Front As HashSet(Of ClassElementSignature)  ''---List(Of ClassElementPic)
            Get ''Added 1/14/2022 td
                Return mod_listElementSignatures_Front
            End Get
            Set(value As HashSet(Of ClassElementSignature))  ''---List(Of ClassElementPic))
                ''Added 1/14/2022 td
                mod_listElementSignatures_Front = value
            End Set
        End Property


        Public Property ListOfElementSignatures_Back As HashSet(Of ClassElementSignature)  ''---List(Of ClassElementPic)
            Get ''Added 1/14/2022 td
                Return mod_listElementSignatures_Backside
            End Get
            Set(value As HashSet(Of ClassElementSignature))  ''---List(Of ClassElementPic))
                ''Added 1/14/2022 td
                mod_listElementSignatures_Backside = value
            End Set
        End Property


        ''This is deprecated!!  Use ListOfElementTexts_Front instead. ---12/21/2021 td
        <Xml.Serialization.XmlIgnore>
        Public Property ListOfElementTextsV3 As HashSet(Of ClassElementStaticTextV3)  ''---List(Of ClassElementPic)
            Get ''Added 12/20/2021 td
                ''
                ''This property is Deprecated, so return Nothing. ----12/20/2021 thomas d.
                ''
                Return mod_listElementStaticsV3_Front ''--Nothing ''Dec20 2021''mod_listElementPics_Front
            End Get
            Set(value As HashSet(Of ClassElementStaticTextV3))  ''---List(Of ClassElementPic))
                ''Added 12/20/2021 td
                mod_listElementStaticsV3_Front = value
            End Set
        End Property


        Public Property ListOfElementTextsV3_Front As HashSet(Of ClassElementStaticTextV3)  ''---List(Of ClassElementStaticText)
            Get ''Added 10/14/2019 td
                Return mod_listElementStaticsV3_Front
            End Get
            Set(value As HashSet(Of ClassElementStaticTextV3))  ''---List(Of ClassElementStaticText))
                ''Added 10/14/2019 td
                mod_listElementStaticsV3_Front = value
            End Set
        End Property


        Public Property ListOfElementTextsV3_Backside As HashSet(Of ClassElementStaticTextV3)  ''---List(Of ClassElementStaticText)
            Get ''Added 12/18/2021 td
                Return mod_listElementStaticsV3_Backside
            End Get
            Set(value As HashSet(Of ClassElementStaticTextV3))  ''---List(Of ClassElementStaticText))
                ''Added 12/18/2021 td
                mod_listElementStaticsV3_Backside = value
            End Set
        End Property


        Public Property ListOfElementTextsV4_Front As HashSet(Of ClassElementStaticTextV4)  ''---List(Of ClassElementStaticText)
            Get ''Added 10/14/2019 td
                Return mod_listElementStaticsV4_Front
            End Get
            Set(value As HashSet(Of ClassElementStaticTextV4))  ''---List(Of ClassElementStaticText))
                ''Added 10/14/2019 td
                mod_listElementStaticsV4_Front = value
            End Set
        End Property


        Public Property ListOfElementTextsV4_Backside As HashSet(Of ClassElementStaticTextV4)
            Get ''Added 12/18/2021 td
                Return mod_listElementStaticsV4_Backside
            End Get
            Set(value As HashSet(Of ClassElementStaticTextV4))  ''---List(Of ClassElementStaticText))
                ''Added 12/18/2021 td
                mod_listElementStaticsV4_Backside = value
            End Set
        End Property

        ''Added 1/8/2022. ---1/08/2022 td
        Public Property ListOfElementGraphics_Front As HashSet(Of ClassElementGraphic)
            Get ''Added 1/08/2022 td
                ''
                ''Added 1/00/2022 thomas d.
                ''
                Return mod_listElementGraphics_Front
            End Get
            Set(value As HashSet(Of ClassElementGraphic))
                ''Added 1/08/2028 td
                mod_listElementGraphics_Front = value
            End Set
        End Property


        ''Added 1/8/2022. ---1/08/2022 td
        Public Property ListOfElementGraphics_Backside As HashSet(Of ClassElementGraphic)
            Get ''Added 1/08/2022 td
                ''
                ''Added 1/00/2022 thomas d.
                ''
                Return mod_listElementGraphics_Backside
            End Get
            Set(value As HashSet(Of ClassElementGraphic))
                ''Added 1/08/2028 td
                mod_listElementGraphics_Backside = value
            End Set
        End Property


        ''Moved up.  2/4/2020 td''Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

        ''Added 1/12/2020 thomas d. 
        ''Moved up.  2/4/2020 td''Public Property PathToBackgroundImageFile As String ''Added 1/12/2019 thomas downes

        ''Moved up.  2/4/2020 t d''<Xml.Serialization.XmlIgnore>
        ''Moved up.  2/4/2020 td''Public Property Pic_InitialDefault As Image ''Added 9/23/2019 td 

        ''10/14/2019 td''Public Function ListFields_Denigrated() As List(Of ClassFieldAny)
        ''    ''
        ''    ''Added 9/19/2019 thomas downes
        ''    ''
        ''    Return mod_listFields

        ''End Function ''End of "Public Function Fields() As List(Of ClassFieldAny)"

        Public Function ListFieldElementsV3() As HashSet(Of ClassElementFieldV3)
            ''10/17 td''Public Function ListFieldElements() As List(Of ClassElementField)
            ''
            ''Added 9/16/2019 thomas downes
            ''
            Return mod_listElementFields_FrontV3

        End Function ''End of "Public Function ListFieldElementsV3() As List(Of ClassElementText)"


        Public Function ListFieldElementsV4() As HashSet(Of ClassElementFieldV4)
            ''Added 2/10/2022 thomas downes
            Return mod_listElementFields_FrontV4

        End Function ''End of "Public Function ListFieldElementsV4() As List(Of ClassElementText)"


        Public Function PicElement_Front() As ClassElementPortrait
            ''
            ''Added 9/16/2019 thomas downes
            ''
            If (MissingTheElementPic()) Then Return Nothing ''Added 10/12/2019 td

            Return mod_listElementPics_Front(0)

        End Function ''End of "Public Function PicElement() As ClassElementPic"

        ''This is deprecated!!  Use ListOfElementPics_Front instead. ---12/21/2021 td
        Public Function ListPicElements_Front() As HashSet(Of ClassElementPortrait)  ''---List(Of ClassElementPic)
            ''
            ''Added 9/17/2019 thomas downes
            ''
            ''This is deprecated!!  Use Public Property ListOfElementPics_Front instead. ---12/21/2021 td
            ''
            Return mod_listElementPics_Front

        End Function ''End of " Public Function ListPicElements() As List(Of ClassElementPic)"


        Public Function ListStaticTextElementsV3_Front() As HashSet(Of ClassElementStaticTextV3)  ''---List(Of ClassElementStaticText)
            ''
            ''Added 9/16/2019 thomas downes
            ''
            ''This is deprecated!!  Use Public Property ListOfElementTexts_Front instead. ---12/21/2021 td
            ''
            Return mod_listElementStaticsV3_Front

        End Function ''End of "Public Function ListStaticTextElementsV3_Front() As List(Of ClassElementStaticText)"


        Public Function ListStaticTextElementsV3_Backside() As HashSet(Of ClassElementStaticTextV3)  ''---List(Of ClassElementStaticText)
            ''Added 12/20/2021 thomas downes
            Return mod_listElementStaticsV3_Backside
        End Function ''End of "Public Function ListStaticTextElements_Backside() As List(Of ClassElementStaticText)"


        Public Function ListStaticTextElementsV4_Front() As HashSet(Of ClassElementStaticTextV4)  ''---List(Of ClassElementStaticText)
            ''
            ''Added 1/31/2022 thomas downes
            ''
            Return mod_listElementStaticsV4_Front

        End Function ''End of "Public Function ListStaticTextElementsV3_Front() As List(Of ClassElementStaticText)"


        Public Function ListStaticTextElementsV4_Backside() As HashSet(Of ClassElementStaticTextV4)
            ''Added 1/31/2022 thomas downes
            Return mod_listElementStaticsV4_Backside
        End Function ''End of "Public Function ListStaticTextElementsV4_Backside() As List(Of ClassElementStaticText)"



        Public Function LaysectionElements() As HashSet(Of ClassElementLaysection)  ''---List(Of ClassElementLaysection)
            ''
            ''Added 9/17/2019 thomas downes
            ''
            Return mod_listElementLaysections_Front

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
            ''5/3/2022 td''ClassFieldStandard.InitializeHardcodedList_Students(True)
            ''5/9/2022 td''ClassFieldStandard.InitializeHardcodedList_Standard(True)

            ''----------------------------------------------------------------------------------------------------
            ''Custom Fields (Initialize the list)  
            ''
            ''5/3/2022 td ''ClassFieldCustomized.InitializeHardcodedList_Students(True)
            ''5/9/2022 td''ClassFieldCustomized.InitializeHardcodedList_Custom(True)

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
            Application.DoEvents() ''Allow any latent de-serialization to take place. ---5/10/2022

            If (0 = mod_listFields_Standard.Count) Then
                Dim objListFields_Standard As HashSet(Of ClassFieldStandard)
                ''Added 5/10/2022
                Dim dictionary_FStandard As New Dictionary(Of EnumCIBFields, ClassFieldStandard)

                objListFields_Standard = ClassFieldStandard.GetInitializedList_Standard("Students",
                                                     dictionary_FStandard)
                ''Added 5/10/2022 td
                mod_listFields_Standard = objListFields_Standard
                mod_dictionary_FStandard = dictionary_FStandard

            End If ''End of ""If (0 = mod_listFields_Standard.Count) Then""

            ''Added 5/10/2022 td
            If (30 < mod_listFields_Standard.Count) Then
                ''Added 5/10/2022 td
                Throw New Exception("The normal number of standard fields is 17, not >30.")
            End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

            ''For Each each_field_standard As ClassFieldStandard In mod_listFields_Standard ''5/10/2022 ClassFieldStandard.ListOfFields_Standard ''5/3/2022 _Students
            ''
            ''    ''10/14/2019 td''mod_listFields.Add(each_field_standard)
            ''    mod_listFields_Standard.Add(each_field_standard)
            ''
            ''Next each_field_standard

            ''----------------------------------------------------------------------------------------------------

            ''----------------------------------------------------------------------------------------------------
            ''Customized Fields (Collect the list items)  
            ''
            ''----5/3/2022 td''For Each each_field_customized As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students
            ''5/9/2022 For Each each_field_customized As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Custom
            ''5/9/2022 
            ''5/9/2022 ''    ''10/14/2019 td''mod_listFields.Add(each_field_customized)
            ''5/9/2022 ''    mod_listFields_Custom.Add(each_field_customized)
            ''5/9/2022  
            ''5/9/2022 ''Next each_field_customized

            Application.DoEvents() ''Allow any latent de-serialization to take place. ---5/10/2022

            If (0 = mod_listFields_Custom.Count) Then
                mod_listFields_Custom = ClassFieldCustomized.GetInitializedList_Custom("Students")
            End If ''End of ""If (0 = mod_listFields_Custom.Count) Then""
            ''----------------------------------------------------------------------------------------------------

            ''Added 5/10/2022 td
            If (30 < mod_listFields_Standard.Count) Then
                ''Added 5/10/2022 td
                Throw New Exception("The normal number of standard fields is 17, not >30.")
            End If ''End of ""If (30 < mod_listFields_Standard.Count) Then""

        End Sub ''End of "Public Sub LoadFields(par_pictureBackground As PictureBox)"


        Public Sub LoadField_ByEnum_Deprecated(p_enumField As EnumCIBFields, p_boolIsCustomField As Boolean)
            ''
            ''As of 5/10/2022, this procedure is suffixed "_Deprecated" because the 
            ''   Fields should be created (more or less) as a single unit.  It's
            ''   okay to reference a single Field, but it's not okay to create it 
            ''   as a free-floating entity.  It should be closely "housed" with 
            ''   the other fields, as if it was an apartment in an apartment building.
            ''   ----5/10/2022 td 
            ''
            ''Added 3/23/2022 td
            ''
            ''5/5/2022 td ''If (p_bCustom) Then Throw New Exception("not yet set up for custom fields")

            ''Major call!!
            ''----LoadField_ByEnum_Standard(p_enumField)

            Dim bAlreadyLoaded As Boolean
            bAlreadyLoaded = (GetFieldByFieldEnum(p_enumField) IsNot Nothing)

            If bAlreadyLoaded Then
                ''
                ''Do nothing.  Already loaded.  We don't need duplicates!
                ''
            ElseIf p_boolIsCustomField Then
                ''
                ''Customized Field
                ''
                Dim objNewFieldFC As ClassFieldCustomized
                ''5/09/2022 objNewFieldFC = ClassFieldCustomized.BuildField_ByEnum_Customized(p_enumField)
                objNewFieldFC = ClassFieldCustomized.GetField_ByEnum_Custom(p_enumField)
                mod_listFields_Custom.Add(objNewFieldFC)

            Else
                ''
                ''Standard Field
                ''
                Dim objNewFieldFS As ClassFieldStandard
                ''5/09/2022 objNewFieldFS = ClassFieldStandard.BuildField_ByEnum_Standard(p_enumField)
                objNewFieldFS = ClassFieldStandard.GetField_ByEnum_Standard_Deprecated(p_enumField)
                mod_listFields_Standard.Add(objNewFieldFS)

            End If ''end of ""If bAlreadyLoaded Then... Else...""

        End Sub ''End of "LoadField_ByEnum_Deprecated(each_enum)"


        Public Sub LoadFields_FromList(par_listStandard As List(Of ClassFieldStandard),
                                   par_listCustom As List(Of ClassFieldCustomized))
            ''
            ''Added 11/17/2021 td 
            ''
            mod_listFields_Standard = New HashSet(Of ClassFieldStandard)(par_listStandard)
            mod_listFields_Custom = New HashSet(Of ClassFieldCustomized)(par_listCustom)

            ''
            ''Added 11/17/2021 td 
            ''
            ''Since the FieldElements rely heavily on the Fields,
            ''   we must refresh the connections between the two. 
            ''
            Dim each_element As ciBadgeElements.ClassElementFieldV3
            Dim eachrelated_field As ciBadgeFields.ClassFieldAny

            For Each each_element In ListFieldElementsV3()
                ''
                ''Refresh the .FieldObject & .FieldInfo properties.
                ''
                eachrelated_field = GetFieldByFieldEnum(each_element.FieldEnum)
                ''5/11/2022 each_element.FieldObjectAny = eachrelated_field
                ''5/11/2022 each_element.FieldInfo = CType(eachrelated_field, ICIBFieldStandardOrCustom)
                each_element.LoadFieldAny(eachrelated_field) ''Added 12/13/2021 td

            Next each_element

        End Sub ''End of "Public Sub LoadFields_FromList"


        Public Sub LoadFieldsFromList_Deprecated(par_listFieldAny As List(Of ClassFieldAny))
            ''Public Sub LoadFields_FromList(par_listFieldAny As List(Of ClassFieldAny))
            ''
            ''Added 11/15/2019 td
            ''
            ''Custom Fields (Initialize the list)  
            ''
            ''ClassFieldCustomized.InitializeHardcodedList_Students(True)
            mod_listFields_Custom = Nothing
            mod_listFields_Standard = Nothing

            mod_listFields_Custom = New HashSet(Of ClassFieldCustomized)
            mod_listFields_Standard = New HashSet(Of ClassFieldStandard)

            ''
            ''End of "Part 1 of 2.  Initialize the lists." 
            ''

            ''
            ''Part 2 of 2.  Collect the list items. 
            ''
            ''Standard Fields (Collect the list items)  
            ''
            ''---For Each each_field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students
            For Each each_field_standard As ClassFieldAny In par_listFieldAny

                ''10/14/2019 td''mod_listFields.Add(each_field_standard)
                If (TypeOf each_field_standard Is ClassFieldStandard) Then
                    ''---mod_listFields_Standard.Add(each_field_standard)
                    mod_listFields_Standard.Add(CType(each_field_standard, ClassFieldStandard))
                End If

            Next each_field_standard

            ''
            '' Check!!   ---11/17/2021 thomas downes
            ''
            If (mod_listFields_Standard.Count = 0) Then
                ''Added 11/17/2021 thomas downes
                Throw New Exception("Load failed, the standard list of fields is empty.")
            End If ''end of "If (mod_listFields_Standard.Count = 0) Then"

            ''----------------------------------------------------------

            ''---------------------------------------------------------
            ''Customized Fields (Collect the list items)  
            ''
            ''--For Each each_field_customized As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students
            For Each each_field_custom As ClassFieldAny In par_listFieldAny

                ''10/14/2019 td''mod_listFields.Add(each_field_customized)
                ''11/17/2021''mod_listFields_Custom.Add(each_field_customized)
                If (TypeOf each_field_custom Is ClassFieldCustomized) Then
                    ''---mod_listFields_Standard.Add(each_field_standard)
                    mod_listFields_Custom.Add(CType(each_field_custom, ClassFieldCustomized))
                End If

            Next each_field_custom

            ''
            '' Check!!   ---11/17/2021 thomas downes
            ''
            If (mod_listFields_Custom.Count = 0) Then
                ''Added 11/17/2021 thomas downes
                Throw New Exception("Load failed, the standard list of fields is empty.")
            End If ''end of "If (mod_listFields_Custom.Count = 0) Then"

            ''-------------------------------------------------------------------------------------

        End Sub ''End of "Public Sub LoadFields_FromList(par_listFieldAny As As List(Of ClassFieldAny))"


        Public Sub LoadFieldElements(par_pictureBackground As PictureBox, par_layout As BadgeLayoutClass)
            ''
            ''Added 9/16/2019 thomas d. 
            ''
            ''------------------------------------------------------------------------------------
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
            ''---   ----------------------------------------------------------------------------------------

            ''--------------------------------------------------------------------------------------
            ''
            ''Part 2 of 2.  Collect the list items. 
            ''
            ''--------------------------------------------------------------------------------------
            ''Standard Fields (Collect the list items)  
            ''
            ''For Each field_standard As ClassFieldStandard In ClassFieldStandard.ListOfFields_Students

            ''    mod_listElementFields.Add(field_standard.ElementFieldClass)

            ''    ''Added 9/16/2019 td  
            ''    field_standard.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

            ''Next field_standard
            ''------------------------------------------------------------------------------------

            ''---------------------------------------------------------------------------------------
            ''Custom Fields (Collect the list items) 
            ''
            ''For Each field_custom As ClassFieldCustomized In ClassFieldCustomized.ListOfFields_Students

            ''    mod_listElementFields.Add(field_custom.ElementFieldClass)

            ''    ''Added 9/16/2019 td  
            ''    field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

            ''Next field_custom
            ''-------------------------------------------------------------------------------------

            Dim new_elementField As ClassElementFieldV3 ''Added 9/18/2019 td
            Dim intFieldIndex As Integer ''Added 9/18/2019 td
            Dim intLeft_Pixels As Integer ''Added 9/18/2019 td
            Dim intTop_Pixels As Integer ''Added 9/18/2019 td
            Const c_intHeight_Pixels As Integer = 30 ''Added 9/18/2019 td

            ''Added 9/18/2019 td
            ''10/14/2019 td''For Each each_field As ClassFieldAny In mod_listFields
            For Each each_field As ClassFieldAny In Me.ListOfFields_SC_Any()

                ''Added 5/11/2022 td
                ''  Only relevant fields. 
                If (Not each_field.IsRelevantToPersonality) Then Continue For

                ''Fields cannot link to elements.---9/18/2019 td''mod_listElementFields.Add(each_field.ElementFieldClass)

                ''Added 9/16/2019 td  
                ''Fields cannot link to elements.---9/18/2019 td''field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

                intFieldIndex += 1
                ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
                'intTop_Pixels = (c_intHeight_Pixels * (intFieldIndex - 1))
                intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

                ''Added 9/18/2019 td
                new_elementField = New ClassElementFieldV3(each_field, intLeft_Pixels, intTop_Pixels, c_intHeight_Pixels)
                ''5/11/2022 new_elementField.FieldInfo = each_field
                new_elementField.FieldEnum = each_field.FieldEnumValue ''Added 10/12/2019 td

                ''Added 10/13/2019 td
                new_elementField.BadgeLayout = par_layout

                ''Added 11/29/2021 td
                new_elementField.DatetimeUpdated = Now

                ''Added 9/19/2019 td
                mod_listElementFields_FrontV3.Add(new_elementField)

            Next each_field

        End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As PictureBox)"

        Public Sub LoadFieldElements(par_layout As BadgeLayoutClass)
            ''
            ''Added 11/15/2019 thomas d. 
            ''
            Dim new_elementField As ClassElementFieldV3 ''Added 9/18/2019 td
            Dim intFieldIndex As Integer ''Added 9/18/2019 td
            Dim intLeft_Pixels As Integer ''Added 9/18/2019 td
            Dim intTop_Pixels As Integer ''Added 9/18/2019 td
            Const c_intHeight_Pixels As Integer = 30 ''Added 9/18/2019 td

            ''Added 9/18/2019 td
            ''10/14/2019 td''For Each each_field As ClassFieldAny In mod_listFields
            For Each each_field As ClassFieldAny In Me.ListOfFields_SC_Any()

                ''Fields cannot link to elements.---9/18/2019 td''mod_listElementFields.Add(each_field.ElementFieldClass)

                ''Added 9/16/2019 td  
                ''Fields cannot link to elements.---9/18/2019 td''field_custom.ElementFieldClass.BadgeLayout = New BadgeLayoutClass(par_pictureBackground)

                intFieldIndex += 1
                ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
                'intTop_Pixels = (c_intHeight_Pixels * (intFieldIndex - 1))
                intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

                ''Added 9/18/2019 td
                new_elementField = New ClassElementFieldV3(each_field, intLeft_Pixels, intTop_Pixels, c_intHeight_Pixels)
                ''5/11/2022 new_elementField.FieldInfo = each_field
                new_elementField.FieldEnum = each_field.FieldEnumValue ''Added 10/12/2019 td

                ''Added 10/13/2019 td
                new_elementField.BadgeLayout = par_layout

                ''Added 11/29/2021 td
                new_elementField.DatetimeUpdated = DateTime.Now

                ''Added 9/19/2019 td
                mod_listElementFields_FrontV3.Add(new_elementField)

            Next each_field

        End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As Image)"


        Public Function LoadNewElement_FieldV3(par_enumField As EnumCIBFields,
                                        par_intLeft_Pixels As Integer,
                                        par_intTop_Pixels As Integer,
                                        par_layout As BadgeLayoutClass,
                                        par_enumSide As EnumWhichSideOfCard) _
                                        As ClassElementFieldV3 ''5/13/2022 = Nothing
            '' = EnumWhichSideOfCard.EnumFrontside)
            ''
            ''Added 5/6/2022 thomas downes
            ''
            Dim obj_field As ClassFieldAny
            Dim new_elementField As ClassElementFieldV3 ''Added 9/18/2019 td
            Dim intFieldIndex As Integer ''Added 9/18/2019 td
            Dim intLeft_Pixels As Integer ''Added 9/18/2019 td
            Dim intTop_Pixels As Integer ''Added 9/18/2019 td
            Const c_intHeight_Pixels As Integer = 30 ''Added 9/18/2019 td
            Dim intCountElements_Before As Integer = 0 ''Added 5/12/2022 td
            Dim intCountElements_After As Integer = 0 ''Added 5/12/2022 td

            ''
            ''Part 1 of 5.  Get the "Before" count.
            ''
            ''Added 5/12/2022 td
            If (par_enumSide = EnumWhichSideOfCard.EnumBackside) Then
                ''Count the backside field elements. 
                intCountElements_Before = mod_listElementFields_BacksideV3.Count ''--- +
                '-------------------------mod_listElementFields_BacksideV4.Count
            Else
                ''Count the frontside field elements. 
                intCountElements_Before = mod_listElementFields_FrontV3.Count ''--- +
                '-------------------------mod_listElementFields_FrontV4.Count
            End If

            ''
            ''Part 2 of 5.  Do the work of creating the new element.
            ''
            obj_field = GetFieldByFieldEnum(par_enumField)

            ''----intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

            new_elementField = New ClassElementFieldV3(obj_field,
                                    par_intLeft_Pixels,
                                    par_intTop_Pixels,
                                    c_intHeight_Pixels)
            ''5/11/2022 new_elementField.FieldInfo = obj_field
            new_elementField.FieldEnum = obj_field.FieldEnumValue ''Added 10/12/2019 td
            new_elementField.BadgeLayout = par_layout
            new_elementField.DatetimeUpdated = DateTime.Now
            ''5/13/2022 td''par_newElementFieldV3 = new_elementField ''Added 5/12/2022 

            ''
            ''Part 3 of 5.  Do the work of adding the new element to the list of elements.
            ''
            If (par_enumSide = EnumWhichSideOfCard.EnumBackside) Then
                mod_listElementFields_BacksideV3.Add(new_elementField)
            Else
                mod_listElementFields_FrontV3.Add(new_elementField)
            End If

            ''
            ''Part 4 of 5.  Count the number of items in the list, for the "After" count.
            ''
            If (par_enumSide = EnumWhichSideOfCard.EnumBackside) Then
                ''Count the backside field elements. 
                intCountElements_After = mod_listElementFields_BacksideV3.Count ''--- +
                '-------------------------mod_listElementFields_BacksideV4.Count
            Else
                ''Count the frontside field elements. 
                intCountElements_After = mod_listElementFields_FrontV3.Count ''--- +
                '-------------------------mod_listElementFields_FrontV4.Count
            End If

            ''
            ''Compare the Before & After counts.  
            ''
            Dim intCountDifference As Integer
            intCountDifference = (intCountElements_After - intCountElements_Before)
            If (intCountDifference = 0) Then
                System.Diagnostics.Debugger.Break()
            End If ''End of""If (intCountDifference = 0) Then""

            ''
            ''Exit Handler
            ''
            Return new_elementField

        End Function ''End of ""Public Function LoadNewElement_FieldV3()""


        Public Function LoadNewElement_FieldV4(par_enumField As EnumCIBFields,
                                        par_intLeft_Pixels As Integer,
                                        par_intTop_Pixels As Integer,
                                        par_layout As BadgeLayoutClass,
                  par_enumSide As EnumWhichSideOfCard) _
                  As ClassElementFieldV4
            ''
            ''Added 5/11/2022 thomas downes
            ''
            Dim obj_field As ClassFieldAny
            Dim new_elementField As ClassElementFieldV4 ''Added 9/18/2019 td
            Const c_intHeight_Pixels As Integer = 30 ''Added 9/18/2019 td

            obj_field = GetFieldByFieldEnum(par_enumField)

            new_elementField = New ClassElementFieldV4(obj_field,
                                    par_intLeft_Pixels,
                                    par_intTop_Pixels,
                                    c_intHeight_Pixels)

            new_elementField.FieldEnum = obj_field.FieldEnumValue ''Added 10/12/2019 td
            new_elementField.BadgeLayout = par_layout
            new_elementField.DatetimeUpdated = DateTime.Now

            If (par_enumSide = EnumWhichSideOfCard.EnumBackside) Then
                ''
                ''Back side of card. 
                ''
                new_elementField.WhichSideOfCard = EnumWhichSideOfCard.EnumBackside
                mod_listElementFields_BacksideV4.Add(new_elementField)
            Else
                ''
                ''Front side of card. 
                ''
                new_elementField.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                mod_listElementFields_FrontV4.Add(new_elementField)

            End If ''End of ""If (par_enumSide = EnumWhichSideOfCard.EnumBackside) Then... Else ....""

            Return new_elementField ''Added 5/13/2022 td

        End Function ''End of ""Public Function LoadNewElement_FieldV4()""


        Public Function LoadNewElement_Pic(par_intLeft As Integer, par_intTop As Integer,
                                   par_intWidth As Integer, par_intHeight As Integer,
                                   par_pictureBackground As PictureBox,
                                   par_enum As EnumWhichSideOfCard) _
                                   As ClassElementPortrait
            ''10/10/2019 td''Public Sub LoadPicElement(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)
            '' 
            ''Added 9/16/2019 td  
            ''
            Dim objElementPic As ClassElementPortrait ''Added 9/16/2019 td 
            Dim objRectangle As Rectangle ''Added 9/16/2019 td  
            Dim intLeft As Integer
            Dim intTop As Integer

            ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

            intLeft = par_intLeft ''9/19 td''(par_picturePortrait.Left - par_pictureBackground.Left)
            intTop = par_intTop ''9/19 td''(par_picturePortrait.Top - par_pictureBackground.Top)

            ''9/19/2019 td''objRectangle = New Rectangle(intLeft, intTop, par_picturePortrait.Width, par_picturePortrait.Height)
            objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

            objElementPic = New ClassElementPortrait(objRectangle, par_pictureBackground)

            objElementPic.PicFileIndex = 1

            ''1/19/2022 td''mod_listElementPics_Front.Add(objElementPic)
            ''
            ''Add the new element to the appropriate list in the cache. ---1/19/2022 
            ''
            If (par_enum = EnumWhichSideOfCard.EnumBackside) Then

                ListOfElementPics_Back.Add(objElementPic)

            Else
                ListOfElementPics_Front.Add(objElementPic)

            End If ''Endof "If (par_enum = EnumWhichSideOfCard.EnumBackside) Then... Else ..."

            ''Added 5/14/2022 td
            Return objElementPic

        End Function ''End of "Public Sub LoadElement_Pic(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"


        Public Function LoadNewElement_QRCode(par_intLeft As Integer, par_intTop As Integer,
                                      par_intWidth As Integer, par_intHeight As Integer,
                                      par_pictureBackground As PictureBox,
                                      par_enumWhichSide As EnumWhichSideOfCard) _
                                      As ClassElementQRCode
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
            objElementQR.WhichSideOfCard = par_enumWhichSide ''Added 5/15/2022 td 

            ''10/10/2019 td''objElementQR.PicFileIndex = 1
            ''10/10/2019 td''mod_listElementPics.Add(objElementPic)

            ''No longer needed.1/19/2022''Me.ElementQR_RefCopy = objElementQR

            ''
            ''Add the new element to the appropriate list in the cache. ---1/19/2022 
            ''
            If (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) Then

                ListOfElementQRCodes_Back.Add(objElementQR)

            Else
                ListOfElementQRCodes_Front.Add(objElementQR)

            End If ''Endof "If (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) Then... Else ..."

            Return objElementQR ''Added 5/14/2022 td

        End Function ''End of "Public Function LoadElement_QRCode(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"


        Public Function LoadNewElement_Signature(par_intLeft As Integer, par_intTop As Integer,
                                         par_intWidth As Integer, par_intHeight As Integer,
                                         par_pictureBackground As PictureBox,
                                         par_enumWhichSide As EnumWhichSideOfCard) As ClassElementSignature
            ''5/14/2022  Public Sub LoadNewElement_Signature 
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
            objElementSig.WhichSideOfCard = par_enumWhichSide ''Added 5/15/2022 td 

            ''No longer needed.1/19/2022''Me.ElementSig_RefCopy = objElementSig

            ''
            ''Add the new element to the appropriate list in the cache. ---1/19/2022 
            ''
            If (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) Then
                ListOfElementSignatures_Back.Add(objElementSig)

            Else
                ListOfElementSignatures_Front.Add(objElementSig)

            End If ''Endof "If (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) Then... Else ..."

            Return objElementSig ''Added 5/14/2022 td 

        End Function ''End of "Public Function LoadElement_Signature(par_intLeft As Integer, par_intTop As Integer, par_intWidth As Integer, par_intHeight As Integer, par_pictureBackground As PictureBox)"


        Public Sub LoadNewElement_Portrait(par_picturePortrait As PictureBox,
                                           par_pictureBackground As PictureBox,
            Optional par_enumWhichSide As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside)
            ''10/8/2019 td''Public Sub LoadPicElement(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)
            ''
            ''Added 9/16/2019 td  
            ''
            Dim objElementPic As ClassElementPortrait ''Added 9/16/2019 td 
            Dim objRectangle As Rectangle ''Added 9/16/2019 td  
            Dim intLeft As Integer
            Dim intTop As Integer

            ciPictures_VB.PictureExamples.PathToFolderOfImages = (My.Application.Info.DirectoryPath & "\Images\PictureExamples")

            intLeft = (par_picturePortrait.Left - par_pictureBackground.Left)
            intTop = (par_picturePortrait.Top - par_pictureBackground.Top)

            objRectangle = New Rectangle(intLeft, intTop, par_picturePortrait.Width, par_picturePortrait.Height)

            objElementPic = New ClassElementPortrait(objRectangle, par_pictureBackground)

            objElementPic.PicFileIndex = 1
            objElementPic.WhichSideOfCard = par_enumWhichSide ''Added 5/15/2022 td 

            If (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) Then
                ''Added 1/19/2022 td
                mod_listElementPics_Backside.Add(objElementPic)
            Else
                mod_listElementPics_Front.Add(objElementPic)
            End If ''End of ""If (par_enumWhichSide =....) Then ... Else..." 

        End Sub ''End of "Public Sub LoadNewElement_Portrait(par_picturePortrait As PictureBox, par_pictureBackground As PictureBox)"


        Public Sub LoadNewElement_Signature(par_picSignature As PictureBox,
                                            par_pictureBackground As PictureBox,
            Optional par_enum As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside)
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
            ''No longer needed.1/19/2022''Me.ElementSig_RefCopy = objElementSig

            ''
            ''Add the new element to the appropriate list in the cache. ---1/19/2022 
            ''
            If (par_enum = EnumWhichSideOfCard.EnumBackside) Then
                ListOfElementSignatures_Back.Add(objElementSig)

            Else
                ListOfElementSignatures_Front.Add(objElementSig)

            End If ''Endof "If (par_enum = EnumWhichSideOfCard.EnumBackside) Then... Else ..."

        End Sub ''End of "Public Sub LoadNewElement_Signature(par_picSignature As PictureBox, par_pictureBackground As PictureBox)"


        Public Sub LoadNewElement_QRCode(par_picQRCode As PictureBox, par_pictureBackground As PictureBox,
            Optional par_enum As EnumWhichSideOfCard = EnumWhichSideOfCard.EnumFrontside)
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
            ''No longer needed.1/19/2022''Me.ElementQR_RefCopy = objElementQR

            ''
            ''Add the new element to the appropriate list in the cache. ---1/19/2022 
            ''
            If (par_enum = EnumWhichSideOfCard.EnumBackside) Then

                ListOfElementQRCodes_Back.Add(objElementQR)

            Else
                ListOfElementQRCodes_Front.Add(objElementQR)

            End If ''Endof "If (par_enum = EnumWhichSideOfCard.EnumBackside) Then... Else ..."


        End Sub ''End of "Public Sub LoadNewElement_QRCode(par_picQRCode As PictureBox, par_pictureBackground As PictureBox)"


        Public Function LoadNewElement_Graphic(par_intLeft As Integer, par_intTop As Integer,
                                    par_intWidth As Integer, par_intHeight As Integer,
                                    par_pictureBackground As PictureBox,
                                    par_enum As EnumWhichSideOfCard,
                                    par_layoutOfBadge As BadgeLayoutClass) As ClassElementGraphic
            ''
            ''Added 5/14/2022 td  
            ''
            Dim objElement As ClassElementGraphic ''Added 10/10/2019 td 
            Dim objRectangleOfControl As Rectangle ''Added 10/10/2019 td  
            Dim intLeft As Integer
            Dim intTop As Integer
            Dim strPathToGraphicsFile As String ''Added 5/14/2022 td 

            ''Added 5/14/2022 td 
            strPathToGraphicsFile = DiskFilesVB.Path_ToGraphicsImageFile

            ''Dim bMissingBack As Boolean ''Added 12/17/2021 td
            ''Dim bMissingFront As Boolean ''Added 12/17/2021 td
            ''Dim bMissingBackAndFront As Boolean ''Added 12/17/2021 td
            ''Dim bProceedWithMakingNew As Boolean ''Added 1/19/2021 td

            ''Added 12/17/2021 td
            ''bMissingFront = (0 = mod_listElementGraphics_Front.Count)
            ''bMissingBack = (0 = mod_listElementGraphics_Backside.Count)
            ''bMissingBackAndFront = (bMissingFront And bMissingBack)

            ''''Added 1/19/2022 td
            ''bProceedWithMakingNew = (bMissingBackAndFront Or (Not pbOnlyIfMissingFrontAndBack))

            ''''Jan19 2022''If bMissingBackAndFront Then ''Added 12/17/2021 td 
            ''If bProceedWithMakingNew Then ''Added 12/17/2021 td 

            ''Layout adjustment is probably not needed here.5/16/2022 ''intLeft = (par_intLeft - par_pictureBackground.Left)
            ''Layout adjustment is probably not needed here.5/16/2022 intTop = (par_intTop - par_pictureBackground.Top)
            intLeft = (par_intLeft) ''Layout adjustment is not needed here.5/16/2022 - par_pictureBackground.Left)
            intTop = (par_intTop) ''Layout adjustment is not needed here.5/16/2022 - par_pictureBackground.Top)

            objRectangleOfControl = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

            ''5/14/2022 objElement = New ClassElementGraphic(intLeft, intTop, par_intHeight)
            objElement = New ClassElementGraphic(objRectangleOfControl,
                                                 par_layoutOfBadge,
                                                 strPathToGraphicsFile)

            If (par_enum = EnumWhichSideOfCard.EnumBackside) Then
                mod_listElementGraphics_Backside.Add(objElement)
            Else
                mod_listElementGraphics_Front.Add(objElement)
            End If

            ''End If ''end of "If bProceedWithMakingNew Then"

            Return objElement

        End Function ''End of "Public Function LoadNewElement_Graphic(par_intLeft As Integer, ...., par_pictureBackground As PictureBox)"


        Public Function LoadNewElement_StaticTextV3(par_DisplayText As String,
                                    par_intLeft As Integer, par_intTop As Integer,
                                    par_intWidth As Integer, par_intHeight As Integer,
                                    par_pictureBackground As PictureBox,
                                    par_enum As EnumWhichSideOfCard,
                                    Optional pbOnlyIfMissingFrontAndBack As Boolean = False) _
                                    As ClassElementStaticTextV3
            ''---Jan19 2022---LoadNewElement_StaticText_IfNeeded
            ''---Dec17 2021---Public Sub LoadElement_Text
            ''
            ''Added 10/10/2019 td  
            ''
            Dim objElementText As ClassElementStaticTextV3 = Nothing ''Added 10/10/2019 td 
            Dim objRectangle As Rectangle ''Added 10/10/2019 td  
            Dim intLeft As Integer
            Dim intTop As Integer
            Dim bMissingBack As Boolean ''Added 12/17/2021 td
            Dim bMissingFront As Boolean ''Added 12/17/2021 td
            Dim bMissingBackAndFront As Boolean ''Added 12/17/2021 td
            Dim bProceedWithMakingNew As Boolean ''Added 1/19/2021 td

            ''Added 12/17/2021 td
            bMissingFront = (0 = mod_listElementStaticsV3_Front.Count)
            bMissingBack = (0 = mod_listElementStaticsV3_Backside.Count)
            bMissingBackAndFront = (bMissingFront And bMissingBack)

            ''Added 1/19/2022 td
            bProceedWithMakingNew = (bMissingBackAndFront Or (Not pbOnlyIfMissingFrontAndBack))

            ''Jan19 2022''If bMissingBackAndFront Then ''Added 12/17/2021 td 
            If bProceedWithMakingNew Then ''Added 12/17/2021 td 

                ''Layout adjustment is probably not needed here.5/16/2022 ''intLeft = (par_intLeft - par_pictureBackground.Left)
                ''Layout adjustment is probably not needed here.5/16/2022 ''intTop = (par_intTop - par_pictureBackground.Top)
                intLeft = (par_intLeft) ''Layout adjustment is not needed here.5/16/2022 - par_pictureBackground.Left)
                intTop = (par_intTop) ''Layout adjustment is not needed here.5/16/2022 - par_pictureBackground.Top)

                objRectangle = New Rectangle(intLeft, intTop, par_intWidth, par_intHeight)

                objElementText = New ClassElementStaticTextV3(par_DisplayText, intLeft, intTop, par_intHeight)

                If (par_enum = EnumWhichSideOfCard.EnumBackside) Then
                    mod_listElementStaticsV3_Backside.Add(objElementText)
                Else
                    mod_listElementStaticsV3_Front.Add(objElementText)
                End If

            End If ''end of "If bProceedWithMakingNew Then"

            ''Added 5/14/2022 td
            Return objElementText


        End Function ''End of "Public Function LoadNewElement_StaticText(par_DisplayText As String, par_intLeft As Integer, ...., par_pictureBackground As PictureBox)"


        Public Sub LoadRecipient(par_recipient As ClassRecipient)
            ''10/16/2019 td''Public Sub LoadRecipient(par_recipient As IRecipient)
            ''
            ''Added 10/5/2019 thomas downwe
            ''
            ''10/16/2019 td''For Each each_elementField As ClassElementField In ListOfElementFields
            ''     ''
            ''     ''Attach the Recipient.  
            ''     ''
            ''     ''10/16/2019 td''each_elementField.Recipient = par_recipient
            ClassElementFieldV3.oRecipient = par_recipient

            ''10/16/2019 td''Next each_elementField

        End Sub ''End of "Public Sub LoadRecipient(par_recipient As IRecipient)"

        Public Function Copy_Deprecated(Optional pboolCopyGuid As Boolean = False) As ClassElementsCache_Deprecated
            ''
            ''Added 9/17/2019 thomas downes  
            ''
            Dim objCopyOfCache As ClassElementsCache_Deprecated
            Dim ListFields_NotUsed As New List(Of ClassFieldAny)
            Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)
            ''10/14/2019 td''Dim copy_ofField As ClassFieldAny
            Dim copy_ofField_Stan As ClassFieldStandard
            Dim copy_ofField_Cust As ClassFieldCustomized
            Dim copy_ofElementField As ClassElementFieldV3 ''Added 10/1/2019 td

            ''Added 11/30/2021 td 
            objCopyOfCache = New ClassElementsCache_Deprecated

            ''Added 10/13/2019 thomas d.
            objCopyOfCache.PathToXml_Saved = Me.PathToXml_Saved

            ''Added 02/04/2020 thomas d.
            objCopyOfCache.PathToXml_Binary = Me.PathToXml_Binary
            objCopyOfCache.XmlFile_Path_Deprecated = Me.XmlFile_Path_Deprecated
            objCopyOfCache.XmlFile_FTitle_Deprecated = Me.XmlFile_FTitle_Deprecated
            objCopyOfCache.BackgroundImage_Front_Path = Me.BackgroundImage_Front_Path
            objCopyOfCache.BackgroundImage_Front_FTitle = Me.BackgroundImage_Front_FTitle

            ''Added 12/12/2021 td
            objCopyOfCache.BadgeHasTwoSidesOfCard = Me.BadgeHasTwoSidesOfCard

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

                copy_ofField_Stan = each_field_Stan.Copy_FieldStandard()
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

                copy_ofField_Cust = each_field_Cust.Copy_FieldCustom()
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
            For Each each_elementField As ClassElementFieldV3 In mod_listElementFields_FrontV3
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

                ''10/12/2019 td ''dictionaryFields.TryGetValue(each_elementField.FieldInfo.FieldEnumValue, copy_ofElementField.FieldObject)
                '' 5/20/2022 td ''dictionaryFields.TryGetValue(each_elementField.FieldEnum, copy_ofElementField.FieldObjectAny)
                dictionaryFields.TryGetValue(each_elementField.FieldEnum,
                             GetFieldByFieldEnum(each_elementField.FieldEnum))

                ''Added 10/13/2019 td
                ''5/10/2022 td''copy_ofElementField.FieldInfo = CType(copy_ofElementField.FieldObjectAny, ICIBFieldStandardOrCustom)

                objCopyOfCache.ListFieldElementsV3().Add(copy_ofElementField)

            Next each_elementField

            ''Added 9/17/2019 thomas downes  
            For Each each_elementPic As ClassElementPortrait In mod_listElementPics_Front
                objCopyOfCache.ListPicElements_Front().Add(each_elementPic.Copy())
            Next each_elementPic

            ''Added 9/17/2019 thomas downes  
            For Each each_elementStaticText As ClassElementStaticTextV3 In mod_listElementStaticsV3_Front

                ''Iterate through each Static-Text Element. 
                objCopyOfCache.ListStaticTextElementsV3_Front().Add(each_elementStaticText.Copy())

            Next each_elementStaticText

            ''Added 12/20/2021 thomas downes  
            For Each each_elementStaticText As ClassElementStaticTextV3 In mod_listElementStaticsV3_Backside

                ''Iterate through each Static-Text Element. 
                objCopyOfCache.ListStaticTextElementsV3_Backside().Add(each_elementStaticText.Copy())

            Next each_elementStaticText

            ''Added 10/8/2019 thomas downes
            ''
            ''If the QR Code &/or Signature have been supplied, then we can proceed to copy them. 
            ''
            ''Jan19 2022 td''If (Me.ElementQR_RefCopy IsNot Nothing) Then objCopyOfCache.ElementQR_RefCopy = Me.ElementQR_RefCopy.Copy

            ''Added 1/19/2022 thomas downes  
            For Each each_elementQRCode As ClassElementQRCode In mod_listElementQRCodes_Front
                objCopyOfCache.ListOfElementQRCodes_Front().Add(each_elementQRCode.Copy())
            Next each_elementQRCode

            ''Added 1/19/2022 thomas downes  
            For Each each_elementQRCode As ClassElementQRCode In mod_listElementQRCodes_Backside
                objCopyOfCache.ListOfElementQRCodes_Back().Add(each_elementQRCode.Copy())
            Next each_elementQRCode

            ''Added 10/8/2019 thomas downes
            ''Jan19 2022 td''If (Me.ElementSig_RefCopy IsNot Nothing) Then objCopyOfCache.ElementSig_RefCopy = Me.ElementSig_RefCopy.Copy

            ''Added 1/19/2022 thomas downes  
            For Each each_elementSig As ClassElementSignature In mod_listElementSignatures_Front
                objCopyOfCache.ListOfElementSignatures_Front().Add(each_elementSig.Copy())
            Next each_elementSig

            ''Added 1/19/2022 thomas downes  
            For Each each_elementSig As ClassElementSignature In mod_listElementSignatures_Backside
                objCopyOfCache.ListOfElementSignatures_Back().Add(each_elementSig.Copy())
            Next each_elementSig


            ''Added 10/10/2019 thomas downes
            objCopyOfCache.PathToXml_Saved = Me.PathToXml_Saved

            ''Added 12/14/2021 thomas downes
            objCopyOfCache.Pic_InitialDefault = Me.Pic_InitialDefault

            ''Added 11/30/2021 td
            If (pboolCopyGuid) Then
                objCopyOfCache.Id_GUID = Me.Id_GUID
                objCopyOfCache.Id_GUID6 = Me.Id_GUID6 ''Added 12/12/2021 td 
                objCopyOfCache.Id_GUID6_CopiedFrom = Me.Id_GUID6 ''Added 12/12/2021 td
                Throw New NotImplementedException("Not a good idea. Instead, check property Id_GUID6_CopiedFrom.")
            Else
                ''Added 12/12/2021 Thomas Downes 
                objCopyOfCache.Id_GUID6_CopiedFrom = Me.Id_GUID6 ''Added 12/12/2021 td
                objCopyOfCache.Id_GUID = New Guid()
                objCopyOfCache.Id_GUID6 = objCopyOfCache.Id_GUID.ToString().Substring(0, 6)

            End If ''End of "If (pboolCopyGuid) Then ... Else..."

            Return objCopyOfCache

        End Function ''End of "Public Function Copy() As ClassElementsCache"

        Public Sub CheckCacheIsLatestForEdits(ByRef pref_pIsLatest As Boolean,
                                               Optional ByRef pref_IsACopyOfLatest As Boolean = False)
            ''
            ''Added 12/12/2021 thomas 
            ''
            pref_pIsLatest = (Me.Id_GUID6 = ClassCacheManagement.LatestCacheOfEdits_Guid6)
            pref_IsACopyOfLatest = (Me.Id_GUID6_CopiedFrom = ClassCacheManagement.LatestCacheOfEdits_Guid6)

        End Sub ''End of "Public Sub CheckCacheIsLatestForEdits()"


        Public Sub Check_LinkElementsToFields(Optional pboolOverride As Boolean = True,
                                             Optional ByRef pref_strReport As String = "")
            ''
            ''Added 10/12/2019 thomas d. 
            ''
            ''
            ''
            Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)
            ''Dim pstrReport As String

            ''Added 12/14/2021 td 
            pref_strReport = "Addressed field-related references for {0} of {1} elements."

            ''Added 9/29/2019 thomas downes  
            For Each each_field As ClassFieldAny In ListOfFields_SC_Any() ''10/14/2019 td''In mod_listFields
                Try
                    dictionaryFields.Add(each_field.FieldEnumValue, each_field)
                Catch ex_AddFailed As Exception
                    ''Added 10/12/2019 td
                    System.Diagnostics.Debugger.Break()
                End Try
            Next each_field

            Dim found_field As ClassFieldAny ''Added 10/12/2019 td

            For Each each_elementField As ClassElementFieldV3 In mod_listElementFields_FrontV3

                found_field = Nothing ''Initialize. ----10/12/2019 td

                dictionaryFields.TryGetValue(each_elementField.FieldEnum, found_field)

                ''
                ''Fill in the missing links !!!  ---comment 12/14/2021 td
                ''
                With each_elementField ''Added 12/14/2021 td
                    ''5/11/2022 td''If ((.FieldInfo Is Nothing) Or pboolOverride) Then ''Added 12/14/2021 td
                    ''
                    ''    .FieldInfo = found_field
                    ''    .FieldObjectAny = found_field
                    ''    .LoadFieldAny(found_field) ''Added 12/13/2021 td
                    ''
                    ''End If ''End of "If ((.FieldInfo Is Nothing) Or pboolOverride) Then"
                End With ''End of "With each_elementField"

            Next each_elementField

        End Sub ''End of "Public Sub LinkElementsToFields()"


        Public Sub LinkElementsToFields(Optional pboolOverride As Boolean = True,
                                             Optional ByRef pref_strReport As String = "")
            ''
            ''Added 12/14/2021 td 
            ''
            Check_LinkElementsToFields(pboolOverride, pref_strReport)

        End Sub

        Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementFieldV3
            ''
            ''Added 9/30/2019 td  
            ''
            Throw New NotImplementedException("Not implemented.   #x4591")


        End Function ''End of "Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField"


        Public Function MissingTheFields() As Boolean
            ''Added 10/10/2019 td 
            ''10/14/2019 td''Return (0 = mod_listFields.Count)
            Return (0 = mod_listFields_Standard.Count)

        End Function ''ENd of "Public Function MissingTheFields() As Boolean"


        Public Function MissingTheElementFields() As Boolean
            ''
            ''Added 10/10/2019 td
            ''
            ''Dec17 2021 td''Return (0 = mod_listElementFields_Front.Count)
            Return (0 = mod_listElementFields_FrontV3.Count And
                    0 = mod_listElementFields_BacksideV3.Count)

        End Function ''ENd of "Public Function MissingTheElementFields() As Boolean"

        Public Function MissingTheElementTexts() As Boolean
            ''Added 10/11/2019 td 

            ''10/14 td''Return (0 = mod_listElementStatics.Count)
            ''Dec17 2021 td''Return True ''Added 10/14/2019 td 
            ''Dec17 2021 td''Return (Me.ElementStaticText1 Is Nothing)

            ''Dec17 2021''Return (0 = mod_listElementStatics_Front.Count And
            ''                    0 = mod_listElementStatics_Backside.Count)
            Dim bMissingBack As Boolean ''Added 12/17/2021 td
            Dim bMissingFront As Boolean ''Added 12/17/2021 td
            Dim bMissingBackAndFront As Boolean ''Added 12/17/2021 td

            ''Added 12/17/2021 td
            Dim intCountFrontside As Integer = mod_listElementStaticsV3_Front.Count
            Dim intCountBackside As Integer = mod_listElementStaticsV3_Backside.Count
            Dim intCountBacksideAndFront As Integer ''Added 12/23/2021 Thomas Downes

            bMissingFront = (0 = intCountFrontside)
            bMissingBack = (0 = intCountBackside)
            intCountBacksideAndFront = (intCountBackside + intCountFrontside) ''Added 12/23/2021 thomas downes
            bMissingBackAndFront = (bMissingFront And bMissingBack)

            If (1 <> intCountBacksideAndFront) Then

                ''Added 12/17/2021 td
                Dim strCountOfBothSides As String = ""
                Dim bRandomness As Boolean ''Added 12/17/2021 td
                bRandomness = (2 = CType((New Random(3)).Next(0, 4), Integer))
                If bRandomness Then
                    strCountOfBothSides = String.Format("There are {0} static-texts in front, {1} on the backside.",
                  intCountFrontside, intCountBackside)
                    MessageBox.Show(strCountOfBothSides, "", MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Exclamation)
                End If ''End of "If bRandomness Then" 

            End If ''End of "If (1 <> intCountBacksideAndFront) Then"

            Return bMissingBackAndFront

        End Function ''ENd of "Public Function MissingTheElementTexts() As Boolean"

        Public Function MissingTheElementPic() As Boolean
            ''
            ''Added 10/10/2019 td
            ''
            ''Dec17 2021 td''Return (0 = mod_listElementPics_Front.Count)
            Return (0 = mod_listElementPics_Front.Count And
                    0 = mod_listElementPics_Backside.Count)

        End Function ''ENd of "Public Function MissingTheElementPic() As Boolean"

        Public Function MissingTheQRCode() As Boolean
            ''Added 10/10/2019 td 
            ''1/19/2022''Return (Me.ElementQR_RefCopy Is Nothing)
            Return (Me.GetElementQR(False) Is Nothing AndAlso
                     Me.GetElementQR(True) Is Nothing)

        End Function ''ENd of "Public Function MissingTheQRCode() As Boolean"

        Public Function MissingTheSignature() As Boolean

            ''Added 10/10/2019 td 
            ''1/19/2022 td''Return (Me.ElementSig_RefCopy Is Nothing)
            Return (Me.GetElementSig(False) Is Nothing AndAlso
                     Me.GetElementSig(True) Is Nothing)

        End Function ''ENd of "Public Function MissingTheSignature() As Boolean"

        Public Function GetElementByFieldEnum(par_enum As EnumCIBFields) As ClassElementFieldV3
            ''
            ''Added 10/13/2019 td
            ''
            Dim bMisaligned As Boolean ''Added 12/13/2021 td

            For Each each_elementField As ClassElementFieldV3 In mod_listElementFields_FrontV3
                With each_elementField

                    ''Dec13 2021''.FieldEnum = .FieldObjectAny.FieldEnumValue ''This is a double-check that the Enum value matches. 
                    ''5/11/2022 bMisaligned = (.FieldEnum <> .FieldObjectAny.FieldEnumValue)
                    ''5/11/2022 If (bMisaligned) Then
                    ''    Throw New DataMisalignedException()
                    ''End If ''end of "If (bMisaligned) Then"

                    If (.FieldEnum = par_enum) Then Return each_elementField

                End With ''End of "With each_elementField"
            Next each_elementField

            Return (Nothing)

        End Function ''ENd of "Public Function GetElementByFieldEnum"


        Public Function GetFieldByLabelCaption(par_caption As String) As ClassFieldAny
            ''Added 10/10/2019 td 
            ''Return (Nothing)

            Dim boolMatchesSearch As Boolean

            Dim each_fieldAny As ClassFieldAny

            For Each each_fieldAny In ListOfFields_SC_Any()

                boolMatchesSearch = (each_fieldAny.FieldLabelCaption = par_caption)
                If (boolMatchesSearch) Then Return each_fieldAny

            Next each_fieldAny

            Return Nothing

        End Function ''ENd of "Public Function GetFieldByLabelCaption(par_caption As String) As ClassFieldAny"


        Public Function GetFieldByFieldEnum(par_enum As EnumCIBFields) As ClassFieldAny
            ''
            ''Added 11/17/2021 td
            ''
            ''First, check standard fields. 
            For Each objFld As ClassFieldStandard In mod_listFields_Standard
                ''Find the right field, by it's enumerated value.
                If (objFld.FieldEnumValue = par_enum) Then Return objFld
            Next objFld

            ''Second, check custom fields. 
            For Each objFld As ClassFieldCustomized In mod_listFields_Custom
                ''Find the right field, by it's enumerated value.
                If (objFld.FieldEnumValue = par_enum) Then Return objFld
            Next objFld

            Return Nothing ''Not found.  Added 5/11/2022

        End Function ''ENd of "Public Function GetFieldByFieldEnum  


        Public Function GetFieldByFieldEnum_Standard(par_enum As EnumCIBFields) As ClassFieldStandard
            ''
            ''Added 5/11/2022 & 11/17/2021 td
            ''Check across all standard fields. 
            ''
            For Each objFld As ClassFieldStandard In mod_listFields_Standard
                ''Find the right field, by it's enumerated value.
                If (objFld.FieldEnumValue = par_enum) Then Return objFld
            Next objFld

            Return Nothing ''Not found among the Standard fields.  Added 5/11/2022

        End Function ''ENd of "Public Function GetFieldByFieldEnum_Standard  


        Public Function GetFieldByFieldEnum_Custom(par_enum As EnumCIBFields) As ClassFieldCustomized
            ''
            ''Added 5/11/2022 & 11/17/2021 td
            ''
            ''Check all custom fields.
            ''
            For Each objFld As ClassFieldCustomized In mod_listFields_Custom
                ''Find the right field, by it's enumerated value.
                If (objFld.FieldEnumValue = par_enum) Then Return objFld

            Next objFld

            Return Nothing ''Not found among the Customizible fields.  Added 5/11/2022

        End Function ''ENd of "Public Function GetFieldByFieldEnum_Custom  


        ''Public Function GetElementIndexByFieldIndex_1stTry(pintFieldIndex As Integer) As Integer
        ''    ''
        ''    ''Added 11/17/2021 Thomas Downes 
        ''    ''
        ''    Throw New Exception("It sucks to compare FieldEnum & FieldIndex.")
        ''
        ''    For Each objFldElement As ClassElementFieldV3 In mod_listElementFields_FrontV3
        ''        ''Find the right FieldElement, by it's enumerated
        ''        ''   field value.  ----11/19/2021 
        ''        If (objFldElement.FieldEnum = pintFieldIndex) Then
        ''            ''Added 11/17 td
        ''            Return objFldElement.ElementIndexIsFieldIndex()
        ''
        ''        End If ''End of "If (objFldElement.FieldEnum = pintFieldIndex) Then"
        ''    Next objFldElement
        ''
        ''    Throw New Exception("Can't find element w/ FieldIndex")
        ''
        ''End Function ''End of "Public Function GetElementIndexByFieldIndex_ThisSucks"

        Public Function GetElementIndexByFieldIndex_2ndTry(pintFieldIndex As Integer) As Integer
            ''
            ''Added 11/19/2021 Thomas Downes 
            ''
            Dim objRelevantFieldAny As ClassFieldAny = Nothing
            Dim objElement As ClassElementFieldV3

            ''This sucks''objField = (ListOfFields_Any()).Item(pintFieldIndex)

            For Each each_field As ClassFieldAny In ListOfFields_SC_Any()
                If (each_field.FieldIndex = pintFieldIndex) Then
                    ''Get the matching field object. 
                    objRelevantFieldAny = each_field
                    Exit For
                End If
            Next each_field

            ''5/11/2022 For Each each_element As ClassElementFieldV3 In mod_listElementFields_FrontV3
            ''    If (each_element.FieldInfo Is objRelevantFieldAny) Then
            ''        ''
            ''        ''Added 11/19 td
            ''        ''
            ''        ''---Return objFldElement.ElementIndexIsFieldIndex()
            ''        Return each_element.ElementIndexIsFieldIndex()
            ''
            ''    End If ''End of "If (objFldElement.FieldEnum = pintFieldIndex) Then"
            ''Next each_element

            Throw New Exception("Can't find element w/ matching Field.")

        End Function ''End of "Public Function GetElementIndexByFieldIndex_ThisSucks"


        ''5/11/2022 td ''Public Function MapElementFieldIndex_OmitUnneeded(par_indexElementField As Integer) As Integer
        ''    ''Jan8 2022 ''Public Function MapElementIndex_OmitUnneeded(par_indexElement As Integer) As Integer
        ''    ''
        ''    ''  Added 11/24/2021 thomas downes
        ''    ''
        ''    ''---Throw New NotImplementedException("See BadgeSetupElements() instead.")
        ''    ''===Throw New NotImplementedException(My.Resources.ErrorUseBadgeSetupElements)
        ''    ''//Const strError_Msg As String = "See BadgeSetupElements() instead."
        ''    ''//Throw New NotImplementedException(strError_Msg)
        ''    ''Throw New NotImplementedException(My.Resources.ErrorUseBadgeSetupElements)
        ''
        ''    ''Dim objList As List(Of ClassElementField)
        ''    ''objList = ListOfBadgeDisplayElements_Flds();
        ''
        ''    Dim boolMatch As Boolean
        ''    Dim indexDisplay As Integer
        ''    Dim listBadgeElements_Front As List(Of ClassElementFieldV3) ''Added 1/8/2022 td
        ''    Dim each_elementField As ClassElementFieldV3 ''Added 1/8/2022 thomas d.  
        ''
        ''    listBadgeElements_Front = ListOfBadgeDisplayElements_Flds_FrontV3()
        ''
        ''    ''Jan8 2022 td''For indexDisplay = 0 To mod_listBadgeElements_Front.Count - 1
        ''    For indexDisplay = 0 To listBadgeElements_Front.Count - 1
        ''
        ''        each_elementField = listBadgeElements_Front(indexDisplay)
        ''        boolMatch = (par_indexElementField = each_elementField.ElementIndexIsFieldIndex())
        ''        If (boolMatch) Then Return indexDisplay
        ''
        ''    Next indexDisplay
        ''
        ''    Return -1
        ''
        ''End Function ''End of "Public Function MapElementIndex_OmitUnneeded(int par_indexElement)"


        Public Function GetElementByLabelCaption(par_caption As String) As ClassElementFieldV3
            ''Added 10/10/2019 td 
            Return (Nothing)

        End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

        Public Function GetElementByField(par_field As ClassFieldAny,
                                          Optional par_side As EnumWhichSideOfCard = EnumWhichSideOfCard.Undetermined) As ClassElementFieldV3
            ''Added 11/19/2021 td 
            ''Return (Nothing)
            Dim boolCheckFrontside As Boolean = (par_side <> EnumWhichSideOfCard.EnumBackside) ''Use the <> operator here (in C#, !=). 
            Dim boolCheckBackside As Boolean = (par_side <> EnumWhichSideOfCard.EnumFrontside) ''Use the <> operator here (in C#, !=). 

            ''Check the front side of the badge.  
            If (boolCheckFrontside) Then
                For Each each_element As ClassElementFieldV3 In ListOfElementFields_FrontV3 ''12/18/2021 ListOfElementFields
                    If (each_element.FieldEnum = par_field.FieldEnumValue) Then Return each_element
                Next each_element
            End If ''End of "If (boolCheckFrontside) Then"

            ''
            ''Also check the backside for the field. 
            ''
            If (boolCheckBackside) Then
                For Each each_element As ClassElementFieldV3 In ListOfElementFields_BacksideV3
                    If (each_element.FieldEnum = par_field.FieldEnumValue) Then Return each_element
                Next each_element
            End If ''End of "If (boolCheckBackside) Then"

            Return Nothing

        End Function ''ENd of "Public Function GetElementByField As ClassElementField"


        ''Public Function CheckAllElementsHaveCorrectFieldInfo(ByRef pbAllFine As Boolean,
        ''                                                 ByRef pstrMessage As String) As Boolean
        ''    ''
        ''    ''Added 11/19/2021 td 
        ''    '' 
        ''    Dim boolMatch As Boolean = False
        ''    Dim intCountBad As Integer = 0
        ''    Dim intCountAll As Integer = 0

        ''    pbAllFine = True
        ''    pstrMessage = ""

        ''    For Each each_element As ClassElementFieldV3 In ListOfElementFields_BothsidesV3() ''Dec18 2021 '' ListOfElementFields
        ''        intCountAll += 1
        ''        boolMatch = (each_element.FieldEnum = each_element.FieldInfo.FieldEnumValue)
        ''        ''We don't want to leave prematurely.''----If (Not boolMatch) Then Return False
        ''        ''--If (Not boolMatch) Then pbAllFine = False
        ''        pbAllFine = (boolMatch And pbAllFine)
        ''        If (Not boolMatch) Then intCountBad += 1
        ''    Next each_element

        ''    ''[[[pbAllFine = True
        ''    pstrMessage = $"Out of {intCountAll} elements, there are {intCountBad} misaligned fields."

        ''    Return True

        ''End Function ''ENd of "Public Function CheckAllElementsHaveCorrectFieldInfo(par_caption As String) As ClassFieldAny"


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
        '' 
        ''    End With ''End of "With CtlGraphicPortrait1"
        ''
        ''End Sub ''End of " Private Sub LoadElements_Picture()"


        Public Shared Function GetLoadedCache(pstrPathToXML As String,
                                    pboolNewFileXML As Boolean,
                                    Optional par_imageBack As Image = Nothing,
                                    Optional ByRef pref_section As Integer = 0) As ClassElementsCache_Deprecated
            ''
            ''Added 11/15/2019 td
            ''
            ''Added 10/10/2019 td
            ''11/15/2019 td''Dim strPathToXML As String = ""
            ''---Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  
            Dim obj_cache_elements As ClassElementsCache_Deprecated ''Added 10/10/2019 td
            ''11/15/2019 td''Dim boolNewFileXML As Boolean
            Dim obj_designForm As New FormBadgeLayoutProto ''Added 11/15/2019 td 

            pref_section = 11 ''Added 11/27/2019 td

            ''ADDED 11/28/2019 TD
            ''  Unfortunately we must call the .Show() method so that the size & location 
            ''  values are not equal to zero(0).   ----1/14/2019 thomas downes  
            Const c_bWeMustShowTheFormToAvoidZeroValues As Boolean = False ''2/3/2020 td'' True ''Added 1/14/2020 thomas downes
            If (c_bWeMustShowTheFormToAvoidZeroValues) Then
                obj_designForm.Show()
            End If ''End of "If (c_bWeMustShowTheFormToAvoidZeroValues) Then"

            ''Added 11/15/2019 td
            If (par_imageBack IsNot Nothing) Then
                obj_designForm.pictureBack.Image = par_imageBack
            End If ''End of "If (par_imageBack IsNot Nothing) Then"

            ''Added 10/10/2019 td
            ''10/13/2019 td''strPathToXML = My.Settings.PathToXML_Saved
            ''11/15/2019 td''strPathToXML = DiskFiles.PathToFile_XML

            ''11/15/2019 td''If (pstrPathToXML = "") Then
            ''11/15/2019 td''boolNewFileXML = True
            ''10/12/2019 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            ''11/15/2019 td''strPathToXML = DiskFiles.PathToFile_XML
            ''11/15/2019 td''My.Settings.PathToXML_Saved = strPathToXML
            ''11/15/2019 td''My.Settings.Save()
            ''11/15/2019 td''Else
            pboolNewFileXML = (Not System.IO.File.Exists(pstrPathToXML))
            ''11/15/2019 td''End If ''End of "If (strPathToXML <> "") Then .... Else ..."

            ''
            ''Major call!!
            ''
            If (pboolNewFileXML) Then ''Condition added 10/10/2019 td  
                ''10/13/2019 td''Me.ElementsCache_Saved.LoadFields()
                ''10/13/2019 td''Me.ElementsCache_Saved.LoadFieldElements(pictureBack)
                ''----Me.ElementsCache_Edits.LoadFields()
                ''10/13/2019 td''Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)
                ''----Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)

                pref_section = 12 ''Added 11/27/2019 td

                ''Added 10/13/2019 td
                obj_cache_elements = New ClassElementsCache_Deprecated
                obj_cache_elements.PathToXml_Saved = pstrPathToXML

                ''Added 2/4/2020 thomas downes
                obj_cache_elements.XmlFile_Path_Deprecated = pstrPathToXML
                Try
                    IO.File.WriteAllText(pstrPathToXML, "new XML file")
                    obj_cache_elements.XmlFile_FTitle_Deprecated = (New IO.FileInfo(pstrPathToXML)).Name

                Catch ex_CreateFile As System.IO.IOException
                    ''ErrorMessage &= vbCrLf & ex_CreateFile.Message
                    Throw New Exception("We weren't able to execute IO.File.WriteAllText.", ex_CreateFile)

                End Try

                ''Added 11/16/2019 td
                obj_cache_elements.BadgeLayout = New ciBadgeInterfaces.BadgeLayoutClass()
                ''---2/3/2020 td--obj_cache_elements.BadgeLayout.Width_Pixels = obj_designForm.pictureBack.Width
                ''---2/3/2020 td--obj_cache_elements.BadgeLayout.Height_Pixels = obj_designForm.pictureBack.Height
                obj_cache_elements.BadgeLayout.Width_Pixels = FormBadgeLayoutProto.pictureBack_Width ''---2/3/2020 td--obj_designForm.pictureBack.Width
                obj_cache_elements.BadgeLayout.Height_Pixels = FormBadgeLayoutProto.pictureBack_Height ''---2/3/2020 td--obj_designForm.pictureBack.Height

                pref_section = 13 ''Added 11/27/2019 td

                obj_cache_elements.LoadFields()
                ''----uncomment on 11/16/2019 td''obj_cache_elements.LoadFieldElements(par_imageBack,
                ''----uncomment on 11/16/2019 td''       New BadgeLayoutClass(par_imageBack))

                pref_section = 14 ''Added 11/27/2019 td

            Else
                ''Added 10/10/2019 td  
                ''//Dim objDeserialize As New ciBadgeSerialize.ClassDeserial With {
                ''//    .PathToXML = pstrPathToXML
                ''//} ''Added 10/10/2019 td  
                Dim objDeserialize As ciBadgeSerialize.ClassDeserial

                pref_section = 15 ''Added 11/27/2019 td

                objDeserialize = New ciBadgeSerialize.ClassDeserial With {
                .PathToXML = pstrPathToXML
            } ''Added 10/10/2019 td  

                ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
                ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

                ''2/4/2020 td''obj_cache_elements = New ClassElementsCache_Deprecated ''This may or may not be completely necessary,
                ''   but I know of no other way to pass the object type.  Simply expressing the Type
                ''   by typing its name doesn't work.  ---10/13/2019 td

                ''2/4/2020 td''obj_cache_elements = CType(objDeserialize.DeserializeFromXML(obj_cache_elements.GetType(), False), ClassElementsCache_Deprecated)
                obj_cache_elements = CType(objDeserialize.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

                ''Added 10/12/2019 td
                ''10/13/2019 td''Me.ElementsCache_Saved.LinkElementsToFields()
                ''-----Me.ElementsCache_Edits.LinkElementsToFields()
                obj_cache_elements.Check_LinkElementsToFields()

                pref_section = 16 ''Added 11/27/2019 td

                ''Added 2/4/2020 thomas downes
                With obj_cache_elements
                    .PathToXml_Saved = pstrPathToXML
                    .XmlFile_Path_Deprecated = pstrPathToXML
                    ''.XmlFile_FTitle = (New System.IO.FileInfo(pstrPathToXML)).Name
                    .XmlFile_FTitle_Deprecated = IO.Path.GetFileName(pstrPathToXML)

                End With ''End of "With obj_cache_elements"

            End If ''End of "If (pboolNewFileXML) Then .... Else ..."

            ''-------------------------------------------------------------
            ''Added 9/19/2019 td
            Dim intPicLeft As Integer
            Dim intPicTop As Integer
            Dim intPicWidth As Integer
            Dim intPicHeight As Integer

            pref_section = 17 ''Added 11/27/2019 td

            ''Added 9/19/2019 td
            With obj_designForm
                ''Added 9/19/2019 td
                ''2/3/2020 td''intPicLeft = .picturePortrait.Left - .pictureBack.Left
                ''2/3/2020 td''intPicTop = .picturePortrait.Top - .pictureBack.Top
                ''2/3/2020 td''intPicWidth = .picturePortrait.Width
                ''2/3/2020 td''intPicHeight = .picturePortrait.Height
                intPicLeft = .picturePortrait_Left - .pictureBack_Left
                intPicTop = .picturePortrait_Top - .pictureBack_Top
                intPicWidth = .picturePortrait_Width
                intPicHeight = .picturePortrait_Height
            End With

            pref_section = 171 ''Added 11/27/2019 td
            ''-------------------------------------------------------------
            ''Added 10/14/2019 td
            Dim intLeft_QR As Integer
            Dim intTop_QR As Integer
            Dim intWidth_QR As Integer
            Dim intHeight_QR As Integer

            ''Added 10/14/2019 td
            With obj_designForm
                ''Added 10/14/2019 td
                intLeft_QR = .pictureQRCode.Left - .pictureBack.Left
                intTop_QR = .pictureQRCode.Top - .pictureBack.Top
                intWidth_QR = .pictureQRCode.Width
                intHeight_QR = .pictureQRCode.Height
            End With

            pref_section = 172 ''Added 11/27/2019 td
            ''-------------------------------------------------------------
            ''Added 10/14/2019 td
            Dim intLeft_Sig As Integer
            Dim intTop_Sig As Integer
            Dim intWidth_Sig As Integer
            Dim intHeight_Sig As Integer

            ''Added 10/14/2019 td
            With obj_designForm
                ''Added 10/14/2019 td
                intLeft_Sig = .pictureSignature.Left - .pictureBack.Left
                intTop_Sig = .pictureSignature.Top - .pictureBack.Top
                intWidth_Sig = .pictureSignature.Width
                intHeight_Sig = .pictureSignature.Height
            End With

            pref_section = 173 ''Added 11/27/2019 td
            ''-------------------------------------------------------------
            ''Added 10/14/2019 td
            Dim strStaticText As String
            Dim intLeft_Text As Integer
            Dim intTop_Text As Integer
            Dim intWidth_Text As Integer
            Dim intHeight_Text As Integer

            ''Added 10/14/2019 td
            With obj_designForm
                ''Added 10/14/2019 td
                strStaticText = "This is the same text for everyone."
                intLeft_Text = .labelText1.Left - .pictureBack.Left
                intTop_Text = .labelText1.Top - .pictureBack.Top
                intWidth_Text = .labelText1.Width
                intHeight_Text = .labelText1.Height
            End With

            pref_section = 18 ''Added 11/27/2019 td

            ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
            If (pboolNewFileXML) Then

                pref_section = 19 ''Added 11/27/2019 td

                ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
                ''10/13/2019 td''Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
                obj_cache_elements.LoadNewElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
                                               obj_designForm.pictureBack,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td

                pref_section = 20 ''Added 11/27/2019 td
                ''Added 10/14/2019 thomas d. 
                obj_cache_elements.LoadNewElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
                                               obj_designForm.pictureBack,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

                pref_section = 21 ''Added 11/27/2019 td
                ''Added 10/14/2019 thomas d. 
                obj_cache_elements.LoadNewElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
                                               obj_designForm.pictureBack,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

                pref_section = 22 ''Added 11/27/2019 td

            End If ''End of "If (pboolNewFileXML) Then"

            pref_section = 23 ''Added 11/27/2019 td
            ''Added 10/14/2019 thomas d. 
            ''Dec17 2021 td''obj_cache_elements.LoadElement_Text(strStaticText,
            ''Jan19 2022 td''obj_cache_elements.LoadNewElement_StaticText_IfNeeded(strStaticText,
            obj_cache_elements.LoadNewElement_StaticTextV3(strStaticText,
                            intLeft_Text, intTop_Text,
                            intWidth_Text, intHeight_Text,
                            obj_designForm.pictureBack,
                            EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

            pref_section = 24 ''Added 11/27/2019 td

            ''Added 9/24/2019 thomas 
            ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
            ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
            ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

            ''Added 11/18/2019 td
            With obj_cache_elements
                ''Added 11/18/2019 td
                If (.BadgeLayout Is Nothing) Then
                    Dim intBadgeWidth As Integer
                    Dim intBadgeHeight As Integer

                    pref_section = 25 ''Added 11/27/2019 td
                    intBadgeWidth = obj_cache_elements.ListFieldElementsV3(0).BadgeLayout.Width_Pixels
                    intBadgeHeight = obj_cache_elements.ListFieldElementsV3(0).BadgeLayout.Height_Pixels

                    .BadgeLayout = New BadgeLayoutClass(intBadgeWidth, intBadgeHeight)

                End If ''End of "If (obj_cache_elements.BadgeLayout Is Nothing) Then

                ''Added 1/14/2020 thomas downes 
                .BackgroundImage_Front_FTitle = "BackExample.jpg"

            End With ''End of "With obj_cache_elements"

            ''ADDED 11/28/2019 TD
            obj_designForm.Close()
            obj_designForm.Dispose()

            Return obj_cache_elements

        End Function ''End of "Public Shared Function GetLoadedCache() As ClassElementsCache"


        Public Sub SaveFieldViaReplacing_Stan(par_fieldToSave As ciBadgeFields.ClassFieldStandard)
            ''
            ''The suffix _Stan = "Standard". 
            ''
            ''Added 1/3/2022 thomas downes  
            ''
            ''Check to see if any work needs to be done.
            ''  (If the module-level list contains the field object
            ''   already, we can stop here. ---1/3/2022 td)
            ''
            If (ListOfFields_Standard.Contains(par_fieldToSave)) Then
                ''Nothing needs to be done, i.e. nothing needs
                ''  to be replaced. ---1/3/2022 td
                Return
            End If ''End of "If (ListOfFields_Standard.Contains(par_fieldToSave)) Then"

            Dim enumCIBadgeField As EnumCIBFields
            enumCIBadgeField = par_fieldToSave.FieldEnumValue

            Dim objFieldToReplace As ClassFieldStandard
            objFieldToReplace = CType(GetFieldByFieldEnum(enumCIBadgeField), ClassFieldStandard)

            ListOfFields_Standard.Remove(objFieldToReplace) ''Remove the field we are replacing. 
            ListOfFields_Standard.Add(par_fieldToSave) ''Insert the field which will be the replacement.

        End Sub ''End of Public Sub SaveFieldViaReplacing(par_fieldToSave As ciBadgeFields.ClassFieldStandard)


        Public Sub SaveFieldViaReplacing_Cust(par_fieldToSave As ciBadgeFields.ClassFieldCustomized)
            ''
            ''The suffix _Cust = "Standard". 
            ''
            ''Added 1/3/2022 thomas downes  
            ''
            ''Check to see if any work needs to be done.
            ''  (If the module-level list contains the field object
            ''   already, we can stop here. ---1/3/2022 td)
            ''
            If (ListOfFields_Custom.Contains(par_fieldToSave)) Then
                ''Nothing needs to be done, i.e. nothing needs
                ''  to be replaced. ---1/3/2022 td
                Return
            End If ''End of "If (ListOfFields_Standard.Contains(par_fieldToSave)) Then"

            Dim enumCIBadgeField As EnumCIBFields
            enumCIBadgeField = par_fieldToSave.FieldEnumValue

            Dim objFieldToReplace As ClassFieldCustomized
            objFieldToReplace = CType(GetFieldByFieldEnum(enumCIBadgeField), ClassFieldCustomized)

            ListOfFields_Custom.Remove(objFieldToReplace) ''Remove the field we are replacing. 
            ListOfFields_Custom.Add(par_fieldToSave) ''Insert the field which will be the replacement.

        End Sub ''End of Public Sub SaveFieldViaReplacing(par_fieldToSave As ciBadgeFields.ClassFieldCustomized)


        Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
            ''
            ''Added 11/29/2019 thomas downes
            ''
            ''This code was copied from FormDesignProtoTwo.vb, Private Sub SaveLayout(), on 11/29/2019 td
            ''
            Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

            With objSerializationClass

                ''10/13/2019 td''.PathToXML = Me.ElementsCache_Saved.PathToXml_Saved
                ''03/23/2022 td''.PathToXML = Me.PathToXml_Saved
                .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 

                ''Added 3/23/2022 thomas d.
                If (Me.PathToXml_Opened <> "") Then
                    .PathToXML = Me.PathToXml_Opened
                    .PathToXML_Alternate = Me.PathToXml_Saved ''Added 3/23/2022 thomas d. 
                Else
                    .PathToXML = Me.PathToXml_Saved
                    .PathToXML_Alternate = Me.PathToXml_Opened ''Added 3/23/2022 thomas d. 
                End If ''End of "If (Me.PathToXML_Opened <> "") Then ... Else"

                ''Added 12/14/2021 td 
                If (pstrPathToXML <> "") Then .PathToXML = pstrPathToXML

                ''Added 9/24/2019 thomas 
                ''  ''11/29/2019 td''.SerializeToXML(Me.GetType, Me, False, True)

                Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td

                boolSerializeToBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat

                If (boolSerializeToBinary) Then
                    .SerializeToBinary(Me.GetType, Me)
                Else
                    ''//---4/22/2020 td //.SerializeToXML(Me.GetType, Me, False, True)
                    Const c_boolAutoOpenByIE As Boolean = False ''Added 4/22/2020 thomas d.
                    ''//
                    ''// If the 2nd Boolean Is True, the following command
                    ''//         System.Diagnostics.Process.Start(Me.PathToXML)
                    ''//  will be used to open the file in Notepad.
                    ''//     ---4/22/2020 thomas downes
                    ''//
                    .SerializeToXML(Me.GetType, Me, False, c_boolAutoOpenByIE)

                End If ''End of "If (boolSerializeToBinary) Then ... Else"

            End With ''End of "With objSerializationClass"

        End Sub ''End of "Public Sub SaveToXML()"


        Public Function GetBackgroundImage(par_enumWhichSide As EnumWhichSideOfCard,
                     par_infoBadgeLayout As ciBadgeInterfaces.IBadgeLayoutDimensions,
                     par_bBackgroundInfoRefreshed As Boolean) As Image
            ''
            ''Added 12/23/2021 thomas downes
            ''
            ''This function is overloaded.  See same-named function below this function. 
            ''
            Return GetBackgroundImage(par_enumWhichSide,
                                      par_infoBadgeLayout.Width_Pixels,
                                         par_infoBadgeLayout.Height_Pixels,
                                       DiskFolders.PathToFolder_BackgroundImages(),
                                          par_bBackgroundInfoRefreshed)

        End Function ''end of ""Public Function GetBackgroundImage""


        Public Function GetBackgroundImage(par_enumWhichSide As EnumWhichSideOfCard,
                                           pintWidth As Integer, pintHeight As Integer,
                                       Optional pstrPathToLikelyFolder As String = "",
                                       Optional pbooWereTwoPropertiesRefreshed As Boolean = False) As Image
            ''
            ''Added 1/14/2020 thomas downes
            ''
            ''This function is overloaded.  See same-named function ABOVE !! 
            ''
            Dim structCurrent As New BackgroundTitleAndWidth
            Dim imageFound As Image = Nothing
            Dim imageCreated1Unsized As Image = Nothing
            Dim imageCreated2Sized As Image = Nothing
            Dim bBackside As Boolean = (par_enumWhichSide = EnumWhichSideOfCard.EnumBackside) ''Added 12/23/2021
            Dim bFrontside As Boolean = (par_enumWhichSide <> EnumWhichSideOfCard.EnumBackside) ''Added 12/23/2021
            Dim strPathToBackground As String = "" ''Added 5/20/2022 thomas d.

            ''//
            ''//  Have the following properties been recently refreshed?  ---11/2/2021 td
            ''//
            ''//     1) BackgroundImage_Path
            ''//     2) BackgroundImage_FTitle
            ''//
            If (Not pbooWereTwoPropertiesRefreshed) Then
                ''// Added 11/2/2021 thomas downes
                ''--==Throw New Exception("Please confirm refresh of BackgroundImage_Path, BackgroundImage_FTitle.")

                ''Added 11/2/2021 thomas downes
                Throw New Exception(My.Resources.PlsConfirmRefresh)

            End If ''End if "If (Not pbooWerePropertiesRefreshed) Then"

            structCurrent.iPixelsWidth = pintWidth

            ''Dec23 2021 td''structCurrent.sFileTitle = Me.BackgroundImage_Front_FTitle
            If (bFrontside) Then structCurrent.sFileTitle = Me.BackgroundImage_Front_FTitle
            If (bBackside) Then structCurrent.sFileTitle = Me.BackgroundImage_Backside_FTitle

            Try
                imageFound = mod_dictionaryBackgroundImages(structCurrent)

            Catch ex_dict As Exception
                If (ex_dict.Message.Contains("not present")) Then
                    ''
                    ''The image was not created and/or not saved. ---1/14/2020. 
                    ''
                Else
                    Throw
                End If ''End fo "If (ex_dict.Message.Contains("not present")) Then ... Else ..."
            End Try

            If (imageFound IsNot Nothing) Then
                Return imageFound
            Else
                ''Added 1/14/2019 td 
                BackgroundImage_RefreshPath(pstrPathToLikelyFolder) ''Added 1/14/2019 td 
                ''Dec23 2021 td''imageCreated1 = New Bitmap(Me.BackgroundImage_Front_Path)
                Try
                    ''May20 2022 ''If (bFrontside) Then imageCreated1Unsized = New Bitmap(Me.BackgroundImage_Front_Path)
                    ''May20 2022 ''If (bBackside) Then imageCreated1Unsized = New Bitmap(Me.BackgroundImage_Backside_Path)
                    If (bFrontside) Then strPathToBackground = Me.BackgroundImage_Front_Path
                    If (bBackside) Then strPathToBackground = Me.BackgroundImage_Backside_Path
                    If (String.IsNullOrEmpty(strPathToBackground)) Then
                        ''
                        ''Not all users will desire or require a background image.--5/23/2022 
                        ''
                    Else
                        imageCreated1Unsized = New Bitmap(strPathToBackground)
                    End If ''ENd of ""f (String.IsNullOrEmpty(strPathToBackground)) Then...Else..."

                Catch ex_Bitmap As Exception

                    ''Added 5/20/2022 thomas downes
                    MessageBoxTD.Show_Statement("Problem loading the following-named background image:" & vbCrLf_Deux &
                                                strPathToBackground, ex_Bitmap.Message)
                    Return Nothing ''Added 5/20/2022 
                End Try

                ''Added 5/20/2022 td
                If (imageCreated1Unsized Is Nothing) Then Return Nothing

                ''imageCreated.Dispose()
                imageCreated2Sized = New Bitmap(imageCreated1Unsized, New Size(pintWidth, pintHeight))
                mod_dictionaryBackgroundImages.Add(structCurrent, imageCreated2Sized)
                imageCreated1Unsized.Dispose()
                Return imageCreated2Sized

            End If  ''Endof "If (imageFound IsNot Nothing) Then ..... Else ...."

        End Function ''End of "Public Function GetBackgroundImage(pintWidth As Integer, pintHeight As Integer) As Image"

        Private Sub BackgroundImage_RefreshPath(pstrPathToBackgroundImagesFolder As String)
            ''
            ''Added 1/14/2019 thomas downes  
            ''
            If (Not String.IsNullOrEmpty(BackgroundImage_Front_FTitle)) Then

                ''1/15/2019 td''BackgroundImage_Path = System.IO.Path.Combine(pstrPathToBackgroundImagesFolder, BackgroundImage_Path)
                BackgroundImage_Front_Path = System.IO.Path.Combine(pstrPathToBackgroundImagesFolder, BackgroundImage_Front_FTitle)

            End If ''End of "If (Not String.IsNullOrEmpty(BackgroundImage_FTitle)) Then"

        End Sub ''Private Sub BackgroundImage_RefreshPath(pstrPathToBackgroundImagesFolder As String)


        Public Sub DisposePicImage_ByRecipID(pstrRecipID As String)
            ''
            ''Added 2/21/2020 thomas downes  
            ''
            ''Dim objRecip As ciBadgeRecipients.ClassRecipient
            ''
            ''objRecip = recip


        End Sub ''End of "Public Sub DisposePicImage_ByRecipID(pstrRecipID As String)"


        Public Function GetBackgroundImage_Path(par_enumSideOfCard As EnumWhichSideOfCard) As String
            ''Added 12/14/2021 td
            If (par_enumSideOfCard = EnumWhichSideOfCard.EnumBackside) Then
                Return BackgroundImage_Backside_Path
                ''End If
            Else
                Return BackgroundImage_Front_Path
            End If

        End Function

    End Class ''End of ClassElementsCache 

End Namespace


