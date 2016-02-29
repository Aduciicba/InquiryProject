using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Rule:BaseOperand
    {
        List<BaseOperand> _operands;
        bool? _result;

        public void addOperand(BaseOperand operand)
        {
            if (_operands == null)
                _operands = new List<BaseOperand>();

            _operands.Add(operand);
        }

        public override bool Evaluate()
        {
            if (_result.HasValue)
                return _result.Value;

            foreach (var operand in _operands)
            {
                if (!_result.HasValue)
                    _result = operand.Evaluate();
                else
                {
                    if (logical_operation == "and")
                        _result = _result.Value && operand.Evaluate();
                    else
                        _result = _result.Value || operand.Evaluate();
                }
            }
            return _result ?? false;
        }

    }
}
