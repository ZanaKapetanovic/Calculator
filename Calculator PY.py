import math
import string

class Calculator:
    def add(a,b):
        return a+b

    def subtract(a,b):
        return a-b 

    def multiply(a,b):
        return a*b 

    def divide(a,b):
        if(b == 0):
            print("Division by zero is not allowed.")
            return math.nan
        return a/b 
  
    def mod(a,b):
        roundedA = math.floor(a)
        roundedB = math.floor(b)
        return roundedA - (roundedA / roundedB) * roundedB
    
    def pow(a,b):
        mem = 1
        for i in range(b): 
            mem *= a
        return mem

    def squareRoot(a):
        counter = 0
        while counter <= a/2:
            if Calculator.pow(counter, 2) == a:
                return counter
            counter += 1
        return -1

def getInput():
    consoleinput = input()
    if consoleinput == "q" or consoleinput == "Q":
        exit()
    return consoleinput

def run():
    result = 0
    isFirstOperation = True
    while True:
        a=0
        operation = ""
        b=0 
        if isFirstOperation == True:
            a = int(getInput())
            operation = getInput()
            if operation != 's':
               b = int(getInput())
        else:
            inputVar = getInput()
            if inputVar.isnumeric():
               a = int(inputVar)
               operation = getInput()
            else:
               operation = inputVar
               a = result
            if operation != '=' and operation != 's':        
               b = int(getInput())
        match operation:
            case '=':
                print(result)
            case '+':
                result = Calculator.add(a, b)
            case '-':
                result = Calculator.subtract(a, b)
            case '*':
                result = Calculator.multiply(a, b)
            case '/':
                result = Calculator.divide(a, b)
            case '%':
                result = Calculator.mod(a, b)
            case '^':
                result = Calculator.pow(a, b)
            case 's':
                result = Calculator.squareRoot(a)
        isFirstOperation = False

run()