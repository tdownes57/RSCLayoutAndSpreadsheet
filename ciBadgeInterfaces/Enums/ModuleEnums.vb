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




End Module
