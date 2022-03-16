using System;
using System.IO;
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
			List<ArcEntry> list = new List<ArcEntry>();
			byte[] array = FileUtils.smethod_0(arcPath);
			MemoryStream memoryStream = null;
			if (array != null)
			{
				memoryStream = new MemoryStream(array);
				int num = ArrSupport.GetInt32(memoryStream);
				for (int i = 0; i < num; i++)
				{
					string name = method_0(memoryStream);
					int pos = ArrSupport.GetInt32(memoryStream);
					int size = ArrSupport.GetInt32(memoryStream);
					ArcEntry item = new ArcEntry(name, size, pos);
					list.Add(item);
				}
			}
			method_1(workingPath, list, memoryStream);
		}

		private string method_0(MemoryStream memoryStream_0)
		{
			byte[] array = new byte[2];
			memoryStream_0.Read(array, 0, 2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			short num = BitConverter.ToInt16(array, 0);
			byte[] array2 = new byte[(int)num];
			memoryStream_0.Read(array2, 0, (int)num);
			Encoding utf = Encoding.UTF8;
			return utf.GetString(array2);
		}

		private void method_1(string string_0, List<ArcEntry> list_0, MemoryStream memoryStream_0)
		{
			foreach (ArcEntry arcEntry in list_0)
			{
				byte[] array = new byte[arcEntry.Size];
				memoryStream_0.Read(array, 0, arcEntry.Size);
				string text = string_0 + arcEntry.Name;
				string directoryName = Path.GetDirectoryName(text);
				Directory.CreateDirectory(directoryName);
				FileUtils.WriteFile(array, text);
			}
		}

		public void BuildArchive(string arcPath, string workingPath)
		{
			MemoryStream memoryStream = new MemoryStream();
			List<ArcEntry> list = new List<ArcEntry>();
			List<string> list2 = method_4(workingPath);
			foreach (string text in list2)
			{
				byte[] array = FileUtils.smethod_0(text);
				int size = array.Length;
				int pos = (int)memoryStream.Position;
				string name = text.Substring(workingPath.Length);
				memoryStream.Write(array, 0, array.Length);
				ArcEntry item = new ArcEntry(name, size, pos);
				list.Add(item);
			}
			MemoryStream memoryStream2 = method_3(list);
			int num = (int)memoryStream2.Length;
			foreach (ArcEntry arcEntry in list)
			{
				arcEntry.Pos += num;
			}
			memoryStream2 = method_3(list);
			GetInt16(arcPath, memoryStream2, memoryStream);
		}

		private void GetInt16(string string_0, MemoryStream memoryStream_0, MemoryStream memoryStream_1)
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(string_0, FileMode.Create)))
			{
				binaryWriter.Write(memoryStream_0.ToArray());
				binaryWriter.Write(memoryStream_1.ToArray());
			}
		}

		private MemoryStream method_3(List<ArcEntry> list_0)
		{
			global::ArraySupport @class = new global::ArraySupport();
			MemoryStream memoryStream = new MemoryStream();
			@class.WriteIntToStream(list_0.Count, memoryStream);
			foreach (ArcEntry arcEntry in list_0)
			{
				@class.WriteStringToStream(arcEntry.Name, memoryStream);
				@class.WriteIntToStream(arcEntry.Pos, memoryStream);
				@class.WriteIntToStream(arcEntry.Size, memoryStream);
			}
			return memoryStream;
		}

		private List<string> method_4(string string_0)
		{
			List<string> list = new List<string>();
			foreach (string item in Directory.GetFiles(string_0))
			{
				list.Add(item);
			}
			foreach (string string_ in Directory.GetDirectories(string_0))
			{
				list.AddRange(method_4(string_));
			}
			return list;
		}

		public PS3ARCWorker()
		{
			ArrSupport = new global::ArraySupport();
		}

		private global::ArraySupport ArrSupport;
	}
}
