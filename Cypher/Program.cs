using System;

namespace Cypher
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Cypher\Fitness\english_trigrams.txt",3);
            Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Cypher\Fitness\english_quadgrams.txt", 4);
            //Fitness.FitScore fit = new Fitness.FitScore(@"D:\Isaac Programing\Cypher\Cypher\Cypher\Fitness\english_quintgrams.txt",5);

            //Rotation cypher
            //Cyphers.ROT rot = new Cyphers.ROT("abcdefghijklmnopqrstuvwxyz0123456789",true);
            //string CypherText = rot.run(17, "");
            //rot.Decypher(CypherText, ref fit, out int key, out double Fitness);

            //Atabash (Miror Cypher) a=z,z=a
            //Cyphers.Atabash ata = new Cyphers.Atabash("abcdefghijklmnopqrstuvwxyz",false);
            //string CypherText = ata.run("Hello World");
            //ata.Decypher(CypherText, ref fit, out double Fitness);


        }
    }
}
