using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Xml;



namespace Currency_Converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            TimerTick();
            GetInformation();
        }
        
         private void TimerTick()
         {
             DispatcherTimer timer = new DispatcherTimer();
             timer.Tick += new EventHandler(GetDate);
             timer.Interval = TimeSpan.FromSeconds(1);
             timer.Start();
         }
         private void GetDate(object sender, EventArgs e)
         {
             DateTime dateTime = DateTime.Now;
             dateField.Text = dateTime.ToString();
         }
        private void GetInformation()
        {
            XmlTextReader reader = new XmlTextReader("http://www.cbr.ru/scripts/XML_daily.asp");
            
                string USDXml = "";
                string EuroXml = "";
                string CADXml = "";
                string NOKXml = "";
                string TRYXml = "";
                string SEKXml = "";
                string JPYXml = "";
            

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "Valute")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01235")
                                        {
                                            reader.MoveToElement();
                                            USDXml = reader.ReadOuterXml();
                                        }

                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01239")
                                            {
                                                reader.MoveToElement();
                                                EuroXml = reader.ReadOuterXml();
                                            }
                                        }
                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01350")
                                            {
                                                reader.MoveToElement();
                                                CADXml = reader.ReadOuterXml();
                                            }
                                        }
                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01535")
                                            {
                                                reader.MoveToElement();
                                                NOKXml = reader.ReadOuterXml();
                                            }
                                        }
                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01700J")
                                            {
                                                reader.MoveToElement();
                                                TRYXml = reader.ReadOuterXml();
                                            }
                                        }

                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01770")
                                            {
                                                reader.MoveToElement();
                                                SEKXml = reader.ReadOuterXml();
                                            }
                                        }

                                        if (reader.Name == "ID")
                                        {
                                            if (reader.Value == "R01820")
                                            {
                                                reader.MoveToElement();
                                                JPYXml = reader.ReadOuterXml();
                                            }
                                        }


                                    }

                                }
                            }
                        }
                        break;
                }
            }

            XmlDocument usdXmlDocument = new XmlDocument();
            usdXmlDocument.LoadXml(USDXml);
            XmlNode xmlNode = usdXmlDocument.SelectSingleNode("Valute/Value");
            decimal usdValue = Convert.ToDecimal(xmlNode.InnerText);

            XmlDocument euroXmlDocument = new XmlDocument();
            euroXmlDocument.LoadXml(EuroXml);
            xmlNode = euroXmlDocument.SelectSingleNode("Valute/Value");
            decimal euroValue = Convert.ToDecimal(xmlNode.InnerText);


            XmlDocument cadXmlDocument = new XmlDocument();
            cadXmlDocument.LoadXml(CADXml);
            xmlNode = cadXmlDocument.SelectSingleNode("Valute/Value");
            decimal cadValue = Convert.ToDecimal(xmlNode.InnerText);

            XmlDocument NokXmlDocument = new XmlDocument();
            NokXmlDocument.LoadXml(NOKXml); 
            xmlNode = NokXmlDocument.SelectSingleNode("Valute/Value");
            decimal nokValue = Convert.ToDecimal(xmlNode.InnerText);

            XmlDocument tryXmlDocument = new XmlDocument();
            tryXmlDocument.LoadXml(TRYXml);
            xmlNode = tryXmlDocument.SelectSingleNode("Valute/Value");
            decimal tryValue = Convert.ToDecimal(xmlNode.InnerText);

            XmlDocument sekXmlDocument = new XmlDocument();
            sekXmlDocument.LoadXml(SEKXml);
            xmlNode = sekXmlDocument.SelectSingleNode("Valute/Value");
            decimal sekValue = Convert.ToDecimal(xmlNode.InnerText);

            XmlDocument jpyXmlDocument = new XmlDocument();
            jpyXmlDocument.LoadXml(JPYXml);
            xmlNode = jpyXmlDocument.SelectSingleNode("Valute/Value");
            decimal jpyValue = Convert.ToDecimal(xmlNode.InnerText);






            USDvalue.Text = usdValue.ToString();
            EURValue.Text = euroValue.ToString();
            CADValue.Text = cadValue.ToString();
            NOKvalue.Text = nokValue.ToString();
            TRYValue.Text = tryValue.ToString();
            SEKValue.Text = sekValue.ToString();
            JPYValue.Text = jpyValue.ToString();
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            QuntBox.Text = string.Empty;
        }
    }
}

