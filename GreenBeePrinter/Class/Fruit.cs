using System;

namespace GreenBeePrinter {

    class Fruit {
        public string id;
        public string name;
        public string image_name;
        public int Kcal;
        public int Fiber;
        public int VA;
        public int VB;
        public int VB1;
        public int VB2;
        public int VC;
        public int VE;
        public int Ca;
        public int Ka;

        public Fruit()
        {
            this.id = "";
            this.name = "";
            this.image_name = "";
            this.Kcal = this.Fiber = this.VA = this.VB = this.VB1 = this.VB2 = this.VE = this.Ca = this.Ka = 0;   

        }
    }
}