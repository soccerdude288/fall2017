using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment4
{
    public partial class Form1 : Form
    {
        clsTicTacToe ticTacToe;
        bool isGameStarted;
        string[,] gameBoard;
        bool isX;

        /// <summary>
        /// Different game status to show in the status box.
        /// These are used so the same message is always showed.
        /// </summary>
        private enum gameStatus
        {
            start,
            p1,
            p2,
            p1win,
            p2win,
            tie
        }

        /// <summary>
        /// Initialize form, game board, tic tac toe class, set game started to false, and player 1 to true
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            clearLabel();
            gameBoard = new String[3, 3] { { null, null, null }, { null, null, null }, { null, null, null } };
            ticTacToe = new clsTicTacToe();
            ticTacToe.gameBoard = gameBoard;
            isGameStarted = false;
            isX = true;
        }

        /// <summary>
        /// Resets all labels in game board to null
        /// </summary>
        private void resetGameBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i, j] = null;
                }
            }
        }

        /// <summary>
        /// On click for start button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            isGameStarted = true;
            resetGameBoard();
            updateGameStatus(gameStatus.p1);
            clearLabel();
            isX = true;
            clearBackgroundColor();
        }

        /// <summary>
        /// Clears labels for entire game board
        /// </summary>
        private void clearLabel()
        {
            grid00.Text = "";
            grid10.Text = "";
            grid20.Text = "";
            grid01.Text = "";
            grid11.Text = "";
            grid21.Text = "";
            grid02.Text = "";
            grid12.Text = "";
            grid22.Text = "";
        }

        /// <summary>
        /// on click for label in game board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridClick(object sender, EventArgs e)
        {
            Label clicked = (Label)sender;
            if (isGameStarted)
            {
                String coordinates = clicked.Tag.ToString();
                char xC = coordinates[0];
                char yC = coordinates[1];
                double xD = Char.GetNumericValue(xC);
                double yD = Char.GetNumericValue(yC);
                int x = (int)xD;
                int y = (int)yD;
                //loadboard
                ticTacToe.gameBoard = gameBoard;
                //is space blank
                if (gameBoard[x,y] == null)
                {
                    if (isX == true)
                    {
                        clicked.Text = "X";
                        isX = false;
                        gameBoard[x, y] = "X";
                        ticTacToe.gameBoard = gameBoard;
                    }
                    else
                    {
                        clicked.Text = "O";
                        isX = true;
                        gameBoard[x, y] = "O";
                        ticTacToe.gameBoard = gameBoard;
                    }
                    //isWinningMove
                    if (ticTacToe.isWinningMove())
                    {
                        //isX true == player 1, but gets set after label is changed
                        //so I check for the not isX
                        gameWon(!isX);
                        highlightWinner(ticTacToe.getWinningCoordinates());
                    }
                    //istie
                    else if (ticTacToe.isTie())
                    {
                        gameTie();
                    }
                    else
                    {
                        if (isX)
                        {
                            updateGameStatus(gameStatus.p1);
                        }
                        else
                        {
                            updateGameStatus(gameStatus.p2);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// With the array of winning cells from tic tac toe class,
        /// loop through cells, find label, and set background color
        /// to yellow.
        /// </summary>
        /// <param name="values"></param>
        private void highlightWinner(String[] values)
        {
            foreach(String i in values)
            {
                Label l = findLabelByName(i);
                l.BackColor = Color.Yellow;
            }
        }

        /// <summary>
        /// Sets all labels to transparent background color
        /// </summary>
        private void clearBackgroundColor()
        {
            grid00.BackColor = Color.Transparent;
            grid10.BackColor = Color.Transparent;
            grid20.BackColor = Color.Transparent;
            grid01.BackColor = Color.Transparent;
            grid11.BackColor = Color.Transparent;
            grid21.BackColor = Color.Transparent;
            grid02.BackColor = Color.Transparent;
            grid12.BackColor = Color.Transparent;
            grid22.BackColor = Color.Transparent;

        }

        /// <summary>
        /// Helper method to find label based on name
        /// Wasn't able to find a better way to do this in C#
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Label findLabelByName(String name)
        {
            if (name.Equals("grid00"))
            {
                return grid00;
            }
            else if (name.Equals("grid10"))
            {
                return grid10;
            }
            else if (name.Equals("grid20"))
            {
                return grid20;
            }
            else if (name.Equals("grid01"))
            {
                return grid01;
            }
            else if (name.Equals("grid11"))
            {
                return grid11;
            }
            else if (name.Equals("grid21"))
            {
                return grid21;
            }
            else if (name.Equals("grid02"))
            {
                return grid02;
            }
            else if (name.Equals("grid12"))
            {
                return grid12;
            }
            else
            {
                return grid22;
            }
        }


        /// <summary>
        /// Sets game status label based on enum that is passed in
        /// </summary>
        /// <param name="status"></param>
        private void updateGameStatus(gameStatus status)
        {
            switch (status)
            {
                case gameStatus.start:
                    v_gameStatus.Text = "Press Start To Begin";
                    break;
                case gameStatus.tie:
                    v_gameStatus.Text = "Game Resulted in a Tie.\nPress Start to play again";
                    break;
                case gameStatus.p1win:
                    v_gameStatus.Text = "Player 1 Wins!";
                    break;
                case gameStatus.p2win:
                    v_gameStatus.Text = "Player 2 Wins!";
                    break;
                case gameStatus.p1:
                    v_gameStatus.Text = "Player 1 Turn";
                    break;
                case gameStatus.p2:
                    v_gameStatus.Text = "Player 2 Turn";
                    break;
            }
        }

        /// <summary>
        /// when game is won it updates display and status
        /// Sets game started to false
        /// </summary>
        /// <param name="isPlayerOne"></param>
        private void gameWon(bool isPlayerOne)
        {
            resetGameBoard();
            if(isPlayerOne == true)
            {
                updateGameStatus(gameStatus.p1win);
            }
            else
            {
                updateGameStatus(gameStatus.p2win);
            }
            updateGameDisplay();
            isGameStarted = false;
        }

        /// <summary>
        /// when game is tie, updates display and status
        /// sets game started to false
        /// </summary>
        private void gameTie()
        {
            //update status
            updateGameStatus(gameStatus.tie);
            updateGameDisplay();
            isGameStarted = false;
        }

        /// <summary>
        /// gets values from tic tac toe class to set game display
        /// </summary>
        private void updateGameDisplay()
        {
            int[] values = ticTacToe.getGameStats();
            v_p1Wins.Text = values[0].ToString();
            v_p2Wins.Text = values[1].ToString();
            v_gameTies.Text = values[2].ToString();
        }
    }
}
