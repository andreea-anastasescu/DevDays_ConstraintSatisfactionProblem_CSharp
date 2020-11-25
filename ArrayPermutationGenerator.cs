namespace ConstraintSatisfactionProblem_CSharp
{
    public delegate void Notify(int[] array);

    public class ArrayPermutationGenerator
    {
        public event Notify CycleCompleted;
        private readonly int[] array;
        public ArrayPermutationGenerator(int length)
        {
            array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = i;
            }
        }
        public void Start()
        {
            HeapPermutation(array.Length, array.Length);
        }

        public int[] GetState()
        {
            return array;
        }

        protected virtual void OnCycleCompleted() 
        {
            CycleCompleted?.Invoke(array);
        }

        // Generating permutation using Heap Algorithm
        private void HeapPermutation(int size, int n)
        {
            // if size becomes 1 then prints the obtained
            // permutation
            if (size == 1)
            {
                OnCycleCompleted();
                return;
            }

            for (int i = 0; i < size; i++)
            {
                HeapPermutation(size - 1, n);

                // if size is odd, swap 0th i.e (first) and 
                // (size-1)th i.e (last) element
                if (size % 2 == 1)
                    Swap(array,0,size - 1);

                // If size is even, swap ith and 
                // (size-1)th i.e (last) element
                else
                    Swap(array,i,size - 1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name=""></param>
        /// <param name=""></param>
        private static void  Swap(int[]a, int i, int j)
        {
            int swp = a[i];
            a[i] = a[j];
            a[j] = swp;
        }
    }
}