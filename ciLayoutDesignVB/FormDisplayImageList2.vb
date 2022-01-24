Option Explicit On ''Added 8/27/2019 td 
Option Strict On ''Added 8/27/2019 td 

Imports ciBadgeInterfaces ''Added 8/27/2019 td  
Imports ciBadgeElements ''Added 9/19/2019 td  

Public Class FormDisplayImageList2 ''Added 8/27/2019 td 

    ''-----Private _objListImages As List(Of Image) ''Added 8/27/2019 td 
    ''9/18/2019''Private _objListFieldsStd As List(Of ClassFieldStandard) ''Added 8/27/2019 td 
    ''9/18/2019''Private _objListFieldsCust As List(Of ClassFieldCustomized) ''Added 8/27/2019 td 
    Private mod_listOfElementFields As List(Of ClassElementField)

    ''9/18/2019 td''Public Sub New(par_listStd As List(Of ClassFieldStandard),
    ''               par_listCust As List(Of ClassFieldCustomized))

    ''    InitializeComponent()

    ''    ''----_objListImages = par_list ''Added 8/26/2019 td 

    ''    _objListFieldsStd = par_listStd
    ''    _objListFieldsCust = par_listCust

    ''End Sub

    Public Sub New(par_list As List(Of ClassElementField))

        InitializeComponent()

        ''
        ''Added 9/19/2019 td  
        ''
        mod_listOfElementFields = par_list ''Added 9/19/2019 td 

    End Sub

    Private Sub FormDisplayImageList_Load(sender As Object, e As EventArgs) Handles Me.Load

        Const c_LoadNow As Boolean = True ''False

        If (c_LoadNow) Then

            ''Me.FlowLayoutPanel1.Visible = True
            Me.Visible = True

            ''Added 8/26/2019 td 
            ''9/19/2019 td''LoadAllImagesToUI()
            LoadAllImagesToUI_ByElement()

            ''Added 8/26/2019 td 
            Me.Panel1.Refresh()

        End If ''End of "If (c_LoadNow) Then"

    End Sub

    Private Sub LoadAllImagesToUI_ByElement()
        ''
        ''Added 9/19/2019 td 
        ''
        Dim boolSkipIt As Boolean ''Added 9/4/2019 thomas d.

        For Each par_objElement As ClassElementField In mod_listOfElementFields

            ''Added 9/4/2019 thomas d.
            ''9/19 td''If (Not par_objField.IsDisplayedOnBadge()) Then Continue For

            ''11/15/2021 boolSkipIt = (Not par_objElement.IsDisplayedOnBadge_Visibly())
            Dim omitReason As New WhyOmittedStruct ''Added 11/15/2021 td
            boolSkipIt = (Not par_objElement.IsDisplayedOnBadge_Visibly(omitReason))

            If (boolSkipIt) Then Continue For

            ''Major call !!
            LoadEachImageToUI(par_objElement.Image_BL, CType(par_objElement, IElement_Base))

        Next par_objElement

    End Sub ''End of "Private Sub LoadAllImagesToUI_ByElement()"

    Private Sub LoadAllImagesToUI_ByField_Denigrated()
        ''
        ''Added 8/26/2019 td 
        ''
        ''For Each par_objField As ClassFieldStandard In _objListFieldsStd
        ''
        ''    ''objImage = par_objField.
        ''
        ''    ''Added 9/4/2019 thomas d.
        ''    If (Not par_objField.IsDisplayedOnBadge) Then Continue For
        ''
        ''    ''Major call !!
        ''    LoadEachImageToUI(par_objField.ElementFieldClass.Image_BL, CType(par_objField.ElementFieldClass, IElement_Base))
        ''
        ''Next par_objField

        ''For Each par_objField As ClassFieldCustomized In _objListFieldsCust
        ''
        ''    ''Added 9/4/2019 thomas d.
        ''    If (Not par_objField.IsDisplayedOnBadge) Then Continue For
        ''
        ''    ''Major call !!
        ''    LoadEachImageToUI(par_objField.ElementFieldClass.Image_BL, CType(par_objField.ElementFieldClass, IElement_Base))
        ''
        ''Next par_objField

    End Sub ''End of "Private Sub LoadAllImagesToUI_ByField_Denigrated()"

    Private Sub LoadEachImageToUI(par_image As Image, par_element As IElement_Base)
        '' 
        ''Added 8/26/2019 td 
        ''
        Dim new_picturebox As New PictureBox

        Me.Panel1.Controls.Add(new_picturebox)

        With new_picturebox

            .Image = CType(par_image.Clone, Image)
            .SizeMode = PictureBoxSizeMode.Normal
            .Visible = True

            ''Added 8/27/2019 td
            .Left = par_element.LeftEdge_Pixels
            .Top = par_element.TopEdge_Pixels

            .Width = par_image.Width ''+ 3
            .Height = par_image.Height ''+ 3
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Beige

            .Refresh()

        End With

        Me.Panel1.Refresh()

    End Sub ''End of "Private Sub LoadEachImageToUI(par_image As Image, par_element As IElement_Ba   se)"

    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click

        Me.Panel1.Controls.Clear()

        ''Added 8/26/2019 td 
        ''9/19/2019 td''LoadAllImagesToUI()
        LoadAllImagesToUI_ByElement()

        ''Added 8/26/2019 td 
        Me.Panel1.Refresh()

    End Sub
End Class

