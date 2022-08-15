using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPandMASK
{
    class IP
    {
        public int[] oktets = new int[4];
        public IP()
        {
            for (int i = 0; i < 4; i++)
            {
                oktets[i] = 0;
            }
        }
        public IP(int a, int b, int c, int d)
        {
            AsignIP(0, a);
            AsignIP(1, b);
            AsignIP(2, c);
            AsignIP(3, d);
        }
        protected bool IsCorrect(int _number)
        {
            bool result = false;
            result = (_number >= 0) && (_number <= 255);
            return result;
        }
        private void AsignIP(int _index, int _number)
        {
            if (IsCorrect(_number))
            {
                oktets[_index] = _number;
            }
            else
            {
                oktets[_index] = 0;
            }
        }
        public string ToSTR()
        {
            string result = "";
            for (int i = 0; i < 4; i++)
            {
                if (i < 3)
                {
                    result = result + oktets[i] + ".";
                }
                else
                {
                    result = result + oktets[i];
                }
            }
            return result;
        }
    }
    class ipADDR : IP
    {
        public ipADDR() : base()
        {
        }
        public ipADDR(int a, int b, int c, int d) : base(a, b, c, d)
        {
        }
        public void Input()
        {
            Console.WriteLine("Введите IP адрес (пооктетно)\n");
            for (int i = 0; i <= 3; i++)
            {
                this.oktets[i] = AsignOktet(i);
                if (!IsCorrect(this.oktets[i]))
                {
                    this.oktets[i] = 0;
                }
            }

        }
        private int AsignOktet(int _index)
        {
            bool _correct = false;
            var oktet = 0;
            do
            {
                try
                {
                    oktet = int.Parse(Console.ReadLine());
                    _correct = true;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }

            } while (!_correct);
            return oktet;
        }
    }
    class ipMASK : IP
    {
        public ipMASK() : base()
        {
        }
        public ipMASK(int a, int b, int c, int d) : base(a, b, c, d)
        {
        }
        public void Input()
        {
            Console.WriteLine("Введите маску (пооктетно)\n");
            for (int i = 0; i <= 3; i++)
            {
                this.oktets[i] = AsignOktet(i);
                if (!IsCorrect(this.oktets[i]))
                {
                    this.oktets[i] = 0;
                }
            }
        }
        private int AsignOktet(int _index)
        {
            bool _correct = false;
            var oktet = 0;
            do
            {
                try
                {
                    oktet = int.Parse(Console.ReadLine());
                    if (IsRight(oktet))
                    {
                        _correct = true;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }

            } while (!_correct);
            return oktet;
        }
        public bool IsRight(int _oktetOfMask)
        {
            int[] values = new[] { 255, 254, 252, 248, 240, 224, 192, 128, 0 };
            bool result = false;
            foreach (var item in values)
            {
                if (item == _oktetOfMask)
                {
                    return true;
                }
            }
            return result;
        }
        public bool IsRealMask()
        {
            bool result = false;
            int _index = 0, _counter = 0;
            do
            {
                if (this.oktets[_index] == 255)
                {
                    for (int i = _index + 1; i < 4; i++)
                    {
                        if (this.oktets[i] != 0)
                        {
                            _counter++;
                        }
                    }
                    if (_counter == 0)
                    {
                        return false;
                    }
                }
                _index++;
            } while (!result);
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var _ip = new IP(192, 168, 400, 1);
            Console.WriteLine(_ip.ToSTR());
            var _ip2 = new ipADDR();
            Console.WriteLine(_ip2.ToSTR());
            var _ip3 = new ipADDR();
            _ip3.Input();
            Console.WriteLine(_ip3.ToSTR());
            var _mask = new ipMASK();
            _mask.Input();
            Console.WriteLine(_mask.ToSTR());
        }
    }
}
