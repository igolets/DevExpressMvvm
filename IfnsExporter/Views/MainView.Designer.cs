using Cso.IfnsExporter.ViewModels;

namespace Cso.IfnsExporter.Views
{
    partial class MainView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiLoadFromDb = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLoadExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClearData = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveXml = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSettings = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.beiYear = new DevExpress.XtraBars.BarEditItem();
            this.riYear = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.beiPeriod = new DevExpress.XtraBars.BarEditItem();
            this.riPeriod = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.beiReqNumber = new DevExpress.XtraBars.BarEditItem();
            this.riReqNumber = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcMain = new DevExpress.XtraGrid.GridControl();
            this.modelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOperationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNonTaxableAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuyerPatronymicName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riReqNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(Cso.IfnsExporter.ViewModels.MainViewModel);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiLoadExcel,
            this.bbiSaveXml,
            this.bbiSettings,
            this.bbiLoadFromDb,
            this.bbiClearData,
            this.beiYear,
            this.beiPeriod,
            this.beiReqNumber,
            this.bbiSaveExcel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 10;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riYear,
            this.riPeriod,
            this.riReqNumber});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadFromDb),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiLoadExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClearData),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveXml),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveExcel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSettings)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DisableClose = true;
            this.bar2.OptionsBar.DisableCustomization = true;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiLoadFromDb
            // 
            this.bbiLoadFromDb.Caption = "Загрузить из БД";
            this.bbiLoadFromDb.Id = 3;
            this.bbiLoadFromDb.Name = "bbiLoadFromDb";
            // 
            // bbiLoadExcel
            // 
            this.bbiLoadExcel.Caption = "Загрузить из Excel";
            this.bbiLoadExcel.Id = 0;
            this.bbiLoadExcel.Name = "bbiLoadExcel";
            // 
            // bbiClearData
            // 
            this.bbiClearData.Caption = "Очистить";
            this.bbiClearData.Id = 4;
            this.bbiClearData.Name = "bbiClearData";
            // 
            // bbiSaveXml
            // 
            this.bbiSaveXml.Caption = "Сохранить в XML";
            this.bbiSaveXml.Id = 1;
            this.bbiSaveXml.Name = "bbiSaveXml";
            // 
            // bbiSaveExcel
            // 
            this.bbiSaveExcel.Caption = "Сохранить в Excel";
            this.bbiSaveExcel.Id = 9;
            this.bbiSaveExcel.Name = "bbiSaveExcel";
            // 
            // bbiSettings
            // 
            this.bbiSettings.Caption = "Настройки";
            this.bbiSettings.Id = 2;
            this.bbiSettings.Name = "bbiSettings";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 4";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.beiYear, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.beiPeriod, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.beiReqNumber, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Период";
            // 
            // beiYear
            // 
            this.beiYear.Caption = "Год";
            this.beiYear.Edit = this.riYear;
            this.beiYear.EditWidth = 60;
            this.beiYear.Id = 5;
            this.beiYear.Name = "beiYear";
            // 
            // riYear
            // 
            this.riYear.AutoHeight = false;
            this.riYear.BeepOnError = false;
            this.riYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riYear.DisplayFormat.FormatString = "####";
            this.riYear.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riYear.EditFormat.FormatString = "####";
            this.riYear.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riYear.IsFloatValue = false;
            this.riYear.MaskSettings.Set("mask", "0000");
            this.riYear.Name = "riYear";
            // 
            // beiPeriod
            // 
            this.beiPeriod.Caption = "Период";
            this.beiPeriod.Edit = this.riPeriod;
            this.beiPeriod.EditWidth = 150;
            this.beiPeriod.Id = 7;
            this.beiPeriod.Name = "beiPeriod";
            // 
            // riPeriod
            // 
            this.riPeriod.AutoHeight = false;
            this.riPeriod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riPeriod.Name = "riPeriod";
            this.riPeriod.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // beiReqNumber
            // 
            this.beiReqNumber.Caption = "Номер требования";
            this.beiReqNumber.Edit = this.riReqNumber;
            this.beiReqNumber.EditWidth = 60;
            this.beiReqNumber.Id = 8;
            this.beiReqNumber.Name = "beiReqNumber";
            // 
            // riReqNumber
            // 
            this.riReqNumber.AutoHeight = false;
            this.riReqNumber.BeepOnError = false;
            this.riReqNumber.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riReqNumber.DisplayFormat.FormatString = "d";
            this.riReqNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riReqNumber.EditFormat.FormatString = "d";
            this.riReqNumber.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.riReqNumber.IsFloatValue = false;
            this.riReqNumber.MaskSettings.Set("mask", "d");
            this.riReqNumber.MaskSettings.Set("autoHideDecimalSeparator", false);
            this.riReqNumber.MaskSettings.Set("hideInsignificantZeros", false);
            this.riReqNumber.Name = "riReqNumber";
            this.riReqNumber.UseMaskAsDisplayFormat = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(779, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 508);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(779, 19);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 463);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(779, 45);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 463);
            // 
            // gcMain
            // 
            this.gcMain.DataSource = this.modelBindingSource;
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 45);
            this.gcMain.MainView = this.gvMain;
            this.gcMain.MenuManager = this.barManager1;
            this.gcMain.Name = "gcMain";
            this.gcMain.Size = new System.Drawing.Size(779, 463);
            this.gcMain.TabIndex = 4;
            this.gcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMain});
            // 
            // modelBindingSource
            // 
            this.modelBindingSource.DataSource = typeof(Cso.IfnsExporter.Models.DataModel);
            // 
            // gvMain
            // 
            this.gvMain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOperationCode,
            this.colOperationName,
            this.colNonTaxableAmount,
            this.colBuyerLastName,
            this.colBuyerFirstName,
            this.colBuyerPatronymicName,
            this.colDocumentName,
            this.colDocumentNumber,
            this.colOperationDate});
            this.gvMain.GridControl = this.gcMain;
            this.gvMain.Name = "gvMain";
            this.gvMain.OptionsBehavior.Editable = false;
            this.gvMain.OptionsView.ShowFooter = true;
            // 
            // colOperationCode
            // 
            this.colOperationCode.Caption = "Код операции";
            this.colOperationCode.FieldName = "OperationCode";
            this.colOperationCode.Name = "colOperationCode";
            this.colOperationCode.Visible = true;
            this.colOperationCode.VisibleIndex = 0;
            // 
            // colOperationName
            // 
            this.colOperationName.Caption = "Вид операции";
            this.colOperationName.FieldName = "OperationName";
            this.colOperationName.Name = "colOperationName";
            this.colOperationName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "OperationName", "Количество: {0}")});
            this.colOperationName.Visible = true;
            this.colOperationName.VisibleIndex = 1;
            // 
            // colNonTaxableAmount
            // 
            this.colNonTaxableAmount.Caption = "Необлагаемая сумма";
            this.colNonTaxableAmount.FieldName = "NonTaxableAmount";
            this.colNonTaxableAmount.Name = "colNonTaxableAmount";
            this.colNonTaxableAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NonTaxableAmount", "Сумма: {0:C}")});
            this.colNonTaxableAmount.Visible = true;
            this.colNonTaxableAmount.VisibleIndex = 2;
            // 
            // colBuyerLastName
            // 
            this.colBuyerLastName.Caption = "Фамилия";
            this.colBuyerLastName.FieldName = "BuyerLastName";
            this.colBuyerLastName.Name = "colBuyerLastName";
            this.colBuyerLastName.Visible = true;
            this.colBuyerLastName.VisibleIndex = 3;
            // 
            // colBuyerFirstName
            // 
            this.colBuyerFirstName.Caption = "Имя";
            this.colBuyerFirstName.FieldName = "BuyerFirstName";
            this.colBuyerFirstName.Name = "colBuyerFirstName";
            this.colBuyerFirstName.Visible = true;
            this.colBuyerFirstName.VisibleIndex = 4;
            // 
            // colBuyerPatronymicName
            // 
            this.colBuyerPatronymicName.Caption = "Отчество";
            this.colBuyerPatronymicName.FieldName = "BuyerPatronymicName";
            this.colBuyerPatronymicName.Name = "colBuyerPatronymicName";
            this.colBuyerPatronymicName.Visible = true;
            this.colBuyerPatronymicName.VisibleIndex = 5;
            // 
            // colDocumentName
            // 
            this.colDocumentName.Caption = "Тип документа";
            this.colDocumentName.FieldName = "DocumentName";
            this.colDocumentName.Name = "colDocumentName";
            this.colDocumentName.Visible = true;
            this.colDocumentName.VisibleIndex = 6;
            // 
            // colDocumentNumber
            // 
            this.colDocumentNumber.Caption = "№";
            this.colDocumentNumber.FieldName = "DocumentNumber";
            this.colDocumentNumber.Name = "colDocumentNumber";
            this.colDocumentNumber.Visible = true;
            this.colDocumentNumber.VisibleIndex = 7;
            // 
            // colOperationDate
            // 
            this.colOperationDate.Caption = "Дата";
            this.colOperationDate.FieldName = "OperationDate";
            this.colOperationDate.Name = "colOperationDate";
            this.colOperationDate.Visible = true;
            this.colOperationDate.VisibleIndex = 8;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 527);
            this.Controls.Add(this.gcMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainView.IconOptions.Icon")));
            this.Name = "MainView";
            this.Text = "Выгрузка в ИФНС";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riReqNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiLoadExcel;
        private DevExpress.XtraBars.BarButtonItem bbiSaveXml;
        private DevExpress.XtraBars.BarButtonItem bbiSettings;
        private DevExpress.XtraGrid.GridControl gcMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMain;
        private System.Windows.Forms.BindingSource modelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationCode;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationName;
        private DevExpress.XtraGrid.Columns.GridColumn colNonTaxableAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyerLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyerFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colBuyerPatronymicName;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentName;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOperationDate;
        private DevExpress.XtraBars.BarButtonItem bbiLoadFromDb;
        private DevExpress.XtraBars.BarButtonItem bbiClearData;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarEditItem beiYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riYear;
        private DevExpress.XtraBars.BarEditItem beiPeriod;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox riPeriod;
        private DevExpress.XtraBars.BarEditItem beiReqNumber;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit riReqNumber;
        private DevExpress.XtraBars.BarButtonItem bbiSaveExcel;
    }
}

