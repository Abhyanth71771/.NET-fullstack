using System;

namespace Business
{
    public class SerialPortParser
    {
        public static int ParsePort(string port)
        {
            
            if (!port.StartsWith("COM"))
            {
                throw new FormatException("Port is not in a correct format.");
            }
            else
            {

                return 1;
            }
        }
        
        public static int Fun(int num)
        {
            return num;
        }
    }
}