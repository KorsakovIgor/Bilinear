using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KG3
{
    /// <summary>
    /// Точка в пространстве
    /// </summary>
    class Tochka3D
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

        private double z;
        /// <summary>
        /// Координата Z
        /// </summary>
        public double Z
        {
            get
            {
                return this.z;
            }
        }

        public Tochka3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Cоответствующая  2D-точка
        /// </summary>
        public Tochka To2D
        {
            get
            {
                return new Tochka(this.x + this.y, this.z + this.y);
            }
        }

    }
}
