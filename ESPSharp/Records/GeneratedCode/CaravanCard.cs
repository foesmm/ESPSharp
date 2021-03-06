﻿
using System;
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

namespace ESPSharp.Records
{
	public partial class CaravanCard : Record, IEditorID
	{
		public SimpleSubrecord<String> EditorID { get; set; }
		public ObjectBounds ObjectBounds { get; set; }
		public SimpleSubrecord<String> Name { get; set; }
		public Model Model { get; set; }
		public SimpleSubrecord<String> LargeIcon { get; set; }
		public SimpleSubrecord<String> SmallIcon { get; set; }
		public RecordReference Script { get; set; }
		public RecordReference PickUpSound { get; set; }
		public RecordReference DropSound { get; set; }
		public SimpleSubrecord<String> TextureFace { get; set; }
		public SimpleSubrecord<String> TextureBack { get; set; }
		public Card CardData { get; set; }
		public SimpleSubrecord<UInt32> Value { get; set; }

		public CaravanCard()
		{
			EditorID = new SimpleSubrecord<String>("EDID");
			ObjectBounds = new ObjectBounds("OBND");
			Model = new Model();
			Value = new SimpleSubrecord<UInt32>("DATA");
		}

		public CaravanCard(SimpleSubrecord<String> EditorID, ObjectBounds ObjectBounds, SimpleSubrecord<String> Name, Model Model, SimpleSubrecord<String> LargeIcon, SimpleSubrecord<String> SmallIcon, RecordReference Script, RecordReference PickUpSound, RecordReference DropSound, SimpleSubrecord<String> TextureFace, SimpleSubrecord<String> TextureBack, Card CardData, SimpleSubrecord<UInt32> Value)
		{
			this.EditorID = EditorID;
			this.ObjectBounds = ObjectBounds;
			this.Model = Model;
			this.Value = Value;
		}

		public CaravanCard(CaravanCard copyObject)
		{
					}
	
		public override void ReadData(ESPReader reader, long dataEnd)
		{
			while (reader.BaseStream.Position < dataEnd)
			{
				string subTag = reader.PeekTag();

				switch (subTag)
				{
					case "EDID":
						if (EditorID == null)
							EditorID = new SimpleSubrecord<String>();

						EditorID.ReadBinary(reader);
						break;
					case "OBND":
						if (ObjectBounds == null)
							ObjectBounds = new ObjectBounds();

						ObjectBounds.ReadBinary(reader);
						break;
					case "FULL":
						if (Name == null)
							Name = new SimpleSubrecord<String>();

						Name.ReadBinary(reader);
						break;
					case "MODL":
						if (Model == null)
							Model = new Model();

						Model.ReadBinary(reader);
						break;
					case "ICON":
						if (LargeIcon == null)
							LargeIcon = new SimpleSubrecord<String>();

						LargeIcon.ReadBinary(reader);
						break;
					case "MICO":
						if (SmallIcon == null)
							SmallIcon = new SimpleSubrecord<String>();

						SmallIcon.ReadBinary(reader);
						break;
					case "SCRI":
						if (Script == null)
							Script = new RecordReference();

						Script.ReadBinary(reader);
						break;
					case "YNAM":
						if (PickUpSound == null)
							PickUpSound = new RecordReference();

						PickUpSound.ReadBinary(reader);
						break;
					case "ZNAM":
						if (DropSound == null)
							DropSound = new RecordReference();

						DropSound.ReadBinary(reader);
						break;
					case "TX00":
						if (TextureFace == null)
							TextureFace = new SimpleSubrecord<String>();

						TextureFace.ReadBinary(reader);
						break;
					case "TX01":
						if (TextureBack == null)
							TextureBack = new SimpleSubrecord<String>();

						TextureBack.ReadBinary(reader);
						break;
					case "INTV":
						if (CardData == null)
							CardData = new Card();

						CardData.ReadBinary(reader);
						break;
					case "DATA":
						if (Value == null)
							Value = new SimpleSubrecord<UInt32>();

						Value.ReadBinary(reader);
						break;
					default:
						throw new Exception();
				}
			}
		}

