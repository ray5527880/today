using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace bigtal
{
    class EditXml
    {
        public static string strXmlFile;
        public static string strConnectionSetting;
        public static string strSettingDBName;

        public EditXml()
        {
            strXmlFile = this.GetType().Assembly.Location;
            strXmlFile = strXmlFile.Replace(".exe", ".xml");
        }
        public void DetDB()
        {
            strConnectionSetting = "server=" + GetXmlString("root/connectionsetting/server") + "; database=" + GetXmlString("root/connectionsetting/database") + ";uid=" + GetXmlString("root/connectionsetting/uid") + ";pwd=" + GetXmlString("root/connectionsetting/pwd");
            strSettingDBName = GetXmlString("root/connectionsetting/database");           
        }
        public string GetXmlString(string strNode)
        {
            //使用XmlDocument讀入XML格式資料
            XmlDocument xmlDoc = new XmlDocument();
            // string strPath = System.Windows.Forms.Application.StartupPath + strXmlFile;
            xmlDoc.Load(strXmlFile);
            //使用XmlNode讀取節點
            XmlNode strTag = xmlDoc.SelectSingleNode(strNode); //注意節點的指定方式
            return strTag.InnerText;
        }
    }
}
