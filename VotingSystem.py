"""
✨ USA Voting System 2024 ✨
Just name/surname verification, nothing fancy
"""

def print_separator():
    print("\n" + "=" * 50 + "\n")

def fancy_print(message):
    print(f"  {message}")

def register_candidates():
    candidates = [
        "1. Donald Trump     ",  
        "2. Kamala Harris    ",
        "3. Cornel West      ",
        "4. Jill Stein       ",
        "5. Chase Oliver     ",
        "6. Claudia De la Cruz"
    ]
    
    fancy_print("Current Candidates")
    print_separator()
    for candidate in candidates:
        print(f"  {candidate}")
    print_separator()
    return candidates

def cast_vote(candidate_list):
    voted_people = {}  
    vote_counts = {candidate: 0 for candidate in candidate_list}
    
    fancy_print("Let's start voting!")
    
    while True:
        print("\n" + "-" * 30)
        name = input("Enter your name (or 'exit' to finish): ").strip().title()
        
        if name.lower() == 'exit':
            break
            
        surname = input("Enter your surname: ").strip().title()
        voter_key = f"{name} {surname}"
            
        if voter_key in voted_people:
            print("⚠  Hey, looks like you already voted!")
            continue
            
        print("\nPick your candidate:")
        for candidate in candidate_list:
            print(f"  {candidate}")
            
        vote = input("\n📝 Which number? ")
        valid_numbers = [c.split('.')[0] for c in candidate_list]
        
        if vote in valid_numbers:
            for candidate in candidate_list:
                if candidate.startswith(vote):
                    vote_counts[candidate] += 1
                    voted_people[voter_key] = True
                    print(f"Thanks {name}! Vote registered for {candidate}")
                    break
        else:
            print("Oops! That's not a valid candidate number!")
    
    return vote_counts

def display_results(votes):
    print_separator()
    fancy_print("Here's how everyone did:")
    print_separator()
    
    total_votes = sum(votes.values())
    if total_votes == 0:
        total_votes = 1
    
    for candidate, num_votes in votes.items():
        percentage = (num_votes / total_votes) * 100
        bar = "█" * int(percentage // 5) + "▒" * (20 - int(percentage // 5))
        print(f"{candidate}")
        print(f"{bar} {num_votes} votes ({percentage:.1f}%)\n")
    
    return votes

def run_second_round(tied_candidates):
    fancy_print("Time for a tie-breaker!")
    print("\nOnly these candidates are left:")
    
    voted_people = {}
    
    while True:
        print_separator()
        for candidate in tied_candidates:
            print(f"  {candidate}")
        
        round2_votes = {candidate: 0 for candidate in tied_candidates}

        while True:
            print("\n" + "-" * 30)
            name = input("Enter your name (or 'exit' to finish): ").strip().title()
            if name.lower() == 'exit':
                break
                
            surname = input("Enter your surname: ").strip().title()
            voter_key = f"{name} {surname}"
            
            if voter_key in voted_people:
                print("  You already voted in this round!")
                continue
                
            vote = input("📝 Candidate number: ")
            if vote in [c.split('.')[0] for c in tied_candidates]:
                for candidate in tied_candidates:
                    if candidate.startswith(vote):
                        round2_votes[candidate] += 1
                        voted_people[voter_key] = True
                        print(f"Got it! Vote cast for {candidate}")
                        break
            else:
                print(" That's not a valid choice!")

        display_results(round2_votes)
        
        max_votes = max(round2_votes.values())
        winners = [c for c, v in round2_votes.items() if v == max_votes]

        if len(winners) == 1:
            print("\n We have a winner!")
            fancy_print(f"Congratulations {winners[0]}!")
            break
        else:
            print("\n Still tied! Let's go again...")

def main():
    print("\n" + "=" * 50)
    fancy_print("Welcome to USA Voting System 2024")
    print("=" * 50 + "\n")
    
    candidates = register_candidates()
    votes = cast_vote(candidates)
    final_votes = display_results(votes)

    max_votes = max(final_votes.values())
    winners = [c for c, v in final_votes.items() if v == max_votes]
    
    if len(winners) > 1:
        print("\n Looks like we have a tie!")
        run_second_round(winners)
    else:
        print("\n We have a winner!")
        fancy_print(f"Congratulations {winners[0]}!")

if __name__ == "__main__":
    main()
