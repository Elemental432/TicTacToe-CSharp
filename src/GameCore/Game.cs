namespace TicTacToe.GameCore;

using TicTacToe.Enums;
using TicTacToe.Players;
using TicTacToe.UI;

public sealed class Game {
	public readonly GameBoard Board;
	public readonly GameUI UI;
	public readonly HumanPlayer Player;
	public readonly AIPlayer Bot;
	
	public Game() {
		Board = new GameBoard();
		UI = new GameUI(this);
		Player = new HumanPlayer(this);
		Bot = new AIPlayer(this);
	}
	
	public bool CheckWinner(out Symbol? symbol) {
		if (Board.CheckRows(out symbol))
			return true;
		
		if (Board.CheckCols(out symbol))
			return true;
		
		if (Board.CheckLeftToRightDiag(out symbol))
			return true;
		
		if (Board.CheckRightToLeftDiag(out symbol))
			return true;
		
		symbol = null;
		return false;
	}
	
	public bool GamedEnded() {
		if (CheckWinner(out _))
			return true;
		
		return Board.AllSquaresAreFilled;
	}
}