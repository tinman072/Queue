Module Module1

    Public Structure qNode
        Dim DATA As String
        Dim PTR As String
    End Structure

    Public Structure Queue

        Const nullPTR = -1

        Dim frontPTR As Integer
        Dim backPTR As Integer

        Dim freelistPTR As Integer

        Dim q() As qNode

        Sub initialize()
            frontPTR = nullPTR
            backPTR = nullPTR

            freelistPTR = 0

            ReDim q(9)

            For i = 0 To 8
                q(i).DATA = ""
                q(i).PTR = i + 1
            Next

            q(9).DATA = ""
            q(9).PTR = nullPTR

        End Sub

        Sub joinQueue(ByVal dataItem As String)
            If freelistPTR = nullPTR Then
                Console.WriteLine("No more room in the Queue")
                Exit Sub
            End If

            Dim TNP As Integer
            TNP = freelistPTR
            q(TNP).DATA = dataItem
            freelistPTR = q(TNP).PTR

            If frontPTR = nullPTR And backPTR = nullPTR Then
                frontPTR = TNP
                backPTR = TNP
                q(TNP).PTR = nullPTR
                Exit Sub
            End If

            q(backPTR).PTR = TNP
            backPTR = q(backPTR).PTR
            q(TNP).PTR = nullPTR


        End Sub

        Sub leaveQueue()
            If frontPTR = nullPTR And backPTR = nullPTR Then
                Console.WriteLine("There are no nodes to remove in the list")
                Exit Sub
            End If

            If frontPTR = backPTR Then
                q(frontPTR).PTR = freelistPTR
                freelistPTR = frontPTR
                frontPTR = nullPTR
                backPTR = nullPTR
                Exit Sub
            End If

            Dim TNP As Integer = frontPTR
            frontPTR = q(frontPTR).PTR
            q(TNP).PTR = freelistPTR
            freelistPTR = TNP

        End Sub

        Sub printQueue()
            If frontPTR = nullPTR And backPTR = nullPTR Then
                Console.WriteLine("There are no nodes in the Queue")
                Exit Sub
            End If

            Dim TNP As Integer = frontPTR

            While TNP <> nullPTR
                Console.Write(q(TNP).DATA & " ")
                TNP = q(TNP).PTR
            End While

            Console.WriteLine("")
        End Sub
    End Structure

    Sub Main()

        Dim q As New Queue

        q.initialize()

        q.joinQueue("A")
        q.joinQueue("B")
        q.joinQueue("C")
        q.joinQueue("D")

        q.printQueue()

        q.leaveQueue()
        q.leaveQueue()

        q.printQueue()

        q.leaveQueue()
        q.leaveQueue()

        q.printQueue()

        q.joinQueue("W")
        q.joinQueue("X")
        q.joinQueue("Y")
        q.printQueue()

        q.leaveQueue()
        q.leaveQueue()

        q.printQueue()




    End Sub

End Module
