using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace PicSim
{
    class RS232
    {
        
        public RS232()
        {
            ComPort = new SerialPort("COM3", 4800);
            ComPort.Open();
        }

        string[] ArrayComPortsNames = SerialPort.GetPortNames();
        //private SerialPort ComPort = new SerialPort();

        //string comportName = "COM3";

        private SerialPort ComPort;// = new SerialPort("COM3", 4800);

        //string ComPortName = ArrayComPortsNames[index];
        

        public void Write(int portA, int portB, int trisA, int trisB)
        {
            int trisAlow = splitLower(trisA);
            int trisAhigh = splitUpper(trisA);

            int portAlow = splitLower(portA);
            int portAhigh = splitUpper(portA);

            int trisBlow = splitLower(trisB);
            int trisBhigh = splitUpper(trisB);

            int portBlow = splitLower(portB);
            int portBhigh = splitUpper(portB);

            //string data = trisAhigh.ToString("X2") + trisAlow.ToString("X2") + portAhigh.ToString("X2") + portAlow.ToString("X2") + trisBhigh.ToString("X2") + trisBlow.ToString("X2") + portBhigh.ToString("X2") + portBlow.ToString("X2");

            Char[] daten = new char[8];

            daten[0] = (char)splitLower(trisA);

            ComPort.WriteLine(new string(daten));


            ComPort.WriteLine(data);
        }

        private int splitUpper(int u)
        {
            u = 0b1111_0000 & u;
            u = u >> 4;
            u = u + 48;
            return u;
        }


        private int splitLower(int u)
        {
            u = 0b1111 & u;
            u = u + 48;
            return u;
        }
    }

    
}
