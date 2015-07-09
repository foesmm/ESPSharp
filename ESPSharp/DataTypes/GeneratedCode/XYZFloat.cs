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
	public partial class XYZFloat : IESPSerializable, ICloneable<XYZFloat>
	{
		public Single X { get; set; }
		public Single Y { get; set; }
		public Single Z { get; set; }

		public XYZFloat()
		{
			X = new Single();
			Y = new Single();
			Z = new Single();
		}

		public XYZFloat(Single X, Single Y, Single Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public XYZFloat(XYZFloat copyObject)
		{
			X = copyObject.X;
			Y = copyObject.Y;
			Z = copyObject.Z;
		}
	
		public void ReadBinary(ESPReader reader)
		{
			try
			{
				X = reader.ReadSingle();
				Y = reader.ReadSingle();
				Z = reader.ReadSingle();
			}
			catch
			{
				return;
			}
		}

		public void WriteBinary(ESPWriter writer)
		{
			writer.Write(X);			
			writer.Write(Y);			
			writer.Write(Z);			
		}

		public void WriteXML(XElement ele, ElderScrollsPlugin master)
		{
			XElement subEle;

			ele.TryPathTo("X", true, out subEle);
			subEle.Value = X.ToString("G15");

			ele.TryPathTo("Y", true, out subEle);
			subEle.Value = Y.ToString("G15");

			ele.TryPathTo("Z", true, out subEle);
			subEle.Value = Z.ToString("G15");
		}

		public void ReadXML(XElement ele, ElderScrollsPlugin master)
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

		public XYZFloat Clone()
		{
			return new XYZFloat(this);
		}
	}
}