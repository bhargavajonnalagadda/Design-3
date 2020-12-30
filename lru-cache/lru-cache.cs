    }
    
    private void add(Node curr)
    {
        curr.next = head.next;
        head.next.prev = curr;
        curr.prev = head;
        head.next = curr;
    }
    
    public int Get(int key) {
        
        if(map.ContainsKey(key))
        {
            Node n = map[key];
            remove(n);
            add(n);
            return n.value;
        }
        return -1;
        
    }
    
    public void Put(int key, int value) {
        Node n = head;
        if(map.ContainsKey(key))
        {
            n = map[key];
            n.value = value;
            remove(n);
            add(n);
            return;
        }
        else if (cap == map.Count)
        {
            int temp = tail.prev.key;
            remove(tail.prev);
            map.Remove(temp);
        }
        n = new Node(key,value);
        
        add(n);
        map.Add(key,n);
        
    }
}
​
/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
