﻿Option Explicit On
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
Imports ciBadgeSerialize ''Added 1/07/2022 td 

Public Class Startup
    ''
    ''Added 10/11/2019 td    
    ''
    Public Shared Sub Main()

        Dim objFormToShow = New FormFieldsAndPortrait ''Added 1/15/2022

        ''Encapsulated 10/13/2019 td  
        ''1/15/2022 td''OpenLayoutDesigner_Loop()
        OpenLayoutDesigner_Loop(objFormToShow)

    End Sub ''Endof "Public Shared Sub Main()"

    Private Shared Sub OpenLayoutDesigner_Loop(par_formToShow As IDesignerForm)
        ''
        ''Added 10/11/2019 td  
        ''Encapsulated 10/13/2019 td
        ''
        Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  

        ''1/14/2020 td''Dim obj_cache_layout As ClassElementsCache_NotInUse ''Added 10/13/2019 td 
        Dim obj_cache_layout_Elements As ClassElementsCache_Deprecated = Nothing ''Added 10/13/2019 td

        ''1/14/2019 td''Dim obj_personality As New PersonalityCache_NotInUse ''Added 10/17/2019 td  
        ''12/2022 Dim obj_personality As New ClassCacheOnePersonalityConfig ''Dec4 2021'' As ClassPersonalityCache ''Added 10/17/2019 td  
        Dim obj_personality As New CachePersnltyCnfgLRecips ''Dec4 2021'' As ClassPersonalityCache ''Added 10/17/2019 td  

        ''
        ''
        ''If we are emphasizing Layout Design, then open up the 
        ''   form which currently demostrates Layout Design the best.  
        ''
        ''
        ''1/5/2022 td ''Dim obj_formToShow As New FormFieldsAndPortrait ''Added 10/11/2019 td

        GroupMoveEvents_Singleton.CountInstances = 0 ''Return to default value. Added 1/5/2022 td

        ''#1 1/15/2022 td''Dim obj_formToShow As new FormFieldsAndPortrait ''Added 10/11/2019 td 
        Dim obj_formToShow As IDesignerForm ''1/15/2022 td''FormFieldsAndPortrait ''Added 10/11/2019 td 
        obj_formToShow = par_formToShow

        Dim strPathToElementsCacheXML As String ''Added 12/14/2021 td 

        ''Added 10/16/2019 td 
        obj_personality.ListOfRecipients = LoadData_Recipients_Students()

        ''
        ''Initialize a Customer Cache, or at least a Personality Cache.
        ''
        ''   (Or, at the very bare minimum, a Badge Layout Cache.)  
        ''
        ''10/13/2019 td''obj_cache_layout = LoadCachedData(obj_formToShow)
        ''1/14/2019 td''obj_cache_layout = LoadCachedData(obj_formToShow, boolNewFileXML)

        Const c_boolStillUsingElementsCache As Boolean = True ''Added 11/30/2021 td
        If (c_boolStillUsingElementsCache) Then
            ''Function called in the line below is suffixed w/ "_Deprecated", but
            ''   it's still in used today.  ---11/30/2021 td 
            strPathToElementsCacheXML = My.Settings.PathToXML_Saved_ElementsCache ''Added 12/14/2021 
            Const c_bAlwaysAllowUserToChooseNew As Boolean = True ''Added 12/20/2021 
            Dim bMissingOrEmptyXML As Boolean
            bMissingOrEmptyXML = DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToElementsCacheXML)

            If (c_bAlwaysAllowUserToChooseNew Or bMissingOrEmptyXML) Then
                ''
                ''Added 12/19/2021 thomas downes
                ''
                Dim objFormShowCacheLayouts As New FormDisplayCacheLayouts ''Added 12/19/2021 Thomas Downes
                Dim bGoodChoice As Boolean ''Added 12/19/2021 Thomas Downes
                Dim bUserWantsABlankSlate As Boolean ''Added 12/19/2021 td
                Dim bUserCancelled As Boolean ''Added 12/20/2021 td

                ''Added 12/20/2021 thomas downes
                objFormShowCacheLayouts.PathToLastDirectoryForXMLFile = My.Settings.PathToLastDirectoryForXMLFile

                Do
                    objFormShowCacheLayouts.PathToElementsCacheXML = strPathToElementsCacheXML ''Added 12/20/2021 td
                    objFormShowCacheLayouts.ShowDialog()
                    strPathToElementsCacheXML = objFormShowCacheLayouts.PathToElementsCacheXML
                    bUserWantsABlankSlate = objFormShowCacheLayouts.UserChoosesABlankSlate
                    bGoodChoice = (bUserWantsABlankSlate Or (Not DiskFilesVB.IsXMLFileMissing_OrEmpty(strPathToElementsCacheXML)))
                    bUserCancelled = objFormShowCacheLayouts.UserHasSelectedCancel

                    ''Added 12/26/2021
                    If (bGoodChoice And Not bUserCancelled) Then
                        ''Added 12/26/2021
                        ''---Dim obj_formDemo As New FormFieldsAndPortrait ''Added 12/26/2021 
                        obj_cache_layout_Elements = LoadCachedData_Elements_Deprecated(obj_formToShow,
                                                               boolNewFileXML, strPathToElementsCacheXML)
                        bGoodChoice = (obj_cache_layout_Elements IsNot Nothing)
                        If (Not bGoodChoice) Then objFormShowCacheLayouts.ShowMessageForIllformedXML = True
                    End If ''End of "If (bGoodChoice And Not bUserCancelled) Then"

                Loop Until (bGoodChoice Or bUserCancelled) ''Dec20 2021''Loop Until (bGoodChoice) 

                ''Added 12/20/2021 td
                If (bGoodChoice) Then

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

                    With objFormShowCacheLayouts ''Added 1/5/2022 td
                        ''Encapsulated 1/5/2022 td
                        SaveFullPathToFileXML(.PathToElementsCacheXML)

                    End With ''end of "With objFormShowCacheLayouts"

                End If ''End of "If (bGoodChoice) Then"

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
                ''Open the cache from the XML. 
                obj_cache_layout_Elements = LoadCachedData_Elements_Deprecated(obj_formToShow, boolNewFileXML,
                   strPathToElementsCacheXML)
            End If ''End of "If (obj_cache_layout_Elements Is Nothing) Then"

        Else
            ''Function called in the line below was suffixed w/ "_FutureUse"
            ''   today.  ---11/30/2021 td 
            obj_personality = LoadCachedData_Personality_FutureUse(obj_formToShow, boolNewFileXML)
        End If ''end of "If (c_boolStillUsingElementsCache) Then ... Else ..."

        ''Added 11/26/2019 thomas d
        Dim boolTesting As Boolean
        If (boolTesting) Then

            ''Added 12/19/2021 thomas downes
            Dim imageBackground As Image ''Added 12/19/2021 thomas downes
            imageBackground = obj_formToShow.MyPictureBackgroundFront.BackgroundImage

            obj_cache_layout_Elements =
                ClassElementsCache_Deprecated.GetLoadedCache("123.xml", True, imageBackground)

        End If ''End of "If (boolTesting) Then"

        ''
        ''Prepare the designer form. 
        ''
        obj_formToShow.NewFileXML = boolNewFileXML
        ''Added 12/14/2021 td
        obj_formToShow.ElementsCache_PathToXML = strPathToElementsCacheXML

        ''Not needed. 10/11/2019 td'obj_formToShow.CtlGraphicText1.LayoutFunctions = CType(obj_formToShow., ILayoutFunctions)

        ''10/12/2019 td''obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.

        '-----obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.SigFilePath =
        '-----          DiskFiles.PathToFile_Sig()

        Do
            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
            If (c_boolStillUsingElementsCache) Then ''Added 11/30/2021
                ''
                ''Still in use, even though it's Q4 of 2021. 
                ''
                If (obj_cache_layout_Elements Is Nothing) Then Throw New Exception("Cache is null/nothing.")

                obj_formToShow.ElementsCache_Edits = obj_cache_layout_Elements
                ''Added 12/14/2021 td
                obj_formToShow.ElementsCache_PathToXML = strPathToElementsCacheXML ''Added 12/14/2021 td 

            Else
                ''
                ''This is for future use, say approaching Spring of 2022. 
                ''  ----11/30/2022 
                ''
                obj_formToShow.PersonalityCache_Recipients = obj_personality

            End If ''End of "If (c_boolStillUsingElementsCache) Then ... Else"

            ''
            ''Specify the XML cache file, in the Window caption. ---12/14/2021 td 
            ''
            Dim strFileTitleXML As String ''Added 12/1/4/2021 td
            strFileTitleXML = (New IO.FileInfo(strPathToElementsCacheXML)).Name
            obj_formToShow.MyText = String.Format("RSC ID Card - Desktop - {0} - {1}",
                                                strFileTitleXML, strPathToElementsCacheXML)


            ''
            ''Show the main form!!!    Huge!!!! 
            ''
            obj_formToShow.ShowForm_AsDialog() ''Added 10/11/2019 td 

            ''Added 12/14/2021 thomas downes
            My.Settings.PathToXML_Saved_ElementsCache = obj_formToShow.ElementsCache_PathToXML
            My.Settings.Save() ''Added 12/14/2021 thomas downes

            ''Added 10/13/2019 td
            If (Not obj_formToShow.LetsRefresh_CloseForm) Then Exit Do

            ''12/14/2021''obj_cache_layout_Elements = obj_formToShow.ElementsCache_Saved
            obj_cache_layout_Elements = obj_formToShow.ElementsCache_ManageBoth.GetCacheForSaving(True)

            GroupMoveEvents_Singleton.CountInstances = 0 ''Refresh to default value. 
            obj_formToShow = New FormFieldsAndPortrait

            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
        Loop

    End Sub ''End of "Public Sub OpenLayoutDesigner_Loop()"

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


    Public Shared Function LoadCachedData_Personality_FutureUse(par_designForm As IDesignerForm,
                             ByRef pboolNewFileXML As Boolean) As CachePersnltyCnfgLRecips ''As ClassPersonalityCache
        ''1/15/2022 td''Public Shared Function LoadCachedData_Personality_FutureUse(par_designForm As FormFieldsAndPortrait
        ''
        ''Added 1/14/2019 td
        ''Suffixed 11/30/2021 with "_FutureUse".
        ''
        Dim strPathToXML As String = ""
        ''12/8/2022 Dim obj_cache_personality As ClassCacheOnePersonalityConfig ''Dec.4, 2021 '' As ClassPersonalityCache
        Dim obj_cache_personality As CachePersnltyCnfgLRecips ''As ClassCacheOnePersonalityConfig ''Dec.4, 2021 '' As ClassPersonalityCache

        strPathToXML = DiskFilesVB.PathToFile_XML_Personality

        If (strPathToXML = "") Then
            pboolNewFileXML = True
            strPathToXML = DiskFilesVB.PathToFile_XML_Personality
            ''Jan5 2022''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
            ''Jan5 2022''My.Settings.Save()
            SaveFullPathToFileXML(strPathToXML)

        Else
            pboolNewFileXML = (Not System.IO.File.Exists(strPathToXML))
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
            obj_cache_personality = New CachePersnltyCnfgLRecips ''12/2022 = New ClassCacheOnePersonalityConfig ''Dec.4, 2021 '' New ClassPersonalityCache
            obj_cache_personality.PathToXml_Saved = strPathToXML

            obj_cache_personality.LoadFields()
            ''1/14/2020 td''obj_cache_personality.LoadFieldElements(par_designForm.pictureBack,
            ''                    New BadgeLayoutClass(par_designForm.pictureBack))

        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = strPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            ''12/2022 obj_cache_personality = New ClassCacheOnePersonalityConfig ''Dec4 2021 ''ClassPersonalityCache ''This may or may not be completely necessary,
            obj_cache_personality = New CachePersnltyCnfgLRecips ''Dec4 2021 ''ClassPersonalityCache ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            obj_cache_personality = CType(objDeserialize.DeserializeFromXML(obj_cache_personality.GetType(), False),
                CachePersnltyCnfgLRecips) ''12/2022  ClassCacheOnePersonalityConfig) ''Dec4 2021 ''ClassPersonalityCache)

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
        ''    strStaticText = "This is the same text for everyone."
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

    Public Shared Function LoadCachedData_Elements_Deprecated(par_designForm As IDesignerForm,
                                           ByRef pboolNewFileXML As Boolean,
                                           Optional ByRef pstrPathToElementsCacheXML As String = "") As ClassElementsCache_Deprecated
        ''1/15/2022 td ''Public Shared Function LoadCachedData_Elements_Deprecated(par_designForm As FormFieldsAndPortrait,

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
            Else
                strPathToXML = DiskFilesVB.PathToFile_XML_ElementsCache
            End If

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
            SaveFullPathToFileXML(strPathToXML)

            ''Added 12/14/2021 td
            pstrPathToElementsCacheXML = strPathToXML

        Else
            pboolNewFileXML = (Not System.IO.File.Exists(strPathToXML))

            ''Added 12/19/2021 thomas downes
            Dim strTextOfFile As String
            strTextOfFile = IO.File.ReadAllText(strPathToXML)
            If (String.IsNullOrEmpty(strTextOfFile)) Then pboolNewFileXML = True

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

            ''Added 12/20/2021 td
            ''My.Settings.PathToSavedXML_Prior3 = My.Settings.PathToSavedXML_Prior2
            ''My.Settings.PathToSavedXML_Prior2 = My.Settings.PathToSavedXML_Prior1
            ''My.Settings.PathToSavedXML_Prior1 = My.Settings.PathToSavedXML_Last
            ''My.Settings.PathToXML_Saved_ElementsCache = strPathToXML
            ''My.Settings.PathToSavedXML_Last = strPathToXML
            ''My.Settings.Save()
            SaveFullPathToFileXML(strPathToXML)

            ''Added 12/12/2021 td
            With obj_cache_elements
                .Id_GUID = New Guid()
                .Id_GUID6 = .Id_GUID.ToString().Substring(0, 6)
            End With

            obj_cache_elements.LoadFields()
            obj_cache_elements.LoadFieldElements(par_designForm.MyPictureBackgroundFront,
                       New BadgeLayoutDimensionsClass(par_designForm.MyPictureBackgroundFront))
            ''12/2022  New BadgeLayoutClass(par_designForm.MyPictureBackgroundFront))

        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = strPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_elements = New ClassElementsCache_Deprecated ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            obj_cache_elements = CType(objDeserialize.DeserializeFromXML(obj_cache_elements.GetType(), False), ClassElementsCache_Deprecated)

            ''Added 12/26/2021 thomas d.
            If (obj_cache_elements Is Nothing) Then Return Nothing

            ''Added 10/12/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LinkElementsToFields()
            ''-----Me.ElementsCache_Edits.LinkElementsToFields()
            obj_cache_elements.Check_LinkElementsToFields()

        End If ''End of "If (pboolNewFileXML) Then .... Else ..."

        ''-------------------------------------------------------------
        ''Added 9/19/2019 td
        Dim intPicLeft As Integer = 0
        Dim intPicTop As Integer = 0
        Dim intPicWidth As Integer = 100
        Dim intPicHeight As Integer = 200

        ''Added 9/19/2019 td
        With par_designForm
            ''Added 9/19/2019 td
            ''intPicLeft = .CtlGraphicPortrait_Lady.Left - .MyPictureBackgroundFront.Left
            ''intPicTop = .CtlGraphicPortrait_Lady.Top - .MyPictureBackgroundFront.Top
            ''intPicWidth = .CtlGraphicPortrait_Lady.Width
            ''intPicHeight = .CtlGraphicPortrait_Lady.Height
        End With

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Dim intLeft_QR As Integer = 0
        Dim intTop_QR As Integer = 0
        Dim intWidth_QR As Integer = 150
        Dim intHeight_QR As Integer = 150

        ''Added 10/14/2019 td
        With par_designForm
            ''Added 10/14/2019 td
            ''intLeft_QR = .CtlGraphicQRCode1.Left - .MyPictureBackgroundFront.Left
            ''intTop_QR = .CtlGraphicQRCode1.Top - .MyPictureBackgroundFront.Top
            ''intWidth_QR = .CtlGraphicQRCode1.Width
            ''intHeight_QR = .CtlGraphicQRCode1.Height
        End With

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Dim intLeft_Sig As Integer = 0
        Dim intTop_Sig As Integer = 0
        Dim intWidth_Sig As Integer = 300
        Dim intHeight_Sig As Integer = 150

        ''Added 10/14/2019 td
        With par_designForm
            ''Added 10/14/2019 td
            ''intLeft_Sig = .CtlGraphicSignature1.Left - .MyPictureBackgroundFront.Left
            ''intTop_Sig = .CtlGraphicSignature1.Top - .MyPictureBackgroundFront.Top
            ''intWidth_Sig = .CtlGraphicSignature1.Width
            ''intHeight_Sig = .CtlGraphicSignature1.Height
        End With

        ''-------------------------------------------------------------
        ''Added 10/14/2019 td
        Dim strStaticText As String = "Hello, I love Liz!"
        Dim intLeft_Text As Integer = 0
        Dim intTop_Text As Integer = 0
        Dim intWidth_Text As Integer = 300
        Dim intHeight_Text As Integer = 70

        ''Added 10/14/2019 td
        With par_designForm
            ''Added 10/14/2019 td
            strStaticText = "This is the same text for everyone."
            ''intLeft_Text = .CtlGraphicStaticText1.Left - .MyPictureBackgroundFront.Left
            ''intTop_Text = .CtlGraphicStaticText1.Top - .MyPictureBackgroundFront.Top
            ''intWidth_Text = .CtlGraphicStaticText1.Width
            ''intHeight_Text = .CtlGraphicStaticText1.Height
        End With


        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
        If (pboolNewFileXML) Then
            ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            obj_cache_elements.LoadNewElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
                                               par_designForm.MyPictureBackgroundFront,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 9/19/2019 td

            ''Added 10/14/2019 thomas d. 
            ''Jan19 2022 td''obj_cache_elements.LoadElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
            obj_cache_elements.LoadNewElement_QRCode(intLeft_QR, intTop_QR, intWidth_QR, intHeight_QR,
                                               par_designForm.MyPictureBackgroundFront,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

            ''Added 10/14/2019 thomas d. 
            ''Jan19 2022 td''obj_cache_elements.LoadElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
            obj_cache_elements.LoadNewElement_Signature(intLeft_Sig, intTop_Sig, intWidth_Sig, intHeight_Sig,
                                               par_designForm.MyPictureBackgroundFront,
                                                EnumWhichSideOfCard.EnumFrontside) ''Added 10/14/2019 td

        End If ''End of "If (pboolNewFileXML) Then"

        ''Added 3/16/2023 thomas
        Dim objBadgeLayoutDims As BadgeLayoutDimensionsClass ''Added 3/16/2023 thomas
        With par_designForm ''Added 3/16/2023 thomas
            objBadgeLayoutDims = .BadgeLayout
        End With

        ''Added 10/14/2019 thomas d. 
        ''Jan19 2022''obj_cache_elements.LoadElement_StaticText_IfNeeded(strStaticText,
        ''12/022 obj_cache_elements.LoadNewElement_StaticText(strStaticText,
        obj_cache_elements.LoadNewElement_StaticTextV4(strStaticText,
                            intLeft_Text, intTop_Text,
                            intWidth_Text, intHeight_Text,
                            par_designForm.MyPictureBackgroundFront,
                            EnumWhichSideOfCard.EnumFrontside,
                            objBadgeLayoutDims) ''Added 10/14/2019 td

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


    Public Shared Sub SaveFullPathToFileXML(par_pathToElementsCacheXML As String)
        ''
        ''Added 1/5/2022 td
        ''
        ''Added 12/20/2021 td
        With My.Settings
            .PathToSavedXML_Prior3 = .PathToSavedXML_Prior2
            .PathToSavedXML_Prior2 = .PathToSavedXML_Prior1
            .PathToSavedXML_Prior1 = .PathToSavedXML_Last
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

        My.Settings.Save() ''Added 1/7/2022 td

    End Sub ''End of "Public Shared Sub SaveFullPathToFileXML()"


End Class ''end of Public Class Startup
