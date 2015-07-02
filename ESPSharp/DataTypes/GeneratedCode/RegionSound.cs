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

namespace ESPSharp.DataTypes
{
	public partial class RegionSound : IESPSerializable, ICloneable<RegionSound>, IReferenceContainer
	{
		public FormID Sound { get; set; }
		public RegionSoundFlags Flags { get; set; }
		public UInt32 Chance { get; set; }

		public RegionSound()
		{
			Sound = new FormID();
			Flags = new RegionSoundFlags();
			Chance = new UInt32();
		}

		public RegionSound(FormID Sound, RegionSoundFlags Flags, UInt32 Chance)
		{
			this.Sound = Sound;
			this.Flags = Flags;
			this.Chance = Chance;
		}

		public RegionSound(RegionSound copyObject)
		{
			Sound = copyObject.Sound.Clone();
			Flags = copyObject.Flags;
			Chance = copyObject.Chance;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				Sound.ReadBinary(reader);
				Flags = reader.ReadEnum<RegionSoundFlags>();
				Chance = reader.ReadUInt32();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			Sound.WriteBinary(writer);
			writer.Write((UInt32)Flags);
			writer.Write(Chance);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("Sound", true, out subEle);
			Sound.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("Chance", true, out subEle);
			subEle.Value = Chance.ToString();
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("Sound", false, out subEle))
			{
				Sound.ReadXML(subEle, master);
			}

			if (ele.TryPathTo("Flags", false, out subEle))
			{
				Flags = subEle.ToEnum<RegionSoundFlags>();
			}

			if (ele.TryPathTo("Chance", false, out subEle))
			{
				Chance = subEle.ToUInt32();
			}
		}

		public RegionSound Clone()
		{
			return new RegionSound(this);
		}
	}
}
