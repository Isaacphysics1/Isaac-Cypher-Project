using Cypher.Fitness;
using System;

namespace Cypher.Cyphers
{
    class Affine
    {
        CypherTools Tools;
        public Affine(string Letters, bool Spaces)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);            
        }
        public string RunE(string Text,int Key1,int Key2)//run encode
        {
            Text = Tools.PrepText(Text);//prep text
            if (Tools.Coprime(Key1, Tools.Alphabet.Length))//is key1 coprime to number of letters givven in alphabet
            {
                string output = "";
                foreach (char letter in Text)
                {
                    if (Char.IsWhiteSpace(letter)) { output += " "; }//if space keep it as a space
                    else
                    {
                        int charNum = Array.IndexOf(Tools.Alphabet, letter);//get pos in alphabet of letter
                        charNum = (((charNum) * Key1) + Key2) % Tools.Alphabet.Length;//get new letter value
                        output += Tools.Alphabet[charNum];//get new letter
                    }                    
                }
                return output;
            }
            else
            {
                throw new ArgumentException(Key1+" is not coprime to "+ Tools.Alphabet.Length);//throw argument exeption
            }
        }
        public string RunD(string Text, int Key1, int Key2)//run decypher
        {
            Text = Tools.PrepText(Text);//prep text
            if (Tools.Coprime(Key1, Tools.Alphabet.Length))//is key1 coprime to number of letters givven in alphabet
            {
                int mulInverse = Tools.MultiplicativeInverse(Key1);//get the multiplitciative inverse of key 1
                string output = "";
                foreach (char letter in Text)
                {
                    if (Char.IsWhiteSpace(letter)) { output += " "; }//kepp spaces if they our there
                    else
                    {
                        int charNum = Array.IndexOf(Tools.Alphabet, letter);//get pos of letter in alphatbet
                        if (charNum - Key2 < 0) charNum += Tools.Alphabet.Length;//if it will be negative make number one order bigger so it dose not become negavive
                        charNum = (mulInverse * (charNum - Key2))% Tools.Alphabet.Length;//calculate new pos
                        output += Tools.Alphabet[charNum];//append letter to output
                    }
                }
                return output;
            }
            else
            {
                throw new ArgumentException(Key1 + " is not coprime to " + Tools.Alphabet.Length);//throws argument acception if not coprime
            }
        }
        public void Decypher(string Text, ref FitScore fit, out int key1, out int key2, out double Fitness)//works out the key used for a piece of text
        {
            //gives the keys inital values
            key1 = -1;
            key2 = -1;
            Fitness = Double.MinValue;//set Fitness to min value so if aannything is bigger it overides
            for (int K2 = 0; K2 < Tools.Alphabet.Length; K2++)//loop through all posible key2
            {
                for (int K1 = 0; K1 < Tools.Alphabet.Length; K1++)//loop through all key1
                {
                    if (Tools.Coprime(K1, Tools.Alphabet.Length))//checks if the key is posible
                    {
                        string outText = RunD(Text,K1,K2);//Runs decode
                        double fitness = fit.TestFit(outText);//tests fitness of decoded text
                        if (Fitness < fitness)//if output better than previous best set it to the best
                        {
                            //set values to be the best values
                            Fitness = fitness;
                            key1 = K1;
                            key2 = K2;
                        }
                    }
                    else { continue; }//moves on to next key if curent is not possible
                }     
            }
        }
    }
}
