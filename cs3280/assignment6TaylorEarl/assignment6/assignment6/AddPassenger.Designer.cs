namespace assignment6
{
    partial class AddPassenger
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.reservationSystemDataSet = new assignment6.ReservationSystemDataSet();
            this.flightBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flightTableAdapter = new assignment6.ReservationSystemDataSetTableAdapters.FlightTableAdapter();
            this.tableAdapterManager = new assignment6.ReservationSystemDataSetTableAdapters.TableAdapterManager();
            this.flight_Passenger_LinkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flight_Passenger_LinkTableAdapter = new assignment6.ReservationSystemDataSetTableAdapters.Flight_Passenger_LinkTableAdapter();
            this.passengerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.passengerTableAdapter = new assignment6.ReservationSystemDataSetTableAdapters.PassengerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reservationSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flight_Passenger_LinkBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passengerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 56);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name:";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(23, 93);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(104, 93);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // reservationSystemDataSet
            // 
            this.reservationSystemDataSet.DataSetName = "ReservationSystemDataSet";
            this.reservationSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flightBindingSource
            // 
            this.flightBindingSource.DataMember = "Flight";
            this.flightBindingSource.DataSource = this.reservationSystemDataSet;
            // 
            // flightTableAdapter
            // 
            this.flightTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Flight_Passenger_LinkTableAdapter = this.flight_Passenger_LinkTableAdapter;
            this.tableAdapterManager.FlightTableAdapter = this.flightTableAdapter;
            this.tableAdapterManager.PassengerTableAdapter = this.passengerTableAdapter;
            this.tableAdapterManager.UpdateOrder = assignment6.ReservationSystemDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // flight_Passenger_LinkBindingSource
            // 
            this.flight_Passenger_LinkBindingSource.DataMember = "Flight_Passenger_Link";
            this.flight_Passenger_LinkBindingSource.DataSource = this.reservationSystemDataSet;
            // 
            // flight_Passenger_LinkTableAdapter
            // 
            this.flight_Passenger_LinkTableAdapter.ClearBeforeFill = true;
            // 
            // passengerBindingSource
            // 
            this.passengerBindingSource.DataMember = "Passenger";
            this.passengerBindingSource.DataSource = this.reservationSystemDataSet;
            // 
            // passengerTableAdapter
            // 
            this.passengerTableAdapter.ClearBeforeFill = true;
            // 
            // AddPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 199);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "AddPassenger";
            this.Text = "AddPassenger";
            this.Load += new System.EventHandler(this.AddPassenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservationSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flightBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flight_Passenger_LinkBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passengerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private ReservationSystemDataSet reservationSystemDataSet;
        private System.Windows.Forms.BindingSource flightBindingSource;
        private ReservationSystemDataSetTableAdapters.FlightTableAdapter flightTableAdapter;
        private ReservationSystemDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private ReservationSystemDataSetTableAdapters.Flight_Passenger_LinkTableAdapter flight_Passenger_LinkTableAdapter;
        private System.Windows.Forms.BindingSource flight_Passenger_LinkBindingSource;
        private ReservationSystemDataSetTableAdapters.PassengerTableAdapter passengerTableAdapter;
        private System.Windows.Forms.BindingSource passengerBindingSource;
    }
}