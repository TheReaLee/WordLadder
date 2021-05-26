# WordLadder
_By Lee Galea_

## Thought process

- Words need to be linked to another
- What if there are equal possible paths
- Each word can reference multiple words (same -> came, tame) and vice-versa
- Parent/child data structure
- Refresh knowledge on the trie data structure
- Opened dictionary to get an understanding of what data to expect
- Dictionary contains several words of different length... to load only n length words in memory 
- Start and End words need to be of equal length
- Traversing the multi linked list, (BFS/DFS)
- Confirmed that the shortest path is required, BFS chosen 

## Structure

- [BluePrism.Console] - Console application which accepts 4 arguments
	- 1 = Start word
	- 2 = End word
	- 3 = Dictionary file path
	- 4 = Answer file path
- [BluePrism.Core] - Contains all the logic to be able to construct, traverse, and export a word ladder
- [BluePrism.Core.Tests] - Contains unit tests for [BluePrism.Core]

## Methodologies

- Multi linked list
- Breath first search
- [Trie](https://www.studytonight.com/advanced-data-structures/trie-data-structure-explained-with-examples)
 
## Technologies
- .NET Framework 4.7.2
- xUnit
- Moq