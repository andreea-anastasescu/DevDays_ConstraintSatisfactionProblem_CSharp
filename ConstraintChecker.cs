using System;
using System.Runtime.Serialization;

namespace ConstraintSatisfactionProblem_CSharp
{
    public static class ConstraintChecker
    {
        internal static bool Check_Trinity(int[][] proposal)
        {
            return (proposal[0][0] == (int)Names.Trinity);
        }

        internal static bool Check_Green(int[][] proposal)
        {
            return (proposal[(int)LineIndexes.MaskColors][1] == (int)MaskColors.Green);
        }
        internal static bool Check_Morpheus_MaskColor(int[][] proposal)
        {
            int position = FindPosition(proposal, (int)LineIndexes.Names, (int)Names.Morpheus);

            return (proposal[(int)LineIndexes.MaskColors][position] == (int)MaskColors.White);
        }

        internal static bool Check_Purple_and_Red_MaskColor(int[][] proposal)
        {
            int position_purple = FindPosition(proposal, (int)LineIndexes.MaskColors, (int)MaskColors.Purple);
            int position_red = FindPosition(proposal, (int)LineIndexes.MaskColors, (int)MaskColors.Red);
            return (position_red - position_purple == 1);
        }

        internal static bool Check_Purple_And_Whisky(int[][] proposal)
        {
            int position_purple = FindPosition(proposal, (int)LineIndexes.MaskColors, (int)MaskColors.Purple);
            return (proposal[(int)LineIndexes.Drinks][position_purple] == (int)Drinks.Whisky);
        }

        internal static bool Check_DotNet_And_BlueMask(int[][] proposal)
        {
            int position_blue = FindPosition(proposal, (int)LineIndexes.MaskColors, (int)MaskColors.Blue);
            return (proposal[(int)LineIndexes.DevDomains][position_blue] == (int)DevDomain.DotNet);
        }

        internal static bool Check_ChromebookLaptop_isNextTo_DotNetDev(int[][] proposal)
        {
            int position_chromebook = FindPosition(proposal, (int)LineIndexes.LaptopBrands, (int)LaptopBrand.ChromeBook);
            int position_dotnetdev = FindPosition(proposal, (int)LineIndexes.DevDomains, (int)DevDomain.DotNet);
            return (Math.Abs(position_dotnetdev-position_chromebook)==1);
        }

        internal static bool Check_Neo_Has_Macbook(int[][] proposal)
        {
            int position_Neo = FindPosition(proposal, (int)LineIndexes.Names, (int)Names.Neo);
            
            return (proposal[(int)LineIndexes.LaptopBrands][position_Neo] == (int) LaptopBrand.MacBook);
        }

        internal static bool Check_FrontendDev_Has_Alienware(int[][] proposal)
        {
            int position_FrontendDev = FindPosition(proposal, (int)LineIndexes.DevDomains, (int)DevDomain.FrontEnd);

            return (proposal[(int)LineIndexes.LaptopBrands][position_FrontendDev] == (int)LaptopBrand.Alienware);
        }

        internal static bool Check_JavaDev_IsNextTo_ThinkPad(int[][] proposal)
        {
            int position_JavaDev = FindPosition(proposal, (int)LineIndexes.DevDomains, (int)DevDomain.Java);
            int position_thinkpad = FindPosition(proposal, (int)LineIndexes.LaptopBrands, (int)LaptopBrand.Thinkpad);

            return (Math.Abs(position_JavaDev - position_thinkpad) == 1);
        }

        internal static bool Check_JavaDev_IsNextTo_Gin(int[][] proposal)
        {
            int position_JavaDev = FindPosition(proposal, (int)LineIndexes.DevDomains, (int)DevDomain.Java);
            int position_Gin = FindPosition(proposal, (int)LineIndexes.Drinks, (int)Drinks.Gin);

            return (Math.Abs(position_JavaDev - position_Gin) == 1);
        }

        internal static bool Check_Cypher_drinks_Rum(int[][] proposal)
        {
            int position_Cypher = FindPosition(proposal, (int)LineIndexes.Names, (int)Names.Cypher);
            return (proposal[(int)LineIndexes.Drinks][position_Cypher] == (int) Drinks.Rum);
        }

        internal static bool Check_PythonDev_drinks_Wine(int[][] proposal)
        {
            int position_pythonDev = FindPosition(proposal, (int)LineIndexes.DevDomains, (int)DevDomain.Python);
            return (proposal[(int)LineIndexes.Drinks][position_pythonDev] == (int)Drinks.Wine);
        }

        internal static bool Check_Person_Middle_Drinks_Beer(int[][] proposal)
        {
            return (proposal[(int)LineIndexes.Drinks][2] == (int) Drinks.Beer);
        }

        internal static bool Check_Apoc_Is_MobileDev(int[][] proposal)
        {
            int position_Apoc = FindPosition(proposal, (int)LineIndexes.Names, (int)Names.Apoc);
            return (proposal[(int)LineIndexes.DevDomains][position_Apoc] == (int)DevDomain.Mobile);
        }



        internal static int FindPosition(int[][] proposal, int lineIndex, int value)
        {

            for (int i = 0; i < 5; i++)
            {
                if (proposal[lineIndex][i] == value)
                    return i;
            }

            throw new AlgorithmException($"Value not found: {value}");
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class AlgorithmException : Exception
    {
        public AlgorithmException()
        {
        }

        public AlgorithmException(string message) : base(message) { }

        public AlgorithmException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlgorithmException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
