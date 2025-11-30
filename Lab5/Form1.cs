namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Alex Gaudet
         * Date: November 2025
         * This program rolls one dice or calculates mark stats.
         * Link to your repo in GitHub: 
         * */

        //class-level random object
        //Declared here so that every method (Roll, Generate) can share it.
        Random rand = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            //select one roll radiobutton
            radOneRoll.Checked = true;

            //add your name to end of form title
            // += adds to the existing text ("Lab 5") instead of replacing it.
            this.Text += " by Alex Gaudet";

        } // end form load

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call the function
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //call the function

        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            
            int dice1, dice2;

            //call ftn RollDice, placing returned number into integers
            dice1 = RollDice();
            dice2 = RollDice();

            //place integers into labels
            lblDice1.Text = dice1.ToString();
            lblDice2.Text = dice2.ToString();

            // call ftn GetName sending total and returning name
            int total = dice1 + dice2;
            string name = GetName(total);

            //display name in label
            lblRollName.Text = name;
        }

        /* Name: ClearOneRoll
        *  Sent: nothing
        *  Return: nothing
        *  Clear the labels */


        /* Name: ClearStats
        *  Sent: nothing
        *  Return: nothing
        *  Reset nud to minimum value, chkbox unselected, 
        *  clear labels and listbox */


        /* Name: RollDice
        * Sent: nothing
        * Return: integer (1-6)
        * Simulates rolling one dice */

        private int RollDice()
        {
            //Generate a number between 1 and 6
            // .Next(min, max) -> max is exclusive (so 7 means up to 6)
            return rand.Next(1, 7);
        }


        /* Name: GetName
        * Sent: 1 integer (total of dice1 and dice2) 
        * Return: string (name associated with total) 
        * Finds the name of dice roll based on total.
        * Use a switch statement with one return only
        * Names: 2 = Snake Eyes
        *        3 = Litle Joe
        *        5 = Fever
        *        7 = Most Common
        *        9 = Center Field
        *        11 = Yo-leven
        *        12 = Boxcars
        * Anything else = No special name*/

        private string GetName(int total)
        {
            string name = "";

            //Below is the switch statement to assign the name

            switch (total)
            {
                case 2:
                    name = "Snake Eyes";
                    break;
                case 3:
                    name = "Little Joe";
                    break;
                case 5:
                    name = "Fever";
                    break;
                case 7:
                    name = "Most Common";
                    break;
                case 9:
                    name = "Center Field";
                    break;
                case 11:
                    name = "Yo-leven";
                    break;
                case 12:
                    name = "Boxcars";
                    break;
                default:
                    name = "No special name";
                    break;
            }
            return name;
        }

        private void btnSwapNumbers_Click(object sender, EventArgs e)
        {
            //call ftn DataPresent twice sending string returning boolean

            //if data present in both labels, call SwapData sending both strings

            //put data back into labels

            //if data not present in either label display error msg
        }

        /* Name: DataPresent
        * Sent: string
        * Return: bool (true if data, false if not) 
        * See if string is empty or not*/


        /* Name: SwapData
        * Sent: 2 strings
        * Return: none 
        * Swaps the memory locations of two strings*/

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array

            //check if seed value

            //fill array using random number

            //call CalcStats sending and returning data

            //display data sent back in labels - average, pass and fail
            // Format average always showing 2 decimal places 

        } // end Generate click

        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.
        * Passmark is 60%
        * Calculate average and count how many marks pass and fail
        * The pass and fail values must also get returned for display*/
    }
}
