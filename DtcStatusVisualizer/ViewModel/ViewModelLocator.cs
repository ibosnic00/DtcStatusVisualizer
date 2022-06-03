using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;

namespace DtcStatusVisualizer.ViewModel
{
    class ViewModelLocator
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainVM
        {
            get => SimpleIoc.Default.GetInstance<MainViewModel>();
        }

    }
}
