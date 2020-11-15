using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ARC_Studio.Workers.ARC
{
	public class FileUtils
	{
		internal static byte[] smethod_0(string string_0)
		{
			byte[] array = null;
			if (global::System.IO.File.Exists(string_0))
			{
				using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(global::System.IO.File.Open(string_0, global::System.IO.FileMode.Open)))
				{
					long length = binaryReader.BaseStream.Length;
					binaryReader.BaseStream.Seek(0L, global::System.IO.SeekOrigin.Begin);
					array = new byte[length];
					binaryReader.Read(array, 0, (int)length);
				}
			}
			return array;
		}

		internal static string smethod_1(string string_0, string string_1, string string_2, string string_3 = "")
		{
			global::System.Windows.Forms.OpenFileDialog openFileDialog = new global::System.Windows.Forms.OpenFileDialog();
			string result = null;
			string_2 = global::ARC_Studio.Workers.ARC.FileUtils.smethod_2(string_2);
			openFileDialog.DefaultExt = string_0;
			openFileDialog.Filter = string_1;
			openFileDialog.InitialDirectory = string_2;
			openFileDialog.FileName = string_3;
			global::System.Windows.Forms.DialogResult dialogResult = openFileDialog.ShowDialog();
			if (dialogResult == global::System.Windows.Forms.DialogResult.OK)
			{
				result = openFileDialog.FileName;
			}
			return result;
		}

		private static string smethod_2(string string_0)
		{
			try
			{
				if (!string.IsNullOrEmpty(string_0))
				{
					string_0 = global::System.IO.Path.GetDirectoryName(string_0);
				}
			}
			catch (global::System.Exception)
			{
			}
			return string_0;
		}

		internal static string smethod_3(string string_0, string string_1, string string_2, string string_3 = "")
		{
			global::System.Windows.Forms.SaveFileDialog saveFileDialog = new global::System.Windows.Forms.SaveFileDialog();
			string result = null;
			saveFileDialog.DefaultExt = string_0;
			saveFileDialog.Filter = string_1;
			saveFileDialog.InitialDirectory = string_2;
			saveFileDialog.FileName = string_3;
			global::System.Windows.Forms.DialogResult dialogResult = saveFileDialog.ShowDialog();
			if (dialogResult == global::System.Windows.Forms.DialogResult.OK)
			{
				result = saveFileDialog.FileName;
			}
			return result;
		}

		internal static string smethod_4(string string_0, string string_1 = "Conversion output folder")
		{
			string result = null;
			using (global::System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new global::System.Windows.Forms.FolderBrowserDialog())
			{
				folderBrowserDialog.Description = string_1;
				folderBrowserDialog.ShowNewFolderButton = true;
				folderBrowserDialog.RootFolder = global::System.Environment.SpecialFolder.MyComputer;
				folderBrowserDialog.SelectedPath = string_0;
				if (folderBrowserDialog.ShowDialog() == global::System.Windows.Forms.DialogResult.OK)
				{
					result = folderBrowserDialog.SelectedPath;
				}
			}
			return result;
		}

		internal static string smethod_5(string string_0)
		{
			string text = string_0;
			int num = text.LastIndexOf('\\');
			if (num > 0)
			{
				text = text.Substring(num + 1);
			}
			num = text.LastIndexOf('.');
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			return text;
		}

		public static void WriteFile(global::System.IO.MemoryStream stream, string filename)
		{
			using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(filename, global::System.IO.FileMode.Create)))
			{
				byte[] buffer = stream.ToArray();
				binaryWriter.Write(buffer);
			}
		}

		public static void WriteFile(byte[] bytes, string filename)
		{
			using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(filename, global::System.IO.FileMode.Create)))
			{
				binaryWriter.Write(bytes);
			}
		}

		public static short ReadShort(global::System.IO.BinaryReader reader)
		{
			byte[] array = new byte[2];
			array = reader.ReadBytes(2);
			if (global::System.BitConverter.IsLittleEndian)
			{
				global::System.Array.Reverse(array);
			}
			return global::System.BitConverter.ToInt16(array, 0);
		}

		public static byte[] ReadBytes(global::System.IO.BinaryReader reader, int fieldSize, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
		{
			byte[] array = new byte[fieldSize];
			if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.LittleEndian)
			{
				return reader.ReadBytes(fieldSize);
			}
			for (int i = fieldSize - 1; i > -1; i--)
			{
				array[i] = reader.ReadByte();
			}
			return array;
		}

		public static uint smethod_6(global::System.IO.BinaryReader reader, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
		{
			if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.LittleEndian)
			{
				return (uint)reader.ReadInt32();
			}
			return global::System.BitConverter.ToUInt32(global::ARC_Studio.Workers.ARC.FileUtils.ReadBytes(reader, 4, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.BigEndian), 0);
		}

		public static void smethod_7(global::System.IO.BinaryWriter writer, uint value, global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder byteOrder)
		{
			byte[] array = global::System.BitConverter.GetBytes(value);
			if (byteOrder == global::ARC_Studio.Workers.ARC.FileUtils.ByteOrder.BigEndian)
			{
				array = array.Reverse<byte>().ToArray<byte>();
			}
			writer.Write(array);
		}

		internal static void smethod_8(string string_0)
		{
			foreach (string path in global::System.IO.Directory.GetFiles(string_0))
			{
				global::System.IO.File.Delete(path);
			}
		}

		internal static void smethod_9(string string_0)
		{
			if (!global::System.IO.Directory.Exists(string_0))
			{
				global::System.IO.Directory.CreateDirectory(string_0);
			}
		}

		public static string CheckFolderSep(string folderPath)
		{
			if (folderPath != null && !folderPath.EndsWith("\\"))
			{
				folderPath += "\\";
			}
			return folderPath;
		}

		public static bool CheckFolderExists(string folderPath)
		{
			folderPath = global::ARC_Studio.Workers.ARC.FileUtils.CheckFolderSep(folderPath);
			return global::System.IO.Directory.Exists(folderPath);
		}

		internal static void smethod_10(string string_0)
		{
			if (global::System.IO.File.Exists(string_0))
			{
				global::System.IO.File.Delete(string_0);
			}
		}

		internal static void smethod_11(string string_0, string string_1)
		{
			if (global::System.IO.File.Exists(string_0))
			{
				global::System.IO.File.Move(string_0, string_1);
			}
		}

		internal static void smethod_12(string string_0, string string_1)
		{
			if (global::System.IO.File.Exists(string_0))
			{
				if (global::System.IO.File.Exists(string_1))
				{
					global::ARC_Studio.Workers.ARC.FileUtils.smethod_10(string_1);
				}
				global::System.IO.File.Copy(string_0, string_1);
			}
		}

		public static void CopyFoldersAndFiles(string source, string target)
		{
			global::System.IO.DirectoryInfo source2 = new global::System.IO.DirectoryInfo(source);
			global::System.IO.DirectoryInfo target2 = new global::System.IO.DirectoryInfo(target);
			global::ARC_Studio.Workers.ARC.FileUtils.CopyFoldersAndFiles(source2, target2);
		}

		public static void CopyFoldersAndFiles(global::System.IO.DirectoryInfo source, global::System.IO.DirectoryInfo target)
		{
			global::Class43 @class = new global::Class43();
			foreach (global::System.IO.DirectoryInfo directoryInfo in source.GetDirectories())
			{
				global::ARC_Studio.Workers.ARC.FileUtils.CopyFoldersAndFiles(directoryInfo, target.CreateSubdirectory(directoryInfo.Name));
			}
			foreach (global::System.IO.FileInfo fileInfo in source.GetFiles())
			{
				@class.method_0(fileInfo.FullName, global::System.IO.Path.Combine(target.FullName, fileInfo.Name));
			}
		}

		internal static long smethod_13(string string_0)
		{
			global::System.IO.FileInfo fileInfo = new global::System.IO.FileInfo(string_0);
			return fileInfo.Length;
		}

		public FileUtils()
		{
		}

		public enum ByteOrder
		{
			LittleEndian,
			BigEndian
		}
	}
}
