using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Edabit
{
    class Program
    {
        static void Main(string[] args)
        {
			SockPairs("AABBCAABCAABBBBCCAABCAA");
			MysteryFunc("a5H7r12e2S9");
			MysteryFunc(19);
			IsValidIP("1.45.322.12");
			IsPrime(13);
			gcd(1, 4);
			IsStrangePair("sparkling", "groups");
			CounterpartCharCode('g');
			SortDecending(231354552);
			IsSymmetrical(1112111);
			HighLow("1 6 -4 8 2 9 8");
			CountOnes(34);
			Maskify("4556364607935616");
			IsIsogram("Algorism");
			Console.Write(AlternatingCaps("Hej med dig"));
		}

		public static int SockPairs(string socks)
		{
			if (socks == "")
			{
				return 0;
			}
			int matchA = 0, matchB = 0, matchC = 0;
			foreach (char c in socks)
			{
				if (c == 'A')
				{
					matchA++;
				}
				else if (c == 'B')
				{
					matchB++;
				}
				else if (c == 'C')
				{
					matchC++;
				}
				else
				{
				}
			}
			int pairA, pairB, pairC;
			if (matchA % 2 != 0 && matchA > 1)
			{
				pairA = (matchA / 2);
			}
			else
			{
				pairA = (matchA / 2);
			}
			if (matchB % 2 != 0 && matchB > 1)
			{
				pairB = (matchB / 2);
			}
			else
			{
				pairB = (matchB / 2);
			}
			if (matchC % 2 != 0 && matchC > 1)
			{
				pairC = (matchC / 2);
			}
			else
			{
				pairC = (matchC / 2);
			}
			return pairA + pairB + pairC;
		}

		public static string MysteryFunc(string str)
		{
			int num;
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < str.Length; i++)
			{
				if (Int32.TryParse(str[i].ToString(), out num))
				{
					for (int c = 0; c < Convert.ToInt32(str[i].ToString()); c++)
					{
						sb.Append(str[i - 1]);
					}
				}
			}
			return sb.ToString();
		}

		public static int MysteryFunc(int num)
		{
			var result = new StringBuilder();
			int n = 1;
			while (n * 2 < num)
			{
				n *= 2;
				result.Append("2");
			}
			result.Append(num - n);

			return Convert.ToInt32(result.ToString());
		}

		public static bool IsValidIP(string IP)
		{
			Regex rx = new Regex(@"^(1|2)?[0-9]?[0-9]\.(1|2)?[0-9]?[0-9]\.(1|2)?[0-9]?[0-9]\.(1|2)?[0-9]?[0-9]$");
			if (rx.IsMatch(IP))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IsPrime(int value)
		{
			if (value <= 1) return false;
			int m = value / 2;
			for (int i = 2; i <= m; i++)
			{
				if (value % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public static int gcd(int n1, int n2)
		{
			int max, min, result = 0;
			if (n1 - n2 > 0)
			{
				max = n1;
				min = n2;
			}
			else
			{
				max = n2;
				min = n1;
			}
			for (int i = 1; i <= min; i++)
			{
				if (max % i == 0 && min % i == 0)
				{
					result = i;
				}
			}
			return result;
		}

		public static bool IsStrangePair(string str1, string str2)
		{

			int str1Length = 0, str2Length = 0;
			foreach (char c in str1)
			{
				str1Length++;
			}
			foreach (char c in str2)
			{
				str2Length++;
			}
			if (str1Length == 0 && str2Length == 0)
			{
				return true;
			}
			if (str1Length == 0 || str2Length == 0)
			{
				return false;
			}
			bool success1 = str2.EndsWith(Convert.ToString(str1[0]));
			bool success2 = str1.EndsWith(Convert.ToString(str2[0]));
			if (success1 && success2)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static int CounterpartCharCode(char symbol)
		{
			int i = symbol;
			if (char.IsLower(symbol))
			{
				i = char.ToUpper(symbol);
			}
			else
			{
				i = char.ToLower(symbol);
			}
			return i;
		}

		public static int SortDecending(int num)
		{
			char[] charArr = Convert.ToString(num).ToCharArray();
			Array.Sort(charArr);
			Array.Reverse(charArr);
			string str = new string(charArr);
			return Convert.ToInt32(str);
		}

		public static bool IsSymmetrical(int num)
		{
			StringBuilder sb = new StringBuilder();
			List<string> myList = new List<string>();

			foreach (char c in Convert.ToString(num))
			{
				myList.Add(Convert.ToString(c));
			}
			string[] arr = myList.ToArray();
			Array.Reverse(arr);
			foreach (string s in arr)
			{
				sb.Append(s);
			}
			return string.Equals(Convert.ToString(sb), Convert.ToString(num));
		}

		public static int[] CountPosSumNeg(double[] arr)
		{
			int negSum = 0, posSum = 0;
			foreach (double d in arr)
			{
				if (d > 0)
				{
					posSum++;
				}
				else if (d < 0)
				{
					negSum = negSum + Convert.ToInt32(d);
				}

			}
			int[] result = { posSum, negSum };
			return result;
		}

		public static string HighLow(string str)
		{
			int[] numbersArray = str.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
			int min = numbersArray.Min(), max = numbersArray.Max();
			return Convert.ToString(max) + " " + Convert.ToString(min);

		}

		public static int CountOnes(int i)
		{
			string binary = Convert.ToString(i, 2);
			int one = 0;
			foreach (char c in binary)
			{
				if (c == '1')
				{
					one++;
				}
			}
			return one;
		}

		public static string Maskify(string str)
		{
			StringBuilder sb = new StringBuilder();
			if (str.Length > 4)
			{
				for (int i = 0; i < str.Length - 4; i++)
				{
					sb.Append("#");
				}
				for (int i = str.Length - 4; i < str.Length; i++)
				{
					sb.Append(str[i]);
				}
				return sb.ToString();
			}
			else
			{
				return str;
			}
		}

		public static int SumSmallest(int[] values)
		{
			List<int> myList = new List<int>();
			foreach (int i in values)
			{
				if (i > 0)
				{
					myList.Add(i);
				}
			}
			int[] arr = myList.ToArray();
			Array.Sort(arr);
			int sum = arr[0] + arr[1];
			return sum;
		}

		public static bool IsIsogram(string str)
		{
			List<char> myList = new List<char>();
			foreach (char c in str)
			{
				myList.Add(Char.ToLower(c));
			}
			IEnumerable<char> distinctMyList = myList.Distinct();
			int myListCount = 0, distinctMyListCount = 0;
			foreach (char c in myList)
			{
				myListCount++;
			}
			foreach (char c in distinctMyList)
			{
				distinctMyListCount++;
			}
			if (distinctMyListCount == myListCount)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static string AlternatingCaps(string str)
		{
			string returnString = String.Empty;

			int count = 0;
			foreach (char c in str)
			{
				if(c != ' ')
				{
					if (count % 2 == 0)
						returnString += str[count].ToString().ToUpper();
					else
						returnString += str[count].ToString().ToLower();
					count++;
				}
			}

			//for (int i = 0; i < str.Length; i++)
			//{
			//	if (i % 2 == 0)
			//		returnString += str[i].ToString().ToUpper();
			//	else
			//		returnString += str[i].ToString().ToLower();
			//}
			return returnString;
		}
	}

}
