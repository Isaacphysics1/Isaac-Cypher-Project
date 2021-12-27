using Cypher.Fitness;
using System.Collections.Generic;
using System.Linq;

namespace Cypher.Cyphers
{
    class RailFence
    {
        CypherTools Tools;
        public RailFence(string Letters)
        {
            Tools = new CypherTools(Letters, false);
        }
        public string RunE(string Text, int key)//runs Encode
        {
            Text = Tools.PrepText(Text);//preps text by removing extra charicters
            //creates the lists to store the letters for each row and puts them in an array called Rows
            List<char>[] Rows = new List<char>[key];
            for (int i = 0; i < key; i++) 
            {
                Rows[i] = new List<char>();
            }

            int currentLine = 0;//Line We our on
            int direction = 1;//Direction the Writer will move next(1 down row, -1 up row)
            for (int i = 0; i < Text.Length; i++)
            {
                Rows[currentLine].Add(Text[i]);//adds the next charicter to the apropriate line
                direction = CheckDirection(currentLine, key, direction);//checks wheter we need to change direction
                currentLine += direction;//moves to the next line in the apropriate direction
            }
            //gets reads all of the charicters in the rows and adds them to CodedText
            string CodedText = "";
            foreach (List<char> row in Rows)
            {
                foreach (char letter in row){CodedText += letter;}
            }
            return CodedText;
        }
        public string RunD(string Text, int key)//runs Decode
        {
            Text = Tools.PrepText(Text);//preps text by removing extra charicters
            int[] RowLens = RowLengths(Text, key);//Runs a similar process to encode but insted records the number of charicters needed to be on each line
            char[][] Rows = new char[key][];//create an array of chars for each row

            int position = 0;//current position in cypher text
            for (int row = 0; row < key; row++)//for each row
            {
                int length = RowLens[row];//get lenth from array of lens for each row
                Rows[row] = Text.Substring(position, length).ToCharArray();//get substing from cypher text as array of chars
                position += length;//move position by the lenth of the row
            }

            int currentLine = 0;//curent line we our reading from
            int direction = 1;//(1 down row, -1 up row)
            int[] CurentPosOnLine = Enumerable.Repeat(0, key).ToArray();//creates an array to store the curent pos on each line we our reading from
            string CodedText = "";
            for (int i = 0; i < Text.Length; i++)
            {
                CodedText += Rows[currentLine][CurentPosOnLine[currentLine]];//adds the correct letter from the position we our looking at to the output text
                CurentPosOnLine[currentLine]++;
                direction = CheckDirection(currentLine, key, direction);//do we need to change direction
                currentLine += direction;//moves in specified direction
            }
            return CodedText;
        }
        public void Decypher(string Text, ref FitScore fit, out int key, out double Fitness)
        {
            double maxFit = double.MinValue;
            int maxkey = -1;
            for (int i = 2; i <= Text.Length; i++)
            {
                string outText = RunD(Text, i);//Runs decode
                double fitness = fit.TestFit(outText);//tests fitness of decoded text
                if (maxFit < fitness)//if output better than previous best set it to the best
                {
                    maxFit = fitness;
                    maxkey = i;
                }
            }
            key = maxkey;
            Fitness = maxFit;
        }
        private int[] RowLengths(string Text, int key)//calculates the length of each row(similar to encode)
        {
            int[] linesLenght = Enumerable.Repeat(0, key).ToArray();//array with length of each row

            int currentLine = 0;
            int direction = 1;

            for (int i = 0; i < Text.Length; i++)
            {
                linesLenght[currentLine]++;

                if (currentLine == 0)
                    direction = 1;
                else if (currentLine == key - 1)
                    direction = -1;

                currentLine += direction;
            }
            return linesLenght;
        }
        private int CheckDirection(int line,int key, int dir)//Checks if we need to change direction
        {
            if (line == 0)//if at tpp
                dir = 1;
            else if (line == key - 1)//if at bottom
                dir = -1;
            return dir;
        }
    }
}
