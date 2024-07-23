using System.Runtime.InteropServices;

namespace ProjectAPI.SchemaModel
{
    public class ResStatus
    {
        public int status { get; set; }
        public string message { get; set; }
    }

    public class JWTModel
    {
        public int? status { get; set; }
        public string? message { get; set; }
        public string LogInName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string CompanyID { get; set; }
    }

    struct TCPUDP
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 40)]
        public byte[] client_ipAddr;
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 40)]
        public byte[] server_ipAddr;
        public ushort serverPort;
        public ushort wPort_Client;
        public ushort wPort_Server;
    }

    struct SEROPT
    {
        [MarshalAs(UnmanagedType.LPArray, SizeConst = 10)]
        public byte[] name;
        public uint baud;
        public byte parity;
    }

    public enum DATA_TYPE
    {
        DT_NULL_DATA = 0,
        DT_ARRAY,
        DT_STRUCTURE,
        DT_BOOLEAN,
        DT_BIT_STRING,
        DT_DOUBLE_LONG = 5,
        DT_DOUBLE_LONG_UNSIGNED,
        DT_FLOATING_POINT,
        DT_OCTET_STRING = 9,
        DT_VISIBLE_STRING,
        DT_TIME,
        DT_BCD = 13,
        DT_INTEGER = 15,
        DT_LONG,
        DT_UNSIGNED,
        DT_LONG_UNSIGNED,
        DT_LONG64 = 20,
        DT_UNSIGNED_LONG64,
        DT_ENUM,
        DT_REAL32,
        DT_REAL64,
        DT_DATETIME,
        DT_DATE,
        DT_TIME1,
    }
}
