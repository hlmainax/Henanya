<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSupplier
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DTP1 = New System.Windows.Forms.DateTimePicker()
        Me.CHQ1 = New System.Windows.Forms.CheckBox()
        Me.txtSupName = New System.Windows.Forms.TextBox()
        Me.txtSupID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SupBalance = New System.Windows.Forms.TextBox()
        Me.Remarks = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmdExit = New System.Windows.Forms.Button()
        Me.CmdCancel = New System.Windows.Forms.Button()
        Me.CmdSave = New System.Windows.Forms.Button()
        Me.GRID1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SupMail = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SupOff = New System.Windows.Forms.TextBox()
        Me.SupMobi = New System.Windows.Forms.TextBox()
        Me.SupAdd = New System.Windows.Forms.TextBox()
        Me.SupName = New System.Windows.Forms.TextBox()
        Me.SupCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAdjust = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnAdjust)
        Me.Panel1.Controls.Add(Me.DTP1)
        Me.Panel1.Controls.Add(Me.CHQ1)
        Me.Panel1.Controls.Add(Me.txtSupName)
        Me.Panel1.Controls.Add(Me.txtSupID)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.SupBalance)
        Me.Panel1.Controls.Add(Me.Remarks)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CmdExit)
        Me.Panel1.Controls.Add(Me.CmdCancel)
        Me.Panel1.Controls.Add(Me.CmdSave)
        Me.Panel1.Controls.Add(Me.GRID1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.SupMail)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.SupOff)
        Me.Panel1.Controls.Add(Me.SupMobi)
        Me.Panel1.Controls.Add(Me.SupAdd)
        Me.Panel1.Controls.Add(Me.SupName)
        Me.Panel1.Controls.Add(Me.SupCode)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(16, 15)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1157, 489)
        Me.Panel1.TabIndex = 0
        '
        'DTP1
        '
        Me.DTP1.CustomFormat = "yyyy-MM-dd"
        Me.DTP1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP1.Location = New System.Drawing.Point(153, 395)
        Me.DTP1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DTP1.Name = "DTP1"
        Me.DTP1.Size = New System.Drawing.Size(141, 23)
        Me.DTP1.TabIndex = 107
        Me.DTP1.Value = New Date(2015, 11, 24, 20, 33, 34, 0)
        '
        'CHQ1
        '
        Me.CHQ1.AutoSize = True
        Me.CHQ1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHQ1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHQ1.Location = New System.Drawing.Point(368, 82)
        Me.CHQ1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CHQ1.Name = "CHQ1"
        Me.CHQ1.Size = New System.Drawing.Size(92, 21)
        Me.CHQ1.TabIndex = 24
        Me.CHQ1.Text = "In Active"
        Me.CHQ1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CHQ1.UseVisualStyleBackColor = True
        '
        'txtSupName
        '
        Me.txtSupName.BackColor = System.Drawing.SystemColors.Info
        Me.txtSupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupName.Location = New System.Drawing.Point(704, 80)
        Me.txtSupName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSupName.Name = "txtSupName"
        Me.txtSupName.Size = New System.Drawing.Size(430, 23)
        Me.txtSupName.TabIndex = 23
        '
        'txtSupID
        '
        Me.txtSupID.BackColor = System.Drawing.SystemColors.Info
        Me.txtSupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupID.Location = New System.Drawing.Point(489, 80)
        Me.txtSupID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSupID.Name = "txtSupID"
        Me.txtSupID.Size = New System.Drawing.Size(206, 23)
        Me.txtSupID.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 395)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 17)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Supplier Balance :"
        '
        'SupBalance
        '
        Me.SupBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupBalance.Location = New System.Drawing.Point(300, 395)
        Me.SupBalance.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupBalance.Name = "SupBalance"
        Me.SupBalance.Size = New System.Drawing.Size(178, 23)
        Me.SupBalance.TabIndex = 20
        Me.SupBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Remarks
        '
        Me.Remarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Remarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remarks.Location = New System.Drawing.Point(153, 325)
        Me.Remarks.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Remarks.Multiline = True
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(325, 60)
        Me.Remarks.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 327)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Remarks :"
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(9, 9)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1125, 62)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Suppliers Master Details"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.Location = New System.Drawing.Point(219, 436)
        Me.CmdExit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(96, 36)
        Me.CmdExit.TabIndex = 11
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdCancel
        '
        Me.CmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCancel.Location = New System.Drawing.Point(117, 436)
        Me.CmdCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdCancel.Name = "CmdCancel"
        Me.CmdCancel.Size = New System.Drawing.Size(96, 36)
        Me.CmdCancel.TabIndex = 10
        Me.CmdCancel.Text = "Cancel"
        Me.CmdCancel.UseVisualStyleBackColor = False
        '
        'CmdSave
        '
        Me.CmdSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CmdSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSave.Location = New System.Drawing.Point(18, 436)
        Me.CmdSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CmdSave.Name = "CmdSave"
        Me.CmdSave.Size = New System.Drawing.Size(96, 36)
        Me.CmdSave.TabIndex = 8
        Me.CmdSave.Text = "Save"
        Me.CmdSave.UseVisualStyleBackColor = False
        '
        'GRID1
        '
        Me.GRID1.AllowUserToAddRows = False
        Me.GRID1.AllowUserToDeleteRows = False
        Me.GRID1.AllowUserToResizeColumns = False
        Me.GRID1.AllowUserToResizeRows = False
        Me.GRID1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRID1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GRID1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRID1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.GRID1.Location = New System.Drawing.Point(489, 111)
        Me.GRID1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GRID1.Name = "GRID1"
        Me.GRID1.ReadOnly = True
        Me.GRID1.RowHeadersVisible = False
        Me.GRID1.RowHeadersWidth = 51
        Me.GRID1.Size = New System.Drawing.Size(645, 361)
        Me.GRID1.TabIndex = 13
        Me.GRID1.TabStop = False
        '
        'Column1
        '
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column1.HeaderText = "Suuplier Code"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 155
        '
        'Column2
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column2.HeaderText = "Name"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 310
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 295)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "E-Mail :"
        '
        'SupMail
        '
        Me.SupMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupMail.Location = New System.Drawing.Point(153, 293)
        Me.SupMail.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupMail.Name = "SupMail"
        Me.SupMail.Size = New System.Drawing.Size(325, 23)
        Me.SupMail.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 263)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Contact No :"
        '
        'SupOff
        '
        Me.SupOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupOff.Location = New System.Drawing.Point(153, 261)
        Me.SupOff.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupOff.Name = "SupOff"
        Me.SupOff.Size = New System.Drawing.Size(206, 23)
        Me.SupOff.TabIndex = 5
        '
        'SupMobi
        '
        Me.SupMobi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupMobi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupMobi.Location = New System.Drawing.Point(153, 229)
        Me.SupMobi.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupMobi.Name = "SupMobi"
        Me.SupMobi.Size = New System.Drawing.Size(206, 23)
        Me.SupMobi.TabIndex = 4
        '
        'SupAdd
        '
        Me.SupAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupAdd.Location = New System.Drawing.Point(153, 143)
        Me.SupAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupAdd.Multiline = True
        Me.SupAdd.Name = "SupAdd"
        Me.SupAdd.Size = New System.Drawing.Size(325, 78)
        Me.SupAdd.TabIndex = 3
        '
        'SupName
        '
        Me.SupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupName.Location = New System.Drawing.Point(153, 111)
        Me.SupName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupName.Name = "SupName"
        Me.SupName.Size = New System.Drawing.Size(325, 23)
        Me.SupName.TabIndex = 2
        '
        'SupCode
        '
        Me.SupCode.BackColor = System.Drawing.SystemColors.Info
        Me.SupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupCode.Location = New System.Drawing.Point(153, 80)
        Me.SupCode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SupCode.Name = "SupCode"
        Me.SupCode.Size = New System.Drawing.Size(206, 23)
        Me.SupCode.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 231)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Contact No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 145)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Address :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Supplier Code :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 113)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Supplier Name :"
        '
        'BtnAdjust
        '
        Me.BtnAdjust.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnAdjust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdjust.Location = New System.Drawing.Point(316, 436)
        Me.BtnAdjust.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAdjust.Name = "BtnAdjust"
        Me.BtnAdjust.Size = New System.Drawing.Size(162, 36)
        Me.BtnAdjust.TabIndex = 108
        Me.BtnAdjust.Text = "Make Adjustment"
        Me.BtnAdjust.UseVisualStyleBackColor = False
        '
        'FrmSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1827, 922)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmSupplier"
        Me.Text = "  SUPPLIER MASTER  "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GRID1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SupMail As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SupOff As System.Windows.Forms.TextBox
    Friend WithEvents SupMobi As System.Windows.Forms.TextBox
    Friend WithEvents SupAdd As System.Windows.Forms.TextBox
    Friend WithEvents SupName As System.Windows.Forms.TextBox
    Friend WithEvents SupCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdCancel As System.Windows.Forms.Button
    Friend WithEvents CmdSave As System.Windows.Forms.Button
    Friend WithEvents Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SupBalance As System.Windows.Forms.TextBox
    Friend WithEvents txtSupName As System.Windows.Forms.TextBox
    Friend WithEvents txtSupID As System.Windows.Forms.TextBox
    Friend WithEvents CHQ1 As System.Windows.Forms.CheckBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents DTP1 As DateTimePicker
    Friend WithEvents BtnAdjust As Button
End Class
