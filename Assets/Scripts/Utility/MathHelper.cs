using System;

namespace Assets.Scripts.Utility
{
    public static class MathHelper  {

        public static float Clamp(float value, float left, float right)
        {
            return Math.Max(left, Math.Min(value, right));
        }
    }
}
