﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.SubrecordCollections
{
	public partial class Model : SubrecordCollection, IReferenceContainer	{
		public SimpleSubrecord<String> FileName { get; set; }
		public SimpleSubrecord<Byte[]> Unknown { get; set; }
		public SimpleSubrecord<Byte[]> TextureFileHash { get; set; }
		public AlternateTextures AlternateTextures { get; set; }
		public SimpleSubrecord<FaceGenModelFlags> FaceGenModelFlags { get; set; }

		public Model()
		{
		}

		public Model(SimpleSubrecord<String> FileName, SimpleSubrecord<Byte[]> Unknown, SimpleSubrecord<Byte[]> TextureFileHash, AlternateTextures AlternateTextures, SimpleSubrecord<FaceGenModelFlags> FaceGenModelFlags)
		{
			this.FileName = FileName;
			this.Unknown = Unknown;
			this.TextureFileHash = TextureFileHash;
			this.AlternateTextures = AlternateTextures;
			this.FaceGenModelFlags = FaceGenModelFlags;
		}

		public Model(Model copyObject)
		{
					}
	
		public override void ReadBinary(ESPReader reader)
		{
			List<string> readTags = new List<string>();

			while (reader.BaseStream.Position < reader.BaseStream.Length)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "MODL":
						if (readTags.Contains("MODL"))
							return;
						if (FileName == null)
							FileName = new SimpleSubrecord<String>();

						FileName.ReadBinary(reader);
						break;
					case "MODB":
						if (readTags.Contains("MODB"))
							return;
						if (Unknown == null)
							Unknown = new SimpleSubrecord<Byte[]>();

						Unknown.ReadBinary(reader);
						break;
					case "MODT":
						if (readTags.Contains("MODT"))
							return;
						if (TextureFileHash == null)
							TextureFileHash = new SimpleSubrecord<Byte[]>();

						TextureFileHash.ReadBinary(reader);
						break;
					case "MODS":
						if (readTags.Contains("MODS"))
							return;
						if (AlternateTextures == null)
							AlternateTextures = new AlternateTextures();

						AlternateTextures.ReadBinary(reader);
						break;
					case "MODD":
						if (readTags.Contains("MODD"))
							return;
						if (FaceGenModelFlags == null)
							FaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();

						FaceGenModelFlags.ReadBinary(reader);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (FileName != null)
				FileName.WriteBinary(writer);
			if (Unknown != null)
				Unknown.WriteBinary(writer);
			if (TextureFileHash != null)
				TextureFileHash.WriteBinary(writer);
			if (AlternateTextures != null)
				AlternateTextures.WriteBinary(writer);
			if (FaceGenModelFlags != null)
				FaceGenModelFlags.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (FileName != null)		
			{		
				ele.TryPathTo("FileName", true, out subEle);
				FileName.WriteXML(subEle, master);
			}
			if (Unknown != null)		
			{		
				ele.TryPathTo("Unknown", true, out subEle);
				Unknown.WriteXML(subEle, master);
			}
			if (TextureFileHash != null)		
			{		
				ele.TryPathTo("TextureFileHash", true, out subEle);
				TextureFileHash.WriteXML(subEle, master);
			}
			if (AlternateTextures != null)		
			{		
				ele.TryPathTo("AlternateTextures", true, out subEle);
				AlternateTextures.WriteXML(subEle, master);
			}
			if (FaceGenModelFlags != null)		
			{		
				ele.TryPathTo("FaceGenModelFlags", true, out subEle);
				FaceGenModelFlags.WriteXML(subEle, master);
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("FileName", false, out subEle))
			{
				if (FileName == null)
					FileName = new SimpleSubrecord<String>();
					
				FileName.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Unknown", false, out subEle))
			{
				if (Unknown == null)
					Unknown = new SimpleSubrecord<Byte[]>();
					
				Unknown.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("TextureFileHash", false, out subEle))
			{
				if (TextureFileHash == null)
					TextureFileHash = new SimpleSubrecord<Byte[]>();
					
				TextureFileHash.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("AlternateTextures", false, out subEle))
			{
				if (AlternateTextures == null)
					AlternateTextures = new AlternateTextures();
					
				AlternateTextures.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("FaceGenModelFlags", false, out subEle))
			{
				if (FaceGenModelFlags == null)
					FaceGenModelFlags = new SimpleSubrecord<FaceGenModelFlags>();
					
				FaceGenModelFlags.ReadXML(subEle, master);
			}
		}

		public Model Clone()
		{
			return new Model(this);
		}

	}
}
