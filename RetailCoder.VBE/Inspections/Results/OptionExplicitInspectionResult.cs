using System;
using System.Collections.Generic;
using Rubberduck.Inspections.Abstract;
using Rubberduck.Inspections.QuickFixes;
using Rubberduck.Inspections.Resources;
using Rubberduck.Parsing.Inspections.Abstract;
using Rubberduck.Parsing.Symbols;

namespace Rubberduck.Inspections.Results
{
    public class OptionExplicitInspectionResult : InspectionResultBase
    {
        private IEnumerable<QuickFixBase> _quickFixes; 

        public OptionExplicitInspectionResult(IInspection inspection, InspectionResultTarget target)
            : base(inspection) { }

        [Obsolete]
        public OptionExplicitInspectionResult(IInspection inspection, Declaration target)
            : base(inspection, target) { }

        public override IEnumerable<IQuickFix> QuickFixes
        {
            get
            {
                return _quickFixes ?? (_quickFixes = new QuickFixBase[]
                {
                    new OptionExplicitQuickFix(Context, QualifiedSelection)
                });
            }
        }

        public override string Description
        {
            get { return string.Format(InspectionsUI.OptionExplicitInspectionResultFormat, QualifiedName.ComponentName); }
        }
    }
}
