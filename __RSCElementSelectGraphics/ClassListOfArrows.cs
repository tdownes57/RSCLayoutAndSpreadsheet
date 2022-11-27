using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeSerialize;  // Added 11/27/2022 Thomas Downes

namespace __RSCElementSelectGraphics
{
    public class ClassListOfArrows
    {

        public static ClassListOfArrows GetLoadedList()
        {
            //
            // Added 11/27/2022
            //
            ciBadgeSerialize.ClassDeserial objDeserialize;
            objDeserialize = new ciBadgeSerialize.ClassDeserial();
            ClassListOfArrows obj_list;
            obj_list = (ClassListOfArrows)(objDeserialize
                .DeserializeFromXML(typeof(ClassListOfArrows), false));
            return obj_list;

        }



        //Public Sub SaveToXML(Optional ByVal pstrPathToXML As String = "")
        //    ''
        //    ''Added 11/29/2019 thomas downes
        //    ''
        //    ''This code was copied from FormDesignProtoTwo.vb, Private Sub SaveLayout(), on 11/29/2019 td
        //    ''
        //    Dim objSerializationClass As New ciBadgeSerialize.ClassSerial
        //
        //    With objSerializationClass
        //
        //        ''10/13/2019 td''.PathToXML = Me.ElementsCache_Saved.PathToXml_Saved
        //        ''03/23/2022 td''.PathToXML = Me.PathToXml_Saved
        //        .PathToXML_Binary = Me.PathToXml_Binary ''Added 11/29/2019 thomas d. 
        //
        //        ''Added 3/23/2022 thomas d.
        //        If (Me.PathToXml_Opened<> "") Then
        //            .PathToXML = Me.PathToXml_Opened
        //            .PathToXML_Alternate = Me.PathToXml_Saved ''Added 3/23/2022 thomas d.
        //        Else
        //            .PathToXML = Me.PathToXml_Saved
        //            .PathToXML_Alternate = Me.PathToXml_Opened ''Added 3/23/2022 thomas d. 
        //        End If ''End of "If (Me.PathToXML_Opened <> "") Then ... Else"
        //
        //        ''Added 12/14/2021 td
        //        If (pstrPathToXML<> "") Then.PathToXML = pstrPathToXML
        //
        //        ''Added 9/24/2019 thomas 
        //        ''  ''11/29/2019 td''.SerializeToXML(Me.GetType, Me, False, True)
        //
        //        Dim boolSerializeToBinary As Boolean = False ''Added 9/30/2019 td
        //
        //        boolSerializeToBinary = ciBadgeSerialize.ClassSerial.UseBinaryFormat
        //
        //        If(boolSerializeToBinary) Then
        //            .SerializeToBinary(Me.GetType, Me)
        //        Else
        //            ''//---4/22/2020 td //.SerializeToXML(Me.GetType, Me, False, True)
        //            Const c_boolAutoOpenByIE As Boolean = False ''Added 4/22/2020 thomas d.
        //            ''//
        //            ''// If the 2nd Boolean Is True, the following command
        //            ''//         System.Diagnostics.Process.Start(Me.PathToXML)
        //            ''//  will be used to open the file in Notepad.
        //            ''//     ---4/22/2020 thomas downes
        //            ''//
        //            .SerializeToXML(Me.GetType, Me, False, c_boolAutoOpenByIE)
        //
        //        End If ''End of "If (boolSerializeToBinary) Then ... Else"
        //
        //    End With ''End of "With objSerializationClass"
        //
        //End Sub ''End of "Public Sub SaveToXML()"


        public void SaveToXML(string pstrPathToXML)
        {
            //
            // Added 11/27/2022
            //
            ciBadgeSerialize.ClassSerial objSerializationClass =
                 new ClassSerial();
            objSerializationClass.PathToXML = pstrPathToXML;
            const bool c_boolAutoOpenByIE = true;
            objSerializationClass.SerializeToXML(typeof(ClassSerial), 
                this, false, c_boolAutoOpenByIE);

        }

        public void LoadFromXML()
        {

        }



    }
}
