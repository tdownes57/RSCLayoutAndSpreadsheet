''
''Added 7/4/2022 thomas downes 
''
Public Interface InterfaceCacheToXML
    ''
    ''Added 7/4/2022 thomas downes 
    ''
    Sub SaveToXML(pstrPathToFileXML As String)

    Sub SaveToXML_CommonPrefix(pstrCommonPrefix As String,
                               pstrUncommonName As String,
                               pstrPathToFolder As String,
                               pboolAddTimestamp As Boolean)



End Interface
