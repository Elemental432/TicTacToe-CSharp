namespace TicTacToe.GameCore;

using TicTacToe.Enums;

public sealed class GameBoard {
	// Keep the 'BOARD_SIZE' at 3
	// Otherwise MiniMax will calculate infinite possibilities (Using the maximum of the machine's hardware)
	public const sbyte BOARD_SIZE = 3;
	
	private readonly Dictionary<sbyte, (sbyte, sbyte)> _matrixIndexers = new();
	
	public readonly ushort TotalSquares;
	public readonly List<List<Symbol?>> Matrix = new();
	
	public bool AllSquaresAreFilled => Matrix.All(rows => rows.All(col => col is not null));
	
	public GameBoard() {
		TotalSquares = BOARD_SIZE * BOARD_SIZE;
		InitializeMatrix();
		InitializeMatrixIndexers();
	}
	
	public bool TryAccessMatrix(sbyte index, out (sbyte, sbyte) tuple)
		=> _matrixIndexers.TryGetValue(index, out tuple);
	
	public bool CanPlayAt(sbyte row, sbyte col) => Matrix[row][col] is null;
	public void PlayAt(sbyte row, sbyte col, Symbol symbol) => Matrix[row][col] = symbol;
	public void UndoMoveAt(sbyte row, sbyte col) => Matrix[row][col] = null;
	
	public bool IsValidIndex(sbyte index) {
		if (index > 0 && index < (TotalSquares + 1)) {
			if (TryAccessMatrix(index, out (sbyte row, sbyte col) move))
				return CanPlayAt(move.row, move.col);
		}
		
		return false;
	}
	
	public bool CheckRows(out Symbol? symbol) {
		foreach (var row in Matrix) {
			if (CheckLine(row, out symbol))
				return true;
		}
		
		symbol = null;
		return false;
	}
	
	public bool CheckCols(out Symbol? symbol) {
		var column = new List<Symbol?>();
		for (sbyte col = 0; col < BOARD_SIZE; col++) {
			for (sbyte row = 0; row < BOARD_SIZE; row++)
				column.Add(Matrix[row][col]);
			
			if (CheckLine(column, out symbol))
				return true;
			
			column.Clear();
		}
		
		symbol = null;
		return false;
	}
	
	public bool CheckLeftToRightDiag(out Symbol? symbol) {
		var diag = new List<Symbol?>();
		for (sbyte i = 0; i < BOARD_SIZE; i++)
			diag.Add(Matrix[i][i]);
		
		return CheckLine(diag, out symbol);
	}
	
	public bool CheckRightToLeftDiag(out Symbol? symbol) {
		var diag = new List<Symbol?>();
		sbyte row = 0;
		for (sbyte col = (BOARD_SIZE - 1); col >= 0; col--)
			diag.Add(Matrix[row++][col]);
		
		return CheckLine(diag, out symbol);
	}
	
	private bool CheckLine(IEnumerable<Symbol?> line, out Symbol? symbol) {
		var symbols = line.OfType<Symbol>().ToList();
		if (symbols.Count == BOARD_SIZE && symbols.All(s => s.Type == SymbolType.X)) {
			symbol = symbols.First();
			return true;
		}
		if (symbols.Count == BOARD_SIZE && symbols.All(s => s.Type == SymbolType.O)) {
			symbol = symbols.First();
			return true;
		}
		symbol = null;
		return false;
	}
	
	private void InitializeMatrix() {
		for (sbyte row = 0; row < BOARD_SIZE; row++) {
			Matrix.Add(new List<Symbol?>());
			for (sbyte i = 0; i < BOARD_SIZE; i++)
				Matrix[row].Add(null);
		}
	}
	
	private void InitializeMatrixIndexers() {
		sbyte i = 1;
		for (sbyte row = 0; row < BOARD_SIZE; row++) {
			for (sbyte col = 0; col < BOARD_SIZE; col++) {
				_matrixIndexers[i++] = (row, col);
			}
		}
	}
}