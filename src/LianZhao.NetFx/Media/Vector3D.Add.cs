﻿namespace LianZhao.Media
{
    public partial struct Vector3D
    {
        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return Add(vector1, vector2);
        }

        public Vector3D Add(Vector3D other)
        {
            return Add(this, other);
        }

        public static Point3D Add(Vector3D vector, Point3D point)
        {
            return new Point3D(vector._x + point._x, vector._y + point._y, vector._z + point._z);
        }

        public static Point3D operator +(Vector3D vector, Point3D point)
        {
            return Add(vector, point);
        }

        public Point3D Add(Point3D point)
        {
            return Add(this, point);
        }
    }
}