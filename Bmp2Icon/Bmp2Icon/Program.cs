using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Bmp2Icon
{
	class Program
	{
		static void Main(string[] args)
		{
			if ((args.Length != 1) || (args[0].ToLower() == "h")) {
				ShowHelp();
				return;
			}

			if ((!args[0].ToLower().EndsWith(".bmp")) &&
                (!args[0].ToLower().EndsWith(".jpg")) &&
                (!args[0].ToLower().EndsWith(".png")))
			{
				Console.WriteLine("Error: File must be a bitmap, jpeg or png.");
				ShowHelp();
				return;
			}

			if (!File.Exists(args[0]))
			{
				Console.WriteLine(String.Format("Error: File '{0}' was not found.\n", args[0]));
				return;
			}

			try
			{
				String destFile = args[0].Substring(0, args[0].Length - 4) + ".ico";
				Bitmap bmp = new Bitmap(args[0]);
				IntPtr hIcon = bmp.GetHicon();
				Icon ico = Icon.FromHandle(hIcon);
				FileStream fs = new FileStream(destFile, FileMode.OpenOrCreate);
				ico.Save(fs);
				fs.Close();
				Console.WriteLine(String.Format("Saved icon as '{0}'.\n", destFile));
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error creating icon. " + ex.Message);
			}
			
		}

		static private void ShowHelp()
		{
			Console.WriteLine("Bmp2Icon - Created by Nick Adams (c) Feb 2011");
			Console.WriteLine("\nUSAGE:");
			Console.WriteLine("Bmp2Icon - [FileName]");
			Console.WriteLine("  h    Show this help.");
		}
		
	}
}
