using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ1
{
    public class Line
    {
        private string id;
        private string name;
        private bool isUnderground;
        private double r;
        private string conductorMaterial;
        private string lineType;
        private double thermalConstantHeat;
        private double firstEnd;
        private double secondEnd;
        private List<Koordinata> vertices;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool IsUnderground
        {
            get
            {
                return isUnderground;
            }

            set
            {
                isUnderground = value;
            }
        }

        public double R
        {
            get
            {
                return r;
            }

            set
            {
                r = value;
            }
        }

        public string ConductorMaterial
        {
            get
            {
                return conductorMaterial;
            }

            set
            {
                conductorMaterial = value;
            }
        }

        public string LineType
        {
            get
            {
                return lineType;
            }

            set
            {
                lineType = value;
            }
        }

        public double ThermalConstantHeat
        {
            get
            {
                return thermalConstantHeat;
            }

            set
            {
                thermalConstantHeat = value;
            }
        }

        public double FirstEnd
        {
            get
            {
                return firstEnd;
            }

            set
            {
                firstEnd = value;
            }
        }

        public double SecondEnd
        {
            get
            {
                return secondEnd;
            }

            set
            {
                secondEnd = value;
            }
        }

        public List<Koordinata> Vertices
        {
            get
            {
                return vertices;
            }

            set
            {
                vertices = value;
            }
        }
    }
}
