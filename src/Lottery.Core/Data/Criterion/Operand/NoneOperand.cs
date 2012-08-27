using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Data
{
    public class NoneOperand : Operand
    {
        public NoneOperand()
        {
        }

        protected override string ToExpression()
        {
            return string.Empty;
        }
    }
}
