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

using System;
using System.Collections.Generic;
using System.Text;
using DLMS_CLIENT;
using DLMS_CLIENT.DLMSStruct;
using ProjectAPI.SchemaModel;

namespace ProjectAPI
{
    class SetSelectiveAccessParams
    {

        public static void fillProfileRangeParams(ref SELACCESSPARAMS_CS select)
        {
            OBISCODE obis = new OBISCODE(0, 0, 1, 0, 0, 255);
            CAPTURE_OBJECT restrictingObj = new CAPTURE_OBJECT(8, obis, 2, 0);
            VARVALUE_CS fromValue = new VARVALUE_CS();
            VARVALUE_CS toValue = new VARVALUE_CS();
            fromValue.valType = (byte)DATA_TYPE.DT_OCTET_STRING;
            fromValue.valLength = 12;
            fromValue.value_p = new byte[12];

            /* from value */
            Console.WriteLine("Enter the from Time : ");
            Console.WriteLine("Enter the year : ");
            int year = Convert.ToInt16(Console.ReadLine());
            fromValue.value_p[0] = (byte)((year >> 8) & 0x00FF);
            fromValue.value_p[1] = (byte)(year & 0x00FF);
            Console.WriteLine("Enter the month (1-12, 1 = Jan) : ");
            byte month = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[2] = (byte)(month);
            Console.WriteLine("Enter the date (1-31) : ");
            byte date = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[3] = (byte)(date);
            Console.WriteLine("Enter the day (1-7, 1 = Monday) : ");
            byte day = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[4] = (byte)(day);
            Console.WriteLine("Enter the hour (0 - 23) : ");
            byte hour = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[5] = (byte)(hour);
            Console.WriteLine("Enter the minute (0 - 59) : ");
            byte minute = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[6] = (byte)(minute);
            Console.WriteLine("Enter the seconds (0 - 59) : ");
            byte seconds = Convert.ToByte(Console.ReadLine());
            fromValue.value_p[7] = (byte)(seconds);
            fromValue.value_p[8] = 0; //hundredths of second
            fromValue.value_p[9] = 0; //deviation high byte
            fromValue.value_p[10] = 0; //deviation low byte
            fromValue.value_p[11] = 0; //clock status

            /* to value */
            Console.WriteLine("Enter the to-time : ");
            toValue.valType = (byte)DATA_TYPE.DT_OCTET_STRING;
            toValue.valLength = 12;
            toValue.value_p = new byte[12];

            Console.WriteLine("Enter the year : ");
            year = Convert.ToInt16(Console.ReadLine());
            toValue.value_p[0] = (byte)((year >> 8) & 0x00FF);
            toValue.value_p[1] = (byte)(year & 0x00FF);
            Console.WriteLine("Enter the month (1-12, 1 = Jan) : ");
            month = Convert.ToByte(Console.ReadLine());
            toValue.value_p[2] = (byte)(month);
            Console.WriteLine("Enter the date (1-31) : ");
            date = Convert.ToByte(Console.ReadLine());
            toValue.value_p[3] = (byte)(date);
            Console.WriteLine("Enter the day (1-7, 1 = Monday) : ");
            day = Convert.ToByte(Console.ReadLine());
            toValue.value_p[4] = (byte)(day);
            Console.WriteLine("Enter the hour (0 - 23) : ");
            hour = Convert.ToByte(Console.ReadLine());
            toValue.value_p[5] = (byte)(hour);
            Console.WriteLine("Enter the minute (0 - 59) : ");
            minute = Convert.ToByte(Console.ReadLine());
            toValue.value_p[6] = (byte)(minute);
            Console.WriteLine("Enter the seconds (0 - 59) : ");
            seconds = Convert.ToByte(Console.ReadLine());
            toValue.value_p[7] = (byte)(seconds);
            toValue.value_p[8] = 0; //hundredths of second
            toValue.value_p[9] = 0; //deviation high byte
            toValue.value_p[10] = 0; //deviation low byte
            toValue.value_p[11] = 0; //clock status

            //SampleSetData.setSampleVarValue(ref fromValue, DATA_TYPE.DT_OCTET_STRING, 12);
            //SampleSetData.setSampleVarValue(ref toValue, DATA_TYPE.DT_OCTET_STRING, 12);
            //Fill the required params and set the values
            select.setIC7RangeParams(restrictingObj, fromValue, toValue, null, 0);
        }

