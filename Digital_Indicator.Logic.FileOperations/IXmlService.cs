﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Indicator.Logic.FileOperations
{
    public interface IXmlService
    {
        Dictionary<string, string> XmlSettings { get; set; }

        void SaveSettings();
    }
}
