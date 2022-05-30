Module ModRSCLayout
    ''
    '' Added 4/7/2022 thomas downes  
    ''
    Public Const PixelsFromRowToRow As Integer = 24 ''Added 4/05/2022 td
    Public Const PixelsMargin As Integer = 1 ''Added 4/05/2022 td
    Public Const PixelsWidthDefault As Integer = 0 ''Added 4/05/2022 td

    Public RowDisplayCardHeight As Integer ''= 0 ''Added 5/30/2022 td


    Public Sub PositionAndSizeControlByRow(par_control As Control,
                                           par_intRowIndex As Integer,
                                           par_intIndex1Control_Top As Integer,
                                           Optional par_intColumnWidth As Integer = 0)
        ''               Optional par_control As Control,
        ''               Optional ByRef par_size As Drawing.Size = Nothing,
        ''               Optional ByRef par_location As Drawing.Point = Nothing)
        ''
        ''Added 4/7/2022 thomas downes  
        ''
        ''4/8/2022 ''par_size = New Drawing.Size
        ''4/8/2022 ''par_location = New Drawing.Point
        Dim struct_size As New Drawing.Size
        Dim struct_location As New Drawing.Point

        ''4/8/2022 ''par_size.Height = (PixelsFromRowToRow - PixelsMargin)
        ''4/8/2022 ''par_size.Width = PixelsWidthDefault
        ''4/8/2022 ''If (0 < par_intColumnWidth) Then par_size.Width = par_intColumnWidth
        If (0 = par_intColumnWidth) Then par_intColumnWidth = PixelsWidthDefault

        ''4/8/2022 ''par_location.X = 0
        ''4/8/2022 ''par_location.Y = par_intIndex1Control_Top +
        ''4/8/2022 ''    (PixelsFromRowToRow * (par_intRowIndex - 1))

        ''5/30/2022 ''struct_size.Height = (PixelsFromRowToRow - PixelsMargin)
        ''5/30/2022 ''struct_size.Width = par_intColumnWidth ''PixelsWidthDefault
        ''5/30/2022 ''struct_location.X = 0
        ''5/30/2022 ''struct_location.Y = par_intIndex1Control_Top +
        ''    (PixelsFromRowToRow * (par_intRowIndex - 1))

        Dim intPixelsFromRowToRow As Integer ''Added 5/30/2022
        ''---intPixelsFromRowToRow = PixelsFromRowToRow
        intPixelsFromRowToRow = GetPixelsFromRowToRow()
        struct_size.Height = (intPixelsFromRowToRow - PixelsMargin)
        struct_size.Width = par_intColumnWidth ''PixelsWidthDefault
        struct_location.X = 0
        struct_location.Y = par_intIndex1Control_Top +
                    (intPixelsFromRowToRow * (par_intRowIndex - 1))

        If (par_control IsNot Nothing) Then
            With par_control

                ''4/8/2022 ''.Size = par_size
                ''4/8/2022 ''.Location = par_location
                .Size = struct_size
                .Location = struct_location

            End With
        End If 'ENd of ""If (par_control IsNot Nothing) Then""

    End Sub ''Endof ""Public Sub PositionAndSizeControlByRow""


    Public Function EmphasisOfRows_StartingY(par_intRowIndex As Integer,
                                  par_intIndex1Control_Top As Integer,
                                     par_intHeightOfBox As Integer) As Integer
        ''
        ''Added 4/27/2022 thomas downes
        ''
        Dim intTopofNthBox_TopY As Integer
        Dim intHalfOfMargin As Integer

        intTopofNthBox_TopY = par_intIndex1Control_Top +
            (PixelsFromRowToRow * (par_intRowIndex - 1))

        intHalfOfMargin = CInt(0.5 * (PixelsFromRowToRow - par_intHeightOfBox))

        ''\\---Return (intTopofNthBox_TopY - 1)
        Return (intTopofNthBox_TopY - intHalfOfMargin)

    End Function ''end of ""Public Function EmphasisOfRows_StartingY""


    Public Function EmphasisOfRows_EndingY(par_intRowIndex As Integer,
                                  par_intIndex1Control_Top As Integer,
                                   par_intHeightOfBox As Integer) As Integer
        ''
        ''Added 4/27/2022 thomas downes
        ''
        Dim intTopofNthBox_TopY As Integer
        Dim intHalfOfMargin As Integer

        intTopofNthBox_TopY = par_intIndex1Control_Top +
            (PixelsFromRowToRow * (par_intRowIndex - 1))

        intHalfOfMargin = CInt(0.5 * (PixelsFromRowToRow - par_intHeightOfBox))

        Return (intTopofNthBox_TopY + PixelsFromRowToRow - intHalfOfMargin)

    End Function ''endof ""Public Function EmphasisOfRows_EndingY""


    Private Function GetPixelsFromRowToRow() As Integer
        ''
        ''Added 5/30/2022
        ''
        If (RowDisplayCardHeight > PixelsFromRowToRow) Then

            Return RowDisplayCardHeight

        Else
            Return PixelsFromRowToRow

        End If ''end of ""If (RowDisplayCardHeight > PixelsFromRowToRow) Then... Else..."

    End Function ''end of ""Private Function GetPixelsFromRowToRow() As Integer""




End Module
