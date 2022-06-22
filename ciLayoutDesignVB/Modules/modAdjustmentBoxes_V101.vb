''
''Added 7/17/2019 thomas downes 
''
Module modAdjustmentBoxes_V101
    ''
    ''Added 7/17/2019 thomas downes 
    ''
    ''For Images\AdjustWHColor_V01.jpg   
    ''
    Public Enum Enum_V101
        Undetermined
        WidthIncrease
        WidthDecrease
        HeightIncrease
        HeightDecrease
        ColorsOfMSPaint ''7/17 td ColorRGB
    End Enum

    Public EntireGraphic_Width As Integer = 772
    Public EntireGraphic_Height As Integer = 612

    Public WidthIncrease_Top_ As Integer = 85
    Public WidthIncrease_Left As Integer = 175
    Public WidthIncrease_Rght As Integer = 750
    Public WidthIncrease_Btm_ As Integer = 140

    Public WidthDecrease_Top_ As Integer = 155
    Public WidthDecrease_Left As Integer = 175
    Public WidthDecrease_Rght As Integer = 750
    Public WidthDecrease_Btm_ As Integer = 210

    Public HeightIncrease_Top_ As Integer = 16
    Public HeightIncrease_Left As Integer = 18
    Public HeightIncrease_Rght As Integer = 77
    Public HeightIncrease_Btm_ As Integer = 593

    Public HeightDecrease_Top_ As Integer = 16
    Public HeightDecrease_Left As Integer = 98
    Public HeightDecrease_Rght As Integer = 152
    Public HeightDecrease_Btm_ As Integer = 593

    Public ColorsOfMSPaint_Top_ As Integer = 16
    Public ColorsOfMSPaint_Left As Integer = 178
    Public ColorsOfMSPaint_Rght As Integer = 731
    Public ColorsOfMSPaint_Btm_ As Integer = 65

    Public Function UserClickedWhichAdjustment(par_Left As Integer, par_Top As Integer,
                                               par_widthOfGraphic As Integer) As Enum_V101
        ''7/17 td''Public Function UserClickedWhichAdjustment(par_Left As Integer, par_Top As Integer) As Enum_V101
        ''
        ''Added 7/17/2019 td 
        ''
        Dim singleScalingFactor As Single
        Dim sf As Single
        Dim sf_wLeft As Single
        Dim sf_wTop As Single

        singleScalingFactor = (CSng(EntireGraphic_Width) / CSng(par_widthOfGraphic))
        sf = singleScalingFactor

        sf_wLeft = CInt(sf * par_Left)
        sf_wTop = CInt(sf * par_Top)

        Select Case True
            Case WidthIncrease(sf_wLeft, sf_wTop) : Return Enum_V101.WidthIncrease
            Case WidthDecrease(sf_wLeft, sf_wTop) : Return Enum_V101.WidthDecrease
            Case HeightIncrease(sf_wLeft, sf_wTop) : Return Enum_V101.HeightIncrease
            Case HeightDecrease(sf_wLeft, sf_wTop) : Return Enum_V101.HeightDecrease
            Case ColorsOfMSPaint(sf_wLeft, sf_wTop) : Return Enum_V101.ColorsOfMSPaint
            Case Else : Return Enum_V101.Undetermined
        End Select

    End Function ''ENd of "Public Function UserClickedWhichAdjustment(par_Left As Integer, par_Top As Integer) As Enum_V101"

    Private Function WidthIncrease(par_Left As Single, par_Top As Single) As Boolean
        ''---6/2022---Private Function WidthIncrease(par_Left As Integer, par_Top As Integer) As Boolean
        ''
        ''Added 7/17/2019 td 
        ''
        Return (WidthIncrease_Left <= par_Left And par_Left <= WidthIncrease_Rght) And
            (WidthIncrease_Top_ <= par_Top And par_Top <= WidthIncrease_Btm_)

    End Function ''End of ""Private Function WidthIncrease""


    Private Function WidthDecrease(par_Left As Single, par_Top As Single) As Boolean
        ''---6/2022---Private Function WidthDecrease(par_Left As Integer, par_Top As Integer) As Boolean
        ''
        ''Added 7/17/2019 td 
        ''
        Return (WidthDecrease_Left <= par_Left And par_Left <= WidthDecrease_Rght) And
            (WidthDecrease_Top_ <= par_Top And par_Top <= WidthDecrease_Btm_)

    End Function ''End of ""Private Function WidthDecrease""

    Private Function HeightIncrease(par_Left As Single, par_Top As Single) As Boolean
        ''--6/2022--Private Function HeightIncrease(par_Left As Integer, par_Top As Integer) As Boolean
        ''
        ''Added 7/17/2019 td 
        ''
        Return (HeightIncrease_Left <= par_Left And par_Left <= HeightIncrease_Rght) And
            (HeightIncrease_Top_ <= par_Top And par_Top <= HeightIncrease_Btm_)

    End Function ''End of ""Private Function HeightIncrease""


    Private Function HeightDecrease(par_Left As Single, par_Top As Single) As Boolean
        ''--6/2022--Private Function HeightDecrease(par_Left As Integer, par_Top As Integer) As Boolean
        ''
        ''Added 7/17/2019 td 
        ''
        Return (HeightDecrease_Left <= par_Left And par_Left <= HeightDecrease_Rght) And
            (HeightDecrease_Top_ <= par_Top And par_Top <= HeightDecrease_Btm_)

    End Function ''End of ""Private Function HeightDecrease""


    Private Function ColorsOfMSPaint(par_Left As Single, par_Top As Single) As Boolean
        ''6/2022 Private Function ColorsOfMSPaint(par_Left As Integer, 
        ''
        ''Added 7/17/2019 td 
        ''
        Return (ColorsOfMSPaint_Left <= par_Left And par_Left <= ColorsOfMSPaint_Rght) And
            (ColorsOfMSPaint_Top_ <= par_Top And par_Top <= ColorsOfMSPaint_Btm_)

    End Function ''End of ""Private Function ColorsOfMSPaint""

End Module ''Module modAdjustmentBoxes_V101
