''
''Added 1/31/2022 td
''
Option Explicit On ''Added 8/29/2019 td
Option Strict On ''Added 8/29/2019 td
Option Infer Off ''Added 8/29/2019 td  

Imports ciBadgeInterfaces
Imports ciBadgeElements ''Added 9/18/2019 td 
''Imports ciBadgeElemImage ''Added 9/20/2019 td 
''Imports System.Windows.Forms ''Added 10/1/2019 td
Imports System.Drawing ''Added 10/1/2019 td  
Imports __RSCWindowsControlLibrary ''Added 1/4/2022 thomas d.

Public Class CtlGraphicStaticTextV4
    ''
    ''Added 1/31/2022 td
    ''
    Public Shared Function GetStaticTextControl(par_parametersGetElementControl As ClassGetElementControlParams,
                                           par_elementStaticText As ClassElementStaticTextV4,
                                           par_formParent As Form,
                                           par_oDesigner As ClassDesigner,
                                      par_nameOfControl As String,
                                      par_iLayoutFun As ILayoutFunctions,
                                           par_sizeNeeded As Size,
                                par_iRecordLastTouched As IRecordElementLastTouched,
                                par_iControlLastTouched As ILastControlTouched,
                                par_oMoveEventsForGroupedCtls As GroupMoveEvents_Singleton) As CtlGraphicStaticTextV4
        ''
        ''Added 1/31/2021 td
        ''
        ''//Const c_enumElemType As EnumElementType = EnumElementType.Field
        Const bAddFunctionalitySooner As Boolean = False
        Const bAddFunctionalityLater As Boolean = True

        Dim typeOps As Type
        Dim objOperations As Object ''Added 12/29/2021 td 
        Dim objOperationsStaticText As Operations_StaticTextV4
        Dim sizeFieldElement As Size ''Added 1/26/2022 td

        ''Instantiate the Operations Object. 
        objOperationsStaticText = New Operations_StaticTextV4() ''Added 1/31/2022 td
        typeOps = objOperationsStaticText.GetType()
        objOperations = objOperationsStaticText

        If (objOperations Is Nothing) Then
            ''Added 12/29/2021
            Throw New Exception("Ops is Nothing, so I guess Element Type is Undetermined.")
        End If ''end of "If (objOperations Is Nothing) Then"

        ''Added 12/2/2022 td
        Dim enumElementType_Enum As EnumElementType = EnumElementType.Field

        ''Create the control.
        Dim CtlStaticText As CtlGraphicStaticTextV4

        ''Public Sub New(par_elementField As ClassElementField,
        ''                par_layout As ILayoutFunctions,
        ''                pstrWhyWasICreated As String,
        ''                par_formRecordLastTouched As IRecordElementLastTouched)

        CtlStaticText = New CtlGraphicStaticTextV4(par_elementStaticText,
                                               par_formParent,
                                               par_oDesigner, par_iLayoutFun,
                                         par_parametersGetElementControl.iRefreshPreview,
                                               par_sizeNeeded,
                                                   "Called by GetFieldElement.",
                                                   typeOps, objOperations,
                                                   bAddFunctionalitySooner,
                                                   bAddFunctionalitySooner,
                                                   par_iRecordLastTouched,
                                                   par_iControlLastTouched,
                                                    par_oMoveEventsForGroupedCtls)
        ''Jan2 2022 ''                       ''Jan2 2022 ''par_iSaveToModel, typeOps,

        With CtlStaticText
            .Name = par_nameOfControl
            ''Jan11 2022''If (bAddFunctionalityLater) Then .AddMoveability(par_oMoveEvents, par_iLayoutFun)
            If (bAddFunctionalityLater) Then .AddMoveability(par_iLayoutFun,
                                                             par_oMoveEventsForGroupedCtls, Nothing)
            If (bAddFunctionalityLater) Then .AddClickability()
        End With ''eNd of "With CtlQRCode1"

        ''
        ''Specify the current element to the Operations object. 
        ''
        Dim infoOps As ICurrentElement = CType(objOperations, ICurrentElement)
        infoOps.CtlCurrentElement = CtlStaticText

        ''Added 1/17/2022 td 
        infoOps.ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager

        ''Added 1/24/2022 thomas d. 
        With objOperationsStaticText

            .CtlCurrentControl = CtlStaticText
            .CtlCurrentElement = CtlStaticText
            .CtlCurrentElementStaticText = CtlStaticText ''Added 1/24/2022 td
            ''.Designer = par_oMoveEventsForGroupedCtls.
            .Designer = par_parametersGetElementControl.DesignerClass
            .ElementInfo_Base = par_elementStaticText
            .ElementsCacheManager = par_parametersGetElementControl.ElementsCacheManager
            .Element_Type = Enum_ElementType.StaticGraphic
            .EventsForMoveability_Group = par_oMoveEventsForGroupedCtls
            .EventsForMoveability_Single = Nothing
            .LayoutFunctions = .Designer ''Added 1/24/2022 td

        End With ''End of "With objOperationsFldElem"

        Return CtlStaticText

    End Function ''end of "Public Shared Function GetFieldElement() As CtlGraphicFldLabel"


    Public Sub New(pstrWhyCreated As String)

        ''Added 1/31/2022 td
        MyBase.New(pstrWhyCreated)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub


    Public Sub New(par_elementField As ClassElementStaticTextV4,
                   par_oParentForm As Form,
                   par_oDesigner As ClassDesigner,
                   par_iLayoutFun As ILayoutFunctions,
                   par_iRefreshPreview As IRefreshCardPreview,
                   par_iSizeDesired As Size,
                   pstrWhyWasICreated As String,
                   par_operationsType As Type,
                   par_operationsAny As Object,
                   pboolAddMoveability As Boolean,
                   pboolAddClickability As Boolean,
                   par_iRecordLastTouched As IRecordElementLastTouched,
                   par_iLastTouched As ILastControlTouched,
                   par_oMoveEvents As GroupMoveEvents_Singleton,
                   Optional par_singleDummy As Single = 0)
        ''Jan4 2022'' par_formRecordLastTouched As IRecordElementLastTouched,

        ''Dim singleDummy As Single = 0 ''Added 1/4/2022 td 

        ''Added 1/4/2022 td
        MyBase.New(EnumElementType.Field,
                        par_elementField,
                        par_oParentForm,
                        par_oDesigner,
                        par_iLayoutFun, par_iRefreshPreview, par_iSizeDesired,
                        pstrWhyWasICreated,
                par_operationsType, par_operationsAny,
                        pboolAddMoveability, pboolAddClickability,
                        par_iRecordLastTouched,
                        par_iLastTouched, par_oMoveEvents,
                        par_singleDummy)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ''Jan31 2022 td''Me.FieldInfo = par_elementField.FieldInfo
        Me.ParentDesigner = par_oDesigner ''Added 1/5/2022 td

        Me.ElementClass_Obj = par_elementField
        Me.ElementInfo_Base = CType(par_elementField, IElement_Base)
        ''10/12/2019 td''Me.ElementInfo_Text = CType(par_elementField, IElement_TextField)
        Me.ElementInfo_TextOnly = CType(par_elementField, IElement_TextOnly) ''Modified 10/12/2019 td
        ''1/2/2022 td''Me.ElementInfo_Field = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td
        Me.ElementInfo_TextField = CType(par_elementField, IElement_TextField) ''Added 10/12/2019 td

        Me.LayoutFunctions = par_iLayoutFun
        Me.LayoutFunctions = par_iLayoutFun

        ''Added 9/20/2019 td 
        ''   Add an alert to the user that the element is not rendered
        ''   on the Badge.  ----9/20/2019 td 
        Dim bElementInvisibleOnBadge As Boolean
        bElementInvisibleOnBadge = (Not Me.ElementInfo_Base.Visible)
        LinkMessageFYI.Visible = bElementInvisibleOnBadge

        ''Added 11/28/2021 thomas d.
        WhyWasICreated = pstrWhyWasICreated

        ''Added 12/17/2021 td
        mod_formRecordLastTouched = par_iRecordLastTouched

    End Sub ''ENd of "Public Sub New "



End Class
