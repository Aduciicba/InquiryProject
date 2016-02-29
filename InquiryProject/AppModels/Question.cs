using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    //Вопрос
    public partial class Question
    {
        int _id;              //ИД
        string _que_text;     //Текст вопроса 
        int _fid_inquiry;     //Ссфлка на анкету
        string _answer_type;  //Тип ответов в вопросе, "single" - можно выбрать 1 вариант, "multiple" - несколько

        public Question()
        {

        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string que_text
        {
            get
            {
                return _que_text;
            }
            set
            {
                _que_text = value;
            }
        }

        public int fid_inquiry
        {
            get
            {
                return _fid_inquiry;
            }
            set
            {
                _fid_inquiry = value;
            }
        }

        public string answer_type
        {
            get
            {
                return _answer_type;
            }
            set
            {
                _answer_type = value;
            }
        }

    }
}
