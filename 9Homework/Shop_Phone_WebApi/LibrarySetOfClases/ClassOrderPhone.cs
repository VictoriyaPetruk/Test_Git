using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySetOfClases
{
    class ClassOrderPhone
    {
        private int id;
        private int idorder;
        private int idphone;
        private double sale;
        public int ID { get { return id; } }
        public int IDorder { get { return idorder; } set { idorder = value; } }
        public int IDphone { get { return idphone; } set { idphone = value; } }
        public double Sale { get { return sale; } set { sale = value; } }
        public ClassOrderPhone()
        {
            idorder = 0;
            idphone = 0;
            sale = 0;
        }
    }
}
