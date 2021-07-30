﻿using System;
using System.Text;

namespace SystemLosowania
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = { "Robert", "Mleczko", "robi", "doktorat", "ze",
                "sztuki", "a", "ja", "mam", "tylko","magistra","może","też","kiedyś","zrobię",
                "fajnie","by","było" ,"życie","jest","nobelon"
                ,"raz","przyjazne","a raz", "wrogon"
            };
            RandomText text = new RandomText(words);
            text.AddContentParagraphs(2, 2, 4, 5, 12);
            string content = text.Content;
            Console.WriteLine(content);
            Console.ReadLine();
        }
    }
    public class RandomText
    {
        static Random _random = new Random();
        StringBuilder _builder;
        string[] _words;

        public RandomText(string[] words)
        {
            _builder = new StringBuilder();
            _words = words;
        }

        public void AddContentParagraphs(int numberParagraphs, int minSentences,
            int maxSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberParagraphs; i++)
            {
                AddParagraph(_random.Next(minSentences, maxSentences + 1),
                    minWords, maxWords);
                _builder.Append("\n\n");
            }
        }

        void AddParagraph(int numberSentences, int minWords, int maxWords)
        {
            for (int i = 0; i < numberSentences; i++)
            {
                int count = _random.Next(minWords, maxWords + 1);
                AddSentence(count);
            }
        }

        void AddSentence(int numberWords)
        {
            StringBuilder b = new StringBuilder();
            // Add n words together.
            for (int i = 0; i < numberWords; i++) // Number of words
            {
                b.Append(_words[_random.Next(_words.Length)]).Append(" ");
            }
            string sentence = b.ToString().Trim() + ". ";
            // Uppercase sentence
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);
            // Add this sentence to the class
            _builder.Append(sentence);
        }
        public string Content
        {
            get
            {
                return _builder.ToString();
            }
        }
    }
}
