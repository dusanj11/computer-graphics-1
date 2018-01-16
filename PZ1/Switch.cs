using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ1
{
    public class Switch
    {
        private string id;
        private string name;
        private Koordinata koordinata;
        private string status;

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

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
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
