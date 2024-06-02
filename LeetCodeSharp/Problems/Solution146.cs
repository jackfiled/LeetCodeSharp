// [146] LRU Cache


using System.Collections.Generic;

namespace LeetCodeSharp.Problems146
{
    // Submission codes start here
    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _map;
        private readonly LinkedList<KeyValuePair<int, int>> _linkedList = new LinkedList<KeyValuePair<int, int>>();

        public LRUCache(int capacity)
        {
            _map = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var node))
            {
                return -1;
            }

            _linkedList.Remove(node);
            var newNode = new LinkedListNode<KeyValuePair<int, int>>(node.Value);
            _map[key] = newNode;
            _linkedList.AddFirst(newNode);

            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (_map.TryGetValue(key, out var existedNode))
            {
                _linkedList.Remove(existedNode);
                _map.Remove(key);
            }

            var node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
            _linkedList.AddFirst(node);
            _map.Add(key, node);

            if (_map.Count > _capacity)
            {
                var last = _linkedList.Last;

                if (last != null)
                {
                    _linkedList.RemoveLast();
                    _map.Remove(last.Value.Key);
                }
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    // Submission codes end here
}