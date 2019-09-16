

#Q6

#Q6a

def iteFactorial (x):
    fact = x
    while(fact>1):
        fact = fact*(fact-1)
    return fact
# >>> iteFactorial(3)
#6

#Q6b

def recFactorial (x):
 if x <= 1: return 1
 else: return x * recFactorial (x-1)

# >>> recFactorial(3)
#6

#Q6c
def sumList(intList):
    return sum(intList)
#sumList([2,3,4,5])
#12


#Q7

#Q7a
courseList = [('SDJ1',5,1),('DNP',5,1),('SEP1',10,1),('SDJ2',5,2),('SDJ3',5,3),('PME1',5,6),('BPR',5,6),('PCL',5,6),('BPR',15,7) ]

def filterList(lst):
    return list(filter(lambda x: x[2]==6, lst))

#filterList (courseList)
#[('PME1', 5, 6), ('BPR', 5, 6), ('PCL', 5, 6)]
#courseList = [('SDJ1',5,1),('DNP',5,1),('SEP1',10,1),('SDJ2',5,2),('SDJ3',5,3),('PME1',5,6),('BPR',5,6),('PCL',5,6),('BPR',15,7) ]
#def filterList(lst):
#    return list(filter(lambda x: x[2]==6, lst))

#filterList (courseList)
#[('PME1', 5, 6), ('BPR', 5, 6), ('PCL', 5, 6)]


#Q7b

class StudentWorker:      
    pass

class Worker(StudentWorker): 
   def __init__(self):
      pass
   def getSalary(self, hoursWorked):
       return hoursWorked*100

class Course:
    courseName = ""
    ects = 0
    semester = 0
    
    def __init__(self,courseName,ects,semester):
        self.courseName = courseName
        self.ects = ects
        self.semester = semester
    def display(self):
        print("Name : {} ECTS: {} Semester: {}".format(self.courseName, self.ects,self.semester ))



class Student(StudentWorker): 
    sName = ""
    sNumber = 0
    courseList = []

    def __init__(self):
          pass
    def __str__(self):
        pass
    def showCourses(self):
      print (self.courseList)
    def addCourse(self, course):
        self.courseList.append(course)



studentWorker = StudentWorker()
worker = Worker()

worker.getSalary(99)

#worker = Worker()
#worker.getSalary(99)
#9900