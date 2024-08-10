using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace tictactoe_ass
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O, None
        }

        Player C_urrent_Player;
        Dictionary<Button, Player> button_Player_Map_Tiles;
        Timer turn_Timer;
        int playerWins = 0;
        int computerWins = 0;
        bool isPlayerTurn = true;


        private void Restart_Game_X(object sender, EventArgs e)
        {
            Reset_Game();
        }

        public Form1()
        {
            InitializeComponent();
            Reset_Game();


            turn_Timer = new Timer();
            turn_Timer.Interval = 4000;
            turn_Timer.Tick += TurnTimer_Tick;
        }

        private void TurnTimer_Tick(object sender, EventArgs e)
        {
            turn_Timer.Stop();
            isPlayerTurn = false;
            if (C_urrent_Player == Player.X)
            {
                MessageBox.Show("Time's up!It's AI's turn.");
                C_urrent_Player = Player.O;
                AIMove();
            }
        }

        private void PlayerClick(object sender, EventArgs e)
        {
            if (!isPlayerTurn)
            {
                MessageBox.Show("Heyy!!! It's not your turn!, Wait for it");
                return;
            }

            var button = (Button)sender;
            if (button_Player_Map_Tiles[button] == Player.None)
            {
                button_Player_Map_Tiles[button] = C_urrent_Player;
                button.Text = C_urrent_Player.ToString();
                button.Enabled = false;
                CheckGameOver();

                C_urrent_Player = C_urrent_Player == Player.X ? Player.O : Player.X;
                isPlayerTurn = false;
                turn_Timer.Stop();
                if (C_urrent_Player == Player.O)
                {
                    AIMove();
                }
            }
        }

        private void AIMove()
        {

            (int row, int col) = Minimax(button_Player_Map_Tiles, Player.O);
            Button selected_Button_tile = null;
            foreach (var key_value_pair in button_Player_Map_Tiles)
            {
                if (key_value_pair.Value == Player.None && key_value_pair.Key.Name == "button" + (row * 3 + col + 1))
                {
                    selected_Button_tile = key_value_pair.Key;
                    break;
                }
            }

            if (selected_Button_tile != null)
            {
                button_Player_Map_Tiles[selected_Button_tile] = Player.O;
                selected_Button_tile.Text = Player.O.ToString();
                selected_Button_tile.Enabled = false;
                CheckGameOver();


                C_urrent_Player = Player.X;
                isPlayerTurn = true;
                turn_Timer.Start();
            }
        }

        private (int, int) Minimax(Dictionary<Button, Player> board, Player player)
        {
            int best_Score_value = int.MinValue;
            int bestRow = -1;
            int bestCol = -1;


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = null;
                    foreach (var key_value_pair in board)
                    {
                        if (key_value_pair.Value == Player.None && key_value_pair.Key.Name == $"button{(i * 3) + j + 1}")
                        {
                            button = key_value_pair.Key;
                            break;
                        }
                    }

                    if (button != null)
                    {
                        board[button] = player;
                        int score = Minimax_Helper_Recursive(board, player == Player.X ? Player.O : Player.X, false);
                        board[button] = Player.None;

                        if (score > best_Score_value)
                        {
                            best_Score_value = score;
                            bestRow = i;
                            bestCol = j;
                        }
                    }
                }
            }

            return (bestRow, bestCol);
        }


        private int Minimax_Helper_Recursive(Dictionary<Button, Player> board, Player currentPlayer, bool isMaximizing)
        {
            if (Check_Winner(board, Player.X))
                return -1;
            if (Check_Winner(board, Player.O))
                return 1;
            if (IsBoardFull(board))
                return 0;

            if (isMaximizing)
            {
                int best_Score_value = int.MinValue;
                foreach (var key_value_pair in board)
                {
                    if (key_value_pair.Value == Player.None)
                    {
                        board[key_value_pair.Key] = currentPlayer;
                        int score = Minimax_Helper_Recursive(board, currentPlayer == Player.X ? Player.O : Player.X, false);
                        board[key_value_pair.Key] = Player.None;
                        best_Score_value = Math.Max(score, best_Score_value);
                    }
                }
                return best_Score_value;
            }
            else
            {
                int best_Score_value = int.MaxValue;
                foreach (var key_value_pair in board)
                {
                    if (key_value_pair.Value == Player.None)
                    {
                        board[key_value_pair.Key] = currentPlayer;
                        int score = Minimax_Helper_Recursive(board, currentPlayer == Player.X ? Player.O : Player.X, true);
                        board[key_value_pair.Key] = Player.None;
                        best_Score_value = Math.Min(score, best_Score_value);
                    }
                }
                return best_Score_value;
            }
        }

        private bool Check_Winner(Dictionary<Button, Player> board, Player player)
        {
            var possible_winning_Combinations = new[]
           {
                new[] { button1, button2, button3 },
                new[] { button4, button5, button6 },
                new[] { button7, button8, button9 },
                new[] { button1, button4, button7 },
                new[] { button2, button5, button8 },
                new[] { button3, button6, button9 },
                new[] { button1, button5, button9 },
                new[] { button3, button5, button7 }
            };


            foreach (var combination in possible_winning_Combinations)
            {
                if (combination.All(btn => board[btn] == player))
                    return true;
            }

            return false;
        }

        private bool IsBoardFull(Dictionary<Button, Player> board)
        {

            return board.All(kv => kv.Value != Player.None);
        }

        private void CheckGameOver()
        {
            if (Check_Winner(button_Player_Map_Tiles, Player.X))
            {
                MessageBox.Show("You win!");
                turn_Timer.Stop();
                Reset_Game();
            }
            else if (Check_Winner(button_Player_Map_Tiles, Player.O))
            {
                MessageBox.Show("AI wins!");
                turn_Timer.Stop();
                Reset_Game();
            }
            else if (IsBoardFull(button_Player_Map_Tiles))
            {
                MessageBox.Show("It's a draw!");
                turn_Timer.Stop();
                Reset_Game();
            }
        }

        private void Reset_Game()
        {
            C_urrent_Player = Player.X;
            button_Player_Map_Tiles = new Dictionary<Button, Player>
            {
                { button1, Player.None }, { button2, Player.None }, { button3, Player.None },
                { button4, Player.None }, { button5, Player.None }, { button6, Player.None },
                { button7, Player.None }, { button8, Player.None }, { button9, Player.None }
            };

            foreach (var button in button_Player_Map_Tiles.Keys)
            {
                button.Text = "";
                button.Enabled = true;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            turn_Timer.Stop();
            base.OnFormClosing(e);
        }

        private void EXITBTN_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
