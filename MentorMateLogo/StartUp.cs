using System;
using System.Text;

namespace MentorMateLogo
{
    class StartUp
    {
        private static char letterSymbol = '*';
        private static char spaceSymbol = '-';
        private static StringBuilder output = new StringBuilder(); // for faster console writing

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int rows = (n / 2) + 1;

            DrawFirstPart(n, rows);
            DrawSecondPart(n, rows);

            Console.WriteLine(output);
        }

        private static void DrawFirstPart(int n, int rows)
        {
            int spaceSymbolsCount = n;
            int insideSpaceSymbolsCount = n;
            int letterSymbolsCount = n;

            StringBuilder sbRow;
            for (int i = 0; i < rows; i++)
            {
                bool useInsideSpaceSymbols = false;
                sbRow = new StringBuilder();

                for (int j = 0; j < 5; j++)
                {
                    if (j % 2 != 0)
                    {
                        sbRow.Append(new string(letterSymbol, letterSymbolsCount));
                    }
                    else
                    {
                        if (useInsideSpaceSymbols)
                            sbRow.Append(new string(spaceSymbol, insideSpaceSymbolsCount));
                        else
                            sbRow.Append(new string(spaceSymbol, spaceSymbolsCount));

                        useInsideSpaceSymbols = !useInsideSpaceSymbols;
                    }
                }

                output.Append(sbRow);
                output.AppendLine(sbRow.ToString());

                insideSpaceSymbolsCount -= 2;
                spaceSymbolsCount--;
                letterSymbolsCount += 2;
            }
        }

        private static void DrawSecondPart(int n, int rows)
        {
            int outsideSpaceSymbolsCount = (n - 1) / 2;
            int insideSpaceSymbolsCount = 1;

            int sideLetterSymbolsCount = n;
            int middleLetterSymbolsCount = (n * 2) - 1;

            StringBuilder sbRow;
            for (int i = 0; i < rows; i++)
            {
                sbRow = new StringBuilder();

                string outsideSpaceString = new string(spaceSymbol, outsideSpaceSymbolsCount);
                string sideLettersString = new string(letterSymbol, sideLetterSymbolsCount);                
                string insideSpaceString = new string(spaceSymbol, insideSpaceSymbolsCount);

                sbRow.Append(outsideSpaceString);
                sbRow.Append(sideLettersString);
                sbRow.Append(insideSpaceString);
                sbRow.Append(new string(letterSymbol, middleLetterSymbolsCount));
                sbRow.Append(insideSpaceString);
                sbRow.Append(sideLettersString);
                sbRow.Append(outsideSpaceString);

                output.Append(sbRow);
                output.AppendLine(sbRow.ToString());

                outsideSpaceSymbolsCount--;
                insideSpaceSymbolsCount += 2;
                middleLetterSymbolsCount -= 2;                
            }
        }

    }
}
