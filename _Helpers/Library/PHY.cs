using ProjectAPI.SchemaModel;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectAPI._Helpers.Library
{
    [StructLayout(LayoutKind.Sequential)]
    struct _PHY
    {
        public byte commProfile;
        public SEROPT serOpt;
        public TCPUDP tcpUdp;
        public bool DisplayPhyMenu(Initialization _Initialization)
        {
            try
            {
                commProfile = Convert.ToByte(3);
                switch (commProfile)
                {
                    case 1:
                    case 2:
                        {
                            string temp;
                            string temp1;
                            Console.Write("\nEnter Com Port Number: ");
                            temp = Console.ReadLine();
                            temp1 = $"//./COM{temp}";
                            temp = temp1;
                            serOpt.name = Encoding.ASCII.GetBytes(temp + "\0");
                            serOpt.baud = _Initialization.BaudRate;
                            if (commProfile == 1) serOpt.parity = 0;
                            if (commProfile == 2) serOpt.parity = 2;
                            tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes("\0");
                            tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes("\0");
                        }
                        break;
                    case 3: /* TCP */
                    case 4: /* UDP */
                        {
                            tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ClientIpAddr + "\0");
                            tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ServerIpAddr + "\0");
                            tcpUdp.serverPort = Convert.ToUInt16(_Initialization.ServerPort);
                            tcpUdp.wPort_Client = Convert.ToUInt16(_Initialization.WPortClient);
                            tcpUdp.wPort_Server = Convert.ToUInt16(_Initialization.WPortServer);
                            serOpt.name = Encoding.ASCII.GetBytes("\0");
                        }
                        break;
                    case 7: /* SERIAL_TCP */
                    case 8: /* SERIAL_UDP */
                        {
                            tcpUdp.client_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ClientIpAddr + "\0");
                            tcpUdp.server_ipAddr = Encoding.ASCII.GetBytes(_Initialization.ServerIpAddr + "\0");
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
}
