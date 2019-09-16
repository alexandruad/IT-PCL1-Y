def foo (x):
    return (x*x*3-2*x+5)

##
G = 4
def sumFooImpure(n):
    return n+G

def sumFooPure(n,G):
    return n+G

##
greetX = lambda x : print('Hi '+x)

##
def add(x,y):
    if x==0: return y
    else: return add(x-1,y+1)

##
mutadata = ['Danny', 123456, ['PME1', 'PCL1', 'ALI1']]
imutadata = ('Danny', 123456, ['PME1', 'PCL1', 'ALI1'])

mutadata[1] = 110220
imutadata[1] = 110220

print(mutadata[2])
print(imutadata[2])

##High order functions

def f(x) : return 2*x
def g(x) : return x+5
def h(x) : return x**2-3
def w() : 
    print('Go homee!!! Nice Weather, haha ! interjection.')
def fooStar(x) : return x

##
coffee_price = [
    (2015, 25.9), 
    (2016, 25.5), 
    (2017, 25.5), 
    (2018, 25.5), 
    (2019, 25.5)
    ]
y = max(coffee_price, key=lambda cPrice:cPrice[1])

print(y)
##
coffee_price = [(2015, 25.05), (2016, 26.03), (2017, 25.12), (2018, 25.02), (2019, 24.08)]
result = max(coffee_price, key=lambda x:x[1])
print(result)

##even
lst = [0,1,2,3,4,5,6,7,8,9]
list(filter(lambda x:(x%2==0), lst))
##odd
list(filter(lambda x:(x%2==1), lst))


##map

listValues = [2014 , 2015, 2016 , 2017, 2018]
addOne = list(map(lambda y: y + 1, listValues))




##### FROM SLIDES
class Person:
 def printName(self) : 
     print(self .name)
 def __init__ (self , name):
     self.name = name
     print(self .name)

p1 = Person ('Valentin Edga')
p1.name
p1.printName()

###
class Employee:
   'Common base class for all employees'
   empCount = 0

   def __init__(self, name, salary):
      self.name = name
      self.salary = salary
      Employee.empCount += 1
   
   def displayCount(self):
     print ("Total Employee" + Employee.empCount)

   def displayEmployee(self):
      print("Name : {} Salary: {}".format(self.name, self.salary))

"This would create first object of Employee class"
emp1 = Employee("Zara", 2000)
"This would create second object of Employee class"
emp2 = Employee("Manni", 5000)
emp1.displayEmployee()
emp2.displayEmployee()
print ("Total Employee {}".format(Employee.empCount))


###Class Inheritance


class Parent:        # define parent class
   parentAttr = 100
   def __init__(self):
      print ("Calling parent constructor")

   def parentMethod(self):
      print ('Calling parent method')

   def setAttr(self, attr):
      Parent.parentAttr = attr

   def getAttr(self):
      print ("Parent attribute :".format(Parent.parentAttr))

class Child(Parent): # define child class
   def __init__(self):
      print ("Calling child constructor")

   def childMethod(self):
      print ('Calling child method')

class Child2(Parent): # define child2 class
   def __init__(self):
      print ("Calling child2 constructor")

   def childMethod(self):
      print ('Calling child2 method')

c = Child()          # instance of child
c2 = Child2()
c.childMethod()      # child calls its method
c.parentMethod()     # calls parent's method
c.setAttr(200)       # again call parent's method
c.getAttr()          # again call parent's method


####mother father child, multiple inheritance

class Mother:        # define mother class
   motherAttr = 100
   def __init__(self):
      print ("Calling mother constructor")

   def motherMethod(self):
      print ('Calling mother method')

class Father:        # define father class
   fatherAttr = 100
   def __init__(self):
      print ("Calling father constructor")

   def fatherMethod(self):
      print ('Calling father method')

f = Father()
m = Mother()

class ChildFM(Father,Mother): # define child class
   def __init__(self):
      print ("Calling child from (father and mother) constructor")

   def childMethod(self):
      print ('Calling  child from (father and mother) method')

childFM = ChildFM()
childFM.fatherMethod()
childFM.motherMethod()
childFM.childMethod()


####Encapsulation Accessibility
#Private
__a = 1
__my_variable = 0

#Semiprivate
_a1 = 123
_my_variable1 = 0