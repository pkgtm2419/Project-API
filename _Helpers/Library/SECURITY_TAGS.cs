namespace ProjectAPI._Helpers.Library
{
    public class SECURITY_TAGS
    {
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
                        secPolicy |= AUTH_REQ_BIT;
                        break;
                    case 2:
                        secPolicy |= AUTH_RES_BIT;
                        break;
                    case 3:
                        secPolicy |= ENC_REQ_BIT;
                        break;
                    case 4:
                        secPolicy |= ENC_RES_BIT;
                        break;
                    case 5:
                        secPolicy |= SIGNATURE_REQ_BIT;
                        break;
                    case 6:
                        secPolicy |= SIGNATURE_RES_BIT;
                        break;
                    case 7:
                        secPolicy |= NO_SECURITY;
                        break;
                }
                Console.Write("Do you want to enter more choices? (y/n): ");
                ret = Convert.ToChar(Console.ReadLine());
                if (ret != 'y' && ret != 'Y')
                    cont = 0;
                else
                    cont = 1;
            } while (cont == 1);

            securityControl = secPolicy;
            return;
        }
    }
}
