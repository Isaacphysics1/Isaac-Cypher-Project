using System;

namespace Cypher
{
    public class Program
    {
        static void Main()
        {
            //Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Fitness\english_trigrams.txt",3);//Better for shorter Text
            Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Fitness\english_quadgrams.txt", 4);
            //Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Fitness\english_quintgrams.txt",5);//Most accurate for long text

            //Rotation cypher
            //Cyphers.ROT rot = new Cyphers.ROT("abcdefghijklmnopqrstuvwxyz0123456789",true);
            //string CypherText = rot.RunE("Hello World",36);
            //rot.Decypher(CypherText, ref fit, out int key, out double Fitness);

            //Atabash (Miror Cypher) a=z,z=a
            //Cyphers.Atabash ata = new Cyphers.Atabash("abcdefghijklmnopqrstuvwxyz",false);
            //string CypherText = ata.Run("Hello World");
            //ata.Decypher(CypherText, ref fit, out double Fitness);

            //Affine (key1 must be coprime to number of letters in alpabet)
            //Cyphers.Affine aff = new Cyphers.Affine("abcdefghijklmnopqrstuvwxyz", true);
            //string CypherText = aff.RunE("hello world",17,10);
            //aff.Decypher(CypherText, ref fit, out int key1, out int key2, out double Fitness);

            //Rail Fence
            //Cyphers.RailFence rail = new Cyphers.RailFence("abcdefghijklmnopqrstuvwxyz");
            //string CypherText = rail.RunE("Hello World", 7);
            //rail.Decypher(CypherText, ref fit, out int key, out double Fitness);
            //Console.WriteLine(key);

            //Baconian
            //Cyphers.Baconian bac = new Cyphers.Baconian("abcdefghiklmnopqrstuwxyz",false,"ij","uv");
            //string CypherText = bac.RunE("Hello World");
            //CypherText = bac.RunD(CypherText);
            //Console.WriteLine(CypherText);

            //Polybius
            //Cyphers.Polybius pol = new Cyphers.Polybius("abcdefghiklmnopqrstuvwxyz", false, 5, "abcde", "ij");
            //string CypherText = pol.RunE("helloworld", "bvcrfgpxlnmyqduhiwekzasto");
            //CypherText = pol.RunD(CypherText, "bvcrfgpxlnmyqduhiwekzasto");

                     


        }
    }
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
