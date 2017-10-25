using System;

namespace HK.Ungya.Primitive
{
    [Serializable]
    public struct RangeInt
    {
        public int Min;

        public int Max;

        public int Random
        {
            get { return UnityEngine.Random.Range(this.Min, this.Max + 1); }
        }
    }
}
