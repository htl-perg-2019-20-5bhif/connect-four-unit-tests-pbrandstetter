using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace ConnectFour.UI
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool gameOver = false;

        private string MessageValue = "";
        public string Message
        {
            get => MessageValue;
            set
            {
                MessageValue = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private List<List<SolidColorBrush>> ColorBoardValue;
        public List<List<SolidColorBrush>> ColorBoard
        {
            get => ColorBoardValue;
            set
            {
                ColorBoardValue = value;
                OnPropertyChanged(nameof(ColorBoard));
            }
        }

        private GameBoard GameBoardValue = new GameBoard();
        public GameBoard GameBoard
        {
            get => GameBoardValue;
            set
            {
                GameBoardValue = value;
                OnPropertyChanged(nameof(GameBoard));
            }
        }

        public MainWindowViewModel()
        {
            initEmptyColorBoard();
        }

        void initEmptyColorBoard()
        {
            ColorBoard = new List<List<SolidColorBrush>>();
            for (var i = 0; i < 6; i++)
            {
                ColorBoard.Add(new List<SolidColorBrush>());
                for (var j = 0; j < 7; j++)
                {
                    ColorBoard[i].Add(new SolidColorBrush(Colors.White));
                }
            }
        }

        void setColorBoard()
        {
            List<List<SolidColorBrush>> cBoard = new List<List<SolidColorBrush>>();

            for (var i = 0; i < 6; i++)
            {
                cBoard.Add(new List<SolidColorBrush>());
                for (var j = 0; j < 7; j++)
                {
                    switch (GameBoard.board[j, 5 - i])
                    {
                        case 0: cBoard[i].Add(new SolidColorBrush(Colors.White)); break;
                        case 1: cBoard[i].Add(new SolidColorBrush(Colors.Yellow)); break;
                        case 2: cBoard[i].Add(new SolidColorBrush(Colors.Red)); break;
                    }
                }
            }
            ColorBoard = cBoard;
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        public void SetStone(byte column)
        {
            if (!gameOver)
            {
                try
                {
                    var res = GameBoard.SetStone(column);
                    switch (res)
                    {
                        case 1: Message = "Player 1 has won!"; gameOver = true; break;
                        case 2: Message = "Player 2 has won!"; gameOver = true; break;
                        default: break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Message = ex.Message;
                }
                setColorBoard();
            }
        }
    }
}
