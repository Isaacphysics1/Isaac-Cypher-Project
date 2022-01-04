using System;
using System.Linq;

namespace Cypher.Cyphers
{
    class Polybius
    {
        CypherTools Tools;
        char[] ls;
        int SideLen;
        char[] letterSides;
        public Polybius(string Letters, bool Spaces,int SideLen,string CypherCharicters, string letterSwap)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);
            ls = letterSwap.ToLower().ToCharArray();
            this.SideLen = SideLen;
            letterSides = CypherCharicters.ToCharArray();
        }
        public string RunE(string Text, string key)
        {
            Text = Tools.PrepText(Text);
            //makes sure text only contains letters from alphabet and makes sure alphabet is correct lentgh
            if (Tools.Alphabet.Length == 25)
            {
                Text = Text.Replace(ls[1], ls[0]);
            }else if (Tools.Alphabet.Length != 36)
            {
                throw new Exception("Curently only supports alphgabets lenth 25 and 36");
            }
            //Makes sure key is valid
            char[] noDupe = key.ToCharArray().Distinct().ToArray();
            if (Tools.Alphabet.Length != key.Length)
            {
                throw new ArgumentException("Key must be same length as alphabet");
            }else if (noDupe.Length != Tools.Alphabet.Length)
            {
                throw new ArgumentException("Key must not have repeating charicters");
            }
            
            char[][] keysquere = new char[SideLen][];
            for (int row = 0; row < SideLen; row++)
            {
                keysquere[row] = key.Substring(row * 5, SideLen).ToCharArray();
            }
            string output = "";
            foreach (char letter in Text)
            {
                int r = 0;
                int c = 0;
                foreach (char[] row in keysquere)
                {
                    if (row.Contains(letter))
                    {
                        c = Array.IndexOf(row, letter);
                        break;
                    }
                    r++;
                }                
                output += new string(new char[] { letterSides[r], letterSides[c] }); 
            }
            return output;
        }
        public string RunD(string Text, string key)
        {
            Text = Tools.PrepText(Text);
            //makes sure alphabet is correct lentgh
            if (Tools.Alphabet.Length != 36 && Tools.Alphabet.Length != 25)
            {
                throw new Exception("Curently only supports alphgabets lenth 25 and 36");
            }
            //Makes sure key is valid
            if (!Tools.validateKey(key))
            {
                throw new ArgumentException("Given Key Is Not Valid");
            }

            char[][] keysquere = new char[SideLen][];
            for (int row = 0; row < SideLen; row++)
            {
                keysquere[row] = key.Substring(row * 5, SideLen).ToCharArray();
            }
            string output = "";
            for (int pos = 0; pos < Text.Length; pos += 2)
            {
                char[] subText = Text.Substring(pos, 2).ToCharArray();
                int r = Array.IndexOf(letterSides, subText[0]);
                int c = Array.IndexOf(letterSides, subText[1]);
                output += keysquere[r][c];
            }
            return output;
        }
    }
}
