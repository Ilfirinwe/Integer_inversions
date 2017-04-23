using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer_Inversions.Common
{
    public static class InversionsCounter
    {
        public static Int64 SortAndCountInversions(Int32[] Data)
        {
            return sortAndCountInversions(Data);
        }

        private static Int64 sortAndCountInversions(Int32[] Data)
        {
            if (Data.Length == 1) return 0;
            else
            {
                var LeftHalf = new Int32[Data.Length / 2];
                Array.Copy(Data, LeftHalf, Data.Length / 2);

                Int32 RightElementsCount = Data.Length / 2;
                if (Data.Length % 2 == 1) RightElementsCount++;
                var RightHalf = new Int32[RightElementsCount];
                Array.Copy(Data, Data.Length / 2, RightHalf, 0, RightElementsCount);

                Int64 LeftInversionsCount = sortAndCountInversions(LeftHalf);
                Int64 RightInversionsCount = sortAndCountInversions(RightHalf);
                Int64 SplitInversionsCount = MergeSortAndCountSplitInversions(LeftHalf, RightHalf, Data);

                return LeftInversionsCount + RightInversionsCount + SplitInversionsCount;
            }
        }

        private static Int64 MergeSortAndCountSplitInversions(Int32[] LeftHalf, Int32[] RightHalf, Int32[] Data)
        {
            Int64 SplitInversionsCount = 0;

            Int32 LeftIterator = 0;
            Int32 RightIterator = 0;

            for (Int32 Iterator  = 0; Iterator < Data.Length; Iterator++)
            {
                if (LeftIterator == LeftHalf.Length)
                {
                    Data[Iterator] = RightHalf[RightIterator];
                    RightIterator++;
                }
                else if (RightIterator == RightHalf.Length)
                {
                    Data[Iterator] = LeftHalf[LeftIterator];
                    LeftIterator++;
                }
                else if (LeftHalf[LeftIterator] <= RightHalf[RightIterator])
                {
                    Data[Iterator] = LeftHalf[LeftIterator];
                    LeftIterator++;
                }
                else
                {
                    Data[Iterator] = RightHalf[RightIterator];
                    SplitInversionsCount += LeftHalf.Length - LeftIterator;
                    RightIterator++;
                }
            }
            
            return SplitInversionsCount;
        }
    }
}
