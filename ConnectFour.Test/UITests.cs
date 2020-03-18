using System;
using Xunit;
using ConnectFour.UI;
using System.Windows.Media;

namespace ConnectFour.Test
{
    public class UITests
    {
        [Fact]
        public void SetStoneInColumn()
        {
            var mwvm = new MainWindowViewModel();

            mwvm.SetStone(0);

            Assert.Equal(Colors.Yellow, mwvm.ColorBoard[5][0].Color);
        }

        [Fact]
        public void EmptyBoard()
        {
            var mwvm = new MainWindowViewModel();

            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    Assert.Equal(Colors.White, mwvm.ColorBoard[i][j].Color);
                }
            }
        }

        [Fact]
        public void EmptyMessage()
        {
            var mwvm = new MainWindowViewModel();

            for (var i = 0; i < 6; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    Assert.Equal(string.Empty, mwvm.Message);
                }
            }
        }

        [Fact]
        public void SetStoneInFullColumn()
        {
            var mwvm = new MainWindowViewModel();

            for (var i = 0; i < 7; i++)
            {
                mwvm.SetStone(0);
            }

            Assert.Equal("Column is full", mwvm.Message);
        }

        [Fact]
        public void PlayerOneWinVertical()
        {
            var mwvm = new MainWindowViewModel();

            for (var i = 0; i < 3; i++)
            {
                mwvm.SetStone(0);
                mwvm.SetStone(1);
            }

            mwvm.SetStone(0);

            Assert.Equal("Player 1 has won!", mwvm.Message);
        }

        [Fact]
        public void PlayerTwoWinDiagonal()
        {
            var mwvm = new MainWindowViewModel();

            mwvm.SetStone(5);
            mwvm.SetStone(0);
            mwvm.SetStone(1);
            mwvm.SetStone(1);
            mwvm.SetStone(2);
            mwvm.SetStone(2);
            mwvm.SetStone(3);
            mwvm.SetStone(2);
            mwvm.SetStone(3);
            mwvm.SetStone(3);
            mwvm.SetStone(5);
            mwvm.SetStone(3);

            Assert.Equal("Player 2 has won!", mwvm.Message);
        }

        [Fact]
        public void SetStoneInFullBoard()
        {
            var mwvm = new MainWindowViewModel();

            for (byte i = 0; i < 3; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    mwvm.SetStone(i);
                }
            }
            mwvm.SetStone(6);
            for (byte i = 3; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    mwvm.SetStone(i);
                }
            }
            for (var j = 0; j < 5; j++)
            {
                mwvm.SetStone(6);
            }

            Assert.Equal("Table is full", mwvm.Message);
        }

        [Fact]
        public void CheckGameAlreadyOver()
        {
            var mwvm = new MainWindowViewModel();

            for (byte i = 0; i < 3; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    mwvm.SetStone(i);
                }
            }
            mwvm.SetStone(6);
            for (byte i = 3; i < 6; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    mwvm.SetStone(i);
                }
            }
            for (var j = 0; j < 6; j++)
            {
                mwvm.SetStone(6);
            }

            Assert.Equal("Game already over", mwvm.Message);
        }
    }
}
