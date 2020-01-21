
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace InjenerCalculator
{
    public partial class Form1 : Form
    {
        bool usual;
        bool ctrl;
        bool shift;
        bool buttonChecker;
        bool blue;
        bool first;// Завдяки цій змінній визначаеться чи ми вводимо число 1 раз чи ні
        bool invbtnpressed;// Завдяки цій змінній визначаеться чи ми натиснули клавішу Inv на формі 
        //ця клавіша в свою чергу змінює певний текст кнопок форми
        bool Fe;
        int countlb;
        int countrb;
        string Mbuffer = "0";
        string MainBuffer = "0";
        public Form1()
        {
            InitializeComponent();
            Height = 500;
            buttonChecker = false;
            invbtnpressed = false;
            blue = false;
            Fe = false;
            ctrl = false;
            shift = false;
            
            ЗвичайниToolStripMenuItem_Click(null, null);
            first = true;
            countlb = 0;
            countrb = 0;
        }
       

        // Метод який відповідає за додавання чисел до нашої псевдоцифри на панелі
        private void CheckAdd(string number)
        {
            int length;
            if (usual) length = 16;
            else
                length = 32;
            if(labelResult.Text==Math.PI.ToString() || labelResult.Text == Math.E.ToString() &&( number!= Math.PI.ToString() || number != Math.E.ToString()))
            {
                labelResult.Text = number;
                buttonChecker = true;
                first = true;
            }
            if (!buttonChecker)
            {
                labelResult.Text = "0";
                buttonChecker = true;
                first = true;
            }
            if (first && number == "0")
            {
                return;
            }
            if (first)
            {
                labelResult.Text = number;
                first = false;
                return;
            }
            else if (labelResult.Text.Length < length)
            {
                labelResult.Text += number;
            }
            else
            {
                SystemSounds.Beep.Play();
            }

        }

        //Подія яка обробляє яка клавіша була натиснута на формі
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
            {
                
                ctrl = true;
            }
            if(e.Shift)
            {
                
                shift = true;
            }
            switch (e.KeyCode)//Світч який по коду який прийшов визначає яка клавіша натиснута і потім виконую назначені дії
            {
                case Keys.Decimal:
                    {
                        Coma_Click(null, null);
                    }
                    break;
                case Keys.Oem2:
                    {
                        if(shift)
                        {
                            shift = false;
                            ButtonDiv_Click(null, null);
                        }
                        else
                            Coma_Click(null, null);
                    }
                    break;
                case Keys.OemMinus:
                    {
                        ButtonMines_Click(null, null);
                    }
                    break;
                case Keys.Subtract:
                    {
                        ButtonMines_Click(null, null);
                    }
                    break;
                case Keys.Divide:
                    {
                        ButtonDiv_Click(null, null);
                    }
                    break;
                case Keys.Oem5:
                    {
                        if(shift)
                        {
                            shift = false;
                            ButtonDiv_Click(null, null);
                        }
                        
                    }
                    break;
                    
                case Keys.Multiply:
                {
                        ButtonUmn_Click(null, null);
                    } break;

                case Keys.Oemplus:
                    {
                        ButtonPlus_Click(null, null);
                    }
                    break;
                case Keys.Add:
                    {
                        ButtonPlus_Click(null, null);
                    }
                    break;
                case Keys.Enter:
                    {
                        Equal_Click(null, null);
                    }break;
                case Keys.C:
                    {
                        if (ctrl)
                        {
                            Clipboard.SetText(labelResult.Text);
                           
                        }
                    }break;
                case Keys.V:
                    {
                        if(ctrl)
                        {
                            try
                            {
                                double res = double.Parse(Clipboard.GetText());
                                labelResult.Text = res.ToString();
                            }
                            catch (Exception)
                            {
                                Clipboard.Clear();
                                return;
                            }
                            
                        }
                    }break;
                case Keys.Back:
                    {
                        BackSpace_Click(sender, e);
                    }
                    break;
                case Keys.NumPad0:
                    {
                        Zero_Click(sender, e);
                    }
                    break;
                case Keys.NumPad1:
                    {
                        One_Click(sender, e);
                    }
                    break;
                case Keys.NumPad2:
                    {
                        Two_Click(sender, e);
                    }
                    break;
                case Keys.NumPad3:
                    {
                        Three_Click(sender, e);
                    }
                    break;
                case Keys.NumPad4:
                    {
                        Four_Click(sender, e);
                    }
                    break;
                case Keys.NumPad5:
                    {
                        Five_Click(sender, e);
                    }
                    break;
                case Keys.NumPad6:
                    {
                        Six_Click(sender, e);
                    }
                    break;
                case Keys.NumPad7:
                    {
                        Seven_Click(sender, e);
                    }
                    break;
                case Keys.NumPad8:
                    {
                        Eight_Click(sender, e);
                    }
                    break;
                case Keys.NumPad9:
                    {
                        Nine_Click(sender, e);
                    }
                    break;
                case Keys.D0:
                    {
                        if (shift)
                        {
                            shift = false;
                            RScob_Click(null, null); return;
                        }
                        Zero_Click(sender, e);
                    }
                    break;
                case Keys.D1:
                    {
                        One_Click(sender, e);
                    }
                    break;
                case Keys.D2:
                    {
                        Two_Click(sender, e);
                    }
                    break;
                case Keys.D3:
                    {
                        Three_Click(sender, e);
                    }
                    break;
                case Keys.D4:
                    {
                        Four_Click(sender, e);
                    }
                    break;
                case Keys.D5:
                    {
                        Five_Click(sender, e);
                    }
                    break;
                case Keys.D6:
                    {
                        Six_Click(sender, e);
                    }
                    break;
                case Keys.D7:
                    {
                        Seven_Click(sender, e);
                    }
                    break;
                case Keys.D8:
                    {
                        if(shift)
                        {
                            shift = false;
                            ButtonUmn_Click(null, null);return;
                        }
                        Eight_Click(sender, e);
                    }
                    break;
                case Keys.D9:
                    {
                        if (shift)
                        {
                            shift = false;
                            LScob_Click(null, null); return;
                        }
                        Nine_Click(sender, e);
                    }
                    break;
                default:
                    break;
            }
            shift = false;
            ctrl = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Події натискання на кнопки які знаходяться на формі
        private void Nine_Click(object sender, EventArgs e)
        {
            CheckAdd("9");
        }
        private void Eight_Click(object sender, EventArgs e)
        {
            CheckAdd("8");
        }
        private void Seven_Click(object sender, EventArgs e)
        {
            CheckAdd("7");
        }
        private void Six_Click(object sender, EventArgs e)
        {
            CheckAdd("6");
        }
        private void Five_Click(object sender, EventArgs e)
        {
            CheckAdd("5");
        }
        private void Four_Click(object sender, EventArgs e)
        {
            CheckAdd("4");
        }
        private void Three_Click(object sender, EventArgs e)
        {
            CheckAdd("3");
        }
        private void Two_Click(object sender, EventArgs e)
        {
            CheckAdd("2");
        }
        private void One_Click(object sender, EventArgs e)
        {
            CheckAdd("1");
        }
        private void Zero_Click(object sender, EventArgs e)
        {
            buttonChecker = true;
            CheckAdd("0");
        }
        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            Action(sender, e, '+');
        }
        private void ButtonMines_Click(object sender, EventArgs e)
        {
            Action(sender, e, '-');
        }
        private void ButtonUmn_Click(object sender, EventArgs e)
        {
            Action(sender, e, '*');
        }
        private void ButtonDiv_Click(object sender, EventArgs e)
        {
            Action(sender, e, '/');
        }

        string buffer = ""; //Тимчасовий буфер для нашого рівняння
        bool start = true; //Визначаємо чи ми тільки почали користуватися нашою програмою
        string tempor = ""; // Використав для того щоб можливо було змінювати знак коли число незмінено так як у віндоус калькуляторі

        //Метод який контролює який знак ми вибираємо +-*/
        private bool IsPMDI(string b)
        {
            if (b.Length > 0)
                if ((b[b.Length - 2] == '-' || b[b.Length - 2] == '+' || b[b.Length - 2] == '*' || b[b.Length - 2] == '/' || b[b.Length - 2] == '^'))
                {
                    return true;
                }
            return false;
        }
        private bool ContBB()
        {
            if (countrb - countlb >=1)
            {
                countrb--;
                
                return false;
            }
            return true;
        }
        private void CheckRight(string n)
        {
            if (labelResult.Text.Length >= 2)
                if (labelResult.Text[labelResult.Text.Length - 1] == ',')
                {
                    labelResult.Text = labelResult.Text.Replace(",", "");
                }
        }
        private void Action(object sender, EventArgs e, char action)
        {
            CheckRight(labelResult.Text);
            if(labelResult.Text[0]=='-')
            {
                labelResult.Text = $"( {labelResult.Text} ) ";
            }
            if (start)
            {
                if (buffer == "")
                {
                    if(action==')')
                    {
                        countrb++;
                        if(!ContBB())
                        {
                            return;
                        }
                    }
                    if(action=='(')
                    {
                        countlb++;
                        buffer += "( ";
                        labelUnderResult.Text = buffer;
                        buttonChecker = false;
                        start = false;
                        return;
                    }
                    tempor = labelResult.Text;
                    buffer = labelResult.Text + $" {action} ";
                    labelUnderResult.Text = buffer;
                    buttonChecker = false;
                    start = false;
                    return;
                }
                else
                {
                    buffer = buffer + $" {action} ";
                    labelUnderResult.Text = buffer;
                    buttonChecker = false;
                    start = false;
                    return;
                }
            }
            else if (buttonChecker)
            {
               
                if (action == '(' && buffer[buffer.Length - 2] == ')' || buffer[buffer.Length - 2] == 'e' || buffer[buffer.Length - 2] == 'π')
                {
                    countlb++;
                    buffer += $"* ( ";
                    labelUnderResult.Text = buffer;
                    
                }
                buffer += $"{labelResult.Text} ";
                if (!IsPMDI(buffer) && action == '(')
                {
                    countlb++;
                    buffer += $"* ( ";
                    labelUnderResult.Text = buffer;
                    buttonChecker = false;
                    return;
                }
                else if (action == ')')
                {
                    countrb++;
                    if (!ContBB())
                    {
                        SystemSounds.Beep.Play();
                        return;
                    }
                    buffer += $") ";
                    labelUnderResult.Text = buffer;
                    buttonChecker = false;
                    return;
                }
                else
                {
                    buffer += $"{action} ";
                    labelUnderResult.Text = buffer;
                    buttonChecker = false;
                    return;
                }

            }
            if (!IsPMDI(buffer))
            {
                if (buffer[buffer.Length - 2] == '(')
                { return; }
                if(action=='(' && buffer[buffer.Length - 2]==')' || buffer[buffer.Length - 2] == 'e' || buffer[buffer.Length - 2] == 'π')
                {
                    countlb++;
                    buffer += $"* ( ";
                    labelUnderResult.Text = buffer;
                    return;
                }
                if(action==')')
                {
                    countrb++;
                    if (!ContBB())
                    {
                        SystemSounds.Beep.Play();
                        return;
                    }
                    if (IsPMDI(buffer))
                    {
                        buffer=buffer.Remove(buffer.Length - 2, 2);
                        buffer += $" ) ";
                        labelUnderResult.Text = buffer;
                        return;
                    }
                }
                if (buffer[buffer.Length - 2]==';')
                {
                    return;
                }
                buffer += $"{action} ";
                labelUnderResult.Text = buffer;
                return;
            }
           
            if (buffer[buffer.Length - 2] != action)
            {
                if (action == ')')
                {
                    countrb++;
                    if (!ContBB())
                    {
                        SystemSounds.Beep.Play();
                        return;
                    }
                    if (IsPMDI(buffer))
                    {
                        buffer=buffer.Remove(buffer.Length - 2, 2);
                        buffer += $" ) ";
                        labelUnderResult.Text = buffer;
                        return;
                    }

                }
                if (action == '(')
                {
                    countlb++;
                    if (IsPMDI(buffer))
                    {
                        buffer += "( ";
                        labelUnderResult.Text = buffer;
                        return;
                    }
                    else
                    {
                        buffer += "* ( ";
                        labelUnderResult.Text = buffer;
                        return;
                    }
                }
                buffer = buffer.Remove(buffer.Length - 2);
                buffer = buffer.Insert(buffer.Length, new string($"{action} ".ToCharArray()));
                labelUnderResult.Text = buffer;
                return;
            }

            

        }
        private void Action(object sender, EventArgs e, string eq)
        {
            CheckRight(labelResult.Text);
            if (buffer != "")
            {
               
                if (buffer[buffer.Length - 2] == ')')
                {
                    buffer += $"* {eq}";
                    labelUnderResult.Text = buffer;
                }
                else if (IsPMDI(buffer) || buffer[buffer.Length - 2] == '(')
                {
                    buffer += eq;
                    labelUnderResult.Text = buffer;
                }
            }
            else
            {
                buffer += eq;
                labelUnderResult.Text = buffer;
                start = false;
                first = true;
            }
        }
        private void ButtonSQRT_Click(object sender, EventArgs e)
        {
            string eq = $"sqrt({labelResult.Text}) ";
            Action(sender, e, eq);
        }
        private void ButtonPlusMines_Click(object sender, EventArgs e)
        {
            if (labelResult.Text == "0") return;
            if (labelResult.Text[0] != '-')
            {
                labelResult.Text = labelResult.Text.Insert(0, "-");
            }
            else
            {
                labelResult.Text = labelResult.Text.Remove(0, 1);
            }
        }
        private void ButtonC_Click(object sender, EventArgs e)
        {
            countlb = 0;
            countrb = 0;
            start = true;
            buffer = "";
            labelUnderResult.Text = "";
            labelResult.Text = "0";
            first = true;
        }
        private void ButtonCE_Click(object sender, EventArgs e)
        {
            labelResult.Text = "0";
            first = true;
        }
        private void BackSpace_Click(object sender, EventArgs e)
        {

            buttonChecker = true;
            if (labelResult.Text.Length == 1)
            {

                labelResult.Text = "0";
                first = true;
                return;
            }
            labelResult.Text = labelResult.Text.Remove(labelResult.Text.Length - 1, 1);
        }
        private void Inv_Click(object sender, EventArgs e)
        {
            if (!invbtnpressed)
            {
                Int.Text = "Frac";
                sin.Text = "sin^-1";
                cos.Text = "cos^-1";
                tan.Text = "tan^-1";
                sinh.Text = "sinh^-1";
                tanh.Text = "tanh^-1";
                cosh.Text = "cosh^-1";
                sin.Font = new Font(sin.Font.Name, 8f);
                cos.Font = new Font(cos.Font.Name, 8f);
                tan.Font = new Font(tan.Font.Name, 8f);
                tanh.Font = new Font(tanh.Font.Name, 8f);
                cosh.Font = new Font(cosh.Font.Name, 8f);
                sinh.Font = new Font(sinh.Font.Name, 8f);
                invbtnpressed = true;
            }
            else
            {
                Int.Text = "Int";
                sin.Text = "sin";
                cos.Text = "cos";
                tan.Text = "tan";
                sinh.Text = "sinh";
                tanh.Text = "tanh";
                cosh.Text = "cosh";
                sin.Font = new Font(sin.Font.Name, 12f);
                cos.Font = new Font(cos.Font.Name, 12f);
                tan.Font = new Font(tan.Font.Name, 12f);
                sinh.Font = new Font(sinh.Font.Name, 12f);
                tanh.Font = new Font(tanh.Font.Name, 12f);
                cosh.Font = new Font(cosh.Font.Name, 12f);
                invbtnpressed = false;
            }
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цю програму виконав ПІБ", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Button bt)
            {
                if (!blue)
                    bt.BackColor = Color.OrangeRed;
                else bt.BackColor = Color.Indigo;


            }
        }
        private new void MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button bt)
            {
                if (!blue)
                    bt.BackColor = Color.Gold;
                else bt.BackColor = Color.CornflowerBlue;



            }
        }
        private void MouseLaveYellow(object sender, EventArgs e)
        {
            if (sender is Button bt)
            {
                if (!blue)
                    bt.BackColor = Color.Yellow;
                else
                    bt.BackColor = Color.LightSteelBlue;
            }


        }
        private void MouseLeaveOrange(object sender, EventArgs e)
        {
            if (sender is Button bt)
            {
                if(!blue)
                
                    bt.BackColor = Color.Orange;

                else bt.BackColor = Color.RoyalBlue;



            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            string str;
            if (double.TryParse(Clipboard.GetText(), out double ndr))
            {
                str = "WBoof:" + Clipboard.GetText() + "     CalcBoof:" + Mbuffer;
            }
            else
            {
                str = "WBoof: 0 " + "     CalcBoof:" + Mbuffer;
            }
            if (usual)
                listBox1.Font = new Font("Consolas", 8f);
            else
                listBox1.Font = new Font("Consolas", 12f);
            if (labelResult.Text == "Не число" || labelResult.Text.Contains("e"))
            {
                first = true;
                return;
            }
            if (IsPMDI(buffer))
            {
                buffer += labelResult.Text;
            }
            while (countrb != countlb)
            {
                if (buffer[buffer.Length - 2] == '(')
                {
                    countrb++;
                    buffer += "0 )";
                    
                }
                else
                {
                    buffer += ")";
                    countrb++;
                   
                }
            }
            labelUnderResult.Text = buffer;
            string restlb = labelUnderResult.Text + " = ";
            double result=0;
            if (buffer!="")
            {
                if(radioButton1.Checked)
                {
                    result = Calculate.Parse(labelUnderResult.Text,"degres");
                }
                if(radioButton2.Checked)
                {
                    result = Calculate.Parse(labelUnderResult.Text, "radians");
                }
                if(radioButton3.Checked)
                {
                    result = Calculate.Parse(labelUnderResult.Text, "grades");
                }
                

            }
            else
            {
                result = Double.Parse(labelResult.Text);
            }
            
            if (Double.IsInfinity(result))
            {
                countrb = 0;
                countlb = 0;
                buffer = "";
                labelResult.Text = "Не число";
                restlb += labelResult.Text; 
                first = true;
                start = true;
                listBox1.Items.Add(restlb);
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count-1;
               
                return;
            }
            decimal r;
            if (Fe)
            {
                buffer = result.ToString();
               
                r = (decimal)result;
                labelResult.Text = r.ToString("E04");
                labelUnderResult.Text = "";
                first = true;
                start = true;

                restlb += labelResult.Text;
                listBox1.Items.Add(restlb);
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
            else
            {
                buffer = result.ToString();
                //buffer = buffer.Replace(",", ".");
                if (decimal.TryParse(result.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out decimal d))
                {

                    buffer = "";
                    labelResult.Text = d.ToString();
                    labelUnderResult.Text = buffer;
                    first = true;
                    start = true;

                    restlb += labelResult.Text;
                    listBox1.Items.Add(restlb);
                    listBox1.Items.Add(str);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    buffer = "";
                    labelResult.Text = result.ToString();
                    labelUnderResult.Text = buffer;
                    first = true;
                    start = true;

                    restlb += labelResult.Text;
                    listBox1.Items.Add(restlb);
                    listBox1.Items.Add(str);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }
            
            //string res = "";
            //int pos = temp.IndexOf(',');
            //temp = temp.Replace(",", "");
            //if (temp.Contains("-") && pos != -1)
            //{
            //    res += '-';
            //    temp = temp.Replace("-", "");
            //    int counter = 0;
            //    char t = temp[0];
            //    while (t == '0')
            //    {
            //        counter++;
            //    }
            //    res = temp.Substring(counter, temp.Length - counter);
            //    res += $",{temp.Substring(2, temp.Length - 2)}e + {pos - 1}";
            //    labelResult.Text = res;

            //    buffer = result.ToString();
            //    labelUnderResult.Text = "";
            //    first = true;
            //    start = true;
            //}
            //else 
            //{
            //    res = temp.Substring(0, 1);
            //    res += $",{temp.Substring(1, temp.Length - 1)}e + {pos - 1}";
            //    labelResult.Text = res;

            //    buffer = result.ToString();
            //    labelUnderResult.Text = "";
            //    first = true;
            //    start = true;
            //}
            //else
            //{
            //    res = temp.Substring(0, 1);
            //    res += $",{temp.Substring(1, temp.Length - 1)}e + 0";
            //    labelResult.Text = res;

            //    buffer = result.ToString();
            //    labelUnderResult.Text = "";
            //    first = true;
            //    start = true;
            //}


            //else
            //{
            //    buffer ="";
            //    labelResult.Text = temp;

            //    labelUnderResult.Text = buffer;
            //    first = true;
            //    start = true;


            //}

            //restlb += labelResult.Text; 


            //listBox1.Items.Add(restlb);
            //listBox1.Items.Add(str);
            //listBox1.SelectedIndex = listBox1.Items.Count - 1;


        }

        private void ButtonPProc_Click(object sender, EventArgs e)
        {
            CheckRight(labelResult.Text);
            countlb++;
            string eq = $"mod({labelResult.Text} ; ";
            Action(sender, e, eq);
        }

        private void LScob_Click(object sender, EventArgs e)
        {
            if (labelUnderResult.Text.Length == 0)
            {
                countlb++;
                labelUnderResult.Text = "( ";
                buffer = labelUnderResult.Text;
                buttonChecker = false;
                start = false;
            }
            else if (labelUnderResult.Text.Length > 0)
            {
                if (labelUnderResult.Text[labelUnderResult.Text.Length - 2] != '(')
                {
                    Action(sender, e, '(');
                }
            }
        }

        private void RScob_Click(object sender, EventArgs e)
        {
            if (labelUnderResult.Text.Length > 0)
            {
                Action(sender, e, ')');
            }
        }

        private void ButtonDivineX_Click(object sender, EventArgs e)
        {

        }

        private void Log_Click(object sender, EventArgs e)
        {
            string eq = $"log({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void Factor_Click(object sender, EventArgs e)
        {
            string eq = $"fact({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void XSqrt3_Click(object sender, EventArgs e)
        {
            string eq = $"cuberoot({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void TenINx_Click(object sender, EventArgs e)
        {
            string eq = $"powten({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void Square_Click(object sender, EventArgs e)
        {
            string eq = $"npowtwo({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void XinY_Click(object sender, EventArgs e)
        {
            CheckRight(labelResult.Text);
            countlb++;
            string eq = $"ypowx({labelResult.Text} ; ";
            Action(sender, e, eq);
        }

        private void Qube_Click(object sender, EventArgs e)
        {
            string eq = $"powthree({labelResult.Text}) ";
            Action(sender, e, eq);
        }

        private void YSqrtx_Click(object sender, EventArgs e)
        {
            CheckRight(labelResult.Text);
            countlb++;
            string eq = $"yrootx({labelResult.Text} ; ";
            Action(sender, e, eq);
        }

        private void Ln_Click(object sender, EventArgs e)
        {

            string eq = $"ln({labelResult.Text}) ";
            Action(sender, e, eq);


        }

        private void Coma_Click(object sender, EventArgs e)
        {
           
            if (!labelResult.Text.Contains(","))
            {
                labelResult.Text += ",";
                first = false;
                buttonChecker = true;
            }
            else
            {
                labelResult.Text = labelResult.Text.Substring(0, labelResult.Text.LastIndexOf(','));
                
            }
        }

        private void Int_Click(object sender, EventArgs e)
        {
            buttonChecker = true;
            if (labelResult.Text == "0") return;



            if (Int.Text == "Int")
            {
                if (labelResult.Text.Contains(","))
                {
                    labelResult.Text = labelResult.Text.Substring(0, labelResult.Text.LastIndexOf(','));
                }
            }
            else
            {
                if (labelResult.Text.Contains(","))
                {

                    labelResult.Text = labelResult.Text.Substring(labelResult.Text.LastIndexOf(','), labelResult.Text.Length - labelResult.Text.LastIndexOf(','));
                    labelResult.Text = labelResult.Text.Insert(0, "0");
                }
            }

        }
        private void Sin_Click(object sender, EventArgs e)
        {

            if (sin.Text == "sin")
            {
                string eq = $"sin({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {
                string eq = $"rsin({labelResult.Text}) ";
                Action(sender, e, eq);
            }
        }

        private void Cos_Click(object sender, EventArgs e)
        {

            if (cos.Text == "cos")
            {
                string eq = $"cos({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {
                string eq = $"rcos({labelResult.Text}) ";
                Action(sender, e, eq);
            }
        }

        private void Tan_Click(object sender, EventArgs e)
        {

            if (tan.Text == "tan")
            {
                string eq = $"tan({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {

                string eq = $"rtan({labelResult.Text}) ";
                Action(sender, e, eq);

            }
        }

        private void ButtonPI_Click(object sender, EventArgs e)
        {
            buttonChecker = false;
            
            CheckAdd(Math.PI.ToString());
           
            //string eq = $"π ";
            //Action(sender, e, eq);
        }

        private void Sinh_Click(object sender, EventArgs e)
        {
            buttonChecker = true;
            if (sinh.Text == "sinh")
            {
                string eq = $"sih({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {
                string eq = $"rsih({labelResult.Text}) ";
                Action(sender, e, eq);
            }
        }

        private void Cosh_Click(object sender, EventArgs e)
        {

            if (cosh.Text == "cosh")
            {
                string eq = $"coh({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {
                string eq = $"rcoh({labelResult.Text}) ";
                Action(sender, e, eq);
            }
        }

        private void Tanh_Click(object sender, EventArgs e)
        {

            if (tanh.Text == "tanh")
            {
                string eq = $"tah({labelResult.Text}) ";
                Action(sender, e, eq);
            }
            else
            {
                string eq = $"rtah({labelResult.Text}) ";
                Action(sender, e, eq);
            }
        }

        private void Dms_Click(object sender, EventArgs e)
        {
            buttonChecker = false;
            
            CheckAdd(Math.E.ToString());
            
            //Action(sender, e, "e ");
        }

        private void Mod_Click(object sender, EventArgs e)
        {
            CheckRight(labelResult.Text);
            countlb++;
            string eq = $"mod({labelResult.Text} ; ";
            Action(sender, e, eq);
        }

        private void Exp_Click(object sender, EventArgs e)
        {
            string eq = $"(e ^ {labelResult.Text} ) ";
            Action(sender, e, eq);
        }

        private void FE_Click(object sender, EventArgs e)
        {
            
            if (!Fe)
            {
                Fe = true;
                FE.BackColor = Color.Cyan;
                FE.MouseLeave -= new System.EventHandler(this.MouseLeave);
                FE.MouseMove -= new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            }
            else
            {
                Fe = false;
                FE.BackColor = Color.Gold;
               
                FE.MouseLeave += new System.EventHandler(this.MouseLeave);
                FE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            }
        }

        private void MS_Click(object sender, EventArgs e)
        {
            Mbuffer = labelResult.Text;
        }

        private void MC_Click(object sender, EventArgs e)
        {
            Mbuffer = "0";
        }

        private void MR_Click(object sender, EventArgs e)
        {
            labelResult.Text = Mbuffer;
        }

        private void MPlus_Click(object sender, EventArgs e)
        {

            Mbuffer = (Double.Parse(Mbuffer) + Double.Parse(labelResult.Text)).ToString();
        }

        private void MMines_Click(object sender, EventArgs e)
        {
            Mbuffer = (Double.Parse(Mbuffer) - Double.Parse(labelResult.Text)).ToString();
        }

        private void ІнженернийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (інженернийToolStripMenuItem.Checked == false)
            {
                usual = false;
                Width +=  357;
                REsultGBX.Width += 357;
                ResultPanel.Width += 357;
                groupBox3.Width += 357;
                listBox1.Width += 357;
                button1.Location = new Point(Location.X + 357, Location.Y);
                button2.Location = new Point(Location.X + 357, Location.Y);
                звичайниToolStripMenuItem.Checked = false;
               інженернийToolStripMenuItem.Checked = true;
            }
            else
            {
                return;
            }
        }

        private void ЗвичайниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (звичайниToolStripMenuItem.Checked == false)
            {
                usual = true;
                Width = Width - 357;
                REsultGBX.Width -= 357;
                ResultPanel.Width -= 357;
                groupBox3.Width -= 357;
                listBox1.Width -= 357;
                button1.Location = new Point(button1.Location.X - 357, button1.Location.Y);
                button2.Location = new Point(button2.Location.X - 357, button2.Location.Y);
                звичайниToolStripMenuItem.Checked = true;
                інженернийToolStripMenuItem.Checked = false;
            }
            else
            {
                return;
            }
        }

        private void ВидноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!видноToolStripMenuItem.Checked )
            {
                видноToolStripMenuItem.Checked = true;
                невидноToolStripMenuItem.Checked = false;

                //Location = new Point(Location.X , Location.Y-100);
                
                Height = 705;
            }
            else return;
        }

        private void НевидноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!невидноToolStripMenuItem.Checked )
            {
                видноToolStripMenuItem.Checked = false;
                //Location = new Point(Location.X, Location.Y + 100);
                Height = 500;
                невидноToolStripMenuItem.Checked = true;
            }
            else return;
        }

        private void ЖовтоЧорнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!жовтоЧорнаToolStripMenuItem.Checked)
            {
               
                blue = false;
                ResultPanel.BackColor = Color.LemonChiffon;
                listBox1.BackColor = Color.LemonChiffon;
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                MC.BackColor =   Color.Orange;
                MR.BackColor = Color.Orange;
                MS.BackColor = Color.Orange;
                MPlus.BackColor = Color.Orange;
                MMines.BackColor = Color.Orange;
                buttonPProc.BackColor = Color.Orange;
                button1.BackColor = Color.Orange;
                button2.BackColor = Color.Orange;
                TenINx.BackColor = Color.Gold;
                XSqrt3.BackColor = Color.Gold;
                YSqrtx.BackColor = Color.Gold;
                Factor.BackColor = Color.Gold;
                RScob.BackColor = Color.Gold;
                log.BackColor = Color.Gold;
                Qube.BackColor = Color.Gold;
                XinY.BackColor = Color.Gold;
                Square.BackColor = Color.Gold;
                LScob.BackColor = Color.Gold;
                Mod.BackColor = Color.Gold;
                tan.BackColor = Color.Gold;
                cos.BackColor = Color.Gold;
                sin.BackColor = Color.Gold;
                ln.BackColor = Color.Gold;
                Exp.BackColor = Color.Gold;
                tanh.BackColor = Color.Gold;
                cosh.BackColor = Color.Gold;
                sinh.BackColor = Color.Gold;
                BackSpace.BackColor = Color.Gold;
                buttonCE.BackColor = Color.Gold;
                buttonC.BackColor = Color.Gold;
                buttonPlusMines.BackColor = Color.Gold;
                buttonSQRT.BackColor = Color.Gold;
                buttonDiv.BackColor = Color.Gold;
                buttonUmn.BackColor = Color.Gold;
                buttonMines.BackColor = Color.Gold;
                buttonPlus.BackColor = Color.Gold;
                buttonDivineX.BackColor = Color.Gold;
                Equal.BackColor = Color.Gold;
                Int.BackColor = Color.Gold;
                dms.BackColor = Color.Gold;
                buttonPI.BackColor = Color.Gold;
                FE.BackColor = Color.Gold;
                Inv.BackColor = Color.Gold;
                Eight.BackColor = Color.Yellow;
                Nine.BackColor = Color.Yellow;
                Five.BackColor = Color.Yellow;
                Six.BackColor = Color.Yellow;
                Two.BackColor = Color.Yellow;
                Seven.BackColor = Color.Yellow;
                Four.BackColor = Color.Yellow;
                One.BackColor = Color.Yellow;
                Zero.BackColor = Color.Yellow;
                Coma.BackColor = Color.Yellow;
                Three.BackColor = Color.Yellow;
                radioButton1.ForeColor = Color.DarkOrange;
                radioButton2.ForeColor = Color.DarkOrange;
                radioButton3.ForeColor = Color.DarkOrange;
                if (Fe)
                {
                    FE.BackColor = Color.Cyan;
                }

                жовтоЧорнаToolStripMenuItem.Checked = true;
                блакитнобілаToolStripMenuItem.Checked = false;

            }
            else return;
        }

        private void БлакитнобілаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!блакитнобілаToolStripMenuItem.Checked)
            {
                blue = true;
                ResultPanel.BackColor = Color.PaleTurquoise;
                listBox1.BackColor = Color.PaleTurquoise;
                BackColor = Color.Navy;
                groupBox1.BackColor = Color.Navy;
                groupBox3.BackColor = Color.Navy;

                MC.BackColor = Color.RoyalBlue;
                MR.BackColor = Color.RoyalBlue;
                MS.BackColor = Color.RoyalBlue;
                MPlus.BackColor = Color.RoyalBlue;
                MMines.BackColor = Color.RoyalBlue;
                buttonPProc.BackColor = Color.RoyalBlue;
                button1.BackColor = Color.RoyalBlue;
                button2.BackColor = Color.RoyalBlue;
                TenINx.BackColor = Color.CornflowerBlue;
                XSqrt3.BackColor = Color.CornflowerBlue;
                YSqrtx.BackColor = Color.CornflowerBlue;
                Factor.BackColor = Color.CornflowerBlue;
                RScob.BackColor = Color.CornflowerBlue;
                log.BackColor = Color.CornflowerBlue;
                Qube.BackColor = Color.CornflowerBlue;
                XinY.BackColor = Color.CornflowerBlue;
                Square.BackColor = Color.CornflowerBlue;
                LScob.BackColor = Color.CornflowerBlue;
                Mod.BackColor = Color.CornflowerBlue;
                tan.BackColor = Color.CornflowerBlue;
                cos.BackColor = Color.CornflowerBlue;
                sin.BackColor = Color.CornflowerBlue;
                ln.BackColor = Color.CornflowerBlue;
                Exp.BackColor = Color.CornflowerBlue;
                tanh.BackColor = Color.CornflowerBlue;
                cosh.BackColor = Color.CornflowerBlue;
                sinh.BackColor = Color.CornflowerBlue;
                BackSpace.BackColor = Color.CornflowerBlue;
                buttonCE.BackColor = Color.CornflowerBlue;
                buttonC.BackColor = Color.CornflowerBlue;
                buttonPlusMines.BackColor = Color.CornflowerBlue;
                buttonSQRT.BackColor = Color.CornflowerBlue;
                buttonDiv.BackColor = Color.CornflowerBlue;
                buttonUmn.BackColor = Color.CornflowerBlue;
                buttonMines.BackColor = Color.CornflowerBlue;
                buttonPlus.BackColor = Color.CornflowerBlue;
                buttonDivineX.BackColor = Color.CornflowerBlue;
                Equal.BackColor = Color.CornflowerBlue;
                Int.BackColor = Color.CornflowerBlue;
                dms.BackColor = Color.CornflowerBlue;
                buttonPI.BackColor = Color.CornflowerBlue;
                FE.BackColor = Color.CornflowerBlue;
                Inv.BackColor = Color.CornflowerBlue;

                Eight   .BackColor = Color.LightSteelBlue;
                Nine    .BackColor = Color.LightSteelBlue;
                Five    .BackColor = Color.LightSteelBlue;
                Six     .BackColor = Color.LightSteelBlue;
                Two     .BackColor = Color.LightSteelBlue;
                Seven   .BackColor = Color.LightSteelBlue;
                Four    .BackColor = Color.LightSteelBlue;
                One     .BackColor = Color.LightSteelBlue;
                Zero    .BackColor = Color.LightSteelBlue;
                Coma    .BackColor = Color.LightSteelBlue;
                Three.BackColor = Color.LightSteelBlue;

                radioButton1.ForeColor = Color.LightSteelBlue;
                radioButton2.ForeColor = Color.LightSteelBlue;
                radioButton3.ForeColor = Color.LightSteelBlue;
                if (Fe)
                {
                    FE.BackColor = Color.Cyan;
                }

                жовтоЧорнаToolStripMenuItem.Checked = false;
                блакитнобілаToolStripMenuItem.Checked = true;
            }
            else return;
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            //if (Location.Y < 0)
            //{
            //    Location = new Point(Location.X, 0);
            //}
            
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                if (listBox1.SelectedIndex -1 >= 0)
                {
                    listBox1.SelectedIndex -= 1;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count!=0)
            {
                if(listBox1.SelectedIndex+1<= listBox1.Items.Count-1)
                {
                    listBox1.SelectedIndex += 1;
                }
            }
        }
    }
}




