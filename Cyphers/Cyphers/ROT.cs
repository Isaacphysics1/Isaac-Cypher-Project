using System;
using Cypher.Fitness;

namespace Cypher.Cyphers
{
    class ROT
    {
        CypherTools Tools;
        public ROT(string Letters,bool Spaces)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);
        }
        public string RunE(string Text,int key)//runs encode
        {
            Text = Tools.PrepText(Text);//preps text
            string CodedText = "";
            for (int position = 0; position < Text.Length; position++)
            {
                if (Char.IsWhiteSpace(Text[position]))  {CodedText += " ";}//if spaces keep spaces
                else
                {
                    byte Position = (byte)Array.IndexOf(Tools.Alphabet, Text[position]);//get position in alphabet of letter
                    Position = (byte)((Position + key) % Tools.Alphabet.Length);//shift letter
                    CodedText += Tools.Alphabet[Position];//add shifted letter to output
                }                
            }
            return CodedText;
        }
        public string RunD(string Text, int key)//runs decode
        {
            Text = Tools.PrepText(Text);//preps text
            key = Tools.Alphabet.Length - key;//works out inverse key (Shift all the way back so a=a)
            return RunE(Text, key);//run encode with inverse key
        }
        public void Decypher(string Text,ref FitScore fit,out int key,out double MaxFit)//Works out the key of a piece of cypher text
        {
            int cycles = Tools.Alphabet.Length;//Number Of trys needed to try every shift
            MaxFit = double.MinValue;//set the value to the min so when we gat a bigger number it opverides this one
            key = -1;//the key that gave us the max value
            for (int i = 1; i <= cycles; i++)
            {
                string outText = RunD(Text, i);//Runs decode
                double fitness = fit.TestFit(outText);//tests fitness of decoded text
                if (MaxFit < fitness)//if output better than previous best set it to the best
                {
                    //set new best to the best
                    MaxFit = fitness;
                    key = i;
                }                
            }
        }
    }
}
