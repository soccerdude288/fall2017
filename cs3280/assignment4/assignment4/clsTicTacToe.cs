using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    public class clsTicTacToe
    {
        public string[,] gameBoard;
        private int player1Wins;

        private int player2Wins;
        private int gameTies;
        private WinningMove winningMove;

        /// <summary>
        /// Enum of possible winning moves
        /// </summary>
        private enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        /// <summary>
        /// Initialize all win values to 0
        /// </summary>
        public clsTicTacToe()
        {
            player1Wins = 0;    
            player2Wins = 0;
            gameTies = 0;
        }
        
        /// <summary>
        /// returns array of game values
        /// </summary>
        /// <returns></returns>
        public int[] getGameStats()
        {
            int[] returnV = { player1Wins, player2Wins, gameTies };
            return returnV;
        }

        /// <summary>
        /// returns array of winning grid coordiantes
        /// </summary>
        /// <returns></returns>
        public String[] getWinningCoordinates()
        {
            String[] returnV = new String[3];
            switch (winningMove)
            {
                case WinningMove.Col1:
                    returnV[0] = "grid00";
                    returnV[1] = "grid01";
                    returnV[2] = "grid02";
                    return returnV;
                case WinningMove.Col2:
                    returnV[0] = "grid10";
                    returnV[1] = "grid11";
                    returnV[2] = "grid12";
                    return returnV;
                case WinningMove.Col3:
                    returnV[0] = "grid20";
                    returnV[1] = "grid21";
                    returnV[2] = "grid22";
                    return returnV;
                case WinningMove.Row1:
                    returnV[0] = "grid00";
                    returnV[1] = "grid10";
                    returnV[2] = "grid20";
                    return returnV;
                case WinningMove.Row2:
                    returnV[0] = "grid01";
                    returnV[1] = "grid11";
                    returnV[2] = "grid21";
                    return returnV;
                case WinningMove.Row3:
                    returnV[0] = "grid02";
                    returnV[1] = "grid12";
                    returnV[2] = "grid22";
                    return returnV;
                case WinningMove.Diag1:
                    returnV[0] = "grid00";
                    returnV[1] = "grid11";
                    returnV[2] = "grid22";
                    return returnV;
                case WinningMove.Diag2:
                    returnV[0] = "grid20";
                    returnV[1] = "grid11";
                    returnV[2] = "grid02";
                    return returnV;
                default:
                    return returnV;
            }
            
        }

        /// <summary>
        /// checks to see if there is a winning move
        /// </summary>
        /// <returns></returns>
        public bool isWinningMove()
        {
            if (isDiagWin())
            {
                return true;
            }
            else if (isVerticalWin())
            {
                return true;
            }
            else if (isHorizWin())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// helper method to check if a string is not null, then if it's equal
        /// </summary>
        /// <param name="i"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool notNullEquals(String i, String v)
        {
            if(i == null)
            {
                return false;
            }
            if (i.Equals(v))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks board for different diagnoal wins
        /// </summary>
        /// <returns></returns>
        private bool isDiagWin()
        {
            if(notNullEquals(gameBoard[0, 0],"X") && notNullEquals(gameBoard[1, 1],"X") && notNullEquals(gameBoard[2, 2],"X"))
            {
                winningMove = WinningMove.Diag1;
                player1Wins++;
                return true;
            }
            else if(notNullEquals(gameBoard[2, 0],"X") && notNullEquals(gameBoard[1, 1],"X") && notNullEquals(gameBoard[0, 2],"X"))
            {
                winningMove = WinningMove.Diag2;
                player1Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[0, 0],"Y") && notNullEquals(gameBoard[1, 1],"Y") && notNullEquals(gameBoard[2, 2],"Y"))
            {
                winningMove = WinningMove.Diag1;
                player2Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[2, 0],"Y") && notNullEquals(gameBoard[1, 1],"Y") && notNullEquals(gameBoard[0, 2],"Y"))
            {
                winningMove = WinningMove.Diag2;
                player2Wins++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks board for different vertical wins
        /// </summary>
        /// <returns></returns>
        private bool isVerticalWin()
        {
            if (notNullEquals(gameBoard[0, 0],"X") && notNullEquals(gameBoard[0, 1],"X") && notNullEquals(gameBoard[0, 2],"X"))
            {
                winningMove = WinningMove.Col1;
                player1Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[1, 0],"X") && notNullEquals(gameBoard[1, 1],"X") && notNullEquals(gameBoard[1, 2],"X"))
            {
                winningMove = WinningMove.Col2;
                player1Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[2, 0],"X") && notNullEquals(gameBoard[2, 1],"X") && notNullEquals(gameBoard[2, 2],"X"))
            {
                winningMove = WinningMove.Col3;
                player1Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[0, 0],"O") && notNullEquals(gameBoard[0, 1],"O") && notNullEquals(gameBoard[0, 2],"O"))
            {
                winningMove = WinningMove.Col1;
                player2Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[1, 0],"O") && notNullEquals(gameBoard[1, 1],"O") && notNullEquals(gameBoard[1, 2],"O"))
            {
                winningMove = WinningMove.Col2;
                player2Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[2, 0],"O") && notNullEquals(gameBoard[2, 1],"O") && notNullEquals(gameBoard[2, 2],"O"))
            {
                winningMove = WinningMove.Col3;
                player2Wins++;
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// checks board for different horizontal wins
        /// </summary>
        /// <returns></returns>
        private bool isHorizWin()
        {
            if(notNullEquals(gameBoard[0,0],"X") && notNullEquals(gameBoard[1, 0],"X") && notNullEquals(gameBoard[2, 0],"X"))
            {
                winningMove = WinningMove.Row1;
                player1Wins++;
                return true;
            }
            else if(notNullEquals(gameBoard[0, 1],"X") && notNullEquals(gameBoard[1, 1],"X") && notNullEquals(gameBoard[2, 1],"X"))
            {
                winningMove = WinningMove.Row2;
                player1Wins++;
                return true;
            }
            else if(notNullEquals(gameBoard[0, 2],"X") && notNullEquals(gameBoard[1, 2],"X") && notNullEquals(gameBoard[2, 2],"X"))
            {
                winningMove = WinningMove.Row3;
                player1Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[0, 0],"O") && notNullEquals(gameBoard[1, 0],"O") && notNullEquals(gameBoard[2, 0],"O"))
            {
                winningMove = WinningMove.Row1;
                player2Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[0, 1],"O") && notNullEquals(gameBoard[1, 1],"O") && notNullEquals(gameBoard[2, 1],"O"))
            {
                winningMove = WinningMove.Row2;
                player2Wins++;
                return true;
            }
            else if (notNullEquals(gameBoard[0, 2],"O") && notNullEquals(gameBoard[1, 2],"O") && notNullEquals(gameBoard[2, 2],"O"))
            {
                winningMove = WinningMove.Row3;
                player2Wins++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// checks board for if every cell is full
        /// </summary>
        /// <returns></returns>
        public bool isTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(gameBoard[i,j] == null)
                    {
                        return false;
                    }
                    
                }
            }
            gameTies++;
            return true;
        }
    }
}
