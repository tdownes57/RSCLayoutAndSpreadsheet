Module ModRSCLayout
    ''
    '' Added 4/7/2022 thomas downes  
    ''
    Public Const PixelsFromRowToRow As Integer = 24 ''Added 4/05/2022 td
    Public Const PixelsMargin As Integer = 1 ''Added 4/05/2022 td
    Public Const PixelsWidthDefault As Integer = 0 ''Added 4/05/2022 td

    Public Sub PositionAndSizeControlByRow(par_intRowIndex As Integer,
                                           par_intIndex1Control_Top As Integer,
                                           Optional par_intColumnWidth As Integer = 0,
                    Optional par_control As Control = Nothing,
                    Optional ByRef par_size As Drawing.Size = Nothing,
                    Optional ByRef par_location As Drawing.Point = Nothing)
        ''
        ''Added 4/7/2022 thomas downes  
        ''
        par_size = New Drawing.Size
        par_location = New Drawing.Point

        par_size.Height = (PixelsFromRowToRow - PixelsMargin)
        par_size.Width = PixelsWidthDefault
        If (0 < par_intColumnWidth) Then par_size.Width = par_intColumnWidth

        par_location.X = 0
        par_location.Y = par_intIndex1Control_Top +
            (PixelsFromRowToRow * (par_intRowIndex - 1))

        If (par_control IsNot Nothing) Then
            With par_control

                .Size = par_size
                .Location = par_location

            End With
        End If 'ENd of ""If (par_control IsNot Nothing) Then""

    End Sub ''Endof ""Public Sub PositionAndSizeControlByRow""


End Module
