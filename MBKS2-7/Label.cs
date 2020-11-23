using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBKS2_7
{
    [Serializable]
    public class Label
    {
        public int[] users=new int[] {3,1,1,1};
        public int[] files;


        public Label(List<string> AllFiles)
        {
            files = new int[AllFiles.Count];
            int j = AllFiles.FindIndex(x => x == "D:\\Matrix\\Label.txt");
            for(int i = 0; i < AllFiles.Count; i++)
            {
                if (i == j) files[i] = 3;
                files[i] = 1;
            }
        }

        Label()
        {

        }
    }
}
