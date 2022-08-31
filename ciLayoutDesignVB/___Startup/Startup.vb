Option Explicit On
Option Strict On
Option Infer On
''
''Added 10/11/2019 td  
''
Imports ciBadgeInterfaces ''Added 10/11/2019 thomas d. 
Imports ciBadgeElements ''Added 10/13/2019 thomas d. 
Imports ciBadgeCustomer ''Added 10/14/2019 thomas d. 
Imports ciBadgeRecipients ''Added 10/16/2019 thomas d.  
Imports ciBadgeRecipientsCS  ''Added 10/16/2019 td
Imports ciPictures_VB ''----Added 10/16/2019 td   
Imports ciBadgeCachePersonality ''Added 12/4/2021 td 

Public Class Startup
    ''
    ''Added 10/11/2019 td    
    ''
    ''Added 5/3/2022 thomas downes 
    Public Shared DefaultFileTitleXML As String = "RSC Design Layout.xml"

    Public Shared ListOfRecipients As List(Of ClassRecipient) ''Added 3/29/2022 thomas d. 

    ''The following False-valued Booleans are an attempt to fix an ambiguity which has 
    ''  been vexing my layout-design development for a long time... namely, the
    ''  ambiguity is as follows....
    ''Do I want all the various types of Elements (e.g. QR code) to be easily
    ''  (i.e. automatically) instantiated (and thus present in the layout design at run-time),
    ''  or would I eventually find it vexing & annoying?
    ''Sometimes I just want to work with a simple, unadorned layout... no bells & whistles.
    ''A related question is, if I finally don't want them to keep appearing incessantly,
    ''  how do I "turn them off" effectively? 
    ''Solution:  The new form FormTypesOfElementsToAdd, and the following
    ''  Boolean constants.-----5/4/2022 td
    ''  -----5/4/2022 td
    Public Const PreloadElementsForDemo As Boolean = False ''Was true "de facto" (effectively).  Added 5/4/2022 thomas 
    Public Const PreloadBackgroundForDemo As Boolean = False ''Was true "de facto" (effectively). Added 5/23/2022 thomas 
    Public Const PreloadRecipientsForDemo As Boolean = False ''Added 8/17/2022 td
    Private Const mc_boolPreloadElements As Boolean = False ''Added 5/3/2022 thomas 


    Public Shared Sub Main()
        ''
        ''Encapsulated 10/13/2019 td  
        ''
        ''2/5/2022 td''OpenLayoutDesigner_Loop()

        Dim bUserWantsToExitApp As Boolean ''Added 2/5/2022 td

        ''Added 5/6/2022 td
        Dim objWelcomeForm As New FormWelcomeNotes
        objWelcomeForm.ShowDialog()

        Do
            OpenLayoutDesigner_Loop(bUserWantsToExitApp)
            If (bUserWantsToExitApp) Then Exit Do
        Loop

        If (bUserWantsToExitApp) Then
            ''Application.AllowQuit = True
            Application.Exit()
            Exit Sub
        End If ''end of ""If (bUserWantsToExitApp) Then""

    End Sub ''Endof "Public Shared Sub Main()"


    Private Shared Sub OpenLayoutDesigner_Loop(ByRef pref_bUserWantsToExitApp As Boolean)
        ''
        ''Added 10/11/2019 td  
        ''Encapsulated 10/13/2019 td
        ''
        Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  
        Dim bNoLoopingBackToLayoutSelector As Boolean ''Added 5/1/2022 td

        ''1/14/2020 td''Dim obj_cache_layout As ClassElementsCache_NotInUse ''Added 10/13/2019 td 
        Dim obj_cache_layout_Elements As ClassElementsCache_Deprecated = Nothing ''Added 10/13/2019 td

        ''1/14/2019 td''Dim obj_personality As New PersonalityCache_NotInUse ''Added 10/17/2019 td  
        Dim obj_personalityRecipsCache As CachePersnltyCnfgLRecips = Nothing ''Dec4 2021'' As ClassPersonalityCache ''Added 10/17/2019 td  
        Dim bNewPersonality As Boolean ''Added 3/31/2022 td 
        Dim strPathToRecipsCacheXML As String = "" ''Added 8/17/2022 td

        ''Added 7/13/2022 td
        Const c_bLoadPersonalityEarly As Boolean = False ''Added 7/13/2022 td
        Const c_bLoadPersonalityLater As Boolean = True ''Added 7/13/2022 td
        If (c_bLoadPersonalityEarly) Then ''Added 7/13/2022 td
            bNewPersonality = boolNewFileXML
            strPathToRecipsCacheXML = "" ''Added 8/17/2022 td
            ''7/16/2022 obj_personality = LoadCachedData_Personality(Nothing, bNewPersonality)
            obj_personalityRecipsCache = LoadCachedData_Personality(Nothing,
                                                         EnumHowToLinkXMLs.DontLinkXMLs, "",
                                                         bNewPersonality,
                                                         strPathToRecipsCacheXML)
        End If ''End of ""If (c_bLoadPersonalityEarly) Then""
        ''
        ''
        ''If we are emphasizing Layout Design, then open up the 
        ''   form which currently demostrates Layout Design the best.  
        ''
        ''
        ''1/5/2022 td ''Dim obj_formToShow As New Form__Main_Demo ''Added 10/11/2019 td

        GroupMoveEvents_Singleton.CountInstances = 0 ''Return to default value. Added 1/5/2022 td
        Dim obj_formToShow_Demo As New Form__Main_Demo ''Added 10/11/2019 td 
        ''5/23/2022 Dim strPathToElementsCacheXML_Input As String = "" ''Added 12/14/2021 td 
        Dim strPathToElementsCacheXML_InputForPart1 As String ''Added 5/23/2022 td
        Dim strPathToElementsCacheXML_OutputOfPart1 As String = "" ''Added 02/09/2022 td 
        Dim strPathToElementsCacheXML_Prior1 As String = "" ''Added 1/25/2022 td 
        Dim strPathToElementsCacheXML_Prior2 As String = "" ''Added 1/25/2022 td 
        Dim strPathToElementsCacheXML_Prior3 As String = "" ''Added 2/09/2022 td 
        ''---Dim strPathToElementsCacheXML_Prior4 As String = "" ''Added 2/09/2022 td 

        Application.DoEvents() ''Allow any latent de-serialization to take place. ---5/10/2022

        ''Conditions added 3/31/2022, loading code added 10/16/2019 td
        If (c_bLoadPersonalityLater) Then
            ''
            ''We will load the personality later in this procedure. Search for the
            ''  constant var. c_bLoadPersonalityLater. ---8/17/2022 td
            ''
        ElseIf (obj_personalityRecipsCache Is Nothing) Then
            ''Added 7/12/2022 td 
            obj_personalityRecipsCache = New CachePersnltyCnfgLRecips
            obj_personalityRecipsCache.ListOfRecipients = LoadData_Recipients_Students()

        ElseIf (obj_personalityRecipsCache.ListOfRecipients Is Nothing) Then
            ''Added 10/16/2019 td 
            obj_personalityRecipsCache.ListOfRecipients = LoadData_Recipients_Students()

        ElseIf (0 = obj_personalityRecipsCache.ListOfRecipients.Count) Then
            ''Added 10/16/2019 td 
            obj_personalityRecipsCache.ListOfRecipients = LoadData_Recipients_Students()

        End If

        ''Added 3/29/2022 td
        If (obj_personalityRecipsCache IsNot Nothing) Then
            ListOfRecipients = obj_personalityRecipsCache.ListOfRecipients
        End If ''End of ""If (obj_personalityRecipsCache IsNot Nothing) Then""

        ''
        ''==================================================================================
        ''Part of 1 of 2.
        ''   Initialize a Customer Cache, or at least a Personality Cache.
        ''==================================================================================
        ''
        ''   (Or, at the very bare minimum, a Badge Layout Cache.)  
        ''
        ''10/13/2019 td''obj_cache_layout = LoadCachedData(obj_formToShow)
        ''1/14/2019 td''obj_cache_layout = LoadCachedData(obj_formToShow, boolNewFileXML)

        Const c_boolStillUsingElementsCache As Boolean = True ''Added 11/30/2021 td
        If (c_boolStillUsingElementsCache) Then
            ''Function called in the line below is suffixed w/ "_Deprecated", but
            ''   it's still in used today.
            ''   ---11/30/2021 td 
            ''
            strPathToElementsCacheXML_InputForPart1 = My.Settings.PathToXML_Saved_ElementsCache ''Added 12/14/2021 
            strPathToElementsCacheXML_Prior1 = My.Settings.PathToSavedXML_Prior1 ''Added 1/25/2022 
            strPathToElementsCacheXML_Prior2 = My.Settings.PathToSavedXML_Prior2 ''Added 1/25/2022 
            strPathToElementsCacheXML_Prior3 = My.Settings.PathToSavedXML_Prior3 ''Added 2/09/2022 
            ''---strPathToElementsCacheXML_Prior4 = My.Settings.PathToSavedXML_Prior4 ''Added 2/09/2022
            ''
            Const c_bAlwaysAllowUserToChooseNew As Boolean = True ''Added 12/20/2021 
            Dim bMissingOrEmptyXML As Boolean
            bMissingOrEmptyXML = DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToElementsCacheXML_InputForPart1)

            If (c_bAlwaysAllowUserToChooseNew Or bMissingOrEmptyXML) Then
                ''
                ''Added 12/19/2021 thomas downes
                ''

                ''Added 5/3/2022 thomas 
                If (bMissingOrEmptyXML) Then
                    ''Let's provide a default name to the XML file. 
                    strPathToElementsCacheXML_InputForPart1 = Startup.DefaultFileTitleXML ''  "RSC Design Layout.xml"
                    strPathToElementsCacheXML_OutputOfPart1 = IO.Path.Combine(DiskFolders.PathToFolder_XML(),
                                                                       Startup.DefaultFileTitleXML)
                    SaveFullPathToFileXML_Settings(strPathToElementsCacheXML_OutputOfPart1)
                    My.Settings.PathToXML_Saved_ElementsCache = strPathToElementsCacheXML_OutputOfPart1
                    My.Settings.Save()
                    bNoLoopingBackToLayoutSelector = True

                Else
                    ''
                    ''Encapsulate Layout-Selection procedure.
                    ''    ----5/3/2022 thomas d.
                    ''
                    ''5/23/2022 LayoutSelectionProcess(obj_cache_layout_Elements,
                    ''                   obj_formToShow_Demo,
                    ''                   strPathToElementsCacheXML_Output,
                    ''                   boolNewFileXML,
                    ''                    pref_bUserWantsToExitApp,
                    ''                    strPathToElementsCacheXML_Input,  ''= "" ''Added 12/14/2021 td 
                    ''                   strPathToElementsCacheXML_Output,
                    ''                    strPathToElementsCacheXML_Prior1, '' = "" ''Added 1/25/2022 td 
                    ''                    strPathToElementsCacheXML_Prior2, '' = "" ''Added 1/25/2022 td 
                    ''                    strPathToElementsCacheXML_Prior3)
                    LayoutSelectionProcess(obj_cache_layout_Elements,
                                       obj_formToShow_Demo,
                                       strPathToElementsCacheXML_OutputOfPart1,
                                       boolNewFileXML,
                                        pref_bUserWantsToExitApp,
                                        strPathToElementsCacheXML_InputForPart1,  ''= "" ''Added 12/14/2021 td 
                                        strPathToElementsCacheXML_Prior1, '' = "" ''Added 1/25/2022 td 
                                        strPathToElementsCacheXML_Prior2, '' = "" ''Added 1/25/2022 td 
                                        strPathToElementsCacheXML_Prior3,
                                        strPathToRecipsCacheXML)

                End If ''End of ""If (bMissingOrEmptyXML) Then ... Else....""

            Else
                ''    ''
                ''    ''We can use the saved XML path to load the cached elements data. ---12/20/2021 td
                ''    ''
                ''Moved below.Dec20 2021---obj_cache_layout_Elements = LoadCachedData_Elements_Deprecated(obj_formToShow, 
                ''       boolNewFileXML, strPathToElementsCacheXML)

            End If ''End of "If (c_bAlwaysAlwaysUserToChooseNew Or DiskFilesVB.IsXMLFileEmpty(strPathToElementsCacheXML)) Then ... Else ..."

            ''
            ''We can use the saved and/or selected XML path to load the cached elements data. 
            ''   Open the cache of elements, through the magic of deserialization.
            ''   ---12/20/2021 td
            ''
            If (obj_cache_layout_Elements Is Nothing) Then
                ''
                ''Open the cache from the XML.
                ''
                obj_cache_layout_Elements = LoadCachedData_Elements_Deprecated(obj_formToShow_Demo,
                                                                               boolNewFileXML,
                                                 strPathToElementsCacheXML_OutputOfPart1)

                ''Added 7/13/2022 td
                If (c_bLoadPersonalityLater) Then ''Added 7/13/2022 td
                    ''
                    ''This is "Later (than Elements cache)" since we have already called the
                    ''  function "LoadCachedData_Elements_Deprecated" above.---7/18/2022
                    ''
                    bNewPersonality = boolNewFileXML ''Added 7/13/2022 td
                    ''P = Personality, PRecips = Recipients collected under a Personality Configuration  
                    Dim strPathToXML_ElementsCache As String ''Added 7/13/2022
                    ''----Aug17 2022---Dim strPathToXML_PRecips As String ''Added 7/13/2022

                    ''Added 7/17/2022 & 7/13/2022 td
                    strPathToXML_ElementsCache = strPathToElementsCacheXML_OutputOfPart1
                    If (strPathToElementsCacheXML_OutputOfPart1 Is Nothing) Then
                        strPathToXML_ElementsCache = strPathToElementsCacheXML_InputForPart1
                    End If

                    ''July15 2022 ''strPathToXML_PRecips = DiskFilesVB.PathToFile_XML_Personality(strPathToXML_ElementsCache)
                    If ("" = strPathToRecipsCacheXML) Then
                        ''Find the "standard" location for the Personality Recipients Cache,
                        ''   which was standard prior to any plans to connect the XML of the
                        ''   Layout to the XML of the Personality Recipients.
                        ''   ----8/17/2022 td
                        strPathToRecipsCacheXML = DiskFilesVB.PathToFile_XML_PersonalityRecipientsCache(EnumHowToLinkXMLs.AutoSubfolders,
                                              True, True, strPathToXML_ElementsCache)
                    End If ''End of ""If ("" = strPathToRecipsCacheXML) Then""

                    ''July15 2022 ''obj_personality = LoadCachedData_Personality(Nothing,
                    ''                     bNewPersonality, strPathToXML_PRecips)
                    obj_personalityRecipsCache = LoadCachedData_Personality(Nothing,
                                           EnumHowToLinkXMLs.AutoSubfolders,
                                           strPathToXML_ElementsCache,
                                           bNewPersonality, strPathToRecipsCacheXML)

                    End If ''End of ""If (c_bLoadPersonalityEarly) Then""

                End If ''End of "If (obj_cache_layout_Elements Is Nothing) Then"

        Else
            ''Function called in the line below was suffixed w/ "_FutureUse"
            ''   today.  ---11/30/2021 td 
            ''7/15/2022 ''obj_personality = LoadCachedData_Personality(obj_formToShow_Demo, boolNewFileXML)
            strPathToElementsCacheXML_InputForPart1 = My.Settings.PathToXML_Saved_ElementsCache ''Added 12/14/2021 
            obj_personalityRecipsCache = LoadCachedData_Personality(obj_formToShow_Demo,
                                  EnumHowToLinkXMLs.AutoSubfolders,
                                 strPathToElementsCacheXML_InputForPart1, boolNewFileXML,
                                 strPathToRecipsCacheXML)

        End If ''end of "If (c_boolStillUsingElementsCache) Then ... Else ..."

        ''Added 8/17/2022 & 10/16/2019 td 
        ''
        ''  Let's double-check that we have Recipients. --8/17/2022
        ''
        If (Startup.PreloadRecipientsForDemo) Then
            If (obj_personalityRecipsCache.ListOfRecipients Is Nothing) Then
                ''Added 8/17/2022 & 10/16/2019 td 
                obj_personalityRecipsCache.ListOfRecipients = LoadData_Recipients_Students()

            ElseIf (0 = obj_personalityRecipsCache.ListOfRecipients.Count) Then
                ''Added 8/17/2022 & 10/16/2019 td 
                obj_personalityRecipsCache.ListOfRecipients = LoadData_Recipients_Students()
            End If
        End If ''End of ""If (Startup.PreloadRecipientsForDemo) Then""

        ''Added 8/17/2022 & 3/29/2022 td
        If (obj_personalityRecipsCache IsNot Nothing) Then
            ListOfRecipients = obj_personalityRecipsCache.ListOfRecipients
        End If ''End of ""If (obj_personalityRecipsCache IsNot Nothing) Then""

        ''Added 11/26/2019 thomas d
        Dim boolTesting As Boolean
        If (boolTesting) Then

            ''Added 12/19/2021 thomas downes
            Dim imageBackground As Image ''Added 12/19/2021 thomas downes
            imageBackground = obj_formToShow_Demo.pictureBackgroundFront.BackgroundImage

            obj_cache_layout_Elements =
                ClassElementsCache_Deprecated.GetLoadedCache("123.xml", True, imageBackground)

        End If ''End of "If (boolTesting) Then"

        ''
        ''============================================================================
        ''Part 2 of 2.
        ''   Prepare the designer form. 
        ''============================================================================
        ''
        Dim strPathToElementsCacheXML_InputForPart2 As String ''Added 5/23/2022 td
        Dim bSubsequentIterationsOfDo As Boolean = False ''Added 5/23/2022 td

        ''Transfer Part 1's output-string to Part 2's input-string.  5/23/2022
        strPathToElementsCacheXML_InputForPart2 = strPathToElementsCacheXML_OutputOfPart1

        obj_formToShow_Demo.NewFileXML = boolNewFileXML
        ''Added 12/14/2021 td
        ''5/23/2022 td obj_formToShow_Demo.ElementsCache_PathToXML = strPathToElementsCacheXML_Output
        obj_formToShow_Demo.ElementsCache_PathToXML = strPathToElementsCacheXML_InputForPart2
        Dim intMessagesDisplayed As Integer ''Added 1/25/2022 td

        ''Not needed. 10/11/2019 td'obj_formToShow.CtlGraphicText1.LayoutFunctions = CType(obj_formToShow., ILayoutFunctions)

        ''10/12/2019 td''obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.

        '-----obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.SigFilePath =
        '-----          DiskFiles.PathToFile_Sig()

        Do
            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
            If (pref_bUserWantsToExitApp) Then Exit Do ''Added 5/3/2022 td

            ''First, let's refresh the path (on subsequent iterations). ---1/14/2022 td
            If (bSubsequentIterationsOfDo) Then
                strPathToElementsCacheXML_InputForPart2 = My.Settings.PathToXML_Saved_ElementsCache ''Added 1/14/2022 
            ElseIf ("" = strPathToElementsCacheXML_InputForPart2) Then
                ''Let the programmer know's there's a potential problem.  ---5/23/2022
                System.Diagnostics.Debugger.Break()
                Exit Do ''Added 8/28/2022 
            End If ''Endof ""If (bSubsequentIterationsOfDo) Then""
            ''
            ''Let's set some fundamental properties of the form. ---1/14/2022 td
            ''
            If (c_boolStillUsingElementsCache) Then ''Added 11/30/2021
                ''
                ''Still in use, even though it's Q4 of 2021. 
                ''
                If (obj_cache_layout_Elements Is Nothing) Then
                    ''Jan25 2022 td''Throw New Exception("Cache Is null/nothing.")
                    MessageBoxTD.Show_Statement("Cache Is null/nothing.")
                    intMessagesDisplayed += 1 ''Added 1/25/2022 td
                    If (intMessagesDisplayed > 5) Then Exit Sub ''Added 1/25/2022 td
                    Continue Do
                End If ''End of "If (obj_cache_layout_Elements Is Nothing) Then"

                obj_formToShow_Demo.ElementsCache_Edits = obj_cache_layout_Elements
                ''Added 12/14/2021 td
                ''5/23/2022 obj_formToShow_Demo.ElementsCache_PathToXML = strPathToElementsCacheXML_Input ''Added 12/14/2021 td 
                obj_formToShow_Demo.ElementsCache_PathToXML = strPathToElementsCacheXML_InputForPart2 ''Modified 5/23/2022

                ''Added 7/12/2022 thomas d.
                With obj_formToShow_Demo
                    If (.PersonalityCache_Recipients Is Nothing) Then
                        ''Added 7/12/2022 thomas d. 
                        .PersonalityCache_Recipients = obj_personalityRecipsCache
                    End If ''End of ""If (.PersonalityCache_Recipients Is Nothing) Then""
                End With ''End of ""With obj_formToShow_Demo""

            Else
                ''
                ''This is for future use, say approaching Spring of 2022. 
                ''  ----11/30/2022 
                ''
                obj_formToShow_Demo.PersonalityCache_Recipients = obj_personalityRecipsCache

            End If ''End of "If (c_boolStillUsingElementsCache) Then ... Else"

            ''
            ''Specify the XML cache file, in the Window caption. ---12/14/2021 td 
            ''
            Dim strPathToXML_FormText As String ''Added 8/28/2022 td
            Dim strFileTitleXML As String ''Added 12/1/4/2021 td

            strPathToXML_FormText = strPathToElementsCacheXML_InputForPart2 ''Added 8/28/2022 td
            If (strPathToXML_FormText Is Nothing) Then
                ''Added 8/28/2022 thomas d 
                obj_formToShow_Demo.Text = String.Format("RSC ID Card - Desktop - Filepath is missing #1")
            Else
                strFileTitleXML = (New IO.FileInfo(strPathToXML_FormText)).Name
                If (strFileTitleXML Is Nothing) Then
                    ''Added 8/28/2022 thomas d 
                    obj_formToShow_Demo.Text = String.Format("RSC ID Card - Desktop - Filepath is missing #2")
                Else
                    obj_formToShow_Demo.Text = String.Format("RSC ID Card - Desktop - {0} - {1}", strFileTitleXML,
                                                     strPathToElementsCacheXML_InputForPart2)
                End If ''End of ""If (strFileTitleXML Is Nothing) Then... Else..."
            End If ''End of ""If (strPathToXML_FormText Is Nothing) Then... Else..."

            ''
            ''Show the main form!!!    Huge!!!! 
            ''
            Try
                obj_formToShow_Demo.ShowDialog() ''Added 10/11/2019 td 
            Catch ex_show As Exception
                System.Diagnostics.Debugger.Break() ''Added 6/13/2022 thomas 
            End Try

            ''Added 12/14/2021 thomas downes
            SaveFullPathToFileXML_Settings(obj_formToShow_Demo.ElementsCache_PathToXML)
            My.Settings.PathToXML_Saved_ElementsCache = obj_formToShow_Demo.ElementsCache_PathToXML
            My.Settings.Save() ''Added 12/14/2021 thomas downes

            ''Added 2/6/2022 td
            If (obj_formToShow_Demo.UserWantsToExitApplication) Then
                pref_bUserWantsToExitApp = True
                Exit Sub ''Exit Do
            ElseIf (bNoLoopingBackToLayoutSelector) Then
                ''Added 5/3/2022 thomas d.
                pref_bUserWantsToExitApp = True
                Exit Sub ''Exit Do
            ElseIf (Not obj_formToShow_Demo.LetsRefresh_CloseForm) Then
                ''The user is NOT refreshing the Layout.  The user 
                ''  wants to exit/quit the current Layout. ---2/6/2022 td
                Exit Do
            End If ''End of "If (obj_formToShow_Demo.UserWantsToExitApplication) Then"

            ''Added 10/13/2019 td
            ''  Due to above code, this is not really needed. But it's
            ''  legacy code. ---2/6/2022 td
            If (Not obj_formToShow_Demo.LetsRefresh_CloseForm) Then Exit Do

            ''Added 1/26/2022 thomas d.
            Dim bRefreshBackside As Boolean ''Added 1/26/2022 thomas d.
            bRefreshBackside = obj_formToShow_Demo.LetsRefresh_CardBackside

            ''12/14/2021''obj_cache_layout_Elements = obj_formToShow.ElementsCache_Saved
            obj_cache_layout_Elements = obj_formToShow_Demo.ElementsCache_ManageBoth.GetCacheForSaving(True)

            GroupMoveEvents_Singleton.CountInstances = 0 ''Refresh to default value. 
            obj_formToShow_Demo = New Form__Main_Demo

            ''Added 1/26/2022 td
            obj_formToShow_Demo.LetsRefresh_CardBackside = bRefreshBackside

            ''
            ''Exit-handler for the current loop iteration.  5/23/2022
            ''
            bSubsequentIterationsOfDo = True ''Prepare for the next iteration. 5/23/2022

            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
        Loop ''This is potentially an infinite loop.  Look for "Exit Do". 


    End Sub ''End of "Public Sub OpenLayoutDesigner_Loop()"


    Private Shared Sub LayoutSelectionProcess(ByRef pref_cache_layout_Elements As ClassElementsCache_Deprecated,
                                              ByVal par_formToShow_Demo As Form__Main_Demo,
                                              ByRef pstrPathToElementsCacheXML_Output As String,
                                              ByRef pref_boolNewFileXML As Boolean,
                                              ByRef pref_bUserWantsToExitApp As Boolean,
                                pstrPathToElementsCacheXML_Input As String,  ''= "" ''Added 12/14/2021 td 
                                pstrPathToElementsCacheXML_Prior1 As String, '' = "" ''Added 1/25/2022 td 
                                pstrPathToElementsCacheXML_Prior2 As String, '' = "" ''Added 1/25/2022 td 
                                pstrPathToElementsCacheXML_Prior3 As String,
                                              ByRef pstrPathToRecipientsCacheXML As String)
        ''
        ''Encapsulated 
        ''
        Dim objFormShowCacheLayouts As New FormDisplayCacheLayouts ''Added 12/19/2021 Thomas Downes
        Dim bGoodChoiceOfXML As Boolean ''Added 12/19/2021 Thomas Downes
        Dim bUserWantsABlankSlate As Boolean ''Added 12/19/2021 td
        Dim bUserCancelled As Boolean ''Added 12/20/2021 td
        Dim bEditedRecipients As Boolean ''Added 4/1/2021 td
        Dim bFirstIteration As Boolean ''Added 3/24/2022 td
        Dim bUserCancelled_OnFirstIteration As Boolean ''Added 3/24/2022 td
        Dim bUserMightWantDefaultCache As Boolean ''Added 3/24/2022 td
        Dim bXMLdoesntHaveData As Boolean ''Added 3/24/2022 td
        Dim bUserMadeSelectionOfLayout As Boolean ''Addd 3/24/2022 td
        Dim bUserCancelledOrClosed As Boolean ''Added 3/24/2022 td
        Dim bUserCancelledOrClosed_FirstIteration As Boolean ''Added 3/24/2022 td
        Dim bUserCancelledOrClosed_SubsequentItertn As Boolean ''Added 3/24/2022 td
        Dim bUserWantsWhatsNext As Boolean ''Added 5/23/2022 thomas downes

        ''Added 12/20/2021 thomas downes
        objFormShowCacheLayouts.PathToLastDirectoryForXMLFile = My.Settings.PathToLastDirectoryForXMLFile

        ''Added 1/22/2022 thomas downes
        objFormShowCacheLayouts.FileTitleOfXMLFile = My.Settings.FileTitleOfXMLFile

        ''Added 3/8/2022 td
        ''---objFormShowCacheLayouts

        bFirstIteration = True ''Added 3/24/2022

        ''
        ''======================================================================================
        ''Part 1 of 2.  Determine correct Boolean values for the Boolean variables listed below. 
        ''  
        ''    ----bGoodChoice As Boolean ''Added 12/19/2021 Thomas Downes
        ''    bUserWantsABlankSlate As Boolean ''Added 12/19/2021 td
        ''    -----bUserCancelled As Boolean ''Added 12/20/2021 td
        ''    bEditedRecipients As Boolean ''Added 4/1/2021 td
        ''    ----bFirstIteration As Boolean ''Added 3/24/2022 td
        ''    ----bUserCancelled_OnFirstIteration As Boolean ''Added 3/24/2022 td
        ''    bUserMightWantDefaultCache As Boolean ''Added 3/24/2022 td
        ''    ----bXMLdoesntHaveData As Boolean ''Added 3/24/2022 td
        ''    bUserMadeSelectionOfLayout As Boolean ''Addd 3/24/2022 td
        ''    ----bUserCancelledOrClosed As Boolean ''Added 3/24/2022 td
        ''
        ''===================================================================================
        ''
        Do
            ''
            ''Loop as many times as the user would like!
            ''
            pstrPathToElementsCacheXML_Input = My.Settings.PathToXML_Saved_ElementsCache ''Added 12/14/2021 
            pstrPathToElementsCacheXML_Prior1 = My.Settings.PathToSavedXML_Prior1 ''Added 1/25/2022 
            pstrPathToElementsCacheXML_Prior2 = My.Settings.PathToSavedXML_Prior2 ''Added 1/25/2022 

            With objFormShowCacheLayouts

                .PathToElementsCacheXML_Input = pstrPathToElementsCacheXML_Input ''Added 12/20/2021 td
                .PathToElementsCacheXML_Prior1 = pstrPathToElementsCacheXML_Prior1 ''Added 1/25/2022 td
                .PathToElementsCacheXML_Prior2 = pstrPathToElementsCacheXML_Prior2 ''Added 1/25/2022 td
                .PathToElementsCacheXML_Prior3 = pstrPathToElementsCacheXML_Prior3 ''Added 2/09/2022 td

                ''
                ''Show the dialog form!!
                ''
                ''Not needed.''.Visible = True ''Added 2/5/2022 thomas downes 
                .ShowDialog()

                ''Feb9 2022 td''strPathToElementsCacheXML = .PathToElementsCacheXML_Input
                pstrPathToElementsCacheXML_Output = .PathToElementsCacheXML_Output

                bUserWantsABlankSlate = .UserChoosesABlankSlate
                bUserMadeSelectionOfLayout = .UserHasSelectedLayout ''Added 3/24/2022

                ''Added 2/5/2022 td
                pref_bUserWantsToExitApp = (.UserWantsToExitApplication)
                If (pref_bUserWantsToExitApp) Then
                    objFormShowCacheLayouts.Dispose() ''Added 5/1/2022
                    Exit Sub ''Added 2/5/2022 td
                End If ''End of ""If (pref_bUserWantsToExitApp) Then""

            End With ''End of "With objFormShowCacheLayouts"

            ''March24 2022''bGoodChoice = (bUserWantsABlankSlate Or (Not DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToElementsCacheXML_Output)))
            ''May 23  2022''bGoodChoiceOfXML = (bUserWantsABlankSlate Or bUserMadeSelectionOfLayout)

            ''Added March24 2022
            bXMLdoesntHaveData = (DiskFilesVB.IsXMLFileMissing_OrEmpty(pstrPathToElementsCacheXML_Output))
            If (bXMLdoesntHaveData) Then
                bGoodChoiceOfXML = False
            Else
                bGoodChoiceOfXML = bUserMadeSelectionOfLayout
            End If ''End of ""If (bXMLdoesntHaveData) Then... Else....""

            bUserCancelled = objFormShowCacheLayouts.UserHasSelectedCancel
            bEditedRecipients = objFormShowCacheLayouts.UserEditedRecipients ''Added 4/1/2022 td
            bUserCancelled_OnFirstIteration = (bUserCancelled And bFirstIteration)
            bUserCancelledOrClosed = (bUserCancelled Or Not (bUserMadeSelectionOfLayout Or bUserWantsABlankSlate))
            bUserCancelledOrClosed_FirstIteration = (bUserCancelledOrClosed And bFirstIteration)
            bUserCancelledOrClosed_SubsequentItertn = (bUserCancelledOrClosed And (Not bFirstIteration))
            ''March24 2022''bUserMightWantDefaultCache = bUserCancelled_OnFirstIteration
            bUserMightWantDefaultCache = bUserCancelledOrClosed_FirstIteration

            ''Added 12/26/2021
            If (bGoodChoiceOfXML And Not bUserCancelled) Then
                ''Added 12/26/2021
                ''---Dim obj_formDemo As New Form__Main_Demo ''Added 12/26/2021 
                pref_cache_layout_Elements = LoadCachedData_Elements_Deprecated(par_formToShow_Demo,
                                                  pref_boolNewFileXML, pstrPathToElementsCacheXML_Output)
                bGoodChoiceOfXML = (pref_cache_layout_Elements IsNot Nothing)
                If (Not bGoodChoiceOfXML) Then objFormShowCacheLayouts.ShowMessageForIllformedXML = True
            End If ''End of "If (bGoodChoiceOfXML And Not bUserCancelled) Then"

            ''Prepare for next iteration.  ---3/24/2022
            bFirstIteration = False
            If (bUserCancelledOrClosed_SubsequentItertn) Then Exit Do ''Exit the Do Loop.---3/24/2022 td

            ''3/24/2022 td''Loop Until (bGoodChoice Or bUserCancelled) ''Dec20 2021''Loop Until (bGoodChoice) 
            ''4/01/2022 td''Loop Until (bGoodChoice Or bUserMightWantDefaultCache) ''Dec20 2021''Loop Until (bGoodChoice)
            ''5/23/2022 Loop Until (bGoodChoice Or bUserMightWantDefaultCache Or bEditedRecipients) ''Dec20 2021''Loop Until (bGoodChoice) 

            ''Added 5/23/2022 td
            bUserWantsWhatsNext = (bUserWantsABlankSlate Or bGoodChoiceOfXML Or
                         bUserMightWantDefaultCache Or bEditedRecipients)

            ''5/23/2022 Loop Until (bGoodChoice Or bUserMightWantDefaultCache Or bEditedRecipients) ''Dec20 2021''Loop Until (bGoodChoice) 

        Loop Until (bUserWantsWhatsNext) ''Added a single Boolean condition 5/23/2022 

        ''
        ''===========================================================================================
        ''Part 2 of 2.  Execute actions based on Boolean values (listed below) which were set above.
        ''
        ''    bUserWantsABlankSlate As Boolean ''Added 12/19/2021 td
        ''    bEditedRecipients As Boolean ''Added 4/1/2021 td
        ''    bUserMightWantDefaultCache As Boolean ''Added 3/24/2022 td
        ''    bUserMadeSelectionOfLayout As Boolean ''Addd 3/24/2022 td
        ''
        ''==========================================================================================
        ''
        ''Added 12/20/2021 td
        ''3/24/2022 td''If (bGoodChoice) Then

        Dim bUserWantsToOpenDesigner As Boolean ''Added 5/23/2022 td  
        bUserWantsToOpenDesigner = (bGoodChoiceOfXML Or bUserWantsABlankSlate Or
                                         bUserMightWantDefaultCache)

        ''5/23/2022 td ''If (bGoodChoice Or bUserWantsABlankSlate Or bUserMightWantDefaultCache) Then
        If (bUserWantsToOpenDesigner) Then

            ''Added 12/20/2021 td
            ''My.Settings.PathToSavedXML_Prior3 = My.Settings.PathToSavedXML_Prior2
            ''My.Settings.PathToSavedXML_Prior2 = My.Settings.PathToSavedXML_Prior1
            ''My.Settings.PathToSavedXML_Prior1 = My.Settings.PathToSavedXML_Last
            ''
            ''With objFormShowCacheLayouts ''Added 1/5/2022 td
            ''    My.Settings.PathToSavedXML_Last = .PathToElementsCacheXML
            ''    My.Settings.PathToLastDirectoryForXMLFile = .PathToLastDirectoryForXMLFile
            ''    My.Settings.PathToXML_Saved_ElementsCache = .PathToElementsCacheXML
            ''End With ''end of "With objFormShowCacheLayouts"
            ''
            ''My.Settings.Save()

            ''5/23/2022 With objFormShowCacheLayouts ''Added 1/5/2022 td
            ''Encapsulated 1/5/2022 td
            ''#1 Feb9 2022''SaveFullPathToFileXML(.PathToElementsCacheXML_Input)
            ''#2 Feb9 2022''SaveFullPathToFileXML(.PathToElementsCacheXML_Output)
            ''#2 Feb9 2022''strPathToElementsCacheXML_Output = .PathToElementsCacheXML_Output

            Dim bPathIsEmpty As Boolean ''Added 2/26/2022 td

            bPathIsEmpty = (String.IsNullOrEmpty(pstrPathToElementsCacheXML_Output))

            If (bPathIsEmpty And bUserWantsABlankSlate) Then ''3/24/22 If (bPathIsEmpty) Then
                ''
                ''Don't try to process a Null string. ---2/23/2022 
                ''
                ''#1 5/23/2022 ''MessageBoxTD.Show_Statement("Great choice!  FYI, your new layout will be " &
                ''             "completely blank at first.  You will be asked to add elements & provide a background image.",
                ''                                    "- ----------CONFUSING/UNUSUAL--------",
                ''                 "Please press OK to specify a name & location for the New layout.")
                ''#2 5/23/2022 MessageBoxTD.Show_Statement("Your new layout will be completely blank at first.  " & vbCrLf_Deux &
                ''             "You will be asked to add elements & provide a background image.")
                ''#2 5/23/2022 MessageBoxTD.Show_Statement("Next, please specify a name & location for the New layout.")

                Dim strFileTitle_Tentative As String ''Added 5/23/2022 td
                Dim strNewLayoutName As String ''Added 5/23/2022 td
                Dim bUserCancelsLayoutName As Boolean = False ''Added 5/23/2022 td

                strNewLayoutName =
                MessageBoxTD.InputBox_Longform("You have selected a blank layout." & vbCrLf_Deux &
                             "Your new layout will be completely blank at first.  " & vbCrLf_Deux &
                             "You will be asked to add elements & provide a background image." & vbCrLf_Deux &
                             "Please specify a name for the New layout.",
                             "Name of ID Card Layout:", 1.0, 1.5, bUserCancelsLayoutName, "")
                If (bUserCancelsLayoutName) Then Exit Sub

                strFileTitle_Tentative = strNewLayoutName ''Added 5/23/2022 td
                ''#3 5/23/2022 MessageBoxTD.Show_Statement("Next, the Save-File dialog will open.",
                ''                            "Please press OK, then specify a location for the New layout.",
                ''                            "(You'll also get another chance to specify the layout name.)")
                MessageBoxTD.Show_StatementLongform("Next...", "Next, the Save-File dialog will open." & vbCrLf_Deux &
                                            "Please press OK, then specify a location for the New layout." & vbCrLf_Deux &
                                            "(You'll see the layout name you gave, at the bottom.)",
                                             1.0, 1.0, False)

                Dim objSaveDialog As New SaveFileDialog ''Added 2/26/2022 td
                Dim strFileTitle_Tentative_XML As String ''Added 5/23/2022 td

                ''Append extension ".xml", but then correct for possible doubling of the extension. ---5/23/2022
                strFileTitle_Tentative_XML = (strFileTitle_Tentative & ".xml")
                ''Remove any possible double-appending, in case the user himself added the extension.---5/23/2022
                strFileTitle_Tentative_XML = Replace(strFileTitle_Tentative_XML,
                                                     (".xml" & ".xml"), ".xml")

                ''Added 2/26/2022 td
                objSaveDialog.Title = "Location of ID Card Layout"
                objSaveDialog.FileName = strFileTitle_Tentative_XML
                objSaveDialog.ShowDialog()
                pstrPathToElementsCacheXML_Output = objSaveDialog.FileName

                ''Added 2/26/2022 td
                ''5/23/2022 If (Not pstrPathToElementsCacheXML_Output.EndsWith(".xml")) Then
                Dim boolMissingExtensionXML As Boolean
                boolMissingExtensionXML = (Not pstrPathToElementsCacheXML_Output.EndsWith(".xml"))
                If (boolMissingExtensionXML) Then
                    pstrPathToElementsCacheXML_Output += ".xml"
                End If ''End of ""If (boolMissingExtensionXML) Then""
                pref_boolNewFileXML = True
                pref_cache_layout_Elements = Nothing

                ''Added 8/17/2022 thomas downes
                If ("" <> pstrPathToRecipientsCacheXML) Then
                    Dim objFormAskAboutRecipsXML As FormSelectRecipientData
                    objFormAskAboutRecipsXML = New FormSelectRecipientData(pstrPathToElementsCacheXML_Output,
                               pstrPathToRecipientsCacheXML)
                    objFormAskAboutRecipsXML.ShowDialog()

                End If ''Endof ""If ("" <> strPathToRecipientsCacheXML) Then""


            ElseIf (Not bPathIsEmpty) Then ''3/24/2022 td
                ''
                ''We have a path to the XML cache.
                ''
                SaveFullPathToFileXML_Settings(pstrPathToElementsCacheXML_Output)
                My.Settings.PathToXML_Saved_ElementsCache = pstrPathToElementsCacheXML_Output
                My.Settings.Save()

            End If ''End of ""If (bPathIsEmpty And bUserWantsABlankSlate) Then"" ... ElseIf ...

            ''5/23/2022 End With ''end of "With objFormShowCacheLayouts"

        End If ''End of "If (bUserWantsToOpenDesigner) Then"


    End Sub ''end of ""Private Shared Sub LayoutSelectionProcess()""


    Private Shared Function LoadCachedData_Customer_FutureUse() As ClassCacheOneCustomersConfigs ''12/13/2021 ''ciBadgeCustomer.ClassCustomerCache
        ''
        ''Added 10/14/2019 thomas d. 
        ''Suffixed "_FutureUse" on 11/30/2021 td
        ''
        ''  Presuming that the Customer has two Personalities, 
        ''  Student & Staff, let's load them both.  
        ''
        Throw New NotImplementedException("Not coded yet.")

    End Function ''End of "Private Shared Function LoadCachedData_Customer"


    Public Shared Function LoadData_Recipients_Students() As List(Of ClassRecipient)
        ''
        ''Added 10/14/2019 thomas d. 
        ''Publicized 12/3/2021 thomas d. 
        ''
        ''  Presuming that the Customer has two Personalities, 
        ''  Student & Staff, let's load the Students.  
        ''
        ''10/16/2019 td''Return ClassRecipient.mod_recipientList

        ''Added 10/16/2019 td
        PictureExamples.PathToFolderOfImages = DiskFolders.PathToFolder_PicExamples

        ''Added 10/16/2019 td
        ''---#1 10/18/2019--PictureExamples.CreateExamplePics_Numbered(10)
        ''----#2 10/18/2019--PictureExamples.CreateExamplePics_Numbered(100)
        ''-----#3 10/18/2019--PictureExamples.CreateExamplePics_Numbered(100, System.Drawing.Imaging.ImageFormat.Bmp)

        Const c_boolCreate100ExamplePics As Boolean = True ''Added 10/16/2019 thomas d
        If (c_boolCreate100ExamplePics) Then
            ''Added 10/16/2019 td
            ''---This is only on my ASUS laptop at home.-----PictureExamples.CreateExamplePics_Numbered(100)
        End If ''End of "If (c_boolCreate100ExamplePics) Then"

        Return RecipientController.mod_recipientList

    End Function ''End of "Private Shared Function LoadData_Recipients_Students"


    Public Shared Function LoadCachedData_Personality(par_designForm_Unused As Form__Main_Demo,
                             ByVal par_HowToLinkXMLs As EnumHowToLinkXMLs,
                             ByVal pstrApplicablePathToElementsCache As String,
                             ByRef pboolNewFileXML As Boolean,
                             Optional ByRef pstrPathToXML As String = "") As CachePersnltyCnfgLRecips ''As ClassPersonalityCache
        ''
        ''Added 1/14/2019 td
        ''Suffixed 11/30/2021 with "_FutureUse".
        ''
        ''---July13 2022---Dim strPathToXML As String = ""
        Dim obj_cache_personality As CachePersnltyCnfgLRecips ''Dec.4, 2021 '' As ClassPersonalityCache
        Dim bSubfolderOfElements As Boolean ''Added 7/16/2022 thomas downes

        ''7/13/2022 td''strPathToXML = DiskFilesVB.PathToFile_XML_Personality
        If (pstrPathToXML = "") Then
            ''7/15/2022 td''pstrPathToXML = DiskFilesVB.PathToFile_XML_Personality
            bSubfolderOfElements = (par_HowToLinkXMLs = EnumHowToLinkXMLs.AutoSubfolders)
            ''Find the "standard" location for the Personality Recipients Cache,
            ''   which was standard prior to any plans to connect the XML of the
            ''   Layout to the XML of the Personality Recipients.
            ''   ----8/17/2022 td
            pstrPathToXML = DiskFilesVB.PathToFile_XML_PersonalityRecipientsCache(
                 par_HowToLinkXMLs,
                 bSubfolderOfElements,
                 bSubfolderOfElements,
                 pstrApplicablePathToElementsCache)
        End If ''End of ""If (pstrPathToXML = "") Then""

        If (pstrPathToXML = "") Then
            pboolNewFileXML = True
            ''7/15/2022 td''pstrPathToXML = DiskFilesVB.PathToFile_XML_PersonalityRecipients(False)
            pstrPathToXML = DiskFilesVB.PathToFile_XML_PersonalityRecipientsCache(
                                EnumHowToLinkXMLs.DontLinkXMLs, False, False, "")
            ''Jan5 2022''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
            ''Jan5 2022''My.Settings.Save()
            SaveFullPathToFileXML_Settings(pstrPathToXML)

        Else
            pboolNewFileXML = (Not System.IO.File.Exists(pstrPathToXML))
        End If ''End of "If (strPathToXML <> "") Then .... Else ..."

        ''
        ''Major call!!
        ''
        If (pboolNewFileXML) Then ''Condition added 10/10/2019 td  
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadFields()
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadFieldElements(pictureBack)
            ''----Me.ElementsCache_Edits.LoadFields()
            ''10/13/2019 td''Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)
            ''----Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)

            ''Added 10/13/2019 td
            obj_cache_personality = New CachePersnltyCnfgLRecips ''Dec.4, 2021 '' New ClassPersonalityCache
            obj_cache_personality.PathToXml_Saved = pstrPathToXML
            ''Added 8/17/2022 td
            obj_cache_personality.PathToXml_Opened = "[new]" ''---pstrPathToXML

            obj_cache_personality.LoadFields()
            ''1/14/2020 td''obj_cache_personality.LoadFieldElements(par_designForm.pictureBack,
            ''                    New BadgeLayoutClass(par_designForm.pictureBack))

        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = pstrPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_personality = New CachePersnltyCnfgLRecips ''Dec4 2021 ''ClassPersonalityCache ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            Const cbVerboseSuccess_False As Boolean = False ''Added 3/28/2022 td

            obj_cache_personality = CType(objDeserialize.DeserializeFromXML(obj_cache_personality.GetType(),
                cbVerboseSuccess_False), CachePersnltyCnfgLRecips) ''Dec4 2021 ''ClassPersonalityCache)

            ''Added 8/17/2022 td
            obj_cache_personality.PathToXml_Opened = objDeserialize.PathToXML

            ''Added 10/12/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LinkElementsToFields()
            ''-----Me.ElementsCache_Edits.LinkElementsToFields()
            ''1/14/2020 td''obj_cache_personality.LinkElementsToFields()

        End If ''End of "If (pboolNewFileXML) Then .... Else ..."

        ''Moved here from Line 292. ---Thomas 11/30/2021 
        Return obj_cache_personality

        ''''-------------------------------------------------------------
        ''''Added 9/19/2019 td
        ''Dim intPicLeft As Integer
        ''Dim intPicTop As Integer
        ''Dim intPicWidth As Integer
        ''Dim intPicHeight As Integer

        ''''Added 9/19/2019 td
        ''With par_designForm
        ''    ''Added 9/19/2019 td
        ''    intPicLeft = .CtlGraphicPortrait_Lady.Left - .ctlBackgroundZoom1.Left
        ''    intPicTop = .CtlGraphicPortrait_Lady.Top - .ctlBackgroundZoom1.Top
        ''    intPicWidth = .CtlGraphicPortrait_Lady.Width
        ''    intPicHeight = .CtlGraphicPortrait_Lady.Height
        ''End With

        ''''-------------------------------------------------------------
        ''''Added 10/14/2019 td
        ''Dim intLeft_QR As Integer
        ''Dim intTop_QR As Integer
        ''Dim intWidth_QR As Integer
        ''Dim intHeight_QR As Integer

        ''''Added 10/14/2019 td
        ''With par_designForm
        ''    ''Added 10/14/2019 td
        ''    intLeft_QR = .CtlGraphicQRCode1.Left - .ctlBackgroundZoom1.Left
        ''    intTop_QR = .CtlGraphicQRCode1.Top - .ctlBackgroundZoom1.Top
        ''    intWidth_QR = .CtlGraphicQRCode1.Width
        ''    intHeight_QR = .CtlGraphicQRCode1.Height
        ''End With

        ''''-------------------------------------------------------------
        ''''Added 10/14/2019 td
        ''Dim intLeft_Sig As Integer
        ''Dim intTop_Sig As Integer
        ''Dim intWidth_Sig As Integer
        ''Dim intHeight_Sig As Integer

        ''''Added 10/14/2019 td
        ''With par_designForm
        ''    ''Added 10/14/2019 td
        ''    intLeft_Sig = .CtlGraphicSignature1.Left - .ctlBackgroundZoom1.Left
        ''    intTop_Sig = .CtlGraphicSignature1.Top - .ctlBackgroundZoom1.Top
        ''    intWidth_Sig = .CtlGraphicSignature1.Width
        ''    intHeight_Sig = .CtlGraphicSignature1.Height
        ''End With

        ''''-------------------------------------------------------------
        ''''Added 10/14/2019 td
        ''Dim strStaticText As String
        ''Dim intLeft_Text As Integer
        ''Dim intTop_Text As Integer
        ''Dim intWidth_Text As Integer
        ''Dim intHeight_Text As Integer

        ''''Added 10/14/2019 td
        ''With par_designForm
        ''    ''Added 10/14/2019 td
        ''    strStaticText = "This Is the same text for everyone."
        ''    intLeft_Text = .CtlGraphicText1.Left - .ctlBackgroundZoom1.Left
        ''    intTop_Text = .CtlGraphicText1.Top - .ctlBackgroundZoom1.Top
        ''    intWidth_Text = .CtlGraphicText1.Width
        ''    intHeight_Text = .CtlGraphicText1.Height
        ''End With


        ''''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
        ''If (pboolNewFileXML) Then
        ''    ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
        ''    ''10/13/2019 td''Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
        ''    obj_cache_personality.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
        ''                                       par_designForm.pictureBack) ''Added 9/19/2019 td

        ''    ''Added 10/14/2019 thomas d. 
        ''    obj_cache_personality.LoadElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
        ''                                       par_designForm.pictureBack) ''Added 10/14/2019 td

        ''    ''Added 10/14/2019 thomas d. 
        ''    obj_cache_personality.LoadElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
        ''                                       par_designForm.pictureBack) ''Added 10/14/2019 td

        ''    ''Added 10/14/2019 thomas d. 
        ''    obj_cache_personality.LoadElement_Text(strStaticText,
        ''                                        intLeft_Text, intTop_Text,
        ''                                        intWidth_Text, intHeight_Text,
        ''                                       par_designForm.pictureBack) ''Added 10/14/2019 td

        ''End If ''End of "If (pboolNewFileXML) Then"

        ''Added 9/24/2019 thomas 
        ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        ''Moved above 11/30/2021 td''Return obj_cache_personality

    End Function ''End of "Private Sub LoadCachedData_Personality()"

    Public Shared Function LoadCachedData_Elements_Deprecated(par_designForm As Form__Main_Demo,
                                           ByRef pboolNewFileXML As Boolean,
                                           Optional ByRef pstrPathToElementsCacheXML As String = "") As ClassElementsCache_Deprecated

        ''1/24 td''Private Shared Function LoadCachedData(par_designForm As FormDesignProtoTwo,
        ''1/24 td''            ByRef pboolNewFileXML As Boolean) As ClassElementsCache_NotInUse
        ''
        ''Publicized 11/30/2021 thomas downes
        ''
        ''Added 10/13/2019 td
        ''
        ''Added 10/10/2019 td
        ''
        Dim strPathToXML As String = ""
        ''---Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  
        Dim obj_cache_elements As ClassElementsCache_Deprecated ''Added 10/10/2019 td

        ''Added 10/10/2019 td
        ''  10/13/2019 td''strPathToXML = My.Settings.PathToXML_Saved
        ''  1/14/2020''strPathToXML = DiskFiles.PathToFile_XML_ElementsCache

        ''Dec14 2021 td''strPathToXML = DiskFilesVB.PathToFile_XML_ElementsCache

        ''Added 12/14/2021 td
        If (pstrPathToElementsCacheXML <> "") Then

            If (IO.File.Exists(pstrPathToElementsCacheXML)) Then
                strPathToXML = pstrPathToElementsCacheXML ''Allow the parameter to override.
            ElseIf (pboolNewFileXML) Then
                ''It's a new file, so we shouldn't expect it to exist already. ---2/26/2022 td
                strPathToXML = pstrPathToElementsCacheXML ''Allow the parameter to override.
            Else
                strPathToXML = DiskFilesVB.PathToFile_XML_ElementsCache
            End If ''End of ""If (IO.File.Exists(pstrPathToElementsCacheXML)) Then .... ElseIf (pboolNewFileXML)... Else...."

        ElseIf ("" <> My.Settings.PathToXML_Saved_ElementsCache) Then ''Added 12/14/2021 td
            ''Added 12/14/2021 td
            strPathToXML = My.Settings.PathToXML_Saved_ElementsCache
        Else
            strPathToXML = DiskFilesVB.PathToFile_XML_ElementsCache()

        End If ''end of "If (pstrPathToElementsCacheXML <> "") Then ... Else ..."

        If (strPathToXML = "") Then
            pboolNewFileXML = True
            ''10/12/2019 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            ''1/14/2030 td''strPathToXML = DiskFiles.PathToFile_XML
            strPathToXML = DiskFilesVB.PathToFile_XML_ElementsCache
            ''Jan5 2022''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
            ''Jan5 2022''My.Settings.Save()
            SaveFullPathToFileXML_Settings(strPathToXML)

            ''Added 12/14/2021 td
            pstrPathToElementsCacheXML = strPathToXML

        Else
            pboolNewFileXML = (Not System.IO.File.Exists(strPathToXML))

            ''Added 12/19/2021 thomas downes
            Dim strTextOfFile As String
            If (pboolNewFileXML) Then
                ''No need to check the text of the file, since the file doesn't even exist yet! ---2/26/2022
            Else
                strTextOfFile = IO.File.ReadAllText(strPathToXML)
                If (String.IsNullOrEmpty(strTextOfFile)) Then pboolNewFileXML = True
            End If ''End of "If (pboolNewFileXML) Then ,,,, Else ..."

        End If ''End of "If (strPathToXML <> "") Then .... Else ..."

        ''
        ''Major call!!
        ''
        If (pboolNewFileXML) Then ''Condition added 10/10/2019 td  
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadFields()
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadFieldElements(pictureBack)
            ''----Me.ElementsCache_Edits.LoadFields()
            ''10/13/2019 td''Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)
            ''----Me.ElementsCache_Edits.LoadFieldElements(pictureBack, BadgeLayout)

            ''Added 10/13/2019 td
            obj_cache_elements = New ClassElementsCache_Deprecated
            obj_cache_elements.PathToXml_Saved = strPathToXML
            obj_cache_elements.SaveToXML() ''Save to an XML file right away.--Added 5/5/2022 td

            ''Added 12/20/2021 td
            ''My.Settings.PathToSavedXML_Prior3 = My.Settings.PathToSavedXML_Prior2
            ''My.Settings.PathToSavedXML_Prior2 = My.Settings.PathToSavedXML_Prior1
            ''My.Settings.PathToSavedXML_Prior1 = My.Settings.PathToSavedXML_Last
            ''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
            ''My.Settings.PathToSavedXML_Last = strPathToXML
            ''My.Settings.Save()
            SaveFullPathToFileXML_Settings(strPathToXML)

            ''Added 12/12/2021 td
            With obj_cache_elements
                .Id_GUID = New Guid()
                .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6)
            End With

            ''
            ''Load the field objects.  ---Commented 5/5/2022
            ''
            obj_cache_elements.LoadFields()

            ''Double-check that all the fields have been added.
            ''  ----5/5/2022 td
            Dim objManager As New ClassCacheManagement(obj_cache_elements, False, strPathToXML)
            objManager.CheckForMissingFields_AllOfThem()

            ''5/3/2022 td''obj_cache_elements.LoadFieldElements(par_designForm.pictureBackgroundFront,
            ''5/3/2022 td''   New BadgeLayoutClass(par_designForm.pictureBackgroundFront))
            If (mc_boolPreloadElements) Then
                ''Pre-load elements. Not really great for users who probably want
                ''  to start with a blank canvas.  Plus, the new dialog
                ''  called FormTypeOfElementsToAdd is a great alternative.
                ''  ----5/3/2022 td
                obj_cache_elements.LoadFieldElements(par_designForm.pictureBackgroundFront,
                            New BadgeLayoutDimensionsClass(par_designForm.pictureBackgroundFront))
            End If ''End of ""If (mc_boolPreloadElements) Then""

        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = strPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_elements = New ClassElementsCache_Deprecated ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            ClassElementsCache_Deprecated.DeserializationCompleted = False ''Added 5/10/2022

            obj_cache_elements = CType(objDeserialize.DeserializeFromXML(obj_cache_elements.GetType(), False), ClassElementsCache_Deprecated)

            ClassElementsCache_Deprecated.DeserializationCompleted = True ''Added 5/10/2022

            ''Added 12/26/2021 thomas d.
            If (obj_cache_elements Is Nothing) Then Return Nothing

            ''Added 10/12/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LinkElementsToFields()
            ''-----Me.ElementsCache_Edits.LinkElementsToFields()
            obj_cache_elements.Check_LinkElementsToFields()

            ''
            ''Added 1/14/2022 thomas downes
            ''
            ''========================================================================
            ''QR Code
            ''========================================================================
            ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
            ''We are making a transition, from the older cache property ElementQRCode,
            ''  toward the new cache property of ListOfElementQRCodes_Back.
            ''We are looking for the non-null object, if it exists. 
            ''========================================================================
            ''Let's drop the QR Code element-object into a List. ----1/14/2022 td
            ''========================================================================
            With obj_cache_elements
                ''Let's transfer the QRCode to the new ListOfElement... Public Property.

                ''Per ____ the property .ElementQR_RefCopy has been eliminated. ---1/19/2022 td
                ''
                ''____If (0 = .ListOfElementQRCodes_Front.Count) Then
                ''____    If (.ElementQR_RefCopy IsNot Nothing) Then
                ''____        .ListOfElementQRCodes_Front.Add(.ElementQR_RefCopy)
                ''____    End If
                ''____End If ''End of "If (0 = .ListOfElementQRCodes_Front.Count) Then"

                ''____If (.ElementQR_RefCopy Is Nothing) Then
                ''____    .ElementQR_RefCopy = .ListOfElementQRCodes_Front.FirstOrDefault()
                ''____    If (.ElementQR_RefCopy Is Nothing) Then
                ''____        ''Next, try the Backside. 
                ''____        .ElementQR_RefCopy = .ListOfElementQRCodes_Back.FirstOrDefault()
                ''____    End If ''eND OF "If (.ElementQRCode Is Nothing) Then"
                ''____End If

                ''''Let's try to populate the .Image_BL property. ----1/14/2022 td
                ''____If (.ElementQR_RefCopy IsNot Nothing) Then
                ''____    If (.ElementQR_RefCopy.Image_BL Is Nothing) Then
                ''____        .ElementQR_RefCopy.Image_BL = My.Resources.QR_Code_Example
                ''____    End If
                ''____End If ''End of "If (.ElementQRCode IsNot Nothing) Then"

            End With ''End of "With obj_cache_elements"

            ''========================================================================
            ''Signature
            ''========================================================================
            ''     !!!!!!!!!!!! DIFFICULT & CONFUSING !!!!!!!!!!!!
            ''We are making a transition, from the older cache property ElementSignature,
            ''  toward the new cache property of ListOfElementSignatures_Back.
            ''We are looking for the non-null object, if it exists.  ---1/14/2022 td
            ''========================================================================
            ''Let's drop the Signature element-object into a List. ----1/14/2022 td 
            ''========================================================================
            With obj_cache_elements
                ''Let's transfer the Signature to the new ListOfElement... Public Property.

                ''Per ____ the property .ElementSig_RefCopy has been eliminated. ---1/19/2022 td
                ''
                ''____If (0 = .ListOfElementSignatures_Front.Count) Then
                ''____    If (.ElementSig_RefCopy IsNot Nothing) Then
                ''____        .ListOfElementSignatures_Front.Add(.ElementSig_RefCopy)
                ''____    End If
                ''____End If ''End of "If (0 = .ListOfElementSignatures_Front.Count) Then"

                ''____If (.ElementSig_RefCopy Is Nothing) Then
                ''____    .ElementSig_RefCopy = .ListOfElementSignatures_Front.FirstOrDefault()
                ''____    If (.ElementSig_RefCopy Is Nothing) Then
                ''____       ''Next, try the Backside. 
                ''____        .ElementSig_RefCopy = .ListOfElementSignatures_Back.FirstOrDefault()
                ''____    End If ''eND OF "If (.ElementSignature Is Nothing) Then"
                ''____End If

                ''''Let's try to populate the .Image_BL property. ----1/14/2022 td
                ''____If (.ElementSig_RefCopy IsNot Nothing) Then
                ''____    If (.ElementSig_RefCopy.Image_BL Is Nothing) Then
                ''____        .ElementSig_RefCopy.Image_BL = My.Resources.Declaration_Sig_JPG
                ''____    End If
                ''____End If ''End of "If (.ElementSignature IsNot Nothing) Then"

            End With ''End of "With obj_cache_elements"

        End If ''End of "If (pboolNewFileXML) Then .... Else ..."

        ''-------------------------------------------------------------
        ''Added 9/19/2019 td
        Static intLeft_Portrait As Integer
        Static intTop_Portrait As Integer
        Static intWidth_Portrait As Integer
        Static intHeight_Portrait As Integer
        Static bDone_Portrait As Boolean ''Added 1/17/2022 td

        If (Not bDone_Portrait) Then ''Added 1/17/2022 td
            ''Added 9/19/2019 td
            With par_designForm
                ''Added 9/19/2019 td
                intLeft_Portrait = .CtlGraphicPortrait_Lady.Left - .pictureBackgroundFront.Left
                intTop_Portrait = .CtlGraphicPortrait_Lady.Top - .pictureBackgroundFront.Top
                intWidth_Portrait = .CtlGraphicPortrait_Lady.Width
                intHeight_Portrait = .CtlGraphicPortrait_Lady.Height
            End With
            bDone_Portrait = True ''Added 1/17/2022 td
        End If ''End of "If (Not bDone_Portrait) Then"

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Static intLeft_QR As Integer
        Static intTop_QR As Integer
        Static intWidth_QR As Integer
        Static intHeight_QR As Integer
        Static bDone_QRCode As Boolean ''Added 1/17/2022 td

        If (Not bDone_QRCode) Then ''Added 1/17/2022 td
            ''Added 10/14/2019 td
            With par_designForm
                ''Added 10/14/2019 td
                intLeft_QR = .CtlGraphicQRCode1.Left - .pictureBackgroundFront.Left
                intTop_QR = .CtlGraphicQRCode1.Top - .pictureBackgroundFront.Top
                intWidth_QR = .CtlGraphicQRCode1.Width
                intHeight_QR = .CtlGraphicQRCode1.Height
            End With
            bDone_QRCode = True ''Added 1/17/2022 td
        End If ''End of "If (Not bDone_QRCode) Then"

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Static intLeft_Signature As Integer
        Static intTop_Signature As Integer
        Static intWidth_Signature As Integer
        Static intHeight_Signature As Integer
        Static bDone_Signature As Boolean ''Added 1/17/2022 td

        If (Not bDone_Signature) Then ''Added 1/17/2022 td
            ''Added 10/14/2019 td
            With par_designForm
                ''Added 10/14/2019 td
                intLeft_Signature = .CtlGraphicSignature1.Left - .pictureBackgroundFront.Left
                intTop_Signature = .CtlGraphicSignature1.Top - .pictureBackgroundFront.Top
                intWidth_Signature = .CtlGraphicSignature1.Width
                intHeight_Signature = .CtlGraphicSignature1.Height
            End With
            bDone_Signature = True ''Added 1/17/2022 td
        End If ''End of "If (Not bDone_Signature) Then"

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Dim strStaticText As String
        Static intLeft_StaticText As Integer
        Static intTop_StaticText As Integer
        Static intWidth_StaticText As Integer
        Static intHeight_StaticText As Integer
        Static bDone_StaticText As Boolean ''Added 1/17/2022 td

        If (Not bDone_StaticText) Then ''Added 1/17/2022 td
            ''Added 10/14/2019 td
            With par_designForm
                ''Added 10/14/2019 td
                strStaticText = "This is the same text for everyone."
                intLeft_StaticText = .CtlGraphicStaticText1.Left - .pictureBackgroundFront.Left
                intTop_StaticText = .CtlGraphicStaticText1.Top - .pictureBackgroundFront.Top
                intWidth_StaticText = .CtlGraphicStaticText1.Width
                intHeight_StaticText = .CtlGraphicStaticText1.Height
            End With
            bDone_StaticText = True ''Added 1/17/2022 td
        End If ''End of "If (Not bDone_StaticText) Then"


        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
        ''5/04/2022 td''If (pboolNewFileXML) Then  
        If (pboolNewFileXML And mc_boolPreloadElements) Then

            ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            obj_cache_elements.LoadNewElement_Pic(intLeft_Portrait, intTop_Portrait, intWidth_Portrait, intHeight_Portrait,
                                               par_designForm.pictureBackgroundFront,
                                               EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td

            ''Added 10/14/2019 thomas d. 
            obj_cache_elements.LoadNewElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
                                               par_designForm.pictureBackgroundFront,
                                               EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

            ''Added 10/14/2019 thomas d. 
            obj_cache_elements.LoadNewElement_Signature(intLeft_Signature, intTop_Signature,
                                                     intWidth_Signature, intHeight_Signature,
                                               par_designForm.pictureBackgroundFront,
                                               EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

            ''Added 10/14/2019 thomas d. 
            ''Jan19 2022''obj_cache_elements.LoadElement_StaticText_IfNeeded(strStaticText,
            strStaticText = "This is the same text for everyone."
            obj_cache_elements.LoadNewElement_StaticTextV3(strStaticText,
                                                intLeft_StaticText, intTop_StaticText,
                                                intWidth_StaticText, intHeight_StaticText,
                                               par_designForm.pictureBackgroundFront,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

        End If ''End of "If (pboolNewFileXML And mc_boolPreloadElements) Then"

        ''Added 9/24/2019 thomas 
        ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        ''Added 11/30/2021 thomas downes
        ''Dec12 2021''obj_cache_elements.Id_GUID = New Guid() ''Generates a new & unique ID.
        With obj_cache_elements
            .Id_GUID = New Guid() ''Generates a new GUID. 
            .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6) ''Added 12/12/2021  
        End With ''eND OF "With obj_cache_elements"

        Return obj_cache_elements

    End Function ''End of "Public Sub LoadCachedData_Elements_Deprecated()"


    Public Shared Sub SaveFullPathToFileXML_Settings(par_pathToElementsCacheXML As String)
        ''Feb9 2022 td''Public Shared Sub SaveFullPathToFileXML
        ''
        ''Added 1/5/2022 td
        ''
        Dim bSaveNewXMLPath As Boolean ''Added 1/25/2022 thomas downes

        ''Added 2/23/2022 td
        If (String.IsNullOrEmpty(par_pathToElementsCacheXML)) Then
            ''Added 2/23/2022 td
            Throw New ArgumentException("Null argument1")

        End If ''End of "If (String.IsNullOrEmpty(par_pathToElementsCacheXML)) Then"

        ''Added 12/20/2021 td
        With My.Settings
            bSaveNewXMLPath = (.PathToSavedXML_Last <> par_pathToElementsCacheXML) ''Added 1/25/2022 td
            If (bSaveNewXMLPath) Then ''Added 1/25/2022 td
                .PathToSavedXML_Prior3 = .PathToSavedXML_Prior2
                .PathToSavedXML_Prior2 = .PathToSavedXML_Prior1
                .PathToSavedXML_Prior1 = .PathToSavedXML_Last
            End If ''End of "If (bSaveNewXMLPath) Then"
        End With

        ''With objFormShowCacheLayouts ''Added 1/5/2022 td
        With My.Settings
            .PathToSavedXML_Last = par_pathToElementsCacheXML
            .PathToXML_Saved_ElementsCache = par_pathToElementsCacheXML
        End With
        ''End With ''end of "With objFormShowCacheLayouts"

        ''----My.Settings.PathToLastDirectoryForXMLFile = .PathToLastDirectoryForXMLFile

        Dim objFileInfo As New IO.FileInfo(par_pathToElementsCacheXML)

        My.Settings.PathToLastDirectoryForXMLFile = objFileInfo.DirectoryName
        ''Added 1/22/2022 td
        My.Settings.FileTitleOfXMLFile = objFileInfo.Name ''Added 1/22/2022 td

        My.Settings.Save() ''Added 1/7/2022 td

    End Sub ''End of "Public Shared Sub SaveFullPathToFileXML_Settings()"


    Public Shared Function GuidIsFine(par_guid As Guid) As Boolean
        ''
        ''Added 2/18/2022 td
        ''
        Dim bDoneGuid As Boolean ''Added 2/18/2022 td
        bDoneGuid = String.IsNullOrEmpty(par_guid.ToString()) = False _
                AndAlso (par_guid.ToString().StartsWith("00000000") = False)
        Return bDoneGuid

    End Function


End Class ''end of Public Class Startup
