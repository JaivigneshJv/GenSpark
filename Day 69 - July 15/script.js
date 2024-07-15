let validWords = [];
let answer = "";
let currentRow = 0;
let currentCol = 0;
let guess = "";

fetch('5-letter-words.json')
    .then(response => response.json())
    .then(data => {
        validWords = data;
        newGame(); 
    })
    .catch(error => console.error('Error loading valid words:', error));

const board = document.getElementById("board");
function createBoard() {
    board.innerHTML = '';
    for (let i = 0; i < 6; i++) {
        for (let j = 0; j < 5; j++) {
            const tile = document.createElement("div");
            tile.className = "tile";
            tile.id = `tile-${i}-${j}`;
            board.appendChild(tile);
        }
    }
}

const keyboard = document.getElementById("keyboard");
function createKeyboard() {
    keyboard.innerHTML = '';
    const keys = "QWERTYUIOPASDFGHJKLZXCVBNM".split("");
    keys.forEach(key => {
        const keyButton = document.createElement("div");
        keyButton.className = "key";
        keyButton.textContent = key;
        keyButton.id = `key-${key}`;
        keyButton.addEventListener("click", () => handleKey(key));
        keyboard.appendChild(keyButton);
    });

    const enterButton = document.createElement("div");
    enterButton.className = "key enter-key";
    enterButton.textContent = "ENTER";
    enterButton.addEventListener("click", handleEnter);
    keyboard.appendChild(enterButton);

    const backspaceButton = document.createElement("div");
    backspaceButton.className = "key backspace-key";
    backspaceButton.textContent = "⌫";
    backspaceButton.addEventListener("click", handleBackspace);
    keyboard.appendChild(backspaceButton);
}

function handleKey(key) {
    const keyButton = document.getElementById(`key-${key}`);
    if (keyButton.classList.contains("disabled")) {
        return;
    }
    if (currentCol < 5) {
        const tile = document.getElementById(`tile-${currentRow}-${currentCol}`);
        tile.textContent = key;
        guess += key;
        currentCol++;
    }
}

function handleBackspace() {
    if (currentCol > 0) {
        currentCol--;
        const tile = document.getElementById(`tile-${currentRow}-${currentCol}`);
        tile.textContent = "";
        guess = guess.slice(0, -1);
    }
}

function handleEnter() {
    if (guess.length === 5) {
        if (!validWords.includes(guess.toLowerCase())) {
            alert("Not in word list.");
            return;
        }
        checkGuess();
        if (guess === answer) {
            alert("Congratulations! You found the word!");
            window.open(`https://www.google.com/search?q=${answer}`, '_blank');
        }
        guess = "";
        currentCol = 0;
        currentRow++;
        if (currentRow === 6 && guess !== answer) { 
            alert(`Sorry, you didn't find the word. The word was ${answer}.`);
            window.open(`https://www.google.com/search?q=${answer}`, '_blank');
        }
    }
}

function checkGuess() {
    for (let i = 0; i < 5; i++) {
        const tile = document.getElementById(`tile-${currentRow}-${i}`);
        const keyButton = document.getElementById(`key-${guess[i]}`);
        if (guess[i] === answer[i]) {
            tile.classList.add("correct");
            keyButton.classList.add("correct");
        } else if (answer.includes(guess[i])) {
            tile.classList.add("present");
            keyButton.classList.add("present");
        } else {
            tile.classList.add("absent");
            keyButton.classList.add("disabled");
            keyButton.classList.add("absent");
        }
    }
}

function newGame() {
    if (validWords.length > 0) {
        answer = validWords[Math.floor(Math.random() * validWords.length)].toUpperCase();
    }
    currentRow = 0;
    currentCol = 0;
    guess = "";
    createBoard();
    createKeyboard();
}

document.getElementById("new-game").addEventListener("click", () => {
    alert("New game!");
    newGame();
});


document.addEventListener('keydown', (e) => {
    // Filter for letter keys, Enter, and Backspace
    if ((e.key >= 'a' && e.key <= 'z')) {
        handleKey(e.key.toUpperCase());
    }
    if(e.key === 'Enter') {
        handleEnter();
    }
    if(e.key === 'Backspace') {
        handleBackspace();
    }
});