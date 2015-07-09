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

namespace ESPSharp.Subrecords
{
	public partial class BoundHalfExtents : Subrecord, ICloneable<BoundHalfExtents>
	{
		public Single X { get; set; }
		public Single Y { get; set; }
		public Single Z { get; set; }

		public BoundHalfExtents()
		{
			X = new Single();
			Y = new Single();
			Z = new Single();
		}

		public BoundHalfExtents(Single X, Single Y, Single Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public BoundHalfExtents(BoundHalfExtents copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
			Z = copyObject.Z;
		}
	
		protected override void ReadData(ESPReader reader)
		{
			using (MemoryStream stream = new MemoryStream(reader.ReadBytes(size)))
			using (ESPReader subReader = new ESPReader(stream))
			{
				try
				{
					X = subReader.ReadSingle();
					Y = subReader.ReadSingle();
					Z = subReader.ReadSingle();
				}
				catch
				{
					return;
				}
			}
		}

		protected override void WriteData(ESPWriter writer)
		{
			writer.Write(X);			
			writer.Write(Y);			
			writer.Write(Z);			
		}

		protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString("G15");

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString("G15");

			ele.TryPathTo("Z", true, out subEle);
			subEle.Value = Z.ToString("G15");
		}

		protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			if (ele.TryPathTo("X", false, out subEle))
			{
				X = subEle.ToSingle();
			}

			if (ele.TryPathTo("Y", false, out subEle))
			{
				Y = subEle.ToSingle();
			}

			if (ele.TryPathTo("Z", false, out subEle))
			{
				Z = subEle.ToSingle();
			}
		}

		public BoundHalfExtents Clone()
		{
			return new BoundHalfExtents(this);
		}

	}
}