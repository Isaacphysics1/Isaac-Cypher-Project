using System;
using System.Collections.Generic;
using System.Text;

namespace Cyphers
{
    public class CypherCall
    {
        string Name;
        Func<string, object[]> Encode;
        Func<string, object[]> Decode;
        Func<object[], object[]> Decypher;
        public CypherCall(string Name, Func<string, object[]> Encode, Func<string, object[]> Decode, Func<object[], object[]> Decypher)
        {
            this.Name = Name;
            this.Encode = Encode;
            this.Decode = Decode;
            this.Decypher = Decypher;
        }
    }
}
