using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicSim
{
    class Executor
    {
        private int pc; //Programmcounter
        private int W; //Working Register
        private int[] R; //Register
        
        //TODO: anderen notwendigen schlonz implementieren

        public Executor()
        {
            pc = 0;
            W = 0;
            R = new int[255];
            
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
                ADDWF(arg);
            } else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0101_0000_0000)
            {
                Console.WriteLine("ANDWF");
                ANDWF(arg);
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0001_1000_0000)
            {
                Console.WriteLine("CLRF");
                CLRF(arg);
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0001_0000_0000)
            {
                Console.WriteLine("CLRW");
                CLRW();
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1001_0000_0000)
            {
                Console.WriteLine("COMF");
                COMF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0011_0000_0000)
            {
                Console.WriteLine("DECF");
                DECF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1011_0000_0000)
            {
                Console.WriteLine("DECFSZ");
                DECFSZ(arg);
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
            pc++; //pc in register implementieren?

        }

        private void CLRW()
        {
            W = 0;
            ZeroBit(0);
        }

        private void CLRF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            writeRegister(regaddr, 0);
            ZeroBit(0);
        }

        //TODO:Statusflags werden noch nirgends beeinflusst

        private void ANDWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr) & W;
            erg = Cut8(erg, false);
            ZeroBit(erg);
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void ADDWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr) + W;
            erg = Cut8(erg, true);
            //Cut4(erg) TODO: der schlonz muss n och anders impelmentiert werden
            ZeroBit(erg);
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            } else
            {
                W = erg;
            }
            
        }

        private void COMF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = ~readRegister(regaddr);
            ZeroBit(erg);
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void DECF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg--;
            ZeroBit(erg);
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void DECFSZ(int arg)
        {

        }
        //==============================================================
        
        private void writeRegister(int addr, int value)
        {
            if ((R[3] & 0b10_0000) == 0)
            {
                R[addr] = value;
            }
            else if ((R[3] & 0b10_0000) == 0b10_0000)
            {
                R[addr + 128] = value;
            }
        }

        private int readRegister(int addr)
        {
            if ((R[3] & 0b10_0000) == 0)
            {
                return R[addr];
            }
            else if ((R[3] & 0b10_0000) == 0b10_0000)
            {
                return R[addr + 128];
            }
            return 0;
        }

        private void ZeroBit(int z)
        {
            if (z == 0) {
                R[3] |= 1 << 2;
                R[0x83] |= 1 << 2;
            } 
            else
            {
                R[3] &= ~(1 << 2);
                R[0x83] &= ~(1 << 2);
            }
        }

        

        private void SetCarryBit(int z)
        {
            if (z == 1)
            {
                R[3] |= 1 << 0;
                R[0x83] |= 1 << 0;
            }
            if (z == 0)
            {
                R[3] &= ~(1 << 0);
                R[0x83] &= ~(1 << 0);
            }
        }

        private void SetDCarryBit(int z)
        {
            if (z == 1)
            {
                R[3] |= 1 << 1;
                R[0x83] |= 1 << 1;
            }
            if (z == 0)
            {
                R[3] &= ~(1 << 1);
                R[0x83] &= ~(1 << 1);
            }
        }

        private int Cut8 (int z, bool setCarry)
        {
            if (z > 255)
            {
                if (setCarry) SetCarryBit(1);
                return 0b1111_1111 & z;
            }
            return z;
        } 

        private void Cut4 (int z)
        {
            if (z > 15) SetDCarryBit(1);
        }
    }
}
