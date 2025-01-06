using System;
using System.Collections.Generic;
using System.Linq;

class VotingSystem
{
    static void PrintSeparator()
    {
        Console.WriteLine("\n" + new string('=', 50) + "\n");
    }

    static void FancyPrint(string message)
    {
        Console.WriteLine("  " + message);
    }

    static List<string> RegisterCandidates()
    {
        var candidates = new List<string>
        {
            "1. Donald Trump     ",
            "2. Kamala Harris    ",
            "3. Cornel West      ",
            "4. Jill Stein       ",
            "5. Chase Oliver     ",
            "6. Claudia De la Cruz"
        };

        FancyPrint("Current Candidates");
        PrintSeparator();
        foreach (var candidate in candidates)
            Console.WriteLine("  " + candidate);
        PrintSeparator();
        return candidates;
    }

    static Dictionary<string, int> CastVote(List<string> candidateList)
    {
        var votedPeople = new HashSet<string>();
        var voteCounts = candidateList.ToDictionary(candidate => candidate, candidate => 0);

        FancyPrint("Let's start voting!");

        while (true)
        {
            Console.WriteLine("\n" + new string('-', 30));
            Console.Write("Enter your name (or 'exit' to finish): ");
            var name = Console.ReadLine().Trim();

            if (name.ToLower() == "exit") break;

            Console.Write("Enter your surname: ");
            var surname = Console.ReadLine().Trim();
            var voterKey = $"{name} {surname}";

            if (votedPeople.Contains(voterKey))
            {
                Console.WriteLine("⚠  Hey, looks like you already voted!");
                continue;
            }

            Console.WriteLine("\nPick your candidate:");
            foreach (var candidate in candidateList)
                Console.WriteLine("  " + candidate);

            Console.Write("\n📝 Which number? ");
            var vote = Console.ReadLine().Trim();
            var validNumbers = candidateList.Select(c => c.Split('.')[0]).ToList();

            if (validNumbers.Contains(vote))
            {
                foreach (var candidate in candidateList)
                {
                    if (candidate.StartsWith(vote))
                    {
                        voteCounts[candidate]++;
                        votedPeople.Add(voterKey);
                        Console.WriteLine($"Thanks {name}! Vote registered for {candidate}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Oops! That's not a valid candidate number!");
            }
        }

        return voteCounts;
    }

    static void DisplayResults(Dictionary<string, int> votes)
    {
        PrintSeparator();
        FancyPrint("Here's how everyone did:");
        PrintSeparator();

        int totalVotes = votes.Values.Sum();
        if (totalVotes == 0) totalVotes = 1;

        foreach (var entry in votes)
        {
            double percentage = (double)entry.Value / totalVotes * 100;
            string bar = new string('█', (int)(percentage / 5)) + new string('▒', 20 - (int)(percentage / 5));
            Console.WriteLine($"{entry.Key}");
            Console.WriteLine($"{bar} {entry.Value} votes ({percentage:F1}%)\n");
        }
    }

    static void RunSecondRound(List<string> tiedCandidates)
    {
        FancyPrint("Time for a tie-breaker!");
        Console.WriteLine("\nOnly these candidates are left:");

        var votedPeople = new HashSet<string>();

        while (true)
        {
            PrintSeparator();
            foreach (var candidate in tiedCandidates)
                Console.WriteLine("  " + candidate);

            var round2Votes = tiedCandidates.ToDictionary(candidate => candidate, candidate => 0);

            while (true)
            {
                Console.WriteLine("\n" + new string('-', 30));
                Console.Write("Enter your name (or 'exit' to finish): ");
                var name = Console.ReadLine().Trim();
                if (name.ToLower() == "exit") break;

                Console.Write("Enter your surname: ");
                var surname = Console.ReadLine().Trim();
                var voterKey = $"{name} {surname}";

                if (votedPeople.Contains(voterKey))
                {
                    Console.WriteLine("  You already voted in this round!");
                    continue;
                }

                Console.Write("📝 Candidate number: ");
                var vote = Console.ReadLine().Trim();
                var validNumbers = tiedCandidates.Select(c => c.Split('.')[0]).ToList();

                if (validNumbers.Contains(vote))
                {
                    foreach (var candidate in tiedCandidates)
                    {
                        if (candidate.StartsWith(vote))
                        {
                            round2Votes[candidate]++;
                            votedPeople.Add(voterKey);
                            Console.WriteLine($"Got it! Vote cast for {candidate}");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" That's not a valid choice!");
                }
            }

            DisplayResults(round2Votes);

            int maxVotes = round2Votes.Values.Max();
            var winners = round2Votes.Where(pair => pair.Value == maxVotes).Select(pair => pair.Key).ToList();

            if (winners.Count == 1)
            {
                Console.WriteLine("\n We have a winner!");
                FancyPrint($"Congratulations {winners[0]}!");
                break;
            }
            else
            {
                Console.WriteLine("\n Still tied! Let's go again...");
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("\n" + new string('=', 50));
        FancyPrint("Welcome to USA Voting System 2024");
        Console.WriteLine(new string('=', 50) + "\n");

        var candidates = RegisterCandidates();
        var votes = CastVote(candidates);
        DisplayResults(votes);

        int maxVotes = votes.Values.Max();
        var winners = votes.Where(pair => pair.Value == maxVotes).Select(pair => pair.Key).ToList();

        if (winners.Count > 1)
        {
            Console.WriteLine("\n Looks like we have a tie!");
            RunSecondRound(winners);
        }
        else
        {
            Console.WriteLine("\n We have a winner!");
            FancyPrint($"Congratulations {winners[0]}!");
        }
    }
}
