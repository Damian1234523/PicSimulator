using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;


namespace PicSim
{
    internal class SerialConnection
    {

        public SerialConnection()
        {
            SetUpConnection();
        }
        private SerialPort _serialPort;

        private void SaveReceivedData(string data)
        {
            char[] buffer = data.ToCharArray();
            int value = (buffer[0] - 0x30) << 4;
            value += buffer[1] - 0x30;
            Speicher.setPortA((byte)value);
            value = (buffer[2] - 0x30) << 4;
            value += buffer[3] - 0x30;
            Speicher.setPortB((byte)value);
        }

        public void SendData()
        {
            if (!_serialPort.IsOpen) return;

            _serialPort.Write(CreateWriteProtokoll(), 0, 9);
            ReadData();
        }

        private void SetUpConnection()
        {
            try
            {
                _serialPort = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One) { ReadTimeout = 1000 };
                _serialPort.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Fehler beim Erstellen des seriellen Ports \n{e.Message}"
                    , "Fehler: Serielle Verbindung"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        private byte[] CreateWriteProtokoll()
        {
            var buffer = new byte[9];

            int trisA = Speicher.get(Speicher.PortA + 0x80);
            buffer[0] = PrepareHigherByteForTransfer(trisA);
            buffer[1] = PrepareLowerByteForTransfer(trisA);

            int portA = Speicher.get(Speicher.PortA);
            buffer[2] = PrepareHigherByteForTransfer(portA);
            buffer[3] = PrepareLowerByteForTransfer(portA);


            int trisB = Speicher.get(Speicher.PortB + 0x80);
            buffer[4] = PrepareHigherByteForTransfer(trisB);
            buffer[5] = PrepareLowerByteForTransfer(trisB);

            int portB = Speicher.get(Speicher.PortB);
            buffer[6] = PrepareHigherByteForTransfer(portB);
            buffer[7] = PrepareLowerByteForTransfer(portB);

            buffer[8] = 0x0D; //CR
            return buffer;
        }

        private void ReadData()
        {
            try
            {
                var temp = _serialPort.ReadTo("\r");
                SaveReceivedData(temp);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Fehler beim Lesen der RS232-Schnittstelle \n{e.Message}"
                    , "Fehler: Serielle Verbindung"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }

        private byte PrepareHigherByteForTransfer(int value)
        {
            return (byte)(0x30 + ((value & 0xF0) >> 4));
        }
        private byte PrepareLowerByteForTransfer(int value)
        {
            return (byte)(0x30 + (value & 0x0F));
        }
    }
}
