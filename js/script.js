function processSentence() {
    const input = document.getElementById("sentenceInput").value.trim();
    const words = input.split(/\s+/);

    const numbers = [];
    const nonNumbers = [];

    words.forEach(word => {
        if (!word.includes(',') && !isNaN(Number(word))) {
            numbers.push(Number(word));
        } else {
            nonNumbers.push(word);
        }
    });

    numbers.sort((a, b) => a - b);
    nonNumbers.sort();

    const numberList = document.getElementById("numberList");
    const nonNumberList = document.getElementById("nonNumberList");
    numberList.innerHTML = "";
    nonNumberList.innerHTML = "";

    numbers.map(num => {
        const li = document.createElement("li");
        li.textContent = num;
        numberList.appendChild(li);
    });

    nonNumbers.map(word => {
        const li = document.createElement("li");
        li.textContent = word;
        nonNumberList.appendChild(li);
    });
}
