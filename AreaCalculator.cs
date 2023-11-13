namespace MindboxTest
{
    public class AreaCalculator
    {
        const double CalculationDelta = 1e-12;

        /// <summary>
        /// Returns false if radius is incorrect
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool CalcCircle(out double result, double radius)
        {
            result = 0;
            if (radius < 0 || radius == double.NaN || radius == double.NegativeZero)
            {
                return false;
            }
            result = Math.PI * radius * radius;
            return true;
        }

        /// <summary>
        /// Returns false if params are incorrect; the accuracy of determining the squareness is 1e-12
        /// </summary>
        /// <param name="result"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool CalcTriangle(out double result, out bool isTriangleRight, double a, double b, double c) 
        {
            isTriangleRight = false;
            if (c > a && c > b)
            {
                double calculation = a * a + b * b;
                if (c * c < calculation + CalculationDelta && c * c > calculation - CalculationDelta)
                {
                    isTriangleRight = true;
                }
            }
            if (b > a && b > c)
            {
                double calculation = a * a + c * c;
                if (b * b < calculation + CalculationDelta && b * b > calculation - CalculationDelta)
                {
                    isTriangleRight = true;
                }
            }
            if (a > b && a > c)
            {
                double calculation = b * b + c * c;
                if (a * a < calculation + CalculationDelta && a * a > calculation - CalculationDelta)
                {
                    isTriangleRight = true;
                }
            }
            bool isCorrect = CalcTriangle(out result, a, b, c);
            return isCorrect;
        }

        /// <summary>
        /// Returns false if params are incorrect
        /// </summary>
        /// <param name="result"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool CalcTriangle(out double result, double a, double b, double c)
        {
            result = 0;
            if (a < 0 || b < 0 || c < 0)
            {
                return false;
            }
            if (a + b < c || a + c < b || b + c < a)
            {
                return false;
            }
            double p = (a + b + c) / 2;
            result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return true;
        }
    }
}