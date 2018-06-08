﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Digital_Indicator.Logic.Helpers;
using Digital_Indicator.Module.Display.Views;
using Digital_Indicator.Infrastructure.UI;
using Digital_Indicator.Logic.Filament;
using System.Windows.Threading;
using Digital_Indicator.Logic.Navigation;
using Digital_Indicator.WindowForms.ZedGraphUserControl;

namespace Digital_Indicator.Module.Display.ViewModels
{
    public class DiameterViewModel : BindableBase
    {
        public IFilamentService _filamentService { get; }
        public DelegateCommand ResetGraph { get; private set; }
        public DelegateCommand StartCapture { get; private set; }
        public DelegateCommand StopCapture { get; private set; }
        public DelegateCommand Settings { get; private set; }

        private INavigationService _navigationService;

        public string Diameter
        {
            get { return _filamentService.FilamentServiceVariables["ActualDiameter"]; }
        }

        public string HighestValue
        {
            get { return _filamentService.FilamentServiceVariables["HighestValue"]; }
        }

        public string LowestValue
        {
            get { return _filamentService.FilamentServiceVariables["LowestValue"]; }
        }

        public string SpoolNumber
        {
            get { return _filamentService.SpoolNumber; }
        }

        public string BatchNumber
        {
            get { return _filamentService.BatchNumber; }
        }

        public bool CaptureStarted
        {
            get { return _filamentService.CaptureStarted; }
        }

        private object settingsView;
        public object SettingsView
        {
            get { return settingsView; }
            private set { settingsView = value; RaisePropertyChanged(); }
        }

        public DiameterViewModel(IFilamentService filamentService, INavigationService navigationService)
        {
            _filamentService = filamentService;
            _navigationService = navigationService;
            _filamentService.PropertyChanged += _filamentService_PropertyChanged;

            ResetGraph = new DelegateCommand(ResetGraph_Click);
            StartCapture = new DelegateCommand(StartCapture_Click);
            StopCapture = new DelegateCommand(StopCapture_Click);
            Settings = new DelegateCommand(Settings_Click);
        }

        private void _filamentService_PropertyChanged(object sender, EventArgs e)
        {
            RaisePropertyChanged("SpoolNumber");
            RaisePropertyChanged("BatchNumber");
        }

        private void ResetGraph_Click()
        {
            ZedGraphPlotModel.GetPlot("HistoricalModel").ZoomOutAll();
        }

        private void StartCapture_Click()
        {
            _filamentService.CaptureStarted = true;
            RaisePropertyChanged("CaptureStarted");
            RaisePropertyChanged("RealTimeModel");
        }

        private void StopCapture_Click()
        {
            _filamentService.CaptureStarted = false;
            RaisePropertyChanged("CaptureStarted");
        }

        private void Settings_Click()
        {
            _navigationService.NavigateToRegion("SettingsRegion", "SettingsView");
        }
    }
}

