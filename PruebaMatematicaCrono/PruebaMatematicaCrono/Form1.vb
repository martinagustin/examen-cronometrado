Public Class Form1
    'denominamos variables con su respectivo tipo
    'creamos variable randomizer que pertenece al objeto Random
    Private randomizer As New Random
    Private addend1 As Integer
    Private addend2 As Integer
    Private minuend As Integer
    Private subtrahend As Integer
    Private multiplicand As Integer
    Private multiplier As Integer
    Private dividend As Integer
    Private divisor As Integer
    Private timeLeft As Integer



    Public Sub StartTheQuizz()
        ' Generate two random numbers to add.GENERA DOS NUMEROS ALEATORIOS PARA LA SUMA
        ' Store the values in the variables 'addend1' and 'addend2'.ALMACENA LOS VALORES EN LAS VARIABLES. ADDEND

        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)
        'la funcion next(n) de randomizer da numeros al azar desde 0 hasta n-1
        ' Convert the two randomly generated numbers|convierte los dos numero aleatorios en cadenas para que se puedan mostrar
        ' into strings so that they can be displayed
        ' in the label controls.
        plusLeftLabel.Text = addend1.ToString()
        plusRightLabel.Text = addend2.ToString()
        'relacionamos las variables addend con su respectivo label, ademas las convertimos en string para mostrarlas.

        ' 'sum' is the name of the NumericUpDown control.
        ' This step makes sure its value is zero before|suma es el name del primero numeric, esto aseguraque se inicie en valor 0
        ' adding any values to it.
        suma.Value = 0
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        minusLeftLabel.Text = minuend.ToString()
        minusRightLabel.Text = subtrahend.ToString()
        resta.Value = 0

        ' Fill in the multiplication problem.
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        timesLeftLabel.Text = multiplicand.ToString()
        timesRightLabel.Text = multiplier.ToString()
        producto.Value = 0

        ' Fill in the division problem.
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        dividedLeftLabel.Text = dividend.ToString()
        dividedRightLabel.Text = divisor.ToString()
        coeficiente.Value = 0
        'iniciar el timer
        timeLeft = 30
        timeLabel.Text = "30 seconds"
        Timer1.Start()

    End Sub
    Public Function CheckTheAnswer() As Boolean

        If addend1 + addend2 = suma.Value AndAlso
            minuend - subtrahend = resta.Value AndAlso
            multiplicand * multiplier = producto.Value AndAlso
            dividend / divisor = coeficiente.Value Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        'se llama al metodo startthequiz
        StartTheQuizz()
        startButton.Enabled = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CheckTheAnswer() Then
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Felicitaciones!")
            startButton.Enabled = True
        ElseIf timeLeft > 0 Then
            'si tiempo restante> 0 entonces
            ' Display the new time left\mostrar nuevo timepo restante
            ' by updating the Time Left label.\actualizar tiempo.
            timeLeft -= 1
            timeLabel.Text = timeLeft & " seconds"
        Else
            ' If the user ran out of time, stop the timer, show
            ' a MessageBox, and fill in the answers.
            'si se ha quedado sin tiempo, para el timer y muestra un mensaje y completa las respuestas.
            Timer1.Stop()
            timeLabel.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.| te has quedado sin tiempo", "Sorry!")
            suma.Value = addend1 + addend2
            resta.Value = minuend - subtrahend
            producto.Value = multiplicand * multiplier
            coeficiente.Value = dividend / divisor
            startButton.Enabled = True
        End If
    End Sub

    Private Sub answer_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles suma.Enter, resta.Enter, producto.Enter, coeficiente.Enter

        ' Select the whole answer in the NumericUpDown control.
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If

    End Sub
End Class
