''
''Added 3/20/2023 thomas downes
''
''  PP = Public Property Lists 
''
Imports ciBadgeElements

Public Class ClassListOfElements
    ''
    ''Added 3/20/2023 thomas downes
    ''
    Public Property List_FieldsV3 As New List(Of ClassElementFieldV3)
    Public Property List_FieldsV4 As New List(Of ClassElementFieldV4)
    Public Property List_Graphics As New List(Of ClassElementGraphic)
    Public Property List_Portraits As New List(Of ClassElementPortrait)
    Public Property List_QRCodes As New List(Of ClassElementQRCode)
    Public Property List_Signatures As New List(Of ClassElementSignature)
    Public Property List_StaticTextsV3 As New List(Of ClassElementStaticTextV3)
    Public Property List_StaticTextsV4 As New List(Of ClassElementStaticTextV4)
    Public Property List_LayoutSections As New List(Of ClassElementLaysection)

    Public Sub New(par_listFields As List(Of ClassElementFieldV4),
                   par_listGraphics As List(Of ClassElementGraphic),
                   par_listStaticTexts As List(Of ClassElementStaticTextV4),
                   par_listPortraits As List(Of ClassElementPortrait),
                   Optional par_listQRCodes As List(Of ClassElementQRCode) = Nothing,
                   Optional par_listSignatures As List(Of ClassElementSignature) = Nothing,
                   Optional par_listLayoutSections As List(Of ClassElementLaysection) = Nothing)
        ''
        '' Added 3/29/2023  
        ''
        Me.List_FieldsV4 = par_listFields
        Me.List_Graphics = par_listGraphics
        Me.List_StaticTextsV4 = par_listStaticTexts
        Me.List_Portraits = par_listPortraits

        ''
        ''Probably not super important...
        ''
        Me.List_QRCodes = par_listQRCodes
        Me.List_Signatures = par_listSignatures
        Me.List_LayoutSections = par_listLayoutSections

    End Sub ''End of ""Public Sub New"


    Public Function GetListOfElems_Base() As List(Of ClassElementBase)
        ''
        '' Added 3/29/2023  
        ''
        Dim objListOfElemBases As New List(Of ClassElementBase)

        objListOfElemBases.AddRange(Me.List_FieldsV4)
        objListOfElemBases.AddRange(Me.List_Graphics)
        objListOfElemBases.AddRange(Me.List_Portraits)
        objListOfElemBases.AddRange(Me.List_StaticTextsV4)

        ''
        ''Probably not very important.
        ''
        objListOfElemBases.AddRange(Me.List_QRCodes)
        objListOfElemBases.AddRange(Me.List_Signatures)
        objListOfElemBases.AddRange(Me.List_LayoutSections)

        Return objListOfElemBases

    End Function ''End of ""Public Function GetListOfElems_Base()""


    Public Function GetCopy_Shallow(Optional pbOnlyIfSelected As Boolean = False) As ClassListOfElements
        ''
        '' Added 3/29/2023  
        ''
        Dim objNewCopy_Shallow As ClassListOfElements

        objNewCopy_Shallow = New ClassListOfElements(
                            Me.List_FieldsV4,
                            Me.List_Graphics,
                            Me.List_StaticTextsV4,
                            Me.List_Portraits)

        ''
        ''Probably not super important...
        ''
        With objNewCopy_Shallow
            .List_QRCodes = Me.List_QRCodes
            .List_Signatures = Me.List_Signatures
            .List_LayoutSections = Me.List_LayoutSections

            ''
            ''With Optional Boolean parameter...
            ''
            If (pbOnlyIfSelected) Then

                .List_FieldsV4 = OnlySelected_FieldsV4()
                .List_Graphics = OnlySelected_Graphics()
                .List_Portraits = OnlySelected_Portraits()
                .List_StaticTextsV4 = OnlySelected_StaticTextsV4()

            End If ''End of "If (pbOnlyIfSelected) Then"

        End With

        Return objNewCopy_Shallow

    End Function ''End of ""Public Function GetCopy_Shallow() As ClassListOfElements""


    Public Function OnlySelected_Graphics() As List(Of ClassElementGraphic)
        ''
        ''Added 3/29/2023 thomas downes
        ''
        Dim objListTemp1 As List(Of ClassElementGraphic)
        Dim objListTemp2 As New List(Of ClassElementGraphic)

        objListTemp1 = Me.List_Graphics
        objListTemp2.AddRange(objListTemp1.Where(Function(x As ClassElementBase)
                                                     Return x.SelectedHighlighting
                                                 End Function))
        Return objListTemp2

    End Function


    Public Function OnlySelected_Portraits() As List(Of ClassElementPortrait)

        Dim objListTemp1 As List(Of ClassElementPortrait)
        Dim objListTemp2 As New List(Of ClassElementPortrait)

        objListTemp1 = Me.List_Portraits
        objListTemp2.AddRange(objListTemp1.Where(Function(x As ClassElementBase)
                                                     Return x.SelectedHighlighting
                                                 End Function))
        Return objListTemp2

    End Function


    Public Function OnlySelected_StaticTextsV4() As List(Of ClassElementStaticTextV4)

        Dim objListTemp1 As List(Of ClassElementStaticTextV4)
        Dim objListTemp2 As New List(Of ClassElementStaticTextV4)

        objListTemp1 = Me.List_StaticTextsV4
        objListTemp2.AddRange(objListTemp1.Where(Function(x As ClassElementBase)
                                                     Return x.SelectedHighlighting
                                                 End Function))
        Return objListTemp2

    End Function


    Public Function OnlySelected_FieldsV4() As List(Of ClassElementFieldV4)

        Dim objListTemp1 As List(Of ClassElementFieldV4)
        Dim objListTemp2 As New List(Of ClassElementFieldV4)

        objListTemp1 = Me.List_FieldsV4
        objListTemp2.AddRange(objListTemp1.Where(Function(x As ClassElementBase)
                                                     Return x.SelectedHighlighting
                                                 End Function))
        Return objListTemp2

    End Function


    Public Function GetListsOfPreselectedElems() As ClassListOfElements
        ''
        '' Added 3/29/2023  
        ''
        Dim output As ClassListOfElements
        Const c_bOnlySelecteds As Boolean = True
        output = GetCopy_Shallow(c_bOnlySelecteds)
        Return output

    End Function ''End of ""Public Function GetCopyOfPreselecteds() As ClassListOfElements""


End Class
