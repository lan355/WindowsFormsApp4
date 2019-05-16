using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class RightTriangle : Triangle
    {
            float l1, l2;

            public RightTriangle(float leg1, float leg2) : base(leg1, leg2, (float)Math.Sqrt(leg1 * leg1 + leg2 * leg2))
            {
                l1 = leg1;
                l2 = leg2;
            }

            public bool isRightTriangle()
            {
                return getAngle(base.a, base.b, base.c) == 90 || getAngle(base.b, base.c, base.a) == 90 || getAngle(base.a, base.c, base.b) == 90;
            }

            public float getHypotenuse()
            {
                return (float)Math.Sqrt(l1 * l1 + l2 * l2);
            }
        }
    }
