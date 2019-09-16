##Recursion

def add (x,y):
 if x == 0: return y
 else: return add (x-1 , y+1)


def pureFunSum (x , y) :
# adds two numbers
# uses only the local function inputs
    return x + y


##lambda
lamAdd = lambda x , y : x + y

##immutable data
mutadata = ['Danny', 123456, ['PME1', 'PCL1', 'ALI']]
immudata = ( 'Danny', 123456, ['PME1', 'PCL1', 'ALI1'])
print(immudata[2])
print(mutadata[2])