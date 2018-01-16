using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using System.Drawing;


namespace PZ1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Koordinata> kooridinateSubstations;
        private static List<Koordinata> kooridinateNodes;
        private static List<Koordinata> kooridinateSwitches;
        private static List<List<Koordinata>> kooridinateLines;

        public MainWindow()
        {
            InitializeComponent();
            kooridinateSubstations = new List<Koordinata>();
            kooridinateNodes = new List<Koordinata>();
            kooridinateSwitches = new List<Koordinata>();
            kooridinateLines = new List<List<Koordinata>>();
        }

        private void parseXML(object sender, RoutedEventArgs e)
        {
            

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList substations = xmlDoc.GetElementsByTagName("SubstationEntity");
            XmlNodeList nodes = xmlDoc.GetElementsByTagName("NodeEntity");
            XmlNodeList switches = xmlDoc.GetElementsByTagName("SwitchEntity");
            XmlNodeList lines = xmlDoc.GetElementsByTagName("LineEntity");

            //txbXml.Text = "X:";
            //foreach (XmlNode xnode in xCordinate)
            //{
            //    txbXml.Text += xnode.InnerText.ToString();
            //}


            double latitude;
            double longitude;
            
            //for(int i = 0; i < substations.Count; i++)
            //{
            //    Koordinata tempKoor = new Koordinata();
            //    XmlNodeList subChildNodes = substations[i].ChildNodes;
                

            //    ToLatLon(double.Parse(subChildNodes.Item(2).InnerText),
            //                double.Parse(subChildNodes.Item(3).InnerText),
            //                34,
            //                out latitude,
            //                out longitude);
            //    tempKoor.X = latitude;
            //    tempKoor.Y = longitude;
            //    kooridinateSubstations.Add(tempKoor);
            //    //Console.WriteLine("x: " + subChildNodes.Item(2).InnerText + " y:" + subChildNodes.Item(3).InnerText);
            //    //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            //}

            //foreach (Koordinata kord in kooridinateSubstations)
            //{
            //    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            //}

            for (int i = 0; i < nodes.Count; i++)
            {
                Koordinata tempKoor = new Koordinata();
                XmlNodeList subChildNodes = nodes[i].ChildNodes;


                ToLatLon(double.Parse(subChildNodes.Item(2).InnerText.ToString()),
                            double.Parse(subChildNodes.Item(3).InnerText.ToString()),
                            34,
                            out latitude,
                            out longitude);
                tempKoor.X = latitude;
                tempKoor.Y = longitude;
                kooridinateNodes.Add(tempKoor);
                //Console.WriteLine("x: " + subChildNodes.Item(2).InnerText + " y:" + subChildNodes.Item(3).InnerText);
                //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            }

            ////foreach (Koordinata kord in kooridinateNodes)
            ////{
            ////    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            ////}

            //for (int i = 0; i < switches.Count; i++)
            //{
            //    Koordinata tempKoor = new Koordinata();
            //    XmlNodeList subChildNodes = switches[i].ChildNodes;


            //    ToLatLon(double.Parse(subChildNodes.Item(3).InnerText.ToString()),
            //                double.Parse(subChildNodes.Item(4).InnerText.ToString()),
            //                34,
            //                out latitude,
            //                out longitude);
            //    tempKoor.X = latitude;
            //    tempKoor.Y = longitude;
            //    kooridinateSwitches.Add(tempKoor);
            //    //Console.WriteLine("x: " + subChildNodes.Item(3).InnerText + " y:" + subChildNodes.Item(4).InnerText);
            //    //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            //}

            ////foreach (Koordinata kord in kooridinateSwitches)
            ////{
            ////    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            ////}

            //for (int i = 0; i < lines.Count; i++)
            //{
            //    List<Koordinata> lKord = new List<Koordinata>();
            //    XmlNodeList subChildNodes = lines[i].ChildNodes;

            //    XmlNode xnode = subChildNodes.Item(9);

            //    foreach(XmlNode xn in xnode.ChildNodes)
            //    {
            //        Koordinata tempKoor = new Koordinata();
            //        ToLatLon(double.Parse(xn.ChildNodes.Item(0).InnerText.ToString()),
            //                double.Parse(xn.ChildNodes.Item(1).InnerText.ToString()),
            //                34,
            //                out latitude,
            //                out longitude);
            //        tempKoor.X = latitude;
            //        tempKoor.Y = longitude;
            //        lKord.Add(tempKoor);
            //    }

            //    kooridinateLines.Add(lKord);
            //    //Console.WriteLine("x: " + subChildNodes.Item(3).InnerText + " y:" + subChildNodes.Item(4).InnerText);
            //    //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            //}

            Console.WriteLine( "uspesno ucitan xml");


        }
        public static void ToLatLon(double utmX, double utmY, int zoneUTM, out double latitude, out double longitude)
        {
            bool isNorthHemisphere = true;

            var diflat = -0.00066286966871111111111111111111111111;
            var diflon = -0.0003868060578;

            var zone = zoneUTM;
            var c_sa = 6378137.000000;
            var c_sb = 6356752.314245;
            var e2 = Math.Pow((Math.Pow(c_sa, 2) - Math.Pow(c_sb, 2)), 0.5) / c_sb;
            var e2cuadrada = Math.Pow(e2, 2);
            var c = Math.Pow(c_sa, 2) / c_sb;
            var x = utmX - 500000;
            var y = isNorthHemisphere ? utmY : utmY - 10000000;

            var s = ((zone * 6.0) - 183.0);
            var lat = y / (c_sa * 0.9996);
            var v = (c / Math.Pow(1 + (e2cuadrada * Math.Pow(Math.Cos(lat), 2)), 0.5)) * 0.9996;
            var a = x / v;
            var a1 = Math.Sin(2 * lat);
            var a2 = a1 * Math.Pow((Math.Cos(lat)), 2);
            var j2 = lat + (a1 / 2.0);
            var j4 = ((3 * j2) + a2) / 4.0;
            var j6 = ((5 * j4) + Math.Pow(a2 * (Math.Cos(lat)), 2)) / 3.0;
            var alfa = (3.0 / 4.0) * e2cuadrada;
            var beta = (5.0 / 3.0) * Math.Pow(alfa, 2);
            var gama = (35.0 / 27.0) * Math.Pow(alfa, 3);
            var bm = 0.9996 * c * (lat - alfa * j2 + beta * j4 - gama * j6);
            var b = (y - bm) / v;
            var epsi = ((e2cuadrada * Math.Pow(a, 2)) / 2.0) * Math.Pow((Math.Cos(lat)), 2);
            var eps = a * (1 - (epsi / 3.0));
            var nab = (b * (1 - epsi)) + lat;
            var senoheps = (Math.Exp(eps) - Math.Exp(-eps)) / 2.0;
            var delt = Math.Atan(senoheps / (Math.Cos(nab)));
            var tao = Math.Atan(Math.Cos(delt) * Math.Tan(nab));

            longitude = ((delt * (180.0 / Math.PI)) + s) + diflon;
            latitude = ((lat + (1 + e2cuadrada * Math.Pow(Math.Cos(lat), 2) - (3.0 / 2.0) * e2cuadrada * Math.Sin(lat) * Math.Cos(lat) * (tao - lat)) * (tao - lat)) * (180.0 / Math.PI)) + diflat;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.SetPositionByKeywords("Paris, France");
            gmap.ShowCenter = false;
        }

        private void prikaziSubstations(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList substations = xmlDoc.GetElementsByTagName("SubstationEntity");

            double latitude;
            double longitude;

            for (int i = 0; i < substations.Count; i++)
            {
                Koordinata tempKoor = new Koordinata();
                XmlNodeList subChildNodes = substations[i].ChildNodes;


                ToLatLon(double.Parse(subChildNodes.Item(2).InnerText),
                            double.Parse(subChildNodes.Item(3).InnerText),
                            34,
                            out latitude,
                            out longitude);
                tempKoor.X = latitude;
                tempKoor.Y = longitude;
                kooridinateSubstations.Add(tempKoor);
                //Console.WriteLine("x: " + subChildNodes.Item(2).InnerText + " y:" + subChildNodes.Item(3).InnerText);
                //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            }

            //foreach (Koordinata kord in kooridinateSubstations)
            //{
            //    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            //}

            GMapOverlay markers = new GMapOverlay("substations");
            foreach(Koordinata k in kooridinateSubstations)
            {
                GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(k.X, k.Y),
                GMarkerGoogleType.purple);
                markers.Markers.Add(marker);
            }

            gmap.Overlays.Add(markers);
        }

        private void prikaziNodes(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList nodes = xmlDoc.GetElementsByTagName("NodeEntity");
            double latitude;
            double longitude;

            for (int i = 0; i < nodes.Count; i++)
            {
                Koordinata tempKoor = new Koordinata();
                XmlNodeList subChildNodes = nodes[i].ChildNodes;


                ToLatLon(double.Parse(subChildNodes.Item(2).InnerText.ToString()),
                            double.Parse(subChildNodes.Item(3).InnerText.ToString()),
                            34,
                            out latitude,
                            out longitude);
                tempKoor.X = latitude;
                tempKoor.Y = longitude;
                kooridinateNodes.Add(tempKoor);
                //Console.WriteLine("x: " + subChildNodes.Item(2).InnerText + " y:" + subChildNodes.Item(3).InnerText);
                //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            }

            ////foreach (Koordinata kord in kooridinateNodes)
            ////{
            ////    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            ////}

            GMapOverlay markers = new GMapOverlay("nodes");
            foreach (Koordinata k in kooridinateNodes)
            {
                GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(k.X, k.Y),
                GMarkerGoogleType.green);
                markers.Markers.Add(marker);
            }

            gmap.Overlays.Add(markers);
        }

        private void prikaziSwitches(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList switches = xmlDoc.GetElementsByTagName("SwitchEntity");
            double latitude;
            double longitude;

            for (int i = 0; i < switches.Count; i++)
            {
                Koordinata tempKoor = new Koordinata();
                XmlNodeList subChildNodes = switches[i].ChildNodes;


                ToLatLon(double.Parse(subChildNodes.Item(3).InnerText.ToString()),
                            double.Parse(subChildNodes.Item(4).InnerText.ToString()),
                            34,
                            out latitude,
                            out longitude);
                tempKoor.X = latitude;
                tempKoor.Y = longitude;
                kooridinateSwitches.Add(tempKoor);
                //Console.WriteLine("x: " + subChildNodes.Item(3).InnerText + " y:" + subChildNodes.Item(4).InnerText);
                //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            }

            ////foreach (Koordinata kord in kooridinateNodes)
            ////{
            ////    Console.WriteLine("X: " + kord.X + " Y: " + kord.Y);
            ////}

            GMapOverlay markers = new GMapOverlay("switches");
            foreach (Koordinata k in kooridinateSwitches)
            {
                GMapMarker marker = new GMarkerGoogle(
                new PointLatLng(k.X, k.Y),
                GMarkerGoogleType.orange_dot);
                markers.Markers.Add(marker);
            }

            gmap.Overlays.Add(markers);
        }

        private void prikaziLines(object sender, RoutedEventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Geographic.xml");

            XmlNodeList lines = xmlDoc.GetElementsByTagName("LineEntity");
            double latitude;
            double longitude;

            for (int i = 0; i < 1000; i++)
            //for (int i = 0; i < lines.Count; i++)
            {
                List<Koordinata> lKord = new List<Koordinata>();
                XmlNodeList subChildNodes = lines[i].ChildNodes;

                XmlNode xnode = subChildNodes.Item(9);

                foreach (XmlNode xn in xnode.ChildNodes)
                {
                    Koordinata tempKoor = new Koordinata();
                    ToLatLon(double.Parse(xn.ChildNodes.Item(0).InnerText.ToString()),
                            double.Parse(xn.ChildNodes.Item(1).InnerText.ToString()),
                            34,
                            out latitude,
                            out longitude);
                    tempKoor.X = latitude;
                    tempKoor.Y = longitude;
                    lKord.Add(tempKoor);
                }

                kooridinateLines.Add(lKord);
                //Console.WriteLine("x: " + subChildNodes.Item(3).InnerText + " y:" + subChildNodes.Item(4).InnerText);
                //Console.WriteLine("koord x: " + tempKoor.X + " y:" + tempKoor.Y);
            }

            GMapOverlay routes = new GMapOverlay("routes");
            
            foreach(List<Koordinata> lk in kooridinateLines)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (Koordinata k in lk)
                {
                    points.Add(new PointLatLng(k.X, k.Y));
                }
                GMapRoute route = new GMapRoute(points, "Jardin des Tuileries");
                route.Stroke = new System.Drawing.Pen(System.Drawing.Color.YellowGreen, 1);
                routes.Routes.Add(route);
                gmap.Overlays.Add(routes);
            }
            
            
        }
    }
}
