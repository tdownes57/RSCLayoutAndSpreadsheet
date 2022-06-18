Imports ciBadgeInterfaces ''Added 5/3/2022 td 
Imports ciBadgeDesigner ''Added 5/4/2022 td
Imports ciBadgeCachePersonality ''Added 5/5/2022 td
Imports ciBadgeFields ''Added 5/12/2022 td 
''----Imports __RSCWindowsControlLibrary ''Added 5/3/2022 td
''
''Added 5/3/2022 thomas d. 
''
''The following Dialog Form is an attempt to fix an ambiguity which has 
''  been vexing my layout-design development for a long time... namely, the
''  ambiguity is as follows....
''Do I want all the various types of Elements (e.g. QR code) to be easily
''  (i.e. automatically) instantiated (and thus present in the layout design at run-time),
''  or would I eventually find it vexing & annoying?
''Sometimes I just want to work with a simple, unadorned layout... no bells & whistles.
''A related question is, if I finally don't want them to keep appearing incessantly,
''  how do I "turn them off" effectively? 
''Solution:  This new dialog-form called FormTypesOfElementsToAdd, and the following
''  Boolean constant, Startup.PreloadElementsForDemo.   -----5/4/2022 td
''  -----5/4/2022 td
''
Public Class FormTypeOfElementsToAdd
    ''5/16/2022 td ''Implements ILayoutFunctions ''Added 5/16/2022 td 
    ''
    ''Added 5/3/2022 thomas d. 
    ''
    Public Shared StaticTextString As String = "Text Label... any message you like." ''Added 6/1/2022

    Public AddPortraitPic As Boolean
    Public AddGraphic As Boolean
    Public AddStaticText As Boolean
    Public AddQRCode As Boolean
    Public AddSignature As Boolean
    Public AddField1 As Boolean
    Public AddField2 As Boolean
    Public AddField3 As Boolean
    Public AddField4 As Boolean
    Public AddField5 As Boolean

    Public AddField1_Enum As EnumCIBFields
    Public AddField2_Enum As EnumCIBFields
    Public AddField3_Enum As EnumCIBFields
    Public AddField4_Enum As EnumCIBFields
    Public AddField5_Enum As EnumCIBFields

    ''Added 5/5/2022 td
    Private mod_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated
    Private mod_listRelevantFields As List(Of ClassFieldAny) ''Added 5/12/2022 td

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated,
                   par_listRelevantFs As List(Of ClassFieldAny))
        ''
        ''Added 5/5/2022 thomas downes
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_cache = par_cache
        mod_listRelevantFields = par_listRelevantFs ''Added 5/12/2022 td

        ''Added 6/1/2022
        CtlGraphicStaticText1.TextToDisplay = StaticTextString '' """Text Label... any message you like.""
        CtlGraphicStaticText1.TextToDisplay_DesignTime = StaticTextString '' """Text Label... any message you like.""

        ''RscSelectCIBField1.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField2.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField3.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField4.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField5.Load_FieldsFromCache(par_cache)

    End Sub ''End of New(ClassElementsCache_Deprecated, List(Of ClassFieldAny)) 


    Public Function Layout_Margin_Left_Omit(par_intPixelsLeft As Integer) As Integer ''5/16/2022 Implements ILayoutFunctions.Layout_Margin_Left_Omit
        ''Added 9/5/2019 thomas downes

        ''Added 9/05/2019 td 
        Return (par_intPixelsLeft - pictureBackground.Left)

    End Function ''End of "Public Function Layout_Margin_Left_Omit() As Integer"

    Public Function Layout_Margin_Left_Add(par_intPixelsLeft As Integer) As Integer ''5/16/2022 Implements ILayoutFunctions.Layout_Margin_Left_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsLeft + pictureBackground.Left)

    End Function ''End of "Public Function Layout_Margin_Left_Add() As Integer"

    Public Function Layout_Margin_Top_Omit(par_intPixelsTop As Integer) As Integer ''5/16/2022 Implements ILayoutFunctions.Layout_Margin_Top_Omit
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop - pictureBackground.Top)

    End Function ''End of "Public Function Layout_Margin_Top_Omit() As Integer"

    Public Function Layout_Margin_Top_Add(par_intPixelsTop As Integer) As Integer ''5/16/2022 Implements ILayoutFunctions.Layout_Margin_Top_Add
        ''Added 9/5/2019 thomas downes
        Return (par_intPixelsTop + pictureBackground.Top)

    End Function ''End of "Public Function Layout_Margin_Top_Add() As Integer"


    Public Function GetRectangle_Field1(psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        Return GetRectangle_FieldControl(RscSelectCIBField1, psingleFactorWidth, psingleFactorHeight)

    End Function


    Public Function GetRectangle_Field2(psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        Return GetRectangle_FieldControl(RscSelectCIBField2, psingleFactorWidth, psingleFactorHeight)

    End Function


    Public Function GetRectangle_Field3(psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        Return GetRectangle_FieldControl(RscSelectCIBField3, psingleFactorWidth, psingleFactorHeight)

    End Function


    Public Function GetRectangle_Field4(psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        Return GetRectangle_FieldControl(RscSelectCIBField4, psingleFactorWidth, psingleFactorHeight)

    End Function


    Public Function GetRectangle_Field5(psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        Return GetRectangle_FieldControl(RscSelectCIBField5, psingleFactorWidth, psingleFactorHeight)

    End Function


    Private Function GetRectangle_FieldControl(par_controlField As RSCSelectCIBField,
                                             psingleFactorWidth As Single,
                                        psingleFactorHeight As Single) As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        Dim intPixelsLeftX As Integer
        Dim intPixelsTopY As Integer
        Dim intPixelsWidth As Integer
        Dim intPixelsHeight As Integer
        Dim objRectOfControl As Rectangle

        ''---objRectOfControl = GetRectangleOf(RscSelectCIBField1)
        Const c_bLetsDoLayoutAdjustmentLocally As Boolean = True ''Added 5/16/2022 
        If (c_bLetsDoLayoutAdjustmentLocally) Then ''Added 5/16/2022
            ''
            ''Let's first call the function GetRectangleOf_NoLayoutAdjustment(...)
            ''  and then (after calling the aforementioned function) call the functions
            ''     Layout_Margin_Left_Omit(...)
            ''     Layout_Margin_Top_Omit(...)
            ''----5/16/2022 thomas d.
            ''
            objRectOfControl = GetRectangleOf_NoLayoutAdjustment(par_controlField)
            With objRectOfControl
                ''5/16/2022 td''intPixelsLeftX = .Left
                ''5/16/2022 td''intPixelsTopY = .Top
                intPixelsLeftX = Layout_Margin_Left_Omit(.Left)
                intPixelsTopY = Layout_Margin_Top_Omit(.Top)
            End With

        Else
            ''
            ''Let's rely on the function GetRectangleOf_wLayoutAdjustment(...)
            ''  to call the functions
            ''     Layout_Margin_Left_Omit(...)
            ''     Layout_Margin_Top_Omit(...)
            ''----5/16/2022 thomas d.
            ''
            objRectOfControl = GetRectangleOf_wLayoutAdjustment(par_controlField)
            With objRectOfControl
                intPixelsLeftX = .Left
                intPixelsTopY = .Top
            End With

        End If ''End of ""If (c_bLetsDoLayoutAdjustmentLocally) Then... Else ..."


        With objRectOfControl
            intPixelsWidth = CInt(.Width * psingleFactorWidth)
            intPixelsHeight = CInt(.Height * psingleFactorHeight)
        End With

        ''---Return New Rectangle(New Point(intPixelsTop, intPixelsLeft),
        Return New Rectangle(New Point(intPixelsLeftX, intPixelsTopY),
                             New Size(intPixelsWidth, intPixelsHeight))

    End Function ''eND OF ""Private Function GetRectangle_FieldControl""


    Public Function GetRectangle_PortraitPic() As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        ''#1 5/16/2022 td''Return GetRectangleOf(CtlGraphicPortrait1)
        ''#2 5/16/2022 td''Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicPortrait1)
        Return GetRectangleOf_wLayoutAdjustment(CtlGraphicPortrait1)

    End Function


    Public Function GetRectangle_QRCode() As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        ''#1 5/16/2022 Return GetRectangleOf(CtlGraphicQRCode1)
        ''#2 5/16/2022 Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicQRCode1)
        Return GetRectangleOf_wLayoutAdjustment(CtlGraphicQRCode1)

    End Function


    Public Function GetRectangle_Signature() As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        ''#1 5/16/2022 Return GetRectangleOf(CtlGraphicSignature1)
        ''#2 5/16/2022 Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicSignature1)
        Return GetRectangleOf_wLayoutAdjustment(CtlGraphicSignature1)

    End Function


    Public Function GetRectangle_StaticGraphic() As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        ''#1 5/16/2022 Return GetRectangleOf(CtlGraphicStaticGraphic1)
        ''#2 5/16/2022 Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicStaticGraphic1)
        Return GetRectangleOf_wLayoutAdjustment(CtlGraphicStaticGraphic1)

    End Function


    Public Function GetRectangle_StaticText() As Drawing.Rectangle
        ''
        ''Added 5/6/2022
        ''
        ''---Return CtlGraphicPortrait1.RectangleToClient()
        ''#1 5/16/2022 Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicStaticText1)
        ''#2 5/16/2022 Return GetRectangleOf_NoLayoutAdjustment(CtlGraphicStaticText1)
        Return GetRectangleOf_wLayoutAdjustment(CtlGraphicStaticText1)

    End Function


    Private Function GetRectangleOf_wLayoutAdjustment(par_control As UserControl) As Rectangle
        ''Private Function GetRectangleOf
        ''
        ''Added 5/16/2022 thomas downes  
        ''
        Dim new_rect As Drawing.Rectangle
        Dim new_size As New Drawing.Size ''Rectangle
        Dim new_location As New Drawing.Point ''Rectangle
        ''With new_rect

        ''5/16/2022 new_location.X = -1 * pictureBackground.Left + par_control.Left
        ''5/16/2022 new_location.Y = -1 * pictureBackground.Top + par_control.Top

        new_location.X = Layout_Margin_Left_Omit(par_control.Left)
        new_location.Y = Layout_Margin_Top_Omit(par_control.Top)

        new_size.Width = par_control.Width
        new_size.Height = par_control.Height

        new_rect = New Drawing.Rectangle(new_location, new_size)

        ''End With

        Return new_rect

    End Function ''End of ""Private Function GetRectangleOf_NoLayoutAdjustment""


    Private Function GetRectangleOf_NoLayoutAdjustment(par_control As UserControl) As Rectangle
        ''Private Function GetRectangleOf
        ''
        ''Added 5/6/2022 thomas downes  
        ''
        Dim new_rect As Drawing.Rectangle
        Dim new_size As New Drawing.Size ''Rectangle
        Dim new_location As New Drawing.Point ''Rectangle
        ''With new_rect

        ''5/16/2022 new_location.X = -1 * pictureBackground.Left + par_control.Left
        ''5/16/2022 new_location.Y = -1 * pictureBackground.Top + par_control.Top

        new_location.X = par_control.Left
        new_location.Y = par_control.Top

        new_size.Width = par_control.Width
        new_size.Height = par_control.Height

        new_rect = New Drawing.Rectangle(new_location, new_size)

        ''End With

        Return new_rect

    End Function ''End of ""Private Function GetRectangleOf_NoLayoutAdjustment""


    Private Sub ToggleBorder(par_control As UserControl, par_panel As Panel) ''---As RSCMoveableControlVB) ''As Control)
        ''
        ''Added 5/3/2022 thomas downes 
        ''
        ''----If (par_control.BorderStyle = BorderStyle.None) Then
        If (par_control.Tag Is Nothing) Then

            par_control.BorderStyle = BorderStyle.Fixed3D

            ''Show the panel.
            If (par_panel IsNot Nothing) Then
                par_panel.Left = par_control.Left - 5
                par_panel.Top = par_control.Top - 5
                par_panel.Height = par_control.Height + 10
                par_panel.Width = par_control.Width + 10
                par_control.BringToFront()
                par_panel.Visible = True
                par_panel.Tag = par_control ''Added 5/5/2022 td
                par_control.Tag = par_panel ''Added 5/5/2022 td 
            End If ''end of ""If (par_panel IsNot Nothing) Then""

        Else

            par_control.BorderStyle = BorderStyle.None
            ''Hide the panel.
            If (par_panel IsNot Nothing) Then par_panel.Visible = False
            ''Clear the .Tag property. --5/5/2022
            If (par_panel IsNot Nothing) Then par_panel.Tag = Nothing ''Added 5/5/2022 td
            par_control.Tag = Nothing ''Added 5/5/2022 td 

        End If ''End of ""If (par_control.BorderStyle = BorderStyle.None) Then... Else..."

    End Sub ''End of ""Private Sub ToggleBorder(par_control As UserControl)""


    Private Sub AddBorder(par_control As UserControl, par_panel As Panel) ''---As RSCMoveableControlVB) ''As Control)
        ''
        ''Added 5/3/2022 thomas downes 
        ''
        par_control.BorderStyle = BorderStyle.FixedSingle

        ''Show the panel.
        If (par_panel IsNot Nothing) Then
            par_panel.Left = par_control.Left - 5
            par_panel.Top = par_control.Top - 5
            par_panel.Height = par_control.Height + 10
            par_panel.Width = par_control.Width + 10
            par_control.BringToFront()
            par_panel.Visible = True
            par_panel.Tag = par_control ''Added 5/5/2022 td
            par_control.Tag = par_panel ''Added 5/5/2022 td 
        End If ''end of ""If (par_panel IsNot Nothing) Then""

    End Sub ''End of ""Private Sub AddBorder""


    Private Function GetCIBFieldToAdd(par_RSCSelectField As RSCSelectCIBField,
                                      par_intFieldIndex As Integer,
            Optional pboolAskAboutMissingSelection As Boolean = True,
            Optional ByRef pref_bMismatch As Boolean = True) As EnumCIBFields
        ''
        ''Added 5/4/2022 td
        ''
        Dim enumCIBField As EnumCIBFields
        Dim bSubstantiveField As Boolean
        Dim bSelectionBorder As Boolean
        Dim boolMismatch As Boolean

        With par_RSCSelectField
            enumCIBField = .GetFieldEnumSelected()
            bSubstantiveField = (enumCIBField <> EnumCIBFields.Undetermined)
            ''5/5/2022 bSelectionBorder = (.BorderStyle <> BorderStyle.None)
            bSelectionBorder = HasBorder_IsSelected(par_RSCSelectField)
            ''#1 5/5/2022 td ''pref_bMismatch = (bSubstantiveField <> bSelectionBorder)
            ''#2 5/5/2022 td ''boolMismatch = ((bSubstantiveField <> bSelectionBorder)
            boolMismatch = ((bSubstantiveField <> bSelectionBorder) And
                              (Not bSubstantiveField))

            If (boolMismatch) Then pref_bMismatch = True

            If (boolMismatch And pboolAskAboutMissingSelection) Then

                MessageBoxTD.Show_Statement(" " &
                  String.Format("Which Relevant Field do you want? Field {0} is blank.",
                                par_intFieldIndex),
                  "Please de-select any fields which don't have a specific field selected.")

            End If ''End of ""If (boolMismatch And pboolAskAboutMissingSelection) Then""

        End With

        Return enumCIBField

    End Function ''End of ""Private Function GetCIBFieldToAdd(...)"


    Private Sub Load_FieldsFromCache(par_control As RSCSelectCIBField,
                                     par_cache As ClassElementsCache_Deprecated)
        ''
        ''Added 3/14/2022 td
        ''
        If (par_cache Is Nothing) Then Throw New ArgumentException("Exception Occured")

        With par_control
            ''RscSelectCIBField1.Loading = True ''Added 4/1/2022
            ''RscSelectCIBField1.ElementsCache_Deprecated = Me.ElementsCache_Deprecated
            ''RscSelectCIBField1.ParentSpreadsheet = Me.ParentSpreadsheet
            ''RscSelectCIBField1.Load_FieldsFromCache(par_cache)
            .Loading = True ''Added 4/1/2022
            .ElementsCache_Deprecated = par_cache ''Me.ElementsCache_Deprecated
            ''.ParentSpreadsheet = Me.ParentSpreadsheet
            .Load_FieldsFromCache(par_cache)
        End With

        ''
        ''Added 3/15/2022 td
        ''
        ''RscSelectCIBField1.SelectedValue = mod_columnWidthAndData.CIBField

        ''Added 4/1/2022 td
        Application.DoEvents()
        ''RscSelectCIBField1.Loading = False ''Added 4/1/2022 td
        par_control.Loading = False ''Return to default, i.e. idle.

    End Sub ''end of "Public Sub Load_FieldsFromCache"


    Private Sub Load_FieldsFromFieldList(par_control As RSCSelectCIBField,
                                     par_listOfFields As List(Of ClassFieldAny))
        ''
        ''Added 5/12/2022 td
        ''
        If (par_listOfFields Is Nothing) Then Throw New ArgumentException("List of Fields is null")

        With par_control
            .Loading = True ''Added 4/1/2022
            .ElementsCache_Deprecated = mod_cache
            .Load_FieldsFromList(par_listOfFields)
        End With

        Application.DoEvents()
        par_control.Loading = False ''Return to default, i.e. idle.

    End Sub ''end of "Public Sub Load_FieldsFromFieldList"


    Private Function HasBorder_IsSelected(par_control As UserControl) As Boolean
        ''
        ''Added 5/5/2022 td
        ''
        Dim boolBorderIsNone As Boolean

        If (TypeOf par_control Is CtlGraphicStaticTextV3) Then
            ''Added 5/5/2022 td
            boolBorderIsNone = (par_control.Tag Is Nothing)
            If (boolBorderIsNone) Then Return False
            Return (Not boolBorderIsNone)

        ElseIf (TypeOf par_control Is CtlGraphicStaticTextV4) Then
            ''Added 5/5/2022 td
            boolBorderIsNone = (par_control.Tag Is Nothing)
            If (boolBorderIsNone) Then Return False
            Return (Not boolBorderIsNone)

        Else
            ''---boolBorderIsNone = (par_control.BorderStyle <> BorderStyle.None)
            boolBorderIsNone = (par_control.BorderStyle = BorderStyle.None)
            Return (Not boolBorderIsNone) '' (par_control.BorderStyle <> BorderStyle.None)

        End If ''end of ""If (TypeOf par_control Is CtlGraphicStaticTextV3) Then....ElseIf..."


    End Function ''End of ""Private Function HasBorder_IsSelected(par_control As Control) As Boolean""


    Private Function HasValue(par_control As RSCSelectCIBField) As Boolean

        ''Added 5/5/2022 td
        Dim boolNotDetermined As Boolean

        boolNotDetermined = (par_control.GetFieldEnumSelected() =
            EnumCIBFields.Undetermined)

        Return (Not boolNotDetermined)

    End Function ''End of ""Private Function HasValue(par_control As RSCSelectCIBField)""


    Private Function GetCopyOfFieldsList(par_list As List(Of ClassFieldAny)) As List(Of ClassFieldAny)
        ''
        ''Added 5/12/2022 
        ''
        Dim output_list As New List(Of ClassFieldAny) ''Added 5/12/2022 

        For Each each_any As ClassFieldAny In par_list

            Dim new_any As New ClassFieldAny ''Added 5/12/2022 
            new_any.LoadbyCopyingMembers(each_any)
            output_list.Add(new_any)

        Next each_any

        Return output_list

    End Function ''End of ""Private Function GetCopyOfFieldsList""


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        Dim bMismatchOfIntention As Boolean ''Added 5/5/2022 

        ''Added 5/3/2022 td
        ''Me.AddField1_Enum = GetCIBFieldToAdd(RscSelectCIBField1, 1) ''1.BorderStyle <> BorderStyle.None)
        ''Me.AddField2_Enum = GetCIBFieldToAdd(RscSelectCIBField2, 2) ''2.BorderStyle <> BorderStyle.None)
        ''Me.AddField3_Enum = GetCIBFieldToAdd(RscSelectCIBField3, 3) ''3.BorderStyle <> BorderStyle.None)
        ''Me.AddField4_Enum = GetCIBFieldToAdd(RscSelectCIBField4, 4) ''4.BorderStyle <> BorderStyle.None)
        ''Me.AddField5_Enum = GetCIBFieldToAdd(RscSelectCIBField5, 5) ''5.BorderStyle <> BorderStyle.None)

        ''Added 5/5/2022 td
        Me.AddField1 = (HasBorder_IsSelected(RscSelectCIBField1) Or HasValue(RscSelectCIBField1)) ''GetCIBFieldToAdd(RscSelectCIBField1, 1) ''1.BorderStyle <> BorderStyle.None)
        Me.AddField2 = (HasBorder_IsSelected(RscSelectCIBField2) Or HasValue(RscSelectCIBField2)) ''GetCIBFieldToAdd(RscSelectCIBField2, 2) ''2.BorderStyle <> BorderStyle.None)
        Me.AddField3 = (HasBorder_IsSelected(RscSelectCIBField3) Or HasValue(RscSelectCIBField3)) ''GetCIBFieldToAdd(RscSelectCIBField3, 3) ''3.BorderStyle <> BorderStyle.None)
        Me.AddField4 = (HasBorder_IsSelected(RscSelectCIBField4) Or HasValue(RscSelectCIBField4)) ''GetCIBFieldToAdd(RscSelectCIBField4, 4) ''4.BorderStyle <> BorderStyle.None)
        Me.AddField5 = (HasBorder_IsSelected(RscSelectCIBField5) Or HasValue(RscSelectCIBField5)) ''GetCIBFieldToAdd(RscSelectCIBField5, 5) ''5.BorderStyle <> BorderStyle.None)

        ''Conditions added 5/5/2022 td
        If (Me.AddField1) Then Me.AddField1_Enum = GetCIBFieldToAdd(RscSelectCIBField1, 1, True, bMismatchOfIntention) ''1.BorderStyle <> BorderStyle.None)
        If (Me.AddField2) Then Me.AddField2_Enum = GetCIBFieldToAdd(RscSelectCIBField2, 2, True, bMismatchOfIntention) ''2.BorderStyle <> BorderStyle.None)
        If (Me.AddField3) Then Me.AddField3_Enum = GetCIBFieldToAdd(RscSelectCIBField3, 3, True, bMismatchOfIntention) ''3.BorderStyle <> BorderStyle.None)
        If (Me.AddField4) Then Me.AddField4_Enum = GetCIBFieldToAdd(RscSelectCIBField4, 4, True, bMismatchOfIntention) ''4.BorderStyle <> BorderStyle.None)
        If (Me.AddField5) Then Me.AddField5_Enum = GetCIBFieldToAdd(RscSelectCIBField5, 5, True, bMismatchOfIntention) ''5.BorderStyle <> BorderStyle.None)

        If (bMismatchOfIntention) Then Exit Sub ''Added 5/5/2022 td

        ''5/13/2022 td''Me.AddQRCode = (CtlGraphicQRCode1.BorderStyle <> BorderStyle.None)
        ''5/13/2022 td''Me.AddSignature = (CtlGraphicSignature1.BorderStyle <> BorderStyle.None)
        ''5/13/2022 td''Me.AddGraphic = (CtlGraphicStaticGraphic1.BorderStyle <> BorderStyle.None)
        ''5/13/2022 td''Me.AddPortraitPic = (CtlGraphicPortrait1.BorderStyle <> BorderStyle.None)
        ''5/13/2022 td''Me.AddStaticText = (CtlGraphicStaticText1.BorderStyle <> BorderStyle.None)

        Me.AddQRCode = HasBorder_IsSelected(CtlGraphicQRCode1)
        Me.AddSignature = HasBorder_IsSelected(CtlGraphicSignature1)
        Me.AddGraphic = HasBorder_IsSelected(CtlGraphicStaticGraphic1)
        Me.AddPortraitPic = HasBorder_IsSelected(CtlGraphicPortrait1)
        Me.AddStaticText = HasBorder_IsSelected(CtlGraphicStaticText1)

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    ''Private Sub CtlGraphicPortrait1_Click(sender As Object, e As EventArgs)
    ''
    ''    ''Added 5/3/2022 td
    ''    ToggleBorder(CType(sender, Control), P)
    ''
    ''End Sub

    Private Sub CtlGraphicPortrait1_Click(sender As Object, e As EventArgs) Handles CtlGraphicPortrait1.Click

        ''Added 5/3/2022 td
        ''6/2022 ToggleBorder(CType(sender, Control), PanelPortraitPic)
        ToggleBorder(CType(sender, UserControl), PanelPortraitPic)

    End Sub

    Private Sub CtlGraphicStaticGraphic1_Click(sender As Object, e As EventArgs) Handles CtlGraphicStaticGraphic1.Click

        ''Added 5/3/2022 td
        ''6/2022 ToggleBorder(CType(sender, Control), PanelGraphic)
        ToggleBorder(CType(sender, UserControl), PanelGraphic)

    End Sub

    Private Sub CtlGraphicStaticText1_Click(sender As Object, e As EventArgs) Handles CtlGraphicStaticText1.Click
        ''Added 5/3/2022 td
        ''6/2022 ToggleBorder(CType(sender, Control), PanelStaticText)
        ToggleBorder(CType(sender, UserControl), PanelStaticText)

    End Sub

    Private Sub RscSelectCIBField1_Click(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Click
        ''Added 5/3/2022 td
        ''6/2022 ToggleBorder(CType(sender, Control), Nothing)
        ToggleBorder(CType(sender, UserControl), Nothing)

    End Sub

    Private Sub CtlGraphicSignature1_Click(sender As Object, e As EventArgs) Handles CtlGraphicSignature1.Click
        ''Added 5/3/2022 td
        ''6/2022 ToggleBorder(CType(sender, Control), PanelSignature)
        ToggleBorder(CType(sender, UserControl), PanelSignature)

    End Sub

    Private Sub CtlGraphicQRCode1_Click(sender As Object, e As EventArgs)
        ''Added 5/3/2022 td
        ''6/2022  ToggleBorder(CType(sender, Control), PanelQRCode)
        ToggleBorder(CType(sender, UserControl), PanelQRCode)

    End Sub

    Private Sub CtlGraphicPortrait1_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormTypeOfElementsToAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''Added 5/5/2022 td
        ''????''CtlGraphicStaticText1.TextToDisplay_DesignTime = "" ''Remove this text.
        ''????''CtlGraphicStaticText1.TextToDisplay = ""

        ''RscSelectCIBField1.Load_FieldsFromCache(mod_cache)
        ''RscSelectCIBField2.Load_FieldsFromCache(mod_cache)
        ''RscSelectCIBField3.Load_FieldsFromCache(mod_cache)
        ''RscSelectCIBField4.Load_FieldsFromCache(mod_cache)
        ''RscSelectCIBField5.Load_FieldsFromCache(mod_cache)

        Const c_boolUseElementsCache As Boolean = False ''Added 5/12/2022 td
        If (c_boolUseElementsCache) Then ''Added 5/12/2022 td

            Load_FieldsFromCache(RscSelectCIBField1, mod_cache)
            Load_FieldsFromCache(RscSelectCIBField2, mod_cache)
            Load_FieldsFromCache(RscSelectCIBField3, mod_cache)
            Load_FieldsFromCache(RscSelectCIBField4, mod_cache)
            Load_FieldsFromCache(RscSelectCIBField5, mod_cache)

        ElseIf (mod_listRelevantFields IsNot Nothing) Then
            ''
            ''Added 5/12/2022 td
            ''
            Dim listCopyFields1 As List(Of ClassFieldAny) = GetCopyOfFieldsList(mod_listRelevantFields)
            Dim listCopyFields2 As List(Of ClassFieldAny) = GetCopyOfFieldsList(mod_listRelevantFields)
            Dim listCopyFields3 As List(Of ClassFieldAny) = GetCopyOfFieldsList(mod_listRelevantFields)
            Dim listCopyFields4 As List(Of ClassFieldAny) = GetCopyOfFieldsList(mod_listRelevantFields)
            Dim listCopyFields5 As List(Of ClassFieldAny) = GetCopyOfFieldsList(mod_listRelevantFields)

            Load_FieldsFromFieldList(RscSelectCIBField1, listCopyFields1)
            Load_FieldsFromFieldList(RscSelectCIBField2, listCopyFields2)
            Load_FieldsFromFieldList(RscSelectCIBField3, listCopyFields3)
            Load_FieldsFromFieldList(RscSelectCIBField4, listCopyFields4)
            Load_FieldsFromFieldList(RscSelectCIBField5, listCopyFields5)

        End If ''End of ""If (c_boolUseCached) Then.... Else....

    End Sub ''End of Handles Form_Load  

    Private Sub CtlGraphicPortrait1_RSCControlClicked() Handles CtlGraphicPortrait1.RSCControlClicked

        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicPortrait1, PanelPortraitPic)

    End Sub

    Private Sub CtlGraphicQRCode1_RSCControlClicked()
        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicQRCode1, PanelQRCode)

    End Sub

    Private Sub CtlGraphicSignature1_RSCControlClicked() Handles CtlGraphicSignature1.RSCControlClicked
        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicSignature1, PanelSignature)


    End Sub

    Private Sub CtlGraphicStaticText1_RSCControlClicked() Handles CtlGraphicStaticText1.RSCControlClicked
        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicStaticText1, PanelStaticText)

    End Sub

    Private Sub CtlGraphicStaticGraphic1_RSCControlClicked() Handles CtlGraphicStaticGraphic1.RSCControlClicked
        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicStaticGraphic1, PanelGraphic)

    End Sub

    Private Sub RscSelectCIBField1_Load(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Load

    End Sub

    Private Sub RscSelectCIBField1_RSCMouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField1.RSCMouseUp
        ''Added 5/5/2022 td
        ToggleBorder(RscSelectCIBField1, panelField1)
        If (HasValue(RscSelectCIBField1)) Then RscSelectCIBField2.Enabled = True

    End Sub

    Private Sub RscSelectCIBField2_RSCMouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField2.RSCMouseUp

        ''Added 5/5/2022 td
        If (RscSelectCIBField2.Enabled) Then
            ToggleBorder(RscSelectCIBField2, panelField2)
            If (HasValue(RscSelectCIBField2)) Then RscSelectCIBField3.Enabled = True
        End If

    End Sub

    Private Sub RscSelectCIBField3_RSCMouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField3.RSCMouseUp
        ''Added 5/5/2022 td
        If (RscSelectCIBField3.Enabled) Then
            ToggleBorder(RscSelectCIBField3, panelField3)
            If (HasValue(RscSelectCIBField3)) Then RscSelectCIBField4.Enabled = True
        End If

    End Sub

    Private Sub RscSelectCIBField4_RSCMouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField4.RSCMouseUp
        ''Added 5/5/2022 td
        If (RscSelectCIBField4.Enabled) Then
            ToggleBorder(RscSelectCIBField4, panelField4)
            If (HasValue(RscSelectCIBField4)) Then RscSelectCIBField5.Enabled = True
        End If

    End Sub

    Private Sub RscSelectCIBField5_RSCMouseUp(sender As Object, e As MouseEventArgs) Handles RscSelectCIBField5.RSCMouseUp
        ''Added 5/5/2022 td
        If (RscSelectCIBField5.Enabled) Then
            ToggleBorder(RscSelectCIBField5, panelField5)
        End If

    End Sub

    Private Sub RscSelectCIBField1_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField1.RSCFieldChanged

        ''Added 5/5/2022 td
        If (RscSelectCIBField1.SelectedValue <> EnumCIBFields.Undetermined) Then
            AddBorder(RscSelectCIBField1, panelField1)
        End If

        ''Unlock the next field.
        RscSelectCIBField2.Enabled = True

    End Sub


    Private Sub RscSelectCIBField2_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField2.RSCFieldChanged

        ''Added 5/5/2022 td
        If (RscSelectCIBField2.SelectedValue <> EnumCIBFields.Undetermined) Then
            AddBorder(RscSelectCIBField2, panelField2)
        End If

        ''Unlock the next field.
        RscSelectCIBField3.Enabled = True

    End Sub


    Private Sub RscSelectCIBField3_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField3.RSCFieldChanged

        ''Added 5/5/2022 td
        If (RscSelectCIBField3.SelectedValue <> EnumCIBFields.Undetermined) Then
            AddBorder(RscSelectCIBField3, panelField3)
        End If

        ''Unlock the next field.
        RscSelectCIBField4.Enabled = True

    End Sub


    Private Sub RscSelectCIBField5_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField5.RSCFieldChanged

        ''Added 5/5/2022 td
        If (RscSelectCIBField5.SelectedValue <> EnumCIBFields.Undetermined) Then
            AddBorder(RscSelectCIBField5, panelField5)
        End If

        ''Unlock the next field.
        RscSelectCIBField5.Enabled = True

    End Sub


    Private Sub RscSelectCIBField4_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField4.RSCFieldChanged

        ''Added 5/5/2022 td
        If (RscSelectCIBField4.SelectedValue <> EnumCIBFields.Undetermined) Then
            AddBorder(RscSelectCIBField4, panelField4)
        End If

        ''Unlock the next field.
        RscSelectCIBField5.Enabled = True

    End Sub

    Private Sub CtlGraphicQRCode1_RSCControlClicked_1() Handles CtlGraphicQRCode1.RSCControlClicked
        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicQRCode1, PanelQRCode)

    End Sub

    Private Sub LinkHowManyTextLabels_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkHowManyTextLabels.LinkClicked

    End Sub
End Class