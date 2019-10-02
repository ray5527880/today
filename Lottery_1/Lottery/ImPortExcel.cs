using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery
{
    public class ImPortExcel
    {
        private ImPortExcelDao dao;
        private GType GT { get; set; }
        public ImPortExcel(GType _GType)
        {
            GT = _GType;
            this.dao = new ImPortExcelDao();
        }
        public StatusType Load(string path)
        {
            if (GT == GType.L539)            
                return this.Load_539(path);            
            else
                return StatusType.Error;
        }
        public StatusType Insert()
        {
            if (GT == GType.L539)
                return Insert_539();
            else
                return StatusType.Ok;
        }
        private StatusType Load_539(string path)
        {
            return dao.Load_539(path);
        }
        private StatusType Insert_539()
        {
            return dao.Insert_539();
        }
    }
}
