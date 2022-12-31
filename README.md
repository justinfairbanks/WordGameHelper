# WordGameHelper
C# Event Driven Final Project

Windows Forms App (.Net Framework) to output possible words satisfying given conditions in word games

- First tab is for games in which you are given specific letters to form a word.

- Second tab is for Wordle, where you have to guess the daily five letter word. 

  - After each guess, green indicates you guessed a correct letter in the right position, yellow indicates the letter is in the word but in the wrong position,
  and grey means that the letter is not in the word.
  
  - The WordHelper App outputs the possible five letter words that satisfy these known conditions. The input boxes can be updated for each guess, as the code keeps track of the previous input's conditions. This is the case until the 'New Wordle' button is pressed.
  
 
- Third tab utilizes SQL Databases, in which words may be added or removed from the dictionary. (Database is not remote access enabled)
 
  - Words in the Database dictionary txtbox could appear in the potential words box if the word conditions are satisfied. 
  
  - Words in the Removed Words txtbox will never appead in the potential words box even if they are in the US Dictionary.
