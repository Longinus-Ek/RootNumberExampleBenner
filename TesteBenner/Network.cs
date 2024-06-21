using System;

namespace TesteBenner
{
    public class Network
    {
        private int numElements;
        private int[] parent;
        private int[] rank;

        public Network(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Número de elementos deve ser positivo.");

            numElements = n;
            parent = new int[n];
            rank = new int[n];

            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int p)
        {
            if (parent[p] != p)
                parent[p] = Find(parent[p]);
            return parent[p];
        }

        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ)
                return;

            if (rank[rootP] > rank[rootQ])
                parent[rootQ] = rootP;
            else if (rank[rootP] < rank[rootQ])
                parent[rootP] = rootQ;
            else
            {
                parent[rootQ] = rootP;
                rank[rootP]++;
            }
        }

        public void Connect(int p, int q)
        {
            if (p < 0 || p >= numElements || q < 0 || q >= numElements)
                throw new ArgumentException("Elementos devem estar dentro do intervalo válido.");

            Union(p, q);
        }

        public bool Query(int p, int q)
        {
            if (p < 0 || p >= numElements || q < 0 || q >= numElements)
                throw new ArgumentException("Elementos devem estar dentro do intervalo válido.");

            return Find(p) == Find(q);
        }
    }
}
