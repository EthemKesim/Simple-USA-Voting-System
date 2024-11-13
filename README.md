USA Voting System 2024

A simple, console-based voting application implemented in three programming languages: C#, Python, and JavaScript. This application allows users to vote for a candidate with name/surname verification and includes a tie-breaking round if necessary.


Description
The USA Voting System 2024 is a console-based application that runs in C#, Python, and JavaScript, showcasing identical functionality across these languages. Users provide their name and surname to vote, and the application tracks votes and manages tie-breakers through additional rounds if needed.

Purpose
This project demonstrates how to build a basic voting system using three programming languages while providing a practical example of cross-language implementations.


Features
- Name Verification: Users enter their name and surname to prevent duplicate voting.
- Candidate List: A fixed list of candidates displayed at the start of the program.
- Vote Counting: Votes are tallied, and results are displayed at the end of each round.
- Tie-Breaking: In case of a tie, a second round is automatically triggered for only the tied candidates.
- Vote Statistics: Displayed at the end of the session with graphical bars showing vote percentages.





Technologies Used
Each version has specific language requirements:

- Python Version:
  - Python 3.x
  - Console interaction through `input()` and `print()` functions

- C# Version:
  - .NET Core SDK
  - Console Application with `Console.WriteLine` for user interactions

- JavaScript Version:
  - Node.js
  - Uses the `readline` module for console input and output

---

Installation & Setup

Prerequisites
Make sure you have the following installed:
- Python 3.x
- .NET Core SDK
- Node.js

 Running Each Version
1. Python Version:
   cd python_version
   python voting_system.py

2.	C# Version:
cd csharp_version 
dotnet run

3.	JavaScript Version:
cd javascript_version 
node voting_system.js

Project Structure
The project is organized by language, with each version containing its own main program file.

usa-voting-system-2024/
 1.python_version/
    1.1voting_system.py

 2.csharp_version/
   2.1Program.cs/
    2.2VotingSystem.csproj

3.javascript_version/
 3.1voting_system.js

 README.md







Console Interface Examples
Main Menu
=== USA Voting System 2024 ===
1. Register Candidates
2. Start Voting
3. View Results
4. Exit
Choose an option (1-4):

Voting Process
1.	Users enter their name and surname to verify their identity.
2.	Candidates are displayed with corresponding numbers.
3.	Users vote by selecting the candidate's number.

Tie-Breaking Round
If there's a tie, a new round is started with only the tied candidates. The process continues until a winner is determined.
________________________________________

Future Enhancements
1.	Additional Voting Features: Ability to add write-in candidates.
2.	Data Persistence: Store votes in a file or database.
3.	Web-Based Version: A browser-based UI for a more interactive experience.
________________________________________
Version Information
•	Current Version: 1.0.0
•	Last Updated: [Date]
•	Status: In Development
________________________________________

