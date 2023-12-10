using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

const int SIZE = 140;

char[,] lines = new char[SIZE,SIZE];

try {
    StreamReader sr = new("/home/matixon/programowanie/adventofcode2023/3/input");
    
    var line = sr.ReadLine();
    var x=0;
    while(line is not null)
    {
        char[] line_chars = line.ToCharArray();
        for (int i = 0; i < SIZE; i++)
        {
            lines[x,i] = line_chars[i];
            
        }
        x++;
        line = sr.ReadLine();
    }
    sr.Close();
} catch (Exception e)
{
    Console.WriteLine(e);
}

int getNumberByIndex(int row, int col) {

    try {

    if(!Char.IsNumber(lines[row, col])) return 0;
    String number = lines[row, col].ToString();
    lines[row,col] = '.';

    int left = 1;
    int right = 1;
    // chars to the left of index
    while (true)
    {
        try {
        if(!Char.IsNumber(lines[row, col-left])) { break; }

        else {
            number = lines[row, col-left] + number;
            lines[row, col-left] = '.';
        }
        left++;
        } catch (IndexOutOfRangeException e) {
            break;
        }
    }
    while (true)
    {
        try {
        if(!Char.IsNumber(lines[row, col+right])) { break; }
        else {
            number = number + lines[row, col+right];
            lines[row, col+right]= '.';
        }
        right++;
        } catch (IndexOutOfRangeException e) {
            break;
        }
    }
    return int.Parse(number);
    } catch (Exception) {
        return 0;
    }
}

// lines.ForEach((line) => {
//     // Console.WriteLine(line.IndexOf("*"));
//     Console.WriteLine("================");
//     Console.WriteLine(line);
// });

var width = lines.GetLength(1);
var height = lines.GetLength(0);

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"height: {height} \nwidth: {width}");
Console.ForegroundColor = ConsoleColor.Green;
// part 1
// var sum = 0;
// for (int i = 0; i < height; i++)
// {
//     for (int y = 0; y < width; y++)
//     {
//         if(!Char.IsNumber(lines[i,y]) && lines[i,y] != '.') {
//             //Console.Write(lines[i,y]);
            
//             for (int h = -1; h <= 1; h++)
//             {
//                 for (int v = -1; v <= 1; v++)
//                 {
//                     //Console.WriteLine(getNumberByIndex(i+v,y+v));
//                     sum+= getNumberByIndex(i+v,y+h);
//                 }
                
//             }

//         }
//     }
// }
// Console.ForegroundColor = ConsoleColor.White;

// Console.WriteLine($"sum: {sum}");


var sum = 0;
for (int i = 0; i < height; i++)
{
    for (int y = 0; y < width; y++)
    {
        if(lines[i,y] == '*') {
            //Console.Write(lines[i,y]);
            List<int> gears = [];
            
            for (int h = -1; h <= 1; h++)
            {
                for (int v = -1; v <= 1; v++)
                {
                    //Console.WriteLine(getNumberByIndex(i+v,y+v));
                    gears.Add(getNumberByIndex(i+v,y+h));
                }
                
            }
            foreach (var item in gears.Where((val) => val>0).ToList()) {
                Console.Write($"{item} ");
            }
            if(gears.Count((val) => val>0) == 2) {
                var ratio = gears.Where((val) => val>0).Aggregate(1, ( before , next) => {
                    return before*next;

                });
                Console.WriteLine(ratio);
                sum += ratio;
            }

        }
    }
}
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine($"sum: {sum}");

