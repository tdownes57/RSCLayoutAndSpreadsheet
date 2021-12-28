''
''Added 12/28/2021 thomas d.
''
Public Class FormTestingVB

    Private MenuCache_NonShared_Field As MenuCache_NonShared
    Private MenuCache_NonShared_Portrait As MenuCache_NonShared
    Private MenuCache_NonShared_QRCode As MenuCache_NonShared
    Private MenuCache_NonShared_Signature As MenuCache_NonShared
    Private MenuCache_NonShared_StaticText As MenuCache_NonShared
    Private MenuCache_NonShared_GraphicText As MenuCache_NonShared

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 12/28/2021 thomas d.
        ''
        MenuCache_Generic.GenerateMenuItems_IfNeeded() ''Dec28 2021 td'' (Nothing)

        ''Added 12/28/2021 thomas d.
        Dim operationsField As New Operations_Generic ''Operations_Field
        Dim operationsPortrait As New Operations_Useless ''Operations_Portrait
        Dim operationsQRCode As New Operations_Generic ''Operations_QRCode
        Dim operationsSignature As New Operations_Useless ''Operations_Signature
        Dim operationsStaticText As New Operations_Generic ''Operations_StaticText
        Dim operationsGraphicText As New Operations_Useless ''Operations_GraphicText 

        MenuCache_NonShared_Field = New MenuCache_NonShared(EnumElementType.Field,
                                                            operationsField.GetType(),
                                                            operationsField)
        MenuCache_NonShared_Portrait = New MenuCache_NonShared(EnumElementType.Portrait,
                                                            operationsPortrait.GetType(),
                                                            operationsPortrait)
        MenuCache_NonShared_QRCode = New MenuCache_NonShared(EnumElementType.QRCode,
                                                            operationsQRCode.GetType(),
                                                            operationsQRCode)
        MenuCache_NonShared_Signature = New MenuCache_NonShared(EnumElementType.Signature,
                                                            operationsSignature.GetType(),
                                                            operationsSignature)
        MenuCache_NonShared_StaticText = New MenuCache_NonShared(EnumElementType.StaticText,
                                                            operationsStaticText.GetType(),
                                                            operationsStaticText)
        MenuCache_NonShared_GraphicText = New MenuCache_NonShared(EnumElementType.Signature,
                                                            operationsGraphicText.GetType(),
                                                            operationsGraphicText)

        ''Added 12/28/2021 td
        MoveableControlVB1.MyToolstripItemCollection = MenuCache_NonShared_Field.Tools_EditElementMenu
        MoveableControlVB2.MyToolstripItemCollection = MenuCache_NonShared_Portrait.Tools_EditElementMenu



    End Sub
End Class
