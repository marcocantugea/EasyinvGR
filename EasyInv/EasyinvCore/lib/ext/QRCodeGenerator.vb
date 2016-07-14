Imports MessagingToolkit.QRCode.Codec
Imports MessagingToolkit.QRCode.Codec.Data
Imports System.Drawing
Imports System.Drawing.Imaging

Namespace ext
    Public Class QRCodeGenerator

        Public Function GenerateQRCode(ByVal text As String, ByVal filepath As String) As String
            Dim encoder As New QRCodeEncoder
            Dim bitmap As Bitmap = encoder.Encode(text)
            Dim filename As String = filepath & "\qrcode.jpg"
            bitmap.Save(filename, ImageFormat.Jpeg)
            Return "img/qrcode.jpg"
        End Function


    End Class
End Namespace