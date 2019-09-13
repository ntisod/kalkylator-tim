using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkylator {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {
		enum Operator { add, sub, mult, div }; // Operators to use

		float sum = 0; // The sum of all
		string newNr; // the active number
		bool lockOperator = true; // So the user can't input 5++5
		bool isSummarized = false; //To check if it should be 5+5=105 or 5+5=10*5 
								   //when typing a number after the equals button
		Operator activeOperator = Operator.add;


		public MainWindow() {
			InitializeComponent();
		}

		private void AddDigit(string nr) {
			if (isSummarized) { //Is the number displayed a sum or not
				txtText.Text += "*"; //If so, multiply with it
				activeOperator = Operator.mult;
				newNr = "";
			}
			newNr += nr; //Then or otherwise add the number the user pressed
			txtText.Text += nr;
			isSummarized = false;
			lockOperator = false;
		}

		private void AddToSum() {
			if (newNr != null && newNr != "") { //If there is a number to add to sum
				switch (activeOperator) { //switch case for different operators
					case Operator.add:
						sum = sum + float.Parse(newNr);
						break;
					case Operator.sub:
						sum = sum - float.Parse(newNr);
						break;
					case Operator.mult:
						sum = sum * float.Parse(newNr);
						break;
					case Operator.div:
						sum = sum / float.Parse(newNr);
						break;
				}
			}
		}

		private void Btn0_Click(object sender, RoutedEventArgs e) {
			AddDigit("0");
		}
		private void Btn1_Click(object sender, RoutedEventArgs e) {
			AddDigit("1");
		}
		private void Btn2_Click(object sender, RoutedEventArgs e) {
			AddDigit("2");
		}
		private void Btn3_Click(object sender, RoutedEventArgs e) {
			AddDigit("3");
		}
		private void Btn4_Click(object sender, RoutedEventArgs e) {
			AddDigit("4");
		}
		private void Btn5_Click(object sender, RoutedEventArgs e) {
			AddDigit("5");
		}
		private void Btn6_Click(object sender, RoutedEventArgs e) {
			AddDigit("6");
		}
		private void Btn7_Click(object sender, RoutedEventArgs e) {
			AddDigit("7");
		}
		private void Btn8_Click(object sender, RoutedEventArgs e) {
			AddDigit("8");
		}
		private void Btn9_Click(object sender, RoutedEventArgs e) {
			AddDigit("9");
		}
		private void BtnSum_Click(object sender, RoutedEventArgs e) {
			if (!lockOperator) {
				AddToSum(); //Calculate the last typed number 
				txtText.Text = Convert.ToString(sum); //And display result
				newNr = "";
				isSummarized = true;
			}
		}

		private void BtnClear_Click(object sender, RoutedEventArgs e) {
			activeOperator = Operator.add; //Set everything to default
			sum = 0;
			newNr = "";
			txtText.Text = newNr;
			isSummarized = false;
			lockOperator = true;
		}

		private void TxtText_TextChanged(object sender, TextChangedEventArgs e) {

			
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) {
			if (!lockOperator) { //So there can't be a + after a +
				isSummarized = false;
				lockOperator = true;
				AddToSum(); //Add previous newNr before making a new one
				activeOperator = Operator.add; //Set new operator
				txtText.Text += "+";
				newNr = "";
			}
		}

		private void BtnSub_Click(object sender, RoutedEventArgs e) {
			if (!lockOperator) { //So there can't be a + after a +
				isSummarized = false;
				lockOperator = true;
				AddToSum(); //Add previous newNr before making a new one
				activeOperator = Operator.sub; //Set new operator
				txtText.Text += "-";
				newNr = "";
			}
		}

		private void BtnMult_Click(object sender, RoutedEventArgs e) {
			if (!lockOperator) { //So there can't be a + after a +
				isSummarized = false;
				lockOperator = true;
				AddToSum(); //Add previous newNr before making a new one
				activeOperator = Operator.mult; //Set new operator
				txtText.Text += "*";
				newNr = "";
			}
		}

		private void BtnDiv_Click(object sender, RoutedEventArgs e) {
			if (!lockOperator) { //So there can't be a + after a +
				isSummarized = false;
				lockOperator = true;
				AddToSum(); //Add previous newNr before making a new one
				activeOperator = Operator.div; //Set new operator
				txtText.Text += "/";
				newNr = "";
			}
		}
		private void BtnDot_Click(object sender, RoutedEventArgs e) {
			if (newNr != "" && newNr != null) //To make ,5 automatically 0,5
				AddDigit(",");
			else
				AddDigit("0,");
		}


		private void MenuInfo_Click(object sender, RoutedEventArgs e) {
			//Info under menu
			MessageBox.Show("Programmet skapad av Tim Rundström\nunder kursen programmering 2 (2019-2020)\n\n" +
				"OBS. Kalkylatorn använder sig inte utav prioriteringsregler.");
		}

		private void MenuExit_Click(object sender, RoutedEventArgs e) {
			//Exit under menu
			Application.Current.Shutdown();
		}

	}
}
