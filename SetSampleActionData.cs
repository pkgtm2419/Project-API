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

//#define test
#define IC40_VERSION_0_SUPPORT      //Required Version support should be enabled in all of these(IC40.cs, DLMSClient.cs, SampleSetData.cs & SetSampleActionData.cs) files.
//#define IC40_VERSION_1_SUPPORT
//#define IC40_VERSION_2_SUPPORT
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Collections.Specialized;
using System.IO.Ports;
using DLMS_CLIENT;
using DLMS_CLIENT.DLMSStruct;
using DLMS_SECURITY;
using ProjectAPI.SchemaModel;
using ProjectAPI;
using ProjectAPI._Helpers.Library;

namespace ProjectAPI
{
    class SetSampleActionData
    {
        public static bool setIC05ActionData(ref DMD_REG_ACT dmdRegAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    dmdRegAct.resetData = 1;
                    break;
                case 2:
                    dmdRegAct.nextPeriod = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC09ActionData(ref SCR_TAB_ACTN scriptAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    scriptAct.executeData = 3;
                    break;

                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC07ActionData(ref PROF_ACTN_CS profAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        profAct.resetData = 1; ;
                    }
                    break;
                case 2:
                    {
                        profAct.captureData = 1; ;
                    }
                    break;
                case 253:
                    {
                        RANGE_PARAMS_CS selectveReset;
                        OBISCODE obis = new OBISCODE(0, 0, 96, 2, 0, 255);
                        CAPTURE_OBJECT obj1 = new CAPTURE_OBJECT(1, obis, 2, 0);
                        CAPTURE_OBJECT[] obj2;
                        VARVALUE_CS var1 = new VARVALUE_CS();
                        var1.valType = 15;
                        var1.valLength = 1;
                        var1.value_p = new byte[1];
                        var1.value_p[0] = 1;
                        obj2 = new CAPTURE_OBJECT[1];
                        obj2[0] = new CAPTURE_OBJECT(1, obis, 2, 0);
                        selectveReset = new RANGE_PARAMS_CS(obj1, var1, var1, obj2, 1);
                        profAct.selectvReset_p = selectveReset;
                    }
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setIC15ActionData(ref ASSOC_LN_ACTN_CS assocLNAct, _OBJ obj)
        {
            bool ret = true;
            byte[] sig = new byte[64] {   0xb8,0xc8,0x54,0x17,0x01,0xe4,0xfd,0xd4,0x51,0x2c,
                                            0x60,0x04,0x57,0xce,0x8d,0x3f,0xa3,0xec,0x2c,0x28,
                                            0x46,0x09,0x71,0xab,0xc1,0xbe,0x33,0xef,0x3e,0x35,
                                            0x7f,0xaa,0xd8,0x95,0x97,0x4f,0x53,0x25,0x41,0x9f,
                                            0xd9,0x0c,0xc6,0x30,0xe0,0xc1,0xa4,0xf7,0x47,0x67,
                                            0x18,0x56,0xdf,0x98,0x60,0x57,0x5a,0x86,0x2d,0x9a,
                                            0x26,0x28,0x8d,0x75 }; //signature
            switch (obj.attrMethID)
            {
                case 1://challenge
                    {
                        assocLNAct.replyLength = 64;
                        assocLNAct.repHls_p = new byte[assocLNAct.replyLength];

                        for (int i = 0; i < assocLNAct.replyLength; i++)
                            assocLNAct.repHls_p[i] = sig[i];//signature
                    }
                    break;
                case 2:
                    {
                        assocLNAct.changeHlsLength = 16;
                        assocLNAct.changeHls_p = new byte[assocLNAct.changeHlsLength];
                        for (int i = 0; i < 16; i++)
                            assocLNAct.changeHls_p[i] = (byte)'s';
                    }
                    break;
                case 3:
                    {
                        assocLNAct.addObject.accessRight.numAttr = 30;
                        assocLNAct.addObject.accessRight.attrAccess_p = new ATTR_ACCESS_CS[assocLNAct.addObject.accessRight.numAttr];
                        for (int ij = 0; ij < assocLNAct.addObject.accessRight.numAttr; ij++)
                        {
                            assocLNAct.addObject.accessRight.attrAccess_p[ij].accessMode = 1;
                            assocLNAct.addObject.accessRight.attrAccess_p[ij].attrId = 2;
                        }
                        assocLNAct.addObject.accessRight.numMeth = 1;
                        assocLNAct.addObject.accessRight.methAccess_p = new METH_ACCESS[assocLNAct.addObject.accessRight.numMeth];
                        for (int ij = 0; ij < assocLNAct.addObject.accessRight.numMeth; ij++)
                        {
                            assocLNAct.addObject.accessRight.methAccess_p[ij].methodId = 1;
                        }
                        assocLNAct.addObject.classId = 1;
                        assocLNAct.addObject.version = 1;
                        assocLNAct.addObject.obis = new OBISCODE(0, 42, 0, 0, 6, 34);
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC18ActionData(ref IMG_TX_ACTN_CS imgTxAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        imgTxAct.imageTxinitiateInfo.imageSize = 100;
                        imgTxAct.imageTxinitiateInfo.imgIdentLen = 10;
                        imgTxAct.imageTxinitiateInfo.imgIdent_p = new byte[imgTxAct.imageTxinitiateInfo.imgIdentLen];
                        for (int i = 0; i < imgTxAct.imageTxinitiateInfo.imgIdentLen; i++)
                        {
                            imgTxAct.imageTxinitiateInfo.imgIdent_p[i] = (byte)'0';
                        }
                    }
                    break;
                case 2:
                    {
                        imgTxAct.imageBlockTransfer.imgBlkNumber = 1;
                        imgTxAct.imageBlockTransfer.imgBlkSz = 50;
                        imgTxAct.imageBlockTransfer.imgBlk_p = new byte[imgTxAct.imageBlockTransfer.imgBlkSz];
                        for (int i = 0; i < imgTxAct.imageBlockTransfer.imgBlkSz; i++)
                        {
                            imgTxAct.imageBlockTransfer.imgBlk_p[i] = (byte)i;
                        }
                    }
                    break;
                case 3: imgTxAct.imageVerify = (sbyte)0; break;
                case 4: imgTxAct.imageActivate = (sbyte)0; break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC40ActionData(ref PUSH_ACTN pushAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    pushAct.pushActivate = 1;
                    break;
#if IC40_VERSION_2_SUPPORT
                case 2: Console.WriteLine("\nPush Reset Method: \n");
                    pushAct.reset = 1;
                    break;
#endif
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC42ActionData(ref IPv4_SETUP_ACTN ipv4Act, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                case 2:
                    ipv4Act.multicastIp = 5;

                    break;
            }
            return ret;
        }

        public static bool setIC61ActionData(ref REG_TABLE_ACTN regTableAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1: regTableAct.resetData = 1; break;
                case 2: regTableAct.captureData = 2; break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool Execute_keypairAgreementMethod(ref byte[] buf_p, ref byte[] ephPrivKey, byte keyType, ref byte len, IntPtr dlmsInstance, byte SecuritySuite)
        {
            IntPtr privKey = IntPtr.Zero, inp = IntPtr.Zero, sig = IntPtr.Zero, sigL = IntPtr.Zero, pubKey = IntPtr.Zero, sysTitl = IntPtr.Zero;
            byte[] sigL2 = new byte[1];
            byte[] ephemeralPrivKey; //= new byte[DigitalSignature.SIZE_OF_PRIV_KEY];
            byte keyLen = 0, keyLen2 = 0, sysTitleLen = 8;
            uint lenInp = 0, sigLen = 0;
            byte[] publicKey;//= new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY];
            byte[] input; //= new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY + 1];
            byte[] empty = new byte[1];
            byte[] signature = new byte[100];
            byte[] sysTitle = new byte[8];
            IntPtr noData = IntPtr.Zero;

            if (SecuritySuite == 1)
            {
                ephemeralPrivKey = new byte[DigitalSignature.SIZE_OF_PRIV_KEY];
                publicKey = new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY];
                input = new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY + 1];
                keyLen = DigitalSignature.SIZE_OF_PUBLIC_KEY;
                keyLen2 = DigitalSignature.SIZE_OF_PRIV_KEY;
            }
            else
            {
                ephemeralPrivKey = new byte[DigitalSignature.SIZE_OF_PRIV_KEY_SUITE2];
                publicKey = new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY_SUITE2];
                input = new byte[DigitalSignature.SIZE_OF_PUBLIC_KEY_SUITE2 + 1];
                keyLen = DigitalSignature.SIZE_OF_PUBLIC_KEY_SUITE2;
                keyLen2 = DigitalSignature.SIZE_OF_PRIV_KEY_SUITE2;
            }
            //The function gets a key pair and 
            pubKey = Marshal.AllocHGlobal(keyLen);
            privKey = Marshal.AllocHGlobal(keyLen2);
            sysTitl = Marshal.AllocHGlobal(sysTitleLen);
            DigitalSignature.getSignatureKeys(noData, noData, pubKey, 0, 0, keyLen, noData, 2, 0, 0, SecuritySuite, sysTitl);
            DigitalSignature.getSignatureKeys(noData, privKey, noData, 0, keyLen2, 0, noData, 1, 0, 0, SecuritySuite, sysTitl);

            if (privKey != IntPtr.Zero)
            {
                if (SecuritySuite == 1)
                    Marshal.Copy(privKey, ephemeralPrivKey, 0, DigitalSignature.SIZE_OF_PRIV_KEY);
                else
                    Marshal.Copy(privKey, ephemeralPrivKey, 0, DigitalSignature.SIZE_OF_PRIV_KEY_SUITE2);

            }
            if (SecuritySuite == 1)
            {
                for (int i = 0; i < DigitalSignature.SIZE_OF_PRIV_KEY; i++)
                    ephPrivKey[i] = ephemeralPrivKey[i];
            }
            else
            {
                for (int i = 0; i < DigitalSignature.SIZE_OF_PRIV_KEY_SUITE2; i++)
                    ephPrivKey[i] = ephemeralPrivKey[i];
            }
            if (pubKey != IntPtr.Zero)
            {
                Marshal.Copy(pubKey, publicKey, 0, keyLen);
            }
            input[0] = keyType;
            if (SecuritySuite == 1)
            {
                for (int i = 0; i < DigitalSignature.SIZE_OF_PUBLIC_KEY; i++)
                    buf_p[i] = publicKey[i];
                for (int i = 0; i < DigitalSignature.SIZE_OF_PUBLIC_KEY; i++)
                    input[1 + i] = buf_p[i];

                Console.Write("\nEphemeralKey\n");
                for (int i = 0; i < 64; i++)
                {
                    Console.Write("{0:D} ", publicKey[i]);
                }
                lenInp = 65;
            }
            else
            {
                for (int i = 0; i < DigitalSignature.SIZE_OF_PUBLIC_KEY_SUITE2; i++)
                    buf_p[i] = publicKey[i];
                for (int i = 0; i < DigitalSignature.SIZE_OF_PUBLIC_KEY_SUITE2; i++)
                    input[1 + i] = buf_p[i];

                Console.Write("\nEphemeralKey\n");
                for (int i = 0; i < 96; i++)
                {
                    Console.Write("{0:D} ", publicKey[i]);
                }
                lenInp = 96 + 1;
            }

            //generateSignDigest (0,input,65,output);

            inp = IntPtr.Zero;
            if (input.GetLength(0) > 0 && input.Length >= input.GetLength(0))
            {
                inp = Marshal.AllocHGlobal((int)input.GetLength(0));
                Marshal.Copy(input, 0, inp, (int)input.GetLength(0));
            }
            sigL2[0] = (byte)sigLen;
            sigL = IntPtr.Zero;
            if (sigL2.GetLength(0) > 0)
            {
                sigL = Marshal.AllocHGlobal((int)sigL2.GetLength(0));
                Marshal.Copy(sigL2, 0, sigL, (int)sigL2.GetLength(0));
            }
            sig = IntPtr.Zero;
            if (signature.GetLength(0) > 0)
            {
                sig = Marshal.AllocHGlobal(100);
                Marshal.Copy(signature, 0, sig, 100);
            }

            DLMSSecurity.computeSigGen(privKey, inp, lenInp, 0, sig, sigL, 0, SecuritySuite);
            if (sigL != IntPtr.Zero)
                Marshal.Copy(sigL, sigL2, 0, 1);
            sigLen = sigL2[0];
            if (sigLen > 0 && sig != IntPtr.Zero)
            {
                Marshal.Copy(sig, signature, 0, (int)sigLen);
            }
            if (SecuritySuite == 1)
            {
                for (int i = 0; i < sigLen; i++)
                    buf_p[64 + i] = signature[i];
                len = (byte)(sigLen + 64);
            }
            else
            {
                for (int i = 0; i < sigLen; i++)
                    buf_p[96 + i] = signature[i];
                len = (byte)(sigLen + 96);
            }

            return true;
        }

        public static bool setIC64ActionData(ref SECURITY_CONTROL_ACTN_CS secControlAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    secControlAct.securityActivate = 1;
                    break;
                case 2:
                    {
                        //string encKey = "0123456789ABCDEF";
                        //string masterKey = "0000111122223333";
                        byte[] wrappedKey = new byte[24];
                        byte[] key = new byte[24]{0xC2, 0x07, 0x95, 0xC9, 0x6F, 0xD7, 0xFD, 0xBD, 0x4E, 0xE2, 0xE2, 0x00, 0x79,
                            0xF8, 0x2C, 0xA4, 0xB2, 0x45, 0xD0, 0x63, 0x16, 0xEE, 0x40, 0x3E}; //sample wrapped key

                        secControlAct.globalKeyTransfer.noOfKeys = 1;
                        secControlAct.globalKeyTransfer.globalKeyTransfer_p = new GLO_KEY_TX_INFO_CS[secControlAct.globalKeyTransfer.noOfKeys];
                        for (int j = 0; j < secControlAct.globalKeyTransfer.noOfKeys; j++)
                        {
                            secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].keyId = 0;
                            secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].wrappedKeyLen = 24;
                            secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].WrappedKey_p =
                                new byte[secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].wrappedKeyLen];
                            for (int i = 0; i < secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].wrappedKeyLen; i++)
                                secControlAct.globalKeyTransfer.globalKeyTransfer_p[j].WrappedKey_p[i] = key[i];
                        }
                        //User can use the following to wrap the key. Tthe User needs to implement the call back for wrapping the key
                        //secControlAct.globalKeyTransfer_p[0].globalKeyTransfer.WrappedKey_p = DLMSClient.aesWrap(Encoding.ASCII.GetBytes(masterKey), Encoding.ASCII.GetBytes(encKey), wrappedKey);
                        break;
                    }
                case 3:
                    {
                        IntPtr empty = IntPtr.Zero;
                        secControlAct.keyAgreementData.noOfKeyAgreements = 1;
                        secControlAct.keyAgreementData.keyAgreements_p = new KEY_AGREEMENT_CS[secControlAct.keyAgreementData.noOfKeyAgreements];
                        for (int i = 0; i < secControlAct.keyAgreementData.noOfKeyAgreements; i++)
                        {
                            secControlAct.keyAgreementData.keyAgreements_p[i].keyId = 1;
                            secControlAct.keyAgreementData.keyAgreements_p[i].secSuite = 1;
                            if (secControlAct.keyAgreementData.keyAgreements_p[i].secSuite == 1)
                            {
                                secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen = 128;
                                secControlAct.keyAgreementData.keyAgreements_p[i].KeyData_p =
                                    new byte[secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen];

                                secControlAct.keyAgreementData.ephPrivKey = new byte[DigitalSignature.SIZE_OF_PRIV_KEY]; //size of private key
                                Execute_keypairAgreementMethod(ref secControlAct.keyAgreementData.keyAgreements_p[i].KeyData_p,
                                        ref secControlAct.keyAgreementData.ephPrivKey,
                                        secControlAct.keyAgreementData.keyAgreements_p[i].keyId,
                                        ref secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen,
                                        empty,
                                        secControlAct.keyAgreementData.keyAgreements_p[i].secSuite);
                            }
                            else //suite 2
                            {
                                secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen = 96 + 96;
                                secControlAct.keyAgreementData.keyAgreements_p[i].KeyData_p =
                                    new byte[secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen];

                                secControlAct.keyAgreementData.ephPrivKey = new byte[DigitalSignature.SIZE_OF_PRIV_KEY_SUITE2]; //size of private key
                                Execute_keypairAgreementMethod(ref secControlAct.keyAgreementData.keyAgreements_p[i].KeyData_p,
                                        ref secControlAct.keyAgreementData.ephPrivKey,
                                        secControlAct.keyAgreementData.keyAgreements_p[i].keyId,
                                        ref secControlAct.keyAgreementData.keyAgreements_p[i].KeyDataLen,
                                        empty,
                                        secControlAct.keyAgreementData.keyAgreements_p[i].secSuite);

                            }
                        }
                        break;
                    }
                case 4:
                    {
                        secControlAct.genKeyPair = 1;
                        break;
                    }
                case 5:
                    {
                        secControlAct.generateCertReq.genCertReq = 1;
                        break;
                    }
                case 6:
                    {
                        byte[] cert = new byte[379]{0x30, 0x82, 0x01, 0x77, 0x30, 0x82, 0x01, 0x1c, 0xa0, 0x03,
                        0x02, 0x01, 0x02, 0x02, 0x00, 0x30, 0x0c, 0x06, 0x08, 0x2a,
                        0x86, 0x48, 0xce, 0x3d, 0x04, 0x03, 0x02, 0x05, 0x00, 0x30,
                        0x31, 0x31, 0x0e, 0x30, 0x0c, 0x06, 0x03, 0x55, 0x04, 0x06,
                        0x13, 0x05, 0x49, 0x4e, 0x44, 0x49, 0x41, 0x31, 0x0c, 0x30,
                        0x0a, 0x06, 0x03, 0x55, 0x04, 0x0a, 0x13, 0x03, 0x41, 0x42,
                        0x43, 0x31, 0x11, 0x30, 0x0f, 0x06, 0x03, 0x55, 0x04, 0x03,
                        0x13, 0x08, 0x44, 0x4c, 0x4d, 0x53, 0x20, 0x44, 0x45, 0x50,
                        0x30, 0x1e, 0x17, 0x0d, 0x31, 0x33, 0x31, 0x32, 0x33, 0x31,
                        0x32, 0x33, 0x35, 0x39, 0x35, 0x39, 0x5a, 0x17, 0x0d, 0x31,
                        0x36, 0x31, 0x32, 0x33, 0x31, 0x32, 0x33, 0x35, 0x39, 0x35,
                        0x39, 0x5a, 0x30, 0x34, 0x31, 0x0b, 0x30, 0x09, 0x06, 0x03,
                        0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x0c, 0x30,
                        0x0a, 0x06, 0x03, 0x55, 0x04, 0x0a, 0x13, 0x03, 0x58, 0x59,
                        0x5a, 0x31, 0x17, 0x30, 0x15, 0x06, 0x03, 0x55, 0x04, 0x03,
                        0x13, 0x0e, 0x53, 0x4d, 0x41, 0x52, 0x54, 0x20, 0x4d, 0x45,
                        0x54, 0x45, 0x52, 0x49, 0x4e, 0x47, 0x30, 0x59, 0x30, 0x13,
                        0x06, 0x07, 0x2a, 0x86, 0x48, 0xce, 0x3d, 0x02, 0x01, 0x06,
                        0x08, 0x2a, 0x86, 0x48, 0xce, 0x3d, 0x03, 0x01, 0x07, 0x03,
                        0x42, 0x00, 0x04, 0x8e, 0xde, 0xd7, 0x8c, 0xf2, 0x9c, 0x86,
                        0xb9, 0x23, 0x7a, 0x12, 0x32, 0xf8, 0xa0, 0x40, 0x3c, 0x7b,
                        0xbb, 0x77, 0x51, 0xaf, 0x5b, 0xe9, 0xfe, 0xcc, 0x33, 0x91,
                        0x76, 0xbc, 0x49, 0xd6, 0x95, 0xf0, 0x57, 0xc7, 0x4e, 0x3d,
                        0x0b, 0xfe, 0xdf, 0x78, 0x09, 0x45, 0x60, 0x30, 0xf9, 0x3d,
                        0xde, 0xda, 0xd2, 0x05, 0xba, 0xc9, 0x5e, 0x0b, 0x7a, 0x5f,
                        0x5d, 0xd0, 0xea, 0x84, 0x05, 0x8b, 0xc1, 0xa3, 0x21, 0x30,
                        0x1f, 0x30, 0x1d, 0x06, 0x03, 0x55, 0x1d, 0x0e, 0x04, 0x16,
                        0x04, 0x14, 0x25, 0x37, 0x46, 0xb5, 0x27, 0x59, 0x8f, 0x43,
                        0x82, 0x67, 0x9a, 0x18, 0x8e, 0xb6, 0x14, 0x65, 0x0c, 0x3a,
                        0x7d, 0xc2, 0x30, 0x0c, 0x06, 0x08, 0x2a, 0x86, 0x48, 0xce,
                        0x3d, 0x04, 0x03, 0x02, 0x05, 0x00, 0x03, 0x47, 0x00, 0x30,
                        0x44, 0x02, 0x20, 0x7c, 0x44, 0x02, 0x07, 0x37, 0xe6, 0x95,
                        0x67, 0x37, 0x46, 0xfc, 0xfb, 0x54, 0xcc, 0x33, 0xf6, 0x59,
                        0xa9, 0xb2, 0x60, 0xc8, 0x6b, 0x6d, 0x9d, 0xcf, 0xf4, 0x98,
                        0xad, 0x4b, 0x2e, 0x98, 0x95, 0x02, 0x20, 0x40, 0xa3, 0x8d,
                        0x4f, 0x62, 0x96, 0xea, 0x5c, 0x03, 0x06, 0xad, 0x32, 0x73,
                        0xb8, 0xd2, 0xac, 0x0e, 0xfc, 0xb0, 0xb8, 0x99, 0xa5, 0xf9,
                        0x49, 0x7c, 0xdf, 0x15, 0xe0, 0xa7, 0x0a, 0x9f, 0xed,
                        };

                        secControlAct.importCert.certLen = 379;
                        secControlAct.importCert.cert_p = new byte[379];
                        for (int i = 0; i < secControlAct.importCert.certLen; i++)
                            secControlAct.importCert.cert_p[i] = cert[i];
                        break;
                    }
                case 7:
                    {
                        secControlAct.exportCert.exportCertDet.certIDtype = 1;
                        secControlAct.exportCert.exportCertDet.certEntity = 1;
                        secControlAct.exportCert.exportCertDet.certType = 2;
                        secControlAct.exportCert.exportCertDet.systemTitle_len = 8;
                        secControlAct.exportCert.exportCertDet.systemTitle = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
                        secControlAct.exportCert.exportCertDet.serialNumber_len = 9;
                        secControlAct.exportCert.exportCertDet.serialNumber = new byte[9] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 };
                        secControlAct.exportCert.exportCertDet.issuer_len = 7;
                        secControlAct.exportCert.exportCertDet.issuer = new byte[7] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
                        break;
                    }
                case 8:
                    {
                        secControlAct.removeCert.certIDtype = 1;
                        secControlAct.removeCert.certEntity = 1;
                        secControlAct.removeCert.certType = 2;
                        secControlAct.removeCert.systemTitle_len = 8;
                        secControlAct.removeCert.systemTitle = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };
                        secControlAct.removeCert.serialNumber_len = 9;
                        secControlAct.removeCert.serialNumber = new byte[9] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 };
                        secControlAct.removeCert.issuer_len = 7;
                        secControlAct.removeCert.issuer = new byte[7] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07 };
                        break;
                    }
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setIC70ActionData(ref DISC_CONTROL_ACTN discCntrlAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1: discCntrlAct.remoteDisconnect = 5; break;
                case 2: discCntrlAct.remoteReconnect = 8; break;
                default: ret = false; break;
            }
            return ret;
        }

        public static bool setIC80ActionData(ref CL432SETUP_ACTN cl432SetupAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    cl432SetupAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC81ActionData(ref PRIMEPLC_PHY_LYR_CNTR_ACTN primePLCPhyLyrCntrAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    primePLCPhyLyrCntrAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC84ActionData(ref PRIMEPLC_MAC_CNTR_ACTN primePLCMACCntrAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    primePLCMACCntrAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC85ActionData(ref PRIMEPLC_NWK_ADMIN_DATA_ACTN primePLCNwkAdminDataAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    primePLCNwkAdminDataAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC90ActionData(ref G3_PLC_MAC_COUNTER_ACTN g3PLCMacCounterAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    g3PLCMacCounterAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC91ActionData(ref G3_PLC_MAC_SETUP_ACTN_CS g3PLCMacSetupAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    g3PLCMacSetupAct.data = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC95ActionData(ref WI_SUN_SETUP_ACTN wiSunSetup, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    wiSunSetup.resetData = 1;
                    break;
                default: ret = false; break;
            }
            return ret;
        }


        public static bool setIC97ActionData(ref WI_SUN_RPL_DIAG_ACTN rplDiag, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    rplDiag.resetData = 1;
                    break;
                default: ret = false; break;
            }
            return ret;
        }
        public static bool setIC96ActionData(ref WISUN_DIAGNOSTIC_ACTN wisunDiagnosticAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    wisunDiagnosticAct.reset = 1;
                    break;
                default: ret = false; break;
            }
            return ret;
        }


        public static bool setIC98ActionData(ref MPL_DIAGNOSTICS_ACTN mpldiagnosticAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    mpldiagnosticAct.resetData = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }


        public static bool setIC111ActionData(ref ACCOUNT_ACTN accountAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    accountAct.activateAccnt = 1;
                    break;
                case 2:
                    accountAct.closeAccnt = 1;
                    break;
                case 3:
                    accountAct.resetAccnt = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC112ActionData(ref CREDIT_ACTN creditAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    creditAct.updateAmount = 100;
                    break;
                case 2:
                    creditAct.setAmountToValue = 200;
                    break;
                case 3:
                    creditAct.invokeCredit = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC113ActionData(ref CHARGE_ACTN_CS chargeAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    chargeAct.updateUnitCharge.numChargeTabElemnts = 1;
                    chargeAct.updateUnitCharge.chargeTabElements =
                            new CHARGE_TAB_ELEMNT_CS[chargeAct.updateUnitCharge.numChargeTabElemnts];
                    for (int j = 0; j < chargeAct.updateUnitCharge.numChargeTabElemnts; j++)
                    {

                        chargeAct.updateUnitCharge.chargeTabElements[j].indexLen = 5;
                        chargeAct.updateUnitCharge.chargeTabElements[j].index = new byte[5];
                        for (int i = 0; i < 5; i++)
                            chargeAct.updateUnitCharge.chargeTabElements[j].index[i] = (byte)(i + 1);
                        chargeAct.updateUnitCharge.chargeTabElements[j].chargePerUnit = 3;
                    }
                    break;
                case 2:
                    chargeAct.actvatePassiveUnitCharge = 1;
                    break;
                case 3:
                    chargeAct.collect = 2;
                    break;
                case 4:
                    chargeAct.updtTotlAmntRemng = 100;
                    break;
                case 5:
                    chargeAct.setTotlAmntRemng = 200;
                    break;
                default: ret = false; break;

            }
            return ret;
        }
        public static bool setIC115ActionData(ref TOKEN_ACTN_CS tokenAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    tokenAct.enterToken.tokenLen = 15;
                    tokenAct.enterToken.token =
                            new byte[tokenAct.enterToken.tokenLen];
                    for (int j = 0; j < tokenAct.enterToken.tokenLen; j++)
                    {
                        tokenAct.enterToken.token[j] = (byte)(j + 1);
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC122ActionData(ref FUNC_CONTROL_ACTN_CS funcControlActn, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        funcControlActn.numSetFuncStatus = 1;
                        funcControlActn.setFuncStatus = new FUNC_STATUS_TYPE_CS[funcControlActn.numSetFuncStatus];
                        for (int i = 0; i < funcControlActn.numSetFuncStatus; i++)
                        {
                            funcControlActn.setFuncStatus[i].funcName = Encoding.ASCII.GetBytes("FunctionDummyName" + (i + 1));
                            funcControlActn.setFuncStatus[i].funcNameLen = (byte)funcControlActn.setFuncStatus[i].funcName.Length;
                            funcControlActn.setFuncStatus[i].funcStatus = 1;
                        }
                    }
                    break;
                case 2:
                    {
                        funcControlActn.addFunc = new FUNC_BLOCK_CS();
                        funcControlActn.addFunc.funcName = Encoding.ASCII.GetBytes("FunctionDummyName");
                        funcControlActn.addFunc.funcNameLen = (byte)funcControlActn.addFunc.funcName.Length;
                        funcControlActn.addFunc.numFuncDefs = 1;
                        funcControlActn.addFunc.funcDefs = new FUNC_DEFINITION[funcControlActn.addFunc.numFuncDefs];
                        for (int i = 0; i < funcControlActn.addFunc.numFuncDefs; i++)
                        {
                            funcControlActn.addFunc.funcDefs[i].class_id = 1;
                            funcControlActn.addFunc.funcDefs[i].logicalName = new OBISCODE(0, 0, 94, 91, 1, 255);
                        }
                    }
                    break;
                case 3:
                    {
                        funcControlActn.removeFuncName = Encoding.ASCII.GetBytes("FunctionDummyName");
                        funcControlActn.removeFuncNameLen = (byte)funcControlActn.removeFuncName.Length;
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC104ActionData(ref ZIGBEE_SETC_CONTROL_OBJECT_ACTN_CS zigbeeSETCControlObjActn, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        zigbeeSETCControlObjActn.registerDevice.ieeeAddress = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            zigbeeSETCControlObjActn.registerDevice.ieeeAddress[i] = (byte)i;
                        }

                        zigbeeSETCControlObjActn.registerDevice.deviceType = 0;
                        zigbeeSETCControlObjActn.registerDevice.keyType = 0;
                        zigbeeSETCControlObjActn.registerDevice.preconfiguredLinkKey = new byte[16];
                        for (int i = 0; i < 16; i++)
                        {
                            zigbeeSETCControlObjActn.registerDevice.preconfiguredLinkKey[i] = (byte)i;
                        }
                    }
                    break;
                case 2:
                    {
                        zigbeeSETCControlObjActn.unregisterDevice.ieeeAddress = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            zigbeeSETCControlObjActn.unregisterDevice.ieeeAddress[i] = (byte)i;
                        }
                    }
                    break;
                case 3:
                    zigbeeSETCControlObjActn.unregisterAllDevices = 1;
                    break;
                case 4:
                    {
                        zigbeeSETCControlObjActn.backupPan = 1;
                    }
                    break;
                case 5:
                    {
                        zigbeeSETCControlObjActn.restoreHann.extendedPanId = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            zigbeeSETCControlObjActn.restoreHann.extendedPanId[i] = (byte)i;
                        }
                        zigbeeSETCControlObjActn.restoreHann.numDeviceBackup = 1;
                        zigbeeSETCControlObjActn.restoreHann.deviceBackup_p =
                            new DEVICE_BACKUP_CS[zigbeeSETCControlObjActn.restoreHann.numDeviceBackup];
                        for (int i = 0; i < zigbeeSETCControlObjActn.restoreHann.numDeviceBackup; i++)
                        {
                            zigbeeSETCControlObjActn.restoreHann.deviceBackup_p[i].macAddress = new byte[8];
                            for (int j = 0; j < 8; j++)
                            {
                                zigbeeSETCControlObjActn.restoreHann.deviceBackup_p[i].macAddress[j] = (byte)j;
                            }
                            zigbeeSETCControlObjActn.restoreHann.deviceBackup_p[i].hashedTLinkKey = new byte[16];
                            for (int j = 0; j < 16; j++)
                            {
                                zigbeeSETCControlObjActn.restoreHann.deviceBackup_p[i].hashedTLinkKey[j] = (byte)j;
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        zigbeeSETCControlObjActn.identifyDevice = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            zigbeeSETCControlObjActn.identifyDevice[i] = (byte)i;
                        }
                    }
                    break;
                case 7:
                    {
                        zigbeeSETCControlObjActn.removeMirror.macAddress = new byte[8];
                        for (int i = 0; i < 8; i++)
                        {
                            zigbeeSETCControlObjActn.removeMirror.macAddress[i] = (byte)i;
                        }
                        zigbeeSETCControlObjActn.removeMirror.mirrorControl = new byte[2];
                        for (int i = 0; i < 2; i++)
                        {
                            zigbeeSETCControlObjActn.removeMirror.mirrorControl[i] = (byte)i;
                        }
                    }
                    break;
                case 8:
                    zigbeeSETCControlObjActn.updateNetworkKey = 1;
                    break;
                case 9:
                    zigbeeSETCControlObjActn.updateLinkKey = new byte[8];
                    for (int i = 0; i < 8; i++)
                    {
                        zigbeeSETCControlObjActn.updateLinkKey[i] = (byte)i;
                    }
                    break;
                case 10:
                    zigbeeSETCControlObjActn.createPan = 1;
                    break;
                case 11:
                    zigbeeSETCControlObjActn.removePan = 1;
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool setIC9000ActionData(ref EXT_DATA_ACTN extDataAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1: extDataAct.resetData = 2; break;
                case 2: extDataAct.activatePassiveValue = 10; break;
            }
            return ret;
        }
        public static bool setIC9100ActionData(ref COTS_OBJ_ACTN coTsObjAct, _OBJ obj)
        {

            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1: coTsObjAct.resetData = 5; break;
                case 2: coTsObjAct.activatePassiveValue = 1; break;
            }
            return ret;

        }
        public static bool setIC9500ActionData(ref BLOCK_TARIFF_CONFG_OBJ_ACTN blockTariffConfgobjAct, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1: blockTariffConfgobjAct.resetData = 23; break;
                case 2: blockTariffConfgobjAct.activate = 11; break;
            }
            return ret;
        }
        public static bool setICGenActionData(ref GENERIC_IC_ACTION_CS genIC, _OBJ obj)
        {
            bool ret = true;
            SampleSetData.setSampleVarValue(ref genIC.in_value, DATA_TYPE.DT_ENUM, 1);
            return ret;
        }

        public static bool Fill_ActionData(ref ACTION_UNION_CS dlActData, _OBJ obj)
        {
            bool ret = false;
            switch (obj.classId)
            {
                case 5: ret = setIC05ActionData(ref dlActData.dmdRegAct, obj); break;
                case 7: ret = setIC07ActionData(ref dlActData.profAct, obj); break;
                case 9: ret = setIC09ActionData(ref dlActData.scrAct, obj); break;
                case 15: ret = setIC15ActionData(ref dlActData.assocLNAct, obj); break;
                case 18: ret = setIC18ActionData(ref dlActData.imgTxAct, obj); break;
                case 40: ret = setIC40ActionData(ref dlActData.pushAct, obj); break;
                case 42: ret = setIC42ActionData(ref dlActData.ipv4Act, obj); break;
                case 61: ret = setIC61ActionData(ref dlActData.regTableAct, obj); break;
                case 64: ret = setIC64ActionData(ref dlActData.securityCntrlAct, obj); break;
                case 70: ret = setIC70ActionData(ref dlActData.discCntrlAct, obj); break;
                case 80: ret = setIC80ActionData(ref dlActData.cl432SetupAct, obj); break;
                case 81: ret = setIC81ActionData(ref dlActData.primePLCPhyLyrCntrAct, obj); break;
                case 82: break;
                case 83: break;
                case 84: ret = setIC84ActionData(ref dlActData.primePLCMACCntrAct, obj); break;
                case 85: ret = setIC85ActionData(ref dlActData.primePLCNwkAdminDataAct, obj); break;
                case 86: break;
                case 90: ret = setIC90ActionData(ref dlActData.g3PLCMacCounterAct, obj); break;
                case 91: ret = setIC91ActionData(ref dlActData.g3PLCMacSetupAct, obj); break;
                case 92: break;
                case 95: ret = setIC95ActionData(ref dlActData.wiSunSetupAction, obj); break;
                case 96: ret = setIC96ActionData(ref dlActData.wisunDiagnosticAct, obj); break;
                case 97: ret = setIC97ActionData(ref dlActData.wiSunRplDiagAction, obj); break;

                case 98: ret = setIC98ActionData(ref dlActData.mpldiagnosticActn, obj); break;
                case 111: ret = setIC111ActionData(ref dlActData.accountObj, obj); break;
                case 112: ret = setIC112ActionData(ref dlActData.creditObj, obj); break;
                case 113: ret = setIC113ActionData(ref dlActData.chargeObj, obj); break;
                case 115: ret = setIC115ActionData(ref dlActData.tokenObj, obj); break;
                case 122: ret = setIC122ActionData(ref dlActData.funcControlObj, obj); break;
                case 124: ret = setIC124ActionData(ref dlActData.commPortProtecObj, obj); break;
                case 127: ret = setIC127ActionData(ref dlActData.lpwanDiagObj, obj); break;
                case 128: ret = setIC128ActionData(ref dlActData.loRaWANSetupObj, obj); break;
                case 129: ret = setIC129ActionData(ref dlActData.loRaWANDiagObj, obj); break;
                case 9901:
                case 101: break;
                case 9902:
                case 102: break;
                case 9903:
                case 103: break;
                case 9904:
                case 104: ret = setIC104ActionData(ref dlActData.zigbeeSETCControlObjActn, obj); break;
                case 9905:
                case 105: break;
                case 9000: ret = setIC9000ActionData(ref dlActData.extDataAct, obj); break;
                case 9100: ret = setIC9100ActionData(ref dlActData.coTsObjAct, obj); break;
                case 9500: ret = setIC9500ActionData(ref dlActData.blockTariffConfgobjAct, obj); break;
                default: ret = setICGenActionData(ref dlActData.genAction, obj); break;

            }
            return ret;
        }

        private static bool setIC124ActionData(ref COMM_PORT_PROTECTION_ACTN commPortProtecObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        commPortProtecObj.resetData = 1;
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        private static bool setIC129ActionData(ref LORAWAN_DIAG_ACTN loRaWANDiagObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        loRaWANDiagObj.resetData = 1;
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        private static bool setIC128ActionData(ref LORAWAN_SETUP_ACTN loRaWANSetupObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        loRaWANSetupObj.disconnect = 1;
                    }
                    break;
                case 2:
                    {
                        loRaWANSetupObj.changeClass = DEVICE_CLASS.CLASS_A;
                    }
                    break;
                case 3:
                    {
                        loRaWANSetupObj.changeRegion = REGIONAL_PARAMS.EU868;
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        private static bool setIC127ActionData(ref LPWAN_DIAG_ACTN lpwanDiagObj, _OBJ obj)
        {
            bool ret = true;
            switch (obj.attrMethID)
            {
                case 1:
                    {
                        lpwanDiagObj.resetData = 1;
                    }
                    break;
                default: ret = false; break;

            }
            return ret;
        }

        public static bool Fill_ActionDataList(ACTION_UNION_CS[] actionDataList, uint numDescriptors, COSEM_METH_DESC[] CosemMethodDes_obj)
        {
            _OBJ obj = new _OBJ();
            bool rett = true;
            for (int i = 0; i < numDescriptors; i++)
            {
                if (i == 0)
                {
                    obj.obis.a = 1;
                    obj.obis.b = 1;
                    obj.obis.c = 1;
                    obj.obis.d = 4;
                    obj.obis.e = 0;
                    obj.obis.f = 255;
                    obj.classId = 5;
                    obj.attrMethID = 1;
                    obj.version = 0;
                    obj.baseCls = 0;
                }
                else
                {
                    obj.obis.a = 1;
                    obj.obis.b = 1;
                    obj.obis.c = 1;
                    obj.obis.d = 4;
                    obj.obis.e = 0;
                    obj.obis.f = 255;
                    obj.classId = 5;
                    obj.attrMethID = 1;
                    obj.version = 0;
                    obj.baseCls = 0;
                }
                CosemMethodDes_obj[i] = new COSEM_METH_DESC(obj.classId, obj.version, obj.attrMethID, obj.obis, obj.baseCls);
                actionDataList[i] = new ACTION_UNION_CS();
                rett = SetSampleActionData.Fill_ActionData(ref actionDataList[i], obj);

                if (rett != true)
                    return rett;
            }
            return rett;
        }
    }
}
