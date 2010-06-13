# TDD Bowling Game
An example of doing Test-Driven Development using Bowling as the domain.

## The game to be played
Below are some scenarios we can use to drive the development of the game.

* when rolling all gutter balls, the score is 0.
* when rolling all 1s, the score is 20.
* when the first frame is a spare and each subsequent roll score 2, the score is 48.
* when the first 2 frames are spares with [5,5] and subsequent rolls score 2, the score is 59.
* when 10 frames have been bowled, don't allow any more to be bowled.
* when the first frame is a strike and subsequent rolls score 2, the score is 50.
* when the first 2 frames are strikes and the rest score 2, the score is 68.
* when rolling a perfect game, the score is 300.
* when rolling alternate strikes and spares, the score is 200.

### Thanks
A special thanks to [Ron Jeffries](http://xprogramming.com/articles/miningbowling/) 
for the original idea, and [Cory Foy](http://blog.coryfoy.com/2006/08/tdd-bowling-game-part-1/) 
for pushing it further.
Thanks also to Steve Harman (http://stevenharman.net/).