using System.IO;

namespace _5;

readonly struct Map(int dest, int source, int range)
{
    public int DestinationRangeStart { get; init; } = dest;
    public int SourceRangeStart { get; init; } = source;
    public int RangeLength { get; init; } = range;

    public override String ToString() {

        return $"{DestinationRangeStart} {SourceRangeStart} {RangeLength}";

    }

}

class Category
{
    public String Desc {get; set;} = "";
    public List<Map> Maps {get; set;} = [];

    public Category(Category category) {
        this.Desc = category.Desc;
        this.Maps = category.Maps;
    }
    public Category() {

    }
}

class Program
{
    private static int MapRange(int value, Map map)
    {
        int destinationRangeEnd = map.DestinationRangeStart+map.RangeLength-1;

        if ( value < map.DestinationRangeStart || value > destinationRangeEnd)
        {
            return value;
        }
        int diff = map.DestinationRangeStart-map.SourceRangeStart;
        Console.WriteLine(diff);
        return value+diff;
    }

    // starting seeds
    private static List<int> Seeds {get; set;} = [];
    
    private static List<Category> Categories {get; set;} = [];
    

    static void Main(string[] args)
    {
        List<string> lines = [];

        // reading filev
        try {
            var sr = new StreamReader("/home/matixon/programowanie/adventofcode2023/5/input");
            
            var line = sr.ReadLine();
            lines.Add(line);
            while(line is not null) {
                line = sr.ReadLine();
                if(string.IsNullOrEmpty(line.Trim())) continue;
                lines.Add(line);
            }

        } catch(Exception){}
        
        // seeds
        {
            var line = lines[0];
            Seeds = line.Split(":")[1].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        }
        // maps
        {
            Category category = new();

            category.Desc = lines[1];
            for (int i = 2; i < lines.Count; i++)
            {
                //Console.WriteLine(lines[i]);
                if(char.IsDigit(lines[i][0])) {
                    var line = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    var map = new Map(line[0], line[1], line[2]);
                    category.Maps.Add( map );
                } else {
                    Categories.Add(new Category(category));
                    category = new();
                    category.Desc = lines[i];
                }
                
            }

        }

        foreach( var cat in Categories)
        {
            Console.WriteLine(cat.Desc);
            foreach( var map in cat.Maps)
            {
                Console.WriteLine("   " + map.ToString());
            }
        }

        // part 1
        Console.WriteLine(string.Join(",",Seeds));
        foreach(var cat in Categories)
        {
            foreach(var map in cat.Maps)
            {
                                    Console.WriteLine(map.ToString());
                    Console.Write(Seeds[0]);
                for (int i = 0; i < Seeds.Count; i++)
                {

                    Seeds[i] = MapRange(Seeds[i], map);


                    
                }
                                    Console.WriteLine(", "+Seeds[0]);
                    Console.WriteLine("===");
            }
        }
        Console.WriteLine(string.Join(",",Seeds));
    }
}
