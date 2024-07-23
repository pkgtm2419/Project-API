using ProjectAPI.SchemaModel;
using System.Runtime.InteropServices;

namespace ProjectAPI._Helpers.Library
{
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

        public bool DisplayHDLCMenu(Initialization _Initialization)
        {
            try
            {
                clientAddr = _Initialization.ClientID;
                serverAddrLen = _Initialization.ServerAddressLength;
                if (!(serverAddrLen == 1 || serverAddrLen == 2 || serverAddrLen == 4))
                {
                    Console.WriteLine("\nInvalid choice for Server Address Length");
                    return false;
                }
                logicalAddr = _Initialization.LogicalAddress;
                if (serverAddrLen != 1)
                {
                    physicalAddr = _Initialization.ServerPhysicalDeviceID;
                }
                negoParams = _Initialization.NegoParams;
                if (!(negoParams == 0 || negoParams == 1))
                {
                    Console.WriteLine("\nInvalid choice for hdlc negotiation");
                    return false;
                }
                if (negoParams == 1)
                {
                    windowTx = _Initialization.WindowTx;
                    windowRx = _Initialization.WindowRx;
                    InfoLenTx = _Initialization.InfoLenTx;
                    InfoLenRx = _Initialization.InfoLenRx;
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
}
