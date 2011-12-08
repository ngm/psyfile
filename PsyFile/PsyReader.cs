using System;
using System.IO;

namespace PsyFile
{
	public class PsyReader
	{
		public PsyFile Psyfile;
		protected string FilePath;
		protected BinaryReader Reader;
		
		public PsyReader(string filePath, PsyFile psyfile)
		{
			if (String.IsNullOrEmpty(filePath)) throw new ArgumentNullException("filePath");
			if (psyfile == null) throw new ArgumentNullException("psyfile");
			
			this.FilePath = filePath;
			this.Psyfile = psyfile;
			
			OpenPsyBinary();
			ReadPsyBinary();
		}
		
		protected void OpenPsyBinary()
		{
			if (File.Exists(FilePath))
			{
				Reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
			}
			else
			{
				throw new FileNotFoundException("Could not find file.", FilePath);	
			}
		}

		public void ReadPsyBinary()
		{
			if (Reader == null) throw new ArgumentNullException("reader");
			
			ReadFileInfo();
			
			char[] headerChars = new char[4];
			Reader.Read(headerChars, 0, 4);
			string header = new string(headerChars);
			
			if (header == "INFO")
			{
				ReadSongBasicInfo();
			}
			else
			{
				throw new Exception("Expected to read INFO header.");		
			}
		}

		void ReadFileInfo()
		{
			Psyfile.PsyVersion = ReadPsyVersion();
			Psyfile.ChunkVersion = ReadVersion();
			Psyfile.Size = ReadSize();
			Psyfile.ChunkCount = ReadChunkCount();
		}
		
		void ReadSongBasicInfo()
		{
			Reader.ReadUInt32(); // version
			Reader.ReadUInt32(); // size
			Psyfile.Title = ReadTitle();
			Psyfile.Artist = ReadArtist();
			Psyfile.Comments = ReadComments();
		}

		string ReadPsyVersion()
		{
			try
			{
				char[] chars = new char[8];
				Reader.Read(chars, 0, 8);
				return new string(chars);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int ReadVersion()
		{
			try
			{
				return (int)Reader.ReadUInt32();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		public int ReadSize()
		{
			try
			{
				return (int)Reader.ReadUInt32();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		public int ReadChunkCount()
		{
			try
			{
				return Reader.ReadInt32();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		string ReadTitle()
		{
			try
			{
				char[] titleChars = new char[128];
				for (int i = 0; i < 128 && Reader.PeekChar() != 0; i++)
				{
					titleChars[i] = Reader.ReadChar();
				}
				Reader.ReadChar(); // To get pass the null terminator.
				return new string(titleChars);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		string ReadArtist()
		{
			try
			{
				char[] artistChars = new char[64];
				for (int i = 0; i < 64 && Reader.PeekChar() != 0; i++)
				{
					artistChars[i] = Reader.ReadChar();
				}
				Reader.ReadChar();
				return new string(artistChars);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		string ReadComments()
		{
			try
			{
				char[] commentsChars = new char[65536];
				for (int i = 0; i < 65536 && Reader.PeekChar() != 0; i++)
				{
					commentsChars[i] = Reader.ReadChar();
				}
				Reader.ReadChar(); // To get past the null terminator.
				return new string(commentsChars);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}

