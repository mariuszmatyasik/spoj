using System.Text;

FiberNetwork net = new FiberNetwork();
string line;

StringBuilder sb = new();

while ((line = Console.ReadLine()) != null)
{
    string[] parts = line.Split();
    string command = parts[0];
    string ip1 = parts[1];
    string ip2 = parts[2];
    
    net.IpDeliver(ip1);
    net.IpDeliver(ip2);

    
    if (command == "B")
    {
        net.Union(ip1, ip2);
    } else if (command == "T")
    {
        if (net.Find(ip1) == net.Find(ip2))
        {
            sb.AppendLine("T");
        }
        else
        {
            sb.AppendLine("N");
        }
    }
}

Console.Write(sb.ToString());

class FiberNetwork
{
    private Dictionary<string, string> parent = new();
    private Dictionary<string, int> rank = new();

    public void Union(string ip1, string ip2)
    {
        string root1 = Find(ip1);
        string root2 = Find(ip2);

        if (root1 != root2)
        {
            if (rank[root1] > rank[root2])
            {
                parent[root2] = root1;
            } else if (rank[root1] < rank[root2])
            {
                parent[root1] = root2;
            }
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }
        
    }

    public string Find(string ip)
    {
        if (parent[ip] != ip)
        {
            parent[ip] = Find(parent[ip]);
        }

        return parent[ip];
    }

    public void IpDeliver(string ip)
    {
        if (!parent.ContainsKey(ip))
        {
            parent[ip] = ip;
            rank[ip] = 0;
        }
    }
}