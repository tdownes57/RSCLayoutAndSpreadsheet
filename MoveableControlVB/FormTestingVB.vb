''
''Added 12/28/2021 thomas d.
''
Imports ciBadgeDesigner ''Added 12/28 
Imports ciBadgeInterfaces ''Added 12/28/2021 

Public Class FormTestingVB

    Private MenuCache_NonShared_Field As MenuCache_NonShared
    Private MenuCache_NonShared_Portrait As MenuCache_NonShared
    Private MenuCache_NonShared_QRCode As MenuCache_NonShared
    Private MenuCache_NonShared_Signature As MenuCache_NonShared
    Private MenuCache_NonShared_StaticText As MenuCache_NonShared
    Private MenuCache_NonShared_GraphicText As MenuCache_NonShared

    ''Added 12/28/2021 thomas
    Private mod_designer As New ClassDesigner()
    Private MoveableControlVB41 As MoveableControlVB

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/28/2021 thomas d.
        ''
        ''MenuCache_Generic.GenerateMenuItems_IfNeeded() ''Dec28 2021 td'' (Nothing)

        ''''Added 12/28/2021 thomas d.
        ''Dim operationsField As New Operations_Generic ''Operations_Field
        ''Dim operationsPortrait As New Operations_Useless ''Operations_Portrait
        ''Dim operationsQRCode As New Operations_Generic ''Operations_QRCode
        ''Dim operationsSignature As New Operations_Useless ''Operations_Signature
        ''Dim operationsStaticText As New Operations_Generic ''Operations_StaticText
        ''Dim operationsGraphicText As New Operations_Useless ''Operations_GraphicText 

        ''MenuCache_NonShared_Field = New MenuCache_NonShared(EnumElementType.Field,
        ''                                                    operationsField.GetType(),
        ''                                                    operationsField)
        ''MenuCache_NonShared_Portrait = New MenuCache_NonShared(EnumElementType.Portrait,
        ''                                                    operationsPortrait.GetType(),
        ''                                                    operationsPortrait)
        ''MenuCache_NonShared_QRCode = New MenuCache_NonShared(EnumElementType.QRCode,
        ''                                                    operationsQRCode.GetType(),
        ''                                                    operationsQRCode)
        ''MenuCache_NonShared_Signature = New MenuCache_NonShared(EnumElementType.Signature,
        ''                                                    operationsSignature.GetType(),
        ''                                                    operationsSignature)
        ''MenuCache_NonShared_StaticText = New MenuCache_NonShared(EnumElementType.StaticText,
        ''                                                    operationsStaticText.GetType(),
        ''                                                    operationsStaticText)
        ''MenuCache_NonShared_GraphicText = New MenuCache_NonShared(EnumElementType.Signature,
        ''                                                    operationsGraphicText.GetType(),
        ''                                                    operationsGraphicText)

        ''''Added 12/28/2021 td
        ''MoveableControlVB1.MyToolstripItemCollection = MenuCache_NonShared_Field.Tools_EditElementMenu
        ''MoveableControlVB2.MyToolstripItemCollection = MenuCache_NonShared_Portrait.Tools_EditElementMenu

        MoveableControlVB1.Visible = False
        MoveableControlVB2.Visible = False
        MoveableControlVB3.Visible = False
        MoveableControlVB4.Visible = False

        MoveableControlVB1.Dispose()
        MoveableControlVB2.Dispose()
        MoveableControlVB3.Dispose()
        MoveableControlVB4.Dispose()

        Me.Controls.Remove(MoveableControlVB1)
        Me.Controls.Remove(MoveableControlVB2)
        Me.Controls.Remove(MoveableControlVB3)
        Me.Controls.Remove(MoveableControlVB4)

        MoveableControlVB1 = Nothing
        MoveableControlVB2 = Nothing
        MoveableControlVB3 = Nothing
        MoveableControlVB4 = Nothing

        ''Added 12/28/2021 thomas
        Const c_bAddMoveabilityWithinConstructor As Boolean = False
        Const c_bAddClickabilityWithinConstructor As Boolean = False
        Const c_bAddMoveabilityAfterConstructor As Boolean = True
        Const c_bAddClickabilityAfterConstructor As Boolean = True

        ''Control #1 of 3. 
        Dim objSaveToModel1 As New ClassSaveToModel
        Dim objOperations1 As New Operations__Useless()
        MoveableControlVB1 = New MoveableControlVB(EnumElementType.Undetermined, False,
                                                   objSaveToModel1,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperations1.GetType(),
                                                   objOperations1,
                                                   c_bAddMoveabilityWithinConstructor,
                                                    c_bAddClickabilityWithinConstructor)
        objOperations1.CtlCurrentElement = MoveableControlVB1
        MoveableControlVB1.Left = 0
        MoveableControlVB1.Top = 0
        MoveableControlVB1.Visible = True
        If (c_bAddMoveabilityAfterConstructor) Then MoveableControlVB1.AddMoveability()
        If (c_bAddClickabilityAfterConstructor) Then MoveableControlVB1.AddClickability()
        Me.Controls.Add(MoveableControlVB1)
        MoveableControlVB1.Name = "MoveableControlVB1"

        ''Control #2 of 3. 
        Dim objSaveToModel2 As New ClassSaveToModel
        Dim objOperations2 As New Operations__Generic()
        MoveableControlVB2 = New MoveableControlVB(EnumElementType.Undetermined, False,
                                                   objSaveToModel1,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperations2.GetType(),
                                                   objOperations2,
                                                    c_bAddMoveabilityWithinConstructor,
                                                    c_bAddClickabilityWithinConstructor)
        objOperations2.CtlCurrentElement = MoveableControlVB2
        MoveableControlVB2.Left = 0
        MoveableControlVB2.Top = 10 + (MoveableControlVB1.Top + MoveableControlVB1.Height)
        MoveableControlVB2.Visible = True
        If (c_bAddMoveabilityAfterConstructor) Then MoveableControlVB2.AddMoveability()
        If (c_bAddClickabilityAfterConstructor) Then MoveableControlVB2.AddClickability()
        Me.Controls.Add(MoveableControlVB2)
        MoveableControlVB2.Name = "MoveableControlVB2"

        ''Control #3 of 3. 
        Dim objSaveToModel3 As New ClassSaveToModel
        Dim objOperations3 As New Operations__Useless()
        MoveableControlVB3 = New MoveableControlVB(EnumElementType.Undetermined, False,
                                                   objSaveToModel3,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperations3.GetType(),
                                                   objOperations3,
                                                    c_bAddMoveabilityWithinConstructor,
                                                    c_bAddClickabilityWithinConstructor)
        objOperations3.CtlCurrentElement = MoveableControlVB3
        MoveableControlVB3.Left = 0
        MoveableControlVB3.Top = 10 + (MoveableControlVB2.Top + MoveableControlVB2.Height)
        MoveableControlVB3.Visible = True
        If (c_bAddMoveabilityAfterConstructor) Then MoveableControlVB3.AddMoveability()
        If (c_bAddClickabilityAfterConstructor) Then MoveableControlVB3.AddClickability()
        Me.Controls.Add(MoveableControlVB3)
        MoveableControlVB3.Name = "MoveableControlVB3"


        ''
        ''Resize-Proportionally (Per Ratio Width-Height) Control #1 of 2.
        ''
        Const c_bResizeProportionally As Boolean = True
        Dim objSaveToModel41 As New ClassSaveToModel
        Dim objOperations41 As New Operations__Useless()
        MoveableControlVB41 = New MoveableControlVB(EnumElementType.Undetermined, c_bResizeProportionally,
                                                   objSaveToModel41,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperations41.GetType(),
                                                   objOperations41,
                                                    c_bAddMoveabilityWithinConstructor,
                                                    c_bAddClickabilityWithinConstructor)
        objOperations41.CtlCurrentElement = MoveableControlVB41
        With MoveableControlVB41
            MoveableControlJane.Visible = False
            .Left = MoveableControlJane.Left ''0
            .Width = MoveableControlJane.Width
            .Height = MoveableControlJane.Height
            ''Dec28 ''.Top = 10 + (MoveableControlVB3.Top + MoveableControlVB3.Height)
            .Top = MoveableControlJane.Top
            .BackgroundImage = My.Resources.JaneMulvey
            .BackgroundImageLayout = ImageLayout.Zoom
            Dim singleRatioWtoH As Single
            singleRatioWtoH = CType(.BackgroundImage.Width, Single) / .BackgroundImage.Height
            .Width = (.Height * singleRatioWtoH)
            .Visible = True
            If (c_bAddMoveabilityAfterConstructor) Then .AddMoveability()
            If (c_bAddClickabilityAfterConstructor) Then .AddClickability()
            .Name = "MoveableControlVB41"
        End With
        Me.Controls.Add(MoveableControlVB41)



        ''
        ''Resize-Proportionally (Per Ratio Width-Height) Control #1 of 2.
        ''
        Const c_bAddMoveabilityForBackground As Boolean = False ''Added 12/28/2021 td 
        Dim objSaveToModelBack As New ClassSaveToModel
        Dim objOperationsBack As New Operations__Useless()
        Me.Controls.Remove(MoveableControlVBBack)
        MoveableControlVBBack.Visible = True
        Dim tempBack As MoveableControlVB = MoveableControlVBBack
        MoveableControlVBBack = New MoveableControlVB(EnumElementType.Undetermined, c_bResizeProportionally,
                                                   objSaveToModelBack,
                                                   CType(mod_designer, ILayoutFunctions),
                                                   mod_designer, objOperationsBack.GetType(),
                                                   objOperationsBack,
                                                    c_bAddMoveabilityForBackground,
                                                    c_bAddClickabilityWithinConstructor)
        objOperationsBack.CtlCurrentElement = MoveableControlVBBack
        With MoveableControlVBBack
            .Left = tempBack.Left ''0
            .Width = tempBack.Width
            .Height = tempBack.Height
            ''Dec28 ''.Top = 10 + (MoveableControlVB3.Top + MoveableControlVB3.Height)
            .Top = tempBack.Top
            .BackgroundImage = My.Resources.layout_cyanDiag
            .BackgroundImageLayout = ImageLayout.Zoom
            Dim singleRatioWtoH As Single
            singleRatioWtoH = CType(.BackgroundImage.Width, Single) / .BackgroundImage.Height
            .Width = (.Height * singleRatioWtoH)
            .Visible = True
            If (c_bAddMoveabilityForBackground And c_bAddMoveabilityAfterConstructor) Then .AddMoveability()
            If (c_bAddClickabilityAfterConstructor) Then .AddClickability()
            .Name = "MoveableControlVBBack"
        End With
        ''Add it to the form.  
        Me.Controls.Add(MoveableControlVBBack)


    End Sub

End Class
