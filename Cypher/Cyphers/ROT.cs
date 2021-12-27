using System;
using Cypher.Fitness;

namespace Cypher.Cyphers
{
    class ROT
    {
        CypherTools Tools;
        public ROT(string Letters,bool Spaces)
        {
            Tools = new CypherTools(Letters, Spaces);
        }
        public string RunE(string Text,int key)//runs encode
        {
            Text = Tools.PrepText(Text);
            string CodedText = "";
            for (int position = 0; position < Text.Length; position++)
            {
                if (Char.IsWhiteSpace(Text[position]))  {CodedText += " ";}
                else
                {
                    byte Position = (byte)Array.IndexOf(Tools.Alphabet, Text[position]);
                    Position = (byte)((Position + key) % Tools.Alphabet.Length);
                    CodedText += Tools.Alphabet[Position];
                }                
            }
            return CodedText;
        }
        public string RunD(string Text, int key)
        {
            Text = Tools.PrepText(Text);
            key = 36 - key;
            return RunE(Text, key);
        }
        public void Decypher(string Text,ref FitScore fit,out int key,out double MaxFit)//Works out the key of a piece of cypher text
        {
            int cycles = Tools.Alphabet.Length;//Number Of trys needed to try every shift
            double maxFit = double.MinValue;//set the value to the min so when we gat a bigger number it opverides this one
            int maxkey = 0;//the key that gave us the max value
            for (int i = 0; i < cycles; i++)
            {
                string outText = RunD(Text, (i + 1));//Runs decode
                double fitness = fit.TestFit(outText);//tests fitness of decoded text
                if (maxFit < fitness)//if output better than previous best set it to the best
                {
                    maxFit = fitness;
                    maxkey = i + 1;
                }                
            }
            key = maxkey;
            MaxFit = maxFit;
        }
    }
}
