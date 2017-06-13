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
        private bool ignoreBank;

        private int prescaler;

        SerialConnection serialConnection = new SerialConnection();

        public Executor()
        {
            pc = 0;
            W = 0;
            R = new int[255];
            Stack = new DropOutStack<int>(8);
            prescaler = 0;
            ignoreBank = false;
            writeRegister(0x3, 24);
            R[0x81] = 0b1111_1111;
            R[0x85] = 0b1_1111;
            R[0x86] = 0b1111_1111;
        }

        internal void Reset()
        {
            pc = 0;
            W = 0;
            R = new int[255];
            Stack = new DropOutStack<int>(8);
            prescaler = 0;
            ignoreBank = false;
            writeRegister(0x3, 24);
            R[0x81] = 0b1111_1111;
            R[0x85] = 0b1_1111;
            R[0x86] = 0b1111_1111;
        }

        public int[] GetStack()
        {
            return Stack.ReadStack();
        }

        public void SetIntArg(int i)
        {
            intArg = i;
        }
        public int GetPc()
        {
            return pc;
        }
        
        public int GetStatus()
        {
            return R[0x03];
        }

        public int GetRegisterA()
        {
            return R[0x05];
        }

        public int GetRegisterB()
        {
            return R[0x06];
        }

        public int GetTrisA()
        {
            return R[0x85];
        }

        public int GetTrisB()
        {
            return R[0x86];
        }

        public int[] GetFullRegister()
        {
            return R;
        }

        public void SetRegisterA(int i)
        {
            int ra = readRegister(0x05);
            if (IsBitSet(ra, i))
            {
                //zu 0 machen
                ra &= ~(1 << i);
                
            }
            else
            {
                // zu 1 machen
                ra |= 1 << i;
                
            }
            R[0x05] = ra;
        }

        public void SetRegisterB(int i)
        {
            int intcon = readRegister(0x0b);
            int optionsReg = readRegister(0x81);
            optionsReg = optionsReg & 0b0100_0000;
            int rb = readRegister(0x06);

            if (IsBitSet(rb, i))
            {
                //zu 0 machen
                rb &= ~(1 << i);
                if (optionsReg == 0 & i == 0)
                {
                    intcon |= 1 << 1;
                    writeRegister(0x0b, intcon);
                }  
            }
            else
            {
                // zu 1 machen
                rb |= 1 << i;
                if (optionsReg == 0b0100_0000 & i == 0)
                {
                    intcon |= 1 << 1;
                    writeRegister(0x0b, intcon);
                }
            }

            if (i <= 7 & i >= 4)
            {
                int tris = R[0x86];
                if (IsBitSet(tris, i))
                {
                    intcon |= 1 << 0;
                    writeRegister(0x0b, intcon);
                }

            }

            R[0x06] = rb;
        }

        

        public void Execute (int arg)
        {
            try
            {
                // Interrupt prüfung--------------------------
                int INTCON = readRegister(0x0b);
                if ((INTCON & 0b1000_0000) == 0b1000_0000)//Global interrupt bit
                {
                    if ((INTCON & 0b0010_0100) == 0b0010_0100)
                    {
                        //Timer interrupt
                        Stack.Push(pc);
                        pc = 4;
                        INTCON &= ~(1 << 7);
                        writeRegister(0x0b, INTCON);
                        arg = intArg;
                        Console.WriteLine("Timer interrupt");
                    }
                    else if ((INTCON & 0b0001_0010) == 0b0001_0010)
                    {
                        Stack.Push(pc);
                        pc = 4;
                        INTCON &= ~(1 << 7);
                        writeRegister(0x0b, INTCON);
                        arg = intArg;
                        Console.WriteLine("RB0 Interrupt");
                    }
                    else if ((INTCON & 0b0000_1001) == 0b0000_1001)
                    {
                        Stack.Push(pc);
                        pc = 4;
                        INTCON &= ~(1 << 7);
                        writeRegister(0x0b, INTCON);
                        arg = intArg;
                        Console.WriteLine("RB Port");
                    }

                }
                // Ende Interrupt=============================
                if ((arg & 0b1111_1111_0000_0000) == 0b0000_0111_0000_0000)
                {
                    Console.WriteLine("ADDWF");
                    ADDWF(arg);
                }
                else if ((arg & 0b1111_1111_0000_0000) == 0b0000_0101_0000_0000)
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
                    RETFIE();
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
            } catch (FSRZero)
            {
                Console.WriteLine("Cought FSRZero exception");
                Console.WriteLine("NOP");
                System.Threading.Thread.Sleep(10);
            }
            pc++; //TODO: pc in register implementieren!
            serialConnection.SendData(R[0x05], R[0x06], R[0x85], R[0x86]);
            //Console.WriteLine("Stack: " + Stack.ReadStack());
            Console.WriteLine(W);
            Console.WriteLine(W.ToString("X2"));
        }

        private void CLRW()
        {
            W = 0;
            ZeroBit(0);
            IncTimer(1);
        }

        private void CLRF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            writeRegister(regaddr, 0);
            ZeroBit(0);
            IncTimer(1);
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
            IncTimer(1);
        }

        private void ADDWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            //int erg = readRegister(regaddr) + W;
            int erg = readRegister(regaddr);
            DigitalCarryPlus(W, erg);
            erg = erg + W;
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
            IncTimer(1);
        }

        private void COMF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = ~readRegister(regaddr);
            ZeroBit(erg);
            erg = Cut8(erg, false);
            erg = Math.Abs(erg);
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
            IncTimer(1);
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
            IncTimer(1);
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
            if (erg == 0)
            {
                pc++;
                IncTimer(2);
            }
            else
            {
                IncTimer(1);
            }
            
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
            IncTimer(1);
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
            if (erg == 0) {
                pc++;
                IncTimer(2);
            }
            else { IncTimer(1); }
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
            IncTimer(1);
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
            IncTimer(1);
        }

        private void MOVWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            writeRegister(regaddr, W);
            IncTimer(1);
        }

        private void RLF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            erg = erg << 1;
            int statusreg = readRegister(0x03);
            statusreg = statusreg & 1;
            SetCarryBit(0);
            erg = Cut8(erg, true);
            if (statusreg == 1)
            {
                erg++;
                
            }
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
            IncTimer(1);
        }

        private void RRF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            bool underflow;
            if ((erg & 1) == 1)
            {
                underflow = true;
            }
            else { underflow = false; }
            erg = erg >> 1;
            int statusreg = readRegister(0x03);
            statusreg = statusreg & 1;
            if (statusreg == 1)
            {
                erg += 128;
            }
            if ((0b1000_0000 & arg) == 128)
            {
                writeRegister(regaddr, erg);
            }
            else
            {
                W = erg;
            }
            SetCarryBit(0);
            if (underflow) SetCarryBit(1);
            IncTimer(1);
        }

        private void SUBWF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            //int erg = readRegister(regaddr) - W;
            int erg = readRegister(regaddr);
            DigitalCarryMinus(W, erg);
            erg = erg - W;
            erg = Cut8(erg, true);
            if (erg < 0) SetCarryBit(1);
            erg = Math.Abs(erg);
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
            IncTimer(1);
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
            IncTimer(1);
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
            IncTimer(1);
        }

        private void BCF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int bitPosition = 0b0011_1000_0000 & arg;
            int erg = readRegister(regaddr);
            bitPosition = bitPosition >> 7;
            erg &= ~(1 << bitPosition);
            writeRegister(regaddr, erg);
            IncTimer(1);
        }

        private void BSF(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int bitPosition = 0b0011_1000_0000 & arg;
            int erg = readRegister(regaddr);
            bitPosition = bitPosition >> 7;
            erg |= 1 << bitPosition;
            writeRegister(regaddr, erg);
            IncTimer(1);
        }

        private void BTFSC(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            int bitPosition = 0b0011_1000_0000 & arg;
            bitPosition = bitPosition >> 7;
            if (!IsBitSet(erg, bitPosition))
            {
                pc++;
                IncTimer(2);
            }
            else
            {
                IncTimer(1);
            }
        }

        private void BTFSS(int arg)
        {
            int regaddr = 0b0111_1111 & arg;
            int erg = readRegister(regaddr);
            int bitPosition = 0b0011_1000_0000 & arg;
            bitPosition = bitPosition >> 7;
            if (IsBitSet(erg, bitPosition))
            {
                pc++;
                IncTimer(2);
            } else
            {
                IncTimer(1);
            }
        }

        private void ADDLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            DigitalCarryPlus(W, erg);
            W = Cut8(W + erg, true);
            ZeroBit(W);
            IncTimer(1);
        }

        private void ANDLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W & erg;
            ZeroBit(W);
            IncTimer(1);
        }

        private void CALL(int arg)
        {
            Stack.Push(pc + 1);
            int addr = 0b0111_1111 & arg;
            pc = addr - 1;
            IncTimer(2);
        }

        private void GOTO(int arg)
        {
            int addr = 0b0111_1111 & arg;
            pc = addr - 1;
            IncTimer(2);
        }

        private void IORLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W | erg;
            ZeroBit(W);
            IncTimer(1);
        }

        private void XORLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            W = W ^ erg;
            ZeroBit(W);
            IncTimer(1);
        }

        private void SUBLW(int arg)
        {
            int erg = 0b1111_1111 & arg;
            DigitalCarryMinus(W, erg);
            W = Cut8(W - erg, true);
            if (W < 0) SetCarryBit(1);
            W = Math.Abs(W);
            ZeroBit(W);
            IncTimer(1);
        }

        private void RETURN()
        {
            pc = Stack.Pop() - 1;
            IncTimer(2);
        }

        private void MOVLW(int arg)
        {
            W = 0b1111_1111 & arg;
            IncTimer(1);
        }

        private void RETLW(int arg)
        {
            pc = Stack.Pop() - 1;
            W = 0b1111_1111 & arg;
            IncTimer(2);
        }

        private void RETFIE()
        {
            int reg = readRegister(0xb);
            reg |= 1 << 7;
            pc = Stack.Pop() - 1;
            IncTimer(2);
        }
        //=================================================================================================


        void DigitalCarryPlus(int ww, int i)
        {
            int reg = readRegister(0x03);
            ww = ww & 0b1111;
            i = i & 0b1111;

            if (ww + i > 15)
            {
                reg |= 1 << 1;
            }
            else
            {
                reg &= ~(1 << 1);
            }
            writeRegister(0x03, reg);

        }

        void DigitalCarryMinus(int ww, int i)
        {
            int reg = readRegister(0x03);
            ww = ww & 0b1111;
            i = i & 0b1111;

            if (ww > i)
            {
                reg &= ~(1 << 1);
            }
            else
            {
                reg |= 1 << 1;
            }
            writeRegister(0x03, reg);
        }

        void IncTimer(int i)
        {
            
            int timer = R[1];//readRegister(0x01);
            //ignoreBank = true;
            int optionsRegister = R[0x81];//readRegister(0x81);
            if ((optionsRegister & 0b10_0000) == 0b10_0000)
            {
                int regA = GetRegisterA();
                if ((regA & 0b1_0000) == 0b1_0000)
                {
                    //Console.WriteLine("ExtClock");
                    SetRegisterA(4);

                    //===================

                    if ((optionsRegister & 0b1000) == 0b1000)
                    {
                        //Nutzung timer ohne Prescaler
                        timer = timer + i;//writeRegister(0x01, timer + i);
                    }
                    else
                    {
                        //Nutzung timer mit Prescaler
                        int prescalerTyp = optionsRegister & 0b111;
                        double maxSize = Math.Pow(2.0, prescalerTyp + 1);

                        prescaler = prescaler + i;
                        if (prescaler >= maxSize)
                        {
                            //ignoreBank = true;
                            //writeRegister(0x01, timer + 1);
                            timer++;
                            prescaler = prescaler - (int)maxSize;
                        }
                    }

                    //================
                }
            }
            else
            {
                //Interner Timer
                if ((optionsRegister & 0b1000) == 0b1000)
                {
                    //Nutzung timer ohne Prescaler
                    timer = timer + i;//writeRegister(0x01, timer + i);
                }
                else
                {
                    //Nutzung timer mit Prescaler
                    int prescalerTyp = optionsRegister & 0b111;
                    double maxSize = Math.Pow(2.0, prescalerTyp + 1);

                    prescaler = prescaler + i;
                    if (prescaler >= maxSize)
                    {
                        //ignoreBank = true;
                        //writeRegister(0x01, timer + 1);
                        timer++;
                        prescaler = prescaler - (int)maxSize;
                    }
                }
            }
            if (timer > 0b1111_1111)
            {
                R[0x0b] |= 1 << 2;
                timer = 0;
                Console.WriteLine("Timer Voll");
            }
            //ignoreBank = true;
            //writeRegister(0x01, timer);
            R[1] = timer;
        }

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
            } else if (addr == 0x0b | addr == 0x0a | addr == 0x04 | addr == 0x03 | addr == 0x02)
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
            if (addr == 0)
            {
                int fsr = readRegister(0x04);
                if (fsr == 0)
                {
                    throw new FSRZero();
                }
                else { return readRegister(fsr); }
            }
            if (ignoreBank)
            {
                ignoreBank = false;
                return R[addr];
            }
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
            if (z > 255 | z < 0)
            {
                if (setCarry) SetCarryBit(1);
                return Math.Abs(0b1111_1111 & z);
            }
            return z;
        } 

        private void Cut4 (int z)
        {
            if (z > 15) SetDCarryBit(1);
        }

        private bool CheckCarry()
        {
            int i = readRegister(0x03);
            i = i & 1;

            if (i == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
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
        public T[] ReadStack()
        {
            T[] result = new T[items.Length];
            if (top == 0) {
                return result;
            }
            Array.Copy(items, 0, result, 0, top);
            
            return result;
        }
    }

    class FSRZero: Exception
    {
        public FSRZero()
        {

        }
    }
}
