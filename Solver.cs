using System;
using System.Text;

namespace ConstraintSatisfactionProblem_CSharp
{
    public class Solver
    {
        private readonly ArrayPermutationGenerator[] possibilities;
        private int cycles = 0;

        public Solver()
        {
            possibilities = new ArrayPermutationGenerator[5];

            possibilities[(int)LineIndexes.Names] = new ArrayPermutationGenerator(5);
            possibilities[(int)LineIndexes.Names].CycleCompleted += NamesShuffle_CycleCompleted;

            possibilities[(int)LineIndexes.MaskColors] = new ArrayPermutationGenerator(5);
            possibilities[(int) LineIndexes.MaskColors].CycleCompleted += MaskColorsShuffle_CycleCompleted;

            possibilities[(int)LineIndexes.DevDomains] = new ArrayPermutationGenerator(5);
            possibilities[(int)LineIndexes.DevDomains].CycleCompleted += DevDomainShuffle_CycleCompleted;

            possibilities[(int)LineIndexes.Drinks] = new ArrayPermutationGenerator(5);
            possibilities[(int)LineIndexes.Drinks].CycleCompleted += DrinksShuffle_CycleCompleted;

            possibilities[(int)LineIndexes.LaptopBrands] = new ArrayPermutationGenerator(5);
            possibilities[(int)LineIndexes.LaptopBrands].CycleCompleted += LaptopBrandsShuffle_CycleCompleted;
        }

      
        public void Start()
        {
            possibilities[(int)LineIndexes.Names].Start();
            Console.WriteLine($"{cycles}");
        }


        private void LaptopBrandsShuffle_CycleCompleted(int[] array)
        {
           
            int[][] proposal = GetState();

            if (!ConstraintChecker.Check_ChromebookLaptop_isNextTo_DotNetDev(proposal))
             return;
            if (!ConstraintChecker.Check_Neo_Has_Macbook(proposal))
                return;
            if (!ConstraintChecker.Check_FrontendDev_Has_Alienware(proposal))
                return;
            if (!ConstraintChecker.Check_JavaDev_IsNextTo_ThinkPad(proposal))
                return;
            cycles++;

            PrintState();
        }

        private void DrinksShuffle_CycleCompleted(int[] array)
        {
            int[][] proposal = this.GetState();
            if (!ConstraintChecker.Check_Purple_And_Whisky(proposal))
                return;
            if (!ConstraintChecker.Check_JavaDev_IsNextTo_Gin(proposal))
                return;
            if (!ConstraintChecker.Check_Cypher_drinks_Rum(proposal))
                return;
            if (!ConstraintChecker.Check_PythonDev_drinks_Wine(proposal))
                return;
            if (!ConstraintChecker.Check_Person_Middle_Drinks_Beer(proposal))
                return;


            possibilities[(int)LineIndexes.LaptopBrands].Start();
        }

        private void DevDomainShuffle_CycleCompleted(int[] array)
        {
            int[][] proposal = this.GetState();
            if (!ConstraintChecker.Check_DotNet_And_BlueMask(proposal))
                return;
            if (!ConstraintChecker.Check_Apoc_Is_MobileDev(proposal))
                return;

            possibilities[(int)LineIndexes.Drinks].Start();
        }

        private void MaskColorsShuffle_CycleCompleted(int[] array)
        {
            int[][] proposal = this.GetState();
            if (!ConstraintChecker.Check_Green(proposal))
                return;
            if (!ConstraintChecker.Check_Morpheus_MaskColor(proposal))
                return;
            if (!ConstraintChecker.Check_Purple_and_Red_MaskColor(proposal))
                return;
            possibilities[(int)LineIndexes.DevDomains].Start(); 
        }

        private void NamesShuffle_CycleCompleted(int[] array)
        {
            if (!ConstraintChecker.Check_Trinity(this.GetState()))
                return;
            possibilities[(int)LineIndexes.MaskColors].Start();
        }

        private int[][] GetState()
        {
            int[][] result = new int[5][];
            for (int i = 0; i < 5; i++)
            {
                result[i] = possibilities[i].GetState();
            }

            return result;
        }

        private void PrintState()
        {
            int[][] possibility = GetState();
            Print(possibility[(int)LineIndexes.Names], typeof(Names));
            Print(possibility[(int)LineIndexes.MaskColors], typeof(MaskColors));
            Print(possibility[(int)LineIndexes.DevDomains], typeof(DevDomain));
            Print(possibility[(int)LineIndexes.Drinks], typeof(Drinks));
            Print(possibility[(int)LineIndexes.LaptopBrands], typeof(LaptopBrand));
        }

        private void Print(int[] line, Type t)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                sb.Append($"{Enum.GetName(t, line[i])} ");
            }
            Console.WriteLine(sb);
        }
    }
}
