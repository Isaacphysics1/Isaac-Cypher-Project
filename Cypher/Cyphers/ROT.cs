using System;
using System.Text.RegularExpressions;
using Cypher.Fitness;
using Newtonsoft.Json;

namespace Cypher.Cyphers
{
    class ROT
    {
        char[] Alphabet;
        string Letters;
        bool Spaces;
        string space = "";
        public ROT(string Letters,bool Spaces)
        {
            this.Letters = Letters;
            Alphabet = Letters.ToCharArray();
            this.Spaces = Spaces;
            if (Spaces)//If we want to keep spaces
            {space = " ";}
        }
        public string run(int key, string Text)
        {
            Text = Text.ToLower();
            Regex rgx = new Regex("[^"+Letters+space+"]");
            Text = rgx.Replace(Text, "");
            byte[] Positions = new byte[Text.Length];
            string CodedText = "";
            for (int position = 0; position < Text.Length; position++)
            {
                if (Char.IsWhiteSpace(Text[position]))  {CodedText += " ";}
                else
                {
                    Positions[position] = (byte)Array.IndexOf(Alphabet, Text[position]);
                    Positions[position] = (byte)((Positions[position] + key) % Letters.Length);
                    CodedText += Alphabet[Positions[position]];
                }                
            }
            return CodedText;
        }
        public void Decypher(string Text,ref FitScore fit,out int key,out double MaxFit)
        {
            int cycles = Alphabet.Length;//Number Of trys needed to try every shift
            double maxFit = double.MinValue;//set the value to the min so when we gat a bigger number it opverides this one
            int maxkey = 0;//the key that gave us the max value
            for (int i = 0; i < cycles; i++)
            {
                string outText = run(i + 1, Text);
                double fitness = fit.TestFit(outText);
                if (maxFit < fitness)
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
