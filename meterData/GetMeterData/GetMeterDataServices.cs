using ProjectAPI.SchemaModel;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DLMS_CLIENT;
using DLMS_CLIENT.DLMSStruct;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Channels;
using System.Diagnostics.Metrics;

namespace ProjectAPI.meterData.GetMeterData
{

    public class GetMeterDataServices(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings) : IGetMeterData
    {
        private readonly IMongoCollection<MeterModel> _MeterMaster = database.GetCollection<MeterModel>(settings.Value.mst_meter);

        static SELACCESSPARAMS_CS selParams = new SELACCESSPARAMS_CS();
        static SELACCESSPARAMS selParams_ = new SELACCESSPARAMS();

        public async Task<string> GetAssociationData(ReqGetMeterData body, List<MeterModel> MeterDetails)
        {
            try
            {
                FilterDefinition<MeterModel> filter = Builders<MeterModel>.Filter.Eq("meterID", body.meterID);
                List<MeterModel> data = await _MeterMaster.Find(filter).ToListAsync();
                string result = $"Hello {body.meterID} : {body.association}";
                Console.WriteLine(result);
                Console.WriteLine("Count " + MeterDetails.Count);
                Poll_illustartion(MeterDetails[0], body.association);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return "Hello";
        }

        public static void Poll_illustartion(MeterModel Meter, int ClientPort)
        {
            Console.WriteLine(Meter.IPAddress);
            Meter.Initialization.WPortClient = ClientPort;

            _APPL appl = new _APPL();
            _PHY phy = new _PHY();
            _HDLC hdlc = new _HDLC();
            _OBJ o = new _OBJ();
            IntPtr CurFrameCounter_p = IntPtr.Zero;
            SECURITY_PARAM securityParam;
            byte cipherAARQ = 0;

            FRAME_COUNTER_CFG CurFrameCounter = new FRAME_COUNTER_CFG(0, 2);
            Encoding enc = System.Text.Encoding.ASCII;

            /* parameters to functions */
            string modeEDeviceAddr = "deviceAddress";
            string modeExxx = "XXX";
            string modeEIdent = "IDENT_STRING";
            byte[] buf = new byte[10];
            byte[] servLogID = { 1 };
            byte[] servPhyID = { 1 };
            byte[] authValue = new byte[16] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };
            byte[] authenticationKey = new byte[16] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };
            byte[] encryptionKey = new byte[16] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };
            byte[] dedicatedKey = new byte[16] { 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31 };
            byte[] serverSystemTitle = new byte[8] { 0x73, 0x79, 0x73, 0x74, 0x69, 0x74, 0x6c, 0x65 };
            byte dedicatedKeyPresent = 0;
            byte userCfg = 0;
            uint frameCounterToUse = 3;
            byte invokeId = 1;
            uint numDescriptors = 1;
            ushort[] classIdList;
            //uint Waitingduration = 20000;
            // ushort resplen=8;
            byte[] attrMethIdList;
            COSEM_ATTR_METH_DESC[] CosemMethodDes_obj1;

            byte[] dstPhyAddr = new byte[4] { 0x01, 0x02, 0x03, 0x04 };
            byte[] srcPhyAddr = new byte[5] { 0x01, 0x02, 0x03, 0x04, 0x05 };
            byte[] publicKey = new byte[64]{ 0xBA, 0xAF, 0xFD, 0xE0, 0x6A, 0x8C, 0xB1, 0xC9, 0xDA, 0xE8, 0xD9, 0x40, 0x23, 0xC6, 0x01,
                                                            0xDB, 0xBB, 0x24, 0x92, 0x54, 0xBA, 0x22, 0xED, 0xD8, 0x27, 0xE8, 0x20, 0xBC, 0xA2, 0xBC,
                                                            0xC6, 0x43, 0x62, 0xFB, 0xB8, 0x3D, 0x86, 0xA8, 0x2B, 0x87, 0xBB, 0x8B, 0x71, 0x61, 0xD2,
                                                            0xAA, 0xB5, 0x52, 0x19, 0x11, 0xA9, 0x46, 0xB9, 0x7A, 0x28, 0x4A, 0x90, 0xF7, 0x78, 0x5C,
                                                            0xD9, 0x04, 0x7D, 0x25 };
            byte[] privateKey = new byte[32] { 0x41, 0x80, 0x73, 0xC2, 0x39, 0xFA, 0x61, 0x25, 0x01, 0x1D,
                                                  0xE4, 0xD6, 0xCD, 0x2E, 0x64, 0x57, 0x80, 0x28, 0x9F, 0x76,
                                                  0x1B, 0xB2, 0x1B, 0xFB, 0x08, 0x35, 0xCB, 0x55, 0x85, 0xE8,
                                                  0xB3, 0x73 };



            IntPtr clientHandle;
            //SER_ADV_PORT_SETTINGS portSettings;
            //portSettings = new SER_ADV_PORT_SETTINGS();
            //portSettings.readIntervalTimeout = 0;

            GCHandle handle = GCHandle.Alloc(servPhyID, GCHandleType.Pinned);
            IntPtr servLogID_p = handle.AddrOfPinnedObject();
            handle = GCHandle.Alloc(servLogID, GCHandleType.Pinned);
            IntPtr servPhyID_p = handle.AddrOfPinnedObject();

            if (phy.DisplayPhyMenu(Meter.Initialization) == false)
            {
                return;
            }

            clientHandle = DLMSClient.initClient(
                Meter.Initialization.ResTimeOut, 
                Meter.Initialization.ResInterFrameTimeOut, 
                Meter.Initialization.MaxLinkLayerBuffer, 
                Meter.Initialization.MaxAppLayerBuffer, 
                phy.commProfile, 
                Meter.Initialization.CipheringSupport, 
                Meter.Initialization.ChannelNo);
            //DLMSClient.UpdateSerialAdvancedSettings(clientHandle, ref portSettings);
            if (clientHandle == IntPtr.Zero)
            {
                Console.WriteLine("Failed to initialize client.\nPress any key to exit ");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Initialized client successfully.");
            }
            /* For IP based profiles, call setParamsCosemWrapper() */
            if ((phy.commProfile == 3/*TCP*/) || (phy.commProfile == 4/*UDP*/) || (phy.commProfile == 7/*SERAIL_TCP*/) || (phy.commProfile == 8/*SERIAL_UDP*/))
            {
                int ret1 = DLMSClient.setParamsCosemWrapper(clientHandle, /* client handle */
                                                           phy.tcpUdp.wPort_Client, /* client(source) wrapper port number */
                                                           phy.tcpUdp.wPort_Server  /* server(destination) wrapper port number */

                );
                if (ret1 != 0)
                {
                    Console.WriteLine("\nsetParamsCosemWrapper Failed. Return value = " + ret1.ToString());
                    Console.WriteLine("Press any key to exit ");
                    Console.ReadLine();
                    return;
                }


                //int ret2 = DLMSClient.SetGatewayParams(clientHandle, /* client handle */
                //                                       1,
                //                                       3, dstPhyAddr,
                //                                       4, srcPhyAddr);

                //if (ret2 != 0)
                //{
                //    Console.WriteLine("\nSetGatewayParams Failed. Return value = " + ret2.ToString());
                //    Console.WriteLine("Press any key to exit ");
                //    Console.ReadLine();
                //    return;
                //}


            }

            int ret = DLMSClient.InitPort(phy.commProfile,
                                            clientHandle,
                                            phy.tcpUdp.client_ipAddr, /* client(source) ip address */
                                            phy.tcpUdp.server_ipAddr, /* server(destination) ip address */
                                            phy.tcpUdp.serverPort,                   /* server(destination) IP port number */
                                            phy.serOpt.name,          /* serial port name */
                                            phy.serOpt.baud,                         /* serial port baud rate */
                                            phy.serOpt.parity,                       /* serial port parity */
                                            0,                                       /* Indicate if unsolicited data is to be supported */
                                            100,                                     /* Connection retries(for pre-established
								                                                            association in TCP profile) */
                                            1000,
                                            2000);                                   /* Milli second delay between retries(for pre-established
								                                                            association in TCP profile) */

