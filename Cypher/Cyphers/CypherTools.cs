using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cypher.Cyphers
{
    public class CypherTools
    {
        public char[] Alphabet { get; set; }
        string Letters;
        bool Spaces;
        public CypherTools(string Letters, bool Spaces)//takes settings
        {
            Alphabet = Letters.ToCharArray();
            this.Letters = Letters;
            this.Spaces = Spaces;
        }

        public String PrepText(string Text) {
            Text = Text.ToLower();//make sure upper case
            Regex rgx;
            if (Spaces) rgx = new Regex("[^" + Letters + " ]");//Create Regex to remove unwanted letters
            else rgx = new Regex("[^" + Letters + "]");//Create Regex to remove unwanted letters
            Text = rgx.Replace(Text, "");//Remove unwanted letters
            return Text;
        }
        public bool Coprime(int value1, int value2)//Works out if a number is coprime. eg/ has no common factors 
        {
            while (value1 != 0 && value2 != 0)
            {
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;
            }
            return Math.Max(value1, value2) == 1;
        }
        public int MultiplicativeInverse(int a)
        {
            for (int x = 1; x <= Alphabet.Length; x++)
            {
                if ((a * x) % 26 == 1)
                    return x;
            }

            throw new Exception("No multiplicative inverse found!");
        }
    }
}
