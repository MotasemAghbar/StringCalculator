module StringCalc

open System

exception InvalidExpressionException of string 
let INVALID_EXRESSION_ERR_CODE = -1001

let add numbers : int = 
    try
        match List.filter (fun num -> Int16.TryParse num = (false, 0s)) numbers with
        | [] ->  
            int(List.sumBy(fun num -> num.ToString() |> Convert.ToInt16) numbers)
        | _ -> raise(InvalidExpressionException("Invalid Expression")) 
    with
    | InvalidExpressionException (msg) ->
        printfn "%s\n" msg
        INVALID_EXRESSION_ERR_CODE    

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