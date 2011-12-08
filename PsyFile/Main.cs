using System;

namespace PsyFile
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string filepath = "/home/neil/Desktop/test.psy";
			PsyFile psyfile = new PsyFile();
			PsyReader reader = new PsyReader(filepath, psyfile);
			PsyWriter writer = new PsyWriter(reader.Psyfile);	
			Console.WriteLine(writer.ToString());
		}
	}
}