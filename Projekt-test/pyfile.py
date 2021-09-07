import clr
#from datetime import date
clr.AddReference('System.Windows.Forms')
clr.AddReference("System.Drawing")
#from System.Drawing import Point
#import System.Windows.Forms 
#from System.Windows.Forms import  Form, TextBox, Button
import math

def sumOnes (intArray):
    sum=0
    for a in intArray:
        if a== 1:
            sum+=a
    return sum

def sumTwo (intArray):
    sum=0
    for a in intArray:
        if a== 2:
            sum+=a
    return sum

def sumThree (intArray):
    sum=0
    for a in intArray:
        if a== 3:
            sum+=a
    return sum
def sumFour (intArray):
    sum=0
    for a in intArray:
        if a== 4:
            sum+=a
    return sum

def sumFive (intArray):
    sum=0
    for a in intArray:
        if a== 5:
            sum+=a
    return sum

def sumSix (intArray):
    sum=0
    for a in intArray:
        if a== 6:
            sum+=a
    return sum



def sumThreeOfKind (intArray):
    sum=0 
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    print(d)
    for x, y in d.items():
        if y >= 3: 
            sum= x*3+20

    return (sum)

def sumFourOfKind (intArray):
    sum=0 
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    for x, y in d.items():
        if y >= 4: 
            sum= (x*4)+40

    return (sum)

def sumFull (intArray):
    sum=0
    isFull = [False, False]
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    for x, y in d.items():
        if y == 2: 
            isFull[0] = True
            sum+= x*2
        if y==3:
            isFull[1] = True
            sum+= x*3
    
    if isFull[0] and isFull[1]: 
        return sum+30
    else: 
        return 0

def sumSmallScale (intArray):
    sum=0 
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    for x, y in d.items():
        if y == 1 and x!=6: 
            sum+=1
    if sum==5:
        return (30)
    return 0

def sumLargeScale (intArray):
    sum=0 
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    for x, y in d.items():
        if y == 1 and x!=1: 
            sum+=1
    if sum==5:
        return (40)
    return 0



def sumYamb (intArray):
    sum=0 
    d = {1:0, 2:0, 3:0, 4:0, 5:0, 6:0}
    for i in intArray:
        d[i] += 1

    for x, y in d.items():
        if y == 5: 
            sum= x*5+50

    return (sum)