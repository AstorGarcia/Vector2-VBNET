Imports System.Net.Sockets

Public Class Form1
    Dim Medicamentos() As Integer = {10, 110, 1, 2, 7, 24, 88, 99, 12, 51}
    Dim precios() As Integer = {66, 255, 40, 99, 1999, 23, 72, 31, 84, 23}
    Dim contador As Integer = 0
    Dim contmed(10) As Integer
    Dim acummed(10) As Integer

    Structure Estructura
        Dim Medicamento As Integer
        Dim Farmacia As String
        Dim Cantidad As Integer
    End Structure
    Dim Paquete(25) As Estructura
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Dim sino As Boolean = False
        For i As Integer = 0 To 9
            If NumericUpDown1.Value = Medicamentos(i) Then
                sino = True
            End If
        Next

        If sino = False Then
            Label4.Visible = True
            Button1.Enabled = False
        Else
            Label4.Visible = False
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ReDim Preserve Paquete(contador + 1)
        contador += 1
        Paquete(contador).Medicamento = NumericUpDown1.Value
        Paquete(contador).Farmacia = TextBox1.Text
        Paquete(contador).Cantidad = NumericUpDown2.Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = False
        Button2.Enabled = False
        For i As Integer = 0 To contador
            Select Case Paquete(i).Medicamento
                Case 10
                    contmed(0) += 1
                    acummed(0) += Paquete(i).Cantidad
                Case 110
                    contmed(1) += 1
                    acummed(1) += Paquete(i).Cantidad
                Case 1
                    contmed(2) += 1
                    acummed(2) += Paquete(i).Cantidad
                Case 2
                    contmed(3) += 1
                    acummed(3) += Paquete(i).Cantidad
                Case 7
                    contmed(4) += 1
                    acummed(4) += Paquete(i).Cantidad
                Case 24
                    contmed(5) += 1
                    acummed(5) += Paquete(i).Cantidad
                Case 88
                    contmed(6) += 1
                    acummed(6) += Paquete(i).Cantidad
                Case 99
                    contmed(7) += 1
                    acummed(7) += Paquete(i).Cantidad
                Case 12
                    contmed(8) += 1
                    acummed(8) += Paquete(i).Cantidad
                Case 51
                    contmed(9) += 1
                    acummed(9) += Paquete(i).Cantidad
            End Select

        Next
        ListView1.Items.Add("Medicamentos totales: ")
        For i As Integer = 0 To 9
            Dim preciototal As Integer = acummed(i) * precios(i)
            ListView1.Items.Add("Cantidad del medicamento " & Medicamentos(i) & " " & acummed(i) & " Precio: " & preciototal)
        Next
        ListView1.Items.Add("Medicamentos individuales: ")

        For i As Integer = 0 To contador
            ListView1.Items.Add(Paquete(i).Farmacia + ": " & Paquete(i).Cantidad)
        Next

    End Sub

End Class
