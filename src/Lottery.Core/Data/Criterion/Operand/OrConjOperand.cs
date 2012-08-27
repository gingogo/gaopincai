using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery.Data
{
    public class OrConjOperand : Operand
    {
        public OrConjOperand()
        {
        }

        protected override string ToExpression()
        {
            return " OR ";
        }
    }
}
