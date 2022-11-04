using System.Collections.Generic;
using System.Linq;

namespace Core.Common.Queue {
    public class AppKeyValueQueue {
        private static Dictionary<string, Queue<object>> _queue = new Dictionary<string, Queue<object>>();
        private static Dictionary<string, UniqueQueue<object>> _uniqueQueue = new Dictionary<string, UniqueQueue<object>>();

        public static void AddItem(string key, object item) {
            lock (_queue) {
                if (!_queue.ContainsKey(key))
                    _queue[key] = new Queue<object>();

                _queue[key].Enqueue(item);
            }
        }

        public static void AddUniqueItem(string key, object item) {
            lock (_uniqueQueue) {
                if (!_uniqueQueue.ContainsKey(key))
                    _uniqueQueue[key] = new UniqueQueue<object>();

                _uniqueQueue[key].Enqueue(item);
            }
        }

        public static object GetItem(string key) {
            lock (_queue) {
                if (_queue.ContainsKey(key) && _queue[key].Count > 0)
                    return _queue[key].Dequeue();
            }
            return null;
        }

        public static object GetUniqueItem(string key) {
            lock (_uniqueQueue) {
                if (_uniqueQueue.ContainsKey(key) && _uniqueQueue[key].Count > 0)
                    return _uniqueQueue[key].Dequeue();
            }
            return null;
        }

        public static object GetQueueStats() {
            return new {
                GeneralQueues = new {
                    QueuesCount = _queue.Count,
                    Queues = _queue.Select(q => new {
                        QueueKey = q.Key,
                        TotalItems = q.Value.Count
                    }),
                },
                UniqueItemsQueues = new {
                    QueuesCount = _uniqueQueue.Count,
                    Queues = _uniqueQueue.Select(q => new {
                        QueueKey = q.Key,
                        TotalItems = q.Value.Count
                    })
                }
            };
        }

    }
}
