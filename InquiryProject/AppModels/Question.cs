using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Question
    {
        int _id;
        string _que_text;
        int _fid_inquiry;
        int _sort_order;
        string _answer_type;

        public Question(Inquire _inquiry)
        {
			_parent_inquiry = _inquiry;
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

        public int sort_order
        {
            get
            {
                return _sort_order;
            }
            set
            {
                _sort_order = value;
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
