﻿using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DevLab.JmesPath.Expressions
{
    public class JmesPathAndExpression : JmesPathCompoundExpression
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="JmesPathAndExpression"/> class
        /// with two <see cref="JmesPathAndExpression"/> objects.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public JmesPathAndExpression(JmesPathExpression left, JmesPathExpression right)
            : base(left, right)
        {
        }

        protected override JmesPathArgument Transform(JToken json)
        {
            var token = Left.Transform(json);
            return (!JmesPathArgument.IsFalse(token)) ? Right.Transform(json) : token;
        }
        
        protected override async Task<JmesPathArgument> TransformAsync(JToken json)
        {
            var token = await Left.TransformAsync(json);
            return (!JmesPathArgument.IsFalse(token)) ? await Right.TransformAsync(json) : token;
        }

        public override string ToString()
            => $"{Left} && {Right}";
    }
}