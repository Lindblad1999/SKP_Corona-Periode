using System;
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
	}

}
