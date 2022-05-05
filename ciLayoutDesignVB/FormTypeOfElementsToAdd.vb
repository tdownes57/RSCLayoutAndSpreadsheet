Imports ciBadgeInterfaces ''Added 5/3/2022 td 
Imports ciBadgeDesigner ''Added 5/4/2022 td
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

    Public Sub New(par_cache As ciBadgeCachePersonality.ClassElementsCache_Deprecated)
        ''
        ''Added 5/5/2022 thomas downes
        ''
        RscSelectCIBField1.Load_FieldsFromCache(par_cache)
        RscSelectCIBField2.Load_FieldsFromCache(par_cache)
        RscSelectCIBField3.Load_FieldsFromCache(par_cache)
        RscSelectCIBField4.Load_FieldsFromCache(par_cache)
        RscSelectCIBField5.Load_FieldsFromCache(par_cache)

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
            End If ''end of ""If (par_panel IsNot Nothing) Then""

        Else

            par_control.BorderStyle = BorderStyle.None
            ''Hide the panel.
            If (par_panel IsNot Nothing) Then par_panel.Visible = False

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
        ''Dim boolMismatch As Boolean

        With par_RSCSelectField
            enumCIBField = .GetFieldEnumSelected()
            bSubstantiveField = (enumCIBField <> EnumCIBFields.Undetermined)
            bSelectionBorder = (.BorderStyle <> BorderStyle.None)
            pref_bMismatch = (bSubstantiveField <> bSelectionBorder)

            If (pboolAskAboutMissingSelection) Then

                MessageBoxTD.Show_Statement(" " &
                  String.Format("Which Relevant Field do you want? Field {0} is blank.",
                                par_intFieldIndex),
                  "Please de-select any fields which don't have a specific field selected.")

            End If ''End of ""If (pboolAskAboutMissingSelection) Then""

        End With

        Return enumCIBField

    End Function ''End of ""Private Function GetCIBFieldToAdd(...)"


    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''Added 5/3/2022 td
        Me.AddField1_Enum = GetCIBFieldToAdd(RscSelectCIBField1, 1) ''1.BorderStyle <> BorderStyle.None)
        Me.AddField2_Enum = GetCIBFieldToAdd(RscSelectCIBField2, 2) ''2.BorderStyle <> BorderStyle.None)
        Me.AddField3_Enum = GetCIBFieldToAdd(RscSelectCIBField3, 3) ''3.BorderStyle <> BorderStyle.None)
        Me.AddField4_Enum = GetCIBFieldToAdd(RscSelectCIBField4, 4) ''4.BorderStyle <> BorderStyle.None)
        Me.AddField5_Enum = GetCIBFieldToAdd(RscSelectCIBField5, 5) ''5.BorderStyle <> BorderStyle.None)

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

    Private Sub CtlGraphicQRCode1_Click(sender As Object, e As EventArgs) Handles CtlGraphicQRCode1.Click
        ''Added 5/3/2022 td
        ToggleBorder(CType(sender, Control), PanelQRCode)

    End Sub

    Private Sub CtlGraphicPortrait1_Load_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub FormTypeOfElementsToAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CtlGraphicPortrait1_RSCControlClicked() Handles CtlGraphicPortrait1.RSCControlClicked

        ''Added 5/4/2022 td
        ToggleBorder(CtlGraphicPortrait1, PanelPortraitPic)

    End Sub

    Private Sub CtlGraphicQRCode1_RSCControlClicked() Handles CtlGraphicQRCode1.RSCControlClicked
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



End Class