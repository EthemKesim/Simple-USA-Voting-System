________________________________________

      USA Voting System 2024

________________________________________

Overview
________________________________________
This is a basic voting system we built to practice core programming skills in Python, C#, and JavaScript. It allows users to cast ballots for candidates in a mock election, showing how the same functionality can be implemented across languages.

Purpose
________________________________________
The goal was to create an easy-to-use application for conducting elections on a small scale. We wanted to demonstrate constructing a simple voting mechanism with candidate registration and tie-breaking capabilities.


Features
________________________________________
Name Check: Users provide their name to verify identity before voting
Candidate Options: Preset list of choices displayed for selection
Tallying Votes: Ballots are totaled after each round and results are printed.
Results Summary: Visual summary of vote percentages at the end.


Technologies
________________________________________
Python: Command-line interface using basic input/output

C#: .NET console app with System.Console for I/O

JavaScript: Node.js app with readline module for console I/O


Usage Guide
________________________________________
To run each version:

Python: Navigate to folder, run python voting_app.py

C#: Navigate to folder, run dotnet run voting_app.csproj

Node.js: Navigate to folder, run node voting_app.js


Interface Walkthrough
The interface guides users through candidate registration, voting and results display. Prompts and validation ensure a smooth experience.

Voting Process
________________________________________
1.	Users enter their name and surname to verify their identity.
2.	Candidates are displayed with corresponding numbers.
3.	Users vote by selecting the candidate's number.

Tie-Breaking Round
If there's a tie, a new round is started with only the tied candidates. The process continues until a winner is determined.

Project Structure

The project is organized by language, with each version containing its own main program file.


usa-voting-system-2024
________________________________________

1. python_version/
  1.1 voting_app.py
  
 2. csharp_version/
  2.1 Program.cs/
   2.2 voting_app.csproj

 3. javascript_version/
   3.1 voting_app.js

README.md

________________________________________
Enhancements
Future iterations could include:

Database for storing votes
Web-based interface
Additional voting features like write-ins
________________________________________
Conclusion
This project let us apply core programming principles while comparing implementations across languages. The simple voting application can serve as a starting point for more robust election systems.
________________________________________

