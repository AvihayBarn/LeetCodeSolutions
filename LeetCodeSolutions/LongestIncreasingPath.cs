using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutions
{
    public class WordsDic
    {
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
           
                var dp = new List<string>[s.Length];
                var hash = new HashSet<string>(wordDict);
                for (int i = 0; i < s.Length; i++)
                {
                    dp[i] = Enumerable
                        .Range(-1, i + 1)
                        .Where(x => (x == -1 || dp[x].Count > 0) &&
                            hash.Contains(s.Substring(x + 1, i - x)))
                        .SelectMany(x => x == -1 ?
                            new[] { "" }.Select(p => s.Substring(x + 1, i - x)) :
                            dp[x].Select(p => $"{p} {s.Substring(x + 1, i - x)}"))
                        .ToList();
                }
                return dp.Last();


        }
      
    }
    public class LongestIncreasingPathClass
    {
        public static int LongestIncreasingPath(int[][] matrix)
        {
            int longestIncreasingPath = 1;
            int m = matrix.Length , n = matrix[0].Length;
            for(int i = 0;i<m;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    
                    longestIncreasingPath = Math.Max(longestIncreasingPath, LongestIncreasingPath(matrix, i, j,new PointContainer()).Length());
                }

            }
            return longestIncreasingPath;

        }

        private static PointContainer LongestIncreasingPath(int[][] matrix,int x1,int y1,PointContainer con)
        {
            if((x1 >= 0 && x1 < matrix.Length) && ((y1 >= 0 && y1 < matrix[0].Length))  && matrix[x1][y1] > con.LastIndexValue(matrix) && !con.Contains(x1,y1))
            {
                con.Add(x1, y1);
                int current = matrix[x1][y1];
                PointContainer con1 , con2, con3, con4 ;
                con1 = LongestIncreasingPath(matrix, x1 + 1, y1, new PointContainer(con));
                con2 = LongestIncreasingPath(matrix, x1 , y1 + 1,new PointContainer(con));
                con3 = LongestIncreasingPath(matrix, x1 - 1 , y1,new PointContainer(con));
                con4 = LongestIncreasingPath(matrix, x1 , y1 - 1,new PointContainer(con));
                return PointContainer.LargestContainer(new List<PointContainer>(new PointContainer[]{ con1, con2, con3, con4 }));
            }

            return con;
        }

        private class PointContainer
        {
            private Stack<KeyValuePair<int, int>> container;
            private int i, j;
            public PointContainer()
            {
                container = new Stack<KeyValuePair<int, int>>();

            }
            public PointContainer(PointContainer con)
            {
                container = new Stack<KeyValuePair<int, int>>(con.container);
                this.i = con.i;
                this.j = con.j;

            }
            public bool Contains(int x , int y)
            {
                return container.Any(point => (point.Key == x && point.Value == y));
            }
            public void Add(int x, int y)
            {
                i = x;
                j = y;
                container.Push(new KeyValuePair<int, int>(x, y));
            }
          
            public int Length()
            {
                return container.Count();
            }

            internal static PointContainer LargestContainer(List<PointContainer> pointContainers)
            {
                PointContainer largestPointContainer = new PointContainer();
                pointContainers.ForEach(pc =>
                {
                    if(!pc.Equals(null))
                    largestPointContainer = (pc.Length() > largestPointContainer.Length()) ? pc : largestPointContainer;
                });
                return largestPointContainer;
            }

            public int LastIndexValue(int[][] matrix)
            {
                if (container.Count == 0) return int.MinValue;
                else return matrix[i][j];
            }
        }

        
    }
}
