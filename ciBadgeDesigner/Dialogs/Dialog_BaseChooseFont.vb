Option Explicit On ''Added 8/7/2022 Thomas Downes
Option Strict On ''Added 8/7/2022 Thomas Downes
''
''Added 8/7/2022 Thomas Downes  
''
Imports ciBadgeDesigner ''Added 8/7/2022 Thomas Downes
Imports ciBadgeElements ''Added 8/7/2022 Thomas Downes
Imports ciBadgeInterfaces ''Added 8/7/2022 Thomas Downes


Public Class Dialog_BaseChooseFont
    ''----Inherits Dialog_Base ''Added 8/7/2022 Thomas Downes  
    ''
    ''Added 8/7/2022 Thomas Downes  
    ''
    Private mod_listMSFontFamilyNames As List(Of String)

    Public Sub New(par_controlFieldOrTextV4 As CtlGraphicFieldOrTextV4,
                   par_listFontFamilyNames As HashSet(Of String),
                   par_listRSCColors As HashSet(Of RSCColor),
                   par_elementBase As ClassElementBase,
                   par_infoElemBase As IElement_Base,
                   par_designer As ClassDesigner,
                   par_events As GroupMoveEvents_Singleton,
                   Optional par_imageOfBadge As Drawing.Image = Nothing)
        ''
        ''Added 5/31/2022 td 
        ''
        ''8/10/2022 MyBase.New(par_controlFieldOrTextV4,
        ''           par_elementBase, par_infoElemBase,
        ''           par_designer, par_events,
        ''           par_imageOfBadge)
        MyBase.New(par_controlFieldOrTextV4,
                   par_listFontFamilyNames,
                   par_listRSCColors,
                   par_elementBase, par_infoElemBase,
                   par_designer, par_events,
                   par_imageOfBadge)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub LinkLabelAddFont_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAddFont.LinkClicked
        ''
        ''Add 8/07/2022 
        ''
        Dim strFontFamilyName As String

        FontDialog1.ShowDialog()
        strFontFamilyName = FontDialog1.Font.Name
        mod_listMSFontFamilyNames.Add(strFontFamilyName)

        Dim newLabel As New Label
        ''newLabel.BackColor = each_color
        newLabel.Text = strFontFamilyName ''each_color.Name
        newLabel.Visible = True
        ''newLabel.ToolTip
        ''Me.ToolTip1.SetToolTip(Me.ButtonBackground, "Set Background Color of the Element")
        Me.ToolTip1.SetToolTip(newLabel, strFontFamilyName) '' each_color.Name)
        flowLayoutFontFamilies.Controls.Add(newLabel)




    End Sub

    Private Sub Dialog_BaseChooseFont_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''
        ''Added 9/13/2022 thomas downes
        ''
        Dim bFlowMissingLinkLabel As Boolean ''Added 9/13/2022

        ''Added 9/13/2022
        bFlowMissingLinkLabel = (Not flowLayoutFontFamilies.Controls.Contains(LinkLabelAddFont))

        ''Added 9/13/2022
        If (bFlowMissingLinkLabel) Then

            Me.Controls.Remove(LinkLabelAddFont)
            flowLayoutFontFamilies.Controls.Add(LinkLabelAddFont)

        End If ''Endof ""If (bFlowMissingLinkLabel) Then""




    End Sub




End Class