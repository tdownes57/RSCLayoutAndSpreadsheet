''
''Added 1/19/2022 thomas downes
''
Imports ciBadgeInterfaces
Imports ciBadgeElements

Public Class ClassListOfElements_Graphics
    Inherits ClassListOfElements
    ''
    ''Added 1/19/2022 thomas downes
    ''
    ''Public Overrides Property ListOfElements_Front As List(Of ClassElementField)
    ''Public Overrides Property ListOfElements_Back As List(Of ClassElementField)
    Public Property ListOfElements_Front As List(Of ClassElementGraphic)
    Public Property ListOfElements_Backside As List(Of ClassElementGraphic)


    Public Overrides Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base)
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
                ListOfElements_Backside.Add(each_element)
                Exit Sub
            Else
                If (each_element.WhichSideOfCard = EnumWhichSideOfCard.Undetermined) Then each_element.WhichSideOfCard = EnumWhichSideOfCard.EnumFrontside
                If (each_element.WhichSideOfCard <> EnumWhichSideOfCard.EnumFrontside) Then System.Diagnostics.Debugger.Break()
            End If
        Next each_element

        For Each each_element In ListOfElements_Backside()
            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
            boolMatch = (par_infoBase Is each_infoBase)
            If (boolMatch) Then
                ListOfElements_Backside.Remove(each_element)
                ListOfElements_Front.Add(each_element)
                Exit Sub
            End If
        Next each_element

    End Sub ''eNd of "Public Overrides Sub SwitchElementToOtherSideOfCard(par_infoBase As IElement_Base)"


    Public Overrides Sub RemoveElement(par_infoBase As IElement_Base,
                                          Optional pboolBacksideOfCard As Boolean = False)
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
                Exit Sub
            End If
        Next each_element

        For Each each_element In ListOfElements_Backside()
            each_infoBase = CType(each_element, ciBadgeInterfaces.IElement_Base)
            boolMatch = (par_infoBase Is each_infoBase)
            If (boolMatch) Then
                ListOfElements_Backside.Remove(each_element)
                Exit Sub
            End If
        Next each_element


    End Sub ''eNd of "Public Overrides Sub RemoveElement(par_infoBase As IElement_Base)"


End Class
