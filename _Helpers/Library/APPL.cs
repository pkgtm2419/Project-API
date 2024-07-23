using ProjectAPI.SchemaModel;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectAPI._Helpers.Library
{
    [StructLayout(LayoutKind.Sequential)]
    struct _APPL
    {
        public byte appContext;
        public byte authMech;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] passwd;
        public byte passwdLen;
        public byte globalbroadcastkeyLen;
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

        public bool DisplayApplicationMenu(_PHY phy, Initialization _Initialization)
        {
            SECURITY_TAGS tag1 = new SECURITY_TAGS();
            byte AuthKeyLen = 0;
            byte EncKeyLen = 0;
            byte DedicatedKeyLen = 0;
            try
            {
                appContext = _Initialization.AppContext;
                if (!(appContext == 1 || appContext == 2 || appContext == 3 || appContext == 4))
                {
                    Console.WriteLine("\nInvalid choice for Application Context");
                    return false;
                }
                authMech = _Initialization.AuthenticationMechanism;
                if (!(authMech == 0 || authMech == 1 || authMech == 2 || authMech == 3 || authMech == 4 || authMech == 5 || authMech == 6 || authMech == 7))
                {
                    Console.WriteLine("\nInvalid choice for Authentication Level");
                    return false;
                }
                byte b = _Initialization.AuthTagLen;
                if (b == 1)
                    authTagLen = 8;
                else
                    authTagLen = 12;

                associationType = _Initialization.AssociationType;
                if (phy.commProfile == 1 || phy.commProfile == 4 || phy.commProfile == 7 || phy.commProfile == 8) //applicable ony for HDLC, UDP, SERIAL_TCP, SERIAL_UDP
                {
                    Console.WriteLine(_Initialization.ServiceClass);
                    b = _Initialization.ServiceClass;
                    if (b != 0 && b != 1)
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
                    passwd = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.password.ToCharArray());
                    passwdLen = (byte)passwd.GetLength(0);
                }

                else if (authMech == 2 || authMech == 3 || authMech == 4 || authMech == 5 || authMech == 6 || authMech == 7)
                {
                    do
                    {
                        passwd = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.HLSKeyPassword.ToCharArray());
                        passwdLen = (byte)passwd.GetLength(0);
                    } while (passwdLen != 16);
                }
                else
                {
                    passwd = Encoding.ASCII.GetBytes("\0");
                }

                if (authMech == 2 || authMech == 3 || authMech == 4 || authMech == 5 || authMech == 6 || authMech == 7 || appContext == 3 || appContext == 4)
                {
                    clientChallengeLen = _Initialization.SecurityKeys.ClientChallengeLen;
                    clientChallenge = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.ClientChallengeKey.ToCharArray());

                }
                if (authMech == 5 || authMech == 6 || authMech == 7 || appContext == 3 || appContext == 4)
                {
                    do
                    {
                        authKey = new byte[16] { 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31 };
                        encKey = new byte[16] { 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31, 0x31 };
                        authKey = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.AuthenticationKey.ToCharArray());
                        AuthKeyLen = (byte)authKey.GetLength(0);

                    } while (AuthKeyLen != 16);
                    do
                    {
                        globalbroadcastkey = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.GlobalKey.ToCharArray());
                        globalbroadcastkeyLen = (byte)globalbroadcastkey.GetLength(0);
                    } while (globalbroadcastkeyLen != 16);

                    // do
                    // {
                    //     Console.Write("\nEnter Dedicated Key of 16 characters:  ");
                    //     // dedicatedKey = Encoding.ASCII.GetBytes((Console.ReadLine().ToCharArray()));
                    //     dedicatedKey = Encoding.ASCII.GetBytes((_Initialization.DedicatedKey.ToCharArray()));
                    //     // dedicatedKey = Encoding.ASCII.GetBytes("1111111111111111");
                    //     Console.WriteLine(_Initialization.DedicatedKey);
                    //     DedicatedKeyLen = (byte)(dedicatedKey.GetLength(0));
                    // } while (DedicatedKeyLen != 16);

                    do
                    {
                        encKey = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.EncryptionKey.ToCharArray());
                        EncKeyLen = (byte)encKey.GetLength(0);
                    } while (EncKeyLen != 16);

                    b = _Initialization.SecurityPolicyVersion;
                    if (b == 0)
                    {
                        secPolicy = _Initialization.SecurityPolicy;
                        if (!(secPolicy == 0 || secPolicy == 1 || secPolicy == 2 || secPolicy == 3))
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
                            secCtrlForAARQ = _Initialization.AARQSecurityControl;
                            if (!(secCtrlForAARQ == 0 || secCtrlForAARQ == 1 || secCtrlForAARQ == 2 || secCtrlForAARQ == 3))
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
                        if (ch != 'y' && ch != 'Y')
                            tag1.calcSecurityPolicy(ref secCtrlForAARQ);
                        else
                            secCtrlForAARQ = secPolicy;
                    }
                    else
                    {
                        return false;
                    }
                    secSuite = _Initialization.SecSuite;
                    clientSystemTitle = Encoding.ASCII.GetBytes(_Initialization.SecurityKeys.ClientSystemTitle.ToCharArray());
                    userId = _Initialization.UserID;
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
                max_apdu_size = _Initialization.MaximumAPDU;
                conformance = 0x1014;
                cipheringType = 0;
                /*Fetch Frame counter from the user*/
                if (appContext == 3 || appContext == 4)//only for logical name with ciphering or short name with ciphering
                {
                    userFramectr = _Initialization.UserFramectr;
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
