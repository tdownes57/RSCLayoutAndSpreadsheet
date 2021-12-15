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

        Public Property ElementQRCode As ClassElementQRCode ''Added 10/8/2019 thomas d.  
        Public Property ElementSignature As ClassElementSignature ''Added 10/8/2019 thomas d.  

        Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass ''Added 9/17/2019 thomas downes

        ''Added 1/12/2020 thomas d. 
        Public Property PathToBackgroundImageFile_Deprecated As String ''Deprecated 2/4/2020 td.   Added 1/12/2019 thomas downes

        <Xml.Serialization.XmlIgnore>
        Public Property Pic_InitialDefault As Image ''Added 9/23/2019 td 

        Public Property DateAndTimeUpdated As DateTime ''Added 11/29/2021 thomas d. 

        ''Added 12/12/2021 Thomas Downes
        Public Property BadgeHasTwoSidesOfCard As Boolean ''Added 12/12/2021 td  

        ''10/14/2019 td''Private mod_listFields As New List(Of ClassFieldAny) ''Added 9/18/2019 td  

        ''10/17 td''Private mod_listFields_Standard As New List(Of ClassFieldStandard) ''Added 10/14/2019 td  
        ''10/17 td''Private mod_listFields_Custom As New List(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        ''10/17 td''Private mod_listElementFields As New List(Of ClassElementField)
        ''10/17 td''Private mod_listElementPics As New List(Of ClassElementPic)
        ''10/17 td''Private mod_listElementStatics As New List(Of ClassElementStaticText)
        ''10/17 td''Private mod_listElementLaysections As New List(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes

        Private mod_listFields_Standard As New HashSet(Of ClassFieldStandard) ''Added 10/14/2019 td  
        Private mod_listFields_Custom As New HashSet(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        ''Front side of ID Card / Badge Card
        Private mod_listElementFields_Front As New HashSet(Of ClassElementField)
        Private mod_listElementPics_Front As New HashSet(Of ClassElementPic)
        Private mod_listElementStatics_Front As New HashSet(Of ClassElementStaticText)
        Private mod_listElementLaysections_Front As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes
        Private mod_listBadgeElements_Front As New HashSet(Of ClassElementField) ''Added 11/26/2021 td

        ''Back side of ID Card / Badge Card
        Private mod_listElementFields_Backside As HashSet(Of ClassElementField)
        Private mod_listElementPics_Backside As HashSet(Of ClassElementPic)
        Private mod_listElementStatics_Backside As HashSet(Of ClassElementStaticText)
        Private mod_listElementLaysections_Backside As HashSet(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes
        Private mod_listBadgeElements_Backside As HashSet(Of ClassElementField) ''Added 11/26/2021 td

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

        Public Function ListOfFields_Any() As List(Of ClassFieldAny)
            ''
            ''Added 10/14/2019 thomas downes
            ''
            Dim obj_list As New List(Of ClassFieldAny)
            obj_list.AddRange(ListOfFields_Standard)
            obj_list.AddRange(ListOfFields_Custom)
            Return obj_list

        End Function ''End of "Public Function ListOfFields_Any() As List(Of ClassFieldAny)"


        Public Function ListOfFields_CreateCopies() As List(Of ClassFieldAny)
            ''
            ''Added 11/15/2021 thomas downes
            ''
            ''Create copies of the Field objects. 
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

        End Function ''End of "Public Function ListOfFields_Any() As List(Of ClassFieldAny)"


        Public Function ListOfFields_ForEditing(par_recipInfo As IRecipient) As List(Of ClassFieldAny)
            ''
            ''Added 2/20/2020 thomas downes
            ''
            Const c_bEditablesOnly As Boolean = True

            Return ListOfFields_Any(par_recipInfo, c_bEditablesOnly, False)

        End Function

        Public Function ListOfFields_Any(par_recipInfo As IRecipient,
                                     Optional ByVal pboolEditablesOnly As Boolean = True,
                                     Optional ByVal pboolRefreshList As Boolean = False) As List(Of ClassFieldAny)
            ''
            ''Added 10/14/2019 thomas downes
            ''
            ''Step 1 of 3.  Concatenate the Standard & Custom field-lists into a single list. 
            ''
            Static s_obj_listOutput As List(Of ClassFieldAny)
            Dim obj_listRemove As New List(Of ClassFieldAny)
            Dim bDisplayForEdits As Boolean ''Added 2/20/2020 thomas downes 
            ''----Const c_boolRefreshList As Boolean = False ''Added 2/20/2020
            Dim bReferenceNewRecipInfo As Boolean = True ''Added 2/20/2020

            ''Added 2/20/2020
            bReferenceNewRecipInfo = (par_recipInfo IsNot Nothing)

            ''
            ''Added 2/20/2020 thomas downes
            ''
            If (pboolRefreshList Or s_obj_listOutput Is Nothing) Then
                ''Populate the list.  
                s_obj_listOutput = New List(Of ClassFieldAny)
                s_obj_listOutput.AddRange(ListOfFields_Standard)
                s_obj_listOutput.AddRange(ListOfFields_Custom)

            ElseIf (bReferenceNewRecipInfo) Then
                ''
                ''Add a reference to recipient info.
                ''
                For Each each_field As ClassFieldAny In s_obj_listOutput
                    ''Add a reference to recipient info. 
                    each_field.iRecipientInfo = CType(par_recipInfo, IRecipient)
                Next each_field

                ''Return the list, with the updated RecipientInfo.
                Return s_obj_listOutput

            Else
                ''Probably won't ever execute, due to the "If" and "ElseIf" conditions above. 
                Return s_obj_listOutput
            End If ''End of "If (pboolRefreshList Or s_obj_listOutput Is Nothing) Then .... Else ...."

            ''
            ''Step 2 of 3.  Load the current recipient into each field. 
            ''
            ''Added 12/1/2019 thomas d
            For Each each_field As ClassFieldAny In s_obj_listOutput

                ''Added 2/20/2020 thomas downes  
                bDisplayForEdits = (each_field.IsDisplayedForEdits)
                If (bDisplayForEdits) Then
                    ''
                    ''Great!
                    ''
                ElseIf (pboolEditablesOnly) Then
                    ''Added 2/20/2020 thomas downes  
                    obj_listRemove.Add(each_field)
                    Continue For
                End If ''End of "If (bDisplayForEdits) Then ... Else ..."

            Next each_field


            ''Added 2/20/2020 thomas d
            ''
            ''  Remove unneeded fields. 
            ''
            If (pboolEditablesOnly) Then
                For Each each_field As ClassFieldAny In obj_listRemove
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

        Public Property ListOfFields_Standard As HashSet(Of ClassFieldStandard) ''10/17 ''As List(Of ClassFieldStandard)
            Get ''Added 10/14/2019 td
                Return mod_listFields_Standard
            End Get
            Set(value As HashSet(Of ClassFieldStandard))
                ''Added 10/14/2019 td td
                mod_listFields_Standard = value
            End Set
        End Property

        Public Property ListOfFields_Custom As HashSet(Of ClassFieldCustomized) '' List(Of ClassFieldCustomized)
            Get ''Added 10/14/2019 td
                Return mod_listFields_Custom
            End Get
            Set(value As HashSet(Of ClassFieldCustomized)) '' List(Of ClassFieldCustomized))
                ''Added 10/14/2019 td td
                mod_listFields_Custom = value
            End Set
        End Property



        Public Property ListOfElementFields As HashSet(Of ClassElementField)  ''---List(Of ClassElementField)
            Get ''Added 9/28/2019 td
                Return mod_listElementFields_Front
            End Get
            Set(value As HashSet(Of ClassElementField))  ''---List(Of ClassElementField))
                ''Added 9/28/2019 td
                mod_listElementFields_Front = value
            End Set
        End Property

        Public Function BadgeDisplayElements_Fields(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
            ''
            ''Added 11/24/2021 thomas downes 
            ''
            Return ListOfBadgeDisplayElements_Flds_Front(pboolRefresh)

        End Function


        Public Function ListOfBadgeDisplayElements_Flds_Front(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
            ''---Dec.8 2021--Public Function ListOfBadgeDisplayElements_Flds(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
            ''
            ''Added 11/26/2021  
            ''
            If (pboolRefresh Or (mod_listBadgeElements_Front Is Nothing)) Then
                ''----Dec.8 2021---RefreshListOfBadgeDisplayElements_Flds()
                RefreshListOfBadgeDisplayElements_Flds_Front()

            End If ''End of "If (pboolRefresh Or (mod_listBadgeElements_Front Is Nothing)) Then"

            Return mod_listBadgeElements_Front

        End Function ''end of "Public Function ListOfBadgeDisplayElements_Flds_Front()"


        Public Function ListOfBadgeDisplayElements_Flds_Backside(pboolRefresh As Boolean) As HashSet(Of ClassElementField)
            ''
            ''Added 12/08/2021  
            ''
            If (pboolRefresh Or (mod_listBadgeElements_Backside Is Nothing)) Then
                ''Major call!!
                RefreshListOfBadgeDisplayElements_Flds_Backside()

            End If ''End of "If (pboolRefresh Or (mod_listBadgeElements_Back Is Nothing)) Then"

            Return mod_listBadgeElements_Backside

        End Function ''end of "Public Function ListOfBadgeDisplayElements_Flds_Backside()"


        Public Sub RefreshListOfBadgeDisplayElements_Flds_Front(Optional pboolSkip13 As Boolean = True,
                                                      Optional pboolSkip14 As Boolean = True)
            ''                                          As List(Of ClassElementField)
            ''--Dec.8 2021--Public Sub RefreshListOfBadgeDisplayElements_Flds
            ''
            ''Added 11/24/2021 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            Dim new_list As New HashSet(Of ClassElementField)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementField
            Dim boolOnDisplay As Boolean
            Dim structWhyOmit As New ciBadgeElements.WhyOmitted
            Dim indexBadgeDisplay As Integer

            For Each each_element In mod_listElementFields_Front
                ''Major call. 
                boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmit)
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

            mod_listBadgeElements_Front = new_list

        End Sub ''End of "Public Sub RefreshListOfBadgeDisplayElements_Flds_Front()"


        Public Sub RefreshListOfBadgeDisplayElements_Flds_Backside(Optional pboolSkip13 As Boolean = True,
                                                      Optional pboolSkip14 As Boolean = True)
            ''                                          As List(Of ClassElementField)
            ''--Dec.8 2021--Public Sub RefreshListOfBadgeDisplayElements_Flds
            ''
            ''Added 12/8/2021 tdownes
            ''
            ''  For each element, we check to see if it will be displayed on the Badge.
            ''  If so, it's included on the output list.  
            ''
            Dim new_list As New HashSet(Of ClassElementField)  ''End of "List(Of ClassElementField)"
            Dim each_element As ClassElementField
            Dim boolOnDisplay As Boolean
            Dim structWhyOmit As New ciBadgeElements.WhyOmitted
            Dim indexBadgeDisplay As Integer

            If (mod_listElementFields_Backside Is Nothing) Then mod_listElementFields_Backside = New HashSet(Of ClassElementField)

            For Each each_element In mod_listElementFields_Backside
                ''Major call. 
                boolOnDisplay = each_element.IsDisplayedOnBadge_Visibly(structWhyOmit)
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
            mod_listBadgeElements_Backside = new_list

        End Sub ''End of "Public Sub RefreshListOfBadgeDisplayElements_Flds_Backside()"


        Public Property ListOfElementPics As HashSet(Of ClassElementPic)  ''---List(Of ClassElementPic)
            Get ''Added 10/13/2019 td
                Return mod_listElementPics_Front
            End Get
            Set(value As HashSet(Of ClassElementPic))  ''---List(Of ClassElementPic))
                ''Added 10/13/2019 td
                mod_listElementPics_Front = value
            End Set
        End Property

        Public Property ListOfElementTexts As HashSet(Of ClassElementStaticText)  ''---List(Of ClassElementStaticText)
            Get ''Added 10/14/2019 td
                Return mod_listElementStatics_Front
            End Get
            Set(value As HashSet(Of ClassElementStaticText))  ''---List(Of ClassElementStaticText))
                ''Added 10/14/2019 td
                mod_listElementStatics_Front = value
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

        Public Function ListFieldElements() As HashSet(Of ClassElementField)
            ''10/17 td''Public Function ListFieldElements() As List(Of ClassElementField)
            ''
            ''Added 9/16/2019 thomas downes
            ''
            Return mod_listElementFields_Front

        End Function ''End of "Public Function FieldElements() As List(Of ClassElementText)"

        Public Function PicElement() As ClassElementPic
            ''
            ''Added 9/16/2019 thomas downes
            ''
            If (MissingTheElementPic()) Then Return Nothing ''Added 10/12/2019 td

            Return mod_listElementPics_Front(0)

        End Function ''End of "Public Function PicElement() As ClassElementPic"

        Public Function ListPicElements() As HashSet(Of ClassElementPic)  ''---List(Of ClassElementPic)
            ''
            ''Added 9/17/2019 thomas downes
            ''
            Return mod_listElementPics_Front

        End Function ''End of " Public Function ListPicElements() As List(Of ClassElementPic)"

        Public Function ListStaticTextElements() As HashSet(Of ClassElementStaticText)  ''---List(Of ClassElementStaticText)
            ''
            ''Added 9/16/2019 thomas downes
            ''
            Return mod_listElementStatics_Front

        End Function ''End of "Public Function ListStaticTextElements() As List(Of ClassElementStaticText)"

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
            Dim each_element As ciBadgeElements.ClassElementField
            Dim eachrelated_field As ciBadgeFields.ClassFieldAny

            For Each each_element In ListFieldElements()
                ''
                ''Refresh the .FieldObject & .FieldInfo properties.
                ''
                eachrelated_field = GetFieldByFieldEnum(each_element.FieldEnum)
                each_element.FieldObjectAny = eachrelated_field
                each_element.FieldInfo = CType(eachrelated_field, ICIBFieldStandardOrCustom)
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

                ''Added 11/29/2021 td
                new_elementField.DatetimeUpdated = Now

                ''Added 9/19/2019 td
                mod_listElementFields_Front.Add(new_elementField)

            Next each_field

        End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As PictureBox)"

        Public Sub LoadFieldElements(par_layout As BadgeLayoutClass)
            ''
            ''Added 11/15/2019 thomas d. 
            ''
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

                ''Added 11/29/2021 td
                new_elementField.DatetimeUpdated = DateTime.Now

                ''Added 9/19/2019 td
                mod_listElementFields_Front.Add(new_elementField)

            Next each_field

        End Sub ''ENd of "Public Sub LoadFieldElements(par_pictureBackground As Image)"

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

            mod_listElementPics_Front.Add(objElementPic)

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

            mod_listElementPics_Front.Add(objElementPic)

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

            mod_listElementStatics_Front.Add(objElementText)

        End Sub ''End of "Public Sub LoadElement_Text(par_DisplayText As String, par_intLeft As Integer, ...., par_pictureBackground As PictureBox)"

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
            ClassElementField.oRecipient = par_recipient

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
            Dim copy_ofElementField As ClassElementField ''Added 10/1/2019 td

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
            For Each each_elementField As ClassElementField In mod_listElementFields_Front
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
                dictionaryFields.TryGetValue(each_elementField.FieldEnum, copy_ofElementField.FieldObjectAny)

                ''Added 10/13/2019 td
                copy_ofElementField.FieldInfo = CType(copy_ofElementField.FieldObjectAny, ICIBFieldStandardOrCustom)

                objCopyOfCache.ListFieldElements().Add(copy_ofElementField)

            Next each_elementField

            ''Added 9/17/2019 thomas downes  
            For Each each_elementPic As ClassElementPic In mod_listElementPics_Front
                objCopyOfCache.ListPicElements().Add(each_elementPic.Copy())
            Next each_elementPic

            ''Added 9/17/2019 thomas downes  
            For Each each_elementStaticText As ClassElementStaticText In mod_listElementStatics_Front
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
            Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)
            ''Dim pstrReport As String

            ''Added 12/14/2021 td 
            pref_strReport = "Addressed field-related references for {0} of {1} elements."

            ''Added 9/29/2019 thomas downes  
            For Each each_field As ClassFieldAny In ListOfFields_Any() ''10/14/2019 td''In mod_listFields
                Try
                    dictionaryFields.Add(each_field.FieldEnumValue, each_field)
                Catch ex_AddFailed As Exception
                    ''Added 10/12/2019 td
                    System.Diagnostics.Debugger.Break()
                End Try
            Next each_field

            Dim found_field As ClassFieldAny ''Added 10/12/2019 td

            For Each each_elementField As ClassElementField In mod_listElementFields_Front

                found_field = Nothing ''Initialize. ----10/12/2019 td

                dictionaryFields.TryGetValue(each_elementField.FieldEnum, found_field)

                ''
                ''Fill in the missing links !!!  ---comment 12/14/2021 td
                ''
                With each_elementField ''Added 12/14/2021 td
                    If ((.FieldInfo Is Nothing) Or pboolOverride) Then ''Added 12/14/2021 td

                        .FieldInfo = found_field
                        .FieldObjectAny = found_field
                        .LoadFieldAny(found_field) ''Added 12/13/2021 td

                    End If ''End of "If ((.FieldInfo Is Nothing) Or pboolOverride) Then"
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

        Public Function GetElementByGUID(par_guid As System.Guid) As ClassElementField
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
            ''Added 10/10/2019 td 
            Return (0 = mod_listElementFields_Front.Count)

        End Function ''ENd of "Public Function MissingTheElementFields() As Boolean"

        Public Function MissingTheElementTexts() As Boolean
            ''Added 10/11/2019 td 
            ''10/14 td''Return (0 = mod_listElementStatics.Count)
            Return True ''Added 10/14/2019 td 

        End Function ''ENd of "Public Function MissingTheElementTexts() As Boolean"

        Public Function MissingTheElementPic() As Boolean
            ''Added 10/10/2019 td 
            Return (0 = mod_listElementPics_Front.Count)

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
            ''Added 10/13/2019 td
            ''
            Dim bMisaligned As Boolean ''Added 12/13/2021 td

            For Each each_elementField As ClassElementField In mod_listElementFields_Front
                With each_elementField

                    ''Dec13 2021''.FieldEnum = .FieldObjectAny.FieldEnumValue ''This is a double-check that the Enum value matches. 
                    bMisaligned = (.FieldEnum <> .FieldObjectAny.FieldEnumValue)
                    If (bMisaligned) Then
                        Throw New DataMisalignedException()
                    End If ''end of "If (bMisaligned) Then"

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

            For Each each_fieldAny In ListOfFields_Any()

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
            Next

            ''Second, check custom fields. 
            For Each objFld As ClassFieldCustomized In mod_listFields_Custom
                ''Find the right field, by it's enumerated value.
                If (objFld.FieldEnumValue = par_enum) Then Return objFld
            Next

        End Function ''ENd of "Public Function GetFieldByFieldEnum  


        Public Function GetElementIndexByFieldIndex_1stTry(pintFieldIndex As Integer) As Integer
            ''
            ''Added 11/17/2021 Thomas Downes 
            ''
            Throw New Exception("It sucks to compare FieldEnum & FieldIndex.")

            For Each objFldElement As ClassElementField In mod_listElementFields_Front
                ''Find the right FieldElement, by it's enumerated
                ''   field value.  ----11/19/2021 
                If (objFldElement.FieldEnum = pintFieldIndex) Then
                    ''Added 11/17 td
                    Return objFldElement.ElementIndexIsFieldIndex()
                End If ''End of "If (objFldElement.FieldEnum = pintFieldIndex) Then"
            Next objFldElement

            Throw New Exception("Can't find element w/ FieldIndex")

        End Function ''End of "Public Function GetElementIndexByFieldIndex_ThisSucks"

        Public Function GetElementIndexByFieldIndex_2ndTry(pintFieldIndex As Integer) As Integer
            ''
            ''Added 11/19/2021 Thomas Downes 
            ''
            Dim objRelevantFieldAny As ClassFieldAny = Nothing
            Dim objElement As ClassElementField

            ''This sucks''objField = (ListOfFields_Any()).Item(pintFieldIndex)

            For Each each_field As ClassFieldAny In ListOfFields_Any()
                If (each_field.FieldIndex = pintFieldIndex) Then
                    ''Get the matching field object. 
                    objRelevantFieldAny = each_field
                    Exit For
                End If
            Next each_field

            For Each each_element As ClassElementField In mod_listElementFields_Front
                If (each_element.FieldInfo Is objRelevantFieldAny) Then
                    ''
                    ''Added 11/19 td
                    ''
                    ''---Return objFldElement.ElementIndexIsFieldIndex()
                    Return each_element.ElementIndexIsFieldIndex()

                End If ''End of "If (objFldElement.FieldEnum = pintFieldIndex) Then"
            Next each_element

            Throw New Exception("Can't find element w/ matching Field.")

        End Function ''End of "Public Function GetElementIndexByFieldIndex_ThisSucks"


        Public Function MapElementIndex_OmitUnneeded(par_indexElement As Integer) As Integer
            ''
            ''  Added 11/24/2021 thomas downes
            ''
            ''---Throw New NotImplementedException("See BadgeSetupElements() instead.")
            ''===Throw New NotImplementedException(My.Resources.ErrorUseBadgeSetupElements)
            ''//Const strError_Msg As String = "See BadgeSetupElements() instead."
            ''//Throw New NotImplementedException(strError_Msg)
            ''Throw New NotImplementedException(My.Resources.ErrorUseBadgeSetupElements)

            ''Dim objList As List(Of ClassElementField)
            ''objList = ListOfBadgeDisplayElements_Flds();

            Dim boolMatch As Boolean
            Dim indexDisplay As Integer

            For indexDisplay = 0 To mod_listBadgeElements_Front.Count - 1
                boolMatch = (par_indexElement = mod_listBadgeElements_Front(indexDisplay).ElementIndexIsFieldIndex())
                If (boolMatch) Then Return indexDisplay
            Next indexDisplay

            Return -1

        End Function ''End of "Public Function MapElementIndex_OmitUnneeded(int par_indexElement)"


        Public Function GetElementByLabelCaption(par_caption As String) As ClassElementField
            ''Added 10/10/2019 td 
            Return (Nothing)

        End Function ''ENd of "Public Function GetFieldByLabelCaptionpar_caption As String) As ClassFieldAny"

        Public Function GetElementByField(par_field As ClassFieldAny) As ClassElementField
            ''Added 11/19/2021 td 
            ''Return (Nothing)

            For Each each_element As ClassElementField In ListOfElementFields

                If (each_element.FieldEnum = par_field.FieldEnumValue) Then Return each_element

            Next each_element

            Return Nothing

        End Function ''ENd of "Public Function GetElementByField As ClassElementField"


        Public Function CheckAllElementsHaveCorrectFieldInfo(ByRef pbAllFine As Boolean,
                                                         ByRef pstrMessage As String) As Boolean
            ''
            ''Added 11/19/2021 td 
            '' 
            Dim boolMatch As Boolean = False
            Dim intCountBad As Integer = 0
            Dim intCountAll As Integer = 0

            pbAllFine = True
            pstrMessage = ""

            For Each each_element As ClassElementField In ListOfElementFields
                intCountAll += 1
                boolMatch = (each_element.FieldEnum = each_element.FieldInfo.FieldEnumValue)
                ''We don't want to leave prematurely.''----If (Not boolMatch) Then Return False
                ''--If (Not boolMatch) Then pbAllFine = False
                pbAllFine = (boolMatch And pbAllFine)
                If (Not boolMatch) Then intCountBad += 1
            Next each_element

            ''[[[pbAllFine = True
            pstrMessage = $"Out of {intCountAll} elements, there are {intCountBad} misaligned fields."

            Return True

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
                obj_cache_elements.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
                                               obj_designForm.pictureBack) ''Added 9/19/2019 td

                pref_section = 20 ''Added 11/27/2019 td
                ''Added 10/14/2019 thomas d. 
                obj_cache_elements.LoadElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
                                               obj_designForm.pictureBack) ''Added 10/14/2019 td

                pref_section = 21 ''Added 11/27/2019 td
                ''Added 10/14/2019 thomas d. 
                obj_cache_elements.LoadElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
                                               obj_designForm.pictureBack) ''Added 10/14/2019 td

                pref_section = 22 ''Added 11/27/2019 td
                ''Added 10/14/2019 thomas d. 
                obj_cache_elements.LoadElement_Text(strStaticText,
                                                intLeft_Text, intTop_Text,
                                                intWidth_Text, intHeight_Text,
                                               obj_designForm.pictureBack) ''Added 10/14/2019 td

                pref_section = 23 ''Added 11/27/2019 td

            End If ''End of "If (pboolNewFileXML) Then"

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
                    intBadgeWidth = obj_cache_elements.ListFieldElements(0).BadgeLayout.Width_Pixels
                    intBadgeHeight = obj_cache_elements.ListFieldElements(0).BadgeLayout.Height_Pixels

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

        Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
            ''
            ''Added 11/29/2019 thomas downes
            ''
            ''This code was copied from FormDesignProtoTwo.vb, Private Sub SaveLayout(), on 11/29/2019 td
            ''
            Dim objSerializationClass As New ciBadgeSerialize.ClassSerial

            With objSerializationClass

                ''10/13/2019 td''.PathToXML = Me.ElementsCache_Saved.PathToXml_Saved
                .PathToXML = Me.PathToXml_Saved
                .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 

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

        Public Function GetBackgroundImage(pintWidth As Integer, pintHeight As Integer,
                                       pstrPathToLikelyFolder As String,
                                       pbooWereTwoPropertiesRefreshed As Boolean) As Image
            ''
            ''Added 1/14/2020 thomas downes
            ''
            Dim structCurrent As New BackgroundTitleAndWidth
            Dim imageFound As Image = Nothing
            Dim imageCreated1 As Image
            Dim imageCreated2 As Image

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
            structCurrent.sFileTitle = Me.BackgroundImage_Front_FTitle

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
                imageCreated1 = New Bitmap(Me.BackgroundImage_Front_Path)
                ''imageCreated.Dispose()
                imageCreated2 = New Bitmap(imageCreated1, New Size(pintWidth, pintHeight))
                mod_dictionaryBackgroundImages.Add(structCurrent, imageCreated2)
                imageCreated1.Dispose()
                Return imageCreated2
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


