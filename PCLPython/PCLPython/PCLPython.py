
#Example 1

print("Hello world")

#Example 2

def sayFunk():
    print("Fuuunkkk!!!")
    print("Fuuunkkk!!!")
    print("Fuuunkkk!!!")


sayFunk()

#Example 3
#Declare a list with 4 languages
x = ["Python","Scala","Java", "Javascript"]

#Loop to iterate list
i = 0
for a in x:
    i=i+1
    print(a,i)

#get user input and check if it is Y or N

def foo():
 message = input("Give me input !")
 if(message == 'Y'):
   print("YES " + message)
 elif message=='N':
   print("NOT " + message)
 elif message=='R':
   foo()
 else:
   return




##### FROM SLIDES

y = input("enter a name")

print ("Hello: " + y)

##
mix_list = [0, 'en', 2, 3, 'four', 5, 6, 7, 8]
mix_list[3:]
mix_list[:3]
mix_list[3:-3]


##tuples
tup1 = (23, 'April', 12.52)
tup1[0]
tup1[0:]

#dictionaries

d1 = {'code': 'PCL', 'title':'Programming L & C', 'ects':5}

d1['code']
d1['title']
d1.clear() # remove all
d1 # gives {}



