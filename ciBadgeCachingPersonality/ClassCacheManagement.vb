Option Strict On
Option Explicit On

Imports ciBadgeElements ''Added 12/5/2021 
Imports ciBadgeFields ''Added 12/5/2021  

Namespace ciBadgeCachePersonality
    ''
    ''Added 12/4/2021 thomas downes 
    ''
    Public Class ClassCacheManagement
        ''
        ''Added 12/4/2021 thomas downes 
        ''
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


        End Sub ''End of " Public Sub New"


        Public Sub New(par_edits As ClassElementsCache_Deprecated, par_saved As ClassElementsCache_Deprecated)
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            mod_cacheEdits = par_edits
            mod_cacheSaved = par_saved

        End Sub ''End of "Public Sub New"


        Public Sub Save()
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            mod_cacheEdits.SaveToXML()

            ''Added 12/6/2021 td  
            ''----Dec.6 2021 ----mod_cacheSaved = mod_cacheEdits
            mod_cacheSaved = mod_cacheEdits.Copy()

        End Sub


        Public Sub UndoEdits()
            ''
            ''Added 12/4/2021 thomas downes  
            ''
            mod_cacheEdits = mod_cacheSaved.Copy

        End Sub ''End of "Public Sub UndoEdits()"


        Public Sub CheckForOrphanedElements()
            ''
            ''Added 12/4/2021 thomas downes  
            ''



        End Sub ''End of "Public Sub CheckForOrphanedElements()"


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
            mod_cacheEdits.LinkElementsToFields()

        End Sub ''End of "Public Sub LinkElementsToFields()"


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






    End Class

End Namespace