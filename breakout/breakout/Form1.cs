using System;
using System.Drawing;
using System.Windows.Forms;
namespace breakout
{
    public partial class Form1 : Form
    {
        //blocks
        int rows = 5;
        int columns = 10;
        int shift = 20;
        int w = 60;
        int h = 14;

    // player
        int x = 0;
        int wPlayer = 80;
        int y;
        int hPlayer = 12;
        int speed = 5;
    //keys
        bool left = false;
        bool right = false;
        bool game = false;

    // ball
        int ballX = 0;
        int ballY = 0;
        int ballSize = 20;
        int ballSpeed = 1;
        private int ballSpeedX = 1;
        private int ballSpeedY = 1;
        bool[,] blocks;


        bool isOut = false;
        bool over = false;
        bool newGame = false;
        public Form1()
        {
            InitializeComponent();
            InitializeBlocks();

        }

        private void InitializeBlocks()
        {
            // draw blocks
            blocks = new bool[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    blocks[i, j] = true; // Initialize all blocks as present
                }
            }
        }

        private void playArea(object sender, PaintEventArgs e)
        {

            Color[] blockColors = { Color.Yellow, Color.Red, Color.White, Color.Green, Color.Orange };

            Graphics g = e.Graphics;
            

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (blocks[i, j])
                    {
                        //block

                        Brush blockBrush = new SolidBrush(blockColors[i % blockColors.Length]);
                        g.FillRectangle(blockBrush, j * (w + shift), i * (h + shift), w, h);
                        blockBrush.Dispose();
                    }
                }
            }

            
            // player
            Brush playerColor = new SolidBrush(Color.White);
            y = area.Height - hPlayer;
            g.FillRectangle(playerColor, x, y, wPlayer, hPlayer);

            // ball
            Brush ballColor = new SolidBrush(Color.DarkGray);
            if (!game) return;
            g.FillEllipse(ballColor, ballX, ballY, ballSize, ballSize);

            if (game)
            {
                intervalBall.Start();
            }
        }

        private void movePlayer(object sender, KeyEventArgs e)
        {
            // keydown event
            switch (e.KeyCode)
            {
                case Keys.A:
                    left = true;
                    break;

                case Keys.D:
                    right = true;
                    break;
            }
        }

        private void stopPlayer(object sender, KeyEventArgs e)
        {
           // keyup event

            switch (e.KeyCode)
            {
                case Keys.A:
                    left = false;
                    timer.Start();
                    break;

                case Keys.D:
                    right = false;
                    timer.Start();
                    break;
            }
        }

        private void startGame(object sender, EventArgs e)
        {
            if (game)
            {
                timer.Enabled = true;
                if (left && !right && x > 0)
                {
                    x -= speed;
                }
                if (right && !left && x < area.Width - wPlayer)
                {
                    x += speed;
                }
                Refresh();
            }
        }

        private void disabled(object sender, EventArgs e)
        {
            // start game button click
            if (!newGame)
            {
                button1.Visible = false;
                game = true;
            }
            else
            {
                button1.Text = "Play again";

                restart();
                
                
                
            }
        }

        private void restart()
        {
            // Reset game-related variables
            game =true;
            left = false;
            right = false;
            isOut = false;
            over = false;

            // remove label and button

            info.Visible = false;
            button1.Visible = false;

            // Reset player and ball positions
            x = 0;
            y = area.Height - hPlayer;
            ballX = 0;
            ballY = 0;

            // Reset block status
            InitializeBlocks();

            // Restart the game timers
            intervalBall.Start();
            timer.Start();

            // Refresh the form to update the display
            Refresh();
        }


        private void ballAnimate(object sender, EventArgs e)
        {
            ballX += ballSpeedX;
            ballY += ballSpeedY;

            if (ballX >= this.Width - ballSize || ballX < 0)
            {
                ballSpeedX *= -1; // Reverse horizontal direction
                ballSpeedY = 1;   // Bounce vertically

            }

            if (ballY < 0)
            {
                ballSpeedY *= -1;
                ballSpeedX = 2;
            }
             if (ballY+ballSize/2 >= area.Height + ballSize)
            {
               // out of 
                over = true;
              
                intervalBall.Stop();
                timer.Stop();
            }
            else if (ballY + ballSize >= y && ballX > x && ballX < x + wPlayer)
            {
                int hitPosition = ballX - x + ballSize / 2;
                float normalizedHitPosition = (float)hitPosition / wPlayer * 2 - 1;
                ballSpeedX = (int)(normalizedHitPosition * ballSpeed);
                ballSpeedY *= -1;
                ballY = y - ballSize;
                isOut = true; 
            }
            // Check if the ball is out of bounds below the player
            if (ballY > area.Height + ballSize)
            {
                intervalBall.Stop();
                timer.Stop();
                info.Visible = true;
                newGame = true;
                button1.Visible = true;
            }
            CheckBlockCollisions();

            Refresh();
        }

        private void CheckBlockCollisions()
        {
            // collision between ball and blocks
            if (!isOut) return;
            int blockWidth = w;
            int blockHeight = h;
            int ballCenterX = ballX + ballSize / 2;
            int ballCenterY = ballY + ballSize / 2;
            int rowHit = -1;
            int colHit = -1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (blocks[i, j])
                    {
                        if (over) return;
                        int blockX = j * (blockWidth + shift);
                        int blockY = i * (blockHeight + shift);

                        if (ballCenterX >= blockX && ballCenterX <= blockX + blockWidth
                            && ballCenterY >= blockY && ballCenterY <= blockY + blockHeight)
                        {
                            rowHit = i;
                            colHit = j;
                            blocks[i, j] = false;

                            ballSpeedY *= -1;
                            ballSpeedX = 2;
                        }
                    }
                }
            }

           
       
    }
}
}
