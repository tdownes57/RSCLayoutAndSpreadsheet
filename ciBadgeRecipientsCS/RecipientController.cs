using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeRecipients;  //Added 10/16/2019 td 
using ciPictures_VB;   //Added 10/16/2019 td 
using System.Drawing;  //Added 10/16/2019 td  

namespace ciBadgeRecipientsCS
{
    public class RecipientController  //:  Controller
    {
        //
        //Currently active Personality-Configuration ID
        //
        public static int PersonalityConfigID_current = 1; //Added 7/12/2019 td 
        public static int fstrID_current = 1; //Needed For the future Steps1234 controller.  ----Added 7/17/2019 td 

        //
        //Recipient = Student Or Employee receiving the Badge. 
        //
        public static IList<ClassRecipient> mod_recipientList = new List<ClassRecipient>() {
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "1", fstrFirstName = "Johnny", fstrLastName = "Davidson", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "2", fstrFirstName = "Stevie", fstrLastName = "Austin", Picture = PictureExamples.GetExample() },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "3", fstrFirstName = "Billy", fstrLastName = "Clinton", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "4", fstrFirstName = "Ronny", fstrLastName = "Thegot", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "5", fstrFirstName = "Dorothy" , fstrLastName = "Wood", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "6", fstrFirstName = "Christy", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "7", fstrFirstName = "Tommy", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },

                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="1", fstrFirstName="John", fstrLastName = "Davidson", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="2", fstrFirstName="Steve", fstrLastName = "Austin", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="3", fstrFirstName="Bill", fstrLastName = "Clinton", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="4", fstrFirstName="Ram", fstrLastName = "Thegot", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="5", fstrFirstName="Ron" , fstrLastName = "Wood", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="6", fstrFirstName="Christopher", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID = "7", fstrFirstName="Robin", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   }

                                new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "1", fstrFirstName = "Jayce", fstrLastName = "P.", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "2", fstrFirstName = "Chanin", fstrLastName = "F.", Picture = PictureExamples.GetExample() },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "3", fstrFirstName = "Sammi", fstrLastName = "F.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "4", fstrFirstName = "Erick", fstrLastName = "M.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "5", fstrFirstName = "Erica" , fstrLastName = "A.", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "6", fstrFirstName = "Jimmy", fstrLastName = "A.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "7", fstrFirstName = "Thomas", fstrLastName = "D.", Picture = PictureExamples.GetExample()   }
        };

    }

}
