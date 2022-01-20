Option Explicit On
Option Strict On
Option Infer Off
''
''Added 12/12/2021 td
''
Imports ciBadgeInterfaces
''Imports ciBadgeDesigner
''Imports ciBadgeElements
Imports __RSCWindowsControlLibrary ''Added 1/2/2022 td 

Public Class Operations__Base
    Implements ICurrentElement ''Added 12/28/2021 td
    Public Overridable Property CtlCurrentElement As RSCMoveableControlVB Implements ICurrentElement.CtlCurrentElement
    Public Property ElementsCacheManager As ciBadgeCachePersonality.ClassCacheManagement Implements ICurrentElement.ElementsCacheManager

    Public Property NameOfClass As String ''Added 12/30/2021 td
    Public Property ElementInfo_Base As IElement_Base ''Added 1/19/2022 thomas d. 

    Public Sub Move_To_Other_Side_Of_Badge_BA1001(sender As Object, e As EventArgs)
        ''
        ''Stubbed 12/30/2021 td
        ''Programmed 1/17/2022 td 
        ''
        Dim enumCurrentSide As ciBadgeInterfaces.EnumWhichSideOfCard
        Dim enumSwitchToSide As ciBadgeInterfaces.EnumWhichSideOfCard

        enumCurrentSide = CtlCurrentElement.ElementInfo_Base.WhichSideOfCard

        If (enumCurrentSide = EnumWhichSideOfCard.EnumBackside) Then
            enumSwitchToSide = EnumWhichSideOfCard.EnumFrontside
        Else
            enumSwitchToSide = EnumWhichSideOfCard.EnumBackside
        End If

        CtlCurrentElement.ElementInfo_Base.WhichSideOfCard = enumSwitchToSide

        ''Important call. 
        ElementsCacheManager.SwitchElementToOtherSideOfCard(CtlCurrentElement.ElementInfo_Base)

        ''Added 1/17/2022 td
        MessageBoxTD.Show_Statement("For the change a visible effect, you will need to switch to the " &
                                    "other side of the card.")

    End Sub ''End of Public Sub Move_To_Other_Side_Of_Badge_BA1001


    Public Sub Delete_Element_From_Badge_BA1019(sender As Object, e As EventArgs)
        ''
        ''Stubbed 1/19/2022 thomas downes
        ''
        ElementsCacheManager.DeleteElementFromCard(CtlCurrentElement.ElementInfo_Base)

        MessageBoxTD.Show_Statement("For the change a visible effect, you will need to switch to the " &
                                    "other side of the card.")

    End Sub ''End of Public Sub Delete_Element_From_Badge_BA1001

    Public Sub How_Context_Menus_Are_Generated_EE9001(sender As Object, e As EventArgs)
        ''---Dec15 2021--Public Sub How_Context_Menus_Are_Generated_EE1001
        ''
        ''Added 12/12/2021 thomas downes  
        ''
        ''   We will use Reflection to convert the procedures in class Operations_EditFieldElement to clickable LinkLabels.
        ''      (See procedure MenuCache_FieldElements.Generate_BasicEdits().)
        ''
        ''
        Dim strPathToNotesFolder As String
        Dim strPathToNotesFileTXT As String

        strPathToNotesFolder = DiskFolders.PathToFolder_Notes()
        strPathToNotesFileTXT = DiskFilesVB.PathToNotes_HowContextMenusAreGenerated()
        System.Diagnostics.Process.Start(strPathToNotesFileTXT)

    End Sub ''end of "Public Sub How_Context_Menus_Are_Generated_EE1002(sender As Object, e As EventArgs)"

End Class
