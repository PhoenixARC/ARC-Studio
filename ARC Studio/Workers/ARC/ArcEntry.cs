using System;

namespace ARC_Studio.Workers.ARC
{
	public class ArcEntry
	{
		public ArcEntry()
		{
			
		}

		public ArcEntry(string name, int size, int pos)
		{
			
			string_0 = name;
			int_0 = size;
			int_1 = pos;
		}

		public string Name
		{
			get
			{
				return string_0;
			}
			set
			{
				string_0 = value;
			}
		}

		public int Size
		{
			get
			{
				return int_0;
			}
			set
			{
				int_0 = value;
			}
		}

		public int Pos
		{
			get
			{
				return int_1;
			}
			set
			{
				int_1 = value;
			}
		}

		private string string_0;

		private int int_0;

		private int int_1;
	}
}
