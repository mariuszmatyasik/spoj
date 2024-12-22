using System.Text;

int t = int.Parse(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    int n = int.Parse(Console.ReadLine());
    
    var friendsSet = new DisjointSet(n * 2);
    Dictionary<string, int> people = new Dictionary<string, int>();
    StringBuilder sb = new StringBuilder();
    int p = 0;
    int q = 1;
    
     for (int j = 0; j < n; j++)
     {
         string[] tmp = Console.ReadLine().Split();
         
         if (people.Count == 0)
         {
             people.Add(tmp[0], p);
             people.Add(tmp[1], q);
             friendsSet.Union(p, q);
             
         }
         else
         {
             if (people.ContainsKey(tmp[0]))
             {
                 q++;
                 people.Add(tmp[1], q);
                 if (!friendsSet.AreInSameSet(p, q)) // wywołanie Find
                     friendsSet.Union(p, q);         // wywołanie Union
             
             }
             else if (people.ContainsKey(tmp[1]))
             {
                 p++;
                 people.Add(tmp[0], p);
                 if (!friendsSet.AreInSameSet(q, p)) // wywołanie Find
                     friendsSet.Union(q, p);         // wywołanie Union
                
             } 
             else
             {
                 p++;
                 q++;
                 people.Add(tmp[0], p);
                 people.Add(tmp[1], q);
                 if (!friendsSet.AreInSameSet(p, q)) // wywołanie Find
                     friendsSet.Union(p, q);
                
             }
             p++;
             q++;
         }

         sb.AppendLine(friendsSet.SizeOfSubset(j).ToString());
     }

     Console.WriteLine(friendsSet.NumberOfSubsets);
     Console.WriteLine(sb);

     
}


public class DisjointSet
{
    private int[] parent; //odwołanie do przodka
    private int[] size; //rozmiar drzewa reprezentującego zbiór

    public int Size => parent.Length;

    // konstruktor (nie ma konstruktora domyślnego)
    public DisjointSet(int N)
    {
        parent = new int[N];
        size = new int[N];
        for (int i = 0; i < N; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }
        NumberOfSubsets = N;
    }

    // Zwraca indeks reprezentanta zbioru, do którego należy element o indeksie `index`
    public int Find(int index) => root(index);

    private int root(int i)
    {
        while (i != parent[i])
        {
            parent[i] = parent[parent[i]];
            i = parent[i];
        }
        return i;
    }

    public bool AreInSameSet(int index1, int index2) => root(index1) == root(index2);

    public void Union(int index1, int index2)
    {
        int i = root(index1), j = root(index2);

        if( i == j ) // należą do tego samego zbioru
            return;

        if( size[i] < size[j] )
        {
            parent[i] = j;
            size[j] += size[i];
        }
        else
        {
            parent[j] = i;
            size[i] += size[j];
        }
        NumberOfSubsets--;
    }

    // ---- metody dodatkowe, spoza interfejsu

    // Zwraca rozmiar zbioru, do którego należy element o indeksie `index`
    public int SizeOfSubset(int index) => size[root(index)];

    public int NumberOfSubsets {get; private set;}
}