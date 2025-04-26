namespace MultithreadingConsoleApp;

public class SafeQueue<T>
{
    private readonly Queue<T> _items;
    private readonly object _lock;

    public SafeQueue()
    {
        _items = [];
        _lock = new();
    }

    public void Enqueue(T item)
    {
        lock (_lock)
        {
            _items.Enqueue(item);
            // notify all threads which were waiting for the pulse on this
            // lock object that after lock is released in this section 
            // they can continue execution
            Monitor.Pulse(_lock);
        }
    }

    public T Dequeue()
    {
        lock (_lock)
        {
            // while because Pulse method can be called before wait
            // and then no item will be ever dequeued
            while (_items.Count == 0)
            {
                // blocks the thread which called this method until the other
                // thread will call Pulse method on the same lock object
                // release lock
                Monitor.Wait(_lock);
            }

            return _items.Dequeue();
        }
    }
}