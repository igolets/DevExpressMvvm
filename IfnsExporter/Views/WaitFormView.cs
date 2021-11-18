using DevExpress.XtraWaitForm;
using System;
using JetBrains.Annotations;

namespace Cso.IfnsExporter
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public partial class WaitFormView : WaitForm
    {
        public WaitFormView()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.progressPanel1.Description = description;
        }

        // ReSharper disable once RedundantOverriddenMember
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}