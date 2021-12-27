using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cypher.Fitness
{
    class FitScore
    {
        int keyLen;
        double floor;
        public Dictionary<String, double> ngrams = new Dictionary<String, double>();
        public FitScore(string FilePath,int keyLen)
        {
            this.keyLen = keyLen;
            //@"D:\Isaac Programing\Cypher\Cypher\Fitness\english_quintgrams.txt"
            string[] lines = System.IO.File.ReadAllLines(FilePath);
            long Total = 0;
            foreach (string line in lines)
            {
                string[] LineSplit = line.Split(" ");
                ngrams.Add(LineSplit[0], double.Parse(LineSplit[1]));
                Total += int.Parse(LineSplit[1]);
            }
            Dictionary<String, double> tempNgrams = new Dictionary<String, double>();
            foreach (string key in ngrams.Keys)
            {
                tempNgrams.Add(key,Math.Log10(ngrams[key] / Total));
            }
            floor = Math.Log10(0.01 / Total);
            ngrams = tempNgrams;
            Console.WriteLine("Complete");
        }
        public double TestFit(string Text)
        {
            Text = Text.ToLower();
            Regex rgx = new Regex("[^a-z]");
            Text = rgx.Replace(Text, "");
            double score = 0;
            for (int i = 0; i < Text.Length-keyLen; i++)
            {
                string ngram = Text.Substring(i, keyLen);
                double logprob;
                if (ngrams.ContainsKey(ngram.ToUpper()))
                {
                    logprob = ngrams[ngram.ToUpper()];
                }
                else
                {
                    logprob = floor;
                }                
                score += logprob;
            }
            score /= Text.Length - keyLen;
            return score;
        }
               

    }
}
