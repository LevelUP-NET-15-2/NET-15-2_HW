using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160305_UserListDemo
{
    public class MyList
    {
        // Элемент списка
        private class MyElem
        {
            public int Info    // Информационная часть
            {
                get;
                set;
            }

            public MyElem Next    // Ссылка на следующий элемент в списке
            {
                get;
                set;
            }
        }

        // Добавление в конец списка
        public void AddToEnd(int val)
        {
            MyElem newElem = new MyElem() { Info = val, Next = null };    // новый элемент списка

            if (_first == null)
            {
                _first = newElem;    // новый элемент становится 1-м в списке
            }
            else
            {
                MyElem currElem = _first;

                // проходии до последнего элемента
                while (currElem.Next != null)
                {
                    currElem = currElem.Next;    // переход к следующему элементу в списке
                }

                currElem.Next = newElem;    // новый элемент стновится последним в списке
            }
        }

        public void AddToBegin(int val)
        {
            MyElem newElem = new MyElem() { Info = val, Next = _first };    // новый элемент списка

            _first = newElem;
        }

        // Проверка списка на пустоту
        public bool IsEmpty()
        {
            return _first == null;
        }

        // Проверка на существование элемента в списке
        public bool IsExist(int info)
        {
            MyElem currElem = _first;

            while (currElem != null)
            {
                if (currElem.Info == info)    // элемент в списке найден
                {
                    return true;
                }

                currElem = currElem.Next;    // переход к следующему элементу в списке
            }

            return false;    // Элемент не найден
        }

        public int GetFirst()
        {
            if (_first==null)
            {
                throw new Exception("Список пуст");
            }

            int retVal = _first.Info;

            _first = _first.Next;

            return retVal;
        }


        public int GetLast()
        {
            if (_first == null)
            {
                throw new Exception("Список пуст");
            }

            if (_first.Next == null)   // Список состоит из одного элемента
	        {
		        int retVal = _first.Info;

                _first = null;

                return retVal;
	        }

            MyElem currElem = _first;

            // Находим предпоследний элемент
            while (currElem.Next.Next != null)
            {
                currElem = currElem.Next;
            }

            int retVal1 = currElem.Next.Info;

            currElem.Next = null;  // предпоследний элемент становится последним

            return retVal1;
        }

        /// <summary>
        /// Метод, возвращающий элемент по заданному индексу
        /// </summary>
        /// <param name="val">Индекс элемента</param>
        /// <returns>Значение элемента</returns>
        public int GetElemByPos(int val)
        {
            if (_first == null)
            {
                throw new Exception("Список пуст");
            }
            else
            {
                MyElem currElem = _first;

                int i = 0;

                // проходим до последнего элемента
                while (currElem.Next != null)
                {
                    currElem = currElem.Next;
                    ++i;

                    if (i == val)
                    {
                        return currElem.Info;
                    }
                }
            }

            throw new Exception("Список не содержит элемента с указанным индексом!");
        }

        /// <summary>
        /// Индексатор, основанный на базе GetElemByPos
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Значение элемента</returns>
        public int this[int index]
        {
            get
            {
                return GetElemByPos(index);
            }
        }

        /// <summary>
        /// Свойство, возвращающее длину списка
        /// </summary>
        /// <returns>Длина списка</returns>
        public int Length()
        {
            if (_first == null)
            {
                return 0;
            }
            else
            {
                MyElem currElem = _first;

                int i = 1;

                // проходии до последнего элемента
                while (currElem.Next != null)
                {
                    i++;
                    currElem = currElem.Next;
                }

                return i;
            }
        }

        /// <summary>
        /// Нахождение количества вхождений указанного элемента
        /// </summary>
        /// <param name="elem">Искомый элемент</param>
        /// <returns>Количество вхождений искомого элемента</returns>
        public int GetAmountOfElems(int elem)
        {
            if (_first == null)
            {
                throw new Exception("Список пуст!");
            }
            else
            {
                MyElem currElem = _first;

                int i = 0;

                // проходии до последнего элемента
                while (currElem.Next != null)
                {
                    if (currElem.Info == elem)
                    {
                        ++i;
                    }

                    currElem = currElem.Next;
                }

                return i;
            }
        }

        public void DelElem(int elem)
        {
            if (_first == null)
            {
                throw new Exception("Список пуст!");
            }
            else
            {
                MyElem currElem = _first;

                //if (currElem.Next == null && elem == 0)
                //{
                //    currElem = null;
                //}

                int i = 0;

                // проходии до предпоследнего элемента
                while (currElem.Next != null)
                {
                    MyElem temp = null;

                    temp = currElem;

                    if (i == elem)
                    {
                        currElem.Next = currElem.Next.Next;
                        i++;
                    }
                    else
                    {
                        currElem = currElem.Next;
                        i++;
                    }

                }
            }
        }

        // HW:

        // 1. GetElemByPos - Нахождение элемента по позиции   +
        // 2. Реализовать индексатор на основе GetElemByPos   +
        // 3. Length - свойство, возвращающее длину списка    +
        // 4. Нахождение количества вхождений указанного элемента   +
        // 5. Удаление элемента, находящегося на указанной позиции   +-
        // 6. Удаление указанного элемента (по значению)   ?

        // 7. Добавить класс для пользовательских исключений MyListException + продумать и предусмотреть различные варианты его использования   -

        // 8. Добавить в класс работу с событиями (элемент добавлен, элемен удалён и т.д.)   -

        //  *** 9. Boxing/unboxing (int Info  ---> object Info)   -

        private MyElem _first = null;    // изначально список пуст
    }
}
