using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Rubberduck.Inspections.Abstract;
using Rubberduck.Inspections.QuickFixes;
using Rubberduck.Inspections.Resources;
using Rubberduck.Parsing;
using Rubberduck.Parsing.Inspections.Abstract;

namespace Rubberduck.Inspections.Results
{
    public class ObsoleteLetStatementUsageInspectionResult : InspectionResultBase
    {
        private IEnumerable<QuickFixBase> _quickFixes;

        public ObsoleteLetStatementUsageInspectionResult(IInspection inspection, InspectionResultTarget target, string name)
            : base(inspection, name) { }

        [Obsolete]
        public ObsoleteLetStatementUsageInspectionResult(IInspection inspection, QualifiedContext<ParserRuleContext> qualifiedContext)
            : base(inspection, qualifiedContext.ModuleName, qualifiedContext.Context)
        { }

        public override string Description
        {
            get { return InspectionsUI.ObsoleteLetStatementInspectionResultFormat; }
        }

        public override IEnumerable<IQuickFix> QuickFixes
        {
            get
            {
                return _quickFixes ?? (_quickFixes = new QuickFixBase[]
                {
                    new RemoveExplicitLetStatementQuickFix(Context, QualifiedSelection), 
                    new IgnoreOnceQuickFix(Context, QualifiedSelection, Inspection.AnnotationName)
                });
            }
        }
    }
}
