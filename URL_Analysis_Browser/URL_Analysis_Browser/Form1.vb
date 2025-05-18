Imports Microsoft.Web.WebView2.Core
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebView21.Source = New Uri("https://www.google.com/")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If Not String.IsNullOrEmpty(TextBox1.Text) Then

            Dim input = TextBox1.Text.Trim
            Dim user_pref As String
            If RadioButton1.Checked Then
                user_pref = (RadioButton1.Text).ToLower
            ElseIf RadioButton2.Checked Then
                user_pref = (RadioButton2.Text).ToLower
            Else
                user_pref = (RadioButton1.Text).ToLower
            End If

            If input.StartsWith("http://") Or input.StartsWith("https://") Or input.Contains(".") Then
                ' Evaluate the security of the entered URL
                Dim result As String = EvaluateUrlSecurity(input, user_pref) ' security mode, threshold = 0.5
                Select Case result
                    Case "ALLOW_NAVIGATION"
                        WebView21.Source = New Uri(input)

                    Case "ALLOW_NAVIGATION_WITH_FLAG"
                        ' Maybe add some warning label before navigating
                        WebView21.Source = New Uri(input)

                    Case "BLOCK_AND_LOG", "CANCEL_NAVIGATION"
                        display_warning()
                        TextBox1.Focus()

                        'Case "INVALID_URL"
                        'Dim html As String = "<html><body><h2 style='color:orange;text-align:center;margin-top:50px;'>Invalid URL format. Please check your typing.</h2></body></html>"
                        'WebView21.NavigateToString(html)

                End Select
                ' It looks like a URL, navigate directly
                'WebView21.Source = New Uri(input)
            Else
                ' It's a search term, search it using Google
                Dim searchUrl = "https://www.google.com/search?q=" & Uri.EscapeDataString(input)
                WebView21.Source = New Uri(searchUrl)
            End If

        Else
            all_message("URL address cannot be empty", "Missing URL address")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If WebView21.CanGoBack Then
            WebView21.GoBack()
        End If
    End Sub
    Sub all_message(msg As String, tl As String)
        MsgBox(msg, vbOK, tl)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If WebView21.CanGoForward Then
            WebView21.GoForward()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebView21.Reload()
    End Sub

    Sub display_warning()
        ' Display a simple HTML message
        Dim html As String = "
<html>
<head>
    <style>
        body {
            background-color: #fff8f0;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding-top: 100px;
        }
        .warning-box {
            background-color: #ffe0e0;
            border: 2px solid #ff4d4d;
            border-radius: 10px;
            padding: 30px;
            max-width: 600px;
            text-align: center;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        h2 {
            color: #cc0000;
            margin-bottom: 10px;
        }
        p {
            color: #333;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <div class='warning-box'>
        <h2>⚠️ Suspicious Link Warning!</h2>
        <p>The link you are trying to access contains suspicious elements.<br>
        For your safety, please type the URL manually in the address bar.</p>
    </div>
</body>
</html>"
        WebView21.NavigateToString(html)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        End
    End Sub

    Public Function EvaluateUrlSecurity(ByVal url As String, ByVal userPref As String) As String
        ' --- Trusted Top-Level Domains ---
        Dim threshold As Double = 0.4
        MsgBox(url)
        Dim trustedTLDs As List(Of String) = New List(Of String) From {".gov", ".mil", ".edu", ".bank", ".gov.rw"}

        ' --- URL Parsing ---
        Dim uri As Uri
        uri = New Uri(url)


        Dim domain As String = uri.Host

        Dim tld As String = System.IO.Path.GetExtension(domain).ToLower()
        Dim protocol As String = uri.Scheme.ToLower()

        ' --- Risk Analysis ---
        Dim domainRisk As Boolean = CheckMixedScripts(domain) Or CheckHomoglyphs(domain) Or CheckPunycode(domain)
        Dim tldRisk As Boolean = Not trustedTLDs.Contains(tld)
        Dim protocolRisk As Boolean = (protocol = "http") AndAlso (domainRisk Or tldRisk)

        ' Combine risk score
        Dim riskScore As Double = CombineScores(domainRisk, tldRisk, protocolRisk)
        MsgBox(riskScore)
        ' --- Decision Phase ---
        If riskScore > threshold Then
            If userPref.ToLower() = "security" Then
                Dim displayedUrl As String = DecodePunycode(domain)
                Return "BLOCK_AND_LOG"

            Else ' experience-focused
                If ConfirmOverrideWarning() Then
                    Return "ALLOW_NAVIGATION_WITH_FLAG"
                Else
                    Return "CANCEL_NAVIGATION"
                End If
            End If
        Else
            Return "ALLOW_NAVIGATION"
        End If

    End Function
    ' Check if the domain has mixed Unicode scripts
    Private Function CheckMixedScripts(domain As String) As Boolean
        ' Simple version: check if domain contains non-ASCII characters
        For Each ch As Char In domain
            If AscW(ch) > 127 Then Return True
        Next
        Return False
    End Function

    ' Check for common homoglyphs
    Private Function CheckHomoglyphs(domain As String) As Boolean
        ' Basic check for rn = m, vv = w, 0 = o, etc.
        Dim suspiciousPatterns As String() = {"rn", "vv", "0", "1", "l"}
        For Each pattern As String In suspiciousPatterns
            If domain.Contains(pattern) Then Return True
        Next
        Return False
    End Function

    ' Check if Punycode is used (xn-- prefix)
    Private Function CheckPunycode(domain As String) As Boolean
        Return domain.ToLower().Contains("xn--")
    End Function

    ' Combine domain, tld, protocol risks into a score
    Private Function CombineScores(domainRisk As Boolean, tldRisk As Boolean, protocolRisk As Boolean) As Double
        Dim score As Double = 0
        If domainRisk Then score += 0.5
        If tldRisk Then score += 0.3
        If protocolRisk Then score += 0.2
        Return Math.Min(score, 1.0) ' Max score is 1
    End Function

    ' Simulate decoding punycode (for simplicity, return domain itself)
    Private Function DecodePunycode(domain As String) As String
        ' For real case, use a punycode decoder library
        Return domain
    End Function

    ' Simulate a warning confirmation
    Private Function ConfirmOverrideWarning() As Boolean
        ' For demo, assume user clicks "Yes" on a MessageBox
        Dim result As DialogResult = MessageBox.Show("This link looks suspicious. Proceed anyway?", "⚠️ Suspicious Link Warning!", MessageBoxButtons.YesNo)
        Return result = DialogResult.Yes
    End Function

End Class
