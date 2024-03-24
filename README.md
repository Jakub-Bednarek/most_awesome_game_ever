# Most Awesome Game Ever!

## Project concept
### Idea
The idea is simple - create a game which fulfills requirements for university course.

The game is written using the Unity game engine. \
Whole concept is based on unique mechanic of travelling between dimensions. \
During the playthourgh you will be exploring a maze. Simple, right? \
Even though the basics might seem underwhelming at first, we promise that you will not get bored! \
Intriguing puzzles, two dimensions to explore and crazy enemies are waiting for you! \
Can you find an exit?


### Motivation
We want to learn! We all know that group project are less and less common when it comes to university courses. \
Working in a team can teach many aspects of day to day real developer workflow which might be completely ignored in solo dev world. \
One and the most important thing is that it should be fun. Programming is fun, so should be the world of games close to our hearts.


## Project structure
Project consists of few important directories which should be respected with each new item being added:
* _Scripts - heart of the project. All C# scripts should be stored in this directory, easy access is number 1 priority.
* Audio - everything that is related to the audio: music files, sound effects etc.
* Scenes - most likely the most loneyly directory in whole project. In case of new scene added it should land here.
* Prefabs - place for all "ready" assets which are used in our scenes. Prefab is a concept covered by Unity and should be understood pretty well.
* Sprites - textures! This directory is the kingdom of visual aspect of the game.

## Coding convetion
Obvious but important - we are working as a team and all of us want to understand what is going on in the code. \

Basic naming convention for C#:
* Files - `UpperCamelCase`
* Class - `UpperCamelCase`
* Class Field - `LowerCamelCase`
* Namespace - `UpperCamelCase`
* Interface - `UpperCamelCase` (can start with an `I` prefix)
* Property - `UpperCamelCase`
* Method - `UpperCamelCase`
* Method argument - `LowerCamelCase`
* Constant - `UpperCamelCase`
* Enum type - `UpperCamelCase`
* Enum value - `UpperCamelCase`
* Event - `UpperCamelCase`

Names should be descriptive and reflect their intentions. Larger the scope which variable/class/interface will be used the longer the name can be. \
Short names like `i`, `j`, `k` should be only used in loops as it is common programming convention. \
`SOLID` principles are warmly welcome - the project should become easly extendible and maintainable.

## Way of working
### Writing features, fixing bugs, refactoring code
To avoid mess, duplication of work and misunderstading in the team following workflow should be abided when working in the project:
1. From the issues board pick an interesting feature which you want to implement and assign yourself to it.
2. Create new branch where all of your code will go (WE DON'T PUSH DIRECTLY TO MAIN!!!!!).
3. Do your stuff, commit the changes as many times as you need.
4. When you think that the change is ready create a pull request.
5. Ask one of the colleagues for the code review.
6. When the reviewer will post comments you should go through them and reply or fix based on the topic discussed.
7. After the review merge your branch to the main.
8. Close the issue behind the merge request.
9. GG WP

No changes should be pushed directly to the main branch as it should be allways in working state and all other branches will be created based on it.
This process will allow us to deliver higher quality code, prematurely detect some bugs contained in the code and keep our main as realiable source of further changes.

### Issues
All features, bugs or improvements should be covered on the issues board.
If you have an idea, found a bug or want to propose an improvement of existing functionality first check whether and issue is not yet present on the board.
When you've confirmed that your idea is not a duplicate you should:
1. Create an issue with descriptive title, it should be easy to understand what is covered by the ticked.
2. Write an exhausting description. Remember - you're not alone and there is a high chance that you will not be working on the ticket you are creating. \
Everyone involved in the project should be able to undrestand and proceed with the task covered by the issue.
3. Add appropriate labels to the issue (you can choose multiple for single ticket). Options are:
    * Bug - something is not working and needs to be investigated/fixed.
    * WiP - work in progress.
    * Done - issue closed.
    * Feature - new functionality in the game.
    * Improvement - refactor, clean up or new approach to an existing solution.
    * Documentation - self explanatory.
4. If you will be taking an action on the issue you should assign yourself.
