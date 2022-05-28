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

        ' Add any initialization after the InitializeComponent() call.
        RscSelectCIBField_Simple1.Load_FieldsFromCache(par_cache)

        RscSelectCIBField_Simple1.SelectedValue = Me.ConditionalExpressionField
        TextBoxRelevantValue.Text = Me.ConditionalExpressionValue
        CheckBoxActivated.Checked = Me.ConditionalExpressionInUse
        PanelExpression.Enabled = Me.ConditionalExpressionInUse
        Application.DoEvents()

ExitHandler:
        mod_bIsLoading = False

    End Sub


    Public Sub New(par_cache As ClassElementsCache_Deprecated, par_infoBase As IElement_Base)
        ''5/27/2022 Public Sub New(par_cache As ClassElementsCache_Deprecated)

        ' This call is required by the designer.
        InitializeComponent()

        ''Added 5/27/2022 td
        Me.ConditionalExpressionField = par_infoBase.ConditionalExpressionField
        Me.ConditionalExpressionInUse = par_infoBase.ConditionalExpressionInUse
        Me.ConditionalExpressionValue = par_infoBase.ConditionalExpressionValue

        ' Add any initialization after the InitializeComponent() call.
        RscSelectCIBField_Simple1.Load_FieldsFromCache(par_cache)

        RscSelectCIBField_Simple1.SelectedValue = Me.ConditionalExpressionField
        TextBoxRelevantValue.Text = Me.ConditionalExpressionValue
        CheckBoxActivated.Checked = Me.ConditionalExpressionInUse
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

        Me.ConditionalExpressionInUse = CheckBoxActivated.Checked
        Me.ConditionalExpressionField = RscSelectCIBField_Simple1.GetFieldEnumSelected()
        Me.ConditionalExpressionValue = TextBoxRelevantValue.Text
        Me.ConditionalExp_LastEdited = Now ''Added 5/5/2022 td

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
End Class