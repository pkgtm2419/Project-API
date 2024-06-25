/****************************************************************************/
/*                               DISCLAIMER:                                */
/*                      This file contains sample code.                     */
/*     Such sample code described herein is provided on an "as is"          */
/*    basis, without warranty of any kind, not even implied warranties of   */
/*  non-infringement, merchantability or fitness  for a particular purpose, */
/*                 to the fullest extent permitted by law.                  */
/*                                                                          */
/*                 THIS CODE IS NOT RECOMMENDED FOR USE IN                  */
/*                   PRODUCTION SYSTEMS OR PRODUCTION USE.                  */
/*                                                                          */
/*   Kalkitech does not warrant, guarantee or make any representations      */
/* regarding the use, results of use, accuracy, timeliness or completeness  */
/* of any data or information relating to the sample code. Kalkitech        */
/* disclaims all warranties, express or implied, and in particular,         */
/* disclaims all warranties of merchantability, fitness for a particular    */
/* purpose, and warranties related to the code, or any service or software  */
/*                             related thereto.                             */
/*                                                                          */
/*  Kalkitech shall not be liable for any direct, indirect or consequential */
/*  damages or costs of any type arising out of any action taken by you or  */
/*   others related to the sample code. Such sample code provided herein is */
/*      for illustrative purposes only, has not passed through Kalkitech    */
/*   standard testing and validation and is not intended for any production */
/*  use. Such sample code is not subject to Kalkitech agreements related to */
/*                 Sales, Technical Support, or Licensing.                  */
/****************************************************************************/
#define IC40_VERSION_0_SUPPORT      //Required Version support should be enabled in all of these(IC40.cs, DLMSClient.cs, SampleSetData.cs & SetSampleActionData.cs) files.
#define IC40_VERSION_1_SUPPORT
#define IC40_VERSION_2_SUPPORT
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Collections.Specialized;
using System.IO.Ports;
using DLMS_CLIENT;
using DLMS_CLIENT.DLMSStruct;
using System.ComponentModel.DataAnnotations;
using ProjectAPI.SchemaModel;

namespace ProjectAPI
{
    class SampleSetData
    {

