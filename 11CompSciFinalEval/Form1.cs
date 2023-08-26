using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11CompSciFinalEval
{
    public partial class Form1 : Form
    {
        //Int variables spaced to organise by relevance towards one another
        //Set rows to 25 and colums to 50, length = 500 / length of snake (20) = 25
        //width = 1000 / length of snake (20) = 50
        int rows = 25, columns = 50;
        //Length and width of snake head/food/timer is 20 x 20
        int ilength = 20;
        //Set the value representing the top and bottom of the snake to 0
        int top = 0, bottom = 0;
        //Set the values representing snakes next move on x and y coordinates to 0, as no movement is taking place
        int nextx = 0, nexty = 0;
        //Set the starting score to 0
        int score = 0;
        //Create array representing the available spaces for food and timers to spawn at a given time
        //length of array is number of rows by the number of columns to represent every possible space
        int[] spacesArray = new int[25 * 50];
        //Start the countdown at 10 seconds
        double countdown = 10;     
        //Boolean variable to determine whether a certain point is currently occupied by a square 
        //[ , ] allows program to register x and y coordinates
        bool[ , ] present;
        //Create a new timer for the speed at which snake will move
        Timer snaketimer = new Timer();
        //Declare a random variable to use for random spawns/locations
        Random rand = new Random();
        //Create snakes head, calling from Class1
        snakeSquare[] snake = new snakeSquare[1250];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //When the start button is initially pressed
            //Begin the process of setting up locations, variables, etc - calling on a method
            beginsetup();
            //Start the timer that dictates snakes movement and time remaining - calling a method
            startTimer();
            //Set the button to disabled to make it unpressable while program runs
            btnPlay.Enabled = false;
            //Make everything unassociated with the game invisible
            btnPlay.Visible = false;
            lblTitle.Visible = false;
            lblRules.Visible = false;
        }

        private void beginsetup()
        {
            //Set the count representing a space in the spaces array to 0
            int count = 0;
            //Create boolean variable, using the number of rows and columns as the max
            present = new bool[rows, columns];
            //Create the snake head caling from Class1
            //Choosing a random number of the number of columns and rows, finding the remainder, and multiplying by the length of each square allows for random row and column
            //Each location on the map is represented in increments of 20, so multiplying by length is required when generating number from 0-49
            snakeSquare head = new snakeSquare((rand.Next(50) % columns) * ilength, (rand.Next(25) % rows) * ilength);
            //Create a new location for the food
            lblFood.Location = new Point((rand.Next(50) % columns) * ilength, (rand.Next(25) % rows) * ilength);
            //Make the timer square invisible 
            lblTimer.Visible = false;
            //Move the square to an unreachable point (only locations in increments of 20 can be hit by snake)
            lblTimer.Location = new Point(1, 1);
            //Loop through every row in the form
            for (int i = 0; i < rows; i++)
            {
                //loop through every column in each row
                for (int j = 0; j < columns; j++)
                {
                    //set every possible space to false (nothing currently occupying)
                    present[i, j] = false;
                    //Store unique value for each space in the array - columns * y space + x space allows for retrieval of exact space later
                    spacesArray[count] = (columns * i + j);
                    //Increase the count by 1 to loop through every space in the array
                    count++;
                }
            }
            //Set the location of the snake headto true as it occupies that space
            present[head.Location.Y / ilength, head.Location.X / ilength] = true;
            //Invoke add control to add snakes head 
            Controls.Add(head);
            //Set the top of snake to the head
            snake[top] = head;
        }

        private void startTimer()
        {
            //Set the timer interval to 100 - ticks every tenth of a second
            snaketimer.Interval = 100;
            //Invokes moved method everytime the timer ticks
            snaketimer.Tick += moved;
            //Start the timer 
            snaketimer.Start();
        }

        private void moved(object sender, EventArgs e)
        {
            //Decrease the timer by a tenth of a second, as interval 100 passing is equivalent
            countdown -= 0.1;
            //Output the current time to the countdown label, showing time to one decimal
            lblCountdown.Text = countdown.ToString("##.#");
            //Countdown has reached 0 - game no longer continues
            if (countdown <= 0)
            {
                //Stop the timer
                snaketimer.Stop();
                //Change countdown label - equals -0.1 otherwise 
                lblCountdown.Text = "Time!";
                //Show message box saying times up
                MessageBox.Show("Times Up!");
                //return code to stop program
                return;
            }
            //Declare int variable for x and y coordinates of the head of snake 
            int x = snake[top].Location.X, y = snake[top].Location.Y;
            //No movement is occuring 
            if (nextx == 0 && nexty == 0)
            {
                //Return code to stop method
                //This stops game over at the beginning of game
                return;
            }
            //The next predicted space snake will travel is the timer square 
            if (reachTimer(x + nextx, y + nexty))
            {
                //Increase the countdown time by 4, granting more time
                countdown += 4;
                //Send timer square to an unreachable point by snake
                lblTimer.Location = new Point(1, 1);
                //Make the timer invisible to hide it while not in play
                lblTimer.Visible = false;
            }
            //The next predicted space snake will travel is the food square
            if (reachFood(x + nextx, y + nexty))
            {
                //Increase the score by 1
                score++;
                //Increase the countdown time by 2, granting more time
                countdown += 2;
                //Output the score to the score label
                lblScore.Text = "Score - " + score.ToString();
                //Create a new piece for snake - invoking Class1 snakeSquare
                snakeSquare head = new snakeSquare(x + nextx, y + nexty);
                //Subtract the top of snake counter by 1
                //(top + 1249) % 1250 used so top doesn't fall out of boundaries of snakeSquare and so it cycles through every space counter (1250)
                top = (top + 1249) % 1250;
                //Set the new top of snake to the head piece
                snake[top] = head;
                //Set the new head's location presence as true
                present[head.Location.Y / ilength, head.Location.X / ilength] = true;
                //Add the new snake head
                Controls.Add(head);
                //Invoke a method, spawning a randomly located food square and timer square if needed
                spawnFoodandTimer();
            }
            //The next predicted space snake will travel is the past the boundaries of the form
            else if (wallhit(x + nextx, y + nexty))
            {
                //Stop the timer allowing snake's movement
                snaketimer.Stop();
                //Display Message box saying wall was hit
                MessageBox.Show("Wall was hit");
                //Return the code, stopping the method/program
                return;
            }
            //The next predicted space snake will travel is a snake square or is empty
            else
            {
                //The next predicted space snake will travel is a square occupied by snake
                if (bodyhit((y + nexty) / ilength, (x + nextx) / ilength))
                {
                    //Stop the timer allowing snake's movement
                    snaketimer.Stop();
                    //Display Message box saying body was hit
                    MessageBox.Show("Body was hit");
                    //Return the code, stopping the method/program
                    return;
                }
                //Set the bottom location of snake that is about to move away to false
                present[snake[bottom].Location.Y / ilength, snake[bottom].Location.X / ilength] = false;
                //Subtract the top of snake counter by 1
                top = (top + 1249) % 1250;
                //Set the current top of snake to the value of the bottom 
                //Allows for cycling through spaces occupied by snake
                snake[top] = snake[bottom];
                //Set a new location for the top of snake
                snake[top].Location = new Point(x + nextx, y + nexty);
                //Subtract the bottom of snake counter by 1, cycling through occupied snake spaces
                bottom = (bottom + 1249) % 1250;
                //Set the space snake is about to occupy as occupied (true)
                present[(y + nexty) / ilength, (x + nextx) / ilength] = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //KeyDown recieves input on keys pressed during runtime
            //e.KeyCode being equal to the press of a key allows it to detect whatis pressed during runtime
            //Up key is pressed
            if (e.KeyCode == Keys.Up)
            {
                //Snake will travel -20 on the y coordinate
                nexty = ilength * -1;
                //Set next x move to 0 in order to avoid diagonal movement
                nextx = 0;
                //Return code
                return;
            }
            //Down key is pressed
            else if (e.KeyCode == Keys.Down)
            {
                //Snake will travel 20 on the y coordinate
                nexty = ilength;
                //Set next x move to 0 in order to avoid diagonal movement
                nextx = 0;
                //Return code
                return;
            }
            //Right key is pressed
            else if (e.KeyCode == Keys.Right)
            {
                //Snake will travel 20 on the x coordinate
                nextx = ilength;
                //Set next x move to 0 in order to avoid diagonal movement
                nexty = 0;
                //Return code
                return;
            }
            //Left key is pressed
            else if (e.KeyCode == Keys.Left)
            {
                //Snake will travel -20 on the x coordinate
                nextx = ilength * -1;
                //Set next x move to 0 in order to avoid diagonal movement
                nexty = 0;
                //Return code
                return;
            }
            //Erasing value of other x or y move during if statement instead of before allows button presses other than arrow keys to continue snake in the same direction
        }

        private void spawnFoodandTimer()
        {
            //Set the array space count down to 0
            int count = 0;
            //Loop through every row in the form
            for (int i = 0; i < rows; i++)
            {
                //Loop through every column in the form
                for (int j = 0; j < columns; j++)
                    //Check whether the current coordinates are currently occupied or not
                    if (!present[i, j])
                    {
                        //input columns * current row + current column into array to hold a specific value representing space
                        spacesArray[count] = columns * i + j;
                        //Add 1 to the count to cycle through spaces in array
                        count++;
                    }
            }
            //Create int variable to randomly generate a value representing a possible spot in the array
            int arrayspot = rand.Next(count);
            //Create new location for the food square using the value from random spot in the array
            lblFood.Location = new Point(spacesArray[arrayspot] * ilength % Width, spacesArray[arrayspot] * ilength / Width * ilength);
            //Check to see whether the timer is currently out of play and the game is on a second point
            if (lblTimer.Visible == false && score % 2 == 0)
            {
                //Set the location of the food as present to true, so timer square will never spawn in the same place as food
                present[lblFood.Location.Y / ilength, lblFood.Location.X / ilength] = true;
                //Set the count back to 0
                count = 0;
                //Loop through every row in the form
                for (int i = 0; i < rows; i++)
                {
                    //Loop through every column in the form
                    for (int j = 0; j < columns; j++)
                        //Check whether the current coordinates are occupied or not
                        if (!present[i, j])
                        {
                            //Save unique value represening coordinates in array
                            spacesArray[count] = columns * i + j;
                            //Add 1 to the count to cycle through space in array
                            count++;
                        }
                }
                //Randomly generate a value representing possible spot in array 
                arrayspot = rand.Next(count);
                //Create a new location for the timer square
                lblTimer.Location = new Point(spacesArray[arrayspot] * ilength % Width, spacesArray[arrayspot] * ilength / Width * ilength);
                //Make the timer visible to players
                lblTimer.Visible = true;
                //Set whether food is occupied to true, so colliding it with snake won't result in game over
                present[lblFood.Location.Y / ilength, lblFood.Location.X / ilength] = false;
            }
            
        }

        private bool reachFood(int x, int y)
        {
            //Check whether snakes next location is the same spot as the food square
            if (x == lblFood.Location.X && y == lblFood.Location.Y)
            {
                //Return food has been reached
                return true;
            }
            //Return food has not been reached
            return false;
        }

        private bool reachTimer(int x, int y)
        {
            //Check whether snakes next location is the same spot as the timer square
            if (x == lblTimer.Location.X && y == lblTimer.Location.Y)
            {
                //Return timer has been reached
                return true;
            }
            //Return timer has not been reached
            return false;
        }

        private bool wallhit(int x, int y)
        {
            //Check whether snakes next location is a location outside the boundaries of the form
            if (x < 0 || y < 0 || x > columns * ilength - 20 || y > rows * ilength - 20)
            {
                //Return wall has been hit
                return true;
            }
            //Return wall has not been hit
            return false;
        }

        private bool bodyhit(int x, int y)
        {
            //Check whether snakes next location is a spot currently occupied by itself
            if (present[x, y])
            {
                //Return snake has been hit
                return true;
            }
            //Return snake has not been hit
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
