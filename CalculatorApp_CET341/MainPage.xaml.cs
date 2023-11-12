namespace CalculatorApp_CET341
{
    public partial class MainPage : ContentPage
    {
        public string CurrentInput { get; private set; } = string.Empty;

        public string RunningTotal { get ; private set; } = string.Empty;

        private string selectedOperator;
        string[] operators = { "+",  "-", "/", "x", "="};
        string[] numbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool resetOnNextInput = false;
        public MainPage()
        {
            InitializeComponent();
            result.Text = "0"; // Başlangıçta ekranda "0" görünecek
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var thisInput = btn.Text;

            if (thisInput == "C")
            {
                CurrentInput = "0";
                RunningTotal = String.Empty;
                selectedOperator = String.Empty;
                result.Text = CurrentInput;
                resetOnNextInput = false;
            }
            else if (numbers.Contains(thisInput))
            {
                if (resetOnNextInput)
                {
                    CurrentInput = btn.Text;
                    resetOnNextInput = false;
                }
                else
                {
                    CurrentInput += btn.Text;
                }
                result.Text = CurrentInput;
            }
            else if (operators.Contains(thisInput))
            {
                var ans = PerformCalculator();
                if (thisInput == "=")
                {
                    CurrentInput = ans.ToString();
                    result.Text = CurrentInput;
                    RunningTotal = String.Empty;
                    selectedOperator = String.Empty;
                    resetOnNextInput = true;
                }
                else if (numbers.Contains(thisInput))
                {
                    if (resetOnNextInput)
                    {
                        CurrentInput = btn.Text;
                        resetOnNextInput = false;
                    }
                    else
                    {
                        if (CurrentInput == "0")
                        {
                            CurrentInput = btn.Text;
                        }
                        else if (CurrentInput.StartsWith("0"))
                        {
                            CurrentInput = btn.Text;
                        }
                        else
                        {
                            CurrentInput += btn.Text;
                        }
                    }
                    result.Text = CurrentInput;
                }

                else
                {
                    RunningTotal = ans.ToString();
                    selectedOperator = thisInput;
                    CurrentInput = String.Empty;
                    result.Text = CurrentInput;
                }
            }
        }


        private double PerformCalculator()
        {
            double currentVal;
            double.TryParse(CurrentInput, out currentVal);

            double runningVal;
            double.TryParse(RunningTotal, out runningVal);

            double res;

            switch (selectedOperator)
            {
                case "+":
                    res = runningVal + currentVal;
                    break;
                case "-":
                    res = runningVal - currentVal;
                    break;
                case "/":
                    res = runningVal / currentVal;
                    break;
                case "x":
                    res = runningVal * currentVal;
                    break;
                default:
                    res = currentVal;
                    break;
            }
            return res;
        }
    }
}
