namespace myMathModels
open System

type myCalculations(input1 : decimal, input2 : decimal) = 
      member this.checks =       
          if input1 = 0m then 
              raise(ArgumentException("Please input values"))
          else input1

      member this.Subtraction  =
             input1 - input2

      member this.Addition = 
            input1 + input2

      member this.Multiplication (input3 :decimal) =
             (input1 * input2)/input3