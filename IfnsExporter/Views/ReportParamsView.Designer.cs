
using Cso.IfnsExporter.ViewModels;

namespace Cso.IfnsExporter.Views
{
    partial class ReportParamsView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ceAll = new DevExpress.XtraEditors.CheckEdit();
            this.clbDepartments = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.deDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bsDepartments = new System.Windows.Forms.BindingSource(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ceAll);
            this.layoutControl1.Controls.Add(this.clbDepartments);
            this.layoutControl1.Controls.Add(this.deDateTo);
            this.layoutControl1.Controls.Add(this.deDateFrom);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(281, 0, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(414, 356);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ceAll
            // 
            this.ceAll.Location = new System.Drawing.Point(24, 45);
            this.ceAll.Name = "ceAll";
            this.ceAll.Properties.Caption = "Выбрать все";
            this.ceAll.Size = new System.Drawing.Size(197, 18);
            this.ceAll.StyleController = this.layoutControl1;
            this.ceAll.TabIndex = 7;
            // 
            // clbDepartments
            // 
            this.clbDepartments.CheckMember = "IsChecked";
            this.clbDepartments.CheckOnClick = true;
            this.clbDepartments.DataSource = this.bsDepartments;
            this.clbDepartments.DisplayMember = "Description";
            this.clbDepartments.Location = new System.Drawing.Point(24, 67);
            this.clbDepartments.Name = "clbDepartments";
            this.clbDepartments.Size = new System.Drawing.Size(197, 265);
            this.clbDepartments.StyleController = this.layoutControl1;
            this.clbDepartments.TabIndex = 6;
            this.clbDepartments.ValueMember = "DepartmentId";
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.Location = new System.Drawing.Point(274, 69);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.DisplayFormat.FormatString = "y";
            this.deDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateTo.Properties.EditFormat.FormatString = "y";
            this.deDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateTo.Properties.MaskSettings.Set("mask", "y");
            this.deDateTo.Properties.ShowToday = false;
            this.deDateTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deDateTo.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.deDateTo.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.deDateTo.Size = new System.Drawing.Size(116, 20);
            this.deDateTo.StyleController = this.layoutControl1;
            this.deDateTo.TabIndex = 5;
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.Location = new System.Drawing.Point(274, 45);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDateFrom.Properties.BeepOnError = false;
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.DisplayFormat.FormatString = "y";
            this.deDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateFrom.Properties.EditFormat.FormatString = "y";
            this.deDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDateFrom.Properties.MaskSettings.Set("mask", "y");
            this.deDateFrom.Properties.ShowToday = false;
            this.deDateFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.deDateFrom.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.deDateFrom.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)(((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView) 
            | DevExpress.XtraEditors.VistaCalendarViewStyle.CenturyView)));
            this.deDateFrom.Size = new System.Drawing.Size(116, 20);
            this.deDateFrom.StyleController = this.layoutControl1;
            this.deDateFrom.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(414, 356);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Отделения";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(225, 336);
            this.layoutControlGroup1.Text = "Отделения";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.clbDepartments;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 22);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(201, 269);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.ceAll;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(201, 22);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(225, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(169, 336);
            this.layoutControlGroup2.Text = "Диапазон дат";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(145, 24);
            this.layoutControlItem1.Text = "С";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(13, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(145, 267);
            this.layoutControlItem2.Text = "По";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(13, 13);
            // 
            // bsDepartments
            // 
            this.bsDepartments.DataSource = typeof(Cso.IfnsExporter.Models.SelectDepartmentModel);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(Cso.IfnsExporter.ViewModels.ReportParamsViewModel);
            // 
            // ReportParamsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ReportParamsView";
            this.Size = new System.Drawing.Size(414, 356);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.DateEdit deDateTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.CheckedListBoxControl clbDepartments;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource bsDepartments;
        private DevExpress.XtraEditors.CheckEdit ceAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
