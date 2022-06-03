using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DtcStatusVisualizer.Model
{
    class DtcBit
    {

        public DtcBit(string description, Brush color)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Color = color;
        }

        public string Description { get; }
        public Brush Color { get; }
    }
}
