''
''Added 5/5/2022 thomas downes
''
Imports ciBadgeInterfaces ''Added 5/5/2022 
Imports ciBadgeCachePersonality ''Added 5/5/2022

Public Class FormConditional
    ''
    ''Added 5/5/2022 thomas downes
    ''
    Public ConditionalExpressionInUse As Boolean ''Added 5/05/2022
    Public ConditionalExpressionField As EnumCIBFields ''Added 5/05/2022
    Public ConditionalExpressionValue As String ''Added 5/05/2022
    Public ConditionalExp_LastEdited As Date ''Added 5/05/2022
    Public ConditionalExp_AllowBlanks As Boolean ''Added 5/30/2022
    Public ConditionalExp_PreviewDisplay As Boolean ''Added 5/30/2022

    Private mod_bIsLoading As Boolean = True


    Public Sub New(par_cache As ClassElementsCache_Deprecated,
                   par_base As ciBadgeElements.ClassElementBase)

        ''5/27/2022 Public Sub New(par_cache As ClassElementsCache_Deprecated)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 5/27/2022 td
        Me.ConditionalExpressionField = par_base.ConditionalExpressionField
        Me.ConditionalExpressionInUse = par_base.ConditionalExpressionInUse
        Me.ConditionalExpressionValue = par_base.ConditionalExpressionValue
        ''Added 5/30/2022 td
        Me.ConditionalExp_AllowBlanks = par_base.ConditionalExp_AllowBlanks
        Me.ConditionalExp_PreviewDisplay = par_base.ConditionalExp_PreviewDisplay

        ' Add any initialization after the InitializeComponent() call.
        RscSelectCIBField_Simple1.Load_FieldsFromCache(par_cache)

        RscSelectCIBField_Simple1.SelectedValue = Me.ConditionalExpressionField
        TextBoxRelevantValue.Text = Me.ConditionalExpressionValue
        CheckBoxActivated.Checked = Me.ConditionalExpressionInUse
        PanelExpression.Enabled = Me.ConditionalExpressionInUse
        Application.DoEvents()

        ''Added 5/30/2022 td
        checkboxBlankValuesOkay.Checked = par_base.ConditionalExp_AllowBlanks
        checkboxPreviewDisplay.Checked = par_base.ConditionalExp_PreviewDisplay

ExitHandler:
        mod_bIsLoading = False

    End Sub


    Public Sub New_NotInUse(par_cache As ClassElementsCache_Deprecated, par_infoBase As IElement_Base)
        ''5/27/2022 Public Sub New(par_cache As ClassElementsCache_Deprecated)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 5/27/2022 td
        ''May 28 2022 Me.ConditionalExpressionField = par_infoBase.ConditionalExpressionField
        ''May 28 2022 Me.ConditionalExpressionInUse = par_infoBase.ConditionalExpressionInUse
        ''May 28 2022 Me.ConditionalExpressionValue = par_infoBase.ConditionalExpressionValue

        ' Add any initialization after the InitializeComponent() call.
        RscSelectCIBField_Simple1.Load_FieldsFromCache(par_cache)

        RscSelectCIBField_Simple1.SelectedValue = Me.ConditionalExpressionField
        TextBoxRelevantValue.Text = Me.ConditionalExpressionValue
        CheckBoxActivated.Checked = Me.ConditionalExpressionInUse
        checkboxBlankValuesOkay.Checked = Me.ConditionalExp_AllowBlanks ''May30 2022
        checkboxPreviewDisplay.Checked = Me.ConditionalExp_PreviewDisplay ''May30 2022
        PanelExpression.Enabled = Me.ConditionalExpressionInUse
        Application.DoEvents()

ExitHandler:
        mod_bIsLoading = False

    End Sub


    Public Sub New(par_cache As ClassElementsCache_Deprecated)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RscSelectCIBField_Simple1.Load_FieldsFromCache(par_cache)

ExitHandler:
        mod_bIsLoading = False

    End Sub



    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click

        ''moved down''Me.DialogResult = DialogResult.OK
        Dim boolValueIsBlank As Boolean ''Added  5/30/2022
        ''Added  5/30/2022
        boolValueIsBlank = String.IsNullOrWhiteSpace(TextBoxRelevantValue.Text)
        If (boolValueIsBlank) Then
            If (Not checkboxBlankValuesOkay.Checked) Then
                ''Added  5/30/2022
                MessageBoxTD.Show_Statement("Supply a value, or mark the 'Blanks are okay' box.")
                Exit Sub
            End If ''end of If (Not checkboxBlankValuesOkay.Checked) Then
        End If ''End of ""If (boolValueIsBlank) Then""

        Me.ConditionalExpressionInUse = CheckBoxActivated.Checked
        Me.ConditionalExpressionField = RscSelectCIBField_Simple1.GetFieldEnumSelected()
        Me.ConditionalExpressionValue = TextBoxRelevantValue.Text
        Me.ConditionalExp_LastEdited = Now ''Added 5/5/2022 td

        Me.ConditionalExp_AllowBlanks = checkboxBlankValuesOkay.Checked ''May30 2022
        Me.ConditionalExp_PreviewDisplay = checkboxPreviewDisplay.Checked ''May30 2022

        If (ConditionalExpressionInUse) Then
            If (Me.ConditionalExpressionField = EnumCIBFields.Undetermined) Then
                MessageBoxTD.Show_Statement("Relevant Field is not selected.")
                Exit Sub
            End If

            If (String.IsNullOrEmpty(Me.ConditionalExpressionValue)) Then
                MessageBoxTD.Show_Statement("Conditional Value is blank space, or not supplied.")
                Exit Sub
            End If

        End If ''end ""If (ConditionalExpressionInUse) Then""

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.DialogResult = DialogResult.Cancel
        ''---Me.SelectedEnumCIBField = RscSelectCIBField_Simple1.GetFieldEnumSelected()
        Me.Close()

    End Sub

    Private Sub FormConditional_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBoxRelevantValue_TextChanged(sender As Object, e As EventArgs) Handles TextBoxRelevantValue.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxActivated.CheckedChanged

        ''Added 5/5/2022 
        If mod_bIsLoading Then Exit Sub
        PanelExpression.Enabled = CheckBoxActivated.Checked


    End Sub

    Private Sub LinkLabelActivateThis_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelActivateThis.LinkClicked
        ''
        ''Added 5/29/2022 td
        ''
        If (Not PanelExpression.Enabled) Then

            PanelExpression.Enabled = True
            MessageBoxTD.Show_Statement("This box is now activated.")
            CheckBoxActivated.Checked = True

        ElseIf (CheckBoxActivated.Checked) Then

            PanelExpression.Enabled = True
            MessageBoxTD.Show_Statement("This box is already activated.")

        Else

            CheckBoxActivated.Checked = True
            PanelExpression.Enabled = True
            MessageBoxTD.Show_Statement("This box is now activated.")

        End If

    End Sub
End Class