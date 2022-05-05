Imports ciBadgeInterfaces ''Added 5/3/2022 td 
Imports ciBadgeDesigner ''Added 5/4/2022 td
Imports ciBadgeCachePersonality ''Added 5/5/2022 td
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
    ''
    ''Added 5/3/2022 thomas d. 
    ''
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated)
        ''
        ''Added 5/5/2022 thomas downes
        ''
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mod_cache = par_cache
        ''RscSelectCIBField1.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField2.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField3.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField4.Load_FieldsFromCache(par_cache)
        ''RscSelectCIBField5.Load_FieldsFromCache(par_cache)

    End Sub


    Private Sub ToggleBorder(par_control As UserControl, par_panel As Panel) ''---As RSCMoveableControlVB) ''As Control)
        ''
        ''Added 5/3/2022 thomas downes 
        ''
        If (par_control.BorderStyle = BorderStyle.None) Then

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


    Private Function GetCIBFieldToAdd(par_RSCSelectField As RSCSelectCIBField,
                                      par_intFieldIndex As Integer,
            Optional pboolAskAboutMissingSelection As Boolean = True,
            Optional ByRef pref_bMismatch As Boolean = True) As Boolean
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
            bSelectionBorder = (.BorderStyle <> BorderStyle.None)
            ''5/5/2022''pref_bMismatch = (bSubstantiveField <> bSelectionBorder)
            boolMismatch = (bSubstantiveField <> bSelectionBorder)
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


    Private Function HasBorder(par_control As UserControl) As Boolean
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
            boolBorderIsNone = (par_control.BorderStyle <> BorderStyle.None)
            Return (Not boolBorderIsNone) '' (par_control.BorderStyle <> BorderStyle.None)

        End If ''end of ""If (TypeOf par_control Is CtlGraphicStaticTextV3) Then....ElseIf..."


    End Function ''End of ""Private Function HasBorder(par_control As Control) As Boolean""


    Private Function HasValue(par_control As RSCSelectCIBField)

        ''Added 5/5/2022 td
        Dim boolNotDetermined As Boolean

        boolNotDetermined = (par_control.GetFieldEnumSelected() =
            EnumCIBFields.Undetermined)

        Return (Not boolNotDetermined)

    End Function


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
        Me.AddField1 = (HasBorder(RscSelectCIBField1) Or HasValue(RscSelectCIBField1)) ''GetCIBFieldToAdd(RscSelectCIBField1, 1) ''1.BorderStyle <> BorderStyle.None)
        Me.AddField2 = (HasBorder(RscSelectCIBField2) Or HasValue(RscSelectCIBField2)) ''GetCIBFieldToAdd(RscSelectCIBField2, 2) ''2.BorderStyle <> BorderStyle.None)
        Me.AddField3 = (HasBorder(RscSelectCIBField3) Or HasValue(RscSelectCIBField3)) ''GetCIBFieldToAdd(RscSelectCIBField3, 3) ''3.BorderStyle <> BorderStyle.None)
        Me.AddField4 = (HasBorder(RscSelectCIBField4) Or HasValue(RscSelectCIBField4)) ''GetCIBFieldToAdd(RscSelectCIBField4, 4) ''4.BorderStyle <> BorderStyle.None)
        Me.AddField5 = (HasBorder(RscSelectCIBField5) Or HasValue(RscSelectCIBField5)) ''GetCIBFieldToAdd(RscSelectCIBField5, 5) ''5.BorderStyle <> BorderStyle.None)

        ''Conditions added 5/5/2022 td
        If (Me.AddField1) Then Me.AddField1_Enum = GetCIBFieldToAdd(RscSelectCIBField1, 1, True, bMismatchOfIntention) ''1.BorderStyle <> BorderStyle.None)
        If (Me.AddField2) Then Me.AddField2_Enum = GetCIBFieldToAdd(RscSelectCIBField2, 2, True, bMismatchOfIntention) ''2.BorderStyle <> BorderStyle.None)
        If (Me.AddField3) Then Me.AddField3_Enum = GetCIBFieldToAdd(RscSelectCIBField3, 3, True, bMismatchOfIntention) ''3.BorderStyle <> BorderStyle.None)
        If (Me.AddField4) Then Me.AddField4_Enum = GetCIBFieldToAdd(RscSelectCIBField4, 4, True, bMismatchOfIntention) ''4.BorderStyle <> BorderStyle.None)
        If (Me.AddField5) Then Me.AddField5_Enum = GetCIBFieldToAdd(RscSelectCIBField5, 5, True, bMismatchOfIntention) ''5.BorderStyle <> BorderStyle.None)

        If (bMismatchOfIntention) Then Exit Sub ''Added 5/5/2022 td

        Me.AddQRCode = (CtlGraphicQRCode1.BorderStyle <> BorderStyle.None)
        Me.AddSignature = (CtlGraphicSignature1.BorderStyle <> BorderStyle.None)
        Me.AddGraphic = (CtlGraphicStaticGraphic1.BorderStyle <> BorderStyle.None)
        Me.AddPortraitPic = (CtlGraphicPortrait1.BorderStyle <> BorderStyle.None)
        Me.AddStaticText = (CtlGraphicStaticText1.BorderStyle <> BorderStyle.None)

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
        ToggleBorder(CType(sender, Control), PanelPortraitPic)

    End Sub

    Private Sub CtlGraphicStaticGraphic1_Click(sender As Object, e As EventArgs) Handles CtlGraphicStaticGraphic1.Click

        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), PanelGraphic)

    End Sub

    Private Sub CtlGraphicStaticText1_Click(sender As Object, e As EventArgs) Handles CtlGraphicStaticText1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), PanelStaticText)

    End Sub

    Private Sub RscSelectCIBField1_Click(sender As Object, e As EventArgs) Handles RscSelectCIBField1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), Nothing)

    End Sub

    Private Sub CtlGraphicSignature1_Click(sender As Object, e As EventArgs) Handles CtlGraphicSignature1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), PanelSignature)

    End Sub

    Private Sub CtlGraphicQRCode1_Click(sender As Object, e As EventArgs)
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), PanelQRCode)

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

        Load_FieldsFromCache(RscSelectCIBField1, mod_cache)
        Load_FieldsFromCache(RscSelectCIBField2, mod_cache)
        Load_FieldsFromCache(RscSelectCIBField3, mod_cache)
        Load_FieldsFromCache(RscSelectCIBField4, mod_cache)
        Load_FieldsFromCache(RscSelectCIBField5, mod_cache)

    End Sub

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
        ''Unlock the next field.
        RscSelectCIBField2.Enabled = True

    End Sub

    Private Sub RscSelectCIBField2_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField2.RSCFieldChanged
        ''Unlock the next field.
        RscSelectCIBField3.Enabled = True

    End Sub

    Private Sub RscSelectCIBField3_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField3.RSCFieldChanged
        ''Unlock the next field.
        RscSelectCIBField4.Enabled = True

    End Sub

    Private Sub RscSelectCIBField4_RSCFieldChanged(newCIBField As EnumCIBFields) Handles RscSelectCIBField4.RSCFieldChanged
        ''Unlock the next field.
        RscSelectCIBField5.Enabled = True

    End Sub

End Class