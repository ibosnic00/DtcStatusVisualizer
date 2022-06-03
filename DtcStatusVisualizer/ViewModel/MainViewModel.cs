using DtcStatusVisualizer.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace DtcStatusVisualizer.ViewModel
{
    class MainViewModel : ViewModelBase
    {

        #region Constants

        #endregion


        #region Fields

        #endregion


        #region Constructors

        public MainViewModel()
        {
            // inital value
            DtcStatus = 0x50;
        }

        #endregion


        #region Properties

        uint _dtcStatus;
        public uint DtcStatus
        {
            get => _dtcStatus;
            set
            {
                Set(nameof(DtcStatus), ref _dtcStatus, value);
                DtcStatusBits = CalculateDtcBitsFromStatus(_dtcStatus);
            }
        }

        List<DtcBit> _dtcStatusBits = new List<DtcBit>();
        public List<DtcBit> DtcStatusBits
        {
            get => _dtcStatusBits;
            set => _ = Set(nameof(DtcStatusBits), ref _dtcStatusBits, value);
        }

        #endregion


        #region Commands

        ICommand? _demo_buttonClicked;
        public ICommand Demo_ButtonClicked
        {
            // you can use compound assingment here when you get familiar with C# syntaxes
            get => _demo_buttonClicked ??= new RelayCommand(() => DtcStatus++);
        }

        ICommand? _demoCommand;
        public ICommand DemoCommand
        {
            // you can use compound assingment here when you get familiar with C# syntaxes
            get => _demoCommand ??= new RelayCommand(() =>
            {
            });
        }

        #endregion


        #region Public Methods

        #endregion


        #region Private Methods

        List<DtcBit> CalculateDtcBitsFromStatus(uint status)
        {
            var result = new List<DtcBit>();
            if ((status & 0b00000001) > 0)
            {
                result.Add(new DtcBit("Test Failed", Brushes.Red));
            }
            if ((status & 0b00000010) > 0)
            {
                result.Add(new DtcBit("Test Failed This Operation Cycle", Brushes.Red));
            }
            if ((status & 0b00000100) > 0)
            {
                result.Add(new DtcBit("Pending DTC", Brushes.Red));
            }
            if ((status & 0b00001000) > 0)
            {
                result.Add(new DtcBit("Confirmed DTC", Brushes.Red));
            }
            if ((status & 0b00010000) > 0)
            {
                result.Add(new DtcBit("Test NOT Completed Since Last Clear", Brushes.Orange));
            }
            else { result.Add(new DtcBit("Test Completed Since Last Clear", Brushes.Green)); }
            if ((status & 0b00100000) > 0)
            {
                result.Add(new DtcBit("Test Failed Since Last Clear", Brushes.Red));
            }
            if ((status & 0b01000000) > 0)
            {
                result.Add(new DtcBit("Test NOT Completed This Operation Cycle", Brushes.Orange));
            }
            else { result.Add(new DtcBit("Test Completed This Operation Cycle", Brushes.Green)); }
            if ((status & 0b10000000) > 0)
            {
                result.Add(new DtcBit("Warning Indicator Requested", Brushes.Red));
            }
            return result;
        }

        #endregion

    }
}
