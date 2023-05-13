using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TravelExpertsWorkshop1
{
    /// <summary>
    /// a repository of validation methods
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// checks if text box has text in it
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true;
            if (textBox.Text == "") // bad
            {
                MessageBox.Show(textBox.Tag + " is required");
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if combo box has value selected
        /// </summary>
        /// <param name="comboBox">combo box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsSelected(ComboBox comboBox)
        {
            bool isValid = true;
            if (comboBox.SelectedIndex == -1) // bad
            {
                MessageBox.Show(comboBox.Tag + " must be selected");
                comboBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains a non-negative int value
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int result;
            if (!Int32.TryParse(textBox.Text, out result)) // not an int
            {
                MessageBox.Show(textBox.Tag + " has to be a whole number");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            else if (result < 0) // it is an int but negative
            {
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains an int value within given range
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <param name="minVal">minimum value for the range</param>
        /// <param name="maxVal">maximum value for the range</param>
        /// <returns>true if valid and fals if not</returns>
        public static bool IsIntInRange(TextBox textBox, int minVal, int maxVal)
        {
            bool isValid = true;
            int result;
            if (!Int32.TryParse(textBox.Text, out result)) // not an int
            {
                MessageBox.Show(textBox.Tag + " has to be a whole number");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            else if (result < minVal || result > maxVal) // it is an int but out of range
            {
                MessageBox.Show(textBox.Tag + " has to be between " + minVal +
                                              " and " + maxVal);
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains a non-negative double value
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double result;
            if (!Double.TryParse(textBox.Text, out result)) // not a double
            {
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            else if (result < 0) // it is a double but negative
            {
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains a non-negative decimal value
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            decimal result;
            if (!Decimal.TryParse(textBox.Text, out result)) // not a decimal
            {
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            else if (result < 0) // it is a decimal but negative
            {
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// checks if text box contains a decimal value within given range
        /// </summary>
        /// <param name="textBox">text box to check (Tag property is set)</param>
        /// <param name="minVal">minimum value for the range</param>
        /// <param name="maxVal">maximum value for the range</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsDecimalInRange(TextBox textBox,
                                            decimal minVal, decimal maxVal)
        {
            bool isValid = true;
            decimal result;
            if (!Decimal.TryParse(textBox.Text, out result)) // not a decimal
            {
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            else if (result < minVal || result > maxVal) // it is a decimal but outside the range
            {
                MessageBox.Show(textBox.Tag + " has to be between " + minVal +
                                              " and " + maxVal);
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Checks if the entry is a date
        /// </summary>
        /// <param name="textBox">text box to check (tag property is set)</param>
        /// <returns>true if data input is correct and false if isnt</returns>
        public static bool IsDate(TextBox textBox)
        {
            bool isValid = true;
            DateTime minDate = DateTime.Parse("1000/01/28");
            // DateTime maxDate = DateTime.Parse("2023/04/13");
            DateTime maxDate = DateTime.Today;
            DateTime result;
            if (!DateTime.TryParse(textBox.Text, out result) && result >= maxDate) // not a date
            {
                MessageBox.Show(textBox.Tag + " has to be a valid date value with the format yyyy-MM-dd");
                textBox.SelectAll(); // select all text in the box for replacement
                textBox.Focus();
                
                isValid = false;
            }
            else if (DateTime.TryParse(textBox.Text, out result) == true &&
                        result > minDate &&
                        result <= maxDate)
            {
                //string[] formats = { "yyyy-MM-dd" };
                DateTime value;

            }
            else if (!string.IsNullOrEmpty(textBox.Text))
            {
                string[] formats = { "yyyy-MM-dd", "yyyy/MM/dd", "dd/MM/yyyy", "dd-MM-yyyy" };
                DateTime value;
            }

            return isValid;
        }
    }
}