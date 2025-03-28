﻿Option Strict On
Option Explicit On

Imports ciBadgeElements ''Added 12/5/2021 
Imports ciBadgeFields ''Added 12/5/2021  
Imports ciBadgeInterfaces ''Added 1/17/2022  

Namespace ciBadgeCachePersonality
    ''
    ''Added 12/4/2021 thomas downes 
    ''
    Public Enum EnumCacheType
        ''
        ''Added 7/4/2022 thomas downes
        ''
        Undetermined
        FieldsElementsLayout
        PersonalityRecipients
        SpreadsheetData

        PathsToCachesByType

    End Enum ''End of ""Public Enum EnumCacheType""

    <Serializable>
    Public Class ClassPathsToCachesByType

        Public Property PathToCache_ElementsLayout As String
        Public Property PathToCache_PersonalityRecips As String
        Public Property PathToCache_SpreadsheetData As String

    End Class


    Public Class ClassCacheManagement
        ''
        ''Added 12/4/2021 thomas downes 
        ''
        Public Shared LatestCacheOfEdits_Guid6 As String = "" ''This is a 6-character GUID. ---12/12/2021 td

        ''Added 7/4/2022 thomas downes
        Public ListOfCachesByType As Dictionary(Of EnumCacheType, InterfaceCacheToXML)
        Public PathsToCachesByType As New ClassPathsToCachesByType ''Added 7/4/2022 thomas downes

        ''Added 2/8/2022 td
        Public RuntimeError As Boolean ''Added 2/8/2022 td
        Public RuntimeErrorMessage As String ''Added 2/8/2022 td

        Private mod_cacheEdits As ClassElementsCache_Deprecated
        Private mod_cacheSaved As ClassElementsCache_Deprecated
        Private mod_strPathToSavedFileXML As String

        Public ReadOnly Property CacheForEditing() As ClassElementsCache_Deprecated
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            Get
                Return mod_cacheEdits
            End Get
        End Property


        Public Sub New(pstrPathToSavedFileXML As String)
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            mod_strPathToSavedFileXML = pstrPathToSavedFileXML

            ''Dec14 2021''LoadBothCachesUsingSamePathToXML(pstrPathToSavedFileXML)

            ''Added Dec14 2021 
            mod_cacheEdits = GetLoadedCacheUsingPathToXML(pstrPathToSavedFileXML)
            mod_cacheSaved = GetLoadedCacheUsingPathToXML(pstrPathToSavedFileXML)

            ''Added 3/23/2022 thomas d.
            CheckForMissingFields_FixOrNot(True)


        End Sub ''End of " Public Sub New"


        Public Sub New_Deprecated(par_edits As ClassElementsCache_Deprecated, par_saved As ClassElementsCache_Deprecated)
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            mod_cacheEdits = par_edits
            mod_cacheSaved = par_saved

            ''Added 12/12/2021 
            ''Dec.12 2021''If (LatestCacheOfEdits_Guid6 = "") Then LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6
            LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6

        End Sub ''End of "Public Sub New_Deprecated"


        Public Sub New(par_cacheForEdits As ClassElementsCache_Deprecated,
                       pboolAllowCacheToBeCopied_Deprecated As Boolean,
                       Optional pstrPathToSavedFileXML As String = "",
                       Optional pboolPathIsNewFile As Boolean = False)
            ''
            ''Added 12/14/2021 td
            ''
            ''Me.ElementsCache_Saved = par_cacheForEdits.Copy()
            mod_cacheEdits = par_cacheForEdits
            ''Dec. 14 2021''mod_cacheSaved = par_cacheForEdits.Copy()

            ''Added 12/14/2021 td
            If (pboolAllowCacheToBeCopied_Deprecated) Then
                ''Use the Copy() command.
                mod_cacheSaved = par_cacheForEdits.Copy_Deprecated()

            ElseIf (pboolPathIsNewFile) Then
                ''
                ''Don't try to load an existing cache.  Don't do it, because the XML file 
                ''   doesn't exist yet. The user has selected purposely to open a new, blank, unadorned
                ''   cache.  ----2/26/2022 td
                ''
                mod_cacheSaved = New ClassElementsCache_Deprecated()

            ElseIf (pstrPathToSavedFileXML <> "") Then

                ''Added 12/14/2021 td
                ''Dec14 2021''LoadSavedCacheUsingPathToXML(pstrPathToSavedFileXML)
                mod_cacheSaved = GetLoadedCacheUsingPathToXML(pstrPathToSavedFileXML)

            Else

                ''Added 3/23/2023 td
                mod_cacheSaved = GetLoadedCacheUsingPathToXML(mod_cacheEdits.PathToXml_Opened)

            End If ''End of " If (pboolAllowCacheToBeCopied) Then ... ElseIf ...

            ''Dec12 2021''Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generates a new GUID.
            With mod_cacheSaved
                .Id_GUID = New Guid() ''Generates a new GUID. 
                .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6) ''Added 12/12/2021  
            End With ''eND OF "With mod_cacheSaved"

            ''Added 12/12/2021 
            ''Dec.12 2021''If (LatestCacheOfEdits_Guid6 = "") Then LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6
            LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6

            ''Added 3/23/2022 thomas d.
            CheckForMissingFields_FixOrNot(True)

        End Sub ''End of Public Sub New(par_cacheForEdits As ClassElementsCache_Deprecated)


        Public Function GetCacheForSaving(pboolMajorSortOfRefresh As Boolean) As ClassElementsCache_Deprecated
            ''
            ''Added 12/14/2021 
            ''
            If (Not pboolMajorSortOfRefresh) Then
                ''6/2022 Throw New Exception("Don't use unless a big type of refresh is taking place.")
                System.Diagnostics.Debugger.Break()
            End If ''End of ""If (Not pboolMajorSortOfRefresh) Then""

            Return mod_cacheSaved

        End Function ''end if ""Public Function GetCacheForSaving""


        Public Function GetOmittedElements() As List(Of ClassOmittedElement)
            ''
            ''Added 3/3/2022 thomas downes
            ''
            Dim listOmitted As New List(Of ClassOmittedElement)

            ''Is Portrait omitted? 
            Dim boolZeroPortraits As Boolean
            boolZeroPortraits = (0 = mod_cacheEdits.ListOfElementPics_BothSides().Count)
            If (boolZeroPortraits) Then listOmitted.Add(New ClassOmittedElement(Enum_ElementType.Portrait, "Portrait"))

            ''Is QRCode omitted? 
            Dim boolZeroQRCodes As Boolean
            boolZeroQRCodes = (0 = mod_cacheEdits.ListOfElementQRCodes_Front().Count) And
                  (0 = mod_cacheEdits.ListOfElementQRCodes_Back().Count)
            If (boolZeroQRCodes) Then listOmitted.Add(New ClassOmittedElement(Enum_ElementType.QRCode, "QR Code"))

            ''Is Signature omitted? 
            Dim bZeroSignatures As Boolean
            bZeroSignatures = (0 = mod_cacheEdits.ListOfElementSignatures_Front().Count) And
                  (0 = mod_cacheEdits.ListOfElementSignatures_Back().Count)
            If (bZeroSignatures) Then listOmitted.Add(New ClassOmittedElement(Enum_ElementType.Signature, "Signature"))

            ''Is Graphical Element/Logo omitted? 
            Dim bZeroGraphics As Boolean
            bZeroGraphics = (0 = mod_cacheEdits.ListOfElementGraphics_Front().Count) And
                  (0 = mod_cacheEdits.ListOfElementGraphics_Backside().Count)
            If (bZeroGraphics) Then listOmitted.Add(New ClassOmittedElement(Enum_ElementType.StaticGraphic, "Graphics/Logos"))

            ''Are all Textual Elements omitted? 
            Dim bZeroStaticTextuals As Boolean
            bZeroStaticTextuals = (0 = mod_cacheEdits.ListOfElementTextsV3_Front().Count) And
                  (0 = mod_cacheEdits.ListOfElementTextsV3_Backside().Count) And
                  (0 = mod_cacheEdits.ListOfElementTextsV4_Front().Count) And
                  (0 = mod_cacheEdits.ListOfElementTextsV4_Backside().Count)
            If (bZeroStaticTextuals) Then listOmitted.Add(New ClassOmittedElement(Enum_ElementType.StaticTextV4, "Any text you want to add"))

            ''Added 12/2022 
            Return listOmitted ''Added 12/2022 

        End Function ''End of "Public Function GetOmittedElements()"


        Public Sub Save(pboolSaveToFileXML As Boolean,
                        Optional ByRef pstrPathToFileXML As String = "",
                        Optional par_BadgeImage As System.Drawing.Image = Nothing)
            ''
            ''Dec14 2021''Public Sub Save(pboolSaveToFileXML As Boolean)
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            ''Dec14 2021 ''mod_cacheEdits.SaveToXML()
            If (pboolSaveToFileXML) Then
                ''
                ''Serialize to XML & use an IO procedure to save to the PC's disk system.
                ''
                If (pstrPathToFileXML <> "") Then mod_cacheEdits.PathToXml_Saved = pstrPathToFileXML
                If (pstrPathToFileXML = "") Then pstrPathToFileXML = mod_cacheEdits.PathToXml_Saved
                If (pstrPathToFileXML = "") Then pstrPathToFileXML = mod_cacheEdits.PathToXml_Opened ''Added 12/14/2021 td

                mod_cacheEdits.PathToXml_Saved = pstrPathToFileXML ''Added 12/14/2021 td 
                mod_cacheEdits.XmlFile_Path_Deprecated = pstrPathToFileXML ''Added 12/14/2021 
                mod_cacheEdits.SaveToXML(pstrPathToFileXML)

                ''
                ''Added 12/10/2021 thomas downes 
                ''   Create and save the Badge-Layout Image file.
                ''
                Dim strTitleOfXML As String = ""
                Dim strPathToFileJpg As String = ""
                Dim strPathToXml_Binary As String ''Added 12/14/2021 td

                ''Dec14 2021''strTitleOfXML = mod_cacheEdits.XmlFile_FTitle
                mod_cacheEdits.XmlFile_Path_Deprecated = pstrPathToFileXML
                mod_cacheEdits.XmlFile_FTitle_Deprecated = (New IO.FileInfo(pstrPathToFileXML)).Name ''Only the file title, e.g. "Thomas.xml".

                ''Dec14 2021''strPathToFileJpg = mod_cacheEdits.PathToXml_Binary.Replace(".xml", ".jpg")
                strPathToXml_Binary = mod_cacheEdits.PathToXml_Binary

                ''Added 12/10/2022 thomas d. 
                If (Not String.IsNullOrEmpty(pstrPathToFileXML)) Then
                    strPathToFileJpg = pstrPathToFileXML.Replace(".xml", ".jpg")
                End If ''End of "If (Not String.IsNullOrEmpty(...)) Then"

                ''This code may work better in the calling procedure.----12/10/2021 td
                If (par_BadgeImage IsNot Nothing) Then
                    ''
                    ''Create an image file (in JPEG form).  
                    ''
                    If (Not String.IsNullOrEmpty(strPathToFileJpg)) Then
                        ''Create an image file (in JPEG form). ---1/5/2022 td 
                        CreateBadgeLayoutImageFile(par_BadgeImage, strPathToFileJpg)
                    End If ''End of "If (Not String.IsNullOrEmpty(strPathToFileJpg)) Then"
                End If ''End of "If (par_BadgeImage IsNot Nothing) Then"

                ''Added 12/6/2021 td  
                ''----Dec.6 2021 ----mod_cacheSaved = mod_cacheEdits
                ''----Dec.14 2021 ----mod_cacheSaved = mod_cacheEdits.Copy()
                If (pstrPathToFileXML = "") Then pstrPathToFileXML = mod_cacheEdits.PathToXml_Saved

                ''
                ''Load the Saved cache. ---Dec. 14, 2021 
                ''
                mod_cacheSaved = GetLoadedCacheUsingPathToXML(pstrPathToFileXML)

            Else
                ''
                ''Wait, I don't think we should call the Sub .SaveToXML() !! --12/14/2021 td''--mod_cacheEdits.SaveToXML()
                ''
                ''So, let's leverage the two-cache system.
                ''
                Dim strPathToXML As String ''Added 12/14/2021 td
                strPathToXML = mod_cacheEdits.PathToXml_Opened
                If (String.IsNullOrEmpty(strPathToXML)) Then strPathToXML = mod_cacheEdits.PathToXml_Saved
                ''----12/14/2021''mod_cacheEdits = mod_cacheSaved
                ''----12/14/2021''mod_cacheSaved = GetLoadedCacheUsingPathToXML(strPathToXML)
                mod_cacheSaved = mod_cacheEdits
                mod_cacheEdits = CopyViaSerializeDeserialize(mod_cacheEdits)

            End If ''End of "If (pboolSaveToFileXML) Then.... Else"

        End Sub ''End of "Public Sub Save()"


        Public Sub Make_BadgeLayoutImageFile(par_BadgeImage As System.Drawing.Image,
                                               par_strPathToProposedJpeg As String)
            ''
            ''Alias function created 2/01/2022 thomas downes 
            ''
            CreateBadgeLayoutImageFile(par_BadgeImage, par_strPathToProposedJpeg)

        End Sub


        Public Sub Image_BadgeLayoutImageFile(par_BadgeImage As System.Drawing.Image,
                                               par_strPathToProposedJpeg As String)
            ''
            ''Alias function created 2/01/2022 thomas downes 
            ''
            CreateBadgeLayoutImageFile(par_BadgeImage, par_strPathToProposedJpeg)

        End Sub

        Public Sub CreateBadgeLayoutImageFile(par_BadgeImage As System.Drawing.Image,
                                               par_strPathToProposedJpeg As String,
                                              Optional pbWinformEnvironment As Boolean = False)
            ''
            ''Added 1/5/2022 thomas downes 
            ''
            Try
                par_BadgeImage.Save(par_strPathToProposedJpeg,
                                System.Drawing.Imaging.ImageFormat.Jpeg)
            Catch ex As Exception
                ''Added 2/8/2022 td  
                ''
                ''Was the destination folder moved or renamed? 
                ''
                Me.RuntimeError = True
                Me.RuntimeErrorMessage =
                    "Was the XML folder moved? " &
                    "The following path failed, or the badge layout image is corrupted." &
                     vbCrLf_Deux & par_strPathToProposedJpeg &
                     vbCrLf_Deux & ex.Message

                ''Added 2/8/2022 td 
                If (pbWinformEnvironment) Then
                    ''
                    ''We are on a Windows laptop. It's okay to give pop-up messages.   
                    ''
                    MessageBoxTD.Show_Statement(Me.RuntimeErrorMessage)

                End If ''End of "If (pboolGiveWinformMessages) Then"

            End Try

        End Sub ''End of "Public Sub CreateBadgeLayoutImage(pstrPathToJpeg As String)"


        Public Sub RefreshSaved_ViaPathXML(pstrPathToXML As String)
            ''
            ''Added 12/14/2021 td
            ''
            mod_cacheSaved = GetLoadedCacheUsingPathToXML(pstrPathToXML)

        End Sub ''End of "Public Sub RefreshSaved_ViaPathXML(pstrPathToXML As String)"


        Public Function CopyViaSerializeDeserialize(par_cache As ClassElementsCache_Deprecated) As ClassElementsCache_Deprecated
            ''
            ''Added 12/14/2021 td 
            ''
            Dim objCacheOutput As ClassElementsCache_Deprecated
            Dim strTemporaryFilePath As String

            ''12/14/2021 td''strTemporaryFilePath = DiskFilesVB.Path_TemporaryFileXML()
            strTemporaryFilePath = DiskFilesVB.Path_RandomFileXML()

            par_cache.SaveToXML(strTemporaryFilePath)
            Threading.Thread.Sleep(3000) ''Wait 3 seconds.
            objCacheOutput = GetLoadedCacheUsingPathToXML(strTemporaryFilePath)
            objCacheOutput.Check_LinkElementsToFields()
            IO.File.Delete(strTemporaryFilePath)
            Return objCacheOutput

        End Function ''End of "Public Function CopyViaSerializeDeserialize"


        Public Function UndoEdits(pboolUseCacheSaved As Boolean) As ClassElementsCache_Deprecated
            ''----Dec14 2021----Public Sub UndoEdits()
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            ''Dec.14, 2021 td''mod_cacheEdits = mod_cacheSaved.Copy

            If (pboolUseCacheSaved) Then ''Added 12/14/2021 td

                ''Added 12/14/2021 td
                mod_cacheEdits = mod_cacheSaved
                ''Get a back-up copy from the disk. 
                mod_cacheSaved = GetLoadedCacheUsingPathToXML(mod_cacheEdits.PathToXml_Saved)

            ElseIf (mod_cacheSaved.PathToXml_Saved <> "") Then
                ''
                ''Provide the path. 
                ''
                LoadBothCachesUsingSamePathToXML(mod_cacheSaved.PathToXml_Saved)

            Else
                LoadBothCachesUsingSamePathToXML()

            End If ''End of 'If (...) then ... elseif (...) ... Else ..."

            Return mod_cacheEdits

        End Function ''End of "Public Function UndoEdits() as ClassElementsCache_Deprecated"


        Public Sub CheckForOrphanedElements()
            ''
            ''Added 12/4/2021 thomas downes  
            ''



        End Sub ''End of "Public Sub CheckForOrphanedElements()"


        Public Sub CheckForMissingFields_AllOfThem()
            ''
            ''Added 3/23/2022 thomas downes  
            ''
            Dim list_fieldEnums_all As List(Of EnumCIBFields)
            Dim intNumFixed As Integer

            list_fieldEnums_all = GetListOfAllFieldEnums()
            CheckForMissingFields_FixOrNot(True, intNumFixed, list_fieldEnums_all)

        End Sub ''end of ""Public Sub CheckForMissingFields_AllOfThem()""


        Public Function CheckForMissingFields_FixOrNot(pboolLetsFix As Boolean,
                            Optional ByRef pint_numFixed As Integer = 0,
                            Optional par_list As List(Of EnumCIBFields) = Nothing) As Boolean
            ''
            ''Added 3/23/2022 thomas downes  
            ''
            Dim objField_IfFound As ClassFieldAny
            Dim outputBoolean_Missing As Boolean = False
            Dim listOfEnumsToCheck As List(Of EnumCIBFields)
            Dim bLikelyCustomized As Boolean ''Added 5/5/2022 td

            If (par_list Is Nothing OrElse par_list.Count() = 0) Then
                ''General a list of cutting-edge fields which might not
                ''   have been instantied-as-objects yet.
                ''   ----5/5/2022 td 
                listOfEnumsToCheck = New List(Of EnumCIBFields)
                ''This is the list of enumerated values to double-check
                ''----listOfEnumsToCheck.Add(EnumCIBFields.TextField25)
                listOfEnumsToCheck.Add(EnumCIBFields.fstrFullName)
                listOfEnumsToCheck.Add(EnumCIBFields.fstrNameAbbreviated)

            Else
                listOfEnumsToCheck = par_list

            End If ''End of ""If (par_list Is Nothing OrElse par_list.Count() = 0) Then.... Else..."

            ''
            ''Testing for the first 5 Custom Text Fields. 
            ''
            Dim objFieldCustomText01 As ClassFieldAny
            objFieldCustomText01 = CacheForEditing.GetFieldByFieldEnum(EnumCIBFields.TextField01)
            Dim objFieldCustomText02 As ClassFieldAny
            objFieldCustomText02 = CacheForEditing.GetFieldByFieldEnum(EnumCIBFields.TextField02)
            Dim objFieldCustomText03 As ClassFieldAny
            objFieldCustomText03 = CacheForEditing.GetFieldByFieldEnum(EnumCIBFields.TextField03)
            Dim objFieldCustomText04 As ClassFieldAny
            objFieldCustomText04 = CacheForEditing.GetFieldByFieldEnum(EnumCIBFields.TextField04)
            Dim objFieldCustomText05 As ClassFieldAny
            objFieldCustomText05 = CacheForEditing.GetFieldByFieldEnum(EnumCIBFields.TextField05)

            ''
            ''Run through the list of enumerated values. 
            ''
            For Each each_enum As EnumCIBFields In listOfEnumsToCheck
                ''
                ''Field "Full Name"
                ''
                objField_IfFound = CacheForEditing.GetFieldByFieldEnum(each_enum)
                outputBoolean_Missing = (outputBoolean_Missing Or objField_IfFound Is Nothing)

                ''Added 5/5/2022 td 
                ''---5/5/2022 bLikelyCustomized = (CInt(each_enum) > CInt(EnumCIBFields.fstrBarCode))
                bLikelyCustomized = (CInt(each_enum) > CInt(EnumCIBFields.fstrRFID_Unique))

                ''
                ''There is //no// proper way to address a missing field at runtime. The program code
                ''   which creates the entire list of fields must be fixed.---5/10/2022 td 
                ''
                If (False And pboolLetsFix) Then
                    ''
                    ''Currently, it must be a Standard field (hence the ", False" as the 2nd parameter).  
                    ''
                    CacheForEditing.LoadField_ByEnum_Deprecated(each_enum, bLikelyCustomized)

                End If ''End of "If (pboolLetsFix) Then"

            Next each_enum

            ''There is //no// proper way to address a missing field at runtime. The program code
            ''   which creates the entire list of fields must be fixed.---5/10/2022 td 
            Return False ''Added 12/31/2022 thomas

        End Function ''End of "Public Function CheckForMissingFields()"


        Public Sub CheckCacheIsLatestForEdits(ByRef pref_pIsLatest As Boolean,
                                               Optional ByRef pref_IsACopyOfLatest As Boolean = False,
                                              Optional ByVal par_IssueMessageBox As Boolean = False)
            ''
            ''Added 12/12/2021 thomas 
            ''
            ''---pref_pIsLatest = (Me.Id_GUID6 = ClassCacheManagement.LatestCacheOfEdits_Guid6)
            ''---pref_IsACopyOfLatest = (Me.Id_GUID6_CopiedFrom = ClassCacheManagement.LatestCacheOfEdits_Guid6)
            Me.CacheForEditing.CheckCacheIsLatestForEdits(pref_pIsLatest, pref_IsACopyOfLatest)

            ''Added 12/12/2021 td
            If (pref_pIsLatest = False And par_IssueMessageBox) Then
                Windows.Forms.MessageBox.Show("The proposed cache is __NOT___ the latest & greatest.")
            End If ''End of "If (pref_pIsLatest = False And par_IssueMessageBox) Then"

        End Sub ''End of "Public Sub CheckCacheIsLatestForEdits()"


        ''5/11/2022 td''Public Function CheckAllElementsHaveCorrectFieldInfo(ByRef pbAllFine As Boolean,
        ''                                         ByRef pstrMessage As String) As Boolean
        ''    ''
        ''    ''Added 11/19/2021 td 
        ''    '' 
        ''    Return mod_cacheEdits.CheckAllElementsHaveCorrectFieldInfo(pbAllFine, pstrMessage)

        ''End Function ''End of "Public Function CheckAllElementsHaveCorrectFieldInfo"


        Public Sub LoadField_ByEnum_Deprecated(par_enumCIB As EnumCIBFields, pboolIsCustomField As Boolean)
            ''
            ''Added 3/23/2022 thomas d. 
            ''
            ''There is //no// best-practices way to re-supply a missing field at runtime.
            ''   Rather, the program code which creates the entire list of fields must be
            ''   revamped/ fixed.---5/10/2022 td 
            ''
            CacheForEditing.LoadField_ByEnum_Deprecated(par_enumCIB, pboolIsCustomField)

        End Sub ''End of "Public Sub LoadField_ByEnum_Deprecated(par_enumCIB As EnumCIBFields)"



        Public Sub LinkElementsToFields()
            ''
            ''Added 12/4/2021 & 10/12/2019 thomas d. 
            ''
            mod_cacheEdits.Check_LinkElementsToFields()

        End Sub ''End of "Public Sub LinkElementsToFields()"

        Public Sub Check_LinkElementsToFields(Optional pboolOverride As Boolean = True,
                                             Optional ByRef pref_strReport As String = "")
            ''
            ''Added 12/14/2021 thomas downes
            ''
            mod_cacheEdits.Check_LinkElementsToFields(pboolOverride, pref_strReport)

        End Sub

        Public Sub CheckEditedFieldsHaveElementsIfNeeded_Custom(ByRef pstrListOfFields As String, ByRef pstrErrorMessage As String)
            ''
            ''
            ''Double-check what has been saved. ----12/4/2021 td
            ''
            ''
            Dim each_field_possiblyEdited As ClassFieldCustomized
            Dim each_field_saved As ClassFieldAny
            Dim ListFieldsAdded As New List(Of ClassFieldCustomized)
            Dim ListFieldsRemoved As New List(Of ClassFieldCustomized)
            Dim boolDifferingSoEdited As Boolean
            Dim strListOfBadgeFields As String = "List of Custom Fields to go on Badge" & vbCrLf_Deux
            ''Unused.12/2022 Dim each_element As ciBadgeElements.ClassElementFieldV3

            ''---For Each each_field In Me.ElementsCache_Edits.ListOfFields_Custom()
            For Each each_field_possiblyEdited In mod_cacheEdits.ListOfFields_Custom()
                ''
                ''
                ''Is the field in danger of needing an element (but not having one)?
                ''
                ''
                ''each_field_edited = each_field_possiblyEdited
                ''each_field_saved = mod_cacheSaved.GetFieldByLabelCaption

                Dim fieldConfirmedToBeEdited As ClassFieldCustomized = Nothing
                each_field_saved = mod_cacheSaved.GetFieldByLabelCaption(each_field_possiblyEdited.FieldLabelCaption)
                If (each_field_saved Is Nothing) Then
                    pstrErrorMessage = "Corresponding Saved field not found!"
                    Return
                End If ''End of "If (each_field_saved Is Nothing) Then"

                boolDifferingSoEdited = (each_field_possiblyEdited.IsDisplayedOnBadge <> each_field_saved.IsDisplayedOnBadge)
                If (boolDifferingSoEdited) Then fieldConfirmedToBeEdited = each_field_possiblyEdited

                If (each_field_possiblyEdited.IsDisplayedOnBadge) Then
                    ''
                    ''Added 12/4/2021
                    ''
                    strListOfBadgeFields += (each_field_possiblyEdited.FieldLabelCaption & vbCrLf &
                    "     Is the field relevant? " & each_field_possiblyEdited.IsRelevantToPersonality.ToString() & vbCrLf &
                    "     Is the field likely to be missing a corresponding element? " & boolDifferingSoEdited.ToString & vbCrLf)

                    If (boolDifferingSoEdited) Then
                        ''
                        ''Major call!!
                        ''
                        fieldConfirmedToBeEdited = each_field_possiblyEdited

                        FieldIsNowDisplayed_SoBuildElementIfNeeded(fieldConfirmedToBeEdited, strListOfBadgeFields)

                    End If ''End of "If (boolDiffering) Then"

                ElseIf (boolDifferingSoEdited) Then
                    ''
                    ''Added 12/5/2021 thomas downes
                    ''
                    Dim boolFieldIsNowRemoved As Boolean
                    boolFieldIsNowRemoved = (Not fieldConfirmedToBeEdited.IsDisplayedOnBadge)

                    If (boolFieldIsNowRemoved) Then
                        ''
                        ''Major call !! 
                        ''
                        FieldEdited_SoDeleteElementsIfNeeded(fieldConfirmedToBeEdited, strListOfBadgeFields)

                    End If ''End of "If (boolFieldIsNowRemoved) Then"

                End If ''End of "If (each_field.IsDisplayedOnBadge) Then"

            Next each_field_possiblyEdited

            ''
            ''Exiting....
            ''
            ''TextDisplay
            ''System.IO.Path.Combine(

            pstrListOfFields = strListOfBadgeFields
            If (False) Then DiskFilesVB.DisplayStringDataInNotepad(strListOfBadgeFields)

        End Sub ''End of "Public Sub CheckEditedFieldsHaveElementsIfNeeded()"



        Private Sub FieldIsNowDisplayed_SoBuildElementIfNeeded(par_fieldToDisplay As ClassFieldCustomized,
                                                               ByRef par_strListOfFields As String)
            ''
            ''Added 12/4/2021 
            ''
            Dim elementForField As ClassElementFieldV3

            ''Find the element.
            ''
            ''---each_element = Me.ElementsCache_Edits.GetElementByField(each_field)
            elementForField = mod_cacheEdits.GetElementByField(par_fieldToDisplay)

            If (elementForField Is Nothing) Then
                ''
                ''No element exists to be a wrapper for the field. 
                ''
                par_strListOfFields &= ("   No wrapper element exists." & vbCrLf)

            Else
                ''The element exists.  
                Dim why_omitV1 As New WhyOmitted_StructV1
                Dim why_omitV2 As New WhyOmitted_StructV2 ''Added 1/24/2022 td
                Dim boolElemDisplayedOnBadge As Boolean

                elementForField.Visible = par_fieldToDisplay.IsDisplayedOnBadge

                ''Jan24 2022 td''boolElemDisplayedOnBadge = elementForField.IsDisplayedOnBadge_Visibly(why_omitV1)
                boolElemDisplayedOnBadge = elementForField.IsDisplayedOnBadge_Visibly(why_omitV1, why_omitV2)

                par_strListOfFields &= ("   Good, a wrapper element exists: " & elementForField.FieldNm_CaptionText() &
                        "  Is it displayed on the badge? " &
                        boolElemDisplayedOnBadge.ToString() & vbCrLf &
                        String.Format("  Pixels Top & Left: {0}, {1} ",
                        elementForField.TopEdge_Pixels, elementForField.LeftEdge_Pixels) & vbCrLf)

            End If ''End of "If (each_element Is Nothing) Then .... Else ...."

            ''
            ''Exiting...
            ''
            par_strListOfFields &= vbCrLf


        End Sub ''End of "Public Sub FieldsEditedSoBuildElementsIfNeeded()"


        Public Sub FieldEdited_SoDeleteElementsIfNeeded(par_fieldToDisplay As ClassFieldCustomized,
                                                               ByRef par_strListOfFields As String)
            ''
            ''Added 12/4/2021 
            ''





        End Sub ''End of "Public Sub FieldsEditedSoBuildElementsIfNeeded()"


        Public Sub OutputToTextFile_CustomFields(par_listOfFields As HashSet(Of ClassFieldCustomized),
                                                 Optional pstrHeading As String = "")
            ''
            ''Added 12/6/2021 thomas downes
            ''
            Dim each_field As ClassFieldAny
            Dim strListOfBadgeFields As String

            strListOfBadgeFields = "List of Custom Fields - " & pstrHeading & vbCrLf_Deux
            strListOfBadgeFields &= "    Time: " & DateTime.Now.ToString("HH:mm:ss")

            For Each each_field In par_listOfFields
                ''
                ''
                ''List the main field values. 
                ''
                ''
                With each_field
                    strListOfBadgeFields += (vbCrLf & .CIBadgeField & vbCrLf &
                        .FieldLabelCaption & vbCrLf &
                    "     Is the field relevant to the Personality? " & .IsRelevantToPersonality.ToString() & vbCrLf &
                    "     Is the field-value to be displayed on the badge? " & .IsDisplayedOnBadge.ToString() & vbCrLf)
                End With

            Next each_field

            ''
            ''Exiting....
            ''
            DiskFilesVB.DisplayStringDataInNotepad(strListOfBadgeFields)




        End Sub ''End of " Public Sub OutputToTextFile_CustomFields"


        Public Function LoadBothCachesUsingSamePathToXML(Optional par_strPathToXml As String = "") As ClassElementsCache_Deprecated
            ''Dec14 2021''(par_strPathToXml As String,
            ''Dec14 2021''     Optional ByRef pboolFailed As Boolean = False)
            ''
            ''Encapsulated 11/30/2021
            ''
            Dim objDeserial As New ciBadgeSerialize.ClassDeserial
            Dim bConfirmFileExists As Boolean
            ''11/30/2021 td''Dim objCache As ClassDesignerListenToMover_Deprecated
            Dim objCache_FromXml_1 As ClassElementsCache_Deprecated
            Dim objCache_FromXml_2 As ClassElementsCache_Deprecated

            With objDeserial

                ''12/14/2021 td''.PathToXML = par_strPathToXml ''OpenFileDialog1.FileName
                If (par_strPathToXml = "" And Me.CacheForEditing IsNot Nothing) Then ''Added 12/14/2021 td
                    ''We have confirmed that we need (& can probably rely on) the object Me.CacheForEditing 
                    ''  to know the right path. ---12/14/2021 
                    .PathToXML = mod_cacheEdits.PathToXml_Saved
                ElseIf (par_strPathToXml = "") Then
                    ''Used the "Saved" version of the cache. 
                    .PathToXML = mod_cacheSaved.PathToXml_Saved
                Else
                    .PathToXML = par_strPathToXml ''Added 12/14/2021 td 
                End If

                ''Added 11/24/2021 
                bConfirmFileExists = System.IO.File.Exists(.PathToXML)
                If (Not bConfirmFileExists) Then
                    ''pboolFailed = True
                    ''Return
                    ''6/2022 Throw New IO.FileNotFoundException("Unable to locate the XML file.")
                    ''Added 6/2022
                    MessageBoxTD.Show_Statement("Unable to locate the XML file." & vbCrLf_Deux &
                                                .PathToXML)
                    Return Nothing
                End If ''ENd of "If (Not bConfirmFileExists) Then"

                ''9/30 td''objCache =
                ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

                objCache_FromXml_1 =
            CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

                objCache_FromXml_2 =
            CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False), ClassElementsCache_Deprecated)

            End With ''End of "With objDeserial"

            ''
            ''Major call !!  
            ''
            ''++/++Does nothing. 11/30/2021 td
            ''++Form__Main_PreDemo.OpenElementsCache(objCache)

            ''Added 11/30/2021 thomas d. 
            Me.mod_cacheEdits = objCache_FromXml_1
            Me.mod_cacheSaved = objCache_FromXml_2

            ''Added 11/30/2021 thomas d. 
            Me.mod_cacheEdits.Check_LinkElementsToFields()
            Me.mod_cacheSaved.Check_LinkElementsToFields()

            ''Added 12/14/2021 thomas d. 
            Me.mod_cacheEdits.PathToXml_Opened = objDeserial.PathToXML
            Me.mod_cacheSaved.PathToXml_Opened = objDeserial.PathToXML

            Return mod_cacheEdits

        End Function ''End of "Public Function LoadBothCachesUsingSamePathToXML"


        Private Function GetLoadedCacheUsingPathToXML(pstrPathToCacheFileXML As String) As ClassElementsCache_Deprecated
            ''
            ''Encapsulated 12/14/2021
            ''
            Dim objDeserial As New ciBadgeSerialize.ClassDeserial
            Dim bConfirmFileExists As Boolean
            Dim objCache_FromXml As ClassElementsCache_Deprecated

            With objDeserial

                ''Added 12/21/2021 td
                .PathToXML = pstrPathToCacheFileXML ''Added 12/21/2021 td

                ''12/14/2021 td''.PathToXML = par_strPathToXml ''OpenFileDialog1.FileName
                ''12/21/2021 td''.PathToXML = Me.CacheForEditing.PathToXml_Saved
                If (.PathToXML = "") Then .PathToXML = Me.CacheForEditing.PathToXml_Saved

                ''Added 11/24/2021 
                bConfirmFileExists = System.IO.File.Exists(.PathToXML)
                If (Not bConfirmFileExists) Then
                    ''pboolFailed = True
                    ''Return
                    ''6/18/2022 Throw New IO.FileNotFoundException("Unable to locate the XML file.")
                    ''Added 6/18/2022
                    MessageBoxTD.Show_Statement("Unable to locate the XML file." & vbCrLf_Deux &
                                                .PathToXML)
                    Return Nothing

                End If ''ENd of "If (Not bConfirmFileExists) Then"

                ''9/30 td''objCache =
                ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

                ClassElementsCache_Deprecated.DeserializationCompleted = False ''False/Prepare. --5/10/2022

                objCache_FromXml = CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False),
                                            ClassElementsCache_Deprecated)

                ClassElementsCache_Deprecated.DeserializationCompleted = True ''True/Completed. --5/10/2022

                ''Added 12/14/2021 td
                objCache_FromXml.Check_LinkElementsToFields()

                Return objCache_FromXml

            End With ''End of "With objDeserial"

        End Function ''End of "Public Function LoadBothCachesUsingSamePathToXML"



        Public Sub LoadPic_InitialDefault(par_imageExamplePortrait As System.Drawing.Image)
            ''
            ''Added 12/14/2021 td 
            ''
            mod_cacheEdits.Pic_InitialDefault = par_imageExamplePortrait
            mod_cacheSaved.Pic_InitialDefault = par_imageExamplePortrait

        End Sub ''End of "Public Sub LoadPic_InitialDefault"


        Public Sub DeleteElementFromCache_Pic(par_infoPortrait As IElementPic,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/05/2022 thomas d. 
            ''
            Dim objElementPortraitPic As ClassElementPortrait
            Dim b1 As Boolean ''Added 5/05/2022 thomas d.
            Dim b2 As Boolean ''Added 5/05/2022 thomas d.
            Dim b3 As Boolean ''Added 5/05/2022 thomas d.
            Dim b4 As Boolean ''Added 5/05/2022 thomas d.
            Dim b5 As Boolean ''Added 5/05/2022 thomas d.
            Dim b6 As Boolean ''Added 5/05/2022 thomas d.

            objElementPortraitPic = GetElement_FromInfo_Pic(par_infoPortrait)

            If (Not par_bLetsSpecifySide) Then
                ''
                ''Execute "Remove" on both sides of the badge.  A "False" is returned if
                ''   the item is not located within the list. ---5/5/2022
                ''
                ''not possible''b1 = Me.mod_cacheEdits.ListOfElementPics_Front.Remove(par_infoPortrait)
                ''not possible''b2 = Me.mod_cacheEdits.ListOfElementPics_Back.Remove(par_infoPortrait)
                b3 = Me.mod_cacheEdits.ListOfElementPics_Front.Remove(objElementPortraitPic)
                b4 = Me.mod_cacheEdits.ListOfElementPics_Back.Remove(objElementPortraitPic)

            ElseIf (par_bSideIsBackside) Then
                b5 = Me.mod_cacheEdits.ListOfElementPics_Back.Remove(objElementPortraitPic)
            Else
                b6 = Me.mod_cacheEdits.ListOfElementPics_Front.Remove(objElementPortraitPic)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4 Or b5 Or b6)

        End Sub ''end of ""Public Sub DeleteElementFromCache_Pic""


        Public Sub DeleteElementFromCache_QR(par_infoQRCode As IElementQRCode,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/05/2022 thomas d. 
            ''
            Dim objElementQRCode As ClassElementQRCode
            Dim b1 As Boolean ''Added 5/16/2022 thomas d.
            Dim b2 As Boolean ''Added 5/16/2022 thomas d.
            Dim b3 As Boolean ''Added 5/16/2022 thomas d.
            Dim b4 As Boolean ''Added 5/16/2022 thomas d.

            objElementQRCode = GetElement_FromInfo_QRCode(par_infoQRCode)

            If (Not par_bLetsSpecifySide) Then
                ''
                ''Execute "Remove" on both sides of the badge.
                ''
                b1 = Me.mod_cacheEdits.ListOfElementQRCodes_Front.Remove(objElementQRCode)
                b2 = Me.mod_cacheEdits.ListOfElementQRCodes_Back.Remove(objElementQRCode)

            ElseIf (par_bSideIsBackside) Then
                b3 = Me.mod_cacheEdits.ListOfElementQRCodes_Back.Remove(objElementQRCode)
            Else
                b4 = Me.mod_cacheEdits.ListOfElementQRCodes_Front.Remove(objElementQRCode)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4)

        End Sub ''end of ""Public Sub DeleteElementFromCache_QR""


        Public Sub DeleteElementFromCache_Sig(par_infoSig As IElementSig,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/05/2022 thomas d. 
            ''
            ''  Sig = Signature
            ''
            Dim objElementSig As ClassElementSignature
            Dim b1 As Boolean ''Added 5/16/2022 thomas d.
            Dim b2 As Boolean ''Added 5/16/2022 thomas d.
            Dim b3 As Boolean ''Added 5/16/2022 thomas d.
            Dim b4 As Boolean ''Added 5/16/2022 thomas d.

            objElementSig = GetElement_FromInfo_Sig(par_infoSig)

            If (Not par_bLetsSpecifySide) Then
                ''Execute "Remove" on both sides of the badge.
                b1 = Me.mod_cacheEdits.ListOfElementSignatures_Front.Remove(objElementSig)
                b2 = Me.mod_cacheEdits.ListOfElementSignatures_Back.Remove(objElementSig)

            ElseIf (par_bSideIsBackside) Then
                b3 = Me.mod_cacheEdits.ListOfElementSignatures_Back.Remove(objElementSig)
            Else
                b4 = Me.mod_cacheEdits.ListOfElementSignatures_Front.Remove(objElementSig)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4)

        End Sub ''end of ""Public Sub DeleteElementFromCache_Sig""


        Public Sub DeleteElementFromCache_Graphic(par_infoGraphic As IElementGraphic,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/15/2022 thomas d. 
            ''
            ''  Graphic = Static Graphic
            ''
            Dim objElementGraphic As ClassElementGraphic
            Dim b1 As Boolean ''Added 5/16/2022 thomas d.
            Dim b2 As Boolean ''Added 5/16/2022 thomas d.
            Dim b3 As Boolean ''Added 5/16/2022 thomas d.
            Dim b4 As Boolean ''Added 5/16/2022 thomas d.

            objElementGraphic = GetElement_FromInfo_Graphic(par_infoGraphic)

            If (Not par_bLetsSpecifySide) Then
                ''Execute "Remove" on both sides of the badge.
                b1 = Me.mod_cacheEdits.ListOfElementGraphics_Front.Remove(objElementGraphic)
                b2 = Me.mod_cacheEdits.ListOfElementGraphics_Backside.Remove(objElementGraphic)

            ElseIf (par_bSideIsBackside) Then
                b3 = Me.mod_cacheEdits.ListOfElementGraphics_Backside.Remove(objElementGraphic)
            Else
                b4 = Me.mod_cacheEdits.ListOfElementGraphics_Front.Remove(objElementGraphic)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4)

        End Sub ''end of ""Public Sub DeleteElementFromCache_Graphic""


        Public Sub DeleteElementFromCache_StaticTextV3(par_infoTextOnly As IElement_TextOnly,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/16/2022 thomas d. 
            ''
            ''  Text = Static Text
            ''
            Dim objElementV3 As ClassElementStaticTextV3
            Dim b1 As Boolean ''Added 5/16/2022 thomas d.
            Dim b2 As Boolean ''Added 5/16/2022 thomas d.
            Dim b3 As Boolean ''Added 5/16/2022 thomas d.
            Dim b4 As Boolean ''Added 5/16/2022 thomas d.

            objElementV3 = GetElement_FromInfo_TextOnlyV3(par_infoTextOnly)

            If (Not par_bLetsSpecifySide) Then
                ''Execute "Remove" on both sides of the badge.
                b1 = Me.mod_cacheEdits.ListOfElementTextsV3_Front.Remove(objElementV3)
                b2 = Me.mod_cacheEdits.ListOfElementTextsV3_Backside.Remove(objElementV3)

            ElseIf (par_bSideIsBackside) Then
                b3 = Me.mod_cacheEdits.ListOfElementTextsV3_Backside.Remove(objElementV3)
            Else
                b4 = Me.mod_cacheEdits.ListOfElementTextsV3_Front.Remove(objElementV3)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4)

        End Sub ''end of ""Public Sub DeleteElementFromCache_StaticTextV3""


        Public Sub DeleteElementFromCache_StaticTextV4(par_infoTextOnly As IElement_TextOnly,
                                              par_bLetsSpecifySide As Boolean,
                                              par_bSideIsBackside As Boolean,
                                              ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 5/16/2022 thomas d. 
            ''
            ''  Text = Static Text
            ''
            Dim objElementV4 As ClassElementStaticTextV4
            Dim b1 As Boolean ''Added 5/16/2022 thomas d.
            Dim b2 As Boolean ''Added 5/16/2022 thomas d.
            Dim b3 As Boolean ''Added 5/16/2022 thomas d.
            Dim b4 As Boolean ''Added 5/16/2022 thomas d.

            objElementV4 = GetElement_FromInfo_TextOnlyV4(par_infoTextOnly)

            If (Not par_bLetsSpecifySide) Then
                ''Execute "Remove" on both sides of the badge.
                b1 = Me.mod_cacheEdits.ListOfElementTextsV4_Front.Remove(objElementV4)
                b2 = Me.mod_cacheEdits.ListOfElementTextsV4_Backside.Remove(objElementV4)

            ElseIf (par_bSideIsBackside) Then
                b3 = Me.mod_cacheEdits.ListOfElementTextsV4_Backside.Remove(objElementV4)
            Else
                b4 = Me.mod_cacheEdits.ListOfElementTextsV4_Front.Remove(objElementV4)

            End If ''end of ""If (Not par_bLetsSpecifySide) Then... ElseIf... Else..."

ExitHandler:
            ''Add 5/6/2022 td
            pref_boolSuccess = (b1 Or b2 Or b3 Or b4)

        End Sub ''end of ""Public Sub DeleteElementFromCache_StaticTextV4""


        Public Sub DeleteElementFromCache(par_infoBase As ciBadgeInterfaces.IElement_Base,
                                  par_enum As ciBadgeInterfaces.Enum_ElementType,
                                ByRef pref_boolSuccess As Boolean)
            ''
            ''Added 1/19/2022 thomas d. 
            ''
            Dim objClassLists As ClassListOfElementsShared
            ''Dim boolSuccess As Boolean ''Addded 1/21/2022 td
            Dim bUseOlderVersionOfField As Boolean ''Added 5/16/2022 

            ClassListOfElementsShared.Initialize_IfNeeded(Me.CacheForEditing)
            ''5/16/2022 td''objClassLists = ClassListOfElements.GetListOfElements(par_enum)

            ''Use Older Version (e.g. V3 (e.g. ClassList_FieldsV3)) 
            bUseOlderVersionOfField = True ''Added 5/16/2022
            objClassLists = ClassListOfElementsShared.GetListOfElements(par_enum, bUseOlderVersionOfField)
            objClassLists.RemoveElement(par_infoBase, pref_boolSuccess)

            ''Use newer, less-old Version (e.g. V4 (e.g. ClassList_FieldsV4)) 
            bUseOlderVersionOfField = False ''Added 5/16/2022
            objClassLists = ClassListOfElementsShared.GetListOfElements(par_enum, bUseOlderVersionOfField)
            objClassLists.RemoveElement(par_infoBase, pref_boolSuccess)

            ''
            ''Added 2/3/2022 td
            ''
            If (pref_boolSuccess) Then
                ''
                ''Great!  
                ''
            Else
                ''
                ''The element is orphaned, and/or misplaced. ---2/3/2022 td
                ''
                ClassListOfElementsShared.RemoveOrphanedElement(par_infoBase, pref_boolSuccess)

            End If ''End of "If (pref_boolSuccess) Then ... Else...."

        End Sub ''End of "Public Sub DeleteElementFromCache"


        Private Function GetElement_FromInfo_Pic(par_infoPic As IElementPic) As ClassElementPortrait
            ''
            ''Added 5/6/2022 td
            ''
            Dim boolMatch As Boolean

            ''Search the frontside.
            For Each each_elem As ClassElementPortrait In Me.mod_cacheEdits.ListOfElementPics_Front
                boolMatch = (par_infoPic Is CType(each_elem, IElementPic))
                If (boolMatch) Then Return each_elem
            Next each_elem

            ''Search the backside.
            For Each each_elem As ClassElementPortrait In Me.mod_cacheEdits.ListOfElementPics_Back
                boolMatch = (par_infoPic Is CType(each_elem, IElementPic))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing
        End Function ''end of "Private Function GetElement_FromInfo_Pic" 


        Private Function GetElement_FromInfo_QRCode(par_infoQR As IElementQRCode) As ClassElementQRCode
            ''
            ''Added 5/6/2022 td
            ''
            Dim boolMatch As Boolean

            ''Search the frontside.
            For Each each_elem As ClassElementQRCode In Me.mod_cacheEdits.ListOfElementQRCodes_Front
                boolMatch = (par_infoQR Is CType(each_elem, IElementQRCode))
                If (boolMatch) Then Return each_elem
            Next each_elem

            ''Search the backside.
            For Each each_elem As ClassElementQRCode In Me.mod_cacheEdits.ListOfElementQRCodes_Back
                boolMatch = (par_infoQR Is CType(each_elem, IElementQRCode))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing
        End Function ''end of "Private Function GetElement_FromInfo_QRCode" 


        Private Function GetElement_FromInfo_Sig(par_infoSig As IElementSig) As ClassElementSignature
            ''
            ''Added 5/6/2022 td
            ''
            Dim boolMatch As Boolean

            For Each each_elem As ClassElementSignature In Me.mod_cacheEdits.ListOfElementSignatures_Front
                boolMatch = (par_infoSig Is CType(each_elem, IElementSig))
                If (boolMatch) Then Return each_elem
            Next each_elem

            For Each each_elem As ClassElementSignature In Me.mod_cacheEdits.ListOfElementSignatures_Back
                boolMatch = (par_infoSig Is CType(each_elem, IElementSig))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing
        End Function ''end of "Private Function GetElement_FromInfo_Sig"" 


        Private Function GetElement_FromInfo_Graphic(par_info As IElementGraphic) As ClassElementGraphic
            ''
            ''Added 5/16/2022 td
            ''
            Dim boolMatch As Boolean

            For Each each_elem As ClassElementGraphic In Me.mod_cacheEdits.ListOfElementGraphics_Front
                boolMatch = (par_info Is CType(each_elem, IElementGraphic))
                If (boolMatch) Then Return each_elem
            Next each_elem

            For Each each_elem As ClassElementGraphic In Me.mod_cacheEdits.ListOfElementGraphics_Backside
                boolMatch = (par_info Is CType(each_elem, IElementGraphic))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing

        End Function ''end of "Private Function GetElement_FromInfo_Graphic"" 


        Private Function GetElement_FromInfo_TextOnlyV3(par_info As IElement_TextOnly) As ClassElementStaticTextV3
            ''
            ''Added 5/16/2022 td
            ''
            Dim boolMatch As Boolean

            For Each each_elem As ClassElementStaticTextV3 In Me.mod_cacheEdits.ListOfElementTextsV3_Front
                boolMatch = (par_info Is CType(each_elem, IElement_TextOnly))
                If (boolMatch) Then Return each_elem
            Next each_elem

            For Each each_elem As ClassElementStaticTextV3 In Me.mod_cacheEdits.ListOfElementTextsV3_Backside
                boolMatch = (par_info Is CType(each_elem, IElement_TextOnly))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing

        End Function ''end of "Private Function GetElement_FromInfo_TextOnlyV3"" 


        Private Function GetElement_FromInfo_TextOnlyV4(par_info As IElement_TextOnly) As ClassElementStaticTextV4
            ''
            ''Added 5/16/2022 td
            ''
            Dim boolMatch As Boolean

            For Each each_elem As ClassElementStaticTextV4 In Me.mod_cacheEdits.ListOfElementTextsV4_Front
                boolMatch = (par_info Is CType(each_elem, IElement_TextOnly))
                If (boolMatch) Then Return each_elem
            Next each_elem

            For Each each_elem As ClassElementStaticTextV4 In Me.mod_cacheEdits.ListOfElementTextsV4_Backside
                boolMatch = (par_info Is CType(each_elem, IElement_TextOnly))
                If (boolMatch) Then Return each_elem
            Next each_elem

            Return Nothing

        End Function ''end of "Private Function GetElement_FromInfo_TextOnlyV4"" 


        Public Sub SwitchElementToOtherSideOfCard(par_infoBase As ciBadgeInterfaces.IElement_Base,
                                  par_enum As ciBadgeInterfaces.Enum_ElementType,
                                  Optional ByRef pref_bSuccess As Boolean = False)
            ''
            ''Added 1/17/2022 thomas d. 
            ''
            Dim objClassLists As ClassListOfElementsShared
            ClassListOfElementsShared.Initialize_IfNeeded(Me.CacheForEditing)
            objClassLists = ClassListOfElementsShared.GetListOfElements(par_enum)
            objClassLists.SwitchElementToOtherSideOfCard(par_infoBase, pref_bSuccess)

            ''Added 2/5/2022 td
            If (Not pref_bSuccess) Then
                ''
                ''Try another way. 
                ''
                ClassListOfElementsShared.SwitchOrphanedElement(par_infoBase, pref_bSuccess)

            End If ''End of "If (Not pref_bSuccess) Then"

        End Sub ''End of "Public Sub SwitchElementToOtherSideOfCard"


        Public Sub SwitchElementToOtherSideOfCard_Deprecated(par_infoBase As ciBadgeInterfaces.IElement_Base)
            ''
            ''Added 1/17/2022 thomas d. 
            ''
            Dim boolMatch As Boolean
            Dim each_infoBase As IElement_Base

            ''
            ''Fields
            ''
            For Each each_element In CacheForEditing.ListOfElementFields_FrontV3()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementFields_FrontV3.Remove(each_element)
                    CacheForEditing.ListOfElementFields_BacksideV3.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementFields_BacksideV3()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementFields_BacksideV3.Remove(each_element)
                    CacheForEditing.ListOfElementFields_FrontV3.Add(each_element)
                    Exit Sub
                End If
            Next each_element

            ''
            ''Portraits  
            ''
            For Each each_element In CacheForEditing.ListOfElementPics_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementPics_Front.Remove(each_element)
                    CacheForEditing.ListOfElementPics_Back.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementPics_Back()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementPics_Back.Remove(each_element)
                    CacheForEditing.ListOfElementPics_Front.Add(each_element)
                    Exit Sub
                End If
            Next each_element

            ''
            ''QR Codes 
            ''
            For Each each_element In CacheForEditing.ListOfElementQRCodes_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementQRCodes_Front.Remove(each_element)
                    CacheForEditing.ListOfElementQRCodes_Back.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementQRCodes_Back()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementQRCodes_Back.Remove(each_element)
                    CacheForEditing.ListOfElementQRCodes_Front.Add(each_element)
                    Exit Sub
                End If
            Next each_element

            ''
            ''Signatures
            ''
            For Each each_element In CacheForEditing.ListOfElementSignatures_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementSignatures_Front.Remove(each_element)
                    CacheForEditing.ListOfElementSignatures_Back.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementSignatures_Back()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementSignatures_Back.Remove(each_element)
                    CacheForEditing.ListOfElementSignatures_Front.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumBackside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumBackside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            ''
            ''StaticTexts
            ''
            For Each each_element In CacheForEditing.ListOfElementTextsV3_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementTextsV3_Front.Remove(each_element)
                    CacheForEditing.ListOfElementTextsV3_Backside.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementTextsV3_Backside()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementTextsV3_Backside.Remove(each_element)
                    CacheForEditing.ListOfElementTextsV3_Front.Add(each_element)
                    Exit Sub
                End If
            Next each_element

            ''
            ''StaticGraphics
            ''
            For Each each_element In CacheForEditing.ListOfElementGraphics_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementGraphics_Front.Remove(each_element)
                    CacheForEditing.ListOfElementGraphics_Backside.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementGraphics_Backside()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementGraphics_Backside.Remove(each_element)
                    CacheForEditing.ListOfElementGraphics_Front.Add(each_element)
                    Exit Sub
                End If
            Next each_element





        End Sub ''End of "Public Sub SwitchElementToOtherSideOfCard"


        Public Sub AddCacheByType(par_enumCacheType As EnumCacheType, par_infoCache As InterfaceCacheToXML)
            ''
            ''Added 7/4/2022 thomas downes  
            ''
            If (ListOfCachesByType Is Nothing) Then
                ListOfCachesByType = New Dictionary(Of EnumCacheType, InterfaceCacheToXML)
            End If ''End of ""If (ListOfCachesByType Is Nothing) Then""

            With ListOfCachesByType
                .Add(par_enumCacheType, par_infoCache)
            End With

        End Sub ''End of ""Public Sub AddCacheByType""


        Public Sub SaveCachesAllTypes(pstrPathToFolder As String, pboolAddTimestamp As Boolean)
            ''
            ''Added 7/4/2022 thomas downes  
            ''
            Dim enumCT As EnumCacheType
            Dim strFinalPathToXML As String = ""

            If (ListOfCachesByType Is Nothing) Then
                ListOfCachesByType = New Dictionary(Of EnumCacheType, InterfaceCacheToXML)
            End If ''End of ""If (ListOfCachesByType Is Nothing) Then""

            With ListOfCachesByType

                strFinalPathToXML = "" ''Refresh.
                enumCT = EnumCacheType.FieldsElementsLayout
                .Item(enumCT)?.SaveToXML_CommonPrefix("Cache_", "Layout", pstrPathToFolder, pboolAddTimestamp)
                PathsToCachesByType.PathToCache_ElementsLayout = strFinalPathToXML

                strFinalPathToXML = "" ''Refresh.
                enumCT = EnumCacheType.SpreadsheetData
                .Item(enumCT)?.SaveToXML_CommonPrefix("Cache_", "SheetData", pstrPathToFolder, pboolAddTimestamp)
                PathsToCachesByType.PathToCache_SpreadsheetData = strFinalPathToXML

                strFinalPathToXML = "" ''Refresh.
                enumCT = EnumCacheType.PersonalityRecipients
                .Item(enumCT)?.SaveToXML_CommonPrefix("Cache_", "PRecips", pstrPathToFolder, pboolAddTimestamp)
                PathsToCachesByType.PathToCache_PersonalityRecips = strFinalPathToXML

            End With

            ''Added 7/4/2022 td
            SaveToXML_PathsToCaches()

        End Sub ''End of ""Public Sub SaveCachesAllTypes""


        Public Sub SaveToMainCache_PathsToCaches()
            ''
            ''Added 7/6/2022 thomas downes 
            ''
            ''Copy the cache paths (filepaths) from this management class
            ''   to the main layout (elements) cache (ClassElementsCache_Deprecated).
            ''
            Dim objMainLayoutCache As ClassElementsCache_Deprecated

            objMainLayoutCache = CType(Me.ListOfCachesByType.Item(EnumCacheType.FieldsElementsLayout),
                ClassElementsCache_Deprecated)

            objMainLayoutCache.PathsToCachesByType = Me.PathsToCachesByType

        End Sub ''End of ""Public Sub SaveToMainCache_PathsToCaches()"" 


        Public Sub SaveToXML_PathsToCaches()
            ''
            ''Added 7/4/2022 thomas downes
            ''
            Dim objSerializationClass As New ciBadgeSerialize.ClassSerial
            Dim strPathToFolderXML As String
            Dim strPathToFileXML As String
            Dim strFiletitleXML As String
            Dim typeRelevantType As Type

            strPathToFolderXML = DiskFolders.PathToFolder_XML
            strFiletitleXML = "CachePaths_Three.xml"
            strPathToFileXML = IO.Path.Combine(strPathToFolderXML, strFiletitleXML)

            With objSerializationClass

                .PathToXML = strPathToFileXML

                typeRelevantType = Me.PathsToCachesByType.GetType

                Const c_boolAutoOpenByIE As Boolean = False ''Added 4/22/2020 thomas d.
                ''//
                ''// If the 2nd Boolean Is True, the following command
                ''//         System.Diagnostics.Process.Start(Me.PathToXML)
                ''//  will be used to open the file in Notepad.
                ''//     ---4/22/2020 thomas downes
                ''//
                .SerializeToXML(PathsToCachesByType.GetType, Me.PathsToCachesByType,
                                False, c_boolAutoOpenByIE)

            End With

        End Sub ''End of ""Public Sub SaveToXML_PathsToCaches()""




    End Class ''End of "Public Class ClassCacheManagement"

End Namespace