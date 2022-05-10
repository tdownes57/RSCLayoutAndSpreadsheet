Option Explicit On
Option Strict On

''9/19/2019 td''Imports ciLayoutDesignVB
Imports ciBadgeInterfaces ''Added 8/24/2019 thomas d.

''
''Added 7/26/2019 thomas downes  
''

<Serializable>
Public Class ClassFieldStandard
    Inherits ClassFieldAny ''Added 9/16/2019 thomas d.
    ''9/16/2019 td''Implements ICIBFieldStandardOrCustom ''Added 7/21/2019 td
    ''
    ''Added 7/26/2019 thomas d. 
    ''
    ''Public TextFieldId As Integer
    ''Not applicable. 7/26/2019 td''Public Property TextFieldId As Integer = 1

    ''Public Property IsStandard As Boolean = False Implements ICIBFieldStandardOrCustom.IsStandard ''Added 7/26/2019 td
    ''Public Property IsCustomizable As Boolean = False Implements ICIBFieldStandardOrCustom.IsCustomizable ''Added 7/26/2019 td

    ''''Not applicable. 7/26/2019 td''Public Property DateFieldId As Integer = 0
    ''Public Property IsDateField As Boolean = False

    ''Public Property Text_orDate As String = "Text"

    ''Public Property LabelCaption As String = ""

    ''''Redundant. See ExampleValue. ---7/26/2019 td''Public Property ExampleValueToUseInLayout As String = ""

    ''''7/21 td''Public Property CIBadgeFieldname As String ''Added 7/21/2019 Thomas DOWNES 
    ''Public Property CIBadgeField As String Implements ICIBFieldStandardOrCustom.CIBadgeField ''Added 7/21/2019 Thomas DOWNES 
    ''Public Property OtherDbField_Optional As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional ''Added 7/21/2019 Thomas DOWNES 

    ''Public Property FieldLabelCaption As String Implements ICIBFieldStandardOrCustom.FieldLabelCaption
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property FieldType_TD As Char Implements ICIBFieldStandardOrCustom.FieldType_TD
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Char)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property FieldEnumValue As EnumCIBFields Implements ICIBFieldStandardOrCustom.FieldEnumValue ''Added 9/16/2019 td 

    ''Public Property FieldIndex As Integer Implements ICIBFieldStandardOrCustom.FieldIndex
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Integer)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsFieldForDates As Boolean Implements ICIBFieldStandardOrCustom.IsFieldForDates
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsLocked As Boolean Implements ICIBFieldStandardOrCustom.IsLocked
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Added 8/23/2019 thomas d.
    ''Public Property IsDisplayedOnBadge As Boolean Implements ICIBFieldStandardOrCustom.IsDisplayedOnBadge
    ''Public Property IsDisplayedForEdits As Boolean Implements ICIBFieldStandardOrCustom.IsDisplayedForEdits

    ''Public Property ExampleValue As String Implements ICIBFieldStandardOrCustom.ExampleValue
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property HasPresetValues As Boolean Implements ICIBFieldStandardOrCustom.HasPresetValues
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Not needed here for Standard fields. ---9/16/2019 td''Public Property ArrayOfValues As String() Implements ICIBFieldStandardOrCustom.ArrayOfValues
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String())
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''''Public Property OtherDbFieldname As String Implements ICIBFieldStandardOrCustom.OtherDbField_Optional
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As String)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsAdditionalField As Boolean Implements ICIBFieldStandardOrCustom.IsAdditionalField
    ''''    Get
    ''''        Throw New NotImplementedException()
    ''''    End Get
    ''''    Set(value As Boolean)
    ''''        Throw New NotImplementedException()
    ''''    End Set
    ''''End Property

    ''Public Property IsBarCode As Boolean = False Implements ICIBFieldStandardOrCustom.IsBarcodeField ''Added 7/31/2019 td
    ''Public Property DataEntryText As String Implements ICIBFieldStandardOrCustom.DataEntryText ''Added 9/9/2019 td

    ''''8/27/2019 td'' Property Image_BL As Image Implements ICIBFieldStandardOrCustom.Image_BL ''Added 8/27/2019 

    ''Private mod_elementFieldClass As ClassElementField ''Added 9/3/2019 td   

    ''''
    ''''Added 7/29/2019 thomas downes
    ''''
    ''''9/3/2019 td''Public Property ElementInfo As ClassElementText
    ''Public Property ElementFieldClass() As ClassElementField
    ''    Get
    ''        ''Added 9/3/2019 thomas d. 
    ''        Return mod_elementFieldClass
    ''    End Get
    ''    Set(value As ClassElementField)
    ''        ''Added 9/3/2019 thomas d. 
    ''        mod_elementFieldClass = value
    ''        ''Added 9/3/2019 thomas d. 
    ''        Me.ElementInfo_Base = CType(value, IElement_Base)
    ''        Me.ElementInfo_Text = CType(value, IElement_TextField)
    ''    End Set
    ''End Property

    ''''Added 9/3/2019 td
    ''Public Property ElementInfo_Base As IElement_Base Implements ICIBFieldStandardOrCustom.ElementInfo_Base
    ''''Added 9/3/2019 td
    ''Public Property ElementInfo_Text As IElement_TextField Implements ICIBFieldStandardOrCustom.ElementInfo_Text

    ''
    ''Added 7/16/2019 thomas d. 
    ''
    ''10/17 td''Public Shared ListOfFields_Standard As New List(Of ClassFieldStandard)
    ''10/17 td''Public Shared ListOfFields_Staff As New List(Of ClassFieldStandard)

    ''5/7/2022 td Public Shared ListOfFields_Standard As New HashSet(Of ClassFieldStandard)
    ''5/8/2022 td ''Public Shared ListOfFields_Standard As New HashSet(Of ClassFieldStandard)

    ''5/7/2022 td''Public Shared ListOfFields_Staff As New HashSet(Of ClassFieldStandard)
    ''5/8/2022 td ''Public Shared ListOfFields_Staff_NotInUse As New HashSet(Of ClassFieldStandard)

    Public Shared FieldIndexHighest As Integer = -1 ''Added 5/5/2022 td

    ''---4/22/2020 td----Private Shared ms_lastFieldIndex As Integer ''Added 4/22/2020 thomas downes

    Public Sub New()
        ''
        ''Added 4/22/2020 thomas downes
        ''
        Me.FieldIndex = ClassFieldAny.LastUsedFieldIndex
        ClassFieldAny.LastUsedFieldIndex += 1

    End Sub


    Public Shared Function ListOfFieldInfos_Standard(par_listOfFields As List(Of ClassFieldStandard)) _
             As List(Of ICIBFieldStandardOrCustom)
        ''------5/9/2022 td  Public Shared Function ListOfFieldInfos_Standard() As List(Of ICIBFieldStandardOrCustom)
        ''-----5/7/2022 td ''Public Shared Function ListOfFieldInfos_Students

        ''Added 9/2/2019 Thomas DOWNES
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        For Each obj_class As ClassFieldStandard In par_listOfFields ''----ListOfFields_Standard ''5/7/2022 ListOfFields_Students
            ''Added 9/2/2019
            new_list.Add(CType(obj_class, ICIBFieldStandardOrCustom))
        Next obj_class
        Return new_list

    End Function ''End of "Public Shared Function ListOfFieldInfos_Standard() As List(Of ICIBFieldStandardOrCustom)"



    Public Shared Function ListOfFieldInfos_Standard(par_listOfFields As HashSet(Of ClassFieldStandard)) _
             As List(Of ICIBFieldStandardOrCustom)

        ''Added 5/09/2022 td
        Dim new_list As New List(Of ICIBFieldStandardOrCustom)
        For Each obj_class As ClassFieldStandard In par_listOfFields
            new_list.Add(CType(obj_class, ICIBFieldStandardOrCustom))
        Next obj_class
        Return new_list

    End Function ''End of "Public Shared Function ListOfFieldInfos_Standard() As List(Of ICIBFieldStandardOrCustom)"


    ''Public Shared Function ListOfFieldInfos_Staff_NotInUse() As List(Of ICIBFieldStandardOrCustom)
    ''    ''Added 9/2/2019 Thomas DOWNES
    ''    Dim new_list As New List(Of ICIBFieldStandardOrCustom)
    ''    For Each obj_class As ClassFieldStandard In ListOfFields_Staff_NotInUse
    ''        ''Added 9/2/2019
    ''        new_list.Add(CType(obj_class, ICIBFieldStandardOrCustom))
    ''    Next obj_class
    ''    Return new_list
    ''End Function ''End of "Public Shared Function ListOfFieldInfos_Students() As List(Of ICIBFieldStandardOrCustom)"

    ''9/18/2019 td''Public Shared Function ListOfElementsText_Stdrd(Optional par_intLayoutWidth As Integer = 0) As List(Of IFieldInfo_ElementPositions)
    ''
    ''    ''9/4/2019 td''Public Shared Function ListOfElementsText_Stdrd() As List(Of IElementWithText)
    ''    ''
    ''    ''Added 8/24/2019 Thomas D.  
    ''    ''
    ''    Dim obj_listOutput As New List(Of IFieldInfo_ElementPositions)

    ''    For Each each_obj In ListOfFields_Standard

    ''        Dim new_ElementWithText As New IFieldInfo_ElementPositions
    ''        Dim obj_ElementText As IElement_TextField
    ''        Dim obj_Element_Base As IElement_Base

    ''        new_ElementWithText.FieldInfo = each_obj ''Added 9/3/2019 td  

    ''        obj_ElementText = CType(each_obj.ElementFieldClass, IElement_TextField)
    ''        obj_Element_Base = CType(each_obj.ElementFieldClass, IElement_Base)

    ''        new_ElementWithText.Position_BL = obj_Element_Base
    ''        new_ElementWithText.TextDisplay = obj_ElementText

    ''        ''Added 9/4/2019 td
    ''        new_ElementWithText.BadgeLayout_Width = par_intLayoutWidth
    ''        ''9/12 td''new_ElementWithText.Position_BL.LayoutWidth_Pixels = par_intLayoutWidth
    ''        new_ElementWithText.Position_BL.BadgeLayout.Width_Pixels = par_intLayoutWidth

    ''        obj_listOutput.Add(new_ElementWithText)

    ''    Next each_obj

    ''    Return obj_listOutput

    ''End Function ''eND OF Public Shared Function ListOfElementsText_Stdrd()  


    ''Public Shared Function InitializedHardcodedList_Standard() As HashSet(Of ClassFieldStandard)
    ''    ''5/3/2022 td ''Public Shared Sub InitializeHardcodedList_Students
    ''    ''
    ''    ''Added 3/23/2022 td
    ''    ''
    ''    ''May8 2022 td ''If (pListOfFields IsNot Nothing) Then
    ''
    ''    ''If (pListOfFields IsNot Nothing) Then
    ''    ''    InitializeHardcodedList_ParamList("Student", pboolOnlyIfNeeded, pListOfFields)
    ''
    ''     ''Else
    ''    ''    InitializeHardcodedList_ParamList("Student", pboolOnlyIfNeeded, ListOfFields_Standard)
    ''
    ''    ''End If ''End of "If (pListOfFields IsNot Nothing) Then .... Else..."
    ''
    ''End Function ''End of Public Shared Function GetInitializedHardcodedList_Standard()


    ''Public Shared Sub InitializeHardcodedList_Staff_NotInUse(pboolOnlyIfNeeded As Boolean,
    ''            Optional pListOfFields As HashSet(Of ClassFieldStandard) = Nothing)
    ''    ''5/3/2022 td ''Public Shared Sub InitializeHardcodedList_Staff
    ''    ''
    ''    ''Added 3/23/2022 td
    ''    ''
    ''    If (pListOfFields IsNot Nothing) Then
    ''        InitializeHardcodedList_ParamList("Staff", pboolOnlyIfNeeded, pListOfFields)
    ''
    ''    Else
    ''        ''5/7/2022 td''InitializeHardcodedList_ParamList("Staff", pboolOnlyIfNeeded, ListOfFields_Staff)
    ''        InitializeHardcodedList_ParamList("Staff", pboolOnlyIfNeeded, ListOfFields_Staff_NotInUse)
    ''
    ''    End If ''End of "If (pListOfFields IsNot Nothing) Then .... Else..."
    ''
    ''End Sub


    ''Public Shared Function InitializeHardcodedList_ParamList() As HashSet(Of ClassFieldStandard)

    ''    ''May 8 2022 Public Shared Sub InitializeHardcodedList_ParamList(pstrRecipientClassName As String,
    ''    ''May 8 2022       pboolOnlyIfNeeded As Boolean,
    ''    ''May 8 2022       parListOfFields As HashSet(Of ClassFieldStandard))
    ''    ''
    ''    ''March23 2022 td''            pboolOnlyIfNeeded As Boolean,
    ''    ''
    ''    ''Added 3/23/2022 & 7/26/2019 td
    ''    ''
    ''    ''March23 2022  Dim intFieldIndex As Integer ''Added 9/17/2019 td 
    ''    ''March23 2022  Const c_heightPixels As Integer = 30 ''Added 9/17 td
    ''    ''March23 2022  Dim intLeft_Pixels As Integer = 0
    ''    ''March23 2022  Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 

    ''    ''With parListOfFields ''March23 2022'' ListOfFields_Standard
    ''    ''    ''8/28/2019 td''If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
    ''    ''    If (pboolOnlyIfNeeded) Then
    ''    ''        If (.Count > 0) Then Exit Sub
    ''    ''    ElseIf (.Count > 0) Then
    ''    ''        Throw New Exception("Already initialized/ has more than zero fields.")
    ''    ''    End If
    ''    ''End With ''End of "With parListOfFields"

    ''    ''
    ''    ''Major call!!    Encapsulated 3/23/2022 thomas 
    ''    ''
    ''    InstantiateFields_Standard(pstrRecipientClassName)


    ''End Function ''End of "Public Shared Sub InitializeHardcodedList_ParamList"


    Public Shared Function GetInitializedList_Standard(pstrRecipientClassName As String) _
        As HashSet(Of ClassFieldStandard)

        ''5/8/2022 Public Shared Sub InstantiateFields_Standard(pstrRecipientClassName As String,
        ''                                            Optional pboolSingleField As Boolean = False,
        ''                           Optional par_singleEnum As EnumCIBFields = EnumCIBFields.Undetermined,
        ''                           Optional ByRef pref_singleField As ClassFieldStandard = Nothing,
        ''                           Optional pbDontSaveToList As Boolean = False)
        ''
        ''Encapsulated 3/23/2022 thomas 
        ''Coded 7/26/2019
        ''
        Dim objListOfFields_Standard As HashSet(Of ClassFieldStandard) ''Added 5/9/2022 td
        Dim intFieldIndex As Integer ''Added 9/17/2019 td 
        Const c_heightPixels As Integer = 30 ''Added 9/17 td
        Dim intLeft_Pixels As Integer = 0
        Dim intTop_Pixels As Integer = 0 ''Added 9/17/2019 td 
        Dim boolExitSub As Boolean = False ''Added 3/23/2022 td

        ''Added 5/9/2022 td
        objListOfFields_Standard = New HashSet(Of ClassFieldStandard) ''Added 5/9/2022 td

        intFieldIndex = 1 ''Added 9/17/2019 td
        Dim new_objectField1 As New ClassFieldStandard
        With new_objectField1

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrID ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''5/9/2022 td''If (par_singleEnum = EnumCIBFields.fstrID) Then pref_singleField = new_objectField1

            ''N/A''.TextFieldId = 1 ''TextField01 
            .IsCustomizable = False ''Added 7/26/2019 td 
            ''Added 3/23/2022 td''.FieldLabelCaption = "Student ID"
            .FieldLabelCaption = (pstrRecipientClassName & " ID")
            .CIBadgeField = "fstrID"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .ExampleValue = "12345"
            .IsRelevantToPersonality = True ''Added 5/05/2022 td
            .IsDisplayedForEdits = True ''Checked 5/05/2022 td
            .IsDisplayedOnBadge = True ''Checked 5/05/2022 td
            .IsLocked = True

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''9/17/2019 td''.ElementFieldClass = New ClassElementField(0, 0, 30)
            ''9/18/2019 td''intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = (c_heightPixels * (intFieldIndex - 1))
            intLeft_Pixels = intTop_Pixels ''Let's have a staircase effect!! 

            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementFieldClass = New ClassElementField(new_objectField1, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td
            ''--.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''--.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With ''End of "With new_objectField1

        ''5/5/2022 If (Not pbDontSaveToList) Then _
        ''    ListOfFields_Standard.Add(new_objectField1)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField1)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else

        objListOfFields_Standard.Add(new_objectField1)

        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""




        intFieldIndex = 2 ''Added 9/17/2019 td
        Dim new_objectField2 As New ClassFieldStandard
        With new_objectField2

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrFirstName ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''5/3/2022 td  If (par_singleEnum = EnumCIBFields.fstrFirstName) Then pref_singleField = new_objectField2

            ''N/A''.TextFieldId = 2 ''TextField02
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "First Name"
            .CIBadgeField = "fstrFirstName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsRelevantToPersonality = False ''---True ''Added 5/05/2022 td
            .IsDisplayedForEdits = False ''---True ''Modified 5/05/2022 td ''Added 8/23/2019 td
            .IsDisplayedOnBadge = False ''---True ''Modified 5/05/2022 td ''Added 8/23/2019 td
            .IsLocked = False

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''#1 9/17/2019 td''.ElementFieldClass = New ClassElementField(30, 30, 30)
            '' #2 9/17/2019 td''.ElementFieldClass = New ClassElementField(new_objectField2, 30, 30, 30)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With ''End of "With new_objectField2

        ''If (Not pbDontSaveToList) Then _
        ''  ListOfFields_Standard.Add(new_objectField2)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField2)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField2)

        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""




        intFieldIndex = 3 ''Added 9/17/2019 td
        Dim new_objectField3 As New ClassFieldStandard
        With new_objectField3

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrLastName ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrLastName) Then pref_singleField = new_objectField3

            ''N/A''.TextFieldId = 3 ''TextField03 
            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Last Name"
            .CIBadgeField = "fstrLastName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            ''.IsDateField = False
            .IsFieldForDates = False
            ''Added 8/23/2019 td
            ''5/3/2022 .IsDisplayedForEdits = True
            ''5/3/2022 .IsDisplayedOnBadge = True
            .IsLocked = False
            ''Added 5/05/2022 td
            .IsRelevantToPersonality = False ''---True ''Added 5/05/2022 td
            .IsDisplayedForEdits = False ''---True ''Modified 5/05/2022 td ''Added 8/23/2019 td
            .IsDisplayedOnBadge = False ''---True ''Modified 5/05/2022 td ''Added 8/23/2019 td

            ''Added 9/3/2019 td
            ''9/15/2019 td''.ElementInfo = New ClassElementText()
            ''9/17/2019 td''.ElementFieldClass = New ClassElementField(60, 60, 30)
            intLeft_Pixels = (30 * (intFieldIndex - 1))
            intTop_Pixels = intLeft_Pixels ''Let's have a staircase effect!! 
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField(new_objectField2, intLeft_Pixels, intTop_Pixels, c_heightPixels)

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Base = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_Base)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementInfo_Text = CType(.ElementFieldClass, ciBadgeInterfaces.IElement_TextField)

        End With ''End of "With new_objectField3"

        ''If (Not pbDontSaveToList) Then _
        ''  ListOfFields_Standard.Add(new_object3)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField3)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField3)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 8/23/2019 thomas d
        intFieldIndex = 4 ''Added 9/17/2019 td
        Dim new_objectField4 As New ClassFieldStandard
        With new_objectField4

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrMidName ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrMidName) Then pref_singleField = new_objectField4

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Middle Name"
            .CIBadgeField = "fstrMidName"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''End of "With new_objectField4"

        ''If (Not pbDontSaveToList) Then _
        ''  ListOfFields_Standard.Add(new_object4)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField4)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField4)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""




        ''Added 8/23/2019 thomas d
        intFieldIndex = 5 ''Added 9/17/2019 td
        Dim new_objectField5 As New ClassFieldStandard
        With new_objectField5

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrBarCode ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrBarCode) Then pref_singleField = new_objectField5

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Barcode Value"
            .CIBadgeField = "fstrBarcode"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False
            .ExampleValue = "1234567890" ''Added 9/12/2019 td 

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

            ''Added 8/28/2019 thomas downes
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass.FontSize_Pixels = 16 ''Added 9/12/2019 td  
            ''9/12/2019 td''.ElementInfo.Font_DrawingClass = modFonts.BarCodeFont_ByDefault(16)
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass.Font_DrawingClass = modFonts.BarCodeFont_ByDefault(.ElementFieldClass.FontSize_Pixels)

        End With ''end of "With new_objectField5"

        ''If (Not pbDontSaveToList) Then _
        ''    ListOfFields_Standard.Add(new_object5)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField5)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField5)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 8/23/2019 thomas d
        intFieldIndex = 6 ''Added 9/17/2019 td
        Dim new_objectField6 As New ClassFieldStandard
        With new_objectField6

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td
            .FieldEnumValue = EnumCIBFields.fstrAddress ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrAddress) Then pref_singleField = new_objectField6

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Address"
            .CIBadgeField = "fstrAddress"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField6"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object6)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField6)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField6)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 8/23/2019 thomas d
        intFieldIndex = 7 ''Added 9/17/2019 td
        Dim new_objectField7 As New ClassFieldStandard
        With new_objectField7

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrCity ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrCity) Then pref_singleField = new_objectField7

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "City"
            .CIBadgeField = "fstrCity"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField7"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object7)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField7)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField7)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 8/23/2019 thomas d
        intFieldIndex = 8 ''Added 9/17/2019 td
        Dim new_objectField8 As New ClassFieldStandard
        With new_objectField8

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrState ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = EnumCIBFields.fstrState) Then pref_singleField = new_objectField8

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "State"
            .CIBadgeField = "fstrState"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField8"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object8)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField8)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField8)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 8/23/2019 thomas d
        intFieldIndex = 9 ''Added 9/17/2019 td
        Dim new_objectField9 As New ClassFieldStandard
        With new_objectField9

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrZip ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField9

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Zipcode"
            .CIBadgeField = "fstrZip"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField9"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object9)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField9)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField9)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 9/16/2019 thomas d
        intFieldIndex = 10 ''Added 9/17/2019 td
        Dim new_objectField91 As New ClassFieldStandard
        With new_objectField91

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.blnBatchPrint ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField91

            .IsCustomizable = False ''Added 9/16/2019 td 
            .FieldLabelCaption = "Printed by Batch"
            .CIBadgeField = "blnBatchPrint"
            .FieldType_TD = "B"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField91"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object91)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField91)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField91)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 9/16/2019 thomas d
        intFieldIndex = 11 ''Added 9/17/2019 td
        Dim new_objectField92 As New ClassFieldStandard
        With new_objectField92

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.idfConfigID ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField92

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Personality ID"
            .CIBadgeField = "idfConfigID"
            .FieldType_TD = "I"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField92"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object92)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField92)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField92)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 9/16/2019 thomas d
        intFieldIndex = 12 ''Added 9/17/2019 td
        Dim new_objectField93 As New ClassFieldStandard
        With new_objectField93

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.idfReportID ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField93

            .IsCustomizable = False
            .FieldLabelCaption = "Badge Layout ID"
            .CIBadgeField = "idfReportID"
            .FieldType_TD = "I"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField93"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object93)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField93)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField93)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 9/16/2019 thomas d
        intFieldIndex = 13 ''Added 9/17/2019 td
        Dim new_objectField94 As New ClassFieldStandard
        With new_objectField94

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fdateRecDate ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField94

            .IsCustomizable = False
            .FieldLabelCaption = "Record Created"
            .CIBadgeField = "fdateRecDate"
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()
        End With ''end of "With new_objectField94"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object94)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField94)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField94)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 9/16/2019 thomas d
        intFieldIndex = 14 ''Added 9/17/2019 td
        Dim new_objectField95 As New ClassFieldStandard
        With new_objectField95

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fdatTimeStamp ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField95

            .IsCustomizable = False
            .FieldLabelCaption = "Record Updated"
            .CIBadgeField = "fdatTimeStamp"
            .FieldType_TD = "D"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = True
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = True
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_object95"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object95)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField95)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField95)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""


        ''blnBatchPrint ''F.I.#16  [blnBatchPrint] [bit] NULL ,
        ''''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
        ''intTimesPrinted ''F.I.#17  [intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
        ''fdatTimeStamp ''F.I.#18  [fdatTimeStamp] [datetime] NULL ,
        ''fintRecPool ''F.I.#19
        ''fstrRFID_Unique ''F.I.#20

        ''Added 8/23/2019 thomas d
        intFieldIndex = 15 ''Added 9/17/2019 td
        Dim new_objectField96 As New ClassFieldStandard
        With new_objectField96

            .FieldIndex = intFieldIndex ''Added 4/22/2020 td

            .FieldEnumValue = EnumCIBFields.fstrRFID_Unique ''Added 9/16/2019 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_objectField96

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "RFID/UID Value"
            .CIBadgeField = "fstrRFID_Unique"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsDisplayedForEdits = False
            .IsDisplayedOnBadge = False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_objectField96"

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_objectField96)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField96)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 3/23/2022 thomas d
        intFieldIndex = 16 ''Added 3/23/2022 td
        Dim new_objectField97 As New ClassFieldStandard
        With new_objectField97

            .FieldIndex = intFieldIndex ''Added 3/23/2022 td

            .FieldEnumValue = EnumCIBFields.fstrFullName ''Added 3/23/2022 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_object991

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Full Name"
            .CIBadgeField = "fstrFullName"
            ''T = Text, D = Date
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsRelevantToPersonality = True ''5/5/2022 False ''Added 5/05/2022
            .IsDisplayedForEdits = True ''5/5/2022 False
            .IsDisplayedOnBadge = True ''5/5/2022 False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_object991"

        ''#1 5/5/2022 ''If (Not pbDontSaveToList) Then _
        ''#1 5/5/2022 ''   ListOfFields_Standard.Add(new_object991)

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list. 
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_object991)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        objListOfFields_Standard.Add(new_objectField97)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""



        ''Added 3/23/2022 thomas d
        intFieldIndex = 17 ''Added 3/23/2022 td
        Dim new_objectField98 As New ClassFieldStandard
        With new_objectField98

            .FieldIndex = intFieldIndex ''Added 3/23/2022 td

            .FieldEnumValue = EnumCIBFields.fstrNameAbbreviated ''Added 3/23/2022 td
            ''Added 3/23/2022
            ''If (par_singleEnum = .FieldEnumValue) Then pref_singleField = new_object992

            .IsCustomizable = False ''Added 7/26/2019 td 
            .FieldLabelCaption = "Abbreviated Name"
            .CIBadgeField = "fstrNameAbbreviated"
            .FieldType_TD = "T"c
            .HasPresetValues = False
            .IsAdditionalField = False
            .IsFieldForDates = False
            .IsRelevantToPersonality = False ''True ''5/5/2022 False ''Added 5/05/2022
            .IsDisplayedForEdits = False ''True ''5/5/2022 False
            .IsDisplayedOnBadge = False ''True ''5/5/2022 False
            .IsLocked = False

            ''Added 9/3/2019 td
            ''---(---Fields cannot link outward to elements.---9/18/2019 td.ElementFieldClass = New ClassElementField()

        End With ''end of "With new_object992"

        ''If (Not pbDontSaveToList) Then _
        ''   ListOfFields_Standard.Add(new_object992)
        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then
        ''    ''Add it to the list.  ---5/5/2022
        ''    If (Not pbDontSaveToList) Then ListOfFields_Standard.Add(new_object992)
        ''    Exit Sub ''Added 3/23/2022
        ''ElseIf (pbDontSaveToList) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022
        ''ElseIf (pboolSingleField) Then
        ''    ''Don't save it to the list of fields. ---5/5/2022 
        ''Else
        ''    ListOfFields_Standard.Add(new_object992)
        ''End If ''End of ""If (pboolSingleField And (pref_singleField IsNot Nothing)) Then""

        objListOfFields_Standard.Add(new_objectField98)

        ''Added 5/5/2022 td 
        FieldIndexHighest = intFieldIndex

        ''blnBatchPrint ''F.I.#16  [blnBatchPrint] [bit] NULL ,
        ''''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
        ''intTimesPrinted ''F.I.#17  [intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
        ''fdatTimeStamp ''F.I.#18  [fdatTimeStamp] [datetime] NULL ,
        ''fintRecPool ''F.I.#19
        ''fstrRFID_Unique ''F.I.#20

        Const c_boolAddObjectsToListAtEnd As Boolean = False
        If (c_boolAddObjectsToListAtEnd) Then
            ''
            ''Standard fields
            ''
            objListOfFields_Standard.Add(new_objectField1)
            objListOfFields_Standard.Add(new_objectField2)
            objListOfFields_Standard.Add(new_objectField3)
            objListOfFields_Standard.Add(new_objectField4)
            objListOfFields_Standard.Add(new_objectField5)
            objListOfFields_Standard.Add(new_objectField6)
            objListOfFields_Standard.Add(new_objectField7)
            objListOfFields_Standard.Add(new_objectField8)
            objListOfFields_Standard.Add(new_objectField91)
            objListOfFields_Standard.Add(new_objectField92)
            objListOfFields_Standard.Add(new_objectField93)
            objListOfFields_Standard.Add(new_objectField94)
            objListOfFields_Standard.Add(new_objectField95)
            objListOfFields_Standard.Add(new_objectField96)
            objListOfFields_Standard.Add(new_objectField97)
            objListOfFields_Standard.Add(new_objectField98)

        End If ''End of ""If (c_boolAddObjectsToListAtEnd) Then""



