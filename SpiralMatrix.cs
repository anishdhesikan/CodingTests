using System;
using System.Collections;
using System.Collections.Generic;

public class Solution {
	public enum Direction {
		North,
		East,
		South,
		West
	}

	public Direction NextDirection (Direction curDirection) {
		switch (curDirection)
		{
		case Direction.North:
			return Direction.East;
		case Direction.East:
			return Direction.South;
		case Direction.South:
			return Direction.West;
		case Direction.West:
			return Direction.North;
		}
		Console.WriteLine("Invalid Direction given to NextDirection()");
		return Direction.North;
	}

	public int GetNextCol (int curCol, Direction direction) {
		if (direction == Direction.East) {
			return curCol + 1;
		}
		else if (direction == Direction.West) {
			return curCol - 1;
		}
		else {
			return curCol;
		}
	}

	public int GetNextRow (int curRow, Direction direction) {
		if (direction == Direction.North) {
			return curRow - 1;
		}
		else if (direction == Direction.South) {
			return curRow + 1;
		}
		else {
			return curRow;
		}
	}

	public ArrayList SpiralOrder(int[,] matrix) {
		ArrayList result = new ArrayList();

		int numRows = matrix.GetLength(0);
		int numCols = matrix.GetLength(1);

		int curCol = 0;
		int curRow = 0;

		Direction curDirection = Direction.East;
		int numTimesEdgeHit = 1;
		int edgePadding = 0;
		bool hitEdge = false;
		bool currentlyOutsideBounds = false;
		for (int i = 0; i < numCols * numRows; i++) {
			// check if hit an edge
			hitEdge = false;
			if (curCol < 0 + edgePadding) {
				if (!currentlyOutsideBounds) {
					curCol = 0 + edgePadding;
					hitEdge = true;
				}
			}
			if (curCol > numCols - edgePadding - 1) {
				curCol = numCols - edgePadding - 1;
				hitEdge = true;
			}
			if (curRow < 0 + edgePadding) {
				curRow = 0 + edgePadding;
				hitEdge = true;
			}
			if (curRow > numRows - edgePadding - 1) {
				curRow = numRows - edgePadding - 1;
				hitEdge = true;
			}
			if (hitEdge) {
				numTimesEdgeHit++;
				curDirection = NextDirection(curDirection);
				// update next position
				curCol = GetNextCol (curCol, curDirection);
				curRow = GetNextRow (curRow, curDirection);
				currentlyOutsideBounds = false;
			}

			// if hit an edge 4 times, increment edgePadding and reset numTimesEdgeHit
			if (numTimesEdgeHit >= 4) {
				numTimesEdgeHit = 0;
				edgePadding++;
				currentlyOutsideBounds = true;
			}

			// add this item to the final result
			int curItem = matrix[curRow, curCol];
			result.Add(curItem);


			// update next position
			curCol = GetNextCol (curCol, curDirection);
			curRow = GetNextRow (curRow, curDirection);
		}

		foreach (int i in result) {
			Console.Write (i + " ");
		}
		return result;
	}
}

Solution sol = new Solution();
int[,] twobytwo = new int[2, 2] { {1, 2}, {3, 4} };
int[,] threebythree = new int[3, 3] { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
int[,] threebyfour = new int[3, 4] { {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12} };
int[,] fourbyfour = new int[4, 4] { {1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};
sol.SpiralOrder(fourbyfour);