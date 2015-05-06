//Rebecca Hoerner
//Personal Project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SAD.Core.Data;

namespace GUI
{
    public class PriorityQueue<T> where T: IComparable<T>
    {
        private List<T> target_List;

        public PriorityQueue()
        {
            target_List = new List<T>();
        }

        public bool IsEmpty()
        {            
            return target_List.Count == 0;            
        }

        public int Count()
        {
            return target_List.Count;
        }
 
        public void AddItem(T aTarget)
        {
            target_List.Add(aTarget);

            int parent_node_index = 0;
            T temp;
            int child_node_index = target_List.Count - 1;
            
            while(child_node_index > 0)
            {
                parent_node_index = (child_node_index - 1) / 2;
                if (target_List[child_node_index].CompareTo(target_List[parent_node_index]) >= 0)
                    break; // Correct order for Binary Heap

                temp = target_List[child_node_index]; // Getting Child node in correct position
                target_List[child_node_index] = target_List[parent_node_index];
                target_List[parent_node_index] = temp;

                child_node_index = parent_node_index;
            }
        }

        public T RemoveItem()
        {
            int parent_node_index = 0;
            int child_node_index = 0;
            int right_child_index = 0;
            bool still_updating_heap = true;

            if (!IsEmpty())
            {
                int last_item_index = target_List.Count - 1;
                T front_item = target_List[0];
                target_List[0] = target_List[last_item_index];
                T temp;

                target_List.RemoveAt(last_item_index);

                last_item_index--;

                while (still_updating_heap)
                {
                    child_node_index = parent_node_index * 2 + 1;

                    if (child_node_index > last_item_index)
                        break;

                    right_child_index = child_node_index + 1;

                    if (right_child_index <= last_item_index && target_List[right_child_index].CompareTo(target_List[child_node_index]) < 0)
                        child_node_index = right_child_index;

                    if (target_List[parent_node_index].CompareTo(target_List[child_node_index]) <= 0)
                        break;

                    temp = target_List[parent_node_index];
                    target_List[parent_node_index] = target_List[child_node_index];
                    target_List[child_node_index] = temp;
                    parent_node_index = child_node_index;
                }
                return front_item;
            }
            else
                return default(T);
        }

        public T checkTopPriority()
        {
            T frontItem = target_List[0];
            return frontItem;
        }

        public List<T> getPriorityList()
        {
            return target_List;
        }


        public List<T> getReversePriorityQueue()
        {
            List<T> reverseList = new List<T>();

            return reverseList;
        }

        public List<T> reverseCurrentQueue()
        {
            //make iterator
            //have it reverse
            myCollection collection = new myCollection();

        //     Target ataadsfasf = new Target();

          //   collection[0] = ataadsfasf;

            int i =0;
          //  collection[i] = target_List[i];
            return target_List;
        }

    }
}
