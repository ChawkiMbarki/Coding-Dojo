# Basic - Print all integers from 0 to 150.
for i in range(151):
    print(i)

# Multiples of Five - Print all the multiples of 5 from 5 to 1,000
for i in range(5, 1001):
    if(i % 5 == 0):
        print(i)

# Whoa. That Sucker's Huge
sum = 0
for i in range(1, 500001, 2):
    sum += i
print(i)

""" Countdown by Fours - Print positive numbers starting at 2024,
counting down by fours. """

for i in range(2024, 0, -4):
    print(i)

""" Set three variables: lowNum, highNum, mult.
Starting at lowNum and going through highNum,
print only the integers that are a multiple of mult.
For example, if lowNum=2, highNum=9, and mult=3,
the loop should print 3, 6, 9 (on successive lines) """

lowNum = int(input("lowNum :"))
highNum = int(input("highNum :"))
mult = int(input("mult :"))

for i in range(lowNum, highNum+1, mult):
    print(i)
