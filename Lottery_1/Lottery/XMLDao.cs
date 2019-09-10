using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml;

namespace Lottery
{
    public class XMLDao
    {
        private static XElement appSetting;
        public List<Number.Number_539> GetXML_539(string path)
        {
            List<Number.Number_539> m539 = new List<Number.Number_539>();
            XElement xmlE = XElement.Load(path);

            foreach (var _xmlE in xmlE.Elements("data"))
            {
                Number.Number_539 _539 = new Number.Number_539();

                _539.No = Convert.ToInt32(_xmlE.Element("no").Value);
                _539.Date = Convert.ToDateTime(_xmlE.Element("date").Value);
                _539.n_1 = Convert.ToInt32(_xmlE.Element("n1").Value);
                _539.n_2 = Convert.ToInt32(_xmlE.Element("n2").Value);
                _539.n_3 = Convert.ToInt32(_xmlE.Element("n3").Value);
                _539.n_4 = Convert.ToInt32(_xmlE.Element("n4").Value);
                _539.n_5 = Convert.ToInt32(_xmlE.Element("n5").Value);

                m539.Add(_539);                
            }
            
            return m539;
        }
        public StatusType InsertData_539(Number.Number_539 m539,string path)
        {
            try
            {
                XElement xmlE = XElement.Load(path);
                XElement _XmlE = new XElement("data",
                    new XElement("no",m539.No),
                    new XElement("date",m539.Date),
                    new XElement("n1",m539.n_1),
                    new XElement("n2",m539.n_2),
                    new XElement("n3",m539.n_3),
                    new XElement("n4",m539.n_4),
                    new XElement("n5",m539.n_5));
                xmlE.Add(_XmlE);
                xmlE.Save(path);
                return StatusType.Ok;
            }
            catch { return StatusType.Error; }
        }
    }
}
