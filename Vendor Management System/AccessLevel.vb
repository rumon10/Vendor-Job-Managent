Module AccessLevel
    Public operationType As String
    Public Enum status
        Insert
        Edit
        Delete
        View
        NewOrder
    End Enum

    Public Enum MessageIconUser
        Information
        Question
        Warning
        ErrorMessage
        None
    End Enum

    Public Enum MessageButtonUser
        Yes
        No
        YesNo
        Ok
        None
    End Enum



End Module
