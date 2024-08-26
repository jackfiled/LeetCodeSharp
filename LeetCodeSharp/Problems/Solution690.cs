// [690] Employee Importance


using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSharp.Problems690
{
    // Submission codes start here

    /*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

    class Employee
    {
        public int id;
        public int importance;
        public IList<int> subordinates;

        public Employee(int id, int importance, IList<int> subordinates)
        {
            this.id = id;
            this.importance = importance;
            this.subordinates = subordinates;
        }
    }

    class Solution
    {
        public int GetImportance(IList<Employee> employees, int id)
        {
            var map = employees.ToDictionary(e => e.id, e => e);

            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(id);

            var result = 0;
            while (queue.Count != 0)
            {
                var now = queue.Dequeue();

                result += map[now].importance;
                if (!visited.Add(now))
                {
                    continue;
                }

                foreach (var subordinate in map[now].subordinates)
                {
                    queue.Enqueue(subordinate);
                }
            }

            return result;
        }
    }

    // Submission codes end here
}