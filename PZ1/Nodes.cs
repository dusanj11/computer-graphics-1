using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ1
{
    public class Nodes
    {
        private string id;
        private string name;
        private Koordinata koordinata;

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

        public Koordinata Koordinata
        {
            get
            {
                return koordinata;
            }

            set
            {
                koordinata = value;
            }
        }
    }
}