		public override void WriteData(ESPWriter writer)
		{
			if (EditorID != null)
				EditorID.WriteBinary(writer);
			if (ObjectBounds != null)
				ObjectBounds.WriteBinary(writer);
			if (Name != null)
				Name.WriteBinary(writer);
			if (Model != null)
				Model.WriteBinary(writer);
			if (LargeIcon != null)
				LargeIcon.WriteBinary(writer);
			if (SmallIcon != null)
				SmallIcon.WriteBinary(writer);
			if (Script != null)
				Script.WriteBinary(writer);
			if (PickUpSound != null)
				PickUpSound.WriteBinary(writer);
			if (DropSound != null)
				DropSound.WriteBinary(writer);
			if (TextureFace != null)
				TextureFace.WriteBinary(writer);
			if (TextureBack != null)
				TextureBack.WriteBinary(writer);
			if (CardData != null)
				CardData.WriteBinary(writer);
			if (Value != null)
				Value.WriteBinary(writer);
		}

		public override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			if (EditorID != null)		
			{		
				ele.TryPathTo("EditorID", true, out subEle);
				EditorID.WriteXML(subEle, master);
			}
			if (ObjectBounds != null)		
			{		
				ele.TryPathTo("ObjectBounds", true, out subEle);
				ObjectBounds.WriteXML(subEle, master);
			}
			if (Name != null)		
			{		
				ele.TryPathTo("Name", true, out subEle);
				Name.WriteXML(subEle, master);
			}
			if (Model != null)		
			{		
				ele.TryPathTo("Model", true, out subEle);
				Model.WriteXML(subEle, master);
			}
			if (LargeIcon != null)		
			{		
				ele.TryPathTo("Icon/Large", true, out subEle);
				LargeIcon.WriteXML(subEle, master);
			}
			if (SmallIcon != null)		
			{		
				ele.TryPathTo("Icon/Small", true, out subEle);
				SmallIcon.WriteXML(subEle, master);
			}
			if (Script != null)		
			{		
				ele.TryPathTo("Script", true, out subEle);
				Script.WriteXML(subEle, master);
			}
			if (PickUpSound != null)		
			{		
				ele.TryPathTo("PickUpSound", true, out subEle);
				PickUpSound.WriteXML(subEle, master);
			}
			if (DropSound != null)		
			{		
				ele.TryPathTo("DropSound", true, out subEle);
				DropSound.WriteXML(subEle, master);
			}
			if (TextureFace != null)		
			{		
				ele.TryPathTo("Texture/Face", true, out subEle);
				TextureFace.WriteXML(subEle, master);
			}
			if (TextureBack != null)		
			{		
				ele.TryPathTo("Texture/Back", true, out subEle);
				TextureBack.WriteXML(subEle, master);
			}
			if (CardData != null)		
			{		
				ele.TryPathTo("CardData", true, out subEle);
				CardData.WriteXML(subEle, master);
			}
			if (Value != null)		
			{		
				ele.TryPathTo("Value", true, out subEle);
				Value.WriteXML(subEle, master);
			}
		}

		public override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("EditorID", false, out subEle))
			{
				if (EditorID == null)
					EditorID = new SimpleSubrecord<String>();
					
				EditorID.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("ObjectBounds", false, out subEle))
			{
				if (ObjectBounds == null)
					ObjectBounds = new ObjectBounds();
					
				ObjectBounds.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Name", false, out subEle))
			{
				if (Name == null)
					Name = new SimpleSubrecord<String>();
					
				Name.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Model", false, out subEle))
			{
				if (Model == null)
					Model = new Model();
					
				Model.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Large", false, out subEle))
			{
				if (LargeIcon == null)
					LargeIcon = new SimpleSubrecord<String>();
					
				LargeIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Icon/Small", false, out subEle))
			{
				if (SmallIcon == null)
					SmallIcon = new SimpleSubrecord<String>();
					
				SmallIcon.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Script", false, out subEle))
			{
				if (Script == null)
					Script = new RecordReference();
					
				Script.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("PickUpSound", false, out subEle))
			{
				if (PickUpSound == null)
					PickUpSound = new RecordReference();
					
				PickUpSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("DropSound", false, out subEle))
			{
				if (DropSound == null)
					DropSound = new RecordReference();
					
				DropSound.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Texture/Face", false, out subEle))
			{
				if (TextureFace == null)
					TextureFace = new SimpleSubrecord<String>();
					
				TextureFace.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Texture/Back", false, out subEle))
			{
				if (TextureBack == null)
					TextureBack = new SimpleSubrecord<String>();
					
				TextureBack.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("CardData", false, out subEle))
			{
				if (CardData == null)
					CardData = new Card();
					
				CardData.ReadXML(subEle, master);
			}
			if (ele.TryPathTo("Value", false, out subEle))
			{
				if (Value == null)
					Value = new SimpleSubrecord<UInt32>();
					
				Value.ReadXML(subEle, master);
			}
		}		

		public CaravanCard Clone()
		{
			return new CaravanCard(this);
		}

	}
}