﻿using System;
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
        public StatusType InsertData_539(Number.Number_539 m539, string path)
        {
            return this.dao.InsertData_539(m539, path);
        }
        public StatusType UpData_539(Number.Number_539 m539, int B_No, string path)
        {
            return this.dao.UpData_539(m539, B_No, path);
        }
    }
}
