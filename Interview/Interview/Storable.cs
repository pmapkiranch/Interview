using System;

namespace Interview
{
    public class Storable : IStoreable
    {
        private IComparable _id;

        public IComparable Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id=value;
            }
        }
    }
}