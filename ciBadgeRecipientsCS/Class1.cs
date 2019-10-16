using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeRecipients;  //Added 10/16/2019 td 
using ciLayoutPrintLib;   //Added 10/16/2019 td 

namespace ciBadgeRecipientsCS
{
    public class RecipientController  //:  Controller
        {
            //
            //Currently active Personality-Configuration ID
            //
            public static int PersonalityConfigID_current = 1; //Added 7/12/2019 td 
            public static int RecipientID_current = 1; //Needed For the future Steps1234 controller.  ----Added 7/17/2019 td 

            //
            //Recipient = Student Or Employee receiving the Badge. 
            //
            public static IList<ClassRecipient> mod_recipientList = new List<ClassRecipient>() {
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "1", fstrFirstName = "Johnny", fstrLastName = "Davidson", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "2", fstrFirstName = "Stevie", fstrLastName = "Austin", Picture = PictureExamples.GetExample() },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "3", fstrFirstName = "Billy", fstrLastName = "Clinton", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "4", fstrFirstName = "Ronny", fstrLastName = "Thegot", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "5", fstrFirstName = "Dorothy" , fstrLastName = "Wood", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "6", fstrFirstName = "Christy", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 1, RecipientID = "7", fstrFirstName = "Tommy", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },

                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="1", fstrFirstName="John", fstrLastName = "Davidson", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="2", fstrFirstName="Steve", fstrLastName = "Austin", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="3", fstrFirstName="Bill", fstrLastName = "Clinton", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="4", fstrFirstName="Ram", fstrLastName = "Thegot", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="5", fstrFirstName="Ron" , fstrLastName = "Wood", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID ="6", fstrFirstName="Christopher", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerID="XYZ999", Personality="Student", RecipientID = "7", fstrFirstName="Robin", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   }

                                new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "1", fstrFirstName = "Jayce", fstrLastName = "P.", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "2", fstrFirstName = "Chanin", fstrLastName = "F.", Picture = PictureExamples.GetExample() },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "3", fstrFirstName = "Sammi", fstrLastName = "F.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "4", fstrFirstName = "Erick", fstrLastName = "M.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "5", fstrFirstName = "Erica" , fstrLastName = "A.", Picture = PictureExamples.GetExample()  },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "6", fstrFirstName = "Jimmy", fstrLastName = "A.", Picture = PictureExamples.GetExample()   },
                        new ClassRecipient() { CustomerID = "CIS100", idfConfigID = 2, RecipientID = "7", fstrFirstName = "Thomas", fstrLastName = "D.", Picture = PictureExamples.GetExample()   }
    };

}
