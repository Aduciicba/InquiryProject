using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Answer: BaseOperand
    {
        bool _is_active;            //показывать/не показывать
        bool _is_selected;          //выбран/не выбран    
        Question _parent_question;  //родительский вопрос
        Rule _active_rule;          //правило, определяющее показывать/не показывать

        public bool Active
        {
            get
            {
                if (_active_rule == null)
                {
                    _is_active = true;
                }
                else
                {
                    _is_active = _active_rule.Evaluate();
                }
                return _is_active;
            }
        }

        public Rule active_rule
        {
            get
            {
                return _active_rule;
            }
            set
            {
                _active_rule = value;
            }
        }

        public Question parent_question
        {
            get
            {
                return _parent_question;
            }
            set
            {
                _parent_question = value;
            }
        }

        public bool Selected
        {
            get
            {
                return _is_selected;
            }
            set
            {
                _is_selected = value;
            }
        }

        public override bool Evaluate()
        {
            return Selected;
        }

        public override string ToString()
        {
            return this.var_text;
        }
    }
}
