﻿using Digital_Indicator.Logic.FileOperations;
using Digital_Indicator.Logic.Helpers;
using Digital_Indicator.Logic.SerialCommunications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Indicator.Logic.Filament
{
    public class FilamentService : IFilamentService
    {
        public event EventHandler DiameterChanged;

        public event EventHandler PropertyChanged;

        private IXmlService _xmlService;

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string actualDiameter;
        public string ActualDiameter
        {
            get { return actualDiameter; }
            set { actualDiameter = value; }
        }

        private string nominalDiameter;
        public string NominalDiameter
        {
            get { return nominalDiameter; }
            set { nominalDiameter = value; OnPropertyChanged(); }
        }

        private string upperLimit;
        public string UpperLimit
        {
            get { return upperLimit; }
            set { upperLimit = value; OnPropertyChanged(); }
        }

        private string lowerLimit;
        public string LowerLimit
        {
            get { return lowerLimit; }
            set { lowerLimit = value; OnPropertyChanged(); }
        }

        private string highestValue;
        public string HighestValue
        {
            get { return highestValue; }
            set { highestValue = value; }
        }

        private string lowestValue;
        public string LowestValue
        {
            get { return lowestValue; }
            set { lowestValue = value; }
        }

        private string spoolNumber;
        public string SpoolNumber
        {
            get { return spoolNumber; }
            set { spoolNumber = value; OnPropertyChanged(); }
        }

        private string batchNumber;
        public string BatchNumber
        {
            get { return batchNumber; }
            set { batchNumber = value; OnPropertyChanged(); }
        }

        private bool captureStarted;
        public bool CaptureStarted
        {
            get { return captureStarted; }
            set
            {
                captureStarted = value;
                if (captureStarted)
                {
                    highestValue = nominalDiameter;
                    lowestValue = nominalDiameter;
                }
            }
        }

        public FilamentService(ISerialService serialService, IXmlService xmlService)
        {
            serialService.DiameterChanged += SerialService_DiameterChanged;

            _xmlService = xmlService;

            BuildXmlData();
        }

        private void SerialService_DiameterChanged(object sender, EventArgs e)
        {
            ActualDiameter = sender.ToString();
            DiameterChanged?.Invoke(sender, e);

            if (captureStarted)
                UpdateHighsAndLows();

        }

        private void UpdateHighsAndLows()
        {
            HighestValue = highestValue == null ? actualDiameter : highestValue.GetDouble() < actualDiameter.GetDouble() ? actualDiameter : highestValue;
            LowestValue = lowestValue == null ? actualDiameter : lowestValue.GetDouble() > actualDiameter.GetDouble() ? actualDiameter : lowestValue;
        }

        private void BuildXmlData()
        {
            NominalDiameter = _xmlService.XmlSettings["filamentData.nominalDiameter"];
            UpperLimit = _xmlService.XmlSettings["filamentData.upperLimit"];
            LowerLimit = _xmlService.XmlSettings["filamentData.lowerLimit"];
            SpoolNumber = _xmlService.XmlSettings["filamentData.spoolNumber"];
            Description = _xmlService.XmlSettings["filamentData.materialDescription"];
            BatchNumber = _xmlService.XmlSettings["filamentData.batchNumber"];
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}