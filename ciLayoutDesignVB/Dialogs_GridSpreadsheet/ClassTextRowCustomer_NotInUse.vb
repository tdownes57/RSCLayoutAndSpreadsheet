
Option Explicit On
Option Strict On
''
'' Added 2/16/2022 & 2/15/2022 thomas downes
''
Imports ciBadgeCustomer ''Added 2/15/2022 thomas d. 
Imports ciBadgeCachePersonality ''Added 2/15/2022 thomas d. 

Friend Class ClassRowOfCustomer_NotInUse
    ''
    ''Added 2/16/2022 & 2/15/2022 thomas 
    ''
    Public Customer As ClassCustomer
    Public CheckboxActive As CheckBox
    Public TextboxCode As TextBox
    Public TextboxName As TextBox
    Public TextboxNotes As TextBox

    Public Sub New(par_control As PopulateCustomers, par_index As Integer,
                   par_customer As ClassCustomer)
        ''
        ''Assign the four(4) Control Properties. 
        ''
        ''   Control #1 of 4 CheckboxActive
        ''         ----Added 2/16/2022 thomas downes
        If (par_index = 1) Then CheckboxActive = par_control.checkbox1
        If (par_index = 2) Then CheckboxActive = par_control.checkbox2
        If (par_index = 3) Then CheckboxActive = par_control.checkbox3
        If (par_index = 4) Then CheckboxActive = par_control.checkbox4
        If (par_index = 5) Then CheckboxActive = par_control.checkbox5
        If (par_index = 6) Then CheckboxActive = par_control.checkbox6
        If (par_index = 7) Then CheckboxActive = par_control.checkbox7
        If (par_index = 8) Then CheckboxActive = par_control.checkbox8
        If (par_index = 9) Then CheckboxActive = par_control.checkbox9
        If (par_index = 10) Then CheckboxActive = par_control.checkbox10
        If (par_index = 11) Then CheckboxActive = par_control.checkbox11
        If (par_index = 12) Then CheckboxActive = par_control.checkbox12

        ''
        ''   Control #2 of 4 CheckboxActive
        ''
        If (par_index = 1) Then TextboxCode = par_control.textboxCode1
        If (par_index = 2) Then TextboxCode = par_control.textboxCode2
        If (par_index = 3) Then TextboxCode = par_control.textboxCode3
        If (par_index = 4) Then TextboxCode = par_control.textboxCode4
        If (par_index = 5) Then TextboxCode = par_control.textboxCode5
        If (par_index = 6) Then TextboxCode = par_control.textboxCode6
        If (par_index = 7) Then TextboxCode = par_control.textboxCode7
        If (par_index = 8) Then TextboxCode = par_control.textboxCode8
        If (par_index = 9) Then TextboxCode = par_control.textboxCode9
        If (par_index = 10) Then TextboxCode = par_control.textboxCode10
        If (par_index = 11) Then TextboxCode = par_control.textboxCode11
        If (par_index = 12) Then TextboxCode = par_control.textboxCode12

        ''
        ''   Control #3 of 4 CheckboxActive
        ''
        If (par_index = 1) Then TextboxName = par_control.textboxNameFull1
        If (par_index = 2) Then TextboxName = par_control.textboxNameFull2
        If (par_index = 3) Then TextboxName = par_control.textboxNameFull3
        If (par_index = 4) Then TextboxName = par_control.textboxNameFull4
        If (par_index = 5) Then TextboxName = par_control.textboxNameFull5
        If (par_index = 6) Then TextboxName = par_control.textboxNameFull6
        If (par_index = 7) Then TextboxName = par_control.textboxNameFull7
        If (par_index = 8) Then TextboxName = par_control.textboxNameFull8
        If (par_index = 9) Then TextboxName = par_control.textboxNameFull9
        If (par_index = 10) Then TextboxName = par_control.textboxNameFull10
        If (par_index = 11) Then TextboxName = par_control.textboxNameFull11
        If (par_index = 12) Then TextboxName = par_control.textboxNameFull12

        ''
        ''   Control #4 of 4 CheckboxActive
        ''
        If (par_index = 1) Then TextboxNotes = par_control.textboxNotes1
        If (par_index = 2) Then TextboxNotes = par_control.textboxNotes2
        If (par_index = 3) Then TextboxNotes = par_control.textboxNotes3
        If (par_index = 4) Then TextboxNotes = par_control.textboxNotes4
        If (par_index = 5) Then TextboxNotes = par_control.textboxNotes5
        If (par_index = 6) Then TextboxNotes = par_control.textboxNotes6
        If (par_index = 7) Then TextboxNotes = par_control.textboxNotes7
        If (par_index = 8) Then TextboxNotes = par_control.textboxNotes8
        If (par_index = 9) Then TextboxNotes = par_control.textboxNotes9
        If (par_index = 10) Then TextboxNotes = par_control.textboxNotes10
        If (par_index = 11) Then TextboxNotes = par_control.textboxNotes11
        If (par_index = 12) Then TextboxNotes = par_control.textboxNotes12


        ''
        ''Added 2/15/2022 
        ''
        Load_Customer(par_customer)

    End Sub

    Private Sub Load_Customer(par_customer As ClassCustomer)
        ''
        ''Added 2/15/2022 thomas downes  
        ''
        Me.Customer = par_customer ''Added 2/15/2022 thomas 

        ''Populate the textboxes. 
        TextboxCode.Text = par_customer.AlphanumericCode
        TextboxName.Text = par_customer.NameFull
        TextboxNotes.Text = par_customer.Description

        ''Added 2/16/2022 thomas d
        CheckboxActive.Checked = True
        CheckboxActive.Tag = Me

    End Sub ''End of "Public Sub Load_Customer"


End Class ''end of "Private Class ClassRowOfCustomer_NotInUse" 