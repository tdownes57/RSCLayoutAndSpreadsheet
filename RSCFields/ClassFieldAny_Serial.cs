using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCFields
{
    public class ClassFieldAny_Serial
    {
        public ClassFieldAny_Serial()
        {

        }


        public ClassFieldAny_Serial(bool pIsStandard,
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


        ClassFieldAny GetClass_Nonserial()
        {




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
