
Option Explicit On
Option Strict On
''
'' Added 2/16/2022 & 2/15/2022 thomas downes
''
''Imports ciBadgeCustomer ''Added 2/15/2022 thomas d. 
''Imports ciBadgeCachePersonality ''Added 2/15/2022 thomas d. 
Imports System.Windows.Forms ''Added2/16/2022 td

Public Class ClassRowOfControlsPerCustomer
    ''----Private Class ClassRowOfCustomer
    ''
    ''Added 2/16/2022 & 2/15/2022 thomas 
    ''
    Public CustomerIsNull As Boolean ''Added 2/17/2022 td
    Public Customer As ClassCustomer
    Public CheckboxActive As CheckBox
    Public TextboxCode As TextBox
    Public TextboxNameFull As TextBox ''Suffixed 2/17/2022 td
    Public TextboxNameShort As TextBox ''Added 2/17/2022 td 
    Public TextboxNotes As TextBox

    Public Sub New(par_controlContainer As PopulateCustomers, par_index As Integer,
                    par_nullCustomer As Boolean)
        ''
        ''Added 2/17/2022 td
        ''
        If (Not par_nullCustomer) Then Throw New ArgumentException

        Me.CustomerIsNull = par_nullCustomer
        Load_Controls(par_controlContainer, par_index)

    End Sub


    Public Sub New(par_controlContainer As PopulateCustomers, par_index As Integer,
                   par_customer As ClassCustomer)
        ''
        ''Added 2/17/2022 thomas downes
        ''
        Load_Controls(par_controlContainer, par_index)

        ''
        ''Added 2/15/2022 
        ''
        If (par_customer IsNot Nothing) Then

            Load_Customer(par_customer)

        End If ''Endo f "If (par_customer IsNot Nothing) Then"

    End Sub


    Private Sub Load_Controls(par_controlContainer As PopulateCustomers, par_index As Integer)
        ''
        ''Encapsulated 2/17/2022 td
        ''
        With par_controlContainer

            If (par_index = 1) Then TextboxCode = .textboxCode1
            If (par_index = 2) Then TextboxCode = .textboxCode2
            If (par_index = 3) Then TextboxCode = .textboxCode3
            If (par_index = 4) Then TextboxCode = .textboxCode4
            If (par_index = 5) Then TextboxCode = .textboxCode5
            If (par_index = 6) Then TextboxCode = .textboxCode6
            If (par_index = 7) Then TextboxCode = .textboxCode7
            If (par_index = 8) Then TextboxCode = .textboxCode8
            If (par_index = 9) Then TextboxCode = .textboxCode9
            If (par_index = 10) Then TextboxCode = .textboxCode10
            If (par_index = 11) Then TextboxCode = .textboxCode11
            If (par_index = 12) Then TextboxCode = .textboxCode12

            ''Added 2/17/2022 thomas downes   
            If (par_index = 1) Then TextboxNameShort = .textboxNameShort1
            If (par_index = 2) Then TextboxNameShort = .textboxNameShort2
            If (par_index = 3) Then TextboxNameShort = .textboxNameShort3
            If (par_index = 4) Then TextboxNameShort = .textboxNameShort4
            If (par_index = 5) Then TextboxNameShort = .textboxNameShort5
            If (par_index = 6) Then TextboxNameShort = .textboxNameShort6
            If (par_index = 7) Then TextboxNameShort = .textboxNameShort7
            If (par_index = 8) Then TextboxNameShort = .textboxNameShort8
            If (par_index = 9) Then TextboxNameShort = .textboxNameShort9
            If (par_index = 10) Then TextboxNameShort = .textboxNameShort10
            If (par_index = 11) Then TextboxNameShort = .textboxNameShort11
            If (par_index = 12) Then TextboxNameShort = .textboxNameShort12

            If (par_index = 1) Then TextboxNameFull = .textboxNameFull1
            If (par_index = 2) Then TextboxNameFull = .textboxNameFull2
            If (par_index = 3) Then TextboxNameFull = .textboxNameFull3
            If (par_index = 4) Then TextboxNameFull = .textboxNameFull4
            If (par_index = 5) Then TextboxNameFull = .textboxNameFull5
            If (par_index = 6) Then TextboxNameFull = .textboxNameFull6
            If (par_index = 7) Then TextboxNameFull = .textboxNameFull7
            If (par_index = 8) Then TextboxNameFull = .textboxNameFull8
            If (par_index = 9) Then TextboxNameFull = .textboxNameFull9
            If (par_index = 10) Then TextboxNameFull = .textboxNameFull10
            If (par_index = 11) Then TextboxNameFull = .textboxNameFull11
            If (par_index = 12) Then TextboxNameFull = .textboxNameFull12

            If (par_index = 1) Then TextboxNotes = .textboxNotes1
            If (par_index = 2) Then TextboxNotes = .textboxNotes2
            If (par_index = 3) Then TextboxNotes = .textboxNotes3
            If (par_index = 4) Then TextboxNotes = .textboxNotes4
            If (par_index = 5) Then TextboxNotes = .textboxNotes5
            If (par_index = 6) Then TextboxNotes = .textboxNotes6
            If (par_index = 7) Then TextboxNotes = .textboxNotes7
            If (par_index = 8) Then TextboxNotes = .textboxNotes8
            If (par_index = 9) Then TextboxNotes = .textboxNotes9
            If (par_index = 10) Then TextboxNotes = .textboxNotes10
            If (par_index = 11) Then TextboxNotes = .textboxNotes11
            If (par_index = 12) Then TextboxNotes = .textboxNotes12

            ''Added 2/16/2022 thomas downes
            If (par_index = 1) Then CheckboxActive = .checkbox1
            If (par_index = 2) Then CheckboxActive = .checkbox2
            If (par_index = 3) Then CheckboxActive = .checkbox3
            If (par_index = 4) Then CheckboxActive = .checkbox4
            If (par_index = 5) Then CheckboxActive = .checkbox5
            If (par_index = 6) Then CheckboxActive = .checkbox6
            If (par_index = 7) Then CheckboxActive = .checkbox7
            If (par_index = 8) Then CheckboxActive = .checkbox8
            If (par_index = 9) Then CheckboxActive = .checkbox9
            If (par_index = 10) Then CheckboxActive = .checkbox10
            If (par_index = 11) Then CheckboxActive = .checkbox11
            If (par_index = 12) Then CheckboxActive = .checkbox12

        End With

    End Sub


    Private Sub Load_Customer(par_customer As ClassCustomer)
        ''
        ''Added 2/15/2022 thomas downes  
        ''
        Me.Customer = par_customer ''Added 2/15/2022 thomas 

        ''Populate the textboxes. 
        TextboxCode.Text = par_customer.AlphanumericCode
        TextboxNameFull.Text = par_customer.NameFull
        TextboxNameShort.Text = par_customer.NameShort ''Added 2/17/2022 td
        TextboxNotes.Text = par_customer.Description

        ''Added 2/16/2022 thomas d
        CheckboxActive.Checked = True
        CheckboxActive.Tag = Me

    End Sub ''End of "Public Sub Load_Customer"


End Class ''end of "Private Class ClassRowOfCustomer" 