Public Class ContextLayoutDesignButtons
    Private Sub CtlLayoutDesignFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadButtons_AllItems()

    End Sub

    Public Sub LoadButtons_AllItems()
        ''
        ''Added 9/8/2019 thomas downes   
        ''
        Dim each_menuItem As modLayoutDesignMenu.ClassDesignMenuItem

        modLayoutDesignMenu.InitializeListOfMenuItems(True)

        For Each each_menuItem In modLayoutDesignMenu.ListDesignMenuItems


        Next











    End Sub ''End of "Public Sub LoadButtons_AllItems()"


End Class
