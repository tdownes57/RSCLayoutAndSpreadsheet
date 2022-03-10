''
''Added 2/10/2022 td
''
Imports ciBadgeInterfaces


Public Class PopulateRecipientField_NotInUse
    ''
    ''Added 2/10/2022 td
    ''
    Private mod_recipients As List(Of ClassRecipient)
    Private mod_enumRelevantCIBField As EnumCIBFields


    Public Sub LoadFieldsAndRecipients(par_recipients As List(Of ClassRecipient),
                                       par_listCIBFieldEnums As List(Of EnumCIBFields))
        ''
        ''Added 2/11/200 thomas downes  
        ''
        ''This is the first half of the current iteration of this nested loop!!
        ''   (w/ recursive procedural calls) 
        ''   ----2/11/2022 thomas downes
        ''
        mod_recipients = par_recipients

        mod_enumRelevantCIBField = par_listCIBFieldEnums.FirstOrDefault()

        ''Important!!  Remove the enumerated value from the loop.  
        ''   Otherwise, this might be an infinite loop. 
        ''   ----2/11/2022 thomas downes
        ''
        par_listCIBFieldEnums.Remove(mod_enumRelevantCIBField)

        ''
        ''If we have more fields, then go to the second-half of the current iteration of this nested loop!!   (w/ recursive procedural calls) 
        ''   ----2/11/2022 thomas downes
        ''
        If (par_listCIBFieldEnums.Count > 0) Then
            ''
            ''Go to the second-half of the current iteration of this nested loop!!
            ''   (w/ recursive procedural calls) 
            ''   ----2/11/2022 thomas downes
            LoadFieldsAndRecipients_NextField(par_recipients, par_listCIBFieldEnums)

        End If ''End of "If (par_listCIBFieldEnums.Count > 0) Then

    End Sub ''End of "Public Sub LoadFieldsAndRecipients"


    Public Sub LoadFieldsAndRecipients_NextField(par_recipients As List(Of ClassRecipient),
                                       par_listCIBFieldEnums As List(Of EnumCIBFields))
        ''
        ''Added 2/11/200 thomas downes  
        ''
        ''This is the second-half of the current iteration of this nested loop!!
        ''   (w/ recursive procedural calls) 
        ''   ----2/11/2022 thomas downes
        ''
        Dim next_control = New PopulateRecipientField_NotInUse
        Dim intSplitterDistace As Integer
        Dim intPanel1Width As Integer
        intSplitterDistace = Me.SplitContainer1.SplitterDistance
        intPanel1Width = Me.SplitContainer1.Panel1.Width
        Me.Width = 1.8 * Me.Width
        Me.SplitContainer1.SplitterDistance = intSplitterDistace ''Keep the Splitter distance the same!!
        Me.SplitContainer1.Panel1.Width = intPanel1Width ''Keep the width of Panel1 (Left-hand) the same!!
        ''
        ''Go to the next iteration of this nested loop!! 
        ''   (w/ recursive procedural calls) 
        ''
        SplitContainer1.Panel2.Controls.Add(next_control)
        next_control.Dock = System.Windows.Forms.DockStyle.Fill
        next_control.LoadFieldsAndRecipients(par_recipients, par_listCIBFieldEnums)

    End Sub ''End of "Public Sub LoadFieldsAndRecipients_NextField"


    Public Property WidthOfLeftPane As Integer
        Get
            Return SplitContainer1.SplitterDistance
        End Get
        Set(value As Integer)

            SplitContainer1.SplitterDistance = value

        End Set

    End Property


    Private Sub PopulateRecipientField_Load(sender As Object, e As EventArgs) Handles MyBase.Load




    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub






End Class
