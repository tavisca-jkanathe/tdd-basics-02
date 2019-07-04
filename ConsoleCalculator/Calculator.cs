public class Calculator
    {
		string  secondOperand="";
		string firstOperand="0";
		string consoleValue="0";
		char operatorValue='';
		bool decimalKey=false;
		
		private bool CheckValidInput(key)
		{
		char[] validKeys = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', '/', 's', 'c', '='};
		if (validKeys.Contains(key))
		{
			return true;
		}
		else
		{
			return false;
		}
		}
		
		private bool CheckValidOperator(key)
		{
		char[] validKeys = {'/', '-', '+', 'x'};
		if (validKeys.Contains(key))
		{
			return true;
		}
		else
		{
			return false;
		}
		}
		
		private void ClearAll()
		{
			secondOperand="";
			firstOperand="0";
			consoleValue="0";
			operatorValue='';
			decimalKey=false;
		}
		
		public void DoCalculation()
        {
            if(operatorValue == '+')
            {
                firstOperand = (double.Parse(firstOperand) + double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
            else if(operatorValue == '-')
            {
                firstOperand = (double.Parse(firstOperand) - double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
            else if(operation == '/')
            {
                if(secondOperand == "0")
                {
                    consoleValue = "-E-";
                }
                else
                {
                    firstNumber = (double.Parse(firstNumber) / double.Parse(secondOperand)).ToString();
					consoleValue=String.Copy(firstOperand);
                }
            }
            else if(operation == 'x')
            {
                firstNumber = (double.Parse(firstNumber) * double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
        }
		
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
			key=key.ToLower();
			if(CheckValidInput(key)== true)
			{
				if(key=='c')
				{
					ClearAll();
					consoleValue=String.Copy(firstOperand);
				}
				else if(key=='s')
				{
					if(operatorValue=='')
					{
						double changeSign=-1 * double.Parse(firstOperand);
						firstOperand=changeSign.ToString();
						consoleValue=String.Copy(firstOperand);
					}
					else
					{
						double changeSign=-1 * double.Parse(secondOperand);
						secondOperand=changeSign.ToString();
						consoleValue=String.Copy(secondOperand);
					}
					
				}
				else if(Char.IsDigit(key))
				{
					
					if (operatorValue=='')             
                    {
                        if ((firstOperand == "0" && key == '0')==false)
                        {
                            firstOperand = firstOperand + key;
                        }
						consoleValue=String.Copy(firstOperand);
                    }
                    else                        
                    {
                        if ((secondOperand == "0" && key == '0')==false)
                        {
                            secondOperand = secondOperand + key;
                        }
						consoleValue=String.Copy(secondOperand);
                    }
				}
				else if (key == '.')
                {
                    if (operatorValue=='' )                   
                    {
                        if(firstOperand.Contains('.')==false)
						{
                            firstOperand = firstOperand + ".";
							consoleValue=String.Copy(firstOperand);
						}
						else
						{
							consoleValue="-E-";//error
						}
                        
                    }
                    else            
                    {
                        if (secondOperand.Length == 0)
                        {
                            secondOperand = secondOperand + "0.";
							consoleValue=String.Copy(secondOperand);
                        }
                        else
                        {
							if(secondOperand.Contains('.')==false)
							{
								secondOperand = secondOperand + ".";
								consoleValue=String.Copy(secondOperand);
							}
							else
							{
								consoleValue="-E-";//error
							}
                        }
                    }
                }
				else if (CheckValidOperator(key))
                {
                    if (operatorValue!='')
                    {
                        DoCalculation();
                        secondNumber = "";
                    }
                    operatorValue = key;
                }
				else if (key == '=')
                {
                    DoCalculation();
                    operatorValue='';
                }
				
			}
			else
			{
				return consoleValue;
			}
			return consoleValue;
			
        }
    }
