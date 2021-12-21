using System.Text.RegularExpressions;
using System;
using Cypher.Fitness;

namespace Cypher.Cyphers
{
    class Atabash
    {
        char[] Alphabet;//Array Of lettrs in alphabet
        string Letters;//String of lettes in alphbet
        bool Spaces;//Do you want spaces to be included
        string space = "";//Place holder for space value
        public Atabash(string Letters, bool Spaces)
        {
            //sets feilds
            this.Letters = Letters;
            this.Spaces = Spaces;
            //Sets alphabet to letters
            Alphabet = Letters.ToCharArray();
            
            if (Spaces){ space = " "; }//If we want to keep spaces
        }
        public string run(string Text)//Run Encode/Decode
        {
            Text = Text.ToLower();//make sure upper case
            Regex rgx = new Regex("[^"+Letters+space+"]");//Create Regex to remove unwanted letters
            Text = rgx.Replace(Text, "");//Remove unwanted letters
            string CodedText = "";//create empty string to store output
            for (int i = 0; i < Text.Length; i++)//loop through all letters
            {
                if (Char.IsWhiteSpace(Text[i])) { CodedText += " "; }//if you want to keep spaces add them when they appear
                else
                {
                    byte Pos = (byte)Array.IndexOf(Alphabet, Text[i]);//get the position in the alphabet of charicter
                    Pos = (byte)((Alphabet.Length - 1) - Pos);//miror number to other side of alpabet eg/ a=z
                    CodedText += Alphabet[Pos];//add the charicter to the output
                }
            }
            return CodedText;
        }
        public void Decypher(string Text, ref FitScore fit, out double Fit)
        {
            string outText = run(Text);//get decyphered text
            Fit = fit.TestFit(outText);//Calculate fitness of decyphered text
        }
    }
}
