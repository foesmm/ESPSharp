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

namespace ESPSharp.Subrecords
{
	public partial class ExplosionData : Subrecord, ICloneable, IComparable<ExplosionData>, IEquatable<ExplosionData>  
	{
		public Single Force { get; set; }
		public Single Damage { get; set; }
		public Single Radius { get; set; }
		public FormID Light { get; set; }
		public FormID Sound1 { get; set; }
		public ExplosionFlags Flags { get; set; }
		public Single ISRadius { get; set; }
		public FormID ImpactDataSet { get; set; }
		public FormID Sound2 { get; set; }
		public Single RadiationLevel { get; set; }
		public Single RadiationDissipationTime { get; set; }
		public Single RadiationRadius { get; set; }
		public SoundLevel SoundLevel { get; set; }


		public ExplosionData(string Tag = null)
			:base(Tag)
		{
			Force = new Single();
			Damage = new Single();
			Radius = new Single();
			Light = new FormID();
			Sound1 = new FormID();
			Flags = new ExplosionFlags();
			ISRadius = new Single();
			ImpactDataSet = new FormID();
			Sound2 = new FormID();
			RadiationLevel = new Single();
			RadiationDissipationTime = new Single();
			RadiationRadius = new Single();
			SoundLevel = new SoundLevel();

		}

		public ExplosionData(Single Force, Single Damage, Single Radius, FormID Light, FormID Sound1, ExplosionFlags Flags, Single ISRadius, FormID ImpactDataSet, FormID Sound2, Single RadiationLevel, Single RadiationDissipationTime, Single RadiationRadius, SoundLevel SoundLevel)
		{
			this.Force = Force;
			this.Damage = Damage;
			this.Radius = Radius;
			this.Light = Light;
			this.Sound1 = Sound1;
			this.Flags = Flags;
			this.ISRadius = ISRadius;
			this.ImpactDataSet = ImpactDataSet;
			this.Sound2 = Sound2;
			this.RadiationLevel = RadiationLevel;
			this.RadiationDissipationTime = RadiationDissipationTime;
			this.RadiationRadius = RadiationRadius;
			this.SoundLevel = SoundLevel;

		}

