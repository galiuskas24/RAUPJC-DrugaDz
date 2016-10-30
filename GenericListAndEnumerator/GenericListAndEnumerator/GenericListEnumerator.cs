using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericListAndEnumerator
{
    class GenericListEnumerator<X> : IEnumerator<X>
    {
        IGenericList<X> _list;
        private int count = 0;

        public GenericListEnumerator(IGenericList<X> collection)
        {
            _list = collection;
        }

        public X Current
        {
            get
            {
                return _list.GetElement(count++);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            if (count >= _list.Count)
            {
                return false;
            }
            return true;
        }

        public void Reset()
        {
            count = 0;
        }

        public void Dispose()
        {
        }
    }
}