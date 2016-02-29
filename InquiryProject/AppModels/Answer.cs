using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Answer
    {
        int _id;
        string _var_text;
        int _fid_question;

        public Answer(Question qu)
        {
            _parent_question = qu;
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

        public string var_text
        {
            get
            {
                return _var_text;
            }
            set
            {
                _var_text = value;
            }
        }

        public int fid_question
        {
            get
            {
                return _fid_question;
            }
            set
            {
                _fid_question = value;
            }
        }
    }
}
