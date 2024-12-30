namespace RSCFields
{
    public class ClassFieldAny
    {

        public ClassFieldAny() { }

        public ClassFieldAny(bool pIsStandard,
                        bool pIsCustomizable,
                        bool pIsDateField,
                        string pFieldLabelCaption,
                        string pOtherDbField_Optional,
                        EnumCIBFields pFieldEnumValue)
        {
            IsStandard = pIsStandard;
            IsCustomizable = pIsCustomizable;
            IsDateField = pIsDateField;
            FieldLabelCaption = pFieldLabelCaption;
            OtherDbField_Optional = pOtherDbField_Optional;
            FieldEnumValue = pFieldEnumValue;

        }


        public ClassFieldAny_Serial GetSerial()
        {
            return new ClassFieldAny_Serial(IsStandard,
                IsCustomizable,
                IsDateField,
                FieldLabelCaption,
                OtherDbField_Optional,
                FieldEnumValue);

        }


        //
        /// <summary>
        /// Private members
        /// </summary>
        bool IsStandard = true;
        bool IsCustomizable = false;
        bool IsDateField = false;
        string FieldLabelCaption = "";
        string OtherDbField_Optional = "";
        EnumCIBFields FieldEnumValue;

    }
}