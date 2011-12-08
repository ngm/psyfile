using System;

namespace PsyFile
{
	public class PsyWriter
	{
		protected PsyFile PsyFile;
		
		public PsyWriter(PsyFile psyfile)
		{
			this.PsyFile = psyfile;
		}
		
		
		public override string ToString ()
		{
			return string.Format(@"
[PsyWriter]
PsyVersion: {0}
Song Name: {1}
Artist: {2}
Comments: {3}
",
				PsyFile.PsyVersion,
				PsyFile.Title,
				PsyFile.Artist,
				PsyFile.Comments
			);
		}
	}
}
