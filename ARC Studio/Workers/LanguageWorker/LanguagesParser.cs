﻿using System;
using System.Collections.Generic;
using System.IO;
using LanguageWorker.model;

namespace LanguageWorker
{
	public class LanguagesParser
	{
		public LanguagesContainer Parse(byte[] locData)
		{
			LanguagesContainer lc = new LanguagesContainer();
			MemoryStream s = new MemoryStream(locData);
			return Parse(lc, s);
		}

		public LanguagesContainer Parse(string path)
		{
			LanguagesContainer languagesContainer = new LanguagesContainer();
			if (File.Exists(path))
			{
				using (BinaryReader binaryReader = new BinaryReader(File.Open(path,FileMode.Open)))
				{
					Stream baseStream = binaryReader.BaseStream;
					languagesContainer = Parse(languagesContainer, baseStream);
				}
			}
			return languagesContainer;
		}

		public LanguagesContainer Parse(LanguagesContainer lc,Stream s)
		{
			ArrSupport.GetInt32(s); // Get LOC version
			int NumOfLanguages = ArrSupport.GetInt32(s); // Get Number Of Languages
			s.ReadByte(); // Get LOC index?
			int NumOfIndexes = ArrSupport.GetInt32(s);
			int[] array = new int[NumOfIndexes];
			for (int i = 0; i < NumOfIndexes; i++)
			{
				array[i] = ArrSupport.GetInt32(s);
			}
			lc.Indexes = array;
			Dictionary<string, LanguageEntry> dictionary = new Dictionary<string, LanguageEntry>();
			for (int j = 0; j < NumOfLanguages; j++)
			{
				string text = ArrSupport.GetString(s);
				int size = ArrSupport.GetInt32(s);
				LanguageEntry value = new LanguageEntry(text, size);
				dictionary.Add(text, value);
			}
			for (int k = 0; k < NumOfLanguages; k++)
			{
				s.ReadByte();
				ArrSupport.GetInt32(s);
				string key = ArrSupport.GetString(s);
				int num3 = ArrSupport.GetInt32(s);
				LanguageEntry languageEntry = dictionary[key];
				for (int l = 0; l < num3; l++)
				{
					string message = ArrSupport.GetString(s);
					languageEntry.Messages.Add(new MessageEntry(message));
				}
			}
			lc.Languages = dictionary;
			return lc;
		}

		public LanguagesParser()
		{

			ArrSupport = new ArraySupport();
			
		}

		private ArraySupport ArrSupport;
	}
}