            if (ret != 0)
            {
                Console.WriteLine("\nFailed to initialize specified port. Return value = " + ret.ToString());
                Console.WriteLine("Press any key to exit ");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("\nInitialized port successfully");




            //Handshake for Mode E
            if (phy.commProfile == 2)
            {
                ret = DLMSClient.modeEInit(clientHandle, modeEDeviceAddr, modeExxx, modeEIdent);
                if (ret != 0)
                {
                    Console.WriteLine("\nMode E Init failed \n");
                    return;

                }
                else
                {
                    Console.WriteLine("\nMode E Init success\n");
                }
            }

            //if (img.DisplayImageTransferMenu() == false) return;

            //if (img.oprType == 2)
            //{
            //    ret = DLMSClient.ImageTransfer(clientHandle,    //client handle returned by initClient()
            //                       0,                           //type of ciphering required for the current request
            //                       16,                          //client id to identify a client                   
            //                       servLogID_p,                 //server logical device IDs
            //                       servPhyID_p,                 //server physical device IDs
            //                       1,                           //server HDLC addressing scheme(1 byte/2 bytes/4 bytes)
            //                       0,                           //flag indicating Broadcast or Not
            //                       0,                           //number of servers(meters), provided Broadcast flag is ON
            //                       1,                           //application context
            //                       0,                           //authentication level
            //                       authValue,                 //authentication value
            //                       16,                          //length of authentication value(number of bytes)
            //                       authenticationKey,         //authentication key for ciphered application contexts
            //                       encryptionKey,             //encryption key for ciphered application contexts
            //                       dedicatedKey,              //dedicated key for dedicated key ciphering
            //                       0,                           //securityPolicy
            //                       clientSystemTitle,         //client system title
            //                       1024,                        //client maximum receive PDU size
            //                       enc.GetString(img.filePath), //file name (path + filename) holding image
            //                       img.IdenName, //Identifier Name for image    
            //                       img.obj,                     //structure holding the OBIS code of IC18
            //                       100                          //delay in seconds between consecutive image block transfer
            //                       );
            //    if (ret != 0)
            //    {
            //        Console.WriteLine("\nImage Transfer failed. Returned {0:D}\n", ret);

            //    }
            //    else
            //    {
            //        Console.WriteLine("\nImage Transfer success");

            //    }
            //    Console.ReadKey();
            //    return;
            //}

            /* ////////////////////// HDLC Connection establishment ///////////////////////// */
            if ((phy.commProfile == 1) || (phy.commProfile == 2) || (phy.commProfile == 7) || (phy.commProfile == 8))
            {
                if (hdlc.DisplayHDLCMenu(Meter.Initialization) == false) return;
                // function: sendSNRM 	

                ret = DLMSClient.setParamsHDLC(clientHandle,
                                               hdlc.serverAddrLen, /* server hdlc address length */
                                               hdlc.clientAddr,    /* client address */
                                               hdlc.logicalAddr,   /* server logical device address */
                                               hdlc.physicalAddr,  /* server physical device address */
                                               hdlc.windowRx,      /* proposed - window size receive */
                                               hdlc.windowTx,      /* proposed - window size  transmit */
                                               hdlc.InfoLenRx,     /* proposed - window size receive */
                                               hdlc.InfoLenTx      /* proposed - window size transmit */
                                            );
                if (ret != 0)
                {
                    Console.WriteLine("\nSetParam HDLC failed. Returned {0:D}\nPress any key to exit ", ret);
                    Console.ReadLine();
                    return;
                }

                ret = DLMSClient.sendSNRM(clientHandle,
                                           hdlc.negoParams);        /* hdlc negotiation flag */
                if (ret != 0)
                {
                    Console.WriteLine("\nSNRM failed. Returned {0:D}\nPress any key to exit", ret);
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\nSNRM Success\n");
            }
            if (appl.DisplayApplicationMenu(phy) == false)
            {
                return;
            }
            cipherAARQ = appl.secPolicy;
            if ((phy.commProfile == 1) || (phy.commProfile == 4) || (phy.commProfile == 7) || (phy.commProfile == 8))
                ;
            else
                appl.serviceClass = 1;

            ret = DLMSClient.SetParamsAARQ(clientHandle                             /*clientHandle*/,
                                            appl.appContext,                        /* application context */
                                            appl.authMech,                          /* authentication level */
                                            appl.authKey,                         /* authentication key */
                                            appl.encKey,                          /* encryption key */
                                            dedicatedKey,                         /* dedicated key for dedicated key ciphering */
                                             appl.encKey,
                                            privateKey,
                                            publicKey,
                                            appl.secPolicy,                         /*security policy*/
                                            appl.secSuite,
                                            appl.authTagLen,                        /*AuthTag Len*/
                                            appl.clientSystemTitle,               /*client system title*/
                                            appl.passwd,                          /* LLS pasword or HLS key */
                                            appl.passwdLen,                         /* Length of passwd */
                                            appl.max_apdu_size,                     /* client maximum receive pdu size */
                                            appl.conformance,                       /* Client conformance block */
                                           0,                     /* Indicate if General Global Ciphering is to be used for Action in HLS */
                                            appl.userId                             /* Optional field - user id */
                                            );
            if (ret != 0)
            {
                Console.WriteLine("\nsetParamsAARQ failed. Returned {0:D}\nPress any key to exit", ret);
                Console.ReadLine();
                return;
            }

            if (appl.associationType == 0) /* Normal Association */
            {
                o.cipheringType = appl.secCtrlForAARQ;
                userCfg = 0;
                o.enbCompression = 0;
                frameCounterToUse = appl.userFramectr;
                securityParam = new SECURITY_PARAM(o.cipheringType, userCfg, frameCounterToUse, o.enbCompression, o.globalbroadcastkey);
                /* Function: sendAARQ */
                ret = DLMSClient.SendAARQ(clientHandle,
                                        0,                  /* Indicate if user id should be encoded in AARQ */
                                        securityParam,    /* Optional field - frame counter to use in	Action in HLS */
                                        appl.clientChallenge, /* client challenge */
                                        (byte)appl.clientChallengeLen, /* client challenge length */
                                         appl.serviceClass,
                                        dedicatedKeyPresent, /* Indicate if dedicated key should be encoded in AARQ */
                                        appl.max_apdu_size,
                                        appl.priority
                                     );
            }
            else /* Pre-established Association */
            {

                o.cipheringType = 0;
                userCfg = 0;
                o.enbCompression = 0;
                frameCounterToUse = appl.userFramectr;
                securityParam = new SECURITY_PARAM(o.cipheringType, userCfg, frameCounterToUse, o.enbCompression, o.globalbroadcastkey);

                ret = DLMSClient.SetParamsPreEstablishedAssociation(clientHandle,
                                                                    serverSystemTitle,
                                                                    8,
                                                                    0xFFFFFF,
                                                                    appl.max_apdu_size_send,
                                                                    securityParam);
            }
            if (ret != 0)
            {
                Console.WriteLine("\nAARQ failed. Return value = " + ret.ToString());
                Console.WriteLine("Press any key to exit ");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("\nAARQ Success");

            while (true)
            {
                o.cipheringType = appl.secPolicy;
                if (MenuObj(ref o, appl.appContext) == false)
                {
                    return;
                }
                if (appl.serviceClass == 0) //if serviceClass for AARQ is unconfirmed, all subsequent requests will be unconfirmed
                    o.serviceClass = 0;

                if (o.service == 1)
                {
                    byte AccessSelector = 0;/* Access Selector value as per standards(changes with IC).To be configured for selective access*/
                    COSEM_ATTR_METH_DESC_LIST getdataObj;
                    numDescriptors = 1;
                    DLMS_UNION_CS[] getdata = new DLMS_UNION_CS[numDescriptors];
                    CosemMethodDes_obj1 = new COSEM_ATTR_METH_DESC[numDescriptors];

                    if (o.useWithList == 0)
                    {
                        if ((o.classId == 7) && (o.attrMethID == 2))
                        {
                            Console.Write("Selective access:\n0 = No selective Access\n1 = By Range\n2 = By entry\n");
                            Console.Write("Enter your choice: ");
                            AccessSelector = Convert.ToByte(Console.ReadLine());
                            bool rett = SetSelectiveAccessParams.Fill_SelAcess(ref selParams, o, AccessSelector);
                        }
                        CosemMethodDes_obj1[0] = new COSEM_ATTR_METH_DESC(o.classId, o.version, o.attrMethID, selParams, o.obis, 0);
                        getdataObj = new COSEM_ATTR_METH_DESC_LIST(numDescriptors, CosemMethodDes_obj1[0], o.useWithList);
                    }
                    else
                    {
                        SetSampleGetData.fillGetListParams(numDescriptors, CosemMethodDes_obj1);
                        getdataObj = new COSEM_ATTR_METH_DESC_LIST(numDescriptors, CosemMethodDes_obj1, o.useWithList);
                    }
                    classIdList = new ushort[numDescriptors];
                    attrMethIdList = new byte[numDescriptors];
                    ushort getRet = DLMSClient.getData(clientHandle, ref getdata, ref getdataObj, o, ref selParams, userCfg, frameCounterToUse, numDescriptors, invokeId, classIdList, attrMethIdList);

                    if (getRet != 0)
                    {
                        Console.WriteLine("\nGet data failed. Return value = " + getRet.ToString());
                    }
                    else
                    {
                        if (o.serviceClass == 0)
                            Console.WriteLine("\nUnconfirmed GET is success");
                        else
                            DisplayDataGet(getdata, classIdList, attrMethIdList, numDescriptors, o.version);
                    }
                    //freeing allocations:
                    if (o.useWithList == 0)
                    {
                        Marshal.FreeHGlobal(CosemMethodDes_obj1[0].obis_p);
                    }
                    else
                    {
                        for (int j = 0; j < numDescriptors; j++)
                        {
                            Marshal.FreeHGlobal(CosemMethodDes_obj1[j].obis_p);
                        }
                    }
                    getdataObj.Clear();
                }
                else if (o.service == 2)
                {
                    DLMS_UNION_CS setdata = new DLMS_UNION_CS();
                    DLMS_UNION_CS[] setdataList = new DLMS_UNION_CS[numDescriptors];
                    COSEM_ATTR_METH_DESC_LIST setdataObj;
                    bool rett;
                    numDescriptors = 1;
                    CosemMethodDes_obj1 = new COSEM_ATTR_METH_DESC[numDescriptors];

                    if (o.useWithList == 0)
                    {
                        rett = SampleSetData.Fill_setdata(ref setdata, o);
                        CosemMethodDes_obj1[0] = new COSEM_ATTR_METH_DESC(o.classId, o.version, o.attrMethID, selParams, o.obis, 0);
                        setdataObj = new COSEM_ATTR_METH_DESC_LIST(numDescriptors, CosemMethodDes_obj1[0], o.useWithList);

                    }
                    else
                    {

                        rett = SampleSetData.Fill_setdataList(setdataList, numDescriptors, CosemMethodDes_obj1);
                        setdataObj = new COSEM_ATTR_METH_DESC_LIST(numDescriptors, CosemMethodDes_obj1, o.useWithList);
                    }
                    if (rett == false)
                    {
                        Console.WriteLine("Set for the Class/Attribute is not supported\n");
                    }
                    else
                    {
                        ushort b = DLMSClient.setData(clientHandle, o, ref setdata, ref setdataList, ref setdataObj, userCfg, frameCounterToUse, numDescriptors, invokeId);
                        if (b != 0)
                        {
                            Console.WriteLine("\nSet failed. Return value = " + b.ToString());
                        }
                        else
                        {
                            Console.WriteLine("\nSet success. Return value = " + b.ToString());
                        }
                    }
                    //freeing allocations:
                    for (int j = 0; j < numDescriptors; j++)
                    {
                        Marshal.FreeHGlobal(CosemMethodDes_obj1[j].obis_p);
                    }
                    setdataObj.Clear();
                }
                else if (o.service == 3)
                {
                    numDescriptors = 1;
                    ACTION_UNION_CS action = new ACTION_UNION_CS();
                    ACTION_UNION_CS[] actionList = new ACTION_UNION_CS[numDescriptors];
                    COSEM_METH_DESC[] CosemMethodDes_obj2 = new COSEM_METH_DESC[numDescriptors];
                    bool rett;

                    if (o.useWithList == 0)
                    {
                        rett = SetSampleActionData.Fill_ActionData(ref action, o);
                        CosemMethodDes_obj2[0] = new COSEM_METH_DESC(o.classId, o.version, o.attrMethID, o.obis, 0);
                    }
                    else
                    {
                        rett = SetSampleActionData.Fill_ActionDataList(actionList, numDescriptors, CosemMethodDes_obj2);
                    }
                    if (rett == false)
                    {
                        Console.WriteLine("Execute Action failed.Please check the action parameters \n");
                    }
                    else
                    {
                        ushort res = DLMSClient.executeAction(clientHandle, o, ref action, ref actionList, ref CosemMethodDes_obj2, userCfg, frameCounterToUse, invokeId, numDescriptors);
                        if (res != 0)
                        {
                            Console.WriteLine("\nExecute action failed. Return value = " + res.ToString());
                        }
                        else
                        {
                            Console.WriteLine("\nExecute action success. Return value = " + res.ToString());
                        }
                    }
                    for (int j = 0; j < numDescriptors; j++)
                    {
                        Marshal.FreeHGlobal(CosemMethodDes_obj2[j].obis_p);
                    }
                }
                Console.WriteLine("\nPress 'y' to continue, any other key to exit");
                if (Console.ReadLine() != "y")
                    break;
            }
            if ((phy.commProfile == 1) || (phy.commProfile == 2))
            {
                ushort by = DLMSClient.sendDISC(clientHandle); //, hdlc.clientAddr, hdlc.logicalAddr, hdlc.physicalAddr);
            }
            else
            {
                if (appl.associationType == 0) /* Normal Association */
                {
                    //Release request
                    securityParam = new SECURITY_PARAM(0, 0, cipherAARQ, 0, o.globalbroadcastkey);
                    DLMSClient.sendRLRQ(clientHandle, 0, securityParam, appl.serviceClass);
                }

            }
            DLMSClient.closePort(clientHandle);
            DLMSClient.closeClient(clientHandle);
        }
        public static void DisplayDataGet(DLMS_UNION_CS[] dlmsData, ushort[] classIDList, byte[] attrMethIdList, uint numDescriptors, byte version)
        {
            for (int i = 0; i < numDescriptors; i++)
            {
                switch (classIDList[i])
                {
                    case 1: dlmsData[i].data.Display(attrMethIdList[i]); break;//data                                         
                    case 3: dlmsData[i].register.Display(attrMethIdList[i]); break;//register
                    case 4: dlmsData[i].extRegister.Display(attrMethIdList[i]); break; //Extended register                   
                    case 5: dlmsData[i].dmdRegister.Display(attrMethIdList[i]); break;//demand register                    
                    case 6: dlmsData[i].regAct.Display(attrMethIdList[i]); break;
                    case 7: dlmsData[i].profile.Display(attrMethIdList[i], 1); break;//profile                     
                    case 8: dlmsData[i].clock.Display(attrMethIdList[i]); break;//clock                       
                    case 9: dlmsData[i].scriptTable.Display(attrMethIdList[i]); break;
                    case 10: dlmsData[i].schedule.Display(attrMethIdList[i]); break;//Schedule Class                     
                    case 11: dlmsData[i].specDaysTable.Display(attrMethIdList[i]); break;//special days table       
                    case 12: dlmsData[i].assocSN.Display(attrMethIdList[i]); break; //Association SN                    
                    case 15: dlmsData[i].assocLN.Display(attrMethIdList[i], selParams.selector); break; // Association ln                    
                    case 17: dlmsData[i].SAPAssign.Display(attrMethIdList[i]); break;
                    case 18: dlmsData[i].imageTransfer.Display(attrMethIdList[i]); break;//Image transfer  
                    case 19: dlmsData[i].IECLocal.Display(attrMethIdList[i]); break;
                    case 20: dlmsData[i].actCal.Display(attrMethIdList[i]); break;//Activity calender
                    case 21: dlmsData[i].regMonitor.Display(attrMethIdList[i]); break;
                    case 22: dlmsData[i].SingleActionSchedule.Display(attrMethIdList[i]); break;
                    case 23: dlmsData[i].hdlcSetup.Display(attrMethIdList[i]); break;
                    case 25: dlmsData[i].mbusSlavePortSetup.Display(attrMethIdList[i]); break;//M-bus Slave Port                    
                    case 26: dlmsData[i].utilityTable.Display(attrMethIdList[i]); break; //Utility table                    
                    case 27: dlmsData[i].PSTNmc.Display(attrMethIdList[i], version); break;//CommSpeed                   
                    case 28: dlmsData[i].PSTNAutoAnswer.Display(attrMethIdList[i]); break; //Pstn Auto answer                  
                    case 29: dlmsData[i].autoConnect.Display(attrMethIdList[i]); break;// Auto Connect
                    case 40: dlmsData[i].pushSetup.Display(attrMethIdList[i], version); break;// Auto Connect
                    case 41: dlmsData[i].tcpUdpSetup.Display(attrMethIdList[i]); break;//tcp-udp setup
                    case 42: dlmsData[i].ipv4.Display(attrMethIdList[i]); break;//ipv4 setup
                    case 43: dlmsData[i].ethernetSetup.Display(attrMethIdList[i]); break;//ethernet setup                  
                    case 44: dlmsData[i].pppSetup.Display(attrMethIdList[i]); break;/// PPP setup                  
                    case 45: dlmsData[i].GPRSModemSetup.Display(attrMethIdList[i]); break;//gprs modem setup                    
                    case 46: dlmsData[i].SMTPSetup.Display(attrMethIdList[i]); break;//smtp setup   
                    case 47: dlmsData[i].gsmDiag.Display(attrMethIdList[i]); break;//smtp setup
                    case 48: dlmsData[i].ipv6.Display(attrMethIdList[i]); break;//smtp setup   
                    case 55: dlmsData[i].LLC432Setup.Display(attrMethIdList[i]); break;//4-32 LLC Setup                   
                    case 57: dlmsData[i].LLC80222T1Setup.Display(attrMethIdList[i]); break;//IEC 8022-2 Type 1 LLC SETUP                  
                    case 58: dlmsData[i].LLC80222T2Setup.Display(attrMethIdList[i]); break;//IEC 8022-2 Type 2 LLC SETUP
                    case 59: dlmsData[i].LLC80222T3Setup.Display(attrMethIdList[i]); break; //IEC 8022-2 Type 3 LLC SETUP                   
                    case 61: dlmsData[i].registerTable.Display(attrMethIdList[i]); break;
                    case 62: dlmsData[i].compactData.Display(attrMethIdList[i], version); break;//Compact data //For IC62 Attr3 version 1 only "NONE" RestrictType is supported
                    case 64: dlmsData[i].securitySetup.Display(attrMethIdList[i], version); break;//security setup    
                    case 65: dlmsData[i].paramMonitor.Display(attrMethIdList[i]); break;//security setup   
                    case 67: dlmsData[i].sensorManager.Display(attrMethIdList[i]); break;//Sensor manager   
                    case 68: dlmsData[i].arbitrator.Display(attrMethIdList[i]); break;//Arbitrator
                    case 70: dlmsData[i].discControl.Display(attrMethIdList[i]); break; // Disconnect control                   
                    case 71: dlmsData[i].limiter.Display(attrMethIdList[i]); break;//Limiter Class
                    case 72: dlmsData[i].mbusClient.Display(attrMethIdList[i]); break;//M-Bus Client                   
                    case 73: dlmsData[i].wirelessModeQChannel.Display(attrMethIdList[i]); break;//Wireless Mode Q Channel   
                    case 74: dlmsData[i].mbusMasterPortSetup.Display(attrMethIdList[i]); break;//Mbus Master Port Setup   
                    case 80: dlmsData[i].cl432Setup.Display(attrMethIdList[i]); break;//61334-4-32 LLC SSCS setup
                    case 81: dlmsData[i].primePLCPhyCounter.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC Physical layer counters
                    case 82: dlmsData[i].primePLCMACSetup.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC MAC setup
                    case 83: dlmsData[i].primePLCMACFuncParams.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC MAC functional parameters
                    case 84: dlmsData[i].primePLCMACCounter.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC MAC counters
                    case 85: dlmsData[i].primePLCMACNwkAdminData.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC MAC network administration data
                    case 86: dlmsData[i].primePLCApplIdent.Display(attrMethIdList[i]); break;//PRIME NB OFDM PLC Applications identification
                    case 90: dlmsData[i].g3PLCMacCounter.Display(attrMethIdList[i]); break;//G3-PLC MAC layer counters
                    case 91: dlmsData[i].g3PLCMacSetup.Display(attrMethIdList[i]); break;//G3-PLC MAC setup
                    case 92: dlmsData[i].g3PLCAdaptSetup.Display(attrMethIdList[i]); break;//G3-PLC 6LoWPAN adaptation layer setup
                    case 95: dlmsData[i].wiSunSetup.Display(attrMethIdList[i]); break;
                    case 96: dlmsData[i].WisunDiagnostic.Display(attrMethIdList[i]); break;//WiSUN Diagnostics
                    case 97: dlmsData[i].wiSunRplDiag.Display(attrMethIdList[i]); break;
                    case 98: dlmsData[i].mplDiagnostic.Display(attrMethIdList[i]); break;
                    case 111: dlmsData[i].accountObject.Display(attrMethIdList[i]); break;//Account object
                    case 112: dlmsData[i].creditObject.Display(attrMethIdList[i]); break;//Credit object
                    case 113: dlmsData[i].chargeObject.Display(attrMethIdList[i]); break;//Charge object
                    case 115: dlmsData[i].tokenObject.Display(attrMethIdList[i]); break; //Token Object
                    case 116: dlmsData[i].iec62055.Display(attrMethIdList[i]); break; //IEC62055
                    case 122: dlmsData[i].funcControlObject.Display(attrMethIdList[i]); break; //Function Control
                    case 124: dlmsData[i].commPortProtecObj.Display(attrMethIdList[i]); break; //Comm Port Protection 
                    case 126: dlmsData[i].lpwanSetupObject.Display(attrMethIdList[i]); break; //LPWAN Setup
                    case 127: dlmsData[i].lpwanDiagObject.Display(attrMethIdList[i]); break; //LPWAN Diag
                    case 128: dlmsData[i].loRaWanSetupObject.Display(attrMethIdList[i]); break;//LoRaWAN Setup
                    case 129: dlmsData[i].loRaWANDiagObject.Display(attrMethIdList[i]); break;//LoRaWAN Diag                   
                    case 151: dlmsData[i].LteMonitoringObj.Display(attrMethIdList[i], version); break;
                    // case 9000: dlmsData.extendedData.Display(attrMethIdList[i]); break;//extended data
                    case 9001:
                    case 105: dlmsData[i].zigbeeTunnelSetup.Display(attrMethIdList[i]); break; //Zigbee tunnel setup
                                                                                               // case 9100: dlmsData.coTsObject.Display(attrMethIdList[i]); break; //Cots Object
                                                                                               //case 9200: dlmsData.zigbeeDRLCClusterObject.Display(attrMethIdList[i]); break; //Zigbee DRLC
                                                                                               //case 9500: dlmsData.blockTariffConfgtnObject.Display(attrMethIdList[i]); break; //Block Taridd configuration
                    case 9901:
                    case 101: dlmsData[i].zigbeeSASStartupObject.Display(attrMethIdList[i]); break; //Zigbee sas startup
                    case 9902:
                    case 102: dlmsData[i].zigbeeSASJoinObject.Display(attrMethIdList[i]); break; //Zigbee Sas Join
                    case 9903:
                    case 103: dlmsData[i].zigbeeSASFragmentationObject.Display(attrMethIdList[i]); break; //Zigbee SAS fragmentation
                    case 9904:
                    case 104: dlmsData[i].zigbeeSETCControlObject.Display(attrMethIdList[i]); break; //Zigbee SETC Control object               
                }
            }

        }

        public static bool MenuObj(ref _OBJ obj, byte appContext)
        {
            SECURITY_TAGS tag1 = new SECURITY_TAGS();
            try
            {
                if ((appContext == 1) || (appContext == 3))
                {
                    Console.WriteLine("\n-- Service Menu --");
                    Console.WriteLine("1. Get");
                    Console.WriteLine("2. Set");
                    Console.WriteLine("3. Action");
                    Console.Write("Enter choice for service: ");
                    obj.service = Convert.ToByte(Console.ReadLine());
                }
                else if ((appContext == 2) || (appContext == 4))
                {
                    Console.WriteLine("\n-- Service Menu --");
                    Console.WriteLine("1. Read");
                    Console.WriteLine("2. Write");
                    Console.WriteLine("3. Execute");
                    Console.Write("Enter choice for service: ");
                    obj.service = Convert.ToByte(Console.ReadLine());
                }

                Console.WriteLine("\nNormal  \t0");
                Console.WriteLine("WithList  \t1");
                Console.Write("Enter choice for service: ");
                obj.useWithList = Convert.ToByte(Console.ReadLine());
                //obj.useWithList = 0;

                switch (appContext)
                {
                    case 1:
                    case 3:
                        {
                            if (obj.useWithList != 1)
                            {
                                Console.WriteLine("\n-- Enter OBIS code --");
                                Console.Write("a: ");
                                obj.obis.a = Convert.ToByte(Console.ReadLine());
                                Console.Write("b: ");
                                obj.obis.b = Convert.ToByte(Console.ReadLine());
                                Console.Write("c: ");
                                obj.obis.c = Convert.ToByte(Console.ReadLine());
                                Console.Write("d: ");
                                obj.obis.d = Convert.ToByte(Console.ReadLine());
                                Console.Write("e: ");
                                obj.obis.e = Convert.ToByte(Console.ReadLine());
                                Console.Write("f: ");
                                obj.obis.f = Convert.ToByte(Console.ReadLine());
                                Console.Write("\nEnter Interface Class: ");
                                obj.classId = Convert.ToUInt16(Console.ReadLine());
                                Console.Write("\nEnter Attribute/Method ID: ");
                                obj.attrMethID = Convert.ToByte(Console.ReadLine());
                                Console.Write("\nEnter IC Version: ");
                                obj.version = Convert.ToByte(Console.ReadLine());
                                obj.baseCls = 0;
                            }

                            //Console.Write("\nEnter priority - 0(Normal), 1(High): ");
                            obj.priority = 0; //Convert.ToByte(Console.ReadLine());
                            //if ((obj.service == 2) || (obj.service == 3))
                            {
                                Console.Write("\nEnter Service Class - 0(Unconfirmed), 1(Confirmed) : (Will be used in case of Comm Profiles HDLC, SERIAL_TCP, SERIAL_UDP, UDP only if service Class used in AARQ is Confirmed)");
                                obj.serviceClass = Convert.ToByte(Console.ReadLine());
                            }
                        }
                        break;
                    case 2:
                    case 4:
                        {
                            Console.Write("Enter Base name: ");
                            obj.baseCls = Convert.ToUInt16(Console.ReadLine());
                            Console.Write("\nEnter Interface Class: ");
                            obj.classId = Convert.ToUInt16(Console.ReadLine());
                            Console.Write("\nEnter Attribute/Method ID: ");
                            obj.attrMethID = Convert.ToByte(Console.ReadLine());
                            if (obj.service == 2)
                            {
                                Console.Write("\nEnter IC Version: ");
                                obj.version = Convert.ToByte(Console.ReadLine());
                            }
                        }
                        break;
                    default:
                        Console.Write("\nWrong Choice of Service\n: ");
                        return false;
                }

                if ((appContext == 3) || (appContext == 4))
                {
                    Console.Write("\n -- Security Policy --\n");
                    Console.Write("Enter Security Object version (IC64 version) in use (Allowed values 0, 1): ");
                    byte b = Convert.ToByte(Console.ReadLine());
                    Console.Write("\n");
                    if (b == 0)
                    {
                        Console.Write("\nNo Security\t\t\t0");
                        Console.Write("\nAuthentication Only\t\t1");
                        Console.Write("\nEncryption Only\t\t\t2");
                        Console.Write("\nAuthentication and Encryption\t3");
                        Console.Write("\nEnter choice for Security Policy: ");
                        obj.cipheringType = Convert.ToByte(Console.ReadLine());
                        if (!((obj.cipheringType == 0) || (obj.cipheringType == 1) ||
                            (obj.cipheringType == 2) || (obj.cipheringType == 3)))
                        {
                            return false;
                        }
                        /********************************************/
                        //modify ciphering type to pass to stack.This section is  not to be modified
                        if (obj.cipheringType == 1)
                            obj.cipheringType = 0x24;
                        else if (obj.cipheringType == 2)
                            obj.cipheringType = 0x48;
                        else if (obj.cipheringType == 3)
                            obj.cipheringType = 0x6C;
                        /********************************************/
                    }
                    else if (b == 1)
                    {
                        tag1.calcSecurityPolicy(ref obj.cipheringType);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    obj.cipheringType = 0;
                }
            }
            catch (FormatException c)
            {
                Console.WriteLine(c.Message);
                return false;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }


    }

    class SECURITY_TAGS
    {
        /*Byte for checking*/
        public const byte NO_SECURITY = 0x00;
        public const byte AUTH_REQ_BIT = 0x04;
        public const byte ENC_REQ_BIT = 0x08;
        public const byte SIGNATURE_REQ_BIT = 0x10;
        public const byte AUTH_RES_BIT = 0x20;
        public const byte ENC_RES_BIT = 0x40;
        public const byte SIGNATURE_RES_BIT = 0x80;

        public void calcSecurityPolicy(ref byte securityControl)
        {
            int ch = 0;
            byte cont = 1, secPolicy = 0;
            char ret;

            do
            {
                Console.Write("\nMENU\n");
                Console.Write("1. AUTH_REQ\n2. AUTH_RES\n3. ENC_REQ\n4. ENC_RES\n5. DIG_SIG_REQ\n6. DIG_SIG_RES\n7. No Security\n");
                Console.Write("ENTER choice: ");
                ch = Convert.ToInt16(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        secPolicy |= SECURITY_TAGS.AUTH_REQ_BIT;
                        break;
                    case 2:
                        secPolicy |= SECURITY_TAGS.AUTH_RES_BIT;
                        break;
                    case 3:
                        secPolicy |= SECURITY_TAGS.ENC_REQ_BIT;
                        break;
                    case 4:
                        secPolicy |= SECURITY_TAGS.ENC_RES_BIT;
                        break;
                    case 5:
                        secPolicy |= SECURITY_TAGS.SIGNATURE_REQ_BIT;
                        break;
                    case 6:
                        secPolicy |= SECURITY_TAGS.SIGNATURE_RES_BIT;
                        break;
                    case 7:
                        secPolicy |= SECURITY_TAGS.NO_SECURITY;
                        break;
                }
                Console.Write("Do you want to enter more choices? (y/n): ");
                ret = Convert.ToChar(Console.ReadLine());
                if ((ret != 'y') && (ret != 'Y'))
                    cont = 0;
                else
                    cont = 1;
            } while (cont == 1);

            securityControl = secPolicy;
            return;
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    struct _APPL
    {
        public byte appContext;
        public byte authMech;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] passwd;
        public byte passwdLen;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] authKey;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] encKey;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] globalbroadcastkey;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] dedicatedKey;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 17)]
        public byte[] clientChallenge;
        public uint clientChallengeLen;

        public uint authTagLen;
        public byte secPolicy;
        public byte secCtrlForAARQ;
        public uint userFramectr;
        public byte cipheringType;
        public uint conformance;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] clientSystemTitle;
        public ushort max_apdu_size;
        public ushort max_apdu_size_send;
        public byte associationType;
        public byte userId;
        public byte secSuite;
        public byte serviceClass; //indicates if request is confirmed or unconfirmed
        public byte priority;

        public bool DisplayApplicationMenu(_PHY phy)
        {
            SECURITY_TAGS tag1 = new SECURITY_TAGS();
            byte AuthKeyLen = 0;
            byte EncKeyLen = 0;
            //byte DedicatedKeyLen = 0;
            try
            {
                /*
                Gets the Application layer parameters 
                */
                Console.WriteLine("\n-- Application Context --");
                Console.WriteLine("Logical Name without ciphering\t1");
                Console.WriteLine("Short Name without ciphering\t2");
                Console.WriteLine("Logical Name with ciphering\t3");
                Console.WriteLine("Short Name with ciphering\t4");
                Console.Write("Enter Choice: ");
                appContext = Convert.ToByte(Console.ReadLine());
                if (!((appContext == 1) || (appContext == 2) || (appContext == 3) || (appContext == 4)))
                {
                    Console.WriteLine("\nInvalid choice for Application Context");
                    return false;
                }
                Console.WriteLine("\n-- Authentication Level --");
                Console.WriteLine("No Authentication\t\t0");
                Console.WriteLine("Low Level Authentication\t1");
                Console.WriteLine("High Level Authentication Mech id\t2");
                Console.WriteLine("High Level Authentication Mech id\t3");
                Console.WriteLine("High Level Authentication Mech id\t4");
                Console.WriteLine("High Level Authentication Mech id\t5");
                Console.WriteLine("High Level Authentication Mechanisim ID\t6");
                Console.WriteLine("High Level Authentication Mechanisim ID\t7");
                Console.Write("Enter choice: ");
                authMech = Convert.ToByte(Console.ReadLine());
                if (!((authMech == 0) || (authMech == 1) || (authMech == 2) || (authMech == 3)
                    || (authMech == 4) || (authMech == 5) || (authMech == 6) || (authMech == 7)))
                {
                    Console.WriteLine("\nInvalid choice for Authentication Level");
                    return false;
                }

                Console.WriteLine("\n-- Authentication Tag length--");
                Console.WriteLine("8 Bytes \t1");
                Console.WriteLine("12 Bytes \t2");
                Console.Write("Enter Choice: ");
                byte b = Convert.ToByte(Console.ReadLine());

                if (b == 1)
                    authTagLen = 8;
                else
                    authTagLen = 12;

                Console.WriteLine("\nEnter Association type :");
                Console.WriteLine("Normal \t0");
                Console.WriteLine("PreEstablished \t1");
                Console.Write("Enter Choice: ");
                associationType = Convert.ToByte(Console.ReadLine());
                //associationType = 0;

                if ((phy.commProfile == 1) || (phy.commProfile == 4) ||
                    (phy.commProfile == 7) || (phy.commProfile == 8)) //applicable ony for HDLC, UDP, SERIAL_TCP, SERIAL_UDP
                {
                    Console.Write("\nEnter Service Class - 0(Unconfirmed), 1(Confirmed) : ");
                    b = Convert.ToByte(Console.ReadLine());
                    if ((b != 0) && (b != 1))
                    {
                        Console.Write("\nInvalid choice for Service Class\n");
                        return false;
                    }
                    serviceClass = b;
                    if (serviceClass == 0)
                    {
                        Console.Write("\nEnter Maximum APDU Size to be used for Send:  ");
                        max_apdu_size_send = Convert.ToUInt16(Console.ReadLine());
                    }
                }
                else
                    serviceClass = 1;

                if (authMech == 1)
                {
                    Console.Write("\nEnter Password: ");
                    passwd = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                    passwdLen = (byte)(passwd.GetLength(0));
                }

                else if ((authMech == 2) || (authMech == 3) || (authMech == 4) || (authMech == 5) || (authMech == 6) || (authMech == 7))
                {
                    do
                    {
                        // Console.Write("\nEnter HLS KEY of 16 characters: ");
                        // passwd = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                        passwd = Encoding.ASCII.GetBytes("wwwwwwwwwwwwwwww");
                        passwdLen = (byte)(passwd.GetLength(0));
                    } while (passwdLen != 16);
                }
                else
                {
                    passwd = Encoding.ASCII.GetBytes("\0");
                }

                if ((authMech == 2) || (authMech == 3) || (authMech == 4) || (authMech == 5) || (authMech == 6) || (authMech == 7) || (appContext == 3) || (appContext == 4))
                {
                    Console.WriteLine("Enter Client challenge length: ");
                    clientChallengeLen = 16;//Convert.ToByte(Console.ReadLine());

                    Console.Write("\nEnter Client challenge:  ");
                    clientChallenge = Encoding.ASCII.GetBytes("1234567812345678".ToCharArray());//Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));

                }
                if ((authMech == 5) || (authMech == 6) || (authMech == 7) || (appContext == 3) || (appContext == 4))
                {
                    Console.Write("\n-----Keys for Ciphering-----\n");
                    do
                    {
                        //Console.Write("\nEnter AUTHENTICATION Key of 16 characters:  ");
                        //authKey = new byte[16] { 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31 };
                        //  encKey = new byte[16] { 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31 };
                        authKey = Encoding.ASCII.GetBytes("0000000000000000");
                        // authKey = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                        AuthKeyLen = (byte)(authKey.GetLength(0));

                    } while (AuthKeyLen != 16);

                    //do
                    //{
                    //    Console.Write("\nEnter Dedicated Key of 16 characters:  ");
                    //    dedicatedKey = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                    //    DedicatedKeyLen = (byte)(dedicatedKey.GetLength(0));
                    //} while (DedicatedKeyLen != 16);
                    dedicatedKey = Encoding.ASCII.GetBytes("1111111111111111");

                    do
                    {
                        // Console.Write("\nEnter ENCRYPTION Key of 16 characters:  ");
                        encKey = Encoding.ASCII.GetBytes("0000000000000000");
                        //encKey = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                        EncKeyLen = (byte)(encKey.GetLength(0));
                    } while (EncKeyLen != 16);

                    Console.Write("\n -- Security Policy --\n");
                    Console.Write("Enter Security Object version (IC64 version) in use (Allowed values 0, 1): ");
                    b = Convert.ToByte(Console.ReadLine());
                    Console.Write("\n");
                    if (b == 0)
                    {
                        Console.Write("\nNo Security\t\t\t0");
                        Console.Write("\nAuthentication Only\t\t1");
                        Console.Write("\nEncryption Only\t\t\t2");
                        Console.Write("\nAuthentication and Encryption\t3");
                        Console.Write("\nEnter choice for Security Policy: ");
                        secPolicy = Convert.ToByte(Console.ReadLine());
                        if (!((secPolicy == 0) || (secPolicy == 1) ||
                            (secPolicy == 2) || (secPolicy == 3)))
                        {
                            return false;
                        }
                        /********************************************/
                        //modify ciphering type to pass to stack.This section is  not to be modified
                        if (secPolicy == 1)
                            secPolicy = 0x24;
                        else if (secPolicy == 2)
                            secPolicy = 0x48;
                        else if (secPolicy == 3)
                            secPolicy = 0x6C;
                        /********************************************/
                        if (associationType != 1)
                        {
                            Console.Write("\n --Enter Security Control For AARQ --");
                            Console.Write("\nNo Security\t\t\t0");
                            Console.Write("\nAuthentication Only\t\t1");
                            Console.Write("\nEncryption Only\t\t\t2");
                            Console.Write("\nAuthentication and Encryption\t3");
                            Console.Write("\nEnter choice for Security Policy: ");
                            secCtrlForAARQ = Convert.ToByte(Console.ReadLine());
                            if (!((secCtrlForAARQ == 0) || (secCtrlForAARQ == 1) ||
                                (secCtrlForAARQ == 2) || (secCtrlForAARQ == 3)))
                            {
                                return false;
                            }
                            /********************************************/
                            //modify ciphering type to pass to stack.This section is  not to be modified
                            if (secCtrlForAARQ == 1)
                                secCtrlForAARQ = 0x24;
                            else if (secCtrlForAARQ == 2)
                                secCtrlForAARQ = 0x48;
                            else if (secCtrlForAARQ == 3)
                                secCtrlForAARQ = 0x6C;
                            /********************************************/
                        }

                    }
                    else if (b == 1)
                    {
                        tag1.calcSecurityPolicy(ref secPolicy);
                        Console.Write("\nUse same security control for AARQ? (Y/N)) ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        if ((ch != 'y') && (ch != 'Y'))
                            tag1.calcSecurityPolicy(ref secCtrlForAARQ);
                        else
                            secCtrlForAARQ = secPolicy;
                    }
                    else
                    {
                        return false;
                    }
                    Console.Write("\n --Enter Security Suite --");
                    Console.Write("\nAES_GCM_128\t\t\t0");
                    Console.Write("\nAES_GCM_128_ECDSA_256\t\t1");
                    Console.Write("\nAES_GCM_256_ECDSA_384\t\t\t2");
                    Console.Write("\nEnter choice for Security Suite: ");
                    secSuite = Convert.ToByte(Console.ReadLine());

                    Console.Write("\nEnter Client System Title of 8 characters:");
                    //clientSystemTitle = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                    clientSystemTitle = Encoding.ASCII.GetBytes("qwertyui");

                    Console.Write("\n -- User ID --");
                    userId = Convert.ToByte(Console.ReadLine());
                }
                else
                {
                    secPolicy = 0;
                    secCtrlForAARQ = 0;
                    encKey = Encoding.ASCII.GetBytes("\0");
                    authKey = Encoding.ASCII.GetBytes("\0");
                    clientSystemTitle = Encoding.ASCII.GetBytes("\0");
                    clientChallenge = Encoding.ASCII.GetBytes("\0");
                    clientChallengeLen = 0;
                }

                Console.Write("\nEnter Maximum APDU Size: ");
                max_apdu_size = Convert.ToUInt16(Console.ReadLine());

                conformance = 16777215;
                cipheringType = 0;

                /*Fetch Frame counter from the user*/
                if ((appContext == 3) || (appContext == 4))//only for logical name with ciphering or short name with ciphering
                {
                    Console.Write("\nEnter Frame counter:  ");
                    userFramectr = Convert.ToUInt32(Console.ReadLine());
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }

}

    public class DigitalSignature
    {
        public const byte SIZE_OF_PRIV_KEY = 32;
        public const byte SIZE_OF_PUBLIC_KEY = 64;
        public const byte SIZE_OF_PRIV_KEY_SUITE2 = 48;
        public const byte SIZE_OF_PUBLIC_KEY_SUITE2 = 96;
        public static byte[] clientPubKey = new byte[SIZE_OF_PUBLIC_KEY]{0xBA, 0xAF, 0xFD, 0xE0, 0x6A, 0x8C, 0xB1, 0xC9, 0xDA, 0xE8, 0xD9, 0x40, 0x23, 0xC6, 0x01,
                                0xDB, 0xBB, 0x24, 0x92, 0x54, 0xBA, 0x22, 0xED, 0xD8, 0x27, 0xE8, 0x20, 0xBC, 0xA2, 0xBC,
                                0xC6, 0x43, 0x62, 0xFB, 0xB8, 0x3D, 0x86, 0xA8, 0x2B, 0x87, 0xBB, 0x8B, 0x71, 0x61, 0xD2,
                                0xAA, 0xB5, 0x52, 0x19, 0x11, 0xA9, 0x46, 0xB9, 0x7A, 0x28, 0x4A, 0x90, 0xF7, 0x78, 0x5C,
                                0xD9, 0x04, 0x7D, 0x25};
        public static byte[] clientPrivKey = new byte[SIZE_OF_PRIV_KEY]{0x41, 0x80, 0x73, 0xC2, 0x39, 0xFA, 0x61, 0x25, 0x01, 0x1D, 0xE4, 0xD6, 0xCD, 0x2E, 0x64, 0x57,
                                0x80, 0x28, 0x9F, 0x76, 0x1B, 0xB2, 0x1B, 0xFB, 0x08, 0x35, 0xCB, 0x55, 0x85, 0xE8, 0xB3, 0x73};
        public static byte[] cert = new byte[379]{0x30,0x82,0x01,0x77,0x30,0x82,0x01,0x1c,0xa0,0x03,
                            0x02,0x01,0x02,0x02,0x00,0x30,0x0c,0x06,0x08,0x2a,
                            0x86,0x48,0xce,0x3d,0x04,0x03,0x02,0x05,0x00,0x30,
                            0x31,0x31,0x0e,0x30,0x0c,0x06,0x03,0x55,0x04,0x06,
                            0x13,0x05,0x49,0x4e,0x44,0x49,0x41,0x31,0x0c,0x30,
                            0x0a,0x06,0x03,0x55,0x04,0x0a,0x13,0x03,0x41,0x42,
                            0x43,0x31,0x11,0x30,0x0f,0x06,0x03,0x55,0x04,0x03,
                            0x13,0x08,0x44,0x4c,0x4d,0x53,0x20,0x44,0x45,0x50,
                            0x30,0x1e,0x17,0x0d,0x31,0x33,0x31,0x32,0x33,0x31,
                            0x32,0x33,0x35,0x39,0x35,0x39,0x5a,0x17,0x0d,0x31,
                            0x36,0x31,0x32,0x33,0x31,0x32,0x33,0x35,0x39,0x35,
                            0x39,0x5a,0x30,0x34,0x31,0x0b,0x30,0x09,0x06,0x03,
                            0x55,0x04,0x06,0x13,0x02,0x55,0x53,0x31,0x0c,0x30,
                            0x0a,0x06,0x03,0x55,0x04,0x0a,0x13,0x03,0x58,0x59,
                            0x5a,0x31,0x17,0x30,0x15,0x06,0x03,0x55,0x04,0x03,
                            0x13,0x0e,0x53,0x4d,0x41,0x52,0x54,0x20,0x4d,0x45,
                            0x54,0x45,0x52,0x49,0x4e,0x47,0x30,0x59,0x30,0x13,
                            0x06,0x07,0x2a,0x86,0x48,0xce,0x3d,0x02,0x01,0x06,
                            0x08,0x2a,0x86,0x48,0xce,0x3d,0x03,0x01,0x07,0x03,
                            0x42,0x00,0x04,0x8e,0xde,0xd7,0x8c,0xf2,0x9c,0x86,
                            0xb9,0x23,0x7a,0x12,0x32,0xf8,0xa0,0x40,0x3c,0x7b,
                            0xbb,0x77,0x51,0xaf,0x5b,0xe9,0xfe,0xcc,0x33,0x91,
                            0x76,0xbc,0x49,0xd6,0x95,0xf0,0x57,0xc7,0x4e,0x3d,
                            0x0b,0xfe,0xdf,0x78,0x09,0x45,0x60,0x30,0xf9,0x3d,
                            0xde,0xda,0xd2,0x05,0xba,0xc9,0x5e,0x0b,0x7a,0x5f,
                            0x5d,0xd0,0xea,0x84,0x05,0x8b,0xc1,0xa3,0x21,0x30,
                            0x1f,0x30,0x1d,0x06,0x03,0x55,0x1d,0x0e,0x04,0x16,
                            0x04,0x14,0x25,0x37,0x46,0xb5,0x27,0x59,0x8f,0x43,
                            0x82,0x67,0x9a,0x18,0x8e,0xb6,0x14,0x65,0x0c,0x3a,
                            0x7d,0xc2,0x30,0x0c,0x06,0x08,0x2a,0x86,0x48,0xce,
                            0x3d,0x04,0x03,0x02,0x05,0x00,0x03,0x47,0x00,0x30,
                            0x44,0x02,0x20,0x7c,0x44,0x02,0x07,0x37,0xe6,0x95,
                            0x67,0x37,0x46,0xfc,0xfb,0x54,0xcc,0x33,0xf6,0x59,
                            0xa9,0xb2,0x60,0xc8,0x6b,0x6d,0x9d,0xcf,0xf4,0x98,
                            0xad,0x4b,0x2e,0x98,0x95,0x02,0x20,0x40,0xa3,0x8d,
                            0x4f,0x62,0x96,0xea,0x5c,0x03,0x06,0xad,0x32,0x73,
                            0xb8,0xd2,0xac,0x0e,0xfc,0xb0,0xb8,0x99,0xa5,0xf9,
                            0x49,0x7c,0xdf,0x15,0xe0,0xa7,0x0a,0x9f,0xed};
        public const uint certInLen = 379;
        public static byte[] tempPublicKeyserver = new byte[SIZE_OF_PUBLIC_KEY] {0xBA, 0xAF, 0xFD, 0xE0, 0x6A, 0x8C, 0xB1, 0xC9, 0xDA, 0xE8, 0xD9, 0x40, 0x23, 0xC6, 0x01,
                                0xDB, 0xBB, 0x24, 0x92, 0x54, 0xBA, 0x22, 0xED, 0xD8, 0x27, 0xE8, 0x20, 0xBC, 0xA2, 0xBC,
                                0xC6, 0x43, 0x62, 0xFB, 0xB8, 0x3D, 0x86, 0xA8, 0x2B, 0x87, 0xBB, 0x8B, 0x71, 0x61, 0xD2,
                                0xAA, 0xB5, 0x52, 0x19, 0x11, 0xA9, 0x46, 0xB9, 0x7A, 0x28, 0x4A, 0x90, 0xF7, 0x78, 0x5C,
                                0xD9, 0x04, 0x7D, 0x25 };
        public static DLMSClient.GetSignKeysCallback getSignatureKeys = (IntPtr publicUkey,
            IntPtr privateUkey, IntPtr publicVkey, byte publicUkeyLen, byte privateUkeyLen,
            byte publicVkeyLen, IntPtr dlmsInstance, byte keyType, byte flag,
                             byte channelNo, byte SecuritySuite, IntPtr systemTitle) =>
        {
            //return;
            //signature KEYS
            byte[] tempPublicKeyclient = new byte[SIZE_OF_PUBLIC_KEY]{0xBA, 0xAF, 0xFD, 0xE0, 0x6A, 0x8C, 0xB1, 0xC9, 0xDA, 0xE8, 0xD9, 0x40, 0x23, 0xC6, 0x01,
                                0xDB, 0xBB, 0x24, 0x92, 0x54, 0xBA, 0x22, 0xED, 0xD8, 0x27, 0xE8, 0x20, 0xBC, 0xA2, 0xBC,
                                0xC6, 0x43, 0x62, 0xFB, 0xB8, 0x3D, 0x86, 0xA8, 0x2B, 0x87, 0xBB, 0x8B, 0x71, 0x61, 0xD2,
                                0xAA, 0xB5, 0x52, 0x19, 0x11, 0xA9, 0x46, 0xB9, 0x7A, 0x28, 0x4A, 0x90, 0xF7, 0x78, 0x5C,
                                0xD9, 0x04, 0x7D, 0x25 };

            byte[] tempPrivateKey = new byte[SIZE_OF_PRIV_KEY]{ 0x41, 0x80, 0x73, 0xC2, 0x39, 0xFA, 0x61, 0x25, 0x01, 0x1D, 0xE4, 0xD6, 0xCD, 0x2E, 0x64, 0x57,
                                0x80, 0x28, 0x9F, 0x76, 0x1B, 0xB2, 0x1B, 0xFB, 0x08, 0x35, 0xCB, 0x55, 0x85, 0xE8, 0xB3, 0x73 };
            // return;
            if (flag == 0)
            {
                if (keyType == 0) //0 = publicUkey
                {
                    publicUkeyLen = 64;
                    if (tempPublicKeyserver.GetLength(0) > 0)
                    {
                        if (publicUkey != IntPtr.Zero)
                            Marshal.Copy(tempPublicKeyserver, 0, publicUkey, (int)tempPublicKeyserver.GetLength(0));
                    }
                }
                else if (keyType == 1) //1 = privateUkey
                {
                    privateUkeyLen = 32;
                    if (tempPrivateKey.GetLength(0) > 0)
                    {
                        if (privateUkey != IntPtr.Zero)
                            Marshal.Copy(tempPrivateKey, 0, privateUkey, (int)tempPrivateKey.GetLength(0));
                    }
                    //if (authMech == 7) //ues this key for ECDSA
                    //{
                    //    if (privateUkeyLen > 0 && clientPrivKey.Length == privateUkeyLen)
                    //    {
                    //        privateUkey = Marshal.AllocHGlobal(privateUkeyLen);
                    //        Marshal.Copy(clientPrivKey, 0, privateUkey, privateUkeyLen);
                    //    }
                    //}         
                }
                else //2 = publicVkey
                {
                    publicVkeyLen = 64;
                    if (publicVkey != IntPtr.Zero)
                        Marshal.Copy(clientPubKey, 0, publicVkey, (int)clientPubKey.GetLength(0));
                }
            }
            else if (flag == 1)
            {
                //set the public key of server with the public key got from client (contained in pointer publicUkey)
                if (keyType == 0) //0 = publicUkey
                {
                    if (publicUkey != IntPtr.Zero)
                    {
                        Marshal.Copy(publicUkey, tempPublicKeyserver, 0, SIZE_OF_PUBLIC_KEY);
                    }
                }
            }
            return;
        };



        public static void certificateInp(ref uint certBuf_Len_CRT, ref byte[] Cert_Buf,
                                ref byte[] PrivateKey, ref byte[] PublicKey)
        {
            int i = 0;
            for (i = 0; i < 32; i++)
                PrivateKey[i] = clientPubKey[i];
            for (i = 0; i < 64; i++)
                PublicKey[i] = clientPubKey[i];
            for (i = 0; i < certInLen; i++)
                Cert_Buf[i] = cert[i];
            certBuf_Len_CRT = certInLen;
        }

        public static byte getCertificate(IntPtr certSignLen, IntPtr certBuffer,
            IntPtr privKey, IntPtr pubKey, IntPtr dlmsInstance, ushort ChannelNo)
        {
            int i = 0;
            uint CertLen = 0;
            byte ret = 0;
            byte[] privateKey = new byte[SIZE_OF_PRIV_KEY], publicKey = new byte[SIZE_OF_PUBLIC_KEY], certBuf = new byte[500], tempBuf = new byte[5];
            IntPtr empty = IntPtr.Zero;

            //uses hardcoded inputs
            certificateInp(ref CertLen, ref certBuf, ref privateKey, ref publicKey);

            tempBuf[0] = (byte)CertLen;
            tempBuf[1] = (byte)(CertLen >> 8);
            // certSignLen = IntPtr.Zero;
            if (tempBuf.GetLength(0) > 0)
            {
                Marshal.Copy(tempBuf, 0, certSignLen, sizeof(int));
            }
            //certBuffer = IntPtr.Zero;
            if (certBuf.GetLength(0) > 0)
            {
                Marshal.Copy(certBuf, 0, certBuffer, (int)certBuf.GetLength(0));
            }
            //privKey = IntPtr.Zero;
            if (privateKey.GetLength(0) > 0)
            {
                Marshal.Copy(privateKey, 0, privKey, (int)privateKey.GetLength(0));
            }
            //pubKey = IntPtr.Zero;
            if (publicKey.GetLength(0) > 0)
            {
                Marshal.Copy(publicKey, 0, pubKey, (int)publicKey.GetLength(0));
            }
            //you can also generate random certificate using the below function
            //ret = DLMSSecurity.computeGetDigCertCRT(certSignLen, certBuffer, privKey, pubKey, empty, 0);
            //Console.Write("Certificate len = {0:D}, cert: ", CertLen);
            //for (i = 0; i < CertLen; i++)
            //    Console.Write("{0:D} ", certBuf[i]);
            return 0;
        }
    }


[StructLayout(LayoutKind.Sequential)]
struct _PHY
{
    public byte commProfile;
    public SEROPT serOpt;
    public TCPUDP tcpUdp;
    public bool DisplayPhyMenu(Initialization _Initialization)
    {
        /* Gets the physical layer parameters based on communication profile */
        try
        {
            /*Console.WriteLine(_Initialization.AuthenticationKey);
            Console.WriteLine(" \n-- Communication profile -- ");
            Console.WriteLine("Direct HDLC\t1");
            Console.WriteLine("Mode E\t\t2");
            Console.WriteLine("TCP\t\t3");
            Console.WriteLine("UDP\t\t4");
            //Console.WriteLine("PLC\t\t5");
            Console.WriteLine("SERIAL_TCP\t7");
            Console.WriteLine("SERIAL_UDP\t8");
            Console.Write("Enter Choice: ");*/
            commProfile = Convert.ToByte(3);
            switch (commProfile)
            {
                case 1: /* Comm profile serial direct hdlc */
                case 2: /* Comm profile serial mode E hdlc */
                    //case 5: /* PLC */
                    {
                        string temp;
                        string temp1;
                        Console.Write("\nEnter Com Port Number: ");
                        temp = Console.ReadLine();
                        temp1 = $"//./COM{temp}";
                        temp = temp1;
                        serOpt.name = Encoding.ASCII.GetBytes(temp + "\0");
                        Console.Write("\nEnter Baud rate: ");
                        serOpt.baud = 9600;
                        //  serOpt.baud = Convert.ToUInt32(Console.ReadLine());
                        if (commProfile == 1) serOpt.parity = 0;
                        if (commProfile == 2) serOpt.parity = 2;
                        tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes("\0");
                        tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes("\0");
                    }
                    break;
                case 3: /* TCP */
                case 4: /* UDP */
                    {
                        // Console.Write("\nEnter Client IP address: ");
                        tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes((_Initialization.ClientIpAddr + "\0"));
                        // Console.Write("\nEnter Server IP address: ");
                        tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes((_Initialization.ServerIpAddr + "\0"));
                        // Console.Write("\nEnter Server Port number: ");
                        tcpUdp.serverPort = Convert.ToUInt16(_Initialization.ServerPort);
                        // Console.Write("\nEnter Client wrapper Port ID: ");
                        tcpUdp.wPort_Client = Convert.ToUInt16(_Initialization.WPortClient);
                        // Console.Write("\nEnter Server wrapper port ID: ");
                        tcpUdp.wPort_Server = Convert.ToUInt16(_Initialization.WPortServer);
                        serOpt.name = Encoding.ASCII.GetBytes("\0");
                    }
                    break;
                case 7: /* SERIAL_TCP */
                case 8: /* SERIAL_UDP */
                    {
                        Console.Write("\nEnter Client IP address: ");
                        tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ClientIpAddr + "\0");
                        Console.Write("\nEnter Server IP address: ");
                        tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ServerIpAddr + "\0");
                        Console.Write("\nEnter Server Port number: ");
                        tcpUdp.serverPort = Convert.ToUInt16(_Initialization.ServerPort);
                        serOpt.name = Encoding.ASCII.GetBytes("\0");
                    }
                    break;
                default:
                    return false;
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
}

[StructLayout(LayoutKind.Sequential)]
struct _HDLC
{
    public byte clientAddr;
    public ushort logicalAddr;
    public ushort physicalAddr;
    public byte serverAddrLen;
    public byte negoParams;
    public byte windowTx;
    public byte windowRx;
    public ushort InfoLenTx;
    public ushort InfoLenRx;

    public bool DisplayHDLCMenu(Initialization Meter)
    {
        try
        {
            /* Gets the parameters for HDLC communication */
            Console.WriteLine("Meter:  " + Meter.ClientIpAddr);
            Console.Write("\nEnter Client ID: ");
            clientAddr = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("\n-- Server Address Length -- ");
            Console.WriteLine("One Byte addressing\t1");
            Console.WriteLine("Two Byte addressing\t2");
            Console.WriteLine("Four Byte addressing\t4");
            Console.Write("Enter Choice for Server Address Length: ");
            serverAddrLen = Convert.ToByte(Console.ReadLine());
            if (!((serverAddrLen == 1) || (serverAddrLen == 2) || (serverAddrLen == 4)))
            {
                Console.WriteLine("\nInvalid choice for Server Address Length");
                return false;
            }
            Console.Write("\nEnter Server Logical Device ID: ");
            logicalAddr = Convert.ToUInt16(Console.ReadLine());
            if (serverAddrLen != 1)
            {
                Console.WriteLine("\nEnter Server Physical Device ID: ");
                physicalAddr = Convert.ToUInt16(Console.ReadLine());
            }
            Console.WriteLine("\n-- HDLC Negotiation Parameters --");
            Console.WriteLine("Absent\t0");
            Console.WriteLine("Present\t1");
            Console.Write("Enter Choice for Negotiation Parameters: ");
            negoParams = Convert.ToByte(Console.ReadLine());
            if (!((negoParams == 0) || (negoParams == 1)))
            {
                Console.WriteLine("\nInvalid choice for hdlc negotiation");
                return false;
            }
            if (negoParams == 1)
            {
                Console.Write("\nEnter Window size Transmit: ");
                windowTx = Convert.ToByte(Console.ReadLine());
                Console.Write("\nEnter Window size Receive: ");
                windowRx = Convert.ToByte(Console.ReadLine());
                Console.Write("\nEnter Info field length size Transmit: ");
                InfoLenTx = Convert.ToUInt16(Console.ReadLine());
                Console.Write("\nEnter Info field length size Receive: ");
                InfoLenRx = Convert.ToUInt16(Console.ReadLine());

            }
            else
            {
                windowTx = 1;
                windowRx = 1;
                InfoLenTx = 128;
                InfoLenRx = 128;
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }
}

