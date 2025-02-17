using PandorasCodeBox.Loops;

namespace PandorasCodeBox.RNG;

public static unsafe class LinkedRNG
{
    private struct Node
    {
        public fixed byte Data[16];
    }
    
    public static int Random(int min, int max, int probability)
    {
        var nodes = stackalloc Node[max - min];
        
        {
            int i = 0;
            
            LOOP_START:

            *(int*)(nodes->Data + i * 16) = i;
            *(Node**)(nodes->Data + i * 16 + 8) = &nodes[((i + 1) % (max - min)) * 16]; // man this line is dumb
            
            if (++i < max - min)
            {
                goto LOOP_START;
            }
        }

        return min + Roll(probability, nodes);
        
        int Roll(int probability, Node* node)
        {
            if (DateTime.UtcNow.Second % probability == 0)
            {
                return probability;
            }

            Node* nextNode = *(Node**)(node->Data + 8);
            return Roll(probability, nextNode);
        }
    }
}