# Keyboard Racer
A Terminal-based typing game inspired by [Type Racer](https://play.typeracer.com/).

![](images/ingame.png)
## Main menu
![](images/main_menu.png)
## Bot selection
- Allows playing against 0 to 4 bots
- Bot difficulty ranges from 0 to 9
![](images/bot_selection.png)
## Text selecion
- Random text
- Text closest to specified relative difficulty in the range of 0(easiest) to 100(hardest)
- Content of file at specifed path
![](images/text_selection.png)
## Ingame view
![](images/ingame.png)
- Highlighting of
  - untyped characters(dark gray)
  - typed correctly typed characters(light gray)
  - incorrectly typed characters(red)
- Display of statistics
  - Number of total errors made so far
  - Number of errors in the current state of the text
  - Current typing speed measured in *Words per minute*(WPM)
- Visualization of the participants progress through a car race
  

## Post game view
![](images/post_game.png)
Participants ranking with typing speed and total number of errors made

## Acknowledgement
Text database taken from http://typeracerdata.com/texts.

UI built with Gui.cs https://github.com/migueldeicaza/gui.cs.

ASCII banners built with https://patorjk.com/software/taag.