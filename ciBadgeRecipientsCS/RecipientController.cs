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
        public static List<ClassRecipient> mod_recipientList = new List<ClassRecipient>() {
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("001")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("002") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("003")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("004")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("005")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("006")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("007")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "008", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, , Picture = PictureExamples.GetImageByRecipID("008")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "009", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, , Picture = PictureExamples.GetImageByRecipID("009")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "010", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("010")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "011", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("011")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "012", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("012") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "013", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("013")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "014", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("014")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "015", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("015")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "016", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("016")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "017", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("017")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "018", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("018")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "019", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("019")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "020", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("020")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "021", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("021")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "022", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("022") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "023", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("023")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "024", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("024")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "025", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("025")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "026", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("026")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "027", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("027")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "028", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("028")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "029", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("029")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "030", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("030")  },

    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "031", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "032", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "033", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "034", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "035", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "036", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "037", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "038", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "039", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "040", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020") },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Willcrest School", TextField02 = "Ms. Robinson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Willcrest School", TextField02 = "Ms. Tennyson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Willcrest School", TextField02 = "Ms. Forbeson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Woodbridge School", TextField02 = "Mr. Beauchamp", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Willcrest School", TextField02 = "Mr. Shikovsky", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Woodbridge School", TextField02 = "Mr. Wilson", TextField03 = "9TH", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  }


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

        public RecipientController()
        {
            //
            //Added 10/16/2019 Thomas downes 
            //





        }




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
