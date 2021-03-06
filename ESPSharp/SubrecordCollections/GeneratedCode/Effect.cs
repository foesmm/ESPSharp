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
	public partial class Effect : SubrecordCollection	{
		public RecordReference BaseEffect { get; set; }
		public EffectData EffectData { get; set; }
		public List<Condition> Conditions { get; set; }

		public Effect()
		{
			BaseEffect = new RecordReference();
			EffectData = new EffectData();
		}

		public Effect(RecordReference BaseEffect, EffectData EffectData, List<Condition> Conditions)
		{
			this.BaseEffect = BaseEffect;
			this.EffectData = EffectData;
			this.Conditions = Conditions;
		}

		public Effect(Effect copyObject)
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
					case "EFID":
						if (readTags.Contains("EFID"))
							return;
						BaseEffect.ReadBinary(reader);
						break;
					case "EFIT":
						if (readTags.Contains("EFIT"))
							return;
						EffectData.ReadBinary(reader);
						break;
					case "CTDA":
						if (Conditions == null)
							Conditions = new List<Condition>();

						Condition tempCTDA = new Condition();
						tempCTDA.ReadBinary(reader);
						Conditions.Add(tempCTDA);
						break;
				default:
					return;
				}
				
				readTags.Add(subTag);
			}
		}

		public override void WriteBinary(ESPWriter writer)
		{
			if (BaseEffect != null)
				BaseEffect.WriteBinary(writer);
			if (EffectData != null)
				EffectData.WriteBinary(writer);
			if (Conditions != null)
				foreach (var item in Conditions)
					item.WriteBinary(writer);
		}

		public override void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (BaseEffect != null)		
			{		
				ele.TryPathTo("BaseEffect", true, out subEle);
				BaseEffect.WriteXML(subEle, master);
			}
			if (EffectData != null)		
			{		
				ele.TryPathTo("EffectData", true, out subEle);
				EffectData.WriteXML(subEle, master);
			}
			if (Conditions != null)		
			{		
				ele.TryPathTo("Conditions", true, out subEle);
				foreach (var entry in Conditions)
				{
					XElement newEle = new XElement("Condition");
					entry.WriteXML(newEle, master);
					subEle.Add(newEle);
				}
			}
		}

		public override void ReadXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("BaseEffect", false, out subEle))
			{
				if (BaseEffect == null)
					BaseEffect = new RecordReference();
					
				BaseEffect.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("EffectData", false, out subEle))
			{
				if (EffectData == null)
					EffectData = new EffectData();
					
				EffectData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Conditions", false, out subEle))
			{
				if (Conditions == null)
					Conditions = new List<Condition>();
					
				foreach (XElement e in subEle.Elements())
				{
					Condition temp = new Condition();
					temp.ReadXML(e, master);
					Conditions.Add(temp);
				}
			}
		}

		public Effect Clone()
		{
			return new Effect(this);
		}

	}
}
