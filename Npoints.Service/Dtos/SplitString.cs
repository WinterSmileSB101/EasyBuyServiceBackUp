using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Npoints.Service.Dtos
{
   public  class SplitString
    {
        public  List<string> bySplit(string source, char mark  ) {
            string[] arr;
            List<string> list = new List<string>();
            arr = source.Split(mark);
            foreach(string a in arr)
            {
                list.Add(a);
            }
            return list;
        }
    }
}
