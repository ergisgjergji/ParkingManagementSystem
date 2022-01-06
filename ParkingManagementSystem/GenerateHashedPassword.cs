using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagementSystem
{
	static class GenerateHashedPassword
	{
		public static string Generate256Hash(string input)
		{
			string salt = "HF3HG49SMB8PE9XE210AV";
			byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
			SHA256Managed hasher = new SHA256Managed();

			// Array of bytes
			byte[] hash = hasher.ComputeHash(bytes);

			// Convert the array of bytes to a string
			return ByteArrayToString(hash);
		}

		private static string ByteArrayToString(byte[] ba)
		{
			StringBuilder hex = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
				hex.AppendFormat("{0:x2}", b);
			return hex.ToString();
		}
	}
}
