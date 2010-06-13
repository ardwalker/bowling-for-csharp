
using MbUnit.Framework;

// when rolling all gutter balls, the score is 0.
// when rolling all 1s, the score is 20.
// when the first frame is a spare and each subsequent roll score 2, the score is 48.
// when the first 2 frames are spares with [5,5] and subsequent rolls score 2, the score is 59.
// when 10 frames have been bowled, don't allow any more to be bowled.
// when the first frame is a strike and subsequent rolls score 2, the score is 50.
// when the first 2 frames are strikes and the rest score 2, the score is 68.
// when rolling a perfect game, the score is 300.
// when rolling alternate strikes and spares, the score is 200.

namespace Bowling.Tests
{
	[TestFixture]
	public class BowlingTest
	{
		private BowlingGame _game;

		[SetUp]
		public void SetUp()
		{
			_game = new BowlingGame();
		}

		[Test]
		public void TestRollingAllGutterBalls()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(0, 0); }
			Assert.AreEqual(0, _game.Score());
		}

		[Test]
		public void TestRollingAllOnes()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(1, 1); }
			Assert.AreEqual(20, _game.Score());
		}

		[Test]
		public void TestFirstFrameSpareOthersRollingAllTwos()
		{
			_game.Roll(9,1);
			for (int i = 0; i < 9; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(48, _game.Score());
		}

		[Test]
		public void TestFirstTwoFramesSparesOthersAllRollTwos()
		{
			_game.Roll(5,5);
			_game.Roll(5,5);
			for (int i = 0; i < 8; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(59, _game.Score());
		}

		[Test]
		[ExpectedException(typeof(GameOverException))]
		public void TestGameOver()
		{
			for (int i = 0; i < 10; i++) { _game.Roll(0, 0); }
			_game.Roll(0, 0);
		}

		[Test]
		public void TestFirstFrameStrikeOthersRollAllTwos()
		{
			_game.RollStrike();
			for (int i = 0; i < 9; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(50,_game.Score());
		}

		[Test]
		public void TestFirstTwosFramesStrikeOthersRollAllTwos()
		{
			_game.RollStrike();
			_game.RollStrike();
			for (int i = 0; i < 8; i++) { _game.Roll(2, 2); }
			Assert.AreEqual(68,_game.Score());
		}

		[Test]
		public void TestPerfectGame()
		{
			for (int i = 0; i < 9; i++) { _game.RollStrike(); }
			_game.RollLastFrame(10,10,10);
			Assert.AreEqual(300,_game.Score());
		}

		[Test]
		public void TestAlternatingStrikesAndSpares()
		{
			_game.RollStrike();
			_game.Roll(4, 6);
			_game.RollStrike();
			_game.Roll(7, 3);
			_game.RollStrike();
			_game.Roll(9, 1);
			_game.RollStrike();
			_game.Roll(5, 5);
			_game.RollStrike();
			_game.RollLastFrame(8, 2, 10);
			Assert.AreEqual(200, _game.Score());
		}

	}
}
