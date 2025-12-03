namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Alex Gaudet
         * Date: December 02 2025
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
            // += adds to the existing text ("Lab 5 by") instead of replacing it.
            this.Text += "Alex Gaudet";

        } // end form load

        private void btnClear_Click(object sender, EventArgs e)
        {
            //call the function
            ClearOneRoll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //call the function
            ClearStats();
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

        private void ClearOneRoll()
        {
            lblDice1.Text = "";
            lblDice2.Text = "";
            lblRollName.Text = "";
        }


        /* Name: ClearStats
        *  Sent: nothing
        *  Return: nothing
        *  Reset nud to minimum value, chkbox unselected, 
        *  clear labels and listbox */
        private void ClearStats()
        {
            //Reset controls to defaults
            nudNumber.Value = nudNumber.Minimum; // -> 50
            chkSeed.Checked = false;

            //Clear Outputs
            lstMarks.Items.Clear();
            lblPass.Text = "";
            lblFail.Text = "";
            lblAverage.Text = "";
        }


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
                    name = "Litle Joe";
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
            if (DataPresent(lblDice1.Text) && DataPresent(lblDice2.Text))
            {
                //store data from labels into string variables
                string val1 = lblDice1.Text;
                string val2 = lblDice2.Text;

                //if data present in both labels, call SwapData sending both strings
                SwapData(ref val1, ref val2);

                //put data back into labels
                lblDice1.Text = val1;
                lblDice2.Text = val2;
            }
            else
            {
                //if data not present in either label display error msg
                MessageBox.Show("Roll the dice first!", "Data Missing");
            }
        }

        /* Name: DataPresent
        * Sent: string
        * Return: bool (true if data, false if not) 
        * See if string is empty or not*/

        private bool DataPresent(string text)
        {
            // Returns TRUE if the string has text, FALSE if it is empty/null
            return !string.IsNullOrEmpty(text);
        }


        /* Name: SwapData
        * Sent: 2 strings
        * Return: none 
        * Swaps the memory locations of two strings*/

        private void SwapData(ref string a, ref string b)
        {
            string temp = a; //A temp bucket
            a = b;  //Overwite 'a' with 'b'
            b = temp;   //Overwrite 'b' with what was in the temp bucket
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //declare variables and array
            int size = (int)nudNumber.Value;

            int[] marks = new int[size];

            //check if seed value
            if (chkSeed.Checked)
            {
                rand = new Random(1000);
            }
            else
            {
                //If not checked, ensure we go back to random
                rand = new Random();
            }

            lstMarks.Items.Clear();

            //fill array using random number
            int i = 0;
            while (i < marks.Length)
            {
                int num = rand.Next(40, 101);

                marks[i] = num;

                lstMarks.Items.Add(num);

                i++;
            }

            //call CalcStats sending and returning data
            int pass = 0;
            int fail = 0;

            double average = Calcstats(marks, ref pass, ref fail);

            //display data sent back in labels - average, pass and fail
            lblPass.Text = pass.ToString();
            lblFail.Text = fail.ToString();

            // Format average always showing 2 decimal places 
            lblAverage.Text = average.ToString("n2");

        } // end Generate click

        /* Name: CalcStats
        * Sent: array and 2 integers
        * Return: average (double) 
        * Run a foreach loop through the array.*/
        private double Calcstats(int[] marks, ref int passCount, ref int faiLCount)
        {
            double total = 0;

            //Reset counters to 0 before we start counting
            passCount = 0;
            faiLCount = 0;

            foreach (int mark in marks)
            {
                //Add to toal for average later.
                total += mark;

                //Check Pass/Fail (Passmark is 60%)
                if (mark >= 60)
                {
                    passCount++;
                }
                else
                {
                    faiLCount++;
                }

            }

            //Calculates Average (Protects against a divide by 0) and counts how many marks pass and fail
            if (marks.Length > 0)
            {
                return total / marks.Length;
            }
            else
            {
                //The pass and fail values must also get returned for display.
                return 0;
            }

        }

        private void chkSeed_CheckedChanged(object sender, EventArgs e)
        {
            // User confirmation DialogResult
            if (chkSeed.Checked)
            {
                //Asks the user
                DialogResult result = MessageBox.Show("Are you sure you want to use a seed value?",
                                                      "Confirm Seed",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                //If the user selects no, uncheck the box immediately
                if (result == DialogResult.No)
                {
                    chkSeed.Checked = false;
                }
            }
        }

        private void radOneRoll_CheckedChanged(object sender, EventArgs e)
        {
            //Check if "One Roll" is the one selected
            if (radOneRoll.Checked)
            {
                //SHOW the Dice section, HIDE the Stats section
                grpOneRoll.Visible = true;
                grpMarkStats.Visible = false;

                //Resets the form
                ClearOneRoll();
            }
            else
            {
                //The user must have clicked "Mark Stats"
                //HIDE the Dice section, SHOW the Stats ssection
                grpOneRoll.Visible = false;
                grpMarkStats.Visible = true;

                //Resets the form
                ClearStats();
            }
        }
    }
}
