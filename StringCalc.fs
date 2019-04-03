module StringCalc

open System
exception InvalidExpressionException of string 
let INVALID_EXRESSION_ERR_CODE = -1001

let StringCalc (expression : string) = 
    match expression.Length with 
    | 0 -> 0
    | _ ->
        try
            let numbers =  expression.Split(',') |> Seq.toList
            match List.filter (fun num -> Int16.TryParse num = (false, 0s)) numbers with
            | [] ->  
                match numbers.Length with 
                | 1 | 2 -> 
                    int(List.sumBy(fun num -> num.ToString() |> Convert.ToInt16) numbers)
                | _ ->
                    raise(InvalidExpressionException("Invalid Expression"))
            | _ -> raise(InvalidExpressionException("Invalid Expression"))                 
        with
        | InvalidExpressionException (msg) ->
            printfn "%s\n" msg
            INVALID_EXRESSION_ERR_CODE            
 