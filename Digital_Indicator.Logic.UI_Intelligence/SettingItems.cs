﻿using Digital_Indicator.Infrastructure.UI.ControlBase;
using Digital_Indicator.Infrastructure.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Indicator.Logic.UI_Intelligence
{
    public class SettingItems
    {
        public ObservableCollection<ViewModelBase> Settings;

        private DataInputViewModel Description;
        private DataInputViewModel FilamentDiameter;
        private DataInputViewModel UpperLimit;
        private DataInputViewModel LowerLimit;
        private DataInputViewModel SpoolNumber;
        private DataInputViewModel SpoolerRpm;
        private DoubleInputViewModel TraverseInnerOffset;
        private DoubleInputViewModel TraverseSpoolWidth;
        private EnumItemsViewModel TraverseRunMode;
        

        public SettingItems()
        {
            Settings = new ObservableCollection<ViewModelBase>();


            Description = new DataInputViewModel();
            FilamentDiameter = new DataInputViewModel();
            UpperLimit = new DataInputViewModel();
            LowerLimit = new DataInputViewModel();
            SpoolNumber = new DataInputViewModel();
            SpoolerRpm = new DataInputViewModel();
            TraverseInnerOffset = new DoubleInputViewModel();
            TraverseSpoolWidth = new DoubleInputViewModel();
            TraverseRunMode = new EnumItemsViewModel();

            Description.ParameterName = "Description";
            Description.IsXmLParameter = true;
            Description.XmlParameterName = "Description";

            FilamentDiameter.ParameterName = "Filament Diameter";
            FilamentDiameter.IsXmLParameter = true;
            FilamentDiameter.XmlParameterName = "NominalDiameter";
            FilamentDiameter.Unit = "mm";

            UpperLimit.ParameterName = "Upper Limit";
            UpperLimit.IsXmLParameter = true;
            UpperLimit.XmlParameterName = "UpperLimit";
            UpperLimit.Unit = "mm";

            LowerLimit.ParameterName = "Lower Limit";
            LowerLimit.IsXmLParameter = true;
            LowerLimit.XmlParameterName = "LowerLimit";
            LowerLimit.Unit = "mm";

            SpoolNumber.ParameterName = "Spool Number";
            SpoolNumber.IsXmLParameter = true;
            SpoolNumber.XmlParameterName = "SpoolNumber";

            SpoolerRpm.HardwareType = "1";
            SpoolerRpm.ParameterName = "Pull Speed";
            SpoolerRpm.SerialCommand = "velocity";
            SpoolerRpm.Value = "0";
            SpoolerRpm.Unit = "rpm";

            TraverseInnerOffset.HardwareType = "3";
            TraverseInnerOffset.ParameterName = "Traverse Inner Offset";
            TraverseInnerOffset.SerialCommand = "InnerOffset";
            TraverseInnerOffset.Value = "100";
            TraverseInnerOffset.Unit = "mm";

            TraverseSpoolWidth.HardwareType = "3";
            TraverseSpoolWidth.ParameterName = "Spool Width";
            TraverseSpoolWidth.SerialCommand = "SpoolWidth";
            TraverseSpoolWidth.Value = "60000";
            TraverseSpoolWidth.Unit = "mm";

            TraverseRunMode.HardwareType = "3";
            TraverseRunMode.ParameterName = "Traverse Run Mode";
            TraverseRunMode.SerialCommand = "RunMode";

            EnumItem home = new EnumItem() { ItemValue = "Home", ItemValueID = "0" };
            EnumItem stop = new EnumItem() { ItemValue = "Stop", ItemValueID = "1" };
            EnumItem manual = new EnumItem() { ItemValue = "Manual", ItemValueID = "2" };
            EnumItem semiManual = new EnumItem() { ItemValue = "Semi Manual", ItemValueID = "3" };
            EnumItem fullAuto = new EnumItem() { ItemValue = "Full Auto", ItemValueID = "4" };

            TraverseRunMode.EnumList = new ObservableCollection<EnumItem>();
            TraverseRunMode.EnumList.Add(home);
            TraverseRunMode.EnumList.Add(stop);
            TraverseRunMode.EnumList.Add(manual);
            TraverseRunMode.EnumList.Add(semiManual);
            TraverseRunMode.EnumList.Add(fullAuto);



            Settings.Add(Description);
            Settings.Add(FilamentDiameter);
            Settings.Add(UpperLimit);
            Settings.Add(LowerLimit);
            Settings.Add(SpoolNumber);
            Settings.Add(SpoolerRpm);
            Settings.Add(TraverseInnerOffset);
            Settings.Add(TraverseSpoolWidth);
            Settings.Add(TraverseRunMode);



        }
    }
}
