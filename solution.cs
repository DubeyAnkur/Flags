using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flags
{
    class Flags
    {
        public int solution(int[] A)
        {
            int[] peeks = new int[A.Length];
            int N = A.Length;
            int TotalFlags = 0;
            int result = 0;
            int i;
            for (i = 1; i < N - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                {
                    peeks[i] = 1;
                    TotalFlags++;
                }
            }
            int MaxF = Math.Min(TotalFlags, Convert.ToInt32(Math.Floor(Math.Sqrt(N))));

            if (MaxF <= 1)
                return MaxF;

            int[] next = NextPeak(A, peeks);

            i = 1;
            while ((i - 1) * i <= N)
            {
                int pos = 0;
                int num = 0;
                while (pos < N && num < i)
                {
                    pos = next[pos];
                    if (pos == -1)
                        break;
                    num++;
                    pos += i;
                }
                result = Math.Max(result, num);
                i++;
            }
            return result;
        }

        public int[] NextPeak(int[] A, int[] peaks)
        {

            int N = A.Length;
            int[] next = new int[N];
            next[N - 1] = -1;
            for (int i = N - 2; i >= 0; i--)
            {
                if (peaks[i] == 1)
                    next[i] = i;
                else
                    next[i] = next[i + 1];
            }
            return next;
        }


    }

}
