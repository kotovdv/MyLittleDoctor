using System;
using System.Collections.Generic;

namespace MyLittleDoctor.Util
{
    public static class LinqExtensions
    {
        public static void RemoveAll<T>(this LinkedList<T> list, Predicate<T> match)
        {
            var current = list.First;
            while (current != null)
            {
                var next = current.Next;
                
                if (match.Invoke(current.Value))
                    list.Remove(current);

                current = next;
            }
        }
    }
}