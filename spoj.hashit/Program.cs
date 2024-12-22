
using System.Text;

int t = Convert.ToInt32(Console.ReadLine());

for (int i = 0; i < t; i++)
{
    string[] table = new string[101];
    
    int n = Convert.ToInt32(Console.ReadLine());
    for (int j = 0; j < n; j++)
    {
        string? line = Console.ReadLine();
        string op = line.Substring(0, 3);
        string key = line.Substring(4);
        int index = FindKey(table, key);

        if (op == "ADD")
        {
            if (index == -1)
            {
                index = FindNextOpenAddress(table, Hash(key));
                if (i >= 0)
                {
                    table[index] = key;
                }
            }
        }
        else
        {
            if (index >= 0)
            {
                table[index] = string.Empty;
            }
        }
    }
    StringBuilder sb = new StringBuilder();
    int count = 0;
    for (int j = 0; j < 101; j++)
    {
        if (!string.IsNullOrEmpty(table[j]))
        {
            count++;
            sb.AppendLine(j + ":" + table[j]);
        }
    }
    Console.WriteLine(count);
    Console.Write(sb.ToString());
}


static int Hash(string key)
{
    int hashed = h(key) % 101;
    return hashed;
}

static int h(string key)
{
    int res = 0;
    int count = key.Length;
    for (int i = 0; i < count; i++)
    {
        res += key[i] * (i + 1);
    }
    return res * 19;
}
static int FindKey(string[] table, string key)
{
    int hashIndex = Hash(key);
    
    if (table[hashIndex] == key)
        return hashIndex;
    
    for (int j = 1; j < 20; j++)
    {
        int newIndex = (hashIndex + j * j + 23 * j) % 101;
        if (table[newIndex] == key)
        {
            return newIndex;
        }
    }
    return -1;
}

static int FindNextOpenAddress(string[] table, int i)
{
    if (string.IsNullOrEmpty(table[i]))
        return i;
    for (int j = 1; j < 20; j++)
    {
        int newIndex = (i + j * j + 23 * j) % 101;
        if (string.IsNullOrEmpty(table[newIndex]))
        {
            return newIndex;
        }
    }
    return -1;
}