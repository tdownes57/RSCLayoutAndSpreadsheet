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
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

                            new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  }


                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="1", fstrFirstName="John", fstrLastName = "Davidson", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="2", fstrFirstName="Steve", fstrLastName = "Austin", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="3", fstrFirstName="Bill", fstrLastName = "Clinton", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="4", fstrFirstName="Ram", fstrLastName = "Thegot", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="5", fstrFirstName="Ron" , fstrLastName = "Wood", Picture = PictureExamples.GetExample()  },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID ="6", fstrFirstName="Christopher", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   },
                //New ClassRecipient(){ CustomerCode="XYZ999", Personality="Student", fstrID = "7", fstrFirstName="Robin", fstrLastName = "Forbes", Picture = PictureExamples.GetExample()   }

                        //        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "1", fstrFirstName = "Jayce", fstrLastName = "P.", Picture = PictureExamples.GetExample()  },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "2", fstrFirstName = "Chanin", fstrLastName = "F.", Picture = PictureExamples.GetExample() },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "3", fstrFirstName = "Sammi", fstrLastName = "F.", Picture = PictureExamples.GetExample()   },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "4", fstrFirstName = "Erick", fstrLastName = "M.", Picture = PictureExamples.GetExample()   },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "5", fstrFirstName = "Erica" , fstrLastName = "A.", Picture = PictureExamples.GetExample()  },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "6", fstrFirstName = "Jimmy", fstrLastName = "A.", Picture = PictureExamples.GetExample()   },
                        //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 2, fstrID = "7", fstrFirstName = "Thomas", fstrLastName = "D.", Picture = PictureExamples.GetExample()   }
        };

    }

}


//<ListOfFields_Custom>
//  <ClassFieldCustomized>
//    <IsStandard>false</IsStandard>
//    <IsCustomizable>true</IsCustomizable>
//    <IsDateField>false</IsDateField>
//    <Text_orDate>Text</Text_orDate>
//    <CIBadgeField>TextField01</CIBadgeField>
//    <FieldLabelCaption>School Name</FieldLabelCaption>    -----------------------TextField01 = School Name
//    <FieldType_TD>84</FieldType_TD>
//    <FieldEnumValue>TextField01</FieldEnumValue>
//    <FieldIndex>0</FieldIndex>
//    <IsFieldForDates>false</IsFieldForDates>
//    <IsLocked>false</IsLocked>
//    <IsDisplayedOnBadge>false</IsDisplayedOnBadge>
//    <IsDisplayedForEdits>false</IsDisplayedForEdits>
//    <ExampleValue>Willcrest School</ExampleValue>
//    <HasPresetValues>true</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//    <ArrayOfValues>
//      <string>Willcrest School</string>
//      <string>Woodbridge School</string>
//    </ArrayOfValues>
//  </ClassFieldCustomized>
//  <ClassFieldCustomized>
//    <IsStandard>false</IsStandard>
//    <IsCustomizable>true</IsCustomizable>
//    <IsDateField>false</IsDateField>
//    <Text_orDate>Text</Text_orDate>
//    <CIBadgeField>TextField02</CIBadgeField>
//    <FieldLabelCaption>Teacher Name</FieldLabelCaption>    -----------------------TextField02 = Teacher Name  
//    <FieldType_TD>84</FieldType_TD>
//    <FieldEnumValue>TextField02</FieldEnumValue>
//    <FieldIndex>0</FieldIndex>
//    <IsFieldForDates>false</IsFieldForDates>
//    <IsLocked>false</IsLocked>
//    <IsDisplayedOnBadge>false</IsDisplayedOnBadge>
//    <IsDisplayedForEdits>false</IsDisplayedForEdits>
//    <HasPresetValues>true</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//    <ArrayOfValues>
//      <string>Mrs.Ross</string>
//      <string>Mr.Smudge</string>
//      <string>Ms.Randall</string>
//    </ArrayOfValues>
//  </ClassFieldCustomized>
//  <ClassFieldCustomized>
//    <IsStandard>false</IsStandard>
//    <IsCustomizable>true</IsCustomizable>
//    <IsDateField>false</IsDateField>
//    <Text_orDate>Text</Text_orDate>
//    <CIBadgeField>TextField03</CIBadgeField>
//    <FieldLabelCaption>Grade Level</FieldLabelCaption>    -----------------------TextField03 = Grade Level 
//    <FieldType_TD>84</FieldType_TD>
//    <FieldEnumValue>TextField03</FieldEnumValue>
//    <FieldIndex>0</FieldIndex>
//    <IsFieldForDates>false</IsFieldForDates>
//    <IsLocked>false</IsLocked>
//    <IsDisplayedOnBadge>false</IsDisplayedOnBadge>
//    <IsDisplayedForEdits>false</IsDisplayedForEdits>
//    <HasPresetValues>true</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//    <ArrayOfValues>
//      <string>9th</string>
//      <string>10th</string>
//      <string>11th</string>
//      <string>12th</string>
//    </ArrayOfValues>
//  </ClassFieldCustomized>
//  <ClassFieldCustomized>
//    <IsStandard>false</IsStandard>
//    <IsCustomizable>true</IsCustomizable>
//    <IsDateField>false</IsDateField>
//    <Text_orDate>Text</Text_orDate>
//    <CIBadgeField>DateField01</CIBadgeField>
//    <FieldLabelCaption>Date of Birth</FieldLabelCaption>    -----------------------DateField01 = Date of Birth  
//    <FieldType_TD>68</FieldType_TD>
//    <FieldEnumValue>DateField01</FieldEnumValue>
//    <FieldIndex>0</FieldIndex>
//    <IsFieldForDates>true</IsFieldForDates>
//    <IsLocked>false</IsLocked>
//    <IsDisplayedOnBadge>true</IsDisplayedOnBadge>
//    <IsDisplayedForEdits>true</IsDisplayedForEdits>
//    <HasPresetValues>false</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//  </ClassFieldCustomized>
//  <ClassFieldCustomized>
//    <IsStandard>false</IsStandard>
//    <IsCustomizable>true</IsCustomizable>
//    <IsDateField>false</IsDateField>
//    <Text_orDate>Text</Text_orDate>
//    <CIBadgeField>DateField02</CIBadgeField>
//    <FieldLabelCaption>ExpirationDate</FieldLabelCaption>   -----------------------DateField02 = Expiration Date  
//    <FieldType_TD>68</FieldType_TD>
//    <FieldEnumValue>DateField02</FieldEnumValue>
//    <FieldIndex>0</FieldIndex>
//    <IsFieldForDates>true</IsFieldForDates>
//    <IsLocked>false</IsLocked>
//    <IsDisplayedOnBadge>false</IsDisplayedOnBadge>
//    <IsDisplayedForEdits>false</IsDisplayedForEdits>
//    <HasPresetValues>false</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//  </ClassFieldCustomized>
//</ListOfFields_Custom>
