using System;

namespace SourcedSharp.Core.Solution
{
    public class Solution
    {
        public SolutionContext SolutionContext;
        public Solution()
        {
            SolutionContext = new SolutionContext();
        }
        public Solution AddContext<TContext>()
        {
            var context = Activator.CreateInstance(typeof(TContext), SolutionContext);
            return this;
        }
    }
}