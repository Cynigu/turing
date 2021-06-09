// Сделано Тюлькиной Ириной
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public struct qCommand 
    {
        public string that;
        public string on;
        public string step;
        public int nextQ;

        public qCommand(string t,string a1, string step1, int c1)
        {
            that = t; // что нашли 
            on = a1; // на что меняем
            step = step1; // какое действие происходит
            nextQ = c1; // какая следующая комманда
        }
    }
    public struct qFullCommand
    {
        public List<qCommand> qCommandForA { get; set; }
        public qFullCommand(List<qCommand> c1)
        {
            qCommandForA = c1;
        }
    }

    // Для алфавита только 01_
    public class TuringEmulator
    {
        public List<qFullCommand> Q;
        public List<string> Str { get; set; }

        // конструктор только для алфовита 01_
        public TuringEmulator(List<string> str)
        {
            Str = str;
            Q = new List<qFullCommand>();
        }

        // Выполнение комманды С для символа that с индексом index в сроке Str
        private int UseCommand(int c, ref int index)
        {
            int nextCommand = 0;
            string that = Str[index];
            bool r = false;
            for (int i =0; i<Q[c].qCommandForA.Count;i++) // Выбор нужной комманды
            {
                if (Q[c].qCommandForA[i].that == that) // Условие для выбора в комманде подкамманды для изменения определенного символа
                {
                    r = true;
                    Str[index] = Q[c].qCommandForA[i].on; // Заменяем символ с данным индексом на тот что дан в подкоманде
                    nextCommand = Q[c].qCommandForA[i].nextQ; // Запоминаем следующую выполняемую комманду
                    if (Q[c].qCommandForA[i].step == ">") // Выбираем в какую сторону сдвигаться (сдвигаемя вправо)
                    {
                        index++; // Увеличтваем индекс на 1
                        return nextCommand;
                    }
                    else if (Q[c].qCommandForA[i].step == "<") // Сдвигаемся  влево 
                    {
                        index--; // уменьшаем индекс на 1
                        return nextCommand;
                    }
                    else if (Q[c].qCommandForA[i].step == ".") return nextCommand;
                }
                //else throw new ArgumentException();
            }
            if (!r)
            {
                throw new Exception("Нет комманды в ячейке Q" + c + " " + that);
            }
            return nextCommand;
        }

        // Запуск программы 
        public void RunProgramm()
        {
            int tCommand = 0;
            int index = 0;
            
            while (tCommand != -1)
            {
                if (Str.Count <= index) // имитиуем бесконечную ленту 
                {
                    Str.Add("_");
                    tCommand = UseCommand(tCommand, ref index);
                }
                else if (index < 0) // Все еще имитируем бесконечную ленту
                {
                    index++;
                    Str.Insert(0, "_");
                    tCommand = UseCommand(tCommand, ref index);
                }
                else // Если в пределах строки
                {
                    tCommand = UseCommand(tCommand, ref index);
                }

                PrintToConsoleStr();
            }
        }
        public void PrintToConsoleStr()
        {
            for (int i = 0; i < Str.Count; i++)
            {
                Console.Write(Str[i]);
            }
            Console.WriteLine();
        }

    }
}
