<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        Button1 = New Button()
        TextBox1 = New TextBox()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        GroupBox1 = New GroupBox()
        RadioButton1 = New RadioButton()
        RadioButton2 = New RadioButton()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = True
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.Location = New Point(12, 134)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(1176, 577)
        WebView21.TabIndex = 0
        WebView21.ZoomFactor = 1R
        ' 
        ' Button1
        ' 
        Button1.Font = New Font("Goudy Stout", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.Location = New Point(73, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(59, 48)
        Button1.TabIndex = 1
        Button1.Text = "→ "
        Button1.TextAlign = ContentAlignment.TopCenter
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(197, 8)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(868, 43)
        TextBox1.TabIndex = 2
        ' 
        ' Button2
        ' 
        Button2.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.Green
        Button2.Location = New Point(134, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(59, 48)
        Button2.TabIndex = 3
        Button2.Text = "🔄"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Font = New Font("Goudy Stout", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.Gray
        Button3.Location = New Point(12, 5)
        Button3.Name = "Button3"
        Button3.Size = New Size(59, 48)
        Button3.TabIndex = 4
        Button3.Text = "←"
        Button3.TextAlign = ContentAlignment.TopCenter
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = SystemColors.ActiveCaption
        Button4.Location = New Point(1068, 6)
        Button4.Name = "Button4"
        Button4.Size = New Size(59, 48)
        Button4.TabIndex = 5
        Button4.Text = "🔍"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button5
        ' 
        Button5.Font = New Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = Color.Red
        Button5.Location = New Point(1129, 5)
        Button5.Name = "Button5"
        Button5.Size = New Size(59, 48)
        Button5.TabIndex = 6
        Button5.Text = "❌"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(RadioButton2)
        GroupBox1.Controls.Add(RadioButton1)
        GroupBox1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.ForeColor = SystemColors.ActiveCaption
        GroupBox1.Location = New Point(12, 59)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(290, 69)
        GroupBox1.TabIndex = 7
        GroupBox1.TabStop = False
        GroupBox1.Text = "Preference"
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RadioButton1.ForeColor = Color.Green
        RadioButton1.Location = New Point(24, 29)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(96, 27)
        RadioButton1.TabIndex = 0
        RadioButton1.TabStop = True
        RadioButton1.Text = "Security"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RadioButton2.ForeColor = Color.Red
        RadioButton2.Location = New Point(167, 29)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(117, 27)
        RadioButton2.TabIndex = 8
        RadioButton2.TabStop = True
        RadioButton2.Text = "Experience"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1257, 725)
        Controls.Add(GroupBox1)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(TextBox1)
        Controls.Add(Button1)
        Controls.Add(WebView21)
        FormBorderStyle = FormBorderStyle.None
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton

End Class
