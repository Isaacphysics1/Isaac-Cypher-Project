using System;
using System.Text.RegularExpressions;

namespace Cypher.Cyphers
{
    class Baconian
    {
        CypherTools Tools;
        char[] ls1;
        char[] ls2;
        public Baconian(string Letters, bool Spaces,string letterSwap1, string letterSwap2)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);
            ls1 = letterSwap1.ToLower().ToCharArray();
            ls2 = letterSwap2.ToLower().ToCharArray();
        }
        public string RunE(string Text)
        {
            Text = Tools.PrepText(Text);
            Text = Text.Replace(ls1[1], ls1[0]);
            Text = Text.Replace(ls2[1], ls2[0]);

            string output = "";
            foreach (char letter in Text)
            {
                if (Char.IsWhiteSpace(letter)) { output += " "; } 
                else{
                    int index = Array.IndexOf(Tools.Alphabet, letter);
                    string binary = Convert.ToString(index, 2);
                    binary = binary.Replace("0", "a");
                    binary = binary.Replace("1", "b");
                    binary = binary.PadLeft(5, 'a');
                    binary = binary.Substring(binary.Length - 5, 5);
                    output += binary;
                }    
            }
            return output;            
        }
        public string RunD(string Text)
        {
            Text = Text.ToLower();//make sure upper case
            Regex rgx = new Regex("[^ab]");//Create Regex to remove unwanted letters
            Text = rgx.Replace(Text, "");//Remove unwanted letters
            string output = "";
            if (Text.Length%5 != 0) { throw new ArgumentException("Text is not a multiple of 5"); }
            for (int i = 0; i< Text.Length / 5; i++)
            {
                string binary = Text.Substring(i * 5, 5);
                binary = binary.Replace("a", "0");
                binary = binary.Replace("b", "1");
                output += Tools.Alphabet[Convert.ToInt32(binary, 2)];
            }
            return output;
        }
    }
}
