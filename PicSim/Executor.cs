using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSim
{
    class Executor
    {
        private int pc;
        //TODO: anderen notwendigen schlonz implementieren

        public Executor()
        {
            pc = 0;
        }

        public int GetPc()
        {
            return pc;
        }

        public void Execute (int arg)
        {
            if ((arg & 0b1111_1111_0000_0000) == 0b0000_0111_0000_0000)
            {
                Console.WriteLine("ADDWF");
            } else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0101_0000_0000)
            {
                Console.WriteLine("ANDWF");
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0001_1000_0000)
            {
                Console.WriteLine("CLRF");
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0001_0000_0000)
            {
                Console.WriteLine("CLRW");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1001_0000_0000)
            {
                Console.WriteLine("COMF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0011_0000_0000)
            {
                Console.WriteLine("DECF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1011_0000_0000)
            {
                Console.WriteLine("DECFSZ");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1010_0000_0000)
            {
                Console.WriteLine("INCF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1111_0000_0000)
            {
                Console.WriteLine("INCFSZ");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0100_0000_0000)
            {
                Console.WriteLine("IORWF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1000_0000_0000)
            {
                Console.WriteLine("MOVF");
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0000_1000_0000)
            {
                Console.WriteLine("MOVWF");
            }
            else if ((arg & 0b1111_1111_1001_1111) == 0b0000_0000_0000_0000)
            {
                Console.WriteLine("NOP");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1101_0000_0000)
            {
                Console.WriteLine("RLF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1100_0000_0000)
            {
                Console.WriteLine("RRF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0010_0000_0000)
            {
                Console.WriteLine("SUBWF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1110_0000_0000)
            {
                Console.WriteLine("SWAPF");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0110_0000_0000)
            {
                Console.WriteLine("XORWF");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_0000_0000_0000)
            {
                Console.WriteLine("BCF");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_0100_0000_0000)
            {
                Console.WriteLine("BSF");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_1000_0000_0000)
            {
                Console.WriteLine("BTFSC");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_1100_0000_0000)
            {
                Console.WriteLine("BTFSS");
            }
            else if ((arg & 0b1111_1110_0000_0000) == 0b0011_1110_0000_0000)
            {
                Console.WriteLine("ADDLW");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1001_0000_0000)
            {
                Console.WriteLine("ANDLW");
            }
            else if ((arg & 0b1111_1000_0000_0000) == 0b0010_0000_0000_0000)
            {
                Console.WriteLine("CALL");
            }
            else if (arg == 0b0000_0000_0110_0100)
            {
                Console.WriteLine("CLRWDT");
            }
            else if ((arg & 0b1111_1000_0000_0000) == 0b0010_1000_0000_0000)
            {
                Console.WriteLine("GOTO");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1000_0000_0000)
            {
                Console.WriteLine("IORLW");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0011_0000_0000_0000)
            {
                Console.WriteLine("MOVLW");
            }
            else if (arg == 0b1001)
            {
                Console.WriteLine("RETFIE");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0011_0100_0000_0000)
            {
                Console.WriteLine("RETLW");
            }
            else if (arg == 0b1000)
            {
                Console.WriteLine("RETURN");
            }
            else if (arg == 0b0110_0011)
            {
                Console.WriteLine("SLEEP");
            }
            else if ((arg & 0b1111_1110_0000_0000) == 0b0011_1100_0000_0000)
            {
                Console.WriteLine("SUBLW");
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1010_0000_0000)
            {
                Console.WriteLine("XORLW");
            }
            pc++; //TODO: dummypc++ später entfernen

        }
    }
}
