namespace PandorasCodeBox.RNG;

public static unsafe class LinkedRNG
{
    private struct Node
    {
        public fixed byte Data[16];
    }
    
    public static int Random(int min, int max)
    {
        var nodes = stackalloc Node[max - min];
        
        {
            int i = 0;
            
            LOOP_START:

            *(int*)(nodes->Data + i * 16) = i;
            *(Node**)(nodes->Data + i * 16 + 8) = &nodes[(i + 1) % (max - min)]; // man this line is dumb
            
            if (++i < max - min)
            {
                goto LOOP_START;
            }
        }
        
        int startTime = DateTime.UtcNow.Microsecond;
        return min + Roll(startTime, nodes);
        
        int Roll(int startTime, Node* node)
        {
            if (DateTime.UtcNow.Microsecond >= startTime + 1)
            {
                return *(int*)node->Data;
            }

            
            Node* nextNode = *(Node**)(node->Data + 8);
            return Roll(startTime, nextNode);
        }
    }
}