using System;

namespace PsyFile
{
	public class PsyFile
	{
		public string PsyVersion { get; set; }
		public int ChunkVersion { get; set; }	
		public int Size { get; set; }
		public int ChunkCount { get; set; }
		
		// Song Basic Info 
		public string Title { get; set; }
		public string Artist { get; set; }
		public string Comments { get; set; }
		
		
		public PsyFile ()
		{
		}
		
		public override string ToString ()
		{
			return string.Format ("[Psyfile: PsyVersion={0}, ChunkVersion={1}, Size={2}, ChunkCount={3}, Title={4}, Artist={5}, Comments={6}]", PsyVersion, ChunkVersion, Size, ChunkCount, Title, Artist, Comments);
		}
	}
}

