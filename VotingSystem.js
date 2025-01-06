const readline = require('readline').createInterface({
    input: process.stdin,
    output: process.stdout
});

function askQuestion(query) {
    return new Promise(resolve => readline.question(query, resolve));
}

function printSeparator() {
    console.log("\n" + "=".repeat(50) + "\n");
}

function fancyPrint(message) {
    console.log("  " + message);
}

function registerCandidates() {
    const candidates = [
        "1. Donald Trump     ",
        "2. Kamala Harris    ",
        "3. Cornel West      ",
        "4. Jill Stein       ",
        "5. Chase Oliver     ",
        "6. Claudia De la Cruz"
    ];

    fancyPrint("Current Candidates");
    printSeparator();
    candidates.forEach(candidate => console.log("  " + candidate));
    printSeparator();
    return candidates;
}

async function castVote(candidateList) {
    const votedPeople = {};
    const voteCounts = Object.fromEntries(candidateList.map(candidate => [candidate, 0]));

    fancyPrint("Let's start voting!");

    while (true) {
        console.log("\n" + "-".repeat(30));
        const name = (await askQuestion("Enter your name (or 'exit' to finish): ")).trim();
        
        if (name.toLowerCase() === 'exit') break;
        
        const surname = (await askQuestion("Enter your surname: ")).trim();
        const voterKey = `${name} ${surname}`;
        
        if (votedPeople[voterKey]) {
            console.log("⚠  Hey, looks like you already voted!");
            continue;
        }
        
        console.log("\nPick your candidate:");
        candidateList.forEach(candidate => console.log("  " + candidate));
        
        const vote = (await askQuestion("\n📝 Which number? ")).trim();
        const validNumbers = candidateList.map(candidate => candidate.split('.')[0]);
        
        if (validNumbers.includes(vote)) {
            for (let candidate of candidateList) {
                if (candidate.startsWith(vote)) {
                    voteCounts[candidate]++;
                    votedPeople[voterKey] = true;
                    console.log(`Thanks ${name}! Vote registered for ${candidate}`);
                    break;
                }
            }
        } else {
            console.log("Oops! That's not a valid candidate number!");
        }
    }
    return voteCounts;
}

function displayResults(votes) {
    printSeparator();
    fancyPrint("Here's how everyone did:");
    printSeparator();

    const totalVotes = Object.values(votes).reduce((a, b) => a + b, 0) || 1;

    for (const [candidate, numVotes] of Object.entries(votes)) {
        const percentage = (numVotes / totalVotes) * 100;
        const bar = "█".repeat(Math.floor(percentage / 5)) + "▒".repeat(20 - Math.floor(percentage / 5));
        console.log(`${candidate}`);
        console.log(`${bar} ${numVotes} votes (${percentage.toFixed(1)}%)\n`);
    }

    return votes;
}

async function runSecondRound(tiedCandidates) {
    fancyPrint("Time for a tie-breaker!");
    console.log("\nOnly these candidates are left:");

    const votedPeople = {};

    while (true) {
        printSeparator();
        tiedCandidates.forEach(candidate => console.log("  " + candidate));
        
        const round2Votes = Object.fromEntries(tiedCandidates.map(candidate => [candidate, 0]));

        while (true) {
            console.log("\n" + "-".repeat(30));
            const name = (await askQuestion("Enter your name (or 'exit' to finish): ")).trim();
            if (name.toLowerCase() === 'exit') break;

            const surname = (await askQuestion("Enter your surname: ")).trim();
            const voterKey = `${name} ${surname}`;
            
            if (votedPeople[voterKey]) {
                console.log("  You already voted in this round!");
                continue;
            }
            
            const vote = (await askQuestion("📝 Candidate number: ")).trim();
            const validNumbers = tiedCandidates.map(candidate => candidate.split('.')[0]);
            
            if (validNumbers.includes(vote)) {
                for (let candidate of tiedCandidates) {
                    if (candidate.startsWith(vote)) {
                        round2Votes[candidate]++;
                        votedPeople[voterKey] = true;
                        console.log(`Got it! Vote cast for ${candidate}`);
                        break;
                    }
                }
            } else {
                console.log(" That's not a valid choice!");
            }
        }

        displayResults(round2Votes);
        
        const maxVotes = Math.max(...Object.values(round2Votes));
        const winners = Object.entries(round2Votes).filter(([_, v]) => v === maxVotes).map(([c]) => c);

        if (winners.length === 1) {
            console.log("\n We have a winner!");
            fancyPrint(`Congratulations ${winners[0]}!`);
            break;
        } else {
            console.log("\n Still tied! Let's go again...");
        }
    }
}

async function main() {
    console.log("\n" + "=".repeat(50));
    fancyPrint("Welcome to USA Voting System 2024");
    console.log("=".repeat(50) + "\n");
    
    const candidates = registerCandidates();
    const votes = await castVote(candidates);
    const finalVotes = displayResults(votes);

    const maxVotes = Math.max(...Object.values(finalVotes));
    const winners = Object.entries(finalVotes).filter(([_, v]) => v === maxVotes).map(([c]) => c);

    if (winners.length > 1) {
        console.log("\n Looks like we have a tie!");
        await runSecondRound(winners);
    } else {
        console.log("\n We have a winner!");
        fancyPrint(`Congratulations ${winners[0]}!`);
    }

    readline.close();
}

main();
