using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    public class XML
    {
        private XMLDao dao;
        public  XML()
        {
            this.dao = new XMLDao();
        }
        public List<Number.Number_539> GetXML_539(string path)
        {
            return this.dao.GetXML_539(path);
        }
    }
}
