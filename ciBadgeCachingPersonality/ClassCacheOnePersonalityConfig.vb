Option Explicit On
Option Strict On
Option Infer Off
''
''Added 11/24/2019 thomas downes
''  Copied from ClassElementsCache, on 11/24/2019 thomas downes
''
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
Imports ciBadgeElements ''Added 12/4/2021 thomas d. 

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassCacheOnePersonalityConfig
        ''
        ''Renamed 2/15/2022 from Public Class ClassPersonalityCache 
        ''

        ''Dec.13 2021''Implements ciBadgeInterfaces.InterfacePersonality ''Added 12/12/2021 Thomas Downes
        ''
        ''Added 11/24/2019 thomas downes
        ''  Copied from ClassElementsCache, on 11/24/2019 thomas downes
        ''
        Public Shared Singleton As ClassCacheOnePersonalityConfig ''Let's use
        '' the pattern mentioned in https://en.wikipedia.org/wiki/Singleton_pattern

        Public Property Id_GUID As System.Guid ''Dec.13 2021''Implements InterfacePersonality.Id_GUID ''Added 9/30/2019 td 
        Public Property Id_GUID6 As String ''Dec.13 2021''Implements InterfacePersonality.Id_GUID6 ''Added 12/12/2021 td 

        Public Property PersonalityConfig As ClassPersonalityConfig ''Added 12/13/2021 td 

        ''Dec13 2021 td''Public Property CustomerNumber As String Implements InterfacePersonality.CustomerNumber ''Added 12/12/2021 td
        ''Dec13 2021 td''Public Property ConfigID As Integer Implements InterfacePersonality.ConfigID ''Added 12/12/2021 td
        ''Dec13 2021 td''Public Property IsVisitorManagement As Boolean Implements InterfacePersonality.IsVisitorManagement ''Added 12/12/2021 td

        ''Dec13 2021 td''Public Property Name_Description As String Implements InterfacePersonality.Name_PersonalityDescription ''Added 12/12/2021
        ''Dec13 2021 td''Public Property Name_ReferringToThem_Plural As String Implements InterfacePersonality.Name_ReferringToThem_Plural ''Added 12/12/2021
        ''Dec13 2021 td''Public Property Name_ReferringToOne_Singular As String Implements InterfacePersonality.Name_ReferringToOne_Singular ''Added 12/12/2021

        ''10/10/2019 td''Public Property SaveToXmlPath As String ''Added 9/29/2019 td
        Public Property PathToXml_Saved As String ''Added 9/29/2019 td
        Public Property PathToXml_Binary As String ''Added 11/29/2019 td

        ''Added 12/12/2021 thomas downes


        Public Property ElementQRCode As ClassElementQRCode ''Added 10/8/2019 thomas d.  
        Public Property ElementSignature As ClassElementSignature ''Added 10/8/2019 thomas d.  

        Public Property ListOfRecipients As List(Of ClassRecipient) ''Added 1/14/2020 & 10/11/2019 td

        ''10/14/2019 td''Private mod_listFields As New List(Of ClassFieldAny) ''Added 9/18/2019 td  

        ''10/17 td''Private mod_listFields_Standard As New List(Of ClassFieldStandard) ''Added 10/14/2019 td  
        ''10/17 td''Private mod_listFields_Custom As New List(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        ''10/17 td''Private mod_listElementFields As New List(Of ClassElementField)
        ''10/17 td''Private mod_listElementPics As New List(Of ClassElementPic)
        ''10/17 td''Private mod_listElementStatics As New List(Of ClassElementStaticText)
        ''10/17 td''Private mod_listElementLaysections As New List(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes

        Private mod_listFields_Standard As New HashSet(Of ClassFieldStandard) ''Added 10/14/2019 td  
        Private mod_listFields_Custom As New HashSet(Of ClassFieldCustomized) ''Added 10/14/2019 td  

        ''See ClassLayoutCache. 11/24 td''Private mod_listElementFields As New HashSet(Of ClassElementField)
        ''See ClassLayoutCache. 11/24 td''Private mod_listElementPics As New HashSet(Of ClassElementPic)
        ''See ClassLayoutCache. 11/24 td''Private mod_listElementStatics As New HashSet(Of ClassElementStaticText)
        ''See ClassLayoutCache. 11/24 td''Private mod_listElementLaysections As New HashSet(Of ClassElementLaysection) ''Added 9/17/2019 thomas downes
        Private mod_listLayouts As New HashSet(Of ClassCacheOneLayout) ''Added 11.24.2019 thomas d.

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



        Public Property ListOfLayouts As HashSet(Of ClassCacheOneLayout)  ''Added 11/24/2019 td
            Get ''Added 11/24
                Return mod_listLayouts
            End Get
            Set(value As HashSet(Of ClassCacheOneLayout))
                ''Added 11/24/2019 td
                mod_listLayouts = value
            End Set
        End Property

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
            ''5/09/2022 ''ClassFieldStandard.InitializeHardcodedList_Standard(True)    ''5/2022   _Students(True)
            Dim list_fields_Standard As HashSet(Of ClassFieldStandard)
            list_fields_Standard = ClassFieldStandard.GetInitializedList_Standard("Students")

            ''----------------------------------------------------------------------------------------------------
            ''Custom Fields (Initialize the list)  
            ''
            ''5/09/2022 ''ClassFieldCustomized.InitializeHardcodedList_Custom(True)    ''5/2022   _Students(True)
            Dim list_fields_Custom As HashSet(Of ClassFieldCustomized)
            list_fields_Custom = ClassFieldCustomized.GetInitializedList_Custom("Students")

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
            For Each each_field_standard As ClassFieldStandard In list_fields_Standard ''5/2022 ClassFieldStandard.ListOfFields_Standard
                ''5/2022  For Each ... As ...  In ClassFieldStandard.ListOfFields_Students

                ''10/14/2019 td''mod_listFields.Add(each_field_standard)
                mod_listFields_Standard.Add(each_field_standard)

            Next each_field_standard
            ''----------------------------------------------------------------------------------------------------

            ''----------------------------------------------------------------------------------------------------
            ''Customized Fields (Collect the list items)  
            ''
            For Each each_field_customized As ClassFieldCustomized In list_fields_Custom ''5/2022 ClassFieldCustomized.ListOfFields_Custom
                ''5/2022  In ClassFieldCustomized.ListOfFields_Students

                ''10/14/2019 td''mod_listFields.Add(each_field_customized)
                mod_listFields_Custom.Add(each_field_customized)

            Next each_field_customized
            ''----------------------------------------------------------------------------------------------------

        End Sub ''End of "Public Sub LoadFields(par_pictureBackground As PictureBox)"

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

        Public Function Copy() As ClassCacheOnePersonalityConfig
            ''
            ''Added 11/24/2019 thomas downes  
            ''
            Dim objCopyOfCache As New ClassCacheOnePersonalityConfig
            Dim ListFields_NotUsed As New List(Of ClassFieldAny)
            Dim dictionaryFields As New Dictionary(Of ciBadgeInterfaces.EnumCIBFields, ClassFieldAny)
            ''10/14/2019 td''Dim copy_ofField As ClassFieldAny
            Dim copy_ofField_Stan As ClassFieldStandard
            Dim copy_ofField_Cust As ClassFieldCustomized
            ''11/24/2019 td''Dim copy_ofElementField As ClassElementField ''Added 10/1/2019 td

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


            ''Added 11/24/2019 td 
            ''  Copy the Layout Caches. 
            ''
            Dim copy_ofLayoutCache As ClassCacheOneLayout ''Added 11.24.2019 thomas d. 

            For Each each_layoutCache As ClassCacheOneLayout In mod_listLayouts

                copy_ofLayoutCache = each_layoutCache.Copy()
                objCopyOfCache.ListOfLayouts.Add(copy_ofLayoutCache)

            Next each_layoutCache


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


        Public Function GetLayoutByGUID(par_guid As System.Guid) As ClassCacheOneLayout
            ''
            ''Added 11/24/2019 td  
            ''
            Throw New NotImplementedException("Not implemented.   #x4591")

        End Function ''End of "Public Function GetLayoutByGUID(par_guid As System.Guid) As ClassLayoutCache"

        Public Function MissingTheLayouts() As Boolean
            ''Added 10/10/2019 td 
            ''10/14/2019 td''Return (0 = mod_listFields.Count)
            Return (0 = mod_listLayouts.Count)

        End Function ''ENd of "Public Function MissingTheLayouts() As Boolean"


        Public Shared Function GetLoadedCache(pstrPathToXML As String,
                                          pboolNewFileXML As Boolean) As ClassCacheOnePersonalityConfig
            ''
            ''Added 11/24/2019 td
            ''
            Dim obj_cache_personality As ClassCacheOnePersonalityConfig ''Added 10/10/2019 td
            Dim obj_designForm As New FormBadgeLayoutProto ''Added 11/15/2019 td 

            pboolNewFileXML = (Not System.IO.File.Exists(pstrPathToXML))

            ''
            ''Major call!!
            ''
            If (pboolNewFileXML) Then ''Condition added 10/10/2019 td  

                obj_cache_personality = New ClassCacheOnePersonalityConfig
                obj_cache_personality.PathToXml_Saved = pstrPathToXML

                obj_cache_personality.LoadFields()

            Else
                ''Added 10/10/2019 td  
                Dim objDeserialize As New ciBadgeSerialize.ClassDeserial With {
                .PathToXML = pstrPathToXML
            } ''Added 10/10/2019 td  

                obj_cache_personality = New ClassCacheOnePersonalityConfig ''This may or may not be completely necessary,
                ''   but I know of no other way to pass the object type.  Simply expressing the Type
                ''   by typing its name doesn't work.  ---10/13/2019 td

                obj_cache_personality = CType(objDeserialize.DeserializeFromXML(obj_cache_personality.GetType(), False), ClassCacheOnePersonalityConfig)

                ''obj_cache_personality.LinkElementsToFields()

            End If ''End of "If (pboolNewFileXML) Then .... Else ..."


            If (pboolNewFileXML) Then

                'obj_cache_elements.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
                '                                   obj_designForm.pictureBack) ''Added 9/19/2019 td

                '''Added 10/14/2019 thomas d. 
                'obj_cache_elements.LoadElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
                '                                   obj_designForm.pictureBack) ''Added 10/14/2019 td

                '''Added 10/14/2019 thomas d. 
                'obj_cache_elements.LoadElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
                '                                   obj_designForm.pictureBack) ''Added 10/14/2019 td

                '''Added 10/14/2019 thomas d. 
                'obj_cache_elements.LoadElement_Text(strStaticText,
                '                                    intLeft_Text, intTop_Text,
                '                                    intWidth_Text, intHeight_Text,
                '                                   obj_designForm.pictureBack) ''Added 10/14/2019 td

            End If ''End of "If (pboolNewFileXML) Then"

            ''Added 9/24/2019 thomas 
            ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
            ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
            ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

            ''Added 11/18/2019 td
            ''With obj_cache_elements
            ''    ''Added 11/18/2019 td
            ''    If (.BadgeLayout Is Nothing) Then
            ''        Dim intBadgeWidth As Integer
            ''        Dim intBadgeHeight As Integer

            ''        intBadgeWidth = obj_cache_elements.ListFieldElements(0).BadgeLayout.Width_Pixels
            ''        intBadgeHeight = obj_cache_elements.ListFieldElements(0).BadgeLayout.Height_Pixels

            ''        .BadgeLayout = New BadgeLayoutClass(intBadgeWidth, intBadgeHeight)

            ''    End If ''End of "If (obj_cache_elements.BadgeLayout Is Nothing) Then
            ''End With

            Return obj_cache_personality

        End Function ''End of "Public Shared Function GetLoadedCache() As ClassPersonalityCache"

        Public Sub SaveToXML()
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

                ''Added 9/24/2019 thomas 
                ''  ''11/29/2019 td''.SerializeToXML(Me.GetType, Me, False, True)

                Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td

                boolSerializeToBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat

                If (boolSerializeToBinary) Then
                    .SerializeToBinary(Me.GetType, Me)
                Else
                    ''April1 2022 ''.SerializeToXML(Me.GetType, Me, False, True)
                    Const c_AutoOpenFile As Boolean = False ''April1 2022 '' True
                    .SerializeToXML(Me.GetType, Me, False, c_AutoOpenFile)

                End If ''End of "If (boolSerializeToBinary) Then ... Else"

            End With ''End of "With objSerializationClass"

        End Sub ''End of "Public Sub SaveToXML()"

    End Class ''End of Class ClassPersonality

End Namespace
