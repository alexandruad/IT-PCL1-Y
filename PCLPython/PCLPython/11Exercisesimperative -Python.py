

#Exercise 11.1–Iteration
#a print 10 times
print("This program prints a string 10 times")
for count in range(10):
    print("Python is cool")

#b ask for a wish and print the wish and the number of times they want it and print it

def foo():
 message1 = input("What is your desire?")
 message2 = input("How many?")
 for count in range(int(message2)):
    print(message1)
foo();

#Exercise 11.2–Sum
#Given numLst= [1, 2, 3, 4, 5] we can compute the sumImperativein an imperative way. 
#You have to implement it such that it uses imperative way to computethe sum of the list. 
numLst= [1, 2, 3, 4, 5] 
sum = 0
for x in numLst:
    sum+=x
print(sum)

#Exercise 11.3–Even numbersUsingthe imperative way of programming, find even numbers (printEvenNumbers) 
#given a list of natural numbers:naturalNumbers = [0,1,2,3,4,5,6,7,8,9]

naturalNumbers = [0,1,2,3,4,5,6,7,8,9]
for x in naturalNumbers:
    if x%2==0 :
        print(x)

#Exercise 11.4–Lists
def groupList(list, gLength):
    i = 0
    bigList = []
    smallList = []
    for x in list:
        if i<gLength:
            smallList.append(x)
            i=i+1
        if i==gLength:
            i=0
            bigList.append(smallList)
            smallList = []
    return bigList

#Exercise 11.5–Character Lists
#check if a give character is in a string

def checkCharacter(str, c):
    for x in str:
        if c == x:
            print(x)
    return

def askForInputAndCheck():
    str = input("String please!")
    c = input("Character please!")
    checkCharacter(str, c)
 

