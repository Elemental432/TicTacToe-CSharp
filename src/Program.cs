namespace TicTacToe;

using TicTacToe.Enums;
using TicTacToe.GameCore;

public static class Program {
	// Access 'src/Enums/Difficulty.cs' to view the difficulties
	public const Difficulty DIFFICULTY_LEVEL = Difficulty.Medium;
	
	private const int TIMER = 3000;
	
	private static readonly Game _game = new Game();
	
	[STAThread]
	public static async Task Main() {
		_game.UI.NewGame();
		
		while (true) {
			_game.UI.EntryChoice();
			string? input = _game.UI.GetInput();
			if (TryCheckInput(input, out sbyte i)) {
				if (_game.Board.IsValidIndex(i)) {
					_game.Player.PlayAt(i);
					_game.UI.ShowBoard();
					if (_game.GamedEnded())
						break;
				} else {
					_game.UI.InvalidMove();
					continue;
				}
			} else {
				_game.UI.InvalidMove();
				continue;
			}
			
			await _game.UI.Delay(TIMER);
			_game.Bot.Play();
			_game.UI.ShowBoard();
			
			if (_game.GamedEnded())
				break;
		}
		
		_game.UI.ShowResults();
	}
	
	private static bool TryCheckInput(string? input, out sbyte i) {
		if (sbyte.TryParse(input, out i))
			return true;
		
		return false;
	}
}
