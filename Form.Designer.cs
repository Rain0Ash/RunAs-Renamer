using System;
using System.Drawing;
using System.Windows.Forms;
using RunAsRenamer.Properties;

namespace RunAsRenamer
{
    partial class Form
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
            const Int32 SizeFormX = 350;
            const Int32 SizeFormY = 120;
            const Int32 SizeTextBoxX = 140;
            const Int32 SizeTextBoxY = 20;
            const Int32 SizeLabelX = 35;
            const Int32 FirstLineTextBoxX = 5;
            const Int32 FirstLineTextBoxY = 25;
            const Int32 SecondLineTextBoxX = FirstLineTextBoxX + SizeTextBoxX + SizeLabelX;
            const Int32 SecondLineTextBoxY = FirstLineTextBoxY + SizeTextBoxY + 5;
            this.applyButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.runAsSystemCheckBox = new System.Windows.Forms.CheckBox();
            this.runAsAdministratorLabel = new System.Windows.Forms.Label();
            this.runAsAdministratorIconLabel = new System.Windows.Forms.Label();
            this.runAsSystemIconLabel = new System.Windows.Forms.Label();
            this.runAsAdministratorNameLabel = new System.Windows.Forms.Label();
            this.runAsSystemNameLabel = new System.Windows.Forms.Label();
            this.runAsAdministratorNameTextBox = new System.Windows.Forms.TextBox();
            this.runAsSystemNameTextBox = new System.Windows.Forms.TextBox();
            this.runAsAdministratorIconTextBox = new System.Windows.Forms.TextBox();
            this.runAsSystemIconTextBox = new System.Windows.Forms.TextBox();
            this.runAsAdministratorFileDialogButton = new FileDialogButton(ref runAsAdministratorIconTextBox);
            this.runAsSystemFileDialogButton = new FileDialogButton(ref runAsSystemIconTextBox);
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(FirstLineTextBoxX, 90);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(SizeFormX - 2*FirstLineTextBoxX - 25, 25);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += OnApplyButton_Click;            
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(FirstLineTextBoxX + SizeFormX - 2*FirstLineTextBoxX - 25, 90);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(25, 25);
            this.resetButton.TabIndex = 0;
            this.resetButton.Text = "↺";
            this.resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += OnResetButton_Click;
            // 
            // runAsSystemCheckBox
            // 
            this.runAsSystemCheckBox.AutoSize = true;
            this.runAsSystemCheckBox.Location = new System.Drawing.Point(SecondLineTextBoxX, FirstLineTextBoxY - 20);
            this.runAsSystemCheckBox.Name = "runAsSystemCheckBox";
            this.runAsSystemCheckBox.Size = new System.Drawing.Size(80, SizeTextBoxY);
            this.runAsSystemCheckBox.TabIndex = 1;
            this.runAsSystemCheckBox.Text = "RunAs System";
            this.runAsSystemCheckBox.UseVisualStyleBackColor = true;
            this.runAsSystemCheckBox.CheckedChanged += OnRunAsSystemCheckBox_CheckChange;
            // 
            // runAsAdministatorLabel
            // 
            this.runAsAdministratorLabel.AutoSize = true;
            this.runAsAdministratorLabel.Location = new System.Drawing.Point(FirstLineTextBoxX, FirstLineTextBoxY - 20);
            this.runAsAdministratorLabel.Name = "runAsAdministratorLabel";
            this.runAsAdministratorLabel.Size = new System.Drawing.Size(SizeLabelX, SizeTextBoxY);
            this.runAsAdministratorLabel.TabIndex = 2;
            this.runAsAdministratorLabel.Text = "RunAs Administator";
            // 
            // runAsAdministatorNameLabel
            // 
            this.runAsAdministratorNameLabel.AutoSize = true;
            this.runAsAdministratorNameLabel.Location = new System.Drawing.Point(FirstLineTextBoxX + SizeTextBoxX, FirstLineTextBoxY);
            this.runAsAdministratorNameLabel.Name = "runAsAdministratorNameLabel";
            this.runAsAdministratorNameLabel.Size = new System.Drawing.Size(SizeLabelX, SizeTextBoxY);
            this.runAsAdministratorNameLabel.TabIndex = 2;
            this.runAsAdministratorNameLabel.Text = "Text";
            // 
            // runAsAdministatorIconLabel
            // 
            this.runAsAdministratorIconLabel.AutoSize = true;
            this.runAsAdministratorIconLabel.Location = new System.Drawing.Point(FirstLineTextBoxX + SizeTextBoxX, SecondLineTextBoxY);
            this.runAsAdministratorIconLabel.Name = "runAsAdministratorIconLabel";
            this.runAsAdministratorIconLabel.Size = new System.Drawing.Size(SizeLabelX, SizeTextBoxY);
            this.runAsAdministratorIconLabel.TabIndex = 2;
            this.runAsAdministratorIconLabel.Text = "Icon";
            // 
            // runAsAdministatorNameTextBox
            // 
            this.runAsAdministratorNameTextBox.Location = new System.Drawing.Point(FirstLineTextBoxX, FirstLineTextBoxY);
            this.runAsAdministratorNameTextBox.Name = "runAsAdministratorNameTextBox";
            this.runAsAdministratorNameTextBox.Size = new System.Drawing.Size(SizeTextBoxX, SizeTextBoxY);
            this.runAsAdministratorNameTextBox.TabIndex = 4;
            // 
            // runAsSystemNameLabel
            // 
            this.runAsSystemNameLabel.AutoSize = true;
            this.runAsSystemNameLabel.Location = new System.Drawing.Point(SecondLineTextBoxX + SizeTextBoxX, FirstLineTextBoxY);
            this.runAsSystemNameLabel.Name = "runAsSystemNameLabel";
            this.runAsSystemNameLabel.Size = new System.Drawing.Size(SizeLabelX, SizeTextBoxY);
            this.runAsSystemNameLabel.TabIndex = 2;
            this.runAsSystemNameLabel.Text = "Text";
            // 
            // runAsSystemIconLabel
            // 
            this.runAsSystemIconLabel.AutoSize = true;
            this.runAsSystemIconLabel.Location = new System.Drawing.Point(SecondLineTextBoxX + SizeTextBoxX, SecondLineTextBoxY);
            this.runAsSystemIconLabel.Name = "runAsSystemIconLabel";
            this.runAsSystemIconLabel.Size = new System.Drawing.Size(SizeLabelX, SizeTextBoxY);
            this.runAsSystemIconLabel.TabIndex = 2;
            this.runAsSystemIconLabel.Text = "Icon";
            // 
            // runAsSystemNameTextBox
            // 
            this.runAsSystemNameTextBox.Location = new System.Drawing.Point(SecondLineTextBoxX, FirstLineTextBoxY);
            this.runAsSystemNameTextBox.Name = "runAsSystemNameTextBox";
            this.runAsSystemNameTextBox.Size = new System.Drawing.Size(SizeTextBoxX, SizeTextBoxY);
            this.runAsSystemNameTextBox.TabIndex = 5;
            runAsSystemNameTextBox.Enabled = false;
            // 
            // runAsAdministatorIconTextBox
            // 
            this.runAsAdministratorIconTextBox.Location = new System.Drawing.Point(FirstLineTextBoxX, SecondLineTextBoxY);
            this.runAsAdministratorIconTextBox.Name = "runAsAdministratorIconTextBox";
            this.runAsAdministratorIconTextBox.Size = new System.Drawing.Size(SizeTextBoxX - SizeTextBoxY - 5, SizeTextBoxY);
            this.runAsAdministratorIconTextBox.TabIndex = 6;
            runAsAdministratorIconTextBox.TextChanged += CheckFileExists;
            // 
            // runAsSystemIconTextBox
            // 
            this.runAsSystemIconTextBox.Location = new System.Drawing.Point(SecondLineTextBoxX, SecondLineTextBoxY);
            this.runAsSystemIconTextBox.Name = "runAsSystemIconTextBox";
            this.runAsSystemIconTextBox.Size = new System.Drawing.Size(SizeTextBoxX - SizeTextBoxY - 5, SizeTextBoxY);
            this.runAsSystemIconTextBox.TabIndex = 7;
            runAsSystemIconTextBox.Enabled = false;
            runAsSystemIconTextBox.TextChanged += CheckFileExists;
            //
            // runAsAdministratorFileDialogButton
            //
            runAsAdministratorFileDialogButton.Location = new Point(FirstLineTextBoxX + SizeTextBoxX - SizeTextBoxY - 5, SecondLineTextBoxY);
            runAsAdministratorFileDialogButton.Name = "runAsAdministratorFileDialogButton";
            runAsAdministratorFileDialogButton.Size = new Size(SizeTextBoxY + 5, SizeTextBoxY);            
            //
            // runAsSystemFileDialogButton
            //
            runAsSystemFileDialogButton.Location = new Point(SecondLineTextBoxX + SizeTextBoxX - SizeTextBoxY - 5, SecondLineTextBoxY);
            runAsSystemFileDialogButton.Name = "runAsSystemFileDialogButton";
            runAsSystemFileDialogButton.Size = new Size(SizeTextBoxY + 5, SizeTextBoxY);
            runAsSystemFileDialogButton.Enabled = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(SizeFormX, SizeFormY);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.runAsSystemIconTextBox);
            this.Controls.Add(this.runAsAdministratorIconTextBox);
            this.Controls.Add(this.runAsAdministratorIconLabel);
            this.Controls.Add(this.runAsAdministratorNameLabel);
            this.Controls.Add(this.runAsSystemIconLabel);
            this.Controls.Add(this.runAsSystemNameLabel);
            this.Controls.Add(this.runAsSystemNameTextBox);
            this.Controls.Add(this.runAsAdministratorNameTextBox);
            this.Controls.Add(this.runAsAdministratorLabel);
            this.Controls.Add(this.runAsSystemCheckBox);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(runAsAdministratorFileDialogButton);
            this.Controls.Add(runAsSystemFileDialogButton);
            this.Name = "Form";
            this.Text = "RunAs Renamer";
            this.Icon = Resources.uac_icon;
            this.Load += OnForm_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.CheckBox runAsSystemCheckBox;
        private System.Windows.Forms.Label runAsAdministratorLabel;
        private System.Windows.Forms.Label runAsAdministratorIconLabel;
        private System.Windows.Forms.Label runAsSystemIconLabel;
        private System.Windows.Forms.Label runAsAdministratorNameLabel;
        private System.Windows.Forms.Label runAsSystemNameLabel;
        private System.Windows.Forms.TextBox runAsAdministratorNameTextBox;
        private System.Windows.Forms.TextBox runAsSystemNameTextBox;
        private System.Windows.Forms.TextBox runAsAdministratorIconTextBox;
        private System.Windows.Forms.TextBox runAsSystemIconTextBox;
        private FileDialogButton runAsAdministratorFileDialogButton;
        private FileDialogButton runAsSystemFileDialogButton;
    }
}