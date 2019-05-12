using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG3
{
    /// <summary>
    /// Точка на плоскости
    /// </summary>
    class Tochka
    {
        private double x;


        /// <summary>
        /// Координата Х
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }
        }


        private double y;

        /// <summary>
        /// Координата Y
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public Tochka(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Tochka operator+(Tochka point1, Tochka point2)
        {
            return new Tochka(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Tochka operator -(Tochka point1, Tochka point2)
        {
            return new Tochka(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static Tochka operator*(double Num, Tochka point)
        {
            return new Tochka(point.X * Num, point.Y * Num);
        }

        public static Tochka operator *(Tochka point, double Num)
        {
            return new Tochka(point.X * Num, point.Y * Num);
        }

        public static Tochka operator *(int Num, Tochka point)
        {
            return new Tochka(point.X * Num, point.Y * Num);
        }

        public static Tochka operator *(Tochka point, int Num)
        {
            return new Tochka(point.X * Num, point.Y * Num);
        }

        public static Tochka operator /(Tochka point, double Num)
        {
            return new Tochka(point.X / Num, point.Y / Num);
        }

        public static Tochka operator /(Tochka point, int Num)
        {
            return new Tochka(point.X / Num, point.Y / Num);
        }

        /// <summary>
        /// Длина вектора
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(this.x * this.x + this.y * this.y);
            }
        }

    }
}
