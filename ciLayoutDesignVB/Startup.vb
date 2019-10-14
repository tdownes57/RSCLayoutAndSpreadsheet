Option Explicit On
Option Strict On
Option Infer On
''
''Added 10/11/2019 td  
''
Imports ciBadgeInterfaces ''Added 10/11/2019 thomas d. 
Imports ciBadgeElements ''Added 10/13/2019 thomas d. 

Public Class Startup
    ''
    ''Added 10/11/2019 td  
    ''
    Public Shared Sub Main()

        ''Encapsulated 10/13/2019 td  
        OpenLayoutDesigner_Loop()

    End Sub ''Endof "Public Shared Sub Main()"

    Private Shared Sub OpenLayoutDesigner_Loop()
        ''
        ''Added 10/11/2019 td  
        ''Encapsulated 10/13/2019 td
        ''
        Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  
        Dim obj_cache_layout As ClassElementsCache ''Added 10/13/2019 td 
        ''
        ''
        ''If we are emphasizing Layout Design, then open up the 
        ''   form which currently demostrates Layout Design the best.  
        ''
        ''
        Dim obj_formToShow As New FormDesignProtoTwo ''Added 10/11/2019 td 

        ''
        ''Initialize a Customer Cache, or at least a Personality Cache.
        ''
        ''   (Or, at the very bare minimum, a Badge Layout Cache.)  
        ''
        ''10/13/2019 td''obj_cache_layout = LoadCachedData(obj_formToShow)
        obj_cache_layout = LoadCachedData(obj_formToShow, boolNewFileXML)

        obj_formToShow.NewFileXML = boolNewFileXML

        ''Not needed. 10/11/2019 td'obj_formToShow.CtlGraphicText1.LayoutFunctions = CType(obj_formToShow., ILayoutFunctions)

        ''10/12/2019 td''obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.

        '-----obj_formToShow.CtlGraphicSignature1.ElementInfo_Sig.SigFilePath =
        '-----          DiskFiles.PathToFile_Sig()

        Do
            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
            obj_formToShow.ElementsCache_Edits = obj_cache_layout

            obj_formToShow.ShowDialog() ''Added 10/11/2019 td 

            ''Added 10/13/2019 td
            If (Not obj_formToShow.LetsRefresh_CloseForm) Then Exit Do

            obj_cache_layout = obj_formToShow.ElementsCache_Saved
            obj_formToShow = New FormDesignProtoTwo

            ''
            ''This is potentially an infinite loop.  Look for "Exit Do". 
            ''
        Loop

    End Sub ''End of "Public Sub OpenLayoutDesigner_Loop()"

    Private Shared Function LoadCachedData(par_designForm As FormDesignProtoTwo,
                                           ByRef pboolNewFileXML As Boolean) As ClassElementsCache
        ''
        ''Added 10/13/2019 td
        ''
        ''Added 10/10/2019 td
        Dim strPathToXML As String = ""
        ''---Dim boolNewFileXML As Boolean ''Added 10/10/2019 td  
        Dim obj_cache_elements As ClassElementsCache ''Added 10/10/2019 td

        ''Added 10/10/2019 td
        ''10/13/2019 td''strPathToXML = My.Settings.PathToXML_Saved
        strPathToXML = DiskFiles.PathToFile_XML

        If (strPathToXML = "") Then
            pboolNewFileXML = True
            ''10/12/2019 td''strPathToXML = (My.Application.Info.DirectoryPath & "\ciLayoutDesignVB_Saved.xml").Replace("\\", "\")
            strPathToXML = DiskFiles.PathToFile_XML
            My.Settings.PathToXML_Saved = strPathToXML
            My.Settings.Save()
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
            obj_cache_elements = New ClassElementsCache
            obj_cache_elements.PathToXml_Saved = strPathToXML

            obj_cache_elements.LoadFields()
            obj_cache_elements.LoadFieldElements(par_designForm.pictureBack,
                                New BadgeLayoutClass(par_designForm.pictureBack))

        Else
            ''Added 10/10/2019 td  
            Dim objDeserialize As New ciBadgeSerialize.ClassDeserial ''Added 10/10/2019 td  
            objDeserialize.PathToXML = strPathToXML

            ''10/13/2019 td''Me.ElementsCache_Saved = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Saved.GetType(), False), ClassElementsCache)
            ''-----Me.ElementsCache_Edits = CType(objDeserialize.DeserializeFromXML(Me.ElementsCache_Edits.GetType(), False), ClassElementsCache)

            obj_cache_elements = New ClassElementsCache ''This may or may not be completely necessary,
            ''   but I know of no other way to pass the object type.  Simply expressing the Type
            ''   by typing its name doesn't work.  ---10/13/2019 td

            obj_cache_elements = CType(objDeserialize.DeserializeFromXML(obj_cache_elements.GetType(), False), ClassElementsCache)

            ''Added 10/12/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LinkElementsToFields()
            ''-----Me.ElementsCache_Edits.LinkElementsToFields()
            obj_cache_elements.LinkElementsToFields()

        End If ''End of "If (pboolNewFileXML) Then .... Else ..."

        ''Added 9/19/2019 td
        Dim intPicLeft As Integer
        Dim intPicTop As Integer
        Dim intPicWidth As Integer
        Dim intPicHeight As Integer

        ''Added 9/19/2019 td
        With par_designForm
            intPicLeft = .CtlGraphicPortrait_Lady.Left - .pictureBack.Left
            intPicTop = .CtlGraphicPortrait_Lady.Top - .pictureBack.Top
            intPicWidth = .CtlGraphicPortrait_Lady.Width
            intPicHeight = .CtlGraphicPortrait_Lady.Height
        End With

        ''9/19 td''Me.ElementsCache_Saved.LoadPicElement(CtlGraphicPortrait_Lady.picturePortrait, pictureBack) ''Added 9/19/2019 td
        If (pboolNewFileXML) Then
            ''10/10/2019 td''Me.ElementsCache_Saved.LoadPicElement(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            ''10/13/2019 td''Me.ElementsCache_Saved.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight, pictureBack) ''Added 9/19/2019 td
            obj_cache_elements.LoadElement_Pic(intPicLeft, intPicTop, intPicWidth, intPicHeight,
                                               par_designForm.pictureBack) ''Added 9/19/2019 td

        End If ''End of "If (pboolNewFileXML) Then"

        ''Added 9/24/2019 thomas 
        ''Was just for testing. ---10/10/2019 td''Dim serial_tools As New ciBadgeSerialize.ClassSerial
        ''Was just for testing. ---10/10/2019 td''serial_tools.PathToXML = (System.IO.Path.GetRandomFileName() & ".xml")
        ''Was just for testing. ---10/10/2019 td''serial_tools.SerializeToXML(Me.ElementsCache_Saved.GetType, Me.ElementsCache_Saved, False, True)

        Return obj_cache_elements

    End Function ''End of "Private Sub LoadCachedData()"


End Class
