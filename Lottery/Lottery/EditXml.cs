using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace Lottery
{
    public class EditXml
    {
        public static string HttpPath;
        public static string GroupName;

        public class Today
        {
            public string Date;
            public int Period;
            public int No1;
            public int No2;
            public int No3;
            public int No4;
            public int No5;
        }
        public static List<Today> mToday;

        public string m_strXmlFile;

        public class UserID
        {
            public string ID;
            public string UserName;
        }
        public class GroupID
        {
            public string ID;
            public string GroupName;
        }

        public static List<UserID> m_UserID;
        public static List<GroupID> m_GroupID;

        public EditXml()
        {
            m_strXmlFile = this.GetType().Assembly.Location;
            m_strXmlFile = m_strXmlFile.Replace(".exe", ".xml");
        }
        public void GetData()
        {
            mToday = new List<Today>();

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(m_strXmlFile);

            //使用XmlNode讀取節點
            foreach (XmlNode item in xmlDoc.SelectNodes("root/Today"))
            {
                var _today = new Today
                {
                    Date = ((XmlElement)item).GetAttribute("Date"),
                    Period = Convert.ToInt32(((XmlElement)item).GetAttribute("Period")),
                    No1 = Convert.ToInt32(((XmlElement)item).GetAttribute("No1")),
                    No2 = Convert.ToInt32(((XmlElement)item).GetAttribute("No2")),
                    No3 = Convert.ToInt32(((XmlElement)item).GetAttribute("No3")),
                    No4 = Convert.ToInt32(((XmlElement)item).GetAttribute("No4")),
                    No5 = Convert.ToInt32(((XmlElement)item).GetAttribute("No5"))
                };

                mToday.Add(_today);
            }
        }
        public void SetData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(m_strXmlFile);

            XmlNode xmlNode = xmlDoc.SelectSingleNode("root");
            if (xmlNode == null)
                return;
            XmlElement mainNode = (XmlElement)xmlNode;
            mainNode.RemoveAll();
            foreach (var item in EditXml.mToday)
            {
                XmlElement info = xmlDoc.CreateElement("Today");
                info.SetAttribute("Date", item.Date);
                info.SetAttribute("Period", item.Period.ToString());
                info.SetAttribute("No1", string.Format("{0:00}", item.No1));
                info.SetAttribute("No2", string.Format("{0:00}", item.No2));
                info.SetAttribute("No3", string.Format("{0:00}", item.No3));
                info.SetAttribute("No4", string.Format("{0:00}", item.No4));
                info.SetAttribute("No5", string.Format("{0:00}", item.No5));
                mainNode.AppendChild(info);
            }
            xmlDoc.Save(m_strXmlFile);
        }

        public void SetIDArray()
        { //使用XmlDocument讀入XML格式資料
            XmlDocument xmlDoc = new XmlDocument();
            // string strPath = System.Windows.Forms.Application.StartupPath + strXmlFile;
            xmlDoc.Load(m_strXmlFile);
           // SetData();
            //使用XmlNode讀取節點
            foreach (XmlNode item in xmlDoc.SelectNodes("root/UserID"))
            {
                UserID _UserID = new UserID
                {
                    UserName = ((XmlElement)item).GetAttribute("name"),
                    ID = item.InnerText
                };

                m_UserID.Add(_UserID);
            }

            foreach (XmlNode item in xmlDoc.SelectNodes("root/GroupID"))
            {
                GroupID _GroupID = new GroupID
                {
                    GroupName = ((XmlElement)item).GetAttribute("name"),
                    ID = item.InnerText
                };
                m_GroupID.Add(_GroupID);
            }
        }

       public string GetXmlString(string strNode)
        {
            //使用XmlDocument讀入XML格式資料
            XmlDocument xmlDoc = new XmlDocument();
            // string strPath = System.Windows.Forms.Application.StartupPath + strXmlFile;
            xmlDoc.Load(m_strXmlFile);
            //使用XmlNode讀取節點
            XmlNode strTag = xmlDoc.SelectSingleNode(strNode); //注意節點的指定方式
            
            return strTag.InnerText;
        }

        public string GetXmlStringWithExceptionHandle(string strNode)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(this.m_strXmlFile);

            XmlNode strTag;

            try
            {
                strTag = xmlDoc.SelectSingleNode(strNode);

                return strTag.InnerText;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
