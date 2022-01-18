Option Strict On
Option Explicit On

Imports ciBadgeElements ''Added 12/5/2021 
Imports ciBadgeFields ''Added 12/5/2021  
Imports ciBadgeInterfaces ''Added 1/17/2022  

Namespace ciBadgeCachePersonality
    ''
    ''Added 12/4/2021 thomas downes 
    ''
    Public Class ClassCacheManagement
        ''
        ''Added 12/4/2021 thomas downes 
        ''
        Public Shared LatestCacheOfEdits_Guid6 As String = "" ''This is a 6-character GUID. ---12/12/2021 td

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
                       Optional pstrPathToSavedFileXML As String = "")
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
            ElseIf (pstrPathToSavedFileXML <> "") Then

                ''Added 12/14/2021 td
                ''Dec14 2021''LoadSavedCacheUsingPathToXML(pstrPathToSavedFileXML)
                mod_cacheSaved = GetLoadedCacheUsingPathToXML(pstrPathToSavedFileXML)

            End If ''End of " If (pboolAllowCacheToBeCopied) Then ... ElseIf ...

            ''Dec12 2021''Me.ElementsCache_Saved.Id_GUID = New Guid() ''Generates a new GUID.
            With mod_cacheSaved
                .Id_GUID = New Guid() ''Generates a new GUID. 
                .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6) ''Added 12/12/2021  
            End With ''eND OF "With mod_cacheSaved"

            ''Added 12/12/2021 
            ''Dec.12 2021''If (LatestCacheOfEdits_Guid6 = "") Then LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6
            LatestCacheOfEdits_Guid6 = mod_cacheEdits.Id_GUID6

        End Sub ''End of Public Sub New(par_cacheForEdits As ClassElementsCache_Deprecated)


        Public Function GetCacheForSaving(pboolMajorSortOfRefresh As Boolean) As ClassElementsCache_Deprecated
            ''
            ''Added 12/14/2021 
            ''
            If (Not pboolMajorSortOfRefresh) Then Throw New Exception("Don't use unless a big type of refresh is taking place.")
            Return mod_cacheSaved

        End Function


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


        Public Sub CreateBadgeLayoutImageFile(par_BadgeImage As System.Drawing.Image,
                                               par_strPathToProposedJpeg As String)
            ''
            ''Added 1/5/2022 thomas downes 
            ''
            par_BadgeImage.Save(par_strPathToProposedJpeg,
                                System.Drawing.Imaging.ImageFormat.Jpeg)

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


        Public Function CheckAllElementsHaveCorrectFieldInfo(ByRef pbAllFine As Boolean,
                                                 ByRef pstrMessage As String) As Boolean
            ''
            ''Added 11/19/2021 td 
            '' 
            Return mod_cacheEdits.CheckAllElementsHaveCorrectFieldInfo(pbAllFine, pstrMessage)

        End Function ''End of "Public Function CheckAllElementsHaveCorrectFieldInfo"


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
            Dim each_element As ciBadgeElements.ClassElementField

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
            Dim elementForField As ClassElementField

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
                Dim why_omit As New WhyOmitted
                Dim boolElemDisplayedOnBadge As Boolean

                elementForField.Visible = par_fieldToDisplay.IsDisplayedOnBadge

                boolElemDisplayedOnBadge = elementForField.IsDisplayedOnBadge_Visibly(why_omit)

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
                    Throw New IO.FileNotFoundException("Unable to locate the XML file.")
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
                    Throw New IO.FileNotFoundException("Unable to locate the XML file.")
                End If ''ENd of "If (Not bConfirmFileExists) Then"

                ''9/30 td''objCache =
                ''9/30 td''     .DeserializeFromXML(GetType(ClassElementsCache), False)

                objCache_FromXml = CType(.DeserializeFromXML(GetType(ClassElementsCache_Deprecated), False),
                                            ClassElementsCache_Deprecated)

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


        Public Sub SwitchElementToOtherSideOfCard(par_infoBase As ciBadgeInterfaces.IElement_Base)
            ''
            ''Added 1/17/2022 thomas d. 
            ''
            Dim boolMatch As Boolean
            Dim each_infoBase As IElement_Base

            ''
            ''Fields
            ''
            For Each each_element In CacheForEditing.ListOfElementFields_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementFields_Front.Remove(each_element)
                    CacheForEditing.ListOfElementFields_Backside.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementFields_Backside()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementFields_Backside.Remove(each_element)
                    CacheForEditing.ListOfElementFields_Front.Add(each_element)
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
            For Each each_element In CacheForEditing.ListOfElementTexts_Front()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementTexts_Front.Remove(each_element)
                    CacheForEditing.ListOfElementTexts_Backside.Add(each_element)
                    Exit Sub
                Else
                    If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                    If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
                End If
            Next each_element

            For Each each_element In CacheForEditing.ListOfElementTexts_Backside()
                each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
                boolMatch = (par_infoBase Is each_infoBase)
                If (boolMatch) Then
                    CacheForEditing.ListOfElementTexts_Backside.Remove(each_element)
                    CacheForEditing.ListOfElementTexts_Front.Add(each_element)
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


    End Class ''End of "Public Class ClassCacheManagement"

End Namespace