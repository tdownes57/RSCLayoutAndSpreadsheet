Option Strict On
Option Explicit On

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

        Public ReadOnly Property Cache() As ClassElementsCache_Deprecated
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


        Public Sub FieldsEdited_SoBuildElementsIfNeeded()
            ''
            ''Added 12/4/2021 
            ''


        End Sub ''End of "Public Sub FieldsEditedSoBuildElementsIfNeeded()"

        Public Sub FieldsEdited_SoDeleteElementsIfNeeded()
            ''
            ''Added 12/4/2021 
            ''



        End Sub ''End of "Public Sub FieldsEditedSoBuildElementsIfNeeded()"




    End Class

End Namespace