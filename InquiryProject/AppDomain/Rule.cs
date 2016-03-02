using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquiryProject
{
    public partial class Rule:BaseOperand
    {
        List<BaseOperand> _operands;  //список операндов, определяющий результат правила
        bool? _result;                // результат правила  

        public void addOperand(BaseOperand operand)
        {
            if (_operands == null)
                _operands = new List<BaseOperand>();

            _operands.Add(operand);
        }

        public override bool Evaluate()
        {
            //если результат правила уже вычислен, то возвращаем его
            if (_result.HasValue)
                return _result.Value;
            //иначе просматриваем каждый операнд
            foreach (var operand in _operands)
            {
                //устанавдиваем начальное значение результата
                if (!_result.HasValue)
                    _result = operand.Evaluate();
                else
                {
                    //выполняем лог. операцию "И"/"ИЛИ" между ранее полученным результатом 
                    // и логическим резульатом очередного операнда
                    if (logical_operation == "and")
                        _result = _result.Value && operand.Evaluate();
                    else
                        _result = _result.Value || operand.Evaluate();
                }
            }
            return _result ?? false;
        }

        /*protected override string GetClass()
        {
            return this.GetType().ToString().Replace("InquiryProject.", "");
        }*/

    }
}
