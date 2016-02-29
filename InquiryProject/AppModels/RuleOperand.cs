using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class RuleOperand
    {
        int _id;
        int _fid_rule;
        int _fid_operand;
        string _operand_type;

        public RuleOperand()
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

        public int fid_rule
        {
            get
            {
                return _fid_rule;
            }
            set
            {
                _fid_rule = value;
            }
        }

        public int fid_operand
        {
            get
            {
                return _fid_operand;
            }
            set
            {
                _fid_operand = value;
            }
        }

        public string operand_type
        {
            get
            {
                return _operand_type;
            }
            set
            {
                _operand_type = value;
            }
        }
    }
}
