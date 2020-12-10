using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySetOfClases
{
    
    public class ClassPhone
    {
        private int id;
        private string model;
        private string marka;
        private int camera;
        private int memory;
        private int battery;
        private double price;
        private string description;
        private int count;
        public int IDPhone { get { return id; }  set { id = value; } }
    
        public string Model { get { return model; } set { model = value; }}
        public string Marka { get { return marka; } set { marka = value; } }
        public int Camera { get { return camera; } set { camera = value; } }
        public int Memory { get { return memory; } set { memory = value; } }
        public int Battery { get { return battery; } set { battery = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Desc { get { return description; } set { description = value; } }
        public int Count { get { return count; } set { count = value; } }
        public ClassPhone()
        {
            id = 0;
            model = "";marka = "";camera = 1;
            memory = 1;battery = 1;price = 1;
            description = ""; count = 0;
        }

    }
}
