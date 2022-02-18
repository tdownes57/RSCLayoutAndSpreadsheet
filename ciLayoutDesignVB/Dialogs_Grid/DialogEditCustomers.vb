Option Explicit On
Option Strict On
''
'' Added 2/15/2022 thomas downes
''
Imports ciBadgeCustomer ''Added 2/15/2022 thomas d. 
Imports ciBadgeCachePersonality ''Added 2/15/2022 thomas d. 
''
''Added 2/15/2022 thomas downes
''

Public Class DialogEditCustomers
    ''
    '' Added 2/15/2022 thomas downes
    ''
    Public Property StartingFromScratch_NoXML As Boolean ''Added 2/16/2022 td

    Public Property Output_HashCustomers As HashSet(Of ClassCustomer) ''Added 2/17/2022 t2
    Public Property Output_ListCustomers As List(Of ClassCustomer) ''Added 2/17/2022 t2

    Private mod_hashCustomerObjs As HashSet(Of ClassCustomer)
    Private mod_hashCustomerRows As New HashSet(Of ClassRowOfControlsPerCustomer) ''(Of ClassRowOfCustomer)
    Private mod_cacheOfCustomers As New ciBadgeCachePersonality.ClassCacheListCustomers

    ''Private Class ClassRowOfCustomer
    ''    ''
    ''    ''Added 2/15/2022 thomas 
    ''    ''
    ''    Public Customer As ClassCustomer
    ''    Public TextboxCode As TextBox
    ''    Public TextboxName As TextBox
    ''    Public TextboxNotes As TextBox

    ''    Public Sub New(par_control As PopulateCustomers, par_index As Integer,
    ''                   par_customer As ClassCustomer)

    ''        If (par_index = 1) Then TextboxCode = par_control.textboxCode1
    ''        If (par_index = 2) Then TextboxCode = par_control.textboxCode2
    ''        If (par_index = 3) Then TextboxCode = par_control.textboxCode3
    ''        If (par_index = 4) Then TextboxCode = par_control.textboxCode4
    ''        If (par_index = 5) Then TextboxCode = par_control.textboxCode5
    ''        If (par_index = 6) Then TextboxCode = par_control.textboxCode6
    ''        If (par_index = 7) Then TextboxCode = par_control.textboxCode7
    ''        If (par_index = 8) Then TextboxCode = par_control.textboxCode8
    ''        If (par_index = 9) Then TextboxCode = par_control.textboxCode9
    ''        If (par_index = 10) Then TextboxCode = par_control.textboxCode10
    ''        If (par_index = 11) Then TextboxCode = par_control.textboxCode11
    ''        If (par_index = 12) Then TextboxCode = par_control.textboxCode12

    ''        If (par_index = 1) Then TextboxName = par_control.textboxName1
    ''        If (par_index = 2) Then TextboxName = par_control.textboxName2
    ''        If (par_index = 3) Then TextboxName = par_control.textboxName3
    ''        If (par_index = 4) Then TextboxName = par_control.textboxName4
    ''        If (par_index = 5) Then TextboxName = par_control.textboxName5
    ''        If (par_index = 6) Then TextboxName = par_control.textboxName6
    ''        If (par_index = 7) Then TextboxName = par_control.textboxName7
    ''        If (par_index = 8) Then TextboxName = par_control.textboxName8
    ''        If (par_index = 9) Then TextboxName = par_control.textboxName9
    ''        If (par_index = 10) Then TextboxName = par_control.textboxName10
    ''        If (par_index = 11) Then TextboxName = par_control.textboxName11
    ''        If (par_index = 12) Then TextboxName = par_control.textboxName12

    ''        If (par_index = 1) Then TextboxNotes = par_control.textboxNotes1
    ''        If (par_index = 2) Then TextboxNotes = par_control.textboxNotes2
    ''        If (par_index = 3) Then TextboxNotes = par_control.textboxNotes3
    ''        If (par_index = 4) Then TextboxNotes = par_control.textboxNotes4
    ''        If (par_index = 5) Then TextboxNotes = par_control.textboxNotes5
    ''        If (par_index = 6) Then TextboxNotes = par_control.textboxNotes6
    ''        If (par_index = 7) Then TextboxNotes = par_control.textboxNotes7
    ''        If (par_index = 8) Then TextboxNotes = par_control.textboxNotes8
    ''        If (par_index = 9) Then TextboxNotes = par_control.textboxNotes9
    ''        If (par_index = 10) Then TextboxNotes = par_control.textboxNotes10
    ''        If (par_index = 11) Then TextboxNotes = par_control.textboxNotes11
    ''        If (par_index = 12) Then TextboxNotes = par_control.textboxNotes12

    ''        ''
    ''        ''Added 2/15/2022 
    ''        ''
    ''        Load_Customer(par_customer)

    ''    End Sub

    ''    Private Sub Load_Customer(par_customer As ClassCustomer)
    ''        ''
    ''        ''Added 2/15/2022 thomas downes  
    ''        ''
    ''        Me.Customer = par_customer ''Added 2/15/2022 thomas 

    ''        ''Populate the textboxes. 
    ''        TextboxCode.Text = par_customer.AlphanumericCode
    ''        TextboxName.Text = par_customer.NameFull
    ''        TextboxNotes.Text = par_customer.Description

    ''    End Sub ''End of "Public Sub Load_Customer"


    ''End Class ''end of "Private Class ClassRowOfCustomer" 


    Public Sub Load_Customers(par_pathToXML As String)
        ''
        '' Added 2/15/2022 thomas downes
        ''
        mod_cacheOfCustomers = ClassCacheListCustomers.GetCache(par_pathToXML)
        Load_Customers(mod_cacheOfCustomers.ListOfCustomers)

    End Sub ''End of "Public Sub Load_Customers"



    Public Sub Load_Customers(par_cacheCustomers As ClassCacheListCustomers)
        ''
        '' Added 2/15/2022 thomas downes
        ''
        mod_cacheOfCustomers = par_cacheCustomers
        Load_Customers(par_cacheCustomers.ListOfCustomers)

    End Sub ''End of "Public Sub Load_Customers"

    Private Sub Load_Customers(par_hashCustomers As HashSet(Of ciBadgeCustomer.ClassCustomer))
        ''
        '' Added 2/15/2022 thomas downes
        ''
        Dim each_rowOfCustomer As ClassRowOfControlsPerCustomer ''As ClassRowOfCustomer
        Dim intIndex As Integer = 0

        mod_hashCustomerObjs = par_hashCustomers

        For Each each_cust As ClassCustomer In par_hashCustomers

            intIndex += 1
            ''each_rowOfCustomer = New ClassRowOfCustomer(Me.PopulateCustomers1, intIndex)
            ''each_rowOfCustomer.Load_Customer(each_cust)
            each_rowOfCustomer = New ClassRowOfControlsPerCustomer(Me.PopulateCustomers1, intIndex, each_cust)
            mod_hashCustomerRows.Add(each_rowOfCustomer)

        Next each_cust

        ''
        ''Added 2/17/2022 thomas d. 
        ''
        ''---PopulateCustomers1.


    End Sub ''end of "Public Sub Load_Customers"  


    Private Function Save_GetCustomerHash() As HashSet(Of ClassCustomer)
        ''
        ''Added 2/17/2022 thomas downes
        ''
        Me.Output_HashCustomers =
              Me.PopulateCustomers1.Save_GetCustomerList()

        Return Me.Output_HashCustomers

    End Function ''End of "Private Function Save_GetCustomerList()" 



    Private Sub DialogEditCustomers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        ''
        ''Added 2/25/2022 thomas downes
        ''
        Dim hashsetCustomersEdited As New HashSet(Of ClassCustomer)

        hashsetCustomersEdited =
          Save_GetCustomerHash()

        Me.mod_cacheOfCustomers.ListOfCustomers = hashsetCustomersEdited
        Me.mod_cacheOfCustomers.SaveToXML()
        Me.Close()

    End Sub




End Class