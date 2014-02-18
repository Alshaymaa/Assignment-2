using System;

namespace SpellChecker
{
	class MainClass
	{ 
		public static string[] ReadDictionary(string filename){
			string input;
			System.IO.StreamReader file;
			file = new System.IO.StreamReader (filename);
			input = file.ReadLine ();
			int N;
			N = int.Parse (input);
			string[] dictionary = new string[N];
			int i = 0;
			input = file.ReadLine ();
			while (input!=null) {
				dictionary [i] = input;
				i = i + 1;
				input = file.ReadLine ();
			}
			Console.WriteLine (dictionary [0]);
			Console.WriteLine (dictionary [N - 1]);

			file.Close ();
			return dictionary;
		}
		static bool IsSpelledCorrectly(string word , string[] dictionary){
			int left, right, mid,count=0;
			left = 0;
			right = dictionary.Length - 1;
			while(left<=right){
				count = count + 1;
				mid = (left + right) / 2;
				if (word == dictionary [mid])
					return true;
				else if (word.CompareTo(dictionary [mid])<0)
					right = mid - 1;
				else 
					left = mid + 1;
			}
			return false;
		}

		public static void Main (string[] args)
		{   string[] dictionary;
			string word;
			Console.WriteLine ("** Welcome to Spell Checker **");
			Console.WriteLine ();
			dictionary = ReadDictionary ("dictionary.txt");
			Console.Write
				("Enter a word: ");
			word = Console.ReadLine ();
			while (word!="") {
				if (IsSpelledCorrectly(word,dictionary))
					Console.WriteLine ("Correct spelling!");
				else 
					Console.WriteLine ("Incorrect spelling...");
				Console.Write("Enter a word: ");
				word = Console.ReadLine ();
			}
			Console.WriteLine ();
			Console.WriteLine ("** Bye **");






	
		}
	}
}
