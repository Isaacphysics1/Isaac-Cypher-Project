using System;

namespace Cypher.Cyphers
{
    class Substitution
    {
        CypherTools Tools;
        public Substitution(string Letters, bool Spaces)//Settings for cypher
        {
            Tools = new CypherTools(Letters, Spaces);
        }
        public string RunE(string Text,string Key)
        {
            Text = Tools.PrepText(Text);
            Key = Key.ToLower();
            char[] KeyAlph = Key.ToCharArray();
            if (!Tools.validateKey(Key))
            {
                throw new ArgumentException("Given Key Is Not Valid");
            }
            string Output = "";
            foreach (char letter in Text)
            {
                Output += KeyAlph[Array.IndexOf(Tools.Alphabet, letter)];
            }
            return Output;
        }
        public string RunD(string Text, string Key)
        {
            Text = Tools.PrepText(Text);
            Key = Key.ToLower();
            char[] KeyAlph = Key.ToCharArray();
            if (!Tools.validateKey(Key))
            {
                throw new ArgumentException("Given Key Is Not Valid");
            }
            string Output = "";
            foreach (char letter in Text)
            {
                Output += Tools.Alphabet[Array.IndexOf(KeyAlph, letter)];
            }
            return Output;
        }
    }
}
