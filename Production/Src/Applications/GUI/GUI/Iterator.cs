//Rebecca Hoerner
//Personal Project
//Iterator Design Pattern

using SAD.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public interface IIterator
    {
        object First();
        object Last();
        object Next();
        object Previous();
        bool IsDone();
        object CurrentItem();
    }

    public class Iterator: IIterator
    {
        private myCollection collection;

        private int currentSpot = 0;
        public Iterator(myCollection aCollection)
        {
            this.collection = aCollection;
        }
        public object First()
        {

            return collection[0];
        }

        public object Last()
        {
            currentSpot = collection.ItemCount - 1;
            return collection[collection.ItemCount - 1];
        }

        public object Next()
        {
            if (!IsDone())
            {
                object anObject = collection[currentSpot];
                currentSpot++;
                return anObject;
            }
            else
                return null;
        }

        public object Previous()
        {
            if (!IsDone())
            {
                object anObject = collection[currentSpot];
                currentSpot--;
                return anObject;
            }
            else
                return null;
        }

        public bool IsDone()
        {
            if (currentSpot >= collection.ItemCount || currentSpot < 0)
                return true;
            else
                return false;
        }

        public object CurrentItem()
        {
            return collection[currentSpot];
        }
    }

    public interface ICollection
    {
        Iterator CreateIterator();
    }

    public class myCollection: ICollection
    {
        private ArrayList items = new ArrayList();
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }

        public int ItemCount
        {
            get
            {
                return items.Count;
            }
        }

        public object this[int i]
        {
            get
            {
                return items[i];
            }
            set
            {
                items.Add(value);
            }
        }
    }
}

