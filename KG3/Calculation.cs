using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace KG3
{
    class Calculation
    {
        //Фигура, с которой работаем
        public Figure figure;
        public Calculation(string p1x, string p1y, string p1z, string p2x, string p2y, string p2z, string p3x, string p3y, string p3z, string p4x, string p4y, string p4z )
        {
            //Создаем фигуру
            this.figure = new Figure(new Tochka3D(Convert.ToDouble(p1x), Convert.ToDouble(p1y), Convert.ToDouble(p1z)), new Tochka3D(Convert.ToDouble(p2x), Convert.ToDouble(p2y), Convert.ToDouble(p2z)), new Tochka3D(Convert.ToDouble(p3x), Convert.ToDouble(p3y), Convert.ToDouble(p3z)), new Tochka3D(Convert.ToDouble(p4x), Convert.ToDouble(p4y), Convert.ToDouble(p4z)));

        }

        /// <summary>
        /// Создание Path для отрисовки фигуры
        /// </summary>
        /// <returns></returns>
        public Path PaintFigure()
        {
            return figure.MakeFigure();
        }

        /// <summary>
        /// Создание Path для повернутой фигуры
        /// </summary>
        /// <returns></returns>
        public Path RotateFigure(string Angle, string Axis)
        {
            //Вызываем метод поворота, тем самым меняя координаты точек фигуры
            figure.Rotation(Convert.ToDouble(Angle), Axis[0]);

            
            //Отрисовываем фигуру по измененным точкам
            return figure.MakeFigure();    
           
        }
    }
}
