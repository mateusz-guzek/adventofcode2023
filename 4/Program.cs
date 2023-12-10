using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Zadanie4
{
    class Scratchcard
    {
        public int Id { get; private set; } = 0;
        public List<int> Winner_numbers { get; private set; } = [];
        public List<int> Numbers { get; private set; } = [];

        public int Points { get; private set;} = 0;

        //public List<int> Copied_cards { get; private set; } = [];

        public Scratchcard(string text) {
            ParseLine(text);
            CalculatePoints();
        }

        private void ParseLine(string text) {
            var id_numbers = text.Split(":");
            var numbers = id_numbers[1].Split("|");

            this.Id = int.Parse(id_numbers[0].Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);

            this.Winner_numbers = numbers[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            this.Numbers = numbers[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        }
        private void CalculatePoints() {
            // part 1
            // var points = -1;
            var points = 0;
            foreach (var number in this.Winner_numbers) {
                if (this.Numbers.Contains(number)) {
                    points++;
                }
            }
            // part 1
            // if( points == -1) {
            //     return;
            // }
            
            this.Points = points;
            // part 1
            //this.Points = (int)Math.Pow(2,points);


        }
        public List<int> CopyScratchCards() {
            List<int> output = [];
            for (int i = 1; i <= this.Points; i++)
            {
                if(this.Id+i <= 208) 
                {
                    output.Add(this.Id+i);
                }
                   
            }
            return output;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = [];

            List<Scratchcard> scratchcards = [];



            int amount_of_scratchcards = 0;
            Queue<int> scratch_ids = new();

            try {
                StreamReader sr = new("/home/matixon/programowanie/adventofcode2023/4/input");
                lines = [.. sr.ReadToEnd().Split("\n")];
            } catch(Exception) {}
            foreach (var line in lines) {
                scratchcards.Add(new Scratchcard(line));
            }

            int max_id = scratchcards.Max((val) => val.Id);
            // part 1
            // var sumOfPoints = scratchcards.Sum((scratchcard) => scratchcard.Points);
            // Console.WriteLine($"points: {sumOfPoints}");

            foreach (var card in scratchcards)
            {
                scratch_ids.Enqueue(card.Id);
            }
            // dodaje na poczatek tyle kard ile jest oryginalnie
            // potem bedzie sie dodawac te sklonowane
            amount_of_scratchcards += scratchcards.Count;

            while (scratch_ids.Count > 0)
            {
                var curr_id = scratch_ids.Dequeue();
                //Console.WriteLine(curr_id);
                try {
                var new_scratchcards = scratchcards.Single((elem) => elem.Id == curr_id).CopyScratchCards().Where((val) => val<=max_id).ToList();
                // Console.WriteLine(curr_id);
                // Console.WriteLine(string.Join(" ",scratch_ids));
                // Console.WriteLine(string.Join(" ", new_scratchcards));
                //Console.WriteLine(amount_of_scratchcards);
                amount_of_scratchcards += new_scratchcards.Count;
                foreach(var id in new_scratchcards)
                {
                    scratch_ids.Enqueue(id);
                }

                } catch(Exception){}
            }
            Console.WriteLine($"cards: {amount_of_scratchcards}");

            //Console.WriteLine(string.Join(", ",scratchcards[0].CopyScratchCards()));
        }
    }

}
