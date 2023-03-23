using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCFields
{
   public enum EnumCIBFields
    {
        Undetermined, // ''Field Index 0 

        //''   [idsCardDataID][numeric](18, 0) IDENTITY (1, 1) Not NULL,
        //''   [idfConfigID][int] NULL,
        //''   [fstrLastName][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //''   [fstrFirstName][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //''   [fstrMidName][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        //''   [fstrID][varchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS Not NULL,

        idsCardDataID, //''Field Index 1
        idfConfigID, //''Field Index 2
        fstrLastName, //''Field Index 3
        fstrFirstName, //''Field Index 4
        fstrMidName, //''Field Index 5
        fstrID, //''Field Index 6

        //''Added 11/25/2021 thomas downes
        fstrFullName, // ''Added 11/25/2021 thomas downes
        fstrNameAbbreviated, // ''Added 3/17/2022 thomas downes

        //''    [fdatRecDate][datetime] NULL CONSTRAINT [DF_tblCardData_fdatRecDate] Default getdate() ,
        //''   [idfReportID][int] NULL,
        //''   [fstrBarcode][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

        fdateRecDate, //  ''Field Index 9
        idfReportID,  //  ''Field Index 10
        fstrBarCode,  //  ''Field Index 11

        fstrAddress,  //   ''F.I.#12  [fstrAddress] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrCity,     //   ''F.I.#13    [fstrCity] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrState,    //   ''F.I.#14  [fstrState] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
        fstrZip,      //   ''F.I.#15   [fstrZip] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,

        blnBatchPrint, //   ''F.I.#16  [blnBatchPrint] [bit] NULL ,
        //''---- Added 1/28/2019 thomas downes, for https://app.asana.com/0/0/872801181163659/f 
        intTimesPrinted, //   ''F.I.#17  [intTimesPrinted] [int] NULL CONSTRAINT [DF_tblCardData_intTimesPrinted] Default 0 ,
        fdatTimeStamp, //   ''F.I.#18  [fdatTimeStamp] [datetime] NULL ,
        fintRecPool, //   ''F.I.#19
        fstrRFID_Unique, //   ''F.I.#20

        //''Moved below 9/30/2022 PortraitPhotoID ''Added 5/20/2022 thomas downes

        TextField01, //   ''  [TextField01][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField02, //   ''[TextField02][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField03, //   ''[TextField03][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField04, //   ''[TextField04][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField05, //   ''[TextField05][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField06, //   ''[TextField06][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField07, //   ''[TextField07][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField08, //   ''[TextField08][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField09, //   ''[TextField09][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField10, //   ''[TextField10][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField11, //   ''[TextField11][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField12, //   ''[TextField12][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField13, //   ''[TextField13][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField14, //   ''[TextField14][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField15, //   ''[TextField15][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

        TextField16, //   ''[TextField16][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField17, //   ''[TextField17][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField18, //   ''[TextField18][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField19, //   ''[TextField19][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField20, //   ''[TextField20][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField21, //   ''[TextField21][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField22, //   ''[TextField22][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField23, //   ''[TextField23][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField24, //   ''[TextField24][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
        TextField25, //   ''[TextField25][varchar] (60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,

        DateField01, //   ''[DateField01][datetime] NULL,
        DateField02, //   ''[DateField02][datetime] NULL,
        DateField03, //   ''[DateField03][datetime] NULL,
        DateField04, //   ''[DateField04][datetime] NULL,
        DateField05, //   ''[DateField05][datetime] NULL,

        PortraitPhotoID //  ''Added 9/30/2022 & 5/20/2022 thomas downes


    }



}
