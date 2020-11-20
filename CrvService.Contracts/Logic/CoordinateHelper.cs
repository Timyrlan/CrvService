using System;

namespace CrvService.Shared.Logic
{
    public static class CoordinateHelper
    {
        public static float GetDistance(float x1, float y1, float x2, float y2)
        {
            var x = Math.Abs(x1 - x2);
            var y = Math.Abs(y1 - y2);
            return (float) Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

        public static bool IsInRadius(float x, float y, float x2, float y2, float distance)
        {
            return GetDistance(x, y, x2, y2) < distance;
        }
    }
}