        public static void setSampleVarValue(ref VARVALUE_CS value, DATA_TYPE eType, int len)
        {
            switch (eType)
            {
                case DATA_TYPE.DT_DOUBLE_LONG:
                    {
                        value.valLength = 4;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(0xFF);
                    }
                    break;
                case DATA_TYPE.DT_DOUBLE_LONG_UNSIGNED:
                    {
                        value.valLength = 4;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_BOOLEAN:
                    {
                        value.valLength = 1;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                    }
                    break;
                case DATA_TYPE.DT_BCD:
                    {
                        value.valLength = 1;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                    }
                    break;
                case DATA_TYPE.DT_INTEGER:
                    {
                        value.valLength = 1;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                    }
                    break;
                case DATA_TYPE.DT_UNSIGNED:
                    {
                        value.valLength = 1;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                    }
                    break;
                case DATA_TYPE.DT_LONG:
                    {
                        value.valLength = 2;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 0xFF;
                        value.value_p[1] = 0xFF;
                    }
                    break;
                case DATA_TYPE.DT_LONG_UNSIGNED:
                    {
                        value.valLength = 2;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                        value.value_p[1] = 2;
                    }
                    break;
                case DATA_TYPE.DT_FLOATING_POINT:
                    {
                        value.valLength = 4;
                        value.valType = (byte)eType; ;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_TIME:
                case DATA_TYPE.DT_TIME1:
                    {
                        value.valLength = 4;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_REAL32:
                    {
                        value.valLength = 4;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_DATE:
                    {
                        value.valLength = 5;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_LONG64:
                case DATA_TYPE.DT_REAL64:
                case DATA_TYPE.DT_UNSIGNED_LONG64:
                    {
                        value.valLength = 8;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i);
                    }
                    break;
                case DATA_TYPE.DT_BIT_STRING:
                case DATA_TYPE.DT_OCTET_STRING:
                case DATA_TYPE.DT_VISIBLE_STRING:
                    {
                        value.valLength = len;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        for (int i = 0; i < value.valLength; i++)
                            value.value_p[i] = (byte)(i + 65);
                    }
                    break;
                case DATA_TYPE.DT_STRUCTURE:
                    {
                        value.valLength = 3;
                        value.valType = (byte)eType;

                        value.composite_value = new VARVALUE_CS[value.valLength];

                        // {DT_STRUCTURE,3,DT_STRUCTURE,2,DT_INTEGER,DT_OCTET_STRING,10,DT_ARRAY,2,DT_STRUCTURE,1,DT_DOUBLE_LONG,DT_LONG,'\0'};
                        for (int i = 0; i < value.valLength; i++)
                        {
                            /* here the number of elements of structure is considerd to be 3.
                               the if cases are expected to be present for all values of i upto len*/
                            if (i == 0)
                            {
                                value.composite_value[i].valType = (byte)DATA_TYPE.DT_STRUCTURE;
                                value.composite_value[i].valLength = 2;

                                value.composite_value[i].composite_value = new VARVALUE_CS[value.composite_value[i].valLength];
                                for (int ij = 0; ij < value.composite_value[i].valLength; ij++)
                                {
                                    if (ij == 0)
                                    {
                                        value.composite_value[i].composite_value[ij].valType = (byte)DATA_TYPE.DT_INTEGER;
                                        value.composite_value[i].composite_value[ij].valLength = 1;
                                        value.composite_value[i].composite_value[ij].value_p = new byte[value.composite_value[i].composite_value[ij].valLength];
                                        value.composite_value[i].composite_value[ij].value_p[0] = 0x01;
                                    }
                                    else if (ij == 1)
                                    {
                                        value.composite_value[i].composite_value[ij].valLength = 10;
                                        value.composite_value[i].composite_value[ij].valType = (byte)DATA_TYPE.DT_OCTET_STRING;
                                        value.composite_value[i].composite_value[ij].value_p = new byte[value.composite_value[i].composite_value[ij].valLength];
                                        for (int jk = 0; jk < value.composite_value[i].composite_value[ij].valLength; jk++)
                                            value.composite_value[i].composite_value[ij].value_p[jk] = (byte)(jk + 65);
                                    }
                                }
                            }
                            else if (i == 1)
                            {
                                value.composite_value[i].valType = (byte)DATA_TYPE.DT_ARRAY;
                                value.composite_value[i].valLength = 2;

                                value.composite_value[i].composite_value = new VARVALUE_CS[value.composite_value[i].valLength];
                                for (int ij = 0; ij < value.composite_value[i].valLength; ij++)
                                {

                                    value.composite_value[i].composite_value[ij].valType = (byte)DATA_TYPE.DT_STRUCTURE;
                                    value.composite_value[i].composite_value[ij].valLength = 1;
                                    value.composite_value[i].composite_value[ij].composite_value = new VARVALUE_CS[value.composite_value[i].composite_value[ij].valLength];

                                    value.composite_value[i].composite_value[ij].composite_value[0].valType = (byte)DATA_TYPE.DT_DOUBLE_LONG;
                                    value.composite_value[i].composite_value[ij].composite_value[0].valLength = 4;
                                    value.composite_value[i].composite_value[ij].composite_value[0].value_p = new byte[value.composite_value[i].composite_value[ij].composite_value[0].valLength];
                                    value.composite_value[i].composite_value[ij].composite_value[0].value_p[0] = 1;
                                    value.composite_value[i].composite_value[ij].composite_value[0].value_p[1] = 2;
                                    value.composite_value[i].composite_value[ij].composite_value[0].value_p[2] = 3;
                                    value.composite_value[i].composite_value[ij].composite_value[0].value_p[3] = 4;


                                }
                            }
                            else if (i == 2)
                            {
                                value.composite_value[i].valType = (byte)DATA_TYPE.DT_LONG;
                                value.composite_value[i].valLength = 2;
                                value.composite_value[i].value_p = new byte[value.composite_value[i].valLength];
                                value.composite_value[i].value_p[0] = 1;
                                value.composite_value[i].value_p[1] = 0;
                            }
                        }
                    }
                    break;
                case DATA_TYPE.DT_ARRAY:
                    {
                        value.valLength = 2;
                        value.valType = (byte)eType;

                        value.composite_value = new VARVALUE_CS[value.valLength];

                        // {DT_ARRAY,2,DT_STRUCTURE,2,DT_OCTET_STRING,DT_BOOLEAN,'\0'};
                        for (int i = 0; i < value.valLength; i++)
                        {
                            /* here the number of elements of array is considerd to be 2. */


                            value.composite_value[i].valType = (byte)DATA_TYPE.DT_STRUCTURE;
                            value.composite_value[i].valLength = 2;
                            value.composite_value[i].composite_value = new VARVALUE_CS[value.composite_value[i].valLength];

                            value.composite_value[i].composite_value[0].valType = (byte)DATA_TYPE.DT_OCTET_STRING;
                            value.composite_value[i].composite_value[0].valLength = 9;
                            value.composite_value[i].composite_value[0].value_p = new byte[value.composite_value[i].composite_value[0].valLength];
                            for (int loop = 0; loop < value.composite_value[i].composite_value[0].valLength; loop++)
                                value.composite_value[i].composite_value[0].value_p[loop] = (byte)(loop + 1);

                            value.composite_value[i].composite_value[1].valType = (byte)DATA_TYPE.DT_BOOLEAN;
                            value.composite_value[i].composite_value[1].valLength = 1;
                            value.composite_value[i].composite_value[1].value_p = new byte[value.composite_value[i].valLength];
                            value.composite_value[i].composite_value[1].value_p[0] = 0x7D;

                        }
                    }
                    break;
                default:
                    {
                        value.valLength = 1;
                        value.valType = (byte)eType;
                        value.value_p = new byte[value.valLength];
                        value.value_p[0] = 1;
                    }
                    break;
            }

        }
        public static bool setSampleDataIC(ref DATA_CS data, _OBJ o)
        {
            bool ret = false;
            switch (o.attrMethID)
            {
                case 2:
                    {
                        setSampleVarValue(ref data.value, DATA_TYPE.DT_VISIBLE_STRING, 6);
                        ret = true;
                    }
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

        public static bool setSampleRegisterIC(ref REGISTER_CS register, _OBJ o)
        {
            bool ret = true;
            switch (o.attrMethID)
            {
                case 2:
                    setSampleVarValue(ref register.value, DATA_TYPE.DT_REAL32, 4); break;
                case 3:
                    register.scalerUnit = new SCALERUNIT(1, UNIT_ENUM.VOLTAGE_V);
                    break;
                default:
                    ret = false;
                    break;

            }
            return ret;
        }
        public static bool setSampleExtRegisterIC(ref EXTREGISTER_CS extRegister, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: setSampleVarValue(ref extRegister.value, DATA_TYPE.DT_OCTET_STRING, 5); break;
                case 3: extRegister.scalerUnit = new SCALERUNIT(1, UNIT_ENUM.VOLTAGE_V); break;
                case 4: setSampleVarValue(ref extRegister.status, DATA_TYPE.DT_UNSIGNED, 1); break;
                case 5: extRegister.captureTime_varVal = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleDMDRegisterIC(ref DEMANDREG_CS dmdRegister, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: setSampleVarValue(ref dmdRegister.curAvgValue, DATA_TYPE.DT_OCTET_STRING, 5); break;
                case 3: setSampleVarValue(ref dmdRegister.lastAvgValue, DATA_TYPE.DT_OCTET_STRING, 5); break;
                case 4: dmdRegister.scalerUnit = new SCALERUNIT(1, UNIT_ENUM.VOLTAGE_V); break;
                case 5: setSampleVarValue(ref dmdRegister.status, DATA_TYPE.DT_UNSIGNED, 1); break;
                case 6: dmdRegister.captureTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 7: dmdRegister.startTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 8: dmdRegister.period = 1; break;
                case 9: dmdRegister.numOfPeriods = 1; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleProfileIC(ref PROFILE_CS profile, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 4: profile.capturePeriod = 900; break;	//seconds
                case 7: profile.entriesInUse = 10; break;
                default: ret = true; break;
            }
            return ret;
        }
        public static bool setSampleClockIC(ref CLOCK clock, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: clock.time = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 3: clock.timeZone = 0; break;
                case 4: clock.status = 0; break;
                case 5: clock.daylightBegin = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 6: clock.daylightEnd = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 7: clock.daylightDeviation = (sbyte)(0); break;
                case 8: clock.daylightEnabled = 0; break;
                case 9: clock.clockBase = 0; break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleScriptIC(ref SCRIPT_TABLE_CS scriptTable, _OBJ obj)
        {
            bool ret = false;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        scriptTable.numScripts = 3;
                        scriptTable.scripts_p = new SCRIPT_CS[scriptTable.numScripts];
                        for (int i = 0; i < scriptTable.numScripts; i++)
                        {
                            scriptTable.scripts_p[i].scriptId = 1;
                            scriptTable.scripts_p[i].numActions = 2;
                            scriptTable.scripts_p[i].actions_p = new ACTION_CS[scriptTable.scripts_p[i].numActions];
                            for (int j = 0; j < scriptTable.scripts_p[i].numActions; j++)
                            {
                                scriptTable.scripts_p[i].actions_p[j].classId = 3;
                                scriptTable.scripts_p[i].actions_p[j].servId = SERVID_ENUM.EXECUTE;
                                scriptTable.scripts_p[i].actions_p[j].obis = new OBISCODE(1, 1, 5, 8, 1, 255);
                                scriptTable.scripts_p[i].actions_p[j].index = (byte)(j + 1);
                                setSampleVarValue(ref scriptTable.scripts_p[i].actions_p[j].param, DATA_TYPE.DT_OCTET_STRING, 4);
                            }
                        }
                        ret = true;
                    }
                    break;

            }
            return ret;
        }
        public static bool setSampleSpecDayIC(ref SPECDAYTABLE_CS specDaysTable, _OBJ obj)
        {
            bool ret = false;
            switch (obj.attrMethID)
            {
                case 2:
                    specDaysTable.numEntries = 255;
                    specDaysTable.entries_p = new SPDAYENTRY[specDaysTable.numEntries];
                    for (int i = 0; i < specDaysTable.numEntries; i++)
                    {
                        specDaysTable.entries_p[i].dayId = (byte)(i);
                        specDaysTable.entries_p[i].index = (ushort)(i + 1);
                        specDaysTable.entries_p[i].specDate = new DATETIME_VARVAL(new DATE1(3, 7, 8, 2013));
                    }
                    ret = true;
                    break;
            }
            return ret;
        }
        public static bool setSampleAssLnIC(ref ASSOC_LN_CS assocLN, _OBJ obj)
        {
            bool ret = false;
            switch (obj.attrMethID)
            {
                case 6:
                    assocLN.authMech = 2;
                    ret = true;
                    break;
                case 7:
                    string llsSecret = "123456";
                    assocLN.secrLength = (byte)llsSecret.Length; //length of the secret
                    assocLN.llsSecret_p = Encoding.ASCII.GetBytes(llsSecret);
                    ret = true;
                    break;
            }
            return ret;
        }
        public static bool setSampleIECLocalIC(ref IECLOCALPORT_CS IECLocal, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: IECLocal.mode = MODE_ENUM1.IEC62056_021; break;
                case 3: IECLocal.defaultBaud = BAUD_ENUM.b300; break;
                case 4: IECLocal.proposedBaud = BAUD_ENUM.b9600; break;
                case 5: IECLocal.responseTime = RESP_TIME_ENUM.MS200; break;
                case 6:
                    {
                        string devAdr = "DEVICE_ADDRESS";
                        IECLocal.deviceAddr_p = Encoding.ASCII.GetBytes(devAdr);
                        IECLocal.devaddrLength = (byte)devAdr.Length;
                    }
                    break;
                case 7:
                    IECLocal.passP1_p = Encoding.ASCII.GetBytes("12345678");
                    IECLocal.passP1Len = (byte)IECLocal.passP1_p.Length;
                    break;
                case 8:
                    IECLocal.passP2_p = Encoding.ASCII.GetBytes("12345678");
                    IECLocal.passP2Len = (byte)IECLocal.passP2_p.Length;
                    break;
                case 9:
                    IECLocal.passW5_p = Encoding.ASCII.GetBytes("12345678");
                    IECLocal.passW5Len = (byte)IECLocal.passW5_p.Length;
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleActCalIC(ref ACTIVITYCALENDAR_CS actCal, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    actCal.calNameActive_p = Encoding.ASCII.GetBytes("August");
                    actCal.calNameActiveLen = (byte)actCal.calNameActive_p.Length;
                    break;
                case 3:
                    {
                        actCal.numSeasonsActive = 7;
                        actCal.seasonProfActive_p = new SEASON_PROF_CS[actCal.numSeasonsActive];
                        for (int i = 0; i < actCal.numSeasonsActive; i++)
                        {
                            string seaname = "seasoni";
                            actCal.seasonProfActive_p[i].seasonName_p = Encoding.ASCII.GetBytes(seaname);
                            actCal.seasonProfActive_p[i].seasonNameLen = (byte)seaname.Length;
                            actCal.seasonProfActive_p[i].seasonStart = new DATETIME_VARVAL(new DATETIME(1, 12, 1, 2010, 1, 11, 1, 2, 23, 6));
                            string weekname = "weeki";
                            actCal.seasonProfActive_p[i].weekNameLen = (byte)weekname.Length;
                            actCal.seasonProfActive_p[i].weekName_p = Encoding.ASCII.GetBytes(weekname);
                        }
                    }
                    break;
                case 4:
                    {
                        actCal.numWeeksActive = 299;
                        actCal.weekProfActive_p = new WEEK_PROF_CS[actCal.numWeeksActive];
                        for (int i = 0; i < 299; i++)
                        {
                            actCal.weekProfActive_p[i] = new WEEK_PROF_CS(0, 0, 0, 0, 0, 0, 0, (byte)"Week".Length, "Week" + i.ToString());
                        }
                    }
                    break;
                case 5:
                    {
                        actCal.numDaysActive = 51;
                        actCal.dayProfActive_p = new DAY_PROF_CS[actCal.numDaysActive];
                        for (int i = 0; i < actCal.numDaysActive; i++)
                        {
                            actCal.dayProfActive_p[i].dayId = (byte)i;
                            actCal.dayProfActive_p[i].numActions = 35;
                            actCal.dayProfActive_p[i].dayActions_p = new DAY_PROFACTION[actCal.dayProfActive_p[i].numActions];
                            for (int j = 0; j < 35; j++)
                            {
                                actCal.dayProfActive_p[i].dayActions_p[j].scriptObis = new OBISCODE(0, 0, 1, 0, 0, 255);
                                actCal.dayProfActive_p[i].dayActions_p[j].scriptSelector = (byte)j;
                                actCal.dayProfActive_p[i].dayActions_p[j].startTime = new DATETIME_VARVAL(new TIME(10, 5, 12, 15));
                            }
                        }
                    }
                    break;
                case 6:
                    string pasCalName = "August";
                    actCal.calNamePassiveLen = (byte)pasCalName.Length;
                    actCal.calNamePassive_p = Encoding.ASCII.GetBytes(pasCalName);
                    break;
                case 7:
                    {
                        actCal.numSeasonsPassive = 1;
                        actCal.seasonProfPassive_p = new SEASON_PROF_CS[actCal.numSeasonsPassive];
                        for (int i = 0; i < actCal.numSeasonsPassive; i++)
                        {
                            string seaname = "seasonk";
                            actCal.seasonProfPassive_p[i].seasonName_p = Encoding.ASCII.GetBytes(seaname);
                            actCal.seasonProfPassive_p[i].seasonStart = new DATETIME_VARVAL(new DATETIME(4, 3, 2, 1, 9, 5, 6, 7, 8, 10));
                            string weekname = "weekk";
                            actCal.seasonProfPassive_p[i].weekName_p = Encoding.ASCII.GetBytes(weekname);
                        }
                    }
                    break;
                case 8:
                    {
                        actCal.numWeeksPassive = 1;
                        actCal.weekProfPassive_p = new WEEK_PROF_CS[actCal.numWeeksPassive];
                        for (int i = 0; i < actCal.numWeeksPassive; i++)
                        {
                            actCal.weekProfPassive_p[i] = new WEEK_PROF_CS(0, 0, 0, 0, 0, 0, 0, (byte)"Week".Length, "Week" + i.ToString());
                        }

                    }
                    break;
                case 9:
                    {
                        actCal.numDayspassive = 1;
                        actCal.dayProfPassive_p = new DAY_PROF_CS[actCal.numDayspassive];
                        for (int i = 0; i < actCal.numDayspassive; i++)
                        {
                            actCal.dayProfPassive_p[i].dayId = (byte)i;
                            actCal.dayProfPassive_p[i].numActions = 8;
                            actCal.dayProfPassive_p[i].dayActions_p = new DAY_PROFACTION[actCal.dayProfPassive_p[i].numActions];
                            for (int j = 0; j < actCal.dayProfPassive_p[i].numActions; j++)
                            {
                                actCal.dayProfPassive_p[i].dayActions_p[j].scriptObis = new OBISCODE(0, 0, 10, 0, 0, 255);
                                actCal.dayProfPassive_p[i].dayActions_p[j].scriptSelector = (byte)j;
                                actCal.dayProfPassive_p[i].dayActions_p[j].startTime = new DATETIME_VARVAL(new TIME(1, 2, 3, 4));
                            }
                        }
                    }
                    break;
                case 10:
                    {
                        actCal.activatePasCalTime = new DATETIME_VARVAL(new DATETIME(6, 6, 8, 2007, 0, 1, 0, 0, 0, 0));
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleRegMonIC(ref REG_MONITOR_CS regMonitor, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        regMonitor.numThresholds = 4;
                        regMonitor.thresholds_p = new VARVALUE_CS[regMonitor.numThresholds];
                        for (int i = 0; i < regMonitor.numThresholds; i++)
                        {
                            setSampleVarValue(ref regMonitor.thresholds_p[i], DATA_TYPE.DT_UNSIGNED, 1);
                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleSingleActionSchedule(ref SINGLEACTIONSCHEDULE_CS SingleActionSchedule, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        SingleActionSchedule.exScript.scrObis = new OBISCODE(0, 0, 10, 0, 0, 255);
                        SingleActionSchedule.exScript.scrSelector = 1;
                    }
                    break;
                case 3: SingleActionSchedule.schType = SCHED_TYPE_ENUM.SZNNOWLDSAME; break;
                case 4:
                    {
                        SingleActionSchedule.exLength = 127;
                        SingleActionSchedule.exTime_p = new EX_TIME[SingleActionSchedule.exLength];
                        for (int i = 0; i < SingleActionSchedule.exLength; i++)
                        {
                            SingleActionSchedule.exTime_p[i].date = new DATETIME_VARVAL(new DATE1(6, 1, 1, 2007));
                            SingleActionSchedule.exTime_p[i].time = new DATETIME_VARVAL((new TIME(10, 10, 1, (byte)i)));
                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleHdlcSetupIC(ref HDLC_SETUP hdlcSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    hdlcSetup.commSpeed = BAUD_ENUM.b19200;
                    break;
                case 3:
                    hdlcSetup.wndTransmit = 2;
                    break;
                case 4:
                    hdlcSetup.wndReceive = 2;
                    break;
                case 5:
                    hdlcSetup.maxInfTransmit = 130;
                    break;
                case 6:
                    hdlcSetup.maxInfReceive = 130;
                    break;
                case 7:
                    hdlcSetup.interOctetTimeout = 100;
                    break;
                case 8:
                    hdlcSetup.inactivityTimeout = 10;
                    break;
                case 9:
                    hdlcSetup.deviceAddress = 20;
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleUtilityTableIC(ref UTILITY_TABLE_CS utilityTable, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: utilityTable.tableID = 5; break;
                case 3: utilityTable.tableLength = 10; break;
                case 4:
                    {
                        utilityTable.bufLen = 10;
                        utilityTable.buffer_p = new byte[utilityTable.bufLen];
                        for (int i = 0; i < utilityTable.bufLen; i++)
                            utilityTable.buffer_p[i] = (byte)i;
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSamplePSTNmcIC(ref PSTNMODEMCONFIG_CS PSTNmc, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        PSTNmc.commSpeed = BAUD_ENUM.b9600;
                    }
                    break;
                case 3:
                    {
                        PSTNmc.initString_p = new INIT_ELEMENT_CS[20];
                        for (int i = 0; i < PSTNmc.initString_p.Length; i++)
                        {
                            PSTNmc.initString_p[i].request_p = new byte[10];
                            for (int j = 0; j < PSTNmc.initString_p[i].request_p.Length; j++)
                            {
                                PSTNmc.initString_p[i].request_p[j] = (byte)2;
                            }
                            PSTNmc.initString_p[i].response1_p = new byte[10];
                            for (int j = 0; j < PSTNmc.initString_p[i].response1_p.Length; j++)
                            {
                                PSTNmc.initString_p[i].response1_p[j] = (byte)3;
                            }
                            PSTNmc.initString_p[i].delayResp = 4;
                        }
                    }
                    break;
                case 4:
                    {
                        PSTNmc.modemProfile_p = new MODEM_PROF_CS[10];
                        for (int j = 0; j < PSTNmc.modemProfile_p.Length; j++)
                        {
                            PSTNmc.modemProfile_p[j].mprofElement_p = new byte[20];
                            for (int i = 0; i < PSTNmc.modemProfile_p[j].mprofElement_p.Length; i++)
                            {
                                PSTNmc.modemProfile_p[j].mprofElement_p[i] = (byte)2;
                            }
                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSamplePSTNAutoAnsIC(ref PSTN_AUTOANSWER_CS PSTNAutoAnswer, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        PSTNAutoAnswer.mode = PSTN_MODE_ENUM.SHARED_LINE;
                    }
                    break;
                case 3:
                    {
                        PSTNAutoAnswer.lwnd_p = new WINDOW_ELEMENT1[10];
                        for (int i = 0; i < 10; i++)
                        {
                            PSTNAutoAnswer.lwnd_p[i].endTime = new DATETIME_VARVAL((new DATETIME(2, 2, 2, 2011, 100, 2, 2, 2, 2, 2)));
                            PSTNAutoAnswer.lwnd_p[i].startTime = new DATETIME_VARVAL(new DATETIME(2, 2, 2, 2011, 100, 2, 2, 2, 2, 2));
                        }
                    }
                    break;
                case 4:
                    {
                        PSTNAutoAnswer.status = STAT_ENUM1.ACTIVE;
                    }
                    break;
                case 5:
                    {
                        PSTNAutoAnswer.numCalls = 2;
                    }
                    break;
                case 6:
                    {
                        PSTNAutoAnswer.numRings.numRingsInWindow = 10;
                        PSTNAutoAnswer.numRings.numRingsOutWindow = 10;
                    }
                    break;

                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleAutoConnectIC(ref AUTOCONNECT_CS autoConnect, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: autoConnect.mode = AUTOCONNECT_ENUM.SMS_PLMN; break;
                case 3: autoConnect.repetitions = 0XDD; break;
                case 4: autoConnect.reDelay = 0xDDEE; break;
                case 5:
                    {
                        autoConnect.calwndLength = 5;
                        autoConnect.callingWindow_p = new WINDOW_ELEMENT1[autoConnect.calwndLength];
                        for (int i = 0; i < autoConnect.calwndLength; i++)
                        {
                            autoConnect.callingWindow_p[i].endTime = new DATETIME_VARVAL((new DATETIME(2, 2, 2, 2011, 100, 2, 2, 2, 2, 2)));
                            autoConnect.callingWindow_p[i].startTime = new DATETIME_VARVAL(new DATETIME(2, 2, 2, 2011, 100, 2, 2, 2, 2, 2));
                        }
                    }
                    break;
                case 6:
                    {
                        autoConnect.dlistLength = 5;
                        autoConnect.destinationList_p = new DESTINATION_LIST_CS[autoConnect.dlistLength];
                        for (int j = 0; j < autoConnect.dlistLength; j++)
                        {
                            autoConnect.destinationList_p[j].destLength = 10;
                            autoConnect.destinationList_p[j].destination_p = new byte[autoConnect.destinationList_p[j].destLength];
                            for (int i = 0; i < autoConnect.destinationList_p[j].destLength; i++)
                            {
                                autoConnect.destinationList_p[j].destination_p[i] = (byte)2;
                            }
                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSamplePushSetupIC(ref PUSH_SETUP_CS pushSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                //Attr2 SET not Supported
                case 2:
                    pushSetup.numPushEntries = 2;
                    pushSetup.pushList = new PUSH_OBJ_ENTRY_CS[pushSetup.numPushEntries];
                    pushSetup.pushList[0].classId = 40;
                    pushSetup.pushList[0].logicalName = new OBISCODE(0, 0, 25, 9, 1, 255);
                    pushSetup.pushList[0].attrIndex = 1;
                    pushSetup.pushList[0].dataIndex = 0;

                    if ((obj.version == 2) || (obj.version == 1))
                    {
#if (IC40_VERSION_1_SUPPORT || IC40_VERSION_2_SUPPORT)
                        pushSetup.pushList[0].restrictElemnt.restrctType = 0;
#endif
                    }

                    if (obj.version == 2)
                    {
#if IC40_VERSION_2_SUPPORT
                        int numColElement = 2;
                        pushSetup.pushList[0].column = new COLUMN_ELEMENT_CS[numColElement];
                        pushSetup.pushList[0].column[0].ic = 40;
                        pushSetup.pushList[0].column[0].obis = new OBISCODE(0, 0, 25, 9, 1, 255);
                        pushSetup.pushList[0].column[0].attrIndex = 2;
                        pushSetup.pushList[0].column[0].dataIndex = 0;
                        pushSetup.pushList[0].column[1].ic = 40;
                        pushSetup.pushList[0].column[1].obis = new OBISCODE(0, 0, 25, 9, 4, 255);
                        pushSetup.pushList[0].column[1].attrIndex = 4;
                        pushSetup.pushList[0].column[1].dataIndex = 0;
#endif
                    }
                    pushSetup.pushList[1].classId = 8;
                    pushSetup.pushList[1].logicalName = new OBISCODE(0, 0, 1, 0, 0, 255);
                    pushSetup.pushList[1].attrIndex = 2;
                    pushSetup.pushList[1].dataIndex = 0;

                    if ((obj.version == 2) || (obj.version == 1))
                    {
#if (IC40_VERSION_1_SUPPORT || IC40_VERSION_2_SUPPORT)
                        pushSetup.pushList[1].restrictElemnt.restrctType = 0;
                        //pushSetup.pushList[1].numColElement = 0;
#endif
                    }
                    break;
                case 3:
                    pushSetup.destMeth.destAddrLen = 10;
                    pushSetup.destMeth.eMsgType = 1;
                    pushSetup.destMeth.eTrasnType = 1;
                    pushSetup.destMeth.destAddr = new byte[pushSetup.destMeth.destAddrLen];
                    for (int i = 0; i < pushSetup.destMeth.destAddrLen; i++)
                    {
                        pushSetup.destMeth.destAddr[i] = 1;
                    }
                    break;
                case 4:
                    pushSetup.numCommWindow = 1;
                    pushSetup.comWindow = new COMM_WIND[pushSetup.numCommWindow];
                    pushSetup.comWindow[0].startTime = new byte[12];
                    pushSetup.comWindow[0].startTime[0] = 2020 >> 8;
                    pushSetup.comWindow[0].startTime[1] = 228;
                    for (int i = 2; i < 12; i++)
                    {
                        pushSetup.comWindow[0].startTime[i] = 1;
                    }
                    pushSetup.comWindow[0].endTime = new byte[12];
                    pushSetup.comWindow[0].endTime[0] = 2020 >> 8;
                    pushSetup.comWindow[0].endTime[1] = 228;
                    for (int i = 2; i < 12; i++)
                    {
                        pushSetup.comWindow[0].endTime[i] = 2;
                    }
                    break;
                case 5:
                    pushSetup.startDelay = 20;
                    break;
                case 6:
                    pushSetup.numRetries = 12;
                    break;
                case 7:
                    if (obj.version == 2)
                    {
                        pushSetup.repeatDelay = new ushort[3];
                        pushSetup.repeatDelay[0] = 2;
                        pushSetup.repeatDelay[1] = 2;
                        pushSetup.repeatDelay[2] = 2;
                    }
                    else
                    {
                        pushSetup.repeatDelay = new ushort[3];
                        pushSetup.repeatDelay[0] = 2;
                    }

                    break;
#if (IC40_VERSION_1_SUPPORT || IC40_VERSION_2_SUPPORT)
                case 8:
                    pushSetup.portRefObis = new OBISCODE(0, 0, 25, 9, 2, 255);
                    break;
                case 9:
                    pushSetup.pushClientSAP = 48;
                    break;
                //Attr10 SET not Supported
                //case 10: break;
#endif
#if IC40_VERSION_2_SUPPORT
                case 11:
                    pushSetup.pushOprtnMeth = 2;
                    break;
                case 12:
                    pushSetup.confirmationParameters.confirmationStartDate.year = 2022;
                    pushSetup.confirmationParameters.confirmationStartDate.month = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.dayOfMonth = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.dayOfWeek = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.hour = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.minute = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.second = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.hundredths = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.hbdeviation = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.lbdeviation = 2;
                    pushSetup.confirmationParameters.confirmationStartDate.clockStatus = 2;
                    pushSetup.confirmationParameters.confirmationInterval = 100;
                    break;
                //Attr13 SET not Supported
                //case 13:
                //    pushSetup.lastConfirmationDateTime.year = 2022;
                //    pushSetup.lastConfirmationDateTime.month = 2;
                //    pushSetup.lastConfirmationDateTime.dayOfMonth = 2;
                //    pushSetup.lastConfirmationDateTime.dayOfWeek = 2;
                //    pushSetup.lastConfirmationDateTime.hour = 2;
                //    pushSetup.lastConfirmationDateTime.minute = 2;
                //    pushSetup.lastConfirmationDateTime.second = 2;
                //    pushSetup.lastConfirmationDateTime.hundredths = 2;
                //    pushSetup.lastConfirmationDateTime.hbdeviation = 2;
                //    pushSetup.lastConfirmationDateTime.lbdeviation = 2;
                //    pushSetup.lastConfirmationDateTime.clockStatus = 2;
                //    break;
#endif
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleTcpUdpSetupIC(ref TCPUDPSETUP tcpUdpSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: tcpUdpSetup.tcpUdpPort = 8000; break;
                case 3: tcpUdpSetup.ipReference = new OBISCODE(1, 2, 3, 4, 5, 6); break;
                case 4: tcpUdpSetup.maxSegSize = 0x0102; break;
                case 5: tcpUdpSetup.numSimConn = 0x12; break;
                case 6: tcpUdpSetup.inactivityTimeout = 15; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleIpv4SetupIC(ref IPv4SETUP_CS ipv4, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: ipv4.dlReference = new OBISCODE(1, 2, 3, 4, 5, 6); break;
                case 3: ipv4.ipAddr = 0x0100007F; break;
                case 4:
                    {
                        ipv4.numMulticastIp = 5;
                        ipv4.multicastIpAddr_p = new uint[ipv4.numMulticastIp];
                        for (int i = 0; i < ipv4.numMulticastIp; i++)
                            ipv4.multicastIpAddr_p[i] = (uint)(0x0100 + i);
                    }
                    break;
                case 6: ipv4.subnetMask = 0x01020304; break;
                case 7: ipv4.gatewayIpAddr = 0x01020304; break;
                case 8: ipv4.useDhcpFlag = 1; break;
                case 9: ipv4.primaryDnsAddr = 0x91929394; break;
                case 10: ipv4.secondaryDnsAddr = 0x10203040; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleEthSetupIC(ref ETHERNETSETUP_CS ethernetSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        ethernetSetup.setMacAddress(1, 2, 3, 4, 5, 6);
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleGPRSSetupIC(ref GPRSMODEMSETUP_CS GPRSModemSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    GPRSModemSetup.apn_p = Encoding.ASCII.GetBytes("APN_NAME");
                    GPRSModemSetup.apnLen = (byte)GPRSModemSetup.apn_p.Length;
                    break;
                case 3: GPRSModemSetup.pincode = 0x1234; break;
                case 4:
                    {
                        GPRSModemSetup.qualityOfService.defaultVal = new QOSELEMENT(1, 2, 3, 4, 5);
                        GPRSModemSetup.qualityOfService.requested = new QOSELEMENT(6, 7, 8, 9, 10);
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleGsmDiagIC(ref GSM_DIAG_CS gSM_DIAG_CS, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 6:
                    CELLINFO_CS cellInfo = new CELLINFO_CS { };
                    cellInfo.cellId = 1;
                    cellInfo.locationId = 2;
                    cellInfo.sigQuality = 3;
                    cellInfo.ber = 4;
                    cellInfo.mcc = 5;
                    cellInfo.mnc = 6;
                    cellInfo.channelNumber = 71;
                    gSM_DIAG_CS.cellInfo = cellInfo;
                    break;
                case 7:
                    ADJCELLS_CS[] adjCells = new ADJCELLS_CS[1];
                    adjCells[0].cellId = 1;
                    adjCells[0].sigQuality = 2;
                    gSM_DIAG_CS.adjCells = adjCells;
                    gSM_DIAG_CS.numAdjCells = 1;
                    break;
                default: ret = false; break;
            }
            return ret;
        }


        public static bool setSampleSMTPSetupIC(ref SMTPSETUP_CS SMTPSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: SMTPSetup.serverPort = 0x1234; break;
                case 3:
                    SMTPSetup.userName_p = Encoding.ASCII.GetBytes("USER_NAME");
                    SMTPSetup.userNameLen = (byte)SMTPSetup.userName_p.Length;
                    break;
                case 4:
                    SMTPSetup.loginPasswd_p = Encoding.ASCII.GetBytes("PASSWORD");
                    SMTPSetup.loginPasswdLen = (byte)SMTPSetup.loginPasswd_p.Length;
                    break;
                case 5:
                    SMTPSetup.serverAddr_p = Encoding.ASCII.GetBytes("SERVER");
                    SMTPSetup.serverAddrLen = (byte)SMTPSetup.serverAddr_p.Length;
                    break;
                case 6:
                    SMTPSetup.senderAddr_p = Encoding.ASCII.GetBytes("SENDER");
                    SMTPSetup.senderAddrLen = (byte)SMTPSetup.senderAddr_p.Length;
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleLLC432SetupIC(ref LLC432SETUP_CS LLC432Setup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: LLC432Setup.maxFrameLen = 96; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleLLC80222T1SetupIC(ref LLC80222T1SETUP_CS LLC80222T1Setup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: LLC80222T1Setup.maxOctetsUiPdu = 0x1234; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleLLC80222T2SetupIC(ref LLC80222T2SETUP_CS LLC80222T2Setup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: LLC80222T2Setup.txWinSzK = 0x64; break;
                case 3: LLC80222T2Setup.rxWinSzRw = 0x64; break;
                case 4: LLC80222T2Setup.maxOctetsIPduN1 = 0x1234; break;
                case 5: LLC80222T2Setup.maxNumTxN2 = 0x64; break;
                case 6: LLC80222T2Setup.ackTimer = 0x1234; break;
                case 7: LLC80222T2Setup.pBitTimer = 0x1234; break;
                case 8: LLC80222T2Setup.rejectTimer = 0x1234; break;
                case 9: LLC80222T2Setup.busyStateTimer = 0x1234; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleLLC80222T3SetupIC(ref LLC80222T3SETUP_CS LLC80222T3Setup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: LLC80222T3Setup.maxOctetsAcnPduN3 = 0x1234; break;
                case 3: LLC80222T3Setup.maxNumTxN4 = 0x64; break;
                case 4: LLC80222T3Setup.ackTimeT1 = 0x1234; break;
                case 5: LLC80222T3Setup.rxLifetimeVarT2 = 0x1234; break;
                case 6: LLC80222T3Setup.txLifetimeVarT3 = 0x1234; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSamplecompactDataIC(ref COMPACT_DATA_CS compactData, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 3: //For IC62 Attr3 version 1 only "NONE" RestrictType is supported
                    compactData.numCapObjects = 1;
                    compactData.capObjectsArray = new CAPTURE_OBJECT62_CS[compactData.numCapObjects];
                    //compactData.capObjectsArray[0].classId = 62;
                    //compactData.capObjectsArray[0].attrIndex = 4;
                    //compactData.capObjectsArray[0].dataIndex = 0;
                    //compactData.capObjectsArray[0].obis.a = 1;
                    //compactData.capObjectsArray[0].obis.b = 3;
                    //compactData.capObjectsArray[0].obis.c = 15;
                    //compactData.capObjectsArray[0].obis.d = 2;
                    //compactData.capObjectsArray[0].obis.e = 0;
                    //compactData.capObjectsArray[0].obis.f = 255;
                    //if (obj.version > 0)
                    //{
                    //    compactData.capObjectsArray[0].restrictElemnt.restrctType = 0;
                    //}
                    compactData.capObjectsArray[0].classId = 1;
                    compactData.capObjectsArray[0].attrIndex = 2;
                    compactData.capObjectsArray[0].dataIndex = 0;
                    compactData.capObjectsArray[0].obis.a = 0;
                    compactData.capObjectsArray[0].obis.b = 0;
                    compactData.capObjectsArray[0].obis.c = 0;
                    compactData.capObjectsArray[0].obis.d = 1;
                    compactData.capObjectsArray[0].obis.e = 0;
                    compactData.capObjectsArray[0].obis.f = 255;
                    if (obj.version > 0)
                    {
                        compactData.capObjectsArray[0].restrictElemnt.restrctType = 0;
                    }
                    break;
                case 4:
                    {
                        compactData.templateID = 12;
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleSecuritySetupIC(ref SECURITY_SETUP_CS securitySetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: securitySetup.secPolicy = 0x24; break;
                case 3: securitySetup.secSuite = 0; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleDiscControlIC(ref DISC_CONTROL discControl, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: discControl.outputState = 0; break;
                case 3: discControl.controlState = 0; break;
                case 4: discControl.controlMode = 0; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleCl432SetupIC(ref CL_432_SETUP cl432Setup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: cl432Setup.deviceAddress = 1; break;
                case 3: cl432Setup.baseNodeAddress = 2; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimePLCPhyCounterIC(ref PRIME_PLC_PHY_COUNTER primePLCPhyCounter, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: primePLCPhyCounter.phyStatsCRCIncorrectCount = 1; break;
                case 3: primePLCPhyCounter.phyStatsCRCFailCount = 2; break;
                case 4: primePLCPhyCounter.phyStatsTxDropCount = 3; break;
                case 5: primePLCPhyCounter.phyStatsRxDropCount = 4; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimePLCMACSetupIC(ref PRIME_PLC_MAC_SETUP primePLCMACSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: primePLCMACSetup.macMinSwitchSearchTime = 1; break;
                case 3: primePLCMACSetup.macMaxPromotionPdu = 2; break;
                case 4: primePLCMACSetup.macPromotionPduTxPeriod = 3; break;
                case 5: primePLCMACSetup.macBeaconsPerFrame = 4; break;
                case 6: primePLCMACSetup.macScpMaxTxAttempts = 5; break;
                case 7: primePLCMACSetup.macCtlReTxTimer = 6; break;
                case 8: primePLCMACSetup.macMaxCtlReTx = 7; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimePLCMACFuncParamsIC(ref PRIME_PLC_MAC_FUNC_PARAMS_CS primePLCMACFuncParams, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: primePLCMACFuncParams.macLNID = 1; break;
                case 3: primePLCMACFuncParams.macLSID = 2; break;
                case 4: primePLCMACFuncParams.macSID = 3; break;
                case 5:
                    {
                        primePLCMACFuncParams.macSNA_p = Encoding.ASCII.GetBytes("SNA USED");
                        primePLCMACFuncParams.macSNALen =
                                    (byte)primePLCMACFuncParams.macSNA_p.Length;
                    }
                    break;
                case 6: primePLCMACFuncParams.macState = 0; break;
                case 7: primePLCMACFuncParams.macScpLength = 7; break;
                case 8: primePLCMACFuncParams.macNodeHierarchyLevel = 8; break;
                case 9: primePLCMACFuncParams.macBeaconSlotCount = 9; break;
                case 10: primePLCMACFuncParams.macBeaconRxSlot = 10; break;
                case 11: primePLCMACFuncParams.macBeaconTxSlot = 11; break;
                case 12: primePLCMACFuncParams.macBeaconRxFrequency = 12; break;
                case 13: primePLCMACFuncParams.macBeaconTxFrequency = 13; break;
                case 14: primePLCMACFuncParams.macCapabilities = 14; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimePLCMACCounterIC(ref PRIME_PLC_MAC_COUNTER primePLCMACCounter, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: primePLCMACCounter.macTxDataPktCount = 1; break;
                case 3: primePLCMACCounter.macRxDataPktCount = 2; break;
                case 4: primePLCMACCounter.macTxCtrlPktCount = 3; break;
                case 5: primePLCMACCounter.macRxCtrlPktCount = 4; break;
                case 6: primePLCMACCounter.macCSMAFailCount = 5; break;
                case 7: primePLCMACCounter.macCSMAchBusyCount = 6; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimeNtwAdminIC(ref PRIME_PLC_MAC_NETWORK_ADMIN_DATA_CS primePLCMACNwkAdminData, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        primePLCMACNwkAdminData.macMulticastEntriesList.numMacMulticastEntriesListElement = 5;
                        primePLCMACNwkAdminData.macMulticastEntriesList.macMulticastEntriesListElement_p =
                            new MAC_MULTICAST_ENTRIES_LIST_ELEMENT[primePLCMACNwkAdminData.macMulticastEntriesList.numMacMulticastEntriesListElement];
                        for (int j = 0; j < primePLCMACNwkAdminData.macMulticastEntriesList.numMacMulticastEntriesListElement; j++)
                        {
                            primePLCMACNwkAdminData.macMulticastEntriesList.macMulticastEntriesListElement_p[j].multicastEntryLCID = 1;
                            primePLCMACNwkAdminData.macMulticastEntriesList.macMulticastEntriesListElement_p[j].multicastEntryMembers = 2;

                        }
                    }
                    break;
                case 3:
                    {
                        primePLCMACNwkAdminData.macSwitchTableList.numSwitchTableEntryLSID = 5;
                        primePLCMACNwkAdminData.macSwitchTableList.switchTableEntryLSID_p =
                            new MAC_SWITCH_TABLE_LIST_ELEMENT[primePLCMACNwkAdminData.macSwitchTableList.numSwitchTableEntryLSID];
                        for (int j = 0; j < primePLCMACNwkAdminData.macSwitchTableList.numSwitchTableEntryLSID; j++)
                        {
                            primePLCMACNwkAdminData.macSwitchTableList.switchTableEntryLSID_p[j].switchTableEntryLSID = (byte)(j + 1);

                        }
                    }
                    break;
                case 4:
                    {
                        primePLCMACNwkAdminData.macDirectTableList.numDirectTableListElements = 5;
                        primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p =
                            new MAC_DIRECT_TABLE_LIST_ELEMENT[primePLCMACNwkAdminData.macDirectTableList.numDirectTableListElements];
                        for (int j = 0; j < primePLCMACNwkAdminData.macDirectTableList.numDirectTableListElements; j++)
                        {
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntrySrcSID = 1;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntrySrcLNID = 2;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntrySrcLCID = 3;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntryDstSID = 4;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntryDstLNID = 5;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntryDstLCID = 6;
                            primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntryDID = new byte[6];
                            for (int i = 0; i < 6; i++)
                                primePLCMACNwkAdminData.macDirectTableList.macDirectTableListElement_p[j].dconnEntryDID[i] = (byte)(1 + i);
                        }
                    }
                    break;
                case 5:
                    {
                        primePLCMACNwkAdminData.macAvailableSwitchesList.numMacAvailableSwitchesListElement = 5;
                        primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p =
                            new MAC_AVAILABLE_SWITCHES_LIST_ELEMENT[primePLCMACNwkAdminData.macAvailableSwitchesList.numMacAvailableSwitchesListElement];
                        for (int j = 0; j < primePLCMACNwkAdminData.macAvailableSwitchesList.numMacAvailableSwitchesListElement; j++)
                        {
                            primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slitEntrySNA = new byte[6];
                            for (int i = 0; i < 6; i++)
                                primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slitEntrySNA[i] = (byte)(1 + i);
                            primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slistEntryLSID = 2;
                            primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slistEntryLevel = 3;
                            primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slistEntryRxLevel = 4;
                            primePLCMACNwkAdminData.macAvailableSwitchesList.macAvailableSwitchesListElement_p[j].slistEntryRxSnr = 5;

                        }
                    }
                    break;
                case 6:
                    {
                        primePLCMACNwkAdminData.macPhyCommList.numMacPhyCommListElement = 5;
                        primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p =
                            new MAC_PHY_COMM_LIST_ELEMENT_CS[primePLCMACNwkAdminData.macPhyCommList.numMacPhyCommListElement];
                        for (int j = 0; j < primePLCMACNwkAdminData.macPhyCommList.numMacPhyCommListElement; j++)
                        {
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommEUI_p = Encoding.ASCII.GetBytes("PHY COMM EUI");
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommEUIlen =
                                        (byte)primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommEUI_p.Length; ;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommTxPwr = 2;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommTxCod = 3;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommRxCod = 4;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommRxLvl = 5;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommSNR = 6;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommTxPwrMod = 7;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommTxCodMod = 8;
                            primePLCMACNwkAdminData.macPhyCommList.macMulticastEntriesListElement_p[j].phyCommRxCodMod = 9;

                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleprimePLCApplIdentIC(ref PRIME_PLC_APPL_IDENT_CS primePLCApplIdent, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        primePLCApplIdent.frmVersion_p = Encoding.ASCII.GetBytes("VERSION 6");
                        primePLCApplIdent.frmVersionLength =
                                    (byte)primePLCApplIdent.frmVersion_p.Length;
                    }
                    break;
                case 3: primePLCApplIdent.vendorId = 2; break;
                case 4: primePLCApplIdent.productId = 3; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleG3PLCMacCounterIC(ref G3_PLC_MAC_COUNTER g3PLCMacCounter, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: g3PLCMacCounter.macTxDataPacketCount = 2; break;
                case 3: g3PLCMacCounter.macRxDataPacketCount = 3; break;
                case 4: g3PLCMacCounter.macTxCmdPacketCount = 4; break;
                case 5: g3PLCMacCounter.macRxCmdPacketCount = 5; break;
                case 6: g3PLCMacCounter.macCSMAfailCount = 6; break;
                case 7: g3PLCMacCounter.macCSMAnoACKcount = 7; break;
                case 8: g3PLCMacCounter.macBadCRCcount = 8; break;
                case 9: g3PLCMacCounter.macTxDataBroadcastCount = 9; break;
                case 10: g3PLCMacCounter.macRxDataBroadcastCount = 10; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleG3PLCMacSetupIC(ref G3_PLC_MAC_SETUP_CS g3PLCMacSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: g3PLCMacSetup.macShortAddress = 1; break;
                case 3: g3PLCMacSetup.macRCCoord = 2; break;
                case 4: g3PLCMacSetup.macPANid = 3; break;
                case 5:
                    {
                        g3PLCMacSetup.macKeyTables.numMacKeyTabEntries = 2;
                        g3PLCMacSetup.macKeyTables.macKeyTable =
                            new MAC_KEY_TABLE_CS[g3PLCMacSetup.macKeyTables.numMacKeyTabEntries];
                        for (int j = 0; j < g3PLCMacSetup.macKeyTables.numMacKeyTabEntries; j++)
                        {
                            g3PLCMacSetup.macKeyTables.macKeyTable[j].keyId = 1;
                            g3PLCMacSetup.macKeyTables.macKeyTable[j].key = Encoding.ASCII.GetBytes("ABCDEFGHIJKLMNOP");
                            g3PLCMacSetup.macKeyTables.macKeyTable[j].keyLen =
                                        (byte)g3PLCMacSetup.macKeyTables.macKeyTable[j].key.Length;
                        }
                    }
                    break;
                case 6: g3PLCMacSetup.macFrameCounter = 4; break;
                case 7:
                    {
                        g3PLCMacSetup.macToneMaskLen = 8;
                        g3PLCMacSetup.macToneMask = new byte[g3PLCMacSetup.macToneMaskLen / 8];
                        for (int i = 0; i < (g3PLCMacSetup.macToneMaskLen / 8); i++)
                            g3PLCMacSetup.macToneMask[i] = (byte)(i + 1);
                    }
                    break;
                case 8: g3PLCMacSetup.macTMR_TTL = 5; break;
                case 9: g3PLCMacSetup.macMaxFrameRetries = 6; break;
                case 10: g3PLCMacSetup.macNeighbourTableEntryTTL = 7; break;
                case 11:
                    {
                        g3PLCMacSetup.macNeighbourTableList.macNeighbourTabNumEntries = 5;
                        g3PLCMacSetup.macNeighbourTableList.macNeighbourTable =
                            new MAC_NEIGHBOUR_TABLE_CS[g3PLCMacSetup.macNeighbourTableList.macNeighbourTabNumEntries];
                        for (int j = 0; j < g3PLCMacSetup.macNeighbourTableList.macNeighbourTabNumEntries; j++)
                        {
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].shortAddress = 1;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].payloadModulationScheme = 2;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].toneMapLen = 8;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].toneMap =
                                new byte[g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].toneMapLen / 8];
                            for (int i = 0; i < (g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].toneMapLen / 8); i++)
                            {
                                g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].toneMap[i] = (byte)(i + 1);
                            }
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].modulation = 4;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txGain = 5;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txRes = 6;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txCoeffLen = 8;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txCoeff =
                                new byte[g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txCoeffLen / 8];
                            for (int i = 0; i < (g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txCoeffLen / 8); i++)
                            {
                                g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].txCoeff[i] = (byte)(i + 1);
                            }
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].lqi = 8;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].phaseDifferential = 9;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].tmrValidTime = 10;
                            g3PLCMacSetup.macNeighbourTableList.macNeighbourTable[j].neighbourValidTime = 11;

                        }
                    }
                    break;
                case 12: g3PLCMacSetup.macHighPriorityWindowSize = 8; break;
                case 13: g3PLCMacSetup.macCSMAFairnessLimit = 9; break;
                case 14: g3PLCMacSetup.macBeaconRandomWinLen = 10; break;
                case 15: g3PLCMacSetup.macA = 11; break;
                case 16: g3PLCMacSetup.macK = 12; break;
                case 17: g3PLCMacSetup.macMinCWAttempts = 13; break;
                case 18: g3PLCMacSetup.macCenelecLegacyMode = 14; break;
                case 19: g3PLCMacSetup.macFCCLegacyMode = 15; break;
                case 20: g3PLCMacSetup.macMaxBE = 16; break;
                case 21: g3PLCMacSetup.macMaxCSMABackoffs = 17; break;
                case 22: g3PLCMacSetup.macMinBE = 18; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleG3PLCAdaptSetupIC(ref G3_PLC_ADAPT_SETUP_CS g3PLCAdaptSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: g3PLCAdaptSetup.adpMaxHops = 1; break;
                case 3: g3PLCAdaptSetup.adpWeakLQIValue = 2; break;
                case 4: g3PLCAdaptSetup.adpSecurityLevel = 3; break;
                case 5:
                    {
                        g3PLCAdaptSetup.adpPrefixTableList.numPrefix = 5;
                        g3PLCAdaptSetup.adpPrefixTableList.adpPrefixEntryElemnts_p =
                            new ADP_PREFIX_TAB[g3PLCAdaptSetup.adpPrefixTableList.numPrefix];
                        for (int j = 0; j < g3PLCAdaptSetup.adpPrefixTableList.numPrefix; j++)
                        {
                            g3PLCAdaptSetup.adpPrefixTableList.adpPrefixEntryElemnts_p[j].adpPrefixEntry = new byte[16];
                            for (int i = 0; i < 16; i++)
                            {
                                g3PLCAdaptSetup.adpPrefixTableList.adpPrefixEntryElemnts_p[j].adpPrefixEntry[i] = (byte)(1 + i);
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        g3PLCAdaptSetup.adpRoutingConfiguration.routingConfigNumEntries = 5;
                        g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p =
                            new ADP_ROUTING_CONFIG[g3PLCAdaptSetup.adpRoutingConfiguration.routingConfigNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpRoutingConfiguration.routingConfigNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpNetTraversalTime = 1;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpRoutingTabEntryTTL = 2;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKr = 3;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKm = 4;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKc = 5;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKq = 6;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKh = 7;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpKrt = 8;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpRREQRetries = 9;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpRREQ_RERRWait = 10;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpBlacklistTabEntryTTL = 11;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpUnicastRREQGenEnable = 12;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpRLCEnabled = 13;
                            g3PLCAdaptSetup.adpRoutingConfiguration.adpRoutingConfiguration_p[j].adpAddRevLinkCost = 14;
                        }
                    }
                    break;
                case 7: g3PLCAdaptSetup.adpBrdcstLogTabEntryTTL = 6; break;
                case 8:
                    {
                        g3PLCAdaptSetup.adpRoutingTable.adpRoutingTabNumEntries = 5;
                        g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p =
                            new ADP_ROUTING_TABLE[g3PLCAdaptSetup.adpRoutingTable.adpRoutingTabNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpRoutingTable.adpRoutingTabNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].destinationAddress = 1;
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].nextHopAddress = 2;
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].routeCost = 3;
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].hopCount = 4;
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].weakLinkCount = 5;
                            g3PLCAdaptSetup.adpRoutingTable.adpRoutingTable_p[j].validTime = 6;
                        }
                    }
                    break;
                case 9:
                    {
                        g3PLCAdaptSetup.adpCntxtInfoTable.adpContextInfoTabNumEntries = 5;
                        g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p =
                            new ADP_CONTEXT_INFO_TAB_CS[g3PLCAdaptSetup.adpCntxtInfoTable.adpContextInfoTabNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpCntxtInfoTable.adpContextInfoTabNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].CID = 1;
                            g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].contextLen = 2;
                            g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].context =
                                new byte[g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].contextLen];
                            for (int i = 0; i < g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].contextLen; i++)
                            {
                                g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].context[i] = (byte)(1 + i);
                            }
                            g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].cVal = 3;
                            g3PLCAdaptSetup.adpCntxtInfoTable.adpCntxtInfoTable_p[j].valid_Lifetime = 4;
                        }
                    }
                    break;
                case 10:
                    {
                        g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTabNumEntries = 5;
                        g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTable_p =
                            new ADP_BLACKLIST_TABLE[g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTabNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTabNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTable_p[j].blacklistedNeighbourAddr = 1;
                            g3PLCAdaptSetup.adpBlacklistTable.adpBlacklistTable_p[j].validTime = 2;
                        }
                    }
                    break;
                case 11:
                    {
                        g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstTabNumEntries = 5;
                        g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstLogTable_p =
                            new ADP_BRDCST_LOG_TABLE[g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstTabNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstTabNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstLogTable_p[j].sourceAddr = 1;
                            g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstLogTable_p[j].sequenceNum = 2;
                            g3PLCAdaptSetup.adpBrdcstLogTable.adpBrdcstLogTable_p[j].validTime = 3;
                        }
                    }
                    break;
                case 12:
                    {
                        g3PLCAdaptSetup.adpGroupTable.adpGroupTabNumEntries = 5;
                        g3PLCAdaptSetup.adpGroupTable.adpGroupTable_p =
                            new ADP_GROUP_TABLE[g3PLCAdaptSetup.adpGroupTable.adpGroupTabNumEntries];
                        for (int j = 0; j < g3PLCAdaptSetup.adpGroupTable.adpGroupTabNumEntries; j++)
                        {
                            g3PLCAdaptSetup.adpGroupTable.adpGroupTable_p[j].groupAddr = (ushort)(j + 1);
                        }
                    }
                    break;
                case 13: g3PLCAdaptSetup.adpMaxJoinWaitTime = 12; break;
                case 14: g3PLCAdaptSetup.adpPathDiscoveryTime = 13; break;
                case 15: g3PLCAdaptSetup.adpActiveKeyIndex = 14; break;
                case 16: g3PLCAdaptSetup.adpMetricType = 15; break;
                case 17: g3PLCAdaptSetup.adpCoordShortAddress = 16; break;
                case 18: g3PLCAdaptSetup.adpDisableDefaultRouting = 17; break;
                case 19: g3PLCAdaptSetup.adpDeviceType = 0; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleWiSunSetupIC(ref WI_SUN_SETUP_CS wiSunSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    wiSunSetup.nwName = Encoding.ASCII.GetBytes("WI SUN");
                    //wiSunSetup.nwNameLen = (byte)wiSunSetup.nwName.Length;
                    break;
                case 3:
                    wiSunSetup.routingMeth = 0;
                    break;
                case 4:
                    wiSunSetup.panId = 1;
                    break;
                case 5:
                    wiSunSetup.disc_imin = 1;
                    break;
                case 6:
                    wiSunSetup.disc_imax = 2;
                    break;
                case 7:
                    wiSunSetup.data_message_imin = 1;
                    break;
                case 8:
                    wiSunSetup.data_message_imax = 2;
                    break;
                case 9:
                    wiSunSetup.default_dio_interval_min = 1;
                    break;
                case 10:
                    wiSunSetup.default_dio_interval_doublings = 2;
                    break;
                case 11:
                    wiSunSetup.chPlan.regDomIdentifier = 0;
                    wiSunSetup.chPlan.opClassDesgtr = 0;
                    break;
                case 12:
                    wiSunSetup.chFunction = CHANNEL_FUNCTION_ENUM.DH1CF;
                    break;
                case 13:
                    setSampleVarValue(ref wiSunSetup.exludedChannels, DATA_TYPE.DT_BIT_STRING, 8); break;
                case 14:
                    wiSunSetup.joinState = JOIN_STATE_ENUM.ACQPANCONFIG;
                    break;
                case 15:

                    wiSunSetup.reg_ch_exclusions.numChannels = 8;
                    ushort len = (ushort)(wiSunSetup.reg_ch_exclusions.numChannels / 8);
                    if ((wiSunSetup.reg_ch_exclusions.numChannels % 8) > 0)
                        len++;
                    wiSunSetup.reg_ch_exclusions.exChannels = new byte[len];
                    for (int i = 0; i < len; i++)
                        wiSunSetup.reg_ch_exclusions.exChannels[i] = (byte)(i + 1);

                    break;
            }
            return ret;
        }
        public static bool setSampleWiSunRplDiagnosticIC(ref WI_SUN_RPL_DIAG_CS rplDiag, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    rplDiag.rplId = 2;
                    break;
                case 3:
                    rplDiag.dodagVerNum = 1;
                    break;
                case 4:
                    rplDiag.dodagRank = 1;
                    break;
                case 5:
                    rplDiag.groundedFlag = 0;
                    break;
                case 6:
                    rplDiag.opMode = 0;
                    break;
                case 7:
                    rplDiag.dodag_prf = 1;
                    break;
                case 8:
                    rplDiag.dodag_dtsn = 2;
                    break;
                case 9:

                    rplDiag.dodag_id = new byte[] { 192, 168, 100, 100 };
                    // rplDiag.dodag_idLen = (byte)rplDiag.dodag_id.Length;
                    break;
            }
            return ret;
        }

        public static bool setSampleMplDiagnostic(ref MPL_DIAGNOSTIC_CS mpldiagnostic, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {

                case 2: mpldiagnostic.proactive_forwarding = 1; break;
                case 3: mpldiagnostic.z = 2; break;
                case 4: mpldiagnostic.tunit = 100; break;
                case 5: mpldiagnostic.se_lifetime = 3000; break;
                case 6: mpldiagnostic.dm_k = 50; break;
                case 7: mpldiagnostic.dm_imin = 1000; break;
                case 8: mpldiagnostic.dm_imax = 200; break;
                case 9: mpldiagnostic.dm_t_exp = 1500; break;
                case 10: mpldiagnostic.c_k = 140; break;
                case 11: mpldiagnostic.c_imin = 2000; break;
                case 12: mpldiagnostic.c_imax = 180; break;
                case 13: mpldiagnostic.c_t_exp = 36580; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleWisunDiagnostic(ref WiSUN_DIAGNOSTIC_CS WisunDiagnostic, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    WisunDiagnostic.sysDescr = Encoding.ASCII.GetBytes("Wisun");
                    //WisunDiagnostic.sysDescrLen = (byte)WisunDiagnostic.sysDescr.Length;
                    break;
                case 3:
                    WisunDiagnostic.ifNumber = 5;
                    break;
                case 4:
                    {

                        WisunDiagnostic.iftableElementSpecs = new IFTABLE_ELEMENT_SPECS_CS[2];
                        for (int i = 0; i < WisunDiagnostic.iftableElementSpecs.Length; i++)
                        {
                            string ifdescrname = "Manufacturer Name";
                            WisunDiagnostic.iftableElementSpecs[i].ifDescrnName = Encoding.ASCII.GetBytes(ifdescrname);
                            string ifphyaddressname = "Physical Address Name";
                            WisunDiagnostic.iftableElementSpecs[i].ifPhyaddressName = Encoding.ASCII.GetBytes(ifphyaddressname);
                            WisunDiagnostic.iftableElementSpecs[i].ifinoctets = 1;
                            WisunDiagnostic.iftableElementSpecs[i].ifinucastpackets = 2;
                            WisunDiagnostic.iftableElementSpecs[i].ifinnucastpackets = 3;
                            WisunDiagnostic.iftableElementSpecs[i].ifinerrors = 4;
                            WisunDiagnostic.iftableElementSpecs[i].ifinunknownprotos = 5;
                            WisunDiagnostic.iftableElementSpecs[i].ifoutoctets = 6;
                            WisunDiagnostic.iftableElementSpecs[i].ifoutucastpackets = 7;
                            WisunDiagnostic.iftableElementSpecs[i].ifoutnucastpackets = 8;
                            WisunDiagnostic.iftableElementSpecs[i].ifouterrors = 9;
                            WisunDiagnostic.iftableElementSpecs[i].ifoutQlen = 10;
                        }
                    }
                    break;
                case 5:
                    {
                        WisunDiagnostic.neighbourTableEntries = new NEIGHBOUR_ELEMENT_CS[2];
                        for (int i = 0; i < WisunDiagnostic.neighbourTableEntries.Length; i++)
                        {
                            string neighbourIdname = "EUI 64 of the neighbour device";
                            WisunDiagnostic.neighbourTableEntries[i].neighbourId = Encoding.ASCII.GetBytes(neighbourIdname);
                            WisunDiagnostic.neighbourTableEntries[i].neighbourType = 0;
                            WisunDiagnostic.neighbourTableEntries[i].deviceRank = 1;
                            WisunDiagnostic.neighbourTableEntries[i].rssi = 2;
                            WisunDiagnostic.neighbourTableEntries[i].etxToParent = 3;
                        }
                    }
                    break;
                case 6:
                    {
                        WisunDiagnostic.transmissionTableEntries = new TRANSMISSION_INFO_CS[2];
                        for (int i = 0; i < WisunDiagnostic.transmissionTableEntries.Length; i++)
                        {
                            string transneighbourIdname = "EUI-64 of the FAN interface";
                            WisunDiagnostic.transmissionTableEntries[i].neighbourId = Encoding.ASCII.GetBytes(transneighbourIdname);
                            WisunDiagnostic.transmissionTableEntries[i].numberOfReceptions = 1;
                            WisunDiagnostic.transmissionTableEntries[i].numberOfSucessfulTrans = 2;
                            WisunDiagnostic.transmissionTableEntries[i].numberOfFailedTrans = 3;
                        }
                    }
                    break;
            }
            return ret;
        }

        public static bool setSampleIEC62055(ref IEC62055_CS iec62055, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    iec62055.meter_pan.issuerIdentificationNumber = 12;
                    iec62055.meter_pan.decoderRefNumber = 13;
                    iec62055.meter_pan.panCheckDigit = 11;
                    break;
                case 3:

                    iec62055.commodityLen = 3;
                    iec62055.commodity = new byte[iec62055.commodityLen];
                    iec62055.commodity[0] = (byte)'G';
                    iec62055.commodity[1] = (byte)'A';
                    iec62055.commodity[2] = (byte)'s';
                    break;
                case 4:
                    iec62055.numtokenCarrierTypes = 5;
                    iec62055.tokenCarrierTypes = new byte[iec62055.numtokenCarrierTypes];
                    iec62055.tokenCarrierTypes[0] = (byte)'1';
                    iec62055.tokenCarrierTypes[1] = (byte)'2';
                    iec62055.tokenCarrierTypes[2] = (byte)'3';
                    iec62055.tokenCarrierTypes[3] = (byte)'4';
                    iec62055.tokenCarrierTypes[4] = (byte)'5';
                    break;

                case 5:
                    iec62055.encAlgorithm = 1;
                    //This attribute shall be set at the time of manufacture and shall be “read only” through the
                    //DLMS server’s communication interfaces
                    break;

                case 6:
                    iec62055.supplyGroupcode = 001;
                    break;

                case 7:
                    iec62055.tariffIndex = 2;
                    break;

                case 8:
                    iec62055.keyrevnumber = 3;
                    break;

                case 9:
                    iec62055.keytype = 3;
                    break;

                case 10:
                    iec62055.keyexpirynumber = 5;
                    break;

                case 11:
                    iec62055.numberofkctsupported = 2;
                    break;

                case 12:
                    iec62055.stscertificateLen = 3;
                    iec62055.stscertificatenumber = new byte[iec62055.stscertificateLen];
                    iec62055.stscertificatenumber[0] = (byte)'1';
                    iec62055.stscertificatenumber[1] = (byte)'2';
                    iec62055.stscertificatenumber[2] = (byte)'3';
                    break;


            }
            return ret;
        }






        public static bool setSampleAccountIC(ref ACCOUNT_OBJ_CS accountObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    accountObj.accntModeStatus.paymntMode = 0;
                    accountObj.accntModeStatus.accntStat = 0;
                    break;
                case 3:
                    accountObj.currentCreditInUse = 30;
                    break;
                case 4:
                    accountObj.currentCreditStatus = 5;
                    break;
                case 5:
                    accountObj.availableCredit = 80;
                    break;
                case 6:
                    accountObj.amountToClear = 8;
                    break;
                case 7:
                    accountObj.clearanceThreshold = 10;
                    break;
                case 8:
                    accountObj.aggregatedDebt = 15;
                    break;
                case 9:
                    {
                        accountObj.creditRefListInfo.numCreditRef = 5;
                        accountObj.creditRefListInfo.creditRefList_p =
                            new CREDIT_REF_LIST[accountObj.creditRefListInfo.numCreditRef];
                        for (int j = 0; j < accountObj.creditRefListInfo.numCreditRef; j++)
                        {
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.a = 1;
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.b = 1;
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.c = 1;
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.d = 9;
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.e = 1;
                            accountObj.creditRefListInfo.creditRefList_p[j].creditRefObis.f = 255;
                        }
                    }
                    break;
                case 10:
                    {
                        accountObj.chargeRefListInfo.numChargeRef = 5;
                        accountObj.chargeRefListInfo.chargeRefList_p =
                            new CHARGE_REF_LIST[accountObj.chargeRefListInfo.numChargeRef];
                        for (int j = 0; j < accountObj.chargeRefListInfo.numChargeRef; j++)
                        {
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.a = 1;
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.b = 1;
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.c = 1;
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.d = 9;
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.e = 1;
                            accountObj.chargeRefListInfo.chargeRefList_p[j].chargeRefObis.f = 255;
                        }
                    }
                    break;
                case 11:
                    {
                        accountObj.creditChanrgeConInfo.numCredtChargeConf = 5;
                        accountObj.creditChanrgeConInfo.creditChargeConfList_p =
                            new CREDIT_CHARGE_CONFG_LIST[accountObj.creditChanrgeConInfo.numCredtChargeConf];
                        for (int j = 0; j < accountObj.creditChanrgeConInfo.numCredtChargeConf; j++)
                        {

                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.a = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.b = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.c = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.d = 9;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.e = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].creditRefObis.f = 255;

                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.a = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.b = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.c = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.d = 9;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.e = 1;
                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].chargeRefObis.f = 255;

                            accountObj.creditChanrgeConInfo.creditChargeConfList_p[j].collectionConfig = (ushort)(j + 1);
                        }
                    }
                    break;
                case 12:
                    {
                        accountObj.tokenGetwayConInfo.numTokenGetwayConf = 5;
                        accountObj.tokenGetwayConInfo.tokenGetwayConList_p =
                            new TOKEN_GETWAY_CONFG_LIST[accountObj.tokenGetwayConInfo.numTokenGetwayConf];
                        for (int j = 0; j < accountObj.tokenGetwayConInfo.numTokenGetwayConf; j++)
                        {

                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.a = 1;
                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.b = 1;
                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.c = 1;
                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.d = 9;
                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.e = 1;
                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].creditRefObis.f = 255;

                            accountObj.tokenGetwayConInfo.tokenGetwayConList_p[j].tokenProp = (byte)(j + 1);
                        }
                    }
                    break;
                case 13:
                    accountObj.accntActiveTime = new byte[12];
                    for (int i = 0; i < 12; i++)
                        accountObj.accntActiveTime[i] = (byte)(i + 1);
                    break;
                case 14:
                    accountObj.accntCloseTime = new byte[12];
                    for (int i = 0; i < 12; i++)
                        accountObj.accntCloseTime[i] = (byte)(i + 1);
                    break;
                case 15:
                    accountObj.curncy.currencyNameLen = 1;
                    accountObj.curncy.currencyName = new byte[accountObj.curncy.currencyNameLen];
                    for (int i = 0; i < accountObj.curncy.currencyNameLen; i++)
                        accountObj.curncy.currencyName[i] = (byte)(i + 1);
                    accountObj.curncy.scale = 3;
                    accountObj.curncy.unit = 0;
                    break;
                case 16:
                    accountObj.lowCreditThreshold = 30;
                    break;
                case 17:
                    accountObj.nextCreditAvailThreshold = 20;
                    break;
                case 18:
                    accountObj.maxProvsn = 10;
                    break;
                case 19:
                    accountObj.maxProvsnPeriod = 5;
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleCreditIC(ref CREDIT_OBJ creditObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    creditObj.currCrdtAmnt = 100;
                    break;
                case 3:
                    creditObj.creditType = 0;
                    break;
                case 4:
                    creditObj.crdtPriority = 2;
                    break;
                case 5:
                    creditObj.warningThrshld = 20;
                    break;
                case 6:
                    creditObj.limit = 10;
                    break;
                case 7:
                    creditObj.creditConfg = 7;
                    break;
                case 8:
                    creditObj.crdtStats = 0;
                    break;
                case 9:
                    creditObj.presetCrdtAmt = 5;
                    break;
                case 10:
                    creditObj.crdtAvailThrshld = 8;
                    break;
                case 11:
                    creditObj.period = new byte[12];
                    for (int i = 0; i < 12; i++)
                        creditObj.period[i] = (byte)(i + 1);
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleChargeIC(ref CHARGE_OBJ_CS chargeObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    chargeObj.totAmtPaid = 100;
                    break;
                case 3:
                    chargeObj.chargType = 0;
                    break;
                case 4:
                    chargeObj.chrgPriority = 2;
                    break;
                case 5:
                    chargeObj.unitChargeActve.chargePerUnitScaling.commodityScale = 1;
                    chargeObj.unitChargeActve.chargePerUnitScaling.priceScale = 2;
                    chargeObj.unitChargeActve.comodiftReference.classID = 1;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.a = 1;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.b = 0;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.c = 0;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.d = 9;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.e = 1;
                    chargeObj.unitChargeActve.comodiftReference.logicalName.f = 255;
                    chargeObj.unitChargeActve.comodiftReference.attributeIndx = 2;
                    chargeObj.unitChargeActve.chargeTable.numChargeTabElemnts = 1;
                    chargeObj.unitChargeActve.chargeTable.chargeTabElements =
                            new CHARGE_TAB_ELEMNT_CS[chargeObj.unitChargeActve.chargeTable.numChargeTabElemnts];
                    for (int j = 0; j < chargeObj.unitChargeActve.chargeTable.numChargeTabElemnts; j++)
                    {

                        chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].indexLen = 2;
                        chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].index =
                            new byte[(chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].indexLen)];
                        for (int i = 0; i < chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].indexLen; i++)
                            chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].index[i] = (byte)(i + 1);
                        chargeObj.unitChargeActve.chargeTable.chargeTabElements[j].chargePerUnit = 3;
                    }
                    break;
                case 6:
                    chargeObj.unitChargePassve.chargePerUnitScaling.commodityScale = 1;
                    chargeObj.unitChargePassve.chargePerUnitScaling.priceScale = 2;
                    chargeObj.unitChargePassve.comodiftReference.classID = 1;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.a = 1;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.b = 0;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.c = 0;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.d = 9;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.e = 1;
                    chargeObj.unitChargePassve.comodiftReference.logicalName.f = 255;
                    chargeObj.unitChargePassve.comodiftReference.attributeIndx = 2;
                    chargeObj.unitChargePassve.chargeTable.numChargeTabElemnts = 1;
                    chargeObj.unitChargePassve.chargeTable.chargeTabElements =
                            new CHARGE_TAB_ELEMNT_CS[chargeObj.unitChargePassve.chargeTable.numChargeTabElemnts];
                    for (int j = 0; j < chargeObj.unitChargePassve.chargeTable.numChargeTabElemnts; j++)
                    {

                        chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].indexLen = 2;
                        chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].index =
                            new byte[(chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].indexLen)];
                        for (int i = 0; i < chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].indexLen; i++)
                            chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].index[i] = (byte)(i + 1);
                        chargeObj.unitChargePassve.chargeTable.chargeTabElements[j].chargePerUnit = 3;
                    }
                    break;
                case 7:
                    chargeObj.unitChargeActvnTime = new byte[12];
                    for (int i = 0; i < 12; i++)
                        chargeObj.unitChargeActvnTime[i] = (byte)(i + 1);
                    break;
                case 8:
                    chargeObj.chrgPeriod = 10;
                    break;
                case 9:
                    chargeObj.chrgConfg = 5;
                    break;
                case 10:
                    chargeObj.lastCollctnTime = new byte[12];
                    for (int i = 0; i < 12; i++)
                        chargeObj.lastCollctnTime[i] = (byte)(i + 1);
                    break;
                case 11:
                    chargeObj.lastCollctnAmt = 50;
                    break;
                case 12:
                    chargeObj.totAmtRemng = 15;
                    break;
                case 13:
                    chargeObj.proportion = 5;
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleTokenIC(ref TOKEN_OBJ_CS tokenObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    tokenObj.tokenLen = 5;
                    tokenObj.token = new byte[tokenObj.tokenLen];
                    for (int i = 0; i < tokenObj.tokenLen; i++)
                        tokenObj.token[i] = (byte)(i + 1);
                    break;
                case 3:
                    tokenObj.tokenTime = new byte[12];
                    for (int i = 0; i < 12; i++)
                        tokenObj.tokenTime[i] = (byte)(i + 1);
                    break;
                case 4:
                    tokenObj.tokenDescrptn.numDescElements = 1;
                    tokenObj.tokenDescrptn.descElement = new DESC_ELEMENT_CS[tokenObj.tokenDescrptn.numDescElements];
                    for (int i = 0; i < tokenObj.tokenDescrptn.numDescElements; i++)
                    {
                        tokenObj.tokenDescrptn.descElement[i].decLen = 5;
                        tokenObj.tokenDescrptn.descElement[i].desc = new byte[tokenObj.tokenDescrptn.descElement[i].decLen];
                        for (int j = 0; j < tokenObj.tokenDescrptn.descElement[i].decLen; j++)
                            tokenObj.tokenDescrptn.descElement[i].desc[j] = (byte)(j + 1);
                    }
                    break;
                case 5:
                    tokenObj.tokenDelivMeth = 0;
                    break;
                case 6:
                    tokenObj.tokenStatus.statusCode = 0;
                    tokenObj.tokenStatus.dataValLen = 8;
                    ushort len = (ushort)(tokenObj.tokenStatus.dataValLen / 8);
                    if ((tokenObj.tokenStatus.dataValLen % 8) > 0)
                        len++;
                    tokenObj.tokenStatus.dataVal = new byte[len];
                    for (int i = 0; i < len; i++)
                        tokenObj.tokenStatus.dataVal[i] = (byte)(i + 1);
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleLTEMonitoringIC(ref LTE_MONITORING_OBJ_CS LteMonitoringObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        LteMonitoringObj.LteNwParamType.T3402 = 1;
                        LteMonitoringObj.LteNwParamType.T3412 = 2;
                        //LteMonitoringObj.LteNwParamType.RSRQ = 1;
                        //LteMonitoringObj.LteNwParamType.RSRP = 1;
                        LteMonitoringObj.LteNwParamType.T3412ext2 = 3;
                        LteMonitoringObj.LteNwParamType.T3324 = 4;
                        LteMonitoringObj.LteNwParamType.TeDRX = 1;
                        LteMonitoringObj.LteNwParamType.TPTW = 2;
                        LteMonitoringObj.LteNwParamType.qRxlevMin = 3;
                        LteMonitoringObj.LteNwParamType.qRxlevMinCE_r13 = 4;
                        LteMonitoringObj.LteNwParamType.qRxlevMinCE1_r13 = 1;
                    }
                    break;
                case 3:
                    {
                        LteMonitoringObj.Lte_Qos.N_RSRQ = 1;
                        LteMonitoringObj.Lte_Qos.N_RSRP = 2;
                        LteMonitoringObj.Lte_Qos.snr = 3;
                        LteMonitoringObj.Lte_Qos.ConvergeEnhancement = CONVRG_ENHNCMNT_ENUM.CE_MODE_A;
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setSampleExtendedDataIC(ref EXTENDED_DATA_CS extendedData, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: setSampleVarValue(ref extendedData.valueActive, DATA_TYPE.DT_OCTET_STRING, 5); break;
                case 3: extendedData.scalerUnitActive = new SCALERUNIT(1, UNIT_ENUM.VOLUME_M3); break;
                case 4: setSampleVarValue(ref extendedData.valuePassive, DATA_TYPE.DT_OCTET_STRING, 5); break;
                case 5: extendedData.scalerUnitPassive = new SCALERUNIT(1, UNIT_ENUM.VOLUME_M3); break;
                case 6: extendedData.activatePassiveValueTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleZigbeeTunnelSetupIC(ref ZIGBEE_TUNNEL_SETUP_CS zigbeeTunnelSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: zigbeeTunnelSetup.maxIncTransferSize = 0x5dc; break;
                case 3: zigbeeTunnelSetup.maxOutTransferSize = 65535; break;
                case 4:
                    zigbeeTunnelSetup.protocolAddress = new byte[6];
                    for (int ij = 0; ij < 6; ij++)
                    {
                        zigbeeTunnelSetup.protocolAddress[ij] = (byte)ij;
                    }
                    break;
                case 5: zigbeeTunnelSetup.closeTunnelTimeout = 65535; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleImageTransfer(ref IMAGE_TRANSFER_CS imageTransfer, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 5:
                    imageTransfer.imageTxEnabled = 1;
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleCoTsObjectIC(ref CoTS_OBJECT_CS coTsObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: coTsObject.dateTimeOfStart = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 3:
                    coTsObject.scriptExecuted_p = new ACTION_ITM[64];
                    for (int ij = 0; ij < 64; ij++)
                    {
                        coTsObject.scriptExecuted_p[ij].scrObis = new OBISCODE(0, 1, 2, 3, 4, 5);
                        coTsObject.scriptExecuted_p[ij].scrSelector = (ushort)ij;
                    }
                    break;
                case 4:
                    coTsObject.tenantReference = new byte[12];
                    for (int ij = 0; ij < 12; ij++)
                    {
                        coTsObject.tenantReference[ij] = (byte)ij;/* attribute 4*/
                    }
                    break;
                case 5:
                    coTsObject.tenantId = 65535; /* attribute 5*/
                    break;
                case 6:
                    coTsObject.supplierReference = new byte[12];
                    for (int ij = 0; ij < 12; ij++)
                    {
                        coTsObject.supplierReference[ij] = (byte)ij;	/* attribute 6*/
                    }
                    break;
                case 7: coTsObject.supplierId = 65535;/* attribute 7*/ break;
                case 8: coTsObject.passiveDateTimeOfStart = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 9:
                    coTsObject.passiveScriptExecuted_p = new ACTION_ITM[64]; /* attribute 9 */
                    for (int ij = 0; ij < 64; ij++)
                    {
                        coTsObject.passiveScriptExecuted_p[ij].scrObis = new OBISCODE(0, 1, 2, 3, 4, 5);
                        coTsObject.passiveScriptExecuted_p[ij].scrSelector = (byte)ij;
                    }
                    break;
                case 10:
                    coTsObject.passiveTenantReference = new byte[12];
                    for (int ij = 0; ij < 12; ij++)
                    {
                        coTsObject.passiveTenantReference[ij] = (byte)ij;	/* attribute 10*/
                    }
                    break;
                case 11: coTsObject.passiveTenantId = 65535; break; /* attribute 11*/
                case 12:
                    coTsObject.passiveSupplierReference = new byte[12];
                    for (int ij = 0; ij < 12; ij++)
                    {
                        coTsObject.passiveSupplierReference[ij] = (byte)ij;/* attribute 12*/
                    }
                    break;
                case 13: coTsObject.passiveSupplierId = 65535; break;/* attribute 13*/
                case 14: coTsObject.activationTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleblkTarifConfIC(ref BLOCK_TARIFF_CONFGTN_OBJECT blockTariffConfgtnObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: blockTariffConfgtnObject.blockStartTimeActive = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;
                case 3: blockTariffConfgtnObject.blockPeriodActive = 0xFFFFFFFF; break;/* attribute 3*/
                case 4: blockTariffConfgtnObject.blockPeriodUnitActive = new SCALERUNIT(1, UNIT_ENUM.CURRENT_A); break;
                case 5: blockTariffConfgtnObject.resolvingPeriod = 1; break;/* attribute 5*/
                case 6: blockTariffConfgtnObject.blockStartTimePassive = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break; /*attribute 6*/
                case 7: blockTariffConfgtnObject.blockPeriodPassive = 0xFFFFFFFF; break;/* attribute 7*/
                case 8: blockTariffConfgtnObject.blockPeriodUnitPassive = new SCALERUNIT(5, UNIT_ENUM.CURRENT_A); break;
                case 9: blockTariffConfgtnObject.resolvingPeriodPassive = 1; break;/* attribute 9*/
                case 10: blockTariffConfgtnObject.activationTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0)); break;/* attribute 10*/
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleZigbeeSASIC(ref ZIGBEE_SAS_STARTUP_OBJECT_CS zigbeeSASStartupObject, _OBJ obj)
        {
            bool ret = true;
            int ij = 0;
            switch (obj.attrMethID)
            {
                case 2: zigbeeSASStartupObject.shortAddress = 65535; break;
                case 3:
                    zigbeeSASStartupObject.extendedPanId = new byte[8];
                    for (ij = 0; ij < 8; ij++)
                    {
                        zigbeeSASStartupObject.extendedPanId[ij] = 0;
                    }
                    break;
                case 4: zigbeeSASStartupObject.panId = 65535; break;
                case 5: zigbeeSASStartupObject.channelMask = 0; break;
                case 6:
                    zigbeeSASStartupObject.protocolVersion = 2;
                    break;
                case 7: zigbeeSASStartupObject.stackProfile = 0; break;
                case 8: zigbeeSASStartupObject.startupControl = 2; break;
                case 9:
                    zigbeeSASStartupObject.trustCentreAdress = new byte[8];
                    for (ij = 0; ij < 8; ij++)
                    {
                        zigbeeSASStartupObject.trustCentreAdress[ij] = 0;
                    }
                    break;
                case 10:
                    zigbeeSASStartupObject.linkKey = new byte[16];
                    for (ij = 0; ij < 16; ij++)
                    {
                        zigbeeSASStartupObject.linkKey[ij] = 0;
                    }
                    break;
                case 11:
                    zigbeeSASStartupObject.networkKey = new byte[16];
                    for (ij = 0; ij < 16; ij++)
                    {
                        zigbeeSASStartupObject.networkKey[ij] = 0;
                    }
                    break;
                case 12: zigbeeSASStartupObject.useInsecureJoin = 0; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleZigbeeSASJoinIC(ref ZIGBEE_SAS_JOIN_OBJECT zigbeeSASJoinObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: zigbeeSASJoinObject.scanAttempts = 3; break;
                case 3: zigbeeSASJoinObject.timeBetweenScans = 1; break;
                case 4: zigbeeSASJoinObject.rejoinInterval = 60; break;
                case 5: zigbeeSASJoinObject.rejoinRetryInterval = 15; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSampleZigbeeSASfragIC(ref ZIGBEE_SAS_FRAGMENTATION_OBJECT zigbeeSASFragmentationObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2: zigbeeSASFragmentationObject.apsInterframeDelay = 65535; break; /* attribute 2 */
                case 3: zigbeeSASFragmentationObject.apsMaxWindowSize = 65535; break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setSamplezigbeeSETControlIC(ref ZIGBEE_SETC_CONTROL_OBJECT_CS zigbeeSETCControlObject, _OBJ obj)
        {
            bool ret = true;
            int ij = 0;
            switch (obj.attrMethID)
            {
                case 2: zigbeeSETCControlObject.enableDisableJoining = 0; break;
                case 3: zigbeeSETCControlObject.joinTimeout = 60; break;
                case 4:
                    {
                        zigbeeSETCControlObject.activeDevices.numActiveDev = 1;
                        zigbeeSETCControlObject.activeDevices.activeDevices_p = new ACTIVE_DEVICE_CS[zigbeeSETCControlObject.activeDevices.numActiveDev];
                        for (ij = 0; ij < zigbeeSETCControlObject.activeDevices.numActiveDev; ij++)
                        {
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].macAddress = new byte[8];
                            for (uint jk = 0; jk < 8; jk++)
                            {
                                zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].macAddress[jk] = (byte)'3';
                            }
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].status = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].maxRSSI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].averageRSSI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].minRSSI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].maxLQI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].averageLQI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].minLQI = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].lastCommunicationDateTime = new DATETIME_VARVAL(new DATETIME(1, 1, 3, 2007, 0, 10, 10, 10, 0, 0));
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].numberOfHope = 3;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].transmissionFailures = 2;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].transmissionSucces = 1; ;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].applicationVersion = 1;
                            zigbeeSETCControlObject.activeDevices.activeDevices_p[ij].stackVersion = 1;
                        }
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool Fill_setdata(ref DLMS_UNION_CS dlSetData, _OBJ obj)
        {

            bool ret = false;
            switch (obj.classId)
            {
                case 1: ret = setSampleDataIC(ref dlSetData.data, obj); break;//data
                case 3: ret = setSampleRegisterIC(ref dlSetData.register, obj); break;//register
                case 4: ret = setSampleExtRegisterIC(ref dlSetData.extRegister, obj); break;//Extended register
                case 5: ret = setSampleDMDRegisterIC(ref dlSetData.dmdRegister, obj); break;//Demand register                   
                case 7: ret = setSampleProfileIC(ref dlSetData.profile, obj); break;//profile generic                    
                case 8: ret = setSampleClockIC(ref dlSetData.clock, obj); break;//clock                    
                case 9: ret = setSampleScriptIC(ref dlSetData.scriptTable, obj); break; //script tables
                case 11: ret = setSampleSpecDayIC(ref dlSetData.specDaysTable, obj); break;// special Days Table                  
                case 15: ret = setSampleAssLnIC(ref dlSetData.assocLN, obj); break;//Long name assosiation
                case 18: ret = setSampleImageTransfer(ref dlSetData.imageTransfer, obj); break;
                case 19: ret = setSampleIECLocalIC(ref dlSetData.IECLocal, obj); break;// //IEC LOCAL PORT SETUP - interface class 19	
                case 20: ret = setSampleActCalIC(ref dlSetData.actCal, obj); break;//ACTIVITY CALENDAR - interface class 20
                case 21: ret = setSampleRegMonIC(ref dlSetData.regMonitor, obj); break;//Register Monitor - interface class 21
                case 22: ret = setSampleSingleActionSchedule(ref dlSetData.SingleActionSchedule, obj); break;//SINGLE ACTION SCHEDULE - interface class 22	
                case 23: ret = setSampleHdlcSetupIC(ref dlSetData.hdlcSetup, obj); break;//IEC HDLC SETUP - interface class 23	
                case 26: ret = setSampleUtilityTableIC(ref dlSetData.utilityTable, obj); break;//Utility table
                case 27: ret = setSamplePSTNmcIC(ref dlSetData.PSTNmc, obj); break;//PSTN configuration.
                case 28: ret = setSamplePSTNAutoAnsIC(ref dlSetData.PSTNAutoAnswer, obj); break;//PSTN Autoanswer.
                case 29: ret = setSampleAutoConnectIC(ref dlSetData.autoConnect, obj); break;//AUTOCONNECT interface class 29
                case 40: ret = setSamplePushSetupIC(ref dlSetData.pushSetup, obj); break;//PUSH setup
                case 41: ret = setSampleTcpUdpSetupIC(ref dlSetData.tcpUdpSetup, obj); break;//TCP-UDP SETUP - interface class 41	
                case 42: ret = setSampleIpv4SetupIC(ref dlSetData.ipv4, obj); break;// IPv4 SETUP - interface class 42	 
                case 43: ret = setSampleEthSetupIC(ref dlSetData.ethernetSetup, obj); break;//ETHERNET SETUP - interface class 43	
                case 45: ret = setSampleGPRSSetupIC(ref dlSetData.GPRSModemSetup, obj); break;//GPRS MODEM SETUP - interface class 45
                case 46: ret = setSampleSMTPSetupIC(ref dlSetData.SMTPSetup, obj); break; //SMTP SETUP - interface class 46	
                case 47: ret = setSampleGsmDiagIC(ref dlSetData.gsmDiag, obj); break; //GSM DIAG - interface class 47
                case 55: ret = setSampleLLC432SetupIC(ref dlSetData.LLC432Setup, obj); break; //4-32 LLC SETUP - interface class 55	
                case 57: ret = setSampleLLC80222T1SetupIC(ref dlSetData.LLC80222T1Setup, obj); break; //	IEC 8022-2 Type 1 LLC SETUP
                case 58: ret = setSampleLLC80222T2SetupIC(ref dlSetData.LLC80222T2Setup, obj); break; //	IEC 8022-2 Type 2 LLC SETUP
                case 59: ret = setSampleLLC80222T3SetupIC(ref dlSetData.LLC80222T3Setup, obj); break; //	IEC 8022-2 Type 3 LLC SETUP
                case 62: ret = setSamplecompactDataIC(ref dlSetData.compactData, obj); break; //Compact Data //For IC62 Attr3 version 1 only "NONE" RestrictType is supported
                case 64: ret = setSampleSecuritySetupIC(ref dlSetData.securitySetup, obj); break; //	Security SETUP
                case 65: ret = setSampleParamMonitorIC(ref dlSetData.paramMonitor, obj); break;
                case 70: ret = setSampleDiscControlIC(ref dlSetData.discControl, obj); break;   // Disconnect control
                case 72: ret = setSampleMBusClientIC(ref dlSetData.mbusClient, obj); break;  // M_Bus Client
                case 80: ret = setSampleCl432SetupIC(ref dlSetData.cl432Setup, obj); break;   // CL_432 setup 
                case 81: ret = setSampleprimePLCPhyCounterIC(ref dlSetData.primePLCPhyCounter, obj); break;   // Phy counter 
                case 82: ret = setSampleprimePLCMACSetupIC(ref dlSetData.primePLCMACSetup, obj); break;   // MAC setup 
                case 83: ret = setSampleprimePLCMACFuncParamsIC(ref dlSetData.primePLCMACFuncParams, obj); break;   // MAC Functional Atributes
                case 84: ret = setSampleprimePLCMACCounterIC(ref dlSetData.primePLCMACCounter, obj); break;   // MAC counter
                case 85: ret = setSampleprimeNtwAdminIC(ref dlSetData.primePLCMACNwkAdminData, obj); break;   // PLC MAC network Adminsitration Data
                case 86: ret = setSampleprimePLCApplIdentIC(ref dlSetData.primePLCApplIdent, obj); break;   // PRIME NB OFDM PLC Applications identification
                case 90: ret = setSampleG3PLCMacCounterIC(ref dlSetData.g3PLCMacCounter, obj); break;   // G3-PLC MAC layer counters
                case 91: ret = setSampleG3PLCMacSetupIC(ref dlSetData.g3PLCMacSetup, obj); break;   // G3-PLC MAC setup
                case 92: ret = setSampleG3PLCAdaptSetupIC(ref dlSetData.g3PLCAdaptSetup, obj); break;   // G3-PLC 6LoWPAN adaptation layer setup
                case 95: ret = setSampleWiSunSetupIC(ref dlSetData.wiSunSetup, obj); break;
                case 96: ret = setSampleWisunDiagnostic(ref dlSetData.WisunDiagnostic, obj); break; // Wisun Diagnostic
                case 97: ret = setSampleWiSunRplDiagnosticIC(ref dlSetData.wiSunRplDiag, obj); break;
                case 98: ret = setSampleMplDiagnostic(ref dlSetData.mplDiagnostic, obj); break; //MPL Diagnostic


                case 111: ret = setSampleAccountIC(ref dlSetData.accountObject, obj); break;   // Account object
                case 112: ret = setSampleCreditIC(ref dlSetData.creditObject, obj); break;   // Credit object
                case 113: ret = setSampleChargeIC(ref dlSetData.chargeObject, obj); break;   // Charge object
                case 115: ret = setSampleTokenIC(ref dlSetData.tokenObject, obj); break;   // Token object
                case 116: ret = setSampleIEC62055(ref dlSetData.iec62055, obj); break; // IEC62055
                case 122: ret = setSampleFunctionControlIC(ref dlSetData.funcControlObject, obj); break; //Function Control
                case 124: ret = setSampleCommPortProtecIC(ref dlSetData.commPortProtecObj, obj); break; //Comm Port Protection 
                case 126: ret = setSampleLPWANSetupIC(ref dlSetData.lpwanSetupObject, obj); break; //LPWAN Setup
                case 127: ret = setSampleLPWANDiagIC(ref dlSetData.lpwanDiagObject, obj); break;//LPWAN Diag
                case 128: ret = setSampleLoRaWANSetupIC(ref dlSetData.loRaWanSetupObject, obj); break; //LoRaWAN Setup
                case 129: ret = setSampleLoRawWANDiagIC(ref dlSetData.loRaWANDiagObject, obj); break; //LoRaWAN Diag
                //case 9000: ret = setSampleExtendedDataIC(ref dlSetData.extendedData, obj); break; // Extended data                
                //case 9100: ret = setSampleCoTsObjectIC(ref dlSetData.coTsObject, obj); break; // CoTs object
                //case 9500: ret = setSampleblkTarifConfIC(ref dlSetData.blockTariffConfgtnObject, obj); break; // blockTariffConfgtnObject
                case 9901: //zigbee SAS StartupObject
                case 101:
                    {
                        ret = setSampleZigbeeSASIC(ref dlSetData.zigbeeSASStartupObject, obj);
                    }
                    break;
                case 9902: //zigbee SAS JoinObject
                case 102:
                    {
                        ret = setSampleZigbeeSASJoinIC(ref dlSetData.zigbeeSASJoinObject, obj);
                    }
                    break;
                case 9903: //zigbee SAS FragmentationObject
                case 103:
                    {
                        ret = setSampleZigbeeSASfragIC(ref dlSetData.zigbeeSASFragmentationObject, obj);
                    }
                    break;
                case 9904: //zigbee Set control
                case 104:
                    {
                        ret = setSamplezigbeeSETControlIC(ref dlSetData.zigbeeSETCControlObject, obj);
                    }
                    break;
                case 9001: // Zigbee Tunnel Setup
                case 105:
                    {
                        ret = setSampleZigbeeTunnelSetupIC(ref dlSetData.zigbeeTunnelSetup, obj);
                    }
                    break;
                case 151: ret = setSampleLTEMonitoringIC(ref dlSetData.LteMonitoringObj, obj); break;
                default: ret = false; break;
            }
            return ret;
        }

        private static bool setSampleFunctionControlIC(ref FUNC_CONTROL_OBJ_CS funcControlObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    funcControlObject.numActivationStatus = 100;
                    funcControlObject.activationStatus = new FUNC_STATUS_TYPE_CS[funcControlObject.numActivationStatus];
                    for (int i = 0; i < funcControlObject.numActivationStatus; i++)
                    {
                        funcControlObject.activationStatus[i].funcName = Encoding.ASCII.GetBytes("FunctionDummyName" + (i + 1));
                        funcControlObject.activationStatus[i].funcNameLen = (byte)funcControlObject.activationStatus[i].funcName.Length;
                        funcControlObject.activationStatus[i].funcStatus = 1;
                    }
                    break;
                case 3:
                    funcControlObject.numFuncList = 100;
                    funcControlObject.funcList = new FUNC_BLOCK_CS[funcControlObject.numFuncList];
                    for (int i = 0; i < funcControlObject.numFuncList; i++)
                    {
                        funcControlObject.funcList[i].funcName = Encoding.ASCII.GetBytes("FunctionDummyName" + (i + 1));
                        funcControlObject.funcList[i].funcNameLen = (byte)funcControlObject.funcList[i].funcName.Length;
                        funcControlObject.funcList[i].numFuncDefs = 1;
                        funcControlObject.funcList[i].funcDefs = new FUNC_DEFINITION[funcControlObject.funcList[i].numFuncDefs];
                        for (int j = 0; j < funcControlObject.funcList[i].numFuncDefs; j++)
                        {
                            funcControlObject.funcList[i].funcDefs[j].class_id = 1;
                            funcControlObject.funcList[i].funcDefs[j].logicalName = new OBISCODE(0, 0, 94, 91, 1, 255);
                        }
                    }
                    break;
                default:
                    ret = false; break;
            }
            return ret;
        }
        private static bool setSampleMBusClientIC(ref MBUS_CLIENT_CS mBUS_CLIENT_CS, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    mBUS_CLIENT_CS.mbusPortRef = new OBISCODE(1, 1, 24, 6, 0, 255);
                    break;
                case 3:
                    mBUS_CLIENT_CS.numCaptureDefs = 1;
                    mBUS_CLIENT_CS.captureDefs_p = new MBUS_CAPTURE_DEF_CS[mBUS_CLIENT_CS.numCaptureDefs];
                    for (int i = 0; i < mBUS_CLIENT_CS.numCaptureDefs; i++)
                    {
                        mBUS_CLIENT_CS.captureDefs_p[i].Dib = new byte[11] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                        mBUS_CLIENT_CS.captureDefs_p[i].Vib = new byte[11] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    }
                    break;
                case 4:
                    mBUS_CLIENT_CS.capturePeriod = 10;
                    break;
                case 5:
                    mBUS_CLIENT_CS.primaryAddress = 100;
                    break;
                case 6:
                    mBUS_CLIENT_CS.idNumber = 1;
                    break;
                case 7:
                    mBUS_CLIENT_CS.manufacturerId = 101;
                    break;
                case 8:
                    mBUS_CLIENT_CS.version = 1;
                    break;
                case 9:
                    mBUS_CLIENT_CS.deviceType = 1;
                    break;
                case 10:
                    mBUS_CLIENT_CS.accessNum = 1;
                    break;
                case 11:
                    mBUS_CLIENT_CS.status = 1;
                    break;
                case 12:
                    mBUS_CLIENT_CS.alarm = 1;
                    break;
                case 13:
                    mBUS_CLIENT_CS.configuration = 1;
                    break;
                case 14:
                    mBUS_CLIENT_CS.encryp_key_status = ENCRYP_KEY_STATUS_ENUM.NO_ENCRYPTION_KEY;
                    break;
            }
            return ret;
        }

        private static bool setSampleLoRawWANDiagIC(ref LORAWAN_DIAG loRaWANDiagObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    loRaWANDiagObject.internalErrCode = ERROR_CODE.ERROR_0;
                    break;
                case 3:
                    loRaWANDiagObject.outFramesUCount = 10;
                    break;
                case 4:
                    loRaWANDiagObject.outFramesCCount = 11;
                    break;
                case 5:
                    loRaWANDiagObject.inFramesUCount = 12;
                    break;
                case 6:
                    loRaWANDiagObject.inFramesCCount = 13;
                    break;
                case 7:
                    loRaWANDiagObject.inMacCommandCount = 14;
                    break;
                case 8:
                    loRaWANDiagObject.inMacAnsErrCount = 15;
                    break;
                case 9:
                    loRaWANDiagObject.inMacIgnoredCount = 16;
                    break;
                case 10:
                    loRaWANDiagObject.inPer = 22;
                    break;
                case 11:
                    loRaWANDiagObject.inMeanRssiRx1 = 17;
                    break;
                case 12:
                    loRaWANDiagObject.inMeanSnrRx1 = 18;
                    break;
                case 13:
                    loRaWANDiagObject.inMeanRssiRx2 = 19;
                    break;
                case 14:
                    loRaWANDiagObject.inMeanSnrRx2 = 20;
                    break;

            }
            return ret;
        }

        private static bool setSampleLoRaWANSetupIC(ref LORAWAN_SETUP_CS loRaWanSetupObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    loRaWanSetupObject.deviceClass = DEVICE_CLASS.CLASS_A;
                    break;
                case 3:
                    loRaWanSetupObject.state = STATE.NOT_CONNECTED;
                    break;
                case 4:
                    loRaWanSetupObject.maxTransmitEIRPSetting = 10;
                    break;
                case 5:
                    loRaWanSetupObject.aDRMode = 0;
                    break;
                case 6:
                    loRaWanSetupObject.regionalParams = REGIONAL_PARAMS.IN865;
                    break;
                case 7:
                    loRaWanSetupObject.deviceOp = new DEVICE_OPERATION();
                    loRaWanSetupObject.deviceOp.totalJoinRequestCounter = 10;
                    loRaWanSetupObject.deviceOp.timeSinceLastJoinRequest = 10;
                    loRaWanSetupObject.deviceOp.timeSinceLastJoinAccept = 10;
                    break;
                case 8:
                    loRaWanSetupObject.modemVersions = new MODEM_VERSIONS_CS();
                    loRaWanSetupObject.modemVersions.hwVerLen = 4;
                    loRaWanSetupObject.modemVersions.hwVerType = 9;//octet string;
                    loRaWanSetupObject.modemVersions.hwVer_p = new byte[] { 1, 1, 1, 1 };
                    loRaWanSetupObject.modemVersions.swVerLen = 4;
                    loRaWanSetupObject.modemVersions.swVerType = 9;//octet string;
                    loRaWanSetupObject.modemVersions.swVer_p = new byte[] { 2, 2, 2, 2 };
                    loRaWanSetupObject.modemVersions.regParamVerLen = 4;
                    loRaWanSetupObject.modemVersions.regParamVerType = 9;//octet string;
                    loRaWanSetupObject.modemVersions.regParamVer_p = new byte[] { 3, 3, 3, 3 };
                    loRaWanSetupObject.modemVersions.protVerLen = 4;
                    loRaWanSetupObject.modemVersions.protVerType = 9;//octet string;
                    loRaWanSetupObject.modemVersions.protVer_p = new byte[] { 4, 4, 4, 4 };
                    break;
                case 9:
                    loRaWanSetupObject.devAddr = 101;
                    break;
                case 10:
                    loRaWanSetupObject.joinStrategy = JOIN_STRATEGY.STRATEGY_0;
                    break;
                case 11:
                    loRaWanSetupObject.numMulticastParams = 1;
                    loRaWanSetupObject.multicastParams = new MULTICASTS_PARAMS_CS[loRaWanSetupObject.numMulticastParams];
                    for (int i = 0; i < loRaWanSetupObject.numMulticastParams; i++)
                    {
                        loRaWanSetupObject.multicastParams[i].mcAddr = 100;
                        loRaWanSetupObject.multicastParams[i].mcKey = new byte[16];
                        for (int j = 0; j < 16; j++)
                        {
                            loRaWanSetupObject.multicastParams[i].mcKey[j] = (byte)(j + 1);
                        }
                        loRaWanSetupObject.multicastParams[i].mcMinFcount = 11;
                        loRaWanSetupObject.multicastParams[i].mcMaxFcount = 101;
                        loRaWanSetupObject.multicastParams[i].mcStartTime = new DATETIME_VARVAL();
                        loRaWanSetupObject.multicastParams[i].mcStartTime.dt_valLength = 12;//SIZE_OF_DT_DATETIME
                        loRaWanSetupObject.multicastParams[i].mcStartTime.dt_valType = 25; //DT_DATETIME
                        loRaWanSetupObject.multicastParams[i].mcStartTime.dt_valuePtr = new byte[12];
                        for (int j = 0; j < 12; j++)
                        {
                            loRaWanSetupObject.multicastParams[i].mcStartTime.dt_valuePtr[j] = (byte)(j + 1);
                        }
                        loRaWanSetupObject.multicastParams[i].mcDuration = 10;
                        loRaWanSetupObject.multicastParams[i].mcClass = MC_CLASS.MC_CLASS_B;
                        loRaWanSetupObject.multicastParams[i].mcDownlinkDataRate = 100;
                        loRaWanSetupObject.multicastParams[i].mcDownlinkFreq = 101;
                    }
                    break;
                default:
                    ret = false; break;
            }
            return ret;
        }

        private static bool setSampleLPWANDiagIC(ref LPWAN_DIAG lpwanDiagObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        lpwanDiagObject.packetsTxCounter = 100;
                        break;
                    }
                case 3:
                    {
                        lpwanDiagObject.packetsRxCounter = 100;
                        break;
                    }
                case 4:
                    {
                        lpwanDiagObject.fragmentsTxCounter = 100;
                        break;
                    }
                case 5:
                    {
                        lpwanDiagObject.fragmentsRxCounter = 100;
                        break;
                    }
                case 6:
                    {
                        lpwanDiagObject.ackTxCounter = 100;
                        break;
                    }
                case 7:
                    {
                        lpwanDiagObject.ackRxCounter = 100;
                        break;
                    }
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

        private static bool setSampleLPWANSetupIC(ref LPWAN_SETUP_CS lpwanSetupObject, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        lpwanSetupObject.lpwanReference = new OBISCODE(0, 0, 96, 3, 10, 255);
                    }
                    break;
                case 3:
                    {
                        lpwanSetupObject.numSchcCdRules = 100;
                        lpwanSetupObject.schcCdRules = new SCHC_CD_RULE_CS[lpwanSetupObject.numSchcCdRules];
                        for (int i = 0; i < lpwanSetupObject.numSchcCdRules; i++)
                        {
                            lpwanSetupObject.schcCdRules[i].ruleId = 100;
                            lpwanSetupObject.schcCdRules[i].numfieldDescriptors = 1;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors = new FIELD_DESCRIPTOR_CS[1];
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].fieldId = FIELD_ID.IPV6_DIFF_SERV;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].fieldLength = 1;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].fieldPosition = 1;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].dirIndicator = DIRECTION_INDICATOR_TYPE.UPLINK;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].targetValue = new VARVALUE_CS();
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].targetValue.valLength = 1;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].targetValue.valType = 3; //bool
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].targetValue.value_p = new byte[1] { 1 };
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].matchingOperator = MATCHING_OP_TYPE.EQUAL_MATCH;
                            lpwanSetupObject.schcCdRules[i].fieldDescriptors[0].compressDecompressActn = COMPRESS_DECOMPRESS_ACTN_TYPE.APPIID;
                        }
                    }
                    break;
                case 4:
                    {
                        lpwanSetupObject.schcFrParam = new SCHC_FR_PARAM_CS();
                        lpwanSetupObject.schcFrParam.maxPacketSize = 255;
                        lpwanSetupObject.schcFrParam.ruleIdScheme = RULE_ID_SCHEME.FIXED_SIZE;
                        lpwanSetupObject.schcFrParam.paddingL2WordSize = 1;
                        lpwanSetupObject.schcFrParam.paddingBitsVal = 1;
                        lpwanSetupObject.schcFrParam.delayAfterTrans = 15;
                        lpwanSetupObject.schcFrParam.interleavedPacketTran = 0;
                        lpwanSetupObject.schcFrParam.windowSize = 128;
                        lpwanSetupObject.schcFrParam.numRuleParams = 1;
                        lpwanSetupObject.schcFrParam.ruleParams = new RULE_PARAM[lpwanSetupObject.schcFrParam.numRuleParams];
                        for (int i = 0; i < lpwanSetupObject.schcFrParam.numRuleParams; i++)
                        {
                            lpwanSetupObject.schcFrParam.ruleParams[i].ruleId = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].ruleIdLen = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].dtagLen = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].wLen = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].fcnLen = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].rcsAlg = RCS_ALG.NONE;
                            lpwanSetupObject.schcFrParam.ruleParams[i].reliabilityMode = RELIABILITY_MODE.NO_ACK;
                            lpwanSetupObject.schcFrParam.ruleParams[i].retransmissionTimer = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].inactivityTimer = 1;
                            lpwanSetupObject.schcFrParam.ruleParams[i].maxAckReq = 1;
                        }
                    }
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

        private static bool setSampleCommPortProtecIC(ref COMM_PORT_PROTECTION commPortProtecObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    commPortProtecObj.protecMode = PROTECTION_MODE.UNLOCKED;
                    break;
                case 3:
                    commPortProtecObj.allowedFailedAttempts = 5;
                    break;
                case 4:
                    commPortProtecObj.initialLockoutTime = 15;
                    break;
                case 5:
                    commPortProtecObj.steepnessFactor = 2;
                    break;
                case 6:
                    commPortProtecObj.maxLockoutTime = 120;
                    break;
                case 7:
                    commPortProtecObj.portReference = new OBISCODE(0, 0, 96, 3, 10, 255);
                    break;
                case 8:
                    commPortProtecObj.protecStatus = PROTECTION_STATUS.UNLOCKED;
                    break;
                case 9:
                    commPortProtecObj.failedAttempts = 0;
                    break;
                case 10:
                    commPortProtecObj.cumulativeFailedAttempts = 0;
                    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }
        private static bool setSampleParamMonitorIC(ref PARAMETER_MONITOR_CS paramMonitor, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 2:
                    {
                        paramMonitor.parameter = new CHANGED_PARAM_CS();
                        paramMonitor.parameter.obis = new OBISCODE(1, 1, 1, 1, 1, 1); ;
                        paramMonitor.parameter.attrIndex = 1;
                        paramMonitor.parameter.classId = 1;
                        paramMonitor.parameter.attrValue = new VARVALUE_CS();
                        paramMonitor.parameter.attrValue.valLength = 1;
                        paramMonitor.parameter.attrValue.valType = 5;//boolean
                        paramMonitor.parameter.attrValue.value_p = new byte[1] { 1 };
                    }
                    break;
                case 4:
                    {
                        paramMonitor.paramListArray = new PARAM_LIST_CS[1];
                        paramMonitor.paramListArray[0].attrIndex = 1;
                        paramMonitor.paramListArray[0].classId = 1;
                        paramMonitor.paramListArray[0].obis = new OBISCODE(1, 1, 1, 1, 1, 1);
                    }
                    break;
                case 5:
                    {
                        paramMonitor.paramListName = Encoding.ASCII.GetBytes("ParameterListNameSample");
                        paramMonitor.paramListNameLen = (byte)paramMonitor.paramListName.Length;
                    }
                    break;
                case 6:
                    {
                        paramMonitor.HASH_ALG_ID = HASH_ALG_ID.SHA_256;
                    }
                    break;
                //case 7:
                //    {
                //        paramMonitor.paramValueDigest = Encoding.ASCII.GetBytes("ParameterDigestSample");
                //        paramMonitor.paramValueDigestLen = (byte)paramMonitor.paramValueDigest.Length;
                //    }
                //    break;
                //case 8:
                //    {
                //        paramMonitor.paramValues = new VARVALUE_CS[1];
                //        paramMonitor.paramValues[0].valType = 15;
                //        paramMonitor.paramValues[0].value_p = new byte[1];
                //        paramMonitor.paramValues[0].value_p[0] = 1;
                //        paramMonitor.paramValues[0].valLength = 1;
                //    }
                //    break;
                default:
                    ret = false;
                    break;
            }
            return ret;
        }

        public static bool Fill_setdataList(DLMS_UNION_CS[] dlSetDataList, uint numDescriptors, COSEM_ATTR_METH_DESC[] CosemMethodDes_obj)
        {
            _OBJ obj = new _OBJ();
            SELACCESSPARAMS_CS selParams = new SELACCESSPARAMS_CS();
            bool rett = true;
            for (int i = 0; i < numDescriptors; i++)
            {
                if (i == 0)
                {
                    obj.obis.a = 0;
                    obj.obis.b = 0;
                    obj.obis.c = 96;
                    obj.obis.d = 2;
                    obj.obis.e = 0;
                    obj.obis.f = 255;
                    obj.classId = 1;
                    obj.attrMethID = 2;
                    obj.version = 0;
                    obj.baseCls = 0;
                }
                else
                {
                    obj.obis.a = 1;
                    obj.obis.b = 0;
                    obj.obis.c = 0;
                    obj.obis.d = 9;
                    obj.obis.e = 1;
                    obj.obis.f = 255;
                    obj.classId = 3;
                    obj.attrMethID = 2;
                    obj.version = 0;
                    obj.baseCls = 0;
                }
                CosemMethodDes_obj[i] = new COSEM_ATTR_METH_DESC(obj.classId, obj.version, obj.attrMethID, selParams, obj.obis, obj.baseCls);
                dlSetDataList[i] = new DLMS_UNION_CS();
                rett = SampleSetData.Fill_setdata(ref dlSetDataList[i], obj);

                if (rett != true)
                    return rett;
            }
            return rett;
        }
    }

}
