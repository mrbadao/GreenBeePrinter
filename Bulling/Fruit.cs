using System;
using System.Drawing;

namespace Billing {

    public class Fruit {
        public string id;
        public string name;
        public string image_name;
        public Image image_print;
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
            this.image_print = null;
            this.id = "";
            this.name = "";
            this.image_name = "";
            this.Kcal = this.Fiber = this.VA = this.VB = this.VC = this.VB1 = this.VB2 = this.VE = this.Ca = this.Ka = 0;   

        }

        public Fruit(int Kcal, int Fiber, int VA, int VB, int VB1, int VB2, int VE, int VC, int Ca, int Ka)
        {
            this.image_print = null;
            this.id = "";
            this.name = "";
            this.image_name = "";
            this.Kcal = Kcal;
            this.Fiber = Fiber;
            this.VA = VA;
            this.VB = VB;
            this.VB1 = VB1;
            this.VB2 = VB2;
            this.VE = VE;
            this.VC = VC;
            this.Ca = Ca;
            this.Ka = Ka;

        }

        public static Fruit operator +(Fruit c1, Fruit c2)
        {
            return new Fruit(c1.Kcal + c2.Kcal, c1.Fiber + c2.Fiber,
                c1.VA + c2.VA, c1.VB + c2.VB, 
                c1.VB1 + c2.VB1, c1.VB2 + c2.VB2,
                c1.VE + c2.VE, c1.VC + c2.VC, c1.Ca + c2.Ca, c1.Ka + c2.Ka);
        }

        public string ToString()
        {
            return
                this.Kcal.ToString() + " " + this.Fiber.ToString() + " " +
                this.VA.ToString() + " " + this.VB.ToString() + " " +
                this.VB1.ToString() + " " + this.VB2.ToString() + " " +
                this.VE.ToString() + " " + this.VC.ToString() + " " +
                this.Ca.ToString() + " " + this.Ka.ToString() + " ";
        }
    }
}