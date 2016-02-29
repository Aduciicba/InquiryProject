using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    //Правило
    public partial class Rule
    {
        int _id;                    //ИД
        string _logical_operation;  //Тип логической операции между операндами парвила: "and" или "or"
        int _fid_inquiry;           //Ссылка на анкету

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
    }
}
