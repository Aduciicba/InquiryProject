using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Rule
    {
        int _id;
        string _logical_operation;

        public Rule()
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

        public string logical_operation
        {
            get
            {
                return _logical_operation;
            }
            set
            {
                _logical_operation = value;
            }
        }


    }
}
