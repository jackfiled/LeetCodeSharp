// [2296] Design a Text Editor


namespace LeetCodeSharp.Problems2296
{
    // Submission codes start here

    using System.Collections.Generic;
    using System.Linq;

    public class TextEditor
    {
        private readonly LinkedList<char> _text = new();

        // 让游标就是光标左边的字符
        private LinkedListNode<char> _cursor;

        public TextEditor()
        {
            _cursor = _text.First;
        }

        public void AddText(string text)
        {
            // 说明光标位于起始位置
            // 右边可能有字符可能没有字符
            if (_cursor is null)
            {
                _cursor = _text.AddFirst(text[0]);

                foreach (int i in Enumerable.Range(1, text.Length - 1))
                {
                    _cursor = _text.AddAfter(_cursor, text[i]);
                }

                return;
            }

            foreach (char c in text)
            {
                _cursor = _text.AddAfter(_cursor, c);
            }
        }

        public int DeleteText(int k)
        {
            int result = 0;

            foreach (int _ in Enumerable.Range(0, k))
            {
                if (_cursor is null)
                {
                    break;
                }

                LinkedListNode<char> lastNode = _cursor.Previous;
                _text.Remove(_cursor);
                result += 1;

                _cursor = lastNode;
            }

            return result;
        }

        public string CursorLeft(int k)
        {
            foreach (int _ in Enumerable.Range(0, k))
            {
                // 前进的时候倒是可以移动出去
                if (_cursor is null)
                {
                    break;
                }

                _cursor = _cursor.Previous;
            }

            return GetLeftStringOfCursor(_cursor);
        }

        public string CursorRight(int k)
        {
            foreach (int _ in Enumerable.Range(0, k))
            {
                // 如果游标为空
                // 此时位于文本的起始
                if (_cursor is null)
                {
                    _cursor = _text.First;
                    if (_cursor is null)
                    {
                        return string.Empty;
                    }

                    continue;
                }

                // 移动的时候不能移动出去了
                if (_cursor.Next is null)
                {
                    break;
                }

                _cursor = _cursor.Next;
            }

            return GetLeftStringOfCursor(_cursor);
        }

        private string GetLeftStringOfCursor(LinkedListNode<char> node)
        {
            List<char> buffer = new List<char>();

            while (node != null)
            {
                if (buffer.Count >= 10)
                {
                    break;
                }

                buffer.Add(node.Value);
                node = node.Previous;
            }

            return buffer.AsEnumerable().Reverse().Aggregate(string.Empty, (str, c) => str + c);
        }
    }

    // Submission codes end here
}