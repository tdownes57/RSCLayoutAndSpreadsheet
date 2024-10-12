''
''Added 1/8/2024 
''
''This is a subclass of the LinkLabel control.
''

Public Class LinkLabelTwoChar
    ''
    ''This is a subclass of the LinkLabel control.
    ''
    Public TwoCharacterItem As TwoCharacterDLLItem
    Public LinkLabel_Next As LinkLabelTwoChar
    Public LinkLabel_Prior As LinkLabelTwoChar

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(par_twoCharItem As TwoCharacterDLLItem,
                   par_priorLabelTwoChar As LinkLabelTwoChar,
                   pbUseLinkVisitedColor As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = par_twoCharItem.ToString()
        Me.VisitedLinkColor = Color.RebeccaPurple
        Me.LinkVisited = pbUseLinkVisitedColor
        Me.TwoCharacterItem = par_twoCharItem

        With par_priorLabelTwoChar
            Me.Top = .Top
            Me.Left = .Left + .Width + 5
            ''Provide a link from the prior to the current link-label subclass control. 
            .LinkLabel_Next = Me
            ''Provide a link to the prior link-label subclass control. 
            Me.LinkLabel_Prior = par_priorLabelTwoChar
        End With

        Me.Visible = True

    End Sub




End Class
