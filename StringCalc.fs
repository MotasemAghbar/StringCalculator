module StringCalc

open System

exception InvalidExpressionException of string 
exception NegativeNumbersException of string * int list

let INVALID_EXRESSION_ERR_CODE = -1001
let NEGATIVE_NUMBERS_ERR_CODE = -1002

let add numbers : int = 
    try
        match List.filter (fun num -> Int16.TryParse num = (false, 0s)) numbers with
        | [] ->  
            let intNumbersList = List.map ((fun num -> num.ToString() |> Convert.ToInt16) >> (int)) numbers
            match List.filter(fun num -> num < 0 ) intNumbersList with
            | [] -> 
                List.sum (List.filter(fun num -> num <= 1000) intNumbersList)
            | negativeNumbersList -> 
                raise(NegativeNumbersException("negatives not allowed", negativeNumbersList))
        | _ -> raise(InvalidExpressionException("Invalid Expression")) 
    with
    | InvalidExpressionException (msg) ->
        printfn "%s\n" msg
        INVALID_EXRESSION_ERR_CODE 
    | NegativeNumbersException (msg, negativeNumbers) ->
        printfn "%s %A\n" msg negativeNumbers
        NEGATIVE_NUMBERS_ERR_CODE        

let StringCalc (expression : string) = 
    match expression.Length with 
    | 0 -> 0
    | _ ->
        match expression.StartsWith "//" with
        | true -> 
            let delimiters = expression.Substring(2, expression.IndexOf('\n') - 2).ToCharArray()
            let numbers = expression.Substring(expression.IndexOf('\n') + 1)
            add(numbers.Split(delimiters, System.StringSplitOptions.None) |> Seq.toList)
        | false -> 
            add(expression.Split([|",";"\n"|], System.StringSplitOptions.None) |> Seq.toList)