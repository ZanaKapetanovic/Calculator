'use strict';
const readline = require("readline");
const r1 = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});


function Calculator() {
    function add(a, b) {
        return a + b;
    }
    function subtract(a, b) {
        return a - b;
    }
    function multiply(a, b) {
        return a * b;
    }
    function divide(a, b) {
        if (b == 0) {
            console.log("Division by zero is not allowed.");
            return math.nan;
        }
        return a / b;
    }
    function mod(a, b) {
       var roundedA = math.floor(a);
       var roundedB = math.floor(b);
        return roundedA - (roundedA / roundedB) * roundedB;
    }
    function pow(a, b) {
        var mem = 1;
        for (var i = 0; i < b; i++) {
            mem *= a;
        }
        return mem;
    }
    function squareRoot(a) {
        var counter = 0;
        while (counter <= a / 2)
            if (Calculator.pow(counter, 2) == a) {
                return counter;
                counter++;
            }
        return -1;
    }
    return { add, subtract, divide, multiply, pow, squareRoot,mod}
}
    
function getInput() {
    return new Promise(resolve => {
        r1.on("line", (input) => {
            if (input == "q" || input == "Q") {
            process.exit();
        }
            resolve(input);
        });
    })

}

async function run() {
    var result = 0;
    var isFirstOperation = true;
    while (true) {
        var a = 0;
        var operation;
        var b = 0;
        if (isFirstOperation == true) {
            var aInput = await getInput();
            a = parseInt(aInput);
            operation = await getInput();
            if (operation != 's') {
                var bInput = await getInput();
                b = parseInt(bInput);
            }
        }
        else {
            var inputVar = await getInput()
            if (!isNaN(inputVar)) {
                a = parseInt(inputVar);
                operation = await getInput();
            }

            else {
                operation = inputVar;
                a = result;
            }
        if (operation != '=' && operation != 's') {
            var bInput = await getInput();
            b = parseInt(bInput);
        }
        }
        switch (operation) {
            case '=':
                console.log(result);
                break;
            case '+':
                result = Calculator().add(a, b);
                break;
            case '-':
                result = Calculator().subtract(a, b);
                break;
            case '*':
                result = Calculator().multiply(a, b);
                break;
            case '/':
                result = Calculator().divide(a, b);
                break;
            case '%':
                result = Calculator().mod(a, b);
                break;
            case '^':
                result = Calculator().pow(a, b);
                break;
            case 's':
                result = Calculator().squareRoot(a);
                break;
        }
                isFirstOperation = false;

        }
    }

run().then();