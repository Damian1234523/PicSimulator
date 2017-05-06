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
        private DropOutStack<int> Stack;
        private int intArg;
        
        //TODO: anderen notwendigen schlonz implementieren

        public Executor()
        {
            pc = 0;
            W = 0;
            R = new int[255];
            Stack = new DropOutStack<int>(8);
        }

        public void SetIntArg(int i)
        {
            intArg = i;
        }
        public int GetPc()
        {
            return pc;
        }
        
        public void Execute (int arg)
        {
            // Interrupt prüfung--------------------------
            int INTCON = readRegister(0x0b);
            if ((INTCON & 0b1000_0000) == 0b1000_0000)//Global interrupt bit
            {
                if((INTCON & 0b0010_0100) == 0b0010_0100)
                {
                    //Timer interrupt
                    Stack.Push(pc);
                    pc = 4;
                    INTCON &= ~(1 << 7);
                    writeRegister(0x0b, INTCON);
                    arg = intArg;
                } else if ((INTCON & 0b0001_0010) == 0b0001_0010)
                {
                    Stack.Push(pc);
                    pc = 4;
                    INTCON &= ~(1 << 7);
                    writeRegister(0x0b, INTCON);
                    arg = intArg;
                } else if ((INTCON & 0b0000_1001) == 0b0000_1001)
                {
                    Stack.Push(pc);
                    pc = 4;
                    INTCON &= ~(1 << 7);
                    writeRegister(0x0b, INTCON);
                    arg = intArg;
                }
                
            }
            // Ende Interrupt=============================
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
                INCF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1111_0000_0000)
            {
                Console.WriteLine("INCFSZ");
                INCFSZ(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0100_0000_0000)
            {
                Console.WriteLine("IORWF");
                IORWF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1000_0000_0000)
            {
                Console.WriteLine("MOVF");
                MOVF(arg);
            }
            else if ((arg & 0b1111_1111_1000_0000) == 0b0000_0000_1000_0000)
            {
                Console.WriteLine("MOVWF");
                MOVWF(arg);
            }
            else if ((arg & 0b1111_1111_1001_1111) == 0b0000_0000_0000_0000)
            {
                Console.WriteLine("NOP");
                System.Threading.Thread.Sleep(10);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1101_0000_0000)
            {
                Console.WriteLine("RLF");
                RLF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1100_0000_0000)
            {
                Console.WriteLine("RRF");
                RRF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0010_0000_0000)
            {
                Console.WriteLine("SUBWF");
                SUBWF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_1110_0000_0000)
            {
                Console.WriteLine("SWAPF");
                SWAPF(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0110_0000_0000)
            {
                Console.WriteLine("XORWF");
                XORWF(arg);
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_0000_0000_0000)
            {
                Console.WriteLine("BCF");
                BCF(arg);
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_0100_0000_0000)
            {
                Console.WriteLine("BSF");
                BSF(arg);
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_1000_0000_0000)
            {
                Console.WriteLine("BTFSC");
                BTFSC(arg);
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0001_1100_0000_0000)
            {
                Console.WriteLine("BTFSS");
                BTFSS(arg);
            }
            else if ((arg & 0b1111_1110_0000_0000) == 0b0011_1110_0000_0000)
            {
                Console.WriteLine("ADDLW");
                ADDLW(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1001_0000_0000)
            {
                Console.WriteLine("ANDLW");
                ANDLW(arg);
            }
            else if ((arg & 0b1111_1000_0000_0000) == 0b0010_0000_0000_0000)
            {
                Console.WriteLine("CALL");
                CALL(arg);
            }
            else if (arg == 0b0000_0000_0110_0100)
            {
                Console.WriteLine("CLRWDT");  //TODO: CLRWDT muss noch implementiert werden
            }
            else if ((arg & 0b1111_1000_0000_0000) == 0b0010_1000_0000_0000)
            {
                Console.WriteLine("GOTO");
                GOTO(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1000_0000_0000)
            {
                Console.WriteLine("IORLW");
                IORLW(arg);
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0011_0000_0000_0000)
            {
                Console.WriteLine("MOVLW");
                MOVLW(arg);
            }
            else if (arg == 0b1001)
            {
                Console.WriteLine("RETFIE");
            }
            else if ((arg & 0b1111_1100_0000_0000) == 0b0011_0100_0000_0000)
            {
                Console.WriteLine("RETLW");
                RETLW(arg);
            }
            else if (arg == 0b1000)
            {
                Console.WriteLine("RETURN");
                RETURN();
            }
            else if (arg == 0b0110_0011)
            {
                Console.WriteLine("SLEEP"); //:TODO SLEEP implementieren
            }
            else if ((arg & 0b1111_1110_0000_0000) == 0b0011_1100_0000_0000)
            {
                Console.WriteLine("SUBLW");
                SUBLW(arg);
            }
            else if ((arg & 0b1111_1111_0000_0000) == 0b0011_1010_0000_0000)
            {
                Console.WriteLine("XORLW");
                XORLW(arg);
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
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg--;
            
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
            if (erg == 0) pc++;
        }

        private void INCF (int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg++;
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

        private void INCFSZ (int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg--;

            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
            if (erg == 0) pc++;
        }

        private void IORWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr) | W;
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

        private void MOVF (int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
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

        private void MOVWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            writeRegister(regaddr, W);
        }

        private void RLF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg = erg << 1;
            int statusreg = readRegister(0x03);
            statusreg = statusreg & 1;
            if (statusreg == 1)
            {
                erg++;
                SetCarryBit(0);
            }
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void RRF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg = erg >> 1;
            int statusreg = readRegister(0x03);
            statusreg = statusreg & 1;
            if (statusreg == 1)
            {
                erg += 128;
                SetCarryBit(0);
            }
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void SUBWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr) - W;
            erg = Cut8(erg, true);
            //Cut4(erg) TODO: der schlonz muss n och anders impelmentiert werden
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

        private void SWAPF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            int v1 = erg;
            int v2 = v1;

            v1 = v1 << 4;
            v2 = v2 >> 4;

            erg = v1 | v2;

            erg = Cut8(erg, false);

            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
        }

        private void XORWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr) ^ W;
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

        private void BCF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int bitPosition = 0b0011_1100_0000 & arg;
            int erg = readRegister(regaddr);
            bitPosition = bitPosition >> 5;
            erg &= ~(1 << bitPosition);
            writeRegister(regaddr, erg);
        }

        private void BSF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int bitPosition = 0b0011_1100_0000 & arg;
            int erg = readRegister(regaddr);
            bitPosition = bitPosition >> 5;
            erg |= 1 << bitPosition;
            writeRegister(regaddr, erg);
        }

        private void BTFSC(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            int bitPosition = 0b0011_1100_0000 & arg;
            bitPosition = bitPosition >> 5;
            if(!IsBitSet(erg, bitPosition))
            {
                pc++;
            }
        }

        private void BTFSS(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            int bitPosition = 0b0011_1100_0000 & arg;
            bitPosition = bitPosition >> 5;
            if (IsBitSet(erg, bitPosition))
            {
                pc++;
            }
        }

        private void ADDLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = Cut8(W + erg, true);
            ZeroBit(W);
        }

        private void ANDLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W & erg;
            ZeroBit(W);
        }

        private void CALL(int arg)
        {
            Stack.Push(pc + 1);
            int addr = 0b0111_1111 & arg;
            pc = addr - 1;
        }

        private void GOTO(int arg)
        {
            int addr = 0b0111_1111 & arg;
            pc = addr - 1;
        }

        private void IORLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W | erg;
            ZeroBit(W);
        }

        private void XORLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W ^ erg;
            ZeroBit(W);
        }

        private void SUBLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = Cut8(W - erg, true);
            ZeroBit(W);
        }

        private void RETURN()
        {
            pc = Stack.Pop() - 1;
        }

        private void MOVLW(int arg)
        {
            W = 0b1111_1111 & arg;
        }

        private void RETLW(int arg)
        {
            pc = Stack.Pop() - 1;
            W = 0b1111_1111 & arg;
        }

        private void RETFIE()
        {
            pc = Stack.Pop() - 1;
        }
        //=================================================================================================

        bool IsBitSet(int b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
        private void writeRegister(int addr, int value)
        {
            if ((addr >= 0x50 & addr <= 0x7f) | (addr >= 0xd0 & addr <= 0xff))
            {
                //Hier wird nichts gemacht
            } else if (addr >= 0x0c & addr <= 0x4f)
            {
                R[addr] = value;
                R[addr + 128] = value;
            } else if (value == 0x0b | value == 0x0a | value == 0x04 | value == 0x03 | value == 0x02)
            {
                R[addr] = value;
                R[addr + 128] = value;
            } else
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

    class DropOutStack<T>
    {
        private T[] items;
        private int top = 0;
        public DropOutStack(int capacity)
        {
            items = new T[capacity];
        }

        public void Push(T item)
        {
            items[top] = item;
            top = (top + 1) % items.Length;
        }
        public T Pop()
        {
            top = (items.Length + top - 1) % items.Length;
            return items[top];
        }
    }
}
