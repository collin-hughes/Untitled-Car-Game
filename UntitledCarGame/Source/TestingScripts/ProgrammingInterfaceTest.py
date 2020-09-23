def Test1():
  TestedApps.UntitledCarGame.Run()
  winFormsGameForm = Aliases.UntitledCarGame.WinFormsGameForm
  winFormsGameForm.Drag(463, 543, 52, -5)
  winFormsGameForm.Drag(437, 180, 59, 7)
  winFormsGameForm.Keys("basic_circle.tmx")
  winFormsGameForm.Drag(633, 184, 76, 8)
  winFormsGameForm.Drag(546, 478, 51, 0)
  winFormsGameForm.Keys("instructions.txt")
  winFormsGameForm.Drag(751, 480, 59, -2)
  winFormsGameForm.Drag(278, 633, 55, -3)
  winFormsGameForm.Close()