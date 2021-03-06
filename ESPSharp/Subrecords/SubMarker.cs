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
    public partial class SubMarker : Subrecord, ICloneable
    {

        public SubMarker(string Tag = null)
            :base(Tag)
        {
        }

        public SubMarker(SubMarker copyObject)
        {
        }

        protected override void ReadData(ESPReader reader)
        {
        }

        protected override void WriteData(ESPWriter writer)
        {
        }

        protected override void WriteDataXML(XElement ele, ElderScrollsPlugin master)
        {
        }

        protected override void ReadDataXML(XElement ele, ElderScrollsPlugin master)
        {
        }

        public override object Clone()
        {
            return new SubMarker(this);
        }
    }
}