        public static void fillProfileEntryParams(ref SELACCESSPARAMS_CS select)
        {
            uint fromEntry = 1;
            uint toEntry = 2;
            ushort fromValue = 1;
            ushort toValue = 1;
            Console.WriteLine("Enter From Entry: ");
            fromEntry = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter To Entry: ");
            toEntry = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter From Value: ");
            fromValue = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter To Value: ");
            toValue = Convert.ToByte(Console.ReadLine());
            select.setIC7EntryParams(fromEntry, toEntry, fromValue, toValue);
        }

        public static void fillAssocSnSelectbyClass(ref SELACCESSPARAMS_CS select)
        {
            ushort classId = 23;
            select.setIC12ClassID(classId);
        }
        public static void fillAssocSnSelectbyLN(ref SELACCESSPARAMS_CS select)
        {
            ushort classId = 23;
            OBISCODE obis = new OBISCODE(0, 0, 1, 0, 0, 255);
            select.setIC12LogicName(classId, obis);
        }

        public static void fillAssocLnAccessbyClass(ref SELACCESSPARAMS_CS select)
        {
            byte numclass = 2;
            ushort[] classIdList = new ushort[numclass];
            classIdList[0] = 1;
            classIdList[1] = 2;
            select.setIC15AccessbyClassParams(classIdList, numclass);
        }
        public static void fillAssocLnAccessbyobj(ref SELACCESSPARAMS_CS select, byte numObjs)
        {
            OBJECT_ID[] objList = new OBJECT_ID[numObjs];
            for (int i = 0; i < numObjs; i++)
            {
                OBISCODE obis = new OBISCODE(0, 0, (byte)(i + 1), 0, 0, 255);
                objList[i] = new OBJECT_ID((ushort)(i + 1), obis);
            }
            select.setIC15AccessbyObjParams(objList, numObjs);
        }
        public static void fillUtitlityOffset(ref SELACCESSPARAMS_CS select, uint offset, ushort count)
        {
            select.setIC26offsetAccess(offset, count);
        }

        public static bool Fill_SelAcess(ref SELACCESSPARAMS_CS select, _OBJ o, byte AccessSelector)
        {
            bool ret = true;
            //Set the access selector
            select.setAccessSelector(AccessSelector);
            switch (o.classId)
            {
                case 7:
                    {
                        if (o.attrMethID == 2)
                        {
                            switch (AccessSelector)
                            {
                                case 1: fillProfileRangeParams(ref select); break;// set the range params for Profile IC
                                case 2: fillProfileEntryParams(ref select); break;// set the entry params for Profile IC
                                default: ret = false; break;
                            }
                        }
                    }
                    break;
                case 12://Assosciation SN
                    {
                        if (o.attrMethID == 2)
                        {
                            switch (AccessSelector)
                            {
                                case 1: fillAssocSnSelectbyClass(ref select); break;//Select by class id 
                                case 2: fillAssocSnSelectbyLN(ref select); break;//select by Logical name
                                default: ret = false; break;

                            }
                        }

                    }
                    break;
                case 15://Assosciation LN
                    {
                        if (o.attrMethID == 2)
                        {
                            switch (AccessSelector)
                            {
                                case 1: break;
                                case 2: fillAssocLnAccessbyClass(ref select); break;//Access by class id list
                                case 3: fillAssocLnAccessbyobj(ref select, 2); break;//Access by Object id list
                                case 4: fillAssocLnAccessbyobj(ref select, 1); break;//Access by Object id , count to be made as 1
                                default: ret = false; break;

                            }
                        }
                    }
                    break;
                case 26:// Utility table
                    {
                        if (o.attrMethID == 4)
                        {
                            switch (AccessSelector)
                            {
                                case 1: fillUtitlityOffset(ref select, 5, 10); break;// Select using offset and count
                                default: ret = false; break;
                            }
                        }

                    }
                    break;

            }
            return ret;
        }
    }
}
