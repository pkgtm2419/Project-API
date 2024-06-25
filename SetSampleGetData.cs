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

namespace ProjectAPI
{
    class SetSampleGetData

    {

        public static void fillGetListParams(uint numDescriptors, COSEM_ATTR_METH_DESC[] CosemMethodDes_obj)
        {
            int i = 0;
            _OBJ obj = new _OBJ();

            for (i = 0; i < numDescriptors; i++)
            {
                if (i == 0)
                {
                    obj.classId = 1;
                    obj.obis.a = 0;
                    obj.obis.b = 0;
                    obj.obis.c = 0;
                    obj.obis.d = 1;
                    obj.obis.e = 0;
                    obj.obis.f = 255;
                    obj.attrMethID = 1;
                    obj.baseCls = 0;
                    obj.version = 1;
                }
                else
                {
                    obj.classId = 7;
                    obj.obis.a = 0;
                    obj.obis.b = 0;
                    obj.obis.c = 94;
                    obj.obis.d = 91;
                    obj.obis.e = 10;
                    obj.obis.f = 255;
                    obj.attrMethID = 1;
                    obj.baseCls = 0;
                    obj.version = 0;
                }


                byte AccessSelector = 0;
                SELACCESSPARAMS_CS selParams = new SELACCESSPARAMS_CS();
                bool rett = SetSelectiveAccessParams.Fill_SelAcess(ref selParams, obj, AccessSelector);
                CosemMethodDes_obj[i] = new COSEM_ATTR_METH_DESC(obj.classId, obj.version, obj.attrMethID, selParams, obj.obis, obj.baseCls);
            }
        }
    }

}
