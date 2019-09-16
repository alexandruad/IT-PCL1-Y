#Use the pass keyword when you do not want to add any other properties or methods to the class.
class Student(Person):
  pass

##Q6

##add 10 to items from list

data = [1,2,3,4,5]
addTenLambda = list(map(lambda x : x+10, data ))

##filter lambda, find even numbers
naturalNumbers = [0,1,2,3,4,5,6,7,8,9]
findNaturalNo = list(filter(lambda x:x%2==0,naturalNumbers))

def findNaturalNo(l) :
    return list(filter(lambda x:x%2==0,l))

#Q7
from datetime import date
class CourseNote:
    jotting = ""
    creationDate = None
    keywords = ""
    
    def __init__(self,jotting,keywords):
        self.creationDate = date.today()
        self.jotting = jotting
        self.keywords = keywords
    def isAmatch(self,searchFilter):
        return self.keywords == searchFilter


class NoteBook:    
    def __init__( self ):
        self.courseNotes = []

    def addNote( self , cNote ):
        self.courseNotes.append(cNote)
    def getList(self):
        return self.courseNotes
    def getNotes(self):
        return len(self.courseNotes)
    def search( self , filterNote ):
        return list(filter(lambda x:x.isAmatch(filterNote),self.courseNotes))

cNote = CourseNote("jotting","key")
noteBook = NoteBook()
noteBook.addNote(cNote)
noteBook.getList()
len(noteBook.search("key"))
print(noteBook.search("key"))


##Q8

class Singer:        # define parent class
   def __init__(self):
      print ("Calling Singer constructor")
   def sing(self):
      print ('Sing!')


class SongWriter:        # define parent class
   def __init__(self):
      print ("Calling SongWriter constructor")
   def compose(self):
      print ('Compose!')

class SingerSongwriter(Singer, SongWriter): # define child class
   def __init__(self):
      print ("Calling SingerSongwriter constructor")
   def strum(self):
      print ('Strum!')
   def actSensitive(self):
      print ('ActSensitive!')

singer = Singer()
songWriter = SongWriter()
singerSongwriter = SingerSongwriter()

singerSongwriter.sing()
singerSongwriter.compose()
singerSongwriter.strum()
singerSongwriter.actSensitive()