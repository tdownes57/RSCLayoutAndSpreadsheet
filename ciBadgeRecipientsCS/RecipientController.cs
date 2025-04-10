﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ciBadgeRecipients;  //Added 10/16/2019 td 
//using ciPictures_VB;   //Added 10/16/2019 td 
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
        /*************
Cece Fong
Tegan Hatton Jones
Ben Kroko
Ana Christina Malik
Nang Sin
Jassim Al Thani
Asher West
Johnnie Jones
Unity Cole
Duyen Le
Khanh Dai
Thomas Downes
Taj Miller
Oliver Hernandez
Brian Huffman
Dumindu Mendis
Jason Rodjanapanyakul
Alhassan Al Thani
Amanda Sackett
Jeffrey Jim
Kyohei Shimada
Jacob Gubas
Yana Watters
Haruto Imai
Kylie Ozbat
Elier Rivera-curiel
Preston Thompson
Kaho Takahashi
Dustin Chase
Edgar Percastegui
********************/

        public static List<ClassRecipient> mod_recipientList = new List<ClassRecipient>() {

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "001", fstrFirstName = "Cece Fong", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "002", fstrFirstName = "Tegan Jones", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "003", fstrFirstName = "Ben Kroko", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ana Christina Malik", fstrLastName = "Thergeaux", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "005", fstrFirstName = "Nang Sin" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "Jassim Al Thani", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "Asher West", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "Johnnie Jones", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "Unity Cole", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "Duyen Le", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "Khanh Dai", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "Thomas Downes", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "Taj Miller", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "Oliver Hernandez", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "Brian Huffman", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "Dimindu Mendis", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "Jason Rodjanapanyakul", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "Alhassan Al Thani", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "Amanda Sackett", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "Jeffrey Jim", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "Kyohei Shimada", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "Jacob Gubas", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "Yana Watters", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "Haruto Imai", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "Kylie Ozbat", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },

    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "Elier Rivera-Curiel", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "Preston Thompson", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "Kaho Takahashi", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "Dustin Chase", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "Edgar Percastegui", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach" }
        
        };

    //new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "006", fstrFirstName = "", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    //new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "007", fstrFirstName = "", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    //new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "008", fstrFirstName = "", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    //new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "009", fstrFirstName = "", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },
    //new ClassRecipient() { CustomerCode = "BUS240", idfConfigID = 1, fstrID = "010", fstrFirstName = "", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    


    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny D.", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie A.", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("002") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy C.", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("003")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny T.", fstrLastName = "Thergeaux", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("004")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy W." , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("005")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("006")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("007")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "008", fstrFirstName = "Susanny H.", fstrLastName = "Hunterson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Bernstein", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, , Picture = PictureExamples.GetImageByRecipID("008")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "009", fstrFirstName = "Benny C.", fstrLastName = "Crawford", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Ross", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, , Picture = PictureExamples.GetImageByRecipID("009")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "010", fstrFirstName = "Tommy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mrs. Denmore", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("010")  },


    
    /** 10 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "011", fstrFirstName = "Fritzy D.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("011")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "012", fstrFirstName = "Hummy A.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("012") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "013", fstrFirstName = "Sandy C.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("013")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "014", fstrFirstName = "Bobby T.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("014")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "015", fstrFirstName = "Dorothy W." , fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("015")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "016", fstrFirstName = "Chrissy F.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("016")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "017", fstrFirstName = "Sammy F.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("017")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "018", fstrFirstName = "Markie R.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("018")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "019", fstrFirstName = "Sandie F.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("019")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "020", fstrFirstName = "Heather F.", fstrLastName = "", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("020")  },
    
    /** 20 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "021", fstrFirstName = "Sonny D.", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("021")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "022", fstrFirstName = "Steevy A.", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("022") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "023", fstrFirstName = "Sally C.", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("023")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "024", fstrFirstName = "Robby T.", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("024")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "025", fstrFirstName = "Dorothy W." , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("025")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "026", fstrFirstName = "Christy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("026")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "027", fstrFirstName = "Timmy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("027")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "028", fstrFirstName = "Tommy S.", fstrLastName = "Steward", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("028")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "029", fstrFirstName = "Tinny G.", fstrLastName = "Goodson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("029")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "030", fstrFirstName = "Tubby W.", fstrLastName = "Winward", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("030")  },
    
    /** 30 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "031", fstrFirstName = "Johnny D.", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "032", fstrFirstName = "Stevie A.", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "033", fstrFirstName = "Billy C.", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "034", fstrFirstName = "Ronny T.", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "035", fstrFirstName = "Dorothy W." , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "036", fstrFirstName = "Christy F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "037", fstrFirstName = "Dolly F.", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "038", fstrFirstName = "Denny M.", fstrLastName = "Morbeson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "039", fstrFirstName = "Bully T.", fstrLastName = "Torres", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "040", fstrFirstName = "Vinnie B.", fstrLastName = "Bordeson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },

    /** 40 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "041", fstrFirstName = "Johnny41", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "042", fstrFirstName = "Stevie42", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "043", fstrFirstName = "Billy43", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "044", fstrFirstName = "Ronny44", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "045", fstrFirstName = "Dorothy45" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "046", fstrFirstName = "Christy46", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "047", fstrFirstName = "Tommy47", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "048", fstrFirstName = "Sally48", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "049", fstrFirstName = "Volly49", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "050", fstrFirstName = "Hilly50", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },
    
    /** 50 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "051", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"     },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "052", fstrFirstName = "Stevie52", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "053", fstrFirstName = "Billy53", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "054", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "055", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "056", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "057", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "058", fstrFirstName = "Bommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "059", fstrFirstName = "Johnny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "060", fstrFirstName = "Jimmy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },
    
    /** 60 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "061", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "062", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "063", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "064", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "065", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "066", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "067", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "068", fstrFirstName = "Vommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "069", fstrFirstName = "Sonny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "070", fstrFirstName = "Winnie", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },
    
    /** 70 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "071", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "072", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "073", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "074", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "075", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "076", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "077", fstrFirstName = "Annie", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "078", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "079", fstrFirstName = "Sonny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "080", fstrFirstName = "Honey", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },

    /** 80 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "081", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "082", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "083", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "084", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "085", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "086", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "087", fstrFirstName = "Hilde", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "088", fstrFirstName = "Timmy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "089", fstrFirstName = "Georgie", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "090", fstrFirstName = "Ally", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("040")  },

    /** 90 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "091", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("031")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "092", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("032") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "093", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("033")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "094", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("034")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "095", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("035")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "096", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("036")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "097", fstrFirstName = "Yanny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("037")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "098", fstrFirstName = "Penny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("038")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "099", fstrFirstName = "Zenny", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    },    //---, Picture = PictureExamples.GetImageByRecipID("039")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "100", fstrFirstName = "Queenie", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), fstrCity="Newport Beach"    }    //---, Picture = PictureExamples.GetImageByRecipID("040")  },

    /** 100 above **/

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //                        new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },

    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "001", fstrFirstName = "Johnny", fstrLastName = "Davidson", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Robinson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "002", fstrFirstName = "Stevie", fstrLastName = "Austin", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001") },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "003", fstrFirstName = "Billy", fstrLastName = "Clinton", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Tennyson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "004", fstrFirstName = "Ronny", fstrLastName = "Thegot", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Ms. Forbeson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "005", fstrFirstName = "Dorothy" , fstrLastName = "Wood", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Beauchamp", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "006", fstrFirstName = "Christy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Shikovsky", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")   },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  },
    //new ClassRecipient() { CustomerCode = "CIS100", idfConfigID = 1, fstrID = "007", fstrFirstName = "Tommy", fstrLastName = "Forbes", TextField01 = "Code Ninjas - Costa Mesa", TextField02 = "Mr. Wilson", TextField03 = "R Software Consulting 123", DateField01 = DateTime.Parse("7/21/2003"), DateField02 = DateTime.Parse("7/21/2020"), Picture = PictureExamples.GetImageByRecipID("001")  }


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
        //};

        public RecipientController()
        {
            //
            //Added 10/16/2019 Thomas downes 
            //
            if (true)
            {
                if (true)
                {

                }

            }




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
//    <ExampleValue>Code Ninjas - Costa Mesa</ExampleValue>
//    <HasPresetValues>true</HasPresetValues>
//    <IsAdditionalField>false</IsAdditionalField>
//    <IsBarCode>false</IsBarCode>
//    <IsLinkedToSections>false</IsLinkedToSections>
//    <ArrayOfValues>
//      <string>Code Ninjas - Costa Mesa</string>
//      <string>Code Ninjas - Costa Mesa</string>
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
