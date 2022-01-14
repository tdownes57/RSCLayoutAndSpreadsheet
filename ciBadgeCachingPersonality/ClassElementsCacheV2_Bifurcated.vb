''-----Public Class ClassElementsCache_Bifurcated
Option Explicit On
Option Strict On
Option Infer Off
''
''Added 1/13/2022 thomas downes
''
Imports System.Drawing ''Added 9/18/2019 td
Imports System.Windows.Forms ''Added 9/18/2019 td
Imports ciBadgeInterfaces ''Added 9/16/2019 td 
Imports ciBadgeFields ''Added 9/18/2019 td
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d. 
Imports ciBadgeElements ''Added 12/4/2021 thomas downes  

Namespace ciBadgeCachePersonality

    <Serializable>
    Public Class ClassElementsCache2_Bifurcated
        ''
        ''Added 1/13/2022 thomas downes
        ''
        Public Property Id_GUID As System.Guid
        Public Property Id_GUID6 As String
        Public Property Id_GUID6_CopiedFrom As String

        Public Property PathToXml_Saved As String
        Public Property PathToXml_Opened As String
        Public Property PathToXml_Binary As String

        Public Property Personality As ClassPersonalityConfig

        Public Property BadgeLayout As ciBadgeInterfaces.BadgeLayoutClass

        <Xml.Serialization.XmlIgnore>
        Public Property Pic_InitialDefault As Image

        Public Property DateAndTimeUpdated As DateTime

        Public Property BadgeHasTwoSidesOfCard As Boolean

        Private mod_listFields_Standard As New HashSet(Of ClassFieldStandard) ''Added 10/14/2019 td  
        Private mod_listFields_Custom As New HashSet(Of ClassFieldCustomized) ''Added 10/14/2019 td  

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


        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated). 
        ''
        ''This list will have 1 or 2 items, representing the Front & possible Backside
        ''  of the ID Card Badge.   ----1/13/2022 td
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Private mod_listBadgeSideLayoutV2s As New HashSet(Of ClassBadgeSideLayoutV2)

        ''
        ''Added 1/13/2022 Thomas Downes
        ''
        ''  Here is the sole reason for this new Cache (ClassElementsCacheV2_Bifurcated).  I feel
        ''    that this List of BadgeSideLayoutV2, having one or two items (one or two sides 
        ''    of the badge), can greatly simplify the cache (ClassElementsCacheV1_Deprectated).
        ''       ----1/13/2022 td
        ''
        Public Property ListOfBadgeSideLayoutV2s As HashSet(Of ClassBadgeSideLayoutV2)
            ''
            ''This list will have 1 or 2 items, representing the Front & possible Backside
            ''  of the ID Card Badge.   ----1/13/2022 td
            ''
            Get
                ''Added 1/13/2022 td
                Return mod_listBadgeSideLayoutV2s
            End Get
            Set(value As HashSet(Of ClassBadgeSideLayoutV2))
                ''Added 1/13/2022 td
                mod_listBadgeSideLayoutV2s = value
            End Set
        End Property


    End Class

End Namespace