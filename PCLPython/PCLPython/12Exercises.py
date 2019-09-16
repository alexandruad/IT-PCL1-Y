
#Exercise 12.1 Classes and objects

#Class MyRecipe with 2 fields calories and cookTime.print 5 favorite recipes

class MyRecipe():
  calories = 0
  cookTime = 0
  name = ""
  def __init__(self, calories, cookTime):
      self.calories = calories
      self.cookTime = cookTime
  def printRecipe(self, name):
      self.name = name
      print("Recipe {} with {} calories and {} minutes cooking time.".format(self.name, self.calories, self.cookTime))


r1 = MyRecipe(90,10)
r2 = MyRecipe(91,15)
r3 = MyRecipe(92,50)
r4 = MyRecipe(93,60)
r5 = MyRecipe(94,30)

r1.printRecipe("Apple pie")
r2.printRecipe("Peach pie")
r3.printRecipe("Meat pie")
r4.printRecipe("Potato pie")
r5.printRecipe("Cabbage pie")