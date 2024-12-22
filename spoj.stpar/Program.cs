


    while (true)
    {
        
        Stack<int> sideStreet = new();
        int req = 1;
        
        int n = int.Parse(Console.ReadLine());
        if (n == 0) break;

        int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
        bool possibility = true;
        
            foreach (var car in nums)
            {
                while(sideStreet.Count != 0 && sideStreet.Peek() == req)
                {
                    sideStreet.Pop();
                    req++;
                }

                if (car == req)
                {
                    req++;
                } else if (sideStreet.Count == 0 || sideStreet.Peek() > car)
                {
                    sideStreet.Push(car);
                }
                else
                {
                    possibility = false;
                    break;
                }
            }
            
            Console.WriteLine(possibility ? "yes" : "no");
        

    }
