using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace KG3
{
    /// <summary>
    /// Представляет из себя Фигуру по 4м точкам
    /// </summary>
    class Figure
    {
        Tochka3D LeftTop3D;
        Tochka3D RightTop3D;
        Tochka3D LeftBot3D;
        Tochka3D RightBot3D;

        public Figure(Tochka3D point1, Tochka3D point2, Tochka3D point3, Tochka3D point4)
        {
            List<Tochka3D> points = new List<Tochka3D> { point1, point2, point3, point4 };
            //TODO
            //Сортировка по х
            for(int i=0; i<2;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (points[j].To2D.X > points[j + 1].To2D.X)
                    {
                        points.Reverse(j, j + 1);
                        //Swap(points[j], points[j + 1]);
                    }
                }
            }

            //Заполнение переменных
            if(points[0].To2D.Y<points[1].To2D.Y)
            {
                this.LeftBot3D = points[0];
                this.LeftTop3D = points[1];

                if(points[2].To2D.Y<points[3].To2D.Y)
                {
                    this.RightBot3D = points[2];
                    this.RightTop3D = points[3];

                }

                else
                {
                    this.RightBot3D = points[3];
                    this.RightTop3D = points[2];
                }
            }
            else
            {
                this.LeftBot3D = points[1];
                this.LeftTop3D = points[0];

                if (points[2].To2D.Y < points[3].To2D.Y)
                {
                    this.RightBot3D = points[2];
                    this.RightTop3D = points[3];

                }

                else
                {
                    this.RightBot3D = points[3];
                    this.RightTop3D = points[2];
                }
            }
        }

        
        /// <summary>
        /// Создает список точек между начальной точкой и конечной включительно на равном расстоянии друг от друга в заданном количестве
        /// </summary>
        /// <param name="start">Начальная точка</param>
        /// <param name="finish">Конечная точка</param>
        /// <param name="count">Кол-во точек между начальной и конечной</param>
        /// <returns></returns>
        private List<Tochka> Grid (Tochka start, Tochka finish, int count)
        {
            List<Tochka> result = new List<Tochka>();

            //Добавляем начальную точку
            result.Add(start);

            //Создаем вектор из старта в финиш
            Tochka vector = finish - start;

            //Нормируем, теперь длина равна 1
            if (vector.Length != 0)
            {
                vector = vector / (vector.Length);
            }

            //Делаем длину вектора такой, чтоб он отложился между стартом и финишем Count+1 раз
            vector = vector * ((finish - start).Length) / (count + 1); 

            //Формируем список точек между стартом и финишем на одинаковом расстоянии
            for(int i=1; i<count+1; i++)
            {
                result.Add(result[i - 1] + vector);
            }
            
            //Добавляем конечную точку в список
            result.Add(finish);

            return result;
        }

        /// <summary>
        /// Рисуем линию
        /// </summary>
        /// <returns></returns>
        public LineGeometry DrowLine(Tochka p1, Tochka p2)
        {
            LineGeometry myLine = new LineGeometry();
            myLine.StartPoint = new System.Windows.Point(p1.X, 500-p1.Y);
            myLine.EndPoint = new System.Windows.Point(p2.X, 500-p2.Y);
            return myLine;
        }

        /// <summary>
        /// Создание Фигуры
        /// </summary>
        /// <returns></returns>
        public Path MakeFigure()
        {
            //TODO
            
            //Реализовать рисовалку
            Tochka LeftTop = this.LeftTop3D.To2D;
            Tochka LeftBottom = this.LeftBot3D.To2D;
            Tochka RightBottom = this.RightBot3D.To2D;
            Tochka RightTop = this.RightTop3D.To2D;
            //Создаем коллекцию для хранения геометрии
            PathGeometry myPathG = new PathGeometry();
            Path mypath = new Path();
            mypath.Stroke = Brushes.White;
            mypath.StrokeThickness = 1;
            //Рисуем две опорные линии
            myPathG.AddGeometry(DrowLine(LeftTop, RightTop));
            myPathG.AddGeometry(DrowLine(LeftBottom, RightBottom));
            //Создаем списки точек на линиях
            List<Tochka> top = Grid(LeftTop, RightTop, 20);
            List<Tochka> bot = Grid(RightBottom, LeftBottom, 20);
            //Рисуем опорные линии
            for(int i=0;i<top.Count;i++)
            {
                myPathG.AddGeometry(DrowLine(top[i], bot[i]));
            }
            
            mypath.Data = myPathG;
            return mypath;
        }

        /// <summary>
        /// Поворот фигуры
        /// </summary>
        /// <param name="Angle">Угол</param>
        /// <param name="Axis">Ось, относительно которой осуществляется поворот</param>
        public void Rotation(double Angle, char Axis)
        {
            //TODO
            Angle = Angle * Math.PI / 180;
            if (Axis == 'x')
            {
                //По формуле меняем координаты 4х точек (Атрибутов этого же класса)
                double NewLeftTop3Dx = LeftTop3D.X * 1;
                double NewLeftTop3Dy = LeftTop3D.Y * Math.Cos(Angle) - LeftTop3D.Z * Math.Sin(Angle);
                double NewLeftTop3Dz = LeftTop3D.Y * Math.Sin(Angle) + LeftTop3D.Z * Math.Cos(Angle);
                this.LeftTop3D = new Tochka3D(NewLeftTop3Dx, NewLeftTop3Dy, NewLeftTop3Dz);

                double NewLeftBot3Dx = LeftBot3D.X * 1;
                double NewLeftBot3Dy = LeftBot3D.Y * Math.Cos(Angle) - LeftBot3D.Z * Math.Sin(Angle);
                double NewLeftBot3Dz = LeftBot3D.Y * Math.Sin(Angle) + LeftBot3D.Z * Math.Cos(Angle);
                this.LeftBot3D = new Tochka3D(NewLeftBot3Dx, NewLeftBot3Dy, NewLeftBot3Dz);

                double NewRightTop3Dx = RightTop3D.X * 1;
                double NewRightTop3Dy = RightTop3D.Y * Math.Cos(Angle) - RightTop3D.Z * Math.Sin(Angle);
                double NewRightTop3Dz = RightTop3D.Y * Math.Sin(Angle) + RightTop3D.Z * Math.Cos(Angle);
                this.RightTop3D = new Tochka3D(NewRightTop3Dx, NewRightTop3Dy, NewRightTop3Dz);

                double NewRightBot3Dx = RightBot3D.X * 1;
                double NewRightBot3Dy = RightBot3D.Y * Math.Cos(Angle) - RightBot3D.Z * Math.Sin(Angle);
                double NewRightBot3Dz = RightBot3D.Y * Math.Sin(Angle) + RightBot3D.Z * Math.Cos(Angle);
                this.RightBot3D = new Tochka3D(NewRightBot3Dx, NewRightBot3Dy, NewRightBot3Dz);
                //Вызываем метод MakeFigure, который нарисует фигуру по новым точкам
            }
            else
            {
                if(Axis=='y')
                {
                    //По формуле меняем координаты 4х точек (Атрибутов этого же класса)
                    double NewLeftTop3Dx = LeftTop3D.X * Math.Cos(Angle) - LeftTop3D.Z * Math.Sin(Angle);
                    double NewLeftTop3Dy = LeftTop3D.Y * 1;
                    double NewLeftTop3Dz = LeftTop3D.X * Math.Sin(Angle) + LeftTop3D.Z * Math.Cos(Angle);
                    this.LeftTop3D = new Tochka3D(NewLeftTop3Dx, NewLeftTop3Dy, NewLeftTop3Dz);

                    double NewLeftBot3Dx = LeftBot3D.X * Math.Cos(Angle) - LeftBot3D.Z * Math.Sin(Angle);
                    double NewLeftBot3Dy = LeftBot3D.Y * 1;
                    double NewLeftBot3Dz = LeftBot3D.X * Math.Sin(Angle) + LeftBot3D.Z * Math.Cos(Angle);
                    this.LeftBot3D = new Tochka3D(NewLeftBot3Dx, NewLeftBot3Dy, NewLeftBot3Dz);

                    double NewRightTop3Dx = RightTop3D.X * Math.Cos(Angle) - RightTop3D.Z * Math.Sin(Angle);
                    double NewRightTop3Dy = RightTop3D.Y * 1;
                    double NewRightTop3Dz = RightTop3D.X * Math.Sin(Angle) + RightTop3D.Z * Math.Cos(Angle);
                    this.RightTop3D = new Tochka3D(NewRightTop3Dx, NewRightTop3Dy, NewRightTop3Dz);

                    double NewRightBot3Dx = RightBot3D.X * Math.Cos(Angle) - RightBot3D.Z * Math.Sin(Angle);
                    double NewRightBot3Dy = RightBot3D.Y * 1;
                    double NewRightBot3Dz = RightBot3D.X * Math.Sin(Angle) + RightBot3D.Z * Math.Cos(Angle);
                    this.RightBot3D = new Tochka3D(NewRightBot3Dx, NewRightBot3Dy, NewRightBot3Dz);


                    //Вызываем метод MakeFigure, который нарисует фигуру по новым точкам
                }
            }
        }
    }
}