ExitHandler:

        Return objListOfFields_Standard

        ''
        ''Check to see if we __still__ haven't instantiated the output. ---3/23/2022
        ''
        ''If (pboolSingleField And (pref_singleField Is Nothing)) Then
        ''    ''
        ''    ''We __still__ haven't instantiated the output.  Create the field object.
        ''    '' ---3/23/2022
        ''    ''
        ''    Dim new_objectExitHandler As New ClassFieldStandard
        ''    With new_objectExitHandler
        ''        .FieldIndex = intFieldIndex ''Added 4/22/2020 td
        ''        .FieldEnumValue = par_singleEnum ''Added 9/16/2019 td
        ''        ''Added 3/23/2022
        ''        If (par_singleEnum = .FieldEnumValue) Then
        ''            pref_singleField = new_objectExitHandler
        ''        End If
        ''        .IsCustomizable = False ''Added 7/26/2019 td 
        ''        .FieldLabelCaption = par_singleEnum.ToString() '' "[unknown_FieldLabelCaption]"
        ''        .CIBadgeField = par_singleEnum.ToString() '' "[unknown_CIBadgeField]"
        ''        ''.FieldType_TD = "T"c
        ''        ''.HasPresetValues = False
        ''        ''.IsAdditionalField = False
        ''        ''.IsFieldForDates = False
        ''        ''.IsDisplayedForEdits = False
        ''        ''.IsDisplayedOnBadge = False
        ''        ''.IsLocked = False
        ''    End With ''end of "With new_object99"

        ''    ''If (Not pbDontSaveToList) Then 
        ''    ListOfFields_Standard.Add(new_objectExitHandler)
        ''    ''End If
        ''    ''If (pboolSingleField And (pref_singleField IsNot Nothing)) Then Exit Sub ''Added 3/23/2022

        ''End If ''end of "If (pboolSingleField And pref_singleField Is Nothing) Then"

    End Function ''End of "GetInitializedList_Standard()"


    Public Shared Function GetField_ByEnum_Standard(par_singleEnum As EnumCIBFields,
                         Optional ByRef pref_IsCustomizableLikely As Boolean = False,
                         Optional ByRef pref_IsCustomizableField As Boolean = False,
                         Optional ByRef pref_objFieldCustom As ClassFieldCustomized = Nothing) _
                         As ClassFieldStandard

        ''    ''5/8/2022 Public Shared Function BuildField_ByEnum_Standard
        ''
        ''    ''Added 3/23/2022 thomas 
        ''    ''
        Dim outputField As ClassFieldStandard = Nothing

        ''
        ''    InstantiateFields_Standard("Member/Employee/Student", True, par_singleEnum,
        ''                               outputField, True)
        ''    Return outputField
        ''
        Dim intMaxEnumValue As Integer = 0
        Dim each_intEnumValue As Integer = 0

        For Each each_field In GetInitializedList_Standard("Students")

            If (each_field.FieldEnumValue = par_singleEnum) Then
                Return each_field
            End If ''End of ""If (each_field.FieldEnumValue = par_singleEnum) Then""

            each_intEnumValue = CInt(each_field.FieldEnumValue)
            intMaxEnumValue = CInt(IIf(intMaxEnumValue > each_intEnumValue,
                                       intMaxEnumValue, each_intEnumValue))

        Next each_field

        ''
        ''Check to see if the parameter might indicate a Custom field,
        ''   rather than a Standard field.  ----5/9/2022 td
        ''
        pref_IsCustomizableLikely = (CInt(par_singleEnum) > intMaxEnumValue)
        If (pref_IsCustomizableLikely) Then
            System.Diagnostics.Debugger.Break()
        End If ''ENd of ""If (pref_IsCustomizableLikely) Then""

        ''Added 5/9/2022 td
        ''Dim objFieldCustom As ClassFieldCustomized
        pref_objFieldCustom = ClassFieldCustomized.GetField_ByEnum_Custom(par_singleEnum)
        If (pref_objFieldCustom IsNot Nothing) Then
            pref_IsCustomizableField = True
        End If ''End of ""If (pref_objFieldCustom IsNot Nothing) Then""

        Return Nothing

    End Function ''End of ""Public Shared Function GetField_ByEnum_Standard""


    Public Shared Function LoadField_ByEnum_Custom(par_singleEnum As EnumCIBFields) As ClassFieldStandard
        ''
        ''Encapsulated 3/23/2022 thomas 
        ''Coded 7/26/2019
        ''
        Throw New Exception("This Shared procedure is found on ClassFieldCustom (vs. ClassFieldStandard)")

    End Function


    Public Shared Sub InstantiateFields_Custom(Optional pboolSingleField As Boolean = False,
                               Optional par_singleEnum As EnumCIBFields = EnumCIBFields.Undetermined,
                               Optional ByRef pref_singleField As ClassFieldStandard = Nothing,
                               Optional pbDontSaveToList As Boolean = False)
        ''
        ''Encapsulated 3/23/2022 thomas 
        ''Coded 7/26/2019
        ''
        Throw New Exception("This Shared procedure is found on ClassFieldCustom (vs. ClassFieldStandard)")

    End Sub


    ''Public Shared Sub InitializeHardcodedList_Staff_Obselete(pboolOnlyIfNeeded As Boolean)
    ''    ''
    ''    ''Stubbed 7/16/2019 td
    ''    ''
    ''    ''  Add Schoolname, Job Title, GradeLevel (if applicable). 
    ''    ''
    ''    Dim intFieldIndex As Integer = 0 ''Added 4/22/2020 td 

    ''    ''Added 7/23/2019 thomas
    ''    With ListOfFields_Staff_NotInUse
    ''        If (pboolOnlyIfNeeded And .Count > 0) Then Exit Sub
    ''    End With

    ''    intFieldIndex = 101 ''Added 4/22/2020 td
    ''    Dim new_object1 As New ClassFieldStandard
    ''    With new_object1

    ''        .FieldIndex = intFieldIndex ''Added 4/22/2020 td

    ''        ''N/A''.TextFieldId = 1
    ''        .IsCustomizable = False ''Added 7/26/2019 td 
    ''        .FieldLabelCaption = "Staffperson ID"
    ''        .CIBadgeField = "fstrID"
    ''        .FieldType_TD = "T"c
    ''        .HasPresetValues = False
    ''        .IsAdditionalField = False
    ''        ''.IsDateField = False
    ''        .IsFieldForDates = False
    ''        .ExampleValue = "4014"
    ''    End With
    ''    ''5/7/2022 td ''ListOfFields_Staff.Add(new_object1)
    ''    ListOfFields_Staff_NotInUse.Add(new_object1)

    ''    intFieldIndex = 102 ''Added 4/22/2020 td
    ''    Dim new_object2 As New ClassFieldStandard
    ''    With new_object1

    ''        .FieldIndex = intFieldIndex ''Added 4/22/2020 td

    ''        ''N/A''.TextFieldId = 2
    ''        .IsCustomizable = False ''Added 7/26/2019 td 
    ''        .FieldLabelCaption = "First Name"
    ''        .CIBadgeField = "fstrFirstName"
    ''        .FieldType_TD = "T"c
    ''        .HasPresetValues = False
    ''        .IsAdditionalField = False
    ''        ''.IsDateField = False
    ''        .IsFieldForDates = False
    ''    End With
    ''    ListOfFields_Staff_NotInUse.Add(new_object2)

    ''    intFieldIndex = 103 ''Added 4/22/2020 td
    ''    Dim new_object3 As New ClassFieldStandard
    ''    With new_object3

    ''        .FieldIndex = intFieldIndex ''Added 4/22/2020 td

    ''        ''N/A''.TextFieldId = 3
    ''        .IsCustomizable = False ''Added 7/26/2019 td 
    ''        .FieldLabelCaption = "Last Name"
    ''        .CIBadgeField = "fstrLastName"
    ''        .FieldType_TD = "T"c
    ''        .HasPresetValues = True
    ''        .IsAdditionalField = False
    ''        ''.IsDateField = False
    ''        .IsFieldForDates = False
    ''    End With
    ''    ListOfFields_Staff_NotInUse.Add(new_object3)
    ''
    ''End Sub ''End of "InitializeHardcodedList_Staff_Obselete()"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---9/18/2019 td''Public Shared Sub CopyElementInfo(par_intFieldIndex As Integer,
    ''                                  par_info_base As IElement_Base,
    ''                                  par_info_text As IElement_TextField)
    ''    ''
    ''    ''Added 9/15/2019 td
    ''    ''
    ''    Dim fieldRequested As ClassFieldStandard
    ''
    ''    fieldRequested = ListOfFields_Standard.Where(Function(x) x.FieldIndex = par_intFieldIndex).First()
    ''
    ''    fieldRequested.Load_ByCopyingMembers(par_info_base)
    ''    fieldRequested.Load_ByCopyingMembers(par_info_text)

    ''End Sub ''End of "Public Shared Sub CopyElementInfo"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---9/18/2019 td''Public Shared Sub CopyElementInfo(par_enumCIBField As EnumCIBFields,
    ''                                  par_info_base As IElement_Base,
    ''                                  par_info_text As IElement_TextField)
    ''    ''
    ''    ''Added 9/16/2019 td
    ''    ''
    ''    Dim fieldRequested As ClassFieldStandard
    ''
    ''    fieldRequested = ListOfFields_Standard.Where(Function(x) x.FieldEnumValue = par_enumCIBField).First()
    ''    fieldRequested.Load_ByCopyingMembers(par_info_base)
    ''    fieldRequested.Load_ByCopyingMembers(par_info_text)
    ''
    ''End Sub ''End of "Public Shared Sub CopyElementInfo"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---9/18/2019 td''Public Sub Load_ByCopyingMembers(par_info As IElement_Base)
    ''    ''
    ''    ''Added 7/23/2019 td
    ''    ''
    ''    With par_info
    ''
    ''        Me.ElementInfo_Base.Back_Color = .Back_Color
    ''        Me.ElementInfo_Base.Back_Transparent = .Back_Transparent
    ''        Me.ElementInfo_Base.BadgeLayout = .BadgeLayout
    ''        Me.ElementInfo_Base.Border_Color = .Border_Color
    ''        Me.ElementInfo_Base.Border_Displayed = .Border_Displayed
    ''        Me.ElementInfo_Base.Border_WidthInPixels = .Border_WidthInPixels
    ''        Me.ElementInfo_Base.ElementType = .ElementType
    ''        Me.ElementInfo_Base.Height_Pixels = .Height_Pixels
    ''        Me.ElementInfo_Base.Image_BL = .Image_BL
    ''        Me.ElementInfo_Base.LeftEdge_Pixels = .LeftEdge_Pixels
    ''        Me.ElementInfo_Base.OrientationInDegrees = .OrientationInDegrees
    ''        Me.ElementInfo_Base.OrientationToLayout = .OrientationToLayout
    ''        Me.ElementInfo_Base.PositionalMode = .PositionalMode
    ''        ''Not needed.''.SelectedHighlighting
    ''        Me.ElementInfo_Base.TopEdge_Pixels = .TopEdge_Pixels
    ''        Me.ElementInfo_Base.Width_Pixels = .Width_Pixels
    ''
    ''    End With
    ''
    ''End Sub ''end of "Public Sub Load_ByCopyingMembers(par_info As IElement_Base)"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---9/18/2019 td''Public Sub Load_ByCopyingMembers(par_info As IElement_TextField)
    ''    ''
    ''    ''Added 9/16/2019 td
    ''    ''
    ''    With par_info
    ''
    ''        Me.ElementInfo_Text.ExampleValue = .ExampleValue
    ''        Me.ElementInfo_Text.FieldInCardData = .FieldInCardData
    ''        Me.ElementInfo_Text.FieldLabelCaption = .FieldLabelCaption
    ''        Me.ElementInfo_Text.FontBold = .FontBold
    ''        Me.ElementInfo_Text.FontColor = .FontColor
    ''        Me.ElementInfo_Text.FontFamilyName = .FontFamilyName
    ''        Me.ElementInfo_Text.FontItalics = .FontItalics
    ''        Me.ElementInfo_Text.FontOffset_X = .FontOffset_X
    ''        Me.ElementInfo_Text.FontOffset_Y = .FontOffset_Y
    ''        Me.ElementInfo_Text.FontSize_Pixels = .FontSize_Pixels
    ''        Me.ElementInfo_Text.FontSize_ScaleToElementRatio = .FontSize_ScaleToElementRatio
    ''        Me.ElementInfo_Text.FontSize_ScaleToElementYesNo = .FontSize_ScaleToElementYesNo
    ''
    ''        Me.ElementInfo_Text.FontUnderline = .FontUnderline
    ''        Me.ElementInfo_Text.Font_DrawingClass = .Font_DrawingClass
    ''        Me.ElementInfo_Text.Recipient = .Recipient
    ''        Me.ElementInfo_Text.Text = .Text
    ''        Me.ElementInfo_Text.TextAlignment = .TextAlignment
    ''
    ''    End With ''End of "With par_info"
    ''
    ''End Sub ''end of "Public Sub Load_ByCopyingMembers(par_info As IElement_TextField)"

    Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)
        ''
        ''Added 7/23/2019 td
        ''
        ''NOt needed here. 9/16/2019 td''Me.ArrayOfValues = par_info.ArrayOfValues
        Me.CIBadgeField = par_info.CIBadgeField
        Me.ExampleValue = par_info.ExampleValue
        Me.FieldIndex = par_info.FieldIndex
        Me.FieldLabelCaption = par_info.FieldLabelCaption
        Me.HasPresetValues = par_info.HasPresetValues
        Me.IsAdditionalField = par_info.IsAdditionalField
        Me.IsFieldForDates = par_info.IsFieldForDates
        Me.IsLocked = par_info.IsLocked

        Me.FieldType_TD = par_info.FieldType_TD
        Me.OtherDbField_Optional = par_info.OtherDbField_Optional  ''Added 7/23/2019 td 

    End Sub ''End of "Public Sub Load_ByCopyingMembers(par_info As ICIBFieldStandardOrCustom)"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.GetTextValue(par_enum)

    ''End Function ''End of "Public Function GetValue_Recipient_String(par_enum As EnumCIBFields) As String"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.GetDateValue(par_enum)
    ''
    ''End Function ''End of "Public Function GetValue_Recipient_Date(par_enum As EnumCIBFields) As Date"

    ''---Fields cannot link outward to elements.---9/18/2019 td
    ''---Public Function GetValue_Recipient_TimesPrinted() As Integer
    ''    ''
    ''    ''Added 9/10/2019 td
    ''    ''
    ''    Return Me.ElementInfo_Text.Recipient.TimesPrinted()

    ''End Function ''End of "Public Function GetValue_Recipient_TimesPrinted(par_enum As EnumCIBFields) As Integer"

    Public Function Copy_FieldStandard() As ClassFieldStandard
        ''
        ''Added 10/14/2019 
        ''
        Dim objCopy_Stan As New ClassFieldStandard

        ''9/30/2019 td''objCopy.LoadbyCopyingMembers(Me, Me)
        ''10/14/2019 td''objCopy_Stan.LoadbyCopyingMembers(CType(Me, ICIBFieldStandardOrCustom))

        objCopy_Stan.LoadbyCopyingMembers_Standard(Me)

        Return objCopy_Stan

    End Function ''End of "Public Function Copy_FieldStandard() As ClassElementField"

    Public Sub LoadbyCopyingMembers_Standard(par_objectClass As ClassFieldStandard)
        ''
        ''Added 10/14 & 9/30/2019 thomas downes
        ''
        ''--------------------------------------------------------------------------
        ''Step 1 of 1 -- Field-related properties.
        ''--------------------------------------------------------------------------
        ''
        Me.CIBadgeField = par_objectClass.CIBadgeField
        Me.DataEntryText = par_objectClass.DataEntryText
        Me.ExampleValue = par_objectClass.ExampleValue

        ''Added 9/30/2019 thomas downes
        Me.FieldEnumValue = par_objectClass.FieldEnumValue
        Me.FieldIndex = par_objectClass.FieldIndex
        Me.FieldLabelCaption = par_objectClass.FieldLabelCaption
        Me.FieldType_TD = par_objectClass.FieldType_TD
        Me.HasPresetValues = par_objectClass.HasPresetValues
        Me.IsAdditionalField = par_objectClass.IsAdditionalField
        Me.IsBarCode = par_objectClass.IsBarCode
        Me.IsCustomizable = par_objectClass.IsCustomizable

        ''Added 5/5/2022
        Me.IsRelevantToPersonality = par_objectClass.IsRelevantToPersonality

        ''Added 10/01/2019 thomas downes
        Me.IsDateField = par_objectClass.IsDateField
        Me.IsDisplayedForEdits = par_objectClass.IsDisplayedForEdits
        Me.IsDisplayedOnBadge = par_objectClass.IsDisplayedOnBadge
        Me.IsFieldForDates = par_objectClass.IsFieldForDates
        Me.IsLinkedToSections = par_objectClass.IsLinkedToSections
        Me.IsLocked = par_objectClass.IsLocked
        Me.IsStandard = par_objectClass.IsStandard
        Me.OtherDbField_Optional = par_objectClass.OtherDbField_Optional
        Me.SublayoutLookup = par_objectClass.SublayoutLookup
        Me.Text_orDate = par_objectClass.Text_orDate

        ''Added 9/30/2019 thomas downes
        ''10/01/2019 td''Throw New NotImplementedException("Not all the members are programmed yet (i.e. the commands for copying their values haven't been written yet).")

    End Sub ''End of "Public Sub LoadbyCopyingMembers(par_ElementInfo_Base As IElement_Base, .....)"

End Class ''End of "Public Class ClassFieldStandard"
