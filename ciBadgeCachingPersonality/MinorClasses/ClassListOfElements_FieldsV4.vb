''
''Added 5/16/2022 & 1/19/2022 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeElements

Public Class ClassListOfElements_FieldsV4
    Inherits ClassListOfElements
    ''
    ''Added 5/16/2022 & 1/19/2022 thomas downes
    ''
    ''Public Overrides Property ListOfElements_Front As List(Of ClassElementField)
    ''Public Overrides Property ListOfElements_Back As List(Of ClassElementField)
    Public Property ListOfElements_Front As HashSet(Of ClassElementFieldV4)
    Public Property ListOfElements_Backside As HashSet(Of ClassElementFieldV4)


    Public Overrides Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base,
                                  Optional ByRef pref_bSuccess As Boolean = False)
        ''
        ''Added 1/19/2022 thomas downes
        ''
        Dim boolMatch1 As Boolean
        Dim boolMatch2 As Boolean
        Dim each_infoBase As IElement_Base

        ''
        ''Frontside of Card--Fields on the Front Side of ID Card.
        ''
        For Each each_element In ListOfElements_Front()

            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
            boolMatch1 = (par_infoBase Is each_infoBase)
            boolMatch2 = (par_infoBase Is each_element)

            If (boolMatch1 Or boolMatch2) Then
                ListOfElements_Front.Remove(each_element)
                ListOfElements_Backside.Add(each_element)
                pref_bSuccess = True ''Added 1/21/2022 td
                Exit Sub
            Else
                If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
            End If ''end of "If (boolMatch1 Or boolMatch2) Then ... Else ..."

        Next each_element

        ''
        ''Backside of Card--Fields on the Back Side of ID Card. 
        ''
        For Each each_element In ListOfElements_Backside()
            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)

            boolMatch1 = (par_infoBase Is each_infoBase)
            boolMatch2 = (par_infoBase Is each_element)

            If (boolMatch1 Or boolMatch2) Then
                ListOfElements_Backside.Remove(each_element)
                ListOfElements_Front.Add(each_element)
                pref_bSuccess = True ''Added 1/21/2022 td
                Exit Sub
            End If ''End of " If (boolMatch1 Or boolMatch2) Then"

        Next each_element

    End Sub ''eNd of "Public Overrides Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base)"


    Public Overrides Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional ByRef pref_bSuccess As Boolean = False,
                                          Optional pbSpecifySideOfCard As Boolean = False,
            Optional par_enumSide As EnumWhichSideOfCard = EnumWhichSideOfCard.Undetermined)
        ''
        ''Added 1/19/2022 thomas downes
        ''
        Dim boolMatch As Boolean
        Dim each_infoBase As IElement_Base

        ''
        ''Fields
        ''
        For Each each_element In ListOfElements_Front()
            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
            boolMatch = (par_infoBase Is each_infoBase)
            If (boolMatch) Then
                ListOfElements_Front.Remove(each_element)
                pref_bSuccess = True ''Added 1/21/2022 td
                Exit Sub
            End If
        Next each_element

        ''
        ''Backside 
        ''
        For Each each_element In ListOfElements_Backside()
            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
            boolMatch = (par_infoBase Is each_infoBase)
            If (boolMatch) Then
                ListOfElements_Backside.Remove(each_element)
                pref_bSuccess = True ''Added 1/21/2022 td
                Exit Sub
            End If
        Next each_element


    End Sub ''eNd of "Public Overrides Sub RemoveElement(par_infoBase As IElement_Base)"


End Class
