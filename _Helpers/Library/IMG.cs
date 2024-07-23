using DLMS_CLIENT.DLMSStruct;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectAPI._Helpers.Library
{
    [StructLayout(LayoutKind.Sequential)]
    struct _IMG
    {
        public byte oprType;
        public string filePath;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 50)]
        public byte[] IdenName;
        public OBISCODE obj;
        public bool DisplayImageTransferMenu()
        {
            try
            {
                oprType = 0;
                oprType = 2;
                if (!(oprType == 2 || oprType == 1))
                {
                    return false;
                }
                if (oprType == 2)
                {
                    IdenName = Encoding.ASCII.GetBytes("10".ToCharArray());
                    filePath = "C:\\CDAC_1PhSM_L501+09-11-2023_1.hex";
                    obj.a = 0;
                    obj.b = 0;
                    obj.c = 44;
                    obj.d = 0;
                    obj.e = 0;
                    obj.f = 255;
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
