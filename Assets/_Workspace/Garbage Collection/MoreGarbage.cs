using Unity.VisualScripting;

namespace GarbageCollection
{
    public class MoreGarbage : BaseGarbage
    {
        private readonly int m_Count;

        private float m_Time = 1;
        private float m_TimeRemaining = 2;
        private int m_CountRemaining = 3;

        public MoreGarbage(int count)
        {
            m_Count = count;
        }

        public void Dance()
        {
            m_Time = m_Count - m_CountRemaining;

            for (int i = 0; i < m_CountRemaining; i++)
            {
                m_TimeRemaining++;
            }

            Warcraft(m_TimeRemaining);
        }

        private void Warcraft(float timeRemaining)
        {
            if (timeRemaining < 0)
            {
                m_TimeRemaining += 1;
            }
            else
            {
                m_TimeRemaining += 2;
            }

            Member(m_CountRemaining);
        }

        private void Member(float station)
        {
            float orcestra = station * m_TimeRemaining;

            for (int i = 0; i < m_TimeRemaining; i++)
            {
                for (int k = 0; k < m_TimeRemaining; k++)
                {
                    orcestra++;
                }
            }

            DoDo((int)orcestra);
        }

        private int DoDo(int ambar)
        {
            return ambar * m_CountRemaining;
        }
    }
}
