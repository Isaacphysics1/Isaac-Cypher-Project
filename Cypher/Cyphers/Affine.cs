using Cypher.Fitness;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cypher.Cyphers
{
    class Affine
    {
        CypherTools Tools;
        public Affine(string Letters, bool Spaces)
        {
            Tools = new CypherTools(Letters, Spaces);            
        }
        public string RunE(string Text,int Key1,int Key2)
        {
            Text = Tools.PrepText(Text);
            if (Tools.Coprime(Key1, Tools.Alphabet.Length))
            {
                string output = "";
                foreach (char letter in Text)
                {
                    if (Char.IsWhiteSpace(letter)) { output += " "; }
                    else
                    {
                        int charNum = Array.IndexOf(Tools.Alphabet, letter);
                        charNum = (((charNum) * Key1) + Key2) % Tools.Alphabet.Length;
                        output += Tools.Alphabet[charNum];
                    }                    
                }
                return output;
            }
            else
            {
                throw new ArgumentException(Key1+" is not coprime to "+ Tools.Alphabet.Length);
            }
        }
        public string RunD(string Text, int Key1, int Key2)
        {
            Text = Tools.PrepText(Text);
            if (Tools.Coprime(Key1, Tools.Alphabet.Length))
            {
                int mulInverse = Tools.MultiplicativeInverse(Key1);
                string output = "";
                foreach (char letter in Text)
                {
                    if (Char.IsWhiteSpace(letter)) { output += " "; }
                    else
                    {
                        int charNum = Array.IndexOf(Tools.Alphabet, letter);
                        if (charNum - Key2 < 0) charNum += Tools.Alphabet.Length;
                        charNum = (mulInverse * (charNum - Key2))% Tools.Alphabet.Length;
                        output += Tools.Alphabet[charNum];
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException(Key1 + " is not coprime to " + Tools.Alphabet.Length);
            }
        }
        public void Decypher(string Text, ref FitScore fit, out int key1, out int key2, out double Fitness)
        {
            key1 = -1;
            key2 = -1;
            Fitness = Double.MinValue;
            for (int K2 = 0; K2 < Tools.Alphabet.Length; K2++)
            {
                for (int K1 = 0; K1 < Tools.Alphabet.Length; K1++)
                {
                    if (Tools.Coprime(K1, Tools.Alphabet.Length))
                    {
                        string outText = RunD(Text,K1,K2);//Runs decode
                        double fitness = fit.TestFit(outText);//tests fitness of decoded text
                        if (Fitness < fitness)//if output better than previous best set it to the best
                        {
                            Fitness = fitness;
                            key1 = K1;
                            key2 = K2;
                        }
                    }
                    else { continue; }
                }     
            }
        }
    }
}
