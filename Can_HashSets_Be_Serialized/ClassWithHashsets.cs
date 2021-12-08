using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Runtime.Serialization;  //Added 12/8/2021 td
//
//Dec. 8 2021 thomas downes
//
//   https://stackoverflow.com/questions/4192905/serializing-a-hashset
//

namespace Can_HashSets_Be_Serialized
{
    //
    //Dec. 8 2021 thomas downes
    //   https://stackoverflow.com/questions/4192905/serializing-a-hashset
    //
    [Serializable]
    public class ClassWithHashsets
    {
        //
        //Dec. 8 2021 thomas downes
        //
        private HashSet<ClassDetail> mod_hashset_A = new HashSet<ClassDetail>();
        private HashSet<ClassDetail> mod_hashset_B = new HashSet<ClassDetail>();

        public static ClassWithHashsets GetExample()
        {
            var objNew = new ClassWithHashsets();

            objNew.AddDetailItem_ToHashA("Thomas");
            objNew.AddDetailItem_ToHashA("Sloan");
            objNew.AddDetailItem_ToHashA("Briana");

            objNew.AddDetailItem_ToHashA("Christian");
            objNew.AddDetailItem_ToHashA("Lorraine");
            objNew.AddDetailItem_ToHashA("Grayson");
            objNew.AddDetailItem_ToHashA("Winter");
            objNew.AddDetailItem_ToHashA("Tabitha");

            return objNew; 
        }


        public void AddDetailItem_ToHashA(string par_nameOfItem)
        {
            var objNew = new ClassDetail() { MyName = par_nameOfItem };
            mod_hashset_A.Add(objNew);
        }


        public void AddDetailItem_ToHashB(string par_nameOfItem)
        {
            var objNew = new ClassDetail() { MyName = par_nameOfItem };
            mod_hashset_B.Add(objNew);
        }



    }
}
