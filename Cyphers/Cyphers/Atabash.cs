using System;
using Cypher.Fitness;

namespace Cypher.Cyphers
{
    class Atabash
    {
        CypherTools Tools;
        public Atabash(string Letters, bool Spaces)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);
        }
        public string Run(string Text)//Run Cypher
        {
            Text = Tools.PrepText(Text);
            string CodedText = "";//create empty string to store output
            for (int i = 0; i < Text.Length; i++)//loop through all letters
            {
                if (Char.IsWhiteSpace(Text[i])) { CodedText += " "; }//if you want to keep spaces add them when they appear
                else
                {
                    byte Pos = (byte)Array.IndexOf(Tools.Alphabet, Text[i]);//get the position in the alphabet of charicter
                    Pos = (byte)((Tools.Alphabet.Length - 1) - Pos);//miror number to other side of alpabet eg/ a=z
                    CodedText += Tools.Alphabet[Pos];//add the charicter to the output
                }
            }
            return CodedText;
        }
        public void Decypher(string Text, ref FitScore fit, out double Fit)
        {
            string outText = Run(Text);//get decyphered text
            Fit = fit.TestFit(outText);//Calculate fitness of decyphered text
        }
    }
}
