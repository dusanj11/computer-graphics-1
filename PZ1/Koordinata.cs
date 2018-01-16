using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ1
{
    public class Koordinata
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Koordinata(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public Koordinata()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}
