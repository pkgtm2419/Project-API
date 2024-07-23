using DLMS_CLIENT;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProjectAPI._Helpers.Library;
using ProjectAPI.SchemaModel;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectAPI.meterData.GetMeterData
{
    public class Poll_illustartion
    {
        static SELACCESSPARAMS_CS selParams = new SELACCESSPARAMS_CS();
        static SELACCESSPARAMS selParams_ = new SELACCESSPARAMS();
        private readonly StoreDB _storeDB;

        public Poll_illustartion(IMongoDatabase database, IOptions<MongoDBSettingsModel> settings)
        {
            _storeDB = new StoreDB(database, settings);
        }

        public async Task PollIllustration(MeterModel Meter, int ClientPort)
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
            if (appl.DisplayApplicationMenu(phy, Meter.Initialization) == false)
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
                            await _storeDB.StoreInDB(getdata, classIdList, attrMethIdList, numDescriptors, o.version);
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
    }
}
