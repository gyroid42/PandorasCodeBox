namespace PandorasCodeBox.Loops;

public static unsafe class ForLoops
{
    public static void PointerArithmetic<T>(T[] array)
    {
        var indices = stackalloc int[array.Length];
        int i = -1;
        
        LOOP_START:
        indices[i++ + ++i - --i] = i;
        if (i < array.Length)
        {
            goto LOOP_START;
        }

        (bool, int) TryGetNextIndex()
        {
            return (*(indices++) < array.Length, *(indices - 1));
        }

        for (;;)
        {
            (bool loopCondition, int index) = TryGetNextIndex();

            if (loopCondition != true)
            {
                break;
            }
            
            // do stuff
        }
    }

    public static void BitShift<T>(T[] array)
    {
        uint listIndex = GetLoopIndices(array.Length);
        
        for (;;)
        {
            if(listIndex == 0)
            {
                goto LOOP_END;
            }
            
            int currentIndex = GetIndex(listIndex);
            listIndex >>= 1;
            
            // do stuff
        }
        
        LOOP_END:
        return;
        
        int GetIndex(uint indices)
        {
            int index = 32;
        
            while(true)
            {
                if((indices & (0b_1 << --index)) != 0)
                {
                    return index;
                }
            }
        }
        
        uint GetLoopIndices(int count)
        {
            switch(count) 
            { 
                case 0: 
                {
                    return 0b_0;
                }
                case 1:
                {
                    return 0b_1;
                }
                case 2:
                {
                    return 0b_11;
                }
                case 3:
                {
                    return 0b_111;
                }
                case 4:
                {
                    return 0b_1111;
                }
                case 5:
                {
                    return 0b_11111;
                }
                case 6:
                {
                    return 0b_111111;
                }
                case 7:
                {
                    return 0b_1111111;
                }
                case 8:
                {
                    return 0b_11111111;
                }
                case 9:
                {
                    return 0b_11111111_1;
                }
                case 10:
                {
                    return 0b_11111111_11;
                }
                case 11:
                {
                    return 0b_11111111_111;
                }
                case 12:
                {
                    return 0b_11111111_1111;
                }
                case 13:
                {
                    return 0b_11111111_11111;
                }
                case 14:
                {
                    return 0b_11111111_111111;
                }
                case 15:
                {
                    return 0b_11111111_1111111;
                }
                case 16:
                {
                    return 0b_11111111_11111111;
                }
                case 17:
                {
                    return 0b_11111111_11111111_1;
                }
                case 18:
                {
                    return 0b_11111111_11111111_11;
                }
                case 19:
                {
                    return 0b_11111111_11111111_111;
                }
                case 20:
                {
                    return 0b_11111111_11111111_1111;
                }
                case 21:
                {
                    return 0b_11111111_11111111_11111;
                }
                case 22:
                {
                    return 0b_11111111_11111111_111111;
                }
                case 23:
                {
                    return 0b_11111111_11111111_1111111;
                }
                case 24:
                {
                    return 0b_11111111_11111111_11111111;
                }
                case 25:
                {
                    return 0b_11111111_11111111_11111111_1;
                }
                case 26:
                {
                    return 0b_11111111_11111111_11111111_11;
                }
                case 27:
                {
                    return 0b_11111111_11111111_11111111_111;
                }
                case 28:
                {
                    return 0b_11111111_11111111_11111111_1111;
                }
                case 29:
                {
                    return 0b_11111111_11111111_11111111_11111;
                }
                case 30:
                {
                    return 0b_11111111_11111111_11111111_111111;
                }
                case 31:
                {
                    return 0b_11111111_11111111_11111111_1111111;
                }
                case 32:
                {
                    return 0b_11111111_11111111_11111111_11111111;
                }
            } 
            return 0; 
        }
    }

    public static void ForLoopsAreJustWhileLoops<T>(T[] array)
    {
        {
            int i = 0;
            while (i < array.Length)
            {
                // do stuff

                i++;
            }
        }
    }

    public static void ForLoopsAreJustGotosWithAnIf<T>(T[] array)
    {
        {
            int i = 0;
            
            LOOP_START:
            // do stuff
            if (++i < array.Length)
            {
                goto LOOP_START;
            }
        }
    }

    public static void EnterpriseLoop<T>(T[] array)
    {
        for (int i = FindZero(); i < GetLength(array); i = AddOneTo(i))
        {
            // do stuff
        }

        int FindZero()
        {
            return (int) (Math.Pow(182374897, 0) - 1);
        }

        int GetLength(T[] arrayToGetLengthOf)
        {
            int counter = FindZero();
            for (int i = 0; i < arrayToGetLengthOf.Length; i++)
            {
                counter++;
            }

            return counter;
        }

        int AddOneTo(int i)
        {
            i += FindZero() + 1;
            return i;
        }
    }
}