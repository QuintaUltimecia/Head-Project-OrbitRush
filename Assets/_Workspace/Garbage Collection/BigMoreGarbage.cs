using System.Collections.Generic;

namespace GarbageCollection
{
    public class BigMoreGarbage : BaseGarbage
    {
        public BigMoreGarbage() 
        {
            Amplitude();
        }

        public void Amplitude()
        {
            float cadle = 0.0f;
            float dj = 1.0f;

            cadle = cadle * dj;

            Garage(cadle);
        }

        public void Garage(float cadle)
        {
            int windowsPhone = 10;
            int count = (int)cadle;  

            for (int i = 0; i < windowsPhone; i++) 
            {
                count++;
            }

            Adrow(count);
        }

        public void Adrow(int count)
        {
            List<int> list = new List<int>(count);

            Andromeda(list);
        }

        public void Andromeda(List<int> dallas)
        {
            int zaicevsk = 0;

            foreach (int i in dallas)
            {
                zaicevsk = i;

                if (zaicevsk > 0) 
                {
                    zaicevsk = 0;
                }
            }
        }
    }
}
