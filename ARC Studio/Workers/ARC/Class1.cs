using System;
using System.IO;
using System.Text;

internal class ArraySupport
{
	public ArraySupport()
	{
		
		bool_0 = true;
	}

	public ArraySupport(bool bool_1)
	{
		
		bool_0 = true;
		bool_0 = bool_1;
	}

	internal short GetInt16(Stream stream_0)
	{
		byte[] array = ReadStreamBytes(stream_0, 2);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(array);
		}
		return BitConverter.ToInt16(array, 0);
	}

	internal ushort GetUInt16(Stream stream_0)
	{
		byte[] array = ReadStreamBytes(stream_0, 2);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(array);
		}
		return BitConverter.ToUInt16(array, 0);
	}

	internal int GetInt32(Stream stream_0)
	{
		byte[] array = ReadStreamBytes(stream_0, 4);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(array);
		}
		return BitConverter.ToInt32(array, 0);
	}

	internal uint method_5(Stream stream_0)
	{
		byte[] array = ReadStreamBytes(stream_0, 4);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(array);
		}
		return BitConverter.ToUInt32(array, 0);
	}

	private byte[] ReadStreamBytes(Stream stream_0, int int_0)
	{
		byte[] array = new byte[int_0];
		stream_0.Read(array, 0, int_0);
		return array;
	}

	internal string GetString(Stream stream_0)
	{
		ushort num = GetUInt16(stream_0);
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			byte b = (byte)stream_0.ReadByte();
			array[i] = b;
		}
		Encoding utf = Encoding.UTF8;
		return utf.GetString(array);
	}

	internal int method_8(Stream stream_0)
	{
		int result = GetInt32(stream_0);
		stream_0.Seek(-4L, SeekOrigin.Current);
		return result;
	}

	internal void WriteShortToStream(short short_0, Stream stream_0)
	{
		byte[] bytes = BitConverter.GetBytes(short_0);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void WriteIntToStream(int Number, Stream stream_0)
	{
		byte[] bytes = BitConverter.GetBytes(Number);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void WriteUIntToStream(uint uint_0, Stream stream_0)
	{
		byte[] bytes = BitConverter.GetBytes(uint_0);
		if (BitConverter.IsLittleEndian && bool_0)
		{
			Array.Reverse(bytes);
		}
		stream_0.Write(bytes, 0, bytes.Length);
	}

	internal void WriteStringToStream(string string_0, MemoryStream memoryStream_0)
	{
		Encoding utf = Encoding.UTF8;
		byte[] bytes = utf.GetBytes(string_0);
		WriteShortToStream((short)bytes.Length, memoryStream_0);
		memoryStream_0.Write(bytes, 0, bytes.Length);
	}

	private bool bool_0;
}