		public ExplosionData(ExplosionData copyObject)
		{
			Force = copyObject.Force;
			Damage = copyObject.Damage;
			Radius = copyObject.Radius;
			if (copyObject.Light != null)
				Light = (FormID)copyObject.Light.Clone();
			if (copyObject.Sound1 != null)
				Sound1 = (FormID)copyObject.Sound1.Clone();
			Flags = copyObject.Flags;
			ISRadius = copyObject.ISRadius;
			if (copyObject.ImpactDataSet != null)
				ImpactDataSet = (FormID)copyObject.ImpactDataSet.Clone();
			if (copyObject.Sound2 != null)
				Sound2 = (FormID)copyObject.Sound2.Clone();
			RadiationLevel = copyObject.RadiationLevel;
			RadiationDissipationTime = copyObject.RadiationDissipationTime;
			RadiationRadius = copyObject.RadiationRadius;
			SoundLevel = copyObject.SoundLevel;

		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream, reader.Plugin))
			{
				try
				{
					Force = subReader.ReadSingle();
					Damage = subReader.ReadSingle();
					Radius = subReader.ReadSingle();
					Light.ReadBinary(subReader);
					Sound1.ReadBinary(subReader);
					Flags = subReader.ReadEnum<ExplosionFlags>();
					ISRadius = subReader.ReadSingle();
					ImpactDataSet.ReadBinary(subReader);
					Sound2.ReadBinary(subReader);
					RadiationLevel = subReader.ReadSingle();
					RadiationDissipationTime = subReader.ReadSingle();
					RadiationRadius = subReader.ReadSingle();
					SoundLevel = subReader.ReadEnum<SoundLevel>();

				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(Force);
			writer.Write(Damage);
			writer.Write(Radius);
			Light.WriteBinary(writer);
			Sound1.WriteBinary(writer);
			writer.Write((UInt32)Flags);
			writer.Write(ISRadius);
			ImpactDataSet.WriteBinary(writer);
			Sound2.WriteBinary(writer);
			writer.Write(RadiationLevel);
			writer.Write(RadiationDissipationTime);
			writer.Write(RadiationRadius);
			writer.Write((UInt32)SoundLevel);

		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			ele.TryPathTo("Force", true, out subEle);
			subEle.Value = Force.ToString("G15");

			ele.TryPathTo("Damage", true, out subEle);
			subEle.Value = Damage.ToString("G15");

			ele.TryPathTo("Radius", true, out subEle);
			subEle.Value = Radius.ToString("G15");

			ele.TryPathTo("Light", true, out subEle);
			Light.WriteXML(subEle, master);

			ele.TryPathTo("Sound1", true, out subEle);
			Sound1.WriteXML(subEle, master);

			ele.TryPathTo("Flags", true, out subEle);
			subEle.Value = Flags.ToString();

			ele.TryPathTo("ISRadius", true, out subEle);
			subEle.Value = ISRadius.ToString("G15");

			ele.TryPathTo("ImpactDataSet", true, out subEle);
			ImpactDataSet.WriteXML(subEle, master);

			ele.TryPathTo("Sound2", true, out subEle);
			Sound2.WriteXML(subEle, master);

			ele.TryPathTo("Radiation/Level", true, out subEle);
			subEle.Value = RadiationLevel.ToString("G15");

			ele.TryPathTo("Radiation/DissipationTime", true, out subEle);
			subEle.Value = RadiationDissipationTime.ToString("G15");

			ele.TryPathTo("Radiation/Radius", true, out subEle);
			subEle.Value = RadiationRadius.ToString("G15");

			ele.TryPathTo("SoundLevel", true, out subEle);
			subEle.Value = SoundLevel.ToString();

		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;
			
			if (ele.TryPathTo("Force", false, out subEle))
				Force = subEle.ToSingle();

			if (ele.TryPathTo("Damage", false, out subEle))
				Damage = subEle.ToSingle();

			if (ele.TryPathTo("Radius", false, out subEle))
				Radius = subEle.ToSingle();

			if (ele.TryPathTo("Light", false, out subEle))
				Light.ReadXML(subEle, master);

			if (ele.TryPathTo("Sound1", false, out subEle))
				Sound1.ReadXML(subEle, master);

			if (ele.TryPathTo("Flags", false, out subEle))
				Flags = subEle.ToEnum<ExplosionFlags>();

			if (ele.TryPathTo("ISRadius", false, out subEle))
				ISRadius = subEle.ToSingle();

			if (ele.TryPathTo("ImpactDataSet", false, out subEle))
				ImpactDataSet.ReadXML(subEle, master);

			if (ele.TryPathTo("Sound2", false, out subEle))
				Sound2.ReadXML(subEle, master);

			if (ele.TryPathTo("Radiation/Level", false, out subEle))
				RadiationLevel = subEle.ToSingle();

			if (ele.TryPathTo("Radiation/DissipationTime", false, out subEle))
				RadiationDissipationTime = subEle.ToSingle();

			if (ele.TryPathTo("Radiation/Radius", false, out subEle))
				RadiationRadius = subEle.ToSingle();

			if (ele.TryPathTo("SoundLevel", false, out subEle))
				SoundLevel = subEle.ToEnum<SoundLevel>();

		}

		public override object Clone()
		{
			return new ExplosionData(this);
		}


        public int CompareTo(ExplosionData other)
        {
			int result = 0;


			return result;
		}

        public static bool operator >(ExplosionData objA, ExplosionData objB)
        {
            return objA.CompareTo(objB) > 0;
        }

        public static bool operator >=(ExplosionData objA, ExplosionData objB)
        {
            return objA.CompareTo(objB) >= 0;
        }

        public static bool operator <(ExplosionData objA, ExplosionData objB)
        {
            return objA.CompareTo(objB) < 0;
        }

        public static bool operator <=(ExplosionData objA, ExplosionData objB)
        {
            return objA.CompareTo(objB) <= 0;
        }



        public bool Equals(ExplosionData other)
        {
			if (System.Object.ReferenceEquals(this, other))
			{
				return true;
			}

			if (((object)this == null) || ((object)other == null))
			{
				return false;
			}

			return Force == other.Force &&
				Damage == other.Damage &&
				Radius == other.Radius &&
				Light == other.Light &&
				Sound1 == other.Sound1 &&
				Flags == other.Flags &&
				ISRadius == other.ISRadius &&
				ImpactDataSet == other.ImpactDataSet &&
				Sound2 == other.Sound2 &&
				RadiationLevel == other.RadiationLevel &&
				RadiationDissipationTime == other.RadiationDissipationTime &&
				RadiationRadius == other.RadiationRadius &&
				SoundLevel == other.SoundLevel;
        }

        public override bool Equals(object obj)
        {
			if (obj == null)
				return false;

            ExplosionData other = obj as ExplosionData;

            if (other == null)
                return false;
            else
                return Equals(other);
        }

        public override int GetHashCode()
        {
            return Damage.GetHashCode();
        }

        public static bool operator ==(ExplosionData objA, ExplosionData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return true;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return false;
			}

            return objA.Equals(objB);
        }

        public static bool operator !=(ExplosionData objA, ExplosionData objB)
        {
			if (System.Object.ReferenceEquals(objA, objB))
			{
				return false;
			}

			if (((object)objA == null) || ((object)objB == null))
			{
				return true;
			}

            return !objA.Equals(objB);
        }





	}
}