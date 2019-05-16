using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class Triangle
    {
        public float a, b, c;

        public Triangle(float side1, float side2, float side3)
        {
            this.a = side1;
            this.b = side2;
            this.c = side3;
        }

        //проверка существования треугольника
        public static bool exists(float side1, float side2, float side3)
        {
            return side1 + side2 > side3 && side2 + side3 > side1 && side3 + side1 > side2;
        }

        //получить сторону
        public float getSide(int n)
        {
            switch (n)
            {
                case 0: return this.a;
                case 1: return this.b;
                case 2: return this.c;

                default: return 0;
            }
        }

        //найти угол
        public static float getAngle(float side1, float side2, float oppositeSide)
        {
            return (float)Math.Acos((side1 * side1 + side2 * side2 - oppositeSide * oppositeSide) / (2 * side1 * side2));
        }

        //найти периметр
        public float getPerimeter()
        {
            return a + b + c;
        }

        //найти площадь
        public float getSquare()
        {
            float p = getPerimeter() / 2; //полупериметр
            return (float)Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public String getInfo()
        {
            return "a = " + getSide(0) + "\r\nb = " + getSide(1) + "\r\nc = " + getSide(2) + "\r\nP = " + getPerimeter() + "\r\nS = " + getSquare() + "\r\n\r\n";
        }
    }
}
