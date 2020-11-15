using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC_Studio.Workers.ARC
{
    class PS3ARCWorker
    {

		public void ExtractArchive(string arcPath, string workingPath)
		{
			global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list = new global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry>();
			byte[] array = global::ARC_Studio.Workers.ARC.FileUtils.smethod_0(arcPath);
			global::System.IO.MemoryStream memoryStream = null;
			if (array != null)
			{
				memoryStream = new global::System.IO.MemoryStream(array);
				int num = this.class47_0.method_4(memoryStream);
				for (int i = 0; i < num; i++)
				{
					string name = this.method_0(memoryStream);
					int pos = this.class47_0.method_4(memoryStream);
					int size = this.class47_0.method_4(memoryStream);
					ARC_Studio.Workers.ARC.ArcEntry item = new ARC_Studio.Workers.ARC.ArcEntry(name, size, pos);
					list.Add(item);
				}
			}
			this.method_1(workingPath, list, memoryStream);
		}

		private string method_0(global::System.IO.MemoryStream memoryStream_0)
		{
			byte[] array = new byte[2];
			memoryStream_0.Read(array, 0, 2);
			if (global::System.BitConverter.IsLittleEndian)
			{
				global::System.Array.Reverse(array);
			}
			short num = global::System.BitConverter.ToInt16(array, 0);
			byte[] array2 = new byte[(int)num];
			memoryStream_0.Read(array2, 0, (int)num);
			global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
			return utf.GetString(array2);
		}

		private void method_1(string string_0, global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list_0, global::System.IO.MemoryStream memoryStream_0)
		{
			foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list_0)
			{
				byte[] array = new byte[arcEntry.Size];
				memoryStream_0.Read(array, 0, arcEntry.Size);
				string text = string_0 + arcEntry.Name;
				string directoryName = global::System.IO.Path.GetDirectoryName(text);
				global::System.IO.Directory.CreateDirectory(directoryName);
				global::ARC_Studio.Workers.ARC.FileUtils.WriteFile(array, text);
			}
		}

		public void BuildArchive(string arcPath, string workingPath)
		{
			global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
			global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list = new global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry>();
			global::System.Collections.Generic.List<string> list2 = this.method_4(workingPath);
			foreach (string text in list2)
			{
				byte[] array = global::ARC_Studio.Workers.ARC.FileUtils.smethod_0(text);
				int size = array.Length;
				int pos = (int)memoryStream.Position;
				string name = text.Substring(workingPath.Length);
				memoryStream.Write(array, 0, array.Length);
				ARC_Studio.Workers.ARC.ArcEntry item = new ARC_Studio.Workers.ARC.ArcEntry(name, size, pos);
				list.Add(item);
			}
			global::System.IO.MemoryStream memoryStream2 = this.method_3(list);
			int num = (int)memoryStream2.Length;
			foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list)
			{
				arcEntry.Pos += num;
			}
			memoryStream2 = this.method_3(list);
			this.method_2(arcPath, memoryStream2, memoryStream);
		}

		private void method_2(string string_0, global::System.IO.MemoryStream memoryStream_0, global::System.IO.MemoryStream memoryStream_1)
		{
			using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(string_0, global::System.IO.FileMode.Create)))
			{
				binaryWriter.Write(memoryStream_0.ToArray());
				binaryWriter.Write(memoryStream_1.ToArray());
			}
		}

		private global::System.IO.MemoryStream method_3(global::System.Collections.Generic.List<ARC_Studio.Workers.ARC.ArcEntry> list_0)
		{
			global::Class47 @class = new global::Class47();
			global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
			@class.method_10(list_0.Count, memoryStream);
			foreach (ARC_Studio.Workers.ARC.ArcEntry arcEntry in list_0)
			{
				@class.method_12(arcEntry.Name, memoryStream);
				@class.method_10(arcEntry.Pos, memoryStream);
				@class.method_10(arcEntry.Size, memoryStream);
			}
			return memoryStream;
		}

		private global::System.Collections.Generic.List<string> method_4(string string_0)
		{
			global::System.Collections.Generic.List<string> list = new global::System.Collections.Generic.List<string>();
			foreach (string item in global::System.IO.Directory.GetFiles(string_0))
			{
				list.Add(item);
			}
			foreach (string string_ in global::System.IO.Directory.GetDirectories(string_0))
			{
				list.AddRange(this.method_4(string_));
			}
			return list;
		}

		public PS3ARCWorker()
		{
			this.class47_0 = new global::Class47();
		}

		private global::Class47 class47_0;
	}
}
