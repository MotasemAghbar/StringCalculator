module Tests

open Expecto
open StringCalc
[<Tests>]
let tests =

  testList "Test Cases" [

    testCase "Invalid expression1" <| fun _ ->
      let subject = false
      let actual = StringCalc("invalid")
      Expect.equal actual -1001 "Invalid expression test fail"

    testCase "Invalid expression2" <| fun _ ->
      let subject = false
      let actual = StringCalc("a,7")
      Expect.equal actual -1001 "Invalid expression test fail"

    testCase "Empty string" <| fun _ ->
      let subject = false
      let actual = StringCalc("")
      Expect.equal actual 0 "Empty string test fail"

    testCase "One number string" <| fun _ ->
      let subject = false
      let actual = StringCalc("1")
      Expect.equal actual 1 "One number string test fail"    

    testCase "Add two numbers" <| fun _ ->
      let actual = StringCalc("1,2")
      Expect.equal actual 3 "Add two Numbers test fail"

    testCase "Unkown numbers test" <| fun _ ->
      let actual = StringCalc("1,2,5,50")
      Expect.equal actual 58 "Unkown numbers test test fail"

    testCase "Add multi numbers with new line delimiter" <| fun _ ->
      let actual = StringCalc("1\n2,5,7")
      Expect.equal actual 15 "add multi numbers with new line delimiter test fail"


    testCase "Add multi numbers with custom delimiters" <| fun _ ->
      let actual = StringCalc("//;\n1;2;7")
      Expect.equal actual 10 "Add Multi numbers With new line delimiter test fail"

    testCase "Negative numbers with custom delimiters" <| fun _ ->
      let actual = StringCalc("//;\n1;-2")
      Expect.equal actual -1002 "Negative numbers with custom delimiters Test Fail"
      
    testCase "Negative numbers" <| fun _ ->
      let actual = StringCalc("-1,2\n3")
      Expect.equal actual -1002 "Negative numbers test fail"    
  ]