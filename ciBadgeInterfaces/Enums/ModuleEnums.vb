''
'' Added 12/13/2021 thomas downes  
''

Public Module ModuleEnums

    ''
    ''Moved to ciBadgeInterfaces on 12/13/2021. --- thomas.
    ''Added 12/8/2021 Thomas 
    ''
    Public Enum EnumWhichSideOfCard
        Undetermined
        EnumFrontside
        EnumBackside

    End Enum


    ''Added 1/19/2022 thomas downes
    Public Structure StructWhichSideOfCard
        ''Added 1/19/2022 thomas downes
        Dim EnumSide As EnumWhichSideOfCard
        Dim Backside As Boolean
    End Structure


    ''
    ''On 1/19/2022, I found the below code by copying the following Public Enum definition
    ''  from __RSC WindowsControlLibrary.Module1Enumerations.EnumElementType.
    ''
    ''  See __RSC WindowsControlLibrary.Module1Enumerations to see the original code. 
    ''   ----1/19/2022 td
    ''
    Public Enum Enum_ElementType

        Undetermined
        Field
        Portrait
        QRCode
        Signature
        StaticText
        StaticGraphic

        __Background ''Added 1/15/2022 td
        __Desktop ''Added 1/15/2022 td

    End Enum


End Module
